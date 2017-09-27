<%@ Page Title="" Language="C#" MasterPageFile="~/AdminDashBoard.Master" AutoEventWireup="true" enableEventValidation="false" CodeBehind="Clients.aspx.cs" Inherits="Laundry.Clients" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="server">
    <div style="margin-top:5%; margin-left:5%; margin-right:5%">
        <h1>Clients</h1>
    <asp:GridView ID="grdClients" runat="server" CssClass="table table-hover table-responsive" AutoGenerateColumns="False" OnRowCommand="grdClients_RowCommand" >
        <HeaderStyle BackColor="#9900cc" ForeColor="White"/>
            <Columns>
                <asp:BoundField DataField="CustomerName" HeaderText="Name" />
                <asp:BoundField DataField="CustomerAddress" HeaderText="Address" />
                <asp:BoundField DataField="CustomerPhoneNo" HeaderText="PhoneNO" />
                <asp:BoundField DataField="CustomerEmail" HeaderText="Email" />
                <asp:BoundField DataField="DateJoind" HeaderText="Date Joind" />
                <asp:BoundField DataField="CustomerRemarks" HeaderText="Remarks" />
                <asp:BoundField DataField="IsEnabled" HeaderText="Enabled" />
                <asp:TemplateField HeaderText="Image">
                    <ItemTemplate>
                        <asp:Image ImageUrl='<%# Eval("CustomerImage") %>' Width="50px" Height="50px" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:ImageButton ID="btnedit" runat="server" ImageUrl="~/images/edit.png" CommandName="EditClient" CommandArgument='<%# Eval("ClientID") %>' />
                        <asp:ImageButton ID="btndelet" runat="server" ImageUrl="~/images/Delete.png" CommandName="deleteClient" CommandArgument='<%# Eval("ClientID") %>'  OnClientClick="return confirm('Are you sure to delet this item');"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        </div>
</asp:Content>
