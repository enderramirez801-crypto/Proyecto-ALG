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
            get { return descripcion; }
            set { descripcion = value; }
        }

        public string RegionOrigen
        {
            get { return regionOrigen; }
            set { regionOrigen = value; }
        }

        public string NombreHabilidad
        {
            get { return nombreHabilidad; }
            set { nombreHabilidad = value; }
        }

        public string Lore
        {
            get { return lore; }
            set { lore = value; }
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
            return this.nombre + " realiza un ataque contra " + oponente.Nombre + "!";
        }

        // Método virtual para defenderse e incrementar el escudo
        public virtual string Defender()
        {
            this.Defensa += 10;
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