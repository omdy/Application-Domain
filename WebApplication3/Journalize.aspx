<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Journalize.aspx.cs" Inherits="WebApplication3.Journalize" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Journalize</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            height: 74px;
        }
        .auto-style4 {
            width: 120px;
        }
        .auto-style5 {
            width: 91px;
        }
        .auto-style6 {
            width: 66px;
        }
        .auto-style7 {
            width: 156px;
        }
        .auto-style8 {
            width: 310px;
        }
    </style>

    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/bootstrap-theme.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-1.9.1.min.js"></script>


</head>
<body>
    
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
        <br />
        <br />

        <br />

        <table class="auto-style1">
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style8">
        <asp:Label ID="Label6" runat="server" Text="Title"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Date<br />
        <asp:TextBox ID="TextBox5" runat="server" OnTextChanged="TextBox5_TextChanged"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style8">Debit</td>
                <td>Credit</td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="TextBox1" runat="server">0</asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server">0</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    &nbsp;</td>
                <td class="auto-style8">Comment:</td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        &nbsp;&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <table class="nav-justified">
            <tr>
                <td class="auto-style5">
        <asp:Button style="background-color:lightgreen" class="btn btn-default" ID="Button3" runat="server" Text="Add" OnClick="Button3_Click" />
                </td>
                <td class="auto-style6">
                    <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Delete" />
                </td>
                <td>
        <asp:DropDownList ID="DropDownList2" runat="server">
        </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">
        <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
                <td class="auto-style6">
                    <asp:Label ID="Label5" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <br />
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />

            <Columns>
                <asp:BoundField ReadOnly="True" HeaderText="ID"
		DataField="ID" SortExpression="ID" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
                
                <asp:BoundField ReadOnly="True" HeaderText="Account"
		DataField="Account" SortExpression="Account" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"></asp:BoundField>

                <asp:BoundField ReadOnly="True" HeaderText="Debit"
		DataField="Debit" SortExpression="Debit"  HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                
                <asp:BoundField ReadOnly="True" HeaderText="Credit"
		DataField="Credit" SortExpression="Credit" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                
                <asp:BoundField ReadOnly="True" HeaderText="Comment"
		DataField="Comment" SortExpression="Comment" HeaderStyle-HorizontalAlign="Right"></asp:BoundField>
                
            </Columns>


            
        </asp:GridView>

        <table class="nav-justified">
            <tr>
                <td class="auto-style7">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label7" runat="server" Text="Total:" Visible="False"></asp:Label>
&nbsp;
        <asp:Label ID="Label2" runat="server" Text="0.00" Visible="False"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td>
        <asp:Label ID="Label3" runat="server" Text="0.00" Visible="False"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <asp:Button ID="Button5" runat="server" Text="Browse to Upload File" />
        <br />
        <br />
        <asp:Button style="background-color:lightgreen" class="btn btn-default" ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:Label ID="Label4" runat="server" Text="Label" Visible="False"></asp:Label>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:Button style="background-color:lightgreen" class="btn btn-default" ID="Button2" runat="server" OnClick="Button2_Click" Text="Return to Home" />
        <br />
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
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
        <br />
        <br />

    </div>

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
    <div>
    
    </div>
    </form>
</body>
</html>
