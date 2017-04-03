<%@ Page Title="" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="ERPSSL.HRM.Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
    <style type="text/css">
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
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdWaitImage" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="UpdatePanel8">
                <ProgressTemplate>
                    <div class="LoaderBackground_">
                        <asp:Image ID="Image1" runat="server" CssClass="LoaderBackground_Image" ImageUrl="../content/image/busy.gif" />
                    </div>

                </ProgressTemplate>
            </asp:UpdateProgress>

            <asp:HiddenField ID="hdnUserID" runat="server" />
            <div class="hm_sec_2_content scrollbar">
                <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="fa fa-edit fa-fw icon-padding"></i>All Reports
                    </div>
                    <div class="col-md-12 bg-success">
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                    </div>
                </div>
                <div>
                    <div class="col-md-12">
                        <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" Width="100%" OnDemand="true"
                            childrenastriggers="True" CssClass="ajax__myTab" ActiveTabIndex="0">

                            <ajaxToolkit:TabPanel runat="server" HeaderText="Employee Report" ID="TabPanel1"
                                OnDemandMode="None">
                                <%-- Employee Report--%>
                                <ContentTemplate>
                                    <div class="row" style="padding-left: 0px;">
                                        <div class="col-md-6" style="padding-left: 0px; padding-right: 0px;">
                                            <div class="col-md-12" style="padding-left: 0px;">
                                                <fieldset>
                                                    <legend style="line-height: 5px;"><span style="background: #fff">Select for Search</span></legend>
                                                    <div class="col-md-12" style="padding-left: 0px;">
                                                        <div class="col-md-6" style="padding-left: 0px;">
                                                            <div class="row">
                                                                <h5 style="padding-left: 20px;">Region
                                                                </h5>
                                                                <div class="col-md-12">
                                                                    <asp:DropDownList ID="ddlRegions" AutoPostBack="True" OnSelectedIndexChanged="drpdwnResionForDepartmentSelecttedIndexChanged" CssClass="form-control"
                                                                        runat="server">
                                                                    </asp:DropDownList>

                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6" style="padding-left: 0px;">

                                                            <div class="row">
                                                                <h5 style="padding-left: 20px;">Date From
                                                                </h5>
                                                                <div class="col-md-12">
                                                                    <asp:TextBox Class="form-control" runat="server" ID="txtDateFrom" autocomplete="off"
                                                                        placeholder="MM/dd/yyyy"></asp:TextBox>

                                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtDateFrom"
                                                                        PopupButtonID="Image_AT" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                                                </div>

                                                            </div>

                                                        </div>
                                                    </div>
                                                    <div class="col-md-12" style="padding-left: 0px;">
                                                        <div class="col-md-6" style="padding-left: 0px;">

                                                            <div class="row">
                                                                <h5 style="padding-left: 20px;">Office
                                                                </h5>
                                                                <div class="col-md-12">
                                                                    <asp:DropDownList ID="drpOffice" AutoPostBack="True" OnSelectedIndexChanged="onSelectedIndedexChangeOffice" CssClass="form-control"
                                                                        runat="server">
                                                                    </asp:DropDownList>
                                                                </div>

                                                            </div>
                                                        </div>
                                                        <div class="col-md-6" style="padding-left: 0px;">

                                                            <div class="row">
                                                                <h5 style="padding-left: 20px;">Date To                                                                </h5>
                                                                <div class="col-md-12">
                                                                    <asp:TextBox Class="form-control" runat="server" ID="txtbxToDate" autocomplete="off"
                                                                        placeholder="MM/dd/yyyy"></asp:TextBox>

                                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtbxToDate"
                                                                        PopupButtonID="Image_AT" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                                                </div>

                                                            </div>

                                                        </div>
                                                    </div>
                                                    <div class="col-md-12" style="padding-left: 0px;">
                                                        <div class="col-md-6" style="padding-left: 0px;">
                                                            <div class="row" style="padding-left: 0px;">
                                                                <h5 style="padding-left: 20px;">Department
                                                                </h5>
                                                                <div class="col-md-12">
                                                                    <asp:DropDownList ID="depDepartment" AutoPostBack="True" OnSelectedIndexChanged="drpdwnDepartmentSelectedIndexChange" CssClass="form-control"
                                                                        runat="server">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>


                                                            <div class="row" style="padding-left: 0px;">
                                                                <h5 style="padding-left: 20px;">Section
                                                                </h5>
                                                                <div class="col-md-12">
                                                                    <asp:DropDownList ID="drpSection" CssClass="form-control"
                                                                        runat="server">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>



                                                        </div>
                                                        <div class="col-md-6">


                                                            <div class="row" style="padding-left: 0px;">
                                                                <h5>Designation</h5>
                                                                <div class="col-md-12" style="padding-left: 0px;">
                                                                    <asp:DropDownList ID="ddldesignation" CssClass="form-control"
                                                                        runat="server">
                                                                    </asp:DropDownList>
                                                                </div>

                                                            </div>
                                                            <div class="row" style="padding-left: 0px;">
                                                                <h5>Blood Group
                                                                </h5>
                                                                <div class="col-md-12" style="padding-left: 0px;">
                                                                    <asp:DropDownList ID="ddlBloodGrp" Class="form-control" runat="server" CssClass="form-control">
                                                                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                                        <asp:ListItem Value="0">Not Available</asp:ListItem>
                                                                        <asp:ListItem Value="1">O+</asp:ListItem>
                                                                        <asp:ListItem Value="2">O-</asp:ListItem>
                                                                        <asp:ListItem Value="3">A+</asp:ListItem>
                                                                        <asp:ListItem Value="4">A-</asp:ListItem>
                                                                        <asp:ListItem Value="5">B+</asp:ListItem>
                                                                        <asp:ListItem Value="6">B-</asp:ListItem>
                                                                        <asp:ListItem Value="7">AB+</asp:ListItem>
                                                                        <asp:ListItem Value="8">AB-</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ValidationGroup="GroupPersonalInfo"
                                                                        runat="server" ControlToValidate="ddlBloodGrp" ErrorMessage="Select Blood Group"
                                                                        InitialValue="0"></asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>


                                                </fieldset>

                                            </div>

                                            <div class="col-md-12" style="padding-left: 0px;">
                                                <fieldset>
                                                    <legend style="line-height: 5px;"><span style="background: #fff">Salary Range Wise Search</span></legend>
                                                    <div class="col-md-12" style="padding-left: 0px;">
                                                        <div class="col-md-6" style="padding-left: 0px;">
                                                            <div class="row">
                                                                <h5 style="padding-left: 20px;">Salary From
                                                                </h5>
                                                                <div class="col-md-12">
                                                                    <asp:TextBox ID="txtSalaryFrom" Class="form-control" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6" style="padding-left: 0px;">
                                                            <div class="row">
                                                                <h5 style="padding-left: 20px;">Salary To</h5>
                                                                <div class="col-md-12">
                                                                    <asp:TextBox ID="txtSalaryTo" Class="form-control" runat="server"></asp:TextBox>
                                                                </div>

                                                            </div>
                                                        </div>
                                                    </div>

                                                </fieldset>

                                            </div>
                                            <div class="col-md-12" style="padding-left: 0px;">
                                                <fieldset>
                                                    <legend style="line-height: 5px;"><span style="background: #fff">Select Employee</span></legend>
                                                    <div class="col-md-12" style="padding-left: 0px;">
                                                        <div class="col-md-6" style="padding-left: 0px;">
                                                            <div class="row" style="padding-left: 0px;">
                                                                <h5 style="padding-left: 20px;">E-ID
                                                                </h5>
                                                                <div class="col-md-12">
                                                                    <asp:Label ID="lblHiddenId" runat="server" Visible="False"></asp:Label>
                                                                    <asp:TextBox ID="txtEid_AT" Class="form-control" runat="server" AutoPostBack="True" OnTextChanged="txtEid_AT_TextChanged"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6" style="padding-left: 0px;">
                                                            <div class="row">
                                                                <h5 style="padding-left: 20px;">Name
                                                                </h5>
                                                                <div class="col-md-12">
                                                                    <asp:TextBox ID="txtEmpName_AT" Class="form-control" AutoPostBack="True" runat="server" Enabled="False"></asp:TextBox>
                                                                </div>

                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12" style="padding-left: 0px;">
                                                        <div class="col-md-6" style="padding-left: 0px;">
                                                            <div class="row">
                                                                <h5 style="padding-left: 20px;">Department
                                                                </h5>
                                                                <div class="col-md-12">
                                                                    <asp:TextBox ID="txtDepartment_AT" Class="form-control" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6" style="padding-left: 0px;">
                                                            <div class="row">
                                                                <h5 style="padding-left: 20px;">Designation
                                                                </h5>
                                                                <div class="col-md-12">
                                                                    <asp:TextBox ID="txtDesignation_AT" Class="form-control" runat="server" Enabled="False"></asp:TextBox>
                                                                </div>

                                                            </div>
                                                        </div>
                                                    </div>

                                                </fieldset>

                                            </div>
                                            <div class="col-md-12" style="">


                                                <asp:Button ID="btnProcess" runat="server" Text="View Report" Width="113px" OnClick="btnProcess_Click"
                                                    CssClass="btn btn-info  pull-right" />
                                                <%--      OnClientClick="window.open('Report_Viewer.aspx','mywindow')"--%>
                                            </div>
                                        </div>
                                        <div class="col-md-6" style="padding-left: 0px;">
                                            <div class="col-md-12" style="padding-left: 0px;">

                                                <div class="row radio_input00">
                                                    <fieldset>
                                                        <legend style="line-height: 5px;"><span style="background: #fff">Employee Report</span></legend>
                                                        <div style="padding-top: 0px">

                                                            <asp:RadioButton ID="rdAllEmployee" runat="server" Text="All Employee" GroupName="rpt_emp" Checked="True" /><br />
                                                            <asp:RadioButton ID="rdCurrentEmoloyee" runat="server" Text="Current Employee" GroupName="rpt_emp" /><br />
                                                            <asp:RadioButton ID="rdEmployee" runat="server" Text="Employee Report" GroupName="rpt_emp" /><br />
                                                            <asp:RadioButton ID="rdCurrentEmoloyeeShiftwise" runat="server" Text="Shift Wise Current Employee" GroupName="rpt_emp" Visible="False" />
                                                            <asp:RadioButton ID="rjoiningNewEmployee" runat="server" Text="Joining Date Wise Employee" GroupName="rpt_emp" /><br />

                                                            <asp:RadioButton ID="rdleftEmployee" runat="server" Text="Left Date Wise Employee" GroupName="rpt_emp" /><br />

                                                            <asp:RadioButton ID="rdMale" runat="server" Text="Male Employee" GroupName="rpt_emp" /><br />
                                                            <asp:RadioButton ID="rdFemale" runat="server" Text="Female Employee" GroupName="rpt_emp" /><br />
                                                            <asp:RadioButton ID="rdbdesignation" runat="server" Text="Designation Wise Employee" GroupName="rpt_emp" /><br />
                                                            <asp:RadioButton ID="rdbbankaccount" runat="server" Text="Bank Account Wise Employee" GroupName="rpt_emp" /><br />
                                                            <asp:RadioButton ID="rdEmpInfo" runat="server" Text="Employee Contact  Wise Report" GroupName="rpt_emp" /><br />
                                                            <asp:RadioButton ID="rdbAllbloodGroup" runat="server" Text="All Blood Group Report" GroupName="rpt_emp" /><br />
                                                            <asp:RadioButton ID="rdBloodWiseEmployee" runat="server" Text="Department Wise Blood Group" GroupName="rpt_emp" Visible="False" />
                                                            <asp:RadioButton ID="rdAllBlood" runat="server" Text="Blood Group Wise Employee" GroupName="rpt_emp" /><br />

                                                            <asp:RadioButton ID="rdManagement" runat="server" Text="Management Employee Report" GroupName="rpt_emp" /><br />
                                                            <asp:RadioButton ID="rdNonManagement" runat="server" Text="Non-Management Employee Report" GroupName="rpt_emp" /><br />
                                                            <asp:RadioButton ID="rdChildCount" runat="server" Text="Employee Children Counting" GroupName="rpt_emp" /><br />
                                                            <asp:RadioButton ID="rdChildList" runat="server" Text="Employee 18+ Children List" GroupName="rpt_emp" /><br />
                                                            <asp:RadioButton ID="rdIndividual" runat="server" Text="Employee Personal Profile" GroupName="rpt_emp" /><br />
                                                            <asp:RadioButton ID="rdlEmplyeeSalary" runat="server" Text="Employee Salary" GroupName="rpt_emp" /><br />

                                                        </div>
                                                    </fieldset>
                                                    <fieldset>
                                                        <legend style="line-height: 5px;"><span style="background: #fff">Employee Separation Report</span></legend>
                                                        <div style="padding-top: 0px">
                                                            <asp:RadioButton ID="rdSeperationEmployee" runat="server" Text="All Seperation Employee" GroupName="rpt_emp" /><br />
                                                            <asp:RadioButton ID="rdTerminatedEmployee" runat="server" Text="Terminated Employee" GroupName="rpt_emp" /><br />
                                                            <asp:RadioButton ID="rdretired" runat="server" Text="Retired Employee" GroupName="rpt_emp" /><br />
                                                            <asp:RadioButton ID="rdresignation" runat="server" Text="Resigned Employee" GroupName="rpt_emp" /><br />
                                                            <asp:RadioButton ID="rdbEMPDismissalStatus" runat="server" Text="Dismissal Employee" GroupName="rpt_emp" /><br />
                                                            <asp:RadioButton ID="rdbEMPDiedStatus" runat="server" Text="Died Employee" GroupName="rpt_emp" /><br />
                                                            <asp:RadioButton ID="rdbEMPDisContinutionStatus" runat="server" Text="Discontinous Employee" GroupName="rpt_emp" /><br />

                                                        </div>
                                                    </fieldset>
                                                    <fieldset>
                                                        <legend style="line-height: 5px;"><span style="background: #fff">Administration Report</span></legend>
                                                        <div style="padding-top: 0px">
                                                            <asp:RadioButton ID="rdTransferEmployee" runat="server" Text="Transfer Employee" GroupName="rpt_emp" /><br />
                                                            <asp:RadioButton ID="rdbLenghtofservices" runat="server" Text="Length Of Service" GroupName="rpt_emp" /><br />
                                                            <asp:RadioButton ID="rdbRetredage" runat="server" Text="Retirement Based On 25 Years Of Service" GroupName="rpt_emp" /><br />
                                                            <asp:RadioButton ID="rdbRetieredforRegion" runat="server" Text="Retirement Based On 60 Years Of Age" GroupName="rpt_emp" /><br />
                                                            <asp:RadioButton ID="rdbTurnOveremp" runat="server" Text="All Employee Turn Over Report" GroupName="rpt_emp" />

                                                            <asp:RadioButton ID="rdbRetieredforOffice" runat="server" Text="Retirement Age Report For Office" GroupName="rpt_emp" Visible="False" />
                                                            <asp:RadioButton ID="rdbRetieredforDept" runat="server" Text="Retirement Age Report For Dept." GroupName="rpt_emp" Visible="False" />
                                                        </div>
                                                    </fieldset>
                                                </div>




                                            </div>
                                        </div>
                                    </div>


                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>
                            <%--  Attendance report--%>
                            <%--<ajaxToolkit:TabPanel runat="server" HeaderText="Attendence Report" ID="TabPanel2"
                                OnDemandMode="None">
                                <ContentTemplate>
                                    <div class="col-md-12">
                                        <div class="col-md-6">
                                            <fieldset style="border: none">
                                                <div class="col-md-12">
                                                    <div class="col-md-2" style="font-size: 13px">
                                                        Status
                                                    </div>
                                                    <div class="col-md-10 radio_input">
                                                        <asp:RadioButton ID="rdbPresent" runat="server" Text="Present" GroupName="ATN" Checked="True" ForeColor="#003300" />&nbsp
                    <asp:RadioButton ID="rdbLate" runat="server" Text="Late" GroupName="ATN" ForeColor="#339933" />&nbsp
                 
                                                        <asp:RadioButton ID="rdbAbsent" runat="server" Text="Absent" GroupName="ATN" ForeColor="Red" />&nbsp
                    <asp:RadioButton ID="rdbAll" runat="server" Text="All" GroupName="ATN" />
                                                    </div>
                                                </div>
                                            </fieldset>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="col-md-6">
                                            <fieldset>
                                                <legend><span style="background: #fff">Select for Search</span></legend>
                                                <div class="col-md-12">
                                                    <div class="col-md-6">
                                                        <div class="row">
                                                            <h5 style="padding-left: 20px;">From
                                                            </h5>
                                                            <div class="col-md-12">
                                                                <asp:TextBox runat="server" ID="txtbxFrom" Class="form-control" placeholder="MM/dd/yyyy" />
                                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtbxFrom"
                                                                    PopupButtonID="txtbxFrom" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <div class="row">
                                                            <h5 style="padding-left: 20px;">To
                                                            </h5>
                                                            <div class="col-md-12">
                                                                <asp:TextBox runat="server" ID="txtbxTo" Class="form-control" placeholder="MM/dd/yyyy" />
                                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtbxTo"
                                                                    PopupButtonID="txtbxTo" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                                            </div>

                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-12">
                                                    <div class="col-md-6">
                                                        <div class="row">
                                                            <h5 style="padding-left: 20px;">Region
                                                            </h5>
                                                            <div class="col-md-12">
                                                                <asp:DropDownList ID="ddlRegion1" AutoPostBack="True" OnSelectedIndexChanged="drpdwnResion1ForDepartmentSelecttedIndexChanged" CssClass="form-control"
                                                                    runat="server">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <div class="row">
                                                            <h5 style="padding-left: 20px;">Office
                                                            </h5>
                                                            <div class="col-md-12">
                                                                <asp:DropDownList ID="ddlOffice1" AutoPostBack="True" OnSelectedIndexChanged="onSelectedIndedexChangeOffice1" CssClass="form-control"
                                                                    runat="server">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-12">
                                                    <div class="col-md-6">
                                                        <div class="row">
                                                            <h5 style="padding-left: 20px;">Department
                                                            </h5>
                                                            <div class="col-md-12">
                                                                <asp:DropDownList ID="ddlDept1" AutoPostBack="True" OnSelectedIndexChanged="drpdwnDepartment1SelectedIndexChange" CssClass="form-control"
                                                                    runat="server">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <div class="row">
                                                            <h5 style="padding-left: 20px;">Shift Code
                                                            </h5>
                                                            <div class="col-md-12">
                                                                <asp:DropDownList ID="ddlShiftCode" AutoPostBack="True" CssClass="form-control"
                                                                    runat="server" OnSelectedIndexChanged="ddlShiftCode_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlShiftCode"
                                                                    Display="Dynamic" ForeColor="Red" Font-Size="11px" SetFocusOnError="True" ErrorMessage="Select a Shift Code"
                                                                    ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                            </fieldset>
                                            <br />
                                            <fieldset>
                                                <legend><span style="background: #fff">Select Employee</span></legend>
                                                <div class="col-md-12">
                                                    <div class="col-md-6">
                                                        <div class="row">
                                                            <h5 style="padding-left: 20px;">E-ID
                                                            </h5>
                                                            <div class="col-md-12">
                                                                <asp:TextBox ID="txtEid1_AT" Class="form-control" runat="server" AutoPostBack="True" OnTextChanged="txtEid1_AT_TextChanged"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <div class="row">
                                                            <h5 style="padding-left: 20px;">Department
                                                            </h5>
                                                            <div class="col-md-12">
                                                                <asp:TextBox ID="dept1TextBox" Class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-12">

                                                    <div class="col-md-6">
                                                        <div class="row">
                                                            <h5 style="padding-left: 20px;">Name
                                                            </h5>
                                                            <div class="col-md-12">
                                                                <asp:TextBox ID="name1TextBox" Class="form-control" AutoPostBack="true" runat="server" Enabled="False"></asp:TextBox>
                                                            </div>

                                                        </div>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <div class="row">
                                                            <h5 style="padding-left: 20px;">Designation
                                                            </h5>
                                                            <div class="col-md-12">
                                                                <asp:TextBox ID="design1TextBox" Class="form-control" runat="server" Enabled="False"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </fieldset>
                                            <br />
                                            <div class="col-md-12" style="margin-top: 0px; margin-left: 0px; padding-left: 0;">
                                                <asp:Button ID="btnProcess1" runat="server" Text="Process" Width="80px" OnClick="btnProcess1_Click"
                                                    CssClass="btn btn-info  pull-right" />
                                            </div>
                                        </div>
                                        <div class="col-md-6 ">
                                            <div class="row radio_input00">
                                                <fieldset>
                                                    <legend><span style="background: #fff">Daily Report</span></legend>
                                                    <div style="padding-top: 10px">

                                                        <asp:RadioButton ID="rdbAllEmpByRegion" runat="server" Text="Region Wise Attendance Report" GroupName="rpt_Attend" Checked="true" />
                                                        <br />
                                                        <asp:RadioButton ID="rdbAllEmpOfficeWise" runat="server" Text="Office Wise Attendance Report" GroupName="rpt_Attend" />
                                                        <br />
                                                        <asp:RadioButton ID="rdbAllEmpDeptWise" runat="server" Text="Dept. Wise Attendance Report" GroupName="rpt_Attend" />
                                                        <br />
                                                        <asp:RadioButton ID="rdbAllEmp" runat="server" Text="All Attendance Report" GroupName="rpt_Attend" />



                                                    </div>
                                                </fieldset>
                                                <fieldset>
                                                    <legend><span style="background: #fff">Monthly Report</span></legend>
                                                    <div style="padding-top: 10px">
                                                        <asp:RadioButton ID="rdbEmpPresentRegWise" runat="server" Text="Region Wise Present Report " GroupName="rpt_Attend" />
                                                        <br />
                                                        <asp:RadioButton ID="rdbEmpOfficeWise" runat="server" Text="Office Wise Present Report" GroupName="rpt_Attend" />
                                                        <br />
                                                        <asp:RadioButton ID="rdbEmpDeptWise" runat="server" Text="Dept Wise Present Report" GroupName="rpt_Attend" />
                                                        <br />
                                                        <asp:RadioButton ID="rdbEmpPresent" runat="server" Text="All Present Report" GroupName="rpt_Attend" />
                                                        <br />


                                                        <asp:RadioButton ID="rdRegAbsRpt" runat="server" Text="Region Wise Absent Report" GroupName="rpt_Attend" />
                                                        <br />
                                                        <asp:RadioButton ID="rdRegAbsRptOffice" runat="server" Text="Office Wise Absent Report" GroupName="rpt_Attend" />

                                                        <asp:RadioButton ID="rdRegAbsRptDeptWise" runat="server" Text="Dept. Wise Absent Report" GroupName="rpt_Attend" Visible="false" />

                                                        <asp:RadioButton ID="rdbEmpAbsent" runat="server" Text="Absent Report(All)" GroupName="rpt_Attend" Visible="false" />
                                                        <br />


                                                        <asp:RadioButton ID="rdRegLateRpt" runat="server" Text="Region Wise Late Report" GroupName="rpt_Attend" />
                                                        <br />
                                                        <asp:RadioButton ID="rdRegLateRptOfficeWise" runat="server" Text="Office Wise Late Report" GroupName="rpt_Attend" />
                                                        <br />
                                                        <asp:RadioButton ID="rdRegLateRptDeptWise" runat="server" Text="Dept. Wise Late Report" GroupName="rpt_Attend" />
                                                        <br />
                                                        <asp:RadioButton ID="rdAllEmpLate" runat="server" Text="Late Report(All)" GroupName="rpt_Attend" Visible="false" />

                                                        <asp:RadioButton ID="rdbAllEmpStatuswise" runat="server" Text="All Employee Attendance(By Status)" GroupName="rpt_Attend" />

                                                    </div>
                                                </fieldset>
                                                <fieldset>
                                                    <legend><span style="background: #fff">Job Card Report</span></legend>
                                                    <div style="padding-top: 10px">
                                                        <asp:RadioButton ID="rdbEmpwiseAll" runat="server" Text="Employee Wise Job Card Report(All)" GroupName="rpt_Attend" />
                                                        <br />
                                                        <asp:RadioButton ID="rdIndividualByStatus" runat="server" Text="Employee Wise Report(By Status)" GroupName="rpt_Attend" />



                                                        <asp:RadioButton ID="rdOffice" runat="server" Text="Office Wise Attendance Report" GroupName="rpt_Attend" Visible="false" />

                                                        <asp:RadioButton ID="rdDepartment" runat="server" Text="Department Wise Report" GroupName="rpt_Attend" Visible="false" />

                                                        <asp:RadioButton ID="rdShiftCode" runat="server" Text="Shift Wise Report" GroupName="rpt_Attend" Visible="false" />

                                                        <asp:RadioButton ID="rdbAllEmpRegionWise" runat="server" Text="All Employee Attendance Region Wise" GroupName="rpt_Attend" Visible="false" />

                                                        <asp:RadioButton ID="rdAllRegion" runat="server" Text="All Region Attendance Report" GroupName="rpt_Attend" Visible="false" />

                                                        <asp:RadioButton ID="rdRegion" runat="server" Text="Region Wise Attendance Report" GroupName="rpt_Attend" Visible="false" />

                                                        <asp:RadioButton ID="rdbAllEmpAtt" runat="server" Text="All Employee Attendance" GroupName="rpt_Attend" Visible="false" />
                                                    </div>
                                                </fieldset>
                                            </div>

                                        </div>
                                    </div>

                                    <div class="col-md-12">
                                        <div class="col-md-6">
                                            <br />
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>--%>


                            <%-- Leave --%>
                            <ajaxToolkit:TabPanel runat="server" HeaderText="Leave Report" ID="TabPanel3"
                                OnDemandMode="None">
                                <ContentTemplate>

                                    <div class="row" style="padding-left: 0px;">
                                        <div class="col-md-6" style="padding-left: 0px; padding-right: 0px;">
                                            <div class="col-md-12" style="padding-left: 0px;">
                                                <fieldset>
                                                    <legend style="line-height: 5px;"><span style="background: #fff">Select for Search</span></legend>
                                                    <div class="col-md-12" style="padding-left: 0px;">
                                                        <div class="col-md-6" style="padding-left: 0px;">
                                                            <div class="row">
                                                                <h5 style="padding-left: 20px;">Region
                                                                </h5>
                                                                <div class="col-md-12">
                                                                    <asp:DropDownList ID="ddlregion2" AutoPostBack="True" OnSelectedIndexChanged="drpdwnResion2ForDepartmentSelecttedIndexChanged" CssClass="form-control"
                                                                        runat="server">
                                                                    </asp:DropDownList>

                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6" style="padding-left: 0px;">

                                                            <div class="row">
                                                                <h5 style="padding-left: 20px;">Date From
                                                                </h5>
                                                                <div class="col-md-12">
                                                                    <asp:TextBox Class="form-control" runat="server" ID="txtDateFrom1" autocomplete="off"
                                                                        placeholder="MM/dd/yyyy"></asp:TextBox>

                                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtDateFrom1"
                                                                        PopupButtonID="Image_AT" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                                                </div>

                                                            </div>

                                                        </div>
                                                    </div>
                                                    <div class="col-md-12" style="padding-left: 0px;">
                                                        <div class="col-md-6" style="padding-left: 0px;">

                                                            <div class="row">
                                                                <h5 style="padding-left: 20px;">Office
                                                                </h5>
                                                                <div class="col-md-12">
                                                                    <asp:DropDownList ID="ddlOffice2" AutoPostBack="True" OnSelectedIndexChanged="onSelectedIndedexChangeOffice2" CssClass="form-control"
                                                                        runat="server">
                                                                    </asp:DropDownList>
                                                                </div>

                                                            </div>
                                                        </div>
                                                        <div class="col-md-6" style="padding-left: 0px;">

                                                            <div class="row">
                                                                <h5 style="padding-left: 20px;">Date To
                                                                </h5>
                                                                <div class="col-md-12">
                                                                    <asp:TextBox Class="form-control" runat="server" ID="txtDateTo1" autocomplete="off"
                                                                        placeholder="MM/dd/yyyy"></asp:TextBox>

                                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txtDateTo1"
                                                                        PopupButtonID="Image_AT" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                                                </div>

                                                            </div>

                                                        </div>
                                                    </div>
                                                    <div class="col-md-12" style="padding-left: 0px;">
                                                        <div class="col-md-6" style="padding-left: 0px;">
                                                            <div class="row">
                                                                <h5 style="padding-left: 20px;">Department
                                                                </h5>
                                                                <div class="col-md-12">
                                                                    <asp:DropDownList ID="ddlDept2" AutoPostBack="True" OnSelectedIndexChanged="drpdwnDepartment2SelectedIndexChange" CssClass="form-control"
                                                                        runat="server">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>

                                                        </div>
                                                        <div class="col-md-6" style="padding-left: 0px;">

                                                            <div class="row">
                                                                <h5 style="padding-left: 20px;">&nbsp;</h5>
                                                                <div class="col-md-12" style="padding-top: 20px;">
                                                                    <asp:Button ID="Button1" runat="server" Text="Process" Width="80px" OnClick="btnProcess2_Click"
                                                                        CssClass="btn btn-info  pull-right" />
                                                                </div>

                                                            </div>
                                                        </div>


                                                    </div>


                                                </fieldset>

                                            </div>

                                            <div class="col-md-12" style="padding-left: 0px;">
                                                <fieldset>
                                                    <legend style="line-height: 5px;"><span style="background: #fff">Select Employee</span></legend>
                                                    <div class="col-md-12" style="padding-left: 0px;">
                                                        <div class="col-md-6" style="padding-left: 0px;">
                                                            <div class="row" style="padding-left: 0px;">
                                                                <h5 style="padding-left: 20px;">E-ID
                                                                </h5>
                                                                <div class="col-md-12">
                                                                    <asp:Label ID="Label3" runat="server" Visible="False"></asp:Label>
                                                                    <asp:TextBox ID="txtEid2_AT" Class="form-control" runat="server" AutoPostBack="True" OnTextChanged="txtEid2_AT_TextChanged"></asp:TextBox>

                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6" style="padding-left: 0px;">
                                                            <div class="row">
                                                                <h5 style="padding-left: 20px;">Name
                                                                </h5>
                                                                <div class="col-md-12">
                                                                    <asp:TextBox ID="nameTextBox2" Class="form-control" AutoPostBack="True" runat="server" Enabled="False"></asp:TextBox>
                                                                </div>

                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12" style="padding-left: 0px;">
                                                        <div class="col-md-6" style="padding-left: 0px;">
                                                            <div class="row">
                                                                <h5 style="padding-left: 20px;">Department
                                                                </h5>
                                                                <div class="col-md-12">
                                                                    <asp:TextBox ID="deptTextBox2" Class="form-control" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6" style="padding-left: 0px;">
                                                            <div class="row">
                                                                <h5 style="padding-left: 20px;">Designation
                                                                </h5>
                                                                <div class="col-md-12">
                                                                    <asp:TextBox ID="desigTextBox2" Class="form-control" runat="server" Enabled="False"></asp:TextBox>
                                                                </div>

                                                            </div>
                                                        </div>
                                                    </div>

                                                </fieldset>

                                            </div>
                                            <div class="col-md-12" style="padding-right: 60px;">

                                                <asp:Button ID="btnProcess2" runat="server" Text="Process" Width="80px" OnClick="btnProcess2_Click"
                                                    CssClass="btn btn-info  pull-right" />
                                            </div>
                                        </div>
                                        <div class="col-md-6" style="padding-left: 0px;">
                                            <div class="col-md-12" style="padding-left: 0px;">

                                                <div class="row radio_input00">
                                                    <fieldset>
                                                        <legend style="line-height: 5px;"><span style="background: #fff">Select  Report Type</span></legend>
                                                        <div style="padding-top: 0px">
                                                            <asp:RadioButton ID="rdbAllEmployeeLeaveSummery" runat="server" Text="All Employee Leave Summery" GroupName="rpt_emp" /><br />
                                                            <asp:RadioButton ID="rdbAllemployeeleave" runat="server" Text="All Employee Leave" GroupName="rpt_emp" /><br />
                                                            <asp:RadioButton ID="rdbMaleEmployeewiseleave" runat="server" Text="Male Employee Id Wise Leave" GroupName="rpt_emp" Visible="False" />
                                                            <asp:RadioButton ID="rdbFemaleEmplyeeleave" runat="server" Text="Female Employee Id Wise Leave" GroupName="rpt_emp" Visible="False" />
                                                            <asp:RadioButton ID="btnEmployeeWiseLeave" runat="server" Text="Individual Leave" GroupName="rpt_emp" /><br />
                                                            <asp:RadioButton ID="rdbEmployeeWiseLeaveStatment" runat="server" Text="Individual Leave Statment" GroupName="rpt_emp" />


                                                        </div>
                                                    </fieldset>

                                                </div>




                                            </div>
                                        </div>
                                    </div>







                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>
                        </ajaxToolkit:TabContainer>
                    </div>

                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <script type="text/javascript">

        function func(result) {
            if (result === 'Data Save Successfully') {
                toastr.success(result);

            }

            else
                toastr.error(result);

            return false;
        }

    </script>


</asp:Content>
