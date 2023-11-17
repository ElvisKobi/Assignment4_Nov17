using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment4_Nov17.mymembers
{
    public partial class mymemberpage : System.Web.UI.Page
    {
        string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\elvis\\OneDrive\\Desktop\\CSCI 213 Project\\Assignment4_Nov17\\App_Data\\KarateSchool.mdf\";Integrated Security=True;Connect Timeout=30";
        KarateDataContext dbcon;

        int myMemberID;
        public string myMemberUserName;
        protected void Page_Load(object sender, EventArgs e)
        {
            //  myMemberUserName=User.Identity.Name;

            myMemberUserName = "user1";

            dbcon = new KarateDataContext(conn);


            //search for Member ID
            NetUser mymem=(from x in dbcon.NetUsers
                          where x.UserName == myMemberUserName
                          select x).First();

            myMemberID=mymem.UserID; 


          var result= from x in dbcon.Members
                      where x.Member_UserID == myMemberID
                      select x;

            GridView1.DataSource = result;
            GridView1.DataBind();

        }
    }
}