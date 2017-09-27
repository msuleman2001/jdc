<%@ Page Title="" Language="C#" MasterPageFile="~/Client.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="AddAccount.aspx.cs" Inherits="Laundry.AddAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script type="text/javascript">
        $(function () {
            $("[id$=txtexpdate]").datepicker({
               
                  
            });
        });
    </script>
    <form class="form-group">
    <div class="container">
        <table class="table-responsive">
            <tr>
                <td>Bank Name</td>
                <td><asp:TextBox ID="txtBankName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Name On Card</td>
                <td><asp:TextBox ID="txtNameoncard" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Credit Card No:</td>
                <td><asp:TextBox ID="txtCardNO" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Expiry Date:</td>
                <td> <asp:TextBox ID="txtexpdate" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>CVV</td>
                <td><asp:TextBox ID="txtCVV" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>IsDefault</td>
                <td><asp:CheckBox ID="chkDefault" runat="server" /></td>
            </tr>
            <tr>
                <td>Account Remarks</td>
                <td><asp:TextBox ID="TxtRemarks"  runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>IsEnabled</td>
                <td><asp:CheckBox ID="chkEnabled" runat="server" /></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnSubmit" CssClass="art-button" runat="server" Text="Submit" OnClick="btnSubmit_Click" /></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Label runat="server" ID="lblerror"></asp:Label></td>
            </tr>
            
        </table>

</div>
        </form>
</asp:Content>
