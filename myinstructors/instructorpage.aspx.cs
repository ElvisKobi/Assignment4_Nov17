using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment4_Nov17.myinstructors
{
    public partial class instructorpage : System.Web.UI.Page
    {
        string conn = ConnectionString.conn;
        KarateDataContext dbcon;
        protected void Page_Load(object sender, EventArgs e)
        {
            //create database connection
            dbcon = new KarateDataContext(conn);

            //TODO -- get InstructorID from session
            int instructorID = Convert.ToInt32(HttpContext.Current.Session["userID"]);

            //find member in table
            var instructor = (from x in dbcon.Instructors
                              where x.InstructorID == instructorID
                              select x).First();

            string fname = instructor.InstructorFirstName;
            string lname = instructor.InstructorLastName;

            //set label to name
            FnameLabel.Text = fname;
            lnameLabel.Text = lname;


            //Fill GridView
            using (SqlConnection dbconn = new SqlConnection(conn))
            {
                string query = "select SectionName, MemberFirstName,MemberLastName " +
                    " from Section join Member on Member_ID = Member_UserID " +
                    "where Instructor_ID = " + instructorID.ToString();

                //define the SqlCommand object
                SqlCommand cmd = new SqlCommand(query, dbconn);


                //set the SqlDataAdapter object
                SqlDataAdapter dAdapter = new SqlDataAdapter(cmd);

                //define dataset
                DataSet ds = new DataSet();

                //fill dataset with query results
                dAdapter.Fill(ds);

                //set the DataGridView control's data source/data table
                resultGridView.DataSource = ds.Tables[0];

                resultGridView.DataBind();

                //close connection
                dbconn.Close();
            }
        }
    }
}