<%@ Page Title="" Language="C#" MasterPageFile="~/AdminDashBoard.Master" AutoEventWireup="true" CodeBehind="Drivers.aspx.cs" Inherits="Laundry.Drivers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="server">
           <div style="margin-top:5%; width:95%; margin-left:3% " >
        <h1>Driver</h1>
            
     <asp:GridView ID="gdvDriver" runat="server" CssClass="table table-hover table-responsive" AutoGenerateColumns="False" OnRowDataBound="gdvDriver_RowDataBound" OnRowCommand="gdvDriver_RowCommand"  >
                <HeaderStyle BackColor="#9900cc" ForeColor="White" />

                <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>

                <Columns>
                    <asp:TemplateField HeaderText="Agent Name">
                        <AlternatingItemTemplate>
                            <asp:Label ID="lblAgentName" runat="server"></asp:Label>
                            <asp:Label ID="lblAgentID" runat="server" Text='<%# Eval("AgentID") %>' Visible="False"></asp:Label>
                        </AlternatingItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblAgentName" runat="server"></asp:Label>
                            <asp:Label ID="lblAgentID" runat="server" Text='<%# Eval("AgentID") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                
                    <asp:BoundField HeaderText="Driver Name" DataField="DriverName" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                 
                    <asp:BoundField HeaderText="Driver Email" DataField="DriverEmail" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Phone Number" DataField="DriverPhoneNO" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="licence NO" DataField="DriverlicenceNO" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Licence Expiry Date" DataField="LicenceExpDate" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Driver Address" DataField="DriverAddress" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>

                     
                    <asp:BoundField HeaderText="Remarks" DataField="Remarks" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField HeaderText="Date Created" DataField="DateCreated" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Enable" DataField="IsEnable" ItemStyle-BorderWidth="1px">
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
                            <asp:Image ID="imgAgentImage" runat="server" Width="50px" Height="50px" ImageUrl='<%# Eval("DriverImage") %>' ></asp:Image>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Actions" ItemStyle-CssClass="column" ItemStyle-BorderWidth="1px">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/images/edit.png" CommandArgument='<%# Eval("DriverID") %>' CommandName="EditDriver" />
                            <asp:ImageButton ID="btnDeletCustomer" runat="server" ImageUrl="~/images/Delete.png" CommandArgument='<%# Eval("DriverID") %>' CommandName="DeleteDriver" OnClientClick="return confirm('Are you sure to delet this item');" />
                        </ItemTemplate>

                        <ItemStyle BorderWidth="1px" CssClass="column"></ItemStyle>
                    </asp:TemplateField>

                </Columns>

           
            </asp:GridView>
      
            <asp:Button ID="BtnDriverAdd" runat="server" CssClass="btn" BackColor="#9900cc" ForeColor="White" Text="Add Driver" OnClick="BtnDriverAdd_Click" />
        </div>
</asp:Content>
