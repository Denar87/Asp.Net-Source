<%@ Page Title="" Language="C#" MasterPageFile="~/INV/Site.Master" AutoEventWireup="true"
    CodeBehind="RecieveByQuotation.aspx.cs" Inherits="ERPSSL.INV.RecieveByQuotation" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <asp:HiddenField ID="hdnId" runat="server" />
                <asp:HiddenField ID="hdnBarCode" runat="server" />
                <asp:HiddenField ID="HiddenProductGroup" runat="server" />
                <asp:HiddenField ID="HiddenCompanyCode" runat="server" />
                <asp:HiddenField ID="HiddenCompanyName" runat="server" />
                <asp:HiddenField ID="hdnSupCode" runat="server" />
                <div class="hm_sec_2_content scrollbar">
                    <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="glyphicon glyphicon-edit icon-padding"></i>Material Recieve Report(MRR)-Through
                        Tender
                    </div>
                </div>
                    <div class="col-md-12 bg-success">
                        <center>
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label></center>
                    </div>
                    <div class="row">
                        <fieldset style="border: none;">
                            <div class="col-md-12">
                                <div class="col-md-7">
                                    <fieldset style="border: none">
                                        <asp:GridView ID="gvPurchase" runat="server" AutoGenerateColumns="False" Width="100%"
                                            CellPadding="4" GridLines="Both" DataKeyNames="Id" BackColor="White" BorderColor="#336666"
                                            BorderStyle="Solid" BorderWidth="1px" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvPurchase_SelectedIndexChanged" AllowPaging="True">
                                            <Columns>
                                                <%--<asp:TemplateField HeaderText="Select">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgbtnEdit" runat="server" CommandArgument='<%# Eval("Id") %>'
                                                            CommandName="select" ImageUrl="img/edit.png" />
                                                    </ItemTemplate>
                                                    <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                                                </asp:TemplateField>--%>
                                                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="true"></asp:BoundField>
                                                <asp:BoundField DataField="PrOrderNo" HeaderText="Pr.Order No." SortExpression="PrOrderNo">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ProductName" HeaderText="Item" SortExpression="Product"></asp:BoundField>
                                                <asp:BoundField DataField="BarCode" HeaderText="Barcode" SortExpression="BarCode"></asp:BoundField>
                                                <asp:BoundField DataField="OrderedQty" HeaderText="Ordered Qty" SortExpression="OrderedQty" />
                                            </Columns>
                                            <EmptyDataRowStyle ForeColor="Red" />
                                            <RowStyle CssClass="Grid_RowStyle" BackColor="White" ForeColor="#333333" HorizontalAlign="Center" />
                                            <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                            <PagerSettings Mode="NumericFirstLast" />
                                            <PagerStyle ForeColor="White" HorizontalAlign="Left" BackColor="#336666" CssClass="pagination01 pageback" />
                                            <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" BackColor="#336666"
                                                Font-Bold="True" ForeColor="White" />
                                            <FooterStyle CssClass="Grid_Footer" BackColor="White" ForeColor="#333333" />
                                            <SelectedRowStyle BackColor="Silver" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                            <SortedAscendingHeaderStyle BackColor="#487575" />
                                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                            <SortedDescendingHeaderStyle BackColor="#275353" />
                                        </asp:GridView>
                                    </fieldset>
                                </div>
                                <div class="col-md-5">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                MRR No.
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtChalanNo" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
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
                                                <asp:TextBox ID="txtSupplier" CssClass="form-control" runat="server" ReadOnly="true"
                                                    AutoPostBack="true"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <%--<div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Supplier
                                            </div>
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="ddlSupplier" Class="form-control" runat="server" AutoPostBack="True" ReadOnly="true"
                                                    OnSelectedIndexChanged="ddlSupplier_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <br />--%>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Date
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox Class="form-control" runat="server" ID="txtDate" autocomplete="off"
                                                    placeholder="MM/dd/yyyy" OnTextChanged="txtDate_TextChanged"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtDate"
                                                    Display="Dynamic" ErrorMessage="Select Date" ForeColor="Red" SetFocusOnError="True"
                                                    Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate"
                                                    PopupButtonID="Image_AT" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
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
                                                <asp:TextBox ID="txtPOrderNo" CssClass="form-control" runat="server" Visible="false"></asp:TextBox>
                                                <asp:TextBox ID="txtProduct" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Unit
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtUnit" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Brand
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtBrand" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <%--<div class="row" style="display: none">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Bal QTY
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtBalQTY" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />--%>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Ordered QTY
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtOrderQTY" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Rec Qty
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtRecQty" CssClass="form-control" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtRecQty"
                                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Enter Recieve Qty"
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
                                                <asp:Button ID="BtnSave" runat="server" Text="Post" ValidationGroup="Group1" Style="margin-top: 6px; margin-right: 20px;"
                                                    class="btn btn-info pull-right" OnClick="BtnSave_Click" />
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row" style="display: none;">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Store
                                            </div>
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="ddlCompanyCode" Class="form-control" runat="server" AutoPostBack="True">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                </div>
                            </div>
                            <div class="col-md-12">
                                <rsweb:ReportViewer ID="ReportViewerPurchase" AsyncRendering="False" InteractiveDeviceInfos="(Collection)"
                                    SizeToReportContent="True" Width="100%" Height="700px" runat="server" Font-Names="Verdana"
                                    Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" BackColor="White">
                                </rsweb:ReportViewer>
                            </div>
                        </fieldset>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script>

        function func(result) {
            if (result === 'Purchase information posted successfully') {
                toastr.success(result);

            }
           

            
           
            else
                toastr.error(result);

            return false;
        }

   </script>
</asp:Content>
