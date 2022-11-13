using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eje8
{
    public class Persona
    {
        public string nombre;
        public int edad;
        public char sexo;
        public string[] nombreHom = {"Julio", "Alberto" , "Marcos" , "Pablo" , "Fernando","Luciano",};
        public string[] nombreMuj = {"Magdalena", "Sofia", "Milena", "Julieta", "Miria", "Marta", };


        public Persona(string nombre, int edad, char sexo)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.sexo = sexo;
            
        }
        public Persona(char sexo)
        {
            this.sexo = sexo;

        }


      

        static Random rnd = new Random();
        



        public string Nombre { get { return this.nombre; } set { this.nombre = value; } }
        public int Edad { get { return this.edad; } set { this.edad = value; } }
        public char Sexo { get { return this.sexo; } set { this.sexo = value; } }
    }


    class Estudiantes : Persona
    {
        public int calificacion_actual;
        

        public Estudiantes(string nombre, int edad, char sexo, int calificacion_actual) : base(nombre, edad, sexo)
        {
            Nombre = nombre;
           
                if (edad >= 7 && edad <= 19 && calificacion_actual >= 1 && calificacion_actual <= 10)
                {
                    Edad = edad;
                this.calificacion_actual = calificacion_actual;              
                }
                else
                {
                    Console.WriteLine(nombre + " Eres demasiado joven o viejo para ser estudiante o tu calificacion es menor a 1 o mayor a 10 ");                   
                }
           

            Sexo = sexo;
           


            
        }

        static Random rndEdad = new Random();
        static Random rndNom = new Random();
        public Estudiantes(char sexo) : base(sexo)
        {
            Sexo = sexo;
            var SEXO = sexo.ToString();
            if (SEXO == "H")
            {
                int Nom = rndNom.Next(nombreHom.Length);

                this.Nombre = nombreHom[Nom];

            }
            else if (SEXO == "M")
            {
                int Nom = rndNom.Next(nombreMuj.Length);
                ;
                this.Nombre = nombreMuj[Nom];
            }
            
            this.Edad = rndEdad.Next(7, 19);
            this.calificacion_actual = rndEdad.Next(0, 11);
            

        }



        public int Calificacion_actual
        {
            get
            {
                return this.calificacion_actual;
            }
            set
            {
                this.calificacion_actual = value;
            }
        }

       

        static Random rnd = new Random();
        public  bool disponibilidad()
        {
            
            int x = rnd.Next(0, 2);

            if (x == 1)
            {
                
                return true;          
            }
            else
            {
                

            }
            return false;
           
          
        }
        public void darInfo()
        {

             Console.WriteLine("Nombre: {0} \n Edad: {1} \n Sexo: {2} \n Nota: {3}", this.Nombre,this.Edad, this.Sexo, this.calificacion_actual);
        }
    }

    class Profesores : Persona
    {
        private string materia;

        public Profesores(string nombre, int edad, char sexo, string materia) : base(nombre, edad, sexo)
        {
            Nombre = nombre;
            Edad = edad;
            Sexo = sexo;
            this.materia = materia;
        }

   

        public string Materia
        {
            get
            {
                return this.materia;
            }
            set
            {
                this.materia = value;
            }
        }
        static Random rnd = new Random();
        public  bool disponibilidad()
        {

            var posibilidad = rnd.Next(1, 101);

            if (posibilidad > 20)
            {
                
                return true;            
            }
            else
            {
                return false;
            }
        }
    }
    class Aula
    {
        int id;
        private Profesores profesor;
        private Estudiantes[] alumnos;
        string materia;
        const int MAX_ALUMNOS = 20;

        public Aula(int id, Profesores profesor, Estudiantes[] alumnos, string materia, int MAX_ALUMNOS)
        {
            this.id = id;
            this.profesor = profesor;
            this.alumnos = alumnos;
            this.materia = materia;
        }

        private bool van_alumnos()
        {
            int contador = 0;
            for (int i = 0; i < alumnos.Length; i++)
            {
                if (alumnos[i].disponibilidad())
                {
                    contador++;
                }
            }
            if (contador > alumnos.Length / 2)
            {
               
                return true;
            }
            else{return false;}
            
        }
        public bool dar_clase()
        {
             if (van_alumnos() == true && profesor.disponibilidad() == true && profesor.Materia == this.materia)
            {
                Console.WriteLine("Viene el profe");
                return true;
            }
            else
            {
                Console.WriteLine("No Viene el profe");
                return false;               
            }

        }
        public void notas()
        {
            int contador_H = 0;
            int contador_M = 0;

            for (int i = 0; i < alumnos.Length; i++)
            {
                if (alumnos[i].Calificacion_actual >= 6 && alumnos[i].Sexo == 'H')
                {

                    contador_H++;
                }

                if (alumnos[i].Calificacion_actual >= 6 && alumnos[i].Sexo == 'M')
                {
                    contador_M++;
                }
            }
             Console.WriteLine("Hay {0} alumnos aprobados y {1} chicas aprobadas", contador_H, contador_M);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Profesores profesor = new Profesores("Pablo", 25, 'M', "Matematica");

            Estudiantes[] alumnos = new Estudiantes[8];
            alumnos[0] = new Estudiantes("Luciano Scerbo", 17, 'H', 8);
            alumnos[1] = new Estudiantes("Fernando Villarreal", 18, 'H', 6);
            alumnos[2] = new Estudiantes('H');
            alumnos[3] = new Estudiantes('M');
            alumnos[4] = new Estudiantes("Lucas Rodriguez" , 22 , 'H' , 12);
            alumnos[5] = new Estudiantes("Milagros Ferreyra", 18, 'M', 6);
            alumnos[6] = new Estudiantes("Sofia Merchuchi", 18, 'M', 6);
            alumnos[7] = new Estudiantes("Luisa Luison", 18, 'M', 6);

            Aula aula = new Aula(1, profesor, alumnos, "Matematica", 20);

            alumnos[2].darInfo();
            //* alumnos[1].disponibilidad();
            //* profesor.disponibilidad();
            

            if (aula.dar_clase() == true)
            {
                aula.notas();

            }
            
        


           Console.ReadKey();
        }

    }
}

