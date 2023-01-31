<%@ Page Title="" Language="C#" MasterPageFile="~/Portal.Master" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="SaifLogic.Test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    
    hello
    <asp:TextBox ID="txtinput" runat="server">
    </asp:TextBox>

    <asp:Label ID="lblOutput" runat="server"></asp:Label>
    <asp:Button runat="server" ID="cmdEncrypt" OnClick="cmdEncrypt_Click" />
</asp:Content>
