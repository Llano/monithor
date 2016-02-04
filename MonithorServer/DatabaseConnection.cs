using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MonithorServer
{
    public class DatabaseConnection
    {
        public string user { get; set; }
        public string password { get; set; }
        public string serverAdress { get; set; }
        public string database { get; set; }
        public string connectionString { get; set; }
        public DatabaseConnection(string user, string password, string serverAdress, string database)
        {
            this.user = user;
            this.password = password;
            this.serverAdress = serverAdress;
            this.database = database;
            this.connectionString = "SERVER=" + this.serverAdress + ";" + "DATABASE=" +
            this.database + ";" + "UID=" + this.user + ";" + "PASSWORD=" + this.password + ";";
        }


        // check if ot's possible to connectoto the selected database
        public bool databaseAvaiable()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
                
            }


        }

        // Retrieve the Arma servers from the database
        public Dictionary<string, int> getArmaServers()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {

                Dictionary<String, int> serverList = new Dictionary<string, int>();
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT * from servers", connection);

                    //Get the DataReader from the comment using ExecuteReader
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        //Use GetString etc depending on the column datatypes.
                        serverList.Add(reader["key"].ToString(), reader.GetInt32("id"));
                    }


                }
                catch (Exception e)
                {


                }

                return serverList;
            }

        }

        public override string ToString()
        {
            return this.connectionString;
        }
    }
}
