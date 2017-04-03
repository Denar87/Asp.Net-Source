<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="employementEdit.ascx.cs"
    Inherits="ERPSSL.HRM.UserControls.employementEdit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:UpdatePanel ID="UpdatePanelSubmit" runat="server">

    <ContentTemplate>
        <div>
            <div class="tab-header">
                Employment Details
    <asp:Button ID="btnedit" runat="server" Text="Edit" CssClass="btn btn-default pull-right tab-button"
        OnClick="BtnEdit_Click" />
            </div>
            <asp:Panel ID="Panel1" runat="server" Style="display: none" CssClass="modalPopupFreight">


                <div>
                    <asp:Label ID="lblModalMessage" runat="server" Font-Bold="true"></asp:Label>
                    <link href="../../css/Modal.css" rel="stylesheet" />
                    <div class="modal-dialog">
                        <asp:Panel ID="Panel3" runat="server">
                            <div class="popuHeader">
                                <asp:LinkButton ID="CancelButton" runat="server">
                                    <button type="button"  style="color:white" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                </asp:LinkButton>
                                <h4 id="myModalLabel">Employment Details</h4>
                            </div>
                        </asp:Panel>
                        <div id="Div2">
                            <div class="row tab-data" style="padding-top: 7px;">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>
                                        Region 
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <asp:DropDownList ID="drpRegion" Class="form-control" runat="server" AutoPostBack="True"
                                            OnSelectedIndexChanged="drpRegion_SelecttedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" ValidationGroup="Group2"
                                            runat="server" ControlToValidate="drpRegion" ErrorMessage="Select Regions" InitialValue="0"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>
                                        Office
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <asp:DropDownList ID="ddlOffice" Class="form-control" AutoPostBack="True" runat="server"
                                            OnSelectedIndexChanged="ddlOffice_SelecttedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" ValidationGroup="Group2"
                                            runat="server" ControlToValidate="ddlOffice" ErrorMessage="Select Office" InitialValue="0"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>
                                        Department
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <asp:DropDownList ID="ddlDepartment" Class="form-control" AutoPostBack="True" runat="server"
                                            OnSelectedIndexChanged="ddlDepartment_SelecttedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" ValidationGroup="Group2"
                                            runat="server" ControlToValidate="ddlDepartment" ErrorMessage="Select Department"
                                            InitialValue="0"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>
                                        Section 
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <asp:DropDownList ID="ddlSection" Class="form-control" OnSelectedIndexChanged="ddlSection_SelecttedIndexChanged"
                                            AutoPostBack="True" runat="server">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" ValidationGroup="Group2"
                                            runat="server" ControlToValidate="ddlSection" ErrorMessage="Select Section" InitialValue="0"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>
                                        Sub-Section 
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <asp:DropDownList ID="ddlSubSections" Class="form-control" runat="server">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator19" ValidationGroup="Group2"
                                            runat="server" ControlToValidate="ddlSubSections" ErrorMessage="Select Sub-Section"
                                            InitialValue="0"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>
                                        Employee Category 
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <asp:DropDownList ID="drpEmployeeCate" Class="form-control" runat="server">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Group2"
                                            runat="server" ControlToValidate="drpEmployeeCate" ErrorMessage="Select Employee Category"
                                            InitialValue="0"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>
                                        Employee Type 
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <asp:DropDownList ID="drpEmployeeType" Class="form-control" runat="server">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Group2"
                                            runat="server" ControlToValidate="drpEmployeeType" ErrorMessage="Select Employee Type"
                                            InitialValue="0"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>


                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>
                                        Designation 
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <asp:DropDownList ID="ddlDesignations" Class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpStep_SelecttedIndexChanged" AppendDataBoundItems="True">
                                            <asp:ListItem Text="----- Select One ------ " Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator22" ValidationGroup="Group2"
                                            runat="server" ControlToValidate="ddlDesignations" ErrorMessage="Select Designation"
                                            InitialValue="0"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <%-- <div class="col-md-4 col-xs-4">
                                            <h4>
                                            Grade :
                                        </div>
                                        <div class="col-md-8 col-xs-12 table-content">
                                            <asp:DropDownList ID="ddlGrade" Width="100%" Class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlGrade_SelecttedIndexChanged">
                                            </asp:DropDownList>
                                          
                                        </div>--%>

                                    <div class="col-md-12">
                                        <div class="col-md-4 col-xs-4">
                                            <h4>Grade 
                                            </h4>
                                        </div>

                                        <div class="col-md-4">
                                            <asp:DropDownList ID="ddlGrade" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="ddlGrade_SelecttedIndexChanged" Class="form-control" runat="server">
                                            </asp:DropDownList>
                                            <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator21" ValidationGroup="Group2"
                                                    runat="server" ControlToValidate="ddlGrade" ErrorMessage="Select Grade" InitialValue="0"></asp:RequiredFieldValidator>--%>
                                        </div>
                                        <div class="col-md-4 col-xs-12 table-content">
                                            <asp:TextBox ID="txtbxGarde" Width="100%" Class="form-control" runat="server"></asp:TextBox>
                                        </div>


                                    </div>


                                </div>
                            </div>
                            <br />
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <%-- <div class="col-md-4 col-xs-4">
                                            <h4>
                                            Grade :
                                        </div>
                                        <div class="col-md-8 col-xs-12 table-content">
                                            <asp:DropDownList ID="ddlGrade" Width="100%" Class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlGrade_SelecttedIndexChanged">
                                            </asp:DropDownList>
                                          
                                        </div>--%>

                                    <div class="col-md-12">
                                        <div class="col-md-4 col-xs-4">
                                            <h4>Gross Salary
                                            </h4>
                                        </div>

                                        <div class="col-md-4">
                                            <asp:DropDownList ID="drpGrossSalary" Class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpGrossSalary_OnSelectedIndexChanged">
                                            </asp:DropDownList>

                                            <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator21" ValidationGroup="Group2"
                                                    runat="server" ControlToValidate="ddlGrade" ErrorMessage="Select Grade" InitialValue="0"></asp:RequiredFieldValidator>--%>
                                        </div>
                                        <div class="col-md-4 col-xs-12 table-content">
                                            <asp:TextBox ID="txtbxGrossSalary" Width="100%" Class="form-control" runat="server"></asp:TextBox>
                                        </div>


                                    </div>


                                </div>
                            </div>
                            <%--<div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>
                                        Gross Salary :
                                    </div>
                                    <div class="col-md-8 col-xs-12 table-content">
                                        <asp:DropDownList ID="drpGrossSalary" Width="100%" Class="form-control" runat="server">
                                            <asp:ListItem Text="----- Select One ------ " Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                      
                                    </div>
                                    
                                </div>
                            </div>--%>

                            <br />

                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>
                                        Shift Code 
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <asp:DropDownList ID="ddlShift" Class="form-control" runat="server" AppendDataBoundItems="True">
                                            <asp:ListItem Text="----- Select One ------ " Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator23" ValidationGroup="Group2"
                                            runat="server" ControlToValidate="ddlShift" ErrorMessage="Select Shift" InitialValue="0"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>
                                        OT Applicable
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <asp:DropDownList ID="drpdwnOTApplicable" Class="form-control" runat="server">
                                            <asp:ListItem Text="----- Select One ------ " Value="0"></asp:ListItem>
                                            <asp:ListItem Value="True">Yes</asp:ListItem>
                                            <asp:ListItem Value="False">No</asp:ListItem>
                                        </asp:DropDownList>

                                    </div>
                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>
                                        Absence Applicable
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <asp:DropDownList ID="drpAbsenceApplicable" Class="form-control" runat="server">
                                            <asp:ListItem Text="----- Select One ------ " Value="0"></asp:ListItem>
                                            <asp:ListItem Value="True">Yes</asp:ListItem>
                                            <asp:ListItem Value="False">No</asp:ListItem>
                                        </asp:DropDownList>

                                    </div>
                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>
                                        Attendance Bouns Applicable
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <asp:DropDownList ID="drpAttandenceApplicable" Class="form-control" runat="server">
                                            <asp:ListItem Text="----- Select One ------ " Value="0"></asp:ListItem>
                                            <asp:ListItem Value="True">Yes</asp:ListItem>
                                            <asp:ListItem Value="False">No</asp:ListItem>
                                        </asp:DropDownList>

                                    </div>
                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>
                                        Late Applicable 
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <asp:DropDownList ID="drpLateApplicable" Class="form-control" runat="server">
                                            <asp:ListItem Text="----- Select One ------ " Value="0"></asp:ListItem>
                                            <asp:ListItem Value="True">Yes</asp:ListItem>
                                            <asp:ListItem Value="False">No</asp:ListItem>
                                        </asp:DropDownList>

                                    </div>
                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>
                                        Tax Applicable 
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <asp:DropDownList ID="drpTaxApplicable" Class="form-control" runat="server">
                                            <asp:ListItem Text="----- Select One ------ " Value="0"></asp:ListItem>
                                            <asp:ListItem Value="True">Yes</asp:ListItem>
                                            <asp:ListItem Value="False">No</asp:ListItem>
                                        </asp:DropDownList>

                                    </div>
                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>
                                        PF Applicable
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <asp:DropDownList ID="drpPFApplicable" Class="form-control" runat="server">
                                            <asp:ListItem Text="----- Select One ------ " Value="0"></asp:ListItem>
                                            <asp:ListItem Value="True">Yes</asp:ListItem>
                                            <asp:ListItem Value="False">No</asp:ListItem>
                                        </asp:DropDownList>

                                    </div>
                                </div>
                            </div>


                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>Joining Date</h4>
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <p>
                                            <asp:TextBox ID="txtbxJoingDate" runat="server" class="form-control" OnTextChanged="txtbxJoiningDate_TextChanged" AutoPostBack="True"></asp:TextBox>
                                        </p>
                                        <asp:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtbxJoingDate"
                                            PopupButtonID="txtbxJoingDate" Format="MM/dd/yyyy" CssClass="ajax__calendar"
                                            Enabled="True" />

                                    </div>
                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>Probation Period From</h4>
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <p>
                                            <asp:TextBox ID="txtbxProbationProbationPeriodFrom" runat="server" class="form-control"></asp:TextBox>
                                        </p>
                                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtbxProbationProbationPeriodFrom"
                                            PopupButtonID="txtbxProbationProbationPeriodFrom" Format="MM/dd/yyyy" CssClass="ajax__calendar"
                                            Enabled="True" />

                                    </div>
                                </div>
                            </div>

                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>Probation Period TO</h4>
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <p>
                                            <asp:TextBox ID="txtbxProbationPeriodTo" runat="server" class="form-control"></asp:TextBox>
                                        </p>
                                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtbxProbationPeriodTo"
                                            PopupButtonID="txtbxProbationPeriodTo" Format="MM/dd/yyyy" CssClass="ajax__calendar"
                                            Enabled="True" />

                                    </div>
                                </div>
                            </div>

                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>Conformation Date </h4>
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <p>
                                            <asp:TextBox ID="txtbxConformationDate" runat="server" class="form-control"></asp:TextBox>
                                            <asp:TextBox ID="txtbxEffectiveSlary" runat="server" Class="form-control" Visible="false"></asp:TextBox>
                                        </p>
                                        <%--<asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtbxConformationDate"
                                                PopupButtonID="txtbxConformationDate" Format="MM/dd/yyyy" CssClass="ajax__calendar"
                                                Enabled="True" />--%>
                                    </div>
                                </div>
                            </div>
                           
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>Job Responsibility 
                                        </h4>
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <asp:TextBox ID="txtbxJobResponsibility" runat="server" Class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="submission">
                        <%-- <asp:Button ID="btnReset" runat="server" Text="Reset" Width="80px" CssClass="btn btn-info pull-right" />--%>
                        <div class="col-md-12">
                            <asp:Button ID="btnUpdate" runat="server" ValidationGroup="Group2" Text="Update"
                                Width="80px" CssClass="btn btn-info pull-right" OnClick="btnUpdate_click" Style="margin-right: 8px;" />
                        </div>
                    </div>
                </div>

            </asp:Panel>
            <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
            <asp:ModalPopupExtender ID="ModalPopupExtender" runat="server" TargetControlID="LinkButton1"
                PopupControlID="Panel1" BackgroundCssClass="modalBackground" CancelControlID="CancelButton"
                DropShadow="True" PopupDragHandleControlID="Panel3" Enabled="True" />

            <div id="Div1">
                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Region
                            </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblRegion" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Office 
                            </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblOffice" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Department 
                            </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblDepartment" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Section
                            </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblSection" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Sub-Section
                            </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblSubSction" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Employee Type
                            </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblEmployeeType" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>
                            Employee Category
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblCategoryName" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Designation 
                            </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblDesignation" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Grade 
                            </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblGrade" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>

                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Gross Salary 
                            </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblGossSalary" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Shift
                            </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblShit" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>OT Applicable
                            </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblOtApplicable" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Attendance Bouns Applicable
                            </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblAttendanceApplicable" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Late Applicable 
                            </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblLateApplicable" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Absence Applicable
                            </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblAbsenceApplicable" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Tax Applicable 
                            </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblTaxApplicable" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>PF Applicable
                            </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblPFApplicable" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Joining Date 
                            </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblJoiningDate" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Probation Period From
                            </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblProbationPeriodFrom" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Probation Period To 
                            </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblProbationPeriodTo" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>

                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Comfirmation Date 
                            </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblConfirmationDate" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Effective Slary
                            </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblEffectiveSlary" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Job Resposibility
                            </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblJobResposibility" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>

                <%-- <div class="row tab-data">
        <div class="container-fluid tab-container">
            <div class="col-md-4 col-xs-4">
                <h4>
                    Reporting Boss:
                </h4>
            </div>
            <div class="col-md-8 col-xs-8 table-content">
                <p>
                    <asp:Label ID="lblReportingBoss" runat="server" Text=""></asp:Label>
                </p>
            </div>
        </div>
    </div>--%>
            </div>

        </div>

        <div>
            <div class="tab-header">
                Bank Information
    <asp:Button ID="Button1s" runat="server" Text="Add" CssClass="btn btn-default pull-right tab-button"
        OnClick="BtnBankInfo_Click" />
            </div>
            <asp:Panel ID="Panel7" runat="server" Style="display: none" CssClass="modalPopupFreight">
                <div>
                    <asp:Label ID="lblBankMessage" runat="server" Font-Bold="true"></asp:Label>
                    <div class="modal-dialog">
                        <asp:Panel ID="Panel8" runat="server">
                            <div class="popuHeader">
                                <asp:LinkButton ID="LinkButton6" runat="server">
                                    <button type="button"  style="color:white" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                </asp:LinkButton>
                                <h4 id="H3">Bank Information</h4>
                            </div>

                        </asp:Panel>


                        <div id="Div7">
                            <div class="row tab-data" style="padding-top: 7px;">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>
                                        Bank Name 
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <asp:TextBox ID="txtbxBankName" runat="server" Class="form-control"></asp:TextBox>

                                    </div>

                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>
                                        A/C Number
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <asp:TextBox ID="txtbxAc" runat="server" Class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>
                                        Branch
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <asp:TextBox ID="txtbxBranch" runat="server" Class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>
                                        Address 
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <asp:TextBox ID="txtbxAddress" runat="server" Class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>
                                        Mobile No
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <asp:TextBox ID="txtbxMobileNO" runat="server" Class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                    <div class="col-md-4 col-xs-4">
                                        <h4>
                                        Mobile Bank Name 
                                    </div>
                                    <div class="col-md-8 col-xs-8 table-content">
                                        <asp:TextBox ID="txbxMobileBankName" runat="server" Class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row tab-data">
                                <div class="container-fluid tab-container">
                                   
                                    <div class="col-md-10 col-xs-8">
                                        <asp:Button ID="btnBankUpdate" runat="server" Text="Submit" Width="80px" CssClass="btn btn-info pull-right" OnClick="btnBanck_Update" />
                                </div> 
                                     <div class="col-md-2 col-xs-4">
                                                <asp:Button ID="btnBankDel" runat="server" Text="Delete" OnClick="btnBankDel_Click" OnClientClick="return ConfirmDelete();" CssClass="btn btn-danger pull-right" />                                         
                                        </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </asp:Panel>
            <asp:LinkButton ID="LinkButton7" runat="server"></asp:LinkButton>
            <asp:ModalPopupExtender ID="ModalPopupExtender3" runat="server" TargetControlID="LinkButton7"
                PopupControlID="Panel7" BackgroundCssClass="modalBackground" CancelControlID="LinkButton6"
                DropShadow="True" PopupDragHandleControlID="Panel8" Enabled="True" />

            <div id="Div8">
                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Bank Name
                            </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblBankName" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>A/C No
                            </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblAccountNumber" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Branch 
                            </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblBranch" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Address
                            </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Mobile No
                            </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblMobileNo" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="row tab-data">
                    <div class="container-fluid tab-container">
                        <div class="col-md-4 col-xs-4">
                            <h4>Mobile Bank Name
                            </h4>
                        </div>
                        <div class="col-md-8 col-xs-8 table-content">
                            <p>
                                <asp:Label ID="lblMoboleBankName" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </ContentTemplate>
</asp:UpdatePanel>
<script>
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
</script>
