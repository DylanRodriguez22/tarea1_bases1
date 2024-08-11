using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tarea1_Bases1.wwwroot.lib.Clase_Paciente;
using System.IO;
namespace Tarea1_Bases1.Pages
{
    //Esta clase se encarga de llenar el arreglo con los pacientes registrados para desplegar la tabla
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<Paciente> pacientes { get; set; } = new List<Paciente>(); //Aquí se van a guardar los datos
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        //Con esta función que se ejecuta cada vez que se cargue la página se va a rellenar el arreglo con los pacientes registrados
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
                        // Se lee cada linea para rellenar el arreglo con los pacientes registrados
                        Console.WriteLine(linea);
                        arregloPaciente = linea.Split(";;;"); //Caracter que divide los datos en el archivo .txt
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
