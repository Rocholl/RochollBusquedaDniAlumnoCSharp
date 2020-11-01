using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modelo1.Modelos
{
    
        public class Connect
        {
            private String user;
            private String password;
            private String server;
            private String database;

            private  MySqlConnection connection;


        public MySqlConnection Connection { get => connection; set => connection = value; }

        public Connect()
            {
             user = "root";
             password = "";
             server = "localhost";
             database = "libros";
            Conectar();
        }

        public void Conectar()
        { 
                   
                    try
                    {
                    var stringConection = new MySqlConnectionStringBuilder
                    {
                        Server = server,
                        UserID = user,
                        Password = password,
                        Database = database,
                        IntegratedSecurity = true,
                        SqlServerMode = true
                    };
                    connection = new MySqlConnection(stringConection.ToString());
           
             
                    }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
            catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                }
               
            
            

        }
    }

