<%@ Page Title="" Language="C#" MasterPageFile="~/Production/Production.Master" AutoEventWireup="true" CodeBehind="PackingList.aspx.cs" Inherits="ERPSSL.Production.PackingList" %>

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
            <div class="hm_sec_2_content scrollbar">
                <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="fa fa-edit fa-fw icon-padding"></i>Packing List
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12 bg-success">
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
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
                                                    <asp:ImageButton ID="imgbtnOrderDetails" runat="server" ImageUrl="~/Production/resources/ico/list_edit.png" OnClick="imgbtnOrderDetails_Click" />
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
                               <asp:TextBox ID="txtOderQty" ReadOnly="true" runat="server" placeholder="Order Qty." CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="row">
                                    Invoice No.
                               <asp:TextBox ID="txtInvoiceNo" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="row">
                                    Shipper
                               <asp:TextBox ID="txtShipper" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="row">
                                    Consignee
                               <asp:TextBox ID="txtConsignee" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="row">
                                    Order Date
                               <asp:TextBox ID="txtOrderDate" runat="server" Enabled="false" placeholder="Order Date" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtOrderDate"
                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True"
                                        Font-Size="11px" ValidationGroup="vlCutting"></asp:RequiredFieldValidator>
                                </div>
                                <div class="row">
                                    Invoice Date
                               <asp:TextBox ID="txtInvoiceDate" runat="server" CssClass="form-control"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtInvoiceDate"
                                        PopupButtonID="txtInvoiceDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                </div>
                                <div class="row">
                                    Ship Date
                               <asp:TextBox ID="txtShipDate" runat="server" CssClass="form-control"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtShipDate"
                                        PopupButtonID="txtShipDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                </div>
                                <div class="row">
                                    File Number
                               <asp:TextBox ID="txtFileNumber" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="row" style="padding-top: 5px">
                                    <div class="col-md-6">
                                    </div>
                                    <div class="col-md-6" style="margin-left: 0px;">
                                        <div class="row">
                                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" ValidationGroup="vlCutting" class="btn btn-info pull-right" OnClick="btnSubmit_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>

                    </div>
                </div>


                <div class="panel" style="padding-top: 5px">
                    <div class="panel-heading panel-heading-01">
                        <i class="fa fa-edit fa-fw icon-padding"></i>Shipment Information
                    </div>
                </div>

                <div class="col-md-12">
                    <div class="row" style="padding-right: 20px;">
                        <div class="col-md-4">
                            <div class="row">
                               Customer PO No.
                               <asp:TextBox ID="txtCustomerPONo"  runat="server" placeholder="Customer PO No." CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="row">
                                PO Date
                               <asp:TextBox ID="txtPODate" runat="server" CssClass="form-control"></asp:TextBox>
                                 <ajaxToolkit:CalendarExtender ID="CalendarExtender7" runat="server" TargetControlID="txtPODate"
                                        PopupButtonID="txtPODate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />

                            </div>
                            <div class="row">
                                Ref No.
                               <asp:TextBox ID="txtRefNo" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="row">
                                AWB/BL No.
                               <asp:TextBox ID="txtAWBBLNo" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-md-4">
                            <div class="row">
                               Letter Of Credit No.
                               <asp:TextBox ID="txtLetterOfCreditNo" runat="server"  CssClass="form-control"></asp:TextBox>
                              
                            </div>
                            <div class="row">
                                Currency
                               <asp:TextBox ID="txtCurrency" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="row">
                               Payment Terms
                               <asp:TextBox ID="txtPaymentTerms" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="row">
                              Incoterms Desc.
                               <asp:TextBox ID="txtIncotermsDesc" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-md-4">
                            <div class="row">
                               Mode Of Transportation
                               <asp:TextBox ID="txtModeOfTransportation" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="row">
                               Transportation Terms
                               <asp:TextBox ID="txtTransportationterms" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="row">
                                Number Of Packages
                               <asp:TextBox ID="txtNumberOfPackages" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="row">
                               Gross Weight(Kg)
                               <asp:TextBox ID="txtGrossWeight" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                    </div>

                </div>

                <br />
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
