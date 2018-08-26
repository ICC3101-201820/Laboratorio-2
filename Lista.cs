using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix
{
    class Lista
    {
        public string nombre;
        private Serie[] series;

        public Lista(string nombre, Serie[] series)
        {
            this.nombre = nombre;
            this.series = series;
        }

        public void VerLista()
        {
            Console.WriteLine("\nLista: " + nombre);
            Console.WriteLine("Esta lista tiene " + series.Length + " series:");
            foreach (Serie serie in series)
                Console.WriteLine(serie.Informacion());
        }
    }
}
