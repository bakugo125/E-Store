<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Users/Seller.master" AutoEventWireup="true" CodeBehind="NewProduct.aspx.cs" Inherits="OnlineStore.Pages.Users.NewProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content4" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content5" runat="server">
    <h1>New Product</h1>
    <hr />
    <asp:Label runat="server" ID="lblSuccess" Text="Label Sucess" CssClass="tag success" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblWarning" Text="Label Warning" CssClass="tag alert" Visible="false"></asp:Label>
    <br />

    <div class="cell colspan3">
        <h4>Product Details</h4>
        <hr />
        <div class="input-control text full-size">
            <asp:TextBox runat="server" placeholder="Name of Product" ID="txtProductName" ></asp:TextBox>
        </div>
        <div class="input-control text full-size">
            <asp:TextBox runat="server" placeholder="Price of Product" ID="txtPrice" MaxLength="13" onkeypress="return isNumber(event)"></asp:TextBox>
        </div>
        <div class="input-control text full-size">
            <asp:TextBox runat="server" placeholder="Description of Product" ID="txtDescription"></asp:TextBox>
        </div>
        <h4>Photo</h4>
        <hr />
        <img id="myImage" runat="server" src="data:image/jpeg; base64, " alt="Photo" width="250" height="250" />
        <br />
        <div class="input-control file full-size" data-role="input">
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <button class="button"><span class="mif-folder"></span></button>
        </div>
        <asp:Button runat="server" ID="btnSubmitPhoto" CssClass="button primary full-size" Text="Submit Photo" OnClick="btnSubmitPhoto_Click" />
        <hr />
        <asp:Button runat="server" ID="btnAddProduct" CssClass="button primary full-size" Text="Add Product" OnClick="btnAddProduct_Click" />
        <hr />
    </div>
    <div class="cell colspan8">
        <h4>My Products</h4>
    <hr />
        <asp:GridView runat="server" ID="gridPhotos" AutoGenerateColumns="False" CssClass="table striped hovered border bordered" data-role="datatable" data-seraching="false">
            <Columns>
                <asp:TemplateField HeaderText="Photos">
                    <ItemTemplate>
                        <img id="dbImage" runat="server" src="data:image/jpeg; base64, " alt="Photo" width="50" height="50" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField Visible="False" HeaderText="ID">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("id") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblID" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField Visible="True" HeaderText="Name">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("name") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lblName" Text='<%# Bind("name") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField Visible="True" HeaderText="Description">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("description") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblAddress" runat="server" Text='<%# Bind("description") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField Visible="True" HeaderText="Price">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("price") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblCity" runat="server" Text='<%# Bind("price") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

        </asp:GridView>
    </div>
    <script type="text/javascript" src="Functions.js"></script>
</asp:Content>
