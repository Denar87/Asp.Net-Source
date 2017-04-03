<%@ Page Title="" Language="C#" MasterPageFile="~/INV/Site.Master" AutoEventWireup="true" CodeBehind="OthersReports_RPT.aspx.cs" Inherits="ERPSSL.INV.OthersReports_RPT" %>
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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
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
                            <i class="glyphicon glyphicon-edit icon-padding"></i>Others Reports
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
                                                Item Group
                                            </div>
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="ddlItemGroup" CssClass="form-control" runat="server">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="col-md-12">
                                        <fieldset style="border: 1px solid #e5e5e5">
                                            <legend style="line-height: 5px; font-weight: bold; font-size: 12px"><span style="background: #fff">Report Type </span></legend>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server"
                                                        AutoPostBack="true">
                                                        <asp:ListItem Selected="True" Value="AllProduct">All Product List</asp:ListItem>
                                                        <asp:ListItem Value="AllSupplier">All Supplier List</asp:ListItem>
                                                        <asp:ListItem Value="ItemUpdateLog">Item Update Log</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                            
                                        </fieldset>
                                    </div>
                                    <div class="row" style="padding-bottom:10px">
                                        <div class="col-md-12">
                                            <asp:Button ID="btnViewReport" runat="server" Text="View Report" Style=" margin-left: 20px;"
                                                class="btn btn-info" OnClick="btnViewReport_Click" />
                                        </div>
                                    </div>
                                    
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="row">
                                    <%-- <rsweb:ReportViewer ID="ReportViewer1" runat="server" AsyncRendering="False" InteractiveDeviceInfos="(Collection)"
                                        SizeToReportContent="True" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana"
                                        WaitMessageFont-Size="14pt" BackColor="White" Style="width: auto; overflow: scroll;">
                                    </rsweb:ReportViewer>--%>
                                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%"
                                        Font-Names="Verdana" Font-Size="8pt" InteractiveDeviceInfos="(Collection)"
                                        WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="500px"
                                        PageCountMode="Actual" AsyncRendering="False" ShowFindControls="false"
                                        InteractivityPostBackMode="AlwaysSynchronous">
                                    </rsweb:ReportViewer>
                                </div>
                            </div>
                        </fieldset>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
