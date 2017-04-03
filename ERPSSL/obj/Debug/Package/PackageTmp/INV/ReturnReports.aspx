<%@ Page Title="" Language="C#" MasterPageFile="~/INV/Site.Master" AutoEventWireup="true" CodeBehind="ReturnReports.aspx.cs" Inherits="ERPSSL.INV.ReturnReports" %>
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
                                <div class="col-md-6">

                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                From Date
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtFrom" CssClass="form-control" runat="server"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtFrom"
                                                    PopupButtonID="txtFrom" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row" style="padding-top: 8px;">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                To Date
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtTo" CssClass="form-control" runat="server"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtTo"
                                                    PopupButtonID="txtTo" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row" style="padding-top: 8px;">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Supplier
                                            </div>
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="ddlSupplier" AppendDataBoundItems="true" CssClass="form-control"
                                                    runat="server">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row" style="padding-top: 8px;">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Department
                                            </div>
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="ddlDepartment" AutoPostBack="True" CssClass="form-control"
                                                    runat="server" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row" style="padding-top: 8px;">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Employee
                                            </div>
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="ddlReciver" CssClass="form-control" runat="server">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>

                                    <%-- <div class="row" style="padding-top: 8px;">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Store
                                            </div>
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="ddlStoreName" Class="form-control" runat="server">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlStoreName"
                                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Store Name"
                                                    Font-Size="13px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                    </div>--%>

                                    <%--   <div class="row" style="padding-bottom: 8px">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            Store<a style="color: red; font-size: 11px">*</a>
                                        </div>
                                        <div class="col-md-8">
                                            <asp:DropDownList ID="ddlStore" Class="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlStore_SelectedIndexChanged"
                                                Visible="True">
                                            </asp:DropDownList>                                           
                                        </div>
                                    </div>
                                </div>--%>

                                    <div class="row" style="padding-top: 8px;">
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
                                    <div class="row" style="padding-top: 8px;">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Item
                                            </div>
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="ddlItemName" CssClass="form-control" runat="server">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                                <div class="col-md-6">
                                    <div class="col-md-12">
                                        <fieldset style="border: 1px solid #e5e5e5">
                                            <legend style="line-height: 5px; font-weight: bold; font-size: 12px; border-color: #e5e5e5"><span>Report Type </span></legend>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <asp:RadioButtonList ID="RBLReport" runat="server" AutoPostBack="true" OnSelectedIndexChanged="RBLReport_SelectedIndexChanged">
                                                        <asp:ListItem Value="AllReturnFromSuppliers">Return To Supplier</asp:ListItem>
                                                        <asp:ListItem Value="AllReturnFromDepartment">Return To Store</asp:ListItem>
                                                        <%--  <asp:ListItem Value="AllProductsReceived">All Items Received</asp:ListItem>
                                                        <asp:ListItem Value="AllProductsBySuppliers">All Items By Suppliers</asp:ListItem>
                                                        <asp:ListItem Value="ProductsBySpecificSupplier">Items By Specific Supplier (Please select supplier)</asp:ListItem>
                                                        <asp:ListItem Value="ProductsByChallanNumber">Items by MRR Number</asp:ListItem>
                                                        <asp:ListItem Value="ProductsByGroup">Items by Item group</asp:ListItem>
                                                        <asp:ListItem Value="SpecificProduct">Specific Item</asp:ListItem>--%>
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                        </fieldset>
                                    </div>
                                    <div class="row ">
                                        <div class="col-md-12">
                                            <asp:HiddenField ID="HiddenField1" runat="server" />
                                            <asp:Button ID="BtnGenerateReport" runat="server" Text="View Report" Style="margin-top: 0px; margin-left: 20px;"
                                                class="btn btn-info" OnClick="BtnGenerateReport_Click" />
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
