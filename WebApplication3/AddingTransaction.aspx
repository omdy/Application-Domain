<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddingTransaction.aspx.cs" Inherits="WebApplication3.AddingTransaction" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Journalize Transaction</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>

     <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/bootstrap-theme.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-1.9.1.min.js"></script>


</head>
<body style="height: 255px">
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


    <div>
    
        <table class="auto-style1">
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>Debit</td>
                <td>Credit</td>
            </tr>
            <tr>
                <td>Which Account will be &#39;Debited&#39;?&nbsp;</td>
                <td>
                    <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                </td>
                <td>Amount:<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Which Account will be &#39;Credited&#39;?</td>
                <td>
                    <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>Amount:<asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <asp:Button style="background-color:lightgreen" class="btn btn-default" ID="Button3" runat="server" OnClick="Button3_Click" Text="Check for Validation" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button style="background-color:lightgreen" class="btn btn-default" ID="Button2" runat="server" OnClick="Button2_Click" Text="Return without Adding" />
        <br />
    
    </div>
    </form>
</body>
</html>
