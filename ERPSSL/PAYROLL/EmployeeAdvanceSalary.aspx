<%@ Page Title="" Language="C#" MasterPageFile="~/PAYROLL/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeAdvanceSalary.aspx.cs" Inherits="ERPSSL.PAYROLL.EmployeeAdvanceSalary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>
            <div class="hm_sec_2_content scrollbar">
                <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="fa fa-edit fa-fw icon-padding"></i>Employee Advance Salary
                    </div>
                </div>
                <div class="col-md-12 bg-success">
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </div>
                <%-- <div class="col-md-12" style="padding: 0px">
                    <div class="col-md-10">
                    </div>
                    <div class="col-md-2">
                        <p style="font-weight: bold">Code :<asp:Label ID="lblAdvanceSalaryCode" runat="server"></asp:Label></p>
                    </div>
                </div>--%>

                <div class="col-md-12">

                    <%--<div class="col-md-6">
                        <div class="alert alert-danger" style="padding: 0px; padding-left: 10px; font-weight: bold" role="alert">
                            Select Employee
                        </div>
                    </div>--%>
                    <div class="col-md-6">
                        <div class="panel panel-info">
                            <div class="panel-heading " style="background-color: #778899; color: white">Select Employee </div>
                            <div class="panel-body" style="font-size: 11px; height: 220px; color: green; margin-top: 0px; margin-bottom: 0px;">


                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            Region
                                        </div>
                                        <div class="col-md-8">
                                            <asp:DropDownList ID="ddlRegion" CssClass="form-control" runat="server"
                                                AutoPostBack="True" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:HiddenField ID="hiadvanceSalaryId" runat="server" />
                                            <asp:HiddenField ID="hiAdCode" runat="server" />
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator16" ValidationGroup="Group2"
                                                runat="server" ControlToValidate="ddlRegion" ErrorMessage="Select Region" InitialValue="0"></asp:RequiredFieldValidator>--%>
                                        </div>
                                    </div>
                                </div>
                                <br />

                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            Office
                                        </div>
                                        <div class="col-md-8">
                                            <asp:DropDownList ID="ddlOffice" CssClass="form-control" runat="server"
                                                AutoPostBack="True" OnSelectedIndexChanged="ddlOffice_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Group2"
                                                runat="server" ControlToValidate="ddlOffice" ErrorMessage="Select Office" InitialValue="0"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            Department
                                        </div>
                                        <div class="col-md-8">
                                            <asp:DropDownList ID="drpDepartment" CssClass="form-control" runat="server"
                                                AutoPostBack="True" OnSelectedIndexChanged="drpDepartment_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Group2"
                                                runat="server" ControlToValidate="drpDepartment" ErrorMessage="Select Department" InitialValue="0"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            Employee
                                        </div>
                                        <div class="col-md-8">
                                            <asp:DropDownList ID="drpEmployee" AutoPostBack="true" OnSelectedIndexChanged="drpEmployee_SelectedIndexChanged" CssClass="form-control" runat="server">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="Group2"
                                                runat="server" ControlToValidate="drpEmployee" ErrorMessage="Select Employee" InitialValue="0"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="panel panel-info">
                            <div class="panel-heading " style="background-color: #778899; color: white">Employee Details </div>
                            <div class="panel-body" style="font-size: 11px; height: 220px; color: green; margin-top: 0px; margin-bottom: 0px;">


                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            E-ID
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtEid_TRNS" class="form-control" runat="server" OnTextChanged="txtEid_TRNS_TextChanged" AutoPostBack="True"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Name
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtEmpName_TRNS" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <br />

                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Department
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtDepartment" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Designation
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtDesignation" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <%--<br />
                       
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-5">
                                        Photo
                                    </div>
                                    <div class="col-md-7">
                                        <asp:Image ID="Emp_IMG_TRNS" ImageUrl="resources/no_image.png" CssClass="img-thumbnail" Width="120px" Height="120px"
                                            runat="server" />
                                    </div>
                                </div>
                            </div>--%>
                            </div>
                        </div>

                    </div>

                </div>

                <div class="col-md-12" style="padding-top: 20px">

                    <div class="panel panel-info">
                        <div class="panel-heading " style="background-color: #778899; color: white">Advance Salary  </div>
                        <div class="panel-body" style="font-size: 11px; color: green; margin-top: 0px; margin-bottom: 0px;">
                            <div class="col-md-12">
                                <div class="col-md-4">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            Amount
                                        </div>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtbxTotalAmount" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtbxTotalAmount"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Total Amount"
                                            ValidationGroup="Group2"></asp:RequiredFieldValidator>

                                    </div>

                                    <div class="col-md-12">
                                        <br />
                                        <div class="col-md-4">
                                            Effective Start Month
                                        </div>
                                        <div class="col-md-8">
                                            <asp:TextBox runat="server" ID="txtbxStartDate" OnTextChanged="txtbxStartDate_TextChanged" AutoPostBack="True" Class="form-control" placeholder="MM/dd/yyyy" />
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtbxStartDate"
                                                PopupButtonID="txtbxStartDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                        </div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtbxStartDate"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Start Date"
                                            ValidationGroup="Group2"></asp:RequiredFieldValidator>

                                    </div>

                                </div>
                                <div class="col-md-4">
                                    <div class="col-md-12">

                                        <div class="col-md-4">
                                            Installment
                                        </div>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtbxInstalment" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtbxInstalment"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Installment"
                                            ValidationGroup="Group2"></asp:RequiredFieldValidator>
                                    </div>

                                    <div class="col-md-12">
                                        <br />
                                        <div class="col-md-4">
                                            End Month
                                        </div>
                                        <div class="col-md-8">
                                            <asp:TextBox runat="server" ID="txtbxEndDate" Class="form-control" placeholder="MM/dd/yyyy" />
                                            <%-- <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtbxEndDate"
                                        PopupButtonID="txtbxEndDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />--%>
                                        </div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtbxEndDate"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input End Date"
                                            ValidationGroup="Group2"></asp:RequiredFieldValidator>
                                    </div>

                                </div>
                                <div class="col-md-4">
                                    <div class="col-md-12">

                                        <div class="col-md-4">
                                            No. of Installment
                                        </div>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtbxNoofInslament" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtbxNoofInslament"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input No. of Installment"
                                                ValidationGroup="Group2"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <br />

                                    <div class="col-md-12">
                                        <br />
                                        <div class="col-md-4">
                                            Remarks
                                        </div>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtRemarks" class="form-control" runat="server"></asp:TextBox>
                                        </div>

                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12" style="padding-top: 8px;">

                                <div class="col-md-5">
                                </div>
                                <div class="col-md-7" style="padding-right: 45px">
                                    <asp:Button ID="btnSaveAdvance" class="btn btn-info  pull-right" ValidationGroup="Group2" runat="server" Text="Submit" OnClick="btnSaveAdvance_Click" />
                                </div>

                            </div>
                        </div>
                    </div>
                </div>

            </div>

        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSaveAdvance" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="ddlRegion" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="drpDepartment" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="ddlOffice" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="drpEmployee" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>

    <script>
        function func(result) {

            if (result === 'This Employee is Inactive!') {
                toastr.error(result);
            }
            return false;
        }

    </script>
</asp:Content>
