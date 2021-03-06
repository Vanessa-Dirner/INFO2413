+﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Vegetable_Seeds_Management.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
      <form id="form1" runat="server">
    <div>
        <asp:HiddenField ID="hfuserid" runat="server" />
    <table>
        <tr>
            <td>
                <asp:Label Text="First Name" runat="server" />
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtFirstName" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label Text="Last Name" runat="server" />
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtLastName" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label Text="Job Role" runat="server" />
            </td>
            <td colspan="2">
                <asp:DropDownList ID="ddlJobRole" runat="server">
                    <asp:ListItem>Employee</asp:ListItem>
                    <asp:ListItem>Gardener</asp:ListItem>
                    <asp:ListItem>Administrator</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label Text="Email" runat="server" />
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtEmail" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <hr />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label Text="Username" runat="server" />
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtUsername" runat="server" />
                <asp:Label Text="*" runat="server" ForeColor="Red" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label Text="Password" runat="server" />
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" />
                 <asp:Label Text="*" runat="server" ForeColor="Red" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label Text="Confirm Password" runat="server" />
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" />
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <asp:Button Text="Submit" ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" />
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <asp:Label Text="" ID="lblSuccessMessage" runat="server" ForeColor="Green" />
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <asp:Label Text="" ID="lblErrorMessage" runat="server" ForeColor="Red" />
            </td>
        </tr>

    </table>
    </div>
    </form>
</body>
</html>
