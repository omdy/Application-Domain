<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication3.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    

    <head>

        <title>ACE_DJ Accounting</title>
        <meta charset="utf-8"" />

    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/bootstrap-theme.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-1.9.1.min.js"></script>

    </head>

    <script>

    </script>



<body>
    <form id="form1" runat="server">

        <div style="text-align: center;">
            <br />
            <font size="5" color="Blue">DJ ACE Account</font><br />
            <br />
        <asp:Button style="background-color:lightgreen" class="btn btn-default" ID="Button8" runat="server" Text="Journalize Transaction" OnClick="Button3_Click" Width="167px" />
            &nbsp;
            <asp:Button style="background-color:lightgreen" class="btn btn-default" ID="Button11" runat="server" OnClick="Button11_Click" Text="Posting" />
            &nbsp;
            <asp:Button style="background-color:lightgreen" class="btn btn-default" ID="Button13" runat="server" Text="Trial Balance" OnClick="Button13_Click" Width="112px" />
            &nbsp;
            <asp:Button style="background-color:lightgreen" class="btn btn-default" ID="Button14" runat="server" Text="Ledger" OnClick="Button14_Click" Width="76px" />
            &nbsp;
        <asp:Button style="background-color:lightgreen" class="btn btn-default" ID="Button1" runat="server" OnClick="Button2_Click" Text="Add Account" Width="115px" />
        &nbsp;
            <asp:Button style="background-color:lightgreen" class="btn btn-default" ID="Button12" runat="server" OnClick="Button12_Click" Text="View Accounts" Width="122px" />
        &nbsp;
        <asp:Button style="background-color:lightgreen" class="btn btn-default" ID="Button9" runat="server" OnClick="Button4_Click" Text="Event Log" Width="101px" />
        <br />
        <br />
            <br />
            <br />
            <br />
            <br />
        <br />
        <br />
        <br />
        <br />
        <br />




        <br />
        <br />

        <asp:GridView ID="GridView1" runat="server"></asp:GridView>

        <asp:GridView ID="GridView2" runat="server" OnSelectedIndexChanged="GridView2_SelectedIndexChanged"></asp:GridView>
        <br />
    </div>
    </form>
</body>
</html>
