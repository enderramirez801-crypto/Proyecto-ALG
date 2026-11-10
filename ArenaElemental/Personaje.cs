/*
 * Created by SharpDevelop.
 * User: Ender
 * Date: 4/11/2026
 * Time: 6:30 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ArenaElemental
{
    // Estructura de transferencia para registrar el desglose del daño y mitigación
    public class ResultadoDanio
    {
        public int DanioTotal { get; set; }
        public int DanioMitigadoPorEscudo { get; set; }
        public int DanioDirectoVida { get; set; }
        public int VidaRestante { get; set; }
        public int EscudoRestante { get; set; }
    }

    public abstract class Personaje
    {
        // 1. Atributos privados (Encapsulamiento estricto)
        private string nombre;
        private string elemento;
        private int vida;           // Ej: 50
        private int vidaMaxima;
        private int defensa;        // Ej: 30
        private int ataque;         // Ej: 20 (HP + DEF + ATK = 100)
        private int energia;        // Recurso para acciones
        private int empatia;        // Atributo para interacción con el evento Terremoto
        private int cargaEspecial;  // Barra de 0 a 100%
        private string rutaImagen;  // Ruta de la imagen de la carta
        private string descripcion; // Descripción del personaje elemental
        private string regionOrigen;    // Lugar o región de donde proviene el Pokémon
        private string nombreHabilidad; // Nombre de su habilidad especial
        private string lore;            // Historia y trasfondo (Lore) del Pokémon

        // 2. Propiedades públicas (Getters y Setters con validación de rangos)
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Elemento
        {
            get { return elemento; }
            set { elemento = value; }
        }

        public int VidaMaxima
        {
            get { return vidaMaxima; }
            set { vidaMaxima = value; }
        }

        public int Vida
        {
            get { return vida; }
            set
            {
                // Aseguramos que la vida no sea negativa ni sobrepase el máximo
                if (value < 0) vida = 0;
                else if (value > vidaMaxima) vida = vidaMaxima;
                else vida = value;
            }
        }

        public int Defensa
        {
            get { return defensa; }
            set
            {
                // Validamos que el escudo no sea negativo ni pase del tope de 60
                if (value < 0) defensa = 0;
                else if (value > 60) defensa = 60;
                else defensa = value;
            }
        }

        public int Ataque
        {
            get { return ataque; }
            set
            {
                if (value < 1) ataque = 1;
                else ataque = value;
            }
        }

        public int Energia
        {
            get { return energia; }
            set
            {
                if (value < 0) energia = 0;
                else if (value > 10) energia = 10;
                else energia = value;
            }
        }

        public int Empatia
        {
            get { return empatia; }
            set
            {
                if (value < 0) empatia = 0;
                else if (value > 100) empatia = 100;
                else empatia = value;
            }
        }

        public int CargaEspecial
        {
            get { return cargaEspecial; }
            set
            {
                if (value < 0) cargaEspecial = 0;
                else if (value > 100) cargaEspecial = 100;
                else cargaEspecial = value;
            }
        }

        public string RutaImagen
        {
            get { return rutaImagen; }
            set { rutaImagen = value; }
        }

        public string Descripcion
        {
            get { return Program.IdiomaIngles ? ObtenerDescripcionIngles() : descripcion; }
            set { descripcion = value; }
        }

        public string RegionOrigen
        {
            get { return Program.IdiomaIngles ? ObtenerRegionIngles() : regionOrigen; }
            set { regionOrigen = value; }
        }

        public string NombreHabilidad
        {
            get { return Program.IdiomaIngles ? ObtenerHabilidadIngles() : nombreHabilidad; }
            set { nombreHabilidad = value; }
        }

        public string Lore
        {
            get { return Program.IdiomaIngles ? ObtenerLoreIngles() : lore; }
            set { lore = value; }
        }

        private string ObtenerRegionIngles()
        {
            if (nombre == "Groudon") return "Tectonic Abysses of Rocky Canyon (Hoenn Region)";
            if (nombre == "Golem") return "Granite Peaks of Rocky Canyon (Mt. Moon / Kanto)";
            if (nombre == "Tyranitar") return "Armored Mountain Range of Rocky Canyon (Mt. Silver / Johto)";
            if (nombre == "Blastoise") return "Springs and Coasts of Cascade Stadium (Cerulean City / Kanto)";
            if (nombre == "Gyarados") return "Abyssal Trenches of Cascade Stadium (Lake of Rage / Kanto-Johto)";
            if (nombre == "Vaporeon") return "Crystal Bays of Cascade Stadium (Kanto)";
            if (nombre == "Charizard") return "Main Crater of Cinnabar Volcano (Charicific Valley / Cinnabar Island)";
            if (nombre == "Arcanine") return "Geothermal Plains of Cinnabar Volcano (Kanto)";
            if (nombre == "Moltres") return "Sacred Caldera of Cinnabar Volcano (Mt. Ember / Sevii Islands)";
            if (nombre == "Rayquaza") return "Stratospheric Peak of Sky Tower (Ozone Layer / Hoenn)";
            if (nombre == "Pidgeot") return "High-Altitude Currents of Sky Tower (Viridian Forest / Kanto)";
            if (nombre == "Lugia") return "Storm Sanctuary of Sky Tower (Whirl Islands / Johto)";
            return "Elemental Territory of " + Program.TraducirElemento(elemento);
        }

        private string ObtenerHabilidadIngles()
        {
            if (nombre == "Groudon") return "Precipice Blades";
            if (nombre == "Golem") return "Stone Edge";
            if (nombre == "Tyranitar") return "Seismic Rock Slide";
            if (nombre == "Blastoise") return "Draining Hydro Pump";
            if (nombre == "Gyarados") return "Healing Aqua Tail";
            if (nombre == "Vaporeon") return "Acid Armor Tide";
            if (nombre == "Charizard") return "Blast Burn";
            if (nombre == "Arcanine") return "Flare Blitz";
            if (nombre == "Moltres") return "Solar Fire Blast";
            if (nombre == "Rayquaza") return "Dragon Ascent";
            if (nombre == "Pidgeot") return "Sky Hurricane";
            if (nombre == "Lugia") return "Aeroblast";
            return "Special Skill of " + Program.TraducirElemento(elemento);
        }

        private string ObtenerDescripcionIngles()
        {
            if (nombre == "Groudon") return "Continental titan that reverses earthquakes into healing.";
            if (nombre == "Golem") return "Pure rock shell with the highest defense in the arena.";
            if (nombre == "Tyranitar") return "Armored colossus capable of shattering mountains and rival shields.";
            if (nombre == "Blastoise") return "Water Pokémon with hydraulic cannons that restores HP and drains energy.";
            if (nombre == "Gyarados") return "Sea colossus of immense vitality and elemental empathy.";
            if (nombre == "Vaporeon") return "Aquatic evolution that merges with water to endure and counterattack.";
            if (nombre == "Charizard") return "Fire dragon whose flames melt any rock or shield.";
            if (nombre == "Arcanine") return "Swift legendary Pokémon with a high-impact blazing attack.";
            if (nombre == "Moltres") return "Legendary fire bird that inflicts direct burn damage.";
            if (nombre == "Rayquaza") return "Sky guardian whose attacks pierce right through the rival shield.";
            if (nombre == "Pidgeot") return "Wind master that steals energy with supersonic gusts.";
            if (nombre == "Lugia") return "Guardian of storms with a devastating aerial strike.";
            return "Elemental fighter of " + Program.TraducirElemento(elemento);
        }

        private string ObtenerLoreIngles()
        {
            if (nombre == "Groudon")
                return "Originating from the deepest magma chambers and tectonic faults beneath Rocky Canyon. " +
                       "According to Elemental Arena legends, Groudon emerged in ancient times to raise the continents " +
                       "and evaporate the seas with its geothermal heat. Its heavy continental rock armor and high Empathy " +
                       "(85 EMP, rising to 95 in Earthquakes) make the earth itself recognize it as its lord, transforming " +
                       "any arena tremor into vital energy (+8 HP and +8 DEF).";
            if (nombre == "Golem")
                return "Comes from the steep slopes and mineral craters of upper Rocky Canyon. Its spherical body is " +
                       "armored by tectonic rock plates so dense that not even dynamite can crack them, granting it the " +
                       "highest base Defense in the entire catalog (35 DEF). Once a year it sheds its stone shell in the " +
                       "canyon caves and rolls down the mountains at extreme speed, creating natural stone trenches to protect its team.";
            if (nombre == "Tyranitar")
                return "Born in the heart of the most unforgiving mountain ranges of Rocky Canyon, where it grew feeding " +
                       "on mineral veins and entire mountains. Its armored hide is immune to almost any ordinary impact, " +
                       "and its territorial temper triggers landslides that force mapmakers to redraw the region. In the " +
                       "Elemental Arena it uses that seismic power to shatter the opponent's shield (-10 DEF) while reinforcing its own rock wall.";
            if (nombre == "Blastoise")
                return "Originating from the sacred reefs and waterfalls of Cascade Stadium. Its heavy blue shell houses " +
                       "two hydrodynamic cannons capable of firing pressurized water jets with such precision that they pierce " +
                       "steel plates from over fifty meters away. To withstand the recoil, Blastoise firmly anchors its feet " +
                       "into the riverbed, giving it high Empathy (78 EMP) to resist tremors and heal while draining rival energy.";
            if (nombre == "Gyarados")
                return "Born in the deepest and most turbulent currents beneath the waterfalls of Cascade Stadium, after " +
                       "overcoming the harsh metamorphosis of swimming upstream against the torrent. Ancient scrolls tell that " +
                       "it emerges when the seas rage, displaying colossal vitality (55 HP) and an instinctive sensitivity to " +
                       "earth and sea vibrations (82 EMP), allowing it to turn submarine earthquakes into regenerative waves.";
            if (nombre == "Vaporeon")
                return "Comes from the crystal lagoons and serene beaches that feed Cascade Stadium. Its cellular structure " +
                       "evolved to become identical to pure water molecules, allowing it to dissolve into the current to evade " +
                       "impacts and regenerate health (+4 HP every time it raises its water shield). Its fins vibrate whenever " +
                       "a storm or a shift in the battle's energy flow approaches.";
            if (nombre == "Charizard")
                return "Originating from the volcanic peaks and lava calderas of Cinnabar Volcano. It soars through the skies " +
                       "in search of powerful opponents, and its inner fire burns at even higher temperatures the tougher the " +
                       "battles it has fought. It holds the highest base Attack in the entire Elemental Arena (40 ATK), capable " +
                       "of melting glaciers and shields in a single fiery breath.";
            if (nombre == "Arcanine")
                return "Born in the basalt plains surrounding the slopes of Cinnabar Volcano and revered since antiquity in " +
                       "ancestral carvings. An inexhaustible flame burns within its chest, allowing it to run ten thousand " +
                       "kilometers in a single day as if flying over the ground. Thanks to its firm bond with volcanic earth, " +
                       "it is the only Fire faction member to reach 75 Empathy, turning earthquakes into vitality and defense.";
            if (nombre == "Moltres")
                return "Legendary elemental bird dwelling in the living magma heart of Cinnabar Volcano. When wounded in battle, " +
                       "it plunges directly into the molten lava crater to regenerate its body and rise anew from glowing ashes. " +
                       "Every beat of its solar wings releases a shower of embers that lights up the night and consumes rivals with direct burns.";
            if (nombre == "Rayquaza")
                return "Originating from the ozone layer crowning the mythical Sky Tower, where it has lived for millions of " +
                       "years without touching solid ground, feeding on atmospheric vapor and meteorite particles. According to " +
                       "ancient chronicles, when continental and marine titans unleash cataclysms, Rayquaza descends from the sky " +
                       "like an emerald lightning bolt, piercing any defensive shield with supersonic speed.";
            if (nombre == "Pidgeot")
                return "Comes from the windy lookouts and elevated forests surrounding Sky Tower. It spreads its majestic wings " +
                       "to catch thermal currents and reach Mach 2 speeds, spotting any movement from over a thousand meters high. " +
                       "Its strong harmony with nature (80 EMP) allows it to anticipate ground earthquakes and channel them in its " +
                       "favor while its gales strip energy from the enemy.";
            if (nombre == "Lugia")
                return "Known as the guardian of the stormy skies connecting the clouds of Sky Tower with the deep oceans. " +
                       "The aerodynamic power of its wings is so overwhelming that a single wingbeat can tear down cliffs and " +
                       "unleash forty-day hurricanes. In the Elemental Arena it focuses that atmospheric pressure into a pure air " +
                       "projectile (35 ATK) that completely ignores rival armor.";
            return "Elemental creature belonging to the " + Program.TraducirElemento(elemento) + " faction.";
        }

        // 3. Constructores Parametrizados de la Clase Padre (evitan duplicación en clases hijas)
        public Personaje(string nombre, string elemento, int vida, int defensa, int ataque, int energia, int empatia)
        {
            // Balance de 100 puntos (Vida + Defensa + ATK = 100)
            if (vida + defensa + ataque != 100)
            {
                vida = 100 - (defensa + ataque);
            }

            this.nombre = nombre;
            this.elemento = elemento;
            this.vidaMaxima = vida;
            this.vida = vida;
            this.defensa = defensa;
            this.ataque = ataque;
            this.energia = energia;
            this.empatia = empatia;
            this.cargaEspecial = 0;
            this.rutaImagen = nombre + ".png";
            this.descripcion = "Personaje elemental de " + elemento;
            this.regionOrigen = "Territorio Elemental de " + elemento;
            this.nombreHabilidad = "Habilidad Especial de " + elemento;
            this.lore = "Criatura elemental perteneciente a la facción de " + elemento + ".";
        }

        public Personaje(string nombre, string elemento, int vida, int defensa, int ataque, int energia)
            : this(nombre, elemento, vida, defensa, ataque, energia, 70)
        {
        }

        // 4. Métodos abstractos y virtuales (Polimorfismo Puro)

        // Cada subclase define su propia superioridad elemental mediante override
        public abstract double CalcularMultiplicadorElemental(string elementoRival);

        // =========================================================================
        // MODELO MATEMÁTICO NO LINEAL (INTEGRACIÓN CON ASIGNATURA DE CÁLCULO)
        // Función matemática logarítmica cóncava suave para amortiguación y escalado de daño:
        // f_noLineal = 1.0 + ln(1 + (Empatia / 100.0) * 0.30)
        // Daño Neto Base = ((Ataque * MultiplicadorElemental) + BonoEscenario) * f_noLineal
        // =========================================================================
        public virtual int CalcularDanio(Personaje oponente, int bonoEscenario)
        {
            double multiplicador = CalcularMultiplicadorElemental(oponente.Elemento);
            double factorCalculoNoLineal = 1.0 + Math.Log(1.0 + (this.empatia / 100.0) * 0.30);
            double calculo = ((this.ataque * multiplicador) + bonoEscenario) * factorCalculoNoLineal;
            int danioFinal = (int)Math.Round(calculo);

            if (danioFinal < 2) danioFinal = 2;
            return danioFinal;
        }

        // Resolución del daño: el escudo absorbe primero; el exceso resta directamente vida
        // Retorna un objeto ResultadoDanio con el desglose exacto de daño y mitigación para la bitácora
        public virtual ResultadoDanio RecibirDanio(int danio)
        {
            ResultadoDanio resultado = new ResultadoDanio();
            resultado.DanioTotal = danio;

            if (this.defensa > 0)
            {
                if (this.defensa >= danio)
                {
                    resultado.DanioMitigadoPorEscudo = danio;
                    resultado.DanioDirectoVida = 0;
                    this.Defensa -= danio;
                }
                else
                {
                    int restante = danio - this.defensa;
                    resultado.DanioMitigadoPorEscudo = this.defensa;
                    resultado.DanioDirectoVida = restante;
                    this.Defensa = 0;
                    this.Vida -= restante;
                }
            }
            else
            {
                resultado.DanioMitigadoPorEscudo = 0;
                resultado.DanioDirectoVida = danio;
                this.Vida -= danio;
            }

            resultado.VidaRestante = this.Vida;
            resultado.EscudoRestante = this.Defensa;
            return resultado;
        }

        public virtual string EjecutarAccionCombate(Personaje oponente)
        {
            if (Program.IdiomaIngles)
                return this.nombre + " performs an attack against " + oponente.Nombre + "!";
            return this.nombre + " realiza un ataque contra " + oponente.Nombre + "!";
        }

        // Método virtual para defenderse e incrementar el escudo
        public virtual string Defender()
        {
            this.Defensa += 10;
            if (Program.IdiomaIngles)
                return this.nombre + " defends and raises shield to " + this.defensa + " DEF.";
            return this.nombre + " se defiende y sube su escudo a " + this.defensa + " DEF.";
        }

        // Habilidad especial polimórfica implementada en cada subclase elemental
        public abstract string UsarHabilidadEspecial(Personaje oponente);

        // Efecto secundario polimórfico opcional sobre jugadores (ej: robar energía en Agua y Aire)
        public virtual void AplicarEfectoSecundarioEspecial(Jugador lanzador, Jugador rival)
        {
            // Comportamiento base sin efectos sobre la reserva de energía
        }

        // Empatía efectiva calculada polimórficamente para eventos ambientales (Terremoto)
        public virtual int ObtenerEmpatiaTerremoto()
        {
            return this.empatia;
        }

        // Prototipo de clonación profunda
        public abstract Personaje Clonar();

        // Copia los metadatos de historia a una instancia clonada
        protected void CopiarDatosLore(Personaje destino)
        {
            if (destino == null) return;
            destino.Descripcion = this.descripcion;
            destino.RegionOrigen = this.regionOrigen;
            destino.NombreHabilidad = this.nombreHabilidad;
            destino.Lore = this.lore;
        }

        // Información de facción elemental polimórfica
        public abstract string ObtenerLoreFaccion();

        // Devuelve el nombre del escenario natal de la facción (Polimórfico)
        public abstract string ObtenerArenaNatal();

        // Devuelve la explicación de ventaja y desventaja elemental (Polimórfico)
        public abstract string ObtenerResumenVentajaElemental();

        // Construye la ficha completa de Lore del Pokémon
        public virtual string ObtenerFichaLoreCompleta()
        {
            int empTerremoto = ObtenerEmpatiaTerremoto();
            string efectoTerremoto = (empTerremoto >= 75)
                ? "Invierte el Terremoto (Curación proporcional de HP y DEF)"
                : "Sufre daño sísmico porcentual a vida y ruptura de escudo";

            return "=== " + this.nombre.ToUpper() + " (" + this.elemento.ToUpper() + ") ===\r\n" +
                   "Origen / Región: " + this.regionOrigen + "\r\n" +
                   "Arena Natal: " + ObtenerArenaNatal() + " (+5 ATK de bono territorial)\r\n" +
                   "Habilidad Especial: " + this.nombreHabilidad + "\r\n" +
                   "Estadísticas Base (Suma=100): HP " + this.vidaMaxima + " | DEF " + this.defensa + " | ATK " + this.ataque + " | EMP " + this.empatia + "\r\n" +
                   "Reacción al Terremoto: " + efectoTerremoto + " (Empatía efectiva: " + empTerremoto + ")\r\n" +
                   "Dominio Elemental: " + ObtenerResumenVentajaElemental() + "\r\n\r\n" +
                   "--- HISTORIA Y LORE DE " + this.nombre.ToUpper() + " ---\r\n" +
                   this.lore + "\r\n\r\n" +
                   "--- ¿DE DÓNDE SON LOS POKÉMON DE " + this.elemento.ToUpper() + "? (LORE DE FACCIÓN) ---\r\n" +
                   ObtenerLoreFaccion();
        }

        public bool EstaVivo()
        {
            return this.vida > 0;
        }
    }
}