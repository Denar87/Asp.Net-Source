<%@ Page Title="" Language="C#" MasterPageFile="~/INV/Site.Master" AutoEventWireup="true"
    CodeBehind="Damage.aspx.cs" Inherits="ERPSSL.INV.Damage" %>

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
                            <i class="glyphicon glyphicon-edit icon-padding"></i>Item Damage
                        </div>
                    </div>
                    <div class="col-md-12 bg-success">
                        <center>
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label></center>
                    </div>
                    <div class="row">
                        <fieldset style="border: none;">
                            <div class="col-md-12">
                                <div class="col-md-5">
                                    <div class="row" style="padding-bottom: 8px;">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Date<a style="color: red; font-size: 11px">*</a>
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtDate" CssClass="form-control" runat="server"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtDate"
                                                    PopupButtonID="txtDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDate"
                                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select a Date"
                                                    Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" style="padding-bottom: 8px;">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Store<a style="color: red; font-size: 11px">*</a>
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtChalanNo" CssClass="form-control" runat="server" ReadOnly="True"
                                                    Visible="false"></asp:TextBox>
                                                <asp:DropDownList ID="ddlStore" AutoPostBack="true" CssClass="form-control" runat="server"
                                                    OnSelectedIndexChanged="ddlStore_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlStore"
                                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select a Store"
                                                    InitialValue="0" Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" style="padding-bottom: 8px;">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Item Group<a style="color: red; font-size: 11px">*</a>
                                            </div>
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="ddlProductGroup" AutoPostBack="true" CssClass="form-control"
                                                    runat="server" OnSelectedIndexChanged="ddlProductGroup_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlProductGroup"
                                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select a Group"
                                                    InitialValue="0" Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" style="padding-bottom: 8px;">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Item Name<a style="color: red; font-size: 11px">*</a>
                                            </div>
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="ddlProduct" AutoPostBack="true" CssClass="form-control" runat="server"
                                                    OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlProduct"
                                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select an Item"
                                                    InitialValue="0" Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>



                                </div>
                                <div class="col-md-7" style="padding-top: 10px;">
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
                                                <asp:TemplateField HeaderText="Damage Category">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="ddlDamageCategory" runat="server">
                                                            <asp:ListItem Text="Broken" Value="Broken"></asp:ListItem>
                                                            <asp:ListItem Text="Damage" Value="Damage"></asp:ListItem>
                                                            <asp:ListItem Text="Date Expire" Value="Date Expire"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                     <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                                    <FooterStyle CssClass="Grid_Footer" />
                                                </asp:TemplateField>
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
                                <div class="col-md-6" style="padding-top: 8px;">
                                    <fieldset>
                                        <div class="row">
                                            <asp:GridView ID="grdDamage" runat="server" Width="100%" AutoGenerateColumns="false"
                                                AllowSorting="true" CellPadding="5" BorderColor="#E3F0FC" BorderStyle="Solid"
                                                CssClass="Grid_Border">
                                                <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                                <Columns>
                                                    <asp:TemplateField Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblId" runat="server" Text='<%# Eval("ChallanNo")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="ProductName" HeaderText="Item Name">
                                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                        <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                                        <FooterStyle CssClass="Grid_Footer" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="BalanceQuanity" HeaderText="Balance Qty">
                                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                                        <FooterStyle CssClass="Grid_Footer" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="NewDamageQty" HeaderText="Damage Qty">
                                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                                        <FooterStyle CssClass="Grid_Footer" />
                                                    </asp:BoundField>
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
                                        </div>
                                    </fieldset>
                                    <div class="row" style="padding-bottom: 8px;">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                            </div>
                                            <div class="col-md-7">
                                                <asp:Button ID="btnConfirm" runat="server" Text="Confirm" ValidationGroup="Group1" class="btn btn-info pull-right"
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
    <script>

        function func(result) {
            if (result === 'Product damage information inserted successfully!') {
                toastr.success(result);

            }
            else if (result === 'Damage Process Temporary successfully') {
                toastr.success(result);
            }

            else
                toastr.error(result);

            return false;
        }

    </script>
</asp:Content>
