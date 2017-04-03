<%@ Page Title="" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true"
    CodeBehind="employeeSetup.aspx.cs" Inherits="ERPSSL.HRM.employeeSetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
    <%@ Register Src="~/HRM/UserControls/AcademicInfo.ascx" TagPrefix="academicControl"
        TagName="academic" %>
    <%@ Register Src="~/HRM/UserControls/EmployeeExperience.ascx" TagPrefix="experienceControl"
        TagName="experience" %>
    <%--<%@ register src="~/HRM/UserControls/imageUpload.ascx" tagprefix="imageUploadControl"
        tagname="imageupload" %>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <%--<asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel2" ChildrenAsTriggers="true">--%>

    <%-- <ContentTemplate>--%>


    <div class="hm_sec_2_content scrollbar">
        <div class="panel">
            <div class="panel-heading panel-heading-01">
                <i class="fa fa-edit fa-fw icon-padding"></i>Employee Profile
            </div>
        </div>
        <asp:Panel ID="pnl_result" runat="server" Visible="false">
            <div class="result">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </div>
        </asp:Panel>
        <%-- <h2>
            Employee Setup</h2>--%>

        <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" Width="100%" OnDemand="true"
            childrenastriggers="True" CssClass="ajax__myTab" ActiveTabIndex="0">
            <ajaxToolkit:TabPanel runat="server" HeaderText="Personal Information" ID="TabPanel1"
                OnDemandMode="None">
                <ContentTemplate>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="row">
                                <div class="col-md-12 bg-success">
                                    <asp:Label ID="Label1" runat="server"></asp:Label>
                                </div>
                                <div class="col-md-12">
                                    <fieldset>
                                        <div class="panel">
                                            <div class="panel-heading panel-heading-01">
                                                <i class="fa fa-edit fa-fw icon-padding"></i>Personal Information
                                            </div>
                                        </div>
                                        <div>
                                            <p class="bg-primary" style="text-align: center" id="divAge" runat="server">
                                                <span style="text-align: center; font-size: 20px;">Not  Allow Below 18 Years of Age  For This Job . Your Age:
                                                   <asp:Label ID="lblage" runat="server"></asp:Label>
                                                </span>
                                            </p>
                                        </div>

                                        <div class="col-md-6">
                                            <br />
                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px">
                                                    <div class="col-md-5">
                                                        First Name<span style="color: #f00;">*</span>

                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:TextBox ID="txtFirstName" Class="form-control" runat="server" placeholder="Enter First Name"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtFirstName"
                                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input First Name"
                                                            ValidationGroup="GroupPersonalInfo"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px">
                                                    <div class="col-md-5">
                                                        Last Name
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:TextBox ID="txtLastName" Class="form-control" runat="server" placeholder="Enter Last Name"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px">
                                                    <div class="col-md-5">
                                                        Full Name (বাংলা)
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:TextBox ID="txtbxBangalFullName" Class="form-control" runat="server" placeholder="Enter Bangla Full Name"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLastName"
                                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Last Name"
                                                            ValidationGroup="GroupPersonalInfo"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px">
                                                    <div class="col-md-5">
                                                        Gender<span style="color: #f00;">*</span>
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:DropDownList ID="ddlGender" Class="form-control" runat="server">
                                                            <asp:ListItem Text="------- Select Gender-------- " Value="0"></asp:ListItem>
                                                            <asp:ListItem>Male</asp:ListItem>
                                                            <asp:ListItem>Female</asp:ListItem>
                                                            <asp:ListItem>Others</asp:ListItem>
                                                        </asp:DropDownList>

                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlGender"
                                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" InitialValue="0" ErrorMessage="Select Gender"
                                                            ValidationGroup="GroupPersonalInfo"></asp:RequiredFieldValidator>
                                                        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="GroupPersonalInfo"
                                                            runat="server" ControlToValidate="ddlGender" ErrorMessage="Select Gender" InitialValue="0"></asp:RequiredFieldValidator>--%>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px">
                                                    <div class="col-md-5">
                                                        Date of Birth
                                                    </div>
                                                    <div class="col-md-4">
                                                        <asp:TextBox runat="server" ID="txtDOB" OnTextChanged="txtDOB_TextChanged" AutoPostBack="True" Class="form-control" placeholder="MM/dd/yyyy" />

                                                        <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtDOB"
                                                            PopupButtonID="txtDOB" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDOB"
                                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Date of Brith"
                                                            ValidationGroup="GroupPersonalInfo"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <asp:TextBox runat="server" ID="txtbxTotalAge" placeholder="Age" Class="form-control" />
                                                    </div>

                                                </div>
                                            </div>


                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px">
                                                    <div class="col-md-5">
                                                        Blood Group<span style="color: #f00;">*</span>
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:DropDownList ID="ddlBloodGrp" Class="form-control" runat="server">
                                                            <asp:ListItem Text="------- Select Blood Group-------- " Value="0"></asp:ListItem>
                                                            <asp:ListItem>Not Avaliable</asp:ListItem>
                                                            <asp:ListItem>O +</asp:ListItem>
                                                            <asp:ListItem>O -</asp:ListItem>
                                                            <asp:ListItem>A +</asp:ListItem>
                                                            <asp:ListItem>A -</asp:ListItem>
                                                            <asp:ListItem>B +</asp:ListItem>
                                                            <asp:ListItem>B -</asp:ListItem>
                                                            <asp:ListItem>AB +</asp:ListItem>
                                                            <asp:ListItem>AB -</asp:ListItem>
                                                        </asp:DropDownList>


                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="ddlBloodGrp"
                                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" InitialValue="0" ErrorMessage="Select  Blood Group"
                                                            ValidationGroup="GroupPersonalInfo"></asp:RequiredFieldValidator>
                                                          

                                                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ValidationGroup="GroupPersonalInfo"
                                                            runat="server" ControlToValidate="ddlBloodGrp" ErrorMessage="Select Blood Group"
                                                            InitialValue="0"></asp:RequiredFieldValidator>--%>
                                                         
                                                    </div>
                                                </div>
                                            </div>




                                        </div>
                                        <div class="col-md-6">
                                            <br />
                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px">
                                                    <div class="col-md-5">
                                                        E-ID<span style="color: #f00;">*</span>
                                                    </div>
                                                    <div class="col-md-7">
                                                        <script src="js/CheckUser.js" type="text/javascript"></script>
                                                        <asp:UpdatePanel ID="PnlUsrDetails" runat="server">
                                                            <ContentTemplate>
                                                                <div id="Checkusername" runat="server" visible="false" class="CheckResult">
                                                                    <asp:Image ID="imgstatus" runat="server" CssClass="lblstatus_icon" />
                                                                    <asp:Label ID="lblStatus" runat="server"></asp:Label>
                                                                </div>
                                                                <div class="waitingdiv" id="loadingdiv" style="display: none">
                                                                    <img src="resources/ico/LoadingImage.gif" alt="Loading.." class="waiting_img" />
                                                                    Please wait...
                                                                </div>
                                                                <div class="clearfix">
                                                                    <asp:TextBox ID="txtEID" runat="server" placeholder="Unique Employee ID" CssClass="form-control"
                                                                        AutoPostBack="True" OnTextChanged="txtEID_TextChanged"></asp:TextBox>
                                                                </div>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtEID"
                                                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input E-Id"
                                                                    ValidationGroup="GroupPersonalInfo"></asp:RequiredFieldValidator>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                </div>
                                            </div>


                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px">
                                                    <div class="col-md-5">
                                                        N-ID
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:TextBox ID="txtbxNId" Class="form-control" runat="server" placeholder="Enter National ID Number"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px">
                                                    <div class="col-md-5">
                                                        Machine-ID<span style="color: #f00;">*</span>
                                                    </div>
                                                    <div class="col-md-7">
                                                        <script src="js/CheckUser.js" type="text/javascript"></script>
                                                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                            <ContentTemplate>
                                                                <div id="CheckusernameB" runat="server" visible="false" class="CheckResult">
                                                                    <asp:Image ID="imgstatusB" runat="server" CssClass="lblstatus_icon" />
                                                                    <asp:Label ID="lblStatusB" runat="server"></asp:Label>
                                                                </div>
                                                                <div class="waitingdivB" id="Div2" style="display: none">
                                                                    <img src="resources/ico/LoadingImage.gif" alt="Loading.." class="waiting_img" />
                                                                    Please wait...
                                                                </div>
                                                                <div class="clearfix">
                                                                    <asp:TextBox ID="txtBioID" runat="server" placeholder="Unique  Machine-ID" CssClass="form-control"
                                                                        AutoPostBack="True" OnTextChanged="txtBioID_TextChanged"></asp:TextBox>
                                                                </div>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtBioID"
                                                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input E-Id"
                                                                    ValidationGroup="GroupPersonalInfo"></asp:RequiredFieldValidator>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                </div>
                                            </div>



                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px">
                                                    <div class="col-md-5">
                                                        Marital Status<span style="color: #f00;">*</span>
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:DropDownList ID="ddlMariedSts" Class="form-control" runat="server">
                                                            <asp:ListItem Text="------- Select Marital Status-------- " Value="0"></asp:ListItem>
                                                            <asp:ListItem>Married</asp:ListItem>
                                                            <asp:ListItem>Un-Married</asp:ListItem>
                                                            <asp:ListItem>Separated</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlMariedSts"
                                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" InitialValue="0" ErrorMessage="Select Marital Status"
                                                            ValidationGroup="GroupPersonalInfo"></asp:RequiredFieldValidator>
                                                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ValidationGroup="GroupPersonalInfo"
                                                            runat="server" ControlToValidate="ddlMariedSts" ErrorMessage="Select Marital Status"
                                                            InitialValue="0"></asp:RequiredFieldValidator>--%>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px">
                                                    <div class="col-md-5">
                                                        Religion<span style="color: #f00;">*</span>
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:DropDownList ID="ddlReligion" Class="form-control" runat="server">
                                                            <asp:ListItem Text="------- Select Religion--------" Value="0"></asp:ListItem>
                                                            <asp:ListItem>Islam</asp:ListItem>
                                                            <asp:ListItem>Hinduism</asp:ListItem>
                                                            <asp:ListItem>Christianity</asp:ListItem>
                                                            <asp:ListItem>Buddhism</asp:ListItem>
                                                            <asp:ListItem>Others</asp:ListItem>
                                                        </asp:DropDownList>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlReligion"
                                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" InitialValue="0" ErrorMessage="Select Religion"
                                                            ValidationGroup="GroupPersonalInfo"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px">
                                                    <div class="col-md-5">
                                                        Nationality<span style="color: #f00;">*</span>
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:DropDownList ID="ddlNationality" CssClass="form-control" runat="server">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="rfv1" runat="server" ValidationGroup="GroupPersonalInfo" ControlToValidate="ddlNationality"
                                                            InitialValue="-- Select Country --" ErrorMessage="Select Nationality" />
                                                    </div>
                                                </div>
                                            </div>




                                        </div>
                                    </fieldset>
                                    <br />


                                    <fieldset>
                                        <div class="panel">
                                            <div class="panel-heading panel-heading-01">
                                                <i class="fa fa-edit fa-fw icon-padding"></i>Contact Information
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <br />
                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px">
                                                    <div class="col-md-5">
                                                        Contact No
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:TextBox ID="txtContactNo" Class="form-control" runat="server" placeholder="Enter Contact Number"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>


                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px">
                                                    <div class="col-md-5">
                                                        Present Address
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:TextBox ID="txtPresentAddr" TextMode="MultiLine" Class="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px">
                                                    <div class="col-md-5">
                                                        Permanent Address
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:TextBox ID="txtPermanentAddress" TextMode="MultiLine" Class="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px">
                                                    <div class="col-md-5">
                                                        Email ID
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:TextBox ID="txtEmailD" Class="form-control" runat="server" placeholder="Enter Email ID"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>



                                            <br />
                                        </div>
                                        <div class="col-md-6">
                                            <br />
                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px">
                                                    <div class="col-md-5">
                                                        Emergency Contact person
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:TextBox ID="txtbxEmergencyContactPerson" Class="form-control" runat="server" placeholder="Enter Emergency Contact person"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px">
                                                    <div class="col-md-5">
                                                        Relation
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:TextBox ID="txtbxConactPersonRelationName" Class="form-control" runat="server" placeholder="Enter Relation Ship"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>


                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px">
                                                    <div class="col-md-5">
                                                        Emergency Contact No
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:TextBox ID="txtEmergencyContact" Class="form-control" runat="server" placeholder="Enter Emergency Contact No"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>



                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px">
                                                    <div class="col-md-5">
                                                        Emergency Address
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:TextBox ID="txtbxEmergencyAddress" Class="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px">
                                                    <div class="col-md-5">
                                                        Alternative email
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:TextBox ID="txtbxAlternative" Class="form-control" runat="server" placeholder="Enter Alternative email"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                    </fieldset>
                                    <br />
                                    <fieldset>
                                        <div class="panel">
                                            <div class="panel-heading panel-heading-01">
                                                <i class="fa fa-edit fa-fw icon-padding"></i>Immediate Relative
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <br />
                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px">
                                                    <div class="col-md-5">
                                                        Father's Name
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:TextBox ID="txtFatherName" Class="form-control" runat="server" placeholder="Enter Father Name"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px">
                                                    <div class="col-md-5">
                                                        Father's Age
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:TextBox ID="txtbxFatherAge" Class="form-control" runat="server" placeholder="Enter Father's Age"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px">
                                                    <div class="col-md-5">
                                                        Father's Profession
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:TextBox ID="txtbxFatherProfession" Class="form-control" runat="server" placeholder="Enter Father's Profession"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px">
                                                    <div class="col-md-5">
                                                        Mother's Name
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:TextBox ID="txtMotherName" Class="form-control" runat="server" placeholder="Enter Mother's Name"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px">
                                                    <div class="col-md-5">
                                                        Mother's Age
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:TextBox ID="txtbxMotherAge" Class="form-control" runat="server" placeholder="Enter Mother's Age"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px">
                                                    <div class="col-md-5">
                                                        Mother's Profession
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:TextBox ID="txtbxMotherProfession" Class="form-control" runat="server" placeholder="Enter Mother's Profession"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="col-md-6">
                                            <br />
                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px">
                                                    <div class="col-md-5">
                                                        Spouse Name
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:TextBox ID="txtbxSpouseName" Class="form-control" runat="server" placeholder="Enter Spouse Name"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px">
                                                    <div class="col-md-5">
                                                        Spouse Age
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:TextBox ID="txtbxSpouseAge" Class="form-control" runat="server" placeholder="Enter Spouse Age"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>


                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px">
                                                    <div class="col-md-5">
                                                        Spouse Profession
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:TextBox ID="txtbxSpouseProfession" Class="form-control" runat="server" placeholder="Enter Spouse Profession"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px">
                                                    <div class="col-md-5">
                                                        Number Of Children
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:TextBox ID="txtbxNumberOfChildren" Class="form-control" runat="server" placeholder="Enter Number Of Children"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px">
                                                    <div class="col-md-5">
                                                        Children Name Remark
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:TextBox ID="txtbxChildrenNameRemark" TextMode="MultiLine" Class="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                    </fieldset>
                                    <br />
                                    <fieldset>
                                        <div class="panel">
                                            <div class="panel-heading panel-heading-01">
                                                <i class="fa fa-edit fa-fw icon-padding"></i>Nominee Information
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <br />
                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px">
                                                    <div class="col-md-5">
                                                        Name
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:TextBox ID="txtNomineeName" Class="form-control" runat="server" placeholder="Enter Nominee Name"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px">
                                                    <div class="col-md-5">
                                                        Age
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:TextBox ID="txtNomineeAge" Class="form-control" runat="server" placeholder="Enter Nominee Age"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <br />
                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px">
                                                    <div class="col-md-5">
                                                        Relation
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:TextBox ID="txtNomineeRelation" Class="form-control" runat="server" placeholder="Enter Relation with Nominee "></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>


                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px">
                                                    <div class="col-md-5">
                                                        Percentage(%)
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:TextBox ID="txtbxAddresss" Class="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>


                                        </div>

                                    </fieldset>
                                    <div class="row" style="float: right; padding-right: 10px">
                                        <br />
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                <asp:Label ID="PersonalInfo_ID" runat="server"></asp:Label>
                                            </div>
                                            <div class="col-md-7" style="padding-right: 10px;">
                                                <asp:Button ID="btnSavePersonalInfo" runat="server" ValidationGroup="GroupPersonalInfo" Text="Save"
                                                    class="btn btn-info pull-right" OnClick="btnSavePersonalInfo_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel runat="server" HeaderText="Employment" ID="TabPanel2" OnDemandMode="None">
                <ContentTemplate>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="row">
                                <div class="col-md-12 bg-success">
                                    <asp:Label ID="Label2" runat="server"></asp:Label>
                                </div>
                                <div class="col-md-12">
                                    <fieldset>
                                        <div class="panel">
                                            <div class="panel-heading panel-heading-01">
                                                <i class="fa fa-edit fa-fw icon-padding"></i>Employment Information
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <br />
                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px;">
                                                    <div class="col-md-5">
                                                        Region<span style="color: #f00;">*</span>
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:DropDownList ID="drpRegion" Class="form-control" runat="server" AutoPostBack="True"
                                                            OnSelectedIndexChanged="drpRegion_SelecttedIndexChanged">
                                                        </asp:DropDownList>
                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator15" ValidationGroup="Group2"
                                                            runat="server" ControlToValidate="drpRegion" ErrorMessage="Select Regions" InitialValue="0"></asp:RequiredFieldValidator>--%>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="drpRegion"
                                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" InitialValue="0" ErrorMessage="Select Regions"
                                                            ValidationGroup="Group2"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>


                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px;">
                                                    <div class="col-md-5">
                                                        Office<span style="color: #f00;">*</span>
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:DropDownList ID="ddlOffice" Class="form-control" AutoPostBack="True" runat="server"
                                                            OnSelectedIndexChanged="ddlOffice_SelecttedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddlOffice"
                                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" InitialValue="0" ErrorMessage="Select Office"
                                                            ValidationGroup="Group2"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px;">
                                                    <div class="col-md-5">
                                                        Department<span style="color: #f00;">*</span>
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:DropDownList ID="ddlDepartment" Class="form-control" AutoPostBack="True" runat="server"
                                                            AppendDataBoundItems="True" OnSelectedIndexChanged="ddlDepartment_SelecttedIndexChanged">
                                                        </asp:DropDownList>

                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="ddlDepartment"
                                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" InitialValue="0" ErrorMessage="Select Department"
                                                            ValidationGroup="Group2"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px;">
                                                    <div class="col-md-5">
                                                        Section<span style="color: #f00;">*</span>
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:DropDownList ID="ddlSection" Class="form-control" OnSelectedIndexChanged="ddlSection_SelecttedIndexChanged"
                                                            AutoPostBack="True" runat="server">
                                                        </asp:DropDownList>


                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="ddlSection"
                                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" InitialValue="0" ErrorMessage="Select Section"
                                                            ValidationGroup="Group2"></asp:RequiredFieldValidator>

                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px;">
                                                    <div class="col-md-5">
                                                        Sub-Sections<span style="color: #f00;">*</span>
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:DropDownList ID="ddlSubSections" Class="form-control" runat="server">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="ddlSubSections"
                                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" InitialValue="0" ErrorMessage="Select Sub-Section"
                                                            ValidationGroup="Group2"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px;">
                                                    <div class="col-md-5">
                                                        Employee Category<span style="color: #f00;">*</span>
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:DropDownList ID="drpEmployeeCate" Class="form-control" runat="server" AppendDataBoundItems="True">
                                                        </asp:DropDownList>


                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="drpEmployeeCate"
                                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" InitialValue="0" ErrorMessage="Select Employee Category"
                                                            ValidationGroup="Group2"></asp:RequiredFieldValidator>

                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px;">
                                                    <div class="col-md-5">
                                                        Employee Type<span style="color: #f00;">*</span>
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:DropDownList ID="drpEmployeeType" Class="form-control" runat="server" AppendDataBoundItems="True">
                                                        </asp:DropDownList>

                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="drpEmployeeType"
                                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" InitialValue="0" ErrorMessage="Select Employee Type"
                                                            ValidationGroup="Group2"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>




                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px;">
                                                    <div class="col-md-5">
                                                        Desgination<span style="color: #f00;">*</span>
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:DropDownList ID="drpdwnDesigantion" Class="form-control" runat="server" OnSelectedIndexChanged="drpStep_SelecttedIndexChanged"
                                                            AutoPostBack="True">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="drpdwnDesigantion"
                                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" InitialValue="0" ErrorMessage="Select Desgination"
                                                            ValidationGroup="Group2"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px;">
                                                    <div class="col-md-5">
                                                        Grade<%--<span style="color: #f00;">*</span>--%></div>

                                                    <div class="col-md-4">
                                                        <asp:DropDownList ID="ddlGrade" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="ddlGrade_SelecttedIndexChanged" Class="form-control" runat="server">
                                                        </asp:DropDownList>
                                                        <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator21" ValidationGroup="Group2"
                                                    runat="server" ControlToValidate="ddlGrade" ErrorMessage="Select Grade" InitialValue="0"></asp:RequiredFieldValidator>--%>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <asp:TextBox ID="txtbxGarde" Width="100%" Class="form-control" runat="server"></asp:TextBox>
                                                    </div>


                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px;">
                                                    <div class="col-md-5">
                                                        Gross Salary<span style="color: #f00;">*</span>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <asp:DropDownList ID="drpGrossSalary" Class="form-control" AutoPostBack="true" OnSelectedIndexChanged="GrossSalary_SelectedIndexChanged" runat="server">
                                                        </asp:DropDownList>

                                                    </div>
                                                    <div class="col-md-3">
                                                        <asp:TextBox ID="txtbxGrossSalary" Width="100%" Class="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px;">
                                                    <div class="col-md-5">
                                                        Shift Code<span style="color: #f00;">*</span>
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:DropDownList ID="ddlShift" Class="form-control" runat="server" AppendDataBoundItems="True">
                                                            <asp:ListItem Text="----- Select One ------ " Value="0"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator23" ValidationGroup="Group2"
                                                            runat="server" ControlToValidate="ddlShift" ErrorMessage="Select Shift" InitialValue="0"></asp:RequiredFieldValidator>--%>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlShift"
                                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" InitialValue="0" ErrorMessage="Select Shift"
                                                            ValidationGroup="Group2"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px;">
                                                    <div class="col-md-5">
                                                        Joining Date<span style="color: #f00;">*</span>
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:TextBox runat="server" ID="txtbxJoiningDate" Class="form-control" OnTextChanged="txtbxJoiningDate_TextChanged" AutoPostBack="True" placeholder="MM/dd/yyyy" />
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtbxJoiningDate"
                                                            PopupButtonID="txtDOB" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtbxJoiningDate"
                                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Joining Date"
                                                            ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="col-md-6">
                                            <br />
                                            <%-- <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Designations
                                            </div>
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="ddlDesignations" Class="form-control" runat="server" AppendDataBoundItems="True">
                                                    <asp:ListItem Text="----- Select One ------ " Value="0"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator22" ValidationGroup="Group2"
                                                    runat="server" ControlToValidate="ddlDesignations" ErrorMessage="Select Designation"
                                                    InitialValue="0"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>--%>


                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px;">
                                                    <div class="col-md-5">
                                                        OT Applicable<span style="color: #f00;">*</span>
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:DropDownList ID="drpdwnOTApplicable" Class="form-control" runat="server">
                                                            <asp:ListItem Text="------- Select -------- " Value="0"></asp:ListItem>
                                                            <asp:ListItem Value="true">Yes</asp:ListItem>
                                                            <asp:ListItem Value="false">No</asp:ListItem>

                                                        </asp:DropDownList>



                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px;">
                                                    <div class="col-md-5">
                                                        Attendance Bonus Applicable<%--<span style="color: #f00;">*--%></span></div>
                                                    <div class="col-md-7">
                                                        <asp:DropDownList ID="drpAttendanceBounsApplicable" Class="form-control" runat="server">
                                                            <asp:ListItem Text="------- Select -------- " Value="0"></asp:ListItem>
                                                            <asp:ListItem Value="true">Yes</asp:ListItem>
                                                            <asp:ListItem Value="false">No</asp:ListItem>

                                                        </asp:DropDownList>



                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px;">
                                                    <div class="col-md-5">
                                                        Late Allow<%--<span style="color: #f00;">*--%></span></div>
                                                    <div class="col-md-7">
                                                        <asp:DropDownList ID="drpLateAllow" Class="form-control" runat="server">
                                                            <asp:ListItem Text="------- Select -------- " Value="0"></asp:ListItem>
                                                            <asp:ListItem Value="true">Yes</asp:ListItem>
                                                            <asp:ListItem Value="false">No</asp:ListItem>

                                                        </asp:DropDownList>



                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px;">
                                                    <div class="col-md-5">
                                                        Absent Allow<%--<span style="color: #f00;">*--%></span></div>
                                                    <div class="col-md-7">
                                                        <asp:DropDownList ID="drpAbsentAllow" Class="form-control" runat="server">
                                                            <asp:ListItem Text="------- Select -------- " Value="0"></asp:ListItem>
                                                            <asp:ListItem Value="true">Yes</asp:ListItem>
                                                            <asp:ListItem Value="false">No</asp:ListItem>

                                                        </asp:DropDownList>



                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px;">
                                                    <div class="col-md-5">
                                                        Tax Applicable<%--<span style="color: #f00;">*--%></span></div>
                                                    <div class="col-md-7">
                                                        <asp:DropDownList ID="drpTaxApplicable" Class="form-control" runat="server">
                                                            <asp:ListItem Text="------- Select -------- " Value="0"></asp:ListItem>
                                                            <asp:ListItem Value="true">Yes</asp:ListItem>
                                                            <asp:ListItem Value="false">No</asp:ListItem>

                                                        </asp:DropDownList>



                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px;">
                                                    <div class="col-md-5">
                                                        PF Applicable<%--<span style="color: #f00;">*--%></span></div>
                                                    <div class="col-md-7">
                                                        <asp:DropDownList ID="drpPfApplicable" Class="form-control" runat="server">
                                                            <asp:ListItem Text="------- Select -------- " Value="0"></asp:ListItem>
                                                            <asp:ListItem Value="true">Yes</asp:ListItem>
                                                            <asp:ListItem Value="false">No</asp:ListItem>

                                                        </asp:DropDownList>



                                                    </div>
                                                </div>
                                            </div>


                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px;">
                                                    <div class="col-md-5">
                                                        Probation period From<%--<span style="color: #f00;">*</span>--%></div>
                                                    <div class="col-md-7">
                                                        <asp:TextBox runat="server" ID="txtboxProbationPeriodFrom" Class="form-control" placeholder="MM/dd/yyyy" />
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtboxProbationPeriodFrom"
                                                            PopupButtonID="txtboxProbationPeriodFrom" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />

                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px;">
                                                    <div class="col-md-5">
                                                        Probation period To<%--<span style="color: #f00;">*</span>--%></div>
                                                    <div class="col-md-7">
                                                        <asp:TextBox runat="server" ID="txtbxProbationPeriodTo" OnTextChanged="txtbxProbationPeriodTo_TextChanged" AutoPostBack="True" Class="form-control" placeholder="MM/dd/yyyy" />
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtbxProbationPeriodTo"
                                                            PopupButtonID="txtbxProbationPeriodTo" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />

                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px;">
                                                    <div class="col-md-5">
                                                        Total Month
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:TextBox runat="server" ID="txtbxTotalMonth" Class="form-control" placeholder="MM/dd/yyyy" />

                                                    </div>
                                                </div>
                                            </div>


                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px;">
                                                    <div class="col-md-5">
                                                        Confirmation date<%--<span style="color: #f00;">*</span>--%></div>
                                                    <div class="col-md-7">
                                                        <asp:TextBox runat="server" ID="txtbxConfirmationDate" Class="form-control" placeholder="MM/dd/yyyy" />
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtbxConfirmationDate"
                                                            PopupButtonID="txtbxConfirmationDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                                        <asp:TextBox runat="server" ID="txtxEffectiveSlary" Class="form-control" Visible="false" />
                                                    </div>
                                                </div>
                                            </div>

                                             

                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px;">
                                                    <div class="col-md-5">
                                                        Job Responsibility<%--<span style="color: #f00;">*</span>--%></div>
                                                    <div class="col-md-7">
                                                        <asp:TextBox ID="txtbxJobResponsibility" Class="form-control" TextMode="MultiLine"
                                                            runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px;">
                                                    <div class="col-md-5">
                                                        <asp:HiddenField ID="hdfEmploymentInfoID" runat="server"></asp:HiddenField>
                                                    </div>
                                                    <div class="" style="margin-right: 12px;">
                                                        <asp:Button ID="btnSaveEmploymentInfo" runat="server" ValidationGroup="Group2" Text="Save"
                                                            class="btn btn-info pull-right pull-right" OnClick="btnSaveEmploymentInfo_Click" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </fieldset>
                                    <br />
                                    <fieldset>
                                        <div class="panel">
                                            <div class="panel-heading panel-heading-01">
                                                <i class="fa fa-edit fa-fw icon-padding"></i>Bank Information
                                            </div>
                                        </div>
                                        <div class="col-md-12 bg-success">
                                            <asp:Label ID="lblBankMg" runat="server"></asp:Label>
                                        </div>
                                        <div class="col-md-6">
                                            <br />
                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px;">
                                                    <div class="col-md-5">
                                                        Bank Name
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:TextBox ID="txtbxBankName" Class="form-control" runat="server" placeholder="Enter Bank Name"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px;">
                                                    <div class="col-md-5">
                                                        A/C No
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:TextBox ID="txtbxAcNo" Class="form-control" runat="server" placeholder="Enter Account Number"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>


                                        </div>
                                        <div class="col-md-6">
                                            <br />
                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px;">
                                                    <div class="col-md-5">
                                                        Branch
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:TextBox ID="txtbxBranch" Class="form-control" runat="server" placeholder="Enter Branch Name"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-12" style="padding-bottom: 5px;">
                                                    <div class="col-md-5">
                                                        Address
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:TextBox ID="txtbxAddress" Class="form-control" runat="server" TextMode="MultiLine" Height="45px"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                        </div>

                                        <div class="col-md-12">
                                            <div class="alert alert-success" style="padding: 0px; padding-left: 10px" role="alert">Mobile Banking info.</div>
                                        </div>


                                        <div class="col-md-6">

                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="col-md-5">
                                                        Mobile No.
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:TextBox ID="txtbxMobileNo" Class="form-control" runat="server" placeholder="Enter Mobile Banking info"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />



                                        </div>
                                        <div class="col-md-6">

                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="col-md-5">
                                                        Mobile Bank Name
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:TextBox ID="txtbxMobileBankName" Class="form-control" runat="server" placeholder="Enter Mobile Bank Name"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="col-md-5">
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:Button ID="btnSaveBankInfo" runat="server" Text="Save"
                                                            class="btn btn-info pull-right pull-right" OnClick="btnSaveBankInfo_Click" />
                                                    </div>
                                                </div>
                                            </div>


                                        </div>


                                    </fieldset>

                                    <%--<fieldset>
                                <div class="panel">
                                    <div class="panel-heading panel-heading-01">
                                        <i class="fa fa-edit fa-fw icon-padding"></i>Grade Information
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Gross Salary:(BDT)
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ReadOnly="True" ID="txtGrossSalary" Class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Conveyance:(BDT)
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ReadOnly="True" ID="txtConveyance" Class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Medical:(BDT)
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ReadOnly="True" ID="txtMedical" Class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Others:(BDT)
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ReadOnly="True" ID="txtOthers" Class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                House Rent:(BDT)
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ReadOnly="True" ID="txtHouseRent" Class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Basic:(BDT)
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ReadOnly="True" ID="txtBasic" Class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Food Allowance:(BDT)
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ReadOnly="True" ID="txtFoodAlloance" Class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </fieldset>
                            <br />--%>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <fieldset>
                        <script src="js/CheckUser.js" type="text/javascript"></script>
                        <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>--%>
                        <div class="row">
                            <div class="col-md-12 bg-success">
                                <asp:Label ID="lblAssignTo" runat="server"></asp:Label>
                            </div>
                            <div class="panel">
                                <div class="panel-heading panel-heading-01">
                                    <i class="fa fa-edit fa-fw icon-padding"></i>Assign To
                                </div>
                            </div>
                            <div class="col-md-12">
                                <span class="label label-danger">Reporting Boss-1</span>
                            </div>
                            <fieldset>
                                <div class="col-md-6">
                                    <br />
                                    <div class="row">
                                        <div class="row">
                                            <div class="col-md-12" style="padding-bottom: 5px;">
                                                <div class="col-md-5">
                                                    Department
                                                </div>
                                                <div class="col-md-7">
                                                    <asp:DropDownList ID="drpFirstReportingDepartment" runat="server" OnSelectedIndexChanged="drpFirstReportingDepartment_SelecttedIndexChanged" AutoPostBack="true" Class="form-control"></asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="col-md-12">

                                                <div class="col-md-5">
                                                    E-ID
                                                </div>
                                                <div class="col-md-7">
                                                    <asp:TextBox ID="txtbxAssignToId" AutoPostBack="True" OnTextChanged="txtbxAssignToId_TextChanged"
                                                        Class="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <br />
                                    <div class="col-md-12" style="padding-bottom: 5px;">
                                        <div class="col-md-5">
                                            Reporting To
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="ddlReportingTo" OnSelectedIndexChanged="ddlReportingTo_SelecttedIndexChanged"
                                                Class="form-control" runat="server" AutoPostBack="True">
                                            </asp:DropDownList>

                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="ddlReportingTo"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" InitialValue="0" ErrorMessage="Select Reporting To"
                                                ValidationGroup="Group3"></asp:RequiredFieldValidator>

                                            <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator19" ValidationGroup="Group3"
                                                runat="server" ControlToValidate="ddlReportingTo" ErrorMessage="Select Reporting To"
                                                InitialValue="0"></asp:RequiredFieldValidator>--%>
                                        </div>
                                    </div>


                                    <div class="col-md-12" style="padding-bottom: 5px;">
                                        <div class="col-md-5">
                                            Designation
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtRptBossDsg" ReadOnly="true" Class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </fieldset>
                            <br />
                            <div class="col-md-12">
                                <span class="label label-danger">Reporting Boss-2</span>
                            </div>
                            <fieldset>
                                <div class="col-md-6">
                                    <br />
                                    <div class="row">
                                        <div class="row">
                                            <div class="col-md-12" style="padding-bottom: 5px;">
                                                <div class="col-md-5">
                                                    Department
                                                </div>
                                                <div class="col-md-7">
                                                    <asp:DropDownList runat="server" ID="drpwownSecondDepartmetn" OnSelectedIndexChanged="drpwownSecondDepartmetn_SelecttedIndexChanged" AutoPostBack="true" Class="form-control">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>

                                            <div class="col-md-12" style="padding-bottom: 5px;">

                                                <div class="col-md-5">
                                                    E-ID
                                                </div>
                                                <div class="col-md-7">
                                                    <asp:TextBox ID="txtbxSecondEdit" AutoPostBack="True" OnTextChanged="txtbxSecondEdit_TextChanged"
                                                        Class="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <br />
                                    <div class="col-md-12" style="padding-bottom: 5px;">
                                        <div class="col-md-5">
                                            Reporting To
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="drpSecondReportingTo" OnSelectedIndexChanged="drpSecondReportingTo_SelecttedIndexChanged"
                                                Class="form-control" runat="server" AutoPostBack="True">
                                            </asp:DropDownList>

                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="drpSecondReportingTo"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" InitialValue="0" ErrorMessage="Select Reporting To"
                                                ValidationGroup="Group3"></asp:RequiredFieldValidator>


                                            <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator26" ValidationGroup="Group3"
                                                runat="server" ControlToValidate="ddlReportingTo" ErrorMessage="Select Reporting To"
                                                InitialValue="0"></asp:RequiredFieldValidator>--%>
                                        </div>
                                    </div>



                                    <div class="col-md-12" style="padding-bottom: 5px;">
                                        <div class="col-md-5">
                                            Designation
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtbxSecondDesignation" ReadOnly="true" Class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <br />



                                </div>
                            </fieldset>

                            <br />
                            <div class="col-md-12">
                                <span class="label label-danger">Reporting Boss-3</span>
                            </div>
                            <fieldset>

                                <div class="col-md-6">
                                    <br />
                                    <div class="col-md-12" style="padding-bottom: 5px;">
                                        <div class="col-md-5">
                                            Department
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="drpdwnThridDepartment" runat="server" OnSelectedIndexChanged="drpdwnThridDepartment_SelecttedIndexChanged" AutoPostBack="true" Class="form-control"></asp:DropDownList>
                                        </div>

                                    </div>


                                    <div class="col-md-12" style="padding-bottom: 5px;">

                                        <div class="col-md-5">
                                            E-ID
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtbxThirdEditPerson" AutoPostBack="True" OnTextChanged="txtbxThirdEditPerson_TextChanged"
                                                Class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>




                                </div>
                                <div class="col-md-6">
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12" style="padding-bottom: 5px;">
                                            <div class="col-md-5">
                                                Reporting To
                                            </div>
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="drpdwnThirdReportingBoss" OnSelectedIndexChanged="drpdwnThirdReportingBoss_SelecttedIndexChanged"
                                                    Class="form-control" runat="server" AutoPostBack="True">
                                                </asp:DropDownList>
                                                <%--    <asp:RequiredFieldValidator ID="RequiredFieldValidator27" ValidationGroup="Group3"
                                                    runat="server" ControlToValidate="ddlReportingTo" ErrorMessage="Select Reporting To"
                                                    InitialValue="0"></asp:RequiredFieldValidator>--%>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="drpdwnThirdReportingBoss"
                                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" InitialValue="0" ErrorMessage="Select Reporting To"
                                                    ValidationGroup="Group3"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">

                                        <div class="col-md-12" style="padding-bottom: 5px;">
                                            <div class="col-md-5">
                                                Designation
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtbxThirdDesignation" ReadOnly="true" Class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>



                                    </div>
                                    <div class="row">
                                        <br />
                                        <div class="col-md-12">
                                            <br />
                                            <div class="col-md-5">
                                                <asp:HiddenField ID="HiddenField1" runat="server"></asp:HiddenField>
                                            </div>
                                            <div class="col-md-7">
                                                <asp:Button ID="btnAssignTo" runat="server" ValidationGroup="Group3" Text="Save"
                                                    class="btn btn-info pull-right pull-right" OnClick="btnAssignTo_Click" />
                                            </div>
                                        </div>
                                    </div>

                                </div>

                            </fieldset>
                            <%-- </ContentTemplate>
                                        </asp:UpdatePanel>--%>
                    </fieldset>
                    </div>
                            </div>
                            <%--</ContentTemplate>
                    </asp:UpdatePanel>--%>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel runat="server" HeaderText="Academic/Training" ID="TabPanel3"
                OnDemandMode="None">
                <ContentTemplate>
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <academicControl:academic ID="academicInfo" runat="server" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </ContentTemplate>

            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel runat="server" HeaderText="Experience" ID="TabPanel4" OnDemandMode="None">
                <ContentTemplate>
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <experienceControl:experience ID="experienceInfo" runat="server" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </ContentTemplate>

            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel runat="server" HeaderText="Image Upload" ID="TabPanel5" OnDemandMode="None">
                <ContentTemplate>

                    <%--<imageUploadControl:imageupload ID="imageUpload" runat="server" />--%>

                    <div class="row">
                        <div class="col-md-12 bg-success">
                            <asp:Label ID="lblImagemessage" runat="server"></asp:Label>
                        </div>
                        <div class="col-md-12">

                            <fieldset>
                                <div class="panel">
                                    <div class="panel-heading panel-heading-01">
                                        <i class="fa fa-edit fa-fw icon-padding"></i>Image Upload
                                    </div>
                                </div>
                                <div class="row">
                                    <br />
                                    <div class="col-md-12">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-12">
                                                <div class="col-md-5">
                                                    Employee Photo:
                                                </div>
                                                <div class="col-md-7">
                                                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="file_Upload" onchange="readfile(this);"
                                                        Width="85%" />
                                                </div>
                                            </div>
                                            <br />
                                            <div class="col-md-12">
                                                <div class="col-md-5">
                                                </div>
                                                <div class="col-md-7">
                                                    <asp:Image ID="Emp_IMG_TRNS" runat="server" class="avater_details" Height="150px"
                                                        ImageUrl="../resources/no_image.png" onerror="this.onerror=null; this.src='resources/no_image_found.png';"
                                                        Width="130px" />
                                                </div>
                                            </div>
                                            <br />
                                            <br />
                                            <div class="col-md-12">
                                                <div class="col-md-11">
                                                </div>
                                                <div class="col-md-1">
                                                    <asp:Button ID="btnimageUpload" runat="server" Text="Save" class="btn btn-info pull-right"
                                                        OnClick="btnimageUpload_Click" />
                                                </div>
                                            </div>
                                        </div>


                                        <div class="col-md-3">
                                        </div>
                                    </div>
                                </div>
                            </fieldset>


                            <fieldset>
                                <div class="panel">
                                    <div class="panel-heading panel-heading-01">
                                        <i class="fa fa-edit fa-fw icon-padding"></i>Singnature Upload
                                    </div>
                                </div>
                                <div class="row">
                                    <br />
                                    <div class="col-md-12">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-12">
                                                <div class="col-md-5">
                                                    Singature Photo:
                                                </div>
                                                <div class="col-md-7">
                                                    <asp:FileUpload ID="FileUpload2" runat="server" CssClass="file_Upload" onchange="readfile(this);"
                                                        Width="85%" />
                                                </div>
                                            </div>
                                            <br />
                                            <div class="col-md-12">
                                                <div class="col-md-5">
                                                </div>
                                                <div class="col-md-7">
                                                    <asp:Image ID="Image1" runat="server" class="avater_details" Height="150px"
                                                        ImageUrl="../resources/no_image.png" onerror="this.onerror=null; this.src='resources/no_image_found.png';"
                                                        Width="130px" />
                                                </div>
                                            </div>
                                            <br />
                                            <br />
                                            <div class="col-md-12">
                                                <div class="col-md-11">
                                                </div>
                                                <div class="col-md-1">
                                                    <asp:Button ID="btnSignatureUpload" runat="server" Text="Save" class="btn btn-info pull-right" OnClick="btnSignatureUpload_Click" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                        </div>
                                    </div>
                                </div>
                            </fieldset>


                            <fieldset>
                                <div class="panel">
                                    <div class="panel-heading panel-heading-01">
                                        <i class="fa fa-edit fa-fw icon-padding"></i>Nomine Image Upload
                                    </div>
                                </div>
                                <div class="row">
                                    <br />
                                    <div class="col-md-12">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-12">
                                                <div class="col-md-5">
                                                    Nominee Photo:
                                                </div>
                                                <div class="col-md-7">
                                                    <asp:FileUpload ID="FileUpload3" runat="server" CssClass="file_Upload" onchange="readfile(this);"
                                                        Width="85%" />
                                                </div>
                                            </div>
                                            <br />
                                            <div class="col-md-12">
                                                <div class="col-md-5">
                                                </div>
                                                <div class="col-md-7">
                                                    <asp:Image ID="Image2" runat="server" class="avater_details" Height="150px"
                                                        ImageUrl="../resources/no_image.png" onerror="this.onerror=null; this.src='resources/no_image_found.png';"
                                                        Width="130px" />
                                                </div>
                                            </div>
                                            <br />
                                            <br />
                                            <div class="col-md-12">
                                                <div class="col-md-11">
                                                </div>
                                                <div class="col-md-1">
                                                    <asp:Button ID="btnNominee" runat="server" Text="Save" class="btn btn-info pull-right" OnClick="btnNominee_Click" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                        </div>
                                    </div>
                                </div>
                            </fieldset>

                        </div>
                    </div>

                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel runat="server" HeaderText="Children's Information" ID="TabPanel6" OnDemandMode="None">
                <ContentTemplate>
                    <%--<imageUploadControl:imageupload ID="imageUpload" runat="server" />--%>
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="row">
                                <div class="col-md-12 bg-success">
                                    <asp:Label ID="childreInfomessage" runat="server"></asp:Label>
                                </div>
                                <div class="col-md-12">
                                    <br />
                                    <fieldset>
                                        <div class="panel">
                                            <div class="panel-heading panel-heading-01">
                                                <i class="fa fa-edit fa-fw icon-padding"></i>Children's Information
                                            </div>
                                        </div>
                                        <div class="row">
                                            <br />
                                            <div class="col-md-12">
                                                <div class="col-md-6">
                                                    <div class="col-md-12" style="padding-bottom: 5px">
                                                        <div class="col-md-5">
                                                            Name
                                                        </div>
                                                        <div class="col-md-7">
                                                            <asp:TextBox ID="txtbxChildrenName" Class="form-control" runat="server"></asp:TextBox>
                                                            <asp:HiddenField ID="hidchildren" runat="server" />
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12" style="padding-bottom: 5px">

                                                        <div class="col-md-5">
                                                            Date of Birth
                                                        </div>
                                                        <div class="col-md-7">
                                                            <asp:TextBox runat="server" ID="txtChildrenDOB" OnTextChanged="txtDob_TextChanged1" AutoPostBack="True" Class="form-control" placeholder="MM/dd/yyyy" />
                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtChildrenDOB"
                                                                PopupButtonID="txtChildrenDOB" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />

                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <div class="col-md-12" style="padding-bottom: 5px">
                                                        <div class="col-md-5">
                                                            Gender
                                                        </div>
                                                        <div class="col-md-7">
                                                            <asp:DropDownList ID="drpChildrenGender" Class="form-control" runat="server">
                                                                <asp:ListItem Text="------- Select Gender -------- " Value="0"></asp:ListItem>
                                                                <asp:ListItem>Male</asp:ListItem>
                                                                <asp:ListItem>Female</asp:ListItem>

                                                                <asp:ListItem>Others</asp:ListItem>
                                                            </asp:DropDownList>

                                                        </div>
                                                    </div>
                                                    <div class="col-md-12" style="padding-bottom: 5px">

                                                        <div class="col-md-5">
                                                            Age
                                                        </div>
                                                        <div class="col-md-7">
                                                            <asp:TextBox ID="txtbxChildrenAge" Class="form-control" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <br />
                                                    <div class="col-md-12">
                                                        <br />
                                                        <div class="col-md-5">
                                                        </div>
                                                        <div class="col-md-7">
                                                            <asp:Button ID="btnSave" runat="server" Text="Submit"
                                                                class="btn btn-info pull-right" OnClick="btnSave_Click" />
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>
                                            <div class="col-md-12">
                                                <asp:GridView ID="gridviewChildrenInfo" runat="server" Width="100%" AutoGenerateColumns="False"
                                                    AllowPaging="True" AllowSorting="True" CellPadding="5" PageSize="5" BorderColor="#99CCFF"
                                                    BorderStyle="Solid" CssClass="Grid_Border" ForeColor="#339933">
                                                    <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                                    <Columns>
                                                        <asp:TemplateField Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblChildrenID" runat="server" Text='<%# Eval("ChildId")%>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Name" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterStyle CssClass="Grid_Footer" />
                                                            <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                                            <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="20%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="DOB">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDoB" runat="server" Text='<%# Bind("DOB") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterStyle CssClass="Grid_Footer" />
                                                            <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                                            <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="10%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Age">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAge" runat="server" Text='<%# Bind("Age") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterStyle CssClass="Grid_Footer" />
                                                            <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                                            <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="20%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Working Department">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblGender" runat="server" Text='<%# Bind("Gender") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterStyle CssClass="Grid_Footer" />
                                                            <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                                            <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="20%" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Edit">
                                                            <ItemTemplate>
                                                                <asp:Button ID="lblChildrenInfo" runat="server" Text="Edit" class="btn btn-primary"
                                                                    OnClick="lblChildrenInfo_Click" />
                                                            </ItemTemplate>
                                                            <FooterStyle CssClass="Grid_Footer" />
                                                            <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                                            <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="15%" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EmptyDataRowStyle ForeColor="Red" />
                                                    <PagerSettings PageButtonCount="5" />
                                                    <RowStyle CssClass="Grid_RowStyle" />
                                                </asp:GridView>
                                            </div>

                                        </div>
                                    </fieldset>


                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
        </ajaxToolkit:TabContainer>
    </div>

    <%--</ContentTemplate>--%>

        <<%--Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnimageUpload"/>
        </Triggers>
    </asp:UpdatePanel>--%>
    <script>

        function func(result) {
            if (result === 'Data Save successfully!') {
                toastr.success(result);

            }
            else if (result === 'E-ID Conflict!') {
                toastr.error(result);

            }
            else if (result === 'Machine-ID Conflict!') {
                toastr.error(result);

            }
            else if (result === 'Image Save Successfully!') {
                toastr.success(result);
            }

            else if (result === 'Data Update successfully!') {
                toastr.success(result);
            }
            else
                toastr.error(result);

            return false;
        }

    </script>
</asp:Content>
