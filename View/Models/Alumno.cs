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

        private String Dni;
        private String Nombre;
        private String Apellido1;
        private String Apellido2;
        public string Dni1 { get => Dni; set => Dni = value; }
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public string Apellido11 { get => Apellido1; set => Apellido1 = value; }
        public string Apellido21 { get => Apellido2; set => Apellido2 = value; }
    }
}
