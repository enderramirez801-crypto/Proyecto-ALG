/*
 * Created by SharpDevelop.
 * User: Ender
 * Date: 5/11/2026
 * Time: 5:05 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ArenaElemental
{
    public class GestorBaseDatos
    {
        private string cadenaConexion = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=ArenaElementalDB;Integrated Security=True;Connect Timeout=1";
        private GestorArchivo gestorArchivo;

        public GestorBaseDatos(GestorArchivo archivo)
        {
            this.gestorArchivo = archivo;
        }

        // Consulta SELECT con SqlDataReader para cargar los personajes desde la tabla Personajes
        public List<Personaje> CargarCatalogoDesdeBD()
        {
            List<Personaje> lista = new List<Personaje>();

            try
            {
                using (SqlConnection con = new SqlConnection(cadenaConexion))
                {
                    con.Open();
                    string sql = "SELECT Nombre, Elemento, VidaBase, DefensaBase, AtaqueBase, EnergiaInicial, Empatia FROM Personajes";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nom = reader.GetString(0);
                            string elem = reader.GetString(1);
                            int hp = reader.GetInt32(2);
                            int def = reader.GetInt32(3);
                            int atk = reader.GetInt32(4);
                            int ener = reader.GetInt32(5);
                            int emp = reader.GetInt32(6);

                            if (elem == "Agua") lista.Add(new CartaAgua(nom, hp, def, atk, ener, emp));
                            else if (elem == "Fuego") lista.Add(new CartaFuego(nom, hp, def, atk, ener, emp));
                            else if (elem == "Tierra") lista.Add(new CartaTierra(nom, hp, def, atk, ener, emp));
                            else if (elem == "Aire") lista.Add(new CartaAire(nom, hp, def, atk, ener, emp));
                        }
                    }
                }
            }
            catch (Exception)
            {
                lista.Clear();
            }

            bool tienePokemon = false;
            foreach (Personaje p in lista)
            {
                if (p.Nombre == "Blastoise" || p.Nombre == "Charizard")
                {
                    tienePokemon = true;
                    break;
                }
            }

            if (lista.Count == 0 || !tienePokemon)
            {
                return gestorArchivo.CargarCatalogo();
            }

            gestorArchivo.CargarLorePokemon(lista);
            return lista;
        }

        // Consulta SELECT con SqlDataReader para cargar las arenas desde Cartas_Escenario
        public List<Escenario> CargarEscenariosDesdeBD()
        {
            List<Escenario> lista = new List<Escenario>();

            try
            {
                using (SqlConnection con = new SqlConnection(cadenaConexion))
                {
                    con.Open();
                    string sql = "SELECT Nombre, ElementoFavorecido, ElementoPenalizado, BonoAtaque FROM Cartas_Escenario";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nom = reader.GetString(0);
                            string fav = reader.GetString(1);
                            string pen = reader.GetString(2);
                            int bono = reader.GetInt32(3);

                            lista.Add(new Escenario(nom, fav, pen, bono));
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
                return gestorArchivo.CargarEscenarios();
            }

            return lista;
        }

        // Consulta SELECT con SqlDataReader para cargar los jugadores y sus equipos desde Jugadores y Equipos
        public List<Jugador> CargarJugadoresDesdeBD(List<Personaje> catalogo)
        {
            List<Jugador> jugadores = new List<Jugador>();
            List<int> idsJugadores = new List<int>();

            try
            {
                using (SqlConnection con = new SqlConnection(cadenaConexion))
                {
                    con.Open();
                    string sqlJug = "SELECT IdJugador, NombreUsuario, PartidasJugadas, Victorias, Derrotas FROM Jugadores";
                    SqlCommand cmdJug = new SqlCommand(sqlJug, con);
                    using (SqlDataReader reader = cmdJug.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string nom = reader.GetString(1);
                            int part = reader.GetInt32(2);
                            int vic = reader.GetInt32(3);
                            int der = reader.GetInt32(4);

                            idsJugadores.Add(id);
                            jugadores.Add(new Jugador(nom, part, vic, der));
                        }
                    }

                    for (int i = 0; i < jugadores.Count; i++)
                    {
                        string sqlEq = "SELECT NombrePersonaje FROM Equipos WHERE IdJugador = @id ORDER BY OrdenRelevo ASC";
                        SqlCommand cmdEq = new SqlCommand(sqlEq, con);
                        cmdEq.Parameters.AddWithValue("@id", idsJugadores[i]);
                        using (SqlDataReader readerEq = cmdEq.ExecuteReader())
                        {
                            while (readerEq.Read())
                            {
                                string nomCarta = readerEq.GetString(0);
                                foreach (Personaje p in catalogo)
                                {
                                    if (p.Nombre == nomCarta && jugadores[i].Mazo.Count < 5)
                                    {
                                        jugadores[i].Mazo.Add(p.Clonar());
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                jugadores.Clear();
            }

            if (jugadores.Count == 0)
            {
                return gestorArchivo.CargarJugadores(catalogo);
            }

            return jugadores;
        }

        // Registra un nuevo jugador con su mazo vacío (0 cartas) para que el usuario lo arme
        public Jugador RegistrarJugador(string nombre, List<Jugador> listaJugadores)
        {
            foreach (Jugador existente in listaJugadores)
            {
                if (existente.Nombre.ToLower() == nombre.ToLower())
                {
                    return existente;
                }
            }

            Jugador nuevo = new Jugador(nombre, 0, 0, 0);

            try
            {
                using (SqlConnection con = new SqlConnection(cadenaConexion))
                {
                    con.Open();
                    string sql = "INSERT INTO Jugadores (NombreUsuario, PartidasJugadas, Victorias, Derrotas, PorcentajeExito) " +
                                 "VALUES (@nom, 0, 0, 0, 0)";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@nom", nuevo.Nombre);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                // Si el servidor SQL no está abierto en la PC, igual se guarda en el archivo .txt
            }

            listaJugadores.Add(nuevo);
            gestorArchivo.GuardarJugadores(listaJugadores);
            return nuevo;
        }

        // Guarda el mazo de 5 cartas del jugador en la tabla relacional Equipos y en el archivo .txt
        public void GuardarEquipoEnBD(Jugador jugador, List<Jugador> todos)
        {
            gestorArchivo.GuardarJugadores(todos);
            if (jugador == null) return;

            try
            {
                using (SqlConnection con = new SqlConnection(cadenaConexion))
                {
                    con.Open();
                    string sqlId = "SELECT IdJugador FROM Jugadores WHERE NombreUsuario = @nom";
                    SqlCommand cmdId = new SqlCommand(sqlId, con);
                    cmdId.Parameters.AddWithValue("@nom", jugador.Nombre);
                    object res = cmdId.ExecuteScalar();

                    if (res != null)
                    {
                        int idJugador = Convert.ToInt32(res);

                        string sqlDel = "DELETE FROM Equipos WHERE IdJugador = @id";
                        SqlCommand cmdDel = new SqlCommand(sqlDel, con);
                        cmdDel.Parameters.AddWithValue("@id", idJugador);
                        cmdDel.ExecuteNonQuery();

                        for (int i = 0; i < jugador.Mazo.Count && i < 5; i++)
                        {
                            string sqlIns = "INSERT INTO Equipos (IdJugador, NombrePersonaje, OrdenRelevo) VALUES (@id, @per, @ord)";
                            SqlCommand cmdIns = new SqlCommand(sqlIns, con);
                            cmdIns.Parameters.AddWithValue("@id", idJugador);
                            cmdIns.Parameters.AddWithValue("@per", jugador.Mazo[i].Nombre);
                            cmdIns.Parameters.AddWithValue("@ord", i + 1);
                            cmdIns.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        // Registra un nuevo personaje en el catálogo, en BD y en CatalogoCartas.txt
        public Personaje RegistrarPersonaje(string nombre, string elemento, int hp, int def, int atk, int emp, List<Personaje> catalogo)
        {
            foreach (Personaje existente in catalogo)
            {
                if (existente.Nombre.ToLower() == nombre.ToLower())
                {
                    return existente;
                }
            }

            Personaje nuevo;
            if (elemento == "Agua") nuevo = new CartaAgua(nombre, hp, def, atk, 2, emp);
            else if (elemento == "Fuego") nuevo = new CartaFuego(nombre, hp, def, atk, 2, emp);
            else if (elemento == "Tierra") nuevo = new CartaTierra(nombre, hp, def, atk, 2, emp);
            else nuevo = new CartaAire(nombre, hp, def, atk, 2, emp);

            try
            {
                using (SqlConnection con = new SqlConnection(cadenaConexion))
                {
                    con.Open();
                    string sql = "INSERT INTO Personajes (Nombre, Elemento, VidaBase, DefensaBase, AtaqueBase, EnergiaInicial, Empatia, NombreHabilidad, Descripcion) " +
                                 "VALUES (@nom, @elem, @hp, @def, @atk, 2, @emp, @hab, @desc)";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@nom", nuevo.Nombre);
                    cmd.Parameters.AddWithValue("@elem", nuevo.Elemento);
                    cmd.Parameters.AddWithValue("@hp", nuevo.VidaMaxima);
                    cmd.Parameters.AddWithValue("@def", nuevo.Defensa);
                    cmd.Parameters.AddWithValue("@atk", nuevo.Ataque);
                    cmd.Parameters.AddWithValue("@emp", nuevo.Empatia);
                    cmd.Parameters.AddWithValue("@hab", "Especial de " + nuevo.Elemento);
                    cmd.Parameters.AddWithValue("@desc", "Personaje elemental de " + nuevo.Elemento);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
            }

            catalogo.Add(nuevo);
            gestorArchivo.GuardarCatalogo(catalogo);
            return nuevo;
        }

        // Registra una nueva Arena (Escenario) en la lista, en BD y en EscenariosArena.txt
        public Escenario RegistrarEscenario(string nombre, string favorecido, string penalizado, int bono, List<Escenario> escenarios)
        {
            foreach (Escenario existente in escenarios)
            {
                if (existente.Nombre.ToLower() == nombre.ToLower())
                {
                    return existente;
                }
            }

            Escenario nuevo = new Escenario(nombre, favorecido, penalizado, bono);

            try
            {
                using (SqlConnection con = new SqlConnection(cadenaConexion))
                {
                    con.Open();
                    string sql = "INSERT INTO Cartas_Escenario (Nombre, ElementoFavorecido, ElementoPenalizado, BonoAtaque, BonoDefensa, UmbralEmpatia, Descripcion) " +
                                 "VALUES (@nom, @fav, @pen, @bono, 4, 75, @desc)";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@nom", nuevo.Nombre);
                    cmd.Parameters.AddWithValue("@fav", nuevo.ElementoFavorecido);
                    cmd.Parameters.AddWithValue("@pen", nuevo.ElementoPenalizado);
                    cmd.Parameters.AddWithValue("@bono", nuevo.BonoAtaque);
                    cmd.Parameters.AddWithValue("@desc", "Arena elemental " + nuevo.Nombre);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
            }

            escenarios.Add(nuevo);
            gestorArchivo.GuardarEscenarios(escenarios);
            return nuevo;
        }

        // Verifica si el motor SQL Server está conectado y accesible
        public bool ProbarConexionBD()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cadenaConexion))
                {
                    con.Open();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Elimina los registros en la base de datos SQL para sincronizar con el reinicio
        public void BorrarDatosEnBD()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cadenaConexion))
                {
                    con.Open();
                    string sql = "DELETE FROM Equipos; DELETE FROM Estadisticas_Partidas; DELETE FROM Jugadores;";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
            }
        }

        // Actualiza victorias/derrotas en Jugadores e inserta el registro de la batalla en Estadisticas_Partidas
        public void ActualizarEstadisticas(
            Jugador j1,
            Jugador j2,
            Jugador ganador,
            List<Jugador> todos,
            string escenario = "Estadio Cascada",
            int totalTurnos = 1,
            int terremotos = 0)
        {
            if (ganador == null || j1 == null || j2 == null) return;

            Jugador perdedor = (ganador == j1) ? j2 : j1;

            ganador.PartidasJugadas++;
            ganador.Victorias++;

            perdedor.PartidasJugadas++;
            perdedor.Derrotas++;

            try
            {
                using (SqlConnection con = new SqlConnection(cadenaConexion))
                {
                    con.Open();
                    string sql = "UPDATE Jugadores SET PartidasJugadas = @p, Victorias = @v, Derrotas = @d, PorcentajeExito = @porc WHERE NombreUsuario = @nom";

                    SqlCommand cmd1 = new SqlCommand(sql, con);
                    cmd1.Parameters.AddWithValue("@p", ganador.PartidasJugadas);
                    cmd1.Parameters.AddWithValue("@v", ganador.Victorias);
                    cmd1.Parameters.AddWithValue("@d", ganador.Derrotas);
                    cmd1.Parameters.AddWithValue("@porc", ganador.PorcentajeExito);
                    cmd1.Parameters.AddWithValue("@nom", ganador.Nombre);
                    cmd1.ExecuteNonQuery();

                    SqlCommand cmd2 = new SqlCommand(sql, con);
                    cmd2.Parameters.AddWithValue("@p", perdedor.PartidasJugadas);
                    cmd2.Parameters.AddWithValue("@v", perdedor.Victorias);
                    cmd2.Parameters.AddWithValue("@d", perdedor.Derrotas);
                    cmd2.Parameters.AddWithValue("@porc", perdedor.PorcentajeExito);
                    cmd2.Parameters.AddWithValue("@nom", perdedor.Nombre);
                    cmd2.ExecuteNonQuery();

                    string sqlPartida = "INSERT INTO Estadisticas_Partidas (Jugador1, Jugador2, Ganador, Escenario, TotalTurnos, TerremotosOcurridos) " +
                                        "VALUES (@j1, @j2, @gan, @esc, @turnos, @terr)";
                    SqlCommand cmdPartida = new SqlCommand(sqlPartida, con);
                    cmdPartida.Parameters.AddWithValue("@j1", j1.Nombre);
                    cmdPartida.Parameters.AddWithValue("@j2", j2.Nombre);
                    cmdPartida.Parameters.AddWithValue("@gan", ganador.Nombre);
                    cmdPartida.Parameters.AddWithValue("@esc", escenario);
                    cmdPartida.Parameters.AddWithValue("@turnos", totalTurnos);
                    cmdPartida.Parameters.AddWithValue("@terr", terremotos);
                    cmdPartida.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
            }

            gestorArchivo.GuardarJugadores(todos);
        }

        // Sobrecarga compatible con versiones anteriores
        public void ActualizarEstadisticas(
            Jugador ganador,
            Jugador perdedor,
            List<Jugador> todos,
            string escenario,
            int totalTurnos,
            int terremotos)
        {
            ActualizarEstadisticas(ganador, perdedor, ganador, todos, escenario, totalTurnos, terremotos);
        }
    }
}
