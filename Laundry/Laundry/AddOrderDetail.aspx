<%@ Page Title="" Language="C#" MasterPageFile="~/Agent.Master" AutoEventWireup="true" enableEventValidation="false" CodeBehind="AddOrderDetail.aspx.cs" Inherits="Laundry.AddOrderDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div  >
        <div style="display:inline; margin-left:20%; margin-right:20%; width: 100%;">
            <table class="Table">
                <tr>
                    <td><asp:DropDownList ID="ddlItems" CssClass="form-control" runat="server"></asp:DropDownList></td>
                    <td><asp:TextBox ID="txtQty" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox></td>
                    <td></td>
                    <td><asp:Button Width="100px" ID="btnSubmit" CssClass="art-button" runat="server" Text="Add" OnClick="btnSubmit_Click"  /></td>
                 </tr>
            </table>
        </div>
         <asp:GridView ID="Gdvorder" runat="server" AutoGenerateColumns="False" BorderStyle="Ridge"   Width="100%"   CssClass="table .table-hover " AllowPaging="false" BorderColor="White" 
                HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" RowStyle-BackColor="#A1DCF2" AlternatingRowStyle-BackColor="White" 
                Style=" -webkit-border-radius: 16px; width:100%; align-self:center; -moz-border-radius: 16px; border-radius: 16px; overflow: hidden;
                font-family: Arial; font-size: 10pt; text-align: center; border-style: none;" OnRowCommand="Gdvorder_RowCommand"  >
                <HeaderStyle Font-Bold="true" ForeColor="#ffffff" BackColor="#0066ff" />  
                      
                    <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>

                    <Columns>

                       <asp:BoundField HeaderText="Item Name" DataField="ItemName" ItemStyle-BorderWidth="1px">
                            <ItemStyle BorderWidth="1px"></ItemStyle>
                        </asp:BoundField>
                         <asp:BoundField HeaderText="Quantity" DataField="Quantity" ItemStyle-BorderWidth="1px">
                            <ItemStyle BorderWidth="1px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="ItemUnitPrice" DataField="ItemUnitPrice" ItemStyle-BorderWidth="1px">
                            <ItemStyle BorderWidth="1px"></ItemStyle>
                            
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Total" ItemStyle-CssClass="column">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lbltotal"  Text='<%# Eval("Total") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                        <asp:TemplateField HeaderText="Actions" ItemStyle-CssClass="column" ItemStyle-BorderWidth="1px">
                            <ItemTemplate>
                                <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/images/edit.png" CommandArgument='<%# Eval("ItemID") %>' CommandName="EditOrderDetail" />
                                 <asp:ImageButton ID="btnDeletCustomer" runat="server" ImageUrl="~/images/Delete.png" CommandArgument='<%# Eval("ItemID") %>' CommandName="DeleteOrderDetail" OnClientClick="return confirm('Are you sure to delet this item');" />
                            </ItemTemplate>

                            <ItemStyle BorderWidth="1px" CssClass="column"></ItemStyle>
                        </asp:TemplateField>

                    </Columns>

                    <RowStyle BackColor="#A1DCF2"></RowStyle>
                </asp:GridView>
        <asp:Label ID="Label1" runat="server" Text="Total Bill = " ></asp:Label>
        <asp:Label ID="lbltotalbill" runat="server" ></asp:Label>
           <br />
        <asp:TextBox ID="txtRemarks"  Placeholder="Remarks" CssClass="form-control" runat="server"></asp:TextBox>
        <asp:Button ID="BtnInsert" runat="server" Text="Submit" OnClick="BtnInsert_Click" />
           </div> 
</asp:Content>
