<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TrialB.aspx.cs" Inherits="WebApplication3.TrialB" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 258px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="auto-style1">
    
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
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Remake TB" />
            <br />
            <br />
        <asp:GridView ID="GridView1" runat="server" CellPadding="10" CellSpacing="5" ForeColor="#333333" GridLines="None" EnableSortingAndPagingCallbacks="True" Width="300px" FooterStyle-HorizontalAlign="Center" AutoGenerateColumns="False" HorizontalAlign="Center">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />

             <Columns>
                <asp:BoundField ReadOnly="True" HeaderText="Account"
		DataField="Account" SortExpression="Account" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
                
                <asp:BoundField ReadOnly="True" HeaderText="Debit"
		DataField="Debit" SortExpression="Debit"  ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                
                <asp:BoundField ReadOnly="True" HeaderText="Credit"
		DataField="Credit" SortExpression="Credit"  ItemStyle-HorizontalAlign="Right"></asp:BoundField>
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
        <br />




        <br />
        <br />

        
    </div>
        <br />
        <br />
    
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
