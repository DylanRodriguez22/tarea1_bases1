using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
using Tarea1_Bases1.wwwroot.lib.Clase_Paciente;

namespace Tarea1_Bases1.Pages

{
    public class AgregarPacienteModel : PageModel
    {
        //Estos atributos son los que van a guardar la entrada en los campos de texto del formulario de registro
        //Se les asignaron propiedades de acuerdo a las caracteristicas que deben de tener para validar sus datos de forma sencilla y que se muestre en la interfaz gráfica
        [BindProperty]
        public string nombre { get; set; } = "";
        [BindProperty]
        public string apellido { get; set; } = "";
        public string fechaNacimiento;
        [BindProperty]
        [RegularExpression("^\\d+$", ErrorMessage = "La cédula solo debe contener números.") ]
        [MinLength(9, ErrorMessage= "La cédula debe contener al menos 9 dígitos.") ]
        public string cedula { get; set; } = "";
        [BindProperty]
        public string direccion { get; set; } = "";

        public  DateTime fechaHoy;
        public bool agregadoCorrectamente = false;

        //Método que se ejecuta cada vez que se carga la ventana. Inicializa los atributos de la clase a modo de constructor.
        public void OnGet()
        {
            fechaHoy = DateTime.Now;
            
            nombre = "";
            apellido = "";
            fechaNacimiento = "";
            cedula = "";
            direccion = "";

         

        }
        //Esta función se ejecuta cuando se presiona el botón de Registrar en el formulario
        //Toma los datos de las entradas de texto y posterior a las validaciones que se realizan con las propiedades de los atributos se ingresan los datos en el archivo .txt
        public void OnPost() {
            nombre = Request.Form["Nombre"];
            apellido = Request.Form["Apellido"];
            fechaNacimiento = Request.Form["fecha"];
            cedula = Request.Form["Cedula"];
            direccion = Request.Form["Direccion"];
            if(nombre != "" & apellido != "" & fechaNacimiento != "" & cedula != "" & direccion != "")
            {
                if (cedula.Length > 8)
                {
                    if (cedula.All(char.IsDigit))
                    {
                        int edad;
                        DateTime hoy = DateTime.Today;

                        DateTime nacimientoDateTime = DateTime.Parse(fechaNacimiento);
                        edad = hoy.Year - nacimientoDateTime.Year;
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
                }


               
            }
            fechaHoy = DateTime.Now;


        }
    }
}
