<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" enableEventValidation="false" CodeBehind="AddVehicle.aspx.cs" Inherits="Laundry.AddVehicle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <form class="form-group">
    <div class="container">
        <table class="table-responsive" style="border-collapse:separate; border-spacing:0 5px;">
            <tr style=" ">
                <td>Agent Name</td>
                <td></td>
                <td style="border: 1px groove black; "><asp:DropDownList ID="ddlAgent" class="form-control" runat="server"></asp:DropDownList></td>
            </tr>
            <tr style=" ">
                <td>Driver Name</td>
                <td></td>
                <td style="border: 1px groove black; "><asp:DropDownList ID="ddlDriver" class="form-control" runat="server"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>Not Assign Driver</td>
                <td></td>
                <td><asp:CheckBox ID="chkDriver" runat="server" Checked="false"/></td>
            </tr>
            <tr>
                <td>Vehicle Maker</td>
                <td></td>
                <td style="border: 1px groove black;"><asp:TextBox ID="txtMake" Width="100%" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Registration No:</td>
                <td></td>
                <td style="border: 1px groove black;"> <asp:TextBox ID="txtRegNO" Width="100%" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Vehicle Image</td>
                <td></td>
                <td ><asp:FileUpload ID="fileImage" runat="server"></asp:FileUpload></td>
                
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td ><asp:Button runat="server" ID="btnUpload" Text="Upload Image" OnClick="btnUpload_Click"  /></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td ><asp:Image runat="server" ID="imgvehicle" Width="100px" Height="100px" /></td>
            </tr>

            <tr>
                <td>Vehivle Remarks</td>
                <td></td>
                <td style="border: 1px groove black;"><asp:TextBox ID="TxtRemarks" Width="100%" runat="server"></asp:TextBox></td>
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
