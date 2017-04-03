<%@ Page Title="" Language="C#" MasterPageFile="~/BuyingHouse/BuyingSite.Master" AutoEventWireup="true" CodeBehind="PendingTask.aspx.cs" Inherits="ERPSSL.BuyingHouse.PendingTask" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

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
                            <i class="glyphicon glyphicon-edit icon-padding"></i>Order Status
                        </div>
                    </div>
                    <div class="col-md-12 bg-success">
                        <asp:HiddenField ID="hidLcNo" runat="server" />
                        <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label>
                        <asp:Label ID="lblMessageUpdate" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label>
                    </div>

                    <div class="col-md-12">
                        <div class="row" style="margin-top: 5px">
                            <div class="col-md-12" style="background-color: silver; padding-bottom: 10px;">
                                <div class="col-md-3" style="padding-left: 0;">
                                    <div class="row">
                                        Order No.
                                    <asp:TextBox ID="txtOrder" Class=" form-control2 form-control " runat="server" Enabled="false"></asp:TextBox>
                                        <cc1:AutoCompleteExtender ServiceMethod="SearchLCNo"
                                            MinimumPrefixLength="1"
                                            CompletionInterval="100" EnableCaching="False"
                                            TargetControlID="txtOrder"
                                            ID="AutoCompleteExtender2" runat="server" DelimiterCharacters="" Enabled="True" ServicePath="">
                                        </cc1:AutoCompleteExtender>
                                        <asp:Label ID="lblSeason" runat="server" Text="Label" Visible="false"></asp:Label>
                                        <asp:HiddenField ID="hidorderid" runat="server" />
                                    </div>
                                    <div class="row">
                                        Style  
                                            <asp:DropDownList ID="ddlStyle" CssClass="form-control2 form-control" runat="server" Enabled="false"></asp:DropDownList>
                                    </div>
                                    <div class="row">
                                        Season 
                                                <asp:HiddenField ID="hidSeasonID" runat="server" />
                                        <asp:DropDownList ID="ddlSeason" AutoPostBack="true" OnSelectedIndexChanged="ddlSeason_SelectedIndexChanged" Enabled="false" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="row">
                                        Office
                                        <asp:DropDownList ID="ddlTTOffice" CssClass="form-control2 form-control" Enabled="false" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="row">
                                        Principal
                                         <asp:DropDownList ID="ddlPrincipal" CssClass="form-control2 form-control" Enabled="false" runat="server">
                                         </asp:DropDownList>
                                    </div>
                                    <div class="row">
                                        Buyer <a style="color: red; font-size: 11px">*</a>
                                        <asp:DropDownList ID="ddlBuyer" CssClass="form-control2 form-control" Enabled="false" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="row">
                                        Buyer Department 
                                            <asp:DropDownList ID="ddlBuyerDepartment" CssClass="form-control" Enabled="false" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="row">
                                        Merchandiser Dept.
                                        <asp:DropDownList ID="ddlMerchandiserDept" CssClass="form-control2 form-control" Enabled="false" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="row">
                                        Merchandiser Name
                                        <asp:DropDownList ID="ddlMerchandiserName" CssClass="form-control2 form-control" Enabled="false" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="row">
                                        Style Type
                                        <asp:DropDownList ID="ddlGender" CssClass="form-control2 form-control" Enabled="false" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="row">
                                        Category
                                        <asp:DropDownList ID="ddlCategory" CssClass="form-control2 form-control" Enabled="false" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="row">
                                        Style Description
                                            <asp:TextBox ID="txtCustomerStyle" Class=" form-control2 form-control " Enabled="false" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="row">
                                        Yarn/Fabrication
                                            <asp:TextBox ID="txtYarnFabrication" Class=" form-control2 form-control " Enabled="false" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="row">
                                        FOB Port
                                            <asp:TextBox ID="txtFOBPort" Class=" form-control2 form-control " Enabled="false" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="row">
                                        Shipment Mode
                                        <asp:DropDownList ID="ddlShipmentMode" CssClass="form-control2 form-control" Enabled="false" runat="server">
                                            <asp:ListItem>---Select---</asp:ListItem>
                                            <asp:ListItem>By Air</asp:ListItem>
                                            <asp:ListItem>By Sea</asp:ListItem>
                                            <asp:ListItem>By Land</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="row">
                                        Country Of Production
                                       <asp:DropDownList ID="ddlCountry" class="form-control" runat="server" Enabled="false">
                                           <asp:ListItem Value="AF">Afghanistan</asp:ListItem>
                                           <asp:ListItem Value="AL">Albania</asp:ListItem>
                                           <asp:ListItem Value="DZ">Algeria</asp:ListItem>
                                           <asp:ListItem Value="AS">American Samoa</asp:ListItem>
                                           <asp:ListItem Value="AD">Andorra</asp:ListItem>
                                           <asp:ListItem Value="AO">Angola</asp:ListItem>
                                           <asp:ListItem Value="AI">Anguilla</asp:ListItem>
                                           <asp:ListItem Value="AQ">Antarctica</asp:ListItem>
                                           <asp:ListItem Value="AG">Antigua And Barbuda</asp:ListItem>
                                           <asp:ListItem Value="AR">Argentina</asp:ListItem>
                                           <asp:ListItem Value="AM">Armenia</asp:ListItem>
                                           <asp:ListItem Value="AW">Aruba</asp:ListItem>
                                           <asp:ListItem Value="AU">Australia</asp:ListItem>
                                           <asp:ListItem Value="AT">Austria</asp:ListItem>
                                           <asp:ListItem Value="AZ">Azerbaijan</asp:ListItem>
                                           <asp:ListItem Value="BS">Bahamas</asp:ListItem>
                                           <asp:ListItem Value="BH">Bahrain</asp:ListItem>
                                           <asp:ListItem Value="BD" Selected="True">Bangladesh</asp:ListItem>
                                           <asp:ListItem Value="BB">Barbados</asp:ListItem>
                                           <asp:ListItem Value="BY">Belarus</asp:ListItem>
                                           <asp:ListItem Value="BE">Belgium</asp:ListItem>
                                           <asp:ListItem Value="BZ">Belize</asp:ListItem>
                                           <asp:ListItem Value="BJ">Benin</asp:ListItem>
                                           <asp:ListItem Value="BM">Bermuda</asp:ListItem>
                                           <asp:ListItem Value="BT">Bhutan</asp:ListItem>
                                           <asp:ListItem Value="BO">Bolivia</asp:ListItem>
                                           <asp:ListItem Value="BA">Bosnia And Herzegowina</asp:ListItem>
                                           <asp:ListItem Value="BW">Botswana</asp:ListItem>
                                           <asp:ListItem Value="BV">Bouvet Island</asp:ListItem>
                                           <asp:ListItem Value="BR">Brazil</asp:ListItem>
                                           <asp:ListItem Value="IO">British Indian Ocean Territory</asp:ListItem>
                                           <asp:ListItem Value="BN">Brunei Darussalam</asp:ListItem>
                                           <asp:ListItem Value="BG">Bulgaria</asp:ListItem>
                                           <asp:ListItem Value="BF">Burkina Faso</asp:ListItem>
                                           <asp:ListItem Value="BI">Burundi</asp:ListItem>
                                           <asp:ListItem Value="KH">Cambodia</asp:ListItem>
                                           <asp:ListItem Value="CM">Cameroon</asp:ListItem>
                                           <asp:ListItem Value="CA">Canada</asp:ListItem>
                                           <asp:ListItem Value="CV">Cape Verde</asp:ListItem>
                                           <asp:ListItem Value="KY">Cayman Islands</asp:ListItem>
                                           <asp:ListItem Value="CF">Central African Republic</asp:ListItem>
                                           <asp:ListItem Value="TD">Chad</asp:ListItem>
                                           <asp:ListItem Value="CL">Chile</asp:ListItem>
                                           <asp:ListItem Value="CN">China</asp:ListItem>
                                           <asp:ListItem Value="CX">Christmas Island</asp:ListItem>
                                           <asp:ListItem Value="CC">Cocos (Keeling) Islands</asp:ListItem>
                                           <asp:ListItem Value="CO">Colombia</asp:ListItem>
                                           <asp:ListItem Value="KM">Comoros</asp:ListItem>
                                           <asp:ListItem Value="CG">Congo</asp:ListItem>
                                           <asp:ListItem Value="CK">Cook Islands</asp:ListItem>
                                           <asp:ListItem Value="CR">Costa Rica</asp:ListItem>
                                           <asp:ListItem Value="CI">Cote D'Ivoire</asp:ListItem>
                                           <asp:ListItem Value="HR">Croatia (Local Name: Hrvatska)</asp:ListItem>
                                           <asp:ListItem Value="CU">Cuba</asp:ListItem>
                                           <asp:ListItem Value="CY">Cyprus</asp:ListItem>
                                           <asp:ListItem Value="CZ">Czech Republic</asp:ListItem>
                                           <asp:ListItem Value="DK">Denmark</asp:ListItem>
                                           <asp:ListItem Value="DJ">Djibouti</asp:ListItem>
                                           <asp:ListItem Value="DM">Dominica</asp:ListItem>
                                           <asp:ListItem Value="DO">Dominican Republic</asp:ListItem>
                                           <asp:ListItem Value="TP">East Timor</asp:ListItem>
                                           <asp:ListItem Value="EC">Ecuador</asp:ListItem>
                                           <asp:ListItem Value="EG">Egypt</asp:ListItem>
                                           <asp:ListItem Value="SV">El Salvador</asp:ListItem>
                                           <asp:ListItem Value="GQ">Equatorial Guinea</asp:ListItem>
                                           <asp:ListItem Value="ER">Eritrea</asp:ListItem>
                                           <asp:ListItem Value="EE">Estonia</asp:ListItem>
                                           <asp:ListItem Value="ET">Ethiopia</asp:ListItem>
                                           <asp:ListItem Value="FK">Falkland Islands (Malvinas)</asp:ListItem>
                                           <asp:ListItem Value="FO">Faroe Islands</asp:ListItem>
                                           <asp:ListItem Value="FJ">Fiji</asp:ListItem>
                                           <asp:ListItem Value="FI">Finland</asp:ListItem>
                                           <asp:ListItem Value="FR">France</asp:ListItem>
                                           <asp:ListItem Value="GF">French Guiana</asp:ListItem>
                                           <asp:ListItem Value="PF">French Polynesia</asp:ListItem>
                                           <asp:ListItem Value="TF">French Southern Territories</asp:ListItem>
                                           <asp:ListItem Value="GA">Gabon</asp:ListItem>
                                           <asp:ListItem Value="GM">Gambia</asp:ListItem>
                                           <asp:ListItem Value="GE">Georgia</asp:ListItem>
                                           <asp:ListItem Value="DE">Germany</asp:ListItem>
                                           <asp:ListItem Value="GH">Ghana</asp:ListItem>
                                           <asp:ListItem Value="GI">Gibraltar</asp:ListItem>
                                           <asp:ListItem Value="GR">Greece</asp:ListItem>
                                           <asp:ListItem Value="GL">Greenland</asp:ListItem>
                                           <asp:ListItem Value="GD">Grenada</asp:ListItem>
                                           <asp:ListItem Value="GP">Guadeloupe</asp:ListItem>
                                           <asp:ListItem Value="GU">Guam</asp:ListItem>
                                           <asp:ListItem Value="GT">Guatemala</asp:ListItem>
                                           <asp:ListItem Value="GN">Guinea</asp:ListItem>
                                           <asp:ListItem Value="GW">Guinea-Bissau</asp:ListItem>
                                           <asp:ListItem Value="GY">Guyana</asp:ListItem>
                                           <asp:ListItem Value="HT">Haiti</asp:ListItem>
                                           <asp:ListItem Value="HM">Heard And Mc Donald Islands</asp:ListItem>
                                           <asp:ListItem Value="VA">Holy See (Vatican City State)</asp:ListItem>
                                           <asp:ListItem Value="HN">Honduras</asp:ListItem>
                                           <asp:ListItem Value="HK">Hong Kong</asp:ListItem>
                                           <asp:ListItem Value="HU">Hungary</asp:ListItem>
                                           <asp:ListItem Value="IS">Icel And</asp:ListItem>
                                           <asp:ListItem Value="IN">India</asp:ListItem>
                                           <asp:ListItem Value="ID">Indonesia</asp:ListItem>
                                           <asp:ListItem Value="IR">Iran (Islamic Republic Of)</asp:ListItem>
                                           <asp:ListItem Value="IQ">Iraq</asp:ListItem>
                                           <asp:ListItem Value="IE">Ireland</asp:ListItem>
                                           <asp:ListItem Value="IL">Israel</asp:ListItem>
                                           <asp:ListItem Value="IT">Italy</asp:ListItem>
                                           <asp:ListItem Value="JM">Jamaica</asp:ListItem>
                                           <asp:ListItem Value="JP">Japan</asp:ListItem>
                                           <asp:ListItem Value="JO">Jordan</asp:ListItem>
                                           <asp:ListItem Value="KZ">Kazakhstan</asp:ListItem>
                                           <asp:ListItem Value="KE">Kenya</asp:ListItem>
                                           <asp:ListItem Value="KI">Kiribati</asp:ListItem>
                                           <asp:ListItem Value="KP">Korea, Dem People'S Republic</asp:ListItem>
                                           <asp:ListItem Value="KR">Korea, Republic Of</asp:ListItem>
                                           <asp:ListItem Value="KW">Kuwait</asp:ListItem>
                                           <asp:ListItem Value="KG">Kyrgyzstan</asp:ListItem>
                                           <asp:ListItem Value="LA">Lao People'S Dem Republic</asp:ListItem>
                                           <asp:ListItem Value="LV">Latvia</asp:ListItem>
                                           <asp:ListItem Value="LB">Lebanon</asp:ListItem>
                                           <asp:ListItem Value="LS">Lesotho</asp:ListItem>
                                           <asp:ListItem Value="LR">Liberia</asp:ListItem>
                                           <asp:ListItem Value="LY">Libyan Arab Jamahiriya</asp:ListItem>
                                           <asp:ListItem Value="LI">Liechtenstein</asp:ListItem>
                                           <asp:ListItem Value="LT">Lithuania</asp:ListItem>
                                           <asp:ListItem Value="LU">Luxembourg</asp:ListItem>
                                           <asp:ListItem Value="MO">Macau</asp:ListItem>
                                           <asp:ListItem Value="MK">Macedonia</asp:ListItem>
                                           <asp:ListItem Value="MG">Madagascar</asp:ListItem>
                                           <asp:ListItem Value="MW">Malawi</asp:ListItem>
                                           <asp:ListItem Value="MY">Malaysia</asp:ListItem>
                                           <asp:ListItem Value="MV">Maldives</asp:ListItem>
                                           <asp:ListItem Value="ML">Mali</asp:ListItem>
                                           <asp:ListItem Value="MT">Malta</asp:ListItem>
                                           <asp:ListItem Value="MH">Marshall Islands</asp:ListItem>
                                           <asp:ListItem Value="MQ">Martinique</asp:ListItem>
                                           <asp:ListItem Value="MR">Mauritania</asp:ListItem>
                                           <asp:ListItem Value="MU">Mauritius</asp:ListItem>
                                           <asp:ListItem Value="YT">Mayotte</asp:ListItem>
                                           <asp:ListItem Value="MX">Mexico</asp:ListItem>
                                           <asp:ListItem Value="FM">Micronesia, Federated States</asp:ListItem>
                                           <asp:ListItem Value="MD">Moldova, Republic Of</asp:ListItem>
                                           <asp:ListItem Value="MC">Monaco</asp:ListItem>
                                           <asp:ListItem Value="MN">Mongolia</asp:ListItem>
                                           <asp:ListItem Value="MS">Montserrat</asp:ListItem>
                                           <asp:ListItem Value="MA">Morocco</asp:ListItem>
                                           <asp:ListItem Value="MZ">Mozambique</asp:ListItem>
                                           <asp:ListItem Value="MM">Myanmar</asp:ListItem>
                                           <asp:ListItem Value="NA">Namibia</asp:ListItem>
                                           <asp:ListItem Value="NR">Nauru</asp:ListItem>
                                           <asp:ListItem Value="NP">Nepal</asp:ListItem>
                                           <asp:ListItem Value="NL">Netherlands</asp:ListItem>
                                           <asp:ListItem Value="AN">Netherlands Ant Illes</asp:ListItem>
                                           <asp:ListItem Value="NC">New Caledonia</asp:ListItem>
                                           <asp:ListItem Value="NZ">New Zealand</asp:ListItem>
                                           <asp:ListItem Value="NI">Nicaragua</asp:ListItem>
                                           <asp:ListItem Value="NE">Niger</asp:ListItem>
                                           <asp:ListItem Value="NG">Nigeria</asp:ListItem>
                                           <asp:ListItem Value="NU">Niue</asp:ListItem>
                                           <asp:ListItem Value="NF">Norfolk Island</asp:ListItem>
                                           <asp:ListItem Value="MP">Northern Mariana Islands</asp:ListItem>
                                           <asp:ListItem Value="NO">Norway</asp:ListItem>
                                           <asp:ListItem Value="OM">Oman</asp:ListItem>
                                           <asp:ListItem Value="PK">Pakistan</asp:ListItem>
                                           <asp:ListItem Value="PW">Palau</asp:ListItem>
                                           <asp:ListItem Value="PA">Panama</asp:ListItem>
                                           <asp:ListItem Value="PG">Papua New Guinea</asp:ListItem>
                                           <asp:ListItem Value="PY">Paraguay</asp:ListItem>
                                           <asp:ListItem Value="PE">Peru</asp:ListItem>
                                           <asp:ListItem Value="PH">Philippines</asp:ListItem>
                                           <asp:ListItem Value="PN">Pitcairn</asp:ListItem>
                                           <asp:ListItem Value="PL">Poland</asp:ListItem>
                                           <asp:ListItem Value="PT">Portugal</asp:ListItem>
                                           <asp:ListItem Value="PR">Puerto Rico</asp:ListItem>
                                           <asp:ListItem Value="QA">Qatar</asp:ListItem>
                                           <asp:ListItem Value="RE">Reunion</asp:ListItem>
                                           <asp:ListItem Value="RO">Romania</asp:ListItem>
                                           <asp:ListItem Value="RU">Russian Federation</asp:ListItem>
                                           <asp:ListItem Value="RW">Rwanda</asp:ListItem>
                                           <asp:ListItem Value="KN">Saint K Itts And Nevis</asp:ListItem>
                                           <asp:ListItem Value="LC">Saint Lucia</asp:ListItem>
                                           <asp:ListItem Value="VC">Saint Vincent, The Grenadines</asp:ListItem>
                                           <asp:ListItem Value="WS">Samoa</asp:ListItem>
                                           <asp:ListItem Value="SM">San Marino</asp:ListItem>
                                           <asp:ListItem Value="ST">Sao Tome And Principe</asp:ListItem>
                                           <asp:ListItem Value="SA">Saudi Arabia</asp:ListItem>
                                           <asp:ListItem Value="SN">Senegal</asp:ListItem>
                                           <asp:ListItem Value="SC">Seychelles</asp:ListItem>
                                           <asp:ListItem Value="SL">Sierra Leone</asp:ListItem>
                                           <asp:ListItem Value="SG">Singapore</asp:ListItem>
                                           <asp:ListItem Value="SK">Slovakia (Slovak Republic)</asp:ListItem>
                                           <asp:ListItem Value="SI">Slovenia</asp:ListItem>
                                           <asp:ListItem Value="SB">Solomon Islands</asp:ListItem>
                                           <asp:ListItem Value="SO">Somalia</asp:ListItem>
                                           <asp:ListItem Value="ZA">South Africa</asp:ListItem>
                                           <asp:ListItem Value="GS">South Georgia , S Sandwich Is.</asp:ListItem>
                                           <asp:ListItem Value="ES">Spain</asp:ListItem>
                                           <asp:ListItem Value="LK">Sri Lanka</asp:ListItem>
                                           <asp:ListItem Value="SH">St. Helena</asp:ListItem>
                                           <asp:ListItem Value="PM">St. Pierre And Miquelon</asp:ListItem>
                                           <asp:ListItem Value="SD">Sudan</asp:ListItem>
                                           <asp:ListItem Value="SR">Suriname</asp:ListItem>
                                           <asp:ListItem Value="SJ">Svalbard, Jan Mayen Islands</asp:ListItem>
                                           <asp:ListItem Value="SZ">Sw Aziland</asp:ListItem>
                                           <asp:ListItem Value="SE">Sweden</asp:ListItem>
                                           <asp:ListItem Value="CH">Switzerland</asp:ListItem>
                                           <asp:ListItem Value="SY">Syrian Arab Republic</asp:ListItem>
                                           <asp:ListItem Value="TW">Taiwan</asp:ListItem>
                                           <asp:ListItem Value="TJ">Tajikistan</asp:ListItem>
                                           <asp:ListItem Value="TZ">Tanzania, United Republic Of</asp:ListItem>
                                           <asp:ListItem Value="TH">Thailand</asp:ListItem>
                                           <asp:ListItem Value="TG">Togo</asp:ListItem>
                                           <asp:ListItem Value="TK">Tokelau</asp:ListItem>
                                           <asp:ListItem Value="TO">Tonga</asp:ListItem>
                                           <asp:ListItem Value="TT">Trinidad And Tobago</asp:ListItem>
                                           <asp:ListItem Value="TN">Tunisia</asp:ListItem>
                                           <asp:ListItem Value="TR">Turkey</asp:ListItem>
                                           <asp:ListItem Value="TM">Turkmenistan</asp:ListItem>
                                           <asp:ListItem Value="TC">Turks And Caicos Islands</asp:ListItem>
                                           <asp:ListItem Value="TV">Tuvalu</asp:ListItem>
                                           <asp:ListItem Value="UG">Uganda</asp:ListItem>
                                           <asp:ListItem Value="UA">Ukraine</asp:ListItem>
                                           <asp:ListItem Value="AE">United Arab Emirates</asp:ListItem>
                                           <asp:ListItem Value="GB">United Kingdom</asp:ListItem>
                                           <asp:ListItem Value="US">United States</asp:ListItem>
                                           <asp:ListItem Value="UM">United States Minor Is.</asp:ListItem>
                                           <asp:ListItem Value="UY">Uruguay</asp:ListItem>
                                           <asp:ListItem Value="UZ">Uzbekistan</asp:ListItem>
                                           <asp:ListItem Value="VU">Vanuatu</asp:ListItem>
                                           <asp:ListItem Value="VE">Venezuela</asp:ListItem>
                                           <asp:ListItem Value="VN">Viet Nam</asp:ListItem>
                                           <asp:ListItem Value="VG">Virgin Islands (British)</asp:ListItem>
                                           <asp:ListItem Value="VI">Virgin Islands (U.S.)</asp:ListItem>
                                           <asp:ListItem Value="WF">Wallis And Futuna Islands</asp:ListItem>
                                           <asp:ListItem Value="EH">Western Sahara</asp:ListItem>
                                           <asp:ListItem Value="YE">Yemen</asp:ListItem>
                                           <asp:ListItem Value="YU">Yugoslavia</asp:ListItem>
                                           <asp:ListItem Value="ZR">Zaire</asp:ListItem>
                                           <asp:ListItem Value="ZM">Zambia</asp:ListItem>
                                           <asp:ListItem Value="ZW">Zimbabwe</asp:ListItem>
                                       </asp:DropDownList>
                                    </div>
                                    <div class="row">
                                        Garments Maker
                                            <asp:DropDownList ID="ddlFactory" CssClass="form-control2 form-control" Enabled="false" runat="server">
                                            </asp:DropDownList>
                                    </div>
                                    <div class="row">
                                        Buyer Price
                                            <asp:TextBox ID="txtFob" Class="form-control2 form-control" runat="server" Enabled="false" Text="0"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="row">
                                        Currency
                                        <asp:DropDownList ID="ddlCurrency" CssClass="form-control2 form-control" runat="server" Enabled="false">
                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
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
                                    </div>
                                    <div class="row">
                                        Order Qty
                                        <asp:TextBox ID="txtOrderQty" Class=" form-control2 form-control " Enabled="false" runat="server" Text="0"></asp:TextBox>
                                    </div>
                                    <div class="row">
                                        Unit
                                        <asp:DropDownList ID="ddlUnit" CssClass="form-control2 form-control" Enabled="false" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="row">
                                        Total Amount
                                            <asp:TextBox ID="txtTotalAmount" Class="form-control2 form-control " Enabled="false" Text="0" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="row">
                                        Commission %
                                            <asp:TextBox ID="txtCommissionPer" Class="form-control2 form-control " Enabled="false" Text="0" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="row">
                                        Total Commission
                                            <asp:TextBox ID="txtTotalCommission" Class="form-control2 form-control" ReadOnly="true" Text="0" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row" style="margin-top: 5px">
                            <asp:GridView ID="GridTask" runat="server" ShowFooter="True" Width="100%" DataKeyNames="TaskDetails_Id"
                                AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" BackColor="White"
                                BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3"
                                OnPageIndexChanging="GridTask_PageIndexChanging"
                                OnRowCancelingEdit="GridTask_RowCancelingEdit"
                                OnRowEditing="GridTask_RowEditing"
                                OnRowUpdating="GridTask_RowUpdating"
                                OnRowDataBound="GridTask_RowDataBound">
                                <Columns>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="2%" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            Sl No.
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblSRNO" runat="server"
                                                Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="6%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="2%" HeaderStyle-HorizontalAlign="Center" Visible="false">

                                        <ItemTemplate>
                                            <asp:Label ID="lblID" runat="server"
                                                Text='<%# Bind("TaskDetails_Id") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="6%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="2%" HeaderStyle-HorizontalAlign="Center" Visible="false" HeaderText="Phase">

                                        <ItemTemplate>
                                            <asp:Label ID="lblOrderID" runat="server"
                                                Text='<%# Bind("Order_No") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="6%" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Task">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTask" runat="server" CssClass="form-control" Text='<%# Bind("Task") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="20%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Schedule Date">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtSchedule_Date" runat="server" placeholder="MM/dd/yyyy" Text='<%# Bind("Schedule_Date") %>' CssClass="form-control"
                                                MaxLength="30" Width="100%"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtSchedule_Date"
                                                PopupButtonID="txtSchedule_Date" Format="MM/dd/yyyy" CssClass="ajax__calendar"
                                                Enabled="True" />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblSchedule_Date" runat="server" CssClass="form-control" Text='<%# Bind("Schedule_Date","{0:MM/dd/yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="20%" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Status">
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddlStatus" runat="server" Height="28px" Width="100%"></asp:DropDownList>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="ddlStatus" runat="server" CssClass="form-control" Text='<%# Bind("Status") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="20%" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Resposible Person">
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddlResposiblePerson" runat="server" Height="28px" Width="100%"></asp:DropDownList>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblResposiblePerson" runat="server" CssClass="form-control" Text='<%# Bind("Responsible_Person") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="20%" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Comments">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtComments" runat="server" Text='<%# Bind("Comments") %>' CssClass="form-control"
                                                MaxLength="30" Width="100%"></asp:TextBox>

                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblComments" runat="server" CssClass="form-control" Text='<%# Bind("Comments") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="20%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Option" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkEdit" runat="server" Text="" CommandName="Edit" ToolTip="Edit"
                                                CommandArgument=''>
                                                <img id="Img1" src="~/img/edit.jpg" width="28" height="28" runat="server" />
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:LinkButton ID="lnkUpdate" runat="server" Text="" ValidationGroup="editGrp3"
                                                CommandName="Update" ToolTip="Save" CommandArgument=''>
                                                <img id="Img3" src="~/img/save.png" runat="server" />
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="lnkCancel" runat="server" Text="" CommandName="Cancel" ToolTip="Cancel"
                                                CommandArgument=''>
                                                <img id="Img4" src="~/img/cancle.png" runat="server" />
                                            </asp:LinkButton>
                                        </EditItemTemplate>

                                        <HeaderStyle Width="10%" />
                                    </asp:TemplateField>

                                </Columns>
                                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                                <EmptyDataRowStyle ForeColor="Red" />
                                <RowStyle CssClass="Grid_RowStyle" BackColor="White" ForeColor="#333333" />
                                <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                <PagerSettings Mode="NumericFirstLast" />
                                <PagerStyle ForeColor="White" HorizontalAlign="Left" BackColor="#336666" CssClass="pagination01 pageback" />
                                <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" BackColor="#336666"
                                    Font-Bold="True" ForeColor="White" />
                                <FooterStyle CssClass="Grid_Footer" BackColor="White" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                <SortedAscendingHeaderStyle BackColor="#487575" />
                                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                <SortedDescendingHeaderStyle BackColor="#275353" />
                            </asp:GridView>
                        </div>
                        <div class="col-md-12" style="max-height: 400px; height: auto">
                            <asp:Button ID="btnUpdate" runat="server" Visible="false" Text="Update" class="btn btn-info pull-right" ValidationGroup="Group1" OnClick="btnUpdate_Click" />
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
