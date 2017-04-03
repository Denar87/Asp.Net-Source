<%@ Page Title="" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true" CodeBehind="Attendance_RPT.aspx.cs" Inherits="ERPSSL.HRM.Attendance_RPT" %>

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
            <div class="row">
                <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="fa fa-edit fa-fw icon-padding"></i>Attendance Reports
                    </div>
                    <div class="col-md-12 bg-success">
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                    </div>
                </div>

                <div class="hm_sec_2_content scrollbar">
                    <div class="col-md-12">
                        <div class="col-md-6">
                            <fieldset style="border: none">
                                <div class="col-md-12">
                                    <div class="col-md-2">
                                        Status
                                    </div>
                                    <div class="col-md-10">
                                        <asp:RadioButton ID="rdbPresent" runat="server" Text="Present" GroupName="ATN" Checked="True" ForeColor="#003300" />&nbsp
                    <asp:RadioButton ID="rdbLate" runat="server" Text="Late" GroupName="ATN" ForeColor="#339933" />&nbsp
                    <asp:RadioButton ID="rdbOverLate" runat="server" Text="Over Late" GroupName="ATN" ForeColor="#0099CC" />&nbsp
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
                                <legend style="line-height: 0;"><span style="background: #fff">Select for Search</span></legend>
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
                                    </div>
                                    <div class="col-md-6">
                                        <div class="row">
                                            <h5 style="padding-left: 20px">Office
                                            </h5>
                                            <div class="col-md-12">
                                                <asp:DropDownList ID="drpOffice" AutoPostBack="True" OnSelectedIndexChanged="onSelectedIndedexChangeOffice" CssClass="form-control"
                                                    runat="server">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <div class="col-md-6">
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
                                    </div>
                                </div>

                            </fieldset>
                            <br />
                            <fieldset>
                                <legend style="line-height: 0;"><span style="background: #fff">Select Employee</span></legend>
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
                            <div class="col-md-12" style="margin-top: 8px;">
                                <div class="col-md-6">
                                </div>
                                <div class="col-md-6">
                                    <div class="col-md-4">
                                    </div>
                                    <div class="col-md-8">
                                        <asp:Button ID="btnProcess" runat="server" Text="Process" Width="80px" OnClick="btnProcess_Click"
                                            CssClass="btn btn-info pull-right" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">

                            <fieldset>
                                <legend style="line-height: 0;"><span style="background: #fff">Report Type</span></legend>
                                <div style="padding-top: 10px">

                                    <asp:RadioButton ID="rdAllRegion" runat="server" Text="All Region Attendance Report" GroupName="rpt_Attend" Checked="True" />
                                    <br />
                                    <asp:RadioButton ID="rdRegion" runat="server" Text="Region Wise Attendance Report" GroupName="rpt_Attend" />
                                    <br />
                                    <asp:RadioButton ID="rdOffice" runat="server" Text="Office Wise Attendance Report" GroupName="rpt_Attend" />
                                    <br />
                                    <asp:RadioButton ID="rdDepartment" runat="server" Text="Department Wise Report" GroupName="rpt_Attend" />
                                    <br />
                                    <asp:RadioButton ID="rdShiftCode" runat="server" Text="Shift Wise Report" GroupName="rpt_Attend" />
                                    <br />
                                    <asp:RadioButton ID="rdbAllEmpStatuswise" runat="server" Text="Employee Attendance(By Status)" GroupName="rpt_Attend" />
                                    <br />
                                    <asp:RadioButton ID="rdbAllEmp" runat="server" Text="All Employee Attendance(All)" GroupName="rpt_Attend" />
                                    <br />
                                    <asp:RadioButton ID="rdbEmpAbsent" runat="server" Text="Monthly Absent Report" GroupName="rpt_Attend" />
                                    <br />
                                    <asp:RadioButton ID="rdAllEmpLate" runat="server" Text="Monthly Late Report" GroupName="rpt_Attend" />
                                    <br />
                                    <asp:RadioButton ID="rdIndividual" runat="server" Text="Employee Wise Report(By Status)" GroupName="rpt_Attend" />
                                    <br />
                                    <asp:RadioButton ID="rdbEmpwiseAll" runat="server" Text="Employee Wise Report(All)" GroupName="rpt_Attend" />
                                    <br />
                                </div>
                            </fieldset>
                        </div>
                    </div>

                    <div class="col-md-12">
                        <div class="col-md-6">
                            <br />
                        </div>
                    </div>

                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
