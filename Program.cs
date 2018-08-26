using System;

namespace Netflix
{
    class Program
    {
        public static string PedirString(string explicacion)
        {
            string valor = "";
            bool valido = false;
            while (!valido)
            {
                Console.WriteLine(explicacion);
                valor = Console.ReadLine();
                if (valor.Trim() != "")
                    valido = true;
                else
                    Console.WriteLine("Debes ingresar un valor válido");
            }
            return valor;
        }

        public static int PedirInt(string explicacion)
        {
            int valor = 0;
            bool valido = false;
            while (!valido)
            {
                Console.WriteLine(explicacion);
                valido = int.TryParse(Console.ReadLine(), out valor);
                if (!valido)
                    Console.WriteLine("Ingresa un año válido");
            }
            return valor;
        }

        public static float PedirFloat(string explicacion)
        {
            float valor = 0;
            bool valido = false;
            while (!valido)
            {
                Console.WriteLine(explicacion);
                valido = float.TryParse(Console.ReadLine(), out valor);
                if (!valido)
                    Console.WriteLine("Ingresa una calificación válida");
            }
            return valor;
        }

        public static void ComandosDisponibles()
        {
            Console.WriteLine("\nLos comandos disponibles son:");
            Console.WriteLine("1: Agregar serie");
            Console.WriteLine("2: Ver series");
            Console.WriteLine("3: Ver series por criterio");
            Console.WriteLine("4: Crear lista");
            Console.WriteLine("5: Ver mis listas");
            Console.WriteLine("0: Salir del programa\n");
        }

        public static void Main(string[] args)
        {
            Organizador organizador = new Organizador();
            organizador.AgregarSerie(new Serie("Stranger Things", "ciencia ficción", 2016, 8.9f));
            organizador.AgregarSerie(new Serie("Sense8", "ciencia ficción", 2016, 7f));
            organizador.AgregarSerie(new Serie("Game of Thrones", "literatura", 2014, 8.9f));
            organizador.AgregarSerie(new Serie("Vikings", "literatura", 2016, 5f));
            organizador.AgregarSerie(new Serie("Tabula Rasa", "ciencia ficción", 2013, 4f));
            bool cerrarPrograma = false;
            Console.WriteLine("Bienvenido a tu Organizador de series Netflix!");
            while (!cerrarPrograma)
            {
                ComandosDisponibles();
                string comando = Console.ReadLine();
                if (comando == "1") {
                    string nombre = PedirString("Ingresa el nombre de la serie");
                    string genero = PedirString("Ingresa el género de la serie:");
                    int anio = PedirInt("Ingresa el año de la serie:");
                    float calificacion = PedirFloat("Ingresa la calificación:");
                    Serie serie = new Serie(nombre, genero, anio, calificacion);
                    if (organizador.AgregarSerie(serie))
                    {
                        Console.WriteLine("Serie agregada existosamente.");
                    }
                } else if (comando == "2") {
                    organizador.VerSeries();
                } else if (comando == "3") {
                    string criterio = PedirString("Ingresa un criterio (nombre, género, año, calificación)");
                    string valor = PedirString("Ingresa un valor para el criterio");
                    Serie[] series = organizador.SeriesPorCriterio(criterio, valor);
                    if (series.Length == 0)
                        Console.WriteLine("No se encontraron series");
                    foreach (Serie serie in series)
                        Console.WriteLine(serie.Informacion());
                } else if (comando == "4") {
                    string nombre = PedirString("Ingresa un nombre para la lista:");
                    string criterio = PedirString("Ingresa un criterio (nombre, género, año, calificación)");
                    string valor = PedirString("Ingresa un valor para el criterio");
                    if (organizador.GenerarLista(criterio, valor, nombre))
                        Console.WriteLine("Lista generada exitosamente.");
                } else if (comando == "5") {
                    organizador.VerMisListas();
                } else if (comando == "0") {
                    cerrarPrograma = true;
                } else {
                    Console.WriteLine("Ingresaste un comando desconocido.");
                    ComandosDisponibles();
                }
            }
        }
    }
}
