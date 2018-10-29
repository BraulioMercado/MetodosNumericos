using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagonalEjemplo
{
    class Program
    {
        int filas, ite, columnas;
        string cf, CifraF;
        double[,] matrix;
        string[] VectorAuxiliar = new string[3];
        int Iteraccion = 0;
        double[] Incognitas = new double[3];
        double[] Errores = new double[3];
        double Anterior1, Anterior2, Anterior3;

        public void Ingresar()
        {
            Console.WriteLine("~~Metodo Gauss-Seidel~~");
            Console.Write("Ingrese magnitud de la matriz (solo se acepta de 3): ");
            filas = int.Parse(Console.ReadLine()); //magnitud de la raiz
            Console.Write("Ingrese iteracion Maxima: "); //iteracion maxima
            ite = int.Parse(Console.ReadLine());
            Console.Write("Ingrese numero de cifras significativas: ");
            cf = (Console.ReadLine());
            CifraF = "N" + cf;
            columnas = filas + 1; //columnas tendra el mismo valor que filas +1
            matrix = new double[filas, columnas];

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
        }
        public bool Diagonal()
        {
            for (int Contador1 = 0; Contador1 < filas; Contador1++)
            {
                if (matrix[(Contador1), 0] > matrix[(Contador1), 1] && matrix[(Contador1), 0] > matrix[(Contador1), 2])
                {
                    VectorAuxiliar[Contador1] = "A";
                }
                else
                {
                    if (matrix[(Contador1), 1] > matrix[(Contador1), 0] && matrix[(Contador1), 1] > matrix[(Contador1), 2])
                    {
                        VectorAuxiliar[Contador1] = "B";
                    }
                    else
                    {
                        VectorAuxiliar[Contador1] = "C";
                    }
                }
            }

            if (VectorAuxiliar[0] != VectorAuxiliar[1] && VectorAuxiliar[0] != VectorAuxiliar[2])
            {
                if (VectorAuxiliar[1] != VectorAuxiliar[0] && VectorAuxiliar[1] != VectorAuxiliar[2])
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public void Proceso()
        {
            bool DoWhile = Diagonal();
            if (DoWhile == true)
            {
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
                Console.WriteLine("\n|Iter|  x1   |  x2  |  x3  |Error:x1|Error:x2|Error:x3|");
                for (int i = 0; i < ite; i++)
                {
                    Iteraccion++;
                    Anterior1 = Incognitas[0];
                    Anterior2 = Incognitas[1];
                    Anterior3 = Incognitas[2];
                    Incognitas[0] = (matrix[0, 3] - (matrix[0, 1] * Incognitas[1]) - (matrix[0, 2] * Incognitas[2])) / matrix[0, 0];
                    Incognitas[1] = (matrix[1, 3] - (matrix[1, 0] * Incognitas[0]) - (matrix[1, 2] * Incognitas[2])) / matrix[1, 1];
                    Incognitas[2] = (matrix[2, 3] - (matrix[2, 0] * Incognitas[0]) - (matrix[2, 1] * Incognitas[1])) / matrix[2, 2];
                    if (Iteraccion == 1)
                    {
                        Errores[0] = 100;
                        Errores[1] = 100;
                        Errores[2] = 100;
                    }
                    else
                    {
                        Errores[0] = (((Incognitas[0] - Anterior1) / Incognitas[0]) * 100);
                        Errores[1] = (((Incognitas[1] - Anterior2) / Incognitas[1]) * 100);
                        Errores[2] = (((Incognitas[2] - Anterior3) / Incognitas[2]) * 100);
                    }
                    Console.WriteLine("|" + Iteraccion + "|" + Incognitas[0].ToString(CifraF) + "|" + Incognitas[1].ToString(CifraF) + "|" + Incognitas[2].ToString(CifraF) + "|" + Errores[0].ToString(CifraF) + "|" + Errores[1].ToString(CifraF) + "|" + Errores[2].ToString(CifraF) + "|");
                }
            }
            else
            {
                Console.WriteLine("El ejercicio no se puede realizar.\nPresione una tecla para continuar.");
            }
        }
        public static void Main(string[] args)
        {
            string opc;
            do
            {
                bool ban = true;
                do
                {
                    try
                    {
                        Console.Clear();
                        Program p = new Program();
                        p.Ingresar();
                        p.Proceso();
                        ban = false;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error" + e.Message);
                        Console.ReadKey();
                    }
                }
                while (ban);

                Console.WriteLine("\nDesea repetir el programa: (SI/NO)");
                opc = Console.ReadLine();
            }
            while (opc == "si");
            Console.ReadKey();
        }
    }
}