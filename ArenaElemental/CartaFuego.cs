/*
 * Created by SharpDevelop.
 * User: Ender
 * Date: 4/11/2026
 * Time: 6:34 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ArenaElemental
{
    public class CartaFuego : Personaje
    {
        public CartaFuego(string nombre, int vida, int defensa, int ataque, int energia, int empatia)
            : base(nombre, "Fuego", vida, defensa, ataque, energia, empatia)
        {
            ConfigurarLoreFuego(nombre);
        }

        public CartaFuego(string nombre, int energia)
            : base(nombre, "Fuego", 40, 20, 40, energia, 60)
        {
            ConfigurarLoreFuego(nombre);
        }

        private void ConfigurarLoreFuego(string nombre)
        {
            if (nombre == "Charizard")
            {
                this.RegionOrigen = "Cráter Principal del Volcán Cinnabar (Valle Charirrífico / Isla Canela)";
                this.NombreHabilidad = "Anillo Ígneo";
                this.Descripcion = "Dragón de fuego cuyas llamas funden cualquier roca o escudo.";
                this.Lore = "Originario de las cumbres volcánicas y calderas de lava del Volcán Cinnabar. Surca los cielos " +
                            "en busca de adversarios poderosos, y su fuego interior arde a temperaturas aún más altas cuanto más " +
                            "duras son las batallas que ha librado. Posee el Ataque base más alto de toda la Arena Elemental (40 ATK), " +
                            "capaz de derretir glaciares y escudos de un solo aliento ígneo, aunque por su orgullo de guerrero nunca " +
                            "usa sus llamas contra un oponente más débil.";
            }
            else if (nombre == "Arcanine")
            {
                this.RegionOrigen = "Llanuras Geotérmicas del Volcán Cinnabar (Kanto)";
                this.NombreHabilidad = "Envite Ígneo";
                this.Descripcion = "Pokémon legendario veloz con ataque ardiente de alto impacto.";
                this.Lore = "Nacido en las tierras basálticas que rodean las faldas del Volcán Cinnabar y venerado desde la " +
                            "antigüedad en grabados ancestrales. En su pecho arde una llama inagotable que le permite recorrer " +
                            "diez mil kilómetros en un solo día como si volara sobre el suelo. Gracias a su conexión firme con la " +
                            "tierra volcánica, es el único miembro de la facción de Fuego que alcanza 75 de Empatía, logrando " +
                            "convertir los terremotos en vitalidad y defensa.";
            }
            else if (nombre == "Moltres")
            {
                this.RegionOrigen = "Caldera Sagrada del Volcán Cinnabar (Monte Ascuas / Islas Sete)";
                this.NombreHabilidad = "Llamarada Solar";
                this.Descripcion = "Ave legendaria del fuego que causa quemaduras directas.";
                this.Lore = "Legendaria ave elemental que habita en el corazón de magma vivo del Volcán Cinnabar. Cuando sufre " +
                            "heridas en combate, se sumerge directamente en el cráter de lava fundida para regenerar su cuerpo y " +
                            "renacer entre cenizas incandescentes. Cada batir de sus alas solares desprende una lluvia de brasas " +
                            "que ilumina la noche y consume la resistencia de sus rivales con quemaduras directas.";
            }
            else
            {
                this.RegionOrigen = "Caldera Interior del Volcán Cinnabar";
                this.NombreHabilidad = "Impacto Meteórico";
                this.Descripcion = "Espíritu ígneo de ataque ofensivo abrasador.";
                this.Lore = "Criatura forjada en las corrientes de lava del Volcán Cinnabar, portadora de llamas perpetuas.";
            }
        }

        // Polimorfismo: Ventaja elemental de Fuego (Fuego consume Aire, pero es extinguido por Agua)
        public override double CalcularMultiplicadorElemental(string elementoRival)
        {
            if (elementoRival == "Aire") return 1.5;
            if (elementoRival == "Agua") return 0.75;
            return 1.0;
        }

        // Polimorfismo: Cálculo de daño especializado (Guía Requerimiento Técnico #1)
        public override int CalcularDanio(Personaje oponente, int bonoEscenario)
        {
            int baseDanio = base.CalcularDanio(oponente, bonoEscenario);
            // Pasiva de Fuego: combustión continua (+4 de daño por calor extremo)
            return baseDanio + 4;
        }

        public override string ObtenerArenaNatal()
        {
            return "Volcan Cinnabar";
        }

        public override string ObtenerResumenVentajaElemental()
        {
            return "Fuerte contra Aire (x1.5 daño) | Débil contra Agua (x0.75 daño) | Pasiva: +4 daño por quemadura continua";
        }

        public override string ObtenerLoreFaccion()
        {
            return "Los Pokémon de Fuego (Charizard, Arcanine y Moltres) tienen su origen en el VOLCÁN CINNABAR (Isla Canela), " +
                   "una isla forjada por erupciones milenarias, ríos de magma y géiseres ardientes. Alimentados por el calor del " +
                   "núcleo volcánico, son la facción más ofensiva de la Arena Elemental: todos sus ataques básicos aplican una " +
                   "pasiva de +4 puntos de daño extra por quemadura, y su habilidad especial agrega +8 de daño directo a la vida " +
                   "del rival ignorando el escudo. Sus llamaradas consumen las corrientes de Aire (x1.5 daño), pero pierden " +
                   "intensidad frente al poder extintor del Agua (x0.75 daño).";
        }

        public override string EjecutarAccionCombate(Personaje oponente)
        {
            return this.Nombre + " (Fuego) desata una llamarada abrasadora sobre " + oponente.Nombre + "!";
        }

        public override string UsarHabilidadEspecial(Personaje oponente)
        {
            // Habilidad especial de Fuego: Impacto de fuego con perforación directa
            int danio = CalcularDanio(oponente, 6);
            ResultadoDanio res = oponente.RecibirDanio(danio);
            oponente.Vida -= 8; // Quemadura térmica directa a los puntos de vida
            this.CargaEspecial = 0;

            return "¡Especial de Fuego! " + this.Nombre + " lanza " + this.NombreHabilidad + " a " + oponente.Nombre +
                   " causando " + danio + " pts (" + res.DanioMitigadoPorEscudo + " mitigados, " + res.DanioDirectoVida + " a vida) y +8 de quemadura directa a su vida.";
        }

        public override Personaje Clonar()
        {
            CartaFuego copia = new CartaFuego(this.Nombre, this.VidaMaxima, this.Defensa, this.Ataque, this.Energia, this.Empatia);
            CopiarDatosLore(copia);
            return copia;
        }
    }
}