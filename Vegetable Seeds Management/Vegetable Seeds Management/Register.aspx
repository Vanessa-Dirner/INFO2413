<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Vegetable_Seeds_Management.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="LoginPage.css" rel="stylesheet" />
</head>
<body>
     <img src="user-01.png" alt="User" class="user" />
        <h2>Register an Account</h2>
        <form id="form2" runat="server">
            <asp:Label Text="Email" CssClass="lblusername" runat="server"></asp:Label>
            <asp:TextBox ID= "txtUserName" runat="server" CssClass="txtusername"></asp:TextBox>
            <asp:Label Text="Password" CssClass="lblpassword" runat="server"></asp:Label>
            <asp:TextBox ID ="txtPassword" runat="server" CssClass="txtpassword"></asp:TextBox>
            <asp:Button Text="Register" CssClass="btnsubmit" runat="server" OnClick="Btn_Register" />
            <asp:Label ID="lblErrorMessage" runat="server" Text="Account Created" ForeColor="Red"></asp:Label>
        </form>
</body>
</html>
