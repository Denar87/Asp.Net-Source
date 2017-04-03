<%@ Page Title="" Language="C#" MasterPageFile="~/BuyingHouse/BuyingSite.Master" AutoEventWireup="true" CodeBehind="BuyerSetup.aspx.cs" Inherits="ERPSSL.BuyingHouse.BuyerSetup" %>


<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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

    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePageMethods="true" EnablePartialRendering="true" ID="ScriptManager1" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="hm_sec_2_content scrollbar">
                <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="fa fa-edit fa-fw icon-padding"></i>Buyer Setup 
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12 bg-success">
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </div>
                    <div class="col-md-12" style="background-color: #a7c5a7; margin: auto 0; padding-bottom: 5px;">
                        <div class="col-md-4" style="padding-left: 0;">
                            <div class="row" style="padding-top: 5px;">
                                <div class="col-md-12" style="padding: 0px;">
                                    <div class="col-md-3" style="padding: 0px;">
                                        Principal Name
                                    </div>
                                    <div class="col-md-1">
                                        <asp:CheckBox ID="chkPrincipalName" runat="server" AutoPostBack="true" OnCheckedChanged="chkPrincipalName_CheckedChanged"></asp:CheckBox>
                                    </div>
                                    <a style="color: red; font-size: 11px">*</a>
                                    <div class="col-md-8"></div>
                                </div>
                                <div class="col-md-12" style="padding: 0px;">
                                    <asp:DropDownList ID="ddlPrincipalName" CssClass="form-control2 form-control" runat="server"></asp:DropDownList>
                                    <asp:TextBox ID="txtPrincipalName" runat="server" class="form-control" Visible="false"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row" style="padding-top: 5px;">
                                Address
                                    <asp:TextBox ID="txtbxAddress" runat="server" placeholder="Enter Address" class="form-control"></asp:TextBox>
                            </div>
                            <div class="row" style="padding-top: 5px;">
                                Country
                                    <asp:DropDownList ID="ddlCountry" runat="server" class="form-control">
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
                            <div class="row" style="padding-top: 5px;">
                                <div class="col-md-12" style="padding: 0px;">
                                    <div class="col-md-1" style="padding: 0px;">
                                        Buyer
                                    </div>
                                    <div class="col-md-1">
                                        <asp:CheckBox ID="chkBuyer" runat="server" AutoPostBack="true" OnCheckedChanged="chkBuyer_CheckedChanged"></asp:CheckBox>
                                    </div>
                                    <a style="color: red; font-size: 11px">*</a>
                                    <div class="col-md-10"></div>
                                </div>
                                <div class="col-md-12" style="padding: 0px;">
                                    <asp:DropDownList ID="ddlBuyer" CssClass="form-control2 form-control" runat="server"></asp:DropDownList>
                                    <asp:TextBox ID="txtBuyer" runat="server" class="form-control" Visible="false"></asp:TextBox>
                                    <asp:HiddenField ID="hidBueyId" runat="server" />
                                </div>

                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row" style="padding-top: 5px;">
                                <div class="col-md-12" style="padding: 0px;">
                                    <div class="col-md-4" style="padding: 0px;">
                                        Buying Department
                                    </div>
                                    <div class="col-md-1">
                                        <asp:CheckBox ID="chkBuyingDepartment" runat="server" AutoPostBack="true" OnCheckedChanged="chkBuyingDepartment_CheckedChanged"></asp:CheckBox>
                                    </div>
                                    <a style="color: red; font-size: 11px">*</a>
                                    <div class="col-md-7"></div>
                                </div>
                                <div class="col-md-12" style="padding: 0px;">
                                    <asp:DropDownList ID="ddlBuyingDepartment" CssClass="form-control2 form-control" runat="server"></asp:DropDownList>
                                    <asp:TextBox ID="txtBuyingDepartment" runat="server" class="form-control" Visible="false"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row" style="padding-top: 5px;">
                                Phone No.
                            <asp:TextBox ID="txtbxPhone" runat="server" class="form-control"></asp:TextBox>
                            </div>
                            <div class="row" style="padding-top: 5px;">
                                E-mail
                            <asp:TextBox ID="txtEmail" runat="server" class="form-control"></asp:TextBox>
                            </div>
                            <div class="row" style="padding-top: 5px;">
                                Consignee
                            <asp:TextBox ID="txtConsignee" runat="server" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4" style="padding-right: 21px;">
                            <div class="row" style="padding-top: 5px;">
                                Notify Party
                            <asp:TextBox ID="txtNotifyParty" runat="server" class="form-control"></asp:TextBox>
                            </div>
                            <div class="row" style="padding-top: 5px;">
                                Delivery Address                              
                            <asp:TextBox ID="txtDeliveryAddress" runat="server" class="form-control"></asp:TextBox>
                            </div>
                            <div class="row" style="padding-top: 5px;">
                                Destination Address                              
                            <asp:TextBox ID="txtDestinationAddress" runat="server" class="form-control"></asp:TextBox>
                            </div>
                            <div class="row" style="padding-top: 5px;">
                                Status <a style="color: red; font-size: 11px">*</a>
                                <asp:DropDownList ID="drpSataus" class="form-control"
                                    runat="server">
                                    <asp:ListItem Text="--- Select --- " Value="0"></asp:ListItem>
                                    <asp:ListItem>True</asp:ListItem>
                                    <asp:ListItem>False</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="Group1"
                                    runat="server" ControlToValidate="drpSataus" ErrorMessage="Select Status"
                                    InitialValue="0"></asp:RequiredFieldValidator>
                            </div>
                            <div class="row" style="padding-top: 0px;">
                                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" ValidationGroup="Group1" Text="Submit" class="btn btn-info  pull-right" /><%--OnClick="btnSave_Click"--%>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12" style="padding-left: 5px; padding-top: 10px;">
                        <div class="row">
                            <div class="col-md-12" style="padding-left: 0;">
                                <asp:TextBox ID="txtS_BuyerName" runat="server" class="form-control" OnTextChanged="txtS_BuyerName_TextChanged"
                                    placeholder="Search With Buyer Name" AutoPostBack="true"></asp:TextBox>
                                <cc1:AutoCompleteExtender ServiceMethod="SearchBuyerName"
                                    MinimumPrefixLength="1"
                                    CompletionInterval="100" EnableCaching="False"
                                    TargetControlID="txtS_BuyerName"
                                    ID="AutoCompleteExtender1" runat="server" DelimiterCharacters="" Enabled="True" ServicePath="">
                                </cc1:AutoCompleteExtender>
                            </div>
                        </div>
                        <div class="row">
                            <asp:GridView ID="grdBuyer" runat="server" AutoGenerateColumns="False" Width="100%"
                                CellPadding="100" AllowPaging="True" PageSize="100">
                                <Columns>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            Sl No.
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblSRNO" runat="server"
                                                Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblByerId" runat="server" Text='<%# Eval("Buyer_ID")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="PrincipalName" HeaderText="Principal">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Buyer_Name" HeaderText="Buyer Name">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="BuyerDepartment_Name" HeaderText="Buying Department">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Address" HeaderText="Address">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Left" Width="20%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgButtonEidt" runat="server" ImageUrl="img/list_edit.png" OnClick="imgButtonEidt_Click" />
                                        </ItemTemplate>
                                        <ItemStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataRowStyle ForeColor="Red" />
                                <RowStyle CssClass="Grid_RowStyle" />
                                <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                <PagerSettings Mode="NumericFirstLast" />
                                <PagerStyle ForeColor="#000066" HorizontalAlign="Left" BackColor="White" CssClass="pagination01 pageback" />
                                <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/JavaScript">

        function func(result) {
            if (result === 'Buyer Saved Successfully') {
                toastr.success(result);
            }
            else if (result === 'Buyer Updated Successfully') {
                toastr.success(result);
            }
            else
                toastr.error(result);
            return false;
        }

    </script>
</asp:Content>
