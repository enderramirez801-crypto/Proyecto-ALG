/*
 * Created by SharpDevelop.
 * User: Ender
 * Date: 5/11/2026
 * Time: 4:25 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace ArenaElemental
{
    public class Jugador
    {
        private string nombre;
        private int partidasJugadas;
        private int victorias;
        private int derrotas;
        private int energia;
        private List<Personaje> mazo;
        private Queue<Personaje> colaRelevos;
        private Personaje personajeActivo;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        // Propiedad compatible con la base de datos y vistas
        public string NombreUsuario
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public int PartidasJugadas
        {
            get { return partidasJugadas; }
            set { partidasJugadas = value; }
        }

        public int Victorias
        {
            get { return victorias; }
            set { victorias = value; }
        }

        public int Derrotas
        {
            get { return derrotas; }
            set { derrotas = value; }
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

        public List<Personaje> Mazo
        {
            get { return mazo; }
            set { mazo = value; }
        }

        public Queue<Personaje> ColaRelevos
        {
            get { return colaRelevos; }
        }

        public Personaje PersonajeActivo
        {
            get { return personajeActivo; }
            set { personajeActivo = value; }
        }

        public double PorcentajeExito
        {
            get
            {
                if (partidasJugadas == 0) return 0;
                return Math.Round((victorias * 100.0) / partidasJugadas, 1);
            }
        }

        public Jugador(string nombre, int partidas, int victorias, int derrotas)
        {
            this.nombre = nombre;
            this.partidasJugadas = partidas;
            this.victorias = victorias;
            this.derrotas = derrotas;
            this.energia = 2;
            this.mazo = new List<Personaje>();
            this.colaRelevos = new Queue<Personaje>();
        }

        // Prepara el equipo de combate: el primer personaje entra como Activo y los otros 4 a la Cola de Relevos (FIFO)
        public void PrepararEquipo()
        {
            colaRelevos.Clear();
            personajeActivo = null;
            energia = 2;

            for (int i = 0; i < mazo.Count; i++)
            {
                Personaje copia = mazo[i].Clonar();
                copia.CargaEspecial = 0;

                if (i == 0)
                {
                    personajeActivo = copia;
                }
                else
                {
                    colaRelevos.Enqueue(copia);
                }
            }
        }

        // Consulta quién es el próximo personaje en la Cola sin retirarlo (Peek)
        public Personaje VerSiguienteEnCola()
        {
            if (colaRelevos.Count == 0) return null;
            return colaRelevos.Peek();
        }

        // Cambia al personaje activo aplicando Enqueue() y Dequeue() en la Cola (Queue)
        public string RelevarPersonaje()
        {
            Personaje proximo = VerSiguienteEnCola();
            if (proximo == null)
            {
                return Program.IdiomaIngles
                    ? "No characters left on the bench."
                    : "No quedan personajes en la banca de relevos.";
            }

            Personaje anterior = personajeActivo;
            personajeActivo = colaRelevos.Dequeue();

            if (anterior != null && anterior.EstaVivo())
            {
                colaRelevos.Enqueue(anterior);
            }

            string nomAnterior = (anterior != null) ? anterior.Nombre : (Program.IdiomaIngles ? "Bench" : "Banca");
            if (Program.IdiomaIngles)
            {
                return nombre + " swaps out " + nomAnterior + " and sends " + personajeActivo.Nombre + " into the battlefield.";
            }
            return nombre + " releva a " + nomAnterior + " y entra " + personajeActivo.Nombre + " al campo de batalla.";
        }

        // Saca al siguiente personaje vivo de la Cola cuando el activo cae a 0 de vida
        // Si no quedan personajes vivos en la cola, el jugador pierde el combate
        public bool SacarSiguientePorMuerte()
        {
            while (colaRelevos.Count > 0)
            {
                Personaje siguiente = colaRelevos.Dequeue();
                if (siguiente.EstaVivo())
                {
                    personajeActivo = siguiente;
                    return true;
                }
            }
            personajeActivo = null;
            return false;
        }
    }
}