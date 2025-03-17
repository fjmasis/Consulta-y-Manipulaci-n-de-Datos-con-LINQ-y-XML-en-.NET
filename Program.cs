using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace LINQAPP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Mapear la ruta XML
            string rutaXML = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Consulta y Manipulación de Datos con LINQ y XML en .NET\Productos.XML");

            // Verificar si el archivo XML existe
            if (!File.Exists(rutaXML))
            {
                Console.WriteLine("El archivo XML no se encuentra en la ruta especificada.");
                return;
            }

            // Cargar el archivo XML
            XDocument xmlDoc = XDocument.Load(rutaXML);

            // Usar LINQ para filtrar productos con precio mayor a 50
            var productos = xmlDoc.Descendants("Producto")
                .Where(e => (decimal?)e.Element("Precio") > 50)
                .Select(x => new
                {
                    Nombre = x.Element("Nombre")?.Value,
                    Precio = (decimal?)x.Element("Precio")
                });

            // Imprimir resultados
            Console.WriteLine("Productos con precio mayor a 50:");
            foreach (var producto in productos)
            {
                Console.WriteLine($"Nombre: {producto.Nombre}, Precio: {producto.Precio:C}");
            }

            Console.ReadLine();
        }
    }
}
