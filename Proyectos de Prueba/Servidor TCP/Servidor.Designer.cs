
namespace Servidor_TCP
{
    partial class Servidor
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Servidor));
			this.labelPuertoServidor = new System.Windows.Forms.Label();
			this.textBoxDatosRecibidos = new System.Windows.Forms.TextBox();
			this.textBoxPuertoServidor = new System.Windows.Forms.TextBox();
			this.buttonSetPuerto = new System.Windows.Forms.Button();
			this.labelBytesCount = new System.Windows.Forms.Label();
			this.textBoxDatosEnviados = new System.Windows.Forms.TextBox();
			this.buttonEnviarCliente = new System.Windows.Forms.Button();
			this.textBoxSegundosCliente = new System.Windows.Forms.TextBox();
			this.labelSegCliente = new System.Windows.Forms.Label();
			this.radioButtonTCP = new System.Windows.Forms.RadioButton();
			this.radioButtonUDP = new System.Windows.Forms.RadioButton();
			this.textBoxPuertoCliente = new System.Windows.Forms.TextBox();
			this.labelPuertoCliente = new System.Windows.Forms.Label();
			this.groupBoxCliente = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.label7 = new System.Windows.Forms.Label();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.textBoxEnviarComando = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.panel5 = new System.Windows.Forms.Panel();
			this.buttonEnviarCommando = new System.Windows.Forms.Button();
			this.textBoxEnviarDato = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.buttonEnviarArchivoo = new System.Windows.Forms.Button();
			this.textBoxComando = new System.Windows.Forms.TextBox();
			this.buttonEnviarRafaga = new System.Windows.Forms.Button();
			this.buttonSetInterval = new System.Windows.Forms.Button();
			this.textBoxIntervalTest = new System.Windows.Forms.TextBox();
			this.checkBoxReListen = new System.Windows.Forms.CheckBox();
			this.checkBoxReConnect = new System.Windows.Forms.CheckBox();
			this.checkBoxTestConnect = new System.Windows.Forms.CheckBox();
			this.buttonDesConectar = new System.Windows.Forms.Button();
			this.textBoxStatusControl = new System.Windows.Forms.TextBox();
			this.buttonConectar = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBoxServidor = new System.Windows.Forms.GroupBox();
			this.labelComandosCount = new System.Windows.Forms.Label();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.textBoxComandoRecibido = new System.Windows.Forms.TextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.buttonunSet = new System.Windows.Forms.Button();
			this.timerStatus = new System.Windows.Forms.Timer(this.components);
			this.labelInformacion = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.mClienteServidorUdp1 = new PeerToPeerTcpUdp.PeerToPeerUdp(this.components);
			this.groupBoxCliente.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.panel4.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel5.SuspendLayout();
			this.groupBoxServidor.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.SuspendLayout();
			// 
			// labelPuertoServidor
			// 
			this.labelPuertoServidor.AutoSize = true;
			this.labelPuertoServidor.Location = new System.Drawing.Point(6, 27);
			this.labelPuertoServidor.Name = "labelPuertoServidor";
			this.labelPuertoServidor.Size = new System.Drawing.Size(38, 13);
			this.labelPuertoServidor.TabIndex = 0;
			this.labelPuertoServidor.Text = "Puerto";
			// 
			// textBoxDatosRecibidos
			// 
			this.textBoxDatosRecibidos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxDatosRecibidos.Location = new System.Drawing.Point(0, 16);
			this.textBoxDatosRecibidos.MaxLength = 400000;
			this.textBoxDatosRecibidos.Multiline = true;
			this.textBoxDatosRecibidos.Name = "textBoxDatosRecibidos";
			this.textBoxDatosRecibidos.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxDatosRecibidos.Size = new System.Drawing.Size(283, 52);
			this.textBoxDatosRecibidos.TabIndex = 1;
			// 
			// textBoxPuertoServidor
			// 
			this.textBoxPuertoServidor.Location = new System.Drawing.Point(56, 24);
			this.textBoxPuertoServidor.Name = "textBoxPuertoServidor";
			this.textBoxPuertoServidor.Size = new System.Drawing.Size(50, 20);
			this.textBoxPuertoServidor.TabIndex = 3;
			this.textBoxPuertoServidor.Text = "7006";
			this.textBoxPuertoServidor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// buttonSetPuerto
			// 
			this.buttonSetPuerto.Location = new System.Drawing.Point(9, 50);
			this.buttonSetPuerto.Name = "buttonSetPuerto";
			this.buttonSetPuerto.Size = new System.Drawing.Size(41, 20);
			this.buttonSetPuerto.TabIndex = 4;
			this.buttonSetPuerto.Text = "Set";
			this.buttonSetPuerto.UseVisualStyleBackColor = true;
			this.buttonSetPuerto.Click += new System.EventHandler(this.buttonSetPuerto_Click);
			// 
			// labelBytesCount
			// 
			this.labelBytesCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelBytesCount.Location = new System.Drawing.Point(6, 96);
			this.labelBytesCount.Name = "labelBytesCount";
			this.labelBytesCount.Size = new System.Drawing.Size(259, 20);
			this.labelBytesCount.TabIndex = 5;
			this.labelBytesCount.Text = "Cerrado:";
			this.labelBytesCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBoxDatosEnviados
			// 
			this.textBoxDatosEnviados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxDatosEnviados.Location = new System.Drawing.Point(3, 16);
			this.textBoxDatosEnviados.MaxLength = 400000;
			this.textBoxDatosEnviados.Multiline = true;
			this.textBoxDatosEnviados.Name = "textBoxDatosEnviados";
			this.textBoxDatosEnviados.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxDatosEnviados.Size = new System.Drawing.Size(277, 122);
			this.textBoxDatosEnviados.TabIndex = 1;
			// 
			// buttonEnviarCliente
			// 
			this.buttonEnviarCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonEnviarCliente.Location = new System.Drawing.Point(211, 112);
			this.buttonEnviarCliente.Name = "buttonEnviarCliente";
			this.buttonEnviarCliente.Size = new System.Drawing.Size(45, 23);
			this.buttonEnviarCliente.TabIndex = 2;
			this.buttonEnviarCliente.Text = "Enviar";
			this.buttonEnviarCliente.UseVisualStyleBackColor = true;
			this.buttonEnviarCliente.Click += new System.EventHandler(this.buttonEnviarCliente_Click);
			// 
			// textBoxSegundosCliente
			// 
			this.textBoxSegundosCliente.Location = new System.Drawing.Point(6, 85);
			this.textBoxSegundosCliente.Name = "textBoxSegundosCliente";
			this.textBoxSegundosCliente.Size = new System.Drawing.Size(100, 20);
			this.textBoxSegundosCliente.TabIndex = 6;
			this.textBoxSegundosCliente.Text = "0";
			this.textBoxSegundosCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// labelSegCliente
			// 
			this.labelSegCliente.AutoSize = true;
			this.labelSegCliente.Location = new System.Drawing.Point(6, 69);
			this.labelSegCliente.Name = "labelSegCliente";
			this.labelSegCliente.Size = new System.Drawing.Size(97, 13);
			this.labelSegCliente.TabIndex = 7;
			this.labelSegCliente.Text = "Enviar cada x Seg:";
			// 
			// radioButtonTCP
			// 
			this.radioButtonTCP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.radioButtonTCP.AutoSize = true;
			this.radioButtonTCP.Location = new System.Drawing.Point(502, 12);
			this.radioButtonTCP.Name = "radioButtonTCP";
			this.radioButtonTCP.Size = new System.Drawing.Size(46, 17);
			this.radioButtonTCP.TabIndex = 8;
			this.radioButtonTCP.Text = "TCP";
			this.radioButtonTCP.UseVisualStyleBackColor = true;
			this.radioButtonTCP.CheckedChanged += new System.EventHandler(this.radioButtonTCP_CheckedChanged);
			// 
			// radioButtonUDP
			// 
			this.radioButtonUDP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.radioButtonUDP.AutoSize = true;
			this.radioButtonUDP.Checked = true;
			this.radioButtonUDP.Location = new System.Drawing.Point(554, 12);
			this.radioButtonUDP.Name = "radioButtonUDP";
			this.radioButtonUDP.Size = new System.Drawing.Size(48, 17);
			this.radioButtonUDP.TabIndex = 9;
			this.radioButtonUDP.TabStop = true;
			this.radioButtonUDP.Text = "UDP";
			this.radioButtonUDP.UseVisualStyleBackColor = true;
			this.radioButtonUDP.CheckedChanged += new System.EventHandler(this.radioButtonUDP_CheckedChanged);
			// 
			// textBoxPuertoCliente
			// 
			this.textBoxPuertoCliente.Location = new System.Drawing.Point(176, 61);
			this.textBoxPuertoCliente.Name = "textBoxPuertoCliente";
			this.textBoxPuertoCliente.Size = new System.Drawing.Size(50, 20);
			this.textBoxPuertoCliente.TabIndex = 11;
			this.textBoxPuertoCliente.Text = "7006";
			this.textBoxPuertoCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// labelPuertoCliente
			// 
			this.labelPuertoCliente.AutoSize = true;
			this.labelPuertoCliente.Location = new System.Drawing.Point(183, 45);
			this.labelPuertoCliente.Name = "labelPuertoCliente";
			this.labelPuertoCliente.Size = new System.Drawing.Size(38, 13);
			this.labelPuertoCliente.TabIndex = 10;
			this.labelPuertoCliente.Text = "Puerto";
			// 
			// groupBoxCliente
			// 
			this.groupBoxCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBoxCliente.Controls.Add(this.tableLayoutPanel2);
			this.groupBoxCliente.Location = new System.Drawing.Point(12, 160);
			this.groupBoxCliente.Name = "groupBoxCliente";
			this.groupBoxCliente.Size = new System.Drawing.Size(590, 172);
			this.groupBoxCliente.TabIndex = 14;
			this.groupBoxCliente.TabStop = false;
			this.groupBoxCliente.Text = "Enviar";
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Controls.Add(this.panel4, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 0);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 19);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(578, 147);
			this.tableLayoutPanel2.TabIndex = 2;
			// 
			// panel4
			// 
			this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel4.Controls.Add(this.buttonEnviarCliente);
			this.panel4.Controls.Add(this.label7);
			this.panel4.Controls.Add(this.textBoxDatosEnviados);
			this.panel4.Location = new System.Drawing.Point(3, 3);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(283, 141);
			this.panel4.TabIndex = 9;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(3, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(82, 13);
			this.label7.TabIndex = 2;
			this.label7.Text = "Datos Enviados";
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel3.ColumnCount = 1;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.Controls.Add(this.panel3, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.panel5, 0, 1);
			this.tableLayoutPanel3.Location = new System.Drawing.Point(292, 3);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 2;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(283, 141);
			this.tableLayoutPanel3.TabIndex = 10;
			// 
			// panel3
			// 
			this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel3.Controls.Add(this.textBoxEnviarComando);
			this.panel3.Controls.Add(this.label4);
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Margin = new System.Windows.Forms.Padding(0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(283, 70);
			this.panel3.TabIndex = 9;
			// 
			// textBoxEnviarComando
			// 
			this.textBoxEnviarComando.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxEnviarComando.Location = new System.Drawing.Point(6, 16);
			this.textBoxEnviarComando.MaxLength = 400000;
			this.textBoxEnviarComando.Multiline = true;
			this.textBoxEnviarComando.Name = "textBoxEnviarComando";
			this.textBoxEnviarComando.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxEnviarComando.Size = new System.Drawing.Size(274, 51);
			this.textBoxEnviarComando.TabIndex = 1;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(52, 13);
			this.label4.TabIndex = 2;
			this.label4.Text = "Comando";
			// 
			// panel5
			// 
			this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel5.Controls.Add(this.buttonEnviarCommando);
			this.panel5.Controls.Add(this.textBoxEnviarDato);
			this.panel5.Controls.Add(this.label5);
			this.panel5.Location = new System.Drawing.Point(0, 70);
			this.panel5.Margin = new System.Windows.Forms.Padding(0);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(283, 71);
			this.panel5.TabIndex = 10;
			// 
			// buttonEnviarCommando
			// 
			this.buttonEnviarCommando.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonEnviarCommando.Location = new System.Drawing.Point(209, 45);
			this.buttonEnviarCommando.Name = "buttonEnviarCommando";
			this.buttonEnviarCommando.Size = new System.Drawing.Size(45, 23);
			this.buttonEnviarCommando.TabIndex = 23;
			this.buttonEnviarCommando.Text = "Enviar";
			this.buttonEnviarCommando.UseVisualStyleBackColor = true;
			this.buttonEnviarCommando.Click += new System.EventHandler(this.buttonEnviarCommando_Click);
			// 
			// textBoxEnviarDato
			// 
			this.textBoxEnviarDato.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxEnviarDato.Location = new System.Drawing.Point(6, 16);
			this.textBoxEnviarDato.MaxLength = 400000;
			this.textBoxEnviarDato.Multiline = true;
			this.textBoxEnviarDato.Name = "textBoxEnviarDato";
			this.textBoxEnviarDato.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxEnviarDato.Size = new System.Drawing.Size(274, 55);
			this.textBoxEnviarDato.TabIndex = 1;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(3, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(30, 13);
			this.label5.TabIndex = 2;
			this.label5.Text = "Dato";
			// 
			// buttonEnviarArchivoo
			// 
			this.buttonEnviarArchivoo.Location = new System.Drawing.Point(36, 111);
			this.buttonEnviarArchivoo.Name = "buttonEnviarArchivoo";
			this.buttonEnviarArchivoo.Size = new System.Drawing.Size(45, 36);
			this.buttonEnviarArchivoo.TabIndex = 25;
			this.buttonEnviarArchivoo.Text = "Env A";
			this.buttonEnviarArchivoo.UseVisualStyleBackColor = true;
			this.buttonEnviarArchivoo.Click += new System.EventHandler(this.buttonEnviarArchivo_Click);
			// 
			// textBoxComando
			// 
			this.textBoxComando.Location = new System.Drawing.Point(4, 43);
			this.textBoxComando.Name = "textBoxComando";
			this.textBoxComando.Size = new System.Drawing.Size(72, 20);
			this.textBoxComando.TabIndex = 24;
			this.textBoxComando.Text = "EnvTexto";
			this.textBoxComando.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// buttonEnviarRafaga
			// 
			this.buttonEnviarRafaga.Location = new System.Drawing.Point(4, 18);
			this.buttonEnviarRafaga.Name = "buttonEnviarRafaga";
			this.buttonEnviarRafaga.Size = new System.Drawing.Size(72, 23);
			this.buttonEnviarRafaga.TabIndex = 22;
			this.buttonEnviarRafaga.Text = "EnviarRafaga";
			this.buttonEnviarRafaga.UseVisualStyleBackColor = true;
			this.buttonEnviarRafaga.Click += new System.EventHandler(this.buttonEnviarRafaga_Click);
			// 
			// buttonSetInterval
			// 
			this.buttonSetInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonSetInterval.Location = new System.Drawing.Point(533, 417);
			this.buttonSetInterval.Name = "buttonSetInterval";
			this.buttonSetInterval.Size = new System.Drawing.Size(34, 20);
			this.buttonSetInterval.TabIndex = 21;
			this.buttonSetInterval.Text = "Set";
			this.buttonSetInterval.UseVisualStyleBackColor = true;
			this.buttonSetInterval.Click += new System.EventHandler(this.buttonSetInterval_Click);
			// 
			// textBoxIntervalTest
			// 
			this.textBoxIntervalTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.textBoxIntervalTest.Location = new System.Drawing.Point(490, 417);
			this.textBoxIntervalTest.Name = "textBoxIntervalTest";
			this.textBoxIntervalTest.Size = new System.Drawing.Size(41, 20);
			this.textBoxIntervalTest.TabIndex = 20;
			this.textBoxIntervalTest.Text = "2000";
			this.textBoxIntervalTest.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// checkBoxReListen
			// 
			this.checkBoxReListen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkBoxReListen.AutoSize = true;
			this.checkBoxReListen.Location = new System.Drawing.Point(418, 363);
			this.checkBoxReListen.Name = "checkBoxReListen";
			this.checkBoxReListen.Size = new System.Drawing.Size(92, 17);
			this.checkBoxReListen.TabIndex = 19;
			this.checkBoxReListen.Text = "ReListen TCP";
			this.checkBoxReListen.UseVisualStyleBackColor = true;
			this.checkBoxReListen.CheckedChanged += new System.EventHandler(this.checkBoxReListen_CheckedChanged);
			// 
			// checkBoxReConnect
			// 
			this.checkBoxReConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkBoxReConnect.AutoSize = true;
			this.checkBoxReConnect.Location = new System.Drawing.Point(418, 391);
			this.checkBoxReConnect.Name = "checkBoxReConnect";
			this.checkBoxReConnect.Size = new System.Drawing.Size(98, 17);
			this.checkBoxReConnect.TabIndex = 18;
			this.checkBoxReConnect.Text = "ReConect TCP";
			this.checkBoxReConnect.UseVisualStyleBackColor = true;
			this.checkBoxReConnect.CheckedChanged += new System.EventHandler(this.checkBoxReConnect_CheckedChanged);
			// 
			// checkBoxTestConnect
			// 
			this.checkBoxTestConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkBoxTestConnect.AutoSize = true;
			this.checkBoxTestConnect.Checked = true;
			this.checkBoxTestConnect.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxTestConnect.Location = new System.Drawing.Point(418, 419);
			this.checkBoxTestConnect.Name = "checkBoxTestConnect";
			this.checkBoxTestConnect.Size = new System.Drawing.Size(66, 17);
			this.checkBoxTestConnect.TabIndex = 17;
			this.checkBoxTestConnect.Text = "TestCon";
			this.checkBoxTestConnect.UseVisualStyleBackColor = true;
			this.checkBoxTestConnect.CheckedChanged += new System.EventHandler(this.checkBoxTestConnect_CheckedChanged);
			// 
			// buttonDesConectar
			// 
			this.buttonDesConectar.Location = new System.Drawing.Point(76, 19);
			this.buttonDesConectar.Name = "buttonDesConectar";
			this.buttonDesConectar.Size = new System.Drawing.Size(83, 23);
			this.buttonDesConectar.TabIndex = 16;
			this.buttonDesConectar.Text = "DesConectar";
			this.buttonDesConectar.UseVisualStyleBackColor = true;
			this.buttonDesConectar.Click += new System.EventHandler(this.buttonDesConectar_Click);
			// 
			// textBoxStatusControl
			// 
			this.textBoxStatusControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.textBoxStatusControl.Location = new System.Drawing.Point(12, 338);
			this.textBoxStatusControl.Multiline = true;
			this.textBoxStatusControl.Name = "textBoxStatusControl";
			this.textBoxStatusControl.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxStatusControl.Size = new System.Drawing.Size(234, 260);
			this.textBoxStatusControl.TabIndex = 15;
			// 
			// buttonConectar
			// 
			this.buttonConectar.Location = new System.Drawing.Point(6, 19);
			this.buttonConectar.Name = "buttonConectar";
			this.buttonConectar.Size = new System.Drawing.Size(64, 23);
			this.buttonConectar.TabIndex = 14;
			this.buttonConectar.Text = "Conectar";
			this.buttonConectar.UseVisualStyleBackColor = true;
			this.buttonConectar.Click += new System.EventHandler(this.buttonConectar_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(6, 61);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(164, 20);
			this.textBox1.TabIndex = 13;
			this.textBox1.Text = "127.0.0.1";
			this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(48, 45);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(74, 13);
			this.label1.TabIndex = 12;
			this.label1.Text = "Direccion o IP";
			// 
			// groupBoxServidor
			// 
			this.groupBoxServidor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBoxServidor.Controls.Add(this.labelComandosCount);
			this.groupBoxServidor.Controls.Add(this.tableLayoutPanel1);
			this.groupBoxServidor.Controls.Add(this.labelBytesCount);
			this.groupBoxServidor.Location = new System.Drawing.Point(12, 35);
			this.groupBoxServidor.Name = "groupBoxServidor";
			this.groupBoxServidor.Size = new System.Drawing.Size(590, 119);
			this.groupBoxServidor.TabIndex = 15;
			this.groupBoxServidor.TabStop = false;
			this.groupBoxServidor.Text = "Recibido";
			// 
			// labelComandosCount
			// 
			this.labelComandosCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelComandosCount.Location = new System.Drawing.Point(301, 96);
			this.labelComandosCount.Name = "labelComandosCount";
			this.labelComandosCount.Size = new System.Drawing.Size(259, 20);
			this.labelComandosCount.TabIndex = 7;
			this.labelComandosCount.Text = "Cerrado:";
			this.labelComandosCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 19);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(578, 74);
			this.tableLayoutPanel1.TabIndex = 6;
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.Controls.Add(this.label3);
			this.panel2.Controls.Add(this.textBoxComandoRecibido);
			this.panel2.Location = new System.Drawing.Point(292, 3);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(283, 68);
			this.panel2.TabIndex = 8;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(107, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Comandos Recibidos";
			// 
			// textBoxComandoRecibido
			// 
			this.textBoxComandoRecibido.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxComandoRecibido.Location = new System.Drawing.Point(0, 16);
			this.textBoxComandoRecibido.MaxLength = 400000;
			this.textBoxComandoRecibido.Multiline = true;
			this.textBoxComandoRecibido.Name = "textBoxComandoRecibido";
			this.textBoxComandoRecibido.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxComandoRecibido.Size = new System.Drawing.Size(283, 52);
			this.textBoxComandoRecibido.TabIndex = 1;
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.textBoxDatosRecibidos);
			this.panel1.Location = new System.Drawing.Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(283, 68);
			this.panel1.TabIndex = 7;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(85, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Datos Recibidos";
			// 
			// buttonunSet
			// 
			this.buttonunSet.Location = new System.Drawing.Point(56, 50);
			this.buttonunSet.Name = "buttonunSet";
			this.buttonunSet.Size = new System.Drawing.Size(50, 20);
			this.buttonunSet.TabIndex = 6;
			this.buttonunSet.Text = "unSet";
			this.buttonunSet.UseVisualStyleBackColor = true;
			this.buttonunSet.Click += new System.EventHandler(this.buttonunSet_Click);
			// 
			// timerStatus
			// 
			this.timerStatus.Enabled = true;
			this.timerStatus.Interval = 400;
			this.timerStatus.Tick += new System.EventHandler(this.timerStatus_Tick);
			// 
			// labelInformacion
			// 
			this.labelInformacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelInformacion.AutoSize = true;
			this.labelInformacion.Location = new System.Drawing.Point(260, 338);
			this.labelInformacion.Name = "labelInformacion";
			this.labelInformacion.Size = new System.Drawing.Size(44, 13);
			this.labelInformacion.TabIndex = 26;
			this.labelInformacion.Text = "Cerrado";
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.groupBox2.Controls.Add(this.labelPuertoServidor);
			this.groupBox2.Controls.Add(this.buttonSetPuerto);
			this.groupBox2.Controls.Add(this.textBoxPuertoServidor);
			this.groupBox2.Controls.Add(this.buttonunSet);
			this.groupBox2.Location = new System.Drawing.Point(253, 357);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(159, 79);
			this.groupBox2.TabIndex = 28;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Escucha TCP o UDP";
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.groupBox3.Controls.Add(this.buttonConectar);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Controls.Add(this.textBox1);
			this.groupBox3.Controls.Add(this.textBoxPuertoCliente);
			this.groupBox3.Controls.Add(this.buttonDesConectar);
			this.groupBox3.Controls.Add(this.labelPuertoCliente);
			this.groupBox3.Location = new System.Drawing.Point(253, 442);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(233, 86);
			this.groupBox3.TabIndex = 30;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Conexion TCP";
			// 
			// groupBox4
			// 
			this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.groupBox4.Controls.Add(this.buttonEnviarRafaga);
			this.groupBox4.Controls.Add(this.textBoxSegundosCliente);
			this.groupBox4.Controls.Add(this.labelSegCliente);
			this.groupBox4.Controls.Add(this.textBoxComando);
			this.groupBox4.Controls.Add(this.buttonEnviarArchivoo);
			this.groupBox4.Location = new System.Drawing.Point(491, 442);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(111, 156);
			this.groupBox4.TabIndex = 31;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Envio Ciclico";
			// 
			// mClienteServidorUdp1
			// 
			this.mClienteServidorUdp1.PuertoEscucha = ((ushort)(80));
			this.mClienteServidorUdp1.ReConexionAutomatica = false;
			this.mClienteServidorUdp1.ReListenAutomatico = false;
			this.mClienteServidorUdp1.TestearConexion = true;
			this.mClienteServidorUdp1.TiempomSegTestConexion = 2000;
			//this.mClienteServidorUdp1.TipoSock = PeerToPeerTcpUdp.PeerToPeerUdp.eTipoSock.TCP;
			this.mClienteServidorUdp1.ConexionEstablecida += new PeerToPeerTcpUdp.PeerToPeerUdp.ConexionEventHandler(this.clienteServidorTCP_UDP1_ConexionEstablecida);
			this.mClienteServidorUdp1.ConexionCancelada += new PeerToPeerTcpUdp.PeerToPeerUdp.ConexionEventHandler(this.clienteServidorTCP_UDP1_ConexionCancelada);
			this.mClienteServidorUdp1.EscuchaIniciada += new PeerToPeerTcpUdp.PeerToPeerUdp.ConexionEventHandler(this.clienteServidorTCP_UDP1_EscuchaIniciada);
			this.mClienteServidorUdp1.EscuchaIniciando += new PeerToPeerTcpUdp.PeerToPeerUdp.ConexionEventHandler(this.clienteServidorTCP_UDP1_EscuchaIniciando);
			this.mClienteServidorUdp1.EscuchaCancelada += new PeerToPeerTcpUdp.PeerToPeerUdp.ConexionEventHandler(this.clienteServidorTCP_UDP1_EscuchaCancelada);
			this.mClienteServidorUdp1.DatosRecibidos += new PeerToPeerTcpUdp.PeerToPeerUdp.ConexionEventHandler(this.clienteServidorTCP_UDP1_DatosRecibidos);
			this.mClienteServidorUdp1.ComandoRecibido += new PeerToPeerTcpUdp.PeerToPeerUdp.ConexionEventHandler(this.clienteServidorTCP_UDP1_ComandoRecibido);
			this.mClienteServidorUdp1.ConexionPerdida += new PeerToPeerTcpUdp.PeerToPeerUdp.ConexionEventHandler(this.clienteServidorTCP_UDP1_ConexionPerdida);
			// 
			// Servidor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(614, 605);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.labelInformacion);
			this.Controls.Add(this.groupBoxServidor);
			this.Controls.Add(this.groupBoxCliente);
			this.Controls.Add(this.buttonSetInterval);
			this.Controls.Add(this.textBoxIntervalTest);
			this.Controls.Add(this.radioButtonUDP);
			this.Controls.Add(this.checkBoxReListen);
			this.Controls.Add(this.checkBoxReConnect);
			this.Controls.Add(this.radioButtonTCP);
			this.Controls.Add(this.checkBoxTestConnect);
			this.Controls.Add(this.textBoxStatusControl);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Servidor";
			this.Text = "Cliente y Servidor TCP y UDP";
			this.groupBoxCliente.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.tableLayoutPanel3.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.groupBoxServidor.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPuertoServidor;
		private System.Windows.Forms.TextBox textBoxDatosRecibidos;
        private System.Windows.Forms.TextBox textBoxPuertoServidor;
        private System.Windows.Forms.Button buttonSetPuerto;
		private System.Windows.Forms.Label labelBytesCount;
		private System.Windows.Forms.TextBox textBoxDatosEnviados;
		private System.Windows.Forms.Button buttonEnviarCliente;
		private System.Windows.Forms.TextBox textBoxSegundosCliente;
		private System.Windows.Forms.Label labelSegCliente;
		private System.Windows.Forms.RadioButton radioButtonTCP;
		private System.Windows.Forms.RadioButton radioButtonUDP;
		private System.Windows.Forms.TextBox textBoxPuertoCliente;
		private System.Windows.Forms.Label labelPuertoCliente;
		private System.Windows.Forms.GroupBox groupBoxCliente;
		private System.Windows.Forms.GroupBox groupBoxServidor;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private PeerToPeerTcpUdp.PeerToPeerUdp mClienteServidorUdp1;
		private System.Windows.Forms.Button buttonConectar;
		private System.Windows.Forms.Button buttonunSet;
		private System.Windows.Forms.Timer timerStatus;
		private System.Windows.Forms.TextBox textBoxStatusControl;
		private System.Windows.Forms.Button buttonDesConectar;
		private System.Windows.Forms.CheckBox checkBoxTestConnect;
		private System.Windows.Forms.CheckBox checkBoxReListen;
		private System.Windows.Forms.CheckBox checkBoxReConnect;
		private System.Windows.Forms.Button buttonSetInterval;
		private System.Windows.Forms.TextBox textBoxIntervalTest;
		private System.Windows.Forms.Button buttonEnviarRafaga;
		private System.Windows.Forms.Button buttonEnviarCommando;
		private System.Windows.Forms.TextBox textBoxComando;
		private System.Windows.Forms.Button buttonEnviarArchivoo;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBoxComandoRecibido;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.TextBox textBoxEnviarComando;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.TextBox textBoxEnviarDato;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label labelComandosCount;
		private System.Windows.Forms.Label labelInformacion;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox4;
    }
}

