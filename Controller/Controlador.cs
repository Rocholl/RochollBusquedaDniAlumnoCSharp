
using Model;
using Model.DAO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vista;

namespace Controller
{
    class Controlador
    {
         
        private AlumnoDAO alumnodao;
        private MySqlConnection con;
        private Alumno alumno;
        private Form2 vistaDni;
        private Form1 tablaAlumnos;
        private Form3 vistaPrincipal;
        public Controlador()
        {
            this.con = Connect.Conectar();
            this.vistaPrincipal = new Form3();
            this.InicializarEventos();
        }
        private void RellenarTabla()
        {

            tablaAlumnos.DataGridView1.DataSource = alumnodao.GetAllAlumnos(con);

        }
        private void InicializarEventos() {
            vistaPrincipal.Button1.Click += new EventHandler(this.CargarAlumnoDni);
            vistaPrincipal.Button2.Click += new EventHandler(this.CargarAlumnoDni);
            vistaDni.Button1.Click += new EventHandler(this.CargarAlumnoDni);
            vistaDni.Button2.Click += new System.EventHandler(this.EliminarAlumno);
        }
        private void CargarAlumnoDni(object sender, EventArgs e) {
            this.alumno = alumnodao.GetAlumno(vistaDni.TextBox1.Text,con);
            vistaDni.TextBox2.Text =alumno.Nombre1;
            vistaDni.TextBox3.Text = alumno.Apellido11;
            vistaDni.TextBox4.Text = alumno.Apellido21;
        }
        private void EliminarAlumno(object sender, EventArgs e) {
            alumnodao.DeleteAlumno(alumno.Dni1, con);
        
        }
        private void AbrirVistaTabla(object sender, EventArgs e) {
            this.tablaAlumnos = new Form1();
        }
        private void AbrirVistaDni(object sender, EventArgs e) {
            this.vistaDni = new Form2();
        }
    }
}
