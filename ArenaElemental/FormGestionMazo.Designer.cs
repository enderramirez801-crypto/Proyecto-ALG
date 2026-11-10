/*
 * Created by SharpDevelop.
 * User: Ender
 * Date: 5/11/2026
 * Time: 5:35 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ArenaElemental
{
	partial class FormGestionMazo
	{
		private System.ComponentModel.IContainer components = null;

		private System.Windows.Forms.Panel pnlHeader;
		private System.Windows.Forms.Label lblTitulo;
		private System.Windows.Forms.Label lblSub;
		private System.Windows.Forms.GroupBox grpJugador;
		private System.Windows.Forms.Label lblSel;
		private System.Windows.Forms.ComboBox cboJugadores;
		private System.Windows.Forms.Label lblNuevo;
		private System.Windows.Forms.TextBox txtNuevoNombre;
		private System.Windows.Forms.Button btnCrearJugador;
		private System.Windows.Forms.Button btnBorrarTodo;
		private System.Windows.Forms.GroupBox grpMazo;
		private System.Windows.Forms.Label lblCat;
		private System.Windows.Forms.ListBox lstCatalogo;
		private System.Windows.Forms.PictureBox picPreviaCarta;
		private System.Windows.Forms.Button btnAgregar;
		private System.Windows.Forms.Button btnQuitar;
		private System.Windows.Forms.Button btnGuardarMazo;
		private System.Windows.Forms.Label lblMazo;
		private System.Windows.Forms.ListBox lstMazo;
		private System.Windows.Forms.GroupBox grpEsc;
		private System.Windows.Forms.Label lblE1;
		private System.Windows.Forms.ComboBox cboEscenario1;
		private System.Windows.Forms.PictureBox picArena1;
		private System.Windows.Forms.CheckBox chkAlternar;
		private System.Windows.Forms.ComboBox cboEscenario2;
		private System.Windows.Forms.PictureBox picArena2;
		private System.Windows.Forms.Label lblJ1;
		private System.Windows.Forms.ComboBox cboCombateJ1;
		private System.Windows.Forms.Label lblJ2;
		private System.Windows.Forms.ComboBox cboCombateJ2;
		private System.Windows.Forms.Label lblModo;
		private System.Windows.Forms.ComboBox cboModoMenu;
		private System.Windows.Forms.Label lblIp;
		private System.Windows.Forms.TextBox txtIpMenu;
		private System.Windows.Forms.Label lblEst;
		private System.Windows.Forms.ListBox lstRanking;
		private System.Windows.Forms.Button btnIniciarCombate;
		private System.Windows.Forms.Button btnVerLoreHeader;
		private System.Windows.Forms.Button btnVerLoreMazo;
		private System.Windows.Forms.Button btnIdioma;

		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.pnlHeader = new System.Windows.Forms.Panel();
			this.lblTitulo = new System.Windows.Forms.Label();
			this.lblSub = new System.Windows.Forms.Label();
			this.grpJugador = new System.Windows.Forms.GroupBox();
			this.lblSel = new System.Windows.Forms.Label();
			this.cboJugadores = new System.Windows.Forms.ComboBox();
			this.lblNuevo = new System.Windows.Forms.Label();
			this.txtNuevoNombre = new System.Windows.Forms.TextBox();
			this.btnCrearJugador = new System.Windows.Forms.Button();
			this.btnBorrarTodo = new System.Windows.Forms.Button();
			this.grpMazo = new System.Windows.Forms.GroupBox();
			this.lblCat = new System.Windows.Forms.Label();
			this.lstCatalogo = new System.Windows.Forms.ListBox();
			this.picPreviaCarta = new System.Windows.Forms.PictureBox();
			this.btnAgregar = new System.Windows.Forms.Button();
			this.btnQuitar = new System.Windows.Forms.Button();
			this.btnGuardarMazo = new System.Windows.Forms.Button();
			this.lblMazo = new System.Windows.Forms.Label();
			this.lstMazo = new System.Windows.Forms.ListBox();
			this.grpEsc = new System.Windows.Forms.GroupBox();
			this.lblE1 = new System.Windows.Forms.Label();
			this.cboEscenario1 = new System.Windows.Forms.ComboBox();
			this.picArena1 = new System.Windows.Forms.PictureBox();
			this.chkAlternar = new System.Windows.Forms.CheckBox();
			this.cboEscenario2 = new System.Windows.Forms.ComboBox();
			this.picArena2 = new System.Windows.Forms.PictureBox();
			this.lblJ1 = new System.Windows.Forms.Label();
			this.cboCombateJ1 = new System.Windows.Forms.ComboBox();
			this.lblJ2 = new System.Windows.Forms.Label();
			this.cboCombateJ2 = new System.Windows.Forms.ComboBox();
			this.lblModo = new System.Windows.Forms.Label();
			this.cboModoMenu = new System.Windows.Forms.ComboBox();
			this.lblIp = new System.Windows.Forms.Label();
			this.txtIpMenu = new System.Windows.Forms.TextBox();
			this.lblEst = new System.Windows.Forms.Label();
			this.lstRanking = new System.Windows.Forms.ListBox();
			this.btnIniciarCombate = new System.Windows.Forms.Button();
			this.btnVerLoreHeader = new System.Windows.Forms.Button();
			this.btnVerLoreMazo = new System.Windows.Forms.Button();
			this.btnIdioma = new System.Windows.Forms.Button();
			this.pnlHeader.SuspendLayout();
			this.grpJugador.SuspendLayout();
			this.grpMazo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picPreviaCarta)).BeginInit();
			this.grpEsc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picArena1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picArena2)).BeginInit();
			this.SuspendLayout();
			// 
			// pnlHeader
			// 
			this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(30, 42, 66);
			this.pnlHeader.Controls.Add(this.lblTitulo);
			this.pnlHeader.Controls.Add(this.lblSub);
			this.pnlHeader.Controls.Add(this.btnIdioma);
			this.pnlHeader.Controls.Add(this.btnVerLoreHeader);
			this.pnlHeader.Location = new System.Drawing.Point(0, 0);
			this.pnlHeader.Name = "pnlHeader";
			this.pnlHeader.Size = new System.Drawing.Size(860, 54);
			this.pnlHeader.TabIndex = 0;
			// 
			// lblTitulo
			// 
			this.lblTitulo.AutoSize = true;
			this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.lblTitulo.ForeColor = System.Drawing.Color.White;
			this.lblTitulo.Location = new System.Drawing.Point(16, 6);
			this.lblTitulo.Name = "lblTitulo";
			this.lblTitulo.Size = new System.Drawing.Size(420, 23);
			this.lblTitulo.TabIndex = 0;
			this.lblTitulo.Text = "POKÉMON ARENA ELEMENTAL - MENÚ DE INICIO";
			// 
			// lblSub
			// 
			this.lblSub.AutoSize = true;
			this.lblSub.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.lblSub.ForeColor = System.Drawing.Color.LightSteelBlue;
			this.lblSub.Location = new System.Drawing.Point(18, 32);
			this.lblSub.Name = "lblSub";
			this.lblSub.Size = new System.Drawing.Size(500, 16);
			this.lblSub.TabIndex = 1;
			this.lblSub.Text = "Registra los jugadores, arma su equipo de 5 cartas Pokémon, elige la Arena, consulta el Lore e inicia el combate";
			// 
			// btnIdioma
			// 
			this.btnIdioma.BackColor = System.Drawing.Color.FromArgb(40, 130, 95);
			this.btnIdioma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnIdioma.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.btnIdioma.ForeColor = System.Drawing.Color.White;
			this.btnIdioma.Location = new System.Drawing.Point(525, 11);
			this.btnIdioma.Name = "btnIdioma";
			this.btnIdioma.Size = new System.Drawing.Size(132, 32);
			this.btnIdioma.TabIndex = 3;
			this.btnIdioma.Text = "🌐 Idioma: ES";
			this.btnIdioma.UseVisualStyleBackColor = false;
			this.btnIdioma.Click += new System.EventHandler(this.BtnIdioma_Click);
			// 
			// btnVerLoreHeader
			// 
			this.btnVerLoreHeader.BackColor = System.Drawing.Color.FromArgb(215, 155, 35);
			this.btnVerLoreHeader.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnVerLoreHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.btnVerLoreHeader.ForeColor = System.Drawing.Color.White;
			this.btnVerLoreHeader.Location = new System.Drawing.Point(665, 11);
			this.btnVerLoreHeader.Name = "btnVerLoreHeader";
			this.btnVerLoreHeader.Size = new System.Drawing.Size(180, 32);
			this.btnVerLoreHeader.TabIndex = 2;
			this.btnVerLoreHeader.Text = "📜 Lore de los Pokémon";
			this.btnVerLoreHeader.UseVisualStyleBackColor = false;
			this.btnVerLoreHeader.Click += new System.EventHandler(this.BtnVerLore_Click);
			// 
			// grpJugador
			// 
			this.grpJugador.Controls.Add(this.lblSel);
			this.grpJugador.Controls.Add(this.cboJugadores);
			this.grpJugador.Controls.Add(this.lblNuevo);
			this.grpJugador.Controls.Add(this.txtNuevoNombre);
			this.grpJugador.Controls.Add(this.btnCrearJugador);
			this.grpJugador.Controls.Add(this.btnBorrarTodo);
			this.grpJugador.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.grpJugador.Location = new System.Drawing.Point(15, 62);
			this.grpJugador.Name = "grpJugador";
			this.grpJugador.Size = new System.Drawing.Size(830, 64);
			this.grpJugador.TabIndex = 1;
			this.grpJugador.TabStop = false;
			this.grpJugador.Text = "1. Registrar o Seleccionar Jugador";
			// 
			// lblSel
			// 
			this.lblSel.AutoSize = true;
			this.lblSel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.lblSel.Location = new System.Drawing.Point(14, 28);
			this.lblSel.Name = "lblSel";
			this.lblSel.Size = new System.Drawing.Size(52, 16);
			this.lblSel.TabIndex = 0;
			this.lblSel.Text = "Jugador:";
			// 
			// cboJugadores
			// 
			this.cboJugadores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboJugadores.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.cboJugadores.Location = new System.Drawing.Point(75, 25);
			this.cboJugadores.Name = "cboJugadores";
			this.cboJugadores.Size = new System.Drawing.Size(185, 24);
			this.cboJugadores.TabIndex = 1;
			this.cboJugadores.SelectedIndexChanged += new System.EventHandler(this.CboJugadores_SelectedIndexChanged);
			// 
			// lblNuevo
			// 
			this.lblNuevo.AutoSize = true;
			this.lblNuevo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.lblNuevo.Location = new System.Drawing.Point(275, 28);
			this.lblNuevo.Name = "lblNuevo";
			this.lblNuevo.Size = new System.Drawing.Size(90, 16);
			this.lblNuevo.TabIndex = 2;
			this.lblNuevo.Text = "Nuevo Jugador:";
			// 
			// txtNuevoNombre
			// 
			this.txtNuevoNombre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.txtNuevoNombre.Location = new System.Drawing.Point(378, 25);
			this.txtNuevoNombre.Name = "txtNuevoNombre";
			this.txtNuevoNombre.Size = new System.Drawing.Size(175, 22);
			this.txtNuevoNombre.TabIndex = 3;
			// 
			// btnCrearJugador
			// 
			this.btnCrearJugador.BackColor = System.Drawing.Color.FromArgb(40, 105, 170);
			this.btnCrearJugador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCrearJugador.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.btnCrearJugador.ForeColor = System.Drawing.Color.White;
			this.btnCrearJugador.Location = new System.Drawing.Point(565, 22);
			this.btnCrearJugador.Name = "btnCrearJugador";
			this.btnCrearJugador.Size = new System.Drawing.Size(140, 30);
			this.btnCrearJugador.TabIndex = 4;
			this.btnCrearJugador.Text = "Agregar Jugador";
			this.btnCrearJugador.UseVisualStyleBackColor = false;
			this.btnCrearJugador.Click += new System.EventHandler(this.BtnCrearJugador_Click);
			// 
			// btnBorrarTodo
			// 
			this.btnBorrarTodo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.btnBorrarTodo.Location = new System.Drawing.Point(715, 22);
			this.btnBorrarTodo.Name = "btnBorrarTodo";
			this.btnBorrarTodo.Size = new System.Drawing.Size(102, 30);
			this.btnBorrarTodo.TabIndex = 5;
			this.btnBorrarTodo.Text = "Reiniciar a 0";
			this.btnBorrarTodo.UseVisualStyleBackColor = true;
			this.btnBorrarTodo.Click += new System.EventHandler(this.BtnBorrarTodo_Click);
			// 
			// grpMazo
			// 
			this.grpMazo.Controls.Add(this.lblCat);
			this.grpMazo.Controls.Add(this.lstCatalogo);
			this.grpMazo.Controls.Add(this.picPreviaCarta);
			this.grpMazo.Controls.Add(this.btnAgregar);
			this.grpMazo.Controls.Add(this.btnQuitar);
			this.grpMazo.Controls.Add(this.btnGuardarMazo);
			this.grpMazo.Controls.Add(this.btnVerLoreMazo);
			this.grpMazo.Controls.Add(this.lblMazo);
			this.grpMazo.Controls.Add(this.lstMazo);
			this.grpMazo.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.grpMazo.Location = new System.Drawing.Point(15, 132);
			this.grpMazo.Name = "grpMazo";
			this.grpMazo.Size = new System.Drawing.Size(830, 212);
			this.grpMazo.TabIndex = 2;
			this.grpMazo.TabStop = false;
			this.grpMazo.Text = "2. Armar Equipo de 5 Cartas Pokémon (12 Pokémon Disponibles)";
			// 
			// lblCat
			// 
			this.lblCat.AutoSize = true;
			this.lblCat.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.lblCat.Location = new System.Drawing.Point(15, 22);
			this.lblCat.Name = "lblCat";
			this.lblCat.Size = new System.Drawing.Size(210, 16);
			this.lblCat.TabIndex = 0;
			this.lblCat.Text = "Catálogo de Cartas Pokémon (12):";
			// 
			// lstCatalogo
			// 
			this.lstCatalogo.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.lstCatalogo.ItemHeight = 15;
			this.lstCatalogo.Location = new System.Drawing.Point(15, 42);
			this.lstCatalogo.Name = "lstCatalogo";
			this.lstCatalogo.Size = new System.Drawing.Size(275, 154);
			this.lstCatalogo.TabIndex = 1;
			this.lstCatalogo.SelectedIndexChanged += new System.EventHandler(this.LstCatalogo_SelectedIndexChanged);
			// 
			// picPreviaCarta
			// 
			this.picPreviaCarta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picPreviaCarta.Location = new System.Drawing.Point(302, 38);
			this.picPreviaCarta.Name = "picPreviaCarta";
			this.picPreviaCarta.Size = new System.Drawing.Size(120, 160);
			this.picPreviaCarta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picPreviaCarta.TabIndex = 2;
			this.picPreviaCarta.TabStop = false;
			// 
			// btnAgregar
			// 
			this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.btnAgregar.Location = new System.Drawing.Point(436, 38);
			this.btnAgregar.Name = "btnAgregar";
			this.btnAgregar.Size = new System.Drawing.Size(110, 34);
			this.btnAgregar.TabIndex = 3;
			this.btnAgregar.Text = "Agregar >>";
			this.btnAgregar.UseVisualStyleBackColor = true;
			this.btnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
			// 
			// btnQuitar
			// 
			this.btnQuitar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.btnQuitar.Location = new System.Drawing.Point(436, 78);
			this.btnQuitar.Name = "btnQuitar";
			this.btnQuitar.Size = new System.Drawing.Size(110, 34);
			this.btnQuitar.TabIndex = 4;
			this.btnQuitar.Text = "<< Quitar";
			this.btnQuitar.UseVisualStyleBackColor = true;
			this.btnQuitar.Click += new System.EventHandler(this.BtnQuitar_Click);
			// 
			// btnGuardarMazo
			// 
			this.btnGuardarMazo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.btnGuardarMazo.Location = new System.Drawing.Point(436, 118);
			this.btnGuardarMazo.Name = "btnGuardarMazo";
			this.btnGuardarMazo.Size = new System.Drawing.Size(110, 34);
			this.btnGuardarMazo.TabIndex = 5;
			this.btnGuardarMazo.Text = "Guardar Mazo";
			this.btnGuardarMazo.UseVisualStyleBackColor = true;
			this.btnGuardarMazo.Click += new System.EventHandler(this.BtnGuardarMazo_Click);
			// 
			// btnVerLoreMazo
			// 
			this.btnVerLoreMazo.BackColor = System.Drawing.Color.FromArgb(40, 105, 170);
			this.btnVerLoreMazo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnVerLoreMazo.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.btnVerLoreMazo.ForeColor = System.Drawing.Color.White;
			this.btnVerLoreMazo.Location = new System.Drawing.Point(436, 158);
			this.btnVerLoreMazo.Name = "btnVerLoreMazo";
			this.btnVerLoreMazo.Size = new System.Drawing.Size(110, 34);
			this.btnVerLoreMazo.TabIndex = 8;
			this.btnVerLoreMazo.Text = "Ver Lore";
			this.btnVerLoreMazo.UseVisualStyleBackColor = false;
			this.btnVerLoreMazo.Click += new System.EventHandler(this.BtnVerLore_Click);
			// 
			// lblMazo
			// 
			this.lblMazo.AutoSize = true;
			this.lblMazo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.lblMazo.Location = new System.Drawing.Point(560, 22);
			this.lblMazo.Name = "lblMazo";
			this.lblMazo.Size = new System.Drawing.Size(230, 16);
			this.lblMazo.TabIndex = 6;
			this.lblMazo.Text = "Equipo Pokémon del Jugador (0 / 5):";
			// 
			// lstMazo
			// 
			this.lstMazo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.lstMazo.ItemHeight = 16;
			this.lstMazo.Location = new System.Drawing.Point(560, 42);
			this.lstMazo.Name = "lstMazo";
			this.lstMazo.Size = new System.Drawing.Size(255, 148);
			this.lstMazo.TabIndex = 7;
			this.lstMazo.SelectedIndexChanged += new System.EventHandler(this.LstMazo_SelectedIndexChanged);
			// 
			// grpEsc
			// 
			this.grpEsc.Controls.Add(this.lblE1);
			this.grpEsc.Controls.Add(this.cboEscenario1);
			this.grpEsc.Controls.Add(this.picArena1);
			this.grpEsc.Controls.Add(this.chkAlternar);
			this.grpEsc.Controls.Add(this.cboEscenario2);
			this.grpEsc.Controls.Add(this.picArena2);
			this.grpEsc.Controls.Add(this.lblJ1);
			this.grpEsc.Controls.Add(this.cboCombateJ1);
			this.grpEsc.Controls.Add(this.lblJ2);
			this.grpEsc.Controls.Add(this.cboCombateJ2);
			this.grpEsc.Controls.Add(this.lblModo);
			this.grpEsc.Controls.Add(this.cboModoMenu);
			this.grpEsc.Controls.Add(this.lblIp);
			this.grpEsc.Controls.Add(this.txtIpMenu);
			this.grpEsc.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.grpEsc.Location = new System.Drawing.Point(15, 350);
			this.grpEsc.Name = "grpEsc";
			this.grpEsc.Size = new System.Drawing.Size(830, 182);
			this.grpEsc.TabIndex = 3;
			this.grpEsc.TabStop = false;
			this.grpEsc.Text = "3. Seleccionar Arenas de Combate y Contendientes";
			// 
			// lblE1
			// 
			this.lblE1.AutoSize = true;
			this.lblE1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.lblE1.Location = new System.Drawing.Point(15, 26);
			this.lblE1.Name = "lblE1";
			this.lblE1.Size = new System.Drawing.Size(55, 16);
			this.lblE1.TabIndex = 0;
			this.lblE1.Text = "Arena 1:";
			// 
			// cboEscenario1
			// 
			this.cboEscenario1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboEscenario1.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.cboEscenario1.Location = new System.Drawing.Point(75, 23);
			this.cboEscenario1.Name = "cboEscenario1";
			this.cboEscenario1.Size = new System.Drawing.Size(215, 23);
			this.cboEscenario1.TabIndex = 1;
			this.cboEscenario1.SelectedIndexChanged += new System.EventHandler(this.CboEscenario1_SelectedIndexChanged);
			// 
			// picArena1
			// 
			this.picArena1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picArena1.Location = new System.Drawing.Point(15, 52);
			this.picArena1.Name = "picArena1";
			this.picArena1.Size = new System.Drawing.Size(275, 116);
			this.picArena1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picArena1.TabIndex = 2;
			this.picArena1.TabStop = false;
			// 
			// chkAlternar
			// 
			this.chkAlternar.AutoSize = true;
			this.chkAlternar.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.chkAlternar.Location = new System.Drawing.Point(304, 25);
			this.chkAlternar.Name = "chkAlternar";
			this.chkAlternar.Size = new System.Drawing.Size(138, 19);
			this.chkAlternar.TabIndex = 3;
			this.chkAlternar.Text = "Alternar con Arena 2:";
			// 
			// cboEscenario2
			// 
			this.cboEscenario2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboEscenario2.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.cboEscenario2.Location = new System.Drawing.Point(445, 23);
			this.cboEscenario2.Name = "cboEscenario2";
			this.cboEscenario2.Size = new System.Drawing.Size(134, 23);
			this.cboEscenario2.TabIndex = 4;
			this.cboEscenario2.SelectedIndexChanged += new System.EventHandler(this.CboEscenario2_SelectedIndexChanged);
			// 
			// picArena2
			// 
			this.picArena2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picArena2.Location = new System.Drawing.Point(304, 52);
			this.picArena2.Name = "picArena2";
			this.picArena2.Size = new System.Drawing.Size(275, 116);
			this.picArena2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picArena2.TabIndex = 5;
			this.picArena2.TabStop = false;
			// 
			// lblJ1
			// 
			this.lblJ1.AutoSize = true;
			this.lblJ1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.lblJ1.Location = new System.Drawing.Point(595, 25);
			this.lblJ1.Name = "lblJ1";
			this.lblJ1.Size = new System.Drawing.Size(65, 16);
			this.lblJ1.TabIndex = 6;
			this.lblJ1.Text = "Jugador 1:";
			// 
			// cboCombateJ1
			// 
			this.cboCombateJ1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboCombateJ1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.cboCombateJ1.Location = new System.Drawing.Point(670, 22);
			this.cboCombateJ1.Name = "cboCombateJ1";
			this.cboCombateJ1.Size = new System.Drawing.Size(145, 24);
			this.cboCombateJ1.TabIndex = 7;
			// 
			// lblJ2
			// 
			this.lblJ2.AutoSize = true;
			this.lblJ2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.lblJ2.Location = new System.Drawing.Point(595, 57);
			this.lblJ2.Name = "lblJ2";
			this.lblJ2.Size = new System.Drawing.Size(65, 16);
			this.lblJ2.TabIndex = 8;
			this.lblJ2.Text = "Jugador 2:";
			// 
			// cboCombateJ2
			// 
			this.cboCombateJ2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboCombateJ2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.cboCombateJ2.Location = new System.Drawing.Point(670, 54);
			this.cboCombateJ2.Name = "cboCombateJ2";
			this.cboCombateJ2.Size = new System.Drawing.Size(145, 24);
			this.cboCombateJ2.TabIndex = 9;
			// 
			// lblModo
			// 
			this.lblModo.AutoSize = true;
			this.lblModo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.lblModo.Location = new System.Drawing.Point(595, 88);
			this.lblModo.Name = "lblModo";
			this.lblModo.Size = new System.Drawing.Size(115, 16);
			this.lblModo.TabIndex = 10;
			this.lblModo.Text = "Modalidad de Juego:";
			// 
			// cboModoMenu
			// 
			this.cboModoMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboModoMenu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.cboModoMenu.Items.AddRange(new object[] {
			"Local (2 Jugadores)",
			"Local (vs Sistema)",
			"Red (Servidor TCP)",
			"Red (Cliente TCP)"});
			this.cboModoMenu.Location = new System.Drawing.Point(595, 108);
			this.cboModoMenu.Name = "cboModoMenu";
			this.cboModoMenu.Size = new System.Drawing.Size(220, 24);
			this.cboModoMenu.TabIndex = 11;
			// 
			// lblIp
			// 
			this.lblIp.AutoSize = true;
			this.lblIp.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.lblIp.Location = new System.Drawing.Point(595, 144);
			this.lblIp.Name = "lblIp";
			this.lblIp.Size = new System.Drawing.Size(45, 16);
			this.lblIp.TabIndex = 12;
			this.lblIp.Text = "IP Red:";
			// 
			// txtIpMenu
			// 
			this.txtIpMenu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.txtIpMenu.Location = new System.Drawing.Point(650, 141);
			this.txtIpMenu.Name = "txtIpMenu";
			this.txtIpMenu.Size = new System.Drawing.Size(165, 22);
			this.txtIpMenu.TabIndex = 13;
			this.txtIpMenu.Text = "127.0.0.1:5000";
			// 
			// lblEst
			// 
			this.lblEst.AutoSize = true;
			this.lblEst.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.lblEst.Location = new System.Drawing.Point(15, 538);
			this.lblEst.Name = "lblEst";
			this.lblEst.Size = new System.Drawing.Size(410, 16);
			this.lblEst.TabIndex = 4;
			this.lblEst.Text = "Estadísticas Históricas (Partidas, Victorias, Derrotas y % de Éxito):";
			// 
			// lstRanking
			// 
			this.lstRanking.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.lstRanking.ItemHeight = 16;
			this.lstRanking.Location = new System.Drawing.Point(15, 558);
			this.lstRanking.Name = "lstRanking";
			this.lstRanking.Size = new System.Drawing.Size(590, 68);
			this.lstRanking.TabIndex = 5;
			// 
			// btnIniciarCombate
			// 
			this.btnIniciarCombate.BackColor = System.Drawing.Color.FromArgb(205, 50, 35);
			this.btnIniciarCombate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnIniciarCombate.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.btnIniciarCombate.ForeColor = System.Drawing.Color.White;
			this.btnIniciarCombate.Location = new System.Drawing.Point(620, 556);
			this.btnIniciarCombate.Name = "btnIniciarCombate";
			this.btnIniciarCombate.Size = new System.Drawing.Size(225, 72);
			this.btnIniciarCombate.TabIndex = 6;
			this.btnIniciarCombate.Text = "¡INICIAR COMBATE!";
			this.btnIniciarCombate.UseVisualStyleBackColor = false;
			this.btnIniciarCombate.Click += new System.EventHandler(this.BtnIniciarCombate_Click);
			// 
			// FormGestionMazo
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.FromArgb(238, 241, 247);
			this.ClientSize = new System.Drawing.Size(860, 642);
			this.Controls.Add(this.pnlHeader);
			this.Controls.Add(this.grpJugador);
			this.Controls.Add(this.grpMazo);
			this.Controls.Add(this.grpEsc);
			this.Controls.Add(this.lblEst);
			this.Controls.Add(this.lstRanking);
			this.Controls.Add(this.btnIniciarCombate);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "FormGestionMazo";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Pokémon Arena Elemental - Menú de Inicio";
			this.pnlHeader.ResumeLayout(false);
			this.pnlHeader.PerformLayout();
			this.grpJugador.ResumeLayout(false);
			this.grpJugador.PerformLayout();
			this.grpMazo.ResumeLayout(false);
			this.grpMazo.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.picPreviaCarta)).EndInit();
			this.grpEsc.ResumeLayout(false);
			this.grpEsc.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.picArena1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picArena2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
	}
}
