/*
 * Created by SharpDevelop.
 * User: Ender
 * Date: 5/11/2026
 * Time: 4:10 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ArenaElemental
{
    public class Escenario
    {
        private string nombre;
        private string elementoFavorecido;
        private string elementoPenalizado;
        private int bonoAtaque;
        private string descripcionLore;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string ElementoFavorecido
        {
            get { return elementoFavorecido; }
            set { elementoFavorecido = value; }
        }

        public string ElementoPenalizado
        {
            get { return elementoPenalizado; }
            set { elementoPenalizado = value; }
        }

        public int BonoAtaque
        {
            get { return bonoAtaque; }
            set { bonoAtaque = value; }
        }

        public string DescripcionLore
        {
            get { return descripcionLore; }
            set { descripcionLore = value; }
        }

        public Escenario(string nombre, string elementoFavorecido, string elementoPenalizado, int bonoAtaque)
        {
            this.nombre = nombre;
            this.elementoFavorecido = elementoFavorecido;
            this.elementoPenalizado = elementoPenalizado;
            this.bonoAtaque = bonoAtaque;
            ConfigurarLoreEscenario();
        }

        private void ConfigurarLoreEscenario()
        {
            if (this.elementoFavorecido == "Tierra")
            {
                this.descripcionLore = "Cañón Rocoso: Territorio ancestral de los Pokémon de Tierra (Groudon, Golem y Tyranitar). " +
                                       "Sus paredes de granito y fallas tectónicas potencian el ataque de Tierra (+5 ATK) y absorben " +
                                       "la fuerza de los Pokémon de Agua (-5 ATK).";
            }
            else if (this.elementoFavorecido == "Agua")
            {
                this.descripcionLore = "Estadio Cascada: Santuario acuático de donde provienen los Pokémon de Agua (Blastoise, Gyarados y Vaporeon). " +
                                       "Sus torrentes cristalinos potencian a la facción de Agua (+5 ATK) y sofocan las llamas de Fuego (-5 ATK).";
            }
            else if (this.elementoFavorecido == "Fuego")
            {
                this.descripcionLore = "Volcán Cinnabar: Caldera magmática natal de los Pokémon de Fuego (Charizard, Arcanine y Moltres). " +
                                       "El calor extremo del cráter potencia los ataques de Fuego (+5 ATK) y enrarece las corrientes de Aire (-5 ATK).";
            }
            else if (this.elementoFavorecido == "Aire")
            {
                this.descripcionLore = "Torre Celeste: Atalaya sobre las nubes donde habitan los Pokémon de Aire (Rayquaza, Pidgeot y Lugia). " +
                                       "Los vientos estratosféricos impulsan a la facción de Aire (+5 ATK) y restan estabilidad a los colosos de Tierra (-5 ATK).";
            }
            else
            {
                this.descripcionLore = "Arena elemental que potencia a " + this.elementoFavorecido + " (+5 ATK) y penaliza a " + this.elementoPenalizado + ".";
            }
        }

        // Devuelve el buff o debuff del escenario según la compatibilidad elemental (Guía 2.5)
        public int CalcularBono(Personaje p)
        {
            if (p == null) return 0;
            if (p.Elemento == this.elementoFavorecido) return this.bonoAtaque;
            if (p.Elemento == this.elementoPenalizado) return -this.bonoAtaque;
            return 0;
        }

        // Evento Algorítmico Terremoto (Guía 2.5 y Enunciado 6):
        // Mecánica de Empatía: Si la empatía efectiva es >= 75 (umbral), se invierte en curación y escudo proporcional.
        // Si es menor, sacude el tablero destruyendo/reduciendo escudos e infligiendo daño sísmico porcentual a la vida.
        public string AplicarTerremoto(Personaje p)
        {
            if (p == null || !p.EstaVivo()) return "";

            // Polimorfismo: la empatía efectiva se resuelve en cada subclase sin if/else (ej. Tierra obtiene +10)
            int empatiaEfectiva = p.ObtenerEmpatiaTerremoto();

            if (empatiaEfectiva >= 75)
            {
                // Inversión proporcional del impacto del cataclismo
                int curacion = (int)Math.Round(empatiaEfectiva * 0.12);
                int escudoExtra = (int)Math.Round(empatiaEfectiva * 0.10);
                p.Vida += curacion;
                p.Defensa += escudoExtra;

                return "¡Terremoto en " + p.Nombre + " (Empatía efectiva " + empatiaEfectiva + ")! " +
                       "¡Efecto invertido! Se regenera +" + curacion + " HP y refuerza coraza +" + escudoExtra + " DEF.";
            }
            else
            {
                int reduccionEscudo = Math.Min(p.Defensa, 12);
                p.Defensa -= reduccionEscudo;

                // Daño sísmico porcentual al total de vida máxima
                int danioPorcentual = Math.Max(4, (int)Math.Round(p.VidaMaxima * 0.12));
                p.Vida -= danioPorcentual;

                return "¡Terremoto en " + p.Nombre + " (Empatía " + empatiaEfectiva + ")! " +
                       "Sufre daño sísmico: -" + reduccionEscudo + " DEF (ruptura de escudo) y -" + danioPorcentual + " HP (daño porcentual).";
            }
        }

        public override string ToString()
        {
            return this.nombre + " (+" + this.elementoFavorecido + " / -" + this.elementoPenalizado + ")";
        }
    }
}