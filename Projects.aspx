<%@ Page Title="" Language="C#" MasterPageFile="~/Portal.Master" AutoEventWireup="true" CodeBehind="Projects.aspx.cs" Inherits="SaifLogic.Projects" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <center><asp:Label ID="lblException" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></center>
    <br />

    <asp:Panel ID="pnlInspectorsGrid" runat="server" ScrollBars="Auto">


             <telerik:RadGrid ID="radGridProjects" runat="server" AllowFilteringByColumn="True" AutoGenerateColumns="False" Skin="Bootstrap" AllowPaging="True" PageSize="25" OnItemDataBound="radGridProjects_ItemDataBound" OnNeedDataSource="radGridProjects_NeedDataSource">
<GroupingSettings CollapseAllTooltip="Collapse all groups" CaseSensitive="False"></GroupingSettings>
        <MasterTableView ShowHeadersWhenNoRecords="False" ShowHeader="True" TableLayout="Auto" Width="100%" Font-Size="Small" HeaderStyle-Wrap="False" ItemStyle-Wrap="False"> 
            <PagerStyle Mode="NextPrevAndNumeric" PageSizeLabelText="Page Size: " PageSizes="5,10,25,50,100,250" />
    <Columns>
      <telerik:GridTemplateColumn AllowFiltering="false">
        <ItemTemplate>          
            <asp:LinkButton ID="lnkActivate" Text="Award KPT" runat="server" ForeColor="Blue" Font-Underline="True" Font-Bold="True" OnClick="lnkActivate_Click"></asp:LinkButton>
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

        <telerik:GridTemplateColumn HeaderText="Project ID" DataField="rowid" CurrentFilterFunction="EqualTo" AutoPostBackOnFilter="true">                       
                         <ItemTemplate>   <asp:Label ID="lblID" runat="server" Text='<%# Bind("rowid") %>'></asp:Label>
                             </ItemTemplate>
                </telerik:GridTemplateColumn> 



                <telerik:GridTemplateColumn HeaderText="Customer" AllowFiltering="false">                       
                         <ItemTemplate>   <asp:Label ID="lblEntity" runat="server" Text='<%# Bind("entity") %>'></asp:Label>
                             </ItemTemplate>
                </telerik:GridTemplateColumn> 

        <telerik:GridTemplateColumn HeaderText="Customer First Name" AllowFiltering="false">                       
                         <ItemTemplate>   <asp:Label ID="lblCustFirstName" runat="server" Text='<%# Bind("customerfirstname") %>'></asp:Label>
                             </ItemTemplate>
                </telerik:GridTemplateColumn>  

                        <telerik:GridTemplateColumn HeaderText="Customer Last Name" AllowFiltering="false">                       
                         <ItemTemplate>   <asp:Label ID="lblCustLastName" runat="server" Text='<%# Bind("customerlastname") %>'></asp:Label>
                             </ItemTemplate>
                </telerik:GridTemplateColumn> 

                        <telerik:GridTemplateColumn HeaderText="PM First Name" DataField="userlastname" CurrentFilterFunction="StartsWith" AutoPostBackOnFilter="true">                       
                         <ItemTemplate>   <asp:Label ID="lblPMFirstName" runat="server" Text='<%# Bind("pmfirstname") %>'></asp:Label>
                             </ItemTemplate>
                </telerik:GridTemplateColumn> 

                                

                                <telerik:GridTemplateColumn HeaderText="PM Last Name" DataField="useremail" CurrentFilterFunction="StartsWith" AutoPostBackOnFilter="true">                       
                         <ItemTemplate>   <asp:Label ID="lblPMLastName" runat="server" Text='<%# Bind("pmlastname") %>'></asp:Label>
                             </ItemTemplate>
                </telerik:GridTemplateColumn>

                        <telerik:GridTemplateColumn HeaderText="Short Description" AllowFiltering="false">                       
                         <ItemTemplate>   <asp:Label ID="lblShortDesc" runat="server" Text='<%# Bind("short_desc") %>'></asp:Label>
                             </ItemTemplate>
                </telerik:GridTemplateColumn> 

                        <telerik:GridTemplateColumn HeaderText="Long Description" AllowFiltering="false">                       
                         <ItemTemplate>   <asp:Label ID="lblLongDesc" runat="server" Text='<%# Bind("long_desc") %>'></asp:Label>
                             </ItemTemplate>
                </telerik:GridTemplateColumn> 

                        <telerik:GridTemplateColumn HeaderText="Status" AllowFiltering="false">                       
                         <ItemTemplate>   <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("status") %>'></asp:Label>
                             </ItemTemplate>
                </telerik:GridTemplateColumn>           


                        <telerik:GridTemplateColumn HeaderText="Start Date" DataField="status" CurrentFilterFunction="StartsWith" AutoPostBackOnFilter="true">                       
                         <ItemTemplate>   <asp:Label ID="lblStartDate" runat="server" Text='<%# Bind("start_date") %>'></asp:Label>
                             </ItemTemplate>
                </telerik:GridTemplateColumn>    

                                <telerik:GridTemplateColumn HeaderText="End Date" AllowFiltering="false">                       
                         <ItemTemplate>   <asp:Label ID="lblEndDate" runat="server" Text='<%# Bind("end_date") %>'></asp:Label>
                             </ItemTemplate>
                </telerik:GridTemplateColumn> 

                    <telerik:GridTemplateColumn HeaderText="Date Created" AllowFiltering="false">                       
                         <ItemTemplate>   <asp:Label ID="lblDateCreated" runat="server" Text='<%# Bind("date_created") %>'></asp:Label>
                             </ItemTemplate>
                </telerik:GridTemplateColumn>      


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

