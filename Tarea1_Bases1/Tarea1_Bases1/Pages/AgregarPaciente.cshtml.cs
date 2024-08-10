using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
using Tarea1_Bases1.wwwroot.lib.Clase_Paciente;

namespace Tarea1_Bases1.Pages

{
    public class AgregarPacienteModel : PageModel
    {
        [BindProperty]
        public string nombre { get; set; } = "";
        [BindProperty]
        public string apellido { get; set; } = "";
        public string fechaNacimiento;
        [BindProperty]
        [MinLength(9)]
        public string cedula { get; set; } = "";
        [BindProperty]
        public string direccion { get; set; } = "";
        public bool errorVacio = false;
        public bool errorCedulaNumeros = false;
        public bool errorCedulaLargo = false;

        public bool hayDatos = false;
        public bool vacio = false;
        public bool agregadoCorrectamente = false;
        
        public  DateTime fechaHoy;
        
        public Paciente paciente; 
        public void OnGet()
        {
            fechaHoy = DateTime.Now;
            paciente= new Paciente();
            nombre = "";
            apellido = "";
            fechaNacimiento = "";
            cedula = "";
            direccion = "";

         

        }
        public void OnPost() {
            nombre = Request.Form["Nombre"];
            apellido = Request.Form["Apellido"];
            fechaNacimiento = Request.Form["fecha"];
            cedula = Request.Form["Cedula"];
            direccion = Request.Form["Direccion"];
            int edad;
            DateTime hoy = DateTime.Today;
            if (nombre == "") {
                errorVacio = true;
            }
            if (apellido == ""){  errorVacio = true; }
            if (fechaNacimiento == "") { errorVacio = true; }
            if (cedula == "") { errorVacio = true; }
            if (direccion == "") { errorVacio = true; }
            if (!errorVacio)
            {
                if (cedula.All(char.IsDigit))
                {
                    if(cedula.Length >= 9)
                    {
                        DateTime nacimientoDateTime = DateTime.Parse(fechaNacimiento);
                        edad =  hoy.Year - nacimientoDateTime.Year;
                        //Escribir en el .txt
                        string linea = nombre + ";;;" + apellido + ";;;" + fechaNacimiento + ";;;" + edad.ToString() + ";;;" + cedula + ";;;" + direccion;
                        try
                        {
                            StreamWriter sw = new StreamWriter("pacientes.txt", true);
                            sw.WriteLine(linea);
                            sw.Close();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Exception: " + e.Message);
                        }
                        finally
                        {
                            agregadoCorrectamente = true;
                            nombre = "";
                            apellido = "";
                            fechaNacimiento = "";
                            cedula = "";
                            direccion = "";
                            fechaHoy = DateTime.Now;
                        }
                    }
                    else
                    {
                        errorCedulaLargo = true;
                        fechaHoy = DateTime.Now;
                    }
                }
                else
                {
                    errorCedulaNumeros = true;
                    fechaHoy = DateTime.Now;
                   

                }
            }
            fechaHoy = DateTime.Now;





        }
    }
}
