using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practia.No._2ahorasi
{
    internal class RegistroAsientos
    {
       
        private static Asiento[,] asientos;
        private static int reservasAleatoriasNegocios = 0;
        private static int reservasManualesNegocios = 0;
        private static int reservasAleatoriasEconomicos = 0;
        private static int reservasManualesEconomicos = 0;
        static RegistroAsientos()
        {
            asientos = new Asiento[10, 7];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    asientos[i, j] = new Asiento();
                }
            }
        }

        public static void MostrarAsientosDisponibles(string tipoAsiento)
        {
            if (tipoAsiento.ToLower() == "negocios")
            {
                Console.WriteLine("    1    2");
                Console.WriteLine("---------------------");
                for (int i = 0; i < 6; i++)
                { 
                    Console.Write($"  {(char)('I' - i )}  |");
                    for (int j = 0; j < 2; j++)
                    {
                        Console.Write(asientos[i, j].Ocupado ? " X |" : "   |");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("---------------------");
            }
            else if (tipoAsiento.ToLower() == "economica" || tipoAsiento.ToLower() == "economico")
            {
                Console.WriteLine("    3    4    5    6    7");
                Console.WriteLine("-------------------------");
                for (int i = 0; i < 9; i++)
                { 
                    Console.Write($"  {(char)('I' - i)}  |");
                    for (int j = 2; j < 7; j++)
                    {
                        Console.Write(asientos[i, j].Ocupado ? " X |" : "   |");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("-------------------------");
            }
            else
            {
                Console.WriteLine("Tipo de asiento no válido.");
            }
        }

        public static void ReservarAsientos(int cantidad, string tipoAsiento)
        {
            int maxFila = tipoAsiento.ToLower() == "negocios" ? 5 : 9;
            int minColumna = tipoAsiento.ToLower() == "negocios" ? 0 : 2;
            int maxColumna = tipoAsiento.ToLower() == "negocios" ? 1 : 6;
           
            
            for (int k = 0; k < cantidad; k++)
            {
                Console.WriteLine($"Reservando asiento {k + 1} de {cantidad}...");
                
                Console.Write("¿Desea seleccionar el asiento manualmente o aleatoriamente? (Manual/Aleatorio): ");
                string seleccion = Console.ReadLine().Trim().ToLower();
                if (tipoAsiento.ToLower() == "negocios")
                {
                    if (seleccion == "aleatorio")
                    {
                        reservasAleatoriasNegocios++;
                    }
                    else if (seleccion == "manual")
                    {
                        reservasManualesNegocios++;
                    }
                }
                else if (tipoAsiento.ToLower() == "economica" || tipoAsiento.ToLower() == "economico")
                {
                    if (seleccion == "aleatorio")
                    {
                        reservasAleatoriasEconomicos++;
                    }
                    else if (seleccion == "manual")
                    {
                        reservasManualesEconomicos++;
                    }
                }
                int filaIndex = 0, columna = minColumna; 
                bool asientoValido = false;

                if (seleccion == "manual")
                {
                    do
                    {
                        Console.Write("Ingrese la fila del asiento (A-F para negocios, A-J para económica): ");
                        char fila = char.Parse(Console.ReadLine().ToUpper());
                        filaIndex = fila - 'A';

                        if (filaIndex < 0 || filaIndex > maxFila)
                        {
                            Console.WriteLine("Fila inválida, por favor intente de nuevo.");
                            continue;
                        }

                        Console.Write("Ingrese la columna del asiento (1-2 para negocios, 3-7 para económica): ");
                        columna = int.Parse(Console.ReadLine()) - 1;

                        if (columna < minColumna || columna > maxColumna)
                        {
                            Console.WriteLine("Columna inválida, por favor intente de nuevo.");
                            continue;
                        }

                        asientoValido = !asientos[filaIndex, columna].Ocupado;
                        if (!asientoValido)
                        {
                            Console.WriteLine("El asiento está ocupado, por favor seleccione otro.");
                        }
                    }
                    while (!asientoValido);
                }
                else 
                {
                    Random rnd = new Random();
                    do
                    {
                        filaIndex = rnd.Next(maxFila + 1);
                        columna = rnd.Next(minColumna, maxColumna + 1);
                        asientoValido = !asientos[filaIndex, columna].Ocupado;
                    }
                    while (!asientoValido);
                }

                string cui;
                do
                {
                    Console.Write("Ingrese su CUI (13 dígitos, últimos 4 dígitos entre 0101 y 2217): ");
                    cui = Console.ReadLine();
                }
                while (!EsCuiValido(cui));

                // Reserva del asiento
                Console.Write("Nombre completo: ");
                asientos[filaIndex, columna].Nombre = Console.ReadLine();
                asientos[filaIndex, columna].CUI = cui;
                Console.Write("¿Lleva maleta? (s/n): ");
                asientos[filaIndex, columna].LlevaMaleta = Console.ReadLine().ToLower() == "s";
                asientos[filaIndex, columna].Ocupado = true;

                Console.WriteLine($"Asiento {((char)('A' + filaIndex))}{columna + 1} reservado correctamente.");
                Console.WriteLine($"Fecha de reserva: {DateTime.Now}");
                asientos[filaIndex, columna].Ocupado = true;
                Console.WriteLine($"Asiento {((char)('A' + filaIndex))}{columna + 1} reservado correctamente.");
                Console.WriteLine($"Fecha de reserva: {DateTime.Now}");

               
                GestorReservas.GuardarReservas(asientos);
            }

        }

        private static bool EsCuiValido(string cui)
        {
            if (cui.Length == 13)
            {
                string ultimosCuatro = cui.Substring(9);
                if (int.TryParse(ultimosCuatro, out int ultimosDigitos))
                {
                    Console.WriteLine();
                    return ultimosDigitos >= 101 && ultimosDigitos <= 2217;

                }
            }
            return false;
        }
        public static int ContarAsientosOcupadosNegocios()
        {
            int count = 0;
            for (int i = 0; i <= 5; i++)  
            {
                for (int j = 0; j <= 1; j++)  
                {
                    if (asientos[i, j].Ocupado) count++;
                }
            }
            return count;
        }

        public static int ContarAsientosLibresNegocios()
        {
            int totalNegocios = 12;  
            return totalNegocios - ContarAsientosOcupadosNegocios();
        }

        public static int ContarAsientosOcupadosEconomica()
        {
            int count = 0;
            for (int i = 0; i < 10; i++)  
            {
                for (int j = 2; j < 7; j++)  
                {
                    if (asientos[i, j].Ocupado) count++;
                }
            }
            return count;
        }

        public static int ContarAsientosLibresEconomica()
        {
            int totalEconomica = 50;  
            return totalEconomica - ContarAsientosOcupadosEconomica();
        }

        public static int ObtenerReservasAleatoriasNegocios()
        {
            return reservasAleatoriasNegocios;
        }

        public static int ObtenerReservasManualesNegocios()
        {
            return reservasManualesNegocios;
        }

        public static int ObtenerReservasAleatoriasEconomicos()
        {
            return reservasAleatoriasEconomicos;
        }

        public static int ObtenerReservasManualesEconomicos()
        {
            return reservasManualesEconomicos;
        }
    }
}

