<%@ Page Title="" Language="C#" MasterPageFile="~/BuyingHouse/BuyingSite.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="ERPSSL.BuyingHouse.Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

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

            <asp:HiddenField ID="hdnUserID" runat="server" />
            <div class="hm_sec_2_content scrollbar">
                <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="fa fa-edit fa-fw icon-padding"></i>All Reports
                    </div>
                    <div class="col-md-12 bg-success">
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                    </div>
                </div>
                <div>
                    <div class="col-md-12">
                        <div class="row">
                            <div class="col-md-6">
                                <%--<fieldset>
                                    <legend style="line-height: 0;"><span style="background: #fff">Production Report</span></legend>--%>
                                <div id="div1" class="row">

                                    <div class="col-md-6">
                                        <asp:Label ID="lblfrom" runat="server">From Date</asp:Label>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFromDate" Display="Dynamic" SetFocusOnError="True" ValidationGroup="GroupInputType"></asp:RequiredFieldValidator>--%>
                                        <asp:TextBox ID="txtFromDate" CssClass="form-control" placeholder="MM/dd/yyyy" runat="server"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFromDate"
                                            PopupButtonID="txtFromDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                    </div>
                                    <div class="col-md-6">
                                        <asp:Label ID="lblToDate" runat="server">To Date</asp:Label>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtToDate" Display="Dynamic"  SetFocusOnError="True" ValidationGroup="GroupInputType"></asp:RequiredFieldValidator>--%>
                                        <asp:TextBox ID="txtToDate" CssClass="form-control" placeholder="MM/dd/yyyy" runat="server"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtToDate"
                                            PopupButtonID="txtToDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                    </div>
                                </div>

                                <div class="row" style="padding-top: 5px;">
                                    <div class="col-md-6">
                                        <asp:Label ID="lblSupplier" runat="server">Supplier</asp:Label>
                                        <asp:DropDownList ID="ddlSupplier" AppendDataBoundItems="True" CssClass="form-control" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:Label ID="lblOrder" runat="server">Order</asp:Label>
                                        <asp:TextBox ID="txtOrder" Class=" form-control2 form-control " runat="server"></asp:TextBox>
                                        <cc1:AutoCompleteExtender ServiceMethod="SearchLCNo"
                                            MinimumPrefixLength="1"
                                            CompletionInterval="100" EnableCaching="False"
                                            TargetControlID="txtOrder"
                                            ID="AutoCompleteExtender2" runat="server" DelimiterCharacters="" Enabled="True" ServicePath="">
                                        </cc1:AutoCompleteExtender>
                                        <asp:Label ID="lblSeason" runat="server" Text="Label" Visible="false"></asp:Label>

                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <%-- <asp:Button ID="Button1" ValidationGroup="GroupInputType" runat="server" Text="View Report" OnClick="btnProcess_Click" CssClass="btn btn-info  pull-right" />--%>
                                    </div>
                                    <div class="col-md-6" style="padding-top: 5px;">
                                        <asp:Button ID="btnProcess" ValidationGroup="GroupInputType" runat="server" Text="View Report" OnClick="btnProcess_Click" CssClass="btn btn-info  pull-right" />
                                    </div>
                                </div>
                                <%--</fieldset>--%>
                            </div>
                            <div class="col-md-6">
                                <fieldset>
                                    <legend style="line-height: 0;"><span style="background: #fff">Select Report Type</span></legend>
                                   <%-- <asp:RadioButton ID="rdDailyfactoryProduction" runat="server" Visible="false" Text="Daily factory Production" GroupName="rpt_Prod" Checked="True" />
                                    <asp:RadioButton ID="rdbDailyProductionDetails" runat="server" Visible="false" Text="Daily Production Details" GroupName="rpt_Prod" />
                                    <asp:RadioButton ID="rdbTna" runat="server" Text="TNA" Visible="false" GroupName="rpt_Prod" AutoPostBack="True" />--%>
                                    <asp:RadioButton ID="rdbSampledetails" runat="server" Text="Sample details" GroupName="rpt_Prod" /><br />
                                    <asp:RadioButton ID="rdbFactoryDetails" runat="server" Text="Factory Details" GroupName="rpt_Prod" /><br />
                                    <asp:RadioButton ID="rdbBuyerDetails" runat="server" Text="Buyer Details" GroupName="rpt_Prod" /><br />
                                    <asp:RadioButton ID="rdbProductionStatus" runat="server" Text="Production Status" GroupName="rpt_Prod" /><br />
                                    <asp:RadioButton ID="rdbOrderdetails" runat="server" Text="Order Details" GroupName="rpt_Prod" /><br />
                                    <asp:RadioButton ID="rdbOrderSummary" runat="server" Text="Order Summary" GroupName="rpt_Prod" /><br />
                                    <asp:RadioButton ID="rdbOrderBuyerwise" runat="server" Text="Order Summary(Buyer Wise)" GroupName="rpt_Prod" /><br />
                                    <asp:RadioButton ID="rdbShipmentSchedule" runat="server" Text="Shipment Schedule" GroupName="rpt_Prod" /><br />
                                    <asp:RadioButton ID="rdbCompleteShipment" runat="server" Text="Complete Shipment" GroupName="rpt_Prod" /><br />
                                    <asp:RadioButton ID="rdbProductionProcess" runat="server" Text="Production Process" GroupName="rpt_Prod" /><br />
                                    <asp:RadioButton ID="rdbTaskDetails" runat="server" Text="Task Details" GroupName="rpt_Prod" /><br />


                                </fieldset>
                            </div>
                        </div>

                    </div>
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
