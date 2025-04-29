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
           
            while (!salir)
            {
                Console.WriteLine("\nMenú:");
                Console.WriteLine("1. Mostrar asientos disponibles");
                Console.WriteLine("2. Reservar asientos");
                Console.WriteLine("3. Contar asientos ocupados en clase de negocios");
                Console.WriteLine("4. Contar asientos ocupados en clase económica");
                Console.WriteLine("5. Mostrar XML");
                Console.WriteLine("6. Mostrar asientos libres");
                Console.WriteLine("9. Salir");

                Console.Write("Seleccione una opción: ");
                int opcion;
                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Opción no válida. Por favor, seleccione un número del 1 al 6.");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        
                        Console.Write("¿Qué tipo de asiento desea ver? (Negocios/Económico): ");
                        string tipoAsiento1 = Console.ReadLine();
                        RegistroAsientos.MostrarAsientosDisponibles(tipoAsiento1);
                        break;
                    case 2:
                        
                        Console.Write("¿Qué tipo de asiento desea reservar? (Negocios/Económico): ");
                        string tipoAsiento2 = Console.ReadLine();
                        Console.Write("¿Cuántos asientos desea reservar? ");
                        if (!int.TryParse(Console.ReadLine(), out int cantidad))
                        {
                            Console.WriteLine("Cantidad no válida. Por favor, ingrese un número entero.");
                            break;
                        }
                        RegistroAsientos.ReservarAsientos(cantidad, tipoAsiento2);
                        break;
                    case 3:
                       
                        int asientosOcupadosNegocios = RegistroAsientos.ContarAsientosOcupadosNegocios();
                        Console.WriteLine($"Cantidad de asientos ocupados en clase de negocios: {asientosOcupadosNegocios}");
                        break;
                    case 4:
                        
                        int asientosOcupadosEconomica = RegistroAsientos.ContarAsientosOcupadosEconomica();
                        Console.WriteLine($"Cantidad de asientos ocupados en clase económica: {asientosOcupadosEconomica}");
                        break;
                    case 5:
                        Console.WriteLine("contenido del archivo xml");
                        GestorReservas.MostrarContenidoXML("reserva/output.xml"); 

                        break;
                    case 6:
                        Console.WriteLine("Asientos Libres Negocios: " + RegistroAsientos.ContarAsientosLibresNegocios());
                        Console.WriteLine("Asientos Libres Económicos: " + RegistroAsientos.ContarAsientosLibresEconomica());
                        break;

                     case 7:
                        Console.WriteLine($"Reservas aleatorias en asientos de negocios: {RegistroAsientos.ObtenerReservasAleatoriasNegocios()}");
                        Console.WriteLine($"Reservas manuales en asientos de negocios: {RegistroAsientos.ObtenerReservasManualesNegocios()}");
                        Console.WriteLine($"Reservas aleatorias en asientos económicos: {RegistroAsientos.ObtenerReservasAleatoriasEconomicos()}");
                        Console.WriteLine($"Reservas manuales en asientos económicos: {RegistroAsientos.ObtenerReservasManualesEconomicos()}");
                        break; 
                    
                    case 9:
                        salir = true;
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, seleccione una opción del 1 al 6.");
                        break;
                }
            }

        }

    }
}
