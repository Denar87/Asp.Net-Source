<%@ Page Title="" Language="C#" MasterPageFile="~/Procurement/Site.Master" AutoEventWireup="true"
    CodeBehind="WorkOrder.aspx.cs" Inherits="ERPSSL.Procurement.WorkOrder" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
               
                <div class="hm_sec_2_content scrollbar">
                     <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="glyphicon glyphicon-edit icon-padding"></i>Purchase Order
                    </div>
                </div>

                    <div class="col-md-12 bg-success">
                        <center>
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label></center>
                    </div>
                    <fieldset style="border: none;">
                        <div class="col-md-12">
                            <div class="col-md-6">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Purchase Order
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="ddlPurchaseOrder" CssClass="form-control" runat="server" AutoPostBack="True"
                                                OnSelectedIndexChanged="ddlPurchaseOrder_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlPurchaseOrder"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select a Purchase Order"
                                                InitialValue="0" Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
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
                                            <asp:DropDownList ID="ddlProduct" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged"
                                                runat="server">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlProduct"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select an Item"
                                                InitialValue="0" Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Supplier
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="ddlSupplier" CssClass="form-control" runat="server">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlSupplier"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select a Supplier"
                                                InitialValue="0" Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Remarks
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtRemarks" CssClass="form-control" runat="server" TextMode="MultiLine"
                                                Height="100px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtRemarks"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Enter Remarks"
                                                Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row ">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                        </div>
                                        <div class="col-md-7">
                                            <asp:Button ID="btnOrderWork" runat="server" Text="Issue Purchase Order" ValidationGroup="Group1"
                                                Style="margin-top: 6px; margin-right: 20px;" class="btn btn-info pull-right" OnClick="btnOrderWork_Click" />
                                        </div>
                                    </div>
                                </div>
                                <br />
                            </div>
                            <div class="col-md-6">
                                <fieldset style="border: 1px solid #e5e5e5">
                                    <legend style="line-height: 0; line-height: 0; font-weight: bold; font-size: 12px"><span
                                        style="background: #fff">Bidders</span></legend>
                                    <asp:GridView ID="grdQuotations" runat="server" AutoGenerateColumns="False" Width="100%"
                                        CellPadding="4" BackColor="White" BorderColor="#336666" BorderStyle="Solid" BorderWidth="1px"
                                        GridLines="Both">
                                        <Columns>
                                            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="false"></asp:BoundField>
                                            <asp:BoundField DataField="QtNo" HeaderText="Quotation No." SortExpression="QtNo"></asp:BoundField>
                                            <asp:BoundField DataField="SupplierName" HeaderText="Supplier" SortExpression="SupplierName"></asp:BoundField>
                                            <asp:BoundField DataField="ProductName" HeaderText="Item" SortExpression="ProductName"></asp:BoundField>
                                            <asp:BoundField DataField="CPU" HeaderText="CPU" SortExpression="CPU"></asp:BoundField>
                                            <asp:BoundField DataField="OrderedQty" HeaderText="Ordered Qty" SortExpression="OrderedQty"></asp:BoundField>
                                            <asp:BoundField DataField="TotalPrice" HeaderText="Total Price" SortExpression="TotalPrice"></asp:BoundField>
                                        </Columns>
                                        <EmptyDataRowStyle ForeColor="Red" />
                                        <RowStyle CssClass="Grid_RowStyle" BackColor="White" ForeColor="#333333" HorizontalAlign="Center" />
                                        <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                        <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#336666" />
                                        <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" BackColor="#336666"
                                            Font-Bold="True" ForeColor="White" />
                                        <FooterStyle CssClass="Grid_Footer" BackColor="White" ForeColor="#333333" />
                                        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                        <SortedAscendingHeaderStyle BackColor="#487575" />
                                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                        <SortedDescendingHeaderStyle BackColor="#275353" />
                                    </asp:GridView>
                                </fieldset>
                                <br />
                            </div>
                        </div>
                        <div class="col-md-12">
                            <asp:UpdatePanel ID="UpdatePanelSubmit" runat="server">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnWorkOrderDone" />
                                </Triggers>
                                <ContentTemplate>
                                    <asp:Button ID="btnWorkOrderDone" runat="server" Style="margin-top: 6px; margin-right: 20px;"
                                        class="btn btn-primary" Text="Send Purchase Order" OnClick="btnWorkOrderDone_Click" />
                                    <asp:Label ID="lblWorkOrder" runat="server" Text="" Font-Size="13px"></asp:Label>
                                    <br />
                                    <asp:UpdateProgress runat="server" ID="UpdateProgress1">
                                        <ProgressTemplate>
                                            Sending email to the selected supplier. Please wait ...
                                            <img alt="Please wait ... loading ..." src="img/ajax_loading.gif" />
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                    <br />
                                    <rsweb:ReportViewer ID="ReportViewer2" AsyncRendering="False" InteractiveDeviceInfos="(Collection)"
                                        SizeToReportContent="True" Width="100%" Height="700px" runat="server" Font-Names="Verdana"
                                        Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" BackColor="White">
                                    </rsweb:ReportViewer>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </fieldset>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
