<%@ Page Title="" Language="C#" MasterPageFile="~/INV/Site.Master" AutoEventWireup="true"
    CodeBehind="EditUnallocatedMRR.aspx.cs" Inherits="ERPSSL.INV.EditUnallocatedMRR" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
    <script language="javascript" type="text/javascript">
        function ShowIcon() {
            var e = document.getElementById("processing");
            e.style.visibility = (e.style.visibility == 'visible') ? 'hidden' : 'visible';
        }
        function ShowIcon_tr() {
            var et = document.getElementById("processing_tr");
            et.style.visibility = (et.style.visibility == 'visible') ? 'hidden' : 'visible';
        }
    </script>
    <style type="text/css">
        .imgwd {
            width: 88px;
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
    <script src="content/js/bootstrap-datetimepicker.js" type="text/javascript"></script>
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="hm_sec_2_content scrollbar">
                    <div class="panel">
                        <div class="panel-heading panel-heading-01">
                            <i class="glyphicon glyphicon-edit icon-padding"></i>Edit Unallocated 
                        </div>
                    </div>
                    <div class="col-md-12 bg-success">
                        <center>
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label></center>
                    </div>
                    <div class="col-md-12" style="margin-top: 10px;">
                        <div class="col-md-12" style="padding-bottom: 15px; border-bottom: 0px solid gray">
                            <div class="row" style="padding-top: 5px; margin: auto 0;">
                                <div class="col-md-6">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                Store & Company<a style="color: red; font-size: 11px">*</a>
                                            </div>
                                            <div class="col-md-8">
                                                <asp:DropDownList ID="ddlStore" Class="form-control" Enabled="false" runat="server" AutoPostBack="True"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlStore"
                                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Store"
                                                    Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" style="padding-top: 5px">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                Supplier<a style="color: red; font-size: 11px">*</a>
                                            </div>
                                            <div class="col-md-8">
                                                <asp:DropDownList ID="ddlSupplier" Class="form-control" runat="server" AutoPostBack="True" Enabled="false"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlSupplier"
                                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Supplier"
                                                    Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" style="padding-top: 5px">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                Ref.No./Challan No.<a style="color: red; font-size: 11px">*</a>
                                            </div>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtRefNo" Class="form-control" ReadOnly="true" placeholder="Ref.No./ Challan No." runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtRefNo"
                                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Enter Ref. No."
                                                    Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" style="padding-top: 5px">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                Season
                                            </div>
                                            <div class="col-md-8">
                                                <asp:DropDownList ID="ddlSeason" Class="form-control" runat="server" AutoPostBack="True">
                                                    <asp:ListItem Value="0">--Select One--</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" style="padding-top: 5px">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                Order
                                            </div>
                                            <div class="col-md-8">
                                                <asp:DropDownList ID="ddlOrder" Class="form-control" placeholder="Order" runat="server" AutoPostBack="True">
                                                    <asp:ListItem Value="0">--Select One--</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                Date<a style="color: red; font-size: 11px">*</a>
                                            </div>
                                            <div class="col-md-8">
                                                <asp:TextBox Class="form-control" Enabled="false" runat="server" ID="txtDate" autocomplete="off"
                                                    placeholder="MM/dd/yyyy"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtDate"
                                                    Display="Dynamic" ErrorMessage="Select Recieved Date" ForeColor="Red" SetFocusOnError="True"
                                                    Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate"
                                                    PopupButtonID="Image_AT" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" style="padding-top: 5px">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                MRR No.
                                            </div>
                                            <div class="col-md-8">
                                                <asp:TextBox Class="form-control" runat="server" placeholder="MRR No." ID="txtChallanNo" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" style="padding-top: 5px">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                Master L/C No.
                                            </div>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtMasterLCNo" Class="form-control" runat="server" placeholder="Master L/C No."></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" style="padding-top: 5px">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                B2B L/C No.
                                            </div>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtB2BLCNo" Class="form-control" runat="server" placeholder="B2B L/C No."></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" style="padding-top: 5px">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                Receiver E-ID
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="txtReceiverEID" Enabled="false" placeholder="Receiver E-ID" Width="110%" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>
                                                <cc1:AutoCompleteExtender ServiceMethod="SearchCurrentEmployee"
                                                    MinimumPrefixLength="1"
                                                    CompletionInterval="100" EnableCaching="False"
                                                    TargetControlID="txtReceiverEID"
                                                    ID="AutoCompleteExtender1" runat="server" DelimiterCharacters="" Enabled="True" ServicePath="">
                                                </cc1:AutoCompleteExtender>
                                            </div>
                                            <div class="col-md-5">
                                                <asp:TextBox ID="txtReceiverName" Width="100%" placeholder="Receiver Name" ReadOnly="true" Class="form-control" runat="server"></asp:TextBox>
                                                <asp:HiddenField ID="hIdEid" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="col-md-7">
                            </div>
                            <div class="col-md-2">
                                <asp:Button ID="btnSave" runat="server" Text="Update" Style="margin-right: 5px;" CssClass="btn btn-info pull-right" OnClick="btnSave_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <rsweb:ReportViewer ID="ReportViewerPurchase" AsyncRendering="False" InteractiveDeviceInfos="(Collection)"
                            SizeToReportContent="True" Width="100%" Height="700px" runat="server" Font-Names="Verdana"
                            Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" BackColor="White">
                        </rsweb:ReportViewer>
                    </div>
                </div>
                <asp:HiddenField ID="hiddenCompanyType" runat="server" />
                <asp:HiddenField ID="hidId" runat="server" />
                <asp:HiddenField ID="hdnBrand" runat="server" />
                <asp:HiddenField ID="hdnStyle" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <script type="text/javascript">
        function func(result) {
            if (result === 'Purchase information posted successfully') {
                toastr.success(result);
            }
            else if (result === 'Data Update Successfully') {
                toastr.success(result);
            }
            else if (result === 'Purchase information has been added temporarily. Please post.') {
                toastr.success(result);
            }
            else
                toastr.error(result);
            return false;
        }
    </script>
</asp:Content>
