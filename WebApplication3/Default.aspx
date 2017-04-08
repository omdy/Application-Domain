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

        <nav class="navbar navbar-default">
  <div class="container-fluid">
    <!-- Brand and toggle get grouped for better mobile display -->
    <div class="navbar-header">
      <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
        <span class="sr-only">Toggle navigation</span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
      </button>
      <a class="navbar-brand" href="#">ACE_DJ Accounting</a>
    </div>

    <!-- Collect the nav links, forms, and other content for toggling -->
    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
      <ul class="nav navbar-nav">
        <li><a href="#">Home</a></li>
        <li><a href="#">Login</a></li>
          <li><a href="#">About Us</a></li>
          </ul>
       

      <%--<form class="navbar-form navbar-left">
        <div class="form-group">
          <%--<input type="text" class="form-control" placeholder="Search">         // THIS IS THE SEARCH BAR AND BUTTON, but they look bad and they break the program
            <button type="submit" class="btn btn-default">Submit</button>--%>
      <%--</form>--%>
      <ul class="nav navbar-nav navbar-right">
          </ul>
    </div><!-- /.navbar-collapse -->
  </div><!-- /.container-fluid -->
</nav>
        <div style="text-align: center;">
        <br />
        <br />
        <asp:Button style="background-color:lightgreen" class="btn btn-default" ID="Button8" runat="server" Text="Journalize Transaction" OnClick="Button3_Click" />
            <br />
            <asp:Button ID="Button11" runat="server" OnClick="Button11_Click" Text="Posting" />
            <br />
            <asp:Button ID="Button13" runat="server" Text="Trial Balance" OnClick="Button13_Click" />
            <br />
            <asp:Button ID="Button14" runat="server" Text="Ledger" OnClick="Button14_Click" />
            <br />
        <asp:Button style="background-color:lightgreen" class="btn btn-default" ID="Button1" runat="server" OnClick="Button2_Click" Text="Add Account" />
        <br />
            <asp:Button ID="Button12" runat="server" OnClick="Button12_Click" Text="View Accounts" />
        <br />
        <asp:Button style="background-color:lightgreen" class="btn btn-default" ID="Button9" runat="server" OnClick="Button4_Click" Text="Event Log" />
        <br />
        <br />
        <asp:Button style="background-color:lightgreen" class="btn btn-default" ID="Button10" runat="server" OnClick="Button5_Click" Text="Test Page" />
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
