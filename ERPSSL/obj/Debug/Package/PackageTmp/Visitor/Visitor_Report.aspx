<%@ Page Title="" Language="C#" MasterPageFile="~/Visitor/Visitor_Site.Master" AutoEventWireup="true" CodeBehind="Visitor_Report.aspx.cs" Inherits="ERPSSL.Visitor.Visitor_Report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <%--<asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>--%>
    <div class="row">


        <div class="hm_sec_2_content scrollbar">
            <div class="panel">
                <div class="panel-heading panel-heading-01">
                    <i class="glyphicon glyphicon-edit icon-padding"></i>Visitor Report
                </div>
            </div>
            <div class="col-md-12 bg-success">
                <center>
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label></center>
            </div>
            <div class="row">
                <div class="col-md-12" style="margin-top: 10px;">
                    <div class="col-md-7">
                        <fieldset>
                            <legend style="line-height: 0px;"><span style="background: #fff">Select for Search</span></legend>
                            <div class="col-md-6">
                                <div class="row">
                                    <div class="col-md-12" style="padding-bottom: 5px">
                                        <div class="col-md-5">
                                            From
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox runat="server" ID="txtvisitfrom" Class="form-control" placeholder="MM/dd/yyyy" />

                                            <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtvisitfrom"
                                                PopupButtonID="txtvisitfrom" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                        </div>


                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="row">
                                    <div class="col-md-12" style="padding-bottom: 5px">
                                        <div class="col-md-5">
                                            To
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox runat="server" ID="txtvisitTo" Class="form-control" placeholder="MM/dd/yyyy" />

                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtvisitTo"
                                                PopupButtonID="txtvisitTo" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                        </div>


                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-10">
                                </div>
                                <div class="col-md-2" style="margin-left: -35px">
                                    <asp:Button ID="btnReport" runat="server" Text="Report" CssClass="btn btn-primary" OnClick="btnReport_Click" />
                                </div>

                            </div>
                        </fieldset>



                    </div>
                    <div class="col-md-5">
                        <fieldset>
                            <legend style="line-height: 0px;"><span style="background: #fff">Visitor Report</span></legend>
                            <asp:RadioButton ID="rdAllVisitor" runat="server" Text="All Visitor" GroupName="rpt_emp" Checked="True"/><br />
                        </fieldset>
                    </div>
                </div>
            </div>

            <div class="col-md-12">
                <rsweb:ReportViewer ID="ReportViewer" AsyncRendering="False" interactivedeviceinfos="(Collection)" PageCountMode="Actual"
                    SizeToReportContent="True" Width="100%" Height="415px" runat="server" Font-Names="Verdana" ShowFindControls="false"
                    Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
                </rsweb:ReportViewer>
            </div>
        </div>
    </div>
    <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
    <script>

        function func(result) {
            if (result === 'Data Saved Successfully') {
                toastr.success(result);

            }
            else if (result === 'No Data Found') {
                toastr.error(result);
            }

            return false;
        }

    </script>
</asp:Content>
