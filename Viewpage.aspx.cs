using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace nocode
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        //This runs commands when page is loaded
        protected void Page_Load(object sender, EventArgs e)
        {
            ListResult.InnerHtml = "";
            string dbConnStr = System.Configuration.ConfigurationManager.ConnectionStrings["nocodedbConnStr"].ToString();
            MySqlConnection dbConnection = new MySqlConnection(dbConnStr);
            try
            {
                //Write Statement to console pannel when connecting to database
                Console.WriteLine("Connecting to MySql...");

                //Open Connection with database
                dbConnection.Open();

                //Database operations below
                string dbQueryStr = "SELECT pageid, page_header, page_body, page_author FROM test_user_blog;";

                MySqlCommand cmd = new MySqlCommand(dbQueryStr, dbConnection);

                MySqlDataReader reader = cmd.ExecuteReader();

                //error_msg.InnerHtml += "Working....";

                if (reader.FieldCount == 0)
                {
                    error_msg.InnerHtml += "No Result Found";
                }
                else
                {
                    if (reader.HasRows)
                    {
                        int i = 1;
                        while (reader.Read())
                        {
                            int pageid = Int32.Parse(reader[0].ToString());
                            string page_header = reader[1].ToString();
                            string page_author = reader[3].ToString();
                            string page_body = reader[2].ToString();

                            ListResult.InnerHtml += "<tr><th>" + i + "</th>";
                            ListResult.InnerHtml += "<td>" + page_header + "</td>";
                            ListResult.InnerHtml += "<td>" + page_author + "</td>";
                            ListResult.InnerHtml += "<td>" + page_body + "</td>";
                            ListResult.InnerHtml += "<td><button runat='server' id="+pageid+" onclick='Del_Data'>DELETE</button></td></tr>";
                            i++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Close connection with database
            dbConnection.Close();
            Console.WriteLine("Connection Closed...");

        }

        //This will add page to the database
        protected void Add_Submit(object sender, EventArgs e)
        {
            string dbConnStr = System.Configuration.ConfigurationManager.ConnectionStrings["nocodedbConnStr"].ToString();
            MySqlConnection dbConnection = new MySqlConnection(dbConnStr);
            try
            {
                //Write Statement to console pannel when connecting to database
                Console.WriteLine("Connecting to MySql...");

                //Open Connection with database
                dbConnection.Open();

                //Database operations below
                string dbQueryStr = "INSERT INTO test_user_blog (page_header, page_body, page_author) VALUES ('" + page_head_input.Text + "', '" + page_body_input.Text + "', '" + page_author_input.Text+ "');";

                MySqlCommand cmd = new MySqlCommand(dbQueryStr, dbConnection);

                cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Close connection with database
            dbConnection.Close();
            Console.WriteLine("Connection Closed...");
        }

        //This will del data by ID
        protected void Del_Data(object sender, EventArgs e)
        {
            error_msg.InnerHtml += "DELETE FUNCTION CLICKED"+e.ToString();
            //string dbConnStr = System.Configuration.ConfigurationManager.ConnectionStrings["nocodedbConnStr"].ToString();
            //MySqlConnection dbConnection = new MySqlConnection(dbConnStr);
            //try
            //{
            //    //Write Statement to console pannel when connecting to database
            //    Console.WriteLine("Connecting to MySql...");

            //    //Open Connection with database
            //    dbConnection.Open();

            //    //Database operations below
            //    string dbQueryStr = "DELETE FROM test_user_blog WHERE test_user_blog.pageid = "+pageid+";";

            //    MySqlCommand cmd = new MySqlCommand(dbQueryStr, dbConnection);

            //    cmd.ExecuteReader();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            ////Close connection with database
            //dbConnection.Close();
            //Console.WriteLine("Connection Closed...");
        }
    }
}