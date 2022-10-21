using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1 //EJERCICIO 1 por Luciano Scerbo y Fernandios Villarreal hecho en clase.
{
    public class Cuenta
    {
        private string titular;
        private double cantidad;

        public Cuenta(string titular)
        {
            this.titular = titular;


        }
        public Cuenta(string titular, double cantidad)
        {
            this.titular = titular;
            if (cantidad < 0)
            {
                this.cantidad = 0;
            }
            else
            {
                this.cantidad = cantidad;
            }

        }
        public string getTitular()
        {
            return titular;
        }
        public void setTitular(string titular)
        {
            this.titular = titular;
        }
        public double getCantidad()
        {
            return cantidad;
        }
        public void setCantidad(double cantidad)
        {
            this.cantidad = cantidad;
        }

        //meter plata en la cuenta
        public void ingresar(double cantidad)
        {
            if (cantidad >
                0)
            {
                this.cantidad += cantidad;
            }
        }

        //sacar plata
        public void retirar(double cantidad)
        {
            if (this.cantidad - cantidad < 0)
            {
                this.cantidad = 0;
            }
            else
            {
                this.cantidad -= cantidad;
            }
        }
        public override string ToString()
        {
            return "El titular " + titular + " tiene $" + cantidad + " en la cuenta";
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Cuenta cuenta1 = new Cuenta("Luciano");
            Cuenta cuenta2 = new Cuenta("Fernando", 1000);

            //Ingresar $$$
            cuenta1.ingresar(100);
            cuenta2.ingresar(500);

            cuenta1.retirar(500);
            cuenta2.retirar(100);

            Console.WriteLine(cuenta1);
            Console.WriteLine(cuenta2);
            Console.ReadKey();
        }
    }
}