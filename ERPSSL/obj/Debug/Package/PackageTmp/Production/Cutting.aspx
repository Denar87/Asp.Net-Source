<%@ Page Title="" Language="C#" MasterPageFile="~/Production/Production.Master" AutoEventWireup="true" CodeBehind="Cutting.aspx.cs" Inherits="ERPSSL.Production.Cutting" %>

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
                        <i class="fa fa-edit fa-fw icon-padding"></i>Cutting
                    </div>
                </div>
                <div class="row" style="padding-top: 5px; margin: 0 auto">
                    <div class="col-md-12 bg-success">
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </div>
                    <div class="col-md-12" style="margin: 0 auto;">
                        <div class="col-md-4" style="padding-top: 10px; padding: 0;">
                            <div class="row">
                                <asp:TextBox ID="txtOrderNo" placeholder="Enter a Order No" CssClass="form-control" AutoPostBack="true"
                                    OnTextChanged="txtOrderNo_TextChanged" runat="server"></asp:TextBox>
                                <cc1:AutoCompleteExtender ServiceMethod="SearchAllOrderNo"
                                    MinimumPrefixLength="1"
                                    CompletionInterval="100" EnableCaching="False"
                                    TargetControlID="txtOrderNo"
                                    ID="AutoCompleteExtender2" runat="server" DelimiterCharacters="" Enabled="True" ServicePath="">
                                </cc1:AutoCompleteExtender>
                            </div>

                            <div class="row">
                                <div style="z-index: 1; height: 160px; width: 100%; overflow: scroll; margin-right: -40px;">
                                    <div class="row">
                                        <asp:GridView ID="grdOrderDetails" runat="server" AutoGenerateColumns="False"
                                            Width="100%" CellPadding="5" AllowPaging="false">
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
                                                        <asp:Label ID="lblProductUnits" runat="server" Text='<%# Eval("UnitName")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLc_OrderUnits" runat="server" Text='<%# Eval("Lc_Order")%>' />
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
                        <div class="col-md-8" style="padding: 0;">
                            <div class="row" style="padding: 0;">
                                <div class="col-md-6" style="padding: 0;">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                Order No.
                                            </div>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtOrderNoFill" runat="server" ReadOnly="true" placeholder="Order No." CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtOrderNoFill"
                                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Order No."
                                                    Font-Size="11px" ValidationGroup="vlCutting"></asp:RequiredFieldValidator>
                                                <asp:HiddenField ID="txthidID" runat="server" />
                                                <asp:HiddenField ID="txthidBuyer" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6" style="padding: 0; padding-top: 5px;">
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
                                                <asp:TextBox ID="txtFinishGoodsQty" ReadOnly="true" Width="110%" runat="server" placeholder="Finish Goods Qty." CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-md-4" style="margin-left: -9px;">
                                                <asp:TextBox ID="txtUnits" ReadOnly="true" runat="server" Width="110%" placeholder="Units" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6" style="padding: 0; padding-top: 5px;">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                Cutting Received Date
                                            </div>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtCuttingReceivedDate" runat="server" placeholder="MM/dd/yyyy" CssClass="form-control"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtCuttingReceivedDate"
                                                    PopupButtonID="txtCuttingReceivedDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6" style="padding: 0; padding-top: 5px;">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                Cutting Received Qty.
                                            </div>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtCuttingReceivedQty" runat="server" Width="110%" placeholder="Cutting Received Qty." CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCuttingReceivedQty"
                                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Received Qty?"
                                                    Font-Size="11px" ValidationGroup="vlCutting"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-md-4" style="margin-left: -9px;">
                                                <asp:DropDownList ID="ddlUnit" Width="110%" runat="server" CssClass="form-control">
                                                    <asp:ListItem>--Select Unit--</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlUnit"
                                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Unit."
                                                    Font-Size="11px" ValidationGroup="vlCutting"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%--<div class="col-md-6" style="padding: 0; padding-top: 5px;" runat="server" visible="false">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                Total Complete Qty
                                            </div>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtCompleteQty" runat="server" ReadOnly="true" placeholder="Total Complete Qty" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCompleteQty"
                                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Total Complete Qty"
                                                    Font-Size="11px" ValidationGroup="vlCutting"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                </div>--%>
                                <div class="col-md-6" style="padding: 0; padding-top: 5px;" runat="server" id="divCCDShow" visible="false">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                Cutting Complete Date
                                            </div>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtCuttingCompleteDate" runat="server" placeholder="MM/dd/yyyy" CssClass="form-control"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtCuttingCompleteDate"
                                                    PopupButtonID="txtCuttingCompleteDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtCuttingCompleteDate"
                                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Complete Date"
                                                    Font-Size="11px" ValidationGroup="vlCutting"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6" style="padding: 0; padding-top: 5px;" runat="server" id="divCCQShow" visible="false">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                Complete Cutting Qty.
                                            </div>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtCCompleteCuttingQty" runat="server" Width="110%" Placeholder="Complete Cutting Qty."
                                                    CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCCompleteCuttingQty"
                                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Complete Cutting Qty"
                                                    Font-Size="11px" ValidationGroup="vlCutting"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-md-4" style="margin-left: -9px;">
                                                <asp:DropDownList ID="ddlTUnits" Width="110%" runat="server" CssClass="form-control">
                                                    <asp:ListItem>--Select Unit--</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlTUnits"
                                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Unit."
                                                    Font-Size="11px" ValidationGroup="vlCutting"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12" style="padding-top: 5px;">
                        <div class="col-md-6">
                        </div>
                        <div class="col-md-6" style="margin-left: 0px;">
                            <div class="row">
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" ValidationGroup="vlCutting" class="btn btn-info pull-right" OnClick="btnSubmit_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12" style="padding-top: 5px; margin: auto 0;">
                        <div class="row" style="background-color: #aeabab">
                            <div class="col-md-3">
                                <h4>Search By Order No.</h4>
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="TextOrderNo4Cutting" placeholder="Enter a Order No" CssClass="form-control" AutoPostBack="true"
                                    OnTextChanged="TextOrderNo4Cutting_TextChanged" runat="server"></asp:TextBox>
                                <cc1:AutoCompleteExtender ServiceMethod="SearchAllOrderNoCutting"
                                    MinimumPrefixLength="1"
                                    CompletionInterval="100" EnableCaching="False"
                                    TargetControlID="TextOrderNo4Cutting"
                                    ID="AutoCompleteExtender1" runat="server" DelimiterCharacters="" Enabled="True" ServicePath="">
                                </cc1:AutoCompleteExtender>
                            </div>
                            <div class="col-md-6">
                            </div>
                        </div>
                        <div class="row">
                            <div style="z-index: 1; height: 160px; width: 100%; overflow: scroll; margin-right: -40px;">
                                <div class="row">
                                    <asp:GridView ID="grdCuttingDetails" runat="server" AutoGenerateColumns="False"
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
                                                    <asp:Label ID="lblCuttingReceivedDate" runat="server" Text='<%# Eval("CuttingReceivedDate")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCuttingReceivedQty" runat="server" Text='<%# Eval("CuttingReceivedQty")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCuttingReceivedUnit" runat="server" Text='<%# Eval("CuttingReceivedUnit")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCuttingCompleteDate" runat="server" Text='<%# Eval("CuttingCompleteDate")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTotalCuttingCompleteQty" runat="server" Text='<%# Eval("TotalCuttingCompleteQty")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTotalCuttingCompleteUnit" runat="server" Text='<%# Eval("TotalCuttingCompleteUnit")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:BoundField DataField="OrderNo" HeaderText="Order No">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Center" Width="7%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="OrderQty" HeaderText="Order Qty">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="7%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="GoodsName" HeaderText="Finish Goods">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="7%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="FGoodsQty" HeaderText="Finish Goods Qty">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <%--<asp:TemplateField HeaderText="Finish Goods Qty">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTotalCuttingCompleteQty" runat="server" Text='<%# Eval("FGoodsQty")+" "+Eval("FGoodsUnit")%>' />
                                                </ItemTemplate>
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:TemplateField>--%>

                                            <asp:BoundField DataField="FGoodsUnit" HeaderText="Finish Goods Unit">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="CuttingReceivedDate" HeaderText="Received Date">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="CuttingReceivedQty" HeaderText=" Received Qty">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="UnitName" HeaderText="Unit">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="CuttingCompleteDate" HeaderText="Cutting Complete Date">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="TotalCuttingCompleteQty" HeaderText="Total Complete Qty">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            
                                            <asp:BoundField DataField="UnitName" HeaderText="Total Complete Unit">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>

                                            <asp:TemplateField HeaderText="Edit">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgbtnCuttingDetails" runat="server" ImageUrl="~/img/Details3.png" OnClick="imgbtnCuttingDetails_Click" />
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
            else {
                toastr.error(result);
            }
            return false;
        }
    </script>

</asp:Content>
