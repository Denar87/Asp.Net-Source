<%@ Page Title="" Language="C#" MasterPageFile="~/LC/Site.Master" AutoEventWireup="true" CodeBehind="LC_Report.aspx.cs" Inherits="ERPSSL.LC.LC_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

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

            <asp:HiddenField ID="hdnUserID" runat="server" />
            <div class="hm_sec_2_content scrollbar">
                <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="fa fa-edit fa-fw icon-padding"></i>All Reports
                    </div>
                    <div class="col-md-12 bg-success">
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                    </div>
                </div>
                <div>
                    <div class="col-md-12">
                        <div class="row">
                            <div class="col-md-6">
                                  <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                From Date
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtFrom" CssClass="form-control" runat="server"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtFrom"
                                                    PopupButtonID="txtFrom" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" style="padding-top: 8px;">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                To Date
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtTo" CssClass="form-control" runat="server"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtTo"
                                                    PopupButtonID="txtTo" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                            </div>
                                        </div>
                                    </div>
                                <div class="col-md-12" style="padding-top: 8px;" >
                                <asp:Button ID="btnProcess" runat="server" Text="View Report" OnClick="btnProcess_Click" CssClass="btn btn-info  pull-right" />
                            </div></div>
                            <div class="col-md-6">
                                <fieldset>
                                    <legend style="line-height: 0;"><span style="background: #fff">LC Report</span></legend>
                                    <asp:RadioButton ID="rdbLCOpenReport" runat="server" Text="LC Open Report" GroupName="rpt_Prod" Checked="True" /><br />
                                     <asp:RadioButton ID="rdbContractLC" runat="server" Text="Contract LC Report" GroupName="rpt_Prod" /><br />
                                     <asp:RadioButton ID="rdbAmend" runat="server" Text="Amend LC Report" GroupName="rpt_Prod"  /><br />
                                    <asp:RadioButton ID="rdbOrderDetailsReport" runat="server" Text="Order Details Report" GroupName="rpt_Prod" /><br />
                                    <asp:RadioButton ID="rdbStyle" runat="server" Text="Style Report" GroupName="rpt_Prod" /><br />
                                </fieldset>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <script type="text/javascript">

        function func(result) {
            if (result === 'Data Save Successfully') {
                toastr.success(result);
            }
            else
                toastr.error(result);
            return false;
        }
    </script>
</asp:Content>
