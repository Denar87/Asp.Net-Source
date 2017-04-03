<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Site.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="ERPSSL.Accounting.UI_Utilities.UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <div class="span12">
        <br />
        <div class="col-xs-12 col-sm-6 widget-container-col">
            <div class="widget-box">
                <div class="widget-header">
                    <h5 class="widget-title bigger lighter">
                        <i class="ace-icon fa fa-table"></i>My Profile
                    </h5>
                    <div class="buttonPanel">

                        <asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/left arrow9.png"
                            Width="32px" ToolTip="Go Back" />
                        <asp:ImageButton ID="btnPrint" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/print49.png"
                            Width="32px" ToolTip="Print Details" />
                    </div>
                </div>
                <div class="widget-body">
                    <div class="widget-main no-padding">
                        <br />
                        <asp:Panel ID="messagePanel" runat="server" Style="padding-bottom: 10px" class="messagePanel"
                            Visible="false">
                            <div id="lblMesssge" runat="server" class="alert alert-success">
                            </div>
                        </asp:Panel>
                        <div class="row-fluid">
                            <ul class="Userinfo">

                                <li>
                                    <h3>
                                        <asp:Label ID="lblUsername" runat="server"></asp:Label></h3>
                                </li>
                                <li>
                                    <asp:Label ID="LblUserID" runat="server"></asp:Label></li>
                                <li>
                                    <asp:Label ID="LblUserEmail" runat="server"></asp:Label></li>
                                <li>
                                    <asp:Label ID="lblLastLoginTime" runat="server"></asp:Label></li>
                                <li>
                                    <asp:Label ID="lblIP_Address" runat="server"></asp:Label></li>
                                <li>
                                    <asp:Label ID="lblStatus" runat="server"></asp:Label></li>
                                <li><a href="UserSecurity.aspx">Security Update</a></li>
                            </ul>
                        </div>
                    </div>
                    <div class="clearfix">
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
