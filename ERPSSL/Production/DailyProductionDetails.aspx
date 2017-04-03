<%@ Page Title="" Language="C#" MasterPageFile="~/Production/Production.Master" AutoEventWireup="true" CodeBehind="DailyProductionDetails.aspx.cs" Inherits="ERPSSL.Production.DailyProductionDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

    <script language="javascript" type="text/javascript">
        function ShowIcon() {
            var e = document.getElementById("processing");
            e.style.visibility = (e.style.visibility == 'visible') ? 'hidden' : 'visible';
        }
        function ShowIcon_tr() {
            var et = document.getElementById("processing_tr");
            et.style.visibility = (et.style.visibility == 'visible') ? 'hidden' : 'visible';
        }
    </script>
    <style type="text/css">
        .imgwd {
            width: 88px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePageMethods="true" EnablePartialRendering="true" ID="ScriptManager1" />
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">

        <ContentTemplate>
            <div class="hm_sec_2_content">
                <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="fa fa-edit fa-fw icon-padding"></i>Daily Production Details
                    </div>
                </div>
                <div class="row" style="padding-top: 5px; margin: 0 auto">
                    <div class="col-md-12 bg-success">
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </div>
                    <div class="col-md-12">

                        <div class="row">
                            <div class="col-md-4">
                                Order Date 
                            <asp:TextBox ID="txtOrderDate" runat="server" placeholder="MM/dd/yyyy" class="form-control"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtOrderDate"
                                    PopupButtonID="txtOrderDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" SetFocusOnError="true" Display="Dynamic" ForeColor="Red"
                                    ControlToValidate="txtOrderDate" ErrorMessage="Please Select Date" ValidationGroup="CC_LC"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-4">
                                Order
                            <asp:DropDownList ID="ddlOrder" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="col-md-4">
                                Style
                            <asp:DropDownList ID="ddlStyle" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <h1 style="margin-top: -2px; margin-bottom: 2px;"></h1>
                    </div>
                    <div class="col-md-12" style="padding-top: 0px; padding-bottom: 0;">
                        <h4 style="margin-top: -2px; color: #0526ef; margin-bottom: 2px;">Cutting Section :</h4>
                        <div class="row" style="padding-top: 0px; padding-bottom: 0;">
                            <div class="col-md-3">
                                Day Cutting.
                            <asp:TextBox ID="txtDayCutting" runat="server" placeholder="Day Cutting." class="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                Day Cutting Input Supply
                            <asp:TextBox ID="txtCuttingInput" runat="server" placeholder="Day Input Supply" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <h1 style="margin-top: -2px; margin-bottom: 2px;"></h1>
                    </div>
                    <div class="col-md-12" style="padding-top: 0px; padding-bottom: 0;">
                        <div class="row" style="padding-top: 0px; padding-bottom: 0;">
                            <h4 style="margin-top: -2px; color: #0526ef; margin-bottom: 2px;">Sewing Section :</h4>
                            <div class="col-md-3">
                                Day Sewing Input
                            <asp:TextBox ID="txtSewingInput" runat="server" placeholder="Day Input" class="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                Day Sewing Target
                            <asp:TextBox ID="txtSewingTarget" runat="server" placeholder="Day Target" class="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                Day Sewing Achieve
                            <asp:TextBox ID="txtSewingAchieve" runat="server" placeholder="Day Achieve" OnTextChanged="txtSewingAchieve_TextChanged" 
                                AutoPostBack="true" class="form-control"></asp:TextBox>

                                <asp:Label ID="lbltxtPersentiges" runat="server" Visible="false"></asp:Label>
                            </div>
                        </div>
                        <h1 style="margin-top: -2px; margin-bottom: 2px;"></h1>
                    </div>
                    <div class="col-md-12" style="padding-top: 0px; padding-bottom: 0;">
                        <div class="row" style="padding-top: 0px; padding-bottom: 0;">
                            <h4 style="margin-top: -2px; color: #0526ef; margin-bottom: 2px;">Finishing Section :</h4>
                            <div class="col-md-3">
                                Finishing Received
                            <asp:TextBox ID="txtFinishingReceived" runat="server" placeholder="Received" class="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                Finishing Iron
                            <asp:TextBox ID="txtFinishingIron" runat="server" placeholder="Iron" class="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                Finishing Day Poly
                            <asp:TextBox ID="txtDayPoly" runat="server" placeholder="Day Poly" class="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                Finishing Day Packing
                            <asp:TextBox ID="txtDayPacking" runat="server" placeholder="Day Packing" class="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-3" style="padding-top: 5px;">
                                Finishing Day Shipment
                            <asp:TextBox ID="txtDayShipment" runat="server" placeholder="Day Shipment" class="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-3" style="padding-top: 5px;">
                                Finishing Shipment FOB
                            <asp:TextBox ID="txtShipmentFOB" runat="server" placeholder="Shipment FOB" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <h1 style="margin-top: -2px; margin-bottom: 2px;"></h1>
                    </div>
                    <div class="col-md-12" style="padding-top: 0px; padding-bottom: 0;">
                        <div class="row" style="padding-top: 0px; padding-bottom: 0;">
                            <h4 style="margin-top: -2px; color: #0526ef; margin-bottom: 2px;">Store Section :</h4>
                            <div class="col-md-3">
                                Store Day Shipment
                            <asp:TextBox ID="txtStoreShipment" runat="server" placeholder="Day Shipment" class="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                Store Shipment FOB
                            <asp:TextBox ID="txtStoreShipmentFOB" runat="server" placeholder="Shipment FOB" class="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                Remarks
                            <asp:TextBox ID="txtRemarks" runat="server" placeholder="Remarks" TextMode="MultiLine" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <h1 style="margin-top: -2px; margin-bottom: 2px;"></h1>
                    </div>
                    <div class="col-md-12" style="padding-top: 0px;">
                        <div class="col-md-6">
                        </div>
                        <div class="col-md-6" style="margin-left: 0px;">
                            <div class="row">
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" ValidationGroup="vlSewing"
                                    OnClick="btnSubmit_Click" class="btn btn-info pull-right" />
                            </div>
                        </div>
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
            else if (result === 'Already Exist In Database') {
                toastr.success(result);
            }
            else if (result === ' Data Already Exists!') {
                toastr.success(result);
            }
            else if (result === 'Data Update Successfully') {
                toastr.success(result);
            }
            else
                toastr.error(result);
            return false;
        }
    </script>

</asp:Content>
