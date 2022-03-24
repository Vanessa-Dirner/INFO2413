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
            <h3>Select the report you'd like to generate:</h3>
            <asp:RadioButton id="WastedReport" Text="Report Wasted" runat="server" OnCheckedChanged="WastedReport_CheckedChanged" /><br />            
            <asp:RadioButton id="HarvestedReport" Text="Report Harvested" runat="server" /><br />
            <asp:button text="Generate!" OnClick="WastedSeedsReport_Click" runat="server"/>
            <asp:GridView ID="GridView2" runat="server" ></asp:GridView> 
        </div>
    </form>
</body>
</html>
