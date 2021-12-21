using OnlineStore.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineStore.Pages.Users
{
    public partial class NewUser : System.Web.UI.Page
    {
        Utilities p = new Utilities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserRole"].ToString() == "admin")
            {
                if (!IsPostBack)
                {
                    loadUsers();
                }
            }
        }

        protected void btnCreateUser_Click(object sender, EventArgs e)
        {
            lblSuccess.Text = lblWarning.Text = "";
            string userEmail = p.FixString(txtEmail.Text);
            string checkUserQuery = string.Format("SELECT email FROM Users WHERE (email = '{0}')", userEmail);

            DataTable dt = p.GetDataTable(checkUserQuery);

            if (dt.Rows.Count > 0)
            {
                showWarningMessage("User already exists, please select a different user name.");
            }
            else
            {
                string password = p.FixString(txtPassword.Text);
                string card = p.FixString(txtCard.Text);
                string phone = p.FixString(txtPhone.Text);
                string role = cmbUserType.SelectedValue;
                string name = p.FixString(txtUserName.Text);
                string address = p.FixString(txtAddress.Text);

                string query = string.Format("INSERT INTO Users (Name, Role, Email, Password, Address, cardNum, Phone) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", name, role, userEmail, password, address, card, phone);
                p.ExecuteQuery(query);
                loadUsers();
            }
        }

        private void loadUsers()
        {
            string users = "SELECT [Name] FROM [Users] ORDER BY [Name] ";
            DataTable dt = p.GetDataTable(users);

            if (dt.Rows.Count > 0)
            {
                gridUsers.DataSource = dt;
                gridUsers.DataBind();

                gridUsers.UseAccessibleHeader = true;
                gridUsers.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        private void showWarningMessage(string s)
        {
            lblWarning.Visible = true;
            lblWarning.Text = p.getWarningMessage(s);
        }
    }
}