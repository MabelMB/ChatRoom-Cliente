using ChatRoom;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;

//using Mysqlx;
//using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ChatRoom.STARTMENU;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ChatRoom
{
    public partial class Form2 : Form
    {
        //DECLARACION DE VARIABLES EXTRA -----------------------------------------------------------
        private STARTMENU _mainForm;
        private STARTMENU.ClientSocket cliente;
        private string connection = "server=127.0.0.1;uid=root;pwd=root;database=ChatRoom";
        int i = 0;
        int userid;
        int currentuserid;
        int currentsalaid;
        int salaid;

        private System.Windows.Forms.Timer timerActualizacion;
        private int salaActual = 0;
        private bool escuchandoMensajes = false;
        private Socket socketEscucha;


        //CONSTRUCTOR -----------------------------------------------------------
        public Form2(STARTMENU mainForm, STARTMENU.ClientSocket clienteExistente, int userId, string userName, string gruposData)
        {
            InitializeComponent();
            //gradient
            this.DoubleBuffered = true;
            //form management
            _mainForm = mainForm;
            cliente = clienteExistente;
            //user data load
            if (userName != "null")
            {
                MuestraUsuario(userName);
                MuestraGrupos(userId, gruposData);
                userid = userId;
            }
            InicializarConexionTiempoReal();
            timerActualizacion.Start();
        }

        //conexiones pa los usuarios
        private void InicializarConexionTiempoReal()
        {
            // Timer para verificar mensajes nuevos
            timerActualizacion = new System.Windows.Forms.Timer();
            timerActualizacion.Interval = 1000; // 1 segundo
            timerActualizacion.Tick += TimerActualizacion_Tick;
        }

        private async void TimerActualizacion_Tick(object sender, EventArgs e)
        {
            if (salaActual == 0) return;

            try
            {
                await VerificarMensajesNuevos();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DEBUG] Error en timer: {ex.Message}");
            }
        }

        private async Task VerificarMensajesNuevos()
        {
            if (salaActual == 0) return;

            try
            {
                using (Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                {
                    // Timeout más corto para mejor respuesta
                    clientSocket.SendTimeout = 1000;
                    clientSocket.ReceiveTimeout = 1000;

                    await Task.Run(() => clientSocket.Connect("127.0.0.1", 11200));

                    string solicitud = $"GET_NEW_MESSAGES|{salaActual}<EOF>";
                    byte[] requestBytes = Encoding.UTF8.GetBytes(solicitud);

                    await Task.Run(() => clientSocket.Send(requestBytes));

                    // Recibir respuesta
                    byte[] buffer = new byte[4096];
                    StringBuilder responseBuilder = new StringBuilder();

                    int bytesRec;
                    while ((bytesRec = await Task.Run(() => clientSocket.Receive(buffer))) > 0)
                    {
                        responseBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRec));
                        if (responseBuilder.ToString().Contains("<EOF>"))
                            break;
                    }

                    string respuesta = responseBuilder.ToString();

                    if (respuesta.Contains("NEW_MESSAGES|"))
                    {
                        this.Invoke(new Action(() => ProcesarMensajesNuevos(respuesta)));
                    }
                }
            }
            catch (Exception ex)
            {
                // Silenciar errores de timeout para no saturar la consola
                if (!ex.Message.Contains("timed out"))
                    Console.WriteLine($"[DEBUG] Error verificando mensajes: {ex.Message}");
            }
        }
        private void ProcesarMensajesNuevos(string data)
        {
            if (data.StartsWith("NEW_MESSAGES|"))
            {
                string contenido = data.Replace("NEW_MESSAGES|", "").Replace("<EOF>", "");
                string[] mensajes = contenido.Split(';');

                foreach (string mensaje in mensajes)
                {
                    if (!string.IsNullOrEmpty(mensaje))
                    {
                        string[] partes = mensaje.Split(':');
                        if (partes.Length >= 4)
                        {
                            string usuario = partes[1];
                            string texto = partes[2];
                            bool esPropio = usuario == usernamelabel.Text;

                            // Verificar si el mensaje ya existe para evitar duplicados
                            if (!MensajeYaExiste(usuario, texto))
                            {
                                AddNewMessage(usuario, texto, esPropio);
                            }
                        }
                    }
                }

                // Asegurar que el scroll esté al final después de agregar nuevos mensajes
                if (chatviewpanel.Controls.Count > 0)
                {
                    chatviewpanel.ScrollControlIntoView(chatviewpanel.Controls[chatviewpanel.Controls.Count - 1]);
                }
            }
        }

        private bool MensajeYaExiste(string usuario, string texto)
        {
            // Verificación simple para evitar mensajes duplicados
            foreach (Control control in chatviewpanel.Controls)
            {
                if (control is Panel panel)
                {
                    foreach (Control subControl in panel.Controls)
                    {
                        if (subControl is FlowLayoutPanel layout)
                        {
                            foreach (Control label in layout.Controls)
                            {
                                if (label is Label lbl && lbl.Text.Contains(texto))
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        //DISEÑO -----------------------------------------------------------
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle rect = this.ClientRectangle;
            using (LinearGradientBrush brush = new LinearGradientBrush(rect, Color.Empty, Color.Empty, 315f))
            {
                ColorBlend blend = new ColorBlend();
                blend.Positions = new float[] { 0.0f, 0.11f, 0.29f, 0.56f, 1.0f };
                blend.Colors = new Color[]
                {
                    ColorTranslator.FromHtml("#4E95D9"),
                    ColorTranslator.FromHtml("#4E95D9"),
                    ColorTranslator.FromHtml("#83CBEB"),
                    ColorTranslator.FromHtml("#4E95D9"),
                    ColorTranslator.FromHtml("#4E95D9")
                };

                brush.InterpolationColors = blend;
                e.Graphics.FillRectangle(brush, rect);
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            //fullscreen controls
            //this.TopMost = true;
            //this.WindowState = FormWindowState.Maximized;
            //this.FormBorderStyle = FormBorderStyle.None;

            chatLayout.Visible = false;
            chooseagroup.Visible = true;
            groupconfigpanel.Visible = false;
            chooseagroup.BringToFront();
            creategrouppanel.Visible = false;
            confirmationpanel.Visible = false;
            freezescreenpanel.Visible = false;
        }



        //EVENTOS BOTONES -----------------------------------------------------------
        private void closesession_Click(object sender, EventArgs e) //Cerrar sesión
        {
            STARTMENU menu = new STARTMENU();
            menu.Show();
            this.Close();
        }
        private void configbutton_Click(object sender, EventArgs e)
        {
            

            chatLayout.Visible = false;
            chooseagroup.Visible = false;
            groupconfigpanel.Visible = true;
            groupconfigpanel.BringToFront();
            creategrouppanel.Visible = false;
        }
        private void backbutton_Click(object sender, EventArgs e)
        {
            chatLayout.Visible = true;
            chatLayout.BringToFront();
            chooseagroup.Visible = false;
            groupconfigpanel.Visible = false;
            creategrouppanel.Visible = false;
        }
        private void creategroupback_Click(object sender, EventArgs e)
        {
            if(currentuserid != 0)
            {
                chatLayout.Visible = true;
                chooseagroup.Visible = false;
                chatLayout.BringToFront();
                groupconfigpanel.Visible = false;
                creategrouppanel.Visible = false;
            }
            chatLayout.Visible = false;
            chooseagroup.Visible = true;
            chooseagroup.BringToFront();
            groupconfigpanel.Visible = false;
            creategrouppanel.Visible = false;
        }
        private void creategroup_Click(object sender, EventArgs e)
        {
            chatLayout.Visible = true;
            chooseagroup.Visible = false;
            groupconfigpanel.Visible = false;
            chatLayout.BringToFront();
            creategrouppanel.Visible = false;

            if (string.IsNullOrWhiteSpace(groupnametextbox.Text))
            {
                MessageBox.Show("El nombre del grupo es obligatorio");
                return;
            }

            int id = userid;

            string nombreGrupo = groupnametextbox.Text;
            string descripcionGrupo = string.IsNullOrWhiteSpace(groupdesctextbox.Text) ?
                "Sin descripción" : groupdesctextbox.Text;
            string usuariosTexto = textBox1.Text;
            {
                ClientSocket clienteTemporal = new ClientSocket();
                string respuesta = clienteTemporal.EnviarCrearGrupo(
                usernamelabel.Text,
                userid,
                nombreGrupo,
                descripcionGrupo,
                usuariosTexto
            );

                if (respuesta.Contains("GROUP_CREATED|"))
                {
                    string[] partes = respuesta.Split('|');
                    int idSalaCreada = int.Parse(partes[1]);

                    currentsalaid = idSalaCreada;
                    AddNewGroup(nombreGrupo, descripcionGrupo, idSalaCreada, true);
                }
            }
        }
            

        //EVENTOS TEXTBOX -----------------------------------------------------------
        private void usernamelabel_Click_2(object sender, EventArgs e)
        {
            chatLayout.Visible = true;
            chatLayout.BringToFront();
            chooseagroup.Visible = false;
            groupconfigpanel.Visible = false;
            creategrouppanel.Visible = false;
        }



        //PANEL DE GRUPOS -----------------------------------------------------------
        //Functions ********
        private void AddNewGroup(String grouptitletext, String groupdescriptiontext, int id, bool usergroup)
        {
            // Crear un nuevo panel
            Panel panel = new Panel();
            panel.AutoSize = false;
            //panel.Width = groupViewPanel.ClientSize.Width - groupViewPanel.Padding.Horizontal - SystemInformation.VerticalScrollBarWidth;
            panel.Width = groupViewPanel.ClientSize.Width - SystemInformation.VerticalScrollBarWidth - 25;
            panel.Height = 50;
            panel.BackColor = Color.White;
            panel.Padding = new Padding(5);
            panel.Tag = id;
            panel.Dock = DockStyle.Top;

            
            Label GROUPTITLE = new Label();
            GROUPTITLE.Text = grouptitletext;
            GROUPTITLE.AutoSize = true;
            GROUPTITLE.Dock = DockStyle.Top;
            GROUPTITLE.Width = panel.Width;
            GROUPTITLE.Location = new Point(0, 0);
            GROUPTITLE.Font = new Font("Myriad Apple", 11, FontStyle.Regular);

            Label GROPUDESCRIPTION = new Label();
            GROPUDESCRIPTION.Text = groupdescriptiontext;
            GROPUDESCRIPTION.AutoSize = true;
            GROPUDESCRIPTION.Width = panel.Width;
            GROPUDESCRIPTION.Dock = DockStyle.Bottom;
            GROPUDESCRIPTION.Location = new Point(0, 50);
            GROPUDESCRIPTION.Font = new Font("Myriad Apple", 8, FontStyle.Italic);

            // Agregar evento para eliminar el panel
            panel.Click += panel_Click;
            foreach (Control c in panel.Controls)
            {
                c.Click += panel_Click;
            }

            // Agregar controles al panel
            panel.Controls.Add(GROUPTITLE);
            panel.Controls.Add(GROPUDESCRIPTION);

            // Agregar el panel al FlowLayoutPanel
            groupViewPanel.Controls.Add(panel);
            if (usergroup == true)
            {
                groupViewPanel.Controls.SetChildIndex(panel, 1);
            }
            
        }
        private void panel_Click(object sender, EventArgs e)
        {
            Panel p = sender as Panel;
            int id = (int)p.Tag;
            currentuserid = id;
            salaid = (int)p.Tag;
            salaActual = id; // ¡IMPORTANTE! Actualizar la sala actual

            foreach (Control control in p.Controls)
            {
                if (control is Label label)
                {
                    if (!label.Text.Contains("id:"))
                    {
                        groputitlelabel.Text = label.Text;
                        break;
                    }
                }
            }

            cargaMensajes(id);
            muestraMiembros(id);

            chatLayout.Visible = true;
            chatLayout.BringToFront();
            chooseagroup.Visible = false;
            groupconfigpanel.Visible = false;
            creategrouppanel.Visible = false;

            // Reiniciar el timer cuando cambias de sala
            timerActualizacion?.Stop();
            timerActualizacion?.Start();
        }

        //Buttons ********

        private void creategroupbutton_Click(object sender, EventArgs e)
        {
            chatLayout.Visible = false;
            chooseagroup.Visible = false;
            groupconfigpanel.Visible = false;
            creategrouppanel.Visible = true;
            creategroup.BringToFront();
        }
        private void confirmaccept_Click(object sender, EventArgs e)
        {
            
        }
        private void delgroupbutton_Click(object sender, EventArgs e)
        {
            int idSala = salaid;

            try
            {
                
                string respuesta = cliente.EnviarEliminarGrupo(idSala, userid);
                
                if (respuesta.Contains("DELETE_EXITOSO"))
                {
                    foreach (Control ctrl in groupViewPanel.Controls)
                    {
                        if (ctrl.Tag is int id && id == idSala)
                        {
                            groupViewPanel.Controls.Remove(ctrl);
                            ctrl.Dispose();
                            break;
                        }
                    }

                    MessageBox.Show("Grupo eliminado exitosamente");
                }
                else
                {
                    MessageBox.Show("Error al eliminar el grupo: " + respuesta);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                return;
            }

            freezescreenpanel.Visible = false;
            confirmationpanel.Visible = false;
            mainLayout.BringToFront();
            chatLayout.Visible = false;
            chooseagroup.Visible = true;
            groupconfigpanel.Visible = false;
            chooseagroup.BringToFront();
            creategrouppanel.Visible = false;
        }
        private void tempaddchatmsg_Click(object sender, EventArgs e)
        {
            //AddNewMessage("Alexis", tempmsgtextbox.Text, tempusercheck.Checked ? true : false);
            //IMPORTANT -+-+-+-+-+-+-*_*_*_*_*_+-+-+-+-+_*_*_*_*_*-+-+-+-+_**_*_*-+
            string mensaje = tempmsgtextbox.Text.Trim();
            if (string.IsNullOrEmpty(mensaje) || salaid == 0) return;

            try
            {
                ClientSocket clienteTemporal = new ClientSocket();
                string respuesta = clienteTemporal.EnviarMensajeNuevo(salaid, userid, mensaje);

                if (respuesta.Contains("MESSAGE_SENT|"))
                {
                    string mensajeLimpio = respuesta.Replace("<EOF>", "");
                    string[] partes = mensajeLimpio.Split('|');
                    string mensajeEmoji = partes[1];
                    AddNewMessage(usernamelabel.Text, mensajeEmoji, true);
                    tempmsgtextbox.Clear();
                }
                else
                {
                    MessageBox.Show("Error al enviar mensaje");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private void confirmcancel_Click(object sender, EventArgs e)
        {
            freezescreenpanel.Visible = false;
            confirmationpanel.Visible = false;
            mainLayout.BringToFront();
            chatLayout.Visible = false;
            chooseagroup.Visible = false;
            groupconfigpanel.Visible = true;
            groupconfigpanel.BringToFront();
            creategrouppanel.Visible = false;
        }

        //Other ********
        private void label1_Click(object sender, EventArgs e)
        {

        }


        //CARGA DE DATOS DEL USUARIO -----------------------------------------------------------

        //Carga del nombre de usuario
        private void MuestraUsuario(string username)
        {

            this.usernamelabel.Text = username;

        }

        //Carga de los grupos del usuario
        private void MuestraGrupos(int userid, string gruposData)
        {
            string[] grupos = gruposData.Split(';');
            foreach (string grupo in grupos)
            {
                if (!string.IsNullOrEmpty(grupo))
                {
                    string[] datosGrupo = grupo.Split(':');
                    int idGrupo = int.Parse(datosGrupo[0]);
                    string nombreGrupo = datosGrupo[1];
                    string descripcionGrupo = datosGrupo[2];
                    string rol = datosGrupo[3]; // "admin" o "miembro"

                    bool esCreador = (rol == "admin");
                    AddNewGroup(nombreGrupo, descripcionGrupo, idGrupo, esCreador);
                }
            }
        }
        //Carga de los miembros del grupo
        private async void muestraMiembros(int salaid)
        {
            try
            {
                
                await Task.Run(() => CargarMiembrosAsync(salaid));
            }
            catch (Exception ex)
            {
                groupmemberslabel.Text = $"Error: {ex.Message}";
            }
        }

        private void CargarMiembrosAsync(int salaid)
        {
            try
            {
                using (Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                {
                    // Configurar timeout
                    clientSocket.SendTimeout = 5000;
                    clientSocket.ReceiveTimeout = 5000;

                    clientSocket.Connect("127.0.0.1", 11200);

                    // SOLICITUD DE MIEMBROS
                    string solicitud = $"GET_MEMBERS|{salaid}<EOF>";
                    byte[] requestBytes = Encoding.UTF8.GetBytes(solicitud);

                    clientSocket.Send(requestBytes);

                    // Recibir respuesta
                    byte[] buffer = new byte[4096];
                    StringBuilder responseBuilder = new StringBuilder();

                    int bytesRec;
                    while ((bytesRec = clientSocket.Receive(buffer)) > 0)
                    {
                        responseBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRec));
                        if (responseBuilder.ToString().Contains("<EOF>"))
                            break;
                    }

                    string data = responseBuilder.ToString();

                    // Procesar en UI thread
                    this.Invoke(new Action(() => ProcesarMiembros(data)));
                }
            }
            catch (Exception ex)
            {
                this.Invoke(new Action(() =>
                {
                    groupmemberslabel.Text = $"Error: {ex.Message}";
                }));
            }
        }


        private void ProcesarMiembros(string data)
        {
            try
            {
                // Limpiar el marcador <EOF>
                string dataLimpia = data.Replace("<EOF>", "");

                // Formato esperado: "MEMBERS_DATA|1|ana;pedro;carlos"
                if (dataLimpia.Contains("MEMBERS_DATA|"))
                {
                    string[] partes = dataLimpia.Split('|');
                    int salaId = int.Parse(partes[1]);
                    string miembrosData = partes[2];
                    string[] miembros = miembrosData.Split(';');
                    groupmemberslabel.Text = string.Join(", ", miembros);
                }
                else if (dataLimpia.Contains("ERROR|"))
                {
                    groupmemberslabel.Text = "Error cargando miembros";
                }
            }
            catch (Exception ex)
            {
                groupmemberslabel.Text = $"Error procesando: {ex.Message}";
            }
        }



        private void AddNewMessage(string username, string message, bool usergroup)
        {
            // Main message panel
            Panel panel = new Panel();
            panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel.Width = chatviewpanel.ClientSize.Width - SystemInformation.VerticalScrollBarWidth;
            panel.Anchor = AnchorStyles.Left | AnchorStyles.Right; // Cambio importante
            panel.BackColor = usergroup ? Color.LightBlue : Color.LightGray; // Para distinguir mensajes propios
            panel.Padding = new Padding(4);
            panel.MaximumSize = new Size(chatviewpanel.ClientSize.Width - SystemInformation.VerticalScrollBarWidth, 0);
            panel.Dock = DockStyle.Top; // Cambio crucial - esto asegura el orden correcto
            panel.AutoSize = true;

            // Flow layout for horizontal alignment
            FlowLayoutPanel layout = new FlowLayoutPanel();
            layout.WrapContents = false;
            layout.AutoSize = true;
            layout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            layout.FlowDirection = FlowDirection.LeftToRight;
            layout.Dock = DockStyle.Fill;
            layout.Padding = new Padding(0);
            layout.Margin = new Padding(0);

            // Profile image
            PictureBox profilePic = new PictureBox();
            profilePic.Image = usergroup ? Properties.Resources.image_removebg_preview__2_ : Properties.Resources.image_removebg_preview__1_;
            profilePic.SizeMode = PictureBoxSizeMode.Zoom;
            profilePic.Size = new Size(23, 23);
            profilePic.Margin = new Padding(0, 0, 4, 0);

            // Username label
            Label usernameLabel = new Label();
            usernameLabel.Text = usergroup ? username + " (Tú)" : username;
            usernameLabel.Font = new Font("Myriad Apple", 9, FontStyle.Bold);
            usernameLabel.ForeColor = usergroup ? Color.Blue : Color.Black;
            usernameLabel.AutoSize = true;
            usernameLabel.Margin = new Padding(0, 3, 4, 0);

            Control messageControl = CrearControlConMenciones(message, usergroup, currentuserid);
            messageControl.MaximumSize = new Size(panel.MaximumSize.Width - 150, 0);
            messageControl.Margin = new Padding(0, 3, 0, 0);

            // Add controls to layout
            layout.Controls.Add(profilePic);
            layout.Controls.Add(usernameLabel);
            layout.Controls.Add(messageControl);

            panel.Controls.Add(layout);

            
            chatviewpanel.SuspendLayout(); // Pausar el layout temporalmente

            // Agregar al FINAL de los controles
            chatviewpanel.Controls.Add(panel);

            // Forzar que el nuevo panel esté al final
            chatviewpanel.Controls.SetChildIndex(panel, chatviewpanel.Controls.Count - 1);

            chatviewpanel.ResumeLayout(); // Reanudar el layout

            // Scroll al final
            chatviewpanel.ScrollControlIntoView(panel);

            // Esto asegura que el scroll se mantenga al final
            Application.DoEvents(); // Procesar eventos pendientes
            //chatviewpanel.VerticalScroll.Value = chatviewpanel.VerticalScroll.Maximum;
        }

        private Control CrearControlConMenciones(string texto, bool esUsuarioActual, int salaId)
        {
            List<string> partes = new List<string>();
            int inicio = 0;

            for (int i = 0; i < texto.Length; i++)
            {
                if (texto[i] == '@' && (i == 0 || texto[i - 1] == ' '))
                {
                    if (i > inicio)
                    {
                        partes.Add(texto.Substring(inicio, i - inicio));
                    }

                    int finMencion = i + 1;
                    while (finMencion < texto.Length && texto[finMencion] != ' ' && texto[finMencion] != '\n')
                    {
                        finMencion++;
                    }

                    string mencion = texto.Substring(i, finMencion - i);
                    partes.Add(mencion);
                    inicio = finMencion;
                    i = finMencion - 1;
                }
            }

            if (inicio < texto.Length)
            {
                partes.Add(texto.Substring(inicio));
            }

            if (partes.Count == 1)
            {
                Label labelSimple = new Label();
                labelSimple.Text = texto;
                labelSimple.Font = new Font("Segoe UI", 9);
                labelSimple.ForeColor = Color.Black;
                labelSimple.AutoSize = true;
                labelSimple.Margin = new Padding(0, 8, 0, 0);
                return labelSimple;
            }

            FlowLayoutPanel panelContenedor = new FlowLayoutPanel();
            panelContenedor.FlowDirection = FlowDirection.LeftToRight;
            panelContenedor.AutoSize = true;
            panelContenedor.WrapContents = true;
            panelContenedor.MaximumSize = new Size(chatviewpanel.ClientSize.Width / 2, 0);
            panelContenedor.Margin = new Padding(0, 8, 0, 0);

            foreach (string parte in partes)
            {
                if (parte.StartsWith("@"))
                {
                    string nombreUsuario = parte.TrimStart('@');
                    bool usuarioExiste = UsuarioExisteEnGrupo(nombreUsuario, salaId);

                    Label lblMencion = new Label();
                    lblMencion.Text = parte;

                    if (usuarioExiste)
                    {
                        lblMencion.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                        lblMencion.ForeColor = Color.DarkBlue;
                        lblMencion.BackColor = Color.LightYellow;
                    }
                    else
                    {
                        lblMencion.Font = new Font("Segoe UI", 9);
                        lblMencion.ForeColor = Color.Gray;
                        lblMencion.BackColor = Color.LightGray;
                    }

                    lblMencion.AutoSize = true;
                    lblMencion.Padding = new Padding(2, 1, 2, 1);
                    lblMencion.Margin = new Padding(0, 0, 2, 0);
                    panelContenedor.Controls.Add(lblMencion);
                }
                else
                {
                    Label lblNormal = new Label();
                    lblNormal.Text = parte;
                    lblNormal.Font = new Font("Segoe UI", 9);
                    lblNormal.ForeColor = Color.Black;
                    lblNormal.AutoSize = true;
                    lblNormal.Margin = new Padding(0);
                    panelContenedor.Controls.Add(lblNormal);
                }
            }

            return panelContenedor;
        }

        //Carga de mensajes
        private async void cargaMensajes(int salaid)
        {
            try
            {
                chatviewpanel.Controls.Clear();

                timerActualizacion?.Stop();
                // Mostrar mensaje de carga
                Label loadingLabel = new Label();
                loadingLabel.Text = "Cargando mensajes...";
                loadingLabel.AutoSize = true;
                chatviewpanel.Controls.Add(loadingLabel);

                await Task.Run(() => CargarMensajesAsync(salaid));
                timerActualizacion?.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            timerActualizacion?.Stop();
            timerActualizacion?.Dispose();
            base.OnFormClosing(e);
        }

        private void CargarMensajesAsync(int salaid)
        {
            try
            {
                using (Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                {
                    // Configurar timeout
                    clientSocket.SendTimeout = 5000;
                    clientSocket.ReceiveTimeout = 5000;

                    clientSocket.Connect("127.0.0.1", 11200);

                    string solicitud = $"GET_RECENT_MESSAGES|{salaid}<EOF>";
                    byte[] requestBytes = Encoding.UTF8.GetBytes(solicitud);

                    clientSocket.Send(requestBytes);

                    // Recibir respuesta
                    byte[] buffer = new byte[4096];
                    StringBuilder responseBuilder = new StringBuilder();

                    int bytesRec;
                    while ((bytesRec = clientSocket.Receive(buffer)) > 0)
                    {
                        responseBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRec));
                        if (responseBuilder.ToString().Contains("<EOF>"))
                            break;
                    }

                    string data = responseBuilder.ToString();

                    // Procesar en UI thread
                    this.Invoke(new Action(() => ProcesarMensajes(data)));

                    clientSocket.Shutdown(SocketShutdown.Both);
                }
            }
            catch (Exception ex)
            {
                this.Invoke(new Action(() =>
                {
                    chatviewpanel.Controls.Clear();
                    Label errorLabel = new Label() { Text = $"Error: {ex.Message}", AutoSize = true };
                    chatviewpanel.Controls.Add(errorLabel);
                }));
            }
        }

        private void ProcesarMensajes(string data)
        {
            chatviewpanel.Controls.Clear();

            if (data.StartsWith("RECENT_MESSAGES|"))
            {
                string contenido = data.Replace("RECENT_MESSAGES|", "").Replace("<EOF>", "");

                if (string.IsNullOrEmpty(contenido))
                {
                    Label noMessages = new Label() { Text = "No hay mensajes en este grupo", AutoSize = true };
                    chatviewpanel.Controls.Add(noMessages);
                    return;
                }

                string[] mensajes = contenido.Split(';');

                foreach (string mensaje in mensajes)
                {
                    if (!string.IsNullOrEmpty(mensaje))
                    {
                        string[] partes = mensaje.Split(':');
                        if (partes.Length >= 4)
                        {
                            string usuario = partes[1];
                            string texto = partes[2];
                            bool esPropio = usuario == usernamelabel.Text;
                            AddNewMessage(usuario, texto, esPropio);
                        }
                    }
                }
            }
            else
            {
                Label errorLabel = new Label() { Text = "Error al cargar mensajes", AutoSize = true };
                chatviewpanel.Controls.Add(errorLabel);
            }
        }


        //private void MandarMensajeBD(string mensaje)
        //{
        //    if (string.IsNullOrWhiteSpace(mensaje) || currentuserid == 0)
        //        return;

        //    try
        //    {
        //        using (MySqlConnection conn = new MySqlConnection(connection))
        //        {
        //            conn.Open();
        //            string query = "INSERT INTO mensajes (id_usuario, id_sala, mensajes, fecha_envio) VALUES (@usuario, @sala, @mensaje, @fecha)";
        //            using (MySqlCommand cmd = new MySqlCommand(query, conn))
        //            {
        //                cmd.Parameters.AddWithValue("@usuario", userid);
        //                cmd.Parameters.AddWithValue("@sala", currentuserid);
        //                cmd.Parameters.AddWithValue("@mensaje", mensaje);
        //                cmd.Parameters.AddWithValue("@fecha", DateTime.Now);
        //                cmd.ExecuteNonQuery();
        //            }
        //        }

        //        string mensajeConEmojis = EmojiHelper.ConvertEmojis(mensaje);
        //        AddNewMessage(usernamelabel.Text, mensajeConEmojis, true);

        //        tempmsgtextbox.Clear();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al enviar el mensaje: " + ex.Message);
        //    }
        //}
        private bool UsuarioExisteEnGrupo(string nombreUsuario, int salaId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connection))
                {
                    conn.Open();
                    string query = @"
                SELECT COUNT(*) 
                FROM miembros_sala ms 
                INNER JOIN usuarios u ON ms.id_usuario = u.id_usuario 
                WHERE u.nombre_usuario = @usuario AND ms.id_sala = @sala";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@usuario", nombreUsuario.TrimStart('@'));
                    cmd.Parameters.AddWithValue("@sala", salaId);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
            catch
            {
                return false;
            }
        }



        //IMPLEMENTACION DE EMOJIS -----------------------------------------------------------
        public static class EmojiHelper
        {
            private static Dictionary<string, string> emojiMap = new Dictionary<string, string>()
            {
                {  ":)", "😊"},
                { ":D", "😄" },
                { ":(", "☹️" },
                { ";)", "😉" },
                { ":P", "😛" },
                { ":O", "😲" },
                { ":'(", "😢" },
                { ":|", "😐" },
                { ":*", "😘" },
                { "<3", "❤️"  },
                { ":fire:","🔥"},
                { ":thumbsup:", "👍" },
                { ":thumbsdown:", "👎" },
                { ":ok_hand:", "👌" },
                { ":clap:", "👏" },
                { ":wave:", "👋" }
            };

            public static string ConvertEmojis(string text)
            {
                if (string.IsNullOrEmpty(text))
                    return text;

                string result = text;
                foreach (var emoji in emojiMap)
                {
                    result = result.Replace(emoji.Key, emoji.Value);
                }
                return result;
            }
        }
        


        //CARGA DE LAYOUTS Y PANELS -----------------------------------------------------------
        private void chatviewpanel_Paint(object sender, PaintEventArgs e)
        {
            chatviewpanel.AutoScroll = true;
            chatviewpanel.WrapContents = false;
            chatviewpanel.FlowDirection = FlowDirection.TopDown;
            chatviewpanel.AutoSize = true;
            chatviewpanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            chatviewpanel.HorizontalScroll.Visible = false;
            chatviewpanel.HorizontalScroll.Maximum = 0;
            chatviewpanel.Padding = new Padding(10);
            //chatviewpanel.BackColor = Color.LightBlue; // your chat background


        }
        private void groupconfigpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void gropuLayout_Paint(object sender, PaintEventArgs e)
        {

        }
        private void groupviewpanel_Paint(object sender, PaintEventArgs e)
        {

        }
        private void chatTextPanel_Paint(object sender, PaintEventArgs e)
        {

        }
        private void grouptitlepanel_Click(object sender, EventArgs e)
        {

        }

        private void othereditgroup_Paint(object sender, PaintEventArgs e)
        {

        }



        //TEMPORAL / ACCIDENTAL CLICKS-----------------------------------------------------------
        private void groupslabel_Click(object sender, EventArgs e)
        {

        }
        private void groupViewPanel_Paint_1(object sender, PaintEventArgs e)
        {

        }
        private void groupmemberslabel_Click(object sender, EventArgs e)
        {

        }
        private void tempmsgtextbox_TextChanged_1(object sender, EventArgs e)
        {

        }
        private void chatLayout_Paint(object sender, PaintEventArgs e)
        {

        }
        private void chooseagroup_Click(object sender, EventArgs e)
        {

        }
        private void label4_Click_1(object sender, EventArgs e)
        {

        }
        private void confirmationpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                string[] usuarios = textBox1.Text.Split(',');
                foreach (string usuario in usuarios)
                {
                    string usuarioLimpio = usuario.Trim();
                    if (!string.IsNullOrWhiteSpace(usuarioLimpio))
                    {
                        //agregaMiembroLista(usuarioLimpio, currentsalaid, "miembro");
                    }
                }
            }
        }
    }
}
