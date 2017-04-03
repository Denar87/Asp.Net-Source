<%@ Page Title="" Language="C#" MasterPageFile="~/INV/Site.Master" AutoEventWireup="true"
    CodeBehind="CentralStockReports.aspx.cs" Inherits="ERPSSL.INV.CentralStockReports" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        label {
            font-weight: normal !important;
        }

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

            <div class="hm_sec_2_content scrollbar">
                <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="glyphicon glyphicon-edit icon-padding"></i>Stock Reports
                    </div>
                </div>
                <div class="col-md-12 bg-success">
                    <center>
                        <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label></center>
                </div>
                <div class="row" style="margin: 0 auto">
                    <fieldset style="border: none;">
                        <div class="col-md-12">
                            <div class="col-md-6">
                                <%-- <div class="row" style="margin-bottom:8px;">
                                    <div class="col-md-12">
                                        <div class="col-md-5">                                           
                                          Project <a style="color: red; font-size: 11px">*</a>
                                        </div>
                                        <div class="col-md-7">
                                           <asp:DropDownList ID="ddlProject" OnSelectedIndexChanged="ddlProject_SelectedIndexChanged" Class="form-control" runat="server" AutoPostBack="True">
                                    </asp:DropDownList>                                          
                                        </div>
                                    </div>
                                        </div>--%>
                                <div class="row" style="margin-bottom: 8px;">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Store <%--<a style="color: red; font-size: 11px">*</a>--%>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="ddlStoreName" Class="form-control" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <%-- <div class="row" style="margin-bottom:8px;">
                                    <div class="col-md-12">
                                        <div class="col-md-5">                                           
                                         Location Unit <a style="color: red; font-size: 11px">*</a>
                                        </div>
                                        <div class="col-md-7">
                                           <asp:DropDownList ID="ddlStoreUnit"  Class="form-control" runat="server">
                                    </asp:DropDownList>                                          
                                        </div>
                                    </div>
                                        </div>--%>
                                <div class="row" style="margin-bottom: 8px;">
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
                                <div class="row" style="margin-bottom: 8px;">
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
                                <div class="row" style="margin-bottom: 8px;">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Qty less then
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtQtyless" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row" style="margin-bottom: 8px;">
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
                                <div class="row">
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
                            </div>
                            <div class="col-md-6">

                                <fieldset style="border: 1px solid #e5e5e5">
                                    <legend style="line-height: 5px; font-weight: bold; font-size: 12px; border-color: #e5e5e5"><span>Report Type </span></legend>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div>
                                                <div>
                                                    <asp:RadioButton ID="rdbFullStock" runat="server" Text="Full Stock" Checked="true" GroupName="rpt_emp" /><br />
                                                    <asp:RadioButton ID="rdbBySpecificItemGroup" runat="server" Text="By Specific Item Group" GroupName="rpt_emp" /><br />
                                                    <asp:RadioButton ID="rdbBySpecificItem" runat="server" Text="By Specific Item" GroupName="rpt_emp" /><br />
                                                    <asp:RadioButton ID="rdbItemDetailByDate" runat="server" Text="Item Details By Date" GroupName="rpt_emp" /><br />
                                                    <asp:RadioButton ID="btnByQtyLessThan" runat="server" Text="By Quantity Less Then" GroupName="rpt_emp" /><br />
                                                    <asp:RadioButton ID="btnLessThenReOrder" runat="server" Text="Less Then Re-Order Level" GroupName="rpt_emp" />

                                                </div>
                                            </div>
                                        </div>
                                        <%--<div class="col-md-12">
                                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged"
                                                        AutoPostBack="true">
                                                        <asp:ListItem Selected="True" Value="FullStock">Full Stock</asp:ListItem>
                                                        <asp:ListItem Value="BySpecificProductGroup">By Specific Item Group</asp:ListItem>
                                                        <asp:ListItem Value="BySpecificProduct">By Specific Item</asp:ListItem>
                                                        <%--<asp:ListItem Value="FromSpecificSupplier">From Specific Supplier</asp:ListItem>--%>
                                        <%-- <asp:ListItem Value="ByQuantityLessThen">By Quantity Less Then</asp:ListItem>
                                                        <asp:ListItem Value="LessThenReOrderQty">Less Then Re-Order Level</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>--%>
                                    </div>
                                </fieldset>

                                <div class="row ">
                                    <div class="col-md-12">
                                        <asp:Button ID="BtnSave" runat="server" Text="View Report" Style="margin-top: 0px; margin-left: 20px;"
                                            class="btn btn-info " OnClick="BtnSave_Click" />
                                    </div>
                                </div>

                            </div>
                        </div>
                        <div class="col-md-12" style="margin: 15px 0 0 0">
                            <center>
                                <div class="row" style="margin: 0 auto">
                                    <div class="col-md-12">
                                        <rsweb:ReportViewer ID="ReportViewer1" runat="server" AsyncRendering="False" InteractiveDeviceInfos="(Collection)"
                                            SizeToReportContent="True" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana"
                                            WaitMessageFont-Size="14pt" BackColor="White" Style="width: auto;">
                                        </rsweb:ReportViewer>
                                    </div>
                                </div>
                            </center>
                        </div>
                    </fieldset>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">

        function func(result) {
            if (result === 'Data Save Successfully') {
                toastr.success(result);
            }

            else
                toastr.error(result);

            return false;
        }

    </script>
</asp:Content>
