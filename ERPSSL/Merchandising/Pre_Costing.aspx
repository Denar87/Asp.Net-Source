<%@ Page Title="" Language="C#" MasterPageFile="~/Merchandising/Merchandising.Master" AutoEventWireup="true" CodeBehind="Pre_Costing.aspx.cs" Inherits="ERPSSL.Merchandising.Pre_Costing" %>

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

        .header {
            background-color: #808080;
            color: #ffffff;
            width: 100%;
        }

        .item {
            background-color: #ffffff;
            width: 100%;
        }

        .alternativeitem {
            background-color: #0094ff;
            color: #ffffff;
            width: 100%;
        }
    </style>


    <script type="text/javascript">
        function SuccessAlert(result) {
            swal({
                title: result,
                type: 'success',
                timer: 1000,
                showConfirmButton: false
            });
        }

        function notsuccessalert(result) {
            swal({
                title: result,
                type: 'error'
            });
        }

        function updatealert() {
            swal({
                title: 'Congratulations!',
                text: 'File Name Update',
                type: 'success'
            });
        }

        function notupdatealert() {
            swal({
                title: 'Oops...!',
                text: 'File Name Not Update',
                type: 'error'
            });
        }



        function CommonRequiredFiledError(result) {
            swal({
                title: result,
                type: 'warning',
                timer: 1500,
                showConfirmButton: false
            });
        }
    </script>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePageMethods="true" EnablePartialRendering="true" ID="ScriptManager1" />

    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
        <ContentTemplate>
            <div class="row">
                <div class="hm_sec_2_content scrollbar">
                    <div class="panel">
                        <div class="panel-heading panel-heading-01">
                            <i class="fa fa-edit fa-fw icon-padding"></i>Pre Costing
                        </div>
                    </div>

                    <div class="row" style="margin: auto 0;">
                        <fieldset style="padding-top: 5px;">
                            <legend style="line-height: 0px; padding-top: 5px;"><span style="background: #fff"></span></legend>
                            <div class="col-md-12" style="background-color: #f0f5f6; padding-bottom: 10px;">
                                <div class="col-md-3" style="padding-left: 0;">
                                    <div class="row" runat="server" id="OrderNo1">
                                        <div>
                                            Order No.<a style="color: red; font-size: 11px">*</a>
                                            <asp:TextBox ID="txtPOrder" Class=" form-control2 form-control " runat="server" OnTextChanged="txtPOrder2_TextChanged" AutoPostBack="True"></asp:TextBox>
                                            <cc1:AutoCompleteExtender ServiceMethod="SearchOrderNo"
                                                MinimumPrefixLength="1"
                                                CompletionInterval="100" EnableCaching="False"
                                                TargetControlID="txtPOrder"
                                                ID="AutoCompleteExtender2" runat="server" DelimiterCharacters="" Enabled="True" ServicePath="">
                                            </cc1:AutoCompleteExtender>
                                        </div>
                                        <div>
                                            Order Received Date
                                            <asp:TextBox ID="orderReceiveDateTextBox" Class=" form-control2 form-control " runat="server" placeholder="MM/dd/yyyy" Enabled="false"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="orderReceiveDateTextBox"
                                                PopupButtonID="orderReceiveDateTextBox" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                        </div>
                                        <div>
                                            <div class="col-md-12" style="padding: 0px;">
                                                <div class="col-md-1" style="padding: 0px;">
                                                    Style  
                                                </div>
                                                <%--<div class="col-md-1">
                                                    <asp:CheckBox ID="chkNewstyle2" runat="server" Visible="true" AutoPostBack="True"></asp:CheckBox>
                                                </div>--%>
                                                <%--<a style="color: red; font-size: 11px">*</a>--%>
                                                <div class="col-md-10"></div>
                                            </div>
                                            <div class="col-md-12" style="padding: 0px;">
                                                <%--<asp:DropDownList ID="ddlStyle2" CssClass="form-control2 form-control" runat="server">
                                                </asp:DropDownList>--%>
                                                <asp:TextBox ID="styleTextBox" runat="server" class="form-control" Enabled="false"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12" style="padding: 0px;">
                                            <div class="col-md-2" style="padding: 0px;">
                                                Season 
                                                <asp:HiddenField ID="hidSeasonID" runat="server" />
                                            </div>
                                            <%-- <div class="col-md-1">
                                                <asp:CheckBox ID="ChkSeason" runat="server" Visible="true" AutoPostBack="True"></asp:CheckBox>
                                            </div>--%>
                                            <%-- <a style="color: red; font-size: 11px">*</a>--%>
                                            <div class="col-md-9"></div>
                                        </div>
                                        <div class="col-md-12" style="padding: 0px;">
                                            <%--<asp:DropDownList ID="ddlSeason" AutoPostBack="true" CssClass="form-control" runat="server">
                                            </asp:DropDownList>--%>
                                            <asp:TextBox ID="seasonTextBox" runat="server" class="form-control" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        SMV
                                        <asp:TextBox ID="sMVTextBox" Class=" form-control2 form-control " runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="row">
                                        Buyer <a style="color: red; font-size: 11px">*</a>
                                        <%--<asp:DropDownList ID="ddlBuyer" CssClass="form-control2 form-control" runat="server">
                                        </asp:DropDownList>--%>
                                        <asp:TextBox ID="BuyerTextBox" Class=" form-control2 form-control " runat="server" Enabled="false"></asp:TextBox>
                                    </div>
                                    <div class="row">
                                        Country
                                           <%-- <asp:DropDownList ID="ddl_Country" CssClass="form-control2 form-control" runat="server">
                                            </asp:DropDownList>--%>
                                        <asp:TextBox ID="countryTextBox" Class=" form-control2 form-control " runat="server" Enabled="false"></asp:TextBox>
                                    </div>
                                    <div class="row">

                                        <div class="col-md-12" style="padding: 0px;">
                                            <div class="col-md-5" style="padding: 0px;">
                                                Buyer Department 
                                            </div>
                                            <%-- <div class="col-md-1">
                                                <asp:CheckBox ID="chkBuyerDepartment" runat="server" AutoPostBack="True"></asp:CheckBox>
                                            </div>--%>
                                            <%-- <a style="color: red; font-size: 11px">*</a>--%>
                                            <div class="col-md-6"></div>
                                        </div>
                                        <div class="col-md-12" style="padding: 0px;">

                                            <asp:TextBox ID="buyerDepartmentTextBox" runat="server" class="form-control" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12" style="padding: 0px;">
                                            <div class="col-md-3" style="padding: 0px;">
                                                Category
                                            </div>
                                            <%--<div class="col-md-1">
                                                <asp:CheckBox ID="chkCategory" runat="server" AutoPostBack="True"></asp:CheckBox>
                                            </div>--%>
                                            <%--<a style="color: red; font-size: 11px">*</a>--%>
                                            <div class="col-md-8"></div>
                                        </div>
                                        <div class="col-md-12" style="padding: 0px;">
                                            <%--<asp:DropDownList ID="ddlCategory" AutoPostBack="true"
                                                CssClass="form-control" runat="server">
                                            </asp:DropDownList>--%>
                                            <asp:TextBox ID="categoryTextBox" runat="server" class="form-control" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        Efficiency %
                                            <asp:TextBox ID="efficiencyTextBox" Class=" form-control2 form-control " runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="row">
                                        Item Description
                                            <asp:TextBox ID="itemDescriptionTextBox" Class=" form-control2 form-control " runat="server" Enabled="false"></asp:TextBox>
                                    </div>
                                    <div class="row">

                                        <div class="col-md-6" style="padding-left: 0px;">
                                            Quantity
                                                <asp:TextBox ID="quantityTextBox" Class="form-control " runat="server" Text="0" Enabled="false"></asp:TextBox>
                                        </div>
                                        <div class="col-md-6" style="padding-right: 0px;">
                                            Unit
                                              <%--  <asp:DropDownList ID="ddlUnit" CssClass=" form-control" runat="server">
                                                </asp:DropDownList>--%>
                                            <asp:TextBox ID="unitTextBox" Class="form-control " runat="server" Text="" AutoPostBack="true" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        Currency
                                        <asp:DropDownList ID="ddlCurrency" CssClass="form-control2 form-control" runat="server" Enabled="false">
                                            <asp:ListItem Value="AED">AED (United Arab Emirates Dirham)</asp:ListItem>
                                            <asp:ListItem Value="ANG">ANG (Netherlands Antillean Guilder)</asp:ListItem>
                                            <asp:ListItem Value="ARS">ARS (Argentine Peso)</asp:ListItem>
                                            <asp:ListItem Value="AUD">AUD (Australian Dollar)</asp:ListItem>
                                            <asp:ListItem Value="BDT">BDT (Bangladeshi Taka)</asp:ListItem>
                                            <asp:ListItem Value="BGN">BGN (Bulgarian Lev)</asp:ListItem>
                                            <asp:ListItem Value="BHD">BHD (Bahraini Dinar)</asp:ListItem>
                                            <asp:ListItem Value="BND">BND (Brunei Dollar)</asp:ListItem>
                                            <asp:ListItem Value="BOB">BOB (Bolivian Boliviano)</asp:ListItem>
                                            <asp:ListItem Value="BRL">BRL (Brazilian Real)</asp:ListItem>
                                            <asp:ListItem Value="BWP">BWP (Botswanan Pula)</asp:ListItem>
                                            <asp:ListItem Value="CAD">CAD (Canadian Dollar)</asp:ListItem>
                                            <asp:ListItem Value="CHF">CHF (Swiss Franc)</asp:ListItem>
                                            <asp:ListItem Value="CLP">CLP (Chilean Peso)</asp:ListItem>
                                            <asp:ListItem Value="CNY">CNY (Chinese Yuan)</asp:ListItem>
                                            <asp:ListItem Value="COP">COP (Colombian Peso)</asp:ListItem>
                                            <asp:ListItem Value="CRC">CRC (Costa Rican Colón)</asp:ListItem>
                                            <asp:ListItem Value="CZK">CZK (Czech Republic Koruna)</asp:ListItem>
                                            <asp:ListItem Value="DKK">DKK (Danish Krone)</asp:ListItem>
                                            <asp:ListItem Value="DOP">DOP (Dominican Peso)</asp:ListItem>
                                            <asp:ListItem Value="DZD">DZD (Algerian Dinar)</asp:ListItem>
                                            <asp:ListItem Value="EEK">EEK (Estonian Kroon)</asp:ListItem>
                                            <asp:ListItem Value="EGP">EGP (Egyptian Pound)</asp:ListItem>
                                            <asp:ListItem Value="EUR">EUR (Euro)</asp:ListItem>
                                            <asp:ListItem Value="FJD">FJD (Fijian Dollar)</asp:ListItem>
                                            <asp:ListItem Value="GBP">GBP (British Pound Sterling)</asp:ListItem>
                                            <asp:ListItem Value="HKD">HKD (Hong Kong Dollar)</asp:ListItem>
                                            <asp:ListItem Value="HNL">HNL (Honduran Lempira)</asp:ListItem>
                                            <asp:ListItem Value="HRK">HRK (Croatian Kuna)</asp:ListItem>
                                            <asp:ListItem Value="HUF">HUF (Hungarian Forint)</asp:ListItem>
                                            <asp:ListItem Value="IDR">IDR (Indonesian Rupiah)</asp:ListItem>
                                            <asp:ListItem Value="ILS">ILS (Israeli New Sheqel)</asp:ListItem>
                                            <asp:ListItem Value="INR">INR (Indian Rupee)</asp:ListItem>
                                            <asp:ListItem Value="JMD">JMD (Jamaican Dollar)</asp:ListItem>
                                            <asp:ListItem Value="JOD">JOD (Jordanian Dinar)</asp:ListItem>
                                            <asp:ListItem Value="JPY">JPY (Japanese Yen)</asp:ListItem>
                                            <asp:ListItem Value="KES">KES (Kenyan Shilling)</asp:ListItem>
                                            <asp:ListItem Value="KRW">KRW (South Korean Won)</asp:ListItem>
                                            <asp:ListItem Value="KWD">KWD (Kuwaiti Dinar)</asp:ListItem>
                                            <asp:ListItem Value="KYD">KYD (Cayman Islands Dollar)</asp:ListItem>
                                            <asp:ListItem Value="KZT">KZT (Kazakhstani Tenge)</asp:ListItem>
                                            <asp:ListItem Value="LBP">LBP (Lebanese Pound)</asp:ListItem>
                                            <asp:ListItem Value="LKR">LKR (Sri Lankan Rupee)</asp:ListItem>
                                            <asp:ListItem Value="LTL">LTL (Lithuanian Litas)</asp:ListItem>
                                            <asp:ListItem Value="LVL">LVL (Latvian Lats)</asp:ListItem>
                                            <asp:ListItem Value="MAD">MAD (Moroccan Dirham)</asp:ListItem>
                                            <asp:ListItem Value="MDL">MDL (Moldovan Leu)</asp:ListItem>
                                            <asp:ListItem Value="MKD">MKD (Macedonian Denar)</asp:ListItem>
                                            <asp:ListItem Value="MUR">MUR (Mauritian Rupee)</asp:ListItem>
                                            <asp:ListItem Value="MVR">MVR (Maldivian Rufiyaa)</asp:ListItem>
                                            <asp:ListItem Value="MXN">MXN (Mexican Peso)</asp:ListItem>
                                            <asp:ListItem Value="MYR">MYR (Malaysian Ringgit)</asp:ListItem>
                                            <asp:ListItem Value="NAD">NAD (Namibian Dollar)</asp:ListItem>
                                            <asp:ListItem Value="NGN">NGN (Nigerian Naira)</asp:ListItem>
                                            <asp:ListItem Value="NIO">NIO (Nicaraguan Córdoba)</asp:ListItem>
                                            <asp:ListItem Value="NOK">NOK (Norwegian Krone)</asp:ListItem>
                                            <asp:ListItem Value="NPR">NPR (Nepalese Rupee)</asp:ListItem>
                                            <asp:ListItem Value="NZD">NZD (New Zealand Dollar)</asp:ListItem>
                                            <asp:ListItem Value="OMR">OMR (Omani Rial)</asp:ListItem>
                                            <asp:ListItem Value="PEN">PEN (Peruvian Nuevo Sol)</asp:ListItem>
                                            <asp:ListItem Value="PGK">PGK (Papua New Guinean Kina)</asp:ListItem>
                                            <asp:ListItem Value="PHP">PHP (Philippine Peso)</asp:ListItem>
                                            <asp:ListItem Value="PKR">PKR (Pakistani Rupee)</asp:ListItem>
                                            <asp:ListItem Value="PLN">PLN (Polish Zloty)</asp:ListItem>
                                            <asp:ListItem Value="PYG">PYG (Paraguayan Guarani)</asp:ListItem>
                                            <asp:ListItem Value="QAR">QAR (Qatari Rial)</asp:ListItem>
                                            <asp:ListItem Value="RON">RON (Romanian Leu)</asp:ListItem>
                                            <asp:ListItem Value="RSD">RSD (Serbian Dinar)</asp:ListItem>
                                            <asp:ListItem Value="RUB">RUB (Russian Ruble)</asp:ListItem>
                                            <asp:ListItem Value="SAR">SAR (Saudi Riyal)</asp:ListItem>
                                            <asp:ListItem Value="SCR">SCR (Seychellois Rupee)</asp:ListItem>
                                            <asp:ListItem Value="SEK">SEK (Swedish Krona)</asp:ListItem>
                                            <asp:ListItem Value="SGD">SGD (Singapore Dollar)</asp:ListItem>
                                            <asp:ListItem Value="SKK">SKK (Slovak Koruna)</asp:ListItem>
                                            <asp:ListItem Value="SLL">SLL (Sierra Leonean Leone)</asp:ListItem>
                                            <asp:ListItem Value="SVC">SVC (Salvadoran Colón)</asp:ListItem>
                                            <asp:ListItem Value="THB">THB (Thai Baht)</asp:ListItem>
                                            <asp:ListItem Value="TND">TND (Tunisian Dinar)</asp:ListItem>
                                            <asp:ListItem Value="TRY">TRY (Turkish Lira)</asp:ListItem>
                                            <asp:ListItem Value="TTD">TTD (Trinidad and Tobago Dollar)</asp:ListItem>
                                            <asp:ListItem Value="TWD">TWD (New Taiwan Dollar)</asp:ListItem>
                                            <asp:ListItem Value="TZS">TZS (Tanzanian Shilling)</asp:ListItem>
                                            <asp:ListItem Value="UAH">UAH (Ukrainian Hryvnia)</asp:ListItem>
                                            <asp:ListItem Value="UGX">UGX (Ugandan Shilling)</asp:ListItem>
                                            <asp:ListItem Value="USD" Selected="True">USD (US Dollar)</asp:ListItem>
                                            <asp:ListItem Value="UYU">UYU (Uruguayan Peso)</asp:ListItem>
                                            <asp:ListItem Value="UZS">UZS (Uzbekistan Som)</asp:ListItem>
                                            <asp:ListItem Value="VEF">VEF (Venezuelan Bolívar)</asp:ListItem>
                                            <asp:ListItem Value="VND">VND (Vietnamese Dong)</asp:ListItem>
                                            <asp:ListItem Value="XOF">XOF (CFA Franc BCEAO)</asp:ListItem>
                                            <asp:ListItem Value="YER">YER (Yemeni Rial)</asp:ListItem>
                                            <asp:ListItem Value="ZAR">ZAR (South African Rand)</asp:ListItem>
                                            <asp:ListItem Value="ZMK">ZMK (Zambian Kwacha)</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="row">
                                        FOB Port
                                            <asp:TextBox ID="fOBPortTextBox" Class=" form-control2 form-control " runat="server" Enabled="false"></asp:TextBox>
                                    </div>

                                    <div class="row">
                                        Item Type
                                         
                                    </div>

                                </div>
                                <div class="col-md-3">
                                    <div class="row">
                                        Shipment Mode
                                        <asp:DropDownList ID="ddlShipmentMode" CssClass="form-control2 form-control" runat="server" Enabled="false">
                                            <asp:ListItem>---Select---</asp:ListItem>
                                            <asp:ListItem>By Air</asp:ListItem>
                                            <asp:ListItem>By Sea</asp:ListItem>
                                            <asp:ListItem>By Land</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="row">
                                        <asp:HiddenField ID="HiddenField1" runat="server" />
                                        Shipment Date
                                            <asp:TextBox ID="shipmentDateTextBox" Class=" form-control2 form-control " runat="server" placeholder="MM/dd/yyyy" Enabled="false"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender14" runat="server" TargetControlID="shipmentDateTextBox"
                                            PopupButtonID="shipmentDateTextBox" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                    </div>
                                    <div class="row">
                                        Merchandiser Name
                                           <%-- <asp:DropDownList ID="ddlMerchandiserName" CssClass="form-control2 form-control" runat="server">
                                            </asp:DropDownList>--%>

                                        <asp:TextBox ID="merchandiserNameTextBox" Class=" form-control2 form-control " runat="server" Enabled="false"></asp:TextBox>

                                    </div>
                                    <div class="row">
                                        Office
                                            <%--<asp:DropDownList ID="ddlTTOffice" CssClass="form-control2 form-control" runat="server"></asp:DropDownList>--%>
                                        <asp:TextBox ID="officeTextBox" Class=" form-control2 form-control " runat="server" Enabled="false"></asp:TextBox>
                                    </div>

                                    <div class="row">
                                        Item Group
                                         
                                    </div>

                                    <div class="row" style="padding-top: 10px;">
                                        <asp:Button ID="addButton" runat="server" Text="Add" Class="btn btn-success right" Style="width: 100px;" OnClick="addButton_Click" />
                                    </div>
                                </div>
                            </div>
                        </fieldset>

                        <div class="row">
                            <div class="col-md-12">

                                <asp:GridView ID="grdProductInfo" runat="server" Width="100%" AutoGenerateColumns="False"
                                    PageSize="20" BorderColor="#E3F0FC" CellPadding="5" OnSelectedIndexChanged="grdProductInfo_SelectedIndexChanged">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center">
                                            <HeaderTemplate>
                                                Sl No.
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblSRNO" runat="server"
                                                    Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Id" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProductId" runat="server" Text='<%# Bind("ProductId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ProductName" HeaderText="Product Name">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Brand" HeaderText="Color/ Brand">
                                            <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                            <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" VerticalAlign="Middle"
                                                Width="15%" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Style/Size" DataField="StyleAndSize">
                                            <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                            <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" VerticalAlign="Middle"
                                                Width="15%" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="UnitName" HeaderText="Unit">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ProductType" HeaderText="Product Type">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>
                                        <%--<asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgbtnProductEdit" runat="server" ImageUrl="img/list_edit.png"
                                                    OnClick="imgbtnProductEdit_Click" />
                                            </ItemTemplate>
                                            <ItemStyle Width="6%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="Price">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPrice" runat="server" Text='<%# Bind("Price") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Required Quantity">
                                            <ItemTemplate>
                                                <asp:TextBox ID="requiredQuantityTextBox" Class="form-control " runat="server" Style="width: 100px;" AutoPostBack="True" OnTextChanged="requiredQuantityTextBox_TextChanged"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total Amount">
                                            <ItemTemplate>
                                                <asp:Label ID="totalAmountLabel" runat="server" Text=""></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                    <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <EmptyDataRowStyle ForeColor="Red" />
                                    <PagerSettings Mode="NumericFirstLast" />
                                    <PagerStyle CssClass="pagination01 pageback" />
                                    <RowStyle CssClass="Grid_RowStyle" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:GridView>

                            </div>
                        </div>
                    </div>
                    <div class="row" style="margin: auto 0;">
                        <fieldset style="padding-top: 0px;">
                            <legend style="line-height: 0px; padding-top: 5px;"><span style="background: #fff"></span></legend>
                            <div class="col-md-3" style="background-color: #f0f5f6;">
                                <div class="row">

                                    <div class="col-md-5" style="padding-left: 0px;">
                                        <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="#339933" Font-Size="Large">Fabric</asp:HyperLink>
                                    </div>
                                    <div class="col-md-7" style="padding-right: 0px;">
                                        <asp:TextBox ID="TextBox2" Class="form-control " runat="server" Text="" AutoPostBack="true"></asp:TextBox>
                                    </div>

                                </div>
                                <div class="row" style="padding-top: 5px;">

                                    <div class="col-md-5" style="padding-left: 0px;">

                                        <asp:HyperLink ID="HyperLink2" runat="server" ForeColor="#339933" Font-Size="Large">Accessories</asp:HyperLink>
                                    </div>
                                    <div class="col-md-7" style="padding-right: 0px;">
                                        <asp:TextBox ID="TextBox1" Class="form-control " runat="server" Text="" AutoPostBack="true"></asp:TextBox>
                                    </div>

                                </div>
                            </div>
                            <div class="col-md-9" style="padding-right: 0;">
                                <table class="table table-bordered">
                                    <tr class="info">
                                        <td>Item Type
                                 
                                        </td>
                                        <td>Construction
                                
                                        </td>
                                        <td>GSM</td>
                                        <%-- <td>Balance</td>
                                        <td>Issue Qty</td>--%>
                                    </tr>
                                    <tr>
                                        <td style="width: 200px">
                                            <asp:DropDownList ID="itemTypeDropDownList" Class="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="itemTypeDropDownList_SelectedIndexChanged"></asp:DropDownList>
                                        </td>
                                        <td style="width: 200px">

                                            <asp:DropDownList ID="itemGroupDropDownList" Class="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="itemGroupDropDownList_SelectedIndexChanged"></asp:DropDownList>

                                        </td>
                                        <td style="width: 200px">
                                            <asp:DropDownList ID="gsmGroupDropDownList" runat="server" AutoPostBack="True" Class="form-control">
                                            </asp:DropDownList>
                                        </td>
                                        <%--<td>
                                            <asp:TextBox ID="txtBalanceQty" Class="form-control" Text="0" runat="server" ReadOnly="true"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtIssueQty" Class="form-control" Text="0" runat="server"></asp:TextBox>
                                        </td>--%>
                                    </tr>
                                </table>
                            </div>
                             <asp:GridView ID="YarnDeterminationGridView" runat="server" AutoGenerateColumns="False" Width="100%"
                                            CellPadding="20" BackColor="White" BorderColor="#336666" BorderStyle="Solid"
                                            BorderWidth="1px" AllowPaging="false" EmptyDataText="No Data">
                                            <Columns>
                                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center">
                                                    <HeaderTemplate>
                                                        SL No.
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSRNO" runat="server"
                                                            Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                </asp:TemplateField>

                                                <asp:TemplateField Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblUniqueId" runat="server" Text='<%# Eval("UniqueId")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="FabricNature" HeaderText="Febric Nature">
                                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                    <ItemStyle HorizontalAlign="Left" CssClass="Grid_Border" />
                                                    <FooterStyle CssClass="Grid_Footer" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="GroupName" HeaderText="Contruction">
                                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                    <ItemStyle HorizontalAlign="Left" CssClass="Grid_Border" />
                                                    <FooterStyle CssClass="Grid_Footer" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="GSM" HeaderText="GSM/Weight">
                                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                    <ItemStyle HorizontalAlign="Left" CssClass="Grid_Border" />
                                                    <FooterStyle CssClass="Grid_Footer" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="ColorName" HeaderText="Color Name">
                                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                    <ItemStyle HorizontalAlign="Left" CssClass="Grid_Border" />
                                                    <FooterStyle CssClass="Grid_Footer" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="CompostionPercentage" HeaderText="Compostion %">
                                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                    <ItemStyle HorizontalAlign="Left" CssClass="Grid_Border" />
                                                    <FooterStyle CssClass="Grid_Footer" />
                                                </asp:BoundField>

                                                <%--  <asp:BoundField DataField="Composition" HeaderText="Composition">
                                                         <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                         <ItemStyle HorizontalAlign="Left" CssClass="Grid_Border" />
                                                         <FooterStyle CssClass="Grid_Footer" />
                                                     </asp:BoundField>
                                                     <asp:BoundField DataField="YarnCount" HeaderText="Yarn Count">
                                                         <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                         <ItemStyle HorizontalAlign="Left" CssClass="Grid_Border" />
                                                         <FooterStyle CssClass="Grid_Footer" />
                                                     </asp:BoundField>

                                                     <asp:BoundField DataField="Price" HeaderText="Price">
                                                         <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                         <ItemStyle HorizontalAlign="Left" CssClass="Grid_Border" />
                                                         <FooterStyle CssClass="Grid_Footer" />
                                                     </asp:BoundField>
                                                     <asp:BoundField DataField="unitName" HeaderText="Unit">
                                                         <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                         <ItemStyle HorizontalAlign="Left" CssClass="Grid_Border" />
                                                         <FooterStyle CssClass="Grid_Footer" />
                                                     </asp:BoundField>--%>

                                                <asp:TemplateField HeaderText="Add">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgbtnYarnCountDetEdit2" runat="server" ImageUrl="img/add-1-icon.png" />
                                                    </ItemTemplate>
                                                    <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                                                </asp:TemplateField>

                                            </Columns>
                                            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                                            <EmptyDataRowStyle ForeColor="Red" />
                                            <RowStyle CssClass="Grid_RowStyle" BackColor="White" ForeColor="#333333" />
                                            <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                            <PagerSettings Mode="NumericFirstLast" />
                                            <PagerStyle ForeColor="White" HorizontalAlign="Left" BackColor="#336666" CssClass="pagination01 pageback" />
                                            <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" BackColor="#336666" Font-Bold="True" ForeColor="White" />
                                            <FooterStyle CssClass="Grid_Footer" BackColor="White" ForeColor="#333333" />
                                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                            <SortedAscendingHeaderStyle BackColor="#487575" />
                                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                            <SortedDescendingHeaderStyle BackColor="#275353" />
                                        </asp:GridView>
                                </fieldset>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
