using ChatServerApp.Comunicacion;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            String hola = "hola";
            int puerto = Int32.Parse(ConfigurationManager.AppSettings["puerto"]);
            Console.WriteLine("Iniciando Servidor en puerto {0}", puerto);
            ServerSocket servidor = new ServerSocket(puerto);
            if (servidor.Iniciar())
            {
                //Obetner Clientes
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Esperando Clientes..");
                    if (servidor.ObtenerCliente())
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Conexion Establecida!");
                        //Protocolo de comunicacion
                        string mensaje = "";
                        while(mensaje.ToLower() != "chao")
                        {
                            mensaje = servidor.Leer();
                            Console.WriteLine("C:{0}",mensaje);
                            if(mensaje.ToLower() != "chao")
                                {
                              //  Console.WriteLine("responda");
                                mensaje = Console.ReadLine().Trim();
                                Console.WriteLine("S:{0}",mensaje);
                                servidor.Escribir(mensaje);

                                }
                        }
                       
                        servidor.CerrarConexion();

                    }
                }     
            }
            else
            {
                //Error
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No es posible iniciar servidor");
                Console.ReadKey();
            }
        }
    }
}
            