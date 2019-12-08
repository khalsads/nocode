using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace nocode
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        //This runs commands when page is loaded
        protected void Page_Load(object sender, EventArgs e)
        {
            GridViewnoCode();
        }

        //This will add page to the database
        protected void Add_Submit(object sender, EventArgs e)
        {
            string dbConnStr = ConfigurationManager.ConnectionStrings["nocodedbConnStr"].ToString();
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
            GridViewnoCode();
            //Close connection with database
            dbConnection.Close();
            Console.WriteLine("Connection Closed...");
        }

        //This will DELETE data by Selected ID
        protected void Del_Data(object sender, EventArgs e)
        {
            int selectedID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            error_msg.InnerHtml += "DELETE FUNCTION CLICKED"+selectedID;

            string dbConnStr = ConfigurationManager.ConnectionStrings["nocodedbConnStr"].ToString();
            MySqlConnection dbConnection = new MySqlConnection(dbConnStr);

            try
            {
                //Write Statement to console pannel when connecting to database
                Console.WriteLine("Connecting to MySql...");

                //Open Connection with database
                dbConnection.Open();

                //Database operations below
                string dbQueryStr = "DELETE FROM test_user_blog WHERE test_user_blog.pageid = "+selectedID+ ";";
                MySqlCommand cmd = new MySqlCommand(dbQueryStr, dbConnection);
                cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            GridViewnoCode();
            //Close connection with database
            dbConnection.Close();
            Console.WriteLine("Connection Closed...");
        }

        //Grid View Class for list all pages
        protected void GridViewnoCode()
        {
            string dbConnStr = ConfigurationManager.ConnectionStrings["nocodedbConnStr"].ConnectionString;
            using (MySqlConnection dbConnection = new MySqlConnection(dbConnStr))
            {
                //Database operations below
                string dbQueryStr = "SELECT pageid, page_header, page_body, page_author FROM test_user_blog;";
                using (MySqlCommand cmd = new MySqlCommand(dbQueryStr))
                {
                    using (MySqlDataAdapter noCodeData = new MySqlDataAdapter())
                    {
                        cmd.Connection = dbConnection;
                        noCodeData.SelectCommand = cmd;
                        using (DataTable noCodeDataTable = new DataTable())
                        {
                            noCodeData.Fill(noCodeDataTable);

                            noCodePageList.DataSource = noCodeDataTable;
                            noCodePageList.DataBind();
                        }
                    }
                }
                //Close connection with database
                dbConnection.Close();
                Console.WriteLine("Connection Closed...");
            }


        }
    }
}