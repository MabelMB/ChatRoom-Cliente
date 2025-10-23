namespace ChatRoom
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.groupLayout = new System.Windows.Forms.TableLayoutPanel();
            this.grouplayout2 = new System.Windows.Forms.Panel();
            this.groupconfigpanel = new System.Windows.Forms.Panel();
            this.backbutton = new System.Windows.Forms.Button();
            this.delgroupbutton = new System.Windows.Forms.Button();
            this.configtitlelabel = new System.Windows.Forms.Label();
            this.chatLayout = new System.Windows.Forms.Panel();
            this.sendmsgpanel = new System.Windows.Forms.Panel();
            this.tempmsgtextbox = new System.Windows.Forms.TextBox();
            this.sendmsgbutton = new System.Windows.Forms.Button();
            this.auxchatpanel = new System.Windows.Forms.Panel();
            this.chatviewpanel = new System.Windows.Forms.FlowLayoutPanel();
            this.chatTitlePanel = new System.Windows.Forms.Panel();
            this.configbutton = new System.Windows.Forms.Button();
            this.groupmemberslabel = new System.Windows.Forms.Label();
            this.groputitlelabel = new System.Windows.Forms.Label();
            this.creategrouppanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupdesctextbox = new System.Windows.Forms.TextBox();
            this.groupnametextbox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.creategroup = new System.Windows.Forms.Button();
            this.creategrouptitle = new System.Windows.Forms.Label();
            this.creategroupback = new System.Windows.Forms.Button();
            this.chooseagrouppanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.chooseagroup = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.userviewpanel = new GlassPanel();
            this.closesesionbutton = new System.Windows.Forms.Button();
            this.usernamelabel = new System.Windows.Forms.Label();
            this.userpicture = new System.Windows.Forms.PictureBox();
            this.glassPanel1 = new GlassPanel();
            this.groupViewPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.yourgroupslabel = new System.Windows.Forms.Label();
            this.creategroupbutton = new System.Windows.Forms.Button();
            this.groupslabel = new System.Windows.Forms.Label();
            this.freezescreenpanel = new GlassPanel();
            this.confirmationpanel = new GlassPanel();
            this.confirmcancel = new System.Windows.Forms.Button();
            this.confirmaccept = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.mainLayout.SuspendLayout();
            this.groupLayout.SuspendLayout();
            this.grouplayout2.SuspendLayout();
            this.groupconfigpanel.SuspendLayout();
            this.chatLayout.SuspendLayout();
            this.sendmsgpanel.SuspendLayout();
            this.auxchatpanel.SuspendLayout();
            this.chatTitlePanel.SuspendLayout();
            this.creategrouppanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.chooseagrouppanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.userviewpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userpicture)).BeginInit();
            this.glassPanel1.SuspendLayout();
            this.groupViewPanel.SuspendLayout();
            this.confirmationpanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainLayout
            // 
            this.mainLayout.BackColor = System.Drawing.Color.Transparent;
            this.mainLayout.ColumnCount = 5;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3F));
            this.mainLayout.Controls.Add(this.groupLayout, 1, 1);
            this.mainLayout.Controls.Add(this.grouplayout2, 3, 1);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 3;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3F));
            this.mainLayout.Size = new System.Drawing.Size(900, 562);
            this.mainLayout.TabIndex = 2;
            // 
            // groupLayout
            // 
            this.groupLayout.BackColor = System.Drawing.Color.Transparent;
            this.groupLayout.ColumnCount = 1;
            this.groupLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.groupLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.groupLayout.Controls.Add(this.userviewpanel, 0, 0);
            this.groupLayout.Controls.Add(this.glassPanel1, 0, 2);
            this.groupLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupLayout.Location = new System.Drawing.Point(30, 20);
            this.groupLayout.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupLayout.Name = "groupLayout";
            this.groupLayout.RowCount = 3;
            this.groupLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.groupLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3F));
            this.groupLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67F));
            this.groupLayout.Size = new System.Drawing.Size(264, 520);
            this.groupLayout.TabIndex = 0;
            this.groupLayout.Paint += new System.Windows.Forms.PaintEventHandler(this.gropuLayout_Paint);
            // 
            // grouplayout2
            // 
            this.grouplayout2.BackColor = System.Drawing.Color.Transparent;
            this.grouplayout2.Controls.Add(this.chatLayout);
            this.grouplayout2.Controls.Add(this.groupconfigpanel);
            this.grouplayout2.Controls.Add(this.creategrouppanel);
            this.grouplayout2.Controls.Add(this.chooseagrouppanel);
            this.grouplayout2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grouplayout2.Location = new System.Drawing.Point(327, 20);
            this.grouplayout2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grouplayout2.Name = "grouplayout2";
            this.grouplayout2.Size = new System.Drawing.Size(543, 520);
            this.grouplayout2.TabIndex = 6;
            // 
            // groupconfigpanel
            // 
            this.groupconfigpanel.Controls.Add(this.backbutton);
            this.groupconfigpanel.Controls.Add(this.delgroupbutton);
            this.groupconfigpanel.Controls.Add(this.configtitlelabel);
            this.groupconfigpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupconfigpanel.Location = new System.Drawing.Point(0, 0);
            this.groupconfigpanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupconfigpanel.Name = "groupconfigpanel";
            this.groupconfigpanel.Size = new System.Drawing.Size(543, 520);
            this.groupconfigpanel.TabIndex = 3;
            this.groupconfigpanel.Paint += new System.Windows.Forms.PaintEventHandler(this.groupconfigpanel_Paint);
            // 
            // backbutton
            // 
            this.backbutton.Location = new System.Drawing.Point(442, 19);
            this.backbutton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.backbutton.Name = "backbutton";
            this.backbutton.Size = new System.Drawing.Size(87, 29);
            this.backbutton.TabIndex = 1;
            this.backbutton.Text = "Volver";
            this.backbutton.UseVisualStyleBackColor = true;
            this.backbutton.Click += new System.EventHandler(this.backbutton_Click);
            // 
            // delgroupbutton
            // 
            this.delgroupbutton.Location = new System.Drawing.Point(182, 264);
            this.delgroupbutton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.delgroupbutton.Name = "delgroupbutton";
            this.delgroupbutton.Size = new System.Drawing.Size(179, 35);
            this.delgroupbutton.TabIndex = 0;
            this.delgroupbutton.Text = "Salir del grupo";
            this.delgroupbutton.UseVisualStyleBackColor = true;
            this.delgroupbutton.Click += new System.EventHandler(this.delgroupbutton_Click);
            // 
            // configtitlelabel
            // 
            this.configtitlelabel.AutoSize = true;
            this.configtitlelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.configtitlelabel.ForeColor = System.Drawing.SystemColors.Control;
            this.configtitlelabel.Location = new System.Drawing.Point(6, 11);
            this.configtitlelabel.Name = "configtitlelabel";
            this.configtitlelabel.Size = new System.Drawing.Size(385, 38);
            this.configtitlelabel.TabIndex = 0;
            this.configtitlelabel.Text = "Configuración del grupo";
            // 
            // chatLayout
            // 
            this.chatLayout.BackColor = System.Drawing.Color.Transparent;
            this.chatLayout.Controls.Add(this.sendmsgpanel);
            this.chatLayout.Controls.Add(this.auxchatpanel);
            this.chatLayout.Controls.Add(this.chatTitlePanel);
            this.chatLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chatLayout.Location = new System.Drawing.Point(0, 0);
            this.chatLayout.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chatLayout.Name = "chatLayout";
            this.chatLayout.Size = new System.Drawing.Size(543, 520);
            this.chatLayout.TabIndex = 10;
            this.chatLayout.Paint += new System.Windows.Forms.PaintEventHandler(this.chatLayout_Paint);
            // 
            // sendmsgpanel
            // 
            this.sendmsgpanel.Controls.Add(this.tempmsgtextbox);
            this.sendmsgpanel.Controls.Add(this.sendmsgbutton);
            this.sendmsgpanel.Location = new System.Drawing.Point(0, 490);
            this.sendmsgpanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sendmsgpanel.Name = "sendmsgpanel";
            this.sendmsgpanel.Size = new System.Drawing.Size(539, 31);
            this.sendmsgpanel.TabIndex = 9;
            // 
            // tempmsgtextbox
            // 
            this.tempmsgtextbox.Location = new System.Drawing.Point(0, 0);
            this.tempmsgtextbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tempmsgtextbox.Multiline = true;
            this.tempmsgtextbox.Name = "tempmsgtextbox";
            this.tempmsgtextbox.Size = new System.Drawing.Size(426, 30);
            this.tempmsgtextbox.TabIndex = 11;
            this.tempmsgtextbox.TextChanged += new System.EventHandler(this.tempmsgtextbox_TextChanged_1);
            // 
            // sendmsgbutton
            // 
            this.sendmsgbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.sendmsgbutton.Location = new System.Drawing.Point(431, 0);
            this.sendmsgbutton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sendmsgbutton.Name = "sendmsgbutton";
            this.sendmsgbutton.Size = new System.Drawing.Size(109, 31);
            this.sendmsgbutton.TabIndex = 10;
            this.sendmsgbutton.Text = "Enviar";
            this.sendmsgbutton.UseVisualStyleBackColor = true;
            this.sendmsgbutton.Click += new System.EventHandler(this.tempaddchatmsg_Click);
            // 
            // auxchatpanel
            // 
            this.auxchatpanel.Controls.Add(this.chatviewpanel);
            this.auxchatpanel.Location = new System.Drawing.Point(0, 82);
            this.auxchatpanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.auxchatpanel.Name = "auxchatpanel";
            this.auxchatpanel.Size = new System.Drawing.Size(542, 400);
            this.auxchatpanel.TabIndex = 8;
            // 
            // chatviewpanel
            // 
            this.chatviewpanel.AutoScroll = true;
            this.chatviewpanel.BackColor = System.Drawing.Color.Transparent;
            this.chatviewpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chatviewpanel.Location = new System.Drawing.Point(0, 0);
            this.chatviewpanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chatviewpanel.Name = "chatviewpanel";
            this.chatviewpanel.Size = new System.Drawing.Size(542, 400);
            this.chatviewpanel.TabIndex = 7;
            this.chatviewpanel.Paint += new System.Windows.Forms.PaintEventHandler(this.chatviewpanel_Paint);
            // 
            // chatTitlePanel
            // 
            this.chatTitlePanel.Controls.Add(this.configbutton);
            this.chatTitlePanel.Controls.Add(this.groupmemberslabel);
            this.chatTitlePanel.Controls.Add(this.groputitlelabel);
            this.chatTitlePanel.Location = new System.Drawing.Point(0, 4);
            this.chatTitlePanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chatTitlePanel.Name = "chatTitlePanel";
            this.chatTitlePanel.Size = new System.Drawing.Size(542, 75);
            this.chatTitlePanel.TabIndex = 6;
            // 
            // configbutton
            // 
            this.configbutton.Location = new System.Drawing.Point(408, 1);
            this.configbutton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.configbutton.Name = "configbutton";
            this.configbutton.Size = new System.Drawing.Size(131, 36);
            this.configbutton.TabIndex = 9;
            this.configbutton.Text = "Configuración";
            this.configbutton.UseVisualStyleBackColor = true;
            this.configbutton.Click += new System.EventHandler(this.configbutton_Click);
            // 
            // groupmemberslabel
            // 
            this.groupmemberslabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupmemberslabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.groupmemberslabel.ForeColor = System.Drawing.SystemColors.Control;
            this.groupmemberslabel.Location = new System.Drawing.Point(3, 36);
            this.groupmemberslabel.Name = "groupmemberslabel";
            this.groupmemberslabel.Size = new System.Drawing.Size(539, 39);
            this.groupmemberslabel.TabIndex = 8;
            this.groupmemberslabel.Text = "GROPUMEMBERS";
            this.groupmemberslabel.Click += new System.EventHandler(this.groupmemberslabel_Click);
            // 
            // groputitlelabel
            // 
            this.groputitlelabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groputitlelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.groputitlelabel.ForeColor = System.Drawing.SystemColors.Control;
            this.groputitlelabel.Location = new System.Drawing.Point(0, 0);
            this.groputitlelabel.Name = "groputitlelabel";
            this.groputitlelabel.Size = new System.Drawing.Size(402, 36);
            this.groputitlelabel.TabIndex = 7;
            this.groputitlelabel.Text = "GROUPTITLE";
            this.groputitlelabel.Click += new System.EventHandler(this.grouptitlepanel_Click);
            // 
            // creategrouppanel
            // 
            this.creategrouppanel.Controls.Add(this.button1);
            this.creategrouppanel.Controls.Add(this.textBox1);
            this.creategrouppanel.Controls.Add(this.label1);
            this.creategrouppanel.Controls.Add(this.label3);
            this.creategrouppanel.Controls.Add(this.label2);
            this.creategrouppanel.Controls.Add(this.groupdesctextbox);
            this.creategrouppanel.Controls.Add(this.groupnametextbox);
            this.creategrouppanel.Controls.Add(this.panel1);
            this.creategrouppanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.creategrouppanel.Location = new System.Drawing.Point(0, 0);
            this.creategrouppanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.creategrouppanel.Name = "creategrouppanel";
            this.creategrouppanel.Size = new System.Drawing.Size(543, 520);
            this.creategrouppanel.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(442, 291);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 29);
            this.button1.TabIndex = 10;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(7, 292);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(428, 26);
            this.textBox1.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(8, 264);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Añadir miembros";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(8, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Descripción";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(7, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Nombre";
            // 
            // groupdesctextbox
            // 
            this.groupdesctextbox.Location = new System.Drawing.Point(11, 160);
            this.groupdesctextbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupdesctextbox.Multiline = true;
            this.groupdesctextbox.Name = "groupdesctextbox";
            this.groupdesctextbox.Size = new System.Drawing.Size(524, 99);
            this.groupdesctextbox.TabIndex = 6;
            // 
            // groupnametextbox
            // 
            this.groupnametextbox.Location = new System.Drawing.Point(11, 94);
            this.groupnametextbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupnametextbox.Name = "groupnametextbox";
            this.groupnametextbox.Size = new System.Drawing.Size(524, 26);
            this.groupnametextbox.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.creategroup);
            this.panel1.Controls.Add(this.creategrouptitle);
            this.panel1.Controls.Add(this.creategroupback);
            this.panel1.Location = new System.Drawing.Point(3, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(532, 49);
            this.panel1.TabIndex = 3;
            // 
            // creategroup
            // 
            this.creategroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.creategroup.Location = new System.Drawing.Point(444, 11);
            this.creategroup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.creategroup.Name = "creategroup";
            this.creategroup.Size = new System.Drawing.Size(87, 29);
            this.creategroup.TabIndex = 9;
            this.creategroup.Text = "Crear grupo";
            this.creategroup.UseVisualStyleBackColor = true;
            this.creategroup.Click += new System.EventHandler(this.creategroup_Click);
            // 
            // creategrouptitle
            // 
            this.creategrouptitle.AutoSize = true;
            this.creategrouptitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.creategrouptitle.ForeColor = System.Drawing.Color.White;
            this.creategrouptitle.Location = new System.Drawing.Point(3, 8);
            this.creategrouptitle.Name = "creategrouptitle";
            this.creategrouptitle.Size = new System.Drawing.Size(161, 30);
            this.creategrouptitle.TabIndex = 0;
            this.creategrouptitle.Text = "Crear grupo";
            // 
            // creategroupback
            // 
            this.creategroupback.Location = new System.Drawing.Point(351, 11);
            this.creategroupback.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.creategroupback.Name = "creategroupback";
            this.creategroupback.Size = new System.Drawing.Size(87, 29);
            this.creategroupback.TabIndex = 1;
            this.creategroupback.Text = "Volver";
            this.creategroupback.UseVisualStyleBackColor = true;
            this.creategroupback.Click += new System.EventHandler(this.creategroupback_Click);
            // 
            // chooseagrouppanel
            // 
            this.chooseagrouppanel.Controls.Add(this.label4);
            this.chooseagrouppanel.Controls.Add(this.chooseagroup);
            this.chooseagrouppanel.Controls.Add(this.pictureBox1);
            this.chooseagrouppanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chooseagrouppanel.Location = new System.Drawing.Point(0, 0);
            this.chooseagrouppanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chooseagrouppanel.Name = "chooseagrouppanel";
            this.chooseagrouppanel.Size = new System.Drawing.Size(543, 520);
            this.chooseagrouppanel.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(114, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(362, 37);
            this.label4.TabIndex = 2;
            this.label4.Text = "Bienvenido a ChatRoom";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Click += new System.EventHandler(this.label4_Click_1);
            // 
            // chooseagroup
            // 
            this.chooseagroup.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chooseagroup.AutoSize = true;
            this.chooseagroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseagroup.ForeColor = System.Drawing.SystemColors.Control;
            this.chooseagroup.Location = new System.Drawing.Point(78, 356);
            this.chooseagroup.Name = "chooseagroup";
            this.chooseagroup.Size = new System.Drawing.Size(440, 37);
            this.chooseagroup.TabIndex = 0;
            this.chooseagroup.Text = "Elige un grupo para continuar";
            this.chooseagroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chooseagroup.Click += new System.EventHandler(this.chooseagroup_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ChatRoom.Properties.Resources.image_removebg_preview__4_;
            this.pictureBox1.Location = new System.Drawing.Point(0, 116);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(542, 289);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // userviewpanel
            // 
            this.userviewpanel.BorderRadius = 20;
            this.userviewpanel.Controls.Add(this.closesesionbutton);
            this.userviewpanel.Controls.Add(this.usernamelabel);
            this.userviewpanel.Controls.Add(this.userpicture);
            this.userviewpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userviewpanel.DrawBorder = true;
            this.userviewpanel.EnableBlur = true;
            this.userviewpanel.Location = new System.Drawing.Point(3, 4);
            this.userviewpanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userviewpanel.Name = "userviewpanel";
            this.userviewpanel.OverlayColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.userviewpanel.Size = new System.Drawing.Size(258, 148);
            this.userviewpanel.TabIndex = 3;
            // 
            // closesesionbutton
            // 
            this.closesesionbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.closesesionbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.closesesionbutton.Location = new System.Drawing.Point(34, 112);
            this.closesesionbutton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.closesesionbutton.Name = "closesesionbutton";
            this.closesesionbutton.Size = new System.Drawing.Size(197, 29);
            this.closesesionbutton.TabIndex = 1;
            this.closesesionbutton.Text = "Cerrar sesión";
            this.closesesionbutton.UseVisualStyleBackColor = true;
            this.closesesionbutton.Click += new System.EventHandler(this.closesession_Click);
            // 
            // usernamelabel
            // 
            this.usernamelabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.usernamelabel.AutoSize = true;
            this.usernamelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.usernamelabel.ForeColor = System.Drawing.Color.White;
            this.usernamelabel.Location = new System.Drawing.Point(72, 15);
            this.usernamelabel.Name = "usernamelabel";
            this.usernamelabel.Size = new System.Drawing.Size(168, 30);
            this.usernamelabel.TabIndex = 1;
            this.usernamelabel.Text = "USERNAME";
            this.usernamelabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.usernamelabel.Click += new System.EventHandler(this.usernamelabel_Click_2);
            // 
            // userpicture
            // 
            this.userpicture.Image = global::ChatRoom.Properties.Resources.image_removebg_preview__2_;
            this.userpicture.Location = new System.Drawing.Point(7, 10);
            this.userpicture.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userpicture.Name = "userpicture";
            this.userpicture.Size = new System.Drawing.Size(58, 42);
            this.userpicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.userpicture.TabIndex = 2;
            this.userpicture.TabStop = false;
            // 
            // glassPanel1
            // 
            this.glassPanel1.BorderRadius = 20;
            this.glassPanel1.Controls.Add(this.groupViewPanel);
            this.glassPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glassPanel1.DrawBorder = true;
            this.glassPanel1.EnableBlur = true;
            this.glassPanel1.Location = new System.Drawing.Point(3, 175);
            this.glassPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.glassPanel1.Name = "glassPanel1";
            this.glassPanel1.OverlayColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.glassPanel1.Size = new System.Drawing.Size(258, 341);
            this.glassPanel1.TabIndex = 4;
            // 
            // groupViewPanel
            // 
            this.groupViewPanel.AutoScroll = true;
            this.groupViewPanel.Controls.Add(this.yourgroupslabel);
            this.groupViewPanel.Controls.Add(this.creategroupbutton);
            this.groupViewPanel.Controls.Add(this.groupslabel);
            this.groupViewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupViewPanel.Location = new System.Drawing.Point(0, 0);
            this.groupViewPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupViewPanel.Name = "groupViewPanel";
            this.groupViewPanel.Size = new System.Drawing.Size(258, 341);
            this.groupViewPanel.TabIndex = 5;
            this.groupViewPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.groupViewPanel_Paint_1);
            // 
            // yourgroupslabel
            // 
            this.yourgroupslabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.yourgroupslabel.BackColor = System.Drawing.Color.Transparent;
            this.yourgroupslabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.yourgroupslabel.ForeColor = System.Drawing.SystemColors.Control;
            this.yourgroupslabel.Location = new System.Drawing.Point(3, 0);
            this.yourgroupslabel.Name = "yourgroupslabel";
            this.yourgroupslabel.Size = new System.Drawing.Size(250, 29);
            this.yourgroupslabel.TabIndex = 0;
            this.yourgroupslabel.Text = "Tus grupos";
            this.yourgroupslabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // creategroupbutton
            // 
            this.creategroupbutton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.creategroupbutton.BackColor = System.Drawing.Color.Transparent;
            this.creategroupbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.creategroupbutton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.creategroupbutton.Location = new System.Drawing.Point(3, 33);
            this.creategroupbutton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.creategroupbutton.Name = "creategroupbutton";
            this.creategroupbutton.Size = new System.Drawing.Size(250, 40);
            this.creategroupbutton.TabIndex = 0;
            this.creategroupbutton.Text = "+ Crear grupo";
            this.creategroupbutton.UseVisualStyleBackColor = false;
            this.creategroupbutton.Click += new System.EventHandler(this.creategroupbutton_Click);
            // 
            // groupslabel
            // 
            this.groupslabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupslabel.BackColor = System.Drawing.Color.Transparent;
            this.groupslabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.groupslabel.ForeColor = System.Drawing.SystemColors.Control;
            this.groupslabel.Location = new System.Drawing.Point(3, 77);
            this.groupslabel.Name = "groupslabel";
            this.groupslabel.Size = new System.Drawing.Size(250, 29);
            this.groupslabel.TabIndex = 1;
            this.groupslabel.Text = "Grupos";
            this.groupslabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.groupslabel.Click += new System.EventHandler(this.groupslabel_Click);
            // 
            // freezescreenpanel
            // 
            this.freezescreenpanel.BackColor = System.Drawing.Color.Transparent;
            this.freezescreenpanel.BorderRadius = 20;
            this.freezescreenpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.freezescreenpanel.DrawBorder = true;
            this.freezescreenpanel.EnableBlur = true;
            this.freezescreenpanel.Location = new System.Drawing.Point(0, 0);
            this.freezescreenpanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.freezescreenpanel.Name = "freezescreenpanel";
            this.freezescreenpanel.OverlayColor = System.Drawing.Color.Transparent;
            this.freezescreenpanel.Size = new System.Drawing.Size(900, 562);
            this.freezescreenpanel.TabIndex = 2;
            this.freezescreenpanel.Visible = false;
            // 
            // confirmationpanel
            // 
            this.confirmationpanel.BorderRadius = 20;
            this.confirmationpanel.Controls.Add(this.confirmcancel);
            this.confirmationpanel.Controls.Add(this.confirmaccept);
            this.confirmationpanel.Controls.Add(this.label5);
            this.confirmationpanel.DrawBorder = true;
            this.confirmationpanel.EnableBlur = true;
            this.confirmationpanel.Location = new System.Drawing.Point(264, 164);
            this.confirmationpanel.Name = "confirmationpanel";
            this.confirmationpanel.OverlayColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.confirmationpanel.Size = new System.Drawing.Size(272, 123);
            this.confirmationpanel.TabIndex = 2;
            this.confirmationpanel.Paint += new System.Windows.Forms.PaintEventHandler(this.confirmationpanel_Paint);
            // 
            // confirmcancel
            // 
            this.confirmcancel.Location = new System.Drawing.Point(17, 81);
            this.confirmcancel.Name = "confirmcancel";
            this.confirmcancel.Size = new System.Drawing.Size(82, 23);
            this.confirmcancel.TabIndex = 2;
            this.confirmcancel.Text = "Cancelar";
            this.confirmcancel.UseVisualStyleBackColor = true;
            this.confirmcancel.Click += new System.EventHandler(this.confirmcancel_Click);
            // 
            // confirmaccept
            // 
            this.confirmaccept.Location = new System.Drawing.Point(178, 81);
            this.confirmaccept.Name = "confirmaccept";
            this.confirmaccept.Size = new System.Drawing.Size(82, 23);
            this.confirmaccept.TabIndex = 1;
            this.confirmaccept.Text = "Aceptar";
            this.confirmaccept.UseVisualStyleBackColor = true;
            this.confirmaccept.Click += new System.EventHandler(this.confirmaccept_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(13, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(322, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "¿Seguro que desea salir del grupo?";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(900, 562);
            this.Controls.Add(this.mainLayout);
            this.Controls.Add(this.freezescreenpanel);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form2";
            this.Text = "ChatRoom (Beta)";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.mainLayout.ResumeLayout(false);
            this.groupLayout.ResumeLayout(false);
            this.grouplayout2.ResumeLayout(false);
            this.groupconfigpanel.ResumeLayout(false);
            this.groupconfigpanel.PerformLayout();
            this.chatLayout.ResumeLayout(false);
            this.sendmsgpanel.ResumeLayout(false);
            this.sendmsgpanel.PerformLayout();
            this.auxchatpanel.ResumeLayout(false);
            this.chatTitlePanel.ResumeLayout(false);
            this.creategrouppanel.ResumeLayout(false);
            this.creategrouppanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.chooseagrouppanel.ResumeLayout(false);
            this.chooseagrouppanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.userviewpanel.ResumeLayout(false);
            this.userviewpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userpicture)).EndInit();
            this.glassPanel1.ResumeLayout(false);
            this.groupViewPanel.ResumeLayout(false);
            this.confirmationpanel.ResumeLayout(false);
            this.confirmationpanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.TableLayoutPanel groupLayout;
        private System.Windows.Forms.Button creategroupbutton;
        private System.Windows.Forms.Label usernamelabel;
        private System.Windows.Forms.PictureBox userpicture;
        private System.Windows.Forms.Button closesesionbutton;
        private System.Windows.Forms.Panel chatTitlePanel;
        private System.Windows.Forms.Label groputitlelabel;
        private System.Windows.Forms.Label groupmemberslabel;
        private System.Windows.Forms.FlowLayoutPanel groupViewPanel;
        private System.Windows.Forms.Label yourgroupslabel;
        private System.Windows.Forms.Label groupslabel;
        private System.Windows.Forms.FlowLayoutPanel chatviewpanel;
        private System.Windows.Forms.Button configbutton;
        private System.Windows.Forms.Panel chooseagrouppanel;
        private System.Windows.Forms.Label chooseagroup;
        private System.Windows.Forms.Label configtitlelabel;
        private System.Windows.Forms.Button backbutton;
        private System.Windows.Forms.Panel grouplayout2;
        private System.Windows.Forms.Panel creategrouppanel;
        private System.Windows.Forms.Button creategroup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox groupdesctextbox;
        private System.Windows.Forms.TextBox groupnametextbox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label creategrouptitle;
        private System.Windows.Forms.Button creategroupback;
        private System.Windows.Forms.Button sendmsgbutton;
        private System.Windows.Forms.TextBox tempmsgtextbox;
        private System.Windows.Forms.Panel chatLayout;
        private System.Windows.Forms.Panel auxchatpanel;
        private GlassPanel userviewpanel;
        private GlassPanel glassPanel1;
        private System.Windows.Forms.Panel sendmsgpanel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel groupconfigpanel;
        private GlassPanel confirmationpanel;
        private System.Windows.Forms.Button confirmcancel;
        private System.Windows.Forms.Button confirmaccept;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button delgroupbutton;
        private GlassPanel freezescreenpanel;
    }
}