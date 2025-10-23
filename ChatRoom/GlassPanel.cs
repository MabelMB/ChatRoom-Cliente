using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public class GlassPanel : Panel
{
    // === Native Windows API (for real blur) ===
    [DllImport("dwmapi.dll")]
    private static extern int DwmEnableBlurBehindWindow(IntPtr hWnd, ref DWM_BLURBEHIND pBlurBehind);

    [StructLayout(LayoutKind.Sequential)]
    private struct DWM_BLURBEHIND
    {
        public uint dwFlags;
        public bool fEnable;
        public IntPtr hRgnBlur;
        public bool fTransitionOnMaximized;
    }

    private const uint DWM_BB_ENABLE = 0x00000001;

    // === Properties ===
    public bool EnableBlur { get; set; } = true;
    public Color OverlayColor { get; set; } = Color.FromArgb(100, 255, 255, 255);
    public int BorderRadius { get; set; } = 20;
    public bool DrawBorder { get; set; } = true;

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);
        TryEnableBlur();
    }

    private void TryEnableBlur()
    {
        if (!EnableBlur)
            return;

        try
        {
            DWM_BLURBEHIND blur = new DWM_BLURBEHIND
            {
                dwFlags = DWM_BB_ENABLE,
                fEnable = true,
                hRgnBlur = IntPtr.Zero,
                fTransitionOnMaximized = false
            };
            DwmEnableBlurBehindWindow(this.Handle, ref blur);
        }
        catch
        {
            // Ignore if DWM not supported
        }
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
        base.OnPaintBackground(e);

        // Draw translucent "frosted glass" overlay
        using (GraphicsPath path = RoundedRect(ClientRectangle, BorderRadius))
        using (SolidBrush overlay = new SolidBrush(OverlayColor))
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.FillPath(overlay, path);

            if (DrawBorder)
            {
                using (Pen border = new Pen(Color.FromArgb(120, 255, 255, 255), 1.5f))
                {
                    e.Graphics.DrawPath(border, path);
                }
            }
        }
    }

    private GraphicsPath RoundedRect(Rectangle bounds, int radius)
    {
        int diameter = radius * 2;
        Size size = new Size(diameter, diameter);
        Rectangle arc = new Rectangle(bounds.Location, size);
        GraphicsPath path = new GraphicsPath();

        if (radius == 0)
        {
            path.AddRectangle(bounds);
            return path;
        }

        // top left
        path.AddArc(arc, 180, 90);

        // top right
        arc.X = bounds.Right - diameter;
        path.AddArc(arc, 270, 90);

        // bottom right
        arc.Y = bounds.Bottom - diameter;
        path.AddArc(arc, 0, 90);

        // bottom left
        arc.X = bounds.Left;
        path.AddArc(arc, 90, 90);

        path.CloseFigure();
        return path;
    }
}
