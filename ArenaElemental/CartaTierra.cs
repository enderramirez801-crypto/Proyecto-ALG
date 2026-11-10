/*
 * Created by SharpDevelop.
 * User: Ender
 * Date: 4/11/2026
 * Time: 6:35 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ArenaElemental
{
    public class CartaTierra : Personaje
    {
        public CartaTierra(string nombre, int vida, int defensa, int ataque, int energia, int empatia)
            : base(nombre, "Tierra", vida, defensa, ataque, energia, empatia)
        {
            ConfigurarLoreTierra(nombre);
        }

        public CartaTierra(string nombre, int energia)
            : base(nombre, "Tierra", 60, 30, 10, energia, 85)
        {
            ConfigurarLoreTierra(nombre);
        }

        private void ConfigurarLoreTierra(string nombre)
        {
            if (nombre == "Groudon")
            {
                this.RegionOrigen = "Abismos Tectónicos del Cañón Rocoso (Región Hoenn)";
                this.NombreHabilidad = "Filo del Abismo";
                this.Descripcion = "Titán continental que invierte los terremotos en curación.";
                this.Lore = "Originario de las cámaras magmáticas y fallas tectónicas más profundas bajo el Cañón Rocoso. " +
                            "Según las leyendas de la Arena Elemental, Groudon emergió en tiempos ancestrales para levantar " +
                            "los continentes y evaporar los mares con su calor geotérmico. Su pesada coraza de roca continental " +
                            "y su altísima Empatía (85 EMP, que sube a 95 en Terremotos) hacen que la tierra misma lo reconozca " +
                            "como su señor, transformando cualquier sismo del escenario en energía vital (+8 HP y +8 DEF).";
            }
            else if (nombre == "Golem")
            {
                this.RegionOrigen = "Cumbres Graníticas del Cañón Rocoso (Monte Moon / Kanto)";
                this.NombreHabilidad = "Roca Afilada";
                this.Descripcion = "Coraza de roca pura con la defensa más alta de la arena.";
                this.Lore = "Proviene de las laderas escarpadas y cráteres minerales de la parte alta del Cañón Rocoso. " +
                            "Su cuerpo esférico está blindado por placas de roca tectónica tan densas que ni la dinamita puede " +
                            "agrietarlas, otorgándole la Defensa base más alta de todo el catálogo (35 DEF). Una vez al año muda " +
                            "su caparazón pétreo en las cuevas del cañón y baja rodando a velocidad extrema por las montañas, " +
                            "creando trincheras naturales y muros de piedra para proteger a su equipo.";
            }
            else if (nombre == "Tyranitar")
            {
                this.RegionOrigen = "Cordillera Acorazada del Cañón Rocoso (Monte Plateado / Johto)";
                this.NombreHabilidad = "Avalancha Sísmica";
                this.Descripcion = "Coloso acorazado capaz de derribar montañas y escudos rivales.";
                this.Lore = "Nacido en el corazón de las cordilleras más implacables del Cañón Rocoso, donde creció alimentándose " +
                            "de vetas minerales y montañas enteras. Su piel acorazada es inmune a casi cualquier impacto ordinario " +
                            "y su temperamento territorial lo lleva a provocar derrumbes que obligan a redibujar los mapas de la región. " +
                            "En la Arena Elemental utiliza esa fuerza sísmica para quebrar el escudo del oponente (-10 DEF) mientras " +
                            "fortalece su propia muralla de roca.";
            }
            else
            {
                this.RegionOrigen = "Cordillera Central del Cañón Rocoso";
                this.NombreHabilidad = "Muro Sísmico";
                this.Descripcion = "Guardián pétreo de alta resistencia y empatía terrestre.";
                this.Lore = "Criatura forjada en los estratos minerales del Cañón Rocoso. Su vínculo con el suelo le permite " +
                            "levantar defensas de piedra y absorber la energía de los terremotos.";
            }
        }

        // Polimorfismo: Ventaja elemental de Tierra (Tierra contiene Agua, pero sufre erosión de Aire)
        public override double CalcularMultiplicadorElemental(string elementoRival)
        {
            if (elementoRival == "Agua") return 1.5;
            if (elementoRival == "Aire") return 0.75;
            return 1.0;
        }

        // Polimorfismo: Cálculo de daño especializado (Guía Requerimiento Técnico #1)
        public override int CalcularDanio(Personaje oponente, int bonoEscenario)
        {
            int baseDanio = base.CalcularDanio(oponente, bonoEscenario);
            // Pasiva de Tierra: impacto telúrico denso con bono de masa (+2 ATK)
            return baseDanio + 2;
        }

        public override string ObtenerArenaNatal()
        {
            return "Canon Rocoso";
        }

        public override string ObtenerResumenVentajaElemental()
        {
            return "Fuerte contra Agua (x1.5 daño) | Débil contra Aire (x0.75 daño) | Bono Terremoto: +10 Empatía y muro de +15 DEF al defenderse";
        }

        public override string ObtenerLoreFaccion()
        {
            return "Los Pokémon de Tierra (Groudon, Golem y Tyranitar) son originarios del imponente CAÑÓN ROCOSO, " +
                   "una región de cordilleras milenarias, fallas tectónicas y cavernas minerales donde la presión geológica " +
                   "forjó sus cuerpos acorazados. A diferencia de otras facciones, los habitantes de Tierra viven en perfecta " +
                   "armonía con las placas sísmicas: reciben una bonificación natural de +10 de Empatía durante los eventos de " +
                   "Terremoto, lo que les permite superar siempre el umbral de 75 de Empatía e invertir los cataclismos en " +
                   "curación (+8 HP y +8 DEF). En combate dominan al elemento Agua (x1.5 daño) al contener sus corrientes con " +
                   "diques de roca, pero sufren ante los ataques de Aire (x0.75 daño) que erosionan las cumbres desde el cielo.";
        }

        public override string EjecutarAccionCombate(Personaje oponente)
        {
            return this.Nombre + " (Tierra) fortifica su postura y embiste a " + oponente.Nombre + "!";
        }

        public override string Defender()
        {
            // Pasiva defensiva de Tierra: levantamiento de muralla pétrea superior (+15 DEF)
            this.Defensa += 15;
            return this.Nombre + " (Tierra) levanta un Muro de Granito (+15 DEF, Escudo actual: " + this.Defensa + ").";
        }

        public override string UsarHabilidadEspecial(Personaje oponente)
        {
            // Habilidad especial de Tierra: Quiebre de escudo rival y refuerzo propio
            int escudoRoto = Math.Min(oponente.Defensa, 10);
            oponente.Defensa -= escudoRoto;
            this.Defensa += 12;

            int danio = CalcularDanio(oponente, 8);
            ResultadoDanio res = oponente.RecibirDanio(danio);
            this.CargaEspecial = 0;

            return "¡Especial de Tierra! " + this.Nombre + " activa " + this.NombreHabilidad + " rompiendo " + escudoRoto +
                   " DEF a " + oponente.Nombre + ", reforzando su coraza (+12 DEF) y golpeando por " + danio +
                   " pts (" + res.DanioMitigadoPorEscudo + " mitigados, " + res.DanioDirectoVida + " a vida).";
        }

        // Pasiva polimórfica de Tierra: Comunión sísmica (+10 de empatía ante terremotos)
        public override int ObtenerEmpatiaTerremoto()
        {
            return this.Empatia + 10;
        }

        public override Personaje Clonar()
        {
            CartaTierra copia = new CartaTierra(this.Nombre, this.VidaMaxima, this.Defensa, this.Ataque, this.Energia, this.Empatia);
            CopiarDatosLore(copia);
            return copia;
        }
    }
}