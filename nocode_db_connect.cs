using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace nocode
{
    public class nocode_db_connect
    {
        public static void Main()
        {
            string dbConnStr = "server=localhost;user=root;database=blog;port=3306;password=root";
            MySqlConnection dbConnection = new MySqlConnection(dbConnStr);
            try
            {
                //Write Statement to console pannel when connecting to database
                Console.WriteLine("Connecting to MySql...");

                //Open Connection with database
                dbConnection.Open();
                
                //Database operations below

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Close connection with database
            dbConnection.Close();
            Console.WriteLine("Connection Closed...");
        }
    }
}