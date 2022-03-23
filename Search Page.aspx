
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Searching.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            Search <asp:TextBox ID="TxtSeedName" runat="server"></asp:TextBox>
            <asp:Button ID="ButSearch" runat="server" Text="Button" OnClick="ButSearch_Click" style="height: 26px" />

            <asp:GridView ID="GridView1" runat="server" ></asp:GridView> 
        </div>
    </form>
</body>
</html>
