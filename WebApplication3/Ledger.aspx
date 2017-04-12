<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ledger.aspx.cs" Inherits="WebApplication3.Ledger" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <asp:Button ID="Button1" runat="server" Text="Return" OnClick="Button1_Click" />
        <br />
        <br />
        
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False">
            

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
        <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False">
            
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
                <asp:BoundField ReadOnly="True" HeaderText="Account"
		DataField="Account" SortExpression="Account" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"></asp:BoundField>

                <asp:BoundField ReadOnly="True" HeaderText="Title"
		DataField="Title" SortExpression="Title" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
                
                <asp:BoundField ReadOnly="True" HeaderText="Debit"
		DataField="Debit" SortExpression="Debit"  HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                
                <asp:BoundField ReadOnly="True" HeaderText="Credit"
		DataField="Credit" SortExpression="Credit" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                
                
            </Columns>
        </asp:GridView>
        <br />
    
    </div>
    </form>
</body>
</html>
