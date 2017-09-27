<%@ Page Title="" Language="C#" MasterPageFile="~/Client.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Laundry.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="content-wrapper">
        <div style="float: left; margin-left: 20%">
            <h1>Profile</h1>
            <table id="tblclient" class="table .table-striped">
                <tr>
                    <td>Name:</td>
                    <td></td>
                    <td>
                        <asp:Label ID="lblname" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>Customer Address:</td>
                    <td></td>
                    <td>
                        <asp:Label ID="lblAddress" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>Phone No:</td>
                    <td></td>
                    <td>
                        <asp:Label ID="lblphone" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>Customer Email:</td>
                    <td></td>
                    <td>
                        <asp:Label ID="lblEmail" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>Customer Image:</td>
                    <td></td>
                    <td>
                        <asp:Image ID="imgCustomer" Width="100px" Height="100px" runat="server"></asp:Image></td>
                </tr>

                <tr style="display: none;">
                    <td>Customer Password:</td>
                    <td></td>
                    <td>
                        <asp:Label ID="lblPassword" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>Date joined:</td>
                    <td></td>
                    <td>
                        <asp:Label ID="lbljoind" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td>
                        <asp:Button ID="btnEdit" runat="server" CssClass="art-button" Text="Edit" OnClick="btnEdit_Click" /></td>
                </tr>
            </table>
        </div>
        <div style="float: left; margin-left: 10%;">
            <h1>Preferances Details</h1>
            <div>

<style type="text/css">
    .box{
      
        background: #f0e68c;
        border: 1px solid #a29415;
    }
    .box-inner{
        padding: 10px;
    }
    .lblInside {
        cursor: pointer;
    }
}
</style>
<script src="https://code.jquery.com/jquery-1.12.4.min.js"></script>
<script type="text/javascript">


    function perform_toggle(id) {
        
        var parent_div = document.getElementById(id).parentElement;
        
        $(parent_div).next().toggle();
    }

    function save_prefrence(btnInside)
    {
        /*var value = $(btnInside).prev();
        var prefrence_value_id = value;
        var paramList = '{"prefrence_value_id":"' + prefrence_value_id + '"}';
        var a = "abc";
        */
        var status = '1';
        if (btnInside.style.backgroundColor == 'green') {
            status = '0';
            $(btnInside).css('background', 'white', 'color','white');
        }
        else
            $(btnInside).css('background', 'green');
        var siblings = $(btnInside).siblings();
        var selected_id = siblings[1].value;
        var hidIDList = document.getElementById('hidIDList');
        var selected_id_list = hidIDList.value.split(',');
        
        hidIDList.value = hidIDList.value + ',' + selected_id;
        var paramList = '{"prefrence_value_id":"' + selected_id + '","status":"' + status + '"}';
        $.ajax({
            type: 'POST',
            url: 'Profile.aspx/GetInputPreferences',
            data: paramList,
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (response) {  },
            error: function (jqxHR) { alert("no"); }
        });
        
        return false;
        //ajax call for server function
    }
</script>
                
<div class="dl-horizontal">
    <input type="hidden" id="hidIDList" />
    <asp:Label ID="a" runat="server"></asp:Label>
    <asp:DataList ID="lstPreferences" runat="server" OnItemDataBound="lstPreferences_ItemDataBound" >
        <ItemTemplate>
            <div >
                <span class="glyphicon glyphicon-resize-vertical"></span>
            -     <asp:Label ID="btnPrefrenceName" Text='<%# Eval("PreferanceName") %>' runat="server" class = "btn btn-secondary btn-lg dropdown-togglet" Width="80%" BackColor="#3399ff" ForeColor="WhiteSmoke" Font-Bold="true" data-toggle="dropdown"  onclick="perform_toggle(this.id);"/>
                <asp:Label ID="lblPreferenceID" runat="server"  Text='<%# Eval("PreferanceID") %>' Visible="false"></asp:Label>
            </div>
            <div id="div2" style="margin-left:25px; cursor:default; display:contents" >
                <asp:DataList ID="lstPreferenceValues" CssClass="col-md-2 control-label" runat="server">
                    <ItemTemplate>
                        <asp:HiddenField ID="lblPrefrenceID" runat="server" value='<%# Eval("PreferanceID") %>' Visible="true"></asp:HiddenField>
                        
                        <asp:HiddenField ID="hidValueID" runat="server" Value='<%# Eval("ValueID") %>' Visible="true"></asp:HiddenField>
                      <asp:Label ID="lblInside" CssClass="zom form-control" Font-Bold="true" ForeColor="#000000" runat="server" Text='<%# Eval("ValueName") %>' onclick="return save_prefrence(this);" BackColor="White" Width="140px"  class = "form-control"  />
                    </ItemTemplate>

                </asp:DataList>

            </div>
        </ItemTemplate>

    </asp:DataList>
    <style>
        .zom:hover {
            -webkit-transition: all 200ms ease-in;
            -webkit-transform: scale(1.2);
            -ms-transition: all 200ms ease-in;
            -ms-transform: scale(1.2);
            -moz-transition: all 200ms ease-in;
            -moz-transform: scale(1.2);
            transition: all 200ms ease-in;
            transform: scale(1.2);
            font-size:larger;
            color:goldenrod;
        }

    </style>
                <asp:Label ID="lblError" runat="server"  ></asp:Label>
            </div>
                </div>

            <asp:Button ID="btnInsert" runat="server" CssClass="art-button" Text="Add Preferance" OnClick="btnInsert_Click" />
        </div>
        <div style="float: left; margin-left: 5%;">
            <h1>Account Details</h1>
            <asp:GridView ID="GdvCards" runat="server" AutoGenerateColumns="False" BorderStyle="Ridge" Width="10%" CssClass="table .table-hover " AllowPaging="true" BorderColor="#ffffff"
                HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" RowStyle-BackColor="#A1DCF2" AlternatingRowStyle-BackColor="White"
                Style="-webkit-border-radius: 16px; align-self: center; -moz-border-radius: 16px; border-radius: 16px; overflow: hidden; font-family: Arial; font-size: 10pt; text-align: center; border-style: none;"
                OnRowCommand="GdvCards_RowCommand">
                <HeaderStyle Font-Bold="true" ForeColor="#ffffff" BackColor="#0066ff" />

                <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>

                <Columns>

                    <asp:BoundField HeaderText="Bank Name" DataField="BankName" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Credit Card NO" DataField="CreditCardNo" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Expiry date" DataField="DateExp" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Default" DataField="IsDefault" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Account Remarks" DataField="AccountRemarks" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Date Edit" DataField="DateCreated" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="IsEnabled" DataField="IsEnabled" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="CVV" DataField="CVV" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Name On Card" DataField="NameOnCard" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>


                    <asp:TemplateField HeaderText="Actions" ItemStyle-CssClass="column" ItemStyle-BorderWidth="1px">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/images/edit.png" CommandArgument='<%# Eval("PaymentAccID") %>' CommandName="EditCard" />
                            <asp:ImageButton ID="btnDeletCustomer" runat="server" ImageUrl="~/images/Delete.png" CommandArgument='<%# Eval("PaymentAccID") %>' CommandName="DeleteCard" OnClientClick="return confirm('Are you sure to delet this item');" />
                        </ItemTemplate>

                        <ItemStyle BorderWidth="1px" CssClass="column"></ItemStyle>
                    </asp:TemplateField>

                </Columns>

                <RowStyle BackColor="#A1DCF2"></RowStyle>
            </asp:GridView>
            <asp:Button ID="btnAdd" runat="server" CssClass="art-button" Text="Add Account" OnClick="btnAdd_Click" />
        </div>

   

    <div class="container">
        <table class="table-responsive" style="border-collapse:separate; border-spacing:0 5px;">
            <tr>
                <td colspan="3"><h1>Place New Order</h1></td>
            </tr>
            <tr style=" ">
                <td>Request Pick up Date</td>
                <td></td>
                <td><asp:TextBox ID="txtRequstdate" TextMode="Date" class="form-control" runat="server"></asp:TextBox></td>
                <td></td>
                <td></td>
            </tr>
            <tr style=" ">
                <td>Pickup Time From:</td>
                <td></td>
                <td ><asp:TextBox ID="txtRequstedTimeFrom" TextMode="Time" Width="100%" runat="server"></asp:TextBox></td>
                 <td>To</td>
                <td ><asp:TextBox ID="txtRequestedTimeEnd" TextMode="Time" Width="100%" runat="server"></asp:TextBox></td>
            </tr>

            <tr style=" ">
                <td>Request Delivery Date</td>
                <td></td>
                <td><asp:TextBox ID="txtDueDate" TextMode="Date" class="form-control" runat="server"></asp:TextBox></td>
                <td></td>
                <td></td>
            </tr>
            <tr style=" ">
                <td>Delivery Time From:</td>
                <td></td>
                <td ><asp:TextBox ID="txtdelviryfrom" TextMode="Time" Width="100%" runat="server"></asp:TextBox></td>
                 <td>To</td>
                <td ><asp:TextBox ID="txtdelviryto" TextMode="Time" Width="100%" runat="server"></asp:TextBox></td>
            </tr>
           
            <tr>
                <td>Remarks</td>
                <td></td>
                <td style="border: 1px groove black;"><asp:TextBox ID="TxtRemarks" TextMode="MultiLine" Width="100%" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td><asp:CheckBox Visible="false" ID="chkEnabled" Checked="true" runat="server" /></td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnSubmit" CssClass="art-button" runat="server" Text="Submit" OnClick="btnSubmit_Click" /></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td><asp:Label runat="server" ID="lblerrormsg"></asp:Label></td>
            </tr>
            
        </table>

</div>

    </div>

     <div style="float: left; margin-left: 2%;">
            <h1>Orders</h1>
            <asp:GridView ID="gdvOrder" runat="server" AutoGenerateColumns="False" BorderStyle="Ridge" Width="100%" CssClass="table .table-hover " AllowPaging="true" BorderColor="#ffffff"
                HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" RowStyle-BackColor="#A1DCF2" AlternatingRowStyle-BackColor="White"
                Style="-webkit-border-radius: 16px; align-self: center; -moz-border-radius: 16px; border-radius: 16px; overflow: hidden; font-family: Arial; font-size: 10pt; text-align: center; border-style: none;" OnRowCommand="gdvOrder_RowCommand">
                <HeaderStyle Font-Bold="true" ForeColor="#ffffff" BackColor="#0066ff" />

                <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>

                <Columns>

                    <asp:BoundField HeaderText="OrderID" DataField="OrderID" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Order Date" DataField="DateCreation" ItemStyle-BorderWidth="1px">
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
                    <asp:BoundField HeaderText="Pickup Date Time" DataField="PickupDateTime" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Drop Date Time" DataField="DropOfDateTime" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Status" DataField="Status" ItemStyle-BorderWidth="1px">
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

</asp:Content>
