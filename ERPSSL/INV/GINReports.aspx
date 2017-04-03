<%@ Page Title="" Language="C#" MasterPageFile="~/INV/Site.Master" AutoEventWireup="true"
    CodeBehind="GINReports.aspx.cs" Inherits="ERPSSL.INV.GIN_Reports" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        label {
            font-weight: normal !important;
        }
    </style>
    <style type="text/css">
        .LoaderBackground_ {
            /*background-color:;*/
            filter: alpha(opacity=90);
            opacity: 0.9;
            z-index: 999999999;
            overflow: hidden;
            width: 20%;
            height: 20%;
            position: absolute;
            margin: 170px 300px 0;
        }

        .LoaderBackground_Image {
            display: block;
            position: absolute;
            left: 48%;
            top: 40%;
            width: 50px;
            height: 50px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdWaitImage" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="UpdatePanel8">
                <ProgressTemplate>
                    <div class="LoaderBackground_">
                        <asp:Image ID="Image1" runat="server" CssClass="LoaderBackground_Image" ImageUrl="../content/image/busy.gif" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <%--            <div class="row">--%>
            <div class="hm_sec_2_content scrollbar">
                <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="glyphicon glyphicon-edit icon-padding"></i>GIN Reports
                    </div>
                </div>
                <div class="col-md-12 bg-success">
                    <center>
                        <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label>
                    </center>
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
                                            <asp:TextBox ID="txtFrom" CssClass="form-control" placeholder="MM/dd/yyyy" runat="server"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtFrom"
                                                PopupButtonID="txtFrom" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            To Date
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtTo" CssClass="form-control" placeholder="MM/dd/yyyy" runat="server"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtTo"
                                                PopupButtonID="txtTo" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Store From
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="ddlStoreFrom" AppendDataBoundItems="true" CssClass="form-control"
                                                AutoPostBack="True" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Store To
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="ddlStoreTo" AppendDataBoundItems="true" CssClass="form-control"
                                                AutoPostBack="True" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Item Group
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="ddlItemGroup" AppendDataBoundItems="true" CssClass="form-control"
                                                AutoPostBack="True" runat="server" OnSelectedIndexChanged="ddlItemGroup_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Item Name
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="ddlItemName" AppendDataBoundItems="true" CssClass="form-control"
                                                AutoPostBack="True" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            GIN No
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtGINNo" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Employee Id
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="TxtEmployeeId" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row" style="padding-top: 5px;">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Sub Company 
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="ddlSubCompany" AppendDataBoundItems="true" CssClass="form-control" AutoPostBack="True" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row" style="padding-top: 5px;" runat="server" id="DivStore" visible="false">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Store Wise GIN
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="ddlStoreWiseGIN" CssClass="form-control" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <br />
                            </div>
                            <div class="col-md-6">
                                <div class="col-md-12">
                                    <fieldset style="border: 1px solid #e5e5e5">
                                        <legend style="line-height: 0; font-weight: bold; font-size: 12px"><span style="background: #fff">Report Type </span>
                                        </legend>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <asp:RadioButtonList ID="RBLReport" runat="server" AutoPostBack="true" OnSelectedIndexChanged="RBLReport_SelectedIndexChanged">
                                                    <asp:ListItem Selected="True" Value="AllProductsDelivered">All Items Delivered</asp:ListItem>
                                                    <asp:ListItem Value="DeliveryByGroup">Issue By Specific Item Group</asp:ListItem>
                                                    <asp:ListItem Value="DeliverySpecificProduct">Issue By Specific Item</asp:ListItem>
                                                    <asp:ListItem Value="DeliveryBySpecificEmployeeId">Issue By Specific EmployeeId</asp:ListItem>
                                                    <%--  <asp:ListItem Value="DeliveryToSpecificCompany">Issue To Specific Store</asp:ListItem>--%>
                                                    <%--<asp:ListItem Value="DeliveryFromSpecificCompany">Issue From Specific Store</asp:ListItem>--%>
                                                    <%-- <asp:ListItem Value="DeliveryFromSpecificCompanyToCompany">Issue From Specific Store To Store</asp:ListItem>--%>
                                                    <asp:ListItem Value="DeliveryByChallanNumber">Issue By GIN Number</asp:ListItem>
                                                    <asp:ListItem Value="SubCompanyWiseReport">Sub Company Wise Report</asp:ListItem>
                                                    <asp:ListItem Value="StoreToStoreTransferHistory">Store To Store Transfer History</asp:ListItem>
                                                    <asp:ListItem Value="ByStoreWiseGINReport">Store Wise GIN</asp:ListItem>
                                                </asp:RadioButtonList>
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

                        <div class="col-md-12">
                            <div class="row ">
                                <div class="col-md-12">
                                    <%--<rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" AsyncRendering="False"
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
            <%--</div>--%>
        </ContentTemplate>
    </asp:UpdatePanel>

    <script type="text/javascript">

        function func(result) {
            if (result === 'Data Saved Successfully') {
                toastr.success(result);
            }
            else if (result === 'Data Updating failure') {
                toastr.error(result);
            }
            else
                toastr.error(result);
            return false;
        }

    </script>

</asp:Content>
