using System;
using System.Windows.Forms;

namespace ArenaElemental
{
    internal static class Program
    {
        public static bool IdiomaIngles = false;

        public static string TraducirElemento(string elem)
        {
            if (!IdiomaIngles) return elem;
            if (elem == "Fuego") return "Fire";
            if (elem == "Agua") return "Water";
            if (elem == "Tierra") return "Earth";
            if (elem == "Aire") return "Air";
            return elem;
        }

        public static string TraducirArena(string nombre)
        {
            if (!IdiomaIngles) return nombre;
            if (nombre == "Estadio Cascada") return "Cascade Stadium";
            if (nombre == "Volcan Cinnabar" || nombre == "Volcán Cinnabar") return "Cinnabar Volcano";
            if (nombre == "Canon Rocoso" || nombre == "Cañón Rocoso") return "Rocky Canyon";
            if (nombre == "Torre Celeste") return "Sky Tower";
            return nombre;
        }

        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormGestionMazo());
        }
    }
}