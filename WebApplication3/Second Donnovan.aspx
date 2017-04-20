<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Second Donnovan.aspx.cs" Inherits="WebApplication3.Second_Donnovan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Account</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 262px;
        }
        .auto-style3 {
            width: 262px;
            height: 26px;
        }
        .auto-style4 {
            height: 26px;
        }
        .auto-style5 {
            width: 262px;
            height: 25px;
        }
        .auto-style6 {
            height: 25px;
        }
        .auto-style7 {
            width: 110px;
        }
        .auto-style8 {
            height: 26px;
            width: 110px;
        }
        .auto-style9 {
            height: 25px;
            width: 110px;
        }
    </style>

     <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/bootstrap-theme.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-1.9.1.min.js"></script>


</head>
<body style="height: 459px">
    <form id="form1" runat="server">

        <div style="text-align: center;">
            <br />
            <font size="5" color="Blue">DJ ACE Account</font><br />
            <br />
        <asp:Button style="background-color:lightgreen" class="btn btn-default" ID="Button20" runat="server" Text="Journalize Transaction" OnClick="Button20_Click" Width="167px" />
            &nbsp;
            <asp:Button style="background-color:lightgreen" class="btn btn-default" ID="Button21" runat="server" OnClick="Button21_Click" Text="Posting" />
            &nbsp;
            <asp:Button style="background-color:lightgreen" class="btn btn-default" ID="Button22" runat="server" Text="Trial Balance" OnClick="Button22_Click" Width="112px" />
            &nbsp;
            <asp:Button style="background-color:lightgreen" class="btn btn-default" ID="Button23" runat="server" Text="Ledger" OnClick="Button23_Click" Width="76px" />
            &nbsp;
        <asp:Button style="background-color:lightgreen" class="btn btn-default" ID="Button24" runat="server" OnClick="Button24_Click" Text="Add Account" Width="115px" />
        &nbsp;
            <asp:Button style="background-color:lightgreen" class="btn btn-default" ID="Button25" runat="server" OnClick="Button25_Click" Text="View Accounts" Width="122px" />
        &nbsp;
        <asp:Button style="background-color:lightgreen" class="btn btn-default" ID="Button26" runat="server" OnClick="Button26_Click" Text="Event Log" Width="101px" />
        <br />
            <br />
        <asp:Label ID="Label1" runat="server" Text="Account Name"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
                    <asp:Label ID="Label2" runat="server" Text="Type"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" Width="127px">
                        <asp:ListItem>Select</asp:ListItem>
                        <asp:ListItem>OwnEq</asp:ListItem>
                        <asp:ListItem>Liability</asp:ListItem>
                        <asp:ListItem>Assets</asp:ListItem>
                    </asp:DropDownList>
             
        <br />
                    <asp:Label ID="Label3" runat="server" Text="Side"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="DropDownList2" runat="server" Height="16px" Width="127px">
                        <asp:ListItem>Select</asp:ListItem>
                        <asp:ListItem>Right</asp:ListItem>
                        <asp:ListItem>Left</asp:ListItem>
                    </asp:DropDownList>
            <br />
                    <asp:Label ID="Label5" runat="server" Text="Sub Type"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            <br />
                    <asp:Label ID="Label6" runat="server" Text="Liquidity Order"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                &nbsp;
            <br />
                    <asp:Label ID="Label7" runat="server" Text="Added by"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label>
                <br />
                    <asp:Label ID="Label8" runat="server" Text="Added on"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label>
                <br />
                    <asp:Label ID="Label9" runat="server" Text="Active"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="DropDownList3" runat="server" Height="16px" Width="127px">
                        <asp:ListItem>Select</asp:ListItem>
                        <asp:ListItem>Active</asp:ListItem>
                        <asp:ListItem>Inactive</asp:ListItem>
                    </asp:DropDownList>
            <br />
                    <asp:Label ID="Label10" runat="server" Text="Comment"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
                    <br />
            Initial Balance&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
                <br />
        <asp:Button style="background-color:lightgreen" class="btn btn-default" ID="Button2" runat="server" OnClick="Button2_Click" Text="Submit" />

                <br />
            <br />


        <asp:Button style="background-color:lightgreen" class="btn btn-default" ID="Button3" runat="server" OnClick="Button3_Click" Text="Return to Home" />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />

    </div>

        <div>
    
            <table class="auto-style1">
            <tr>
                <td class="auto-style3">
                    &nbsp;</td>
                <td class="auto-style8">
                    &nbsp;</td>
                <td class="auto-style4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    &nbsp;</td>
                <td class="auto-style7">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    &nbsp;</td>
                <td class="auto-style8">
                    &nbsp;</td>
                <td class="auto-style4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    &nbsp;</td>
                <td class="auto-style7">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">
                </td>
                <td class="auto-style9">
                    &nbsp;</td>
                <td class="auto-style6">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    &nbsp;</td>
                <td class="auto-style7">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    &nbsp;</td>
                <td class="auto-style7">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    &nbsp;</td>
                <td class="auto-style7">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    &nbsp;</td>
                <td class="auto-style7">
                    <br />
                    </td>
                <td>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    &nbsp;</td>
                <td class="auto-style7">
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    &nbsp;</td>
                <td class="auto-style7">

                    <br />


                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
        <br />
        <br />
        <br />
        <br />
        <br />
    </form>
</body>
</html>
