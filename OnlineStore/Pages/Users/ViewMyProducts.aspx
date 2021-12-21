<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Users/Seller.master" AutoEventWireup="true" CodeBehind="ViewMyProducts.aspx.cs" Inherits="OnlineStore.Pages.Users.ViewMyProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content4" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content5" runat="server">
    <h1>Search and View Products:</h1>
    <hr />
    <asp:Label runat="server" ID="lblSuccess" Text="Label Sucess" CssClass="tag success" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblWarning" Text="Label Warning" CssClass="tag alert" Visible="false"></asp:Label>
    <br />

    <div class="cell colspan6">
        <h4>Search</h4>
        <hr />
        <asp:GridView runat="server" ID="gridPhotos" AutoGenerateColumns="False" CssClass="table striped hovered border bordered" data-role="datatable" data-seraching="false" OnRowCommand="gridPhotos_RowCommand">
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
                        <asp:LinkButton runat="server" ID="lblName" Text='<%# Bind("name") %>' CommandName="view" CommandArgument='<%# Bind("id") %>'></asp:LinkButton>
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
    <div class="cell colspan5">
        <h4>Details</h4>
        <hr />
        <asp:Panel ID="pnlDetails" runat="server" Visible="false">
            <div id="pDiv1">
                <h1>FAST-NUCES LAB PROJECT</h1>
                <h2>Product Details</h2>
                <table style="width: 100%">
                    <tr>
                        <td style="width: 85%">
                            <h3><%= product.ProductName %></h3>
                            <h4><%= product.ProductDescription %></h4>
                            <h4><%= product.ProductRating %></h4>
                            <h4><%= product.ProductPrice %></h4>
                        </td>
                        <td style="width: 15%">
                            <div class="image-container rounded">
                                <div class="frame">
                            <img id="myImage" runat="server" src="data:image/jpeg; base64, " alt="Photo" width="125" height="200" />
                                </div></div>
                        </td>
                    </tr>
                </table>
            </div>
            <asp:Button runat="server" ID="Button1" CssClass="button primary full-size" Text="Print Product Details" OnClientClick="printDiv('pDiv1')" />
        </asp:Panel>

    </div>
</asp:Content>
