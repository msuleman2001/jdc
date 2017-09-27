<%@ Page Title="" Language="C#" MasterPageFile="~/Agent.Master" AutoEventWireup="true" CodeBehind="AgentDefault.aspx.cs" Inherits="Laundry.AgentDefault" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="float: left; margin-left: 05%">
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
                        <asp:Button ID="btnEdit" runat="server" CssClass="art-button" Text="Edit" /></td>
                </tr>
            </table>
        </div>
        <div style="width:40%; height:300px; float:left; margin-left:5%;margin-top:3%">
            <h1>Orders</h1>
              <table id="tbl" class="table .table-striped" style=" border-width:1px; border-color:black;">
                <tr>
                    <td style="font-size:larger"><b>New Orders</b></td>
                    <td>=</td>
                    <td ><asp:Label ID="lblPlace" Font-Bold="true"  runat="server"/></td>
                    <td></td>
                    <td style="font-size:larger"><b>Picked Orders</b></td>
                    <td>=</td>
                    <td><asp:Label ID="lblPicked" Font-Bold="true"  runat="server"/></td>
                    
                </tr>
                 <tr>
                    <td style="font-size:larger"><b>Process Orders</b></td>
                     <td>=</td>
                    <td><asp:Label ID="lblprocess" Font-Bold="true"  runat="server"/></td>
                    <td></td>
                    <td style="font-size:larger"><b>Deliverd Orders</b></td>
                     <td>=</td>
                    <td><asp:Label ID="LblDeliverd" Font-Bold="true"  runat="server"/></td>
                    <td></td>
                </tr>
               
            </table>

        </div>
</asp:Content>
