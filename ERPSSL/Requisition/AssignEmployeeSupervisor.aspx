<%@ Page Title="" Language="C#" MasterPageFile="~/Requisition/Site.Master" AutoEventWireup="true"
    CodeBehind="AssignEmployeeSupervisor.aspx.cs" Inherits="ERPSSL.Requisition.AssignEmployeeSupervisor" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="glyphicon glyphicon-edit icon-padding"></i>Assign Employee Supervisor
                    </div>
                </div>

                <div class="hm_sec_2_content scrollbar">
                    <div class="col-md-12 bg-success">
                        <center>
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label></center>
                    </div>
                    <asp:HiddenField ID="hdnOfficeID" runat="server" />
                    <div class="row">
                        <fieldset style="border: none;">
                            <div class="col-md-12">

                                <div class="col-md-6">
                                    <fieldset>
                                        <legend style="line-height: 0;"><span style="background: #fff">Select Employee</span></legend>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="col-md-5">
                                                    E-ID<a style="color: red; font-size: 11px">*</a>
                                                </div>
                                                <div class="col-md-7">
                                                    <asp:TextBox ID="txtEID" CssClass="form-control" runat="server" OnTextChanged="txtEID_TextChanged"
                                                        AutoPostBack="true"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="col-md-5">
                                                    Department<a style="color: red; font-size: 11px">*</a>
                                                </div>
                                                <div class="col-md-7">
                                                    <asp:DropDownList ID="ddlDepartment" AppendDataBoundItems="true" CssClass="form-control"
                                                        runat="server" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged" AutoPostBack="True">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlDepartment"
                                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Department"
                                                        Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="col-md-5">
                                                    Employee<a style="color: red; font-size: 11px">*</a>
                                                </div>
                                                <div class="col-md-7">
                                                    <asp:DropDownList ID="ddlEmployee" CssClass="form-control" runat="server" AutoPostBack="true"
                                                        OnSelectedIndexChanged="ddlEmployee_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlEmployee"
                                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Employee"
                                                        Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                    </fieldset>
                                </div>
                                <div class="col-md-6">
                                    <fieldset>
                                        <legend style="line-height: 0;"><span style="background: #fff">Select Supervisor</span></legend>
                                        <%--<div class="row">
                                            <div class="col-md-12">
                                                <div class="col-md-5">
                                                    Supervisor E-ID<a style="color: red; font-size: 11px">*</a>
                                                </div>
                                                <div class="col-md-7">
                                                    <asp:TextBox ID="txtSupervisorEID" CssClass="form-control" runat="server" OnTextChanged="txtSupervisorEID_TextChanged"
                                                        AutoPostBack="true"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <br />--%>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="col-md-5">
                                                    Reporting Boss-1<a style="color: red; font-size: 11px">*</a>
                                                </div>
                                                <div class="col-md-7">
                                                    <asp:DropDownList ID="ddlSupervisorEID" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSupervisorEID_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlSupervisorEID"
                                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select One"
                                                        Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="col-md-5">
                                                    Reporting Boss-2<a style="color: red; font-size: 11px">*</a>
                                                </div>
                                                <div class="col-md-7">
                                                    <asp:DropDownList ID="ddlSupervisor2EID" CssClass="form-control" runat="server" AutoPostBack="True">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlSupervisor2EID"
                                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select One"
                                                        Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="col-md-5">
                                                    Reporting Boss-3<a style="color: red; font-size: 11px">*</a>
                                                </div>
                                                <div class="col-md-7">
                                                    <asp:DropDownList ID="ddlSupervisor3EID" CssClass="form-control" runat="server" AutoPostBack="True">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlSupervisor3EID"
                                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select One"
                                                        Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row ">
                                            <div class="col-md-12">
                                                <div class="col-md-5">
                                                </div>
                                                <div class="col-md-7">
                                                    <asp:Button ID="BtnSave" runat="server" Text="Update" Style="margin-right: 20px;"
                                                        ValidationGroup="Group1" class="btn btn-info pull-right" OnClick="BtnSave_Click" />
                                                </div>
                                            </div>
                                        </div>
                                    </fieldset>
                                </div>
                            </div>
                        </fieldset>
                    </div>

                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">

        function func(result) {
            if (result === 'Supervisor updated successfully for this employee') {
                toastr.success(result);
            }
            else
                toastr.error(result);

            return false;
        }

    </script>
</asp:Content>
