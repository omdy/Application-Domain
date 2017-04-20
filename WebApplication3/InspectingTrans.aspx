<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InspectingTrans.aspx.cs" Inherits="WebApplication3.InspectingTrans" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 40px;
        }
    </style>
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
    
        <asp:Label ID="Label1" runat="server" Text="Select Title"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Select" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Return" />
            <br />
            <br />
        <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" HorizontalAlign="Center">
            
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
                <asp:BoundField ReadOnly="True" HeaderText="Title"
		DataField="Title" SortExpression="Title" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
                
                <asp:BoundField ReadOnly="True" HeaderText="Status"
		DataField="Status" SortExpression="Status" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"></asp:BoundField>

                <asp:BoundField ReadOnly="True" HeaderText="ID"
		DataField="ID" SortExpression="ID" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"></asp:BoundField>

                <asp:BoundField ReadOnly="True" HeaderText="Account"
		DataField="Account" SortExpression="Account" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"></asp:BoundField>

                <asp:BoundField ReadOnly="True" HeaderText="Debit"
		DataField="Debit" SortExpression="Debit"  HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                
                <asp:BoundField ReadOnly="True" HeaderText="Credit"
		DataField="Credit" SortExpression="Credit" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                
                <asp:BoundField ReadOnly="True" HeaderText="Comment"
		DataField="Comment" SortExpression="Comment" HeaderStyle-HorizontalAlign="Right"></asp:BoundField>
                
                <asp:BoundField ReadOnly="True" HeaderText="Reason"
		DataField="Reason" SortExpression="Reason" HeaderStyle-HorizontalAlign="Right"></asp:BoundField>
                

            </Columns>
        </asp:GridView>
        <br />
        <asp:Button ID="Button2" runat="server" Text="Post" OnClick="Button2_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button3" runat="server" Text="Reject" OnClick="Button3_Click" />
        <asp:TextBox ID="TextBox1" runat="server" Visible="False">Add a reason</asp:TextBox>
        <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Reject with Reason" Visible="False" />
        <br />
            <br />
            <br />
            <br />
        <asp:Label ID="Label2" runat="server" Text="General Journal"></asp:Label>
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False" HorizontalAlign="Center">
            
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
                <asp:BoundField ReadOnly="True" HeaderText="Title"
		DataField="Title" SortExpression="Title" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
                
                <asp:BoundField ReadOnly="True" HeaderText="Status"
		DataField="Status" SortExpression="Status" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"></asp:BoundField>

                <asp:BoundField ReadOnly="True" HeaderText="ID"
		DataField="ID" SortExpression="ID" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"></asp:BoundField>

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

    <div class="auto-style1">
    
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
