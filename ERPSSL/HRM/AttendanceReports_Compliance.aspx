<%@ Page Title="" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true" CodeBehind="AttendanceReports_Compliance.aspx.cs" Inherits="ERPSSL.HRM.AttendanceReports_Compliance" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                        <i class="fa fa-edit fa-fw icon-padding"></i>Attendance Reports
                    </div>

                    <div class="col-md-12">
                        <div class="col-md-6">
                            <fieldset>
                                <legend style="line-height: 5px;"><span style="background: #fff">Select for Search</span></legend>
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
                                                <asp:DropDownList ID="ddlRegion1" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="drpdwnResion1ForDepartmentSelecttedIndexChanged"
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

                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <div class="col-md-6">
                                        <div class="row">
                                            <h5 style="padding-left: 20px;">Office
                                            </h5>
                                            <div class="col-md-12">
                                                <asp:DropDownList ID="ddlOffice1" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="onSelectedIndedexChangeOffice1"
                                                    runat="server">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="row">
                                            <h5 style="padding-left: 20px;">Sub-Section
                                            </h5>
                                            <div class="col-md-12">
                                                <asp:DropDownList ID="ddlSubSections" AutoPostBack="True" CssClass="form-control"
                                                    runat="server" OnSelectedIndexChanged="ddlSubSections_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlSubSections"
                                                    Display="Dynamic" ForeColor="Red" Font-Size="11px" SetFocusOnError="True" ErrorMessage="Select a Sub-Section"
                                                    ValidationGroup="Group1"></asp:RequiredFieldValidator>
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
                                                <asp:DropDownList ID="ddlDept1" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="drpdwnDepartment1SelectedIndexChange"
                                                    runat="server">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="row" style="padding-right: 0;">

                                            <h5 style="padding-left: 20px;">Absent Day</h5>
                                            <div class="col-md-6" style="padding-top: 3px;">
                                                <asp:TextBox ID="txtAbsentDay" Class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-md-6" style="padding-top: 3px; margin-left:-9px;">
                                                <asp:Button ID="btnAttProcess" runat="server" Text="Preview" CssClass="btn btn-info" OnClick="btnAttProcess_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </fieldset>

                            <fieldset>
                                <legend style="line-height: 5px;"><span style="background: #fff">Select Employee</span></legend>
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

                            <div class="col-md-12" style="margin-top: 0px; padding-bottom: 10px; padding-left: 0px">

                                <asp:Button ID="btnProcess1" runat="server" Text="View Report" Width="167px"
                                    CssClass="btn btn-info  pull-right" OnClick="btnProcess1_Click" />


                            </div>
                        </div>
                        <div class="col-md-6 ">
                            <div class="row radio_input00">
                                <fieldset>
                                    <legend style="line-height: 5px;"><span style="background: #fff">Daily Report</span></legend>
                                    <div style="padding-top: 0px">
                                        <asp:RadioButton ID="rdbDailyAttendance" runat="server" Text="Attendance Report" GroupName="rpt_Attend" Checked="true" />
                                        <br />
                                        <asp:RadioButton ID="rdbDailyAbsentReport" runat="server" Text="Absent Report" GroupName="rpt_Attend" />
                                        <br />
                                        <asp:RadioButton ID="rdbDailyLateReport" runat="server" Text="Late Report" GroupName="rpt_Attend" />
                                        <br />
                                        <asp:RadioButton ID="rdbDailyAttendanceSummary" runat="server" Text="Attendance Summary" GroupName="rpt_Attend" />
                                        <br />
                                        <asp:RadioButton ID="rdbDailyAttendanceSummaryByDesignation" runat="server" Text="Attendance Summary(Designation wise)" GroupName="rpt_Attend" />
                                        <br />
                                        <asp:RadioButton ID="rdbDailySinglePunchList" runat="server" Text="Single Punch List" GroupName="rpt_Attend" />
                                        <br />
                                        <asp:RadioButton ID="rdbAllLeave" runat="server" Text="Today Leave Report" GroupName="rpt_Attend" />
                                        <br />
                                        <asp:RadioButton ID="rdbAllOTList" runat="server" Visible="false" Text="Overtime Report" GroupName="rpt_Attend" />
                                    </div>
                                </fieldset>
                                <fieldset>
                                    <legend style="line-height: 5px;"><span style="background: #fff">Monthly Report</span></legend>
                                    <div style="padding-top: 0px">
                                        <asp:RadioButton ID="rdbMonthlyAttendance" runat="server" Text="Attendance Report" GroupName="rpt_Attend" />
                                        <br />
                                        <asp:RadioButton ID="rdbMonthlyPresent" runat="server" Text="Present Report" GroupName="rpt_Attend" />
                                        <br />
                                        <asp:RadioButton ID="rdbMonthlyAbsent" runat="server" Text="Absent Report/Long Absent List" GroupName="rpt_Attend" />
                                        <br />
                                        <asp:RadioButton ID="rdbMonthlyLate" runat="server" Text="Late Report" GroupName="rpt_Attend" Visible="false" />

                                        <asp:RadioButton ID="rdbMonthlyAttendanceSummary" runat="server" Text="Attendance Summary" GroupName="rpt_Attend" />
                                        <br />
                                        <asp:RadioButton ID="rdbMonthlyOvertimeList" runat="server" Text="Overtime Report" GroupName="rpt_Attend" />
                                        <asp:RadioButton ID="rdbMonthlyOvertimeSummary" runat="server" Text="Overtime Summary" GroupName="rpt_Attend" Visible="false"/>
                                        <br />
                                        <asp:RadioButton ID="rdbMonthlyAttendanceEmpwise" runat="server" Text="Employee wise Attendance" GroupName="rpt_Attend"/>
                                        <br />
                                        <asp:RadioButton ID="rdbMonthlyAllAttendance" runat="server" Text="All Attendance Report" GroupName="rpt_Attend" />
                                        <br />
                                    </div>
                                </fieldset>
                                <%-- <fieldset>
                                    <legend style="line-height: 5px;"><span style="background: #fff">Job Card Wise</span></legend>
                                    <div style="padding-top: 10px">
                                        <asp:RadioButton ID="rdbEmpwiseAll" runat="server" Text="Attendance Report" GroupName="rpt_Attend" />
                                        <br />
                                        <asp:RadioButton ID="rdIndividualByStatus" runat="server" Text="Absent Report" GroupName="rpt_Attend" />
                                        <br />
                                        <asp:RadioButton ID="rdbAllEmpStatuswise" runat="server" Text="Late Report" GroupName="rpt_Attend" />
                                    </div>
                                </fieldset>--%>
                            </div>

                        </div>
                    </div>
                </div>

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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
