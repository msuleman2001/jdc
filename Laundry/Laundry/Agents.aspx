<%@ Page Title="" Language="C#" MasterPageFile="~/AdminDashBoard.Master" AutoEventWireup="true" enableEventValidation="False" CodeBehind="Agents.aspx.cs" Inherits="Laundry.Agents" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="server">
     <div style="margin-top:5%; margin-left:5%; margin-right:5%">
      <h1>Agents</h1>
     <asp:GridView ID="gdvAgents" runat="server"  CssClass="table table-hover table-responsive" AutoGenerateColumns="False" OnRowDataBound="gdvAgents_RowDataBound" OnRowCommand="gdvAgents_RowCommand">
                <HeaderStyle BackColor="#9900cc" ForeColor="White" />

                <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>

                <Columns>

                
                    <asp:BoundField HeaderText="Agent Name" DataField="AgentName" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                 
                    <asp:BoundField HeaderText="Agent Email" DataField="AgentEmail" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Phone Number" DataField="AgentPhoneNO" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                     <asp:BoundField HeaderText="AgentAddress" DataField="AgentAddress" ItemStyle-BorderWidth="1px">
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
                    <asp:TemplateField HeaderText="Admin Name">
                        <AlternatingItemTemplate>
                            <asp:Label ID="lblAdminName" runat="server"></asp:Label>
                            <asp:Label ID="lblAdminID" runat="server" Text='<%# Eval("AdminID") %>' Visible="False"></asp:Label>
                        </AlternatingItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblAdminName" runat="server"></asp:Label>
                            <asp:Label ID="lblAdminID" runat="server" Text='<%# Eval("AdminID") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Agent Image">
                        <ItemTemplate>
                            <asp:Image ID="imgAgentImage" runat="server" Width="50px" Height="50px" ImageUrl='<%# Eval("AgentImage") %>' ></asp:Image>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Actions" ItemStyle-CssClass="column" ItemStyle-BorderWidth="1px">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/images/edit.png" CommandArgument='<%# Eval("AgentID") %>' CommandName="EditAgent" />
                            <asp:ImageButton ID="btnDeletCustomer" runat="server" ImageUrl="~/images/Delete.png" CommandArgument='<%# Eval("AgentID") %>' CommandName="DeleteAgent" OnClientClick="return confirm('Are you sure to delet this item');" />
                        </ItemTemplate>

                        <ItemStyle BorderWidth="1px" CssClass="column"></ItemStyle>
                    </asp:TemplateField>

                </Columns>

               
            </asp:GridView>
            <asp:Button ID="btnAgent" runat="server" CssClass="btn" BackColor="#9900cc" ForeColor="White"  Text="Add Agent" OnClick="btnAgent_Click" />
        </div>
</asp:Content>
