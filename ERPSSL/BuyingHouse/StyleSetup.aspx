<%@ Page Title="" Language="C#" MasterPageFile="~/BuyingHouse/BuyingSite.Master" AutoEventWireup="true" CodeBehind="StyleSetup.aspx.cs" Inherits="ERPSSL.BuyingHouse.StyleSetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <div class="hm_sec_2_content scrollbar">
        <div class="panel">
            <div class="panel-heading panel-heading-01">
                <i class="fa fa-edit fa-fw icon-padding"></i>Stype Setup 
            </div>
        </div>
        <div class="row">
            <div class="col-md-12 bg-success">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </div>
            <div class="col-md-12">   
                <div class="col-md-5">
                    <div class="row" style="padding-top: 3px;">
                        <div class="col-md-5">
                            Style Name <a style="color: red; font-size: 11px">*</a>
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtStyle" runat="server" class="form-control"></asp:TextBox>
                            <asp:HiddenField ID="hidBueyId" runat="server" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtStyle"
                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Style Name"
                                ValidationGroup="Group1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row" style="padding-top: 3px;">
                        <div class="col-md-5">
                            Specification 
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtSpecification" runat="server" class="form-control"></asp:TextBox>
                            <asp:HiddenField ID="HiddenField1" runat="server" />

                        </div>
                    </div>

                    <div class="row" style="padding-top: 3px;">
                        <div class="col-md-5">
                            H S Code
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtHSCode" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row" style="padding-top: 3px;">
                        <div class="col-md-5">
                            Men Ladies
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtMenLadies" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row" style="padding-top: 3px;">
                        <div class="col-md-5">
                            Top/Bottom
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtTopBottom" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row" style="padding-top: 3px;">
                        <div class="col-md-5">
                            Product Description
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtProductDescription" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row" style="padding-top: 3px;">
                        <div class="col-md-5">
                            Fabrics
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtFabrics" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row" style="padding-top: 3px;">
                        <div class="col-md-5">
                            Accessories
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtAccessories" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row" style="padding-top: 3px;">
                        <div class="col-md-5">
                            Country Of Production
                        </div>
                        <div class="col-md-7">
                            <asp:DropDownList ID="ddlCountry" class="form-control" runat="server">
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
                    </div>
                    <div class="row" style="padding-top: 3px;">
                        <div class="col-md-5">
                            Price
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtPrice" runat="server" Text="0" class="form-control"></asp:TextBox>
                        </div>
                    </div>


                    <div class="row" style="padding-top: 5px;">
                        <div class="col-md-5">
                            Employee Photo:
                        </div>
                        <div class="col-md-7" style="text-align: right;">
                            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="file_Upload" onchange="readfile(this);"
                                Width="85%" />
                            <%-- <asp:Image ID="imgUploadStyle" runat="server" class="avater_details" ImageAlign="Right" Height="150px"
                                ImageUrl="../resources/no_image.png" onerror="this.onerror=null; this.src='resources/no_image_found.png';"
                                Width="130px" />--%>
                        </div>
                    </div>
                   



                    <div class="row">
                        <fieldset>
                            <legend style="line-height: 0px; padding-top: 5px;"><span style="background: #fff">Size Setup</span></legend>
                            <div class="col-md-12" style="padding-top: 5px;">

                                <div class="col-md-3">
                                    Size From
                                <asp:TextBox ID="txtSizeFrom" runat="server" class="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-3">
                                    Size To
                                <asp:TextBox ID="txtSizeTo" runat="server" class="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    Months
                                 <asp:DropDownList ID="ddlType" runat="server" class="form-control">
                                     <asp:ListItem>Size</asp:ListItem>
                                     <asp:ListItem>Months</asp:ListItem>
                                     <asp:ListItem>Years</asp:ListItem>
                                 </asp:DropDownList>
                                </div>
                                <div class="col-md-2" style="padding-top: 13px">
                                    <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/BuyingHouse/img/check60.png"
                                        OnClick="btnAdd_Click" Width="32px" />
                                </div>







                            </div>

                            <div class="col-md-12" style="padding-top: 5px;">
                                <asp:GridView ID="GridSize" runat="server" AutoGenerateColumns="False" Width="100%"
                                    CellPadding="5" AllowPaging="false" PageSize="10">
                                    <%--OnPageIndexChanging="gridviewSection_PageIndexChanging"--%>
                                    <Columns>

                                        <%-- <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center">
                                <HeaderTemplate>
                                    Sl No.
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblSRNO" runat="server"
                                        Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>

                                        <asp:TemplateField HeaderText="Sl.">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSerial" runat="server" Text='<%#Eval("Size_Id") %>'
                                                    Width="30px"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header Color_Green" Width="5%" />
                                            <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer Color_Green" Width="5%" />
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="SizeFrom" HeaderText="Size From">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="SizeTo" HeaderText="Size To">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="type" HeaderText="type">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Option">
                                            <ItemTemplate>
                                                 <span onclick="return confirm('Are you sure want to delete?')">
                                                <asp:ImageButton ID="imgButtonDelete" runat="server" ImageUrl="~/BuyingHouse/img/list_Delete.png" OnClick="imgButtonDelete_Click" />
                                            </ItemTemplate>
                                            <ItemStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                                        </asp:TemplateField>

                                        <%--<asp:BoundField DataField="Style_Photo" HeaderText="Name">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>--%>
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
                        </fieldset>
                    </div>

                     <div class="row" style="padding-top: 8px;">
                        <div class="col-md-12">
                            <div class="col-md-3">
                            </div>
                            <div class="col-md-9">
                                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" ValidationGroup="Group1" Text="Submit" class="btn btn-info  pull-right" /><%--OnClick="btnSave_Click"--%>
                            </div>
                        </div>
                    </div>




                </div>
                <div class="col-md-7">
                    <div class="col-md-12" style="overflow-x: hidden; overflow-y: scroll; max-height: 400px; height: auto ; max-width: 1000px; width:auto;">
                    <asp:GridView ID="grdStyle" runat="server" AutoGenerateColumns="False" Width="100%"
                        CellPadding="5" AllowPaging="false" PageSize="10">
                        <%--OnPageIndexChanging="gridviewSection_PageIndexChanging"--%>
                        <Columns>

                            <%-- <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center">
                                <HeaderTemplate>
                                    Sl No.
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblSRNO" runat="server"
                                        Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>

                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="2%" HeaderStyle-HorizontalAlign="Center">
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
                                    <asp:Label ID="lblByerId" runat="server" Text='<%# Eval("StyleId")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="StyleName" HeaderText="Name">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Specification" HeaderText="Specification">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                            <asp:BoundField DataField="HS_Code" HeaderText="HS Code">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                            <%--<asp:BoundField DataField="Style_Photo" HeaderText="Name">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>--%>
                            <asp:TemplateField HeaderText="Image">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemTemplate>
                                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# "StyleImg.ashx?StyleId="+ Eval("StyleId") %>' Width="60%" />
                                </ItemTemplate>
                                <ItemStyle Width="4%" HorizontalAlign="Center" />
                                <ControlStyle CssClass="imgwd" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:TemplateField>

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
    </div>

    <script type="text/javascript">

        function func(result) {
            if (result === 'Style Saved Successfully') {
                toastr.success(result);
            }
            else if (result === 'Style Updated Successfully') {
                toastr.success(result);
            }
            else
                toastr.error(result);
            return false;
        }

    </script>
</asp:Content>
