using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercccccccio
{
    interface Entregable
    {
        void entregar();
        void devolver();
        bool isEntregado();
        Entregable compareTo(Entregable e);

    }


    class videojuego : Entregable
    {

        string titulo = "";
        int horasEstimadas = 10;
        public bool entregado = false;
        string compania = "";

        public string TITULO { get { return titulo; } set { titulo = value; } }

        public int HORASESTIMADAS { get { return horasEstimadas; } set { horasEstimadas = value; } }


        public string COMPANIA { get { return compania; } set { compania = value; } }







        public videojuego()
        {
        }
        public videojuego(string titulo, int horasEstimadas)
        {
            TITULO = titulo;
            HORASESTIMADAS = horasEstimadas;
        }

        public videojuego(string titulo, int horasEstimadas, string compania)
        {
            TITULO = titulo;
            HORASESTIMADAS = horasEstimadas;
            COMPANIA = compania;
        }

        public void entregar()
        {
            entregado = true;
        }
        public bool isEntregado()
        {
            return entregado;
        }
        public void devolver()
        {
            entregado = false;

        }


        public Entregable compareTo(Entregable a)
        {

            if (a is videojuego)
            {
                videojuego z = (videojuego)a;

                if (z.HORASESTIMADAS > this.horasEstimadas)
                {
                    return z;

                }
                else
                {
                 

                }
            }
            else if (a is serie)
            {
                serie z = (serie)a;
                if (z.TEMPORADA > this.horasEstimadas)
                {
                    return z;

                }
                else
                {

                    return this;
                }
            }
            return null;

        }





    }

    class serie : Entregable
    {
        string titulo = "";
        int temporada = 3;
        public bool entregado = false;
        string genero = "";
        string creador = "";


        public string TITULO { get { return titulo; } set { titulo = value; } }

        public int TEMPORADA { get { return temporada; } set { temporada = value; } }

        public string GENERO { get { return genero; } set { genero = value; } }
        public string CREADOR { get { return creador; } set { creador = value; } }







           public serie()
                {

                }
           public serie(string titulo, string creador)
                {
                    TITULO = titulo;
                    CREADOR = creador;
                }
           public serie(string titulo, int temporada, string genero, string creador)
               {
                    TITULO = titulo;
                    TEMPORADA = temporada;
                    GENERO = genero;
                    CREADOR = creador;
               }
                 public void entregar()
                            {
                                entregado = true;
                            }
                  public bool isEntregado()
                        {
                            return entregado;
                        }
                 public void devolver()
                        {
                            entregado = false;
                        }
            public Entregable compareTo(Entregable a)
                        {

                            if (a is videojuego)
                            {
                                videojuego z = (videojuego)a;

                                if (z.HORASESTIMADAS > this.TEMPORADA)
                                {
                                    return z;
                                }
                                else{ }
                            }
                            else if (a is serie)
                            {
                                serie s = (serie)a;
                                if (s.TEMPORADA > this.TEMPORADA)
                                {
                                    return s;
                                }
                                else {  }
                            }
                            return null;
                        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            List<serie> serie = new List<serie>();
            List<videojuego> videojuegos = new List<videojuego>();
            int videojue = 0;
            string NomVideoMasJugado = " ";
            int serietem = 0;
            string NomSerieMasJugado = " ";
            int entregadosS = 0;
            int entregadosJ = 0;



            videojuego j1 = new videojuego();
            videojuegos.Add(j1);
            videojuego j2 = new videojuego("minecraft", 200);
            videojuegos.Add(j2);
            videojuego j3 = new videojuego("League of Legends", 10000, "Riot Games");
            videojuegos.Add(j3);
            videojuego j4 = new videojuego("Fortnite", 200000, "AFEL TECH");
            videojuegos.Add(j4);
            videojuego j5 = new videojuego("FLY", 540);
            videojuegos.Add(j5);

            serie s1 = new serie();
            serie.Add(s1);
            serie s2 = new serie("Friends", 10, "comedia", "Family studios");
            serie.Add(s2);
            serie s3 = new serie("Breaking Bad", 6, "ciencia ficcion", "Mobile Studios");
            serie.Add(s3);
            serie s4 = new serie("Grey's Anatomy", "Medic studios");
            serie.Add(s4);
            serie s5 = new serie("Vikingos", "Nordic Studios");
            serie.Add(s5);

            j1.entregar(); //este solo tienen el por defecto
            j3.entregar();
            j4.entregar();
            j5.entregar();
            s1.entregar(); //este solo tienen el por defecto
            s2.entregar();
            j5.devolver();



            foreach (videojuego videojuego in videojuegos)
            {

                if (videojuego.HORASESTIMADAS > videojue)
                {
                    videojue = videojuego.HORASESTIMADAS;
                    NomVideoMasJugado = videojuego.TITULO;
                }
                else { }
                if (videojuego.entregado == true)
                {
                    entregadosJ++;

                }
                else { }
            }
            foreach (serie series in serie)
            {

                if (series.TEMPORADA > serietem)
                {
                    serietem = series.TEMPORADA;
                    NomSerieMasJugado = series.TITULO;
                }
                else { }
                if (series.entregado == true)
                {
                    entregadosS++;

                }
                else { }


            }

            var comparacion = j1.compareTo(s2);


            Console.WriteLine("Se entregaron: " + entregadosS + " series");
            Console.WriteLine("Se entregaron: " + entregadosJ + " juegos");
            Console.WriteLine("El juego con mas horas es: " + NomVideoMasJugado + " con: " + videojue + " horas");
            Console.WriteLine("La serie con mas temporadas: " + NomSerieMasJugado + " con: " + serietem + " temporadas");
            Console.WriteLine(comparacion);



            
            Console.ReadKey();

        }
    }
}