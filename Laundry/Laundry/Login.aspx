<%@ Page Title="" Language="C#" MasterPageFile="~/Client.Master" AutoEventWireup="true" enableEventValidation="false" CodeBehind="Login.aspx.cs" Inherits="Laundry.LoginRegister" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div id="loginbox" style="margin-top:50px;" class="mainbox col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">                    
            <div class="panel panel-info" >
                    <div class="panel-heading">
                        <div class="panel-title">Sign In</div>
                        <div style="float:right; font-size: 80%; position: relative; top:-10px"><a href="#">Forgot password?</a></div>
                    </div>     

                    <div style="padding-top:30px" class="panel-body" >

                        <div style="display:none" id="login-alert" class="alert alert-danger col-sm-12"></div>
                            
                        <form id="loginform" class="form-horizontal" role="form">
                                    
                            <div style="margin-bottom: 25px" class="input-group">
                                        <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                                        <asp:TextBox runat="server" id="txtLoginEmail" TextMode="Email" class="form-control"  value="" placeholder="Email"/>                                        
                                    </div>
                                
                            <div style="margin-bottom: 25px" class="input-group">
                                        <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                                        <asp:TextBox runat="server" id="txtloginPassword" TextMode="Password" class="form-control" placeholder="password"/>
                                    </div>
                                    

                                
                            <div class="input-group">
                                      <div class="checkbox">
                                        <label>
                                          <asp:CheckBox id="rememberme" runat="server"  Text="Remember me" /> 
                                        </label>
                                      </div>
                                    </div>


                                <div style="margin-top:10px" class="form-group">
                                    <!-- Button -->

                                    <div class="col-sm-12 controls">
                                      <asp:Button runat="server" id="btnlogin" Text="Login" class="btn btn-success" OnClick="btnlogin_Click"></asp:Button>
                                     &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                            Don't have an account! 
                                       <asp:Button runat="server" id="btnSignUp" Text="Signup" class="btn btn-success" OnClick="btnSignUp_Click" ></asp:Button>
                                     
                                        

                                    </div>
                                    <div class="col-sm-12 controls">
                                      <asp:Label runat="server" ID="lblError" Visible="false"></asp:Label>
                                     

                                    </div>
                                </div>


                                <div class="form-group">
                                    <div class="col-md-12 control">
                                        
                                    </div>
                                </div>    
                            </form>     



                        </div>                     
                    </div>  
        </div>
        
 
</asp:Content>
