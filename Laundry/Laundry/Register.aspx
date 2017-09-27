<%@ Page Title="" Language="C#" MasterPageFile="~/Client.Master" AutoEventWireup="true" Async="true"  enableEventValidation="false" CodeBehind="Register.aspx.cs" Inherits="Laundry.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="margin-top:5%; margin-left:5%; margin-right:5%">
        <h1>SignUp</h1>
    <div class="container">
        <table class="table-responsive" style="border-collapse:separate; border-spacing:0 5px;">
            <tr >
                <td>Name</td>
                <td></td>
                <td><asp:TextBox ID="txtName" class="form-control"   PlaceHolder="Name" Width="100%" required="true" runat="server"></asp:TextBox></td>
                
            </tr>
            <tr>
                <td>Address</td>
                <td></td>
                <td ><asp:TextBox ID="txtAddress" class="form-control" Width="100%" PlaceHolder="Address" runat="server"  required="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Phone Number</td>
                <td></td>
                <td ><asp:TextBox ID="txtphoneno" TextMode="Phone" class="form-control" Width="100%" PlaceHolder="Phone NO" runat="server"  required="true"></asp:TextBox></td>
                <td><asp:Button ID="btnSendCode" runat="server" CssClass="btn" Text="Send Code" OnClick="btnSendCode_Click" /></td>
            </tr>
            
            <tr>
                <td>VerifyCode</td>
              <td></td> 
                <td ><asp:TextBox ID="txtCode" class="form-control" Width="100%" PlaceHolder="Enter Verification code" runat="server"  required="true"></asp:TextBox></td>
                <td><asp:Button ID="btnverify" runat="server" CssClass="btn" Text="Verify" OnClick="btnverify_Click" /></td>
            </tr>
            <tr>
                <td>Status</td>
              <td></td> 
               
                <td><asp:Label ID="lblMessage" class="form-control" runat="server" Visible="false"></asp:Label></td>
            </tr>
            
            <tr>
                <td>Email</td>
                <td></td>
                <td ><asp:TextBox ID="txtmail" Width="100%" runat="server"  required="true" class="form-control"  Placeholder="Email" TextMode="Email"></asp:TextBox></td>
            </tr>
            
            <tr>
                <td>Password</td>
                <td></td>
                <td ><asp:TextBox ID="txtPassword" Width="100%" class="form-control" TextMode="Password" required="true" placeholder="Password" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Image</td>
                <td></td>
                <td ><asp:FileUpload class="btn btn-success btn-file" BackColor="#cc00ff" ID="flImage"  runat="server"></asp:FileUpload></td>
                
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td ><asp:Button runat="server" CssClass="btn btn-file"   BackColor="#cc00ff" ID="imgUpload" Text="Upload Image" OnClick="imgUpload_Click"   /></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td ><asp:Image runat="server" ID="imgselected" Width="100px" Height="100px" /></td>
            </tr>
             <tr style="color:red">
                 <td></td>
                <td></td>
                <td><asp:Label runat="server" ID="lblerror"></asp:Label></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td><asp:Button ID="btnsignup" CssClass="btn btn-google" runat="server" Text="Submit" OnClick="btnsignup_Click"   /></td>
            </tr>
           
            
        </table>

</div>
      
        </div>



</asp:Content>
