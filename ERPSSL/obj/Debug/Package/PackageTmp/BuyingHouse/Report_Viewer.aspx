<%@ Page Title="" Language="C#" MasterPageFile="~/BuyingHouse/BuyingSite.Master" AutoEventWireup="true" CodeBehind="Report_Viewer.aspx.cs" Inherits="ERPSSL.BuyingHouse.Report_Viewer" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="hm_sec_2_content">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <center>
            <div class="row" style="margin: 0px auto">

                <div style="float: right; padding-right: 110px;">
                    <div></div>
                    <asp:RadioButton ID="rdbPdf" Checked="true" runat="server" GroupName="print" Text="PDF" />
                    <%-- <asp:RadioButton ID="rdbDoc" runat="server" GroupName="print" Text="DOC" />--%>
                    <asp:RadioButton ID="rdbExcel" runat="server" GroupName="print" Text="EXCEL" />
                    <asp:ImageButton ID="btnDload" runat="server" OnClick="btnDload_Click" ImageUrl="~/Accounting/Resources/png_icon_set/download177.png" Width="32" />
                    <%--<img alt="" src="../Accounting/Resources/png_icon_set/download177.png" style="Width: 32px" onclick="btnDload_Click" />--%> 
                     <%--<img alt="" src="../Accounting/Resources/png_icon_set/print49.png" style="Width: 32px" onclick="JavaScript: printDiv('printablediv')" />--%>
                </div>
                <%--<div>
                    <asp:RadioButton ID="rdbPdf" runat="server" GroupName="print" Text="PDF" />
                    <asp:RadioButton ID="rdbDoc" runat="server" GroupName="print" Text="DOC" />
                    <asp:RadioButton ID="rdbExcel" runat="server" GroupName="print" Text="EXCEL" />
                   <asp:Button ID="btnDload" runat="server" Text="Download" OnClick="btnDload_Click" />
                </div>--%>
                <div style="clear: both;" class="col-md-12">
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
            <script type="text/JavaScript">
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
