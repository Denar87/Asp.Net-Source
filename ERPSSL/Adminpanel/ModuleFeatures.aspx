<%@ Page Title="" Language="C#" MasterPageFile="~/Adminpanel/Site.Master" AutoEventWireup="true"
    CodeBehind="ModuleFeatures.aspx.cs" Inherits="ERPSSL.Adminpanel.ModuleFeatures" %>

<%@ Register Src="~/Adminpanel/UserControls/ModuleSetup.ascx" TagPrefix="uc1" TagName="ModuleSetup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <uc1:ModuleSetup runat="server" ID="ModuleSetup" />


   
    
</asp:Content>
