<%@ Page Title="" Language="C#" MasterPageFile="~/FA/Site.Master" AutoEventWireup="true"
    CodeBehind="AssetEntry.aspx.cs" Inherits="ERPSSL.FA.AssetEntry" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        label
        {
            font-weight: normal !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
        <ContentTemplate>
            <div class="row">
                

                <div class="hm_sec_2_content scrollbar">
                    <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="fa fa-edit fa-fw icon-padding"></i>Asset Entry
                    </div>
                </div>
                    <div class="col-md-12 bg-success">
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </div>
                    <div class="row">
                        <fieldset style="border: none;">
                            <div class="col-md-12">
                                <div class="col-md-6">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Group:<span style="color:#f00">*</span>
                                            </div>
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="ddlGroup" AppendDataBoundItems="true" CssClass="form-control"
                                                    runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlGroup_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" SetFocusOnError="true"
                                                    ControlToValidate="ddlGroup" ValidationGroup="AssetEntry"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Asset:<span style="color:#f00">*</span>
                                            </div>
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="ddlAsset" AppendDataBoundItems="true" CssClass="form-control"
                                                    runat="server">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" SetFocusOnError="true"
                                                    ControlToValidate="ddlAsset" ValidationGroup="AssetEntry"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Employee ID:<span style="color:#f00">*</span>
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtEmployeeId" CssClass="form-control" runat="server" OnTextChanged="txtEmployeeId_TextChanged"
                                                    AutoPostBack="True"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" SetFocusOnError="true"
                                                    ControlToValidate="txtEmployeeId" ValidationGroup="AssetEntry"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Ownership Type:<span style="color:#f00">*</span>
                                            </div>
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="ddlOwnershipType" AppendDataBoundItems="true" CssClass="form-control"
                                                    runat="server">
                                                    <asp:ListItem Value="">Select One</asp:ListItem>
                                                    <asp:ListItem Value="Owned">Owned</asp:ListItem>
                                                    <asp:ListItem Value="Leased">Leased</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" SetFocusOnError="true"
                                                    ControlToValidate="ddlOwnershipType" ValidationGroup="AssetEntry"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Region:
                                            </div>
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="ddlRegion" AppendDataBoundItems="true" CssClass="form-control"
                                                    runat="server" AutoPostBack="True"
                                                    OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged"
                                                    OnDataBound="ddlRegion_DataBound">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Office:
                                            </div>
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="ddlOffice" AppendDataBoundItems="true" CssClass="form-control"
                                                    runat="server" AutoPostBack="True"
                                                    OnSelectedIndexChanged="ddlOffice_SelectedIndexChanged"
                                                    OnDataBound="ddlOffice_DataBound">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Department:
                                            </div>
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="ddlDepartment" AppendDataBoundItems="true" CssClass="form-control"
                                                    runat="server" AutoPostBack="True"
                                                    OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged"
                                                    OnDataBound="ddlDepartment_DataBound">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                User:
                                            </div>
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="ddlUser" AppendDataBoundItems="true" CssClass="form-control"
                                                    runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlUser_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Entry Type:<span style="color:#f00">*</span>
                                            </div>
                                            <div class="col-md-7">
                                                <asp:RadioButtonList ID="rdoAssetStatus" runat="server" OnSelectedIndexChanged="rdoAssetStatus_SelectedIndexChanged"
                                                    RepeatLayout="Flow" CellSpacing="100" AutoPostBack="True" RepeatDirection="Horizontal">
                                                    <asp:ListItem Value="NewAsset">New Asset</asp:ListItem>
                                                    <asp:ListItem Value="OldAsset">Old Asset</asp:ListItem>
                                                </asp:RadioButtonList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" SetFocusOnError="true"
                                                    ControlToValidate="rdoAssetStatus" ValidationGroup="AssetEntry"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Entry Date:
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtTransferDate" CssClass="form-control" runat="server"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtTransferDate"
                                                    PopupButtonID="txtEntryDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                               Salvage Value:
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtReschedualCost" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Acquisition Value:
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtPrice" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </fieldset>
                    </div>
                    <asp:Label ID="lblEmployeeStatus" runat="server" Text=""></asp:Label>
                    <hr />
                    <div class="row">
                        <div class="col-md-12" style="margin-top: 20px;">
                            <div class="col-md-6">
                                <fieldset>
                                    <legend style="line-height: 0;"><span style="background: #fff">Asset Value: Opening balance
                                as on entry date</span></legend>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                As per Accounting:
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtACOBAccounting" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                As per Tax:
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtACOBTax" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                            <div class="col-md-6">
                                <fieldset>
                                    <legend style="line-height: 0;"><span style="background: #fff">Depreciation: Opening
                                balance as on entry date</span></legend>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                As per Accounting:
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtDepOBAccounting" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                As per Tax:
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtDepOBTax" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12" style="margin-top: 20px;">
                            <div class="col-md-6">
                                <fieldset>
                                    <legend style="line-height: 0;"><span style="background: #fff">Reval. Reserve: Opening
                                balance as on entry date</span></legend>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                As per Accounting:
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtRROBAccounting" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                As per Tax:
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtRROBTax" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                            <div class="col-md-6">
                                <fieldset>
                                    <legend style="line-height: 0;"><span style="background: #fff">Deferred Tax: Opening
                                balance as on entry date</span></legend>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Asset:
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtDTOBAsset" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Liability:
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtDTOBLiability" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </fieldset>
                                <div class="row ">
                                    <div class="col-md-12">
                                        <asp:HiddenField ID="HiddenField1" runat="server" />
                                        <asp:Button ID="btnReceiveAsset" runat="server" Text="Save" Style="float: right; margin-top: 15px; margin-right: 20px;"
                                            class="btn btn-info"
                                            OnClick="btnReceiveAsset_Click" ValidationGroup="AssetEntry" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <rsweb:ReportViewer ID="ReportViewer1" AsyncRendering="False" InteractiveDeviceInfos="(Collection)"
                            SizeToReportContent="True" Width="100%" runat="server" Font-Names="Verdana" Font-Size="8pt"
                            WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" BackColor="White">
                        </rsweb:ReportViewer>
                    </div>
                    <br />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
