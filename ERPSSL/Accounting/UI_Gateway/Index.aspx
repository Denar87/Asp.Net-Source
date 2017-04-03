<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Site.Master" AutoEventWireup="true"
    CodeBehind="Index.aspx.cs" Inherits="ERPSSL.Accounting.UI_Gateway.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="span12  home_sec_main">
        <asp:Panel ID="messagePanel" runat="server" Style="padding: 10px" class="messagePanel"
            Visible="false">
            <asp:Label ID="lblMessage" runat="server" Text="message"></asp:Label>
        </asp:Panel>
        <div class="home_sec_top">
            <h4>
                <img src="../Resources/logo.png" style="position: absolute; right: 35px; width: 200px;" />
                <a href="">
                    <img src="../content/images/admin.png" alt="some text" width="24" height="24" style="margin-right: 3px; margin-bottom: 10px">
                    <asp:Label ID="lblUser" runat="server" ForeColor="Purple" />
                </a>
            </h4>
        </div>
        <div class="home_sec1">
            <h3>
                <asp:Label ID="lblCompany" runat="server" ForeColor="Black"></asp:Label></h3>
            <ul>
                <li>
                    <h4>
                        <asp:Label ID="lblFinancialYear" runat="server" ForeColor="Green"></asp:Label></h4>
                </li>
                <li>
                    <h4>
                        <asp:Label ID="lblBookYear" runat="server" ForeColor="Green"></asp:Label></h4>
                </li>
            </ul>
        </div>
        <asp:Literal ID="lt" runat="server"></asp:Literal>
        <div id="chart_div" style="background:#fff;border:1px solid #ccc;margin-top:7px;"></div>
    </div>
</asp:Content>
