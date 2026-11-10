/*
 * Created by SharpDevelop.
 * User: Ender
 * Date: 8/11/2026
 * Time: 12:35 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ArenaElemental
{
    public partial class FormLore : Form
    {
        private List<Personaje> catalogoCompleto;
        private List<Personaje> listaFiltrada;
        private List<Escenario> listaEscenarios;
        private GestorArchivo gestorArchivo;
        private string filtroActual = "Todos";

        // Constructor vacío requerido por el diseñador visual de SharpDevelop
        public FormLore()
        {
            InitializeComponent();
            this.gestorArchivo = new GestorArchivo();
            this.catalogoCompleto = gestorArchivo.CargarCatalogo();
            this.listaEscenarios = gestorArchivo.CargarEscenarios();
            this.listaFiltrada = new List<Personaje>();
            AplicarIdiomaLore();
            AplicarFiltro("Todos", null);
        }

        public FormLore(
            List<Personaje> catalogo,
            List<Escenario> escenarios,
            GestorArchivo archivo,
            Personaje pokemonInicial)
        {
            InitializeComponent();

            this.gestorArchivo = (archivo != null) ? archivo : new GestorArchivo();
            this.catalogoCompleto = (catalogo != null && catalogo.Count > 0) ? catalogo : this.gestorArchivo.CargarCatalogo();
            this.listaEscenarios = (escenarios != null && escenarios.Count > 0) ? escenarios : this.gestorArchivo.CargarEscenarios();
            this.listaFiltrada = new List<Personaje>();

            AplicarIdiomaLore();
            AplicarFiltro("Todos", pokemonInicial);
        }

        private void BtnIdiomaLore_Click(object sender, EventArgs e)
        {
            Program.IdiomaIngles = !Program.IdiomaIngles;
            Personaje sel = (lstPokemonLore.SelectedIndex >= 0 && lstPokemonLore.SelectedIndex < listaFiltrada.Count)
                ? listaFiltrada[lstPokemonLore.SelectedIndex]
                : null;
            AplicarIdiomaLore();
            AplicarFiltro(this.filtroActual, sel);
        }

        private void AplicarIdiomaLore()
        {
            bool en = Program.IdiomaIngles;
            this.Text = en
                ? "Pokémon Elemental Arena - Lore & History Encyclopedia"
                : "Pokémon Arena Elemental - Lore e Historia de los Pokémon";
            lblTitulo.Text = en
                ? "POKÉMON ELEMENTAL ARENA - LORE & ORIGIN ENCYCLOPEDIA"
                : "POKÉMON ARENA ELEMENTAL - ENCICLOPEDIA DE LORE Y ORIGEN";
            lblSub.Text = en
                ? "Discover the origin of Earth, Water, Fire & Air Pokémon and the history of all 12 fighters"
                : "Descubre de dónde son los Pokémon de Tierra, Agua, Fuego y Aire y la historia de los 12 luchadores";
            btnIdiomaLore.Text = en ? "🌐 Lang: EN" : "🌐 Idioma: ES";
            btnCerrarLore.Text = en ? "Close Lore" : "Cerrar Lore";

            grpFacciones.Text = en ? "1. Factions & Pokémon (12)" : "1. Facciones y Pokémon (12)";
            lblFil.Text = en ? "Filter by Region / Element:" : "Filtrar por Región / Elemento:";
            btnFiltroTodos.Text = en ? "All Pokémon (12)" : "Todos los Pokémon (12)";
            btnFiltroTierra.Text = en ? "Earth — Rocky Canyon (3)" : "Tierra — Cañón Rocoso (3)";
            btnFiltroAgua.Text = en ? "Water — Cascade Stadium (3)" : "Agua — Estadio Cascada (3)";
            btnFiltroFuego.Text = en ? "Fire — Cinnabar Volcano (3)" : "Fuego — Volcán Cinnabar (3)";
            btnFiltroAire.Text = en ? "Air — Sky Tower (3)" : "Aire — Torre Celeste (3)";
            lblListaPok.Text = en ? "Select a Pokémon from Catalog:" : "Selecciona un Pokémon del Catálogo:";
            lblHistInd.Text = en ? "Individual Pokémon Biography & Lore:" : "Biografía y Lore Individual del Pokémon:";
        }

        private void AplicarFiltro(string elementoFiltro, Personaje seleccionar)
        {
            this.filtroActual = elementoFiltro;
            this.listaFiltrada.Clear();
            this.lstPokemonLore.Items.Clear();

            int indiceSeleccionar = 0;

            for (int i = 0; i < catalogoCompleto.Count; i++)
            {
                Personaje p = catalogoCompleto[i];
                if (elementoFiltro == "Todos" || p.Elemento == elementoFiltro)
                {
                    if (seleccionar != null && p.Nombre == seleccionar.Nombre)
                    {
                        indiceSeleccionar = listaFiltrada.Count;
                    }
                    listaFiltrada.Add(p);
                    lstPokemonLore.Items.Add(p.Nombre + " [" + Program.TraducirElemento(p.Elemento) + "] - " + p.ObtenerArenaNatal());
                }
            }

            ResaltarBotonFiltro(elementoFiltro);

            if (lstPokemonLore.Items.Count > 0)
            {
                lstPokemonLore.SelectedIndex = indiceSeleccionar;
            }
        }

        private void ResaltarBotonFiltro(string elem)
        {
            btnFiltroTodos.BackColor = (elem == "Todos") ? Color.FromArgb(40, 105, 170) : Color.FromArgb(225, 230, 240);
            btnFiltroTodos.ForeColor = (elem == "Todos") ? Color.White : Color.Black;

            btnFiltroTierra.BackColor = (elem == "Tierra") ? Color.FromArgb(165, 115, 55) : Color.FromArgb(245, 232, 210);
            btnFiltroTierra.ForeColor = (elem == "Tierra") ? Color.White : Color.Black;

            btnFiltroAgua.BackColor = (elem == "Agua") ? Color.FromArgb(45, 135, 215) : Color.FromArgb(215, 238, 255);
            btnFiltroAgua.ForeColor = (elem == "Agua") ? Color.White : Color.Black;

            btnFiltroFuego.BackColor = (elem == "Fuego") ? Color.FromArgb(215, 65, 40) : Color.FromArgb(255, 225, 215);
            btnFiltroFuego.ForeColor = (elem == "Fuego") ? Color.White : Color.Black;

            btnFiltroAire.BackColor = (elem == "Aire") ? Color.FromArgb(50, 145, 175) : Color.FromArgb(225, 248, 255);
            btnFiltroAire.ForeColor = (elem == "Aire") ? Color.White : Color.Black;
        }

        private Escenario BuscarEscenarioPorElemento(string elemento)
        {
            if (listaEscenarios != null)
            {
                foreach (Escenario e in listaEscenarios)
                {
                    if (e.ElementoFavorecido == elemento) return e;
                }
            }
            return null;
        }

        private void LstPokemonLore_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = lstPokemonLore.SelectedIndex;
            if (idx < 0 || idx >= listaFiltrada.Count) return;

            MostrarLorePokemon(listaFiltrada[idx]);
        }

        private void MostrarLorePokemon(Personaje p)
        {
            if (p == null) return;
            bool en = Program.IdiomaIngles;
            string elemTrad = Program.TraducirElemento(p.Elemento);

            picCartaPokemonLore.Image = gestorArchivo.DibujarCartaPokemon(p, false);

            Escenario escNatal = BuscarEscenarioPorElemento(p.Elemento);
            if (escNatal != null)
            {
                lblArenaNatal.Text = en
                    ? "Homeland / Native Arena: " + escNatal.ToString() + " (+" + escNatal.BonoAtaque + " ATK Bonus to " + elemTrad + ")"
                    : "Territorio / Arena Natal: " + escNatal.ToString() + " (Bono +" + escNatal.BonoAtaque + " ATK a " + p.Elemento + ")";
                picArenaNatal.Image = gestorArchivo.ObtenerImagenArena(escNatal, 250, 115);
            }
            else
            {
                lblArenaNatal.Text = (en ? "Homeland / Native Arena: " : "Territorio / Arena Natal: ") + p.ObtenerArenaNatal();
                picArenaNatal.Image = null;
            }

            grpOrigenFaccion.Text = en
                ? "2. Where are " + elemTrad + " Pokémon from? (Faction Origin & Lore)"
                : "2. ¿De dónde son los Pokémon de " + p.Elemento + "? (Origen y Lore de la Facción)";
            string textoFaccion = p.ObtenerLoreFaccion();
            if (escNatal != null && escNatal.DescripcionLore != null && escNatal.DescripcionLore != "")
            {
                textoFaccion += "\r\n\r\n[" + (en ? "ELEMENTAL SANCTUARY - " : "SANTUARIO ELEMENTAL - ") + escNatal.Nombre.ToUpper() + "]: " + escNatal.DescripcionLore;
            }
            txtLoreFaccion.Text = textoFaccion;

            grpDetallePokemon.Text = en
                ? "3. History, Origin & Attributes of " + p.Nombre + " (" + elemTrad + ")"
                : "3. Historia, Origen y Atributos de " + p.Nombre + " (" + p.Elemento + ")";
            lblNombreElem.Text = en
                ? p.Nombre.ToUpper() + "  —  " + elemTrad + " Elemental Faction"
                : p.Nombre.ToUpper() + "  —  Facción Elemental de " + p.Elemento;
            lblRegionOrigen.Text = (en ? "Origin Region: " : "Región de Origen: ") + p.RegionOrigen;
            lblHabilidadLore.Text = (en ? "Special Skill: " : "Habilidad Especial: ") + p.NombreHabilidad + " (" + p.Descripcion + ")";
            lblStatsLore.Text = en
                ? "Base Stats (Balance = 100 pts):   HP: " + p.VidaMaxima +
                  "   |   Shield (DEF): " + p.Defensa +
                  "   |   Attack (ATK): " + p.Ataque +
                  "   |   Empathy: " + p.Empatia
                : "Estadísticas Base (Balance = 100 pts):   HP: " + p.VidaMaxima +
                  "   |   Escudo (DEF): " + p.Defensa +
                  "   |   Ataque (ATK): " + p.Ataque +
                  "   |   Empatía: " + p.Empatia;

            int empTerremoto = (p.Elemento == "Tierra") ? (p.Empatia + 10) : p.Empatia;
            if (empTerremoto >= 75)
            {
                lblTerremotoLore.Text = en
                    ? "Seismic Bond (Earthquake): Effective Empathy " + empTerremoto + " (>= 75) -> Reverses earthquake and heals +8 HP & +8 DEF!"
                    : "Vínculo Sísmico (Terremoto): Empatía Efectiva " + empTerremoto + " (>= 75) -> ¡Invierte el terremoto y se cura +8 HP y +8 DEF!";
                lblTerremotoLore.ForeColor = Color.DarkGreen;
            }
            else
            {
                lblTerremotoLore.Text = en
                    ? "Seismic Bond (Earthquake): Effective Empathy " + empTerremoto + " (< 75) -> Suffers earthquake damage (-10 DEF & -6 HP)."
                    : "Vínculo Sísmico (Terremoto): Empatía Efectiva " + empTerremoto + " (< 75) -> Sufre el impacto del terremoto (-10 DEF y -6 HP).";
                lblTerremotoLore.ForeColor = Color.Firebrick;
            }

            lblVentajaLore.Text = (en ? "Elemental Mechanic: " : "Mecánica Elemental: ") + p.ObtenerResumenVentajaElemental();

            txtLoreIndividual.Text = p.Lore + "\r\n\r\n" +
                                     (en ? "--- BATTLE BEHAVIOR ---\r\n• Attack Action: " : "--- COMPORTAMIENTO EN COMBATE ---\r\n• Acción de Ataque: ") +
                                     p.EjecutarAccionCombate(p) + "\r\n" +
                                     (en ? "• Special Skill (" + p.NombreHabilidad + "): Requires round > 1, 100% charge and 2 Energy."
                                         : "• Habilidad Especial (" + p.NombreHabilidad + "): Requiere turno > 1, 100% de carga y 2 de Energía.");
        }

        private void BtnFiltroTodos_Click(object sender, EventArgs e)
        {
            AplicarFiltro("Todos", null);
        }

        private void BtnFiltroTierra_Click(object sender, EventArgs e)
        {
            AplicarFiltro("Tierra", null);
        }

        private void BtnFiltroAgua_Click(object sender, EventArgs e)
        {
            AplicarFiltro("Agua", null);
        }

        private void BtnFiltroFuego_Click(object sender, EventArgs e)
        {
            AplicarFiltro("Fuego", null);
        }

        private void BtnFiltroAire_Click(object sender, EventArgs e)
        {
            AplicarFiltro("Aire", null);
        }

        private void BtnCerrarLore_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
