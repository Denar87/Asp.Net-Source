<%@ Page Title="" Language="C#" MasterPageFile="~/Commercial/ComSite.Master" AutoEventWireup="true" CodeBehind="CreateInvoice.aspx.cs" Inherits="ERPSSL.Commercial.CreateInvoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
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

        .lblText {
            text-align: center;
            font-size: 1em;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePageMethods="true" EnablePartialRendering="true" ID="ToolkitScriptManager1" />
    <script src="content/js/bootstrap-datetimepicker.js" type="text/javascript"></script>

    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="hm_sec_2_content scrollbar">
                    <div class="panel">
                        <div class="panel-heading panel-heading-01">
                            <i class="glyphicon glyphicon-edit icon-padding"></i>Create Invoice
                        </div>
                    </div>
                    <div class="col-md-12 bg-success">
                        <center>
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label>
                        </center>
                    </div>
                    <div class="row" style="margin: 0 auto">
                        <%-- <div class="col-md-12" style="margin: auto 0; padding: 0px;">--%>
                        <div class="col-md-12" style="margin: auto 0;">
                            <div class="row" style="margin: auto 0;">
                                <div class="col-md-3">
                                    <div class="row" style="padding-top: 5px">
                                        Invoice Ref. No.<a style="color: red; font-size: 11px">*</a>
                                        <asp:TextBox ID="txtInvoiceNo" runat="server" ToolTip="Enter Invoice Number" placeholder="Invoice No" class="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtInvoiceNo"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Group1"
                                            Font-Size="11px" ToolTip="Enter Invoice Number"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="row" style="padding-top: 5px">
                                        Invoice Date<a style="color: red; font-size: 11px">*</a>
                                        <asp:TextBox ID="txtinvoiceDate" runat="server" placeholder="MM/dd/yyyy" class="form-control"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtinvoiceDate"
                                            PopupButtonID="Image_AT" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtinvoiceDate"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Group1"
                                            Font-Size="11px"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="row" style="padding-top: 5px">
                                        Order Number
                                        <asp:TextBox ID="txtOrderNumber" runat="server" ToolTip="Search With Order Number" OnTextChanged="txtOrderNumber_TextChanged"
                                            placeholder="Search With Order Number" AutoPostBack="true" class="form-control"></asp:TextBox>
                                        <cc1:AutoCompleteExtender ServiceMethod="SearchOrderNo"
                                            MinimumPrefixLength="1"
                                            CompletionInterval="100" EnableCaching="False"
                                            TargetControlID="txtOrderNumber"
                                            ID="AutoCompleteExtender1" runat="server" DelimiterCharacters="" Enabled="True" ServicePath="">
                                        </cc1:AutoCompleteExtender>
                                        <asp:HiddenField ID="HidOrderId" runat="server" />
                                        <%--<asp:DropDownList ID="ddlPoOrder" AutoPostBack="true" OnSelectedIndexChanged="ddlPoOrder_SelectedIndexChanged" CssClass="form-control" runat="server">
                                           </asp:DropDownList>--%>
                                    </div>
                                    <div class="row" style="padding-top: 5px">
                                        Style
                                           <asp:DropDownList ID="ddlStyle" AutoPostBack="true" OnSelectedIndexChanged="ddlStyle_SelectedIndexChanged" CssClass="form-control" runat="server">
                                           </asp:DropDownList>
                                    </div>
                                    <div class="row" style="padding-top: 5px">
                                        Buyer Name<a style="color: red; font-size: 11px">*</a>
                                        <asp:DropDownList ID="ddlBayer" OnSelectedIndexChanged="ddlBayer_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>

                                </div>
                                <div class="col-md-3">
                                    <div class="row" style="padding-top: 5px">
                                        Buyer Country
                                           <asp:TextBox ID="txtOriginatedCountry" runat="server" ReadOnly="true" placeholder="Country of Buyer" class="form-control"></asp:TextBox>
                                    </div>
                                    <div class="row" style="padding-top: 5px">
                                        Buying Dept.
                                            <asp:TextBox ID="txtBuyingDept" runat="server" ReadOnly="true" placeholder="Buying Dept." class="form-control"></asp:TextBox>
                                    </div>
                                    <div class="row" style="padding-top: 5px">
                                        Consignee
                                            <asp:TextBox ID="txtConsignee" runat="server" ReadOnly="true" placeholder="Consignee" class="form-control"></asp:TextBox>
                                    </div>
                                    <div class="row" style="padding-top: 5px">
                                        Notify Party
                                            <asp:TextBox ID="txtNotifyParty" runat="server" ReadOnly="true" placeholder="Notify Party" class="form-control"></asp:TextBox>
                                    </div>
                                    <div class="row" style="padding-top: 5px">
                                        Destination
                                            <asp:TextBox ID="txtDestination" runat="server" placeholder="Destination.." ReadOnly="true" class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="row" style="padding-top: 5px">
                                        Delivery address
                                          <asp:TextBox ID="txtDeliveryAddress" runat="server" ReadOnly="true" placeholder=" Delivery address" class="form-control"></asp:TextBox>
                                    </div>
                                    <div class="row" style="padding-top: 5px">
                                        EXP. Ref. NO.<a style="color: red; font-size: 11px">*</a>
                                        <asp:TextBox ID="txtExpNo" ToolTip="Enter EXP. Ref. NO." runat="server" placeholder="EXP NO." class="form-control"></asp:TextBox>
                                    </div>
                                    <div class="row" style="padding-top: 5px">
                                        EXP. Date<a style="color: red; font-size: 11px">*</a>
                                        <asp:TextBox ID="txtExpDate" runat="server" placeholder="MM/dd/yyyy" class="form-control"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtExpDate"
                                            PopupButtonID="Image_AT" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtExpDate"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Group1"
                                            Font-Size="11px"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="row" style="padding-top: 5px">
                                        LC NO.<a style="color: red; font-size: 11px">*</a>
                                        <asp:DropDownList ID="ddlLCNo" OnSelectedIndexChanged="ddlLCNo_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" runat="server">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlLCNo"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Group1"
                                            Font-Size="11px"></asp:RequiredFieldValidator>
                                    </div>

                                    <div class="row" style="padding-top: 5px">
                                        LC Date
                                        <asp:TextBox ID="txtLCDate" runat="server" Enabled="false" ReadOnly="true" placeholder="MM/dd/yyyy" class="form-control"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtLCDate"
                                            PopupButtonID="Image_AT" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                    </div>

                                </div>
                                <div class="col-md-3">
                                    <div class="row" style="padding-top: 5px">
                                        L/C  Issuing Bank
                                           <asp:TextBox ID="txtIssueBank" runat="server" ReadOnly="true" placeholder=" L/C Issuing Bank" class="form-control"></asp:TextBox>
                                    </div>

                                    <div class="row" style="padding-top: 5px">
                                        Marks & Numbers
                                             <asp:TextBox ID="txtMarksNumbers" placeholder="Marks & Numbers" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="row" style="padding-top: 5px">
                                        Container No.
                                           <asp:TextBox ID="ttxtContainerNo" placeholder="Container No." CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>

                                    <div class="row" style="padding-top: 5px">
                                        No. & Kind of Packages
                                           <asp:TextBox ID="txtNoKindofPackages" placeholder="No. & Kind of Packages" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="row" style="padding-top: 5px">
                                        Remarks
                                           <asp:TextBox ID="txtRemarks" runat="server" placeholder="Remarks" class="form-control"></asp:TextBox>
                                    </div>
                                    <div class="row" style="padding-top: 5px; visibility: hidden">
                                        Season<a style="color: red; font-size: 11px">*</a>
                                        <asp:DropDownList ID="ddlSeason" AutoPostBack="true" OnSelectedIndexChanged="ddlSeason_SelectedIndexChanged" CssClass="form-control" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>

                            </div>
                            <div class="row" runat="server" id="showOrderList" style="overflow-x:scroll; overflow-y:hidden">
                                <%--<fieldset>--%>
                                    <legend style="line-height: 0px; padding-top: 5px; padding-bottom:10px;"><span style="background: #fff">Invoice List</span></legend>
                                    <asp:GridView ID="grdorder" runat="server" AutoGenerateColumns="False" Width="120%" 
                                        CellPadding="100" BackColor="White" BorderColor="#336666" BorderStyle="Solid"
                                        BorderWidth="1px" AllowPaging="True" OnRowCommand="grdorder_RowCommand" OnRowDataBound="grdorder_RowDataBound">
                                        <Columns>

                                            <asp:TemplateField HeaderText="Id" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOrderEntryID" runat="server" Text='<%# Bind("OrderEntryID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:CheckBox runat="server" ID="headerLevelCheckBox" AutoPostBack="true" OnCheckedChanged="headerLevelCheckBox_CheckedChanged1" />
                                                    <itemstyle horizontalalign="Center" width="1%" cssclass="Grid_Border" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="rowLevelCheckBox" runat="server" />
                                                    <headerstyle verticalalign="Middle" cssclass="Grid_Header" />
                                                    <itemstyle horizontalalign="Center" width="1%" cssclass="Grid_Border" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="1%" CssClass="Grid_Border" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Order No." Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOrderNo" runat="server" Text='<%# Bind("OrderNo") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Article">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblArticle" runat="server" Text='<%# Bind("Article") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                            </asp:TemplateField>
                                            <%-------------------------%>

                                            <asp:TemplateField HeaderText="Item Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblItemName" runat="server" Text='<%# Bind("ItemName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="Price">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPrice" runat="server" Text='<%# Bind("Price") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="Size">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSize" runat="server" Text='<%# Bind("Size") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="Total Amount">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTotalAmount" runat="server" Text='<%# Bind("TotalAmount") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                            </asp:TemplateField>
                                            <%-------------------------%>
                                            <asp:TemplateField HeaderText="Style">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStyle" runat="server" Text='<%# Bind("Style") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Color">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblColorSpecification" runat="server" Text='<%# Bind("Color") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Order Qty">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOrderQuantity" runat="server" Text='<%# Bind("orderQuntity") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="CAT">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtCAT" runat="server" Width="100%" Style="text-align: center"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="4%" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="H.S Code">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtHSCode" Width="100%"  Text='<%# Bind("H_S_Code") %>' runat="server"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="7%" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Qty">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtQty" runat="server" Width="100%" Style="text-align: center"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="6%" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Unit">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlReqUnit" runat="server" Width="100%" Style="text-align: center"></asp:DropDownList>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="8%" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Price($)">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtPrice" runat="server" Width="100%" AutoPostBack="true" OnTextChanged="txtPrice_TextChanged" Style="text-align: center"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Currency">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlCurrency" runat="server" Width="100%" Style="text-align: center">
                                                        <asp:ListItem Value="USD">USD (US Dollar)</asp:ListItem>
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
                                                        <asp:ListItem Value="UYU">UYU (Uruguayan Peso)</asp:ListItem>
                                                        <asp:ListItem Value="UZS">UZS (Uzbekistan Som)</asp:ListItem>
                                                        <asp:ListItem Value="VEF">VEF (Venezuelan Bolívar)</asp:ListItem>
                                                        <asp:ListItem Value="VND">VND (Vietnamese Dong)</asp:ListItem>
                                                        <asp:ListItem Value="XOF">XOF (CFA Franc BCEAO)</asp:ListItem>
                                                        <asp:ListItem Value="YER">YER (Yemeni Rial)</asp:ListItem>
                                                        <asp:ListItem Value="ZAR">ZAR (South African Rand)</asp:ListItem>
                                                        <asp:ListItem Value="ZMK">ZMK (Zambian Kwacha)</asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Rate" Visible="false">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtRate" runat="server" Width="100%" Style="text-align: right"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="4%" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Total Value">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAmount" runat="server" Width="100%" Style="text-align: center"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="7%" />
                                            </asp:TemplateField>

                                            <%--<asp:BoundField DataField="ShipmentDate" HeaderText="Shipment Date" DataFormatString="{0:dd MMM, yyyy}" HtmlEncode="false">
                                                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                                </asp:BoundField>--%>
                                        </Columns>
                                        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                                        <EmptyDataRowStyle ForeColor="Red" />
                                        <RowStyle CssClass="Grid_RowStyle" BackColor="White" ForeColor="#333333" />
                                        <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                        <PagerSettings Mode="NumericFirstLast" />
                                        <PagerStyle ForeColor="White" HorizontalAlign="Left" BackColor="#336666" CssClass="pagination01 pageback" />
                                        <HeaderStyle Width="20%" VerticalAlign="Middle" CssClass="Grid_Header" BackColor="#336666"
                                            Font-Bold="True" ForeColor="White" />
                                        <FooterStyle CssClass="Grid_Footer" BackColor="White" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                        <SortedAscendingHeaderStyle BackColor="#487575" />
                                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                        <SortedDescendingHeaderStyle BackColor="#275353" />
                                    </asp:GridView>
                                    <div class="col-md-12" style="padding-top: 8px;">
                                        <div class="col-md-4">
                                        </div>
                                        <div class="col-md-8">
                                            <asp:Button ID="btnAdd" runat="server" ValidationGroup="Group1" Text="Add" class="btn btn-primary pull-right" OnClick="btnAdd_Click" />
                                        </div>
                                    </div>
                               <%-- </fieldset>--%>
                            </div>
                        </div>
                        <%--<div class="row" style="padding-top: 8px;">
                           
                        </div>--%>
                        <div class="row" style="margin: auto 0;" runat="server" id="showDiv">
                            <fieldset>
                                <legend style="line-height: 0px; padding-top: 5px;"><span style="background: #fff">Invoice</span></legend>
                                <asp:GridView ID="grdInvoice" runat="server" AutoGenerateColumns="False" Width="99%"
                                    CellPadding="100" BackColor="White" BorderColor="#336666" BorderStyle="Solid"
                                    BorderWidth="1px" AllowPaging="True" OnRowDataBound="grdInvoice_RowDataBound">
                                    <Columns>

                                        <asp:BoundField DataField="InvoiceNo" HeaderText="Invoice No">
                                            <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Article" HeaderText="Article">
                                            <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Style" HeaderText="Style">
                                            <ItemStyle HorizontalAlign="Center" Width="7%" CssClass="Grid_Border" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="CAT_No" HeaderText="CAT No">
                                            <ItemStyle HorizontalAlign="Center" Width="7%" CssClass="Grid_Border" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="OrderQty" HeaderText="Order Qty.">
                                            <ItemStyle HorizontalAlign="Center" Width="7%" CssClass="Grid_Border" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="Total" HeaderText="Total">
                                            <ItemStyle HorizontalAlign="Center" Width="7%" CssClass="Grid_Border" />
                                        </asp:BoundField>

                                    </Columns>
                                    <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                                    <EmptyDataRowStyle ForeColor="Red" />
                                    <RowStyle CssClass="Grid_RowStyle" BackColor="White" ForeColor="#333333" />
                                    <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                    <PagerSettings Mode="NumericFirstLast" />
                                    <PagerStyle ForeColor="White" HorizontalAlign="Left" BackColor="#336666" CssClass="pagination01 pageback" />
                                    <HeaderStyle Width="20%" VerticalAlign="Middle" CssClass="Grid_Header" BackColor="#336666"
                                        Font-Bold="True" ForeColor="White" />
                                    <FooterStyle CssClass="Grid_Footer" BackColor="White" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                    <SortedAscendingHeaderStyle BackColor="#487575" />
                                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                    <SortedDescendingHeaderStyle BackColor="#275353" />
                                </asp:GridView>
                                <asp:Label ID="lblTotalCost" Style="float: right; margin-right: 80px;" runat="server" Font-Bold="true" Font-Size="12px" ForeColor="Maroon"></asp:Label>
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-md-4">
                                            <div class="row">
                                                <div class="col-md-12" style="padding-top: 5px;">
                                                    <div class="row">
                                                        <div class="col-md-8">
                                                            TOTAL CTNS :
                                                        
                                                            <asp:TextBox ID="txtTotalCtns" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtTotalCtns_TextChanged"></asp:TextBox>
                                                        </div>
                                                        <div class="col-md-3" style="padding-top: 15px;">
                                                            <asp:Label ID="lblTotalCtns" ForeColor="#800000" CssClass="lblText" Font-Bold="true" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-1">
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-12" style="padding-top: 5px;">
                                                    <div class="row">
                                                        <div class="col-md-8">
                                                            GROSS WGT KGS :
                                                            <asp:TextBox ID="txtGrssWgt" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtGrssWgt_TextChanged"></asp:TextBox>
                                                        </div>
                                                        <div class="col-md-3" style="padding-top: 15px;">
                                                            <asp:Label ID="lblGrssWgt" ForeColor="#800000" CssClass="lblText" Font-Bold="true" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-1">
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="row">
                                                <div class="col-md-12" style="padding-top: 5px;">
                                                    <div class="row">
                                                        <div class="col-md-8">
                                                            NET WGT KGS :
                                                       
                                                            <asp:TextBox ID="txtNetWgt" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtNetWgt_TextChanged"></asp:TextBox>
                                                        </div>
                                                        <div class="col-md-3" style="padding-top: 15px;">
                                                            <asp:Label ID="lblNetWgt" ForeColor="#800000" CssClass="lblText" Font-Bold="true" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-1">
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-12" style="padding-top: 5px;">
                                                    <div class="row">
                                                        <div class="col-md-8">
                                                            CUBIC M3 CBM :
                                                        
                                                            <asp:TextBox ID="txtCubicM" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtCubicM_TextChanged"></asp:TextBox>
                                                        </div>
                                                        <div class="col-md-3" style="padding-top: 15px;">
                                                            <asp:Label ID="lblCubic" ForeColor="#800000" CssClass="lblText" Font-Bold="true" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-1">
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="row">
                                                        <div class="col-md-8">
                                                            Less % Bonus
                                                       
                                                            <asp:TextBox ID="txtLessBonus" runat="server" placeholder="Less % Bonus" CssClass="form-control"
                                                                AutoPostBack="true" OnTextChanged="txtLessBonus_TextChanged"></asp:TextBox>
                                                        </div>
                                                        <div class="col-md-3" style="padding-top: 15px;">
                                                            <asp:Label ID="lblLessBonus" CssClass="lblText" ForeColor="#800000" Font-Bold="true" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-1">
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-12" style="padding-top: 5px;">
                                                    <div class="row">
                                                        <div class="col-md-8">
                                                            Less % P.R.C.
                                                        
                                                            <asp:TextBox ID="txtLessPRC" runat="server" placeholder="Less % P.R.C." CssClass="form-control"
                                                                AutoPostBack="true" OnTextChanged="txtLessPRC_TextChanged"></asp:TextBox>
                                                        </div>
                                                        <div class="col-md-3" style="padding-top: 15px;">
                                                            <asp:Label ID="lblLessPRC" ForeColor="#800000" CssClass="lblText" Font-Bold="true" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-1">
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </fieldset>
                            <div class="col-md-12">
                                <div class="row">
                                    <div class="col-md-8"></div>
                                    <div class="col-md-4">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                    </div>
                                                    <div class="col-md-4" id="Div1" runat="server" visible="false">
                                                        Grand Total
                                                    </div>
                                                    <div class="col-md-3">
                                                        <asp:Label ID="lblGrandTotal" ForeColor="#800000" CssClass="lblText" Font-Bold="true" runat="server"></asp:Label>
                                                    </div>
                                                    <div class="col-md-1">
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row" style="padding-top: 8px;">
                            <div class="col-md-12">
                                <div class="col-md-4">
                                </div>
                                <div class="col-md-7">
                                    <asp:Button ID="btnSubmit" Visible="false" runat="server" Text="Submit" class="btn btn-info pull-right" OnClick="btnSubmit_Click" />
                                </div>
                                <div class="col-md-1">
                                    <asp:Button ID="btnPrint" Visible="false" runat="server" Text="Print" class="btn btn-Default pull-right" OnClick="btnPrint_Click" />
                                </div>
                            </div>
                        </div>

                        <div class="col-md-12">
                            <rsweb:ReportViewer ID="ReportViewerInvoice" AsyncRendering="False" interactivedeviceinfos="(Collection)"
                                SizeToReportContent="True" Width="100%" Height="700px" runat="server" Font-Names="Verdana"
                                Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" BackColor="White">
                            </rsweb:ReportViewer>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>

        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="txtLessBonus" EventName="TextChanged" />
            <asp:AsyncPostBackTrigger ControlID="txtLessPRC" EventName="TextChanged" />
        </Triggers>

    </asp:UpdatePanel>

    <script type="text/javascript">
        function func(result) {
            if (result === 'Data Saved Successfully') {
                toastr.success(result);
            }
            else if (result === 'Data Post Successfully !') {
                toastr.success(result);
            }
            else if (result === 'Data Added Successfully') {
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
