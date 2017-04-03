<%@ Page Title="" Language="C#" MasterPageFile="~/Production/Production.Master" AutoEventWireup="true" CodeBehind="Finishing.aspx.cs" Inherits="ERPSSL.Production.Finishing" %>

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
                        <i class="fa fa-edit fa-fw icon-padding"></i>Finishing
                    </div>
                </div>
                <div class="row" style="padding-top: 5px; margin: 0 auto">
                    <div class="col-md-12 bg-success">
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </div>
                    <div class="col-md-12" style="margin: 0 auto;">
                        <div class="col-md-4" style="padding-top: 10px; padding: 0;">
                            <div class="row">
                                <asp:TextBox ID="txtFillOrderNo" placeholder="Enter a Order No" CssClass="form-control" AutoPostBack="true"
                                    OnTextChanged="txtFillOrderNo_TextChanged" runat="server"></asp:TextBox>
                                <cc1:AutoCompleteExtender ServiceMethod="SearchAllOrderNo"
                                    MinimumPrefixLength="1"
                                    CompletionInterval="100" EnableCaching="False"
                                    TargetControlID="txtFillOrderNo"
                                    ID="AutoCompleteExtender2" runat="server" DelimiterCharacters="" Enabled="True" ServicePath="">
                                </cc1:AutoCompleteExtender>
                            </div>

                            <div class="row">
                                <div style="z-index: 1; height: 160px; width: 100%; overflow: scroll; margin-right: -40px;">
                                    <div class="row">
                                        <asp:GridView ID="grdWashingDetails" runat="server" AutoGenerateColumns="False"
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
                                                        <asp:Label ID="lblTotalWashingCompleteQty" runat="server" Text='<%# Eval("TotalWashingCompleteQty")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTotalWashingCompleteUnit" runat="server" Text='<%# Eval("TotalWashingCompleteUnit")%>' />
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
                                                        <asp:ImageButton ID="imgbtnWashingDetails" runat="server" ImageUrl="~/img/Details3.png" OnClick="imgbtnWashingDetails_Click" />
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
                                                <asp:TextBox ID="txtFinishGoodsQty" ReadOnly="true" Width="110%" runat="server" placeholder="Goods Qty." CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-md-4" style="margin-left: -9px;">
                                                <asp:TextBox ID="txtFinishGoodsUnits" ReadOnly="true" runat="server" Width="110%" placeholder="Goods Unit" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-6" style="padding: 0; padding-top: 5px;" runat="server" id="div1">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                Washing Complete Qty.
                                            </div>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtCCompleteWashingQty" runat="server" ReadOnly="true" Width="110%" Placeholder="Washing Qty."
                                                    CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-md-4" style="margin-left: -9px;">
                                                <asp:TextBox ID="txtCCompleteWashingunit" runat="server" ReadOnly="true" Width="110%" Placeholder="Washing Unit."
                                                    CssClass="form-control"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6" style="padding: 0; padding-top: 5px; visibility: hidden;">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                            </div>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="TextBox1" ReadOnly="true" Width="110%" runat="server" placeholder="Received Goods Qty." CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-md-4" style="margin-left: -9px;">
                                                <asp:TextBox ID="TextBox2" ReadOnly="true" runat="server" Width="110%" placeholder="Received Goods Units" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6" style="padding: 0; padding-top: 5px;" runat="server">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                Finishing Received Date
                                            </div>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtFinishingReceivedDate" runat="server" placeholder="MM/dd/yyyy" CssClass="form-control"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFinishingReceivedDate"
                                                    PopupButtonID="txtFinishingReceivedDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFinishingReceivedDate"
                                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Complete Date"
                                                    Font-Size="11px" ValidationGroup="vlSewing"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6" style="padding: 0; padding-top: 5px;">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                Finishing Received Qty.
                                            </div>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtFinishingReceivedQty" runat="server" Width="110%" placeholder="Finishing Received Qty." CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFinishingReceivedQty"
                                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Sewing Qty?"
                                                    Font-Size="11px" ValidationGroup="vlSewing"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-md-4" style="margin-left: -9px;">
                                                <asp:DropDownList ID="ddlFFinishingUnit" Width="110%" runat="server" CssClass="form-control">
                                                    <asp:ListItem>--Select Unit--</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlFFinishingUnit"
                                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Unit."
                                                    Font-Size="11px" ValidationGroup="vlSewing"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-6" style="padding: 0; padding-top: 5px;" runat="server" id="divCCDShow" visible="false">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                Finishing Complete Date
                                            </div>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtFinishingCompleteDate" runat="server" placeholder="MM/dd/yyyy" CssClass="form-control"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFinishingCompleteDate"
                                                    PopupButtonID="txtFinishingCompleteDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFinishingCompleteDate"
                                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Complete Date"
                                                    Font-Size="11px" ValidationGroup="vlSewing"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6" style="padding: 0; padding-top: 5px;" runat="server" id="divCCQShow" visible="false">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                Complete Finishing Qty.
                                            </div>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtCCompleteFinishingQty" runat="server" Width="110%" Placeholder="Complete Cutting Qty."
                                                    CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCCompleteFinishingQty"
                                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Sewing Qty"
                                                    Font-Size="11px" ValidationGroup="vlSewing"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-md-4" style="margin-left: -9px;">
                                                <asp:DropDownList ID="ddlTUnits" Width="110%" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlTUnits"
                                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Unit."
                                                    Font-Size="11px" ValidationGroup="vlSewing"></asp:RequiredFieldValidator>
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
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" ValidationGroup="vlSewing" class="btn btn-info pull-right" OnClick="btnSubmit_Click" />
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
                                    runat="server"></asp:TextBox>
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
                                                    <asp:Label ID="lblTotalWashingCompleteQty" runat="server" Text='<%# Eval("TotalWashingCompleteQty")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTotalWashingCompleteUnit" runat="server" Text='<%# Eval("TotalWashingCompleteUnit")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <%--<asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTotalSewingCompleteUnit" runat="server" Text='<%# Eval("TotalSewingCompleteUnit")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>

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

                                            <%-- <asp:BoundField DataField="FGoodsQty" HeaderText="Finish Goods Qty">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>--%>

                                            <asp:TemplateField HeaderText="Finish Goods Qty">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFinishGoodsQtyFill" runat="server" Text='<%# Eval("FGoodsQty")+", "+Eval("FGoodsUnit")%>' />
                                                </ItemTemplate>
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:TemplateField>

                                            <%--<asp:BoundField DataField="FGoodsUnit" HeaderText="Finish Goods Unit">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>--%>

                                            <%--<asp:BoundField DataField="TotalCuttingCompleteQty" HeaderText="Cutting Complete Qty">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>--%>

                                            <asp:TemplateField HeaderText="Washing Complete Qty">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTotalWashingCompleteQtyFill" runat="server" Text='<%# Eval("TotalWashingCompleteQty")+", "+Eval("TotalWashingCompleteUnit")%>' />
                                                </ItemTemplate>
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:TemplateField>

                                            <%--<asp:BoundField DataField="TotalCuttingCompleteUnit" HeaderText=" Cutting Complete Unit">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>--%>

                                            <asp:BoundField DataField="TotalFinishingReceivedDate" HeaderText="Finishing Received Date">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>

                                            <%--  <asp:BoundField DataField="TotalSewingReceivedQty" HeaderText="Sewing Received Qty">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>--%>

                                            <asp:TemplateField HeaderText="Finishing Received Qty">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTotalSewingReceivedQtyFill" runat="server" Text='<%# Eval("TotalFinishingReceivedQty")+", "+Eval("UnitName")%>' />
                                                </ItemTemplate>
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:TemplateField>

                                            <%--<asp:BoundField DataField="UnitName" HeaderText="Total Complete Unit">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>--%>

                                            <asp:BoundField DataField="TotalFinishingCompleteDate" HeaderText="Finishing Complete Date">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>

                                            <%--<asp:BoundField DataField="TotalSewingCompleteQty" HeaderText="Sewing Complete Qty">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>--%>

                                            <asp:TemplateField HeaderText="Finishing Complete Qty">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTotalSewingCompleteQtyFill" runat="server" Text='<%# Eval("TotalFinishingCompleteQty")+", "+Eval("UnitName")%>' />
                                                </ItemTemplate>
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:TemplateField>

                                            <%--<asp:BoundField DataField="UnitName" HeaderText=" Sewing Complete Unit">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>--%>

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
            else if (result === 'Data Updated Successfully') {
                toastr.success(result);
            }
            else {
                toastr.error(result);
            }
            return false;
        }
    </script>

</asp:Content>
