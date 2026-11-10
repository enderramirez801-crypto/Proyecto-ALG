/*
 * Created by SharpDevelop.
 * User: Ender
 * Date: 8/11/2026
 * Time: 12:35 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ArenaElemental
{
	partial class FormLore
	{
		private System.ComponentModel.IContainer components = null;

		private System.Windows.Forms.Panel pnlHeader;
		private System.Windows.Forms.Label lblTitulo;
		private System.Windows.Forms.Label lblSub;
		private System.Windows.Forms.Button btnCerrarLore;
		private System.Windows.Forms.Button btnIdiomaLore;

		private System.Windows.Forms.GroupBox grpFacciones;
		private System.Windows.Forms.Label lblFil;
		private System.Windows.Forms.Button btnFiltroTodos;
		private System.Windows.Forms.Button btnFiltroTierra;
		private System.Windows.Forms.Button btnFiltroAgua;
		private System.Windows.Forms.Button btnFiltroFuego;
		private System.Windows.Forms.Button btnFiltroAire;
		private System.Windows.Forms.Label lblListaPok;
		private System.Windows.Forms.ListBox lstPokemonLore;

		private System.Windows.Forms.GroupBox grpOrigenFaccion;
		private System.Windows.Forms.PictureBox picArenaNatal;
		private System.Windows.Forms.Label lblArenaNatal;
		private System.Windows.Forms.TextBox txtLoreFaccion;

		private System.Windows.Forms.GroupBox grpDetallePokemon;
		private System.Windows.Forms.PictureBox picCartaPokemonLore;
		private System.Windows.Forms.Label lblNombreElem;
		private System.Windows.Forms.Label lblRegionOrigen;
		private System.Windows.Forms.Label lblHabilidadLore;
		private System.Windows.Forms.Label lblStatsLore;
		private System.Windows.Forms.Label lblTerremotoLore;
		private System.Windows.Forms.Label lblVentajaLore;
		private System.Windows.Forms.Label lblHistInd;
		private System.Windows.Forms.TextBox txtLoreIndividual;

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
			this.btnCerrarLore = new System.Windows.Forms.Button();
			this.btnIdiomaLore = new System.Windows.Forms.Button();
			this.grpFacciones = new System.Windows.Forms.GroupBox();
			this.lblFil = new System.Windows.Forms.Label();
			this.btnFiltroTodos = new System.Windows.Forms.Button();
			this.btnFiltroTierra = new System.Windows.Forms.Button();
			this.btnFiltroAgua = new System.Windows.Forms.Button();
			this.btnFiltroFuego = new System.Windows.Forms.Button();
			this.btnFiltroAire = new System.Windows.Forms.Button();
			this.lblListaPok = new System.Windows.Forms.Label();
			this.lstPokemonLore = new System.Windows.Forms.ListBox();
			this.grpOrigenFaccion = new System.Windows.Forms.GroupBox();
			this.picArenaNatal = new System.Windows.Forms.PictureBox();
			this.lblArenaNatal = new System.Windows.Forms.Label();
			this.txtLoreFaccion = new System.Windows.Forms.TextBox();
			this.grpDetallePokemon = new System.Windows.Forms.GroupBox();
			this.picCartaPokemonLore = new System.Windows.Forms.PictureBox();
			this.lblNombreElem = new System.Windows.Forms.Label();
			this.lblRegionOrigen = new System.Windows.Forms.Label();
			this.lblHabilidadLore = new System.Windows.Forms.Label();
			this.lblStatsLore = new System.Windows.Forms.Label();
			this.lblTerremotoLore = new System.Windows.Forms.Label();
			this.lblVentajaLore = new System.Windows.Forms.Label();
			this.lblHistInd = new System.Windows.Forms.Label();
			this.txtLoreIndividual = new System.Windows.Forms.TextBox();
			this.pnlHeader.SuspendLayout();
			this.grpFacciones.SuspendLayout();
			this.grpOrigenFaccion.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picArenaNatal)).BeginInit();
			this.grpDetallePokemon.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picCartaPokemonLore)).BeginInit();
			this.SuspendLayout();
			// 
			// pnlHeader
			// 
			this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(66)))));
			this.pnlHeader.Controls.Add(this.lblTitulo);
			this.pnlHeader.Controls.Add(this.lblSub);
			this.pnlHeader.Controls.Add(this.btnIdiomaLore);
			this.pnlHeader.Controls.Add(this.btnCerrarLore);
			this.pnlHeader.Location = new System.Drawing.Point(0, 0);
			this.pnlHeader.Name = "pnlHeader";
			this.pnlHeader.Size = new System.Drawing.Size(920, 56);
			this.pnlHeader.TabIndex = 0;
			// 
			// lblTitulo
			// 
			this.lblTitulo.AutoSize = true;
			this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.lblTitulo.ForeColor = System.Drawing.Color.White;
			this.lblTitulo.Location = new System.Drawing.Point(16, 6);
			this.lblTitulo.Name = "lblTitulo";
			this.lblTitulo.Size = new System.Drawing.Size(551, 23);
			this.lblTitulo.TabIndex = 0;
			this.lblTitulo.Text = "POKÉMON ARENA ELEMENTAL - ENCICLOPEDIA DE LORE Y ORIGEN";
			// 
			// lblSub
			// 
			this.lblSub.AutoSize = true;
			this.lblSub.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.lblSub.ForeColor = System.Drawing.Color.Khaki;
			this.lblSub.Location = new System.Drawing.Point(18, 32);
			this.lblSub.Name = "lblSub";
			this.lblSub.Size = new System.Drawing.Size(531, 15);
			this.lblSub.TabIndex = 1;
			this.lblSub.Text = "Descubre de dónde son los Pokémon de Tierra, Agua, Fuego y Aire y la historia de " +
			"los 12 luchadores";
			// 
			// btnCerrarLore
			// 
			this.btnIdiomaLore.BackColor = System.Drawing.Color.FromArgb(40, 130, 95);
			this.btnIdiomaLore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnIdiomaLore.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.btnIdiomaLore.ForeColor = System.Drawing.Color.White;
			this.btnIdiomaLore.Location = new System.Drawing.Point(650, 11);
			this.btnIdiomaLore.Name = "btnIdiomaLore";
			this.btnIdiomaLore.Size = new System.Drawing.Size(115, 34);
			this.btnIdiomaLore.TabIndex = 3;
			this.btnIdiomaLore.Text = "🌐 Idioma: ES";
			this.btnIdiomaLore.UseVisualStyleBackColor = false;
			this.btnIdiomaLore.Click += new System.EventHandler(this.BtnIdiomaLore_Click);
			this.btnCerrarLore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(50)))), ((int)(((byte)(35)))));
			this.btnCerrarLore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCerrarLore.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.btnCerrarLore.ForeColor = System.Drawing.Color.White;
			this.btnCerrarLore.Location = new System.Drawing.Point(775, 11);
			this.btnCerrarLore.Name = "btnCerrarLore";
			this.btnCerrarLore.Size = new System.Drawing.Size(128, 34);
			this.btnCerrarLore.TabIndex = 2;
			this.btnCerrarLore.Text = "Cerrar Lore";
			this.btnCerrarLore.UseVisualStyleBackColor = false;
			this.btnCerrarLore.Click += new System.EventHandler(this.BtnCerrarLore_Click);
			// 
			// grpFacciones
			// 
			this.grpFacciones.Controls.Add(this.lblFil);
			this.grpFacciones.Controls.Add(this.btnFiltroTodos);
			this.grpFacciones.Controls.Add(this.btnFiltroTierra);
			this.grpFacciones.Controls.Add(this.btnFiltroAgua);
			this.grpFacciones.Controls.Add(this.btnFiltroFuego);
			this.grpFacciones.Controls.Add(this.btnFiltroAire);
			this.grpFacciones.Controls.Add(this.lblListaPok);
			this.grpFacciones.Controls.Add(this.lstPokemonLore);
			this.grpFacciones.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.grpFacciones.Location = new System.Drawing.Point(14, 64);
			this.grpFacciones.Name = "grpFacciones";
			this.grpFacciones.Size = new System.Drawing.Size(270, 540);
			this.grpFacciones.TabIndex = 1;
			this.grpFacciones.TabStop = false;
			this.grpFacciones.Text = "1. Facciones y Pokémon (12)";
			// 
			// lblFil
			// 
			this.lblFil.AutoSize = true;
			this.lblFil.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.lblFil.Location = new System.Drawing.Point(12, 22);
			this.lblFil.Name = "lblFil";
			this.lblFil.Size = new System.Drawing.Size(162, 15);
			this.lblFil.TabIndex = 0;
			this.lblFil.Text = "Filtrar por Región / Elemento:";
			// 
			// btnFiltroTodos
			// 
			this.btnFiltroTodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnFiltroTodos.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.btnFiltroTodos.Location = new System.Drawing.Point(12, 42);
			this.btnFiltroTodos.Name = "btnFiltroTodos";
			this.btnFiltroTodos.Size = new System.Drawing.Size(246, 28);
			this.btnFiltroTodos.TabIndex = 1;
			this.btnFiltroTodos.Text = "Todos los Pokémon (12)";
			this.btnFiltroTodos.UseVisualStyleBackColor = false;
			this.btnFiltroTodos.Click += new System.EventHandler(this.BtnFiltroTodos_Click);
			// 
			// btnFiltroTierra
			// 
			this.btnFiltroTierra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnFiltroTierra.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.btnFiltroTierra.Location = new System.Drawing.Point(12, 74);
			this.btnFiltroTierra.Name = "btnFiltroTierra";
			this.btnFiltroTierra.Size = new System.Drawing.Size(246, 28);
			this.btnFiltroTierra.TabIndex = 2;
			this.btnFiltroTierra.Text = "Tierra — Cañón Rocoso (3)";
			this.btnFiltroTierra.UseVisualStyleBackColor = false;
			this.btnFiltroTierra.Click += new System.EventHandler(this.BtnFiltroTierra_Click);
			// 
			// btnFiltroAgua
			// 
			this.btnFiltroAgua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnFiltroAgua.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.btnFiltroAgua.Location = new System.Drawing.Point(12, 106);
			this.btnFiltroAgua.Name = "btnFiltroAgua";
			this.btnFiltroAgua.Size = new System.Drawing.Size(246, 28);
			this.btnFiltroAgua.TabIndex = 3;
			this.btnFiltroAgua.Text = "Agua — Estadio Cascada (3)";
			this.btnFiltroAgua.UseVisualStyleBackColor = false;
			this.btnFiltroAgua.Click += new System.EventHandler(this.BtnFiltroAgua_Click);
			// 
			// btnFiltroFuego
			// 
			this.btnFiltroFuego.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnFiltroFuego.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.btnFiltroFuego.Location = new System.Drawing.Point(12, 138);
			this.btnFiltroFuego.Name = "btnFiltroFuego";
			this.btnFiltroFuego.Size = new System.Drawing.Size(246, 28);
			this.btnFiltroFuego.TabIndex = 4;
			this.btnFiltroFuego.Text = "Fuego — Volcán Cinnabar (3)";
			this.btnFiltroFuego.UseVisualStyleBackColor = false;
			this.btnFiltroFuego.Click += new System.EventHandler(this.BtnFiltroFuego_Click);
			// 
			// btnFiltroAire
			// 
			this.btnFiltroAire.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnFiltroAire.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.btnFiltroAire.Location = new System.Drawing.Point(12, 170);
			this.btnFiltroAire.Name = "btnFiltroAire";
			this.btnFiltroAire.Size = new System.Drawing.Size(246, 28);
			this.btnFiltroAire.TabIndex = 5;
			this.btnFiltroAire.Text = "Aire — Torre Celeste (3)";
			this.btnFiltroAire.UseVisualStyleBackColor = false;
			this.btnFiltroAire.Click += new System.EventHandler(this.BtnFiltroAire_Click);
			// 
			// lblListaPok
			// 
			this.lblListaPok.AutoSize = true;
			this.lblListaPok.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.lblListaPok.Location = new System.Drawing.Point(12, 208);
			this.lblListaPok.Name = "lblListaPok";
			this.lblListaPok.Size = new System.Drawing.Size(213, 15);
			this.lblListaPok.TabIndex = 6;
			this.lblListaPok.Text = "Selecciona un Pokémon del Catálogo:";
			// 
			// lstPokemonLore
			// 
			this.lstPokemonLore.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.lstPokemonLore.ItemHeight = 15;
			this.lstPokemonLore.Location = new System.Drawing.Point(12, 228);
			this.lstPokemonLore.Name = "lstPokemonLore";
			this.lstPokemonLore.Size = new System.Drawing.Size(246, 289);
			this.lstPokemonLore.TabIndex = 7;
			this.lstPokemonLore.SelectedIndexChanged += new System.EventHandler(this.LstPokemonLore_SelectedIndexChanged);
			// 
			// grpOrigenFaccion
			// 
			this.grpOrigenFaccion.Controls.Add(this.picArenaNatal);
			this.grpOrigenFaccion.Controls.Add(this.lblArenaNatal);
			this.grpOrigenFaccion.Controls.Add(this.txtLoreFaccion);
			this.grpOrigenFaccion.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.grpOrigenFaccion.Location = new System.Drawing.Point(296, 67);
			this.grpOrigenFaccion.Name = "grpOrigenFaccion";
			this.grpOrigenFaccion.Size = new System.Drawing.Size(610, 185);
			this.grpOrigenFaccion.TabIndex = 2;
			this.grpOrigenFaccion.TabStop = false;
			this.grpOrigenFaccion.Text = "2. ¿De dónde son los Pokémon de este Elemento? (Lore de la Facción)";
			// 
			// picArenaNatal
			// 
			this.picArenaNatal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picArenaNatal.Location = new System.Drawing.Point(14, 28);
			this.picArenaNatal.Name = "picArenaNatal";
			this.picArenaNatal.Size = new System.Drawing.Size(220, 142);
			this.picArenaNatal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picArenaNatal.TabIndex = 0;
			this.picArenaNatal.TabStop = false;
			// 
			// lblArenaNatal
			// 
			this.lblArenaNatal.AutoSize = true;
			this.lblArenaNatal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.lblArenaNatal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(66)))));
			this.lblArenaNatal.Location = new System.Drawing.Point(246, 26);
			this.lblArenaNatal.Name = "lblArenaNatal";
			this.lblArenaNatal.Size = new System.Drawing.Size(139, 15);
			this.lblArenaNatal.TabIndex = 1;
			this.lblArenaNatal.Text = "Territorio / Arena Natal:";
			// 
			// txtLoreFaccion
			// 
			this.txtLoreFaccion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(251)))), ((int)(((byte)(254)))));
			this.txtLoreFaccion.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.txtLoreFaccion.Location = new System.Drawing.Point(246, 48);
			this.txtLoreFaccion.Multiline = true;
			this.txtLoreFaccion.Name = "txtLoreFaccion";
			this.txtLoreFaccion.ReadOnly = true;
			this.txtLoreFaccion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtLoreFaccion.Size = new System.Drawing.Size(350, 122);
			this.txtLoreFaccion.TabIndex = 2;
			// 
			// grpDetallePokemon
			// 
			this.grpDetallePokemon.Controls.Add(this.picCartaPokemonLore);
			this.grpDetallePokemon.Controls.Add(this.lblNombreElem);
			this.grpDetallePokemon.Controls.Add(this.lblRegionOrigen);
			this.grpDetallePokemon.Controls.Add(this.lblHabilidadLore);
			this.grpDetallePokemon.Controls.Add(this.lblStatsLore);
			this.grpDetallePokemon.Controls.Add(this.lblTerremotoLore);
			this.grpDetallePokemon.Controls.Add(this.lblVentajaLore);
			this.grpDetallePokemon.Controls.Add(this.lblHistInd);
			this.grpDetallePokemon.Controls.Add(this.txtLoreIndividual);
			this.grpDetallePokemon.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.grpDetallePokemon.Location = new System.Drawing.Point(296, 258);
			this.grpDetallePokemon.Name = "grpDetallePokemon";
			this.grpDetallePokemon.Size = new System.Drawing.Size(610, 346);
			this.grpDetallePokemon.TabIndex = 3;
			this.grpDetallePokemon.TabStop = false;
			this.grpDetallePokemon.Text = "3. Historia, Origen y Atributos del Pokémon Seleccionado";
			// 
			// picCartaPokemonLore
			// 
			this.picCartaPokemonLore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picCartaPokemonLore.Location = new System.Drawing.Point(14, 28);
			this.picCartaPokemonLore.Name = "picCartaPokemonLore";
			this.picCartaPokemonLore.Size = new System.Drawing.Size(120, 160);
			this.picCartaPokemonLore.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picCartaPokemonLore.TabIndex = 0;
			this.picCartaPokemonLore.TabStop = false;
			// 
			// lblNombreElem
			// 
			this.lblNombreElem.AutoSize = true;
			this.lblNombreElem.Font = new System.Drawing.Font("Segoe UI", 14.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.lblNombreElem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(66)))));
			this.lblNombreElem.Location = new System.Drawing.Point(146, 26);
			this.lblNombreElem.Name = "lblNombreElem";
			this.lblNombreElem.Size = new System.Drawing.Size(84, 20);
			this.lblNombreElem.TabIndex = 1;
			this.lblNombreElem.Text = "POKÉMON";
			// 
			// lblRegionOrigen
			// 
			this.lblRegionOrigen.AutoSize = true;
			this.lblRegionOrigen.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.lblRegionOrigen.ForeColor = System.Drawing.Color.SaddleBrown;
			this.lblRegionOrigen.Location = new System.Drawing.Point(146, 52);
			this.lblRegionOrigen.Name = "lblRegionOrigen";
			this.lblRegionOrigen.Size = new System.Drawing.Size(107, 15);
			this.lblRegionOrigen.TabIndex = 2;
			this.lblRegionOrigen.Text = "Región de Origen:";
			// 
			// lblHabilidadLore
			// 
			this.lblHabilidadLore.AutoSize = true;
			this.lblHabilidadLore.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.lblHabilidadLore.Location = new System.Drawing.Point(146, 76);
			this.lblHabilidadLore.Name = "lblHabilidadLore";
			this.lblHabilidadLore.Size = new System.Drawing.Size(106, 15);
			this.lblHabilidadLore.TabIndex = 3;
			this.lblHabilidadLore.Text = "Habilidad Especial:";
			// 
			// lblStatsLore
			// 
			this.lblStatsLore.AutoSize = true;
			this.lblStatsLore.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.lblStatsLore.Location = new System.Drawing.Point(146, 100);
			this.lblStatsLore.Name = "lblStatsLore";
			this.lblStatsLore.Size = new System.Drawing.Size(101, 15);
			this.lblStatsLore.TabIndex = 4;
			this.lblStatsLore.Text = "Estadísticas Base:";
			// 
			// lblTerremotoLore
			// 
			this.lblTerremotoLore.AutoSize = true;
			this.lblTerremotoLore.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.lblTerremotoLore.Location = new System.Drawing.Point(146, 124);
			this.lblTerremotoLore.Name = "lblTerremotoLore";
			this.lblTerremotoLore.Size = new System.Drawing.Size(96, 15);
			this.lblTerremotoLore.TabIndex = 5;
			this.lblTerremotoLore.Text = "Vínculo Sísmico:";
			// 
			// lblVentajaLore
			// 
			this.lblVentajaLore.AutoSize = true;
			this.lblVentajaLore.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.lblVentajaLore.Location = new System.Drawing.Point(146, 148);
			this.lblVentajaLore.Name = "lblVentajaLore";
			this.lblVentajaLore.Size = new System.Drawing.Size(111, 13);
			this.lblVentajaLore.TabIndex = 6;
			this.lblVentajaLore.Text = "Mecánica Elemental:";
			// 
			// lblHistInd
			// 
			this.lblHistInd.AutoSize = true;
			this.lblHistInd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.lblHistInd.Location = new System.Drawing.Point(14, 196);
			this.lblHistInd.Name = "lblHistInd";
			this.lblHistInd.Size = new System.Drawing.Size(230, 15);
			this.lblHistInd.TabIndex = 7;
			this.lblHistInd.Text = "Biografía y Lore Individual del Pokémon:";
			// 
			// txtLoreIndividual
			// 
			this.txtLoreIndividual.BackColor = System.Drawing.Color.White;
			this.txtLoreIndividual.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.txtLoreIndividual.Location = new System.Drawing.Point(14, 216);
			this.txtLoreIndividual.Multiline = true;
			this.txtLoreIndividual.Name = "txtLoreIndividual";
			this.txtLoreIndividual.ReadOnly = true;
			this.txtLoreIndividual.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtLoreIndividual.Size = new System.Drawing.Size(582, 116);
			this.txtLoreIndividual.TabIndex = 8;
			// 
			// FormLore
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(247)))));
			this.ClientSize = new System.Drawing.Size(920, 618);
			this.Controls.Add(this.pnlHeader);
			this.Controls.Add(this.grpFacciones);
			this.Controls.Add(this.grpOrigenFaccion);
			this.Controls.Add(this.grpDetallePokemon);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "FormLore";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Pokémon Arena Elemental - Lore e Historia de los Pokémon";
			this.pnlHeader.ResumeLayout(false);
			this.pnlHeader.PerformLayout();
			this.grpFacciones.ResumeLayout(false);
			this.grpFacciones.PerformLayout();
			this.grpOrigenFaccion.ResumeLayout(false);
			this.grpOrigenFaccion.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.picArenaNatal)).EndInit();
			this.grpDetallePokemon.ResumeLayout(false);
			this.grpDetallePokemon.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.picCartaPokemonLore)).EndInit();
			this.ResumeLayout(false);
		}
	}
}
