<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="gridCustomers" runat="server" 
            DataSourceID="DataSourceCustomers" AutoGenerateColumns="False" 
            onrowcommand="gridCustomers_RowCommand" 
            onrowdatabound="gridCustomers_RowDataBound">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                <asp:BoundField DataField="UserName" HeaderText="UserName" 
                    SortExpression="UserName" />
                <asp:CheckBoxField DataField="IsApproved" HeaderText="IsApproved" 
                    SortExpression="IsApproved" />
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="linkReject" runat="server" CausesValidation="false" 
                            Text="Reject" CommandName="Reject" CommandArgument='<%# Eval("Id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="linkApprove" runat="server" CausesValidation="false" 
                            Text="Approve" CommandName="Approve" CommandArgument='<%# Eval("Id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        
        <br />
        <br />
        <asp:TextBox ID="txtUserName" runat="server" />&nbsp;<asp:Button ID="btnAdd" 
            runat="server" Text="Add" onclick="btnAdd_Click" />
        
        <asp:ObjectDataSource ID="DataSourceCustomers" runat="server" 
            SelectMethod="GetCustomers" TypeName="Managers.CustomerManager" />
    </div>
    </form>
</body>
</html>
