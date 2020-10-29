using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Xceed.Wpf.Toolkit;

namespace Modelo.DAO
{
    class AlumnoDAO
    {
        Connect connect;
        DataTable tabla = new DataTable();
        Alumno alumno;
        MySqlCommand command;
        MySqlConnection conn;
        MySqlDataReader leer;
        int numeroDeLibros;
        private DataTable GetAllAlumnos()
        {
            try {
                connect = new Connect();
                connect.Conectar();
                connect.Connection1.Open();
                conn = connect.Connection1;

                command = new MySqlCommand("select * from Alumnos;", conn);
                leer = command.ExecuteReader();
                tabla.Load(leer);
            } catch (Exception ex) {
                MessageBox.Show(ex);
            }
            finally {
                connect.Connection1.Close();
                
            }
            return tabla;
        }
        private Alumno CrearAlumno(MySqlDataReader leer) {
            alumno = new Alumno(leer.GetString(0), leer.GetString(1), leer.GetString(2), leer.GetString(3));
            return alumno;
        }
        private Alumno GetAlumno(String Dni)
        {
            try
            {
                connect = new Connect();
            connect.Conectar();
            connect.Connection1.Open();

           conn = connect.Connection1;
            command = new MySqlCommand("SELECT * FROM Alumnos WHERE Dni=@val1", conn);
            command.Parameters.AddWithValue("@val1", Dni);
            command.Prepare();
            leer = command.ExecuteReader();
            }
              catch (Exception ex) {
                MessageBox.Show(ex);
            }
              finally {
                connect.Connection1.Close();
                
            }
            return this.CrearAlumno(leer);

            
        }
        private int GetAlumnoLibros(String Dni)
        {
            try
            {
                connect = new Connect();
                connect.Conectar();
                connect.Connection1.Open();

                conn = connect.Connection1;
                command = new MySqlCommand("SELECT COUNT(codLibros) FROM Prestamos WHERE Dni=@val1", conn);
                command.Parameters.AddWithValue("@val1", Dni);
                command.Prepare();
                leer = command.ExecuteReader();
                 numeroDeLibros = leer.GetInt32(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex);
            }
            finally
            {
                connect.Connection1.Close();

            }
            return numeroDeLibros;


        }
        private void DeleteAlumno(String Dni) 
        {

            if (this.GetAlumnoLibros(Dni) <= 0)
            {
                try
                {
                    connect = new Connect();
                    connect.Conectar();
                    connect.Connection1.Open();
                    conn = connect.Connection1;





                }
           } else
            {
                MessageBox.Show("No es posible crear el alumno ya que posee "+ this.GetAlumnoLibros(Dni)+"libros en prestamo");

            }
    }

