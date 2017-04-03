<%@ Page Title="Attendance" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true"
    CodeBehind="UpdateAttendanceStatus.aspx.cs" Inherits="ERPSSL.HRM.UpdateAttendanceStatus" %>

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
            <div class="row">

                <div class="hm_sec_2_content scrollbar">
                    <div class="panel">
                        <div class="panel-heading panel-heading-01">
                            <i class="fa fa-edit fa-fw icon-padding"></i>Update Employee Attendance Status
                        </div>

                    </div>
                    <div class="col-md-12 bg-success scrollbar">
                        <center>
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Text=""></asp:Label></center>
                    </div>
                    <fieldset style="border: none">
                        <div class="col-md-12">
                            <div class="col-md-6">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            Shift<span style="color: #f00;">*</span>
                                        </div>
                                        <div class="col-md-8">
                                            <asp:DropDownList ID="ddlShiftCode" AutoPostBack="True" CssClass="form-control"
                                                runat="server" OnSelectedIndexChanged="ddlShiftCode_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlShiftCode"
                                                Display="Dynamic" ForeColor="Red" Font-Size="11px" SetFocusOnError="True" ErrorMessage="Select a Shift"
                                                ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            Date From<span style="color: #f00;">*</span>
                                        </div>
                                        <div class="col-md-8">
                                            <asp:TextBox Class="form-control" runat="server" ID="txtDateFrom" autocomplete="off" AutoPostBack="true"
                                                placeholder="MM/dd/yyyy" OnTextChanged="txtDateFrom_TextChanged"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDateFrom"
                                                Display="Dynamic" ErrorMessage="Select From Date" ForeColor="Red" SetFocusOnError="True" Font-Size="11px"
                                                ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDateFrom"
                                                Display="Dynamic" ErrorMessage="Select From Date" ForeColor="Red" SetFocusOnError="True" Font-Size="11px"
                                                ValidationGroup="Group3"></asp:RequiredFieldValidator>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDateFrom"
                                                PopupButtonID="Image_AT" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            Date To<span style="color: #f00;">*</span>
                                        </div>
                                        <div class="col-md-8">
                                            <asp:TextBox Class="form-control" runat="server" ID="txtDateTo" autocomplete="off" AutoPostBack="true"
                                                placeholder="MM/dd/yyyy" OnTextChanged="txtDateTo_TextChanged"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtDateTo"
                                                Display="Dynamic" ErrorMessage="Select To Date" ForeColor="Red" SetFocusOnError="True" Font-Size="11px"
                                                ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDateTo"
                                                Display="Dynamic" ErrorMessage="Select To Date" ForeColor="Red" SetFocusOnError="True" Font-Size="11px"
                                                ValidationGroup="Group3"></asp:RequiredFieldValidator>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDateTo"
                                                PopupButtonID="Image_AT" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                        </div>
                                    </div>
                                </div>
                                <br />

                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                        </div>
                                        <div class="col-md-2">
                                            <asp:Button ID="btnUpdate" runat="server" Text="Update" class="btn btn-info" ValidationGroup="Group1" OnClick="btnUpdate_Click" />
                                        </div>
                                        <div class="col-md-5">
                                            <asp:Button ID="btnUpdateAll" runat="server" Text="Update All" class="btn btn-primary" ValidationGroup="Group3" OnClick="btnUpdateAll_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </fieldset>

                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">

        function func(result) {
            if (result === 'Employee Attendance Status Updated Successfully') {
                toastr.success(result);

            }
            else
                toastr.error(result);

            return false;
        }

    </script>
</asp:Content>
