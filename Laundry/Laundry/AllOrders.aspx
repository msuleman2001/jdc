<%@ Page Title="" Language="C#" MasterPageFile="~/AdminDashBoard.Master" AutoEventWireup="true" CodeBehind="AllOrders.aspx.cs" Inherits="Laundry.AllOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="server">
    <div style="margin-top:5%; margin-left:5%; margin-right:5%">
     <div style="width:100%; color:green" id="divPlaced">
         <h1 style="margin-left:2%; color:#ff6600"><asp:Label runat="server" Text="Placed"></asp:Label></h1>
         <h3 style="margin-left:2%; color:black; margin-left:15%"><asp:Label runat="server" id="lblPlaced"></asp:Label></h3>
         <asp:GridView ID="gdvPlaced" runat="server" AutoGenerateColumns="False" BorderStyle="Ridge"   Width="100%"   CssClass="table .table-hover " AllowPaging="true" BorderColor="#ff6600" 
                HeaderStyle-BackColor="#ff6600" HeaderStyle-ForeColor="White" RowStyle-BackColor="#ff9933" AlternatingRowStyle-BackColor="White" 
                Style=" -webkit-border-radius: 16px; width:100%; align-self:center; -moz-border-radius: 16px; border-radius: 16px; overflow: hidden;
                font-family: Arial; font-size: 10pt; text-align: center; border-style: none;" OnRowDataBound="gdvPlaced_RowDataBound" OnRowCommand="gdvPlaced_RowCommand"  >
                <HeaderStyle Font-Bold="true" ForeColor="#ffffff" BackColor="#ff6600" />  
                      
                    <AlternatingRowStyle BackColor="#ffff99"></AlternatingRowStyle>

                    <Columns>

                        <asp:BoundField HeaderText="Order Number" DataField="OrderNumber" ItemStyle-BorderWidth="1px">
                            <ItemStyle BorderWidth="1px"></ItemStyle>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Customer Name">
                            <ItemTemplate>
                                <asp:Label ID="LblCustomerID" runat="server" Visible="false" Text='<%# Eval("ClientID") %>'></asp:Label>
                                <asp:Label ID="lblCustomerName" runat="server" ></asp:Label>
                            </ItemTemplate>
                            <ItemStyle BorderWidth="1px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Customer Addess">
                            <ItemTemplate>
                              
                                <asp:Label ID="lblCustomerAdd" runat="server" ></asp:Label>
                            </ItemTemplate>
                            <ItemStyle BorderWidth="1px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Agent Name">
                            <ItemTemplate>
                                <asp:Label ID="lblLaundryName" runat="server" Text="To  Be Assigned"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle BorderWidth="1px" />
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Ordar Date" DataField="DateCreation" ItemStyle-BorderWidth="1px">
                            <ItemStyle BorderWidth="1px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Requested Pickup Date" DataField="RequestPickupDate" ItemStyle-BorderWidth="1px">
                            <ItemStyle BorderWidth="1px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Pickup Time Slot" DataField="PickupTimeSlot" ItemStyle-BorderWidth="1px">
                            <ItemStyle BorderWidth="1px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Requested Drop Date" DataField="RequestDropOffDate" ItemStyle-BorderWidth="1px">
                            <ItemStyle BorderWidth="1px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Drop Time Slot" DataField="DropOffTimeSlot" ItemStyle-BorderWidth="1px">
                            <ItemStyle BorderWidth="1px"></ItemStyle>
                        </asp:BoundField>

                        <asp:BoundField HeaderText="Remarks" DataField="Remarks" ItemStyle-BorderWidth="1px">
                            <ItemStyle BorderWidth="1px"></ItemStyle>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Actions" ItemStyle-CssClass="column" ItemStyle-BorderWidth="1px">
                            <ItemTemplate>
                                <asp:ImageButton ID="btnAssign" runat="server" ImageUrl="~/images/Assign.png" CommandArgument='<%# Eval("OrderID") %>' CommandName="Assign" />
                            </ItemTemplate>

                            <ItemStyle BorderWidth="1px" CssClass="column"></ItemStyle>
                        </asp:TemplateField>
 

                    </Columns>

                    <RowStyle BackColor="#A1DCF2"></RowStyle>
                </asp:GridView>
    </div>

    <div style="width:100%;color:green">
         <h1 style="margin-left:2%; color:chocolate">To be Picke</h1>
         <asp:GridView ID="gdvToPick" runat="server" AutoGenerateColumns="False" BorderStyle="Ridge"   Width="100%"   CssClass="table .table-hover " AllowPaging="true" BorderColor="chocolate" 
                HeaderStyle-BackColor="#ff6600" HeaderStyle-ForeColor="White" RowStyle-BackColor="#ff9933" AlternatingRowStyle-BackColor="White" 
                Style=" -webkit-border-radius: 16px; width:100%; align-self:center; -moz-border-radius: 16px; border-radius: 16px; overflow: hidden;
                font-family: Arial; font-size: 10pt; text-align: center; border-style: none;" OnRowDataBound="gdvToPick_RowDataBound"  >
                <HeaderStyle Font-Bold="true" ForeColor="#ffffff" BackColor="chocolate" />  
                      
                    <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>

                     <Columns>

                        <asp:BoundField HeaderText="Order Number" DataField="OrderNumber" ItemStyle-BorderWidth="1px">
                            <ItemStyle BorderWidth="1px"></ItemStyle>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Customer Name">
                            <ItemTemplate>
                                <asp:Label ID="LblCustomerID" runat="server" Visible="false" Text='<%# Bind("ClientID") %>'></asp:Label>
                                <asp:Label ID="lblCustomerName" runat="server" ></asp:Label>
                            </ItemTemplate>
                            <ItemStyle BorderWidth="1px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Customer Addess">
                            <ItemTemplate>
                              
                                <asp:Label ID="lblCustomerAdd" runat="server" ></asp:Label>
                            </ItemTemplate>
                            <ItemStyle BorderWidth="1px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Agent Name">
                            <ItemTemplate>
                                <asp:Label ID="LblAgentID" runat="server" Visible="false" Text='<%# Bind("AgentID") %>'></asp:Label>
                                <asp:Label ID="lblAgentName" runat="server" ></asp:Label>
                            </ItemTemplate>
                            <ItemStyle BorderWidth="1px" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Admin Name">
                            <ItemTemplate>
                                <asp:Label ID="LblAdminID" runat="server" Visible="false" Text='<%# Bind("AdminID") %>'></asp:Label>
                                <asp:Label ID="lblAdminName" runat="server" ></asp:Label>
                            </ItemTemplate>
                            <ItemStyle BorderWidth="1px" />
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Ordar Date" DataField="DateCreation" ItemStyle-BorderWidth="1px">
                            <ItemStyle BorderWidth="1px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Requested Pickup Date" DataField="RequestPickupDate" ItemStyle-BorderWidth="1px">
                            <ItemStyle BorderWidth="1px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Pickup Time Slot" DataField="PickupTimeSlot" ItemStyle-BorderWidth="1px">
                            <ItemStyle BorderWidth="1px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Requested Drop Date" DataField="RequestDropOffDate" ItemStyle-BorderWidth="1px">
                            <ItemStyle BorderWidth="1px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Drop Time Slot" DataField="DropOffTimeSlot" ItemStyle-BorderWidth="1px">
                            <ItemStyle BorderWidth="1px"></ItemStyle>
                        </asp:BoundField>

                        <asp:BoundField HeaderText="Remarks" DataField="Remarks" ItemStyle-BorderWidth="1px">
                            <ItemStyle BorderWidth="1px"></ItemStyle>
                        </asp:BoundField>

                    </Columns>

                    <RowStyle BackColor="#A1DCF2"></RowStyle>
                </asp:GridView>
    </div>

    <div style="width:100%;color:green">
         <h1 style="margin-left:2%; color:crimson">Picked</h1>
         <asp:GridView ID="gdvPicked" runat="server" AutoGenerateColumns="False" BorderStyle="Ridge"   Width="100%"   CssClass="table .table-hover " AllowPaging="true" BorderColor="crimson" 
                HeaderStyle-BackColor="#ff6600" HeaderStyle-ForeColor="White" RowStyle-BackColor="#ff9933" AlternatingRowStyle-BackColor="White" 
                Style=" -webkit-border-radius: 16px; width:100%; align-self:center; -moz-border-radius: 16px; border-radius: 16px; overflow: hidden;
                font-family: Arial; font-size: 10pt; text-align: center; border-style: none;" OnRowDataBound="gdvToPick_RowDataBound" OnRowCommand="gdvPicked_RowCommand"  >
                <HeaderStyle Font-Bold="true" ForeColor="#ffffff" BackColor="crimson" />  
                      
                    <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>

                     <Columns>

                        <asp:BoundField HeaderText="Order Number" DataField="OrderNumber" ItemStyle-BorderWidth="1px">
                            <ItemStyle BorderWidth="1px"></ItemStyle>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Customer Name">
                            <ItemTemplate>
                                <asp:Label ID="LblCustomerID" runat="server" Visible="false" Text='<%# Bind("ClientID") %>'></asp:Label>
                                <asp:Label ID="lblCustomerName" runat="server" ></asp:Label>
                            </ItemTemplate>
                            <ItemStyle BorderWidth="1px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Customer Addess">
                            <ItemTemplate>
                              
                                <asp:Label ID="lblCustomerAdd" runat="server" ></asp:Label>
                            </ItemTemplate>
                            <ItemStyle BorderWidth="1px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Agent Name">
                            <ItemTemplate>
                                <asp:Label ID="LblAgentID" runat="server" Visible="false" Text='<%# Bind("AgentID") %>'></asp:Label>
                                <asp:Label ID="lblAgentName" runat="server" ></asp:Label>
                            </ItemTemplate>
                            <ItemStyle BorderWidth="1px" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Admin Name">
                            <ItemTemplate>
                                <asp:Label ID="LblAdminID" runat="server" Visible="false" Text='<%# Bind("AdminID") %>'></asp:Label>
                                <asp:Label ID="lblAdminName" runat="server" ></asp:Label>
                            </ItemTemplate>
                            <ItemStyle BorderWidth="1px" />
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Ordar Date" DataField="DateCreation" ItemStyle-BorderWidth="1px">
                            <ItemStyle BorderWidth="1px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Requested Pickup Date" DataField="RequestPickupDate" ItemStyle-BorderWidth="1px">
                            <ItemStyle BorderWidth="1px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Pickup Time Slot" DataField="PickupTimeSlot" ItemStyle-BorderWidth="1px">
                            <ItemStyle BorderWidth="1px"></ItemStyle>
                        </asp:BoundField>
                         <asp:BoundField HeaderText="Pickup DateTime" DataField="PickupDateTime" ItemStyle-BorderWidth="1px">
                            <ItemStyle BorderWidth="1px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Requested Drop Date" DataField="RequestDropOffDate" ItemStyle-BorderWidth="1px">
                            <ItemStyle BorderWidth="1px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Drop Time Slot" DataField="DropOffTimeSlot" ItemStyle-BorderWidth="1px">
                            <ItemStyle BorderWidth="1px"></ItemStyle>
                        </asp:BoundField>

                        <asp:BoundField HeaderText="Remarks" DataField="Remarks" ItemStyle-BorderWidth="1px">
                            <ItemStyle BorderWidth="1px"></ItemStyle>
                        </asp:BoundField>
                  <asp:TemplateField HeaderText="Actions" ItemStyle-CssClass="column" ItemStyle-BorderWidth="1px">
                            <ItemTemplate>
                                 <asp:ImageButton ID="btnView" runat="server" ImageUrl="~/images/preview.png" CommandArgument='<%# Eval("OrderID") %>' CommandName="Preview" />
                            </ItemTemplate>

                            <ItemStyle BorderWidth="1px" CssClass="column"></ItemStyle>
                        </asp:TemplateField>
                    </Columns>

                    <RowStyle BackColor="#A1DCF2"></RowStyle>
                </asp:GridView>
    </div>

        <div style="width:100%;color:green">
         <h1 style="margin-left:2%; color:#0066ff">In Process</h1>
         <asp:GridView ID="gdvProcess" runat="server" AutoGenerateColumns="False" BorderStyle="Ridge"   Width="100%"   CssClass="table .table-hover " AllowPaging="true" BorderColor="#0066ff" 
                HeaderStyle-BackColor="#ff6600" HeaderStyle-ForeColor="White" RowStyle-BackColor="#ff9933" AlternatingRowStyle-BackColor="White" 
                Style=" -webkit-border-radius: 16px; width:100%; align-self:center; -moz-border-radius: 16px; border-radius: 16px; overflow: hidden;
                font-family: Arial; font-size: 10pt; text-align: center; border-style: none;" OnRowDataBound="gdvToPick_RowDataBound" OnRowCommand="gdvProcess_RowCommand"  >
                <HeaderStyle Font-Bold="true" ForeColor="#ffffff" BackColor="#0066ff" />  
                      
                    <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>

                   <Columns>

                        <asp:BoundField HeaderText="Order Number" DataField="OrderNumber" ItemStyle-BorderWidth="1px">
                            <ItemStyle BorderWidth="1px"></ItemStyle>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Customer Name">
                            <ItemTemplate>
                                <asp:Label ID="LblCustomerID" runat="server" Visible="false" Text='<%# Bind("ClientID") %>'></asp:Label>
                                <asp:Label ID="lblCustomerName" runat="server" ></asp:Label>
                            </ItemTemplate>
                            <ItemStyle BorderWidth="1px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Customer Addess">
                            <ItemTemplate>
                              
                                <asp:Label ID="lblCustomerAdd" runat="server" ></asp:Label>
                            </ItemTemplate>
                            <ItemStyle BorderWidth="1px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Agent Name">
                            <ItemTemplate>
                                <asp:Label ID="LblAgentID" runat="server" Visible="false" Text='<%# Bind("AgentID") %>'></asp:Label>
                                <asp:Label ID="lblAgentName" runat="server" ></asp:Label>
                            </ItemTemplate>
                            <ItemStyle BorderWidth="1px" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Admin Name">
                            <ItemTemplate>
                                <asp:Label ID="LblAdminID" runat="server" Visible="false" Text='<%# Bind("AdminID") %>'></asp:Label>
                                <asp:Label ID="lblAdminName" runat="server" ></asp:Label>
                            </ItemTemplate>
                            <ItemStyle BorderWidth="1px" />
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Ordar Date" DataField="DateCreation" ItemStyle-BorderWidth="1px">
                            <ItemStyle BorderWidth="1px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Requested Pickup Date" DataField="RequestPickupDate" ItemStyle-BorderWidth="1px">
                            <ItemStyle BorderWidth="1px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Pickup Time Slot" DataField="PickupTimeSlot" ItemStyle-BorderWidth="1px">
                            <ItemStyle BorderWidth="1px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Pickup DateTime" DataField="PickupDateTime" ItemStyle-BorderWidth="1px">
                            <ItemStyle BorderWidth="1px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Requested Drop Date" DataField="RequestDropOffDate" ItemStyle-BorderWidth="1px">
                            <ItemStyle BorderWidth="1px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Drop Time Slot" DataField="DropOffTimeSlot" ItemStyle-BorderWidth="1px">
                            <ItemStyle BorderWidth="1px"></ItemStyle>
                        </asp:BoundField>

                        <asp:BoundField HeaderText="Remarks" DataField="Remarks" ItemStyle-BorderWidth="1px">
                            <ItemStyle BorderWidth="1px"></ItemStyle>
                        </asp:BoundField>
                     <asp:TemplateField HeaderText="Actions" ItemStyle-CssClass="column" ItemStyle-BorderWidth="1px">
                            <ItemTemplate>
                                 <asp:ImageButton ID="btnView" runat="server" ImageUrl="~/images/preview.png" CommandArgument='<%# Eval("OrderID") %>' CommandName="Preview" />
                            </ItemTemplate>

                            <ItemStyle BorderWidth="1px" CssClass="column"></ItemStyle>
                        </asp:TemplateField>
                    </Columns>

                    <RowStyle BackColor="#A1DCF2"></RowStyle>
                </asp:GridView>
    </div>
      
    <div style="width:100%;color:white">
         <h1 style="margin-left:2%; color:green">Delivered</h1>
         <asp:GridView ID="gdvDelivered" runat="server" AutoGenerateColumns="False" BorderStyle="Ridge"   Width="100%"   CssClass="table .table-hover " AllowPaging="true" BorderColor="green" 
                HeaderStyle-BackColor="#ff6600" HeaderStyle-ForeColor="Black" RowStyle-BackColor="#ff9933" AlternatingRowStyle-BackColor="White" RowStyle-ForeColor="Black" 
                Style=" -webkit-border-radius: 16px; width:100%; align-self:center; -moz-border-radius: 16px; border-radius: 16px; overflow: hidden;
                font-family: Arial; font-size: 10pt; text-align: center; border-style: none;" OnRowDataBound="gdvToPick_RowDataBound" OnRowCommand="gdvDelivered_RowCommand"  >
                <HeaderStyle Font-Bold="true" ForeColor="#00000" BackColor="Green" />  
                      
                    <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>

                    <Columns>

                        <asp:BoundField HeaderText="Order Number" DataField="OrderNumber" ItemStyle-BorderWidth="1px">
                            <ItemStyle BorderWidth="1px"></ItemStyle>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Customer Name">
                            <ItemTemplate>
                                <asp:Label ID="LblCustomerID" runat="server" Visible="false" Text='<%# Bind("ClientID") %>'></asp:Label>
                                <asp:Label ID="lblCustomerName" runat="server" ></asp:Label>
                            </ItemTemplate>
                            <ItemStyle BorderWidth="1px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Customer Addess">
                            <ItemTemplate>
                              
                                <asp:Label ID="lblCustomerAdd" runat="server" ></asp:Label>
                            </ItemTemplate>
                            <ItemStyle BorderWidth="1px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Agent Name">
                            <ItemTemplate>
                                <asp:Label ID="LblAgentID" runat="server" Visible="false" Text='<%# Bind("AgentID") %>'></asp:Label>
                                <asp:Label ID="lblAgentName" runat="server" ></asp:Label>
                            </ItemTemplate>
                            <ItemStyle BorderWidth="1px" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Admin Name">
                            <ItemTemplate>
                                <asp:Label ID="LblAdminID" runat="server" Visible="false" Text='<%# Bind("AdminID") %>'></asp:Label>
                                <asp:Label ID="lblAdminName" runat="server" ></asp:Label>
                            </ItemTemplate>
                            <ItemStyle BorderWidth="1px" />
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Ordar Date" DataField="DateCreation" ItemStyle-BorderWidth="1px">
                            <ItemStyle BorderWidth="1px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Requested Pickup Date" DataField="RequestPickupDate" ItemStyle-BorderWidth="1px">
                            <ItemStyle BorderWidth="1px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Pickup Time Slot" DataField="PickupTimeSlot" ItemStyle-BorderWidth="1px">
                            <ItemStyle BorderWidth="1px"></ItemStyle>
                        </asp:BoundField>
                         <asp:BoundField HeaderText="Pickup DateTime" DataField="PickupDateTime" ItemStyle-BorderWidth="1px">
                            <ItemStyle BorderWidth="1px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Requested Drop Date" DataField="RequestDropOffDate" ItemStyle-BorderWidth="1px">
                            <ItemStyle BorderWidth="1px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Drop Time Slot" DataField="DropOffTimeSlot" ItemStyle-BorderWidth="1px">
                            <ItemStyle BorderWidth="1px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Drop DateTime" DataField="DropOfDateTime" ItemStyle-BorderWidth="1px">
                            <ItemStyle BorderWidth="1px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Remarks" DataField="Remarks" ItemStyle-BorderWidth="1px">
                            <ItemStyle BorderWidth="1px"></ItemStyle>
                        </asp:BoundField>
                     <asp:TemplateField HeaderText="Actions" ItemStyle-CssClass="column" ItemStyle-BorderWidth="1px">
                            <ItemTemplate>
                                 <asp:ImageButton ID="btnView" runat="server" ImageUrl="~/images/preview.png" CommandArgument='<%# Eval("OrderID") %>' CommandName="Preview" />
                            </ItemTemplate>

                            <ItemStyle BorderWidth="1px" CssClass="column"></ItemStyle>
                        </asp:TemplateField>
                    </Columns>

                    <RowStyle BackColor="#A1DCF2"></RowStyle>
                </asp:GridView>
    </div>

      <div style="width:100%; color:green">
         <h1 style="margin-left:2%; color:#ff6600">Canceled</h1>
         <asp:GridView ID="grdcanceled" runat="server" AutoGenerateColumns="False" BorderStyle="Ridge"   Width="100%"   CssClass="table .table-hover " AllowPaging="true" BorderColor="#ff6600" 
                HeaderStyle-BackColor="#ff6600" HeaderStyle-ForeColor="White" RowStyle-BackColor="#ff9933" AlternatingRowStyle-BackColor="White" 
                Style=" -webkit-border-radius: 16px; width:100%; align-self:center; -moz-border-radius: 16px; border-radius: 16px; overflow: hidden;
                font-family: Arial; font-size: 10pt; text-align: center; border-style: none;"   OnRowDataBound="grdcanceled_RowDataBound" OnRowCommand="grdcanceled_RowCommand"  >
                <HeaderStyle Font-Bold="true" ForeColor="#ffffff" BackColor="#ff6600" />  
                      
                    <AlternatingRowStyle BackColor="#ffff99"></AlternatingRowStyle>

                    <Columns>

                        <asp:BoundField HeaderText="Order Number" DataField="OrderNumber" ItemStyle-BorderWidth="1px">
                            <ItemStyle BorderWidth="1px"></ItemStyle>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Customer Name">
                            <ItemTemplate>
                                <asp:Label ID="LblCustomerID" runat="server" Visible="false" Text='<%# Eval("ClientID") %>'></asp:Label>
                                <asp:Label ID="lblCustomerName" runat="server" ></asp:Label>
                            </ItemTemplate>
                            <ItemStyle BorderWidth="1px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Customer Addess">
                            <ItemTemplate>
                              
                                <asp:Label ID="lblCustomerAdd" runat="server" ></asp:Label>
                            </ItemTemplate>
                            <ItemStyle BorderWidth="1px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Agent Name">
                            <ItemTemplate>
                                <asp:Label ID="lblagentID" runat="server" Text='<%# Eval("AgentID") %>' Visible="false"></asp:Label>
                                <asp:Label ID="lblAgentName" runat="server" Text=""></asp:Label>
                            </ItemTemplate>
                            <ItemStyle BorderWidth="1px" />
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Ordar Date" DataField="DateCreation" ItemStyle-BorderWidth="1px">
                            <ItemStyle BorderWidth="1px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Requested Pickup Date" DataField="RequestPickupDate" ItemStyle-BorderWidth="1px">
                            <ItemStyle BorderWidth="1px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Pickup Time Slot" DataField="PickupTimeSlot" ItemStyle-BorderWidth="1px">
                            <ItemStyle BorderWidth="1px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Requested Drop Date" DataField="RequestDropOffDate" ItemStyle-BorderWidth="1px">
                            <ItemStyle BorderWidth="1px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Drop Time Slot" DataField="DropOffTimeSlot" ItemStyle-BorderWidth="1px">
                            <ItemStyle BorderWidth="1px"></ItemStyle>
                        </asp:BoundField>

                        <asp:BoundField HeaderText="Remarks" DataField="Remarks" ItemStyle-BorderWidth="1px">
                            <ItemStyle BorderWidth="1px"></ItemStyle>
                        </asp:BoundField>

                        <asp:TemplateField HeaderText="Declined Remarks">
                            <ItemTemplate>
                                <asp:Label ID="LblOrderID" runat="server" Visible="false" Text='<%# Eval("OrderID") %>'></asp:Label>
                                <asp:Label ID="lbldeclinedRemarks" runat="server" ></asp:Label>
                            </ItemTemplate>
                            <ItemStyle BorderWidth="1px" />
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="Declined DateTime">
                            <ItemTemplate>
                                <asp:Label ID="lbldeclinedDateTime" runat="server" ></asp:Label>
                            </ItemTemplate>
                            <ItemStyle BorderWidth="1px" />
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="Status of Declined">
                            <ItemTemplate>
                                <asp:Label ID="lblDeclined" runat="server" ></asp:Label>
                            </ItemTemplate>
                            <ItemStyle BorderWidth="1px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Actions" ItemStyle-CssClass="column" ItemStyle-BorderWidth="1px">
                            <ItemTemplate>
                                <asp:ImageButton ID="btnAssign" runat="server" ImageUrl="~/images/Assign.png" CommandArgument='<%# Eval("OrderID") %>' CommandName="Assign" />
                            </ItemTemplate>

                            <ItemStyle BorderWidth="1px" CssClass="column"></ItemStyle>
                        </asp:TemplateField>
 

                    </Columns>

                    <RowStyle BackColor="#A1DCF2"></RowStyle>
                </asp:GridView>
    </div>
            <div style="width:100%; color:green">
         <h1 style="margin-left:2%; color:#ff6600">Canceled Assigned</h1>

          <asp:GridView ID="grdOrderReAssigned" runat="server" AutoGenerateColumns="False" BorderStyle="Ridge"   Width="100%"   CssClass="table .table-hover " AllowPaging="true" BorderColor="#ff6600" 
                HeaderStyle-BackColor="#ff6600" HeaderStyle-ForeColor="White" RowStyle-BackColor="#ff9933" AlternatingRowStyle-BackColor="White" 
                Style=" -webkit-border-radius: 16px; width:100%; align-self:center; -moz-border-radius: 16px; border-radius: 16px; overflow: hidden;
                font-family: Arial; font-size: 10pt; text-align: center; border-style: none;" OnRowDataBound="grdOrderReAssigned_RowDataBound"   >
                <HeaderStyle Font-Bold="true" ForeColor="#ffffff" BackColor="#ff6600" />  
                      
                    <AlternatingRowStyle BackColor="#ffff99"></AlternatingRowStyle>

                    <Columns>
                        <asp:TemplateField HeaderText="Customer Name">
                            <ItemTemplate>
                                <asp:Label ID="lblCustomerName" runat="server" ></asp:Label>
                                <asp:Label ID="lblOrderID" runat="server" Text='<%# Eval("OrderID") %>' Visible="false"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle BorderWidth="1px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Customer Addess">
                            <ItemTemplate>
                              
                                <asp:Label ID="lblCustomerAdd" runat="server" ></asp:Label>
                            </ItemTemplate>
                            <ItemStyle BorderWidth="1px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Agent Name">
                            <ItemTemplate>
                                <asp:Label ID="lblagentID" runat="server" Text='<%# Eval("AgentID") %>' Visible="false"></asp:Label>
                                <asp:Label ID="lblAgentName" runat="server" Text=""></asp:Label>
                            </ItemTemplate>
                            <ItemStyle BorderWidth="1px" />
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Cancel Date" DataField="DateCreated" ItemStyle-BorderWidth="1px">
                            <ItemStyle BorderWidth="1px"></ItemStyle>
                        </asp:BoundField>

                        <asp:BoundField HeaderText="Declined Remarks" DataField="DeclinedRemarks" ItemStyle-BorderWidth="1px">
                            <ItemStyle BorderWidth="1px"></ItemStyle>
                        </asp:BoundField>
                         <asp:TemplateField HeaderText="Status of Declined">
                            <ItemTemplate>
                                <asp:Label ID="lblDeclined" runat="server"  Text="Assigned to Other Agent"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle BorderWidth="1px" />
                        </asp:TemplateField>
                    </Columns>

                    <RowStyle BackColor="#A1DCF2"></RowStyle>
                </asp:GridView>

      </div>
        </div>
</asp:Content>
