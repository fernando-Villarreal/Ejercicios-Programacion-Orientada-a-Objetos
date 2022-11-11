using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace eje11
{
    internal class Program
    {
        interface constantes
        {
            void EntrarPorra();
            void Ganadores();
            void generarResultados();


        }



        public class jugador : constantes
        {
            public int dineroPorra = 1;
            public int dineroIni = 5;
            public int dineroRecaudado = 0;



            public string nombre;
            public int dinero;
            public int porrasGanadas;
            public string equipo;
            public string[] resultados;
            public string GanoPerdio = "";

            public jugador(string nombre) 
            {
                this.nombre = nombre;
                this.dinero = dineroIni;
                this.porrasGanadas = 0;
            }



            public void reiniciarResultados()
            {
                dineroRecaudado = 0;

            }

            public bool tieneDinero() 
            {
                if (this.dinero >= dineroPorra)
                {
                return true;
            }
                else
                {
                return false;
            }
            }
            static Random random = new Random();
            public void EntrarPorra()
            {
                this.dinero = this.dinero - dineroPorra;
                dineroRecaudado = dineroRecaudado + dineroPorra;

                

                if (tieneDinero() == true)
                {
                    Console.WriteLine(nombre + " entro a la porra! le quedan: " + dinero + " dolares");

                      int x = random.Next(0, 2);

                    if (x == 0)
                    {
                        this.equipo = "Local";

                    }
                    else if (x == 1)
                    {
                        this.equipo = "Visitante";

                    }


                }
                else
                {
                    Console.WriteLine(nombre + " NO ENTRO A LA PORRA POR FALTA DE DINERO, TIENE " + dinero + " dolares");
                }
            }

            public void generarResultados()
            {
                

                int local = 0;
                int visitante = 0;
                var quienGana = 0;

                for (int i = 0; i < 2; i++)
                {
                    local = random.Next(0, 7);
                    visitante = random.Next(0, 7);
                }
                quienGana = local - visitante;

                if (quienGana > 0)
                 {
                    if (equipo == "Local")
                    {
                        this.GanoPerdio = "gano";
                    }
                    if (equipo == "Visitante")
                    {
                        this.GanoPerdio = "perdio";
                    }

                }
                 else if (quienGana < 0)
                 {
                    if (equipo == "Local")
                    {
                        this.GanoPerdio = "perdio";
                    }
                    if (equipo == "Visitante")
                    {
                        this.GanoPerdio = "gano";
                    }
                }
                 else if (quienGana == 0 )
                 {
                    if (equipo == "Local")
                    {
                        this.GanoPerdio = "empate";
                    }
                    if (equipo == "Visitante")
                    {
                        this.GanoPerdio = "empate";
                    }
                }


                 
                Console.WriteLine("local : " + local + " visitante: " + visitante);
            }

            public void Ganadores()
            {
                

                if (this.GanoPerdio == "gano")
                {
                    porrasGanadas++;
                    this.dinero = this.dinero + dineroRecaudado;
                    this.dineroRecaudado = 0;
                    Console.WriteLine(nombre + " gano la porra! tiene: " + this.dinero + " dolares");
                    
                    reiniciarResultados();
                }
                else if (this.GanoPerdio == "perdio")
                {
                    this.dinero = this.dinero;
                    Console.WriteLine(nombre + " perdio la porra! sigue teniendo " + this.dinero + " dolares");
                    
                    
                }
                else if (this.GanoPerdio == "empate")
                {
                    this.dinero = this.dinero;
                    Console.WriteLine(nombre + " No gano ni perdio, el bote se acumula! sigue teniendo " + this.dinero + " dolares");
                    
                    
                }

            }

        }

       



        






        static void Main(string[] args)
        {
            List<jugador> jugadores = new List<jugador>();
          

            jugador j1 = new jugador("ferka");
            jugador j2 = new jugador("Luis");
            jugador j3 = new jugador("Marquito");


            
            jugadores.Add(j1);
            jugadores.Add(j2);
            jugadores.Add(j3);





            foreach (jugador j in jugadores)
            {
                Console.WriteLine("----------------------------------------");
                j.EntrarPorra();
                
                Console.WriteLine(j.nombre + " APOSTO POR: " + j.equipo);
                j.generarResultados();
                j.Ganadores();

                Console.WriteLine("----------------------------------------");

                j.EntrarPorra();
                Console.WriteLine(j.nombre + " APOSTO POR: " + j.equipo);
                j.generarResultados();
                j.Ganadores();

                Console.WriteLine("Gano: " + j.porrasGanadas + " porras");
              
                

            }



            Console.ReadKey();
        }
    }
}
