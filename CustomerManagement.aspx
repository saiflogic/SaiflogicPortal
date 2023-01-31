<%@ Page Title="" Language="C#" MasterPageFile="~/Portal.Master" AutoEventWireup="true" CodeBehind="CustomerManagement.aspx.cs" Inherits="SaifLogic.CustomerManagement" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <center><asp:Label ID="lblException" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></center>
    <br />

    <asp:Panel ID="pnlInspectorsGrid" runat="server" ScrollBars="Auto">


             <telerik:RadGrid ID="radGridCustomer" runat="server" AllowFilteringByColumn="True" AutoGenerateColumns="False" Skin="Bootstrap" AllowPaging="True" PageSize="25" OnItemDataBound="radGridCustomer_ItemDataBound" OnNeedDataSource="radGridCustomer_NeedDataSource">
<GroupingSettings CollapseAllTooltip="Collapse all groups" CaseSensitive="False"></GroupingSettings>
        <MasterTableView ShowHeadersWhenNoRecords="False" ShowHeader="True" TableLayout="Auto" Width="100%" Font-Size="Small" HeaderStyle-Wrap="False" ItemStyle-Wrap="False"> 
            <PagerStyle Mode="NextPrevAndNumeric" PageSizeLabelText="Page Size: " PageSizes="5,10,25,50,100,250" />
    <Columns>
      <telerik:GridTemplateColumn AllowFiltering="false">
        <ItemTemplate>          
            <asp:LinkButton ID="lnkActivate" Text="Activate/Deactivate" runat="server" ForeColor="Blue" Font-Underline="True" Font-Bold="True" OnClientClick="return confirm('Are you sure you want to activate this User?');" OnClick="lnkActivate_Click"></asp:LinkButton>
     </ItemTemplate>           
       </telerik:GridTemplateColumn> 

<%--             <telerik:GridTemplateColumn HeaderText=" " AllowFiltering="false">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkEdit" Text="Edit" runat="server" Font-Bold="True" OnClick="lnkEdit_Click"></asp:LinkButton>
                                        </ItemTemplate>
              </telerik:GridTemplateColumn>--%>

<%--                 <telerik:GridTemplateColumn HeaderText="Payroll" AllowFiltering="false">                       
                         <ItemTemplate>   <asp:HyperLink ID="lnkPayroll" runat="server">Conduct Payroll</asp:HyperLink>
                             </ItemTemplate>
                </telerik:GridTemplateColumn> --%>

                <telerik:GridTemplateColumn HeaderText="User ID" AllowFiltering="false">                       
                         <ItemTemplate>   <asp:Label ID="lblID" runat="server" Text='<%# Bind("userid") %>'></asp:Label>
                             </ItemTemplate>
                </telerik:GridTemplateColumn> 

        <telerik:GridTemplateColumn HeaderText="Entity" DataField="rank" CurrentFilterFunction="StartsWith" AutoPostBackOnFilter="true">                       
                         <ItemTemplate>   <asp:Label ID="lblEntity" runat="server" Text='<%# Bind("entity") %>'></asp:Label>
                             </ItemTemplate>
                </telerik:GridTemplateColumn>  

                        <telerik:GridTemplateColumn HeaderText="First Name" DataField="userfirstname" CurrentFilterFunction="StartsWith" AutoPostBackOnFilter="true">                       
                         <ItemTemplate>   <asp:Label ID="lblFirstName" runat="server" Text='<%# Bind("userfirstname") %>'></asp:Label>
                             </ItemTemplate>
                </telerik:GridTemplateColumn> 

                        <telerik:GridTemplateColumn HeaderText="Last Name" DataField="userlastname" CurrentFilterFunction="StartsWith" AutoPostBackOnFilter="true">                       
                         <ItemTemplate>   <asp:Label ID="lblLastName" runat="server" Text='<%# Bind("userlastname") %>'></asp:Label>
                             </ItemTemplate>
                </telerik:GridTemplateColumn> 

                                

                                <telerik:GridTemplateColumn HeaderText="Email" DataField="useremail" CurrentFilterFunction="StartsWith" AutoPostBackOnFilter="true">                       
                         <ItemTemplate>   <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("useremail") %>'></asp:Label>
                             </ItemTemplate>
                </telerik:GridTemplateColumn>

                        <telerik:GridTemplateColumn HeaderText="Address" AllowFiltering="false">                       
                         <ItemTemplate>   <asp:Label ID="lblAddress" runat="server" Text='<%# Bind("address") %>'></asp:Label>
                             </ItemTemplate>
                </telerik:GridTemplateColumn> 

                        <telerik:GridTemplateColumn HeaderText="City" AllowFiltering="false">                       
                         <ItemTemplate>   <asp:Label ID="lblCity" runat="server" Text='<%# Bind("city") %>'></asp:Label>
                             </ItemTemplate>
                </telerik:GridTemplateColumn> 

                        <telerik:GridTemplateColumn HeaderText="State" AllowFiltering="false">                       
                         <ItemTemplate>   <asp:Label ID="lblState" runat="server" Text='<%# Bind("state") %>'></asp:Label>
                             </ItemTemplate>
                </telerik:GridTemplateColumn>           

        
                        <telerik:GridTemplateColumn HeaderText="Zip" AllowFiltering="false">                       
                         <ItemTemplate>   <asp:Label ID="lblZip" runat="server" Text='<%# Bind("zip") %>'></asp:Label>
                             </ItemTemplate>
                </telerik:GridTemplateColumn>        
           
                        <telerik:GridTemplateColumn HeaderText="Status" DataField="status" CurrentFilterFunction="StartsWith" AutoPostBackOnFilter="true">                       
                         <ItemTemplate>   <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("status") %>'></asp:Label>
                             </ItemTemplate>
                </telerik:GridTemplateColumn>    

                                <telerik:GridTemplateColumn HeaderText="Phone Number" AllowFiltering="false">                       
                         <ItemTemplate>   <asp:Label ID="lblPhone" runat="server" Text='<%# Bind("userphonenum") %>'></asp:Label>
                             </ItemTemplate>
                </telerik:GridTemplateColumn> 


            <telerik:GridTemplateColumn HeaderText="Last Login" AllowFiltering="false">            
                        <ItemTemplate><asp:Label ID="lblLastLogin" runat="server" Text='<%# Bind("LastLogon") %>'></asp:Label>
                            </ItemTemplate>
            </telerik:GridTemplateColumn>     

      <%--  <telerik:GridTemplateColumn HeaderText="QR Code" AllowFiltering="false">            
                        <ItemTemplate>
                             <asp:ImageButton runat="server" ID="imgQR" ToolTip="Inspector QR Code" ImageUrl="images/QR.png" Height="25px" Width="25px"/>
                            </ItemTemplate>
            </telerik:GridTemplateColumn> --%>    

              <telerik:GridTemplateColumn AllowFiltering="false">
        <ItemTemplate>          
            <asp:LinkButton ID="lnkEdit" Text="Edit" runat="server" ForeColor="Blue" Font-Underline="True" Font-Bold="True"  OnClick="lnkEdit_Click"></asp:LinkButton>
     </ItemTemplate>           
       </telerik:GridTemplateColumn> 

    </Columns>       
            <HeaderStyle Font-Bold="True" Font-Size="Medium" />
            </MasterTableView>

    </telerik:RadGrid>
    

        </asp:Panel>

                            <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
    </telerik:RadScriptManager>
</asp:Content>
