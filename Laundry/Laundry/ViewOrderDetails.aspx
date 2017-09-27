<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="ViewOrderDetails.aspx.cs" Inherits="Laundry.ViewOrderDetails" %>

    <!-- Latest compiled and minified CSS -->
<title>Invoice</title>
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">

<!-- Optional theme -->
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css" integrity="sha384-rHyoN1iRsVXV4nD0JutlnGaslCJuC7uwjduW9SVrLvRYooPp2bWYgmgJQIXwl/Sp" crossorigin="anonymous">

<!-- Latest compiled and minified JavaScript -->
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
<body onload="payment();">
<form runat="server" style=" margin-left:20%;margin-top:40px;margin-right:20%">
        <asp:Panel id="pnlContents" runat = "server">
    <h1 style="position:center; margin-left:40%">Invoice</h1>
    <table class="table table-bordered" style="position:center; margin-left:0%;margin-right:0%; width:100%">
        <tr>
            <td>Order ID</td>
            <td><asp:label runat="server" id="lblOrderID"></asp:label></td>
            <td>Customer Name</td>
            <td><asp:label runat="server" id="lblName"></asp:label></td>
            
        </tr>
        <tr>
            <td>Order Date</td>
            <td><asp:label runat="server" id="lblOrderDate"></asp:label></td>
            <td>Customer Address</td>
            <td><asp:label runat="server" id="LblAddress"></asp:label></td>
        </tr>
        <tr>
            <td>Picked Date Time</td>
            <td><asp:label runat="server" id="LblPickedDateTime"/></td>
        </tr>
        <tr>
            <td>Drop Date Time</td>
            <td><asp:label runat="server" id="lblDropDateTime"/></td>
        </tr>
    </table>

     <asp:GridView ID="Gdvorder" runat="server" AutoGenerateColumns="False" BorderStyle="Ridge"   Width="100%"   CssClass="table .table-hover " AllowPaging="false" BorderColor="black"
           
                HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" RowStyle-BackColor="White" AlternatingRowStyle-BackColor="White" 
                Style=" - border-bottom-color:black; width:100%; align-self:center; 
                font-family: Arial; font-size: 10pt; text-align: center; border-style: none;" OnRowDataBound="Gdvorder_RowDataBound"  >
                <HeaderStyle Font-Bold="true" ForeColor="#ffffff" BackColor="#0066ff" />  
                      
                    <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>

                    <Columns>

                       <asp:TemplateField HeaderText="Item Name" ItemStyle-CssClass="column">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblItemName"></asp:Label>
                                <asp:Label runat="server" ID="lblItemID" Visible="false" Text='<%# Eval("ItemID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date Time" ItemStyle-CssClass="column">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="Label3" Text='<%# Eval("DateTimeCreated") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quantity" ItemStyle-CssClass="column">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblqty"  Text='<%# Eval("Quantity") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Item UnitPrice" ItemStyle-CssClass="column">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblPrice" Text='<%# Eval("UnitPrice") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total" ItemStyle-CssClass="column">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lbltotal" ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                    <RowStyle BackColor="White"></RowStyle>
                </asp:GridView>
                <div style="margin-left:80%">
                    <asp:Label runat="server" ID="Label2" text="Total Bill = "></asp:Label>
                    <asp:Label runat="server" name="amount" ID="Label1" ></asp:Label>
                    <br />
                <script type = "text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title></title>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }
    </script>

                    
                </div>
     </asp:Panel>

<asp:button id="BtnPrint" runat="server" OnClientClick = "return PrintPanel();" style="width:200px" class="form-control btn-info" text="Print" xmlns:asp="#unknown" />
</form>

    <form action="https://www.paypal.com/cgi-bin/webscr" method="post">

    <input type="hidden" name="cmd" value="_xclick" />
    <input type="hidden" name="business" value="ch.amjadraza@gmail.com" />

    <input type="hidden" name="item_name" value="JUST DRY CLEANS" />
    <input type="hidden" id="amount" name="amount"  /> 
    <input type="submit" onclick="return payment();" value="Buy!" />

</form>
      <script type="text/javascript">
    function payment() {
        
        var paymentvalue = document.getElementById("<% =Label1.ClientID %>");
        
        var paymentfield = document.getElementById("amount");
        var a = paymentvalue.innerHTML;
   
        paymentfield.value = a;

        return true;
    }
</script> 
</body>
</html>

