using System;
using Biblioteca;

namespace SistemaTransporte
{
    class Program
    {
        static void Main(string[] args)
        {
            MapaTransporte mapa = new MapaTransporte(10, 10);
            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("Sistema de Transporte");
                Console.WriteLine("1. Agregar Parada");
                Console.WriteLine("2. Agregar Calle");
                Console.WriteLine("3. Mostrar Mapa");
                Console.WriteLine("4. Recorrer Paradas");
                Console.WriteLine("5. Eliminar Parada");
                Console.WriteLine("6. Salir");
                Console.Write("Seleccione una opción: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.Write("Ingrese coordenada X (0-9): ");
                            int x = int.Parse(Console.ReadLine());
                            Console.Write("Ingrese coordenada Y (0-9): ");
                            int y = int.Parse(Console.ReadLine());
                            mapa.AgregarParada(x, y);
                            break;

                        case 2:
                            Console.Write("Ingrese coordenada X (0-9): ");
                            x = int.Parse(Console.ReadLine());
                            Console.Write("Ingrese coordenada Y (0-9): ");
                            y = int.Parse(Console.ReadLine());
                            mapa.AgregarCalle(x, y);
                            break;

                        case 3:
                            Console.WriteLine("\nMapa Actual:");
                            mapa.MostrarMapa();
                            Console.WriteLine("\nP = Parada");
                            Console.WriteLine("C = Calle");
                            Console.WriteLine("□ = Vacío");
                            Console.WriteLine("\nPresione cualquier tecla para continuar...");
                            Console.ReadKey();
                            break;

                        case 4:
                            Console.WriteLine("\nRecorrido de Paradas:");
                            mapa.RecorrerParadas();
                            Console.WriteLine("\nPresione cualquier tecla para continuar...");
                            Console.ReadKey();
                            break;

                        case 5:
                            Console.Write("Ingrese coordenada X de la parada a eliminar: ");
                            x = int.Parse(Console.ReadLine());
                            Console.Write("Ingrese coordenada Y de la parada a eliminar: ");
                            y = int.Parse(Console.ReadLine());
                            mapa.EliminarParada(x, y);
                            Console.WriteLine("Parada eliminada si existía en esa ubicación");
                            Console.WriteLine("\nPresione cualquier tecla para continuar...");
                            Console.ReadKey();
                            break;
                    }
                }
            } while (opcion != 6);
        }
    }
}