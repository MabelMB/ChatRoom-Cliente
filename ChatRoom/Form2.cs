using ChatRoom;
using MySql.Data.MySqlClient;
//using Mysqlx;
//using Mysqlx.Crud;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ChatRoom
{
    public partial class Form2 : Form
    {
        //DECLARACION DE VARIABLES EXTRA -----------------------------------------------------------
        private STARTMENU _mainForm;
        private string connection = "server=127.0.0.1;uid=root;pwd=root;database=ChatRoom";
        int i = 0;
        int userid;
        int currentuserid;
        int currentsalaid;

        //CONSTRUCTOR -----------------------------------------------------------
        public Form2(STARTMENU mainForm, int userId, string userName)
        {
            InitializeComponent();
            //gradient
            this.DoubleBuffered = true;
            //form management
            _mainForm = mainForm;
            //user data load
            if (userName != "null")
            {
                MuestraUsuario(userId, userName);
                MuestraGrupos(userId);
                userid = userId;
            }
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

            if (groupnametextbox.Text == "" && groupdesctextbox.Text == "")
            {
                AddNewGroup("test", "test", 123, false);
                return;
            }

            try
            {
                string nombreGrupo = groupnametextbox.Text;
                string descripcionGrupo = groupdesctextbox.Text;

                int id;

                using (MySqlConnection conn = new MySqlConnection(connection))
                {
                    conn.Open();
                    string query = "INSERT INTO salas (nombre_sala, descripcion, id_creador) VALUES (@nombre, @descripcion, @id_creador)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombreGrupo);
                        cmd.Parameters.AddWithValue("@descripcion", descripcionGrupo);
                        cmd.Parameters.AddWithValue("@id_creador", userid);
                        cmd.ExecuteNonQuery();
                        // Obtener el ultimo ID insertado
                        id = (int)cmd.LastInsertedId;
                    }

                }

                if (!string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    string[] usuarios = textBox1.Text.Split(',');
                    foreach (string usuario in usuarios)
                    {
                        string usuarioLimpio = usuario.Trim();
                        if (!string.IsNullOrWhiteSpace(usuarioLimpio))
                        {
                            agregaMiembroLista(usuarioLimpio, id, "miembro");
                        }
                    }
                    currentsalaid = id;
                    agregaMiembro(userid, id, "admin");
                    AddNewGroup(groupnametextbox.Text, groupdesctextbox.Text, id, true);



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear el grupo: " + ex.Message);
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

            //grouptitlepanel.Text = label.Text;
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

            //IMPORTANT -+-+-+-+-+-+-*_*_*_*_*_+-+-+-+-+_*_*_*_*_*-+-+-+-+_**_*_*-+
            cargaMensajes(id);
            muestraMiembros(id);
            
            chatLayout.Visible = true;
            chatLayout.BringToFront();
            chooseagroup.Visible = false;
            groupconfigpanel.Visible = false;
            creategrouppanel.Visible = false;
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
            int targetId = currentuserid;


            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM miembros_sala WHERE id_sala = @sala AND id_usuario = @user", conn);
                cmd.Parameters.AddWithValue("@sala", currentuserid);
                cmd.Parameters.AddWithValue("@user", userid);
                int filasAfectadas = cmd.ExecuteNonQuery();
            }

            foreach (Control ctrl in groupViewPanel.Controls)
            {
                if (ctrl.Tag is int id && id == targetId)
                {
                    groupViewPanel.Controls.Remove(ctrl);
                    break;
                }
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
            MandarMensajeBD(tempmsgtextbox.Text);
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
        private void MuestraUsuario(int userid, string username)
        {
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM usuarios WHERE id_usuario = @id", conn);
            cmd.Parameters.AddWithValue("@id", userid);

            MySqlDataReader Reader = cmd.ExecuteReader();
            if (Reader.Read())
            {
                this.usernamelabel.Text = Reader.GetString("nombre_usuario");
            }

        }

        //Carga de los grupos del usuario
        private void MuestraGrupos(int userid)
        {
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();

            // CONSULTA CORREGIDA - Buscar salas donde el usuario es CREADOR O MIEMBRO
            MySqlCommand cmd = new MySqlCommand(@"
        SELECT s.*, 
               CASE 
                   WHEN s.id_creador = @id THEN 'creador'
                   ELSE 'miembro' 
               END as tipo_miembro
        FROM salas s
        WHERE s.id_creador = @id 
           OR s.id_sala IN (SELECT id_sala FROM miembros_sala WHERE id_usuario = @id)",
                conn);

            cmd.Parameters.AddWithValue("@id", userid);
            MySqlDataReader Reader = cmd.ExecuteReader();

            while (Reader.Read())
            {
                string tipoMiembro = Reader.GetString("tipo_miembro");
                bool esCreador = (tipoMiembro == "creador");

                AddNewGroup(Reader.GetString("nombre_sala"),
                           Reader.GetString("descripcion"),
                           Reader.GetInt32("id_sala"),
                           esCreador);

                // Si no es creador, asegurar que esté en miembros_sala
                if (!esCreador)
                {
                    string rol = "miembro";
                    agregaMiembro(userid, Reader.GetInt32("id_sala"), rol);
                }
            }
            Reader.Close();
        }
        //Carga de los miembros del grupo
        private void muestraMiembros(int salaid)
        {
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT u.id_usuario, u.nombre_usuario FROM miembros_sala ms INNER JOIN usuarios u ON ms.id_usuario = u.id_usuario WHERE ms.id_sala = @sala", conn);
            cmd.Parameters.AddWithValue("@sala", salaid);

            MySqlDataReader Reader = cmd.ExecuteReader();

            List<string> miembros = new List<string>();

            while (Reader.Read()) {
                miembros.Add(Reader.GetString("nombre_usuario"));
            }
            groupmemberslabel.Text = string.Join(", ", miembros);
        }

        private void agregaMiembro(int userid, int salaid, string rol) {


            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();

            MySqlCommand verificar = new MySqlCommand("SELECT COUNT(*) FROM miembros_sala WHERE id_usuario = @us AND id_sala = @sala", conn);
            verificar.Parameters.AddWithValue("@us", userid);
            verificar.Parameters.AddWithValue("@sala", salaid);

            int existe = Convert.ToInt32(verificar.ExecuteScalar());


            if (existe == 0)
            {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO miembros_sala (id_usuario, id_sala, rol) VALUES (@us, @sala, @rol)", conn);
                cmd.Parameters.AddWithValue("@us", userid);
                cmd.Parameters.AddWithValue("@sala", salaid);
                cmd.Parameters.AddWithValue("@rol", rol);

                cmd.ExecuteNonQuery();
            }
        }

        private void agregaMiembroLista(string user, int salaid, string rol)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connection))
                {
                    conn.Open();

                    MySqlCommand obtenerIdCmd = new MySqlCommand("SELECT id_usuario FROM usuarios WHERE nombre_usuario = @nombre", conn);
                    obtenerIdCmd.Parameters.AddWithValue("@nombre", user);

                    object resultado = obtenerIdCmd.ExecuteScalar();
                    if (resultado != null)
                    {
                        int userId = Convert.ToInt32(resultado);

                        MySqlCommand cmd = new MySqlCommand("INSERT INTO miembros_sala (id_usuario, id_sala, rol) VALUES (@us, @sala, @rol)", conn);
                        cmd.Parameters.AddWithValue("@us", userId);
                        cmd.Parameters.AddWithValue("@sala", salaid);
                        cmd.Parameters.AddWithValue("@rol", rol);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("El usuario se agregó con éxito");
                    }
                    else
                    {
                        MessageBox.Show("El usuario no existe");
                    }
                }
            }
            catch (Exception ex)
            {
                // Si falla, simplemente continuamos
                Console.WriteLine($"Error al agregar {user}: {ex.Message}");
            }
        }


        //Carga de usuarios disponibles para agregar al grupo
        private List<string> ObtenerUsuariosDisponibles(int idSala)
        {
            List<string> usuariosDisponibles = new List<string>();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connection))
                {
                    conn.Open();

                    // Consulta para obtener usuarios que NO son miembros y NO son el creador
                    string query = @" SELECT u.id_usuario, u.nombre_usuario FROM usuarios u WHERE u.id_usuario NOT IN (SELECT id_usuario FROM miembros_sala WHERE id_sala = @salaId)
                                    AND u.id_usuario NOT IN (SELECT id_creador FROM salas WHERE id_sala = @salaId )";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@salaId", idSala);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            usuariosDisponibles.Add(reader.GetString("nombre_usuario"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener usuarios disponibles: " + ex.Message);
            }

            return usuariosDisponibles;
        }

        private void AddNewMessage(string username, string message, bool usergroup)
        {
            string convertedMessage = EmojiHelper.ConvertEmojis(message);

            // Main message panel
            Panel panel = new Panel();
            panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel.Width = chatviewpanel.ClientSize.Width - SystemInformation.VerticalScrollBarWidth;
            panel.Anchor = AnchorStyles.Left;
            panel.BackColor = Color.LightGray;
            panel.Padding = new Padding(4);
            panel.MaximumSize = new Size(chatviewpanel.ClientSize.Width - SystemInformation.VerticalScrollBarWidth, 0);
            panel.Dock = DockStyle.None;
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
            profilePic.Image = usergroup? Properties.Resources.image_removebg_preview__2_ : Properties.Resources.image_removebg_preview__1_;
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

            // Add to chat view
            chatviewpanel.Controls.Add(panel);
            
            chatviewpanel.PerformLayout();

            chatviewpanel.ScrollControlIntoView(panel);
            chatviewpanel.VerticalScroll.Value = chatviewpanel.VerticalScroll.Maximum;
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
        private void cargaMensajes(int salaid)
        {

            chatviewpanel.Controls.Clear();

            if(currentuserid == salaid)
            {
                MySqlConnection conn = new MySqlConnection(connection);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM mensajes m INNER JOIN usuarios u ON m.id_usuario = u.id_usuario WHERE m.id_sala = @sala ORDER BY m.fecha_envio ASC", conn);
                cmd.Parameters.AddWithValue("@sala", salaid);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) { 
                    string username = reader.GetString("nombre_usuario");
                    string message = reader.GetString("mensajes");
                    int idUsuarioMensaje = reader.GetInt32("id_usuario");
                    bool usergroup = (idUsuarioMensaje == userid);
                    string messageWithEmojis = EmojiHelper.ConvertEmojis(message);
                    AddNewMessage(username, messageWithEmojis, usergroup);


                }

            }
        }
        private void MandarMensajeBD(string mensaje)
        {
            if (string.IsNullOrWhiteSpace(mensaje) || currentuserid == 0)
                return;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connection))
                {
                    conn.Open();
                    string query = "INSERT INTO mensajes (id_usuario, id_sala, mensajes, fecha_envio) VALUES (@usuario, @sala, @mensaje, @fecha)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario", userid);
                        cmd.Parameters.AddWithValue("@sala", currentuserid);
                        cmd.Parameters.AddWithValue("@mensaje", mensaje);
                        cmd.Parameters.AddWithValue("@fecha", DateTime.Now);
                        cmd.ExecuteNonQuery();
                    }
                }

                string mensajeConEmojis = EmojiHelper.ConvertEmojis(mensaje);
                AddNewMessage(usernamelabel.Text, mensajeConEmojis, true);

                tempmsgtextbox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar el mensaje: " + ex.Message);
            }
        }
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
                        agregaMiembroLista(usuarioLimpio, currentsalaid, "miembro");
                    }
                }
            }
        }
    }
}
