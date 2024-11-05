using System;
using Biblioteca;

namespace SistemaTransporte
{
    public class MapaTransporte
    {
        private Nodo[,] mapa;
        private Nodo paradaActual;
        private int ancho;
        private int alto;

        public MapaTransporte(int ancho, int alto)
        {
            this.ancho = ancho;
            this.alto = alto;
            mapa = new Nodo[ancho, alto];
        }

        public void AgregarParada(int x, int y)
        {
            var datosParada = new { X = x, Y = y, Tipo = "Parada" };
            Nodo nuevaParada = new Nodo(datosParada);

            if (paradaActual == null)
            {
                paradaActual = nuevaParada;
                paradaActual.Enlace = paradaActual;
            }
            else
            {
                nuevaParada.Enlace = paradaActual.Enlace;
                paradaActual.Enlace = nuevaParada;
            }

            mapa[x, y] = nuevaParada;
        }

        public void AgregarCalle(int x, int y)
        {
            var datosCalle = new { X = x, Y = y, Tipo = "Calle" };
            mapa[x, y] = new Nodo(datosCalle);
        }

        public void MostrarMapa()
        {
            for (int i = 0; i < alto; i++)
            {
                for (int j = 0; j < ancho; j++)
                {
                    if (mapa[j, i] == null)
                        Console.Write("□ ");
                    else if (((dynamic)mapa[j, i].Dato).Tipo == "Parada")
                        Console.Write("P ");
                    else
                        Console.Write("C ");
                }
                Console.WriteLine();
            }
        }

        public void RecorrerParadas()
        {
            if (paradaActual == null)
            {
                Console.WriteLine("No hay paradas en el mapa");
                return;
            }

            Nodo actual = paradaActual;
            do
            {
                dynamic datos = actual.Dato;
                Console.WriteLine($"Parada en ({datos.X}, {datos.Y})");
                actual = actual.Enlace;
            } while (actual != paradaActual);
        }

        public void EliminarParada(int x, int y)
        {
            if (mapa[x, y] == null) return;

            Nodo actual = paradaActual;
            Nodo anterior = null;

            do
            {
                dynamic datosActual = actual.Enlace.Dato;
                if (datosActual.X == x && datosActual.Y == y)
                {
                    if (actual.Enlace == paradaActual)
                    {
                        if (actual == paradaActual)
                            paradaActual = null;
                        else
                        {
                            paradaActual = actual;
                            paradaActual.Enlace = paradaActual;
                        }
                    }
                    else
                    {
                        actual.Enlace = actual.Enlace.Enlace;
                        if (actual.Enlace == paradaActual)
                            paradaActual = actual;
                    }
                    mapa[x, y] = null;
                    return;
                }
                anterior = actual;
                actual = actual.Enlace;
            } while (actual != paradaActual);
        }
    }
}