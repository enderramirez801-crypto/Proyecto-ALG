/*
 * Created by SharpDevelop.
 * User: Ender
 * Date: 4/11/2026
 * Time: 6:32 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ArenaElemental
{
    public class CartaAgua : Personaje
    {
        public CartaAgua(string nombre, int vida, int defensa, int ataque, int energia, int empatia)
            : base(nombre, "Agua", vida, defensa, ataque, energia, empatia)
        {
            ConfigurarLoreAgua(nombre);
        }

        public CartaAgua(string nombre, int energia)
            : base(nombre, "Agua", 50, 30, 20, energia, 80)
        {
            ConfigurarLoreAgua(nombre);
        }

        private void ConfigurarLoreAgua(string nombre)
        {
            if (nombre == "Blastoise")
            {
                this.RegionOrigen = "Manantiales y Costas del Estadio Cascada (Ciudad Celeste / Kanto)";
                this.NombreHabilidad = "Hidrobomba Drenadora";
                this.Descripcion = "Pokémon de agua con cañones hidráulicos que restaura vida y drena energía.";
                this.Lore = "Originario de los arrecifes y cataratas sagradas del Estadio Cascada. Su pesado caparazón azulado " +
                            "alberga dos cañones hidrodinámicos capaces de disparar chorros de agua presurizada con tal precisión que " +
                            "perforan planchas de acero a más de cincuenta metros. Para soportar el retroceso de sus disparos, " +
                            "Blastoise ancla firmemente sus patas en el lecho acuático, lo que le otorga una alta Empatía (78 EMP) " +
                            "para resistir temblores y usar la fuerza del agua para curarse mientras drena la energía rival.";
            }
            else if (nombre == "Gyarados")
            {
                this.RegionOrigen = "Fosas Abisales del Estadio Cascada (Lago de la Furia / Kanto-Johto)";
                this.NombreHabilidad = "Acua Cola Curativa";
                this.Descripcion = "Coloso de los mares de gran vitalidad y empatía elemental.";
                this.Lore = "Nacido en las corrientes más profundas y turbulentas bajo las cataratas del Estadio Cascada, tras " +
                            "superar la dura metamorfosis de remontar el torrente contra la corriente. Antiguos pergaminos relatan " +
                            "que emerge cuando los mares se embravecen, desplegando una vitalidad colosal (55 HP) y una sensibilidad " +
                            "instintiva hacia las vibraciones de la tierra y el mar (82 EMP), permitiéndole transformar incluso los " +
                            "terremotos submarinos en oleadas regenerativas.";
            }
            else if (nombre == "Vaporeon")
            {
                this.RegionOrigen = "Bahías Cristalinas del Estadio Cascada (Kanto)";
                this.NombreHabilidad = "Marea Ácida";
                this.Descripcion = "Evolución acuática que se funde con el agua para resistir y contraatacar.";
                this.Lore = "Proviene de las lagunas cristalinas y playas serenas que alimentan el Estadio Cascada. Su estructura " +
                            "celular evolucionó hasta volverse idéntica a las moléculas de agua pura, permitiéndole disolverse en " +
                            "la corriente para esquivar impactos y regenerar su salud (+4 HP cada vez que levanta su escudo de agua). " +
                            "Sus aletas vibran cuando se aproxima una tormenta o un cambio en el flujo energético del combate.";
            }
            else
            {
                this.RegionOrigen = "Cuenca Hidrográfica del Estadio Cascada";
                this.NombreHabilidad = "Marea Drenadora";
                this.Descripcion = "Guardián acuático capaz de sanar con el flujo de las mareas.";
                this.Lore = "Criatura nacida en los manantiales del Estadio Cascada, maestra en el control de corrientes curativas.";
            }
        }

        // Polimorfismo: Ventaja elemental de Agua (Agua apaga Fuego, pero es contenida por Tierra)
        public override double CalcularMultiplicadorElemental(string elementoRival)
        {
            if (elementoRival == "Fuego") return 1.5;
            if (elementoRival == "Tierra") return 0.75;
            return 1.0;
        }

        // Polimorfismo: Cálculo de daño especializado (Guía Requerimiento Técnico #1)
        public override int CalcularDanio(Personaje oponente, int bonoEscenario)
        {
            int baseDanio = base.CalcularDanio(oponente, bonoEscenario);
            // Pasiva de Agua: flujo hidrodinámico adaptativo continuo (+1 de daño fluido constante)
            return baseDanio + 1;
        }

        public override string ObtenerArenaNatal()
        {
            return "Estadio Cascada";
        }

        public override string ObtenerResumenVentajaElemental()
        {
            return "Fuerte contra Fuego (x1.5 daño) | Débil contra Tierra (x0.75 daño) | Defensa: +4 HP extra y Especial: drena 1 ENER y cura +12 HP";
        }

        public override string ObtenerLoreFaccion()
        {
            return "Los Pokémon de Agua (Blastoise, Gyarados y Vaporeon) provienen del ESTADIO CASCADA, un santuario natural " +
                   "formado por cataratas gigantes, fosas abisales y manantiales cristalinos. Criados en el flujo incesante de " +
                   "las mareas, su filosofía de combate se basa en la adaptación y la vitalidad continua: al defenderse no solo " +
                   "levantan un escudo líquido (+10 DEF), sino que también restauran su propia salud (+4 HP), y su habilidad " +
                   "especial drena 1 punto de energía al rival además de curar +12 HP. En la rueda elemental apagan sin esfuerzo " +
                   "a la facción de Fuego (x1.5 daño), pero ven frenado su avance frente a las murallas de Tierra (x0.75 daño).";
        }

        public override string EjecutarAccionCombate(Personaje oponente)
        {
            return this.Nombre + " (Agua) lanza un torrente presurizado contra " + oponente.Nombre + "!";
        }

        public override string Defender()
        {
            // Pasiva defensiva de Agua: regenera salud biológica al condensar el escudo
            this.Defensa += 10;
            this.Vida += 4;
            return this.Nombre + " (Agua) crea una barrera de agua (+10 DEF y +4 HP regenerados).";
        }

        public override string UsarHabilidadEspecial(Personaje oponente)
        {
            // Habilidad especial de Agua: Marea Curativa y Drenadora
            int danio = CalcularDanio(oponente, 4);
            ResultadoDanio res = oponente.RecibirDanio(danio);
            this.Vida += 12; // Regeneración biológica del usuario
            this.CargaEspecial = 0;

            return "¡Especial de Agua! " + this.Nombre + " desata " + this.NombreHabilidad + " contra " + oponente.Nombre +
                   " (" + danio + " pts: " + res.DanioMitigadoPorEscudo + " mitigados, " + res.DanioDirectoVida + " a vida), se regenera +12 HP y drena 1 de energía.";
        }

        // Efecto secundario polimórfico: roba 1 de energía al adversario
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
            CartaAgua copia = new CartaAgua(this.Nombre, this.VidaMaxima, this.Defensa, this.Ataque, this.Energia, this.Empatia);
            CopiarDatosLore(copia);
            return copia;
        }
    }
}