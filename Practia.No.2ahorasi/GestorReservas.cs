using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Practia.No._2ahorasi
{
    internal class GestorReservas
    {
        private static string outputFilePath = "reserva/outp" +
            "ut.xml";

        public static void GuardarReservas(Asiento[,] asientos)
        {
            XElement root = new XElement("reserva");
            for (int i = 0; i < asientos.GetLength(0); i++)
            {
                for (int j = 0; j < asientos.GetLength(1); j++)
                {
                    Asiento asiento = asientos[i, j];
                    if (asiento.Ocupado)
                    {
                        XElement asientoElement = new XElement("asiento",
                            new XElement("identificador", $"{(char)('A' + i)}{j + 1}"),
                            new XElement("nombre", asiento.Nombre),
                            new XElement("cui", asiento.CUI),
                            new XElement("maleta", asiento.LlevaMaleta ? "true" : "false"),
                            new XElement("fecha", DateTime.Now.ToString("dd/MM/yyyy HH:mm"))
                        );
                        root.Add(asientoElement);
                    }
                }
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputFilePath));
            root.Save(outputFilePath);
            Console.WriteLine($"Reservas guardadas en {outputFilePath}");
        }

        public static void CargarReservas(Asiento[,] asientos)
        {
            string inputFilePath = "reserva/output.xml";
            int successCount = 0;
            int errorCount = 0;
            Stopwatch stopwatch = Stopwatch.StartNew();

            try
            {
                XElement root = XElement.Load(inputFilePath);
                foreach (XElement asientoElement in root.Elements("asiento"))
                {
                    try
                    {
                        string identificador = asientoElement.Element("identificador").Value;
                        int fila = identificador[0] - 'A';
                        int columna = int.Parse(identificador.Substring(1)) - 1;

                        asientos[fila, columna].Nombre = asientoElement.Element("nombre").Value;
                        asientos[fila, columna].CUI = asientoElement.Element("cui").Value;
                        asientos[fila, columna].LlevaMaleta = asientoElement.Element("maleta").Value.ToLower() == "true";
                        asientos[fila, columna].Ocupado = true;
                        successCount++;
                    }
                    catch
                    {
                        errorCount++;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al cargar el archivo: {e.Message}");
            }

            stopwatch.Stop();
            Console.WriteLine($"Carga completada: {successCount} asientos cargados con éxito, {errorCount} errores encontrados.");
            Console.WriteLine($"Tiempo de carga: {stopwatch.ElapsedMilliseconds} ms");
        }

        public static void MostrarContenidoXML(string inputFilePath)
        {
            try
            {
                XElement root = XElement.Load(inputFilePath);
                Console.WriteLine("Contenido del archivo XML:");
                Console.WriteLine(root);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al cargar el archivo: {e.Message}");
            }
        }
    }
}
