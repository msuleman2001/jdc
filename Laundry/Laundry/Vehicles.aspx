<%@ Page Title="" Language="C#" MasterPageFile="~/AdminDashBoard.Master" AutoEventWireup="true" CodeBehind="Vehicles.aspx.cs" enableEventValidation="false" Inherits="Laundry.Vehicles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="server">
    <div style="margin-top:5%; margin-left:5%; margin-right:5%">
      <h1>Vehicles</h1>
     <asp:GridView ID="gdvVehicle" runat="server"  CssClass="table table-hover table-responsive" AutoGenerateColumns="False" OnRowCommand="gdvVehicle_RowCommand" OnRowDataBound="gdvVehicle_RowDataBound">
                <HeaderStyle BackColor="#9900cc" ForeColor="White" />

                <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>

                <Columns>

                
                    <asp:BoundField HeaderText="Vehicle Make" DataField="VehicleMake" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                 
                    <asp:BoundField HeaderText="Vehicle Color" DataField="VehicleColor" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Vehicle RegNO" DataField="VehicleRegNO" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                     <asp:BoundField HeaderText="DateCreated" DataField="DateCreated" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Remarks" DataField="Remarks" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="IsEnabled" DataField="IsEnabled" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Admin Name">
                        <ItemTemplate>
                            <asp:Label ID="lblAdminName" runat="server"></asp:Label>
                            <asp:Label ID="lblAdminID" runat="server" Text='<%# Eval("AdminID") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Agent Name">
                           <ItemTemplate>
                            <asp:Label ID="lblAgentName" runat="server"></asp:Label>
                            <asp:Label ID="lblAgentID" runat="server" Text='<%# Eval("AgentID") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Image">
                        <ItemTemplate>
                            <asp:Image ID="imgAgentImage" runat="server" Width="50px" Height="50px" ImageUrl='<%# Eval("VehicalImage") %>' ></asp:Image>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Actions" ItemStyle-CssClass="column" ItemStyle-BorderWidth="1px">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/images/edit.png" CommandArgument='<%# Eval("VehicleID") %>' CommandName="EditVehicle" />
                            <asp:ImageButton ID="btnDeletVehicle" runat="server" ImageUrl="~/images/Delete.png" CommandArgument='<%# Eval("VehicleID") %>' CommandName="DeleteVehicle" OnClientClick="return confirm('Are you sure to delet this item');" />
                        </ItemTemplate>

                        <ItemStyle BorderWidth="1px" CssClass="column"></ItemStyle>
                    </asp:TemplateField>

                </Columns>

               
            </asp:GridView>
            <asp:Button ID="btnVehicle" runat="server" CssClass="btn" BackColor="#9900cc" ForeColor="White"  Text="Add Vehicle"  />
        </div>
</asp:Content>
