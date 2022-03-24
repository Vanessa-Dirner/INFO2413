<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Notifications.aspx.cs" Inherits="Vegetable_Seeds_Management.Notifications" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="Notifications.css" rel="stylesheet" />
</head>
<body>
    <form id="form3" runat="server">
        <div class="report">
            <h2>Generate Reports</h2>
            <h3>Select a report to generate:</h3>
            <asp:button text="Report Wasted" OnClick="WastedSeedsReport_Click" runat="server"/>
            <asp:button text="Report Harvested" OnClick="HarvestedSeedsReport_Click" runat="server"/>
            <asp:GridView ID="GridView2" runat="server" ></asp:GridView> 
        </div>
    </form>
</body>
</html>
