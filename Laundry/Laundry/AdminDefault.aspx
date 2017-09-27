<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" EnableEventValidation="false"  CodeBehind="AdminDefault.aspx.cs" Inherits="Laundry.AdminDefault" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div style=" margin-left: 20%">
            <h1>Profile</h1>
    <table class="table-responsive" style="border-collapse:separate; border-spacing:0 5px;">
            <tr style=" ">
                <td>Admin Name</td>
                <td style="width: 166px">&nbsp;</td>
                <td  ><asp:Label ID="lblname"  runat="server"></asp:Label></td>
            </tr>
            <tr style=" ">
                <td>Email</td>
                <td style="width: 166px"></td>
                <td ><asp:Label ID="lblEmail"    runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>PhoneNo:</td>
                <td style="width: 166px"></td>
                <td> <asp:Label ID="lblPhoneNO"   runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>Addres</td>
                <td style="width: 166px"></td>
                <td > <asp:Label ID="lblAdress"   runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>Image</td>
                <td style="width: 166px">&nbsp;</td>
                <td ><asp:Image ID="imgAdmin" runat="server"  Width="100px" Height="100px" /></td>
            </tr>

            <tr>
                <td>Remarks</td>
                <td style="width: 166px"></td>
                <td><asp:Label ID="lblRemarks"   runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>IsEnabled</td>
                <td style="width: 166px" ></td>
                <td><asp:Label ID="lblEnabled"  runat="server" /></td>
            </tr> 
        <tr>
                <td>Edit</td>
                <td style="width: 166px" ></td>
                <td><asp:Button ID="btnEdit"  class="art-button" Text="Edit" runat="server" OnClick="btnEdit_Click" /></td>
            </tr>          
        </table>
            </div>
        </div>
    <div>
        <h1>Preferances</h1>
     <asp:GridView ID="gdvPreferances" runat="server" AutoGenerateColumns="False" BorderStyle="Ridge" Width="100%" CssClass="table .table-hover " AllowPaging="true" BorderColor="#ffffff"
                HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" RowStyle-BackColor="#A1DCF2" AlternatingRowStyle-BackColor="White"
                Style="-webkit-border-radius: 16px; align-self: center; -moz-border-radius: 16px; border-radius: 16px; overflow: hidden; font-family: Arial; font-size: 10pt; text-align: center; border-style: none;" OnRowCommand="gdvPreferances_RowCommand">
                <HeaderStyle Font-Bold="true" ForeColor="#ffffff" BackColor="#0066ff" />

                <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>

                <Columns>

                
                    <asp:BoundField HeaderText="Preferance Name" DataField="PreferanceName" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Remarks" DataField="Remarks" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Date Created" DataField="DateCreated" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="IsEnabled" DataField="IsEnabled" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>

                    <asp:TemplateField HeaderText="Actions" ItemStyle-CssClass="column" ItemStyle-BorderWidth="1px">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/images/edit.png" CommandArgument='<%# Eval("PreferanceID") %>' CommandName="EditPreferance" />
                            <asp:ImageButton ID="btnDeletCustomer" runat="server" ImageUrl="~/images/Delete.png" CommandArgument='<%# Eval("PreferanceID") %>' CommandName="DeletePreferance" OnClientClick="return confirm('Are you sure to delet this item');" />
                        </ItemTemplate>

                        <ItemStyle BorderWidth="1px" CssClass="column"></ItemStyle>
                    </asp:TemplateField>

                </Columns>

                <RowStyle BackColor="#A1DCF2"></RowStyle>
            </asp:GridView>
            <asp:Button ID="btnInsert" runat="server" CssClass="art-button" Text="Add Preferance" OnClick="btnInsert_Click"  />
        </div>
        <div>
        <h1>Preferance Values</h1>
     <asp:GridView ID="gdvValues" runat="server" AutoGenerateColumns="False" BorderStyle="Ridge" Width="100%" CssClass="table .table-hover " AllowPaging="true" BorderColor="#ffffff"
                HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" RowStyle-BackColor="#A1DCF2" AlternatingRowStyle-BackColor="White"
                Style="-webkit-border-radius: 16px; align-self: center; -moz-border-radius: 16px; border-radius: 16px; overflow: hidden; font-family: Arial; font-size: 10pt; text-align: center; border-style: none;" OnRowDataBound="gdvValues_RowDataBound" OnRowCommand="gdvValues_RowCommand">
                <HeaderStyle Font-Bold="true" ForeColor="#ffffff" BackColor="#0066ff" />

                <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>

                <Columns>

                
                    <asp:BoundField HeaderText="Value Name" DataField="ValueName" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Preferance Name">
                        <AlternatingItemTemplate>
                            <asp:Label ID="lblPresefarnceName" runat="server"></asp:Label>
                            <asp:Label ID="lblPreferanceID" runat="server" Text='<%# Eval("PreferanceID") %>' Visible="False"></asp:Label>
                        </AlternatingItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblPresefarnceName" runat="server"></asp:Label>
                            <asp:Label ID="lblPreferanceID" runat="server" Text='<%# Eval("PreferanceID") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Remarks" DataField="Remarks" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Date Created" DataField="DateCreated" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="IsEnabled" DataField="IsEnabled" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>

                    <asp:TemplateField HeaderText="Actions" ItemStyle-CssClass="column" ItemStyle-BorderWidth="1px">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/images/edit.png" CommandArgument='<%# Eval("ValueID") %>' CommandName="EditPreferanceValue" />
                            <asp:ImageButton ID="btnDeletCustomer" runat="server" ImageUrl="~/images/Delete.png" CommandArgument='<%# Eval("ValueID") %>' CommandName="DeletePreferanceValue" OnClientClick="return confirm('Are you sure to delet this item');" />
                        </ItemTemplate>

                        <ItemStyle BorderWidth="1px" CssClass="column"></ItemStyle>
                    </asp:TemplateField>

                </Columns>

                <RowStyle BackColor="#A1DCF2"></RowStyle>
            </asp:GridView>
            <asp:Button ID="btnValue" runat="server" CssClass="art-button" Text="Add Preferance Values" OnClick="btnValue_Click" />
        </div>

    <div>
        <h1>Agents</h1>
     <asp:GridView ID="gdvAgents" runat="server" AutoGenerateColumns="False" BorderStyle="Ridge" Width="100%" CssClass="table .table-hover " AllowPaging="true" BorderColor="#ffffff"
                HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" RowStyle-BackColor="#A1DCF2" AlternatingRowStyle-BackColor="White"
                Style="-webkit-border-radius: 16px; align-self: center; -moz-border-radius: 16px; border-radius: 16px; overflow: hidden; font-family: Arial; font-size: 10pt; text-align: center; border-style: none;" OnRowDataBound="gdvAgents_RowDataBound" OnRowCommand="gdvAgents_RowCommand">
                <HeaderStyle Font-Bold="true" ForeColor="#ffffff" BackColor="#0066ff" />

                <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>

                <Columns>

                
                    <asp:BoundField HeaderText="Agent Name" DataField="AgentName" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                 
                    <asp:BoundField HeaderText="Agent Email" DataField="AgentEmail" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Phone Number" DataField="AgentPhoneNO" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                     <asp:BoundField HeaderText="AgentAddress" DataField="AgentAddress" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Remarks" DataField="Remarks" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField HeaderText="Date Created" DataField="DateCreated" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="IsEnabled" DataField="IsEnabled" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Admin Name">
                        <AlternatingItemTemplate>
                            <asp:Label ID="lblAdminName" runat="server"></asp:Label>
                            <asp:Label ID="lblAdminID" runat="server" Text='<%# Eval("AdminID") %>' Visible="False"></asp:Label>
                        </AlternatingItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblAdminName" runat="server"></asp:Label>
                            <asp:Label ID="lblAdminID" runat="server" Text='<%# Eval("AdminID") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Agent Image">
                        <ItemTemplate>
                            <asp:Image ID="imgAgentImage" runat="server" Width="50px" Height="50px" ImageUrl='<%# Eval("AgentImage") %>' ></asp:Image>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Actions" ItemStyle-CssClass="column" ItemStyle-BorderWidth="1px">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/images/edit.png" CommandArgument='<%# Eval("AgentID") %>' CommandName="EditAgent" />
                            <asp:ImageButton ID="btnDeletCustomer" runat="server" ImageUrl="~/images/Delete.png" CommandArgument='<%# Eval("AgentID") %>' CommandName="DeleteAgent" OnClientClick="return confirm('Are you sure to delet this item');" />
                        </ItemTemplate>

                        <ItemStyle BorderWidth="1px" CssClass="column"></ItemStyle>
                    </asp:TemplateField>

                </Columns>

                <RowStyle BackColor="#A1DCF2"></RowStyle>
            </asp:GridView>
            <asp:Button ID="btnAgent" runat="server" CssClass="art-button" Text="Add Agent" OnClick="btnAgent_Click" />
        </div>

        <div>
        <h1>Driver</h1>
            <div style="margin:0%,-10%,0%,0%">
     <asp:GridView ID="gdvDriver" runat="server" AutoGenerateColumns="False" BorderStyle="Ridge" Width="100%" CssClass="table" AllowPaging="true" BorderColor="#ffffff"
                HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" RowStyle-BackColor="#A1DCF2" AlternatingRowStyle-BackColor="White"
                Style="-webkit-border-radius: 16px; align-self: center; -moz-border-radius: 16px; border-radius: 16px; overflow: hidden; font-family: Arial; font-size: 10pt; text-align: center; border-style: none;" OnRowDataBound="gdvDriver_RowDataBound" OnRowCommand="gdvDriver_RowCommand"  >
                <HeaderStyle Font-Bold="true" ForeColor="#ffffff" BackColor="#0066ff" />

                <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>

                <Columns>
                    <asp:TemplateField HeaderText="Agent Name">
                        <AlternatingItemTemplate>
                            <asp:Label ID="lblAgentName" runat="server"></asp:Label>
                            <asp:Label ID="lblAgentID" runat="server" Text='<%# Eval("AgentID") %>' Visible="False"></asp:Label>
                        </AlternatingItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblAgentName" runat="server"></asp:Label>
                            <asp:Label ID="lblAgentID" runat="server" Text='<%# Eval("AgentID") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                
                    <asp:BoundField HeaderText="Driver Name" DataField="DriverName" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                 
                    <asp:BoundField HeaderText="Driver Email" DataField="DriverEmail" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Phone Number" DataField="DriverPhoneNO" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="licence NO" DataField="DriverlicenceNO" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Licence Issue Date" DataField="LicenceIssueDate" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Licence Expiry Date" DataField="LicenceExpDate" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Driver Address" DataField="DriverAddress" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>

                     
                    <asp:BoundField HeaderText="Remarks" DataField="Remarks" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField HeaderText="Date Created" DataField="DateCreated" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="IsEnabled" DataField="IsEnable" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Admin Name">
                        <AlternatingItemTemplate>
                            <asp:Label ID="lblAdminName" runat="server"></asp:Label>
                            <asp:Label ID="lblAdminID" runat="server" Text='<%# Eval("AdminID") %>' Visible="False"></asp:Label>
                        </AlternatingItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblAdminName" runat="server"></asp:Label>
                            <asp:Label ID="lblAdminID" runat="server" Text='<%# Eval("AdminID") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Agent Image">
                        <ItemTemplate>
                            <asp:Image ID="imgAgentImage" runat="server" Width="50px" Height="50px" ImageUrl='<%# Eval("DriverImage") %>' ></asp:Image>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Actions" ItemStyle-CssClass="column" ItemStyle-BorderWidth="1px">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/images/edit.png" CommandArgument='<%# Eval("DriverID") %>' CommandName="EditDriver" />
                            <asp:ImageButton ID="btnDeletCustomer" runat="server" ImageUrl="~/images/Delete.png" CommandArgument='<%# Eval("DriverID") %>' CommandName="DeleteDriver" OnClientClick="return confirm('Are you sure to delet this item');" />
                        </ItemTemplate>

                        <ItemStyle BorderWidth="1px" CssClass="column"></ItemStyle>
                    </asp:TemplateField>

                </Columns>

                <RowStyle BackColor="#A1DCF2"></RowStyle>
            </asp:GridView>
                </div>
            <asp:Button ID="BtnDriverAdd" runat="server" CssClass="art-button" Text="Add Driver" OnClick="BtnDriverAdd_Click" />
        </div>

    <div>
        <h1>Vehicals</h1>
            <div >
     <asp:GridView ID="gdvVehicals" runat="server" AutoGenerateColumns="False" BorderStyle="Ridge" Width="100%" CssClass="table .table-hover " AllowPaging="true" BorderColor="#ffffff"
                HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" RowStyle-BackColor="#A1DCF2" AlternatingRowStyle-BackColor="White"
                Style="-webkit-border-radius: 16px; align-self: center; -moz-border-radius: 16px; border-radius: 16px; overflow: hidden; font-family: Arial; font-size: 10pt; text-align: center; border-style: none;" OnRowDataBound="gdvVehicals_RowDataBound" OnRowCommand="gdvVehicals_RowCommand"  >
                <HeaderStyle Font-Bold="true" ForeColor="#ffffff" BackColor="#0066ff" />

                <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>

                <Columns>
                    <asp:BoundField HeaderText="Vehicle Make" DataField="VehicleMake" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Color" DataField="VehicleColor" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="RegNO" DataField="VehicleRegNO" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>

                    <asp:TemplateField HeaderText="Agent Name">
                        <AlternatingItemTemplate>
                            <asp:Label ID="lblAgentName" runat="server"></asp:Label>
                            <asp:Label ID="lblAgentID" runat="server" Text='<%# Eval("AgentID") %>' Visible="False"></asp:Label>
                        </AlternatingItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblAgentName" runat="server"></asp:Label>
                            <asp:Label ID="lblAgentID" runat="server" Text='<%# Eval("AgentID") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Admin Name">
                        <AlternatingItemTemplate>
                            <asp:Label ID="lblAdminName" runat="server"></asp:Label>
                            <asp:Label ID="lblAdminID" runat="server" Text='<%# Eval("AdminID") %>' Visible="False"></asp:Label>
                        </AlternatingItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblAdminName" runat="server"></asp:Label>
                            <asp:Label ID="lblAdminID" runat="server" Text='<%# Eval("AdminID") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Driver Name">
                        <AlternatingItemTemplate>
                            <asp:Label ID="lblDriverName" runat="server"></asp:Label>
                            <asp:Label ID="lblDriverID" runat="server" Text='<%# Eval("DriverID") %>' Visible="False"></asp:Label>
                        </AlternatingItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblDriverName" runat="server"></asp:Label>
                            <asp:Label ID="lblDriverID" runat="server" Text='<%# Eval("DriverID") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                
                    
                    <asp:BoundField HeaderText="Remarks" DataField="Remarks" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField HeaderText="Date Created" DataField="DateCreated" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="IsEnabled" DataField="IsEnabled" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                    
                    <asp:TemplateField HeaderText="Vehicle Image">
                        <ItemTemplate>
                            <asp:Image ID="imgAgentImage" runat="server" Width="50px" Height="50px" ImageUrl='<%# Eval("VehicalImage") %>' ></asp:Image>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Actions" ItemStyle-CssClass="column" ItemStyle-BorderWidth="1px">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/images/edit.png" CommandArgument='<%# Eval("VehicleID") %>' CommandName="EditVehicle" />
                            <asp:ImageButton ID="btnDeletCustomer" runat="server" ImageUrl="~/images/Delete.png" CommandArgument='<%# Eval("VehicleID") %>' CommandName="DeleteVehicle" OnClientClick="return confirm('Are you sure to delet this item');" />
                        </ItemTemplate>

                        <ItemStyle BorderWidth="1px" CssClass="column"></ItemStyle>
                    </asp:TemplateField>

                </Columns>

                <RowStyle BackColor="#A1DCF2"></RowStyle>
            </asp:GridView>
                </div>
            <asp:Button ID="btnVehicle" runat="server" CssClass="art-button" Text="Add Vehicle" OnClick="btnVehicle_Click"  />
        </div>

     <div>
        <h1>Item Category</h1>
            <div>
     <asp:GridView ID="GridItemCategory" runat="server" AutoGenerateColumns="False" BorderStyle="Ridge" Width="100%" CssClass="table .table-hover " AllowPaging="true" BorderColor="#ffffff"
                HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" RowStyle-BackColor="#A1DCF2" AlternatingRowStyle-BackColor="White"
                Style="-webkit-border-radius: 16px; align-self: center; -moz-border-radius: 16px; border-radius: 16px; overflow: hidden; font-family: Arial; font-size: 10pt; text-align: center; border-style: none;" OnRowCommand="GridItemCategory_RowCommand" OnRowDataBound="GridItemCategory_RowDataBound"  >
                <HeaderStyle Font-Bold="true" ForeColor="#ffffff" BackColor="#0066ff" />

                <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>

                <Columns>
                
                    <asp:BoundField HeaderText="Category Name" DataField="CategoryName" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                 
                    <asp:TemplateField HeaderText="Master Category Name">
                        <AlternatingItemTemplate>
                            <asp:Label ID="lblCategoryName" runat="server"></asp:Label>
                            <asp:Label ID="lblParentCategoryID" runat="server" Text='<%# Eval("ParentCategoryID") %>' Visible="False"></asp:Label>
                        </AlternatingItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblCategoryName" runat="server"></asp:Label>
                            <asp:Label ID="lblParentCategoryID" runat="server" Text='<%# Eval("ParentCategoryID") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Admin Name">
                        <AlternatingItemTemplate>
                            <asp:Label ID="lblAdminName" runat="server"></asp:Label>
                            <asp:Label ID="lblAdminID" runat="server" Text='<%# Eval("AdminID") %>' Visible="False"></asp:Label>
                        </AlternatingItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblAdminName" runat="server"></asp:Label>
                            <asp:Label ID="lblAdminID" runat="server" Text='<%# Eval("AdminID") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                     
                    <asp:BoundField HeaderText="Remarks" DataField="Remarks" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField HeaderText="Date Created" DataField="DateCreated" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="IsEnabled" DataField="IsEnabled" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                   
                    <asp:TemplateField HeaderText="Category Image">
                        <ItemTemplate>
                            <asp:Image ID="imgCategoryImage" runat="server" Width="50px" Height="50px" ImageUrl='<%# Eval("CategoryImage") %>' ></asp:Image>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Actions" ItemStyle-CssClass="column" ItemStyle-BorderWidth="1px">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/images/edit.png" CommandArgument='<%# Eval("CategoryID") %>' CommandName="EditCategory" />
                            <asp:ImageButton ID="btnDeletCustomer" runat="server" ImageUrl="~/images/Delete.png" CommandArgument='<%# Eval("CategoryID") %>' CommandName="DeleteCategory" OnClientClick="return confirm('Are you sure to delet this item');" />
                        </ItemTemplate>

                        <ItemStyle BorderWidth="1px" CssClass="column"></ItemStyle>
                    </asp:TemplateField>

                </Columns>

                <RowStyle BackColor="#A1DCF2"></RowStyle>
            </asp:GridView>
                </div>
            <asp:Button ID="btnCategory" runat="server" CssClass="art-button" Text="Add Category" OnClick="btnCategory_Click" />
        </div>

     <div>
        <h1>Items</h1>
            <div>
     <asp:GridView ID="gdvItems" runat="server" AutoGenerateColumns="False" BorderStyle="Ridge" Width="100%" CssClass="table .table-hover " AllowPaging="true" BorderColor="#ffffff"
                HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" RowStyle-BackColor="#A1DCF2" AlternatingRowStyle-BackColor="White"
                Style="-webkit-border-radius: 16px; align-self: center; -moz-border-radius: 16px; border-radius: 16px; overflow: hidden; font-family: Arial; font-size: 10pt; text-align: center; border-style: none;" OnRowCommand="gdvItems_RowCommand" OnRowDataBound="gdvItems_RowDataBound"  >
                <HeaderStyle Font-Bold="true" ForeColor="#ffffff" BackColor="#0066ff" />

                <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>

                <Columns>
                
                    <asp:BoundField HeaderText="Item Name" DataField="ItemName" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                 
                    <asp:TemplateField HeaderText="Category Name">
                        <AlternatingItemTemplate>
                            <asp:Label ID="lblCategoryName" runat="server"></asp:Label>
                            <asp:Label ID="lblCategoryID" runat="server" Text='<%# Eval("CategoryID") %>' Visible="False"></asp:Label>
                        </AlternatingItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblCategoryName" runat="server"></asp:Label>
                            <asp:Label ID="lblCategoryID" runat="server" Text='<%# Eval("CategoryID") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Admin Name">
                        <AlternatingItemTemplate>
                            <asp:Label ID="lblAdminName" runat="server"></asp:Label>
                            <asp:Label ID="lblAdminID" runat="server" Text='<%# Eval("AdminID") %>' Visible="False"></asp:Label>
                        </AlternatingItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblAdminName" runat="server"></asp:Label>
                            <asp:Label ID="lblAdminID" runat="server" Text='<%# Eval("AdminID") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="UnitPrice" DataField="UnitPrice" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                     
                    <asp:BoundField HeaderText="Remarks" DataField="Remarks" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField HeaderText="Date Created" DataField="DateCreated" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="IsEnabled" DataField="IsEnabled" ItemStyle-BorderWidth="1px">
                        <ItemStyle BorderWidth="1px"></ItemStyle>
                    </asp:BoundField>
                   
                    <asp:TemplateField HeaderText="Item Image">
                        <ItemTemplate>
                            <asp:Image ID="img" runat="server" Width="50px" Height="50px" ImageUrl='<%# Eval("ItemImage") %>' ></asp:Image>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Actions" ItemStyle-CssClass="column" ItemStyle-BorderWidth="1px">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/images/edit.png" CommandArgument='<%# Eval("ItemID") %>' CommandName="EditItem" />
                            <asp:ImageButton ID="btnDelet" runat="server" ImageUrl="~/images/Delete.png" CommandArgument='<%# Eval("ItemID") %>' CommandName="DeleteItem" OnClientClick="return confirm('Are you sure to delet this item');" />
                        </ItemTemplate>

                        <ItemStyle BorderWidth="1px" CssClass="column"></ItemStyle>
                    </asp:TemplateField>

                </Columns>

                <RowStyle BackColor="#A1DCF2"></RowStyle>
            </asp:GridView>
                </div>
            <asp:Button ID="btnItem" runat="server" CssClass="art-button" Text="Add Category" OnClick="btnItem_Click"  />
        </div>
</asp:Content>
