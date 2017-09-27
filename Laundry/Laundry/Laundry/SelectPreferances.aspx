<%@ Page Title="" Language="C#" MasterPageFile="~/Client.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="SelectPreferances.aspx.cs" Inherits="Laundry.SelectPreferances" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="signup" style=" margin-top:50px" class="mainbox col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <div class="panel-title">Insert Preferances Value</div>
                            <div style="float:right; font-size: 85%; position: relative; top:-10px"></div>
                        </div>  
                        <div class="panel-body" >
                            <form id="signupform" class="form-horizontal" role="form">
                                
                                  
                                <div class="form-group">
                                    <label for="email" class="col-md-3 control-label">Select Preferance</label>
                                    <div class="col-md-9">
                                        <asp:DropDownList ID="drpPreferances" class="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpPreferances_SelectedIndexChanged">  
                                            </asp:DropDownList>  
                                    </div>
                                </div>
                                            <div class="form-group" style="margin-top:15%">
                                    <label for="email" class="col-md-3 control-label">Selecct Preferance Value</label>
                                    <div class="col-md-9">
                                        <asp:DropDownList ID="drpvalue" class="form-control" runat="server">  
                                            </asp:DropDownList>  
                                    </div>
                                </div>
                                    <div class="form-group" style="margin-top:35%" >
                                    <label for="password" class="col-md-3 control-label">Remarks</label>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="txtRemarks" runat="server"  class="form-control"  placeholder="Remarks"/>
                                    </div>
                                </div>
                                    
                                <div class="form-group" >
                                    <label for="icode" class="col-md-3 control-label">IsEnabled</label>
                                    <div class="col-md-9">
                                        <asp:CheckBox id="chkIsEnabled" runat="server"  Checked="true"  value="1"/> 
                                    </div>
                                </div>

                                <div class="form-group">
                                    <!-- Button -->                                        
                                    <div class="col-md-offset-3 col-md-9">
                                        <asp:button id="btnInsert" runat="server" Text="Submit" type="button" class="btn btn-info" OnClick="btnInsert_Click" ></asp:button>
                                        <asp:Label ID="lblerror" runat="server"></asp:Label>
                                    </div>
                                </div>
                                
                                
                                
                                
                                
                            </form>
                         </div>
                    </div>
    
</asp:Content>
