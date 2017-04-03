<%@ Page Title="" Language="C#" MasterPageFile="~/FA/Site.Master" AutoEventWireup="true"
    CodeBehind="Revaluation.aspx.cs" Inherits="ERPSSL.FA.Revaluation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="Control/ShortAssetInfo.ascx" TagName="ShortAssetInfo" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />

    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
        <ContentTemplate>
            <div class="row">


                <div class="hm_sec_2_content scrollbar">
                    <div class="panel">
                        <div class="panel-heading panel-heading-01">
                            <i class="fa fa-edit fa-fw icon-padding"></i>Revaluation
                        </div>
                    </div>
                    <div class="col-md-12 bg-success">
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </div>
                    <div class="row">
                        <div class="col-md-12" style="margin-top: 20px;">
                            <fieldset>
                                <legend style="line-height: 0;"><span style="background: #fff">Find Asset</span></legend>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-6">
                                            <div class="row">
                                                <div class="col-md-5">
                                                    Region
                                                </div>
                                                <div class="col-md-7">
                                                    <asp:DropDownList ID="ddlRegion" CssClass="form-control" runat="server"
                                                        AutoPostBack="True" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-5">
                                                    Office
                                                </div>
                                                <div class="col-md-7">
                                                    <asp:DropDownList ID="ddlOffice" CssClass="form-control" runat="server"
                                                        AutoPostBack="True" OnSelectedIndexChanged="ddlOffice_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-5">
                                                    Department
                                                </div>
                                                <div class="col-md-7">
                                                    <asp:DropDownList ID="ddlDepartment" CssClass="form-control" runat="server"
                                                        AutoPostBack="True" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-5">
                                                    User
                                                </div>
                                                <div class="col-md-7">
                                                    <asp:DropDownList ID="ddlUser" CssClass="form-control" runat="server"
                                                        AutoPostBack="True" OnSelectedIndexChanged="ddlUser_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-5">
                                                    Asset
                                                </div>
                                                <div class="col-md-7">
                                                    <asp:DropDownList ID="ddlAsset" CssClass="form-control" runat="server"
                                                        AutoPostBack="True" OnSelectedIndexChanged="ddlAsset_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="col-md-5">
                                                        Asset Code<span style="color: #f00">*</span>
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:TextBox ID="txtAssetCode" CssClass="form-control" runat="server"
                                                            OnTextChanged="txtAssetCode_TextChanged"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                            ControlToValidate="txtAssetCode" SetFocusOnError="True"
                                                            ValidationGroup="Revalu"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="col-md-5">
                                                        Revalue Date
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:TextBox ID="txtRevalueDate" CssClass="form-control" runat="server"></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtRevalueDate"
                                                            PopupButtonID="txtRevalueDate" Format="MM/dd/yyyy" CssClass="ajax__calendar"
                                                            Enabled="True" />
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="col-md-5">
                                                        Revalued By Amount<span style="color: #f00">*</span>
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:TextBox ID="txtRevaluatedByAmount" CssClass="form-control" runat="server"
                                                            AutoPostBack="True" OnTextChanged="txtRevaluatedByAmount_TextChanged"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                            ControlToValidate="txtRevaluatedByAmount" SetFocusOnError="True"
                                                            ValidationGroup="Revalu"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="col-md-5">
                                                        Revalued At Amount<span style="color: #f00">*</span>
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:TextBox ID="txtRevaluatedAtAmount" CssClass="form-control" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                                            ControlToValidate="txtRevaluatedAtAmount" SetFocusOnError="True"
                                                            ValidationGroup="Revalu"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="col-md-5">
                                                        <asp:HiddenField ID="HiddenField2" runat="server" />
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:Button ID="btnRevalue" runat="server" Text="ReValue"
                                                            class="btn btn-info" OnClick="btnRevalue_Click" ValidationGroup="Revalu" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                    </div>
                    <asp:Label ID="lblParentStatus" runat="server" Text=""></asp:Label>
                    <div class="row">
                        <fieldset style="border: none; margin-top: 15px;">
                            <div class="col-md-12">
                                <fieldset>
                                    <legend style="line-height: 0;"><span style="background: #fff; font-weight: 600;">Find
                                Asset</span></legend>



                                    <uc1:ShortAssetInfo ID="ShortAssetInfo1" runat="server" />




                                </fieldset>
                            </div>
                        </fieldset>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
