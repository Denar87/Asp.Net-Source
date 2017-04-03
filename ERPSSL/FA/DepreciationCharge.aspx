<%@ Page Title="" Language="C#" MasterPageFile="~/FA/Site.Master" AutoEventWireup="true" CodeBehind="DepreciationCharge.aspx.cs" Inherits="ERPSSL.FA.DepreciationCharge" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <div class="row">
        <div class="hm_sec_2_content scrollbar">
            <div class="panel">
                <div class="panel-heading panel-heading-01">
                    <i class="fa fa-edit fa-fw icon-padding"></i>Depreciation Charge
                </div>
            </div>


            <div class="col-md-12 bg-success">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </div>
            <div class="col-md-12 bg-success">
                Last Day of Depreciation Charge:
                <asp:Label ID="lblLastDepreciationDate" runat="server" Text=""></asp:Label>
            </div>
            <div class="row">
                <div class="col-md-12" style="margin-top: 20px;">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-6">
                                <div class="col-md-3">
                                    Up To
                                </div>
                                <div class="col-md-5">
                                    <asp:TextBox ID="txtUpToDate" CssClass="form-control" runat="server"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtUpToDate"
                                        PopupButtonID="txtUpToDate" Format="MM/dd/yyyy" CssClass="ajax__calendar"
                                        Enabled="True" />
                                </div>
                                <div class="col-md-4">
                                    <asp:HiddenField ID="hdfDepreciationCharge" runat="server" />

                                    <asp:Button ID="btnCalculateDepreciation" runat="server"
                                        Text="Calculate Depreciation" class="btn btn-info"
                                        OnClick="btnCalculateDepreciation_Click" />

                                </div>
                                <asp:Label ID="lblDepreciationStatus" runat="server" Text=""></asp:Label>
                            </div>

                        </div>


                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
