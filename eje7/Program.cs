using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eje7
{
    class raices
    {
        double a;
        double b;
        double c;

        public raices(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public void obtenerRaices()
        {

            double valor = this.b * this.b - 4 * (this.a) * (this.c);
            double x = Math.Sqrt(valor);

            if (x > 0)
            {
                double Positivo = (-(this.b) + (x)) / 2 * this.a;
                double Negativo = (-(this.b) - (x)) / 2 * this.a;

                Console.WriteLine("Raiz1 es:" + Positivo + "\n Raiz 2 es:" + Negativo);
            }

        }
        public void obtenerRaiz()
        {
            double valor = this.b * this.b - 4 * (this.a) * (this.c);
            double p1 = Math.Sqrt(valor);

            if (p1 == 0)
            {
                double valorCero = -(this.b) / 2 * this.a;
                Console.WriteLine("solo una raíz");

            }
        }
        public double getDiscriminante()
        {

            double discriminante = Math.Pow(this.b, 2) - 4 * (this.a) * (this.c);

            return discriminante;
        }
        public bool tieneRaices()
        {
            double valor = this.b * this.b - 4 * (this.a) * (this.c);
            double x = Math.Sqrt(valor);

            if (x >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool tieneRaiz()
        {

            double valor = this.b * this.b - 4 * (this.a) * (this.c);
            double x = Math.Sqrt(valor);

            if (x == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void calcular()
        {
            if (tieneRaices())
            {
                obtenerRaices();
            }
            else if (tieneRaiz())
            {
                obtenerRaiz();
            }
            else
            {
                Console.WriteLine("no tiene solucion");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            raices raiz = new raices(1, 5, 5);
            raiz.calcular();

            Console.ReadKey();
        }
    }
}