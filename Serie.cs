using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix
{
    class Serie
    {
        public string nombre;
        public string genero;
        public int anio;
        public float calificacion;

        public Serie(string nombre, string genero, int anio, float calificacion)
        {
            this.nombre = nombre;
            this.genero = genero;
            this.anio = anio;
            this.calificacion = calificacion;
        }

        public string Informacion()
        {
            return $"género: {genero}, calificación: {calificacion}, año: {anio}, nombre: {nombre}";
        }
    }
}
