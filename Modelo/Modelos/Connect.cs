using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.Common;
using MySql.Data.MySqlClient;
using System.Windows;


namespace Modelo
{
    public class Connect
    {
        private String user;
        private String password;
        private String server;
        private String database;
        private MySqlConnectionStringBuilder stringConection;
        private static Connect _singleton;
        private static MySqlConnection connection;
        

        private Connect()
        {
          
        }
  
        public static MySqlConnection Conectar()
        {  if (_singleton == null)
            {
                String user = "root";
                String password = "";
                String server = "localhost";
                String database = "libros";
                try
                {
                    stringConection = new MySqlConnectionStringBuilder();
                    stringConection.Server = server;
                    stringConection.UserID = user;
                    stringConection.Password = password;
                    stringConection.Database = database;
                    stringConection.IntegratedSecurity = true;
                    stringConection.SqlServerMode = true;
                    connection = new MySqlConnection(stringConection.ToString());

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex);
                }
                
            }
            else { MessageBox.Show("Una instacia de la conexion ya esta activa"); }
            return connection;
        }
      
    }
}
