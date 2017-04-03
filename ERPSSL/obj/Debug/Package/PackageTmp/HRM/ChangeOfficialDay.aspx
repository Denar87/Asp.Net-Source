<%@ Page Title="Attendance" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true"
    CodeBehind="ChangeOfficialDay.aspx.cs" Inherits="ERPSSL.HRM.ChangeOfficialDay" %>

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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
        <ContentTemplate>
            <script src="content/js/bootstrap-datetimepicker.js" type="text/javascript"></script>
            <link href="content/css/bootstrap-datetimepicker.min.css" rel="stylesheet" type="text/css" />
            <div class="hm_sec_2_content scrollbar">
                <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="fa fa-edit fa-fw icon-padding"></i>Change Office Day
                    </div>
                    <div class="col-md-12 bg-success">
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="row">

                    <fieldset style="border: none;">

                        <div class="col-md-12">
                            <div class="col-md-6">
                                <div class="panel panel-info">
                                    <div class="panel-heading " style="background-color: #778899; color: white">Change Official Day (All) </div>
                                    <div class="panel-body" style="font-size: 11px;  color: green; margin-top: 0px; margin-bottom: 0px;">

                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="col-md-4">
                                                    Date
                                                </div>
                                                <div class="col-md-7">
                                                    <asp:TextBox Class="form-control" runat="server" ID="txtAttDate" autocomplete="off"
                                                        placeholder="MM/dd/yyyy"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAttDate"
                                                        Display="Dynamic" ErrorMessage="Select Date" ForeColor="Red" SetFocusOnError="True" Font-Size="11px"
                                                        ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtAttDate"
                                                        PopupButtonID="Image_AT" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row" style="padding-top: 8px;">
                                            <div class="col-md-12">
                                                <div class="col-md-4">
                                                    Working Day
                                                </div>
                                                <div class="col-md-7">
                                                    <asp:DropDownList ID="ddlWorkingDay" CssClass="form-control"
                                                        runat="server">
                                                        <asp:ListItem Value="0" Text="------ Select One ------"></asp:ListItem>
                                                        <asp:ListItem Value="General">General</asp:ListItem>
                                                        <asp:ListItem Value="Holiday">Holiday</asp:ListItem>
                                                        <asp:ListItem Value="Extra">Extra</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlWorkingDay"
                                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select a Working Day"
                                                        Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row" style="padding-top: 8px;">
                                            <div class="col-md-12">
                                                <div class="col-md-4">
                                                    OT Applicable
                                                </div>
                                                <div class="col-md-7">
                                                    <asp:DropDownList ID="ddlOTAppliocable" CssClass="form-control"
                                                        runat="server">
                                                        <asp:ListItem Text="------ Select One------" Value="0"></asp:ListItem>
                                                        <asp:ListItem Value="True">Yes</asp:ListItem>
                                                        <asp:ListItem Value="False">No</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlOTAppliocable"
                                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select OT Status"
                                                        Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row" style="padding-top: 8px;">
                                            <div class="col-md-12">
                                                <div class="col-md-8">
                                                </div>
                                                <div class="col-md-4">
                                                    <asp:Button ID="btnUpdate" runat="server" Text="Process" class="btn btn-info" ValidationGroup="Group1" OnClick="btnUpdate_Click" />
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="panel panel-info">
                                    <div class="panel-heading " style="background-color: #778899; color: white">Change Official Day (Individual) </div>
                                    <div class="panel-body" style="font-size: 11px; color: green; margin-top: 0px; margin-bottom: 0px;">




                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="col-md-4">
                                                    E-ID
                                                </div>
                                                <div class="col-md-7">
                                                    <asp:TextBox ID="txtEid_TRNS" class="form-control" runat="server" OnTextChanged="txtEid_TRNS_TextChanged" AutoPostBack="True"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row" style="padding-top: 8px;">
                                            <div class="col-md-12">
                                                <div class="col-md-4">
                                                    Name
                                                </div>
                                                <div class="col-md-7">
                                                    <asp:TextBox ID="txtEmpName_TRNS" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>


                                        <div class="row" style="padding-top: 8px;">
                                            <div class="col-md-12">
                                                <div class="col-md-4">
                                                    Department
                                                </div>
                                                <div class="col-md-7">
                                                    <asp:TextBox ID="txtDepartment" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row" style="padding-top: 8px;">
                                            <div class="col-md-12">
                                                <div class="col-md-4">
                                                    Designation
                                                </div>
                                                <div class="col-md-7">
                                                    <asp:TextBox ID="txtDesignation" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row" style="padding-top: 8px;">
                                            <div class="col-md-12">
                                                <div class="col-md-4">
                                                    Date
                                                </div>
                                                <div class="col-md-7">
                                                    <asp:TextBox Class="form-control" runat="server" ID="txtDate" autocomplete="off"
                                                        placeholder="MM/dd/yyyy"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDate"
                                                        Display="Dynamic" ErrorMessage="Select Date" ForeColor="Red" SetFocusOnError="True" Font-Size="11px"
                                                        ValidationGroup="Group2"></asp:RequiredFieldValidator>
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate"
                                                        PopupButtonID="Image_AT" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row" style="padding-top: 8px;">
                                            <div class="col-md-12">
                                                <div class="col-md-4">
                                                    Working Day
                                                </div>
                                                <div class="col-md-7">
                                                    <asp:DropDownList ID="ddlday" CssClass="form-control"
                                                        runat="server">
                                                        <asp:ListItem Value="0" Text="------ Select One ------"></asp:ListItem>
                                                        <asp:ListItem Value="General">General</asp:ListItem>
                                                        <asp:ListItem Value="Holiday">Holiday</asp:ListItem>
                                                        <asp:ListItem Value="Holiday">Extra</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlday"
                                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select a Working Day"
                                                        Font-Size="11px" ValidationGroup="Group2" InitialValue="0"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row" style="padding-top: 8px;">
                                            <div class="col-md-12">
                                                <div class="col-md-4">
                                                    OT Applicable
                                                </div>
                                                <div class="col-md-7">
                                                    <asp:DropDownList ID="ddlOT" CssClass="form-control"
                                                        runat="server">
                                                        <asp:ListItem Text="------ Select One------" Value="0"></asp:ListItem>
                                                        <asp:ListItem Value="True">Yes</asp:ListItem>
                                                        <asp:ListItem Value="False">No</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlOT"
                                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select OT Status"
                                                        Font-Size="11px" ValidationGroup="Group2" InitialValue="0"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row" style="padding-top: 8px;">
                                            <div class="col-md-12">
                                                <div class="col-md-8">
                                                </div>
                                                <div class="col-md-4">
                                                    <asp:Button ID="btnProcess" runat="server" Text="Process" class="btn btn-info" ValidationGroup="Group2" OnClick="btnProcess_Click" />
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </fieldset>
                </div>
            </div>
        </ContentTemplate>

        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnUpdate" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <script type="text/javascript">

        function func(result) {
            if (result === 'Data Updated Successfully') {
                toastr.success(result);
            }

            else
                toastr.error(result);

            return false;
        }

    </script>

</asp:Content>
