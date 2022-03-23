// Login Page.aspx
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login Page.aspx.cs" Inherits="Vegetable_Seeds_Management.Login_Page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="LoginPage.css" rel="stylesheet" />
</head>
<body>
    <div class="loginbox" >
        <img src="user-01.png" alt="User" class="user" />
        <h2>Log In</h2>
        <form id="form2" runat="server">
            <asp:Label Text="Email" CssClass="lblusername" runat="server"></asp:Label>
            <asp:TextBox ID= "txtUserName" runat="server" CssClass="txtusername"></asp:TextBox>
            <asp:Label Text="Password" CssClass="lblpassword" runat="server"></asp:Label>
            <asp:TextBox ID ="txtPassword" runat="server" CssClass="txtpassword"></asp:TextBox>
            <asp:Button Text="Sign In" CssClass="btnsubmit" runat="server" OnClick="Btn_Login" />
            <asp:Label ID="lblErrorMessage" runat="server" Text="Incorrect User Credentials" ForeColor="Red"></asp:Label>
        </form>
    </div> 
</body>
</html>
