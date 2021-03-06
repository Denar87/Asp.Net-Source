﻿<%@ Page Title="" Language="C#" MasterPageFile="~/FA/Site.Master" AutoEventWireup="true"
    CodeBehind="Disposal.aspx.cs" Inherits="ERPSSL.FA.Disposal" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
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
                <i class="fa fa-edit fa-fw icon-padding"></i>Disposal
            </div>
        </div>
       
       
             <div class="col-md-12 bg-success">
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </div>
            <div class="row">
                <div class="col-md-12" style="margin-top: 20px;">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-6">
                                <div class="row">
                                    <div class="col-md-5">
                                        Region
                                    </div>
                                    <div class="col-md-7">
                                        <asp:DropDownList ID="ddlRegion" CssClass="form-control" runat="server" 
                                            AutoPostBack="True" onselectedindexchanged="ddlRegion_SelectedIndexChanged">
                                 
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
                                            AutoPostBack="True" onselectedindexchanged="ddlOffice_SelectedIndexChanged">
                                           
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
                                            AutoPostBack="True" onselectedindexchanged="ddlDepartment_SelectedIndexChanged">
                                          
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
                                            AutoPostBack="True" onselectedindexchanged="ddlUser_SelectedIndexChanged">
                                            
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
                                            AutoPostBack="True" onselectedindexchanged="ddlAsset_SelectedIndexChanged">
                                           
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                             <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-5">
                                        Asset Code
                                    </div>
                                    <div class="col-md-7">
                                        <asp:TextBox ID="txtAssetCode" CssClass="form-control" runat="server" 
                                            ontextchanged="txtAssetCode_TextChanged" AutoPostBack="True"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                            ControlToValidate="txtAssetCode" SetFocusOnError="True" 
                                            ValidationGroup="Disposal"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-5">
                                        Disposal Date
                                    </div>
                                    <div class="col-md-7">
                                        <asp:TextBox ID="txtDisposalDate" CssClass="form-control" runat="server"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtDisposalDate"
                                            PopupButtonID="txtDisposalDate" Format="MM/dd/yyyy" CssClass="ajax__calendar"
                                            Enabled="True" />
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-5">
                                        Disposal Amount
                                    </div>
                                    <div class="col-md-7">
                                        <asp:TextBox ID="txtDisposeAmount" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                            ControlToValidate="txtDisposeAmount" EnableViewState="False" 
                                            SetFocusOnError="True" ValidationGroup="Disposal"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-5">
                                        Remarks
                                    </div>
                                    <div class="col-md-7">
                                        <asp:TextBox ID="txtRemarks" CssClass="form-control" runat="server" TextMode="MultiLine"
                                            Height="100px"></asp:TextBox>
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
                                        <asp:Button ID="btnDispose" runat="server" Text="Dispose" class="btn btn-info" 
                                            onclick="btnDispose_Click" ValidationGroup="Disposal" />
                                    </div>
                                </div>
                            </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

              <asp:Label ID="lblParentStatus" runat="server" Text=""></asp:Label>
            <div class="row" id="ShowInfoDetails" runat="server">
                <fieldset style="border: none; margin-top: 15px;">
                    <div class="col-md-12">
                        <fieldset>
                            <legend style="line-height: 0;"><span style="background: #fff; font-weight: 600;">Find
                                Asset</span></legend>
                                  <fieldset>
        <asp:Label ID="lblAssetCode" runat="server" Font-Bold="True" Font-Size="Larger"></asp:Label>
        <div style="width: 95%">
            <hr />
        </div>
        <div style="background-color: #F1F0F0;">
            <div style="float: left; width: 35%;">
                <asp:Label ID="lblAsset" runat="server" Font-Bold="True"></asp:Label><br />
                <asp:Label ID="lblGroup" runat="server" Font-Bold="True"></asp:Label><br />
                <asp:Label ID="lblUser" runat="server" Text=""></asp:Label><br />
                <asp:Label ID="lblDepartment" runat="server" Text=""></asp:Label><br />
                <asp:Label ID="lblOffice" runat="server" Text=""></asp:Label><br />
                <asp:Label ID="lblRegion" runat="server" Text=""></asp:Label><br />
            </div>
            <div style="float: left; width: 60%;">
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <asp:Label ID="AccTax" runat="server" Text="As Per"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Tax" runat="server" Text="Accounting" Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text="Tax" Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="A/C Balance" />
                        </td>
                        <td>
                            <asp:Label ID="lblACClosingBalance" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblACClosingBalanceTax" runat="server" Font-Bold="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Acc. Dep. Balance" />
                        </td>
                        <td>
                            <asp:Label ID="lblADClosingBalance" runat="server" Font-Bold="False"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblADClosingBalanceTax" runat="server" Font-Bold="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Rev. Rsrv. Balance" />
                        </td>
                        <td>
                            <asp:Label ID="lblRRClosingBalance" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblRRClosingBalanceTax" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Method" />
                        </td>
                        <td>
                            <asp:Label ID="lblMethod" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblMethodTax" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div style="clear: both;">
            <div style="width: 95%">
                <hr />
            </div>
        </div>
        <asp:Label ID="lblStatus" runat="server" ForeColor="#CC3300"></asp:Label>
    </fieldset>
                        </fieldset>
                    </div>
                </fieldset>
            </div>
        </div>
    </div>

    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
