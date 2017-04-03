<%@ Page Title="" Language="C#" MasterPageFile="~/FA/Site.Master" AutoEventWireup="true"
    CodeBehind="Addition.aspx.cs" Inherits="ERPSSL.FA.Addition" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="Control/ShortAssetDetails.ascx" TagName="ShortAssetDetails" TagPrefix="uc1" %>
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
                <i class="fa fa-edit fa-fw icon-padding"></i>Addition
            </div>
        </div>
            <div class="col-md-12 bg-success">
        <asp:Label ID="lblParentStatus" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </div>
            <div class="row">
                <div class="col-md-12" style="margin-top: 20px;" >
                    <fieldset style="border: none">
                        <%--<legend style="line-height: 0;"><span style="background: #fff">Find Asset</span></legend>--%>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-6">
                                    <div class="row">
                                        <div class="col-md-5">
                                            Region
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="ddlRegion" CssClass="form-control" runat="server" AutoPostBack="True"
                                                OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-5">
                                            Office
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="ddlOffice" CssClass="form-control" runat="server" AutoPostBack="True"
                                                OnSelectedIndexChanged="ddlOffice_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-5">
                                            Department
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="ddlDepartment" CssClass="form-control" runat="server" AutoPostBack="True"
                                                OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-5">
                                            User
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="ddlUser" CssClass="form-control" runat="server" AutoPostBack="True"
                                                OnSelectedIndexChanged="ddlUser_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-5">
                                            Asset
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="ddlAsset" CssClass="form-control" runat="server" AutoPostBack="True"
                                                OnSelectedIndexChanged="ddlAsset_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Asset Code<span style="color:#f00">*</span>
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtAssetCode" CssClass="form-control" runat="server" AutoPostBack="True"
                                                    OnTextChanged="txtAssetCode_TextChanged"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAssetCode"
                                                    ValidationGroup="Addition" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Addition Date
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtAdditionDate" CssClass="form-control" runat="server"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtAdditionDate"
                                                    PopupButtonID="txtAdditionDate" Format="MM/dd/yyyy" CssClass="ajax__calendar"
                                                    Enabled="True" />
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Current Value
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtCurrentValue" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Current Residual Cost
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtCurrentResidualCost" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Additional Cost<span style="color:#f00">*</span>
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtAdditionalCost" CssClass="form-control" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAdditionalCost"
                                                    ValidationGroup="Addition" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Revised Residual Cost<span style="color:#f00">*</span>
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtRevisedResidualCost" CssClass="form-control" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" SetFocusOnError="true"
                                                    ControlToValidate="txtRevisedResidualCost" ValidationGroup="Addition"></asp:RequiredFieldValidator>
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
                                                <asp:Button ID="btnAddition" runat="server" Text="Save" class="btn btn-info" OnClick="btnAddition_Click"
                                                    ValidationGroup="Addition" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </fieldset>
                </div>
            </div>
           
            <div class="col-md-12">
                <fieldset>
                    <legend style="line-height: 0;"><span style="background: #fff">Find Asset</span></legend>
                    <div class="col-md-12">
                        <uc1:ShortAssetDetails ID="ShortAssetDetails1" runat="server" />
                        
                    </div>
                </fieldset>
            </div>
        </div>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
