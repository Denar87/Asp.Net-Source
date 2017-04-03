<%@ Page Title="" Language="C#" MasterPageFile="~/Commercial/ComSite.Master" AutoEventWireup="true" CodeBehind="ProcessRealization.aspx.cs" Inherits="ERPSSL.Commercial.ProcessRealization" %>

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

        function cal() {
            if ($('#txtFromDate').val() != '' && $('#txtToDate').val() != '') {
                var start = new Date($('#txtFromDate').val());
                var end = new Date($('#txtToDate').val());

                // end - start returns difference in milliseconds 
                var diff = new Date(end - start);

                // get days
                var days = diff / 1000 / 60 / 60 / 24;

                $('#txtTotalDays').val(days + 1);
                CalculateDailyTarget();
            }
        }

        function CalculateDailyTarget() {
            var totaldays = $('#txtTotalDays').val();
            var orderQuantity = $('#txtOrderQuantity').val();

            var result = (orderQuantity / totaldays)
            // alert(result);
            $('#txtDailyTarget').val(result);
            //CalculateDailyTarget();
        }
        function CalculateTotalTarget() {
            var totaldays = $('#txtTotalDays').val();
            var dailyTargets = $('#txtDailyTarget').val();

            var result = (totaldays * dailyTargets)
            $('#txtTotalTarget').val(result);

        }
        function CalculateTotalLine() {
            var DailyTergets = $('#txtDailyTarget').val();
            var DailyPerLineTergets = $('#txtDailyPerLineTarget').val();

            var result = (DailyTergets / DailyPerLineTergets)
            //alert(result);
            $('#txtTotalLine').val(result);
            CalculateTotalLineTarget();

        }
        function CalculateTotalLineTarget() {
            var DailyTergets = $('#txtTotalDays').val();
            var DailyPerLineTergets = $('#txtDailyPerLineTarget').val();

            var result = (DailyTergets * DailyPerLineTergets)
            //alert(result);
            $('#txttotalperlinetarget').val(result);

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
                        <i class="fa fa-edit fa-fw icon-padding"></i>Process Realization
                    </div>
                </div>
                <div class="row" style="padding-top: 10px;">
                    <div class="col-md-6">
                        <div class="row">
                            <asp:TextBox ID="txtOrderNo" placeholder="Enter a Order No" CssClass="form-control" AutoPostBack="true" runat="server"></asp:TextBox>
                        </div>
                        <div class="row">
                            <div style="z-index: 1; height: 200px; width: 100%; overflow: scroll; margin-right: -40px;">
                                <div class="row">
                                    <asp:GridView ID="grdOrderDetails" runat="server" AutoGenerateColumns="False"
                                        Width="100%" CellPadding="5" AllowPaging="True">
                                        <Columns>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    SL.
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSRNO" runat="server"
                                                        Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblId" runat="server" Text='<%# Eval("Id")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBuyerID" runat="server" Text='<%# Eval("Buyer_ID")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFinishedGoods_ID" runat="server" Text='<%# Eval("FinishedGoods_ID")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFinishedGoods_Qty" runat="server" Text='<%# Eval("FinishedGoods_Qty")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFinishedGoodsName" runat="server" Text='<%# Eval("FinishedGoodsName")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLc_Order" runat="server" Text='<%# Eval("Lc_Order")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Lc_Order" HeaderText="Order No">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="BuyerName" HeaderText="Buyer">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>

                                            <asp:TemplateField HeaderText="Edit">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgbtnOrderDetails" runat="server" ImageUrl="~/img/Details3.png" OnClick="imgbtnOrderDetails_Click" />
                                                </ItemTemplate>
                                                <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataRowStyle ForeColor="Red" />
                                        <RowStyle CssClass="Grid_RowStyle" />
                                        <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                        <PagerSettings Mode="NumericFirstLast" />
                                        <PagerStyle ForeColor="#000066" HorizontalAlign="Left" BackColor="White" CssClass="pagination01 pageback" />
                                        <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="col-md-6">
                        <div class="row" style="padding-right: 20px;">
                            <div class="col-md-6">
                                <div class="row">
                                    Order Quantity
                              <asp:TextBox ID="txtOrderQuantity" CssClass="form-control" Enabled="false" runat="server" ClientIDMode="Static"></asp:TextBox>
                                </div>
                                <div class="row">
                                    Shipment Date
                                     <asp:TextBox ID="txtShipmentDate" placeholder="MM/dd/YYYY" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtShipmentDate"
                                        SetFocusOnError="True" ForeColor="Red" ValidationGroup="save" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtShipmentDate"
                                        PopupButtonID="txtShipmentDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />

                                </div>
                                <div class="row">
                                    Style
                                    <asp:DropDownList ID="ddlStyle" runat="server" CssClass="form-control"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlStyle"
                                        SetFocusOnError="True" ForeColor="Red" ValidationGroup="add" InitialValue="0" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="row">
                                    Gross Value
                                    <div class="col-md-12">
                                        <div class="col-md-6" style="margin-left: -28px;">
                                            <asp:TextBox ID="TextBox3" Width="140%" CssClass="form-control" placeholder="USD" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-md-6" style="margin-left: 28px;">
                                            <asp:TextBox ID="TextBox4" Width="140%" CssClass="form-control" placeholder="BDT" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="row">
                                    Goods Description
                                    <asp:TextBox ID="txtItemDescription" placeholder="Goods Description" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                </div>
                                <div class="row">
                                    Order Date
                                    <asp:TextBox ID="txtOrderDate" placeholder="MM/dd/yyyy" CssClass="form-control" onchange="cal()" runat="server" ClientIDMode="Static"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtOrderDate"
                                        SetFocusOnError="True" ForeColor="Red" ValidationGroup="save" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtOrderDate"
                                        PopupButtonID="txtOrderDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                </div>
                                <div class="row">
                                    Amount A/C
                                    <asp:TextBox ID="txtAmountAC" CssClass="form-control" placeholder="Amount A/C" runat="server"></asp:TextBox>
                                </div>
                                <div class="row">
                                    BTB
                                    <div class="col-md-12">
                                        <div class="col-md-6" style="margin-left: -28px;">
                                            <asp:TextBox ID="TextBox1" Width="140%" CssClass="form-control" placeholder="USD" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-md-6" style="margin-left: 28px;">
                                            <asp:TextBox ID="TextBox2" Width="140%" CssClass="form-control" placeholder="BDT" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row" style="padding-right: 20px; padding-top: 10px;">
                            <asp:Button ID="btn_PlanningSave" runat="server" CssClass="btn btn-info pull-right" Text="Save" ValidationGroup="save" />
                        </div>
                        <div class="col-md-12">
                            <div class="row">
                                Deduct Charges 
                            </div>
                            <div class="row" style="margin-left: -14px;">
                                <div class="col-md-6">
                                    <div class="row">
                                        <asp:DropDownList ID="ddlDeductCharges" runat="server" CssClass="form-control">
                                            <asp:ListItem>--Select One--</asp:ListItem>
                                            <asp:ListItem>Fund Charge</asp:ListItem>
                                            <asp:ListItem>Bank Charge</asp:ListItem>
                                            <asp:ListItem>SME Charge</asp:ListItem>
                                            <asp:ListItem>Insurance Charge</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ControlToValidate="ddlDeductCharges"
                                            SetFocusOnError="True" ForeColor="Red" ValidationGroup="add" InitialValue="0" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-md-6"style="margin-left: -14px;">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-6">
                                                <asp:TextBox ID="TextBox5" Width="140%" CssClass="form-control" placeholder="USD" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-md-6" style="margin-left:0px;">
                                                <asp:TextBox ID="TextBox6" Width="140%" CssClass="form-control" placeholder="BDT" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTargetAmount"
                                        SetFocusOnError="True" ForeColor="Red" ValidationGroup="add" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12" style="padding-top: 10px;">
                                <asp:Button ID="btnAdLine" runat="server" CssClass="btn btn-info pull-right" ValidationGroup="add" Text="Add" />
                            </div>
                        </div>

                        <div class="col-md-12">
                            <asp:GridView ID="grdLineAllocation" runat="server" AutoGenerateColumns="False"
                                Width="100%" CellPadding="5" AllowPaging="True">
                                <Columns>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            SL.
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblSRNO" runat="server"
                                                Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="LineName" HeaderText="Line Name">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TargetsAmount" HeaderText="Target Amount">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>

                                </Columns>
                                <EmptyDataRowStyle ForeColor="Red" />
                                <RowStyle CssClass="Grid_RowStyle" />
                                <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                <PagerSettings Mode="NumericFirstLast" />
                                <PagerStyle ForeColor="#000066" HorizontalAlign="Left" BackColor="White" CssClass="pagination01 pageback" />
                                <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:GridView>
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
