using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment4_Nov17.mymembers
{
    public partial class mymemberpage : System.Web.UI.Page
    {
        string conn = ConnectionString.conn;
        KarateDataContext dbcon;

        protected void Page_Load(object sender, EventArgs e)
        {
            //create database connection
            dbcon = new KarateDataContext(conn);

            //TODO -- get MemberID from session
            int memberID =Convert.ToInt32( HttpContext.Current.Session["userID"]);

            //find member in table
            var member = (from x in dbcon.Members
                          where x.Member_UserID == memberID
                          select x).First();

            string fname = member.MemberFirstName;
            string lname = member.MemberLastName;

            //set label to name
            fnameLabel.Text = fname;
            lnameLabel.Text = lname;

            //Fill GridView
            using (SqlConnection dbconn = new SqlConnection(conn))
            {
                string query = "select SectionName, InstructorFirstName, InstructorLastName, " +
                    "SectionStartDate, SectionFee from Section join Instructor on Instructor_ID = InstructorID " +
                    "where Member_ID = " + memberID.ToString();

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