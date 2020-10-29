using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.Common;
using MySql.Data.MySqlClient;
using System.Windows;


namespace Modelo
{
    class Connect
    {
        private String user;
        private String password;
        private String server;
        private String database;
        MySqlConnectionStringBuilder stringConection;
        private MySqlConnection connection;
        private MySqlCommand cmd;

        public Connect()
        {
            user = "root";
            password = "";
            server = "localhost";
            database = "libros";
        }
        public MySqlConnection Connection1
        {
            get { return connection; }
            set { connection = value; }

        }
        public void Conectar()
        {
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
                cmd = connection.CreateCommand();
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
