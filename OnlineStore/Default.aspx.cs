using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineStore
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect(@"~\Pages\Membership\Login.aspx");
            }
            else
            {
                string role = Session["UserRole"].ToString();

                if (Session["UserRole"].ToString() == "admin")
                    Response.Redirect(@"~\Pages\Users\Admin.aspx");

                else if (Session["UserRole"].ToString() == "seller")
                {
                    Response.Redirect(@"~\Pages\Users\Seller.aspx");
                }
                else if (Session["UserRole"].ToString() == "customer")
                {
                    Response.Redirect(@"~\Pages\Users\customer.aspx");
                }
                else
                {
                    Response.Redirect(@"~\Pages\Membership\Login.aspx");
                }
            }
        }
    }
}