using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
  public  class Prestamo
    {
        public Prestamo(string id, string codAlumno, string codLibros, DateTime fechaPrestamo, DateTime fechaDevolucion, string estado)
        {
            Id = id;
            this.codAlumno = codAlumno;
            this.codLibros = codLibros;
            FechaPrestamo = fechaPrestamo;
            FechaDevolucion = fechaDevolucion;
            this.estado = estado;
        }

        private String Id { get; set; }
        private String codAlumno { get; set; }
        private String codLibros { get; set; }
        private DateTime FechaPrestamo { get; set; }
        private DateTime FechaDevolucion { get; set; }
        private String estado { get; set; }

    }
}
