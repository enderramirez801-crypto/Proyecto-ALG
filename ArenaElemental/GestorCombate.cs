/*
 * Created by SharpDevelop.
 * User: Ender
 * Date: 4/11/2026
 * Time: 6:45 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace ArenaElemental
{
    public class GestorCombate
    {
        private Jugador jugador1;
        private Jugador jugador2;
        private Escenario escenario1;
        private Escenario escenario2;
        private Escenario escenarioActivo;
        private bool alternarEscenarios;

        private Queue<Personaje> colaTurnos;
        private Stack<string> historialAcciones;

        private int turnoActual; // 1 o 2
        private int numeroRonda;
        private int terremotosOcurridos;
        private bool partidaActiva;
        private Jugador ganador;
        private Random random;

        public Jugador Jugador1
        {
            get { return jugador1; }
            set { jugador1 = value; }
        }

        public Jugador Jugador2
        {
            get { return jugador2; }
            set { jugador2 = value; }
        }

        public Escenario EscenarioActivo
        {
            get { return escenarioActivo; }
        }

        public Queue<Personaje> ColaTurnos
        {
            get { return colaTurnos; }
        }

        public Stack<string> HistorialAcciones
        {
            get { return historialAcciones; }
        }

        public int TurnoActual
        {
            get { return turnoActual; }
        }

        public int NumeroRonda
        {
            get { return numeroRonda; }
        }

        public int TerremotosOcurridos
        {
            get { return terremotosOcurridos; }
        }

        // Consulta la última acción registrada en el tope de la Pila usando Peek() (Regla de Oro #2)
        public string ObtenerUltimaAccion()
        {
            if (historialAcciones.Count == 0) return "La pila de historial está vacía.";
            return historialAcciones.Peek();
        }

        // Extrae y elimina la última acción del tope de la Pila usando Pop() (Regla de Oro #2)
        public string DeshacerUltimaAccionHistorial()
        {
            if (historialAcciones.Count == 0) return "";
            return historialAcciones.Pop();
        }

        // Extrae todos los registros de la Pila mediante Pop() secuencial en orden cronológico (Turno 1 -> Final)
        public string[] ExtraerBitacoraConPop()
        {
            // Al inicializar un nuevo Stack a partir de historialAcciones, el orden de iteración
            // (que empieza por el tope) deja los elementos más antiguos en el tope de tempStack.
            // Al hacer Pop() de tempStack, se extraen secuencialmente desde el primer turno hasta el último.
            Stack<string> tempStack = new Stack<string>(historialAcciones);
            List<string> resultado = new List<string>();
            while (tempStack.Count > 0)
            {
                resultado.Add(tempStack.Pop());
            }
            return resultado.ToArray();
        }

        public bool PartidaActiva
        {
            get { return partidaActiva; }
        }

        public Jugador Ganador
        {
            get { return ganador; }
        }

        public Jugador JugadorEnTurno
        {
            get { return (turnoActual == 1) ? jugador1 : jugador2; }
        }

        public Jugador JugadorRival
        {
            get { return (turnoActual == 1) ? jugador2 : jugador1; }
        }

        public GestorCombate()
        {
            colaTurnos = new Queue<Personaje>();
            historialAcciones = new Stack<string>();
            random = new Random();
            turnoActual = 1;
            numeroRonda = 1;
            partidaActiva = false;
        }

        // Inicia el combate entre los dos jugadores
        public void IniciarCombate(Jugador j1, Jugador j2, Escenario esc1, Escenario esc2, bool alternar)
        {
            this.jugador1 = j1;
            this.jugador2 = j2;
            this.escenario1 = esc1;
            this.escenario2 = esc2;
            this.alternarEscenarios = alternar;

            historialAcciones.Clear();
            j1.PrepararEquipo();
            j2.PrepararEquipo();

            // Sorteo aleatorio del jugador inicial (Requisito Guía 5)
            turnoActual = random.Next(1, 3);
            numeroRonda = 1;
            terremotosOcurridos = 0;
            ganador = null;
            partidaActiva = true;

            escenarioActivo = esc1;

            if (Program.IdiomaIngles)
            {
                historialAcciones.Push("=== ELEMENTAL ARENA BATTLE STARTED ===");
                historialAcciones.Push("Active Arena: " + escenarioActivo.ToString());
                historialAcciones.Push("Random draw: " + JugadorEnTurno.Nombre + " starts the battle with 2 Energy.");
            }
            else
            {
                historialAcciones.Push("=== INICIO DEL COMBATE EN ARENA ELEMENTAL ===");
                historialAcciones.Push("Arena activa: " + escenarioActivo.ToString());
                historialAcciones.Push("Sorteo aleatorio: Inicia el combate " + JugadorEnTurno.Nombre + " con 2 de Energía.");
            }
        }

        // Sincroniza el turno inicial para multijugador por Sockets TCP
        public void SincronizarTurnoInicialRed(int turnoSorteado)
        {
            this.turnoActual = turnoSorteado;
            historialAcciones.Clear();
            jugador1.PrepararEquipo();
            jugador2.PrepararEquipo();
            numeroRonda = 1;
            terremotosOcurridos = 0;
            ganador = null;
            partidaActiva = true;
            escenarioActivo = escenario1;

            if (Program.IdiomaIngles)
            {
                historialAcciones.Push("=== SYNCHRONIZED TCP NETWORK BATTLE ===");
                historialAcciones.Push("Active Arena: " + escenarioActivo.ToString());
                historialAcciones.Push("Synchronized initial turn: " + JugadorEnTurno.Nombre + " with 2 Energy.");
            }
            else
            {
                historialAcciones.Push("=== COMBATE EN RED TCP SINCRONIZADO ===");
                historialAcciones.Push("Arena activa: " + escenarioActivo.ToString());
                historialAcciones.Push("Turno inicial sincronizado: " + JugadorEnTurno.Nombre + " con 2 de Energía.");
            }
        }

        // Acción 1: Atacar (Consume 1 de energía)
        public string Atacar()
        {
            bool en = Program.IdiomaIngles;
            if (!partidaActiva) return en ? "The match has already ended." : "La partida ya terminó.";

            Jugador actual = JugadorEnTurno;
            Jugador rival = JugadorRival;

            if (actual.Energia < 1)
            {
                return en ? "Not enough energy to attack." : "No tienes suficiente energía para atacar.";
            }

            actual.Energia -= 1;
            // Progresión controlada de la habilidad especial (+15% por acción ofensiva)
            actual.PersonajeActivo.CargaEspecial += 15;

            int bono = escenarioActivo.CalcularBono(actual.PersonajeActivo);
            int danio = actual.PersonajeActivo.CalcularDanio(rival.PersonajeActivo, bono);
            ResultadoDanio res = rival.PersonajeActivo.RecibirDanio(danio);

            string texto = en
                ? actual.PersonajeActivo.EjecutarAccionCombate(rival.PersonajeActivo) +
                  " Deals " + danio + " pts [Shield mitigated: " + res.DanioMitigadoPorEscudo +
                  ", Net HP damage: " + res.DanioDirectoVida + "]. " +
                  rival.PersonajeActivo.Nombre + " (HP: " + res.VidaRestante + "/" +
                  rival.PersonajeActivo.VidaMaxima + ", DEF: " + res.EscudoRestante + ")"
                : actual.PersonajeActivo.EjecutarAccionCombate(rival.PersonajeActivo) +
                  " Causa " + danio + " pts [Mitigado por escudo: " + res.DanioMitigadoPorEscudo +
                  ", Daño neto a vida: " + res.DanioDirectoVida + "]. " +
                  rival.PersonajeActivo.Nombre + " (HP: " + res.VidaRestante + "/" +
                  rival.PersonajeActivo.VidaMaxima + ", DEF: " + res.EscudoRestante + ")";

            historialAcciones.Push((en ? "[Round " : "[Ronda ") + numeroRonda + " - " + actual.Nombre + "] " + texto);
            RevisarSiMurio(rival, actual);

            return texto;
        }

        // Acción 2: Defender (Consume 1 de energía e incrementa el escudo)
        public string Defender()
        {
            bool en = Program.IdiomaIngles;
            if (!partidaActiva) return en ? "The match has already ended." : "La partida ya terminó.";

            Jugador actual = JugadorEnTurno;
            if (actual.Energia < 1)
            {
                return en ? "Not enough energy to defend." : "No tienes suficiente energía para defender.";
            }

            actual.Energia -= 1;
            // Progresión controlada de la barra especial (+15% por acción defensiva)
            actual.PersonajeActivo.CargaEspecial += 15;

            string texto = actual.PersonajeActivo.Defender();
            historialAcciones.Push((en ? "[Round " : "[Ronda ") + numeroRonda + " - " + actual.Nombre + "] " + texto);
            return texto;
        }

        // Acción 3: Habilidad Especial (Consume 2 de energía, requiere 100% y bloqueada en Turno 1)
        public string UsarEspecial()
        {
            bool en = Program.IdiomaIngles;
            if (!partidaActiva) return en ? "The match has already ended." : "La partida ya terminó.";

            Jugador actual = JugadorEnTurno;
            Jugador rival = JugadorRival;

            if (numeroRonda == 1)
            {
                return en ? "Special skill is locked during round 1." : "La habilidad especial está bloqueada durante el turno 1.";
            }
            if (actual.PersonajeActivo.CargaEspecial < 100)
            {
                return en
                    ? "Special skill bar has not reached 100% yet (Current: " + actual.PersonajeActivo.CargaEspecial + "%)."
                    : "La barra de habilidad especial aún no alcanza el 100% (Actual: " + actual.PersonajeActivo.CargaEspecial + "%).";
            }
            if (actual.Energia < 2)
            {
                return en
                    ? "At least 2 energy points are required for the ultimate technique."
                    : "Se requieren al menos 2 puntos de energía para la técnica definitiva.";
            }

            actual.Energia -= 2;

            // Invocación polimórfica de efectos secundarios (ej: robo de energía implementado en Agua y Aire)
            actual.PersonajeActivo.AplicarEfectoSecundarioEspecial(actual, rival);

            string texto = actual.PersonajeActivo.UsarHabilidadEspecial(rival.PersonajeActivo);
            historialAcciones.Push((en ? "[Round " : "[Ronda ") + numeroRonda + (en ? " - SPECIAL] " : " - ESPECIAL] ") + texto);
            RevisarSiMurio(rival, actual);

            return texto;
        }

        // Acción 4: Relevar personaje de la Cola de Reserva (Queue - Enqueue/Dequeue)
        public string Relevar()
        {
            bool en = Program.IdiomaIngles;
            if (!partidaActiva) return en ? "The match has already ended." : "La partida ya terminó.";

            Jugador actual = JugadorEnTurno;
            if (actual.ColaRelevos.Count == 0)
            {
                return en ? "No characters left in the bench queue." : "No quedan personajes disponibles en la cola de relevos.";
            }
            if (actual.Energia < 1)
            {
                return en ? "1 energy point is required to execute a tactical swap." : "Se requiere 1 punto de energía para ejecutar el relevo táctico.";
            }

            actual.Energia -= 1;
            string texto = actual.RelevarPersonaje();
            historialAcciones.Push((en ? "[Round " : "[Ronda ") + numeroRonda + (en ? " - SWAP] " : " - RELEVO] ") + texto);
            return texto;
        }

        // Pasar o cambiar el turno entre jugadores
        public string PasarTurno(bool porTiempo)
        {
            bool en = Program.IdiomaIngles;
            if (!partidaActiva) return en ? "Match finished." : "Partida finalizada.";

            if (porTiempo)
            {
                historialAcciones.Push(en
                    ? "[Round " + numeroRonda + "] Time expired for " + JugadorEnTurno.Nombre + ". Turn forfeited due to inactivity."
                    : "[Ronda " + numeroRonda + "] Tiempo agotado para " + JugadorEnTurno.Nombre + ". Se cede el turno por inactividad.");
            }
            else
            {
                historialAcciones.Push(en
                    ? "[Round " + numeroRonda + "] " + JugadorEnTurno.Nombre + " ends their action turn."
                    : "[Ronda " + numeroRonda + "] " + JugadorEnTurno.Nombre + " finaliza su turno de acción.");
            }

            // Cada 3 rondas se dispara el Evento Algorítmico Terremoto (Guía 2.5)
            if (numeroRonda % 3 == 0)
            {
                ActivarTerremoto();
            }

            if (!partidaActiva) return "¡Fin de la partida!";

            // Alternancia estricta de turnos
            turnoActual = (turnoActual == 1) ? 2 : 1;
            numeroRonda++;

            if (alternarEscenarios && escenario2 != null)
            {
                escenarioActivo = (turnoActual == 1) ? escenario1 : escenario2;
            }

            // Al inicio de turno el jugador activo gana +1 de energía y +25% de carga especial (tarda al menos 2 turnos completos en llegar a 100%)
            Jugador entrante = JugadorEnTurno;
            entrante.Energia += 1;
            if (entrante.PersonajeActivo != null)
            {
                entrante.PersonajeActivo.CargaEspecial += 25;
            }

            return "Turno de " + entrante.Nombre;
        }

        // Dispara el evento catastrófico Terremoto sobre ambos personajes activos
        public void ActivarTerremoto()
        {
            if (!partidaActiva || escenarioActivo == null) return;

            terremotosOcurridos++;
            historialAcciones.Push(Program.IdiomaIngles
                ? "=== ARENA ENVIRONMENTAL EVENT: TECTONIC EARTHQUAKE! ==="
                : "=== ¡EVENTO AMBIENTAL DEL ESCENARIO: TERREMOTO TECTÓNICO! ===");

            if (jugador1.PersonajeActivo != null)
            {
                string res1 = escenarioActivo.AplicarTerremoto(jugador1.PersonajeActivo);
                historialAcciones.Push(res1);
                RevisarSiMurio(jugador1, jugador2);
            }

            if (partidaActiva && jugador2.PersonajeActivo != null)
            {
                string res2 = escenarioActivo.AplicarTerremoto(jugador2.PersonajeActivo);
                historialAcciones.Push(res2);
                RevisarSiMurio(jugador2, jugador1);
            }
        }

        // Cierre manual del combate definiendo el ganador por puntaje de salud total
        public void TerminarCombateManual()
        {
            if (!partidaActiva) return;

            partidaActiva = false;

            int puntosJ1 = CalcularSaludTotalEquipo(jugador1);
            int puntosJ2 = CalcularSaludTotalEquipo(jugador2);

            if (puntosJ1 >= puntosJ2)
            {
                ganador = jugador1;
            }
            else
            {
                ganador = jugador2;
            }

            if (Program.IdiomaIngles)
            {
                historialAcciones.Push("=== BATTLE ENDED BY TOTAL TEAM HEALTH DECISION ===");
                historialAcciones.Push("Proclaimed Winner: " + ganador.Nombre + " (Total team health: " + puntosJ1 + " vs " + puntosJ2 + ")");
            }
            else
            {
                historialAcciones.Push("=== COMBATE FINALIZADO POR DECISIÓN DE SALUD ===");
                historialAcciones.Push("Ganador proclamado: " + ganador.Nombre + " (Salud total de equipo: " + puntosJ1 + " vs " + puntosJ2 + ")");
            }
        }

        private int CalcularSaludTotalEquipo(Jugador j)
        {
            if (j == null) return 0;
            int total = 0;
            if (j.PersonajeActivo != null && j.PersonajeActivo.EstaVivo())
            {
                total += j.PersonajeActivo.Vida + j.PersonajeActivo.Defensa;
            }
            foreach (Personaje p in j.ColaRelevos)
            {
                if (p.EstaVivo()) total += p.Vida + p.Defensa;
            }
            return total;
        }

        // Turno automático de la Inteligencia Artificial (Modo vs CPU)
        public void JugarTurnoCPU()
        {
            if (!partidaActiva || turnoActual != 2) return;

            Jugador cpu = jugador2;
            if (cpu.PersonajeActivo != null)
            {
                if (numeroRonda > 1 && cpu.PersonajeActivo.CargaEspecial >= 100 && cpu.Energia >= 2)
                {
                    UsarEspecial();
                }
                else if (cpu.PersonajeActivo.Defensa == 0 && cpu.Energia >= 2)
                {
                    Defender();
                    if (partidaActiva && cpu.Energia >= 1) Atacar();
                }
                else if (cpu.Energia >= 1)
                {
                    Atacar();
                }
            }

            if (partidaActiva && turnoActual == 2)
            {
                PasarTurno(false);
            }
        }

        private void RevisarSiMurio(Jugador afectado, Jugador atacante)
        {
            if (afectado.PersonajeActivo != null && !afectado.PersonajeActivo.EstaVivo())
            {
                string caido = afectado.PersonajeActivo.Nombre;
                bool tieneRelevo = afectado.SacarSiguientePorMuerte();

                if (tieneRelevo)
                {
                    historialAcciones.Push(Program.IdiomaIngles
                        ? caido + " fainted! " + afectado.PersonajeActivo.Nombre + " enters from the Bench Queue."
                        : "¡" + caido + " cayó debilitado! Entra " + afectado.PersonajeActivo.Nombre + " desde la Cola de Relevos.");
                }
                else
                {
                    partidaActiva = false;
                    ganador = atacante;
                    if (Program.IdiomaIngles)
                    {
                        historialAcciones.Push(caido + " was eliminated and " + afectado.Nombre + " has no more cards in their queue!");
                        historialAcciones.Push("!! ULTIMATE VICTORY: " + atacante.Nombre.ToUpper() + " WINS THE MATCH !!");
                    }
                    else
                    {
                        historialAcciones.Push("¡" + caido + " fue eliminado y " + afectado.Nombre + " no tiene más cartas en su cola!");
                        historialAcciones.Push("¡¡VICTORIA DEFINITIVA: " + atacante.Nombre.ToUpper() + " GANA LA PARTIDA!!");
                    }
                }
            }
        }
    }
}