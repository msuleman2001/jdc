<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Assignment.aspx.cs" Inherits="Laundry.Assignment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
        <table class="table-responsive">
            <tr>
                <td>Agent Name</td>
                <td><asp:DropDownList ID="ddlAgent" runat="server"></asp:DropDownList></td>
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
