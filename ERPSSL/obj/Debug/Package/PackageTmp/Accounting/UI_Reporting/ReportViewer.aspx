<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Site.Master" AutoEventWireup="true"
    CodeBehind="ReportViewer.aspx.cs" Inherits="ERPSSL.Accounting.UI_Reporting.ReportViewer" %>


<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript">
        function CallPrint(strid) {
            var prtContent = document.getElementById(strid);
            var WinPrint =
           window.open('', '', 'letf=0,top=0,width=500,height=400,toolbar=0,scrollbars=0,sta­tus=0');
            WinPrint.document.write(prtContent.innerHTML);
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();
            prtContent.innerHTML = strOldOne;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="span12">
        <br />
        <div class="col-xs-12 col-sm-6 widget-container-col">
            <div class="widget-box">
                <div class="widget-header">
                    <h5 class="widget-title bigger lighter">
                        <i class="ace-icon fa fa-table"></i>
                        <asp:Label ID="lblTitle" runat="server"></asp:Label>
                    </h5>
                    <div class="buttonPanel">
                        <asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/left arrow9.png"
                            Width="32px" ToolTip="Go Back" OnClick="btnBack_Click" />
                        <asp:ImageButton ID="btnDownload" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/download177.png"
                            Width="32px" OnClick="btnDownload_Click" />
                        <asp:ImageButton ID="btnPrint" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/print49.png"
                            Width="32px" OnClick="btnPrint_Click" />
                    </div>
                </div>
                <div class="widget-body">
                    <div class="widget-main no-padding">
                        <br />
                        <div style="position: relative">
                            <div class="radio_panel_reporting_rdlc">
                                <div class="SingleCheckbox ">
                                    <asp:RadioButton ID="rdbPdf" runat="server" GroupName="print" />
                                    <asp:Label ID="Label3" AssociatedControlID="rdbPdf" runat="server"
                                        Text="Pdf File(.pdf)" CssClass="CheckBoxLabel"></asp:Label>
                                </div>
                                <div class="SingleCheckbox margin_left_rdlc">
                                    <asp:RadioButton ID="rdbDoc" runat="server" GroupName="print" />
                                    <asp:Label ID="Label1" AssociatedControlID="rdbDoc" runat="server"
                                        Text="Word File(.docx)" CssClass="CheckBoxLabel"></asp:Label>
                                </div>
                                <div class="SingleCheckbox margin_left_rdlc1">
                                    <asp:RadioButton ID="rdbExcel" runat="server" GroupName="print" />
                                    <asp:Label ID="Label2" AssociatedControlID="rdbExcel" runat="server"
                                        Text="Excel File(.xls)" CssClass="CheckBoxLabel"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <asp:Panel ID="messagePanel" runat="server" Style="padding-bottom: 10px" class="messagePanel"
                            Visible="false">
                            <div id="lblMesssge" runat="server" class="alert alert-success">
                                <asp:Label ID="lblMessage" runat="server" Text="message"></asp:Label>
                            </div>
                        </asp:Panel>
                        <div id="divPrint" class="row-fluid" style="height: 415px; overflow-x: hidden; overflow-y: scroll; margin-top: 10px; padding-top: 10px; padding-bottom: 10px; border-top: 1px solid #eee;">
                            <rsweb:ReportViewer ID="ReportViewerAc" AsyncRendering="False" Width="100%" Height="415px" runat="server" Font-Names="Verdana" ShowToolBar="false"
                                Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" ZoomMode="PageWidth" ShowPrintButton="true">
                            </rsweb:ReportViewer>
                        </div>
                        <div class="clearfix">
                        </div>
                    </div>
                    <div class="clearfix">
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

