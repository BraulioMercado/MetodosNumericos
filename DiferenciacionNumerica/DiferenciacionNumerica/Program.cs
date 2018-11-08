using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiferenciacionNumerica
{
    class Program
    {
        double xi, h, x4, x3, x2, x, c; //declaramos variables globales
        string tipo, derivada, oh;

        double resultado = 0;

        static void Main(string[] args)
        {
            Program op = new Program();
            op.Proceso(); //llamamos al proceso
            Console.ReadKey();
        }
        public void Proceso()
        {
            string opc;
            do
            {
                Console.Clear();
                try
                {
                    Console.WriteLine("~~~~Ingreso de valores~~~~");
                    Console.Write("Ingrese funcion x4: ");
                    x4 = double.Parse(Console.ReadLine());
                    Console.Write("Ingrese funcion x3: ");
                    x3 = double.Parse(Console.ReadLine()); //ingresamos valores de cada variable
                    Console.Write("Ingrese funcion x2: ");
                    x2 = double.Parse(Console.ReadLine());
                    Console.Write("Ingrese funcion x1: ");
                    x = double.Parse(Console.ReadLine());
                    Console.Write("Ingrese funcion x: ");
                    c = double.Parse(Console.ReadLine());

                    Console.Write("Ingrese xi: ");
                    xi = double.Parse(Console.ReadLine());
                    Console.Write("Ingrese h: ");
                    h = double.Parse(Console.ReadLine());

                    Console.Clear();

                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.Write("Ingrese accion: \nCentrada(1) \nHacia adelante(2) \nHacia atras(3): "); //escogemos el tipo de accion
                    tipo = Console.ReadLine();

                    if (tipo == "1") //if dependiendo de la accion
                    {
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        Console.Write("Ingrese derivada: \nPrimera derivada(1) \nSegunda derivada(2): "); //escogemos derivada
                        derivada = Console.ReadLine();

                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        Console.Write("Ingrese oh: \n1=O(h^2) \n2=O(h^4): "); //escogemos oh
                        oh = Console.ReadLine();

                        switch (derivada) //switch dependiendo de la derivada
                        {
                            case "1":
                                switch (oh) //switch dependiendo del oh
                                {
                                    case "1":
                                        resultado = ((CalcularFuncion(xi + h)) - (CalcularFuncion(xi - h))) / (2 * h);
                                        Console.WriteLine("\nResultado: " + resultado);
                                        break;

                                    case "2":
                                        resultado = ((-CalcularFuncion(xi + (2 * h))) + (8 * CalcularFuncion(xi + h)) - (8 * CalcularFuncion(xi - h)) + (CalcularFuncion(xi - (2 * h)))) / (12 * h);
                                        Console.WriteLine("\nResultado: " + resultado);
                                        break;
                                }
                                break;

                            case "2":
                                switch (oh) //switch dependiendo del oh
                                {
                                    case "O(h^2)":
                                        resultado = (CalcularFuncion(xi + h) - (2 * CalcularFuncion(xi)) + CalcularFuncion(xi - h)) / (Math.Pow(h, 2));
                                        Console.WriteLine("\nResultado: " + resultado);
                                        break;

                                    case "O(h^4)":
                                        resultado = (-CalcularFuncion(xi + (2 * h)) + (16 * CalcularFuncion(xi + h)) - (30 * CalcularFuncion(xi)) + (16 * CalcularFuncion(xi - h)) - (CalcularFuncion(xi - (2 * h)))) / (12 * Math.Pow(h, 2));
                                        Console.WriteLine("\nResultado: " + resultado);
                                        break;
                                }
                                break;
                        }

                    }
                    else if (tipo == "2") //if dependiendo de la accion
                    {
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        Console.Write("Ingrese cual derivada: \nPrimera derivada(1) \nSegunda derivada(2): ");
                        derivada = Console.ReadLine();

                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        Console.Write("Ingrese oh: \n1=O(h) \n2=O(h^2): ");
                        oh = Console.ReadLine();

                        switch (derivada) //switch dependiendo de la derivada
                        {
                            case "1":
                                switch (oh) //switch dependiendo del oh
                                {
                                    case "1":
                                        resultado = ((CalcularFuncion(xi + h)) - (CalcularFuncion(xi))) / (2 * h);
                                        Console.WriteLine("\nResultado: " + resultado);
                                        break;

                                    case "2":
                                        resultado = ((-CalcularFuncion(xi + (h * 2))) + (4 * CalcularFuncion(xi + h)) - (3 * CalcularFuncion(xi))) / (2 * h);
                                        Console.WriteLine("\nResultado: " + resultado);
                                        break;
                                }
                                break;

                            case "2":
                                switch (oh) //switch dependiendo del oh
                                {
                                    case "1":
                                        resultado = ((CalcularFuncion(xi + (2 * h))) - (2 * CalcularFuncion(xi + h)) + (CalcularFuncion(xi))) / (Math.Pow(h, 2));
                                        Console.WriteLine("\nResultado: " + resultado);
                                        break;

                                    case "2":
                                        resultado = ((-CalcularFuncion(xi + (3 * h))) + (4 * CalcularFuncion(xi + (2 * h))) - (5 * CalcularFuncion(xi + h)) + (2 * CalcularFuncion(xi))) / (Math.Pow(h, 2));
                                        Console.WriteLine("\nResultado: " + resultado);
                                        break;
                                }
                                break;
                        }
                    }
                    else if (tipo == "3") //if dependiendo de la accion
                    {
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        Console.Write("Ingrese cual derivada: \nPrimera derivada(1) \nSegunda derivada(2): ");
                        derivada = Console.ReadLine();

                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        Console.Write("Ingrese oh: \n1=O(h) \n2=O(h^2): ");
                        oh = Console.ReadLine();

                        switch (derivada) //switch dependiendo de la derivada
                        {
                            case "1":
                                switch (oh) //switch dependiendo del oh
                                {
                                    case "1":
                                        resultado = ((CalcularFuncion(xi)) - (CalcularFuncion(xi - h))) / (2 * h);
                                        Console.WriteLine("\nResultado: " + resultado);
                                        break;

                                    case "2":
                                        resultado = ((3 * CalcularFuncion(xi)) - (4 * CalcularFuncion(xi - h)) + (1 * CalcularFuncion(xi - (2 * h)))) / (2 * h);
                                        Console.WriteLine("\nResultado: " + resultado);
                                        break;
                                }
                                break;

                            case "2":
                                switch (oh) //switch dependiendo del oh
                                {
                                    case "1":
                                        resultado = ((CalcularFuncion(xi)) - (2 * CalcularFuncion(xi - h)) + (CalcularFuncion(xi + (2 * h)))) / (Math.Pow(h, 2));
                                        Console.WriteLine("\nResultado: " + resultado);
                                        break;

                                    case "2":
                                        resultado = ((2 * CalcularFuncion(xi)) - (5 * CalcularFuncion(xi - h)) + (4 * CalcularFuncion(xi + (2 * h))) - (CalcularFuncion(xi - (3 * h)))) / (Math.Pow(h, 2));
                                        Console.WriteLine("\nResultado: " + resultado);
                                        break;
                                }
                                break;
                        }
                    }
                }

                catch (Exception e) //excepcion para posibles errores
                {
                    Console.WriteLine("Se ha producido un Error" + e.Message);
                }
                Console.Write("Desea repetir el programa (si/no): ");
                opc = Console.ReadLine();
            }
            while (opc=="si");
        }
        public double CalcularFuncion(double XI) //metodo donde se calcula la funcion
        {
            double funcion = 0;
            funcion = ((Math.Pow(XI, 4) * x4) + (Math.Pow(XI, 3) * x3) + (Math.Pow(XI, 2) * x2) + (XI * x) + c);
            return funcion;
        }
    }
}
