using System;

using Modelo;
using Modelo.DAO;
using MySql.Data.MySqlClient;

namespace Controlador
{
    public class Controlador
    {
        private AlumnoDAO alumnodao;
        private MySqlConnection con;
        private Alumno alumno;
   
        public Controlador() {
            this.con = Connect.Conectar();
            
        
        }
        private void RellenarTabla() { 
        
        
        
        }


    }
}
