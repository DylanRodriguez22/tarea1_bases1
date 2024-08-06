using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Tarea1_Bases1.Pages
{
    public class AgregarPacienteModel : PageModel
    {
        public string nombre = "";
        public bool hayDatos = false;
        public bool vacio = false;
        public void OnGet()
        {
        }
        public void OnPost() {
            
            nombre = Request.Form["Nombre"];
            if (nombre != "")
            {
                hayDatos = true;
            }
            else
            {
                vacio = true;

            }

        }
    }
}
