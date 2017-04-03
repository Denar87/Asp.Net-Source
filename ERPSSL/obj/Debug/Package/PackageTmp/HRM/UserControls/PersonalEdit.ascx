<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PersonalEdit.ascx.cs"
    Inherits="ERPSSL.HRM.UserControls.PersonalEdit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:UpdatePanel ID="UpdatePanelSubmit" runat="server">

    <ContentTemplate>
        <div>
            <div class="tab-header">
                Personal Details
    <asp:Button ID="btnedit" runat="server" Text="Edit" CssClass="btn btn-default pull-right tab-button"
        OnClick="BtnEdit_Click" />
            </div>
            <asp:Panel ID="Panel1" runat="server" Style="display: none" CssClass="modalPopupFreight">


                <%-- <h2>
                    Grade Info (<asp:Label ID="lblID" runat="server"></asp:Label>)</h2>--%>
                <div>
                    <asp:Label ID="lblModalMessage" runat="server" Font-Bold="true"></asp:Label>
                    <link href="../../css/Modal.css" rel="stylesheet" />
                    <div class="modal-dialog">
                        <div class="popuHeader">
                            <asp:Panel ID="Panel3" runat="server">
                                <asp:LinkButton ID="CancelButton" runat="server">
                                    <button type="button" style="color:white" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                </asp:LinkButton>
                            </asp:Panel>
                            <h4 id="myModalLabel">Personal Details</h4>
                        </div>
                        <div id="Div2">
                            <asp:HiddenField ID="hidMachineId" runat="server" />
                            <div class="row tab-data" style="padding-top: 7px;">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>
                                        First Name
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <asp:TextBox ID="txtbxFirstName" runat="server" class="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtbxFirstName"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input First Name"
                                            ValidationGroup="GroupPersonalInfo"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>Last Name</h4>
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <asp:TextBox ID="txtbxLastName" runat="server" class="form-control"></asp:TextBox>
                                        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtbxLastName"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Last Name"
                                                ValidationGroup="GroupPersonalInfo"></asp:RequiredFieldValidator>--%>
                                    </div>
                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>Full Name (বাংলা)</h4>
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <asp:TextBox ID="txtbxBangalFullName" Class="form-control" runat="server"></asp:TextBox>


                                    </div>
                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>Gender </h4>
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <asp:DropDownList ID="ddlGender" Class="form-control" runat="server">
                                            <asp:ListItem Text="------- Select -------- " Value="0"></asp:ListItem>
                                            <asp:ListItem>Male</asp:ListItem>
                                            <asp:ListItem>Female</asp:ListItem>
                                            <asp:ListItem>Others</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="GroupPersonalInfo"
                                            runat="server" ControlToValidate="ddlGender" ErrorMessage="Select Gender" InitialValue="0"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>Religion </h4>
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <asp:DropDownList ID="ddlReligion" Class="form-control" runat="server">
                                            <asp:ListItem Text="Islam" Value="Islam"></asp:ListItem>
                                            <asp:ListItem>Buddhism</asp:ListItem>
                                            <asp:ListItem>Christianity</asp:ListItem>
                                            <asp:ListItem>Hinduism</asp:ListItem>
                                            <asp:ListItem>Jainism</asp:ListItem>
                                            <asp:ListItem>Judaism</asp:ListItem>
                                            <asp:ListItem>Roman Cathlic</asp:ListItem>
                                            <asp:ListItem>Sikhism</asp:ListItem>
                                            <asp:ListItem>Others</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="GroupPersonalInfo"
                                            runat="server" ControlToValidate="ddlReligion" ErrorMessage="Select Religion"
                                            InitialValue="0"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>Date of Birth </h4>
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <p>
                                            <asp:TextBox ID="txtbxdateOfBrith" runat="server" class="form-control"></asp:TextBox>
                                        </p>
                                        <asp:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtbxdateOfBrith"
                                            PopupButtonID="txtbxdateOfBrith" Format="MM/dd/yyyy" CssClass="ajax__calendar"
                                            Enabled="True" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtbxdateOfBrith"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Date of Brith"
                                            ValidationGroup="GroupPersonalInfo"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>Nationality</h4>
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <asp:DropDownList ID="ddlNationality" CssClass="form-control" runat="server">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfv1" runat="server" ValidationGroup="GroupPersonalInfo"
                                            ControlToValidate="ddlNationality" InitialValue="-- Select Country --" ErrorMessage="Select Nationality" />
                                    </div>
                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>N-ID</h4>
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <asp:TextBox ID="txtbxNId" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>


                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>Machine-ID</h4>
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <asp:TextBox ID="txtbxMachineID" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <%--<div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>Machine-ID</h4>
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">                                      
                                         <script src="js/CheckUser.js" type="text/javascript"></script>
                                                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                            <ContentTemplate>
                                                                <div id="CheckusernameB" runat="server" visible="false" class="CheckResult">
                                                                    <asp:Image ID="imgstatusB" runat="server" CssClass="lblstatus_icon" />
                                                                    <asp:Label ID="lblStatusB" runat="server"></asp:Label>
                                                                </div>
                                                                <div class="waitingdivB" id="Div9" style="display: none">
                                                                    <img src="resources/ico/LoadingImage.gif" alt="Loading.." class="waiting_img" />
                                                                    Please wait...
                                                                </div>
                                                                <div class="clearfix">
                                                                    <asp:TextBox ID="txtbxMachineID" runat="server" placeholder="Unique  Machine-ID" CssClass="form-control"
                                                                        AutoPostBack="True" OnTextChanged="txtBioID_TextChanged"></asp:TextBox>
                                                                </div>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtbxMachineID"
                                                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input E-Id"
                                                                    ValidationGroup="GroupPersonalInfo"></asp:RequiredFieldValidator>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>--%>


                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>Blood Group </h4>
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <asp:DropDownList ID="ddlBloodGrp" Class="form-control" runat="server">
                                            <asp:ListItem Text="------- Select -------- " Value="0"></asp:ListItem>
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
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ValidationGroup="GroupPersonalInfo"
                                            runat="server" ControlToValidate="ddlBloodGrp" ErrorMessage="Select Blood Group"
                                            InitialValue="0"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>Marital Status</h4>
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <asp:DropDownList ID="ddlMariedSts" Class="form-control" runat="server">
                                            <asp:ListItem Text="------- Select -------- " Value="0"></asp:ListItem>
                                            <asp:ListItem>Married</asp:ListItem>
                                            <asp:ListItem>Un-Married</asp:ListItem>
                                            <asp:ListItem>Separated</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ValidationGroup="GroupPersonalInfo"
                                            runat="server" ControlToValidate="ddlMariedSts" ErrorMessage="Select Marital Status"
                                            InitialValue="0"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="submission">
                            <%--<asp:Button ID="btnReset" runat="server" Text="Reset" Width="80px" CssClass="btn btn-info pull-right" />--%>
                            <div class="col-md-12">
                                <asp:Button ID="btnUpdate" runat="server" ValidationGroup="GroupPersonalInfo" Text="Update"
                                    Width="80px" CssClass="btn btn-info pull-right" OnClick="btnUpdate_click" Style="margin-right: 8px;" />
                            </div>
                        </div>
                    </div>

                </div>

            </asp:Panel>
            <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
            <asp:ModalPopupExtender ID="ModalPopupExtender" runat="server" TargetControlID="LinkButton1"
                PopupControlID="Panel1" BackgroundCssClass="modalBackground" CancelControlID="CancelButton"
                DropShadow="True" PopupDragHandleControlID="Panel3" DynamicServicePath="" Enabled="True" />

            <div id="Div1">
                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>
                            First Name
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblFirstName" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Last name </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblLastName" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Full Name (বাংলা) </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblBanglaFullName" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>

                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Gender </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblGender" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>


                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Religion </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblReligion" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Date of Brith</h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblDateOfBrith" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Marital Status</h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblMaritalStatus" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Blood Group </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblBloodGroup" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>N-ID</h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblNId" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>

                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Machine ID</h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblMachineId" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>

                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Nationality</h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblNationality" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
            </div>

        </div>

        <div>
            <div class="tab-header">
                Contact Information
    <asp:Button ID="btnAcademic" runat="server" Text="Add" CssClass="btn btn-default pull-right tab-button"
        OnClick="btnContactInfo_Click" />
            </div>
            <asp:Panel ID="Panel2" runat="server" Style="display: none" CssClass="modalPopupFreight">


                <div>
                    <asp:Label ID="lblContactMessage" runat="server" Font-Bold="true"></asp:Label>
                    <div class="modal-dialog">
                        <asp:Panel ID="Panel4" runat="server">
                            <div class="popuHeader">

                                <asp:LinkButton ID="LinkButton2" runat="server">
                                   <button type="button" style="color:white" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                </asp:LinkButton>
                                <h4 id="H1">Contact Information</h4>
                            </div>
                        </asp:Panel>


                        <div id="Div3">


                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>Contact NO</h4>
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <p>
                                            <asp:TextBox ID="txtbxContactNo" runat="server" class="form-control"></asp:TextBox>
                                        </p>
                                    </div>
                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>Present Address</h4>
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <p>
                                            <asp:TextBox ID="txtbxPresentAddress" runat="server" class="form-control"></asp:TextBox>
                                        </p>
                                    </div>
                                </div>
                            </div>

                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>Permanent Address</h4>
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <p>
                                            <asp:TextBox ID="txtbxPermanentAddress" runat="server" class="form-control"></asp:TextBox>
                                        </p>
                                    </div>
                                </div>
                            </div>



                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>Emergency Contact Person</h4>
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <p>
                                            <asp:TextBox ID="txtbxEmergenceContactPerson" runat="server" class="form-control"></asp:TextBox>
                                        </p>
                                    </div>
                                </div>
                            </div>

                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>Emergency Contact</h4>
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <p>
                                            <asp:TextBox ID="txtbxEmergenceContact" runat="server" class="form-control"></asp:TextBox>
                                        </p>
                                    </div>
                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>Relation</h4>
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <p>
                                            <asp:TextBox ID="txtbxEmergenceContactRelation" runat="server" class="form-control"></asp:TextBox>
                                        </p>
                                    </div>
                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>Emergence Contact Address</h4>
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <p>
                                            <asp:TextBox ID="txtbxEmergenceContactAddress" runat="server" class="form-control"></asp:TextBox>
                                        </p>
                                    </div>
                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>Email </h4>
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <p>
                                            <asp:TextBox ID="txtbxEmail" runat="server" class="form-control"></asp:TextBox>
                                        </p>
                                    </div>
                                </div>
                            </div>

                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>
                                        Alternative Email /h4>
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <p>
                                            <asp:TextBox ID="txtbxAllternativeEmail" runat="server" class="form-control"></asp:TextBox>
                                        </p>
                                    </div>
                                </div>
                            </div>

                        </div>
                        <div class="submission">
                            <%--<asp:Button ID="btnAcademicReset" runat="server" Text="Reset" Width="80px" CssClass="btn btn-info pull-right" />--%>
                            <div class="col-md-12">
                                <asp:Button ID="btnSaveandUpdate" runat="server"
                                    Text="Submit" Width="80px" CssClass="btn btn-info pull-right" OnClick="ContactInfo_Click" Style="margin-right: 8px;" />
                            </div>
                        </div>
                    </div>

                </div>

            </asp:Panel>
            <asp:LinkButton ID="LinkButton3" runat="server"></asp:LinkButton>
            <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="LinkButton3"
                PopupControlID="Panel2" BackgroundCssClass="modalBackground" CancelControlID="CancelButton"
                DropShadow="True" PopupDragHandleControlID="Panel4" DynamicServicePath="" Enabled="True" />


            <div id="Div4">
                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Contact No
                            </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblContactNo" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>
                            Present Address
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblPresentAddress" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Permanent Address
                            </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblPermanentAddress" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Emergence Contact Person
                            </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblEmergenceContactPeson" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Relation
                            </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblEmergenceContractRelation" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>

                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Emergence Contact No
                            </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblEmergenceContactNo" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Emergence Contact Address
                            </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblEmergenceContactAddress" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>

                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Email
                            </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>

                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Alternative Email
                            </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblAlternativeEmail" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>

            </div>
        </div>
        <div>
            <div class="tab-header">
                Immediate Relative Information
    <asp:Button ID="btnImmediateRelative" runat="server" Text="Add" CssClass="btn btn-default pull-right tab-button"
        OnClick="btnImmediateRelative_Click" />
            </div>
            <asp:Panel ID="Panel5" runat="server" Style="display: none" CssClass="modalPopupFreight">


                <div>
                    <asp:Label ID="lblImmediateRelativeInfoMess" runat="server" Font-Bold="true"></asp:Label>
                    <div class="modal-dialog">
                        <asp:Panel ID="Panel6" runat="server">
                            <div class="popuHeader">
                                <asp:LinkButton ID="LinkButton4" runat="server">
                                    <button type="button" style="color:white" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                </asp:LinkButton>
                                <h4 id="H2">Immediate Relative Information</h4>
                            </div>
                        </asp:Panel>
                        <div id="Div5">
                            <div class="row tab-data" style="padding-top: 7px;">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>Father Name</h4>
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <p>
                                            <asp:TextBox ID="txtbxFatherName" runat="server" class="form-control"></asp:TextBox>
                                        </p>

                                    </div>

                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>Father's Age</h4>
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <p>
                                            <asp:TextBox ID="txtbxFatherAge" runat="server" class="form-control"></asp:TextBox>
                                        </p>

                                    </div>

                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>Father's Profession</h4>
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <p>
                                            <asp:TextBox ID="txtbxFatherProfession" runat="server" class="form-control"></asp:TextBox>
                                        </p>

                                    </div>

                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>Mother's Name </h4>
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <p>
                                            <asp:TextBox ID="txtbxMotherName" runat="server" class="form-control"></asp:TextBox>
                                        </p>

                                    </div>

                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>Mother's Age</h4>
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <p>
                                            <asp:TextBox ID="txtbxMotherAge" runat="server" class="form-control"></asp:TextBox>
                                        </p>

                                    </div>

                                </div>
                            </div>

                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>Mother's Profession</h4>
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <p>
                                            <asp:TextBox ID="txtbxMotherProfession" runat="server" class="form-control"></asp:TextBox>
                                        </p>

                                    </div>

                                </div>
                            </div>

                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>Spouse Name</h4>
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <p>
                                            <asp:TextBox ID="txtbxSpourseName" runat="server" class="form-control"></asp:TextBox>
                                        </p>

                                    </div>

                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>Spouse Age</h4>
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <p>
                                            <asp:TextBox ID="txtbxSpourseAge" runat="server" class="form-control"></asp:TextBox>
                                        </p>

                                    </div>

                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>Spouse Profession</h4>
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <p>
                                            <asp:TextBox ID="txtbxSpourseProfession" runat="server" class="form-control"></asp:TextBox>
                                        </p>

                                    </div>

                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>Number Of Children</h4>
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <p>
                                            <asp:TextBox ID="txtbxNumberOfChilldren" runat="server" class="form-control"></asp:TextBox>
                                        </p>

                                    </div>

                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>Children Name Remark </h4>
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <p>
                                            <asp:TextBox ID="txtbxChildrenNameRemark" runat="server" class="form-control"></asp:TextBox>
                                        </p>

                                    </div>

                                </div>
                            </div>

                        </div>
                        <div class="submission">
                            <%--<asp:Button ID="Button4" runat="server" Text="Reset" Width="80px" CssClass="btn btn-info pull-right" />--%>
                            <div class="col-md-12">
                                <asp:Button ID="btnTraingUpdateAndSumit" runat="server" Text="Update" Width="80px"
                                    CssClass="btn btn-info pull-right" OnClick="ImmediateUpdateButton_Click" Style="margin-right: 8px;" />
                            </div>
                        </div>
                    </div>

                </div>

            </asp:Panel>
            <asp:LinkButton ID="LinkButton5" runat="server"></asp:LinkButton>
            <asp:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="LinkButton5"
                PopupControlID="Panel5" BackgroundCssClass="modalBackground" CancelControlID="CancelButton"
                DropShadow="True" PopupDragHandleControlID="Panel6" DynamicServicePath="" Enabled="True" />

            <div id="Div6">
                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Father's Name
                            </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblFatherName" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Father's Age
                            </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblFatherAge" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Father's Profession
                            </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblFatherProfession" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Mother's Name
                            </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblMotherName" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Mother's Age
                            </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblMotherAge" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Mother's Profession
                            </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblMotherProfession" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Spourse Name
                            </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblSpourseName" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Spourse Age
                            </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblSpourseAge" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Spourse Profession
                            </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblSpourseProfession" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>
                            Number Of Children
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblNumberOfChildren" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>

                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Children Name Remark
                            </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblChildrenNameRemark" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div>
            <div class="tab-header">
                Nominee Information
    <asp:Button ID="Button1s" runat="server" Text="Add" CssClass="btn btn-default pull-right tab-button"
        OnClick="BtnEdits_Click" />
            </div>
            <asp:Panel ID="Panel7" runat="server" Style="display: none" CssClass="modalPopupFreight">


                <div>
                    <asp:Label ID="lblNomineeMessage" runat="server" Font-Bold="true"></asp:Label>
                    <div class="modal-dialog">
                        <asp:Panel ID="Panel8" runat="server">
                            <div class="popuHeader">

                                <asp:LinkButton ID="LinkButton6" runat="server">
                                    <button type="button" style="color:white" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                </asp:LinkButton>
                                <h4 id="H3">Nominee Information</h4>
                            </div>
                        </asp:Panel>
                        <div id="Div7">
                            <div class="row tab-data" style="padding-top: 7px">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>
                                        Name
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <asp:TextBox ID="txtbxNomineeName" runat="server" Class="form-control"></asp:TextBox>

                                    </div>

                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>
                                        Age
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <asp:TextBox ID="txtbxAge" runat="server" Class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>
                                        Relation
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <asp:TextBox ID="txtbxRelation" runat="server" Class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>
                                        Percentage(%)
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <asp:TextBox ID="txtbxAddress" runat="server" Class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="submission">
                            <%--<asp:Button ID="btnSkilReset" runat="server" Text="Reset" Width="80px" CssClass="btn btn-info pull-right" />--%>
                            <div class="col-md-12">
                                <asp:Button ID="btnSkillUpdate" runat="server" Text="Submit"
                                    Width="80px" CssClass="btn btn-info pull-right" OnClick="btnNomineeUpdate_Click" Style="margin-right: 8px;" />
                            </div>
                        </div>
                    </div>

                </div>

            </asp:Panel>
            <asp:LinkButton ID="LinkButton7" runat="server"></asp:LinkButton>
            <asp:ModalPopupExtender ID="ModalPopupExtender3" runat="server" TargetControlID="LinkButton7"
                PopupControlID="Panel7" BackgroundCssClass="modalBackground" CancelControlID="LinkButton6"
                DropShadow="True" PopupDragHandleControlID="Panel8" DynamicServicePath="" Enabled="True" />

            <div id="Div8">
                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Name
                            </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Age
                            </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblAge" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Relation
                            </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblRelation" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Percentage(%)
                            </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblNomineeAdress" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
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
