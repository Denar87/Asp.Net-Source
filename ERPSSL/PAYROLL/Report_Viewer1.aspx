<%@ Page Title="" Language="C#" MasterPageFile="~/PAYROLL/Site.Master" AutoEventWireup="true" CodeBehind="Report_Viewer1.aspx.cs" Inherits="ERPSSL.PAYROLL.Report_Viewer1" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--  <script language="javascript" type="text/javascript">
        function printDiv(divID) {
            //Get the HTML of div
            var divElements = document.getElementById(divID).innerHTML;
            //Get the HTML of whole page
            var oldPage = document.body.innerHTML;

            //Reset the page's HTML with div's HTML only
            document.body.innerHTML =
                  "<html><head><title></title></head><body>" +
                  divElements + "</body>";

            //Print Page
            window.print();

            //Restore orignal HTML
            document.body.innerHTML = oldPage;
        }
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="hm_sec_2_content scrollbar">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <center>
              
            <div class="row">

                <div style="float: right; padding-right: 110px;">
                    <div></div>
                    <asp:RadioButton ID="rdbPdf" Checked="true" runat="server" GroupName="print" Text="PDF" />
                    <%-- <asp:RadioButton ID="rdbDoc" runat="server" GroupName="print" Text="DOC" />--%>
                    <asp:RadioButton ID="rdbExcel" runat="server" GroupName="print" Text="EXCEL" />
                    <asp:ImageButton ID="btnDload" runat="server" OnClick="btnDload_Click" ImageUrl="~/Accounting/Resources/png_icon_set/download177.png" Width="32" />
                    <%--<img alt="" src="../Accounting/Resources/png_icon_set/download177.png" style="Width: 32px" onclick="btnDload_Click" />--%> 
                     <%--<img alt="" src="../Accounting/Resources/png_icon_set/print49.png" style="Width: 32px" onclick="javascript: printDiv('printablediv')" />--%>
                </div>
                <%--<div>
                    <asp:RadioButton ID="rdbPdf" runat="server" GroupName="print" Text="PDF" />
                    <asp:RadioButton ID="rdbDoc" runat="server" GroupName="print" Text="DOC" />
                    <asp:RadioButton ID="rdbExcel" runat="server" GroupName="print" Text="EXCEL" />
                   <asp:Button ID="btnDload" runat="server" Text="Download" OnClick="btnDload_Click" />
                </div>--%>
                <div id="printablediv" style="clear: both;">
                    <%--<rsweb:ReportViewer ID="ReportViewer1" runat="server" AsyncRendering="false" Width="80%" ></rsweb:ReportViewer>--%>
                    <%--<rsweb:ReportViewer ID="ReportViewer1" AsyncRendering="false" runat="server" InteractiveDeviceInfos="(Collection)" SizeToReportContent="True" Width="100%" Height="100%" BackColor="White" ShowToolBar="false" ZoomMode="PageWidth" ShowBackButton="false" ShowExportControls="false" ShowFindControls="false" ShowPageNavigationControls="false" ShowPrintButton="false" ShowRefreshButton="false" ShowZoomControl="false">
                    </rsweb:ReportViewer>--%>
                    <%--<rsweb:ReportViewer ID="ReportViewer1" AsyncRendering="False" Width="100%" Height="415px" runat="server" Font-Names="Verdana" ShowToolBar="false"
                                Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" ZoomMode="PageWidth" ShowPrintButton="true">
                            </rsweb:ReportViewer>--%>
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%"
                        Font-Names="Verdana" Font-Size="8pt" InteractiveDeviceInfos="(Collection)"
                        WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="500px"
                        PageCountMode="Actual" AsyncRendering="False" ShowFindControls="false"
                        InteractivityPostBackMode="AlwaysSynchronous">
                    </rsweb:ReportViewer>


                </div>
            </div>
                                  
        </center>
    </div>
</asp:Content>

      <%--<script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.11.0.min.js"></script>
            <script type="text/javascript">
                function PrintPanel() {
                    var panel = document.getElementById("<%=pnlContents.ClientID %>");
                    var printWindow = window.open('', '', 'height=400,width=800');
                    printWindow.document.write('<html><head>');
                    printWindow.document.write('</head><body >');
                    printWindow.document.write(panel.innerHTML);
                    printWindow.document.write('</body></html>');
                    printWindow.document.close();
                    setTimeout(function () {
                        printWindow.print();
                    }, 500);
                    return false;
                }
            </script>

            <asp:ScriptManager ID="ScriptManager2" runat="server">
            </asp:ScriptManager>
            <asp:Panel ID="pnlContents" runat="server">
                <rsweb:ReportViewer ID="ReportViewer2" runat="server" Width="100%"
                    Font-Names="Verdana" Font-Size="8pt" ShowPrintButton="true" InteractiveDeviceInfos="(Collection)"
                    WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="500px"
                    PageCountMode="Actual" AsyncRendering="False" ShowFindControls="false"
                    InteractivityPostBackMode="AlwaysSynchronous">
                </rsweb:ReportViewer>
            </asp:Panel>
            <asp:Button ID="PrintButton" Text="Print" runat="server" OnClientClick="return PrintPanel();" />



        </center>--%>
