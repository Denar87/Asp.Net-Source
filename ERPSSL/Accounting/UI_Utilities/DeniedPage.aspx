<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Site.Master" AutoEventWireup="true" CodeBehind="DeniedPage.aspx.cs" Inherits="ERPSSL.Accounting.UI_Utilities.DeniedPage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <div class="span12">
        <br />
        <div class="col-xs-12 col-sm-6 widget-container-col">
            <div class="widget-box">
                <div class="widget-header">
                    <h5 class="widget-title bigger lighter">
                        <i class="ace-icon fa fa-table"></i>Access denied for User!
                    </h5>
                </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <%-------------Panel--------------%>
                        <div class="widget-body">
                            <div class="widget-main no-padding">
                                <asp:Panel ID="messagePanel" runat="server" Style="padding: 0px" class="messagePanel"
                                    Visible="false">
                                    <div id="lblMesssge" runat="server" class="alert alert-success">
                                        <asp:Label ID="lblMessage" runat="server" Text="message"></asp:Label>
                                    </div>
                                </asp:Panel>
                                <br />
                                <div class="row-fluid">
                                    <div class="span8">
                                        <ul class="Userinfo">
                                            <strong>If you get an error message like this:</strong>
                                            <p>

                                                <span style="color: red">Warning:</span> Page Access denied for user: 
                                                <asp:Label ID="lblUser" runat="server"></asp:Label>
                                                (Using password: YES) 
                                            </p>
                                            <h4 style="color: red">Please Contact with your administrator, to solve this Issue!</h4>
                                        </ul>
                                    </div>
                                </div>
                                <div class="clearfix">
                                </div>
                            </div>
                            <div class="clearfix">
                            </div>
                        </div>
                        <%-------------Panel--------------%>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        window.onload = function () {

            var x = document.getElementById('<%= lblMessage.ClientID %>');

            if (x.innerHTML == 'message') {
                document.getElementById("<%=lblMesssge.ClientID %>").style.display = "none";
            }
            else {
                var seconds = 5;
                setTimeout(function () {
                    document.getElementById("<%=lblMesssge.ClientID %>").style.display = "none";
                }, seconds * 1000);
            }
        };
    </script>
</asp:Content>

