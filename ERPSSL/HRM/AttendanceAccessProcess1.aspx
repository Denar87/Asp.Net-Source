<%@ Page Title="" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true" CodeBehind="AttendanceAccessProcess1.aspx.cs" Inherits="ERPSSL.HRM.AttendanceAccessProcess1" %>

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
                        <i class="glyphicon glyphicon-edit icon-padding"></i>Access DB Process
                    </div>
                </div>

                <div class="row" style="margin: 8px auto;">

                    <fieldset style="border: 1px skyblue solid">
                        <div class="col-md-12" style="margin-top: 0px">

                            <div class="col-md-12 bg-success">
                                <asp:Label ID="lblMessage" runat="server"></asp:Label>
                            </div>

                            <div class="row">
                                <div class="col-md-12" style="margin-top: -10px">

                                    <div class="col-md-1">
                                        Date<span style="color: #f00;">*</span>
                                    </div>
                                    <div class="col-md-2">
                                        <asp:TextBox runat="server" ID="txtbxFromDate" Class="form-control" placeholder="MM/dd/yyyy" />
                                        <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtbxFromDate"
                                            PopupButtonID="txtbxFromDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtbxFromDate"
                                            Display="Dynamic" ErrorMessage="Select Date" ForeColor="Red" SetFocusOnError="True" Font-Size="11px"
                                            ValidationGroup="Group5"></asp:RequiredFieldValidator>
                                    </div>

                                    <%--<div class="col-md-3">
                            <asp:TextBox runat="server" ID="txtbxFromDate" Class="form-control" placeholder="Date" />
                            <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtbxFromDate"
                                PopupButtonID="txtbxFromDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                        </div>--%>
                                    <%--<div class="col-md-1" style="margin-top: 10px; margin-right: -50px; font-weight: bold">to</div>--%>
                                    <%-- <div class="col-md-3">
                            <asp:TextBox runat="server" ID="txtbxToDate" Class="form-control" placeholder="To Date" />
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtbxToDate"
                                PopupButtonID="txtbxToDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />

                        </div>--%>
                                    <div class="col-md-1">
                                        <asp:Button ID="btnAttendanceProcess" runat="server" Text="Process" CssClass="btn btn-primary" OnClick="btnAttendanceProcess_Click" ValidationGroup="Group5" />
                                    </div>
                                    <div class="col-md-1">
                                        <asp:Button ID="btnCOnf" runat="server" Text="Confirm" CssClass="btn btn-info" OnClick="btnCOnf_Click" ValidationGroup="Group5" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </fieldset>
                </div>

                <%--<fieldset style="border: none">--%>
                <div class="row" style="margin: 0 auto">
                    <div class="col-md-6">
                        <div class="panel" style="border: 1px skyblue solid">
                            <div class="panel-heading panel-heading-01">
                                <i class="glyphicon glyphicon-edit icon-padding"></i>Attendance Status Process
                            </div>
                            <br />

                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                        Shift<span style="color: #f00;">*</span>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddlShiftCode" CssClass="form-control"
                                            runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                        Date<span style="color: #f00;">*</span>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:TextBox Class="form-control" runat="server" ID="txtDateFrom" autocomplete="off"
                                            placeholder="MM/dd/yyyy"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDateFrom"
                                            Display="Dynamic" ErrorMessage="Select Date" ForeColor="Red" SetFocusOnError="True" Font-Size="11px"
                                            ValidationGroup="Group1"></asp:RequiredFieldValidator>

                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDateFrom"
                                            PopupButtonID="Image_AT" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                    </div>
                                </div>
                            </div>
                            <br />

                            <%-- <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            Date To<span style="color: #f00;">*</span>
                                        </div>
                                        <div class="col-md-8">
                                            <asp:TextBox Class="form-control" runat="server" ID="txtDateTo" autocomplete="off"
                                                placeholder="MM/dd/yyyy"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDateTo"
                                                Display="Dynamic" ErrorMessage="Select To Date" ForeColor="Red" SetFocusOnError="True" Font-Size="11px"
                                                ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtDateTo"
                                                Display="Dynamic" ErrorMessage="Select To Date" ForeColor="Red" SetFocusOnError="True" Font-Size="11px"
                                                ValidationGroup="Group3"></asp:RequiredFieldValidator>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtDateTo"
                                                PopupButtonID="Image_AT" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                        </div>
                                    </div>
                                </div>
                                <br />--%>

                            <div class="row" style="margin-bottom: 10px">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                    </div>
                                    <div class="col-md-2">
                                        <asp:Button ID="btnUpdateStatus" runat="server" Text="Update" class="btn btn-info" ValidationGroup="Group1" OnClick="btnUpdateStatus_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="panel" style="border: 1px skyblue solid">
                            <div class="panel-heading panel-heading-01"><i class="glyphicon glyphicon-edit icon-padding"></i>OT Proccess</div>
                            <br />

                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                        Date From<span style="color: #f00;">*</span>
                                    </div>
                                    <div class="col-md-7">
                                        <asp:TextBox Class="form-control" runat="server" ID="txtOTFrom" AutoPostBack="true"
                                            placeholder="MM/dd/yyyy" OnTextChanged="txtOTFrom_TextChanged"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtOTFrom"
                                            Display="Dynamic" ErrorMessage="Select From Date" ForeColor="Red" SetFocusOnError="True" Font-Size="11px"
                                            ValidationGroup="Group2"></asp:RequiredFieldValidator>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtOTFrom"
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
                                    <div class="col-md-7">
                                        <asp:TextBox Class="form-control" runat="server" ID="txtOTTo" autocomplete="off"
                                            placeholder="MM/dd/yyyy"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtOTTo"
                                            Display="Dynamic" ErrorMessage="Select To Date" ForeColor="Red" SetFocusOnError="True" Font-Size="11px"
                                            ValidationGroup="Group2"></asp:RequiredFieldValidator>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtOTTo"
                                            PopupButtonID="Image_AT" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row" style="margin-bottom: 10px">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                    </div>
                                    <div class="col-md-7">
                                        <asp:Button ID="btnOTProccess" runat="server" Text="Process" class="btn btn-info" ValidationGroup="Group2" OnClick="btnOTProccess_Click" />
                                    </div>
                                    <%-- <div class="col-md-5">
                                    <asp:Button ID="btnReport" runat="server" Text="Print" class="btn btn-primary" ValidationGroup="Group1"/>
                                </div>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <script type="text/javascript">

        function func(result) {
            if (result === 'Data Proccessed Temporarily') {
                toastr.success(result);
            }
            else if (result === 'Data Proccessed Successfully') {
                toastr.success(result);
            }
            else if (result === 'Employee Attendance Status Proccessed Successfully') {
                toastr.success(result);
            }
            else if (result === 'OT Proccessed Successfully') {
                toastr.success(result);
            }
            else
                toastr.error(result);

            return false;
        }
    </script>

</asp:Content>
