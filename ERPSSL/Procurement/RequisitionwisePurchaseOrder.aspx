<%@ Page Title="Requisition List" Language="C#" MasterPageFile="~/Procurement/Site.Master"
    AutoEventWireup="true" CodeBehind="RequisitionwisePurchaseOrder.aspx.cs" Inherits="ERPSSL.Procurement.RequisitionwisePurchaseOrder" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>
            <div class="row">
                
                <div class="hm_sec_2_content scrollbar">
                    <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="glyphicon glyphicon-edit icon-padding"></i>Requisition wise Purchase Order
                    </div>
                </div>

                    <div class="col-md-12 bg-success">
                        <center>
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label></center>
                    </div>
                    <br />
                    <div class="row">
                        <fieldset style="border: none;">
                            <div class="col-md-12">
                                <div class="col-md-7">
                                    <fieldset style="border: 1px solid #e5e5e5">
                                        <legend style="line-height: 0; font-weight: bold;"><span style="background: #fff">Purchase Requisition Item List</span></legend>
                                        <asp:GridView ID="grdProductToPurchase" runat="server" AutoGenerateColumns="False" Width="100%"
                                            DataKeyNames="Id" AutoGenerateSelectButton="True" OnSelectedIndexChanged="grdProductToPurchase_SelectedIndexChanged"
                                            CellPadding="4" ForeColor="#333333" GridLines="Both">
                                            <Columns>
                                                <asp:BoundField DataField="Id" HeaderText="Id" Visible="true"
                                                    SortExpression="Id" />
                                                <asp:BoundField DataField="BarCode" HeaderText="Barcode" SortExpression="BarCode" />
                                                <asp:BoundField DataField="ProductName" HeaderText="Item" SortExpression="ProductName" />
                                                <asp:BoundField DataField="CompanyCode" HeaderText="Store Code" SortExpression="CompanyCode" />
                                                <asp:BoundField DataField="CompanyName" HeaderText="Store" SortExpression="CompanyName" />
                                                <asp:BoundField DataField="CompanyType" HeaderText="Store Type" SortExpression="CompanyType"
                                                    Visible="false" />
                                                <asp:BoundField DataField="ReqQty" HeaderText="Req. Qty" SortExpression="ReqQty" />
                                                <asp:BoundField DataField="BalQty" HeaderText="Balance Qty" SortExpression="BalQty" />
                                                <asp:BoundField DataField="PurchaseQty" HeaderText="Purchase Qty" SortExpression="PurchaseQty" />
                                                <asp:BoundField DataField="AssetType" HeaderText="AssetType" SortExpression="AssetType"
                                                    Visible="false" />
                                            </Columns>
                                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                            <EditRowStyle BackColor="#7C6F57" />
                                            <EmptyDataRowStyle ForeColor="Red" />
                                            <RowStyle CssClass="Grid_RowStyle" BackColor="#E3EAEB" HorizontalAlign="Center" />
                                            <AlternatingRowStyle CssClass="Grid_AltRowStyle" BackColor="White" />
                                            <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#666666" />
                                            <HeaderStyle Width="20%" VerticalAlign="Middle" CssClass="Grid_Header" BackColor="#1C5E55"
                                                Font-Bold="True" ForeColor="White" />
                                            <FooterStyle CssClass="Grid_Footer" BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                            <SortedAscendingHeaderStyle BackColor="#246B61" />
                                            <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                            <SortedDescendingHeaderStyle BackColor="#15524A" />
                                        </asp:GridView>
                                    </fieldset>
                                    <fieldset style="border: none">
                                        <asp:Button ID="BtnPurchaseByQuotation" runat="server" Text="Request For Approval"
                                            Style="margin-top: 15px; margin-right: 20px;" class="btn btn-info pull-right" OnClick="BtnPurchaseByQuotation_Click" />
                                        <asp:Button ID="BtnDirectPurchase" runat="server" Text="Direct Purchase" Style="margin-top: 15px; margin-right: 20px;"
                                            class="btn btn-primary" OnClick="BtnDirectPurchase_Click" />
                                    </fieldset>
                                </div>

                                <div class="col-md-5">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                PO No.
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtOrderNo" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                PO Date
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtOrderDate" CssClass="form-control" runat="server" AutoPostBack="true"
                                                    OnTextChanged="txtOrderDate_TextChanged"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtOrderDate"
                                                    PopupButtonID="txtOrderDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Item
                                            </div>
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="ddlGoodsType" AutoPostBack="true" CssClass="form-control" runat="server"
                                                    Visible="false" OnSelectedIndexChanged="ddlGoodsType_SelectedIndexChanged">
                                                    <asp:ListItem Value="FixedAsset">Fixed Asset</asp:ListItem>
                                                    <asp:ListItem Value="ConsumableProduct" Selected="True">Consumable Product</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:TextBox ID="txtProduct" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Purchase Qty
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtPurchaseQty" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </fieldset>
                    </div>

                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
