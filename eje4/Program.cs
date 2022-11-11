using System;
using System.Runtime.CompilerServices;

namespace eje4
{
    class Electrodomestico
    {
        string color = "Blanco";
        char consumo_energetico = 'F';
        int peso = 5;
        int precio_base = 100;

        public int PRECIOBASE { get { return this.PRECIOBASE; } set { this.precio_base = value; } }
        public string COLOR { get { return this.COLOR; } set { this.color = value; } }
        public char CONSUMO { get { return this.CONSUMO; } }
        public int PESO { get { return this.PESO; } set { this.PESO = value; } }


        public Electrodomestico()
        {

        }
        public Electrodomestico(int peso, int precio_base)
        {
            this.peso = peso;
            this.precio_base = precio_base;
        }
        public Electrodomestico(int precio, string color, int peso, char consumo_energetico)
        {
            this.precio_base = precio;
            this.peso = peso;
            comprobarConsumoEnergetico(consumo_energetico);
            comprobarColor(color);
        }

        private char comprobarConsumoEnergetico(char letra)
        {
            return ((int)letra >= 65 && (int)letra <= 70) ? letra : 'F';

        }

        private void comprobarColor(string color)
        {
            string[] coloresPos = { "Blanco", "Negro", "Rojo", "Azul", "Gris" };
            bool comprobado = false;

            for (int i = 0; i < coloresPos.Length && !comprobado; i++)
            {
                if (coloresPos[i].Equals(color))
                {
                    comprobado = true;
                }
            }
            if (comprobado)
            {
                this.color = color;
            }
            else
            {
                this.color = "Blanco";
            }
        }
        public int PrecioFinal()
        {
            int precio = precio_base;
            switch (this.consumo_energetico)
            {
                case 'A':
                    precio_base += 100;
                    break;
                case 'B':
                    precio_base += 80;
                    break;
                case 'C':
                    precio_base += 60;
                    break;
                case 'D':
                    precio_base += 50;
                    break;
                case 'E':
                    precio_base += 30;
                    break;
                case 'F':
                    precio_base += 10;
                    break;
            }

            if (this.peso > 0 && this.peso < 19)
            {
                this.peso += 10;
            }
            else if (this.peso > 20 && this.peso < 49)
            {
                this.peso += 50;
            }
            else if (this.peso > 50 && this.peso < 79)
            {
                this.peso += 80;
            }
            else if (this.peso > 80)
            {
                this.peso += 100;
            }

            return precio;
        }
    }
    class Lavadora : Electrodomestico
    {
        int carga = 5;
        public int CARGA { get { return this.carga; } }
        public Lavadora()
        {

        }

        public Lavadora(int precio, int peso) : base(peso, precio)
        {

        }
        public Lavadora(int precio, string color, int peso, char consumo_energetico, int carga) : base(peso, color, peso, consumo_energetico)
        {
            this.carga = carga;
        }


        public int precioFinal()
        {
            int precio = base.PrecioFinal();
            if (this.carga > 30)
            {
                precio += 50;
            }
            return precio;
        }
    }

    class Television : Electrodomestico
    {
        float resolucion = 20;
        bool sintonizador = false;
        public float Resolucion { get { return this.resolucion; } }
        public bool Sintonizador { get { return this.sintonizador; } }

        public Television() : base()
        {

        }
        public Television(int peso, int precio) : base(peso, precio)
        {

        }
        public Television(int precio, string color, int peso, char consumo_energetico, float resolucion, bool sintonizador) : base(precio, color, peso, consumo_energetico)
        {
            this.sintonizador = sintonizador;
            this.resolucion = resolucion;
        }


        public int precioFinal()
        {
            int precio = base.PrecioFinal();
            if (this.sintonizador)
            {
                precio += 50;
            }
            if (this.resolucion > 40)
            {
                precio = precio + ((precio * 30) / 100);
            }
            return precio;
        }


    }

    class Program
    {
        static void Main(string[] args)
        {

            int televisores = 0;
            int lavarropas = 0;
            int electrodomesticosTotales = 0;

            Electrodomestico[] electrodomesticos = new Electrodomestico[10];
            electrodomesticos[0] = new Television();
            electrodomesticos[1] = new Lavadora(200, 60);
            electrodomesticos[2] = new Television(11, "Negro", 35, 'B', 20, true);
            electrodomesticos[3] = new Lavadora(80, "Blanco", 30, 'A', 25);
            electrodomesticos[4] = new Lavadora();
            electrodomesticos[5] = new Television();
            electrodomesticos[6] = new Television(20, 70);
            electrodomesticos[7] = new Lavadora(150, 30);
            electrodomesticos[8] = new Lavadora();
            electrodomesticos[9] = new Television(98, "Azul", 65, 'D', 43, false);


            foreach (Electrodomestico e in electrodomesticos)
            {
                electrodomesticosTotales++;
                e.PrecioFinal();
                if (e is Television)
                {
                    televisores++;
                }
                if (e is Lavadora)
                {
                    lavarropas++;
                }

            }
            Console.WriteLine("Hay: " + televisores + " televisores");
            Console.WriteLine("Hay: " + lavarropas + " lavarropas");
            Console.WriteLine("Hay: " + electrodomesticosTotales + " electrodomesticos en total");

            Console.ReadKey();
        }
    }
}