<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Users/Admin.master" AutoEventWireup="true" CodeBehind="NewUser.aspx.cs" Inherits="OnlineStore.Pages.Users.NewUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content4" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content5" runat="server">
    <h1>New User</h1>
    <hr />
    <asp:Label runat="server" ID="lblSuccess" Text="Label Sucess" CssClass="tag success" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblWarning" Text="Label Warning" CssClass="tag alert" Visible="false"></asp:Label>
    <br />
    <div class="cell colspan5">
        <h3>New User</h3>
        <hr />
            <div class="input-control text full-size" >
                <asp:TextBox runat="server" placeholder="User Name" ID="txtUserName"></asp:TextBox>
            </div>
            <div class="input-control text full-size" >
                <asp:TextBox runat="server" TextMode="Password" placeholder="Password" ID="txtPassword"></asp:TextBox>
            </div>
        <div class="input-control select full-size">
            <asp:DropDownList runat="server" ID="cmbUserType">
                <asp:ListItem>admin</asp:ListItem>
                <asp:ListItem>seller</asp:ListItem>
                <asp:ListItem>customer</asp:ListItem>
            </asp:DropDownList>
        </div>
            <div class="input-control text full-size" >
                <asp:TextBox runat="server" placeholder="Email" ID="txtEmail"></asp:TextBox>
            </div>
            <div class="input-control text full-size" >
                <asp:TextBox runat="server" placeholder="Card Number" ID="txtCard"></asp:TextBox>
            </div>
            <div class="input-control text full-size" >
                <asp:TextBox runat="server" placeholder="Address" ID="txtAddress"></asp:TextBox>
            </div>
            <div class="input-control text full-size" >
                <asp:TextBox runat="server" placeholder="Phone" ID="txtPhone"></asp:TextBox>
            </div>

            <asp:Button runat="server" ID="btnCreateUser" CssClass="button primary full-size" Text="Create" OnClick="btnCreateUser_Click"  />

        </div>
    <div class="cell colspan6">
        <h3>Existing Users</h3>
            <asp:GridView runat="server" ID="gridUsers" CssClass="table striped hovered border bordered"  data-role="datatable" data-seraching="true"  AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="User Name" SortExpression="Name" />
                </Columns>
            </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:LabProjectConnectionString %>" SelectCommand="SELECT [Name] FROM [Users] ORDER BY [Name]"></asp:SqlDataSource>
    </div>
</asp:Content>