<%@ Page Title="" Language="C#" MasterPageFile="~/INV/Site.Master" AutoEventWireup="true" CodeBehind="DamageReports.aspx.cs" Inherits="ERPSSL.INV.DamageReports" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        label {
            font-weight: normal !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="hm_sec_2_content scrollbar">
                    <div class="panel">
                        <div class="panel-heading panel-heading-01">
                            <i class="glyphicon glyphicon-edit icon-padding"></i>Return Report

                        </div>
                    </div>
                    <div class="col-md-12 bg-success">
                        <center>
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label></center>
                    </div>
                    <div class="row">
                        <fieldset style="border: none;">
                            <div class="col-md-12">
                                <div class="col-md-12">

                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-2">
                                                From Date
                                            </div>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtFrom" CssClass="form-control" runat="server"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtFrom"
                                                    PopupButtonID="txtFrom" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row" style="padding-top: 8px;">
                                        <div class="col-md-12">
                                            <div class="col-md-2">
                                                To Date
                                            </div>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtTo" CssClass="form-control" runat="server"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtTo"
                                                    PopupButtonID="txtTo" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12">
                            
                                    <div class="row " style="padding-top: 8px;">
                                        <div class="col-md-6">
                                            <asp:HiddenField ID="HiddenField1" runat="server" />
                                            <asp:Button ID="BtnGenerateReport" runat="server" Text="View Report"
                                                OnClick="BtnGenerateReport_Click" Style="margin-top: 0px; margin-left: 20px;"
                                                class="btn btn-info Pull right"  />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12" style="padding-top: 10px;">
                                <div class="row ">
                                    <div class="col-md-12">
                                        <%-- <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" AsyncRendering="False"
                                            InteractiveDeviceInfos="(Collection)" SizeToReportContent="True" Font-Names="Verdana"
                                            Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" BackColor="White">
                                        </rsweb:ReportViewer>--%>
                                        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%"
                                            Font-Names="Verdana" Font-Size="8pt" InteractiveDeviceInfos="(Collection)"
                                            WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="500px"
                                            PageCountMode="Actual" AsyncRendering="False" ShowFindControls="false"
                                            InteractivityPostBackMode="AlwaysSynchronous">
                                        </rsweb:ReportViewer>
                                    </div>
                                </div>
                            </div>
                        </fieldset>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <script type="text/javascript">

        function func(result) {
            if (result === 'Data recorded successfully') {
                toastr.success(result);
            }
            else
                toastr.error(result);

            return false;
        }

    </script>

</asp:Content>
