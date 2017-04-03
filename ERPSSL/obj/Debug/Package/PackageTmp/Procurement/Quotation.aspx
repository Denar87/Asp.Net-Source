<%@ Page Title="" Language="C#" MasterPageFile="~/Procurement/Site.Master" AutoEventWireup="true"
    CodeBehind="Quotation.aspx.cs" Inherits="ERPSSL.Procurement.Quotation" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

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
                        <i class="glyphicon glyphicon-edit icon-padding"></i>Tender Quotation Collection
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
                                            Purchase Order No.
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="ddlPurchaseOrder" AutoPostBack="true" CssClass="form-control"
                                                runat="server" OnSelectedIndexChanged="ddlPurchaseOrder_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ValidationGroup="ADDR" ControlToValidate="ddlPurchaseOrder"
                                                SetFocusOnError="True" ID="RequiredFieldValidator6" runat="server" ErrorMessage="*"
                                                Font-Size="11px" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>
                                            <asp:RequiredFieldValidator ValidationGroup="ADD" ControlToValidate="ddlPurchaseOrder"
                                                SetFocusOnError="True" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Select a Purchase Order"
                                                Font-Size="11px" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>
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
                                            <asp:DropDownList ID="ddlSupplier" AutoPostBack="true" CssClass="form-control" runat="server"
                                                OnSelectedIndexChanged="ddlSupplier_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ValidationGroup="ADD" ControlToValidate="ddlSupplier"
                                                SetFocusOnError="True" ID="RequiredFieldValidator7" runat="server" ErrorMessage="Select a Supplier"
                                                Font-Size="11px" ForeColor="Red" InitialValue="0">
                                            </asp:RequiredFieldValidator>
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
                                            <asp:DropDownList ID="ddlProduct" AutoPostBack="true" CssClass="form-control" runat="server"
                                                OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ValidationGroup="ADD" ControlToValidate="ddlProduct"
                                                SetFocusOnError="True" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Select an Item"
                                                Font-Size="11px" ForeColor="Red" InitialValue="0">
                                            </asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            CPU
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtCPU" CssClass="form-control" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ValidationGroup="ADD" ControlToValidate="txtCPU" SetFocusOnError="True"
                                                ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Cost Per Unit"
                                                Font-Size="11px" ForeColor="Red"> </asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Ordered Qty
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtOrderedQty" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Quotation No.
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtQuotationNo" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Date
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtQuotationDate" CssClass="form-control" runat="server" AutoPostBack="true"
                                                OnTextChanged="txtQuotationDate_TextChanged"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtQuotationDate"
                                                PopupButtonID="txtQuotationDate" Format="MM/dd/yyyy" CssClass="ajax__calendar"
                                                Enabled="True" />
                                            <asp:RequiredFieldValidator ValidationGroup="ADD" ControlToValidate="txtQuotationDate"
                                                SetFocusOnError="True" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Select Date"
                                                Font-Size="11px" ForeColor="Red">
                                            </asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="row ">
                                    <div class="col-md-5">
                                    </div>
                                    <div class="col-md-7">
                                        <asp:Button ID="BtnAddQuotation" runat="server" Text="Add Quotation" Style="margin-top: 15px; margin-right: 20px;"
                                            ValidationGroup="ADD" class="btn btn-info pull-right" OnClick="BtnAddQuotation_Click" />
                                        <asp:Button ID="BtnReport" runat="server" Text="Report" Style="margin-top: 15px; margin-right: 20px;"
                                            class="btn btn-warning" OnClick="BtnReport_Click" ValidationGroup="ADDR" />
                                    </div>
                                    <br />
                                </div>
                                <br />
                            </div>
                            <div class="col-md-6">
                                <fieldset style="border: 1px solid #e5e5e5">
                                    <legend style="line-height: 0; line-height: 0; font-weight: bold; font-size: 12px"><span
                                        style="background: #fff">Select Purchase order No.</span></legend>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Purchase Order No.
                                            </div>
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="ddlPurchaseOrderReport" AutoPostBack="true" CssClass="form-control"
                                                    runat="server">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ValidationGroup="GENREPORT" ControlToValidate="ddlPurchaseOrderReport"
                                                    SetFocusOnError="True" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Select a Purchase Order"
                                                    Font-Size="11px" ForeColor="Red" InitialValue="0">
                                                </asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row ">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                            </div>
                                            <div class="col-md-7">
                                                <asp:Button ID="BtnGenerateReport" runat="server" Text="Generate Report" Style="margin-top: 15px; margin-right: 20px;"
                                                    class="btn btn-info pull-right" OnClick="BtnGenerateReport_Click" ValidationGroup="GENREPORT" />
                                            </div>
                                        </div>
                                    </div>
                                </fieldset>
                                <fieldset style="border: none;">
                                    <asp:GridView ID="grdQuotations" runat="server" AutoGenerateColumns="False" Width="100%"
                                        CellPadding="4" BackColor="White" BorderColor="#336666" BorderStyle="Solid" BorderWidth="1px"
                                        GridLines="Both">
                                        <Columns>
                                            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="false"></asp:BoundField>
                                            <asp:BoundField DataField="QtNo" HeaderText="Quotation No." SortExpression="QtNo"></asp:BoundField>
                                            <asp:BoundField DataField="SupplierName" HeaderText="Supplier Name" SortExpression="SupplierName"></asp:BoundField>
                                            <asp:BoundField DataField="ProductName" HeaderText="Item Name" SortExpression="ProductName"></asp:BoundField>
                                            <asp:BoundField DataField="CPU" HeaderText="CPU" SortExpression="CPU"></asp:BoundField>
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
                            </div>
                        </div>
                        <div class="col-md-12">
                            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" AsyncRendering="False"
                                InteractiveDeviceInfos="(Collection)" SizeToReportContent="True" Font-Names="Verdana"
                                Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" BackColor="White">
                            </rsweb:ReportViewer>
                        </div>
                    </fieldset>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
