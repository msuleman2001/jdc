<%@ Page Title="" Language="C#" MasterPageFile="~/AdminDashBoard.Master" AutoEventWireup="true"  enableEventValidation="false" CodeBehind="AddDriver.aspx.cs" Inherits="Laundry.AddDriver" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="server">
     <script type="text/javascript">
        $(function () {
            $("[id$=txtDateissue]").datepicker({
                changeMonth: true,
                changeYear: true,
                showButtonPanel: true,
                  
            });

            $("[id$=txtexpdate]").datepicker({
                changeMonth: true,
                changeYear: true,
                showButtonPanel: true,

            });
        });
    </script>

    <div class="container">
        <table class="table-responsive" style="border-collapse:separate; border-spacing:0 5px;">
            <tr style=" ">
                <td>Agent Name</td>
                <td></td>
                <td ><asp:DropDownList ID="ddlAgent" BackColor="#cc0099" ForeColor="White" class="form-control" runat="server"></asp:DropDownList></td>
            </tr>
            <tr style=" ">
                <td>Driver Name</td>
                <td></td>
                <td ><asp:TextBox ID="txtName" class="form-control" placeholder="Name" runat="server"></asp:TextBox></td>
            </tr>

            <tr>
                <td>Driver Email</td>
                <td></td>
                <td ><asp:TextBox ID="txtEmail" class="form-control" placeholder="Email" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Driver Password</td>
                <td></td>
                <td ><asp:TextBox ID="txtPassword" class="form-control" placeholder="Password"  runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Phone No:</td>
                <td></td>
                <td > <asp:TextBox ID="txtPhoneNO" class="form-control" placeholder="Phone Number" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Driver Image</td>
                <td></td>
                <td ><asp:FileUpload ID="fileImage" class="btn btn-success btn-file" BackColor="#cc00ff" runat="server"></asp:FileUpload></td>
                
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td ><asp:Button runat="server" ID="btnUpload" class="btn btn-file"   BackColor="#cc00ff" Text="Upload Image" OnClick="btnUpload_Click"  /></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td ><asp:Image runat="server" ID="imgAgent" Width="100px" Height="100px" /></td>
            </tr>
            <tr>
                <td>Driver Address</td>
                <td></td>
                <td ><asp:TextBox ID="txtAdress" Width="100%" placeholder="Address" class="form-control"  runat="server" /></td>
            </tr>
            <tr>
                <td>Licence No</td>
                <td></td>
                <td > <asp:TextBox ID="txtLicenceNo" Width="100%" placeholder="Licence Number" class="form-control"  runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Licence Issue Date</td>
                <td></td>
                <td ><asp:TextBox ID="txtDateissue" class="form-control" TextMode="Date" placeholder="IssueDate"  runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Licence Expiry Date</td>
                <td></td>
                <td ><asp:TextBox ID="txtexpdate" class="form-control" TextMode="Date" placeholder="Exp Date"  runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Driver Remarks</td>
                <td></td>
                <td ><asp:TextBox ID="TxtRemarks"  class="form-control" TextMode="MultiLine" placeholder="Remarks" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>IsEnabled</td>
                <td></td>
                <td><asp:CheckBox ID="chkEnabled" class="form-control"  runat="server" /></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnSubmit" CssClass="btn btn-google" runat="server" Text="Submit" OnClick="btnSubmit_Click"  /></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Label runat="server" ID="lblerror"></asp:Label></td>
            </tr>
            
        </table>

</div>
   
</asp:Content>
