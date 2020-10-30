using System;

namespace Model
{
    public class Alumno
    {
        private string dni;
        private string nombre;
        private string apellido1;
        private string apellido2;

        public Alumno(string dni, string nombre, string apellido1, string apellido2)
        {
            Dni = dni;
            Nombre = nombre;
            Apellido1 = apellido1;
            Apellido2 = apellido2;
        }

        private String Dni { get => dni; set => dni = value; }
        private String Nombre { get => nombre; set => nombre = value; }
        private String Apellido1 { get => apellido1; set => apellido1 = value; }
        private String Apellido2 { get => apellido2; set => apellido2 = value; }

    }
}
