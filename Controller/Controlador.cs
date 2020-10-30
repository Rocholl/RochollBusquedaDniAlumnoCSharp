
using Model;
using Model.DAO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    class Controlador
    {
         
        private AlumnoDAO alumnodao;
        private MySqlConnection con;
        private Alumno alumno;

        public Controlador()
        {
            this.con = Connect.Conectar();


        }
        private void RellenarTabla()
        {



        }
    }
}
