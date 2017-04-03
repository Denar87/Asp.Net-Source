<%@ Page Title="" Language="C#" MasterPageFile="~/PAYROLL/Site.Master" AutoEventWireup="true" CodeBehind="Payroll_RPT.aspx.cs" Inherits="ERPSSL.PAYROLL.Payroll_RPT" %>

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
            <div class="hm_sec_2_content scrollbar">
                <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="fa fa-edit fa-fw icon-padding"></i>Payroll Reports
                    </div>
                    <div class="col-md-12 bg-success">
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                    </div>
                </div>

                <div class="row">

                    <div class="col-md-12">
                        <div class="col-md-6">
                            <fieldset>
                                <legend style="line-height: 5px;"><span style="background: #fff">Select for Search</span></legend>
                                <div class="col-md-12">
                                    <div class="col-md-6">
                                        <div class="row">
                                            <h5 style="padding-left: 20px">From
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
                                            <h5 style="padding-left: 20px">To
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
                                            <h5 style="padding-left: 20px">Region
                                            </h5>
                                            <div class="col-md-12">
                                                <asp:DropDownList ID="ddlRegions" AutoPostBack="True" OnSelectedIndexChanged="drpdwnResionForDepartmentSelecttedIndexChanged" CssClass="form-control"
                                                    runat="server">
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <h5 style="padding-left: 20px">Office
                                            </h5>
                                            <div class="col-md-12">
                                                <asp:DropDownList ID="drpOffice" AutoPostBack="True" OnSelectedIndexChanged="onSelectedIndedexChangeOffice" CssClass="form-control"
                                                    runat="server">
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <h5 style="padding-left: 20px">Department
                                            </h5>
                                            <div class="col-md-12">
                                                <asp:DropDownList ID="depDepartment" AutoPostBack="True" OnSelectedIndexChanged="drpdwnDepartmentSelectedIndexChange" CssClass="form-control"
                                                    runat="server">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="row">
                                            <h5 style="padding-left: 20px;">Section
                                            </h5>
                                            <div class="col-md-12">
                                                <asp:DropDownList ID="ddlSection" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="ddlSection_SelecttedIndexChanged"
                                                    runat="server">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <h5 style="padding-left: 20px;">Sub-Section
                                            </h5>
                                            <div class="col-md-12">
                                                <asp:DropDownList ID="ddlSubSections" CssClass="form-control"
                                                    runat="server">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlSubSections"
                                                    Display="Dynamic" ForeColor="Red" Font-Size="11px" SetFocusOnError="True" ErrorMessage="Select a Sub-Section"
                                                    ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <h5 style="padding-left: 20px;">OT(hrs)
                                            </h5>
                                            <div class="col-md-4">
                                                <asp:TextBox runat="server" Style="width: 140%; padding-left: -30px;" ID="txtOTHour" Class="form-control" />
                                            </div>
                                            <div class="col-md-8">
                                                <asp:Button ID="btnProcess" runat="server" Text="View Report" OnClick="btnProcess_Click"
                                                    CssClass="btn btn-info pull right" />
                                            </div>


                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <div class="col-md-6">
                                    </div>
                                    <%-- <div class="col-md-6">
                                        <div class="row">
                                            <h5 style="padding-left: 20px">Shift Code
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
                                    </div>--%>
                                </div>

                            </fieldset>

                            <fieldset>
                                <legend style="line-height: 5px;"><span style="background: #fff">Select Employee</span></legend>
                                <div class="col-md-12">
                                    <div class="col-md-6">
                                        <div class="row">
                                            <h5 style="padding-left: 20px">E-ID
                                            </h5>
                                            <div class="col-md-12">
                                                <asp:TextBox ID="txtEid_AT" Class="form-control" runat="server" AutoPostBack="True" OnTextChanged="txtEid_AT_TextChanged"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="row">
                                            <h5 style="padding-left: 20px">Department
                                            </h5>
                                            <div class="col-md-12">
                                                <asp:TextBox ID="txtDepartment_AT" Class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12">

                                    <div class="col-md-6">
                                        <div class="row">
                                            <h5 style="padding-left: 20px">Name
                                            </h5>
                                            <div class="col-md-12">
                                                <asp:TextBox ID="txtEmpName_AT" Class="form-control" AutoPostBack="true" runat="server" Enabled="False"></asp:TextBox>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="row">
                                            <h5 style="padding-left: 20px">Designation
                                            </h5>
                                            <div class="col-md-12">
                                                <asp:TextBox ID="txtDesignation_AT" Class="form-control" runat="server" Enabled="False"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </fieldset>

                            <div class="col-md-12">
                                <div class="col-md-6">
                                </div>
                                <div class="col-md-6" style="padding-right: 36px">
                                    <asp:Button ID="Button1" runat="server" Text="View Report" OnClick="btnProcess_Click"
                                        CssClass="btn btn-info pull right" />
                                </div>

                            </div>
                        </div>

                        <div class="col-md-6">
                            <fieldset>
                                <legend style="line-height: 5px;"><span style="background: #fff">Report Type</span></legend>
                                <div style="padding-top: 0px">
                                    <%-- <asp:RadioButton ID="rdAttendanceOTRegister" runat="server" Text="Attendance & O.T Register" GroupName="rpt_Attend" Checked="true" />
                            <br />
                            <asp:RadioButton ID="rdAllOTHourCal" runat="server" Text="Monthly OT Report" GroupName="rpt_Attend" />
                            <br />
                            <%--<asp:RadioButton ID="rdbEmpwiseOT" runat="server" Text="Individual Wise OT" GroupName="rpt_Attend" />
                            <br />
                            <asp:RadioButton ID="rdOfficeWiseOT" runat="server" Text="Region Wise OT Report" GroupName="rpt_Attend" />
                            <br />--%>
                                    <asp:RadioButton ID="rdSalaryandOTSheet" Checked="true" runat="server" Text="Salary & OT Sheet" GroupName="rpt_Attend" />
                                    <br />
                                    <asp:RadioButton ID="rdSalaryandOTSheet_ByCash" runat="server" Text="Salary & OT (Cash)" GroupName="rpt_Attend" />
                                    <br />
                                    <asp:RadioButton ID="rdSalaryandOTSheet_ByBank" runat="server" Text="Salary & OT (Bank)" GroupName="rpt_Attend" />
                                    <br />
                                    <asp:RadioButton ID="rdSalaryandOTSheet_ByMobile" runat="server" Text="Salary & OT (Mobile Bank)" GroupName="rpt_Attend" />
                                    <br />
                                    <asp:RadioButton ID="rdSalaryandOTCompliance" runat="server" Text="Salary & OT Compliance" GroupName="rpt_Attend" Visible="false"/>    
                                    <asp:RadioButton ID="rdSalaryandOTSheetByCash" runat="server" Text="Salary & OT Compliance (Cash)" GroupName="rpt_Attend" Visible="false"/>
                                    <asp:RadioButton ID="rdSalaryandOTSheetByBank" runat="server" Text="Salary & OT Compliance (Bank)" GroupName="rpt_Attend" Visible="false"/>
                                    <asp:RadioButton ID="rdSalaryandOTSheetByMobileBank" runat="server" Text="Salary & OT Compliance (Mobile Bank)" GroupName="rpt_Attend" Visible="false"/>
                                    <%--<br />--%>
                                    <asp:RadioButton ID="rdSalaryWithStamp" runat="server" Text="Salary Sheet With Stamp" GroupName="rpt_Attend" />
                                    <br />
                                    <asp:RadioButton ID="rdSalarySheet" runat="server" Text="Salary Sheet" GroupName="rpt_Attend" />
                                    <br />
                                    <asp:RadioButton ID="rdSalaryTopSheet" runat="server" Text="Salary Top Sheet" GroupName="rpt_Attend" />
                                    <br />
                                    <asp:RadioButton ID="rdSalaryTopSheetByCash" runat="server" Text="Salary Top Sheet (Cash)" GroupName="rpt_Attend" />
                                    <br />
                                    <asp:RadioButton ID="rdSalaryTopSheetByBank" runat="server" Text="Salary Top Sheet (Bank)" GroupName="rpt_Attend" />
                                    <br />
                                    <asp:RadioButton ID="rdSalaryTopSheetByMobileBank" runat="server" Text="Salary Top Sheet (Mobile Bank)" GroupName="rpt_Attend" />
                                    <br />

                                    <asp:RadioButton ID="rdOtSheet" runat="server" Text="OT Sheet" GroupName="rpt_Attend" />
                                    <br />
                                    <asp:RadioButton ID="rdOTSheetByHour" runat="server" Text="OT Sheet Hour Wise" GroupName="rpt_Attend" />
                                    <br />
                                    <asp:RadioButton ID="rdEmpWiseBenefit" runat="server" Text="Employee Wise Benefit" GroupName="rpt_Attend" />
                                    <br />
                                    <asp:RadioButton ID="rdAllEmpBenefit" runat="server" Text="All Employee Benefit" GroupName="rpt_Attend" />
                                    <br />
                                    <asp:RadioButton ID="rdbAllEmpBenifitOfficeWise" runat="server" Text="All Employee Benefit Office Wise" GroupName="rpt_Attend" />
                                    <br />
                                    <asp:RadioButton ID="rdbAllEmpBenifitDeptWise" runat="server" Text="All Employee Benefit Department Wise" GroupName="rpt_Attend" />
                                    <br />
                                    <asp:RadioButton ID="rdSalAdvList" runat="server" Text="Employee Wise Salary Advanced List" GroupName="rpt_Attend" />
                                    <br />
                                    <asp:RadioButton ID="rdAllSalAdvList" runat="server" Text="All Salary Advanced List" GroupName="rpt_Attend" />
                                    <br />
                                    <asp:RadioButton ID="rdAllSalAdvListOfficeWise" runat="server" Text="All Salary Advanced List Office Wise" GroupName="rpt_Attend" />
                                    <br />
                                    <asp:RadioButton ID="rdAllSalAdvListDeptWise" runat="server" Text="All Salary Advanced List Department Wise" GroupName="rpt_Attend" />
                                    <br />
                                    <asp:RadioButton ID="rdSalary" runat="server" Text="Dept. Wise Salary Info" GroupName="rpt_Attend" />
                                    <br />
                                    <asp:RadioButton ID="rdAllSalary" runat="server" Text="All Employee Salary Info" GroupName="rpt_Attend" />
                                    <br />
                                    <asp:RadioButton ID="rdtaxCalculation" runat="server" Text="Tax Details Employee Wise" GroupName="rpt_Attend" />
                                    <br />
                                    <asp:RadioButton ID="rdbMobileBank" runat="server" Text="Mobile Bank Advice(Salary)" GroupName="rpt_Attend" />
                                    <br />
                                    <asp:RadioButton ID="rdbBankAdvice" runat="server" Text="Bank Advice(Salary)" GroupName="rpt_Attend" />
                                    <br />
                                    <asp:RadioButton ID="rdbCashSalary" runat="server" Text="Cash Salary" GroupName="rpt_Attend" />

                                </div>
                            </fieldset>


                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <script type="text/javascript">

        function func(result) {
            if (result === 'Salary processed successfully') {
                toastr.success(result);
            }
            else if (result === 'Salary proccessed temporarily') {
                toastr.success(result);
            }
            else {
                toastr.error(result);
            }
            return false;
        }

    </script>





</asp:Content>
