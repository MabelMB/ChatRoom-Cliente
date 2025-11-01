using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ChatRoom
{
    public partial class STARTMENU : Form
    {
        //DECLARACION DE VARIABLES EXTRA -----------------------------------------------------------
        //Form f = null;
        private string connection = "server=127.0.0.1;uid=root;pwd=root;database=ChatRoom";
        private ClientSocket cliente;
        int usuarioId;
        string nombreUsuario;

        public STARTMENU()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            cliente = new ClientSocket();
            
        }

        public class ClientSocket
        {
            private Socket socket;

            public string EnviarLogin(string username, string password)
            {
                if (socket != null)
                {
                    socket.Close();
                    socket = null;
                }

                Conectar();

                string eventoLogin = $"LOGIN|{username}|{password}";
                string respuesta = Client(eventoLogin);
                //MessageBox.Show(respuesta);
                return respuesta;

            }
            public string Client(string evento)
            {
                byte[] msg = Encoding.UTF8.GetBytes(evento + "<EOF>");
                int bytesSent = socket.Send(msg);

                byte[] bytes = new byte[1024];
                int byteRec = socket.Receive(bytes);

                string texto = Encoding.UTF8.GetString(bytes, 0, byteRec);
                return texto;
            }

            public void Conectar()
            {

                IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11200);

                try
                {
                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                    socket.Connect(remoteEP);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }

            public string EnviarRegistro(string username, string password)
            {
                if (socket == null || !socket.Connected)
                {
                    Conectar();
                }

                string eventoRegistro = $"REGISTER|{username}|{password}";
                string respuesta = Client(eventoRegistro);
                return respuesta;
            }

            public string EnviarHistorial(string username, int userid)
            {
                if (socket == null || !socket.Connected)
                {
                    Conectar();
                }

                string eventoRegistro = $"RECENTS|{username}|{userid}";
                string respuesta = Client(eventoRegistro);
                return respuesta;
            }

        }


        //DISEÑO -----------------------------------------------------------
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle rect = this.ClientRectangle;

            // Create a 315° linear gradient brush
            using (LinearGradientBrush brush = new LinearGradientBrush(rect, Color.Empty, Color.Empty, 315f))
            {
                ColorBlend blend = new ColorBlend();

                // 👇 Must start at 0.0 and end at 1.0
                blend.Positions = new float[] { 0.0f, 0.11f, 0.29f, 0.56f, 1.0f };
                blend.Colors = new Color[]
                {
                    ColorTranslator.FromHtml("#4E95D9"), // start
                    ColorTranslator.FromHtml("#4E95D9"), // at 11%
                    ColorTranslator.FromHtml("#83CBEB"), // at 29%
                    ColorTranslator.FromHtml("#4E95D9"), // at 56%
                    ColorTranslator.FromHtml("#4E95D9")  // end
                };

                brush.InterpolationColors = blend;
                e.Graphics.FillRectangle(brush, rect);
            }
        }
        private void Inicio_Load(object sender, EventArgs e)
        {
            //this.TopMost = true;
            //this.WindowState = FormWindowState.Maximized;
            //this.FormBorderStyle = FormBorderStyle.None;

            startmenulayout.Visible = true;
            loginmenulayout.Visible = false;
            registermenulayout.Visible = false;

        }

        private void ConfigurarBotonRedondo(Button boton, int radio)
        {
            boton.Paint += new PaintEventHandler(Boton_Paint);
            boton.Tag = radio;
        }

        //Aplicar el dibujo a un botón
        private void Boton_Paint(object sender, PaintEventArgs e)
        {
            Button botonActual = (Button)sender;
            int radio = (int)botonActual.Tag;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            System.Drawing.Drawing2D.GraphicsPath path = CrearPathRedondeado(botonActual.Width, botonActual.Height, radio);
            botonActual.Region = new System.Drawing.Region(path);
        }

        //Diseñar y dibujar el redondeado
        private System.Drawing.Drawing2D.GraphicsPath CrearPathRedondeado(int ancho, int alto, int radio)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();

            path.AddArc(0, 0, radio, radio, 180, 90);
            path.AddArc(ancho - radio, 0, radio, radio, 270, 90);
            path.AddArc(ancho - radio, alto - radio, radio, radio, 0, 90);
            path.AddArc(0, alto - radio, radio, radio, 90, 90);
            path.CloseFigure();

            return path;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //EVENTOS BOTONES -----------------------------------------------------------
        //Menu principal ***************
        //iniciar sesión
        private void loginButton_Click(object sender, EventArgs e)
        {
            loginmenulayout.Visible = true;
            startmenulayout.Visible = false;
            registermenulayout.Visible = false;
        }
        //registrarse
        private void registerButton_Click(object sender, EventArgs e)
        {
            registermenulayout.Visible = true;
            startmenulayout.Visible = false;
            loginmenulayout.Visible = false;
        }
        //salir del programa
        private void exitbutton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();

        }
        //Menu login ***************
        //iniciar sesion
        private void loginuserbutton_Click(object sender, EventArgs e)
        {
            //if (userlogin.Text == "123" && passwordlogin.Text == "123")
            //{
            //    Form2 f = new Form2(this, 12345, "null");
            //    f.Show();
            //    this.Hide();
            //    return;
            //}

            //Validación del usuario y su contraseña
            if (string.IsNullOrEmpty(userlogin.Text) || userlogin.Text == "Usuario" ||
                string.IsNullOrEmpty(passwordlogin.Text) || passwordlogin.Text == "Contraseña")
            {
                MessageBox.Show("Ingresa un usuario y contraseña");
                return;
            }

            // Enviar login y recibir respuesta
            string respuestaServidor = cliente.EnviarLogin(userlogin.Text, passwordlogin.Text);

            //MessageBox.Show($"El servidor respondió: {respuestaServidor}");

            if (respuestaServidor.Contains("LOGIN_EXITOSO|"))
            {
                string mensajeLimpio = respuestaServidor.Replace("<EOF>", "");
               
                string[] partes = mensajeLimpio.Split('|');
                string usuario = partes[1];
                int userId = int.Parse(partes[2]);
                string gruposData = partes[3];
                string mensajesData = partes[4];

                Form2 f = new Form2(this, userId, usuario, gruposData, mensajesData);
                f.Show();
                this.Hide();
            }
            else if (respuestaServidor.Contains("LOGIN_ERROR"))
            {
                MessageBox.Show("ERROR " + respuestaServidor);
            }

            userlogin.Text = "Usuario";
            userlogin.ForeColor = Color.Gray;
            passwordlogin.Text = "Contraseña";
            passwordlogin.ForeColor = Color.Gray;
            passwordlogin.UseSystemPasswordChar = false;
            passwordlogin.PasswordChar = '\0';
            
        }
        //volver al menu principal
        private void loginBackButton_Click(object sender, EventArgs e)
        {
            startmenulayout.Visible = true;
            loginmenulayout.Visible = false;
            registermenulayout.Visible = false;
            userlogin.Text = "Usuario";
            userlogin.ForeColor = Color.Gray;
            passwordlogin.Text = "Contraseña";
            passwordlogin.ForeColor = Color.Gray;
            passwordlogin.UseSystemPasswordChar = false;
            passwordlogin.PasswordChar = '\0';
        }
        //Menu register ***************

        //registrarse
        private void registeruserbutton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(registeruser.Text) || string.IsNullOrEmpty(registerpassword.Text)
         || string.IsNullOrEmpty(confirmpassword.Text))
            {
                MessageBox.Show("Ingresa un usuario y contraseña");
                return;
            }

            if (registerpassword.Text != confirmpassword.Text)
            {
                MessageBox.Show("Las contraseñas deben coincidir");
                return;
            }

            // Enviar evento al servidor
            string respuestaServidor = cliente.EnviarRegistro(registeruser.Text, registerpassword.Text);

            if (respuestaServidor.Contains("REGISTER_EXITOSO"))
            {
                MessageBox.Show("✅ Usuario registrado con éxito");
            }
            else if (respuestaServidor.Contains("REGISTER_ERROR"))
            {
                MessageBox.Show("❌ No se pudo registrar. El usuario puede existir o hubo un error");
            }

            // Reset de los campos
            registeruser.Text = "Usuario";
            registeruser.ForeColor = Color.Gray;
            registerpassword.Text = "Contraseña";
            registerpassword.ForeColor = Color.Gray;
            registerpassword.UseSystemPasswordChar = false;
            registerpassword.PasswordChar = '\0';
            confirmpassword.Text = "Confirmar Contraseña";
            confirmpassword.ForeColor = Color.Gray;
            confirmpassword.UseSystemPasswordChar = false;
            confirmpassword.PasswordChar = '\0';
        }
        //volver al menu principal
        private void registerbackbutton_Click(object sender, EventArgs e)
        {
            startmenulayout.Visible = true;
            loginmenulayout.Visible = false;
            registermenulayout.Visible = false;
            registeruser.Text = "Usuario";
            registeruser.ForeColor = Color.Gray;
            registerpassword.Text = "Contraseña";
            registerpassword.ForeColor = Color.Gray;
            registerpassword.UseSystemPasswordChar = false; //Estos bloques de codigo son temporales
            registerpassword.PasswordChar = '\0';
            confirmpassword.Text = "Confirmar Contraseña"; //luego veo como lo optimizo 
            confirmpassword.ForeColor = Color.Gray;
            confirmpassword.UseSystemPasswordChar = false;
            confirmpassword.PasswordChar = '\0';
        }

        //EVENTOS TEXTBOX -----------------------------------------------------------
        //Menu login ***************
        private void userlogin_TextChanged(object sender, EventArgs e)
        {

        }
        private void passwordlogin_TextChanged(object sender, EventArgs e)
        {

        }
        //Menu register ***************
        private void registeruser_TextChanged(object sender, EventArgs e)
        {

        }
        private void registerpassword_TextChanged(object sender, EventArgs e)
        {

        }
        private void confirmpassword_TextChanged(object sender, EventArgs e)
        {

        }

        //ENCRIPTACION Y DESENCRIPTACION -----------------------------------------------------------
        //1ra prueba para encriptacion y desencriptacion bestis :)
        public static class Crypto
        {
            private static string key = "claveFija";
            public static string Encrypt(string text)
            {
                byte[] datos = Encoding.UTF8.GetBytes(text);
                byte[] claveBytes = Encoding.UTF8.GetBytes(key);
                byte[] resultado = new byte[datos.Length];

                for (int i = 0; i < datos.Length; i++)
                {
                    resultado[i] = (byte)(datos[i] ^ claveBytes[i % claveBytes.Length]);
                }
                return Convert.ToBase64String(resultado);
            }

            public static string Decrypt(string text)
            {
                byte[] datos = Convert.FromBase64String(text);
                byte[] claveBytes = Encoding.UTF8.GetBytes(key);
                byte[] resultado = new byte[datos.Length];

                for (int i = 0; i < datos.Length; i++)
                {
                    resultado[i] = (byte)(datos[i] ^ claveBytes[i % claveBytes.Length]);
                }
                return Encoding.UTF8.GetString(resultado);
            }
        }

        //PLACEHOLDERS -----------------------------------------------------------
        //registeruser
        private void registeruser_Enter(object sender, EventArgs e)
        {
            if (registeruser.Text == "Usuario")
            {
                registeruser.Text = "";
                registeruser.ForeColor = Color.Black;
            }
        }
        private void registeruser_Leave(object sender, EventArgs e)
        {
            if (registeruser.Text == "")
            {
                registeruser.Text = "Usuario";
                registeruser.ForeColor = Color.Gray;
            }
        }
        //registerpassword
        private void registerpassword_Enter(object sender, EventArgs e)
        {
            if (registerpassword.Text == "Contraseña")
            {
                registerpassword.Text = "";
                registerpassword.ForeColor = Color.Black;
                registerpassword.UseSystemPasswordChar = true;
                registerpassword.PasswordChar = '*';
            }
        }
        private void registerpassword_Leave(object sender, EventArgs e)
        {
            if (registerpassword.Text == "")
            {
                registerpassword.Text = "Contraseña";
                registerpassword.ForeColor = Color.Gray;
                registerpassword.UseSystemPasswordChar = false;
                registerpassword.PasswordChar = '\0';
            }
        }
        //confirmregisterpassword
        private void confirmpassword_Enter(object sender, EventArgs e)
        {
            if (confirmpassword.Text == "Confirmar Contraseña")
            {
                confirmpassword.Text = "";
                confirmpassword.ForeColor = Color.Black;
                confirmpassword.UseSystemPasswordChar = true;
                confirmpassword.PasswordChar = '*';
            }
        }
        private void confirmpassword_Leave(object sender, EventArgs e)
        {
            if (confirmpassword.Text == "")
            {
                confirmpassword.Text = "Confirmar Contraseña";
                confirmpassword.ForeColor = Color.Gray;
                confirmpassword.UseSystemPasswordChar = false;
                confirmpassword.PasswordChar = '\0';
            }
        }
        //userlogin
        private void userlogin_Enter(object sender, EventArgs e)
        {
            if (userlogin.Text == "Usuario")
            {
                userlogin.Text = "";
                userlogin.ForeColor = Color.Black;
            }
        }
        private void userlogin_Leave(object sender, EventArgs e)
        {
            if (userlogin.Text == "")
            {
                userlogin.Text = "Usuario";
                userlogin.ForeColor = Color.Gray;
            }
        }
        //passwordlogin
        private void passwordlogin_Enter(object sender, EventArgs e)
        {
            if (passwordlogin.Text == "Contraseña")
            {
                passwordlogin.Text = "";
                passwordlogin.ForeColor = Color.Black;
                passwordlogin.UseSystemPasswordChar = true;
                passwordlogin.PasswordChar = '*';
            }
        }
        private void passwordlogin_Leave(object sender, EventArgs e)
        {
            if (passwordlogin.Text == "")
            {
                passwordlogin.Text = "Contraseña";
                passwordlogin.ForeColor = Color.Gray;
                passwordlogin.UseSystemPasswordChar = false;
                passwordlogin.PasswordChar = '\0';
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}