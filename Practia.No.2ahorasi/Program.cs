using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practia.No._2ahorasi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool salir = false;
            bool salir2 = false;
            bool salir4 = false;

            while (!salir)
            {
                Console.WriteLine("\nMenú:");
                Console.WriteLine("\nPor favor Seleccione una opcion:");
                Console.WriteLine("1. Cargar Reservas de Asientos");
                Console.WriteLine("2. Reserva de Asientos");
                Console.WriteLine("3. Guardar Asientos Reservados");
                Console.WriteLine("4. Reportes");
                Console.WriteLine("0. Salir");

                Console.Write("Seleccione una opción: ");
                int opcion;
                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Opción no válida. Por favor, seleccione un número del 1 al 6.");
                    continue;
                }

                switch (opcion)
                {
                    case 0:
                        salir = true;
                        Console.WriteLine("Saliendo del programa...");
                        break;

                    case 1:
                        Console.Clear();
                        break;



                    case 2:
                        
                        while (!salir2)
                        {
                            Console.Clear();
                            Console.WriteLine("\nReserva de Asientos:");
                            Console.WriteLine("\nPor favor Seleccione una opcion:");
                            Console.WriteLine("1. Realizar una Reserva");
                            Console.WriteLine("2. Modificar una Reserva");
                            Console.WriteLine("3. Canselar una Reserva");
                            Console.WriteLine("0. Salir");
                            if (!int.TryParse(Console.ReadLine(), out opcion))
                            {
                                Console.WriteLine("Opción no válida. Por favor, seleccione un número del 1 al 6.");
                                continue;
                            }
                            switch (opcion)
                            {
                                case 0:
                                    salir2 = true;
                                    Console.WriteLine("Saliendo del programa...");
                                    break;
                                case 1:
                                    Console.Clear();
                                    Console.WriteLine("Realizar una Reserva");
                                    // Lógica para realizar una reserva

                                    break;
                                case 2:
                                    Console.Clear();
                                    Console.WriteLine("Modificar una Reserva");
                                    // Lógica para modificar una reserva
                                    break;
                                case 3:
                                    Console.Clear();
                                    Console.WriteLine("Cancelar una Reserva");
                                    // Lógica para cancelar una reserva
                                    break;
                                default:
                                    Console.WriteLine("Opción no válida. Por favor, seleccione un número del 1 al 6.");
                                    break;
                            }
                        }
                        break;


                    case 3:

                        Console.Clear();
                        break;

                    case 4:
                        while (!salir4)
                        {
                            Console.Clear();
                            Console.WriteLine("\nReportes:");
                            Console.WriteLine("\nPor favor Seleccione una opcion:");
                            Console.WriteLine("1. Ver diagrama de asientos");
                            Console.WriteLine("2. Cantidad de asientos en clase de negocios ocupados");
                            Console.WriteLine("3. Cantidad de asientos en clase económica ocupados");
                            Console.WriteLine("4. Cantidad de asientos en clase de negocios libres ");
                            Console.WriteLine("5. Cantidad de asientos en clase económica libres ");
                            Console.WriteLine("6. Cantidad de asientos seleccionados por usuario");
                            Console.WriteLine("7. Cantidad de asientos seleccionados aleatorio");
                            Console.WriteLine("8. Cantidad de asientos modificados (por ejecución) ");
                            Console.WriteLine("9. Cantidad de asientos cancelados (por ejecución)");

                            Console.WriteLine("0. Salir");
                            if (!int.TryParse(Console.ReadLine(), out opcion))
                            {
                                Console.WriteLine("Opción no válida. Por favor, seleccione un número del 1 al 6.");
                                continue;
                            }
                            switch (opcion)
                            {
                                case 0:
                                    salir4 = true;
                                    Console.WriteLine("Saliendo del programa...");
                                    break;
                                case 1:
                                    Console.Clear();
                                    Console.WriteLine("Ver diagrama de asientos");
                                    // Lógica para ver diagrama de asientos
                                    break;
                                case 2:
                                    Console.Clear();
                                    Console.WriteLine("Cantidad de asientos en clase de negocios ocupados");
                                    // Lógica para cantidad de asientos en clase de negocios ocupados
                                    break;
                                case 3:
                                    Console.Clear();
                                    Console.WriteLine("Cantidad de asientos en clase económica ocupados");
                                    // Lógica para cantidad de asientos en clase económica ocupados
                                    break;
                                case 4:
                                    Console.Clear();
                                    Console.WriteLine("Cantidad de asientos en clase de negocios libres");
                                    // Lógica para cantidad de asientos en clase de negocios libres
                                    break;
                                case 5:
                                    Console.Clear();
                                    Console.WriteLine("Cantidad de asientos en clase económica libres");
                                    // Lógica para cantidad de asientos en clase económica libres
                                    break;
                                case 6:
                                    Console.Clear();
                                    Console.WriteLine("Cantidad de asientos seleccionados por usuario");
                                    // Lógica para cantidad de asientos seleccionados por usuario
                                    break;
                                case 7:
                                    Console.Clear();
                                    Console.WriteLine("Cantidad de asientos seleccionados aleatorio");
                                    // Lógica para cantidad de asientos seleccionados aleatorio
                                    break;
                                case 8:
                                   Console.Clear();
                                   Console.WriteLine("Cantidad de asientos modificados (por ejecución)");
                                    // Lógica para cantidad de asientos modificados (por ejecución)
                                    break;
                                case 9:
                                    Console.Clear();
                                    Console.WriteLine("Cantidad de asientos cancelados (por ejecución)");
                                    // Lógica para cantidad de asientos cancelados (por ejecución)
                                    break;
                                default:
                                    Console.WriteLine("Opción no válida. Por favor, seleccione un número del 1 al 6.");
                                    break;
                            }

                        }
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, seleccione una opción del 1 al 6.");
                        break;
                }
            }

        }

    }
}
