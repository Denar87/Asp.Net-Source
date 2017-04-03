<%@ Page Title="" Language="C#" MasterPageFile="~/Merchandising/Merchandising.Master" AutoEventWireup="true" CodeBehind="NewOrderEntry.aspx.cs" Inherits="ERPSSL.Merchandising.NewOrderEntry" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        function successalert(result) {
            swal({
                title: result,
                type: 'success'
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

    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>



            <div class="row">
                <div class="hm_sec_2_content scrollbar">
                    <div class="panel">
                        <div class="panel-heading panel-heading-01">
                            <i class="glyphicon glyphicon-edit icon-padding"></i>Order Entry 
                        </div>
                    </div>

                    <div class="col-md-12">
                        <%--<div class="row" style="margin-top: 5px;">
                            <asp:Button ID="AddOrder" runat="server" Text="Add New" class="btn btn-info pull-Left" ValidationGroup="Group1" OnClick="AddOrder_Click" />
                        </div>--%>
                        <div class="row" id="ShowDiv" runat="server">
                            <div class="row">
                                &nbsp; &nbsp; Style Wise
                                        <asp:CheckBox ID="chkStleWise" runat="server" Visible="true" AutoPostBack="True" OnCheckedChanged="chkStleWise_CheckedChanged"></asp:CheckBox>
                            </div>
                            <fieldset>
                                <legend style="line-height: 0px; padding-top: 5px;"><span style="background: #fff"></span></legend>
                                <div class="col-md-12" style="background-color: #f0f5f6; padding-bottom: 10px;">

                                    <div class="col-md-3" style="padding-left: 0;">
                                        <div class="row" runat="server" id="OrderNo1">


                                            <div>
                                                Order Received Date
                                            <asp:TextBox ID="txtOrderReceivedDate" Class=" form-control2 form-control " runat="server" placeholder="MM/dd/yyyy"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtOrderReceivedDate"
                                                    PopupButtonID="txtOrderReceivedDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                            </div>
                                            <div>
                                                Order No.<a style="color: red; font-size: 11px">*</a>
                                                <asp:TextBox ID="txtPOrder" Class=" form-control2 form-control " runat="server"></asp:TextBox>
                                            </div>
                                            <div>
                                                <div class="col-md-12" style="padding: 0px;">
                                                    <div class="col-md-1" style="padding: 0px;">
                                                        Style  
                                                    </div>
                                                    <div class="col-md-1">
                                                        <asp:CheckBox ID="chkNewstyle" runat="server" Visible="true" AutoPostBack="True" OnCheckedChanged="chkNewstyle_CheckedChanged"></asp:CheckBox>
                                                    </div>
                                                    <a style="color: red; font-size: 11px">*</a>
                                                    <div class="col-md-10"></div>
                                                </div>
                                                <div class="col-md-12" style="padding: 0px;">
                                                    <asp:DropDownList ID="ddlStyle" CssClass="form-control2 form-control" runat="server">
                                                    </asp:DropDownList>
                                                    <asp:TextBox ID="txtStyle" runat="server" class="form-control" Visible="false"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row" runat="server" visible="false" id="OrderNo2">

                                            <div>
                                                Order Received Date
                                            <asp:TextBox ID="txtOrderReceivedDate1" Class=" form-control2 form-control " runat="server" placeholder="MM/dd/yyyy"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtOrderReceivedDate1"
                                                    PopupButtonID="txtOrderReceivedDate1" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                            </div>
                                            <div class="col-md-12" style="padding: 0px;">
                                                <div class="col-md-1" style="padding: 0px;">
                                                    Style  
                                                </div>
                                                <div class="col-md-1">
                                                    <asp:CheckBox ID="chkNewstyle2" runat="server" Visible="true" AutoPostBack="True" OnCheckedChanged="chkNewstyle2_CheckedChanged"></asp:CheckBox>
                                                </div>
                                                <a style="color: red; font-size: 11px">*</a>
                                                <div class="col-md-10"></div>
                                            </div>
                                            <div class="col-md-12" style="padding: 0px;">
                                                <asp:DropDownList ID="ddlStyle2" CssClass="form-control2 form-control" runat="server">
                                                </asp:DropDownList>
                                                <asp:TextBox ID="txtStyle2" runat="server" class="form-control" Visible="false"></asp:TextBox>
                                            </div>
                                            <div>
                                                Order No.<a style="color: red; font-size: 11px">*</a>
                                                <asp:TextBox ID="txtPOrder2" Class=" form-control2 form-control " runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12" style="padding: 0px;">
                                                <div class="col-md-2" style="padding: 0px;">
                                                    Season 
                                                <asp:HiddenField ID="hidSeasonID" runat="server" />
                                                </div>
                                                <div class="col-md-1">
                                                    <asp:CheckBox ID="ChkSeason" runat="server" Visible="true" AutoPostBack="True" OnCheckedChanged="ChkSeason_CheckedChanged"></asp:CheckBox>
                                                </div>
                                                <a style="color: red; font-size: 11px">*</a>
                                                <div class="col-md-9"></div>
                                            </div>
                                            <div class="col-md-12" style="padding: 0px;">
                                                <asp:DropDownList ID="ddlSeason" AutoPostBack="true" CssClass="form-control" runat="server">
                                                </asp:DropDownList>
                                                <asp:TextBox ID="txtSeason" runat="server" class="form-control" Visible="false"></asp:TextBox>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="col-md-3">
                                        <div class="row">
                                            Buyer <a style="color: red; font-size: 11px">*</a>
                                            <asp:DropDownList ID="ddlBuyer" CssClass="form-control2 form-control" runat="server" OnSelectedIndexChanged="ddlBuyer_SelectedIndexChanged" AutoPostBack="True">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="row">
                                            Country
                                            <asp:TextBox ID="countryTextBox" runat="server" class="form-control" Enabled="false"></asp:TextBox>

                                        </div>
                                        <div class="row">

                                            <div class="col-md-12" style="padding: 0px;">
                                                <div class="col-md-5" style="padding: 0px;">
                                                    Buyer Department 
                                                </div>
                                                <div class="col-md-1">
                                                    <asp:CheckBox ID="chkBuyerDepartment" runat="server" AutoPostBack="True" OnCheckedChanged="chkBuyerDepartment_CheckedChanged"></asp:CheckBox>
                                                </div>
                                                <a style="color: red; font-size: 11px">*</a>
                                                <div class="col-md-6"></div>
                                            </div>
                                            <div class="col-md-12" style="padding: 0px;">
                                                <asp:DropDownList ID="ddlBuyerDepartment" AutoPostBack="true"
                                                    CssClass="form-control" runat="server">
                                                </asp:DropDownList>
                                                <asp:TextBox ID="txtBuyerDepartment" runat="server" class="form-control" Visible="false"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12" style="padding: 0px;">
                                                <div class="col-md-3" style="padding: 0px;">
                                                    Category
                                                </div>
                                                <div class="col-md-1">
                                                    <asp:CheckBox ID="chkCategory" runat="server" AutoPostBack="True" OnCheckedChanged="chkCategory_CheckedChanged"></asp:CheckBox>
                                                </div>
                                                <a style="color: red; font-size: 11px">*</a>
                                                <div class="col-md-8"></div>
                                            </div>
                                            <div class="col-md-12" style="padding: 0px;">
                                                <asp:DropDownList ID="ddlCategory" AutoPostBack="true"
                                                    CssClass="form-control" runat="server">
                                                </asp:DropDownList>
                                                <asp:TextBox ID="txtCategory" runat="server" class="form-control" Visible="false"></asp:TextBox>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="col-md-3">
                                        <div class="row">
                                            Item Description
                                            <asp:TextBox ID="txtItemDescription" Class=" form-control2 form-control " runat="server"></asp:TextBox>
                                        </div>
                                        <div class="row">

                                            <div class="col-md-6" style="padding-left: 0px;">
                                                Quantity
                                                <asp:TextBox ID="txtOrderQty" Class="form-control " runat="server" Text="0" AutoPostBack="true"></asp:TextBox>
                                            </div>
                                            <div class="col-md-6" style="padding-right: 0px;">
                                                Unit
                                                <asp:DropDownList ID="ddlUnit" CssClass=" form-control" runat="server">
                                                </asp:DropDownList>
                                            </div>

                                        </div>
                                        <div class="row">
                                            Currency
                                        <asp:DropDownList ID="ddlCurrency" CssClass="form-control2 form-control" runat="server">
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
                                            <asp:TextBox ID="txtFOBPort" Class=" form-control2 form-control " runat="server"></asp:TextBox>
                                        </div>

                                    </div>
                                    <div class="col-md-3">

                                        <div class="row">
                                            Shipment Mode
                                        <asp:DropDownList ID="ddlShipmentMode" CssClass="form-control2 form-control" runat="server">
                                            <asp:ListItem>---Select---</asp:ListItem>
                                            <asp:ListItem>By Air</asp:ListItem>
                                            <asp:ListItem>By Sea</asp:ListItem>
                                            <asp:ListItem>By Land</asp:ListItem>
                                        </asp:DropDownList>
                                        </div>
                                        <div class="row">
                                            <asp:HiddenField ID="HiddenField1" runat="server" />
                                            Shipment Date
                                            <asp:TextBox ID="txtShipmentDate" Class=" form-control2 form-control " runat="server" placeholder="MM/dd/yyyy"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender14" runat="server" TargetControlID="txtShipmentDate"
                                                PopupButtonID="txtShipmentDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                        </div>
                                        <div class="row">
                                            Merchandiser Name
                                            <asp:DropDownList ID="ddlMerchandiserName" CssClass="form-control2 form-control" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="row">
                                            Office
                                            <asp:DropDownList ID="ddlTTOffice" CssClass="form-control2 form-control" runat="server"></asp:DropDownList>
                                        </div>

                                    </div>
                            </fieldset>

                            <div class="row" style="margin-top: 3px; padding-right: 40px;">
                                <asp:Button ID="btnSubmit" runat="server" Text="Add" class="btn btn-info pull-right" ValidationGroup="Group1" OnClick="btnSubmit_Click" />
                            </div>
                        </div>
                        <div class="row" id="ShowGrid" runat="server" style="padding-top: 5px;">
                            <div class="col-md-12" style="padding-left: 0;">
                                <div class="row">
                                    <div class="col-md-2" style="padding-left: 0;">
                                        <div class="row">
                                            Order No.
                                                <asp:TextBox ID="txtS_OrderNo" Class="form-control" AutoPostBack="true" runat="server"></asp:TextBox>
                                            <cc1:AutoCompleteExtender ServiceMethod="SearchOrderNo"
                                                MinimumPrefixLength="1"
                                                CompletionInterval="100" EnableCaching="False"
                                                TargetControlID="txtS_OrderNo"
                                                ID="AutoCompleteExtender2" runat="server" DelimiterCharacters="" Enabled="True" ServicePath="">
                                            </cc1:AutoCompleteExtender>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="row">
                                            Style
                                                <asp:DropDownList ID="searchStyleddl" Class="form-control" AutoPostBack="true" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <%-- <div class="col-md-2" style="padding-bottom: 5px;">
                                        <div class="row">
                                            Principal
                                                <asp:DropDownList ID="ddlS_Principal" Class="form-control" AutoPostBack="true" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>--%>
                                    <div class="col-md-2" style="padding-bottom: 5px;">
                                        <div class="row">
                                            Buyer
                                                <asp:DropDownList ID="searchBuyerdllr" Class="form-control" AutoPostBack="true" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <%--<div class="col-md-2" style="padding-bottom: 5px;">
                                        <div class="row">
                                            Factory
                                                <asp:DropDownList ID="ddlS_Factory" Class="form-control" AutoPostBack="true" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>--%>
                                </div>
                            </div>
                            <div class="col-md-12" style="padding-left: 0; margin: auto 0;">
                                <div class="row" style="padding-left: 0; padding-top: 5px; margin: auto 0;">
                                    <fieldset style="margin: auto 0;">
                                        <legend style="line-height: 0px; padding-top: 5px;"><span style="background: #fff">Order Sheet</span></legend>
                                        <div class="row" style="overflow-x: hidden; overflow-y: scroll; max-height: 400px; height: auto; margin: auto 0;">
                                            <asp:GridView ID="grdorder" runat="server" AutoGenerateColumns="False" Width="100%"
                                                CellPadding="20" BackColor="White" BorderColor="#336666" BorderStyle="Solid"
                                                BorderWidth="1px" AllowPaging="false">
                                                <Columns>
                                                    <asp:BoundField DataField="OrderId" HeaderText="Id" Visible="false"></asp:BoundField>
                                                    <asp:TemplateField Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblOrderEntryID" runat="server" Text='<%# Eval("OrderId")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblOrderNo" runat="server" Text='<%# Eval("OrderNo")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblStyleId" runat="server" Text='<%# Eval("StyleId")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblStyle" runat="server" Text='<%# Eval("Style")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblBuyerId" runat="server" Text='<%# Eval("BuyerId")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblBuyer" runat="server" Text='<%# Eval("Buyer")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblQuantity" runat="server" Text='<%# Eval("Quantity")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="OrderNo" HeaderText="Order No">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Style" HeaderText="Style">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Buyer" HeaderText="Buyer Name">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Quantity" HeaderText="Order Quantity">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="ShipmentDate" HeaderText="Shipment Date" DataFormatString="{0:MM/dd/yyyy}">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Edit">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="imgbtnOrderSheetEdit" runat="server" ImageUrl="img/list_edit.png" OnClick="imgbtnOrderSheetEdit_Click" />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Color & Size">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="imgbtnAdd" runat="server" ImageUrl="~/Merchandising/img/add-1-icon.png" OnClick="imgbtnAdd_Click" />
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
                                        </div>
                                    </fieldset>
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
            else if (result === 'Data Post Successfully !') {
                toastr.success(result);
            }
            else if (result === 'Data Already Exist') {
                toastr.error(result);
            }
            else if (result === 'Data Updated Successfully') {
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
