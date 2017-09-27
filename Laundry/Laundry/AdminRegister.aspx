<%@ Page Title="" Language="C#" MasterPageFile="~/AdminDashBoard.Master" AutoEventWireup="true" enableEventValidation="False" CodeBehind="AdminRegister.aspx.cs" Inherits="Laundry.AdminRegister" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="server">
    <div style="margin-top:5%; margin-left:5%; margin-right:5%">
        <h1>SignUp</h1>
    <div class="container">
        <table class="table-responsive" style="border-collapse:separate; border-spacing:0 5px;">
            <tr >
                <td>Admin Name</td>
                <td></td>
                <td><asp:TextBox ID="txtname" class="form-control"  PlaceHolder="Name" required="true" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Email</td>
                <td></td>
                <td ><asp:TextBox ID="txtEmail" TextMode="Email" class="form-control" PlaceHolder="Email" runat="server"  required="true"></asp:TextBox></td>
            </tr>
            
            <tr>
                <td>AdminPassword</td>
                <td></td>
                <td ><asp:TextBox ID="txtadminpassword" Width="100%" runat="server"  required="true" class="form-control" PlaceHolder="Password" TextMode="Password">adminpassword</asp:TextBox></td>
            </tr>
            <tr>
                <td>PhoneNo:</td>
                <td></td>
                <td> <asp:TextBox ID="txtPhoneNO" Width="100%" PlaceHolder="Phone No" class="form-control" runat="server"  required="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Addres</td>
                <td></td>
                <td> <asp:TextBox ID="txtAdress" Width="100%"   required="true" PlaceHolder="Address" class="form-control" TextMode="MultiLine" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Admin Image</td>
                <td></td>
                <td ><asp:FileUpload class="btn btn-success btn-file" BackColor="#cc00ff" ID="fileImage"  runat="server"></asp:FileUpload></td>
                
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td ><asp:Button runat="server" class="btn btn-file"   BackColor="#cc00ff" ID="btnUpload" Text="Upload Image" OnClick="btnUpload_Click"   /></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td ><asp:Image runat="server" ID="imgAdmin" Width="100px" Height="100px" /></td>
            </tr>

            <tr>
                <td>Remarks</td>
                <td></td>
                <td ><asp:TextBox ID="TxtRemarks" Width="100%" class="form-control"  required="true" placeholder="Remarks" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="visibility:hidden">Master Admin</td>
                <td></td>
                <td><asp:CheckBox ID="chkAdmin" runat="server"  required="true" Checked="false"/></td>
            </tr>
            <tr>
                <td>IsEnabled</td>
                <td></td>
                <td><asp:CheckBox ID="chkEnabled" class="form-control"   runat="server" /></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnSubmit" CssClass="btn btn-google" runat="server" Text="Submit" OnClick="btnSubmit_Click"   /></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Label runat="server" ID="lblerror"></asp:Label></td>
            </tr>
            
        </table>

</div>
      
        </div>
</asp:Content>
