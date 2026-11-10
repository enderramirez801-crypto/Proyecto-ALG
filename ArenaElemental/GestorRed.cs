/*
 * Created by SharpDevelop.
 * User: Ender
 * Date: 5/11/2026
 * Time: 5:20 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ArenaElemental
{
    public class GestorRed
    {
        private TcpListener servidor;
        private TcpClient cliente;
        private StreamReader lector;
        private StreamWriter escritor;
        private Thread hiloEscucha;
        private bool conectado = false;

        public Action<string> AlRecibirMensaje;

        public bool Conectado
        {
            get { return conectado; }
        }

        public string IniciarServidor(int puerto)
        {
            try
            {
                Cerrar();
                servidor = new TcpListener(IPAddress.Any, puerto);
                servidor.Start();

                hiloEscucha = new Thread(EsperarCliente);
                hiloEscucha.IsBackground = true;
                hiloEscucha.Start();

                return "Servidor esperando conexión en puerto " + puerto + "...";
            }
            catch (Exception ex)
            {
                return "Error al abrir servidor: " + ex.Message;
            }
        }

        public string ConectarCliente(string ip, int puerto)
        {
            try
            {
                Cerrar();
                cliente = new TcpClient(ip, puerto);
                lector = new StreamReader(cliente.GetStream());
                escritor = new StreamWriter(cliente.GetStream());
                escritor.AutoFlush = true;
                conectado = true;

                hiloEscucha = new Thread(EscucharDatos);
                hiloEscucha.IsBackground = true;
                hiloEscucha.Start();

                return "Conectado al servidor " + ip + ":" + puerto;
            }
            catch (Exception ex)
            {
                return "No se pudo conectar: " + ex.Message;
            }
        }

        private void EsperarCliente()
        {
            try
            {
                cliente = servidor.AcceptTcpClient();
                lector = new StreamReader(cliente.GetStream());
                escritor = new StreamWriter(cliente.GetStream());
                escritor.AutoFlush = true;
                conectado = true;

                if (AlRecibirMensaje != null) AlRecibirMensaje("CONECTADO");
                EscucharDatos();
            }
            catch (Exception)
            {
                conectado = false;
            }
        }

        private void EscucharDatos()
        {
            try
            {
                while (conectado && cliente != null && cliente.Connected)
                {
                    string mensaje = lector.ReadLine();
                    if (mensaje == null) break;

                    if (AlRecibirMensaje != null)
                    {
                        AlRecibirMensaje(mensaje);
                    }
                }
            }
            catch (Exception)
            {
                conectado = false;
            }
        }

        public void EnviarAccion(string comando)
        {
            try
            {
                if (conectado && escritor != null)
                {
                    escritor.WriteLine(comando);
                }
            }
            catch (Exception)
            {
                conectado = false;
            }
        }

        public void Cerrar()
        {
            conectado = false;
            try { if (lector != null) lector.Close(); } catch (Exception) { }
            try { if (escritor != null) escritor.Close(); } catch (Exception) { }
            try { if (cliente != null) cliente.Close(); } catch (Exception) { }
            try { if (servidor != null) servidor.Stop(); } catch (Exception) { }
        }
    }
}
