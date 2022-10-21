using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio2 //Fernando Villarreal y Luciano Scerbo
{
    internal class Program
    {

        class persona
        {
            string nombre;
            int edad;
            int dni;
            string sexo;
            int peso;
            double altura;




            public string Nombre { get { return nombre; } set { this.nombre = value; } }
            public int Edad { set { this.edad = value; } get { return edad; } }

            public int Dni { set { this.dni = value; } get { return dni; } }


            public string Sexo { set { this.sexo = value; } get { return sexo; } }


            public int Peso { set { this.peso = value; } get { return peso; } }

            public double Altura { set { this.altura = value; } get { return altura; } }


            public persona()
            {
            }


            public persona(string nombre, int edad, string sexo)
            {
                this.nombre = nombre;
                this.edad = edad;
                this.sexo = sexo;
            }

            public persona(string nombre, int edad, int dni, string sexo, int peso, double altura)
            {
                this.nombre = nombre;
                this.edad = edad;
                this.dni = dni;
                this.sexo = sexo;
                this.peso = peso;
                this.altura = altura;
            }



            public double resultado()
            {
                double resultado = Peso / (Math.Pow(altura, 2));

                return resultado;
            }



            public int calcularIMC()
            {
                double resultado = peso / (altura * altura);

                int IMC = 0;

                if (resultado < 20)
                {
                    IMC = -1;
                    return IMC;

                }
                if (resultado >= 20 && resultado <= 25)
                {
                    IMC = 0;
                    return IMC;
                }
                else
                { // amo los perritos <3
                    IMC = 1;
                    return IMC;
                }
            }



            public bool esMayor()
            {
                bool devolver = false;
                if (edad >= 18)
                {
                    devolver = true;
                    return devolver;
                }
                else
                {
                    devolver = false;
                    return devolver;
                }
            }


            public bool ComprobarSexo()
            {


                bool sexoB = false;
                if (sexo == "H" || sexo == "h")
                {
                    sexoB = false;
                    return sexoB;

                }
                else if (sexo == "M" || sexo == "m")
                {


                    sexoB = true;
                    return sexoB;
                }
                else
                {
                    sexoB = false;
                    return sexoB;


                }



            }



            public void InfoObj()
            {

                Console.WriteLine("----------------------------");

                Console.WriteLine("Nombre: " + this.nombre);
                Console.WriteLine("Edad: " + this.edad + " Años");
                Console.WriteLine("Peso: " + this.peso + " KG");
                Console.WriteLine("Altura: " + this.altura + " Metros");
                Console.WriteLine("DNI: " + this.dni + " dni");
                var compedad = esMayor();

                if (compedad)
                {
                    Console.WriteLine(this.nombre + " es mayor ");
                }
                else
                {
                    Console.WriteLine(this.nombre + " es menor ");
                }
                var compsexo = ComprobarSexo();
                if (compsexo)
                {
                    Console.WriteLine("Es mujer");
                }
                else { Console.WriteLine("Es hombre"); }

                var compIMC = calcularIMC();
                if (compIMC == 0) { Console.WriteLine(this.nombre + " esta en su peso ideal"); }
                if (compIMC == 1) { Console.WriteLine(this.nombre + " esta en sobrepeso"); }
                if (compIMC == -1) { Console.WriteLine(this.nombre + " esta en infrapeso"); }



            }






        }


        static void Main(string[] args)
        {

            persona per1 = new persona();
            persona per4 = new persona();



            Console.Write("Ingrese nombre: ");
            per1.Nombre = (Console.ReadLine());



            Console.Write("Ingrese su edad: ");
            per1.Edad = (int.Parse(Console.ReadLine()));

            Console.Write("Ingrese su peso en KG: ");
            per1.Peso = (int.Parse(Console.ReadLine()));

            Console.Write("Ingrese su altura en metros: ");
            per1.Altura = (double.Parse(Console.ReadLine()));

            Console.Write("Ingrese H si es hombre o M si es mujer: ");
            per1.Sexo = (Console.ReadLine());


            persona per2 = new persona("Juan", 19, "H");
            persona per3 = new persona("Virginia", 16, 45235120, "M", 64, 1.70);



            per4.Nombre = "angela";
            per4.Edad = 16;
            per4.Peso = 120;
            per4.Altura = 1.90;
            per4.Dni = 12345678;
            per4.Sexo = "M";

            per1.InfoObj();
            per2.InfoObj();
            per3.InfoObj();
            per4.InfoObj();







            Console.ReadKey();






        }
    }
}