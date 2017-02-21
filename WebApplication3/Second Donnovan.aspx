<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Second Donnovan.aspx.cs" Inherits="WebApplication3.Second_Donnovan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
</head>
<body style="height: 274px">
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style7">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    &nbsp;</td>
                <td class="auto-style8">
        <asp:Label ID="Label1" runat="server" Text="Account Name"></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    &nbsp;</td>
                <td class="auto-style7">
                    <asp:Label ID="Label2" runat="server" Text="Type"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" Width="127px">
                        <asp:ListItem>Select</asp:ListItem>
                        <asp:ListItem>OwnEq</asp:ListItem>
                        <asp:ListItem>Liability</asp:ListItem>
                        <asp:ListItem>Assets</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    &nbsp;</td>
                <td class="auto-style8">
                    <asp:Label ID="Label3" runat="server" Text="Side"></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:DropDownList ID="DropDownList2" runat="server" Height="16px" Width="127px">
                        <asp:ListItem>Select</asp:ListItem>
                        <asp:ListItem>Right</asp:ListItem>
                        <asp:ListItem>Left</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    &nbsp;</td>
                <td class="auto-style7">
                    <asp:Label ID="Label5" runat="server" Text="Account Code"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">
                </td>
                <td class="auto-style9">
                    <asp:Label ID="Label6" runat="server" Text="Liquidity Order"></asp:Label>
                </td>
                <td class="auto-style6">
                    <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    &nbsp;</td>
                <td class="auto-style7">
                    <asp:Label ID="Label7" runat="server" Text="Added by"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    &nbsp;</td>
                <td class="auto-style7">
                    <asp:Label ID="Label8" runat="server" Text="Added on"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    &nbsp;</td>
                <td class="auto-style7">
                    <asp:Label ID="Label9" runat="server" Text="Active"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList3" runat="server" Height="16px" Width="127px">
                        <asp:ListItem>Select</asp:ListItem>
                        <asp:ListItem>Active</asp:ListItem>
                        <asp:ListItem>Inactive</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    &nbsp;</td>
                <td class="auto-style7">
                    <asp:Label ID="Label10" runat="server" Text="Comment"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    &nbsp;</td>
                <td class="auto-style7">
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Submit" Height="26px" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    &nbsp;</td>
                <td class="auto-style7">
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Return to Main" />
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
