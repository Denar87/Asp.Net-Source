<%@ Page Title="" Language="C#" MasterPageFile="~/Procurement/Site.Master" AutoEventWireup="true"
    CodeBehind="PurchaseOrderApproval.aspx.cs" Inherits="ERPSSL.Procurement.PurchaseOrderApproval" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <asp:UpdatePanel ID="UpdatePanelSubmit" runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnApprove" />
        </Triggers>
        <ContentTemplate>
            <div class="row">

                <div class="hm_sec_2_content scrollbar">
                     <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="glyphicon glyphicon-edit icon-padding"></i>Requisition wise Purchase Order Approval
                    </div>
                </div>
                    <div class="col-md-12 bg-success">
                        <center>
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label></center>
                    </div>
                    <fieldset style="border: none;">
                        <div class="col-md-12" style="display: none;">
                            <div class="col-md-5">
                                Purchase Order
                            </div>
                            <div class="col-md-7">
                                <asp:DropDownList ID="ddlPurchaseOrder" AutoPostBack="true" CssClass="form-control"
                                    runat="server" OnSelectedIndexChanged="ddlPurchaseOrder_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="col-md-4">
                                <fieldset style="border: 1px solid #e5e5e5">
                                    <legend style="line-height: 0; font-weight: bold; font-size: 12px"><span style="background: #fff">Pending Requests List</span></legend>
                                    <asp:GridView ID="grdPendingPurchaseOrders" runat="server" AutoGenerateColumns="False"
                                        Width="90%" ShowHeaderWhenEmpty="true" OnSelectedIndexChanged="grdPendingPurchaseOrders_SelectedIndexChanged"
                                        BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px"
                                        CellPadding="3" CellSpacing="2">
                                        <Columns>
                                            <asp:BoundField DataField="PrOrderNo" HeaderText="Pr. Order No" SortExpression="PrOrderNo" />
                                            <asp:BoundField DataField="OrderDate" HeaderText="Order Date" SortExpression="OrderDate" DataFormatString="{0:dd/MM/yyyy}" />
                                            <asp:CommandField ShowSelectButton="True" />
                                        </Columns>
                                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                        <EmptyDataRowStyle ForeColor="Red" />
                                        <RowStyle CssClass="Grid_RowStyle" BackColor="#FFF7E7" ForeColor="#8C4510" HorizontalAlign="Center" />
                                        <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                        <HeaderStyle Width="20%" VerticalAlign="Middle" CssClass="Grid_Header" BackColor="#A55129"
                                            Font-Bold="True" ForeColor="White" />
                                        <FooterStyle CssClass="Grid_Footer" BackColor="#F7DFB5" ForeColor="#8C4510" />
                                        <SortedAscendingCellStyle BackColor="#FFF1D4" />
                                        <SortedAscendingHeaderStyle BackColor="#B95C30" />
                                        <SortedDescendingCellStyle BackColor="#F1E5CE" />
                                        <SortedDescendingHeaderStyle BackColor="#93451F" />
                                    </asp:GridView>
                                </fieldset>
                            </div>
                            <div class="col-md-4">
                                <fieldset style="border: 1px solid #e5e5e5">
                                    <legend style="line-height: 0; font-weight: bold; font-size: 12px"><span style="background: #fff">Item List</span></legend>
                                    <asp:GridView ID="grdPurchaseOrderToApprove" runat="server" AutoGenerateColumns="False"
                                        BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px"
                                        ShowHeaderWhenEmpty="true" CellPadding="3" GridLines="Both" DataKeyNames="Id"
                                        OnSelectedIndexChanged="grdPurchaseOrderToApprove_SelectedIndexChanged">
                                        <AlternatingRowStyle BackColor="#F7F7F7" />
                                        <Columns>
                                            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True"
                                                SortExpression="Id" />
                                            <asp:BoundField DataField="PrOrderNo" HeaderText="PrOrder No" SortExpression="PrOrderNo" />
                                            <asp:BoundField DataField="ProductName" HeaderText="Item" SortExpression="ProductName" />
                                            <asp:BoundField DataField="OrderedQty" HeaderText="Ordered Qty" SortExpression="OrderedQty" />
                                            <asp:BoundField DataField="OrderDate" HeaderText="Order Date" SortExpression="OrderDate" DataFormatString="{0:dd/MM/yyyy}" />
                                            <asp:ButtonField CommandName="Select" HeaderText="Action" ShowHeader="True" Text="Add" />
                                        </Columns>
                                        <SelectedRowStyle BackColor="#979DA1" Font-Bold="True" ForeColor="#F7F7F7" />
                                        <EmptyDataRowStyle ForeColor="Red" />
                                        <RowStyle CssClass="Grid_RowStyle" BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Center" />
                                        <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                        <PagerStyle ForeColor="#4A3C8C" HorizontalAlign="Right" BackColor="#E7E7FF" />
                                        <HeaderStyle Width="20%" VerticalAlign="Middle" CssClass="Grid_Header" BackColor="#4A3C8C"
                                            Font-Bold="True" ForeColor="#F7F7F7" />
                                        <FooterStyle CssClass="Grid_Footer" BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                                        <SortedAscendingCellStyle BackColor="#F4F4FD" />
                                        <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                                        <SortedDescendingCellStyle BackColor="#D8D8F0" />
                                        <SortedDescendingHeaderStyle BackColor="#3E3277" />
                                    </asp:GridView>
                                </fieldset>
                            </div>
                            <div class="col-md-4">
                                <fieldset style="border: 1px solid #e5e5e5">
                                    <legend style="line-height: 0; font-weight: bold; font-size: 12px"><span style="background: #fff">Approved Item List</span></legend>
                                    <asp:GridView ID="grdApproved" runat="server" AutoGenerateColumns="False" BackColor="White"
                                        BorderColor="#336666" BorderStyle="Solid" BorderWidth="1px" CellPadding="4"
                                        GridLines="Both" ShowHeaderWhenEmpty="true" DataKeyNames="Id" OnSelectedIndexChanged="grdApproved_SelectedIndexChanged">
                                        <AlternatingRowStyle />
                                        <Columns>
                                            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True"
                                                SortExpression="Id" />
                                            <asp:BoundField DataField="PrOrderNo" HeaderText="PrOrder No" SortExpression="PrOrderNo" />
                                            <asp:BoundField DataField="ProductName" HeaderText="Item" SortExpression="ProductName" />
                                            <asp:BoundField DataField="OrderedQty" HeaderText="Ordered Qty" SortExpression="OrderedQty" />
                                            <asp:BoundField DataField="OrderDate" HeaderText="Order Date" SortExpression="OrderDate" DataFormatString="{0:dd/MM/yyyy}" />
                                            <asp:ButtonField CommandName="Select" HeaderText="Action" ShowHeader="True" Text="Remove" />
                                        </Columns>
                                        <SelectedRowStyle BackColor="#A0B7AC" Font-Bold="True" ForeColor="White" />
                                        <EmptyDataRowStyle ForeColor="Red" />
                                        <RowStyle CssClass="Grid_RowStyle" BackColor="White" ForeColor="#333333" HorizontalAlign="Center" />
                                        <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                        <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#336666" />
                                        <HeaderStyle Width="20%" VerticalAlign="Middle" CssClass="Grid_Header" BackColor="#336666"
                                            Font-Bold="True" ForeColor="White" />
                                        <FooterStyle CssClass="Grid_Footer" BackColor="White" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                        <SortedAscendingHeaderStyle BackColor="#487575" />
                                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                        <SortedDescendingHeaderStyle BackColor="#275353" />
                                    </asp:GridView>
                                </fieldset>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <asp:Button ID="BtnApprove" runat="server" Text="Approve & Call For Tender" Style="margin-top: 15px; margin-right: 20px; float: right;"
                                    class="btn btn-info pull-right" OnClick="BtnApprove_Click" />
                                <div class="load_progress">
                                    <asp:UpdateProgress runat="server" ID="UpdateProgress1">
                                        <ProgressTemplate>
                                            Sending email to all enlisted suppliers. Please wait ...
                                    <img alt="Please wait. Sending email to all enlisted suppliers ... " src="img/ajax_loading.gif" />
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </div>
                            </div>
                        </div>
                    </fieldset>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
