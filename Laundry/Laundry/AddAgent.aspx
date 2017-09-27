<%@ Page Title="" Language="C#" MasterPageFile="~/AdminDashBoard.Master" AutoEventWireup="true" enableEventValidation="false" CodeBehind="AddAgent.aspx.cs" Inherits="Laundry.AddAgent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="server">
     <div style="margin-top:5%; margin-left:5%; margin-right:5%">

         <h1>Add Agent</h1>

        <table class="table-responsive" style="border-collapse:separate; border-spacing:0 5px;">
            <tr style=" ">
                <td>Agent Name</td>
                <td></td>
                <td ><asp:TextBox ID="txtName"  class="form-control" runat="server" placeholder="Name"></asp:TextBox></td>
            </tr>

            <tr>
                <td>Agent Email</td>
                <td></td>
                <td ><asp:TextBox ID="txtAgentEmail"  class="form-control" placeholder="Email" TextMode="Email" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>AgentPassword</td>
                <td></td>
                <td ><asp:TextBox ID="txtAgentPassword" CssClass="form-control" placeholder="Password" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Phone No:</td>
                <td></td>
                <td > <asp:TextBox class="form-control"  ID="txtAgentPhoneNO" placeholder="Phone Number" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Agent Image</td>
                <td></td>
                <td ><asp:FileUpload ID="fileAgentImage" class="btn btn-success btn-file" BackColor="#cc00ff" runat="server"></asp:FileUpload></td>
                
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td ><asp:Button runat="server" ID="btnUpload" class="btn btn-file"   BackColor="#cc00ff" Text="Upload Image" OnClick="btnUpload_Click" /></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td ><asp:Image runat="server" ID="imgAgent" Width="100px" Height="100px" /></td>
            </tr>
            <tr>
                <td>Agent Address</td>
                <td></td>
                <td ><asp:TextBox ID="txtAdress" class="form-control"   placeholder="Address" TextMode="MultiLine" runat="server" /></td>
            </tr>
            <tr>
                <td>Agent Remarks</td>
                <td></td>
                <td ><asp:TextBox ID="TxtRemarks"  class="form-control"   placeholder="Remarks" runat="server"></asp:TextBox></td>
            </tr>

            <tr>
                <td>IsEnabled</td>
                <td></td>
                <td ><asp:CheckBox ID="chkEnabled" runat="server"  /></td>
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
 <style> 
#chkcheckbox:checked{
    height: 50px;
    width: 50px;
}
</style>
</asp:Content>
