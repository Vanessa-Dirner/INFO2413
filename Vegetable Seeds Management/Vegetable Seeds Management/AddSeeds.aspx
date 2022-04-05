<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddSeeds.aspx.cs" Inherits="Vegetable_Seeds_Management.Inventory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
</head>
<body>
    <form id="form1" runat="server">
          <div>
             <asp:HiddenField ID="hfbatch" runat="server" />
    <table>
        <tr>
            <td>
                <asp:Label Text="Quantity" runat="server" />
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtQuantity" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label Text="ExpirationDate" runat="server" />
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtExpirationDate" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label Text="PlantingTime" runat="server" />
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtPlantingTime" runat="server" />
            </td>
        </tr>
         <tr>
            <td>
                <asp:Label Text="SeedType" runat="server" />
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtSeedType" runat="server" />
            </td>
        </tr>
         <tr>
            <td>
                <asp:Label Text="SeedName" runat="server" />
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtSeedName" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label Text="Category" runat="server" />
            </td>
            <td colspan="2">
                <asp:DropDownList ID="ddlCategory" runat="server">
                    <asp:ListItem>Harvested</asp:ListItem>
                    <asp:ListItem>Planted</asp:ListItem>
                </asp:DropDownList>
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
