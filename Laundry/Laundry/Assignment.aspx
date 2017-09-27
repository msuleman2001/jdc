<%@ Page Title="" Language="C#" MasterPageFile="~/AdminDashBoard.Master" AutoEventWireup="true" CodeBehind="Assignment.aspx.cs" Inherits="Laundry.Assignment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="server">
      <div style="margin-top:5%; margin-left:5%; margin-right:5%"> 
          <h1>Assign Order to Agent</h1>
        <table class="table-responsive">
            <tr>
                <td>Agent Name</td>
                <td><asp:DropDownList ID="ddlAgent" CssClass="form-control-static" runat="server"></asp:DropDownList></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnSubmit" CssClass="btn btn-rose" BackColor="#cc0099" runat="server" Text="Submit" OnClick="btnSubmit_Click"  /></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Label runat="server" ID="lblerror"></asp:Label></td>
            </tr>
            
        </table>

</div>
</asp:Content>
