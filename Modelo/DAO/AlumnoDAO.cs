using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Forms;

namespace Modelo.DAO
{
   public class AlumnoDAO
    {
        
        DataTable tabla = new DataTable();
        Alumno alumno;
        MySqlCommand command;
        
        MySqlDataReader leer;
        int numeroDeLibros;
        
        private DataTable GetAllAlumnos(MySqlConnection con)
        {
            try {            
                command = new MySqlCommand("select * from Alumnos;", con);
                leer = command.ExecuteReader();
                tabla.Load(leer);
            } catch (Exception ex) {
              MessageBox.Show(ex);
            }
           
            return tabla;
        }
        private Alumno CrearAlumno(MySqlDataReader leer) {
            alumno = new Alumno(leer.GetString(0), leer.GetString(1), leer.GetString(2), leer.GetString(3));
            return alumno;
        }
        private Alumno GetAlumno(String Dni,MySqlConnection con)
        {
            try
            {
             

               
                command = new MySqlCommand("SELECT * FROM Alumnos WHERE Dni=@val1", con);
                command.Parameters.AddWithValue("@val1", Dni);
                command.Prepare();
                leer = command.ExecuteReader();
            }
            catch (Exception ex) {
                MessageBox.Show(ex);
            }
         
            return this.CrearAlumno(leer);


        }
        private int GetAlumnoLibros(String Dni, MySqlConnection con)
        {
            try
            {
              

               
                command = new MySqlCommand("SELECT COUNT(codLibros) FROM Prestamos WHERE Dni=@val1", con);
                command.Parameters.AddWithValue("@val1", Dni);
                command.Prepare();
                leer = command.ExecuteReader();
                numeroDeLibros = leer.GetInt32(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex);
            }
           
            return numeroDeLibros;


        }
        private void DeleteAlumno(String Dni, MySqlConnection con)
        {

            if (this.GetAlumnoLibros(Dni,con) <= 0)
            {
                try
                {
                    
                    command = new MySqlCommand("DELETE FROM Alumno WHERE Dni=@val1", con);
                    command.Parameters.AddWithValue("@val1", Dni);
                    command.Prepare();
                    leer = command.ExecuteReader();







                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }
               
           } else
            {
                MessageBox.Show("No es posible crear el alumno ya que posee " + this.GetAlumnoLibros(Dni,con) + "libros en prestamo");

            }
        }
    }
}

