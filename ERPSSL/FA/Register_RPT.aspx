<%@ Page Title="" Language="C#" MasterPageFile="~/FA/Site.Master" AutoEventWireup="true"
    CodeBehind="Register_RPT.aspx.cs" Inherits="ERPSSL.FA.Register_RPT" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        label
        {
            font-weight: normal !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <div class="row">
        

        <div class="hm_sec_2_content scrollbar">
            <div class="panel">
            <div class="panel-heading panel-heading-01">
                <i class="fa fa-edit fa-fw icon-padding"></i>Register Report
            </div>
        </div>
            <div class="col-md-12 bg-success">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </div>
            <div class="row">
                <fieldset style="border: none;">
                    <div class="col-md-12">
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-5">
                                        From Date:
                                    </div>
                                    <div class="col-md-7">
                                        <asp:TextBox ID="txtDateFrom" CssClass="form-control" runat="server"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtDateFrom"
                                            PopupButtonID="txtFrom" Format="MM/dd/yyyy" CssClass="ajax__calendar"
                                            Enabled="True" />
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-5">
                                        To Date:
                                    </div>
                                    <div class="col-md-7">
                                        <asp:TextBox ID="txtDateTo" CssClass="form-control" runat="server"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDateTo"
                                            PopupButtonID="txtTo" Format="MM/dd/yyyy" CssClass="ajax__calendar"
                                            Enabled="True" />
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-5">
                                        Region
                                    </div>
                                    <div class="col-md-7">
                                        <asp:DropDownList ID="ddlRegion" AppendDataBoundItems="true" CssClass="form-control"
                                            runat="server" AutoPostBack="True"
                                            OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-5">
                                        Office
                                    </div>
                                    <div class="col-md-7">
                                        <asp:DropDownList ID="ddlOffice" AppendDataBoundItems="true" CssClass="form-control"
                                            runat="server" AutoPostBack="True"
                                            OnSelectedIndexChanged="ddlOffice_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-5">
                                        Department
                                    </div>
                                    <div class="col-md-7">
                                        <asp:DropDownList ID="ddlDepartment" AppendDataBoundItems="true" CssClass="form-control"
                                            runat="server" AutoPostBack="True"
                                            OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-5">
                                        Asset
                                    </div>
                                    <div class="col-md-7">
                                        <asp:DropDownList ID="ddlAsset" AppendDataBoundItems="true" CssClass="form-control"
                                            runat="server" AutoPostBack="True"
                                            OnSelectedIndexChanged="ddlAsset_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-5">
                                        Asset Code
                                    </div>
                                    <div class="col-md-7">
                                        <asp:TextBox ID="txtAssetCode" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="col-md-12">
                                <fieldset>
                                    <legend style="line-height: 0;"><span style="background: #fff">As Per</span></legend>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <asp:RadioButtonList ID="rdoAsPer" runat="server">
                                                <asp:ListItem>Accounting</asp:ListItem>
                                                <asp:ListItem>Tax</asp:ListItem>
                                            </asp:RadioButtonList>

                                        </div>

                                    </div>
                                    <br />
                                </fieldset>
                            </div>
                            <div class="col-md-12" style="margin-top: 20px;">
                                <fieldset>
                                    <legend style="line-height: 0;"><span style="background: #fff">Report Type </span></legend>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                                                <asp:ListItem>Summary</asp:ListItem>
                                                <asp:ListItem Value="IndividualItem">Individual Item </asp:ListItem>
                                            </asp:RadioButtonList>

                                        </div>
                                        <div class="col-md-12">
                                            <asp:Label ID="Label1" runat="server" Text="(Please select an Asset or enter Asset Code)"></asp:Label>
                                        </div>

                                    </div>
                                    <br />
                                </fieldset>
                            </div>
                            <div class="row ">
                                <div class="col-md-12">
                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                    <asp:Button ID="BtnSave" runat="server" Text="View Report" Style="margin-top: 15px; margin-left: 20px;"
                                        class="btn btn-info" OnClick="BtnSave_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </fieldset>
                <div class="row">
                    <rsweb:ReportViewer ID="ReportViewer1" AsyncRendering="False" InteractiveDeviceInfos="(Collection)"
                        SizeToReportContent="True" Width="100%" runat="server" Font-Names="Verdana" Font-Size="8pt"
                        WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" BackColor="White">
                    </rsweb:ReportViewer>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
