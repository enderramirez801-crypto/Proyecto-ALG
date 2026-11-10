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

        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormGestionMazo());
        }
    }
}