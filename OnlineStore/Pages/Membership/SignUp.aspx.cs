using OnlineStore.Common;
using System;
using System.Data;
using System.Data.SqlClient;

namespace OnlineStore.Pages.Membership
{
    public partial class SignUp : System.Web.UI.Page
    {
        Utilities p = new Utilities();
        protected void Page_Load(object sender, EventArgs e)
        {
            Email.Focus();
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            lblResults.Text = "";
            string email = p.FixString(Email.Text);
            string checkUserQuery = string.Format("SELECT email FROM Users WHERE (email = '{0}')", email);

            DataTable dt = p.GetDataTable(checkUserQuery);

            if (dt.Rows.Count > 0)
            {
                lblResults.Text = "User already exists, please select a different user name.";
            }
            else
            {
                string password = p.FixString(Password.Text);
                string card = p.FixString(CardNum.Text);
                string phone = p.FixString(Phone.Text);
                string role = cmbUserType.SelectedValue;
                string name = p.FixString(Name.Text);
                string address = p.FixString(Address.Text);

                string query = string.Format("INSERT INTO Users (Name, Role, Email, Password, Address, cardNum, Phone) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", name, role, email, password, address, card, phone);
                
                try
                {
                    p.ExecuteQuery(query);
                    Response.Redirect(@"~\Pages\Membership\Login.aspx");
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error" + ex.Message.ToString());
                    Response.Redirect(@"~\Pages\Membership\SignUp.aspx");
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Email.Text = "";
            Password.Text = "";
            Name.Text = "";
            Address.Text = "";
            CardNum.Text = "";
            Phone.Text = "";
            Response.Redirect(@"~\Pages\Membership\SignUp.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"~\Pages\Membership\Login.aspx");
        }
    }
}