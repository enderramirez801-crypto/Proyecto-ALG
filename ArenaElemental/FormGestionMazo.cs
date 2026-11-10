/*
 * Created by SharpDevelop.
 * User: Ender
 * Date: 5/11/2026
 * Time: 5:35 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ArenaElemental
{
    public partial class FormGestionMazo : Form
    {
        private List<Jugador> listaJugadores;
        private List<Personaje> catalogo;
        private List<Escenario> escenarios;
        private GestorBaseDatos gestorBD;
        private GestorArchivo gestorArchivo;

        public FormGestionMazo()
        {
            InitializeComponent();

            this.gestorArchivo = new GestorArchivo();
            this.gestorBD = new GestorBaseDatos(gestorArchivo);

            // Carga los 12 Pokémon, las 4 Arenas y los jugadores desde BD o archivo .txt
            this.catalogo = gestorBD.CargarCatalogoDesdeBD();
            this.escenarios = gestorBD.CargarEscenariosDesdeBD();
            this.listaJugadores = gestorBD.CargarJugadoresDesdeBD(this.catalogo);

            ActualizarIndicadorBD();
            CargarListas(0, 1, true);
            AplicarIdioma();
        }

        private void BtnIdioma_Click(object sender, EventArgs e)
        {
            Program.IdiomaIngles = !Program.IdiomaIngles;
            AplicarIdioma();
        }

        private void AplicarIdioma()
        {
            bool en = Program.IdiomaIngles;

            this.Text = en
                ? "Pokémon Elemental Arena - Main Menu"
                : "Pokémon Arena Elemental - Menú de Inicio";
            lblTitulo.Text = en
                ? "POKÉMON ELEMENTAL ARENA - MAIN MENU"
                : "POKÉMON ARENA ELEMENTAL - MENÚ DE INICIO";
            btnIdioma.Text = en ? "🌐 Lang: EN" : "🌐 Idioma: ES";
            btnVerLoreHeader.Text = en ? "📜 Pokémon Lore" : "📜 Lore de los Pokémon";

            grpJugador.Text = en ? "1. Register or Select Player" : "1. Registrar o Seleccionar Jugador";
            lblSel.Text = en ? "Player:" : "Jugador:";
            lblNuevo.Text = en ? "New Player:" : "Nuevo Jugador:";
            btnCrearJugador.Text = en ? "Add Player" : "Agregar Jugador";
            btnBorrarTodo.Text = en ? "Reset All" : "Reiniciar a 0";

            grpMazo.Text = en
                ? "2. Build 5-Pokémon Card Team (12 Pokémon Available)"
                : "2. Armar Equipo de 5 Cartas Pokémon (12 Pokémon Disponibles)";
            lblCat.Text = en ? "Pokémon Card Catalog (12):" : "Catálogo de Cartas Pokémon (12):";
            btnAgregar.Text = en ? "Add >>" : "Agregar >>";
            btnQuitar.Text = en ? "<< Remove" : "<< Quitar";
            btnGuardarMazo.Text = en ? "Save Team" : "Guardar Mazo";
            btnVerLoreMazo.Text = en ? "View Lore" : "Ver Lore";

            grpEsc.Text = en
                ? "3. Select Battle Arenas and Contenders"
                : "3. Seleccionar Arenas de Combate y Contendientes";
            lblE1.Text = en ? "Arena 1:" : "Arena 1:";
            chkAlternar.Text = en ? "Alternate Arena 2:" : "Alternar con Arena 2:";
            lblJ1.Text = en ? "Player 1:" : "Jugador 1:";
            lblJ2.Text = en ? "Player 2:" : "Jugador 2:";
            lblModo.Text = en ? "Game Mode:" : "Modalidad de Juego:";
            lblIp.Text = en ? "Net IP:" : "IP Red:";

            int modoPrev = cboModoMenu.SelectedIndex >= 0 ? cboModoMenu.SelectedIndex : 0;
            cboModoMenu.Items.Clear();
            if (en)
            {
                cboModoMenu.Items.AddRange(new object[] {
                    "Local (2 Players)",
                    "Local (vs CPU System)",
                    "Network (TCP Server)",
                    "Network (TCP Client)"
                });
            }
            else
            {
                cboModoMenu.Items.AddRange(new object[] {
                    "Local (2 Jugadores)",
                    "Local (vs Sistema)",
                    "Red (Servidor TCP)",
                    "Red (Cliente TCP)"
                });
            }
            cboModoMenu.SelectedIndex = modoPrev;

            lblEst.Text = en
                ? "Historical Statistics (Matches, Wins, Losses & Win Rate %):"
                : "Estadísticas Históricas (Partidas, Victorias, Derrotas y % de Éxito):";
            btnIniciarCombate.Text = en ? "START BATTLE!" : "¡INICIAR COMBATE!";

            ActualizarIndicadorBD();

            int catIdx = lstCatalogo.SelectedIndex >= 0 ? lstCatalogo.SelectedIndex : 0;
            lstCatalogo.Items.Clear();
            foreach (Personaje p in catalogo)
            {
                lstCatalogo.Items.Add(p.Nombre + " (" + Program.TraducirElemento(p.Elemento) + ") - HP:" + p.VidaMaxima +
                                      " DEF:" + p.Defensa + " ATK:" + p.Ataque + " EMP:" + p.Empatia);
            }
            if (lstCatalogo.Items.Count > catIdx) lstCatalogo.SelectedIndex = catIdx;

            MostrarMazoActual();
            ActualizarRankingTexto();
        }

        private void ActualizarIndicadorBD()
        {
            bool conectada = gestorBD.ProbarConexionBD();
            bool en = Program.IdiomaIngles;
            if (conectada)
            {
                lblSub.Text = en
                    ? "Database: [🟢 Connected to SQL Server (ArenaElementalDB)] | 5-Pokémon Teams"
                    : "Base de Datos: [🟢 Conectado a SQL Server (ArenaElementalDB)] | Equipos de 5 Pokémon";
                lblSub.ForeColor = System.Drawing.Color.PaleGreen;
            }
            else
            {
                lblSub.Text = en
                    ? "Database: [🟠 .TXT Fallback Mode Active (SQL disconnected)] | 5-Pokémon Teams"
                    : "Base de Datos: [🟠 Modo Contingencia .TXT Activo (SQL desconectado)] | Equipos de 5 Pokémon";
                lblSub.ForeColor = System.Drawing.Color.Khaki;
            }
        }

        private void CargarListas(int esc1, int esc2, bool alternar)
        {
            if (cboModoMenu.Items.Count > 0 && cboModoMenu.SelectedIndex < 0)
            {
                cboModoMenu.SelectedIndex = 0;
            }

            lstCatalogo.Items.Clear();
            foreach (Personaje p in catalogo)
            {
                lstCatalogo.Items.Add(p.Nombre + " (" + p.Elemento + ") - HP:" + p.VidaMaxima +
                                      " DEF:" + p.Defensa + " ATK:" + p.Ataque + " EMP:" + p.Empatia);
            }
            if (lstCatalogo.Items.Count > 0) lstCatalogo.SelectedIndex = 0;

            cboEscenario1.Items.Clear();
            cboEscenario2.Items.Clear();
            foreach (Escenario e in escenarios)
            {
                cboEscenario1.Items.Add(e.ToString());
                cboEscenario2.Items.Add(e.ToString());
            }
            if (cboEscenario1.Items.Count > esc1) cboEscenario1.SelectedIndex = esc1;
            if (cboEscenario2.Items.Count > esc2) cboEscenario2.SelectedIndex = esc2;
            chkAlternar.Checked = alternar;

            ActualizarFotoArena1();
            ActualizarFotoArena2();
            ActualizarJugadoresYRanking(0);
        }

        private void CboEscenario1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarFotoArena1();
        }

        private void CboEscenario2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarFotoArena2();
        }

        private void ActualizarFotoArena1()
        {
            int idx = cboEscenario1.SelectedIndex;
            if (idx >= 0 && idx < escenarios.Count)
            {
                picArena1.Image = gestorArchivo.ObtenerImagenArena(escenarios[idx], 280, 115);
            }
        }

        private void ActualizarFotoArena2()
        {
            int idx = cboEscenario2.SelectedIndex;
            if (idx >= 0 && idx < escenarios.Count)
            {
                picArena2.Image = gestorArchivo.ObtenerImagenArena(escenarios[idx], 280, 115);
            }
        }

        private void LstCatalogo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = lstCatalogo.SelectedIndex;
            if (idx >= 0 && idx < catalogo.Count)
            {
                picPreviaCarta.Image = gestorArchivo.DibujarCartaPokemon(catalogo[idx], false);
            }
        }

        private void LstMazo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idxJug = cboJugadores.SelectedIndex;
            int idxMazo = lstMazo.SelectedIndex;
            if (idxJug >= 0 && idxJug < listaJugadores.Count)
            {
                Jugador j = listaJugadores[idxJug];
                if (idxMazo >= 0 && idxMazo < j.Mazo.Count)
                {
                    picPreviaCarta.Image = gestorArchivo.DibujarCartaPokemon(j.Mazo[idxMazo], false);
                }
            }
        }

        private void ActualizarJugadoresYRanking(int idxSeleccionado)
        {
            int prevJ1 = cboCombateJ1.SelectedIndex;
            int prevJ2 = cboCombateJ2.SelectedIndex;

            cboJugadores.Items.Clear();
            cboCombateJ1.Items.Clear();
            cboCombateJ2.Items.Clear();
            lstRanking.Items.Clear();

            foreach (Jugador j in listaJugadores)
            {
                cboJugadores.Items.Add(j.Nombre);
                cboCombateJ1.Items.Add(j.Nombre);
                cboCombateJ2.Items.Add(j.Nombre);

                lstRanking.Items.Add(j.Nombre + " -> Partidas: " + j.PartidasJugadas +
                                     " | Victorias: " + j.Victorias +
                                     " | Derrotas: " + j.Derrotas +
                                     " | Exito: " + j.PorcentajeExito + "% (Cartas: " + j.Mazo.Count + "/5)");
            }

            if (cboJugadores.Items.Count > idxSeleccionado && idxSeleccionado >= 0)
            {
                cboJugadores.SelectedIndex = idxSeleccionado;
            }
            else if (cboJugadores.Items.Count > 0)
            {
                cboJugadores.SelectedIndex = 0;
            }
            else
            {
                lstMazo.Items.Clear();
                lblMazo.Text = "Equipo Pokémon del Jugador (0 / 5):";
            }

            if (cboCombateJ1.Items.Count > 0)
            {
                cboCombateJ1.SelectedIndex = (prevJ1 >= 0 && prevJ1 < cboCombateJ1.Items.Count) ? prevJ1 : 0;
            }
            if (cboCombateJ2.Items.Count > 1)
            {
                cboCombateJ2.SelectedIndex = (prevJ2 >= 0 && prevJ2 < cboCombateJ2.Items.Count && prevJ2 != cboCombateJ1.SelectedIndex) ? prevJ2 : 1;
            }
            else if (cboCombateJ2.Items.Count > 0)
            {
                cboCombateJ2.SelectedIndex = 0;
            }
        }

        private void CboJugadores_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarMazoActual();
        }

        private void MostrarMazoActual()
        {
            lstMazo.Items.Clear();
            bool en = Program.IdiomaIngles;
            int idx = cboJugadores.SelectedIndex;
            if (idx < 0 || idx >= listaJugadores.Count)
            {
                lblMazo.Text = en ? "Player Pokémon Team (0 / 5):" : "Equipo Pokémon del Jugador (0 / 5):";
                return;
            }

            Jugador j = listaJugadores[idx];
            lblMazo.Text = en
                ? j.Nombre + "'s Team (" + j.Mazo.Count + " / 5 Pokémon):"
                : "Equipo de " + j.Nombre + " (" + j.Mazo.Count + " / 5 Pokémon):";

            for (int i = 0; i < j.Mazo.Count; i++)
            {
                Personaje p = j.Mazo[i];
                string puesto = (i == 0)
                    ? (en ? "[Active] " : "[Activo] ")
                    : (en ? "[Queue " + i + "] " : "[Cola " + i + "] ");
                lstMazo.Items.Add(puesto + p.Nombre + " (" + Program.TraducirElemento(p.Elemento) + ")");
            }
        }

        private void BtnCrearJugador_Click(object sender, EventArgs e)
        {
            bool en = Program.IdiomaIngles;
            string nom = txtNuevoNombre.Text.Trim();
            if (nom == "")
            {
                MessageBox.Show(en ? "Enter a name for the new player." : "Escribe un nombre para el nuevo jugador.");
                return;
            }

            Jugador nuevo = gestorBD.RegistrarJugador(nom, listaJugadores);
            txtNuevoNombre.Text = "";
            ActualizarJugadoresYRanking(listaJugadores.IndexOf(nuevo));

            if (listaJugadores.Count == 1) cboCombateJ1.SelectedIndex = 0;
            else if (listaJugadores.Count == 2)
            {
                cboCombateJ1.SelectedIndex = 0;
                cboCombateJ2.SelectedIndex = 1;
            }

            MessageBox.Show(en
                ? "Player '" + nuevo.Nombre + "' created. Now add 5 Pokémon from the catalog."
                : "Jugador '" + nuevo.Nombre + "' creado. Ahora agrégale sus 5 Pokémon del catálogo.");
        }

        private void BtnBorrarTodo_Click(object sender, EventArgs e)
        {
            bool en = Program.IdiomaIngles;
            listaJugadores.Clear();
            gestorArchivo.BorrarDatosRegistrados();
            gestorBD.BorrarDatosEnBD();
            ActualizarJugadoresYRanking(-1);
            ActualizarIndicadorBD();
            MessageBox.Show(en
                ? "All players, teams, and statistics have been reset to zero in both SQL Server and text files."
                : "Todos los jugadores, equipos y estadísticas fueron reiniciados a cero tanto en SQL Server como en los archivos de texto.");
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            bool en = Program.IdiomaIngles;
            int idxJug = cboJugadores.SelectedIndex;
            int idxCarta = lstCatalogo.SelectedIndex;
            if (idxJug < 0)
            {
                MessageBox.Show(en ? "First create or select a player above." : "Primero crea o selecciona un jugador arriba.");
                return;
            }
            if (idxCarta < 0) return;

            Jugador j = listaJugadores[idxJug];
            if (j.Mazo.Count >= 5)
            {
                MessageBox.Show(en ? "The team already has all 5 Pokémon." : "El equipo ya tiene los 5 Pokémon completos.");
                return;
            }

            j.Mazo.Add(catalogo[idxCarta].Clonar());
            gestorBD.GuardarEquipoEnBD(j, listaJugadores);
            MostrarMazoActual();
            ActualizarRankingTexto();
        }

        private void BtnQuitar_Click(object sender, EventArgs e)
        {
            int idxJug = cboJugadores.SelectedIndex;
            int idxMazo = lstMazo.SelectedIndex;
            if (idxJug < 0 || idxMazo < 0) return;

            Jugador j = listaJugadores[idxJug];
            j.Mazo.RemoveAt(idxMazo);
            gestorBD.GuardarEquipoEnBD(j, listaJugadores);
            MostrarMazoActual();
            ActualizarRankingTexto();
        }

        private void ActualizarRankingTexto()
        {
            bool en = Program.IdiomaIngles;
            lstRanking.Items.Clear();
            foreach (Jugador j in listaJugadores)
            {
                if (en)
                {
                    lstRanking.Items.Add(j.Nombre + " -> Matches: " + j.PartidasJugadas +
                                         " | Wins: " + j.Victorias +
                                         " | Losses: " + j.Derrotas +
                                         " | Win Rate: " + j.PorcentajeExito + "% (Cards: " + j.Mazo.Count + "/5)");
                }
                else
                {
                    lstRanking.Items.Add(j.Nombre + " -> Partidas: " + j.PartidasJugadas +
                                         " | Victorias: " + j.Victorias +
                                         " | Derrotas: " + j.Derrotas +
                                         " | Exito: " + j.PorcentajeExito + "% (Cartas: " + j.Mazo.Count + "/5)");
                }
            }
        }

        private void BtnGuardarMazo_Click(object sender, EventArgs e)
        {
            bool en = Program.IdiomaIngles;
            int idxJug = cboJugadores.SelectedIndex;
            if (idxJug < 0)
            {
                MessageBox.Show(en ? "First create or select a player." : "Primero crea o selecciona un jugador.");
                return;
            }

            Jugador j = listaJugadores[idxJug];
            if (j.Mazo.Count != 5)
            {
                MessageBox.Show(en
                    ? j.Nombre + "'s team must have 5 Pokémon (currently " + j.Mazo.Count + ")."
                    : "El equipo de " + j.Nombre + " debe tener 5 Pokémon (llevas " + j.Mazo.Count + ").");
                return;
            }

            gestorBD.GuardarEquipoEnBD(j, listaJugadores);
            MessageBox.Show(en
                ? "5-Pokémon team saved for " + j.Nombre + "."
                : "Equipo de 5 Pokémon guardado para " + j.Nombre + ".");
        }

        private void BtnIniciarCombate_Click(object sender, EventArgs e)
        {
            bool en = Program.IdiomaIngles;
            if (listaJugadores.Count == 0)
            {
                MessageBox.Show(en
                    ? "First register Player 1 and add 5 Pokémon to their team."
                    : "Primero registra al Jugador 1 y agrégale sus 5 Pokémon al equipo.");
                return;
            }

            int i1 = cboCombateJ1.SelectedIndex;
            if (i1 < 0 || i1 >= listaJugadores.Count)
            {
                MessageBox.Show(en ? "Select Player 1." : "Selecciona al Jugador 1.");
                return;
            }

            Jugador j1 = listaJugadores[i1];
            if (j1.Mazo.Count < 5)
            {
                MessageBox.Show(en
                    ? "Team '" + j1.Nombre + "' has " + j1.Mazo.Count + " Pokémon. Add 5 Pokémon before starting battle."
                    : "El equipo de '" + j1.Nombre + "' tiene " + j1.Mazo.Count + " Pokémon. Agrégale sus 5 Pokémon antes de iniciar el combate.");
                return;
            }

            int modo = cboModoMenu.SelectedIndex >= 0 ? cboModoMenu.SelectedIndex : 0;
            int i2 = cboCombateJ2.SelectedIndex;

            if (modo != 1) // Si no es contra Sistema (CPU), valida el Jugador 2
            {
                if (listaJugadores.Count < 2)
                {
                    MessageBox.Show(en
                        ? "To play 2-player mode, register Player 2 as well and build their 5-Pokémon team."
                        : "Para jugar 2 jugadores necesitas registrar también al Jugador 2 y armar su equipo de 5 Pokémon.");
                    return;
                }
                if (i2 < 0 || i1 == i2)
                {
                    MessageBox.Show(en
                        ? "Select two different players for Player 1 and Player 2."
                        : "Selecciona dos jugadores distintos en Jugador 1 y Jugador 2.");
                    return;
                }
                Jugador j2 = listaJugadores[i2];
                if (j2.Mazo.Count < 5)
                {
                    MessageBox.Show(en
                        ? "Team '" + j2.Nombre + "' has " + j2.Mazo.Count + " Pokémon. Add 5 Pokémon before starting battle."
                        : "El equipo de '" + j2.Nombre + "' tiene " + j2.Mazo.Count + " Pokémon. Agrégale sus 5 Pokémon antes de iniciar el combate.");
                    return;
                }
            }

            gestorArchivo.GuardarJugadores(listaJugadores);

            // Oculta el Menú de Inicio y abre únicamente la Vista de Combate
            this.Hide();
            MainForm vistaCombate = new MainForm(
                listaJugadores,
                catalogo,
                escenarios,
                gestorBD,
                gestorArchivo,
                i1,
                i2,
                cboEscenario1.SelectedIndex,
                cboEscenario2.SelectedIndex,
                chkAlternar.Checked,
                modo,
                txtIpMenu.Text);

            vistaCombate.ShowDialog();

            // Al terminar o cerrar la vista de combate, regresa al Menú de Inicio con estadísticas actualizadas
            ActualizarJugadoresYRanking(cboJugadores.SelectedIndex);
            AplicarIdioma();
            this.Show();
        }

        private void BtnVerLore_Click(object sender, EventArgs e)
        {
            Personaje seleccionado = null;
            if (lstCatalogo.SelectedIndex >= 0 && lstCatalogo.SelectedIndex < catalogo.Count)
            {
                seleccionado = catalogo[lstCatalogo.SelectedIndex];
            }

            FormLore ventanaLore = new FormLore(this.catalogo, this.escenarios, this.gestorArchivo, seleccionado);
            ventanaLore.ShowDialog();
        }
    }
}
