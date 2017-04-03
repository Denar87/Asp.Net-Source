<%@ Page Title="Procurement Reports" Language="C#" MasterPageFile="~/Procurement/Site.Master"
    AutoEventWireup="true" CodeBehind="RequisitionReports.aspx.cs" Inherits="ERPSSL.Procurement.RequisitionReports" %>

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
    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>
            <div class="row">               
                <div class="hm_sec_2_content scrollbar">
                     <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="glyphicon glyphicon-edit icon-padding"></i>Requisition Reports
                    </div>
                </div>

                    <div class="col-md-12 bg-success">
                        <center>
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label></center>
                    </div>
                    <div class="row">
                        <fieldset style="border: none;">
                            <div class="col-md-12">
                                <div class="col-md-6">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Date From
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtFromDate" CssClass="form-control" runat="server"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtFromDate"
                                                    PopupButtonID="txtFromDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                To Date
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtToDate" CssClass="form-control" runat="server"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtToDate"
                                                    PopupButtonID="txtToDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Company
                                            </div>
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="ddlCompany" CssClass="form-control" runat="server">
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
                                                <asp:DropDownList ID="ddlDepartment" AutoPostBack="true" CssClass="form-control"
                                                    OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged" runat="server">
                                                </asp:DropDownList>
                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlDepartment"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select a Department"
                                            InitialValue="0" Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>--%>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Item Group
                                            </div>
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="ddlItemGroup" AutoPostBack="true" CssClass="form-control" runat="server"
                                                    OnSelectedIndexChanged="ddlItemGroup_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Requisition No
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtRequisitionNo" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Employee
                                            </div>
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="ddlEmployee" CssClass="form-control" runat="server">
                                                </asp:DropDownList>
                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlEmployee"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select an Emplyee"
                                            InitialValue="0" Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>--%>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Item Name
                                            </div>
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="ddlItemName" CssClass="form-control" runat="server">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                </div>
                                <div class="col-md-6">
                                    <div class="col-md-12">
                                        <fieldset style="border: 1px solid #e5e5e5">
                                            <legend style="line-height: 0; font-weight: bold; font-size: 12px"><span style="background: #fff">Reports for products, yet to issue purchased order</span></legend>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged"
                                                        AutoPostBack="true">
                                                        <asp:ListItem Selected="True" Value="AllRequisitions">All Requisitions</asp:ListItem>
                                                        <asp:ListItem Value="FromSpecificCompany">From Specific Company</asp:ListItem>
                                                        <asp:ListItem Value="FromSpecificDepartment">From Specific Department</asp:ListItem>
                                                        <asp:ListItem Value="FromSpecificEmployee">From Specific Employee</asp:ListItem>
                                                        <asp:ListItem Value="BySpecificProductGroup">By Specific Item Group</asp:ListItem>
                                                        <asp:ListItem Value="BySpecificProduct">By Specific Item</asp:ListItem>
                                                        <asp:ListItem Value="ByRequisitionNumber">By Requisition Number</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                            <br />
                                        </fieldset>
                                    </div>
                                    <div class="row ">
                                        <div class="col-md-12">
                                            <asp:HiddenField ID="HiddenField1" runat="server" />
                                            <asp:Button ID="btnGenerateReport" runat="server" Text="View Report" ValidationGroup="Group1"
                                                OnClick="btnGenerateReport_Click" Style="margin-top: 15px; margin-left: 20px;"
                                                class="btn btn-info pull-right" />
                                        </div>
                                        <br />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="row ">
                                    <div class="col-md-12">
                                        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" AsyncRendering="False"
                                            InteractiveDeviceInfos="(Collection)" SizeToReportContent="True" Font-Names="Verdana"
                                            Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" BackColor="White">
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
</asp:Content>
