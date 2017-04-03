<%@ Page Title="" Language="C#" MasterPageFile="~/INV/Site.Master" AutoEventWireup="true"
    CodeBehind="RecieveGeneral_withoutBarcode.aspx.cs" Inherits="ERPSSL.INV.RecieveGeneral_withoutBarcode" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

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

        .CustomCSSFooter {
            font-size: 11px;
            color: Maroon;
            float: right;
        }

        .LoaderBackground_ {
            /*background-color:;*/
            filter: alpha(opacity=90);
            opacity: 0.9;
            z-index: 999999999;
            overflow: hidden;
            width: 20%;
            height: 20%;
            position: absolute;
            margin: 170px 300px 0;
        }

        .LoaderBackground_Image {
            display: block;
            position: absolute;
            left: 48%;
            top: 40%;
            width: 50px;
            height: 50px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <script src="content/js/bootstrap-datetimepicker.js" type="text/javascript"></script>
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="hm_sec_2_content scrollbar">
                    <div class="panel">
                        <div class="panel-heading panel-heading-01">
                            <i class="glyphicon glyphicon-edit icon-padding"></i>Material Receive General
                        </div>
                    </div>
                    <div class="col-md-12 bg-success">
                        <center>
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label></center>
                    </div>
                    <div class="col-md-12">
                        <div class="row" style="padding-top: 5px; margin: auto 0;">
                            <div class="col-md-6">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            Store<a style="color: red; font-size: 11px">*</a>
                                        </div>
                                        <div class="col-md-8">
                                            <asp:DropDownList ID="ddlStore" Class="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlStore_SelectedIndexChanged"
                                                Visible="True">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlStore"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Store"
                                                Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="row" style="padding-top: 5px">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            Supplier<a style="color: red; font-size: 11px">*</a>
                                        </div>
                                        <div class="col-md-8">
                                            <asp:DropDownList ID="ddlSupplier" Class="form-control" runat="server" AutoPostBack="True"
                                                OnSelectedIndexChanged="ddlSupplier_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlSupplier"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Supplier"
                                                Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="row" style="padding-top: 5px">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            Ref.No./Challan No.<a style="color: red; font-size: 11px">*</a>
                                        </div>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtRefNo" Class="form-control" placeholder="Ref.No./ Challan No." runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtRefNo"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Enter Ref. No."
                                                Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <%--<div class="row" style="padding-top: 5px">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            Season
                                        </div>
                                        <div class="col-md-8">
                                            <asp:DropDownList ID="ddlSeason" Class="form-control" OnSelectedIndexChanged="ddlSeason_SelectedIndexChanged" runat="server" AutoPostBack="True">
                                                <asp:ListItem Value="0">--Select One--</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>--%>
                                <div class="row" style="padding-top: 5px">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            Order
                                        </div>
                                        <div class="col-md-8">
                                            <asp:DropDownList ID="ddlOrder" Class="form-control" placeholder="Order" runat="server" AutoPostBack="True">
                                                <asp:ListItem Value="0">--Select One--</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row" style="padding-top: 5px">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            Master L/C No.
                                        </div>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtMasterLCNo" Class="form-control" runat="server" placeholder="Master L/C No."></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            Date<a style="color: red; font-size: 11px">*</a>
                                        </div>
                                        <div class="col-md-8">
                                            <asp:TextBox Class="form-control" runat="server" ID="txtDate" autocomplete="off"
                                                placeholder="MM/dd/yyyy"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtDate"
                                                Display="Dynamic" ErrorMessage="Select Recieved Date" ForeColor="Red" SetFocusOnError="True"
                                                Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate"
                                                PopupButtonID="Image_AT" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row" style="padding-top: 5px">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            MRR No.
                                        </div>
                                        <div class="col-md-8">
                                            <asp:TextBox Class="form-control" runat="server" placeholder="MRR No." ID="txtChallanNo" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row" style="padding-top: 5px">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            B2B L/C No.
                                        </div>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtB2BLCNo" Class="form-control" runat="server" placeholder="B2B L/C No."></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row" style="padding-top: 5px">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            P.I. No.
                                        </div>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtPINo" Class="form-control" runat="server" placeholder="P. I. No"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row" style="padding-top: 5px">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            Receiver E-ID
                                        </div>
                                        <div class="col-md-3">
                                            <asp:TextBox ID="txtReceiverEID" placeholder="Receiver E-ID" Width="110%" OnTextChanged="txtReceiverEID_TextChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>
                                            <cc1:AutoCompleteExtender ServiceMethod="SearchCurrentEmployee"
                                                MinimumPrefixLength="1"
                                                CompletionInterval="100" EnableCaching="False"
                                                TargetControlID="txtReceiverEID"
                                                ID="AutoCompleteExtender1" runat="server" DelimiterCharacters="" Enabled="True" ServicePath="">
                                            </cc1:AutoCompleteExtender>
                                        </div>
                                        <div class="col-md-5">
                                            <asp:TextBox ID="txtReceiverName" Width="100%" placeholder="Receiver Name" ReadOnly="true" Class="form-control" runat="server"></asp:TextBox>
                                            <asp:HiddenField ID="hIdEid" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-12" style="padding-top: 5px;">
                            <table class="table table-bordered">
                                <tr class="info">
                                    <td>Item Category
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" SetFocusOnError="true" ControlToValidate="ddlProductGroup"
                                     ErrorMessage="*" ValidationGroup="ValPrice"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>Item
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" SetFocusOnError="true" ControlToValidate="ddlProductName"
                                    ErrorMessage="*" ValidationGroup="ValPrice"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>Receive Qty
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" SetFocusOnError="true" ControlToValidate="txtReceiveQty"
                                    ErrorMessage="*" ValidationGroup="ValPrice"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>Actual Qty / Free Qty.
                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" SetFocusOnError="true" ControlToValidate="txtUnit"
                                       ErrorMessage="*" ValidationGroup="ValPrice"></asp:RequiredFieldValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" SetFocusOnError="true" ControlToValidate="txtReOrderQty"
                                            ErrorMessage="*" InitialValue="0" ValidationGroup="ValPrice"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>Unit / ReOrder
                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" SetFocusOnError="true" ControlToValidate="txtUnit"
                                       ErrorMessage="*" ValidationGroup="ValPrice"></asp:RequiredFieldValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" SetFocusOnError="true" ControlToValidate="txtReOrderQty"
                                            ErrorMessage="*" InitialValue="0" ValidationGroup="ValPrice"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>Balance</td>
                                </tr>
                                <tr>
                                    <td style="width: 200px">
                                        <asp:DropDownList ID="ddlProductGroup" Class="form-control" runat="server" AutoPostBack="True"
                                            OnSelectedIndexChanged="ddlProductGroup_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="ddlStoreName" Enabled="false" Class="form-control" Visible="false" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 200px">
                                        <asp:DropDownList ID="ddlProductName" Class="form-control" runat="server" AutoPostBack="True"
                                            OnSelectedIndexChanged="ddlProductName_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtReceiveQty" Text="0" Style="color: maroon" AutoPostBack="true" OnTextChanged="txtReceiveQty_TextChanged" Class="form-control" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <div class="row">
                                            <div class="col-md-6" style="padding: 0px;">
                                                <asp:HiddenField ID="HidActualAmount" runat="server" />
                                                <asp:TextBox ID="txtActualQty" Class="form-control" Text="0" Width="90%" AutoPostBack="true" OnTextChanged="txtActualQty_TextChanged" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-md-6" style="padding: 0px;">
                                                <asp:HiddenField ID="HidFreeAmount" runat="server" />
                                                <asp:TextBox ID="txtFreeQty" Class="form-control" Text="0" Width="90%" runat="server" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                    </td>
                                    <td>
                                        <div class="row">
                                            <div class="col-md-6" style="padding: 0px;">
                                                <asp:TextBox ID="txtUnit" Class="form-control" Width="90%" runat="server" ReadOnly="true"></asp:TextBox>
                                            </div>
                                            <div class="col-md-6" style="padding: 0px;">
                                                <asp:TextBox ID="txtReOrderQty" Class="form-control" Text="0" Width="90%" runat="server" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtBalanceQty" Class="form-control" Text="0" runat="server" ReadOnly="true"></asp:TextBox>
                                    </td>
                                </tr>

                                <tr class="info" style="height: 10px;">
                                    <td style="visibility: visible">Currency  
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" SetFocusOnError="true" ControlToValidate="ddlCurrency"
                                         ErrorMessage="*" InitialValue="0" ValidationGroup="ValPrice"></asp:RequiredFieldValidator>
                                    </td>
                                    <td style="visibility: visible">Price 
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" SetFocusOnError="true" ControlToValidate="txtOrCPU"
                                         ErrorMessage="*" InitialValue="0" ValidationGroup="ValPrice"></asp:RequiredFieldValidator>
                                    </td>
                                    <td style="visibility: visible">Total 
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" SetFocusOnError="true" ControlToValidate="txtorTotal"
                                         ErrorMessage="*" InitialValue="0" ValidationGroup="ValPrice"></asp:RequiredFieldValidator>
                                    </td>
                                    <td style="visibility: visible">Convert Currency  
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" SetFocusOnError="true" ControlToValidate="ddlConvertCurrency"
                                         ErrorMessage="*" InitialValue="0" ValidationGroup="ValPrice"></asp:RequiredFieldValidator>
                                    </td>
                                    <td style="visibility: visible">Rate 
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" SetFocusOnError="true" ControlToValidate="txtCCRate"
                                         ErrorMessage="*" InitialValue="0" ValidationGroup="ValPrice"></asp:RequiredFieldValidator>
                                    </td>
                                    <td style="visibility: visible">App-Cost 
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" SetFocusOnError="true" ControlToValidate="txtCCTotal"
                                         ErrorMessage="*" InitialValue="0" ValidationGroup="ValPrice"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlCurrency" Class="form-control" runat="server" AutoPostBack="True">
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
                                            <asp:ListItem Value="BWP">BWP (Botswana Pula)</asp:ListItem>
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
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtOrCPU" Class="form-control" Text="0" OnTextChanged="txtOrCPU_TextChanged" AutoPostBack="true" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtorTotal" Class="form-control" AutoPostBack="true" OnTextChanged="txtorTotal_TextChanged" runat="server" Text="0" ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <td style="width: 200px">
                                        <asp:DropDownList ID="ddlConvertCurrency" Class="form-control" runat="server" AutoPostBack="True">
                                            <asp:ListItem Value="BDT">BDT (Bangladeshi Taka)</asp:ListItem>
                                            <asp:ListItem Value="AED">AED (United Arab Emirates Dirham)</asp:ListItem>
                                            <asp:ListItem Value="ANG">ANG (Netherlands Antillean Guilder)</asp:ListItem>
                                            <asp:ListItem Value="ARS">ARS (Argentine Peso)</asp:ListItem>
                                            <asp:ListItem Value="AUD">AUD (Australian Dollar)</asp:ListItem>
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
                                            <asp:ListItem Value="USD">USD (US Dollar)</asp:ListItem>
                                            <asp:ListItem Value="UYU">UYU (Uruguayan Peso)</asp:ListItem>
                                            <asp:ListItem Value="UZS">UZS (Uzbekistan Som)</asp:ListItem>
                                            <asp:ListItem Value="VEF">VEF (Venezuelan Bolívar)</asp:ListItem>
                                            <asp:ListItem Value="VND">VND (Vietnamese Dong)</asp:ListItem>
                                            <asp:ListItem Value="XOF">XOF (CFA Franc BCEAO)</asp:ListItem>
                                            <asp:ListItem Value="YER">YER (Yemeni Rial)</asp:ListItem>
                                            <asp:ListItem Value="ZAR">ZAR (South African Rand)</asp:ListItem>
                                            <asp:ListItem Value="ZMK">ZMK (Zambian Kwacha)</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCCRate" Text="0" Class="form-control" OnTextChanged="txtCCRate_TextChanged" AutoPostBack="true"
                                            Style="color: maroon" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCCTotal" Class="form-control" Text="0" runat="server" ReadOnly="true"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="row" style="float: right; padding-right: 30px;">
                            <asp:Button ID="btnSubmit" runat="server" ValidationGroup="Group1" Text="Add" CssClass="btn btn-primary"
                                OnClick="btnSubmit_Click" />
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <fieldset>
                                    <legend style="line-height: 0px;"><span style="background: #fff">Item List</span></legend>
                                    <asp:GridView ID="gvPurchase" runat="server" AutoGenerateColumns="False" Width="100%"
                                        PageSize="100" BorderColor="#E3F0FC" CellPadding="10" AllowPaging="false" OnRowCommand="gvPurchase_RowCommand"
                                        OnRowDataBound="gvPurchase_RowDataBound" AutoGenerateSelectButton="False" HorizontalAlign="Left">
                                        <Columns>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    Sl
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSRNO" runat="server"
                                                        Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Item">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblItelmListddd" runat="server" Text='<%# Eval("ProductName")%>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ProductName" Visible="false" HeaderText="Item">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Brand" Visible="false" HeaderText="Brand">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Center" Width="6%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="StyleSize" Visible="false" HeaderText="Style/Size">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Center" Width="6%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Barcode" HeaderText="Code" Visible="false">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Center" Width="6%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ReceiveQuantity" HeaderText="Rec. Qty.">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Center" Width="6%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ActualQty" HeaderText="Actual Qty.">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Center" Width="6%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Free_Qty" HeaderText="Free Qty.">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Center" Width="6%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CPU" HeaderText="Price" DataFormatString="{0:0.0000}">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Center" Width="6%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TotalPrice" HeaderText="Total($)" DataFormatString="{0:0.00}">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Right" Width="6%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Actual_Amount" HeaderText="Actual($)" DataFormatString="{0:0.00}">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Right" Width="6%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="FreeQty_Amount" HeaderText="Free($)" DataFormatString="{0:0.00}">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Right" Width="6%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Rate" HeaderText="Rate" DataFormatString="{0:0.00}">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Center" Width="6%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TotalAppCost" HeaderText="App Cost" DataFormatString="{0:0.00}">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Right" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgbtnEdit" runat="server" ImageUrl="img/edit.png" CommandArgument='<%# Eval("Id") %>'
                                                        CommandName="edt" />
                                                    <asp:ImageButton ID="ImageButtonDelete" runat="server" OnClientClick="return ConfirmDelete();" CommandArgument='<%# Eval("Id") %>'
                                                        CommandName="dlt" ImageUrl="img/list_Delete.png" />
                                                </ItemTemplate>
                                                <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataRowStyle ForeColor="Red" />
                                        <PagerSettings Mode="NumericFirstLast" />
                                        <PagerStyle CssClass="pagination01 pageback" />
                                        <RowStyle CssClass="Grid_RowStyle" />
                                        <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                        <%--<PagerStyle ForeColor="#000066" HorizontalAlign="Left" BackColor="White" />--%>
                                        <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:GridView>
                                    <div class="row">

                                        <div class="col-md-1">
                                            <asp:Label ID="lblTotal" Font-Bold="true" runat="server" Text="Total"></asp:Label>
                                        </div>
                                        <div class="col-md-5"></div>
                                        <div class="col-md-1" style="margin-left: -13px">
                                            <asp:Label ID="lblTotalUSD" runat="server" CssClass="CustomCSSFooter"></asp:Label>
                                        </div>
                                        <div class="col-md-1" style="margin-left: -13px">
                                            <asp:Label ID="lblActual" runat="server" CssClass="CustomCSSFooter"></asp:Label>
                                        </div>
                                        <div class="col-md-1" style="margin-left: -8px">
                                            <asp:Label ID="lblFree" runat="server" CssClass="CustomCSSFooter"></asp:Label>
                                        </div>
                                        <div class="col-md-1">
                                        </div>
                                        <div class="col-md-1">
                                            <asp:Label ID="lblTotalCost" runat="server" CssClass="CustomCSSFooter"></asp:Label>
                                        </div>
                                        <div class="col-md-1">
                                        </div>
                                        <%-- <span  style="margin-left: 0px; visibility:hidden"><b>Total:</b></span>--%>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="col-md-7">
                            </div>
                            <div class="col-md-3">
                                <asp:DropDownList ID="ddlChalanNo" Class="form-control" runat="server" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlChalanNo_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-2">
                                <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btn btn-warning pull-right"
                                    OnClick="btnPrint_Click" />
                                <asp:Button ID="btnSave" runat="server" Text="Post" Style="margin-right: 5px;" CssClass="btn btn-info pull-right" OnClick="btnSave_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <rsweb:ReportViewer ID="ReportViewerPurchase" AsyncRendering="False" InteractiveDeviceInfos="(Collection)"
                            SizeToReportContent="True" Width="100%" Height="700px" runat="server" Font-Names="Verdana"
                            Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" BackColor="White">
                        </rsweb:ReportViewer>
                    </div>
                </div>
                <asp:HiddenField ID="hiddenCompanyType" runat="server" />
                <asp:HiddenField ID="hidId" runat="server" />
                <asp:HiddenField ID="hdnBrand" runat="server" />
                <asp:HiddenField ID="hdnStyle" runat="server" />
                <asp:HiddenField ID="hidStoreCode" runat="server" />
                <%--<asp:HiddenField ID="hdnProductName" runat="server" />--%>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <script type="text/JavaScript">

        function ConfirmDelete() {
            var x = confirm("Do you want to delete this item?");
            if (x)
                return true;
            else
                return false;
        }

        function func(result) {
            if (result === 'Data Update Successfully.') {
                toastr.success(result);
            }
            else
                toastr.error(result);
            return false;
        }

        function func(result) {
            if (result === 'Purchase information posted successfully') {
                toastr.success(result);
            }
            else if (result === 'Data Update Successfully') {
                toastr.success(result);
            }
            else if (result === 'Purchase information has been added temporarily. Please post.') {
                toastr.success(result);
            }
            else
                toastr.error(result);
            return false;
        }
    </script>
</asp:Content>
