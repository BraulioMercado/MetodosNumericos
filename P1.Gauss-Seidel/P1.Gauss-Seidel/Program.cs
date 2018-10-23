using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1.Gauss_Seidel
{
    class Program
    {
        public static void Main(string[] args)
        {
            int filas;
            int columnas;
            int ite;
            Console.WriteLine("~~Metodo Gauss-Seidel~~");
            Console.Write("Ingrese magnitud de la matriz: ");
            filas = int.Parse(Console.ReadLine()); //magnitud de la raiz
            Console.Write("Ingrese iteracion Maxima: "); //iteracion maxima
            ite = int.Parse(Console.ReadLine());

            columnas = filas + 1; //columnas tendra el mismo valor que filas +1
            double[,] matrix = new double[filas, columnas]; //creamos la matriz 

            for (int Contador1 = 1; Contador1 < filas + 1; Contador1++) //for para imprimir tabla de posicion 
            {
                for (int Contador2 = 1; Contador2 < columnas + 1; Contador2++)
                {
                    Console.Write("v" + Contador1 + Contador2 + " | ");
                }
                Console.WriteLine();
            }

            for (int Contador1 = 1; Contador1 < filas + 1; Contador1++) //for para ingresar datos de cada variable
            {
                for (int Contador2 = 1; Contador2 < columnas + 1; Contador2++)
                {
                    Console.Write("Ingrese v" + Contador1 + Contador2 + ": ");
                    matrix[(Contador1 - 1), (Contador2 - 1)] = Convert.ToDouble(Console.ReadLine()); //guardamos en la matriz
                }
            }

            Console.Clear();
            Console.WriteLine("\nValores acomodados: "); //se acomodan los valores
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~");
            for (int Contador1 = 0; Contador1 < filas; Contador1++)
            {
                for (int Contador2 = 0; Contador2 < columnas; Contador2++)
                {
                    Console.Write(matrix[Contador1, Contador2] + " | ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~");

            double[] aux = new double[filas]; //se crea un vector auxiliar

            for (int iteraciones = 0; iteraciones < ite; iteraciones++) //for para el numero de iteraciones
            {
                Console.Write("\nIteracion {0}", iteraciones + 1);
                for (int i = 0; i < filas; i++) //for por cada fila(ecuaciones)
                {
                    double suma = 0;
                    for (int j = 0; j < columnas - 1; j++) //for para las columnas(valor)
                    {
                        if (j == i) continue; //no usar el result
                        suma += matrix[i, j] * aux[j]; //suma += de la matriz con los 2 for * el vector auxiliar
                    }
                    aux[i] = (matrix[i, columnas - 1] - suma) / matrix[i, i]; //el vector auxiliar es igual:...
                }

                for (int i = 0; i < filas; i++) //for para imprimir
                {
                    Console.Write(" | " + "X" + (i + 1) + " = " + aux[i] + " | "); //se imprime el vector auxiliar 
                }
            }
            Console.ReadKey();

        }
    }
}