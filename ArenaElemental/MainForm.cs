/*
 * Created by SharpDevelop.
 * User: Ender
 * Date: 4/11/2026
 * Time: 6:27 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ArenaElemental
{
    public partial class MainForm : Form
    {
        private GestorCombate gestorCombate;
        private GestorArchivo gestorArchivo;
        private GestorBaseDatos gestorBD;
        private GestorRed gestorRed;

        private List<Personaje> catalogoCartas;
        private List<Escenario> listaEscenarios;
        private List<Jugador> listaJugadores;

        private int idxJugador1 = 0;
        private int idxJugador2 = 1;
        private int idxEscenario1 = 0;
        private int idxEscenario2 = 1;
        private bool alternarEscenarios = true;
        private int modoSeleccionado = 0;
        private string ipPuertoRed = "127.0.0.1:5000";
        private int tiempoRestante = 20;

        // Constructor vacío requerido por el diseñador visual de SharpDevelop
        public MainForm()
        {
            InitializeComponent();
        }

        // Constructor invocado únicamente desde el Menú de Inicio
        public MainForm(
            List<Jugador> jugadores,
            List<Personaje> catalogo,
            List<Escenario> escenarios,
            GestorBaseDatos bd,
            GestorArchivo archivo,
            int idxJ1,
            int idxJ2,
            int esc1,
            int esc2,
            bool alternar,
            int modoJuego,
            string ipPuerto)
        {
            InitializeComponent();

            this.gestorArchivo = archivo;
            this.gestorBD = bd;
            this.gestorCombate = new GestorCombate();
            this.gestorRed = new GestorRed();
            this.gestorRed.AlRecibirMensaje = ProcesarMensajeRed;

            this.catalogoCartas = catalogo;
            this.listaEscenarios = escenarios;
            this.listaJugadores = jugadores;
            this.idxJugador1 = idxJ1;
            this.idxJugador2 = idxJ2;
            this.idxEscenario1 = esc1;
            this.idxEscenario2 = esc2;
            this.alternarEscenarios = alternar;
            this.modoSeleccionado = modoJuego;
            this.ipPuertoRed = ipPuerto;

            if (modoSeleccionado == 2 || modoSeleccionado == 3)
            {
                ConectarRedSiCorresponde();
            }

            IniciarCombate();
        }

        private void ConectarRedSiCorresponde()
        {
            string[] partes = ipPuertoRed.Split(':');
            string ip = partes[0];
            int puerto = 5000;
            if (partes.Length > 1) int.TryParse(partes[1], out puerto);

            if (modoSeleccionado == 2)
            {
                MessageBox.Show(gestorRed.IniciarServidor(puerto));
            }
            else if (modoSeleccionado == 3)
            {
                MessageBox.Show(gestorRed.ConectarCliente(ip, puerto));
            }
        }

        private void IniciarCombate()
        {
            Jugador j1 = listaJugadores[idxJugador1];
            Jugador j2 = null;

            if (modoSeleccionado == 1)
            {
                j2 = new Jugador("Sistema (CPU)", 0, 0, 0);
                for (int k = 0; k < 5 && k < catalogoCartas.Count; k++)
                {
                    j2.Mazo.Add(catalogoCartas[(k * 2) % catalogoCartas.Count].Clonar());
                }
            }
            else
            {
                j2 = listaJugadores[idxJugador2];
            }

            Escenario e1 = listaEscenarios[idxEscenario1];
            Escenario e2 = listaEscenarios[idxEscenario2];

            gestorCombate.IniciarCombate(j1, j2, e1, e2, alternarEscenarios);

            tiempoRestante = 20;
            timerTurno.Start();

            AplicarIdiomaCombate();
            RefrescarPantalla();
            RevisarTurnoCPU();
        }

        private void BtnIdiomaCombate_Click(object sender, EventArgs e)
        {
            Program.IdiomaIngles = !Program.IdiomaIngles;
            AplicarIdiomaCombate();
            RefrescarPantalla();
        }

        private void AplicarIdiomaCombate()
        {
            bool en = Program.IdiomaIngles;

            this.Text = en
                ? "Pokémon Elemental Arena - Battle View"
                : "Pokémon Arena Elemental - Vista de Combate";
            btnIdiomaCombate.Text = en ? "🌐 EN" : "🌐 ES";
            btnLoreCombate.Text = "📜 Lore";
            btnGuardar.Text = en ? "Save .TXT" : "Guardar .TXT";
            btnVolverMenu.Text = en ? "Back to Menu" : "Volver al Menú";

            lblColaJ1.Text = en
                ? "Pokémon Bench (Queue):"
                : "Banca de Relevos Pokémon (Cola / Queue):";
            lblColaJ2.Text = en
                ? "Pokémon Bench (Queue):"
                : "Banca de Relevos Pokémon (Cola / Queue):";

            grpAcciones.Text = en ? "Active Arena and Actions" : "Arena Activa y Acciones";
            btnAtacar.Text = en ? "Attack (1 ENER)" : "Atacar (1 ENER)";
            btnDefender.Text = en ? "Defend (1 ENER)" : "Defender (1 ENER)";
            btnEspecial.Text = en ? "Special Skill (2 ENER)" : "Hab. Especial (2 ENER)";
            btnRelevar.Text = en ? "Swap Queue (1 ENER)" : "Relevar Cola (1 ENER)";
            btnPasarTurno.Text = en ? "Pass / End Turn" : "Pasar / Terminar Turno";
            btnTerremoto.Text = en ? "Test Earthquake" : "Probar Terremoto";
            btnTerminarCombate.Text = en ? "End Battle" : "Terminar Combate";

            lblHist.Text = en
                ? "Live Pokémon Battle History (Stack):"
                : "Historial de Batalla Pokémon en Vivo (Pila / Stack):";
            btnVerTopePila.Text = en ? "🔍 Stack Top (Peek)" : "🔍 Tope de la Pila (Peek)";
            btnDeshacerPila.Text = en ? "↩ Pop Last (Pop)" : "↩ Desapilar Última (Pop)";
        }

        private void RefrescarPantalla()
        {
            bool en = Program.IdiomaIngles;
            Jugador j1 = gestorCombate.Jugador1;
            Jugador j2 = gestorCombate.Jugador2;

            ActualizarControlesJugador(j1, grpJugador1, picCartaJ1, lblCartaJ1, lblEnergiaJ1,
                lblVidaJ1, pbVidaJ1, lblEscudoJ1, pbEscudoJ1, lblEspecialJ1, pbEspecialJ1, lstColaJ1);

            ActualizarControlesJugador(j2, grpJugador2, picCartaJ2, lblCartaJ2, lblEnergiaJ2,
                lblVidaJ2, pbVidaJ2, lblEscudoJ2, pbEscudoJ2, lblEspecialJ2, pbEspecialJ2, lstColaJ2);

            if (gestorCombate.PartidaActiva)
            {
                lblEstado.Text = en
                    ? "Round " + gestorCombate.NumeroRonda + " - Turn: " + gestorCombate.JugadorEnTurno.Nombre
                    : "Ronda " + gestorCombate.NumeroRonda + " - Turno de: " + gestorCombate.JugadorEnTurno.Nombre;
            }
            else if (gestorCombate.Ganador != null)
            {
                lblEstado.Text = en
                    ? "Winner: " + gestorCombate.Ganador.Nombre + "!"
                    : "¡Ganador: " + gestorCombate.Ganador.Nombre + "!";
            }

            if (gestorCombate.EscenarioActivo != null)
            {
                lblEscenario.Text = "Arena: " + gestorCombate.EscenarioActivo.ToString();
                picArenaActiva.Image = gestorArchivo.ObtenerImagenArena(gestorCombate.EscenarioActivo, 176, 95);
            }

            lblTiempo.Text = (en ? "Time: " : "Tiempo: ") + tiempoRestante + "s";

            bool activo = gestorCombate.PartidaActiva;
            Jugador enTurno = gestorCombate.JugadorEnTurno;

            bool turnoBloqueadoPorRed = false;
            if (modoSeleccionado == 2 && gestorCombate.TurnoActual != 1) turnoBloqueadoPorRed = true;
            if (modoSeleccionado == 3 && gestorCombate.TurnoActual != 2) turnoBloqueadoPorRed = true;

            if (activo && enTurno != null && enTurno.PersonajeActivo != null && !turnoBloqueadoPorRed)
            {
                btnAtacar.Enabled = (enTurno.Energia >= 1);
                btnDefender.Enabled = (enTurno.Energia >= 1);
                btnEspecial.Enabled = (gestorCombate.NumeroRonda > 1 && enTurno.PersonajeActivo.CargaEspecial >= 100 && enTurno.Energia >= 2);
                btnRelevar.Enabled = (enTurno.ColaRelevos.Count > 0 && enTurno.Energia >= 1);
                btnPasarTurno.Enabled = true;
                btnTerremoto.Enabled = true;
                btnTerminarCombate.Enabled = true;
            }
            else
            {
                btnAtacar.Enabled = false;
                btnDefender.Enabled = false;
                btnEspecial.Enabled = false;
                btnRelevar.Enabled = false;
                btnPasarTurno.Enabled = false;
                btnTerremoto.Enabled = false;
                btnTerminarCombate.Enabled = activo;
            }

            lstHistorial.Items.Clear();
            foreach (string accion in gestorCombate.HistorialAcciones)
            {
                lstHistorial.Items.Add(accion);
            }
        }

        private void ActualizarControlesJugador(
            Jugador j,
            GroupBox grp,
            PictureBox pic,
            Label lblCarta,
            Label lblEner,
            Label lblVida,
            ProgressBar pbVida,
            Label lblEsc,
            ProgressBar pbEsc,
            Label lblEsp,
            ProgressBar pbEsp,
            ListBox lstCola)
        {
            if (j == null) return;
            bool en = Program.IdiomaIngles;

            grp.Text = en
                ? j.Nombre + " (W:" + j.Victorias + " L:" + j.Derrotas + " | " + j.PorcentajeExito + "%)"
                : j.Nombre + " (V:" + j.Victorias + " D:" + j.Derrotas + " | " + j.PorcentajeExito + "%)";
            lblEner.Text = (en ? "Energy: " : "Energia: ") + j.Energia + " | ATK: " + (j.PersonajeActivo != null ? j.PersonajeActivo.Ataque : 0);

            Personaje p = j.PersonajeActivo;
            if (p != null)
            {
                lblCarta.Text = p.Nombre + " [" + Program.TraducirElemento(p.Elemento) + "]";
                lblVida.Text = (en ? "HP: " : "Vida: ") + p.Vida + " / " + p.VidaMaxima + " (EMP:" + p.Empatia + ")";
                pbVida.Maximum = p.VidaMaxima;
                pbVida.Value = p.Vida;

                lblEsc.Text = (en ? "Shield (DEF): " : "Escudo (DEF): ") + p.Defensa;
                pbEsc.Value = Math.Min(pbEsc.Maximum, p.Defensa);

                lblEsp.Text = (en ? "Special Skill: " : "Habilidad Especial: ") + p.CargaEspecial + "%";
                pbEsp.Value = p.CargaEspecial;

                pic.Image = gestorArchivo.DibujarCartaPokemon(p, true);
            }
            else
            {
                lblCarta.Text = en ? "No Pokémon" : "Sin Pokémon";
                lblVida.Text = en ? "HP: 0" : "Vida: 0";
                pbVida.Value = 0;
                lblEsc.Text = en ? "Shield: 0" : "Escudo: 0";
                pbEsc.Value = 0;
                lblEsp.Text = en ? "Special: 0%" : "Especial: 0%";
                pbEsp.Value = 0;
                pic.Image = null;
            }

            lstCola.Items.Clear();
            Personaje proximoEnCola = j.VerSiguienteEnCola();
            foreach (Personaje reserva in j.ColaRelevos)
            {
                string prefijo = (reserva == proximoEnCola) ? (en ? "[Next] " : "[Próximo] ") : "";
                lstCola.Items.Add(prefijo + reserva.Nombre + " (" + Program.TraducirElemento(reserva.Elemento) + ") - HP:" + reserva.Vida + " DEF:" + reserva.Defensa);
            }
        }

        private void BtnAtacar_Click(object sender, EventArgs e)
        {
            gestorCombate.Atacar();
            if (gestorRed.Conectado) gestorRed.EnviarAccion("ATACAR");
            DespuesDeAccion();
        }

        private void BtnDefender_Click(object sender, EventArgs e)
        {
            gestorCombate.Defender();
            if (gestorRed.Conectado) gestorRed.EnviarAccion("DEFENDER");
            DespuesDeAccion();
        }

        private void BtnEspecial_Click(object sender, EventArgs e)
        {
            gestorCombate.UsarEspecial();
            if (gestorRed.Conectado) gestorRed.EnviarAccion("ESPECIAL");
            DespuesDeAccion();
        }

        private void BtnRelevar_Click(object sender, EventArgs e)
        {
            gestorCombate.Relevar();
            if (gestorRed.Conectado) gestorRed.EnviarAccion("RELEVAR");
            DespuesDeAccion();
        }

        private void BtnPasarTurno_Click(object sender, EventArgs e)
        {
            gestorCombate.PasarTurno(false);
            if (gestorRed.Conectado) gestorRed.EnviarAccion("PASAR");
            tiempoRestante = 20;
            RefrescarPantalla();
            RevisarFinOPasoCPU();
        }

        private void BtnTerremoto_Click(object sender, EventArgs e)
        {
            gestorCombate.ActivarTerremoto();
            if (gestorRed.Conectado) gestorRed.EnviarAccion("TERREMOTO");
            RefrescarPantalla();
            RevisarFinOPasoCPU();
        }

        private void BtnTerminarCombate_Click(object sender, EventArgs e)
        {
            if (!gestorCombate.PartidaActiva) return;

            gestorCombate.TerminarCombateManual();
            if (gestorRed.Conectado) gestorRed.EnviarAccion("TERMINAR");
            RefrescarPantalla();
            RevisarFinOPasoCPU();
        }

        private void DespuesDeAccion()
        {
            RefrescarPantalla();

            if (!gestorCombate.PartidaActiva)
            {
                RevisarFinOPasoCPU();
                return;
            }

            if (gestorCombate.JugadorEnTurno.Energia == 0)
            {
                gestorCombate.PasarTurno(false);
                if (gestorRed.Conectado) gestorRed.EnviarAccion("PASAR");
                tiempoRestante = 20;
                RefrescarPantalla();
                RevisarFinOPasoCPU();
            }
        }

        private void TimerTurno_Tick(object sender, EventArgs e)
        {
            if (!gestorCombate.PartidaActiva)
            {
                timerTurno.Stop();
                return;
            }

            tiempoRestante--;
            lblTiempo.Text = (Program.IdiomaIngles ? "Time: " : "Tiempo: ") + tiempoRestante + "s";

            if (tiempoRestante <= 0)
            {
                gestorCombate.PasarTurno(true);
                // Sincronización en red: notificar al otro extremo que expiró el temporizador
                if (gestorRed.Conectado)
                {
                    gestorRed.EnviarAccion("PASAR");
                }

                tiempoRestante = 20;
                RefrescarPantalla();
                RevisarFinOPasoCPU();
            }
        }

        private void RevisarTurnoCPU()
        {
            if (gestorCombate.PartidaActiva && modoSeleccionado == 1 && gestorCombate.TurnoActual == 2)
            {
                gestorCombate.JugarTurnoCPU();
                tiempoRestante = 20;
                RefrescarPantalla();
                RevisarFinOPasoCPU();
            }
        }

        private void RevisarFinOPasoCPU()
        {
            if (!gestorCombate.PartidaActiva && gestorCombate.Ganador != null)
            {
                timerTurno.Stop();

                Jugador j1 = gestorCombate.Jugador1;
                Jugador j2 = gestorCombate.Jugador2;
                Jugador ganador = gestorCombate.Ganador;

                string nomArena = (gestorCombate.EscenarioActivo != null) ? gestorCombate.EscenarioActivo.Nombre : "Estadio Cascada";

                // 1. Actualización relacional en base de datos con asignación verídica de J1 y J2 (Guía 2.6 #1)
                gestorBD.ActualizarEstadisticas(
                    j1,
                    j2,
                    ganador,
                    listaJugadores,
                    nomArena,
                    gestorCombate.NumeroRonda,
                    gestorCombate.TerremotosOcurridos);

                // 2. Exportación estructurada obligatoria del log de combate turno por turno (Guía 2.6 #2 y Enunciado 7.2)
                string[] historialBitacora = gestorCombate.ExtraerBitacoraConPop();
                gestorArchivo.GuardarHistorialDetallado(
                    historialBitacora,
                    j1.Nombre,
                    j2.Nombre,
                    ganador.Nombre,
                    nomArena,
                    gestorCombate.NumeroRonda,
                    gestorCombate.TerremotosOcurridos);

                RefrescarPantalla();
                if (Program.IdiomaIngles)
                {
                    MessageBox.Show("Battle finished! Winner: " + ganador.Nombre +
                                    "\n\nDatabase statistics were updated and the official battle log was exported to HistorialCombate.txt.",
                                    "Arena Victory");
                }
                else
                {
                    MessageBox.Show("¡Fin del combate! Ganador: " + ganador.Nombre +
                                    "\n\nSe actualizaron las estadísticas en la Base de Datos y se exportó la bitácora oficial en HistorialCombate.txt.",
                                    "Victoria en la Arena");
                }
                return;
            }

            RevisarTurnoCPU();
        }

        private void BtnLoreCombate_Click(object sender, EventArgs e)
        {
            Personaje activo = null;
            if (gestorCombate != null && gestorCombate.JugadorEnTurno != null)
            {
                activo = gestorCombate.JugadorEnTurno.PersonajeActivo;
            }

            FormLore ventanaLore = new FormLore(this.catalogoCartas, this.listaEscenarios, this.gestorArchivo, activo);
            ventanaLore.ShowDialog();
            AplicarIdiomaCombate();
            RefrescarPantalla();
        }

        private void BtnVolverMenu_Click(object sender, EventArgs e)
        {
            timerTurno.Stop();
            this.Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            bool en = Program.IdiomaIngles;
            if (gestorCombate.HistorialAcciones.Count == 0)
            {
                MessageBox.Show(en ? "There is no action history to save yet." : "No hay historial de acciones para guardar todavía.");
                return;
            }

            string[] historialArray = gestorCombate.ExtraerBitacoraConPop();
            string j1Nom = (gestorCombate.Jugador1 != null) ? gestorCombate.Jugador1.Nombre : "Jugador 1";
            string j2Nom = (gestorCombate.Jugador2 != null) ? gestorCombate.Jugador2.Nombre : "Jugador 2";
            string ganNom = (gestorCombate.Ganador != null) ? gestorCombate.Ganador.Nombre : (en ? "In progress" : "En curso");
            string nomArena = (gestorCombate.EscenarioActivo != null) ? gestorCombate.EscenarioActivo.Nombre : "Arena";

            gestorArchivo.GuardarHistorialDetallado(
                historialArray,
                j1Nom,
                j2Nom,
                ganNom,
                nomArena,
                gestorCombate.NumeroRonda,
                gestorCombate.TerremotosOcurridos);

            MessageBox.Show(en
                ? "Battle history successfully saved in structured format to HistorialCombate.txt!"
                : "¡Historial guardado exitosamente con formato estructurado en HistorialCombate.txt!");
        }

        // Operación interactiva LIFO - Peek(): Permite al docente inspeccionar el tope de la Pila sin removerlo
        private void BtnVerTopePila_Click(object sender, EventArgs e)
        {
            bool en = Program.IdiomaIngles;
            string ultimo = gestorCombate.ObtenerUltimaAccion();
            MessageBox.Show((en ? "Element at the TOP of the Stack (Peek()):\n\n" : "Elemento en el TOPE de la Pila (Peek()):\n\n") + ultimo,
                            en ? "Dynamic LIFO Structure - Stack (Stack.Peek)" : "Estructura Dinámica LIFO - Pila (Stack.Peek)");
        }

        // Operación interactiva LIFO - Pop(): Permite extraer y desapilar la última jugada de la Pila
        private void BtnDeshacerPila_Click(object sender, EventArgs e)
        {
            bool en = Program.IdiomaIngles;
            string desapilado = gestorCombate.DeshacerUltimaAccionHistorial();
            RefrescarPantalla();

            if (!string.IsNullOrEmpty(desapilado))
            {
                MessageBox.Show((en ? "Element popped with Pop():\n\n" : "Elemento desapilado con Pop():\n\n") + desapilado,
                                en ? "Dynamic LIFO Structure - Stack (Stack.Pop)" : "Estructura Dinámica LIFO - Pila (Stack.Pop)");
            }
            else
            {
                MessageBox.Show(en ? "The history stack is empty." : "La pila de historial está vacía.",
                                en ? "Empty Stack" : "Pila Vacía");
            }
        }

        private void ProcesarMensajeRed(string msg)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<string>(ProcesarMensajeRed), new object[] { msg });
                return;
            }

            if (msg == "CONECTADO")
            {
                IniciarCombate();
                if (gestorCombate.PartidaActiva)
                {
                    gestorRed.EnviarAccion("INICIAR:" + gestorCombate.TurnoActual);
                }
            }
            else if (msg.StartsWith("INICIAR:"))
            {
                int turnoSorteado = int.Parse(msg.Split(':')[1]);
                if (gestorCombate.PartidaActiva)
                {
                    gestorCombate.SincronizarTurnoInicialRed(turnoSorteado);
                    tiempoRestante = 20;
                    timerTurno.Start();
                }
            }
            else if (msg == "ATACAR") gestorCombate.Atacar();
            else if (msg == "DEFENDER") gestorCombate.Defender();
            else if (msg == "ESPECIAL") gestorCombate.UsarEspecial();
            else if (msg == "RELEVAR") gestorCombate.Relevar();
            else if (msg == "TERREMOTO") gestorCombate.ActivarTerremoto();
            else if (msg == "TERMINAR") gestorCombate.TerminarCombateManual();
            else if (msg == "PASAR")
            {
                gestorCombate.PasarTurno(false);
                tiempoRestante = 20;
            }

            // Se refresca siempre y se evalúa victoria para que el cliente remoto registre post-batalla si terminó
            RefrescarPantalla();
            RevisarFinOPasoCPU();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (timerTurno != null) timerTurno.Stop();
            if (gestorRed != null) gestorRed.Cerrar();
            base.OnFormClosing(e);
        }

        private void MainFormLoad(object sender, EventArgs e)
        {
        }
    }
}
