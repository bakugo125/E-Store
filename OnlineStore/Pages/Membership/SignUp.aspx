<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="OnlineStore.Pages.Membership.SignUp" %>

<!DOCTYPE html>

<html>
<head>
    <meta content="IE=11.0000" http-equiv="X-UA-Compatible">
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <meta name="description" content="Metro, a sleek, intuitive, and powerful framework for faster and easier web development for Windows Metro Style.">
    <meta name="keywords" content="HTML, CSS, JS, JavaScript, framework, metro, front-end, frontend, web development">
    <meta name="author" content="Sergey Pimenov and Metro UI CSS contributors">
    <link href="../favicon.ico" rel="shortcut icon" type="image/x-icon">
    <title>SignUp form</title>
    <script src="../../Metro-UI-CSS-master/test/RequireJS/scripts/jquery-2.1.3.min.js"></script>
    <script src="../../Metro-UI-CSS-master/test/RequireJS/scripts/metro.js"></script>
    <script type="text/javascript" src="SignUp.js"></script>
    <link href="../../Metro-UI-CSS-master/build/css/metro.css" rel="stylesheet" />
    <link href="../../Metro-UI-CSS-master/build/css/metro-icons.css" rel="stylesheet" />
    <link href="../../Metro-UI-CSS-master/build/css/metro-responsive.css" rel="stylesheet" />

    <style>
        .login-form {
            width: 25rem;
            height: 40rem;
            position: fixed;
            top: 35%;
            margin-top: -11.375rem;
            left: 50%;
            margin-left: -12.5rem;
            background-color: #ffffff;
            opacity: 0;
            -webkit-transform: scale(.8);
            transform: scale(.8);
        }
    </style>

    <script>
        $(function () {
            var form = $(".login-form");

            form.css({
                opacity: 1,
                "-webkit-transform": "scale(1)",
                "transform": "scale(1)",
                "-webkit-transition": ".5s",
                "transition": ".5s"
            });
        });
    </script>

    <meta name="GENERATOR" content="MSHTML 11.00.9600.18739">
</head>
<body class="bg-darkTeal">
    <div class="login-form padding20 block-shadow">
        <form id="form1" runat="server">
            <h1 class="text-light">Sign Up</h1>
            <hr>
            <br>
            <div class="input-control text full-size" data-role="input">
                <label for="Email">
                    Email:</label>
                <asp:TextBox runat="server" ID="Email" onkeypress="return lengthCheck(Email, 50)"  ></asp:TextBox>
                <button class="button helper-button clear"><span class="mif-cross"></span></button>
            </div>
            <br>
            <br>
            <div class="input-control password full-size" data-role="input">
                <label for="Password">
                    Password:</label>
                <asp:TextBox runat="server" ID="Password" TextMode="Password" onkeypress="return lengthCheck(Password, 50)"  ></asp:TextBox>
                <button class="button helper-button reveal">
                    <span
                        class="mif-looks"></span>
                </button>
            </div>
            <br>
            <br>
            <div class="input-control select full-size">
                <label for="cmbUserType">
                    Role:</label>
                <asp:DropDownList runat="server" ID="cmbUserType">
                    <asp:ListItem>admin</asp:ListItem>
                    <asp:ListItem>seller</asp:ListItem>
                    <asp:ListItem>customer</asp:ListItem>
                </asp:DropDownList>
            </div>
            <br>
            <br>
            <div class="input-control text full-size" data-role="input">
                <label for="Name">
                    Name:</label>
                <asp:TextBox runat="server" ID="Name" onkeypress="return lengthCheck(Name, 30)"></asp:TextBox>
            </div>
            <br>
            <br>
            <div class="input-control text full-size" data-role="input">
                <label for="CardNum">
                    Card Number:</label>
                <asp:TextBox runat="server" ID="CardNum" onkeypress="return lengthCheck(CardNum, 16) && isNumber(event)"></asp:TextBox>
            </div>
            <br>
            <br>
            <div class="input-control text full-size" data-role="input">
                <label for="Address">
                    Address:</label>
                <asp:TextBox runat="server" ID="Address" onkeypress="return lengthCheck(Address, 50)"></asp:TextBox>
            </div>
            <br>
            <br>
            <div class="input-control text full-size" data-role="input">
                <label for="Phone">
                    Phone:</label>
                <asp:TextBox runat="server" ID="Phone" onkeypress="return lengthCheck(Phone, 12) && isNumber(event)"></asp:TextBox>
            </div>
            <br>
            <br>
            <asp:Button runat="server" ID="btnSignUp" CssClass="button primary full-size" Text="SignUp" OnClick="btnSignUp_Click" OnClientClick="return validate();"/>
            <asp:Button runat="server" ID="btnCancel" CssClass="button danger full-size" Text="Cancel" OnClick="btnCancel_Click"/>
            <asp:Button runat="server" ID="btnLogin" CssClass="button primary full-size" Text="Login" OnClick="btnLogin_Click"/>
            <asp:Label runat="server" ID="lblResults"></asp:Label>
        </form>
    </div>
</body>
</html>