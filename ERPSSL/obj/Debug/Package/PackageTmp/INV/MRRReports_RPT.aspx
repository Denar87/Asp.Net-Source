<%@ Page Title="" Language="C#" MasterPageFile="~/INV/Site.Master" AutoEventWireup="true"
    CodeBehind="MRRReports_RPT.aspx.cs" Inherits="ERPSSL.INV.MRRReports_RPT" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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
            <div class="row">
                <div class="hm_sec_2_content scrollbar">
                    <div class="panel">
                        <div class="panel-heading panel-heading-01">
                            <i class="glyphicon glyphicon-edit icon-padding"></i>MRR Report
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
                                                Supplier
                                            </div>
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="ddlSupplier" AppendDataBoundItems="true" CssClass="form-control"
                                                    runat="server">
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
                                                <asp:DropDownList ID="ddlItemGroup" AutoPostBack="true" CssClass="form-control" runat="server"
                                                    OnSelectedIndexChanged="ddlItemGroup_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" style="padding-top: 5px;">
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
                                    <div class="row" style="padding-top: 5px;">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                MRR No.
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtMRRNo" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" style="padding-top: 5px;">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Master LC No.
                                            </div>
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="ddlMasterLc" CssClass="form-control" runat="server">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <%--  --%>
                                    <div class="row" style="padding-top: 5px;" runat="server" id="DivddlB2BLCNo" Visible="false" >
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                B2B LC No.
                                            </div>
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="ddlB2BLCNo" CssClass="form-control" runat="server">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" style="padding-top: 5px;" runat="server" id="DivddlPINo" Visible="false" >
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                P.I. No.
                                            </div>
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="ddlPINo" CssClass="form-control" runat="server">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <%--  --%>
                                    <div class="row" style="padding-top: 5px;" runat="server" id="DivStore" Visible="false" >
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Store Wise MRR
                                            </div>
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="ddlStoreWiseMRR" CssClass="form-control" runat="server">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <fieldset style="border: 1px solid #e5e5e5">
                                        <legend style="line-height: 0; font-weight: bold; font-size: 12px"><span style="background: #fff">Report Type </span></legend>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <%--<asp:RadioButton ID="rdbMRRReport" selected="true" Text="MRR Report" runat="server"></asp:RadioButton>--%><br />
                                                <asp:RadioButtonList ID="RBLReport" runat="server" AutoPostBack="true" OnSelectedIndexChanged="RBLReport_SelectedIndexChanged">
                                                    <asp:ListItem Selected="True" Value="AllProductsReceived">All Items Received</asp:ListItem>
                                                    <asp:ListItem Value="AllProductsBySuppliers">All Items By Suppliers</asp:ListItem>
                                                    <asp:ListItem Value="ProductsBySpecificSupplier">Items By Specific Supplier (Please select supplier)</asp:ListItem>
                                                    <asp:ListItem Value="ProductsByChallanNumber">Items by MRR Number</asp:ListItem>
                                                    <asp:ListItem Value="ProductsByGroup">Items by Item group</asp:ListItem>
                                                    <asp:ListItem Value="SpecificProduct">Specific Item</asp:ListItem>
                                                    <asp:ListItem Value="ByMasterLC">Master LC Wise</asp:ListItem>
                                                    <asp:ListItem Value="ByB2BLc">B2B LC Wise MRR</asp:ListItem>
                                                    <asp:ListItem Value="ByPINo">P.I. No Wise MRR</asp:ListItem>
                                                    <asp:ListItem Value="ByStoreWiseMRRReport">Store Wise MRR</asp:ListItem>
                                                   
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </fieldset>
                                    <div class="row ">
                                        <div class="col-md-12">
                                            <asp:HiddenField ID="HiddenField1" runat="server" />
                                            <asp:Button ID="BtnGenerateReport" runat="server" Text="View Report" Style="margin-top: 15px; margin-left: 20px;"
                                                class="btn btn-info" OnClick="BtnGenerateReport_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <asp:Panel ID="Panel1" runat="server" Style="width: auto" Class="modalPopupFreight">
                                <asp:Label ID="lblModalMessage" runat="server" Font-Bold="true"></asp:Label>
                                <link href="../../css/Modal.css" rel="stylesheet" />
                                <div class="modal-dialog" style="width: 830px">
                                    <asp:Panel ID="Panel3" runat="server">
                                        <div class="popuHeader">
                                            <asp:LinkButton ID="CancelButton" runat="server">
                                    <button type="button"  style="color:white" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                            </asp:LinkButton>
                                            <h4 id="myModalLabel">MRR Report</h4>
                                        </div>
                                    </asp:Panel>
                                    <div class="row">
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
                            </asp:Panel>
                            <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                            <asp:ModalPopupExtender ID="ModalPopupExtender" runat="server" TargetControlID="LinkButton1"
                                PopupControlID="Panel1" BackgroundCssClass="modalBackground" CancelControlID="CancelButton"
                                DropShadow="True" PopupDragHandleControlID="Panel3" Enabled="True" />

                        </fieldset>
                    </div>
                </div>
            </div>
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
