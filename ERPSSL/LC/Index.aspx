<%@ Page Title="LC" Language="C#" MasterPageFile="~/LC/Site.Master" AutoEventWireup="true"
    CodeBehind="Index.aspx.cs" Inherits="ERPSSL.LC.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="panel" style="margin-top: 100px;">
        <div class="panel-heading panel-heading-01">
            <i class="glyphicon glyphicon-edit icon-padding"></i>Welcome to LC & Merchandising
        </div>
    </div>
    <style type="text/css">
        #slideshow {
            position: relative;
            width: 500px;
            height: 200px;
        }

            #slideshow > div {
                position: absolute;
                top: 5px;
                right: 5px;
                bottom: 5px;
                height: 240px;
            }

        .iconI {
            font-size: 40px;
            padding-top: 20px;
        }

        .heights {
            height: 150px;
        }

        .backcolor1 {
            text-align: left;
        }

        .backcolor2 {
            box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19);
            background-color: azure;
            text-align: center;
            font-size: 20px;
        }
    </style>
    <div class="row" style="margin-top: 10px;">


        <div class="col-md-4" runat="server" visible="false">
            <div class="panel panel-danger">
                <div class="panel-heading" style="text-align: center"><i class="glyphicon glyphicon-user"></i><b>&nbsp;L/C & Merchandising Status</b> </div>
                <div class="panel-body">
                    <div style="height: 30px; color: #2F4F4F; font-size: 12px; font-weight: bold">
                        Master LC Open
                                    <span class="badge alert-danger pull-right">
                                        <asp:Label ID="lblSurveyTodayPending" runat="server" Text="0"></asp:Label></span>
                    </div>
                    <div style="height: 30px; color: #2F4F4F; font-size: 12px; font-weight: bold">
                        B2B LC Open
                            <span class="badge alert-danger pull-right ">
                                <asp:Label ID="lblAirExportTodayPending" runat="server" Text="0"></asp:Label></span>
                    </div>
                    <div style="height: 30px; color: #2F4F4F; font-size: 12px; font-weight: bold">
                        Cost Estimating 
                                    <span class="badge alert-danger pull-right">
                                        <asp:Label ID="lblAirImportTodayPending" runat="server" Text="0"></asp:Label></span>
                    </div>
                    <div style="height: 30px; color: #2F4F4F; font-size: 12px; font-weight: bold">
                        Cost Approval
                                   <span class="badge alert-danger  pull-right">
                                       <asp:Label ID="lblSeaExportTodayPending" runat="server" Text="0"></asp:Label></span>
                    </div>
                   <%-- <div style="height: 30px; color: #2F4F4F; font-size: 12px; font-weight: bold">
                        Sea Import Quotation
                                   <span class="badge  alert-danger pull-right">
                                       <asp:Label ID="lblSeaImportTodayPending" runat="server" Text="0"></asp:Label></span>
                    </div>
                    <div style="height: 30px; color: #2F4F4F; font-size: 12px; font-weight: bold">
                        Land Export Quotation
                                   <span class="badge alert-danger  pull-right">
                                       <asp:Label ID="lblLandExportTodayPending" runat="server" Text="0"></asp:Label></span>
                    </div>
                    <div style="height: 30px; color: #2F4F4F; font-size: 12px; font-weight: bold">
                        Land Import Quotation
                                   <span class="badge alert-danger  pull-right">
                                       <asp:Label ID="lblLandImportTodayPending" runat="server" Text="0"></asp:Label></span>
                    </div>
                    <div style="height: 30px; color: #2F4F4F; font-size: 12px; font-weight: bold">
                        HBP Quotation
                                   <span class="badge alert-danger  pull-right">
                                       <asp:Label ID="lblHBPTodayPending" runat="server" Text="0"></asp:Label></span>
                    </div>--%>

                </div>
            </div>
        </div>


        <div class="col-md-4" runat="server" visible="false">
            <div class="panel panel-info">
                <div class="panel-heading" style="text-align: center"><i class="glyphicon glyphicon-user"></i><b>&nbsp;Requisition & PO Status</b> </div>
                <div class="panel-body">
                    <div style="height: 30px; color: #2F4F4F; font-size: 12px; font-weight: bold">
                        Requisition Create
                                    <span class="badge alert-info pull-right">
                                        <asp:Label ID="lblSurveyTodayComplite" runat="server" Text="0"></asp:Label></span>
                    </div>
                    <div style="height: 30px; color: #2F4F4F; font-size: 12px; font-weight: bold">
                        Requisition Approve
                            <span class="badge alert-info pull-right ">
                                <asp:Label ID="lblAirExportTodayComplite" runat="server" Text="0"></asp:Label></span>
                    </div>
                    <div style="height: 30px; color: #2F4F4F; font-size: 12px; font-weight: bold">
                        PO By Requisition
                                    <span class="badge alert-info pull-right">
                                        <asp:Label ID="lblAirImportTodayComplite" runat="server" Text="0"></asp:Label></span>
                    </div>
                    <div style="height: 30px; color: #2F4F4F; font-size: 12px; font-weight: bold">
                        Sea Export Quotation
                                   <span class="badge alert-info  pull-right">
                                       <asp:Label ID="lblSeaExportTodayComplite" runat="server" Text="0"></asp:Label></span>
                    </div>
                    <div style="height: 30px; color: #2F4F4F; font-size: 12px; font-weight: bold">
                        PO Approve
                                   <span class="badge alert-info  pull-right">
                                       <asp:Label ID="lblSeaimportTodayComplite" runat="server" Text="0"></asp:Label></span>
                    </div>
                    <%--<div style="height: 30px; color: #2F4F4F; font-size: 12px; font-weight: bold">
                        Land Export Quotation
                                   <span class="badge alert-info  pull-right">
                                       <asp:Label ID="lblLandExportTodayComplite" runat="server" Text="0"></asp:Label></span>
                    </div>
                    <div style="height: 30px; color: #2F4F4F; font-size: 12px; font-weight: bold">
                        Land Import Quotation
                                   <span class="badge alert-info  pull-right">
                                       <asp:Label ID="lblLandImportTodayComplite" runat="server" Text="0"></asp:Label></span>
                    </div>
                    <div style="height: 30px; color: #2F4F4F; font-size: 12px; font-weight: bold">
                        HBP Quotation
                                   <span class="badge alert-info  pull-right">
                                       <asp:Label ID="lblHBPTodayComplite" runat="server" Text="0"></asp:Label></span>
                    </div>--%>

                </div>
            </div>

        </div>
        <div class="col-md-4" runat="server" visible="false">
            <div class="panel panel-success">
                <div class="panel-heading" style="text-align: center"><i class="glyphicon glyphicon-user"></i><b>&nbsp;Last Month Complete Status</b> </div>
                <div class="panel-body">
                    <div style="height: 30px; color: #2F4F4F; font-size: 12px; font-weight: bold">
                        Master LC Open
                                    <span class="badge alert-danger pull-right">
                                        <asp:Label ID="Label1" runat="server" Text="0"></asp:Label></span>
                    </div>
                    <div style="height: 30px; color: #2F4F4F; font-size: 12px; font-weight: bold">
                        B2B LC Open
                            <span class="badge alert-danger pull-right ">
                                <asp:Label ID="Label2" runat="server" Text="0"></asp:Label></span>
                    </div>
                    <div style="height: 30px; color: #2F4F4F; font-size: 12px; font-weight: bold">
                        Cost Estimating 
                                    <span class="badge alert-danger pull-right">
                                        <asp:Label ID="Label3" runat="server" Text="0"></asp:Label></span>
                    </div>
                    <div style="height: 30px; color: #2F4F4F; font-size: 12px; font-weight: bold">
                        Cost Approval
                                   <span class="badge alert-danger  pull-right">
                                       <asp:Label ID="Label4" runat="server" Text="0"></asp:Label></span>
                    </div>

                    <div style="height: 30px; color: #2F4F4F; font-size: 12px; font-weight: bold">
                        Requisition Create
                                    <span class="badge alert-info pull-right">
                                        <asp:Label ID="Label5" runat="server" Text="0"></asp:Label></span>
                    </div>
                    <div style="height: 30px; color: #2F4F4F; font-size: 12px; font-weight: bold">
                        Requisition Approve
                            <span class="badge alert-info pull-right ">
                                <asp:Label ID="Label6" runat="server" Text="0"></asp:Label></span>
                    </div>
                    <div style="height: 30px; color: #2F4F4F; font-size: 12px; font-weight: bold">
                        PO By Requisition
                                    <span class="badge alert-info pull-right">
                                        <asp:Label ID="Label7" runat="server" Text="0"></asp:Label></span>
                    </div>
                    <div style="height: 30px; color: #2F4F4F; font-size: 12px; font-weight: bold">
                        Sea Export Quotation
                                   <span class="badge alert-info  pull-right">
                                       <asp:Label ID="Label8" runat="server" Text="0"></asp:Label></span>
                    </div>
                    <div style="height: 30px; color: #2F4F4F; font-size: 12px; font-weight: bold">
                        PO Approve
                                   <span class="badge alert-info  pull-right">
                                       <asp:Label ID="Label9" runat="server" Text="0"></asp:Label></span>
                    </div>

                </div>
            </div>

        </div>
    </div>
    <div class="row" style="padding-top: 8px;">
    </div>

</asp:Content>

