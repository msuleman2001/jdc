<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PayPal.aspx.cs" Inherits="Laundry.PayPal" %>

<html lang=en>
<head>
  <meta charset=utf-8>
  <title>Testing a PayPal Payments Standard Button</title>
</head>
<body>
<h2>Buy Strings!</h2>
<table>
<tr>
  <td>Bass Guitar Strings</td>
  <td>
<form action="https://www.paypal.com/cgi-bin/webscr" method="post">

    <input type="hidden" name="cmd" value="_xclick" />
    <input type="hidden" name="business" value="ch.amjadraza@gmail.com" />

    <input type="hidden" name="item_name" value="My painting" />
    <input type="hidden" name="amount" value="50.00" /> 
    <input type="submit" value="Buy!" />

</form>
 
  </td>
</tr>
</table>
</body>
</html>