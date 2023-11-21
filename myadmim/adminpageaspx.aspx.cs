using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment4_Nov17.myadmim
{
    public partial class adminpageaspx : System.Web.UI.Page
    {
        KarateDataContext dbcon;
        KarateDataContext dbcon2;
        Var UserId;
        Var UserId1;
        protected void Page_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        public void Refresh()
        {
            string conn = ConnectionString.conn;
            dbcon = new KarateDataContext(conn);
            dbcon2 = new KarateDataContext(conn);

            // Select all records from the member table
            var result = from item in dbcon.Members
                         select new
                         {
                             item.MemberFirstName,
                             item.MemberLastName,
                             item.MemberPhoneNumber,
                             item.MemberDateJoined
                         };

            // Add it to the GridView1
            GridView1.DataSource = result;
            GridView1.DataBind();

            // Select all Records from the Instructors Table
            var instructor = from item in dbcon2.Instructors
                             orderby item.InstructorFirstName, item.InstructorLastName
                             select new
                             {
                                 item.InstructorFirstName,
                                 item.InstructorLastName
                             };

            // Add it to the GridView2
            GridView2.DataSource = instructor;
            GridView2.DataBind();
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void MemberCreateBtn_Click(object sender, EventArgs e)
        {
            string conn = ConnectionString.conn;

            dbcon = new KarateDataContext(conn);

            // create instance of new user
            NetUser newuser = new NetUser();
            if (usertypeDropDown.SelectedValue == "Member")
            {
                Member newmember = new Member();
                newuser.UserName = usernameTextBox.Text;
                newuser.UserPassword = passwordTextBox.Text;
                newuser.UserType = "Member";
                dbcon.NetUsers.InsertOnSubmit(newuser);
                try
                {
                    dbcon.SubmitChanges();
                    newuser = (from x in dbcon.NetUsers
                               where (x.UserName == usernameTextBox.Text)
                               select x).First();
                    newmember.Member_UserID = newuser.UserID;
                    newmember.MemberFirstName = MemberFirstNameTxt.Text;
                    newmember.MemberLastName = MemberLastNameTxt.Text;
                    newmember.MemberPhoneNumber = MemberPhoneTxt.Text;
                    newmember.MemberEmail = MemberEmailTxt.Text;
                    newmember.MemberDateJoined = DateTime.Now;
                    dbcon.Members.InsertOnSubmit(newmember);
                    dbcon.SubmitChanges();
                    deleteError.Text = "Member successfully created! :)";
                }
                catch
                {
                    deleteError.Text = "Something went wrong :(";
                }

            }
            else if (usertypeDropDown.SelectedValue == "Instructor")
            {
                Instructor newinstructor = new Instructor();
                newuser.UserName = usernameTextBox.Text;
                newuser.UserPassword = passwordTextBox.Text;
                newuser.UserType = "Instructor";
                dbcon.NetUsers.InsertOnSubmit(newuser);
                try
                {
                    dbcon.SubmitChanges();
                    newuser = (from x in dbcon.NetUsers
                               where (x.UserName == usernameTextBox.Text)
                               select x).First();
                    newinstructor.InstructorID = newuser.UserID;
                    newinstructor.InstructorFirstName = MemberFirstNameTxt.Text;
                    newinstructor.InstructorLastName = MemberLastNameTxt.Text;
                    newinstructor.InstructorPhoneNumber = MemberPhoneTxt.Text;
                    dbcon.Instructors.InsertOnSubmit(newinstructor);
                    dbcon.SubmitChanges();
                    deleteError.Text = "Instructor successfully created! :)";
                }
                catch
                {
                    deleteError.Text = "Something went wrong :(";
                }
            }
            Refresh();
        }

        protected void InstructorBtn_Click(object sender, EventArgs e)
        {

            
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = DeleteTextBox.Text;
                NetUser deleteuser = (from x in dbcon.NetUsers
                                      where x.UserName == userName
                                      select x).First();
                if (deleteuser.UserType == "Member")
                {
                    Member deletemember = (from x in dbcon.Members
                                           where x.Member_UserID == deleteuser.UserID
                                           select x).First();
                    dbcon.Members.DeleteOnSubmit(deletemember);
                    dbcon.SubmitChanges();
                    dbcon.NetUsers.DeleteOnSubmit(deleteuser);
                    dbcon.SubmitChanges();
                    deleteError.Text = "Member sucessfully deleted.";
                }
                else if (deleteuser.UserType == "Instructor")
                {
                    Instructor deleteinstructor = (from x in dbcon.Instructors
                                                   where x.InstructorID == deleteuser.UserID
                                                   select x).First();
                    dbcon.Instructors.DeleteOnSubmit(deleteinstructor);
                    dbcon.SubmitChanges();
                    dbcon.NetUsers.DeleteOnSubmit(deleteuser);
                    dbcon.SubmitChanges();
                    deleteError.Text = "Instructor sucessfully deleted";
                }
            }
            catch
            {
                deleteError.Text = "Something went wrong";
            }
            Refresh();

        }

        protected void AddSectionBtn_Click(object sender, EventArgs e)
        {
        }

        protected void sectionBtn_Click(object sender, EventArgs e)
        {

            string conn = ConnectionString.conn;

            dbcon = new KarateDataContext(conn);

            Section NewSection = new Section();
            NewSection.SectionName = sectionNameDrpDwn.SelectedValue.ToString();
            NewSection.SectionStartDate = DateTime.Now;
            NewSection.Member_ID = Convert.ToInt32(MemberIdTextBox.Text);
            NewSection.Instructor_ID = Convert.ToInt32(InstructorIdTextBox.Text);
            NewSection.SectionFee = Convert.ToDecimal(sectionFeeTxt.Text);

            dbcon.Sections.InsertOnSubmit(NewSection);
            dbcon.SubmitChanges();
        }
    }
}
