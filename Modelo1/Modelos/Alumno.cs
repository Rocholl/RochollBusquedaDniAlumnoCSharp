using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo1.Modelos
{
    public class Alumno
    {


        public Alumno(int registro,string dni, string nombre, string apellido1, string apellido2)
        {
            Registro = registro;
            Dni = dni;
            Nombre = nombre;
            Apellido1 = apellido1;
            Apellido2 = apellido2;
        }
        private int Registro;

        private String Dni;
        private String Nombre;
        private String Apellido1;
        private String Apellido2;
        public string Dni1 { get => Dni; set => Dni = value; }
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public string Apellido11 { get => Apellido1; set => Apellido1 = value; }
        public string Apellido21 { get => Apellido2; set => Apellido2 = value; }
        public int Registro1 { get => Registro; set => Registro = value; }
    }
}
