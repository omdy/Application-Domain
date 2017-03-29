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
    
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Return" />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" CellPadding="10" CellSpacing="5" ForeColor="#333333" GridLines="None" EnableSortingAndPagingCallbacks="True" Width="300px" FooterStyle-HorizontalAlign="Center" AutoGenerateColumns="False">
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
    
    </div>
    </form>
</body>
</html>
