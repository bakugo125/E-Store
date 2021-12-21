using OnlineStore.Common;
using System;
using System.Data;

namespace OnlineStore.Pages.Membership
{
    public partial class Login : System.Web.UI.Page
    {
        Utilities p = new Utilities();
        protected void Page_Load(object sender, EventArgs e)
        {
            Email.Focus();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            lblResults.Text = "";
            string email = p.FixString(Email.Text);
            string password = p.FixString(Password.Text);

            string query = string.Format("SELECT Name, Role, Password, ID FROM Users WHERE email = '{0}' AND Password = '{1}'", email, password);
            DataTable dt = p.GetDataTable(query);

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                Session["UserName"] = dr[0].ToString();
                Session["UserRole"] = dr[1].ToString();
                Session["ID"] = dr[3].ToString();
                Response.Redirect(@"~\Default.aspx");
            }

            else
            {
                lblResults.Text = "No such user exists.";
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Email.Text = "";
            Password.Text = "";
            Response.Redirect(@"~\Pages\Membership\Logout.aspx");
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"~\Pages\Membership\SignUp.aspx");
        }
    }
}