<%@ Page Title="" Language="C#" MasterPageFile="~/AdminDashBoard.Master" AutoEventWireup="true" CodeBehind="PreferancesView.aspx.cs" Inherits="Laundry.PreferancesView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="server">
     <div style="margin-top:5%; margin-left:5%; margin-right:5%">
        <h1>Preferances</h1>
     <asp:GridView ID="gdvPreferances" runat="server" AutoGenerateColumns="False" CssClass="table table-hover table-responsive" OnRowCommand="gdvPreferances_RowCommand">
              <HeaderStyle BackColor="#9900cc" ForeColor="White" />

                <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>

                <Columns>

                
                    <asp:BoundField HeaderText="Preferance Name" DataField="PreferanceName" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Remarks" DataField="Remarks" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Date Created" DataField="DateCreated" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="IsEnabled" DataField="IsEnabled" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>

                    <asp:TemplateField HeaderText="Actions" ItemStyle-CssClass="column" ItemStyle-BorderWidth="1px">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/images/edit.png" CommandArgument='<%# Eval("PreferanceID") %>' CommandName="EditPreferance" />
                            <asp:ImageButton ID="btnDeletCustomer" runat="server" ImageUrl="~/images/Delete.png" CommandArgument='<%# Eval("PreferanceID") %>' CommandName="DeletePreferance" OnClientClick="return confirm('Are you sure to delet this item');" />
                        </ItemTemplate>

                        <ItemStyle BorderWidth="1px" CssClass="column"></ItemStyle>
                    </asp:TemplateField>

                </Columns>

                <RowStyle BackColor="#A1DCF2"></RowStyle>
            </asp:GridView>
            <asp:Button ID="btnInsert" runat="server" CssClass="btn btn-rose" BackColor="#9900cc" Text="Add Preferance" OnClick="btnInsert_Click"  />
        </div>
         <div style="margin-top:5%; margin-left:5%; margin-right:5%">
        <h1>Preferance Values</h1>
     <asp:GridView ID="gdvValues" runat="server" AutoGenerateColumns="False" CssClass="table table-hover table-responsive" OnRowDataBound="gdvValues_RowDataBound" OnRowCommand="gdvValues_RowCommand">
                 <HeaderStyle BackColor="#9900cc" ForeColor="White" />

                <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>

                <Columns>

                
                    <asp:BoundField HeaderText="Value Name" DataField="ValueName" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Preferance Name">
                        <AlternatingItemTemplate>
                            <asp:Label ID="lblPresefarnceName" runat="server"></asp:Label>
                            <asp:Label ID="lblPreferanceID" runat="server" Text='<%# Eval("PreferanceID") %>' Visible="False"></asp:Label>
                        </AlternatingItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblPresefarnceName" runat="server"></asp:Label>
                            <asp:Label ID="lblPreferanceID" runat="server" Text='<%# Eval("PreferanceID") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Remarks" DataField="Remarks" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Date Created" DataField="DateCreated" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="IsEnabled" DataField="IsEnabled" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>

                    <asp:TemplateField HeaderText="Actions" ItemStyle-CssClass="column" ItemStyle-BorderWidth="1px">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/images/edit.png" CommandArgument='<%# Eval("ValueID") %>' CommandName="EditPreferanceValue" />
                            <asp:ImageButton ID="btnDeletCustomer" runat="server" ImageUrl="~/images/Delete.png" CommandArgument='<%# Eval("ValueID") %>' CommandName="DeletePreferanceValue" OnClientClick="return confirm('Are you sure to delet this item');" />
                        </ItemTemplate>

                        <ItemStyle BorderWidth="1px" CssClass="column"></ItemStyle>
                    </asp:TemplateField>

                </Columns>

                <RowStyle BackColor="#A1DCF2"></RowStyle>
            </asp:GridView>
            <asp:Button ID="btnValue" runat="server" CssClass="btn btn-rose" BackColor="#9900cc" Text="Add Preferance Values" OnClick="btnValue_Click" />
        </div>

    <div>
</asp:Content>
