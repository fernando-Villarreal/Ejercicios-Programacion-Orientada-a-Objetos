using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ejercicio10
{
    internal class Ejercicio10
    {
         class Metodos
        {
            public static Random random = new Random();
            public static int randomNum(int minimo, int maximo)

            {
                int numero = random.Next(minimo, maximo);
                return numero;
            }

        }
         class Carta

        {
            int numero;
            string palo;
            public static int numeroMax = 12;
            public static string[] palos = { "Espada", "Oro", "Basto", "Copas" };

            public Carta(int numero, string palo)
            {
                this.numero = numero;
                this.palo = palo;
            }

        }

         class Baraja

        {
             Carta[] carta;
             int sigCarta;

            public static int cantCartas = 40;
            public Baraja()

            {
                this.carta = new Carta[cantCartas];
                this.sigCarta = 0;
                crearBaraja();
                barajar();

            }
            private void crearBaraja()

            {
                string[] palos = Carta.palos;

                for (int i = 0; i < palos.Length; i++)
                {
                    for (int j = 0; j < Carta.numeroMax; j++)
                    {
                        if (!(j == 7 || j == 8))

                        {
                            if (j >= 9)

                            {

                                carta[((i * (Carta.numeroMax - 2)) + (j - 2))] = new Carta(j + 1, palos[i]);

                            }

                            else

                            {

                                carta[((i * (Carta.numeroMax - 2)) + (j))] = new Carta(j + 1, palos[i]);

                            }

                        }

                    }

                }

            }
            public void barajar()

            {

                int posAleatoria = 0;

                Carta c;


                for (int i = 0; i < carta.Length; i++)

                {

                    posAleatoria = Metodos.randomNum(0, cantCartas - 1);

                    c = carta[i];

                    carta[i] = carta[posAleatoria];

                    carta[posAleatoria] = c;

                }

                this.sigCarta = 0;

            }
            public Carta siguienteCarta()

            {

                Carta c = null;


                if (sigCarta == cantCartas)

                {
                    Console.WriteLine("No quedan cartas, hay que barajar de nuevo");
                }
                else
                {

                    c = carta[sigCarta++];
                }

                return c;

            }


            public Carta[] darCartas(int numCartas)

            {
                if (numCartas > cantCartas)
                {

                    Console.WriteLine("No se pueden dar mas cartas");

                }
                else if (cartasDisponible() < numCartas)
                {

                    Console.WriteLine("No hay suficientes cartas");

                }
                else
                {

                    Carta[] DarCartas = new Carta[numCartas];

                    for (int i = 0; i < DarCartas.Length; i++)

                    {

                        DarCartas[i] = siguienteCarta();

                    }
                    return DarCartas;
                }
                return null;
            }

            public int cartasDisponible()

            {
                return cantCartas - sigCarta;
            }

            public void cartasMonton()

            {
                if (cartasDisponible() == cantCartas)
                {
                    Console.WriteLine("No se ha sacado ninguna carta");
                }

                else
                {
                    int cantCartitas = 0;
                    for (int i = 0; i < sigCarta; i++)
                    {
                        cantCartitas++;
                    }
                    Console.WriteLine(cantCartitas);
                }
            }

            public void mostrarBaraja()

            {
                if (cartasDisponible() == 0)
                {
                    Console.WriteLine("No hay cartas que mostrar");
                }
                else
                {

                    for (int i = sigCarta; i < carta.Length; i++)
                    {
                        Console.WriteLine(carta[i]);

                    }
                }
            }
        }

        static void Main(string[] args)

        {

            int Cartas = 0;
            Baraja b = new Baraja();
            Carta[] c = b.darCartas(10);
            Console.WriteLine("Hay cartas disponibles: " + b.cartasDisponible());
            b.siguienteCarta();
            b.darCartas(5);
            Console.WriteLine("Hay cartas disponibles: " + b.cartasDisponible());
            Console.WriteLine("Cartas sacadas por ahora: ");
            b.cartasMonton();
            b.barajar();
           
            Console.WriteLine("Cartas sacadas despues de barajar: ");       

            for (int i = 0; i < c.Length; i++)
            {
                Cartas++;
            }
            Console.WriteLine(Cartas);
            Console.ReadKey();

        }

    }

}