namespace Tarea1_Bases1.wwwroot.lib.Clase_Paciente
{
    public class Paciente
    {
        public string nombre;
        public string apellido;
        public string cedula;
        public string fechaDeNacimiento;
        public string edad;
        public string direccion;

        public Paciente(string pNombre, string pApellido, string pCedula, string pFechaNacimiento, string pEdad, string pDireccion)
        {
            nombre = pNombre;
            apellido = pApellido;
            cedula = pCedula;
            fechaDeNacimiento = pFechaNacimiento;
            edad = pEdad;
            direccion = pDireccion;
        }
        public Paciente() {
            nombre = "";
         apellido = "";
         cedula = "";
       fechaDeNacimiento = "";
         edad = "";
         direccion = "";
    }
    }
}
