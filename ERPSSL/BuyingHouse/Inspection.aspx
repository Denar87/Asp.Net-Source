<%@ Page Title="" Language="C#" MasterPageFile="~/BuyingHouse/BuyingSite.Master" AutoEventWireup="true" CodeBehind="Inspection.aspx.cs" Inherits="ERPSSL.BuyingHouse.Inspection" %>

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
        .imgwd
        {
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

                <div class="row" style="padding-top: 10px;">
                    <div class="col-md-6">
                        <div class="row">
                            <asp:TextBox ID="txtOrderNo" placeholder="Enter a Order No" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtOrderNo_OnTextChanged" runat="server"></asp:TextBox>
                        </div>
                        <br />
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
                                              <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOrderDate" runat="server" Text='<%# Eval("OrderDate")%>' />
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
                                    Order No
                              <asp:TextBox ID="txtOrderNumber" CssClass="form-control" Enabled="false" runat="server" ClientIDMode="Static"></asp:TextBox>
                                   </div>       
                                <div class="row">
                                    Order Quantity
                              <asp:TextBox ID="txtOrderQuantity" CssClass="form-control" Enabled="false" runat="server" ClientIDMode="Static"></asp:TextBox>
                                   </div>   
                                 <div class="row">
                                    Reject Quantity
                              <asp:TextBox ID="txtRejectQty" CssClass="form-control"  runat="server" ClientIDMode="Static"></asp:TextBox>
                                   </div>    
                                 <div class="row">
                                    Left Order Quantity
                              <asp:TextBox ID="txtLeftOrderQty" CssClass="form-control"  runat="server" ClientIDMode="Static"></asp:TextBox>
                                   </div>                                    
                                

                            </div>
                            <div class="col-md-6">                              
                              <div class="row">
                                    Order Date
                              <asp:TextBox ID="txtOrderDate" CssClass="form-control" Enabled="false" runat="server" ClientIDMode="Static"></asp:TextBox>
                                   </div>       
                                <div class="row">
                                    Production Quantity
                              <asp:TextBox ID="txtProductionQty" CssClass="form-control" runat="server" ClientIDMode="Static"></asp:TextBox>
                                   </div>   
                                 <div class="row">
                                    Good Quantity
                              <asp:TextBox ID="txtGoodQty" CssClass="form-control"  runat="server" ClientIDMode="Static"></asp:TextBox>
                                   </div>    
                                 <div class="row">
                                    Remarks
                              <asp:TextBox ID="txtRemarks" CssClass="form-control"  runat="server" ClientIDMode="Static"></asp:TextBox>
                                   </div>            

                            </div>

                        </div>
                        <div class="row" style="padding-right: 20px; padding-top: 10px;">
                           <%-- ValidationGroup="save" OnClick="btn_PlanningSave_OnClick"--%>
                            <asp:Button ID="btn_PlanningSave" runat="server" CssClass="btn btn-info pull-right" Text="Save"  />
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
