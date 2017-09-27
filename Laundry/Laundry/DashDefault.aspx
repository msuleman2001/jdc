<%@ Page Title="" Language="C#" MasterPageFile="~/AdminDashBoard.Master" AutoEventWireup="true" CodeBehind="DashDefault.aspx.cs" Inherits="Laundry.DashDefault" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-3 col-md-6 col-sm-6">
                <div class="card card-stats">
                    <div class="card-header" data-background-color="orange">
                        <asp:Image runat="server" ImageUrl="~/images/clients-icon.png" Width="50px" Height="50px" />
                    </div>
                    <div class="card-content">
                        <p class="category">Clients</p>
                        
                        <h3 class="title">
                          
                            <asp:Label runat="server" ID="lblClients" ></asp:Label>
                        </h3>
                    </div>
                    <div class="card-footer">
                        <div class="stats">
                            <i class="material-icons text-center"></i>
                            <a href="Clients.aspx">View Clients</a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-3 col-md-6 col-sm-6">
                <div class="card card-stats">
                    <div class="card-header" data-background-color="Blue">
                        <asp:Image runat="server" ImageUrl="~/images/agent.png" Width="50px" Height="50px" />
                    </div>
                    <div class="card-content">
                        <p class="category">Agents</p>
                        <h3 class="title"><asp:Label runat="server" ID="lblAgents"></asp:Label></h3>
                    </div>
                    <div class="card-footer">
                        <div class="stats">
                            <i class="material-icons"></i>
                            <a href="Agents.aspx">View Agents</a>
                                   
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-3 col-md-6 col-sm-6">
                <div class="card card-stats">
                    <div class="card-header" data-background-color="blue">
                        <asp:Image runat="server" ImageUrl="~/images/Orders.png" Width="50px" Height="50px" />
                    </div>
                    <div class="card-content">
                        <p class="category">Orders</p>
                        <h3 class="title"><asp:Label runat="server" ID="lblOrders"></asp:Label></h3>
                    </div>
                    <div class="card-footer">
                        <div class="stats">
                            <i class="material-icons"></i>
                            <a href="AllOrders.aspx">View Orders</a>
                                   
                        </div>
                    </div>
                </div>
            </div>
             <div class="col-lg-3 col-md-6 col-sm-6">
                <div class="card card-stats">
                    <div class="card-header" data-background-color="blue">
                        <asp:Image runat="server" ImageUrl="~/images/moneybagpound256.png" Width="50px" Height="50px" />
                    </div>
                    <div class="card-content">
                        <p class="category">Total Earning</p>
                        <h3 class="title"><asp:Label runat="server" ID="lblearning" ></asp:Label></h3>
                    </div>
                    <div class="card-footer">
                        <div class="stats">
                            <i class="material-icons"></i>
                            <a href="#pablo"></a>
                                   
                        </div>
                    </div>
                </div>
            </div>
           
        </div>
       
</asp:Content>
