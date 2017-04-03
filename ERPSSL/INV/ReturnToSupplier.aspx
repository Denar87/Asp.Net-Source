<%@ Page Title="" Language="C#" MasterPageFile="~/INV/Site.Master" AutoEventWireup="true"
    CodeBehind="ReturnToSupplier.aspx.cs" Inherits="ERPSSL.INV.ReturnToSupplier" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>
            <div class="row">
                <asp:HiddenField ID="hdnBarCode" runat="server" />
                <div class="hm_sec_2_content scrollbar">
                    <div class="panel">
                        <div class="panel-heading panel-heading-01">
                            <i class="glyphicon glyphicon-edit icon-padding"></i>Return To Supplier
                        </div>
                    </div>
                    <div class="col-md-12 bg-success">
                        <center>
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label></center>
                    </div>
                    <div class="row">
                        <fieldset style="border: none;">
                            <div class="col-md-12">
                                <div class="col-md-6">
                                    <div class="row" style="padding-bottom: 8px">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                Supplier To<a style="color: red; font-size: 11px">*</a>
                                            </div>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtDate" CssClass="form-control" runat="server"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtDate"
                                                    PopupButtonID="txtDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" style="padding-bottom: 8px">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                Store<a style="color: red; font-size: 11px">*</a>
                                            </div>
                                            <div class="col-md-8">
                                                <asp:DropDownList ID="ddlStore" AutoPostBack="true" CssClass="form-control" runat="server"
                                                    OnSelectedIndexChanged="ddlStore_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlStore"
                                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select a Store"
                                                    InitialValue="0" Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row" style="padding-bottom: 8px">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                Supplier To<a style="color: red; font-size: 11px">*</a>
                                            </div>
                                            <div class="col-md-8">

                                                <asp:TextBox ID="txtChalanNoReturn" CssClass="form-control" runat="server" ReadOnly="True" Visible="false"></asp:TextBox>
                                                <asp:DropDownList ID="ddlSupplierTo" AutoPostBack="true" CssClass="form-control"
                                                    runat="server" OnSelectedIndexChanged="ddlSupplierTo_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlSupplierTo"
                                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select a Supplier"
                                                    InitialValue="0" Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row" style="padding-bottom: 8px">
                                        <asp:HiddenField ID="hdfCompanyCode" runat="server" />
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                Item Group<a style="color: red; font-size: 11px">*</a>
                                            </div>
                                            <div class="col-md-8">
                                                <asp:DropDownList ID="ddlProductGroup" AutoPostBack="true" CssClass="form-control"
                                                    runat="server" OnSelectedIndexChanged="ddlProductGroup_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlProductGroup"
                                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select a Group"
                                                    InitialValue="0" Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row" style="padding-bottom: 8px">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                Item Description<a style="color: red; font-size: 11px">*</a>
                                            </div>
                                            <div class="col-md-8">
                                                <asp:DropDownList ID="ddlProduct" AutoPostBack="true" CssClass="form-control" runat="server"
                                                    OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlProduct"
                                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select an Item"
                                                    InitialValue="0" Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>

                                    <%--                      <div class="row" style="padding-bottom: 8px">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                Balance Qty
                                            </div>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtBalanceQty" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row" style="padding-bottom: 8px">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                Return Qty<a style="color: red; font-size: 11px">*</a>
                                            </div>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtReturnQty" CssClass="form-control" runat="server" AutoPostBack="true"
                                                    OnTextChanged="txtReturnQty_TextChanged"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtReturnQty"
                                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Enter Return Qty"
                                                    Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row" style="padding-bottom: 10px">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                Remaining Qty
                                            </div>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtRemainingQty" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>--%>
                                </div>


                                <div class="col-md-6" style="padding-top: 10px;">
                                    <fieldset>
                                        <legend style="line-height: 0; margin-bottom: 0"><span style="background: #fff">Item List</span></legend>
                                        <asp:GridView ID="GridShow" runat="server" Width="100%" AutoGenerateColumns="false"
                                            AllowSorting="true" CellPadding="5" BorderColor="#E3F0FC" BorderStyle="Solid"
                                            CssClass="Grid_Border" AllowPaging="True">
                                            <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                            <Columns>
                                                <asp:TemplateField ItemStyle-Width="2%">
                                                    <HeaderTemplate>
                                                        <asp:CheckBox runat="server" ID="headerLevelCheckBox" AutoPostBack="true" OnCheckedChanged="headerLevelCheckBox_CheckedChanged" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="rowLevelCheckBox" runat="server" AutoPostBack="true" OnCheckedChanged="rowLevelCheckBox_CheckedChanged" />
                                                    </ItemTemplate>
                                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                                    <FooterStyle CssClass="Grid_Footer" />
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblproductName" runat="server" Text='<%# Eval("ProductName")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBrand" runat="server" Text='<%# Eval("Brand")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStyleAndSize" runat="server" Text='<%# Eval("StyleSize")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSupplierReturnQty" runat="server" Text='<%# Eval("SupplierReturnQty")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCompanyId" runat="server" Text='<%# Eval("CompanyId")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCompanyName" runat="server" Text='<%# Eval("CompanyName")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblproductGroup" runat="server" Text='<%# Eval("productGroup")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblReceiveQuantity" runat="server" Text='<%# Eval("ReceiveQuantity")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCPU" runat="server" Text='<%# Eval("CPU")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDeliveryQty" runat="server" Text='<%# Eval("DeliveryQty")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblOcode" runat="server" Text='<%# Eval("Ocode")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCompanyCode" runat="server" Text='<%# Eval("CompanyCode")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPurchaseDate" runat="server" Text='<%# Eval("PurchaseDate")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBalanceQty" runat="server" Text='<%# Eval("BalanceQuanity")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblChallanNo" runat="server" Text='<%# Eval("ChallanNo")%>' />
                                                    </ItemTemplate>

                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBarCode" runat="server" Text='<%# Eval("BarCode")%>' />
                                                    </ItemTemplate>

                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblUnitName" runat="server" Text='<%# Eval("UnitName")%>' />
                                                    </ItemTemplate>

                                                </asp:TemplateField>
                                                <asp:BoundField DataField="ProductName" HeaderText="Item">
                                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                    <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                    <FooterStyle CssClass="Grid_Footer" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ChallanNo" HeaderText="Challan No">
                                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                    <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                    <FooterStyle CssClass="Grid_Footer" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="BarCode" Visible="false" HeaderText="BarCode">
                                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                                    <FooterStyle CssClass="Grid_Footer" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="BalanceQuanity" HeaderText="Balance Qty">
                                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                                    <FooterStyle CssClass="Grid_Footer" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Return Qty" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtReturnQty" runat="server" Width="100%" Style="text-align: center"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                                    <FooterStyle CssClass="Grid_Footer" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Remarks" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtRemarks" runat="server" Width="100%" Style="text-align: center"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                                    <FooterStyle CssClass="Grid_Footer" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataRowStyle ForeColor="Red" />
                                            <PagerSettings Mode="NumericFirstLast" />
                                            <PagerStyle CssClass="pagination01 pageback" />
                                            <RowStyle CssClass="Grid_RowStyle" />
                                        </asp:GridView>
                                    </fieldset>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                            </div>
                                            <div class="col-md-8">
                                                <asp:Button ID="BtnSave" runat="server" Text="Add" class="btn btn-info pull-right" ValidationGroup="Group1"
                                                    OnClick="BtnSave_Click" />
                                            </div>

                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-6" style="padding-top: 10px;">
                                    <%-- <div class="row">--%>
                                    <fieldset>
                                        <legend style="line-height: 0; margin-bottom: 0"><span style="background: #fff">Return Item List</span></legend>
                                        <asp:GridView ID="grdTransfer" runat="server" Width="100%" AutoGenerateColumns="false"
                                            AllowSorting="true" CellPadding="5" BorderColor="#E3F0FC" BorderStyle="Solid"
                                            CssClass="Grid_Border" AllowPaging="True">
                                            <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                            <Columns>
                                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center">
                                                    <HeaderTemplate>
                                                        Sl.
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSRNO" runat="server"
                                                            Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                </asp:TemplateField>
                                                <%-- <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblId" runat="server" Text='<%# Eval("Id")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                                <asp:BoundField DataField="ProductName" HeaderText="Item">
                                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                    <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                    <FooterStyle CssClass="Grid_Footer" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ChallanNo" HeaderText="Challan No">
                                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                    <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                    <FooterStyle CssClass="Grid_Footer" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="SupplierName" HeaderText="Supplier">
                                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                    <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                    <FooterStyle CssClass="Grid_Footer" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ReturnQty" HeaderText="Return Qty">
                                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                                    <FooterStyle CssClass="Grid_Footer" />
                                                </asp:BoundField>
                                                <%--<asp:BoundField DataField="PrqBalanceQuanity" HeaderText="Balance Qty">
                                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                                    <FooterStyle CssClass="Grid_Footer" />
                                                </asp:BoundField>--%>
                                                <%--<asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImgGroupEdit" runat="server" ImageUrl="img/list_edit.png" OnClick="ImgGroupEdit_Click" />
                                            </ItemTemplate>
                                            <FooterStyle CssClass="Grid_Footer" />
                                            <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                            <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" Width="8%" />
                                        </asp:TemplateField>--%>
                                            </Columns>
                                            <EmptyDataRowStyle ForeColor="Red" />
                                            <PagerSettings Mode="NumericFirstLast" />
                                            <PagerStyle CssClass="pagination01 pageback" />
                                            <RowStyle CssClass="Grid_RowStyle" />
                                        </asp:GridView>
                                        <%-- </div>--%>
                                    </fieldset>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                            </div>
                                            <div class="col-md-8">
                                                <asp:Button ID="btnConfirm" runat="server" Text="Confirm" class="btn btn-success pull-right" ValidationGroup="Group1"
                                                    OnClick="btnConfirm_Click" />
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

    <script type="text/javascript">

        function func(result) {
            if (result === 'Item Returned Successfully') {
                toastr.success(result);
            }
            else if (result === 'Return Process Temporary successfully') {
                toastr.success(result);
            }
            else
                toastr.error(result);

            return false;
        }

    </script>
</asp:Content>
