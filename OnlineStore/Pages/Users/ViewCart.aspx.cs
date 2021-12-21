using OnlineStore.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace OnlineStore.Pages.Users
{
	public partial class ViewCart : System.Web.UI.Page
	{
		Utilities p = new Utilities();
		Dictionary<string, object> photos = new Dictionary<string, object>();
		public Product product = new Product();

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				dataBindPhotos();
				pnlDetails.Visible = false;
			}
		}

		private void dataBindPhotos()
		{
			string imageSrc = string.Empty;
			string query = "SELECT ProductID, picture FROM Product";
			string dtQuery = string.Format("SELECT Product.picture, Product.name as name, Product.description as description, ShoppingCart.quantity as quantity, Product.price as price, ShoppingCart.ID as cartID, ShoppingCart.productID as id FROM ShoppingCart INNER JOIN Product ON ShoppingCart.productID = Product.ProductID WHERE (ShoppingCart.userID = {0})", int.Parse(Session["ID"].ToString())) ;
			photos = p.getIntObjectDictionary(query);
			DataTable dt = p.GetDataTable(dtQuery);
			gridPhotos.DataSource = dt;
			gridPhotos.DataBind();

			for (int i = 0; i < gridPhotos.Rows.Count; i++)
			{
				Label lName = (Label)gridPhotos.Rows[i].FindControl("lblID");
				string id = lName.Text;
				object data = new object();
				if (photos.TryGetValue(id, out data))
				{
					byte[] bytesPhoto = (byte[])data;
					string base64Photo = Convert.ToBase64String(bytesPhoto);
					imageSrc = "data:image/jpeg; base64," + base64Photo;
				}
				else
				{
				}

				HtmlImage image = (HtmlImage)gridPhotos.Rows[i].FindControl("dbImage");
				image.Src = imageSrc;
			}

			if (gridPhotos.Rows.Count > 0)
			{
				refreshGrid();
			}
		}

		private void refreshGrid()
		{
			gridPhotos.UseAccessibleHeader = true;
			gridPhotos.HeaderRow.TableSection = TableRowSection.TableHeader;
		}

		protected void gridPhotos_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			pnlDetails.Visible = false;
			try
			{
				int productID = int.Parse(e.CommandArgument.ToString());
				showProduct(productID);
				pnlDetails.Visible = true;
				refreshGrid();
			}
			catch (SqlException ex)
			{
				Console.WriteLine("SQL Error" + ex.Message.ToString());
			}
		}

		private void showProduct(int id)
		{
			string query = string.Format("SELECT ProductID AS id, name, price, description, rating FROM Product WHERE ProductID = {0}", id);

			DataTable dt = p.GetDataTable(query);

			if (dt.Rows.Count > 0)
			{
				DataRow dr = dt.Rows[0];
				viewPhoto(id);
				product.ProductName = dr[1].ToString();
				product.ProductPrice = int.Parse(dr[2].ToString());
				product.ProductDescription = dr[3].ToString();
				product.ProductRating = int.Parse(dr[4].ToString());
			}

		}

		private void viewPhoto(int id)
		{
			string base64Photo = string.Empty;

			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = ConfigurationManager.ConnectionStrings["LabProjectConnectionString"].ToString();
				using (SqlCommand cmd = new SqlCommand())
				{
					cmd.CommandText = "SELECT picture FROM product WHERE productID = @id";
					cmd.Parameters.Clear();
					cmd.Parameters.AddWithValue("@id", id);
					cmd.Connection = conn;
					try
					{
						conn.Open();
						byte[] bytesPhoto = (byte[])cmd.ExecuteScalar();
						base64Photo = Convert.ToBase64String(bytesPhoto);

						string imageSrc = "data:image/jpeg; base64," + base64Photo;
						myImage.Src = imageSrc;

					}
					catch (SqlException ex)
					{
						Console.WriteLine("SQL Error" + ex.Message.ToString());
					}
				}
			}
		}
	}
}