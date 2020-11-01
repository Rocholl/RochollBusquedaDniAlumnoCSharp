using Modelo1;
using Modelo1.Modelos;
using System;
using System.Windows.Forms;
using Vista;

namespace Controlador1
{
    class Controlador
    {
        private Connect connection = new Connect();

        private AlumnoDAO alumnodao = new AlumnoDAO();

        private Alumno alumno;
        private VistaBuscar vistaDni = new VistaBuscar();
        private VistaTablaAlumnos tablaAlumnos = new VistaTablaAlumnos();
        private VistaPrincipal vistaPrincipal = new VistaPrincipal();

       

        public Controlador()
        {
            try
            {
                this.RellenarTabla();
                this.InicializarEventos();
                vistaPrincipal.ShowDialog();
            }
            catch (NullReferenceException nre)
            {
                MessageBox.Show("NullReferenceException");
              
            }
            catch (Exception ex) {

                MessageBox.Show("Ha ocurrido un error" + ex.ToString());

            }






         
        }
        private void RellenarTabla()
        {

            tablaAlumnos.DataGridView1.DataSource = alumnodao.GetAllAlumnos(connection.Connection);

        }
        private void InicializarEventos()
        {
            try
            {
                vistaPrincipal.Button1.Click += new EventHandler(AbrirVistaTabla);
            vistaPrincipal.Button2.Click += new EventHandler(AbrirVistaDni);
            vistaDni.Button1.Click += new EventHandler(CargarAlumnoDni);
            vistaDni.Button2.Click += new System.EventHandler(EliminarAlumno);
                tablaAlumnos.Button1.Click += new EventHandler(CerrarTabla);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error" + ex.ToString());
            }
        }
        private void CargarAlumnoDni(object sender, EventArgs e)
        {
            try
            {
                String dni = vistaDni.TextBox1.Text;
            alumno = alumnodao.GetAlumno(dni, connection.Connection);
            vistaDni.TextBox2.Text = alumno.Nombre1;
            vistaDni.TextBox3.Text = alumno.Apellido11;
            vistaDni.TextBox4.Text = alumno.Apellido21;
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error" + ex.ToString());
            }
        }
        private void EliminarAlumno(object sender, EventArgs e)
        {
            try
            {
                alumnodao.DeleteAlumno(alumno.Dni1, connection.Connection);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error" + ex.ToString());
            }
         
        }
        private void AbrirVistaTabla(object sender, EventArgs e)
        {
            try
            {
                vistaPrincipal.Hide();

            tablaAlumnos.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error" + ex.ToString());
            }
         
        }
        private void AbrirVistaDni(object sender, EventArgs e)
        {

            vistaPrincipal.Hide();

            vistaDni.ShowDialog();
        }
        private void CerrarTabla(object sender, EventArgs e){
            var confirmar = MessageBox.Show("Estas seguro de que quieres salir", "Confirmar",
                                                MessageBoxButtons.OKCancel,
                                                MessageBoxIcon.Question);
            if (confirmar == DialogResult.OK) {
                tablaAlumnos.Close();
            
            }

        }
    }
}
