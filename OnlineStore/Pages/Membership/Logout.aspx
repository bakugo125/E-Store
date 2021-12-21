<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="OnlineStore.Pages.Membership.Logout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h3>You have successfully logged out of application or your session has expired.</h3>
    <asp:HyperLink runat="server" ID="HyperLink34" Text="Login Again" NavigateUrl="~/Pages/Membership/Login.aspx"></asp:HyperLink>
</body>
</html>
