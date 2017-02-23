<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication3.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    

    <script>

    </script>



<body>
    <form id="form1" runat="server">
    <div>

        <asp:Button ID="Button1" runat="server" Text="Display Chart of Accounts" OnClick="Button1_Click" />

        <br />
        <br />

        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        <br />
        <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Display Current Account Balances" />
        <br />
        <br />

        <asp:GridView ID="GridView2" runat="server" OnSelectedIndexChanged="GridView2_SelectedIndexChanged"></asp:GridView>
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Add Account" />
        <br />
        <br />
        <asp:Button ID="Button3" runat="server" Text="Journalize Transaction" OnClick="Button3_Click" />
        <br />
        <br />
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Event Log" />
        <br />
        <br />
        <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Test Page" />
        <br />
    </div>
    </form>
</body>
</html>
