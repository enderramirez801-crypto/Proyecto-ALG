/*
 * Created by SharpDevelop.
 * User: Ender
 * Date: 4/11/2026
 * Time: 6:36 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ArenaElemental
{
    public class CartaAire : Personaje
    {
        public CartaAire(string nombre, int vida, int defensa, int ataque, int energia, int empatia)
            : base(nombre, "Aire", vida, defensa, ataque, energia, empatia)
        {
            ConfigurarLoreAire(nombre);
        }

        public CartaAire(string nombre, int energia)
            : base(nombre, "Aire", 45, 25, 30, energia, 75)
        {
            ConfigurarLoreAire(nombre);
        }

        private void ConfigurarLoreAire(string nombre)
        {
            if (nombre == "Rayquaza")
            {
                this.RegionOrigen = "Cúspide Estratosférica de la Torre Celeste (Capa de Ozono / Hoenn)";
                this.NombreHabilidad = "Ascenso Draco";
                this.Descripcion = "Guardián de los cielos cuyos ataques perforan el escudo rival.";
                this.Lore = "Originario de la capa de ozono que corona la mítica Torre Celeste, donde ha vivido durante millones " +
                            "de años sin tocar tierra firme, alimentándose de vapor atmosférico y partículas de meteoritos. " +
                            "Según las crónicas antiguas, cuando los titanes continentales y marinos desatan cataclismos, Rayquaza " +
                            "desciende desde el cielo como un relámpago esmeralda, atravesando cualquier escudo defensivo con su " +
                            "velocidad supersónica.";
            }
            else if (nombre == "Pidgeot")
            {
                this.RegionOrigen = "Corrientes de Altitud de la Torre Celeste (Bosque Verde / Kanto)";
                this.NombreHabilidad = "Vendaval Celeste";
                this.Descripcion = "Maestro del viento que roba energía con ráfagas supersónicas.";
                this.Lore = "Proviene de los miradores ventosos y bosques elevados que rodean la Torre Celeste. Extiende sus " +
                            "majestuosas alas para atrapar las corrientes térmicas y alcanzar velocidades de Mach 2, divisando " +
                            "cualquier movimiento a más de mil metros de altura. Su gran sintonía con el entorno natural (80 EMP) " +
                            "le permite anticipar los terremotos del suelo y canalizarlos a su favor, mientras sus vendavales " +
                            "despojan de energía al enemigo.";
            }
            else if (nombre == "Lugia")
            {
                this.RegionOrigen = "Santuario de las Tormentas de la Torre Celeste (Islas Remolino / Johto)";
                this.NombreHabilidad = "Aerochorro";
                this.Descripcion = "Guardián de las tormentas con ataque aéreo devastador.";
                this.Lore = "Conocido como el guardián de los cielos tormentosos que conectan las nubes de la Torre Celeste con " +
                            "los océanos profundos. La potencia aerodinámica de sus alas es tan sobrecogedora que un simple " +
                            "aleteo suyo puede derribar acantilados y desatar huracanes de cuarenta días. En la Arena Elemental " +
                            "concentra esa presión atmosférica en un proyectil de aire puro (35 ATK) que ignora la armadura rival.";
            }
            else
            {
                this.RegionOrigen = "Cumbres Nubosas de la Torre Celeste";
                this.NombreHabilidad = "Ráfaga Perforante";
                this.Descripcion = "Combatiente celeste de gran velocidad y daño perforante.";
                this.Lore = "Criatura nacida en las alturas de la Torre Celeste, capaz de dominar los vientos supersónicos.";
            }
        }

        // Polimorfismo: Ventaja elemental de Aire (Aire erosiona Tierra, pero cede ante Fuego)
        public override double CalcularMultiplicadorElemental(string elementoRival)
        {
            if (elementoRival == "Tierra") return 1.5;
            if (elementoRival == "Fuego") return 0.75;
            return 1.0;
        }

        // Polimorfismo: Cálculo de daño especializado (Guía Requerimiento Técnico #1)
        public override int CalcularDanio(Personaje oponente, int bonoEscenario)
        {
            int baseDanio = base.CalcularDanio(oponente, bonoEscenario);
            // Pasiva de Aire: velocidad y corte aerodinámico (+3 de penetración cinética)
            return baseDanio + 3;
        }

        public override string ObtenerArenaNatal()
        {
            return "Torre Celeste";
        }

        public override string ObtenerResumenVentajaElemental()
        {
            return "Fuerte contra Tierra (x1.5 daño) | Débil contra Fuego (x0.75 daño) | Especial: Daño perforante directo a la vida y roba 1 ENER";
        }

        public override string ObtenerLoreFaccion()
        {
            return "Los Pokémon de Aire (Rayquaza, Pidgeot y Lugia) son originarios de la TORRE CELESTE, una ancestral " +
                   "atalaya que se eleva por encima de las nubes hasta rozar la estratósfera. Dueños absolutos de las corrientes " +
                   "de viento y las tormentas de altitud, ningún muro físico puede detener su avance: su habilidad especial " +
                   "perfora por completo el escudo del oponente causando daño directo a sus puntos de vida (HP) y robándole 1 " +
                   "punto de energía. Gracias a su dominio de las alturas superan a la facción de Tierra (x1.5 daño), pero son " +
                   "vulnerables a las tormentas ígneas de Fuego (x0.75 daño).";
        }

        public override string EjecutarAccionCombate(Personaje oponente)
        {
            return this.Nombre + " (Aire) invoca una cuchilla de viento supersónica contra " + oponente.Nombre + "!";
        }

        public override string UsarHabilidadEspecial(Personaje oponente)
        {
            // Habilidad especial de Aire: daño perforante directo a la vida ignorando completamente el escudo (DEF)
            int danioDirecto = CalcularDanio(oponente, 5);
            oponente.Vida -= danioDirecto;
            this.CargaEspecial = 0;

            return "¡Especial de Aire! " + this.Nombre + " ejecuta " + this.NombreHabilidad + " atravesando el escudo de " +
                   oponente.Nombre + ", propinando " + danioDirecto + " HP directos a su vida y robando 1 de energía.";
        }

        // Efecto secundario polimórfico: roba 1 de energía al oponente
        public override void AplicarEfectoSecundarioEspecial(Jugador lanzador, Jugador rival)
        {
            if (rival != null && rival.Energia > 0)
            {
                rival.Energia -= 1;
                if (lanzador != null) lanzador.Energia += 1;
            }
        }

        public override Personaje Clonar()
        {
            CartaAire copia = new CartaAire(this.Nombre, this.VidaMaxima, this.Defensa, this.Ataque, this.Energia, this.Empatia);
            CopiarDatosLore(copia);
            return copia;
        }
    }
}