<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Journalize.aspx.cs" Inherits="WebApplication3.Journalize" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Which Account?"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="How Much?"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Return to Main" />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    <div>
    
    </div>
    </form>
</body>
</html>
