<%@ Page Title="" Language="C#" MasterPageFile="~/POS/Site.Master" AutoEventWireup="true" CodeBehind="Report_Viewer.aspx.cs" Inherits="ERPSSL.POS.Report_Viewer" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="row">

        <div class="box col-md-12">
            <div class="box-inner">
                <div class="panel-heading panel-heading-01">
                    <i class="fa fa-edit fa-fw icon-padding"></i>Report Viwer
                </div>

                <div class="box-content row content" id="content-1">
                    <asp:Button ID="btnDload" runat="server" Text="Download" OnClick="btnDload_Click" />
                    <div>
                        <asp:RadioButton ID="rdbPdf" runat="server" GroupName="print" Text="PDF" />
                        <asp:RadioButton ID="rdbDoc" runat="server" GroupName="print" Text="DOC" />
                        <asp:RadioButton ID="rdbExcel" runat="server" GroupName="print" Text="EXCEL" />
                    </div>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <rsweb:ReportViewer ID="ReportViewer1" AsyncRendering="False" InteractiveDeviceInfos="(Collection)"
                        SizeToReportContent="True" Width="100%" Height="415px" runat="server" Font-Names="Verdana" ShowToolBar="true"
                        Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" ZoomMode="PageWidth" ShowPrintButton="true">
                    </rsweb:ReportViewer>
                </div>
            </div>
    </div>
</asp:Content>
