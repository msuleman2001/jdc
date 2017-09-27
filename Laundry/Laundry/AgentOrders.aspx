<%@ Page Title="" Language="C#" MasterPageFile="~/Agent.Master" AutoEventWireup="true" CodeBehind="AgentOrders.aspx.cs" Inherits="Laundry.AgentOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <script type="text/javascript">
function myFunction() {
    var Reason = prompt("Please Reason ");
    if (Reason != null) {
        var paramList = '{"DeclinedRemarks":"' + Reason + '"}';
        $.ajax({
            type: 'POST',
            url: 'AgentOrders.aspx/declinedOrdersRemarks',
            data: paramList,
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (response) { },
            error: function (jqxHR) { alert("no"); }
            
        });
        
    }
}
</script>
    <div style="width:100%;color:green">
         <h1 style="margin-left:2%; color:chocolate">To be Picke</h1>
         <asp:GridView ID="gdvToPick" runat="server" AutoGenerateColumns="False" BorderStyle="Ridge"   Width="100%"   CssClass="table .table-hover " AllowPaging="true" BorderColor="chocolate" 
                HeaderStyle-BackColor="#ff6600" HeaderStyle-ForeColor="White" RowStyle-BackColor="#ff9933" AlternatingRowStyle-BackColor="White" 
                Style=" -webkit-border-radius: 16px; width:100%; align-self:center; -moz-border-radius: 16px; border-radius: 16px; overflow: hidden;
                font-family: Arial; font-size: 10pt; text-align: center; border-style: none;" OnRowDataBound="gdvToPick_RowDataBound" OnRowCommand="gdvToPick_RowCommand"   >
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
                                <asp:ImageButton ID="btnAssign" runat="server" ImageUrl="~/images/cmpltd.png" CommandArgument='<%# Eval("OrderID") %>' CommandName="Completed" />
                                <asp:ImageButton ID="btnCancle" runat="server" ImageUrl="~/images/cancel.png" CommandArgument='<%# Eval("OrderID") %>' CommandName="Cancel" OnClientClick="myFunction()" />
                            </ItemTemplate>
                            

                            <ItemStyle BorderWidth="1px" CssClass="column"></ItemStyle>
                        </asp:TemplateField>

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
                                <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/images/Add.png" CommandArgument='<%# Eval("OrderID") %>' CommandName="Details" />
                                <asp:ImageButton ID="btnAssign" runat="server" ImageUrl="~/images/cmpltd.png" CommandArgument='<%# Eval("OrderID") %>' CommandName="Completed" />
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
                font-family: Arial; font-size: 10pt; text-align: center; border-style: none;"  OnRowDataBound="gdvToPick_RowDataBound" OnRowCommand="gdvProcess_RowCommand"  >
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
                                <asp:ImageButton ID="btnAssign" runat="server" ImageUrl="~/images/cmpltd.png" CommandArgument='<%# Eval("OrderID") %>' CommandName="Completed" />
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
         <h1 style="margin-left:2%; color:#ff6600">Canceled Orders</h1>

          <asp:GridView ID="grdOrderReAssigned" runat="server" AutoGenerateColumns="False" BorderStyle="Ridge"   Width="100%"   CssClass="table .table-hover " AllowPaging="true" BorderColor="#ff6600" 
                HeaderStyle-BackColor="#ff6600" HeaderStyle-ForeColor="White" RowStyle-BackColor="#ff9933" AlternatingRowStyle-BackColor="White" 
                Style=" -webkit-border-radius: 16px; width:100%; align-self:center; -moz-border-radius: 16px; border-radius: 16px; overflow: hidden;
                font-family: Arial; font-size: 10pt; text-align: center; border-style: none;" OnRowDataBound="grdOrderReAssigned_RowDataBound"   >
                <HeaderStyle Font-Bold="true" ForeColor="#ffffff" BackColor="#ff6600" />  
                      
                    <AlternatingRowStyle BackColor="#ffff99"></AlternatingRowStyle>

                    <Columns>
                        <asp:TemplateField HeaderText="Order Number">
                            <ItemTemplate>
                                <asp:Label ID="lblOrderno" runat="server" ></asp:Label>
                                
                            </ItemTemplate>
                            <ItemStyle BorderWidth="1px" />
                        </asp:TemplateField>
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
</asp:Content>
