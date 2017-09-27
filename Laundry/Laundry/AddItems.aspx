<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" enableEventValidation="false" CodeBehind="AddItems.aspx.cs" Inherits="Laundry.AddItems" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form class="form-group">
    <div class="container">
        <table class="table-responsive" style="border-collapse:separate; border-spacing:0 5px;">
            <tr style=" ">
                <td>Item Name</td>
                <td></td>
                <td style="border: 1px groove black; "><asp:TextBox ID="txtname" class="form-control" Width="100%" PlaceHolder="Name" runat="server"></asp:TextBox></td>
            </tr>
            <tr style=" ">
                <td>Category</td>
                <td></td>
                <td style="border: 1px groove black; "><asp:DropDownList ID="ddlCategory" class="form-control" Width="100%" runat="server"></asp:DropDownList></td>
            </tr>
             <tr style=" ">
                <td>UnitPrice</td>
                <td></td>
                <td style="border: 1px groove black; "><asp:TextBox ID="txtPrice" class="form-control" Width="100%" PlaceHolder="UnitPrice" runat="server"/></td>
            </tr>
            <tr>
                <td>Item Image</td>
                <td></td>
                <td ><asp:FileUpload ID="fileImage" runat="server"></asp:FileUpload></td>
                
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td ><asp:Button runat="server" ID="btnUpload" Text="Upload Image" OnClick="btnUpload_Click"   /></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td ><asp:Image runat="server" ID="imgItem" Width="100px" Height="100px" /></td>
            </tr>

            <tr>
                <td>Remarks</td>
                <td></td>
                <td style="border: 1px groove black;"><asp:TextBox ID="TxtRemarks" Width="100%" runat="server" placeholder="Remarks"></asp:TextBox></td>
            </tr>

            <tr>
                <td>IsEnabled</td>
                <td></td>
                <td><asp:CheckBox ID="chkEnabled" runat="server" /></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnSubmit" CssClass="art-button" runat="server" Text="Submit" OnClick="btnSubmit_Click"  /></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Label runat="server" ID="lblerror"></asp:Label></td>
            </tr>
            
        </table>

</div>
        </form>
</asp:Content>
