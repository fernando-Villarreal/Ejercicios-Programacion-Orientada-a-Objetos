using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio12
{
    internal class Program
    {
       class Empleado
        {
            string nombre;
            int edad;
            double salario;
            int plus = 300;

            public string NOMBRE { get { return nombre; } set { this.nombre = value; } }
            public int EDAD { get { return edad; } set { this.edad = value; } }
            public double SALARIO { get { return salario; } set { this.salario = value; } }

            public int PLUS { get { return plus; } }

            public Empleado(string nombre, int edad, double salario)
            {
                this.nombre = nombre;
                this.edad = edad;
                this.salario = salario;
               // this.plus = plus;
            }

      
        }

        class Comercial : Empleado
        {
            double comision;
            public double COMISION { get { return comision; } set { this.comision = value; } }
        
            public Comercial(string nombre, int edad, double salario,/*int plus*/ double comision ) : base ( nombre , edad, salario/*, plus*/)
            {
                this.comision = comision;
            }

            public bool AgregarPlus()
            {
                if(EDAD > 30 && COMISION > 200)
                {
                    double NuevoSalario = SALARIO + PLUS;
                    SALARIO = NuevoSalario;
                    Console.WriteLine("El  salario con el plus es de: $" + SALARIO);
                    return true;

                }
                else
                {
                    Console.WriteLine("El salario básico es : $" + SALARIO);
                    return false;
                }
            }

        }

        class Repartidor : Empleado
        {
            string zona;
            public string ZONA { get { return zona; } set { this.zona = value; } }

            public Repartidor(string nombre, int edad, double salario /*int plus*/, string zona) : base(nombre, edad, salario /*, plus*/)
            {
                this.zona = zona;
            }

            public bool AgregarPlus()
            {
                if (EDAD < 25 && zona == "zona 3")
                {
                    double NuevoSalario = SALARIO + PLUS;
                    SALARIO = NuevoSalario;
                    Console.WriteLine("El  salario con el plus es de: $" + SALARIO);
                    return true;

                }
                else
                {
                    SALARIO = SALARIO;
                    Console.WriteLine("El salario básico es: "+ SALARIO);
                    return false;
                }
            }
        }
    



        static void Main(string[] args)
        {
            Comercial comercial1 = new Comercial("Fernando", 35, 500, 400);
            Repartidor repartidor1 = new Repartidor("Luciano", 17, 300, "zona 3");
            Repartidor repartidor2 = new Repartidor("Pablo", 45, 900, "zona 1");


            var x = comercial1.AgregarPlus();
           var y = repartidor1.AgregarPlus();
            var z = repartidor2.AgregarPlus();

            Console.WriteLine(x);
            Console.WriteLine(y);
            Console.WriteLine(z);
            Console.ReadKey();
        }
    }
}
