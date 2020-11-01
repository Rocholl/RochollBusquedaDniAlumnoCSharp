using Modelo1.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Modelo1
{
    public class AlumnoDAO
    {

        private DataTable tabla;
        private Alumno alumno;
        private MySqlCommand command;

        private MySqlDataReader leer;
        int numeroDeLibros;

        public DataTable GetAllAlumnos(MySqlConnection con)
        {
            try
            {
                con.Open();
                command = new MySqlCommand("select * from Alumnos;",
                                           con);
                leer = command.ExecuteReader();
                tabla = new DataTable();
                tabla.Load(leer);
            }

            catch (MySqlException mysq)
            {
                MessageBox.Show("Ha ocurrido un error " + mysq.ToString());
            }
            finally
            {
                con.Dispose();
                con.Close();
            }

            return tabla;
        }
        private Alumno CrearAlumno(MySqlDataReader leer)
        {
            int registro;
            String dni;

            String nombre;
            String apellido1;
            String apellido2;
            while (leer.Read())
            {
                registro = leer.GetInt32(0);
                dni = leer.GetString(1);

                nombre = leer.GetString(2);
                apellido1 = leer.GetString(3);
                apellido2 = leer.GetString(4);
                alumno = new Alumno(registro,
                    dni,
                                   nombre,
                                   apellido1,
                                   apellido2);
            }

            return alumno;
        }
        public Alumno GetAlumno(String Dni, MySqlConnection con)
        {
            MySqlDataReader readerAlumno;
            try
            {

                con.Open();

                command = new MySqlCommand("SELECT * FROM Alumnos WHERE dni=@val1", con);
                command.Parameters.AddWithValue("@val1", Dni);
                command.Prepare();
                readerAlumno = command.ExecuteReader();
                alumno = this.CrearAlumno(readerAlumno);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
          
            finally
            {
                con.Close();
            }

            return alumno;


        }
        private int GetAlumnoLibros(String Dni, MySqlConnection con)
        {
            alumno = GetAlumno(Dni, con);
            int registro = alumno.Registro1;
            try
            {
                con.Open();


                command = new MySqlCommand("SELECT COUNT(codLibros) FROM prestamos WHERE codAlumno=@val1", con);
                command.Parameters.AddWithValue("@val1", registro);
                command.Prepare();
                leer = command.ExecuteReader();
                while (leer.Read())
                {
                    numeroDeLibros = leer.GetInt32(0);
                }
            }
            catch (MySqlException mysq)
            {
                MessageBox.Show("Ha ocurrido un error " + mysq.ToString());
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            finally
            {
                con.Close();
            }

            return numeroDeLibros;


        }
        public void DeleteAlumno(String Dni, MySqlConnection con)
        {
            if (this.GetAlumnoLibros(Dni, con) <= 0)
            {
                try
                {
                    con.Open();
                    command = new MySqlCommand("DELETE FROM Alumnos WHERE Dni=@val1", con);
                    command.Parameters.AddWithValue("@val1", Dni);
                    command.Prepare();
                    leer = command.ExecuteReader();







                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }

                finally
                {
                    con.Close();
                }

            }
            else
            {
                MessageBox.Show("No es posible eliminar el alumno ya que posee " + this.GetAlumnoLibros(Dni, con) + " libros en prestamo");

            }
        }
    }
}
