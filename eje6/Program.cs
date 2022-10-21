using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio6
{

    public class Libro
    {

        string isbn;
        public string ISBN { get { return isbn; } set { this.isbn = value; } }

        string titulo;
        public string TITULO { get { return titulo; } set { this.titulo = value; } }
        string autor;
        public string AUTOR { get { return autor; } set { this.autor = value; } }
        int cantPaginas;
        public int CANTPAGINAS { get { return cantPaginas; } set { this.cantPaginas = value; } }

        public Libro(string isbn, string titulo, string autor, int cantPaginas)
        {
            this.isbn = isbn;
            this.titulo = titulo;
            this.autor = autor;
            this.cantPaginas = cantPaginas;

        }

        public void devolverInfo()
        {
            Console.WriteLine("El libro " + titulo + " con ISBN " + isbn + " por el autor " + autor + " tiene " + cantPaginas + " paginas");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Libro libro1 = new Libro("981293", "Mundo Gaturro", "Nik", 222);
            Libro libro2 = new Libro("777812", "It", "Stephen King", 389);



            libro1.devolverInfo();
            libro2.devolverInfo();

            if (libro1.CANTPAGINAS > libro2.CANTPAGINAS)
            {
                Console.WriteLine("El libro " + libro1.TITULO + " tiene mas paginas");
            }
            else
            {
                Console.WriteLine("El libro " + libro2.TITULO + " tiene mas paginas");
            }

            Console.ReadKey();
        }
    }
}
