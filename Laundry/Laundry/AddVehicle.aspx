<%@ Page Title="" Language="C#" MasterPageFile="~/AdminDashBoard.Master" AutoEventWireup="true" enableEventValidation="false" CodeBehind="AddVehicle.aspx.cs" Inherits="Laundry.AddVehicle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="server">
 <div style="margin-top:5%; margin-left:5%; margin-right:5%">

         <h1>Add Agent</h1>

        <table class="table-responsive" style="border-collapse:separate; border-spacing:0 5px;">
            <tr style=" ">
                <td>Agent Name</td>
                <td></td>
                <td ><asp:DropDownList ID="ddlAgent" class="form-control" runat="server"></asp:DropDownList></td>
            </tr>
            <tr style=" ">
                <td>Driver Name</td>
                <td></td>
                <td ><asp:DropDownList ID="ddlDriver" class="form-control" runat="server"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>Not Assign Driver</td>
                <td></td>
                <td><asp:CheckBox ID="chkDriver" class="form-control" runat="server" Checked="false"/></td>
            </tr>
            <tr>
                <td>Vehicle Maker</td>
                <td></td>
                <td><asp:TextBox ID="txtMake" Width="100%" placeholder="Maker" class="form-control" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Registration No:</td>
                <td></td>
                <td > <asp:TextBox ID="txtRegNO" class="form-control" placeholder="Registration Number" Width="100%" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Vehicle Image</td>
                <td></td>
                <td ><asp:FileUpload ID="fileImage" class="btn btn-success" runat="server"></asp:FileUpload></td>
                
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td ><asp:Button runat="server" ID="btnUpload" CssClass="btn btn-success"  Text="Upload Image" OnClick="btnUpload_Click"  /></td>
            </tr>

            <tr>
                <td></td>
                <td></td>
                <td ><asp:Image runat="server" ID="imgvehicle" class="form-control" Width="100px" Height="100px" /></td>
            </tr>
            <br />
            <tr>
                <td>Vehivle Remarks</td>
                <td></td>
                <td ><asp:TextBox ID="TxtRemarks" Width="100%" placeholder="Remarks" class="form-control" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>IsEnabled</td>
                <td></td>
                <td><asp:CheckBox ID="chkEnabled" class="form-control" runat="server" /></td>
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
</asp:Content>
