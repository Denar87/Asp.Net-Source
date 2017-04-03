<%@ Page Title="" Language="C#" MasterPageFile="~/LC/Site.Master" AutoEventWireup="true" CodeBehind="Estimating.aspx.cs" Inherits="ERPSSL.LC.Estimating" %>

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
                            <i class="glyphicon glyphicon-edit icon-padding"></i>Estimating
                        </div>
                    </div>
                    <div class="col-md-12 bg-success">
                        <center>
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label></center>
                    </div>
                    <div class="row">
                        <div class="col-md-12" style="margin: auto 0; padding: 0px;">
                            <div class="col-md-12" style="margin: auto 0; padding: 0px;">
                                <fieldset>
                                    <legend style="line-height: 0px;"><span style="background: #fff"></span></legend>
                                    <div class="row">
                                        <div class="col-md-4" style="margin: auto 0; padding: 0px;">
                                            <div class="row" style="padding-top: 0px">
                                                <div class="col-md-12" style="padding-top: 0px">
                                                    <div class="col-md-4">
                                                        Buyer Name<a style="color: red; font-size: 11px">*</a>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:DropDownList ID="ddlBuyerName" class="form-control" runat="server"></asp:DropDownList>

                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row" style="padding-top: 8px">
                                                <div class="col-md-12" style="padding-top: 0px">
                                                    <div class="col-md-4">
                                                        Style<a style="color: red; font-size: 11px">*</a>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:DropDownList ID="ddlStyle" class="form-control" runat="server"></asp:DropDownList>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row" style="padding-top: 8px">
                                                <div class="col-md-12" style="padding-top: 0px">
                                                    <div class="col-md-4">
                                                        Order<a style="color: red; font-size: 11px">*</a>
                                                        <asp:HiddenField ID="hidEstimatingCostID" runat="server" />
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:DropDownList ID="ddlOrder" OnSelectedIndexChanged="ddlOrder_SelectedIndexChanged" AutoPostBack="true" class="form-control" runat="server"></asp:DropDownList>
                                                        <asp:TextBox ID="txtMarchandisingNo" runat="server" Visible="false" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row" style="padding-top: 8px">
                                                <div class="col-md-12">
                                                    <div class="col-md-4">
                                                        P.O<a style="color: red; font-size: 11px">*</a>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtPO" runat="server" placeholder="" class="form-control"></asp:TextBox>
                                                        <%-- <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtIssueBank"
                                                            PopupButtonID="txtDateofExpiry" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />--%>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row" style="padding-top: 8px">
                                                <div class="col-md-12">
                                                    <div class="col-md-4">
                                                        Ref.<a style="color: red; font-size: 11px">*</a>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtRef" runat="server" placeholder="" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>


                                        </div>
                                        <div class="col-md-4">
                                            <div class="row">
                                                <div class="col-md-12" style="padding-top: 0px">
                                                    <div class="col-md-4">
                                                        Delivery<a style="color: red; font-size: 11px">*</a>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtDelivery" runat="server" placeholder="" class="form-control"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row" style="padding-top: 8px">
                                                <div class="col-md-12">
                                                    <div class="col-md-4">
                                                        S-Range
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtRange" runat="server" placeholder=" S-Range" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row" style="padding-top: 8px">
                                                <div class="col-md-12">
                                                    <div class="col-md-4">
                                                        Unit price
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtUnitPrice" runat="server" placeholder="price" class="form-control"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row" style="padding-top: 8px">
                                                <div class="col-md-12">
                                                    <div class="col-md-4">
                                                        Amount LC
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtAmountLc" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row" style="padding-top: 8px">
                                                <div class="col-md-12">
                                                    <div class="col-md-4">
                                                        Term
                                                    </div>
                                                    <div class="col-md-8">

                                                        <asp:TextBox ID="txtTerm" runat="server" placeholder="Term" class="form-control"></asp:TextBox>

                                                    </div>

                                                </div>
                                            </div>


                                        </div>
                                        <div class="col-md-4">
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="col-md-4">
                                                        Order Date <a style="color: red; font-size: 11px">*</a>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtDate" runat="server" placeholder="MM/dd/yyyy" class="form-control"></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate"
                                                            PopupButtonID="txtDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row" style="padding-top: 8px">
                                                <div class="col-md-12">
                                                    <div class="col-md-4">
                                                        Merchandiser
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtMerchandiser" runat="server" placeholder="Merchandiser" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row" style="padding-top: 8px">
                                                <div class="col-md-12">
                                                    <div class="col-md-4">
                                                        Finish Goods 
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:DropDownList ID="ddlFinishGoods" class="form-control" runat="server"></asp:DropDownList>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row" style="padding-top: 8px">
                                                <div class="col-md-12">
                                                    <div class="col-md-4">
                                                        Finish Goods Qty
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="row">
                                                            <asp:TextBox ID="txtQuantity" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <asp:DropDownList ID="ddlunit" class="form-control" runat="server"></asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row" style="padding-top: 8px">
                                                <div class="col-md-12">
                                                    <div class="col-md-4">
                                                        Target
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="row">
                                                            <asp:TextBox ID="txtTergate" runat="server" placeholder="Target" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">

                                                        <asp:TextBox ID="txtCost" runat="server" placeholder="Cost" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <%--<div class="row" style="padding-top: 8px">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            Item Category
                                        </div>
                                        <div class="col-md-8">
                                            <asp:DropDownList ID="ddlItemCategory" CssClass="form-control" runat="server" AutoPostBack="true"
                                                OnSelectedIndexChanged="ddlItemCategory_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>--%>
                                        </div>



                                    </div>
                                </fieldset>
                            </div>

                            <div class="row" style="padding-top: 8px">

                                <div class="col-md-6">
                                    <div class="panel panel-info">
                                        <div class="panel-heading">Fabric Details</div>
                                        <div class="panel-body">
                                            <asp:GridView ID="grvOrderSheetEntry" runat="server" Width="100%" AutoGenerateColumns="False"
                                                PageSize="20" BorderColor="#E3F0FC" CellPadding="5" AllowPaging="True" OnRowDataBound="grvOrderSheetEntry_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Id" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblGroupId" runat="server" Text='<%# Bind("GroupId") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Id" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblProductId" runat="server" Text='<%# Bind("ProductId") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Id" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblUnitId" runat="server" Text='<%# Bind("UnitId") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>


                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:CheckBox runat="server" ID="headerLevelCheckBox" AutoPostBack="true" OnCheckedChanged="headerLevelCheckBox_CheckedChanged" />
                                                            <itemstyle horizontalalign="Left" width="1%" cssclass="Grid_Border" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="rowLevelCheckBox" runat="server" />
                                                            <headerstyle verticalalign="Middle" cssclass="Grid_Header" />
                                                            <itemstyle horizontalalign="Left" width="1%" cssclass="Grid_Border" />
                                                            <footerstyle cssclass="Grid_Footer" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="1%" CssClass="Grid_Border" />
                                                    </asp:TemplateField>
                                                    <%--<asp:BoundField DataField="ProductName" HeaderText="Description">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>--%>
                                                    <asp:TemplateField HeaderText="Description">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("ProductName")+ " " + Eval("StyleAndSize")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" VerticalAlign="Middle"
                                                            Width="20%" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="UnitName" HeaderText="Unit">
                                                        <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                                        <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" VerticalAlign="Middle"
                                                            Width="15%" />
                                                        <FooterStyle CssClass="Grid_Footer" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Supplier">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="ddlSupplier" runat="server"></asp:DropDownList>
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                                        <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" VerticalAlign="Middle"
                                                            Width="10%" />
                                                        <FooterStyle CssClass="Grid_Footer" />
                                                    </asp:TemplateField>

                                                    <%--  <asp:BoundField DataField="StyleSize" HeaderText="Style And Size">
                                                <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                                <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" VerticalAlign="Middle"
                                                    Width="15%" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>--%>
                                                    <%--<asp:BoundField DataField="BalanceQuanity" HeaderText="Balance">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>--%>
                                                    <asp:TemplateField HeaderText="Qty/Pc">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtConsumption" runat="server" OnTextChanged="txtConsumption_TextChanged" AutoPostBack="true" Width="100%" Style="text-align: center"></asp:TextBox>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Id" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTotalunitQty" runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Qty/Dzn">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtQtyDzn" runat="server" Width="100%" Style="text-align: center"></asp:TextBox>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Unit Price($)">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtUSDRate" runat="server" Width="100%" OnTextChanged="txtUSDRate_TextChanged" AutoPostBack="true" Style="text-align: center"></asp:TextBox>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Amount($)">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblValue" runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                    </asp:TemplateField>
                                                    <%--<asp:TemplateField HeaderText="Rate(BDT)">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtBDTRate" runat="server" Width="100%" OnTextChanged="txtBDTRate_TextChanged" AutoPostBack="true" Style="text-align: center"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Value(BDT)">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBDTValue" runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                            </asp:TemplateField>--%>
                                                </Columns>
                                                <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                                <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <EmptyDataRowStyle ForeColor="Red" />
                                                <PagerSettings Mode="NumericFirstLast" />
                                                <PagerStyle CssClass="pagination01 pageback" />
                                                <RowStyle CssClass="Grid_RowStyle" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:GridView>
                                            <span style="color: maroon; float: right">
                                                <asp:Label ID="lblGrandTotal" runat="server"></asp:Label></span>
                                            <span style="color: maroon; margin-right: 150px; float: right"><b>Total Fabric Value</b></span>
                                            <div class="col-md-12">
                                                <asp:Button ID="btnFabric" OnClick="btnFabric_Click" runat="server" Text="Submit" class="btn btn-info pull-right" ValidationGroup="Group1" />
                                            </div>


                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="panel panel-info">
                                        <div class="panel-heading">Accessories Details</div>
                                        <div class="panel-body">
                                            <asp:GridView ID="gridAccessories" runat="server" Width="100%" AutoGenerateColumns="False"
                                                PageSize="20" BorderColor="#E3F0FC" CellPadding="5" AllowPaging="True" OnRowDataBound="gridAccessories_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Id" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblGroupId1" runat="server" Text='<%# Bind("GroupId") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Id" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblProductId1" runat="server" Text='<%# Bind("ProductId") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Id" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblUnitId1" runat="server" Text='<%# Bind("UnitId") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <asp:CheckBox runat="server" ID="headerLevelCheckBox1" AutoPostBack="true" OnCheckedChanged="headerLevelCheckBox1_CheckedChanged" />
                                                            <itemstyle horizontalalign="Left" width="1%" cssclass="Grid_Border" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="rowLevelCheckBox1" runat="server" />
                                                            <headerstyle verticalalign="Middle" cssclass="Grid_Header" />
                                                            <itemstyle horizontalalign="Left" width="1%" cssclass="Grid_Border" />
                                                            <footerstyle cssclass="Grid_Footer" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="1%" CssClass="Grid_Border" />
                                                    </asp:TemplateField>
                                                    <%--<asp:BoundField DataField="ProductName" HeaderText="Description">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>--%>
                                                    <asp:TemplateField HeaderText="Description">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label10" runat="server" Text='<%#Eval("ProductName")+ " " + Eval("StyleAndSize")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" VerticalAlign="Middle"
                                                            Width="20%" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="UnitName" HeaderText="Unit">
                                                        <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                                        <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" VerticalAlign="Middle"
                                                            Width="15%" />
                                                        <FooterStyle CssClass="Grid_Footer" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Supplier">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="ddlSupplier2" runat="server"></asp:DropDownList>
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                                        <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <FooterStyle CssClass="Grid_Footer" />
                                                    </asp:TemplateField>
                                                    <%--  <asp:BoundField DataField="StyleSize" HeaderText="Style And Size">
                                                <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                                <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" VerticalAlign="Middle"
                                                    Width="15%" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>--%>
                                                    <%-- <asp:BoundField DataField="BalanceQuanity" HeaderText="Balance">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>--%>
                                                    <asp:TemplateField HeaderText="Qty/Pc">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtQtyPc" OnTextChanged="txtQtyPc_TextChanged" AutoPostBack="true" runat="server" Width="100%" Style="text-align: center"></asp:TextBox>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Id" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTotalunitQty1" runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Qty/Dzn">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtQtyDzn2" runat="server" Width="100%" Style="text-align: center"></asp:TextBox>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Unit Price($)">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtUnit" runat="server" Width="100%" OnTextChanged="txtUnit_TextChanged" AutoPostBack="true" Style="text-align: center"></asp:TextBox>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Amount($)">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAmount" runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                    </asp:TemplateField>
                                                    <%--<asp:TemplateField HeaderText="Rate(BDT)">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtBDTRate" runat="server" Width="100%" OnTextChanged="txtBDTRate_TextChanged" AutoPostBack="true" Style="text-align: center"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Value(BDT)">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBDTValue" runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                            </asp:TemplateField>--%>
                                                </Columns>
                                                <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                                <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <EmptyDataRowStyle ForeColor="Red" />
                                                <PagerSettings Mode="NumericFirstLast" />
                                                <PagerStyle CssClass="pagination01 pageback" />
                                                <RowStyle CssClass="Grid_RowStyle" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:GridView>
                                            <span style="color: maroon; float: right">
                                                <asp:Label ID="lblGrandTotalAccessories" runat="server"></asp:Label></span>
                                            <span style="color: maroon; margin-right: 150px; float: right"><b>Total Value of Accessories</b></span><br />
                                            <span style="color: maroon; float: right">
                                                <asp:Label ID="lblParsentageCost" runat="server"></asp:Label></span>
                                            <span style="color: maroon; margin-right: 150px; float: right"><b>Total Value of Accessories with 5% Excess</b></span>
                                            <div class="col-md-12">
                                                <asp:Button ID="btnAccessories" OnClick="btnAccessories_Click" runat="server" Text="Submit" class="btn btn-info pull-right" ValidationGroup="Group1" />
                                            </div>

                                        </div>
                                    </div>

                                </div>

                            </div>


                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-12">
                                        <div class="panel panel-info">
                                            <div class="panel-heading">Accessories Details</div>
                                            <div class="panel-body">

                                                <div class="col-md-12" style="background-color: #DCDCDC">
                                                    <div class="col-md-10">Total Fabric Cost</div>
                                                    <div class="col-md-2">
                                                        <asp:TextBox ID="txtTotalFabricCost" Style="width: 130%; text-align: right" ReadOnly="true" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-12" style="background-color: #FFF0F5">
                                                    <div class="col-md-10">Total Accessories Cost</div>
                                                    <div class="col-md-2">
                                                        <asp:TextBox ID="txtTotalAccessoryCost" runat="server" Style="width: 130%; text-align: right" ReadOnly="true" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-12" style="background-color: #DCDCDC">
                                                    <div class="col-md-10">Washing Cost</div>
                                                    <div class="col-md-2">
                                                        <asp:TextBox ID="txtWashingCost" on runat="server" Style="width: 130%; text-align: right" AutoPostBack="true" class="form-control" OnTextChanged="txtWashingCost_TextChanged"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-12" style="background-color: #FFF0F5">
                                                    <div class="col-md-10">Lab Test/DZ</div>
                                                    <div class="col-md-2">
                                                        <asp:TextBox ID="txtLabTest" runat="server" Style="width: 130%; text-align: right" AutoPostBack="true" class="form-control" OnTextChanged="txtLabTest_TextChanged"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-12" style="background-color: #DCDCDC">
                                                    <div class="col-md-10">Print Cost|Stitch</div>
                                                    <div class="col-md-2">
                                                        <asp:TextBox ID="txtPrintCost" runat="server" Style="width: 130%; text-align: right" AutoPostBack="true" class="form-control" OnTextChanged="txtPrintCost_TextChanged"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-12" style="background-color: #FFF0F5">
                                                    <div class="col-md-10">C/M</div>
                                                    <div class="col-md-2">
                                                        <asp:TextBox ID="txtCM" runat="server" Style="width: 130%; text-align: right" AutoPostBack="true" class="form-control" OnTextChanged="txtCM_TextChanged"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-12" style="background-color: #DCDCDC">
                                                    <div class="col-md-10">Total price/Dozen</div>
                                                    <div class="col-md-2">
                                                        <asp:TextBox ID="txtTotalPrice" runat="server" Style="width: 130%; text-align: right" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-12" style="background-color: #FFF0F5">
                                                    <div class="col-md-10">Commission(%)</div>
                                                    <div class="col-md-2">
                                                        <asp:TextBox ID="txtCommission" runat="server" Style="width: 130%; text-align: right" AutoPostBack="true" class="form-control" OnTextChanged="txtCommission_TextChanged"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-12" style="background-color: #CD5C5C">
                                                    <div class="col-md-10">Final Price</div>
                                                    <div class="col-md-2">
                                                        <asp:TextBox ID="txtFinalPrice" runat="server" Style="width: 130%; text-align: right" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <div class="row" style="padding-top: 8px">
                                <div class="col-md-12">
                                    <div class="col-md-6">
                                    </div>
                                    <div class="col-md-6">
                                        <div class="col-md-8">
                                        </div>
                                        <div class="col-md-2">
                                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-info pull-right" ValidationGroup="Group1" OnClick="btnSubmit_Click" />
                                        </div>
                                        <div class="col-md-2">
                                            <asp:Button ID="btnPrint" runat="server" Text="Print" class="btn btn-info pull-right" ValidationGroup="Group1" OnClick="btnPrint_Click" />
                                        </div>

                                    </div>
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
            //if (result === 'Save Successfully') {
            //    toastr.success(result);

            //}
            if (result === 'Data Added Successfully') {
                toastr.success(result);
            }
            else if (result === 'Data Saving Failure') {
                toastr.error(result);
            }
            else if (result === 'Data Already Exist') {
                toastr.error(result);
            }

            else if (result === 'Data Updated Successfully') {
                toastr.success(result);
            }
            else if (result === 'Data Submit Successfully') {
                toastr.success(result);
            }
            else if (result === 'Data Updating failure') {
                toastr.error(result);
            }
            else
                toastr.error(result);

            return false;
        }

    </script>
</asp:Content>
