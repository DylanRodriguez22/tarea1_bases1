using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tarea1_Bases1.wwwroot.lib.Clase_Paciente;
using System.IO;
namespace Tarea1_Bases1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<Paciente> pacientes { get; set; } = new List<Paciente>();
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            string linea;
            string[] arregloPaciente;
            try
            {
                string direccionArchivo = "pacientes.txt";
                using (StreamReader reader = new StreamReader(direccionArchivo))
                {

                    while ((linea = reader.ReadLine()) != null)
                    {
                        // Procesar cada línea
                        Console.WriteLine(linea);
                        arregloPaciente = linea.Split(";;;");
                        Paciente paciente = new Paciente(arregloPaciente[0], arregloPaciente[1], arregloPaciente[4], arregloPaciente[2], arregloPaciente[3], arregloPaciente[5]);
                        pacientes.Add(paciente);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Se produjo un error: " + e.Message);
            }
        }
    }
}
