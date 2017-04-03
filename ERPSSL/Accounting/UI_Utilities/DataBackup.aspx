<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Site.Master" AutoEventWireup="true" CodeBehind="DataBackup.aspx.cs" Inherits="ERPSSL.Accounting.UI_Utilities.DataBackup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <div class="span12">
        <br />
        <div class="col-xs-12 col-sm-6 widget-container-col">
            <div class="widget-box widget-color-blue">
                <div class="widget-header">
                    <h5 class="widget-title bigger lighter">
                        <i class="ace-icon fa fa-table"></i>Data Backup
                    </h5>
                    <div class="widget-toolbar widget-toolbar-light no-border">
                    </div>
                </div>
                <div class="widget-body">
                    <div class="widget-main no-padding">
                        <br />
                        <asp:Panel ID="messagePanel" runat="server" Style="padding-bottom: 10px" class="messagePanel"
                            Visible="false">
                            <div id="lblMesssge" runat="server" class="alert alert-success">
                                <asp:Label ID="lblMessage" runat="server" Text="message"></asp:Label>
                            </div>
                        </asp:Panel>
                        <div class="row-fluid">

                        </div>
                    </div>
                    <div class="clearfix">
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>