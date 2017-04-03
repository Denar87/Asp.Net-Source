<%@ Page Title="Attendance" Language="C#" MasterPageFile="~/PAYROLL/Site.Master" AutoEventWireup="true"
    CodeBehind="Attendance_OTperiodic_Calculation_Report.aspx.cs" Inherits="ERPSSL.PAYROLL.Attendance_OTperiodic_Calculation_Report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .time_section input {
            width: 27px !important;
            height: auto !important;
            text-align: center;
            border: none !important;
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
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <script src="content/js/bootstrap-datetimepicker.js" type="text/javascript"></script>
    <link href="content/css/bootstrap-datetimepicker.min.css" rel="stylesheet" type="text/css" />
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
                                <i class="fa fa-edit fa-fw icon-padding"></i>Attendance & O.T Register
                            </div>
                            <div class="col-md-12 bg-success">
                                <asp:Label ID="lblMessage" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-6">
                                    <fieldset>
                                        <legend style="line-height: 5px;"><span style="background: #fff">Select for Search</span></legend>

                                        <div class="col-md-12">

                                            <div class="row">
                                                <div class="col-md-3">
                                                    Region
                                                </div>
                                                <div class="col-md-9">
                                                    <asp:DropDownList ID="ddlRegion1" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="drpdwnResion1ForDepartmentSelecttedIndexChanged"
                                                        runat="server">
                                                    </asp:DropDownList>
                                                    <br />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12">
                                            <div class="row">
                                                <div class="col-md-3">
                                                    Office
                                                </div>
                                                <div class="col-md-9">
                                                    <asp:DropDownList ID="ddlOffice1" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="onSelectedIndedexChangeOffice1"
                                                        runat="server">
                                                    </asp:DropDownList>
                                                    <br />
                                                </div>
                                            </div>

                                        </div>
                                        <div class="col-md-12">

                                            <div class="row">
                                                <div class="col-md-3">
                                                    Department
                                                </div>
                                                <div class="col-md-9">
                                                    <asp:DropDownList ID="ddlDept1" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="drpdwnDepartment1SelectedIndexChange"
                                                        runat="server">
                                                    </asp:DropDownList>
                                                    <br />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12">
                                            <div class="row">
                                                <div class="col-md-3">
                                                    Section
                                                </div>
                                                <div class="col-md-9">
                                                    <asp:DropDownList ID="ddlSection" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="ddlSection_SelecttedIndexChanged"
                                                        runat="server">
                                                    </asp:DropDownList>
                                                    <br />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12">
                                            <div class="row">
                                                <div class="col-md-3">
                                                    Sub-Section
                                                </div>
                                                <div class="col-md-9">
                                                    <asp:DropDownList ID="ddlSubSections" AutoPostBack="True" CssClass="form-control"
                                                        runat="server" OnSelectedIndexChanged="ddlSubSections_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlSubSections"
                                                Display="Dynamic" ForeColor="Red" Font-Size="11px" SetFocusOnError="True" ErrorMessage="Select a Sub-Section"
                                                ValidationGroup="Group1"></asp:RequiredFieldValidator>--%>
                                                    <br />
                                                </div>
                                            </div>
                                        </div>

                                    </fieldset>
                                </div>
                                <div class="col-md-6">
                                    <fieldset>
                                        <legend style="line-height: 5px;"><span style="background: #fff">Attendance & O.T Register </span></legend>
                                        <div class="col-md-12">

                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="col-md-3">
                                                        Date From
                                                    </div>
                                                    <div class="col-md-9">
                                                        <asp:TextBox Class="form-control" runat="server" ID="txtDateFrom" autocomplete="off" AutoPostBack="true"
                                                            placeholder="MM/dd/yyyy"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDateFrom"
                                                            Display="Dynamic" ErrorMessage="Select From Date" ForeColor="Red" SetFocusOnError="True" Font-Size="11px"
                                                            ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDateFrom"
                                                            PopupButtonID="Image_AT" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="col-md-3">
                                                        Date To
                                                    </div>
                                                    <div class="col-md-9">
                                                        <asp:TextBox Class="form-control" runat="server" ID="txtDateTo" autocomplete="off" AutoPostBack="true"
                                                            placeholder="MM/dd/yyyy"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDateTo"
                                                            Display="Dynamic" ErrorMessage="Select To Date" ForeColor="Red" SetFocusOnError="True" Font-Size="11px"
                                                            ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDateTo"
                                                            PopupButtonID="Image_AT" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                                    </div>
                                                </div>
                                            </div>
                                            <br />

                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="col-md-3">
                                                    </div>
                                                    <div class="col-md-9">

                                                        <asp:Button ID="btnUpdate" runat="server" Text="Process-1" class="btn btn-info" ValidationGroup="Group1" OnClick="btnUpdate_Click" />
                                                        <asp:Button ID="btnUpdate2" runat="server"  Text="Process-2" class="btn btn-info" ValidationGroup="Group1" OnClick="btnUpdate2_Click" />
                                                        <asp:Button ID="btnReport" runat="server" Text="Preview" class="btn btn-primary" ValidationGroup="Group1" OnClick="btnReport_Click" />

                                                    </div>
                                                    <%-- <div class="col-md-5">
                                    <asp:Button ID="btnReport" runat="server" Text="Print" class="btn btn-primary" ValidationGroup="Group1"/>
                                </div>--%>
                                                </div>
                                            </div>
                                            <br />
                                        </div>


                                    </fieldset>
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnUpdate" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnUpdate2" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnReport" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>

    <script type="text/javascript">

        function func(result) {
            if (result === 'Data Processed Successfully') {
                toastr.success(result);
            }
            else
                toastr.error(result);

            return false;
        }

    </script>
</asp:Content>
