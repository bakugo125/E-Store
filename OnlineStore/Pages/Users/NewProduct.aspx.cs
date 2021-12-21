using OnlineStore.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace OnlineStore.Pages.Users
{
    public partial class NewProduct : System.Web.UI.Page
    {
        Utilities p = new Utilities();
        string variable = string.Empty;
        Dictionary<string, object> photos = new Dictionary<string, object>();

        protected void Page_Load(object sender, EventArgs e)
        {
            variable = Session["UserName"].ToString() + "_photo";
            if (!IsPostBack)
            {
                dataBindPhotos();
            }
        }

        private void showWarningMessage(string s)
        {
            lblWarning.Visible = true;
            lblWarning.Text = p.getWarningMessage(s);
        }

        private void showSuccessMessage(string s)
        {
            lblSuccess.Visible = true;
            lblSuccess.Text = p.getSuccessMessage(s);
        }

        private void clearLabels()
        {
            lblSuccess.Visible = lblWarning.Visible = false;
        }

        protected void btnSubmitPhoto_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Session["ID"].ToString());
            HttpPostedFile postedFile = Request.Files[0];

            if (postedFile != null && postedFile.ContentLength > 0)
            {
                string fileName = Path.GetFileName(postedFile.FileName);
                string fileExtension = Path.GetExtension(fileName);

                fileExtension = fileExtension.ToLower();

                if (fileExtension == ".jpg" || fileExtension == ".jpeg" || fileExtension == ".bmp" || fileExtension == ".png" || fileExtension == ".gif")
                {
                    Stream stream = postedFile.InputStream;
                    BinaryReader binaryReader = new BinaryReader(stream);
                    byte[] photo = binaryReader.ReadBytes((int)stream.Length);

                    using (SqlConnection conn = new SqlConnection())
                    {
                        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LabProjectConnectionString"].ToString();
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = " DELETE FROM tmpimage WHERE id = @id  INSERT INTO  tmpimage(id, photo) VALUES (@id,@photo)";
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@photo", photo);
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.Connection = conn;
                            try
                            {
                                conn.Open();
                                int effectedRows = 0;
                                effectedRows = cmd.ExecuteNonQuery();

                                if (effectedRows > 0)
                                {
                                    viewPhoto(id);
                                }
                            }
                            catch (SqlException ex)
                            {
                                Console.WriteLine("SQL Error" + ex.Message.ToString());
                            }
                        }
                    }
                }
            }
            else
            {
                showWarningMessage("Select a file and a valid student ID.");
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
                    cmd.CommandText = "SELECT photo FROM tmpimage WHERE id = @id";
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

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            clearLabels();
            try
            {
                int id = int.Parse(Session["ID"].ToString());
                string name = p.FixString(txtProductName.Text);
                int price = int.Parse(p.FixString(txtPrice.Text));
                string decriptions = p.FixString(txtDescription.Text);
                string sellerID = Session["ID"].ToString();
                int rating = 0;
                byte[] picture = getPicture(id);

                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["LabProjectConnectionString"].ToString();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = " INSERT INTO Product(name, SellerID, price, rating, picture, description) VALUES (@name, @id, @price, @rating, @picture, @description)";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@price", price);
                        cmd.Parameters.AddWithValue("@rating", rating);
                        cmd.Parameters.AddWithValue("@description", decriptions);
                        cmd.Parameters.AddWithValue("@picture", picture);
                        cmd.Connection = conn;
                        try
                        {
                            conn.Open();
                            int effectedRows = 0;
                            effectedRows = cmd.ExecuteNonQuery();

                            if (effectedRows > 0)
                            {
                                viewPhoto(id);
                                showSuccessMessage("Product Added Successfully.");
                                dataBindPhotos();
                            }
                        }
                        catch (SqlException ex)
                        {
                            Console.WriteLine("SQL Error" + ex.Message.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                showWarningMessage(ex.Message);
            }
        }

        private byte[] getPicture(int id)
        {
            string base64Photo = string.Empty;
            byte[] bytesPhoto = null;

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["LabProjectConnectionString"].ToString();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT photo FROM tmpimage WHERE id = @id";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection = conn;
                    try
                    {
                        conn.Open();
                        bytesPhoto = (byte[])cmd.ExecuteScalar();
                        return bytesPhoto;

                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("SQL Error" + ex.Message.ToString());
                        return bytesPhoto;
                    }
                }
            }
        }

        private void dataBindPhotos()
        {
            string imageSrc = string.Empty;
            string query = "SELECT ProductID, picture FROM Product";
            string dtQuery = string.Format("SELECT ProductID AS id, name, price, description FROM Product WHERE SellerID = '{0}'", Session["ID"].ToString());
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
    }
}