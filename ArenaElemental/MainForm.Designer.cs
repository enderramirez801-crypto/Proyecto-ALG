/*
 * Created by SharpDevelop.
 * User: Ender
 * Date: 4/11/2026
 * Time: 6:27 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ArenaElemental
{
	partial class MainForm
	{
		private System.ComponentModel.IContainer components = null;

		private System.Windows.Forms.Panel pnlBarraCombate;
		private System.Windows.Forms.Label lblEstado;
		private System.Windows.Forms.Label lblEscenario;
		private System.Windows.Forms.Label lblTiempo;
		private System.Windows.Forms.Button btnLoreCombate;
		private System.Windows.Forms.Button btnGuardar;
		private System.Windows.Forms.Button btnVolverMenu;
		private System.Windows.Forms.Button btnIdiomaCombate;
		private System.Windows.Forms.Timer timerTurno;

		private System.Windows.Forms.GroupBox grpJugador1;
		private System.Windows.Forms.PictureBox picCartaJ1;
		private System.Windows.Forms.Label lblCartaJ1;
		private System.Windows.Forms.Label lblEnergiaJ1;
		private System.Windows.Forms.Label lblVidaJ1;
		private System.Windows.Forms.ProgressBar pbVidaJ1;
		private System.Windows.Forms.Label lblEscudoJ1;
		private System.Windows.Forms.ProgressBar pbEscudoJ1;
		private System.Windows.Forms.Label lblEspecialJ1;
		private System.Windows.Forms.ProgressBar pbEspecialJ1;
		private System.Windows.Forms.Label lblColaJ1;
		private System.Windows.Forms.ListBox lstColaJ1;

		private System.Windows.Forms.GroupBox grpJugador2;
		private System.Windows.Forms.PictureBox picCartaJ2;
		private System.Windows.Forms.Label lblCartaJ2;
		private System.Windows.Forms.Label lblEnergiaJ2;
		private System.Windows.Forms.Label lblVidaJ2;
		private System.Windows.Forms.ProgressBar pbVidaJ2;
		private System.Windows.Forms.Label lblEscudoJ2;
		private System.Windows.Forms.ProgressBar pbEscudoJ2;
		private System.Windows.Forms.Label lblEspecialJ2;
		private System.Windows.Forms.ProgressBar pbEspecialJ2;
		private System.Windows.Forms.Label lblColaJ2;
		private System.Windows.Forms.ListBox lstColaJ2;

		private System.Windows.Forms.GroupBox grpAcciones;
		private System.Windows.Forms.PictureBox picArenaActiva;
		private System.Windows.Forms.Button btnAtacar;
		private System.Windows.Forms.Button btnDefender;
		private System.Windows.Forms.Button btnEspecial;
		private System.Windows.Forms.Button btnRelevar;
		private System.Windows.Forms.Button btnPasarTurno;
		private System.Windows.Forms.Button btnTerremoto;
		private System.Windows.Forms.Button btnTerminarCombate;

		private System.Windows.Forms.Label lblHist;
		private System.Windows.Forms.ListBox lstHistorial;
		private System.Windows.Forms.Button btnVerTopePila;
		private System.Windows.Forms.Button btnDeshacerPila;

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
			this.components = new System.ComponentModel.Container();
			this.pnlBarraCombate = new System.Windows.Forms.Panel();
			this.lblEstado = new System.Windows.Forms.Label();
			this.lblEscenario = new System.Windows.Forms.Label();
			this.lblTiempo = new System.Windows.Forms.Label();
			this.btnLoreCombate = new System.Windows.Forms.Button();
			this.btnGuardar = new System.Windows.Forms.Button();
			this.btnVolverMenu = new System.Windows.Forms.Button();
			this.btnIdiomaCombate = new System.Windows.Forms.Button();
			this.timerTurno = new System.Windows.Forms.Timer(this.components);
			this.grpJugador1 = new System.Windows.Forms.GroupBox();
			this.picCartaJ1 = new System.Windows.Forms.PictureBox();
			this.lblCartaJ1 = new System.Windows.Forms.Label();
			this.lblEnergiaJ1 = new System.Windows.Forms.Label();
			this.lblVidaJ1 = new System.Windows.Forms.Label();
			this.pbVidaJ1 = new System.Windows.Forms.ProgressBar();
			this.lblEscudoJ1 = new System.Windows.Forms.Label();
			this.pbEscudoJ1 = new System.Windows.Forms.ProgressBar();
			this.lblEspecialJ1 = new System.Windows.Forms.Label();
			this.pbEspecialJ1 = new System.Windows.Forms.ProgressBar();
			this.lblColaJ1 = new System.Windows.Forms.Label();
			this.lstColaJ1 = new System.Windows.Forms.ListBox();
			this.grpJugador2 = new System.Windows.Forms.GroupBox();
			this.picCartaJ2 = new System.Windows.Forms.PictureBox();
			this.lblCartaJ2 = new System.Windows.Forms.Label();
			this.lblEnergiaJ2 = new System.Windows.Forms.Label();
			this.lblVidaJ2 = new System.Windows.Forms.Label();
			this.pbVidaJ2 = new System.Windows.Forms.ProgressBar();
			this.lblEscudoJ2 = new System.Windows.Forms.Label();
			this.pbEscudoJ2 = new System.Windows.Forms.ProgressBar();
			this.lblEspecialJ2 = new System.Windows.Forms.Label();
			this.pbEspecialJ2 = new System.Windows.Forms.ProgressBar();
			this.lblColaJ2 = new System.Windows.Forms.Label();
			this.lstColaJ2 = new System.Windows.Forms.ListBox();
			this.grpAcciones = new System.Windows.Forms.GroupBox();
			this.picArenaActiva = new System.Windows.Forms.PictureBox();
			this.btnAtacar = new System.Windows.Forms.Button();
			this.btnDefender = new System.Windows.Forms.Button();
			this.btnEspecial = new System.Windows.Forms.Button();
			this.btnRelevar = new System.Windows.Forms.Button();
			this.btnPasarTurno = new System.Windows.Forms.Button();
			this.btnTerremoto = new System.Windows.Forms.Button();
			this.btnTerminarCombate = new System.Windows.Forms.Button();
			this.lblHist = new System.Windows.Forms.Label();
			this.lstHistorial = new System.Windows.Forms.ListBox();
			this.btnVerTopePila = new System.Windows.Forms.Button();
			this.btnDeshacerPila = new System.Windows.Forms.Button();
			this.pnlBarraCombate.SuspendLayout();
			this.grpJugador1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picCartaJ1)).BeginInit();
			this.grpJugador2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picCartaJ2)).BeginInit();
			this.grpAcciones.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picArenaActiva)).BeginInit();
			this.SuspendLayout();
			// 
			// pnlBarraCombate
			// 
			this.pnlBarraCombate.BackColor = System.Drawing.Color.FromArgb(30, 42, 66);
			this.pnlBarraCombate.Controls.Add(this.lblEstado);
			this.pnlBarraCombate.Controls.Add(this.lblEscenario);
			this.pnlBarraCombate.Controls.Add(this.lblTiempo);
			this.pnlBarraCombate.Controls.Add(this.btnIdiomaCombate);
			this.pnlBarraCombate.Controls.Add(this.btnLoreCombate);
			this.pnlBarraCombate.Controls.Add(this.btnGuardar);
			this.pnlBarraCombate.Controls.Add(this.btnVolverMenu);
			this.pnlBarraCombate.Location = new System.Drawing.Point(0, 0);
			this.pnlBarraCombate.Name = "pnlBarraCombate";
			this.pnlBarraCombate.Size = new System.Drawing.Size(950, 52);
			this.pnlBarraCombate.TabIndex = 0;
			// 
			// lblEstado
			// 
			this.lblEstado.AutoSize = true;
			this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.lblEstado.ForeColor = System.Drawing.Color.White;
			this.lblEstado.Location = new System.Drawing.Point(15, 16);
			this.lblEstado.Name = "lblEstado";
			this.lblEstado.Size = new System.Drawing.Size(70, 19);
			this.lblEstado.TabIndex = 0;
			this.lblEstado.Text = "Ronda 1";
			// 
			// lblEscenario
			// 
			this.lblEscenario.AutoSize = true;
			this.lblEscenario.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.lblEscenario.ForeColor = System.Drawing.Color.Khaki;
			this.lblEscenario.Location = new System.Drawing.Point(235, 16);
			this.lblEscenario.Name = "lblEscenario";
			this.lblEscenario.Size = new System.Drawing.Size(65, 19);
			this.lblEscenario.TabIndex = 1;
			this.lblEscenario.Text = "Arena: -";
			// 
			// lblTiempo
			// 
			this.lblTiempo.AutoSize = true;
			this.lblTiempo.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.lblTiempo.ForeColor = System.Drawing.Color.Salmon;
			this.lblTiempo.Location = new System.Drawing.Point(455, 16);
			this.lblTiempo.Name = "lblTiempo";
			this.lblTiempo.Size = new System.Drawing.Size(85, 19);
			this.lblTiempo.TabIndex = 2;
			this.lblTiempo.Text = "Tiempo: 20s";
			// 
			// btnIdiomaCombate
			// 
			this.btnIdiomaCombate.BackColor = System.Drawing.Color.FromArgb(40, 130, 95);
			this.btnIdiomaCombate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnIdiomaCombate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.btnIdiomaCombate.ForeColor = System.Drawing.Color.White;
			this.btnIdiomaCombate.Location = new System.Drawing.Point(548, 10);
			this.btnIdiomaCombate.Name = "btnIdiomaCombate";
			this.btnIdiomaCombate.Size = new System.Drawing.Size(80, 32);
			this.btnIdiomaCombate.TabIndex = 6;
			this.btnIdiomaCombate.Text = "🌐 ES";
			this.btnIdiomaCombate.UseVisualStyleBackColor = false;
			this.btnIdiomaCombate.Click += new System.EventHandler(this.BtnIdiomaCombate_Click);
			// 
			// btnLoreCombate
			// 
			this.btnLoreCombate.BackColor = System.Drawing.Color.FromArgb(215, 155, 35);
			this.btnLoreCombate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnLoreCombate.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.btnLoreCombate.ForeColor = System.Drawing.Color.White;
			this.btnLoreCombate.Location = new System.Drawing.Point(634, 10);
			this.btnLoreCombate.Name = "btnLoreCombate";
			this.btnLoreCombate.Size = new System.Drawing.Size(80, 32);
			this.btnLoreCombate.TabIndex = 5;
			this.btnLoreCombate.Text = "📜 Lore";
			this.btnLoreCombate.UseVisualStyleBackColor = false;
			this.btnLoreCombate.Click += new System.EventHandler(this.BtnLoreCombate_Click);
			// 
			// btnGuardar
			// 
			this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.btnGuardar.Location = new System.Drawing.Point(720, 10);
			this.btnGuardar.Name = "btnGuardar";
			this.btnGuardar.Size = new System.Drawing.Size(96, 32);
			this.btnGuardar.TabIndex = 3;
			this.btnGuardar.Text = "Guardar .TXT";
			this.btnGuardar.UseVisualStyleBackColor = true;
			this.btnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
			// 
			// btnVolverMenu
			// 
			this.btnVolverMenu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.btnVolverMenu.Location = new System.Drawing.Point(822, 10);
			this.btnVolverMenu.Name = "btnVolverMenu";
			this.btnVolverMenu.Size = new System.Drawing.Size(110, 32);
			this.btnVolverMenu.TabIndex = 4;
			this.btnVolverMenu.Text = "Volver al Menú";
			this.btnVolverMenu.UseVisualStyleBackColor = true;
			this.btnVolverMenu.Click += new System.EventHandler(this.BtnVolverMenu_Click);
			// 
			// timerTurno
			// 
			this.timerTurno.Interval = 1000;
			this.timerTurno.Tick += new System.EventHandler(this.TimerTurno_Tick);
			// 
			// grpJugador1
			// 
			this.grpJugador1.Controls.Add(this.picCartaJ1);
			this.grpJugador1.Controls.Add(this.lblCartaJ1);
			this.grpJugador1.Controls.Add(this.lblEnergiaJ1);
			this.grpJugador1.Controls.Add(this.lblVidaJ1);
			this.grpJugador1.Controls.Add(this.pbVidaJ1);
			this.grpJugador1.Controls.Add(this.lblEscudoJ1);
			this.grpJugador1.Controls.Add(this.pbEscudoJ1);
			this.grpJugador1.Controls.Add(this.lblEspecialJ1);
			this.grpJugador1.Controls.Add(this.pbEspecialJ1);
			this.grpJugador1.Controls.Add(this.lblColaJ1);
			this.grpJugador1.Controls.Add(this.lstColaJ1);
			this.grpJugador1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.grpJugador1.Location = new System.Drawing.Point(15, 60);
			this.grpJugador1.Name = "grpJugador1";
			this.grpJugador1.Size = new System.Drawing.Size(345, 372);
			this.grpJugador1.TabIndex = 1;
			this.grpJugador1.TabStop = false;
			this.grpJugador1.Text = "Jugador 1";
			// 
			// picCartaJ1
			// 
			this.picCartaJ1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picCartaJ1.Location = new System.Drawing.Point(12, 24);
			this.picCartaJ1.Name = "picCartaJ1";
			this.picCartaJ1.Size = new System.Drawing.Size(120, 160);
			this.picCartaJ1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picCartaJ1.TabIndex = 0;
			this.picCartaJ1.TabStop = false;
			// 
			// lblCartaJ1
			// 
			this.lblCartaJ1.AutoSize = true;
			this.lblCartaJ1.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.lblCartaJ1.Location = new System.Drawing.Point(140, 22);
			this.lblCartaJ1.Name = "lblCartaJ1";
			this.lblCartaJ1.Size = new System.Drawing.Size(130, 19);
			this.lblCartaJ1.TabIndex = 1;
			this.lblCartaJ1.Text = "Pokémon Activo J1";
			// 
			// lblEnergiaJ1
			// 
			this.lblEnergiaJ1.AutoSize = true;
			this.lblEnergiaJ1.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.lblEnergiaJ1.Location = new System.Drawing.Point(140, 45);
			this.lblEnergiaJ1.Name = "lblEnergiaJ1";
			this.lblEnergiaJ1.Size = new System.Drawing.Size(115, 16);
			this.lblEnergiaJ1.TabIndex = 2;
			this.lblEnergiaJ1.Text = "Energia: 2 | ATK: 0";
			// 
			// lblVidaJ1
			// 
			this.lblVidaJ1.AutoSize = true;
			this.lblVidaJ1.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.lblVidaJ1.Location = new System.Drawing.Point(140, 66);
			this.lblVidaJ1.Name = "lblVidaJ1";
			this.lblVidaJ1.Size = new System.Drawing.Size(85, 16);
			this.lblVidaJ1.TabIndex = 3;
			this.lblVidaJ1.Text = "Vida: 50 / 50";
			// 
			// pbVidaJ1
			// 
			this.pbVidaJ1.Location = new System.Drawing.Point(140, 84);
			this.pbVidaJ1.Name = "pbVidaJ1";
			this.pbVidaJ1.Size = new System.Drawing.Size(190, 16);
			this.pbVidaJ1.TabIndex = 4;
			// 
			// lblEscudoJ1
			// 
			this.lblEscudoJ1.AutoSize = true;
			this.lblEscudoJ1.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.lblEscudoJ1.Location = new System.Drawing.Point(140, 104);
			this.lblEscudoJ1.Name = "lblEscudoJ1";
			this.lblEscudoJ1.Size = new System.Drawing.Size(105, 16);
			this.lblEscudoJ1.TabIndex = 5;
			this.lblEscudoJ1.Text = "Escudo (DEF): 30";
			// 
			// pbEscudoJ1
			// 
			this.pbEscudoJ1.Location = new System.Drawing.Point(140, 122);
			this.pbEscudoJ1.Maximum = 60;
			this.pbEscudoJ1.Name = "pbEscudoJ1";
			this.pbEscudoJ1.Size = new System.Drawing.Size(190, 16);
			this.pbEscudoJ1.TabIndex = 6;
			// 
			// lblEspecialJ1
			// 
			this.lblEspecialJ1.AutoSize = true;
			this.lblEspecialJ1.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.lblEspecialJ1.Location = new System.Drawing.Point(140, 142);
			this.lblEspecialJ1.Name = "lblEspecialJ1";
			this.lblEspecialJ1.Size = new System.Drawing.Size(130, 16);
			this.lblEspecialJ1.TabIndex = 7;
			this.lblEspecialJ1.Text = "Habilidad Especial: 0%";
			// 
			// pbEspecialJ1
			// 
			this.pbEspecialJ1.Location = new System.Drawing.Point(140, 160);
			this.pbEspecialJ1.Maximum = 100;
			this.pbEspecialJ1.Name = "pbEspecialJ1";
			this.pbEspecialJ1.Size = new System.Drawing.Size(190, 16);
			this.pbEspecialJ1.TabIndex = 8;
			// 
			// lblColaJ1
			// 
			this.lblColaJ1.AutoSize = true;
			this.lblColaJ1.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.lblColaJ1.Location = new System.Drawing.Point(12, 192);
			this.lblColaJ1.Name = "lblColaJ1";
			this.lblColaJ1.Size = new System.Drawing.Size(250, 16);
			this.lblColaJ1.TabIndex = 9;
			this.lblColaJ1.Text = "Banca de Relevos Pokémon (Cola / Queue):";
			// 
			// lstColaJ1
			// 
			this.lstColaJ1.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.lstColaJ1.ItemHeight = 15;
			this.lstColaJ1.Location = new System.Drawing.Point(12, 212);
			this.lstColaJ1.Name = "lstColaJ1";
			this.lstColaJ1.Size = new System.Drawing.Size(320, 139);
			this.lstColaJ1.TabIndex = 10;
			// 
			// grpJugador2
			// 
			this.grpJugador2.Controls.Add(this.picCartaJ2);
			this.grpJugador2.Controls.Add(this.lblCartaJ2);
			this.grpJugador2.Controls.Add(this.lblEnergiaJ2);
			this.grpJugador2.Controls.Add(this.lblVidaJ2);
			this.grpJugador2.Controls.Add(this.pbVidaJ2);
			this.grpJugador2.Controls.Add(this.lblEscudoJ2);
			this.grpJugador2.Controls.Add(this.pbEscudoJ2);
			this.grpJugador2.Controls.Add(this.lblEspecialJ2);
			this.grpJugador2.Controls.Add(this.pbEspecialJ2);
			this.grpJugador2.Controls.Add(this.lblColaJ2);
			this.grpJugador2.Controls.Add(this.lstColaJ2);
			this.grpJugador2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.grpJugador2.Location = new System.Drawing.Point(580, 60);
			this.grpJugador2.Name = "grpJugador2";
			this.grpJugador2.Size = new System.Drawing.Size(345, 372);
			this.grpJugador2.TabIndex = 2;
			this.grpJugador2.TabStop = false;
			this.grpJugador2.Text = "Jugador 2";
			// 
			// picCartaJ2
			// 
			this.picCartaJ2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picCartaJ2.Location = new System.Drawing.Point(12, 24);
			this.picCartaJ2.Name = "picCartaJ2";
			this.picCartaJ2.Size = new System.Drawing.Size(120, 160);
			this.picCartaJ2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picCartaJ2.TabIndex = 0;
			this.picCartaJ2.TabStop = false;
			// 
			// lblCartaJ2
			// 
			this.lblCartaJ2.AutoSize = true;
			this.lblCartaJ2.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.lblCartaJ2.Location = new System.Drawing.Point(140, 22);
			this.lblCartaJ2.Name = "lblCartaJ2";
			this.lblCartaJ2.Size = new System.Drawing.Size(130, 19);
			this.lblCartaJ2.TabIndex = 1;
			this.lblCartaJ2.Text = "Pokémon Activo J2";
			// 
			// lblEnergiaJ2
			// 
			this.lblEnergiaJ2.AutoSize = true;
			this.lblEnergiaJ2.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.lblEnergiaJ2.Location = new System.Drawing.Point(140, 45);
			this.lblEnergiaJ2.Name = "lblEnergiaJ2";
			this.lblEnergiaJ2.Size = new System.Drawing.Size(115, 16);
			this.lblEnergiaJ2.TabIndex = 2;
			this.lblEnergiaJ2.Text = "Energia: 2 | ATK: 0";
			// 
			// lblVidaJ2
			// 
			this.lblVidaJ2.AutoSize = true;
			this.lblVidaJ2.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.lblVidaJ2.Location = new System.Drawing.Point(140, 66);
			this.lblVidaJ2.Name = "lblVidaJ2";
			this.lblVidaJ2.Size = new System.Drawing.Size(85, 16);
			this.lblVidaJ2.TabIndex = 3;
			this.lblVidaJ2.Text = "Vida: 50 / 50";
			// 
			// pbVidaJ2
			// 
			this.pbVidaJ2.Location = new System.Drawing.Point(140, 84);
			this.pbVidaJ2.Name = "pbVidaJ2";
			this.pbVidaJ2.Size = new System.Drawing.Size(190, 16);
			this.pbVidaJ2.TabIndex = 4;
			// 
			// lblEscudoJ2
			// 
			this.lblEscudoJ2.AutoSize = true;
			this.lblEscudoJ2.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.lblEscudoJ2.Location = new System.Drawing.Point(140, 104);
			this.lblEscudoJ2.Name = "lblEscudoJ2";
			this.lblEscudoJ2.Size = new System.Drawing.Size(105, 16);
			this.lblEscudoJ2.TabIndex = 5;
			this.lblEscudoJ2.Text = "Escudo (DEF): 30";
			// 
			// pbEscudoJ2
			// 
			this.pbEscudoJ2.Location = new System.Drawing.Point(140, 122);
			this.pbEscudoJ2.Maximum = 60;
			this.pbEscudoJ2.Name = "pbEscudoJ2";
			this.pbEscudoJ2.Size = new System.Drawing.Size(190, 16);
			this.pbEscudoJ2.TabIndex = 6;
			// 
			// lblEspecialJ2
			// 
			this.lblEspecialJ2.AutoSize = true;
			this.lblEspecialJ2.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.lblEspecialJ2.Location = new System.Drawing.Point(140, 142);
			this.lblEspecialJ2.Name = "lblEspecialJ2";
			this.lblEspecialJ2.Size = new System.Drawing.Size(130, 16);
			this.lblEspecialJ2.TabIndex = 7;
			this.lblEspecialJ2.Text = "Habilidad Especial: 0%";
			// 
			// pbEspecialJ2
			// 
			this.pbEspecialJ2.Location = new System.Drawing.Point(140, 160);
			this.pbEspecialJ2.Maximum = 100;
			this.pbEspecialJ2.Name = "pbEspecialJ2";
			this.pbEspecialJ2.Size = new System.Drawing.Size(190, 16);
			this.pbEspecialJ2.TabIndex = 8;
			// 
			// lblColaJ2
			// 
			this.lblColaJ2.AutoSize = true;
			this.lblColaJ2.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.lblColaJ2.Location = new System.Drawing.Point(12, 192);
			this.lblColaJ2.Name = "lblColaJ2";
			this.lblColaJ2.Size = new System.Drawing.Size(250, 16);
			this.lblColaJ2.TabIndex = 9;
			this.lblColaJ2.Text = "Banca de Relevos Pokémon (Cola / Queue):";
			// 
			// lstColaJ2
			// 
			this.lstColaJ2.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.lstColaJ2.ItemHeight = 15;
			this.lstColaJ2.Location = new System.Drawing.Point(12, 212);
			this.lstColaJ2.Name = "lstColaJ2";
			this.lstColaJ2.Size = new System.Drawing.Size(320, 139);
			this.lstColaJ2.TabIndex = 10;
			// 
			// grpAcciones
			// 
			this.grpAcciones.Controls.Add(this.picArenaActiva);
			this.grpAcciones.Controls.Add(this.btnAtacar);
			this.grpAcciones.Controls.Add(this.btnDefender);
			this.grpAcciones.Controls.Add(this.btnEspecial);
			this.grpAcciones.Controls.Add(this.btnRelevar);
			this.grpAcciones.Controls.Add(this.btnPasarTurno);
			this.grpAcciones.Controls.Add(this.btnTerremoto);
			this.grpAcciones.Controls.Add(this.btnTerminarCombate);
			this.grpAcciones.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.grpAcciones.Location = new System.Drawing.Point(368, 60);
			this.grpAcciones.Name = "grpAcciones";
			this.grpAcciones.Size = new System.Drawing.Size(204, 372);
			this.grpAcciones.TabIndex = 3;
			this.grpAcciones.TabStop = false;
			this.grpAcciones.Text = "Arena Activa y Acciones";
			// 
			// picArenaActiva
			// 
			this.picArenaActiva.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picArenaActiva.Location = new System.Drawing.Point(14, 22);
			this.picArenaActiva.Name = "picArenaActiva";
			this.picArenaActiva.Size = new System.Drawing.Size(176, 95);
			this.picArenaActiva.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picArenaActiva.TabIndex = 0;
			this.picArenaActiva.TabStop = false;
			// 
			// btnAtacar
			// 
			this.btnAtacar.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.btnAtacar.Location = new System.Drawing.Point(14, 124);
			this.btnAtacar.Name = "btnAtacar";
			this.btnAtacar.Size = new System.Drawing.Size(176, 30);
			this.btnAtacar.TabIndex = 1;
			this.btnAtacar.Text = "Atacar (1 ENER)";
			this.btnAtacar.UseVisualStyleBackColor = true;
			this.btnAtacar.Click += new System.EventHandler(this.BtnAtacar_Click);
			// 
			// btnDefender
			// 
			this.btnDefender.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.btnDefender.Location = new System.Drawing.Point(14, 158);
			this.btnDefender.Name = "btnDefender";
			this.btnDefender.Size = new System.Drawing.Size(176, 30);
			this.btnDefender.TabIndex = 2;
			this.btnDefender.Text = "Defender (1 ENER)";
			this.btnDefender.UseVisualStyleBackColor = true;
			this.btnDefender.Click += new System.EventHandler(this.BtnDefender_Click);
			// 
			// btnEspecial
			// 
			this.btnEspecial.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.btnEspecial.Location = new System.Drawing.Point(14, 192);
			this.btnEspecial.Name = "btnEspecial";
			this.btnEspecial.Size = new System.Drawing.Size(176, 30);
			this.btnEspecial.TabIndex = 3;
			this.btnEspecial.Text = "Hab. Especial (2 ENER)";
			this.btnEspecial.UseVisualStyleBackColor = true;
			this.btnEspecial.Click += new System.EventHandler(this.BtnEspecial_Click);
			// 
			// btnRelevar
			// 
			this.btnRelevar.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.btnRelevar.Location = new System.Drawing.Point(14, 226);
			this.btnRelevar.Name = "btnRelevar";
			this.btnRelevar.Size = new System.Drawing.Size(176, 30);
			this.btnRelevar.TabIndex = 4;
			this.btnRelevar.Text = "Relevar Cola (1 ENER)";
			this.btnRelevar.UseVisualStyleBackColor = true;
			this.btnRelevar.Click += new System.EventHandler(this.BtnRelevar_Click);
			// 
			// btnPasarTurno
			// 
			this.btnPasarTurno.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.btnPasarTurno.Location = new System.Drawing.Point(14, 260);
			this.btnPasarTurno.Name = "btnPasarTurno";
			this.btnPasarTurno.Size = new System.Drawing.Size(176, 30);
			this.btnPasarTurno.TabIndex = 5;
			this.btnPasarTurno.Text = "Pasar / Terminar Turno";
			this.btnPasarTurno.UseVisualStyleBackColor = true;
			this.btnPasarTurno.Click += new System.EventHandler(this.BtnPasarTurno_Click);
			// 
			// btnTerremoto
			// 
			this.btnTerremoto.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.btnTerremoto.Location = new System.Drawing.Point(14, 294);
			this.btnTerremoto.Name = "btnTerremoto";
			this.btnTerremoto.Size = new System.Drawing.Size(176, 28);
			this.btnTerremoto.TabIndex = 6;
			this.btnTerremoto.Text = "Probar Terremoto";
			this.btnTerremoto.UseVisualStyleBackColor = true;
			this.btnTerremoto.Click += new System.EventHandler(this.BtnTerremoto_Click);
			// 
			// btnTerminarCombate
			// 
			this.btnTerminarCombate.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.btnTerminarCombate.Location = new System.Drawing.Point(14, 326);
			this.btnTerminarCombate.Name = "btnTerminarCombate";
			this.btnTerminarCombate.Size = new System.Drawing.Size(176, 30);
			this.btnTerminarCombate.TabIndex = 7;
			this.btnTerminarCombate.Text = "Terminar Combate";
			this.btnTerminarCombate.UseVisualStyleBackColor = true;
			this.btnTerminarCombate.Click += new System.EventHandler(this.BtnTerminarCombate_Click);
			// 
			// lblHist
			// 
			this.lblHist.AutoSize = true;
			this.lblHist.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.lblHist.Location = new System.Drawing.Point(15, 438);
			this.lblHist.Name = "lblHist";
			this.lblHist.Size = new System.Drawing.Size(340, 16);
			this.lblHist.TabIndex = 4;
			this.lblHist.Text = "Historial de Batalla Pokémon en Vivo (Pila / Stack):";
			// 
			// btnVerTopePila
			// 
			this.btnVerTopePila.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.btnVerTopePila.Location = new System.Drawing.Point(530, 432);
			this.btnVerTopePila.Name = "btnVerTopePila";
			this.btnVerTopePila.Size = new System.Drawing.Size(185, 25);
			this.btnVerTopePila.TabIndex = 6;
			this.btnVerTopePila.Text = "🔍 Tope de la Pila (Peek)";
			this.btnVerTopePila.UseVisualStyleBackColor = true;
			this.btnVerTopePila.Click += new System.EventHandler(this.BtnVerTopePila_Click);
			// 
			// btnDeshacerPila
			// 
			this.btnDeshacerPila.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.btnDeshacerPila.Location = new System.Drawing.Point(725, 432);
			this.btnDeshacerPila.Name = "btnDeshacerPila";
			this.btnDeshacerPila.Size = new System.Drawing.Size(200, 25);
			this.btnDeshacerPila.TabIndex = 7;
			this.btnDeshacerPila.Text = "↩ Desapilar Última (Pop)";
			this.btnDeshacerPila.UseVisualStyleBackColor = true;
			this.btnDeshacerPila.Click += new System.EventHandler(this.BtnDeshacerPila_Click);
			// 
			// lstHistorial
			// 
			this.lstHistorial.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.lstHistorial.ItemHeight = 14;
			this.lstHistorial.Location = new System.Drawing.Point(15, 460);
			this.lstHistorial.Name = "lstHistorial";
			this.lstHistorial.Size = new System.Drawing.Size(910, 144);
			this.lstHistorial.TabIndex = 5;
			// 
			// MainForm
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.FromArgb(240, 240, 245);
			this.ClientSize = new System.Drawing.Size(940, 620);
			this.Controls.Add(this.pnlBarraCombate);
			this.Controls.Add(this.grpJugador1);
			this.Controls.Add(this.grpJugador2);
			this.Controls.Add(this.grpAcciones);
			this.Controls.Add(this.lblHist);
			this.Controls.Add(this.btnVerTopePila);
			this.Controls.Add(this.btnDeshacerPila);
			this.Controls.Add(this.lstHistorial);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Pokémon Arena Elemental - Vista de Combate";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.pnlBarraCombate.ResumeLayout(false);
			this.pnlBarraCombate.PerformLayout();
			this.grpJugador1.ResumeLayout(false);
			this.grpJugador1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.picCartaJ1)).EndInit();
			this.grpJugador2.ResumeLayout(false);
			this.grpJugador2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.picCartaJ2)).EndInit();
			this.grpAcciones.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.picArenaActiva)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
	}
}
