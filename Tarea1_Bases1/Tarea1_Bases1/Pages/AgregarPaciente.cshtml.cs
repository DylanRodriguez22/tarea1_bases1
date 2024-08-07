using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tarea1_Bases1.wwwroot.lib.Clase_Paciente;

namespace Tarea1_Bases1.Pages

{
    public class AgregarPacienteModel : PageModel
    {
        public string nombre;
        public string apellido;
        public string fechaNacimiento;
        public string cedula;
        public string direccion;


        public bool hayDatos = false;
        public bool vacio = false;
        
        public  DateTime fechaHoy;
        
        public Paciente paciente; 
        public void OnGet()
        {
            fechaHoy = DateTime.Now;
            paciente= new Paciente();


         

        }
        public void OnPost() {
            nombre = Request.Form["Nombre"];
            apellido = Request.Form["Apellido"];
            fechaNacimiento = Request.Form["fecha"];
            cedula = Request.Form["Cedula"];
            direccion = Request.Form["Direccion"];
            string linea = nombre + "," + apellido + "," + fechaNacimiento + "," + cedula + "," + direccion;
            try
            {
                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter("pacientes.txt", true);
                //Write a line of text
                sw.WriteLine(linea);
                
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }


        }
    }
}
