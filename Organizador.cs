using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix
{
    class Organizador
    {
        Serie[] series;
        Lista[] listas;

        public Organizador()
        {
            series = new Serie[0];
            listas = new Lista[0];
        }

        public bool AgregarSerie(Serie serie)
        {
            // Buscamos si la serie ya fue agregada, según enunciado:
            // "se debe chequear que en el arreglo de series no exista otra serie con el mismo nombre, género y año"
            foreach(Serie serieGuardada in series)
            {
                if (serieGuardada.nombre == serie.nombre && serieGuardada.genero == serie.genero && serieGuardada.anio == serie.anio)
                {
                    // La serie ya está, retornamos false. Esto hará que la función finalice inmediatamente
                    return false;
                }
            }

            // Si llegamos aquí, quiere decir que la no existía otra serie con el mismo nombre. Debemos agregar la nueva serie.
            // Para esto, agrandamos nuestro arreglo "series" (le agregamos 1 elemento)
            Array.Resize(ref series, series.Length + 1);

            // Y colocamos la nueva serie al final del arreglo:
            series[series.Length - 1] = serie;
            return true;
        }

        public void VerSeries()
        {
            foreach(Serie serie in series)
            {
                Console.WriteLine(serie.Informacion());
            }
        }

        public Serie[] SeriesPorCriterio(string criterio, string valor)
        {
            Serie[] seriesFiltradas = new Serie[0];

            if (criterio != "nombre" && criterio != "género" && criterio != "año" && criterio != "calificación")
            {
                Console.WriteLine("Se ingreso un criterio no válido. Los criterios válidos son: nombre, género, año y calificación");
                return seriesFiltradas;
            }

            foreach(Serie serie in series)
            {
                bool agregarSerie = false;

                // Vemos si tenemos que agregar esta serie. Vamos criterio por criterio

                if (criterio == "nombre" && serie.nombre == valor)
                    agregarSerie = true;
                else if (criterio == "género" && serie.genero == valor)
                    agregarSerie = true;
                else if (criterio == "año" && serie.anio.ToString() == valor)
                    agregarSerie = true;
                else if (criterio == "calificación")
                {
                    float calificacion;
                    bool valorValido = float.TryParse(valor, out calificacion);
                    if (valorValido && calificacion <= serie.calificacion)
                        agregarSerie = true;
                }

                if (agregarSerie)
                {
                    Array.Resize(ref seriesFiltradas, seriesFiltradas.Length + 1);
                    seriesFiltradas[seriesFiltradas.Length - 1] = serie;
                }
            }

            return seriesFiltradas;
        }

        public bool GenerarLista(string criterio, string valorCriterio, string nombreLista)
        {
            foreach (Lista lista in listas)
                if (lista.nombre == nombreLista)
                {
                    Console.WriteLine("Ya existe una lista con ese nombre");
                    return false;
                }
            
            Serie[] seriesFiltradas = SeriesPorCriterio(criterio, valorCriterio);

            if (seriesFiltradas.Length == 0)
            {
                Console.WriteLine("No hay series que cumplan con tu criterio de búsqueda");
                return false;
            }

            Array.Resize(ref listas, listas.Length + 1);
            listas[listas.Length - 1] = new Lista(nombreLista, seriesFiltradas);
            return true;
        }

        public void VerMisListas()
        {
            foreach(Lista lista in listas)
                lista.VerLista();
        }
    }
}
