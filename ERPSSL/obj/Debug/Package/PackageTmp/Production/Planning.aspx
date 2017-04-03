<%@ Page Title="" Language="C#" MasterPageFile="~/Production/Production.Master" AutoEventWireup="true" CodeBehind="Planning.aspx.cs" Inherits="ERPSSL.Production.Planning" %>

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
                        <i class="fa fa-edit fa-fw icon-padding"></i>Planning
                    </div>
                </div>

                <div class="row" style="padding-top: 10px;">
                    <div class="col-md-6">
                        <div class="row">
                            <asp:TextBox ID="txtOrderNo" placeholder="Enter a Order No" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtOrderNo_OnTextChanged" runat="server"></asp:TextBox>
                        </div>
                        <div class="row">
                            <div style="z-index: 1; height: 300px; width: 100%; overflow: scroll; margin-right: -40px;">
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
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtShipmentDate"
                                        SetFocusOnError="True" ForeColor="Red" ValidationGroup="save" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>

                                    <asp:TextBox ID="txtShipmentDate" placeholder="MM/dd/YYYY" CssClass="form-control" runat="server"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtShipmentDate"
                                        PopupButtonID="txtShipmentDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />

                                </div>
                                <div class="row">
                                    Lead Time From Date
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtFromDate"
                                        SetFocusOnError="True" ForeColor="Red" ValidationGroup="save" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>

                                    <asp:TextBox ID="txtFromDate" placeholder="MM/dd/YYYY" CssClass="form-control" runat="server" onchange="cal()" ClientIDMode="Static"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFromDate"
                                        PopupButtonID="txtFromDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                </div>
                                <div class="row">
                                    Daily Target<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtDailyTarget"
                                        SetFocusOnError="True" ForeColor="Red" ValidationGroup="save" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>

                                    <asp:TextBox ID="txtDailyTarget" CssClass="form-control" runat="server" ClientIDMode="Static"></asp:TextBox>

                                </div>

                                <div class="row">
                                    Daily Per Line Target
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDailyPerLineTarget"
                                        SetFocusOnError="True" ForeColor="Red" ValidationGroup="save" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>

                                    <asp:TextBox ID="txtDailyPerLineTarget" CssClass="form-control" runat="server" ClientIDMode="Static" onchange="CalculateTotalLine()"></asp:TextBox>
                                </div>

                            </div>
                            <div class="col-md-6">
                                <div class="row">
                                    Item Description
                              <asp:TextBox ID="txtItemDescription" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                </div>
                                <div class="row">
                                    Total Days 
                                    Lead Time To Date  Total Line
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtTotalDays"
                                        SetFocusOnError="True" ForeColor="Red" ValidationGroup="save" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>

                                    <asp:TextBox ID="txtTotalDays" CssClass="form-control" runat="server" ClientIDMode="Static" Enabled="false" onchange="CalculateDailyTarget()"></asp:TextBox>
                                </div>
                                <div class="row">
                                    Lead Time To Date  Total Line
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtToDate"
                                        SetFocusOnError="True" ForeColor="Red" ValidationGroup="save" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:TextBox ID="txtToDate" placeholder="MM/dd/yyyy" CssClass="form-control" onchange="cal()" runat="server" ClientIDMode="Static"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtToDate"
                                        PopupButtonID="txtToDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                </div>

                                <div class="row">
                                    Total Line
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTotalLine"
                                        SetFocusOnError="True" ForeColor="Red" ValidationGroup="save" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:TextBox ID="txtTotalLine" CssClass="form-control" runat="server" ClientIDMode="Static" Enabled="false"></asp:TextBox>
                                </div>
                                <div class="row">
                                    Per Line Total Target for Order
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txttotalperlinetarget"
                                        SetFocusOnError="True" ForeColor="Red" ValidationGroup="save" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>

                                    <asp:TextBox ID="txttotalperlinetarget" CssClass="form-control" runat="server" ClientIDMode="Static" Enabled="false"></asp:TextBox>
                                </div>

                            </div>

                        </div>
                        <div class="row" style="padding-right: 20px; padding-top: 10px;">
                            <asp:Button ID="btn_PlanningSave" runat="server" CssClass="btn btn-info pull-right" Text="Save" ValidationGroup="save" OnClick="btn_PlanningSave_OnClick" />
                        </div>

                        <div class="col-md-12">

                            <div class="col-md-6">
                                <div class="row">
                                    Line<asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ControlToValidate="ddlLineList"
                                        SetFocusOnError="True" ForeColor="Red" ValidationGroup="add" InitialValue="0" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:DropDownList ID="ddlLineList" runat="server" CssClass="form-control"></asp:DropDownList>


                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="row">
                                    Target
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTargetAmount"
                                        SetFocusOnError="True" ForeColor="Red" ValidationGroup="add" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:TextBox ID="txtTargetAmount" runat="server" placeholder="Enter Target Amount" CssClass="form-control"></asp:TextBox>

                                </div>
                            </div>
                            <div class="col-md-12" style="padding-right: 10px; padding-top: 10px;">
                                <asp:Button ID="btnAdLine" runat="server" CssClass="btn btn-info pull-right" ValidationGroup="add" Text="Add" OnClick="btnAdLine_OnClick" />
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
