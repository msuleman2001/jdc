<%@ Page Title="" Language="C#" MasterPageFile="~/Client.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Laundry.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="signup" style=" margin-top:50px" class="mainbox col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <div class="panel-title">Sign Up</div>
                            <div style="float:right; font-size: 85%; position: relative; top:-10px"></div>
                        </div>  
                        <div class="panel-body" >
                            <form id="signupform" class="form-horizontal" role="form">
                                
                                <div id="signupalert" style="display:none" class="alert alert-danger">
                                    <p>Error:</p>
                                    <span></span>
                                </div>
                                    
                                
                                  
                                <div class="form-group">
                                    <label for="email" class="col-md-3 control-label">Name</label>
                                    <div class="col-md-9">
                                        <asp:TextBox id="txtName" runat="server" class="form-control"  placeholder="Customer Name"/>
                                    </div>
                                </div>
                                    
                                <div class="form-group" style="margin-top:12%;">
                                    <label for="firstname" class="col-md-3 control-label">Address</label>
                                    <div class="col-md-9">
                                        <asp:TextBox runat="server" ID="txtAddress" TextMode="MultiLine" class="form-control"  placeholder="Enter your address"/>
                                    </div>
                                </div>
                                <div class="form-group" style="margin-top:30%;">
                                    <label for="lastname" class="col-md-3 control-label">Phone NO</label>
                                    <div class="col-md-9">
                                        <asp:TextBox runat="server" ID="txtphoneno" class="form-control" placeholder="Phone No"/>
                                    </div>
                                </div>
                                <div class="form-group" style="margin-top:42%;">
                                    <label for="password" class="col-md-3 control-label">Email</label>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="txtmail" runat="server"  class="form-control"  placeholder="Email"/>
                                    </div>
                                </div>
                                    
                                <div class="form-group" style="margin-top:55%;">
                                    <label for="icode" class="col-md-3 control-label">Password</label>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="form-control"  placeholder="Password"/>
                                    </div>
                                </div>

                                <div class="form-group" style="margin-top:68%;">
                                    <label for="icode" class="col-md-3 control-label">ReEnter Password</label>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="txtreenterpassword" runat="server" TextMode="Password" class="form-control"  placeholder="Re Enter Password"/>
                                        <asp:CheckBox id="chkIsEnabled" Visible="false" runat="server" Checked="true"  Text="IsEnabled" value="1"/> 
                                    </div>
                                </div>

                                <div class="form-group">
                                    <!-- Button -->                                        
                                    <div class="col-md-offset-3 col-md-9">
                                        <asp:button id="btnsignup" runat="server" Text="SignUp" type="button" class="btn btn-info" OnClick="btnsignup_Click"></asp:button>
                                 
                                    </div>
                                </div>
                                
                                
                                
                                
                                
                            </form>
                         </div>
                    </div>
</asp:Content>
