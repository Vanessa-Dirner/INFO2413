<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Input Seed Purchase.aspx.cs" Inherits="Vegetable_Seeds_Management.Input_Seed_Purchase" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link href="LoginPage.css" rel="stylesheet" />
    <title>Inventory Update</title>
</head>
<body>
    <form id="form3" runat="server">
        <div>
            <asp:Label Text="Expiration Date" CssClass="lblusername" runat="server"></asp:Label>
            <asp:TextBox ID= "ExpirationDate" runat="server" CssClass="txtusername"></asp:TextBox>
            <asp:Label Text="Quantity" CssClass="lblusername" runat="server"></asp:Label>
            <asp:TextBox ID= "Quantity" runat="server" CssClass="txtusername"></asp:TextBox>
            <asp:Label Text="Bought or Harvested?" CssClass="lblusername" runat="server"></asp:Label>
            <asp:TextBox ID= "SeedType" runat="server" CssClass="txtusername"></asp:TextBox>
             <asp:Label Text="Seed Name" CssClass="lblusername" runat="server"></asp:Label>
            <asp:TextBox ID= "SeedName" runat="server" CssClass="txtusername"></asp:TextBox>
            <asp:Label Text="Planting Time" CssClass="lblusername" runat="server"></asp:Label>
            <asp:TextBox ID= "PlantingTime" runat="server" CssClass="txtusername"></asp:TextBox>
            <asp:Button Text="Add to Inventory" CssClass="btnsubmit" runat="server" OnClick="InsertSeedPurchase_Click" />
            <asp:Label ID="lblConfirm" runat="server" Text="Inventory Updated" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>
