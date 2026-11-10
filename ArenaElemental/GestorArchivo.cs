/*
 * Created by SharpDevelop.
 * User: Ender
 * Date: 4/11/2026
 * Time: 6:40 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace ArenaElemental
{
    public class GestorArchivo
    {
        private string rutaHistorial = "HistorialCombate.txt";
        private string rutaCatalogo = "CatalogoCartas.txt";
        private string rutaJugadores = "JugadoresRanking.txt";
        private string rutaEscenarios = "EscenariosArena.txt";
        private string rutaLore = "LorePokemon.txt";

        // Crea las 12 cartas de Pokémon del catálogo (3 por elemento, HP + DEF + ATK = 100)
        public List<Personaje> ObtenerCatalogoBase()
        {
            List<Personaje> lista = new List<Personaje>();

            // 3 Pokémon de Agua
            lista.Add(new CartaAgua("Blastoise", 50, 30, 20, 2, 78));
            lista.Add(new CartaAgua("Gyarados", 55, 20, 25, 2, 82));
            lista.Add(new CartaAgua("Vaporeon", 45, 30, 25, 2, 70));

            // 3 Pokémon de Fuego
            lista.Add(new CartaFuego("Charizard", 40, 20, 40, 2, 62));
            lista.Add(new CartaFuego("Arcanine", 45, 20, 35, 2, 75));
            lista.Add(new CartaFuego("Moltres", 50, 20, 30, 2, 68));

            // 3 Pokémon de Tierra
            lista.Add(new CartaTierra("Groudon", 55, 30, 15, 2, 85));
            lista.Add(new CartaTierra("Golem", 50, 35, 15, 2, 80));
            lista.Add(new CartaTierra("Tyranitar", 55, 25, 20, 2, 76));

            // 3 Pokémon de Aire
            lista.Add(new CartaAire("Rayquaza", 45, 25, 30, 2, 74));
            lista.Add(new CartaAire("Pidgeot", 50, 25, 25, 2, 80));
            lista.Add(new CartaAire("Lugia", 40, 25, 35, 2, 66));

            return lista;
        }

        // Crea las 4 Arenas Pokémon (1 por cada elemento)
        public List<Escenario> ObtenerEscenariosBase()
        {
            List<Escenario> lista = new List<Escenario>();
            lista.Add(new Escenario("Estadio Cascada", "Agua", "Fuego", 5));
            lista.Add(new Escenario("Volcan Cinnabar", "Fuego", "Aire", 5));
            lista.Add(new Escenario("Canon Rocoso", "Tierra", "Agua", 5));
            lista.Add(new Escenario("Torre Celeste", "Aire", "Tierra", 5));
            return lista;
        }

        // Busca un archivo de imagen en la carpeta Imagenes (compatible con bin/Debug y raíz)
        private string BuscarRutaImagen(string nombreArchivo)
        {
            string[] posibles = new string[]
            {
                Path.Combine("Imagenes", nombreArchivo),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Imagenes", nombreArchivo),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "Imagenes", nombreArchivo)
            };

            foreach (string ruta in posibles)
            {
                if (File.Exists(ruta)) return ruta;
            }
            return null;
        }

        // Dibuja la carta estilo Pokémon con su foto oficial, marco elemental y estadísticas
        public Bitmap DibujarCartaPokemon(Personaje p, bool mostrarVidaActual)
        {
            Bitmap bmp = new Bitmap(120, 160);
            bmp.SetResolution(96, 96);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;

                Color colorMarco = Color.FromArgb(45, 135, 215);
                Color colorFondo = Color.FromArgb(215, 238, 255);
                if (p.Elemento == "Fuego")
                {
                    colorMarco = Color.FromArgb(215, 65, 40);
                    colorFondo = Color.FromArgb(255, 225, 215);
                }
                else if (p.Elemento == "Tierra")
                {
                    colorMarco = Color.FromArgb(165, 115, 55);
                    colorFondo = Color.FromArgb(245, 232, 210);
                }
                else if (p.Elemento == "Aire")
                {
                    colorMarco = Color.FromArgb(65, 165, 195);
                    colorFondo = Color.FromArgb(225, 248, 255);
                }

                g.Clear(colorFondo);

                // Encabezado de la carta
                using (SolidBrush brHeader = new SolidBrush(colorMarco))
                {
                    g.FillRectangle(brHeader, 0, 0, 120, 22);
                }

                Font fNombre = new Font("Segoe UI", 11f, FontStyle.Bold, GraphicsUnit.Pixel);
                Font fElem = new Font("Segoe UI", 9.5f, FontStyle.Bold, GraphicsUnit.Pixel);
                Font fStats = new Font("Segoe UI", 10.5f, FontStyle.Bold, GraphicsUnit.Pixel);

                g.DrawString(p.Nombre, fNombre, Brushes.White, 5, 3);

                // Recuadro central para la foto del Pokémon
                Rectangle rectFoto = new Rectangle(8, 25, 104, 82);
                g.FillRectangle(Brushes.White, rectFoto);
                g.DrawRectangle(Pens.Gray, rectFoto);

                string rutaFoto = BuscarRutaImagen(p.Nombre + ".png");
                if (rutaFoto != null)
                {
                    try
                    {
                        using (Image imgPokemon = Image.FromFile(rutaFoto))
                        {
                            g.DrawImage(imgPokemon, 14, 27, 92, 78);
                        }
                    }
                    catch (Exception)
                    {
                    }
                }

                // Etiqueta de tipo elemental
                using (SolidBrush brTag = new SolidBrush(colorMarco))
                {
                    g.FillRectangle(brTag, 8, 92, 48, 15);
                }
                g.DrawString(p.Elemento.ToUpper(), fElem, Brushes.White, 11, 93);

                // Estadísticas en la parte inferior de la carta
                int hpMostrar = mostrarVidaActual ? p.Vida : p.VidaMaxima;
                g.DrawString("HP: " + hpMostrar + "/" + p.VidaMaxima, fStats, Brushes.DarkRed, 8, 110);
                g.DrawString("DEF: " + p.Defensa + "  ATK: " + p.Ataque, fStats, Brushes.Black, 8, 125);
                g.DrawString("EMP: " + p.Empatia, fStats, Brushes.DarkSlateBlue, 8, 140);

                // Borde exterior de la carta
                using (Pen penMarco = new Pen(colorMarco, 3))
                {
                    g.DrawRectangle(penMarco, 1, 1, 117, 157);
                }
            }
            return bmp;
        }

        // Carga o dibuja la foto respectiva de la Arena según su elemento favorecido
        public Bitmap ObtenerImagenArena(Escenario esc, int ancho, int alto)
        {
            Bitmap bmp = new Bitmap(ancho, alto);
            bmp.SetResolution(96, 96);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;

                string elem = (esc != null) ? esc.ElementoFavorecido : "Agua";
                string ruta = BuscarRutaImagen("Arena_" + elem + ".png");

                if (ruta != null)
                {
                    try
                    {
                        using (Image imgArena = Image.FromFile(ruta))
                        {
                            g.DrawImage(imgArena, 0, 0, ancho, alto);
                        }
                        g.DrawRectangle(Pens.Black, 0, 0, ancho - 1, alto - 1);
                        return bmp;
                    }
                    catch (Exception)
                    {
                    }
                }

                // Respaldo visual si no se encuentra el archivo
                Color c1 = Color.DodgerBlue;
                if (elem == "Fuego") c1 = Color.Crimson;
                else if (elem == "Tierra") c1 = Color.Peru;
                else if (elem == "Aire") c1 = Color.SkyBlue;

                g.Clear(c1);
                if (esc != null)
                {
                    Font f = new Font("Segoe UI", 12f, FontStyle.Bold, GraphicsUnit.Pixel);
                    g.DrawString(esc.Nombre, f, Brushes.White, 8, 8);
                }
                g.DrawRectangle(Pens.Black, 0, 0, ancho - 1, alto - 1);
            }
            return bmp;
        }

        public void GuardarEscenarios(List<Escenario> escenarios)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(rutaEscenarios, false))
                {
                    foreach (Escenario e in escenarios)
                    {
                        string linea = e.Nombre + ";" + e.ElementoFavorecido + ";" +
                                       e.ElementoPenalizado + ";" + e.BonoAtaque;
                        writer.WriteLine(linea);
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public List<Escenario> CargarEscenarios()
        {
            List<Escenario> lista = new List<Escenario>();

            try
            {
                if (!File.Exists(rutaEscenarios))
                {
                    lista = ObtenerEscenariosBase();
                    GuardarEscenarios(lista);
                    return lista;
                }

                using (StreamReader reader = new StreamReader(rutaEscenarios))
                {
                    string linea;
                    while ((linea = reader.ReadLine()) != null)
                    {
                        if (linea == "" || linea.StartsWith("#")) continue;

                        string[] datos = linea.Split(';');
                        if (datos.Length >= 4)
                        {
                            string nombre = datos[0];
                            string fav = datos[1];
                            string pen = datos[2];
                            int bono = int.Parse(datos[3]);

                            lista.Add(new Escenario(nombre, fav, pen, bono));
                        }
                    }
                }
            }
            catch (Exception)
            {
                lista.Clear();
            }

            if (lista.Count == 0)
            {
                lista = ObtenerEscenariosBase();
                GuardarEscenarios(lista);
            }

            return lista;
        }

        public void GuardarCatalogo(List<Personaje> personajes)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(rutaCatalogo, false))
                {
                    foreach (Personaje p in personajes)
                    {
                        string linea = p.Nombre + ";" + p.Elemento + ";" + p.VidaMaxima + ";" +
                                       p.Defensa + ";" + p.Ataque + ";" + p.Energia + ";" + p.Empatia;
                        writer.WriteLine(linea);
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public List<Personaje> CargarCatalogo()
        {
            List<Personaje> lista = new List<Personaje>();

            try
            {
                if (!File.Exists(rutaCatalogo))
                {
                    lista = ObtenerCatalogoBase();
                    GuardarCatalogo(lista);
                    CargarLorePokemon(lista);
                    return lista;
                }

                using (StreamReader reader = new StreamReader(rutaCatalogo))
                {
                    string linea;
                    while ((linea = reader.ReadLine()) != null)
                    {
                        if (linea == "" || linea.StartsWith("#")) continue;

                        string[] datos = linea.Split(';');
                        if (datos.Length >= 7)
                        {
                            string nombre = datos[0];
                            string elem = datos[1];
                            int hp = int.Parse(datos[2]);
                            int def = int.Parse(datos[3]);
                            int atk = int.Parse(datos[4]);
                            int ener = int.Parse(datos[5]);
                            int emp = int.Parse(datos[6]);

                            if (elem == "Agua") lista.Add(new CartaAgua(nombre, hp, def, atk, ener, emp));
                            else if (elem == "Fuego") lista.Add(new CartaFuego(nombre, hp, def, atk, ener, emp));
                            else if (elem == "Tierra") lista.Add(new CartaTierra(nombre, hp, def, atk, ener, emp));
                            else if (elem == "Aire") lista.Add(new CartaAire(nombre, hp, def, atk, ener, emp));
                        }
                    }
                }
            }
            catch (Exception)
            {
                lista.Clear();
            }

            // Verifica que el archivo tenga los Pokémon actuales; si tenía nombres antiguos o está vacío, lo actualiza
            bool tienePokemonActuales = false;
            foreach (Personaje p in lista)
            {
                if (p.Nombre == "Blastoise" || p.Nombre == "Charizard")
                {
                    tienePokemonActuales = true;
                    break;
                }
            }

            if (lista.Count == 0 || !tienePokemonActuales)
            {
                lista = ObtenerCatalogoBase();
                GuardarCatalogo(lista);
            }

            CargarLorePokemon(lista);
            return lista;
        }

        // Guarda el Lore, Región de Origen y Habilidad Especial de los Pokémon en LorePokemon.txt
        public void GuardarLorePokemon(List<Personaje> personajes)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(rutaLore, false))
                {
                    foreach (Personaje p in personajes)
                    {
                        string linea = p.Nombre + ";" + p.Elemento + ";" + p.RegionOrigen + ";" +
                                       p.NombreHabilidad + ";" + p.Descripcion + ";" + p.Lore;
                        writer.WriteLine(linea);
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        // Carga o inicializa el archivo LorePokemon.txt para mantener sincronizado el lore de los 12 Pokémon
        public void CargarLorePokemon(List<Personaje> personajes)
        {
            if (personajes == null || personajes.Count == 0) return;

            try
            {
                if (!File.Exists(rutaLore))
                {
                    GuardarLorePokemon(personajes);
                    return;
                }

                using (StreamReader reader = new StreamReader(rutaLore))
                {
                    string linea;
                    while ((linea = reader.ReadLine()) != null)
                    {
                        if (linea == "" || linea.StartsWith("#")) continue;

                        string[] datos = linea.Split(';');
                        if (datos.Length >= 6)
                        {
                            string nom = datos[0];
                            Personaje encontrado = BuscarCarta(personajes, nom);
                            if (encontrado != null)
                            {
                                encontrado.RegionOrigen = datos[2];
                                encontrado.NombreHabilidad = datos[3];
                                encontrado.Descripcion = datos[4];
                                encontrado.Lore = datos[5];
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        // Guarda los jugadores y sus mazos en .txt
        public void GuardarJugadores(List<Jugador> jugadores)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(rutaJugadores, false))
                {
                    foreach (Jugador j in jugadores)
                    {
                        string cartasTexto = "";
                        for (int i = 0; i < j.Mazo.Count; i++)
                        {
                            if (i > 0) cartasTexto += ",";
                            cartasTexto += j.Mazo[i].Nombre;
                        }

                        string linea = j.Nombre + ";" + j.PartidasJugadas + ";" +
                                       j.Victorias + ";" + j.Derrotas + ";" + cartasTexto;
                        writer.WriteLine(linea);
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        // Lee los jugadores y reconstruye sus mazos desde el .txt
        public List<Jugador> CargarJugadores(List<Personaje> catalogo)
        {
            List<Jugador> jugadores = new List<Jugador>();

            try
            {
                if (File.Exists(rutaJugadores))
                {
                    using (StreamReader reader = new StreamReader(rutaJugadores))
                    {
                        string linea;
                        while ((linea = reader.ReadLine()) != null)
                        {
                            if (linea == "" || linea.StartsWith("#")) continue;

                            string[] datos = linea.Split(';');
                            if (datos.Length >= 4)
                            {
                                string nom = datos[0];
                                int part = int.Parse(datos[1]);
                                int vic = int.Parse(datos[2]);
                                int der = int.Parse(datos[3]);

                                Jugador j = new Jugador(nom, part, vic, der);

                                if (datos.Length >= 5 && datos[4] != "")
                                {
                                    string[] nombresCartas = datos[4].Split(',');
                                    for (int i = 0; i < nombresCartas.Length; i++)
                                    {
                                        Personaje encontrada = BuscarCarta(catalogo, nombresCartas[i]);
                                        if (encontrada != null && j.Mazo.Count < 5)
                                        {
                                            j.Mazo.Add(encontrada.Clonar());
                                        }
                                    }
                                }

                                jugadores.Add(j);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                jugadores.Clear();
            }

            return jugadores;
        }

        private Personaje BuscarCarta(List<Personaje> catalogo, string nombre)
        {
            foreach (Personaje p in catalogo)
            {
                if (p.Nombre == nombre) return p;
            }
            return null;
        }

        // Borra los archivos de jugadores e historial para dejar todo en cero
        public void BorrarDatosRegistrados()
        {
            try
            {
                if (File.Exists(rutaJugadores)) File.Delete(rutaJugadores);
                if (File.Exists(rutaHistorial)) File.Delete(rutaHistorial);
                string rutaHistoricaAcumulada = "Bitacora_Historica_Partidas.txt";
                if (File.Exists(rutaHistoricaAcumulada)) File.Delete(rutaHistoricaAcumulada);
            }
            catch (Exception)
            {
            }
        }

        // Guarda la bitácora completa detallada post-batalla en archivo .txt (Guía 2.6 y Enunciado 7.2)
        public void GuardarHistorialDetallado(
            IEnumerable<string> historial,
            string jugador1,
            string jugador2,
            string ganador,
            string escenario,
            int totalTurnos,
            int totalTerremotos)
        {
            try
            {
                // 1. Guardar la bitácora de la partida actual en HistorialCombate.txt
                using (StreamWriter writer = new StreamWriter(rutaHistorial, false, System.Text.Encoding.UTF8))
                {
                    writer.WriteLine("======================================================================");
                    writer.WriteLine("BITÁCORA OFICIAL DE COMBATE POST-BATALLA - ARENA ELEMENTAL");
                    writer.WriteLine("======================================================================");
                    writer.WriteLine("Fecha y Hora        : " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    writer.WriteLine("Jugador 1           : " + jugador1);
                    writer.WriteLine("Jugador 2           : " + jugador2);
                    writer.WriteLine("Ganador de la Arena : " + ganador);
                    writer.WriteLine("Escenario / Arena   : " + escenario);
                    writer.WriteLine("Total de Rondas     : " + totalTurnos);
                    writer.WriteLine("Terremotos Ocurridos: " + totalTerremotos);
                    writer.WriteLine("======================================================================");
                    writer.WriteLine("REGISTRO SECUENCIAL TURNO POR TURNO (PILA / LIFO EXTRAÍDA CON POP):");
                    writer.WriteLine("======================================================================");

                    foreach (string accion in historial)
                    {
                        writer.WriteLine(accion);
                    }

                    writer.WriteLine("======================================================================");
                    writer.WriteLine("FIN DE LA BITÁCORA DE BATALLA");
                    writer.WriteLine("======================================================================");
                }

                // 2. Acumular también en un archivo de bitácora general para persistencia histórica
                string rutaHistoricaAcumulada = "Bitacora_Historica_Partidas.txt";
                using (StreamWriter writerAcum = new StreamWriter(rutaHistoricaAcumulada, true, System.Text.Encoding.UTF8))
                {
                    writerAcum.WriteLine("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "] " +
                                         jugador1 + " vs " + jugador2 + " | Ganador: " + ganador +
                                         " | Arena: " + escenario + " | Rondas: " + totalTurnos + " | Terremotos: " + totalTerremotos);
                }
            }
            catch (Exception)
            {
            }
        }

        // Sobrecarga de conveniencia
        public void GuardarHistorial(IEnumerable<string> historial)
        {
            GuardarHistorialDetallado(historial, "Jugador 1", "Jugador 2", "No definido", "Arena", 1, 0);
        }
    }
}
