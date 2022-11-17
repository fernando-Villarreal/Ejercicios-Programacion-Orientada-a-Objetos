using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace eje9
{
    internal class Ejercicio9
    {
        class Pelicula
        {
            private string titulo = "";
            private int duracion = 0;
            private int edad = 0;
            private string director = "";

            public string Titulo { get { return titulo; } set { titulo = value; } }
            public int Duracion { get { return duracion; } set { duracion = value; } }
            public int Edad { get { return edad; } set { edad = value; } }
            public string Director { get { return director; } set { director = value; } }

            public Pelicula(int edad)
            {
                Edad = edad;
            }
        }
        class Espectador
        {
            string nombre = "";
            int edad = 0;
            int dinero = 0;

            public string Nombre { get { return nombre; } set { nombre = value; } }
            public int Edad { get { return edad; } set { edad = value; } }
            public int Dinero { get { return dinero; } set { dinero = value; } }

            public Espectador(string nombre, int edad, int dinero)
            {
                Edad = edad;
                Dinero = dinero;
                Nombre = nombre;
            }
        }
        class Cine
        {
            int precio = 0;
            Pelicula peli = null;

            public int Precio { get { return precio; } set { precio = value; } }
            public Pelicula Peli { get { return peli; } set { peli = value; } }

            public Cine(int precio, Pelicula peli)
            {
                Precio = precio;
                Peli = peli;
            }
        }
        class Sala
        {
            int columna = 0;
            int fila = 0;
            char[] letra = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K' };
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            public List<string> Asiento = new List<string>();
            public List<string> AsientoOcupados = new List<string>();

            static Random rnd = new Random();
            public int Columna { get { return columna; } set { columna = value; } }
            public int Fila { get { return fila; } set { fila = value; } }

            public Sala(int columna, int fila)
            {
                Columna = columna;
                Fila = fila;
                int cont = 0;
                for (int a = 0; a < fila; a++)
                {
                    cont++;
                    for (int b = 0; b < columna; b++)
                    {
                        Asiento.Add($"{array[fila - cont]}{letra[b]}");
                    }
                }
            }
            public void simulacion()
            {
                int cont = 0;
                for (int a = 0; a < fila; a++)
                {
                    for (int b = 0; b < columna; b++)
                    {
                        Console.Write(Asiento[cont] + "   ");
                        cont++;
                    }
                    Console.WriteLine("\n");
                }
            }
            public void ocuparRandom(Espectador espectador)
            {
                int probabilidad = rnd.Next(columna * fila);
                if (Asiento[probabilidad] != "Esta ocupado")
                {
                    AsientoOcupados.Add($"{Asiento[probabilidad]} esta ocupado por: {espectador.Nombre}");
                    AsientoOcupados.Add($"{Asiento[probabilidad]} esta ocupado por: {espectador.Nombre}");
                    Asiento.Insert(probabilidad, "esta ocupado");
                    Asiento.RemoveAt(probabilidad + 1);
                }
                else
                {
                    int cont = 0;
                    foreach (string item in Asiento)
                    {
                        if (Asiento[cont] != "esta ocupado")
                        {
                            AsientoOcupados.Add($"{Asiento[cont]} esta ocupado por: {espectador.Nombre}");
                            Asiento.Insert(cont, "esta ocupado");
                            Asiento.RemoveAt(cont + 1);
                            break;
                        }
                        cont++;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            int cont = 0;
            List<Espectador> espectados = new List<Espectador>();
            Espectador per1 = new Espectador("Fernando", 38, 2);
            Espectador per2 = new Espectador("Luciano", 24, 9999);
            Espectador per3 = new Espectador("Pablo", 10, 50);
            Espectador per4 = new Espectador("Martin", 69, 5);
            espectados.Add(per1);
            espectados.Add(per2);
            espectados.Add(per3);
            espectados.Add(per4);

            Sala sala = new Sala(9, 5);
            Pelicula peli = new Pelicula(20);
            Cine cine = new Cine(200, peli);

            foreach (Espectador espectador in espectados)
            {
                if (espectador.Edad > cine.Peli.Edad)
                {
                    if (espectador.Dinero >= cine.Precio)
                    {
                        sala.ocuparRandom(espectador);
                        Console.WriteLine($"El asiento {sala.AsientoOcupados[cont]}");
                        Console.WriteLine("");
                        cont++;
                    }
                    else
                    {
                        Console.WriteLine($"{espectador.Nombre} dinero insuficiente");
                        Console.WriteLine("");
                    }
                }
                else
                {
                    Console.WriteLine($"{espectador.Nombre} no tiene la edad para la pelicula");
                    Console.WriteLine("");
                }
            }a
            sala.simulacion();
            Console.ReadKey();
        }
    }
}