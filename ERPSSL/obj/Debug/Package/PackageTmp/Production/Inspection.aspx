<%@ Page Title="" Language="C#" MasterPageFile="~/Production/Production.Master" AutoEventWireup="true" CodeBehind="Inspection.aspx.cs" Inherits="ERPSSL.Production.Inspection" %>

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
                        <i class="fa fa-edit fa-fw icon-padding"></i>Inspection
                    </div>
                </div>
                <div class="col-md-12" style="margin: 0 auto; padding-top:8px;">

                    <div class="col-md-4">
                        <div class="row">
                            <asp:TextBox ID="txtOrderNo" placeholder="Enter a Order No" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtOrderNo_OnTextChanged" runat="server"></asp:TextBox>
                        </div>
                        <br />
                        <div class="row">
                            <div style="z-index: 1; height: 300px; width: 100%; overflow: scroll; margin-right: -40px;">
                                <div class="row">
                                    <asp:GridView ID="grdFinishingDetails" runat="server" AutoGenerateColumns="False"
                                        Width="100%" CellPadding="5" AllowPaging="false">
                                        <Columns>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%" HeaderStyle-HorizontalAlign="Center">
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
                                                    <asp:Label ID="lblId" runat="server" Text='<%# Eval("ID")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCuttingID" runat="server" Text='<%# Eval("CuttingID")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSewingID" runat="server" Text='<%# Eval("SewingID")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBuyerID" runat="server" Text='<%# Eval("BuyerID")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblWashingID" runat="server" Text='<%# Eval("WashingID")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <%--<asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFinishingID" runat="server" Text='<%# Eval("FinishingID")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>

                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOrderNo" runat="server" Text='<%# Eval("OrderNo")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOrderQty" runat="server" Text='<%# Eval("OrderQty")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFinishedGoodsName" runat="server" Text='<%# Eval("GoodsName")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFGoodsQty" runat="server" Text='<%# Eval("FGoodsQty")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFGoodsUnit" runat="server" Text='<%# Eval("FGoodsUnit")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTotalFinishingCompleteDate" runat="server" Text='<%# Eval("TotalFinishingCompleteDate")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTotalFinishingCompleteQty" runat="server" Text='<%# Eval("TotalFinishingCompleteQty")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTotalFinishingCompleteUnit" runat="server" Text='<%# Eval("UnitName")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:BoundField DataField="OrderNo" HeaderText="Order No">
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
                                                    <asp:ImageButton ID="imgbtnFinishingDetails" runat="server" ImageUrl="~/img/Details3.png" OnClick="imgbtnFinishingDetails_Click" />
                                                </ItemTemplate>
                                                <ItemStyle Width="7%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
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
                    <div class="col-md-8" style="padding: 0;">
                        <div class="row" style="padding: 0; padding-bottom:8px;">
                            <div class="col-md-6" style="padding: 0;">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            Order No.
                                        </div>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtOrderNoFill" runat="server" ReadOnly="true" placeholder="Order No." CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtOrderNoFill"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Order No.?"
                                                Font-Size="11px" ValidationGroup="vlSewing"></asp:RequiredFieldValidator>
                                            <asp:HiddenField ID="txthidID" runat="server" />
                                            <asp:HiddenField ID="txthidBuyer" runat="server" />
                                            <asp:HiddenField ID="txthidCuttingID" runat="server" />
                                            <asp:HiddenField ID="txthidSewingID" runat="server" />
                                            <asp:HiddenField ID="txthidWashingID" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6" style="padding: 0;">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            Order Qty.
                                        </div>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtOderQty" ReadOnly="true" runat="server" placeholder="Order Qty." CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6" style="padding: 0; padding-top: 5px;">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            Finish Goods
                                        </div>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtFinishGoods" ReadOnly="true" runat="server" placeholder="Finish Goods Name" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6" style="padding: 0; padding-top: 5px;">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            Finish Goods Qty.
                                        </div>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="txtFinishGoodsQty" ReadOnly="true" Width="110%" runat="server" placeholder="Goods Qty." CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-md-4" style="margin-left: -9px;">
                                            <asp:TextBox ID="txtFinishGoodsUnits" ReadOnly="true" runat="server" Width="110%" placeholder="Goods Unit" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-6" style="padding: 0; padding-top: 5px;" runat="server">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            Finishing Complete Date
                                        </div>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtFinishingCompleteDate" ReadOnly="true" runat="server" placeholder="MM/dd/yyyy" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6" style="padding: 0; padding-top: 5px;" runat="server">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            Production Quantity
                                        </div>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="txtCCompleteFinishingQty" ReadOnly="true" runat="server" Width="110%" Placeholder="Complete Finishing Qty."
                                                CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-md-4" style="margin-left: -9px;">
                                            <asp:TextBox ID="txtCCompleteFinishingUnit" runat="server" ReadOnly="true" Width="110%" Placeholder="Complete Finishing Unit."
                                                CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-6" style="padding: 0; padding-top: 5px;">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            Reject Quantity
                                        </div>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtRejectQuantity" runat="server" placeholder="Reject Quantity" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6" style="padding: 0; padding-top: 5px;">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            Good Quantity
                                        </div>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtGoodQuantity" runat="server" placeholder="Good Quantity" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6" style="padding: 0; padding-top: 5px;">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            Left Order Quantity
                                        </div>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtLeftOrderQuantity" runat="server" placeholder="Left Order Quantity" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6" style="padding: 0; padding-top: 5px;">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            Remarks
                                        </div>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtRemarks" runat="server" placeholder="Remarks" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" ValidationGroup="vlSewing" class="btn btn-info pull-right" OnClick="btnSubmit_Click" />
                    </div>
                </div>

                <div class="col-md-12" style="padding-top: 5px;">
                    <div class="col-md-6">
                    </div>
                    <div class="col-md-6" style="margin-left: 0px;">
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
