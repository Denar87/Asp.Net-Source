<%@ Page Title="" Language="C#" MasterPageFile="~/Production/Production.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="ERPSSL.Production.Report" %>

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
                                <%--<fieldset>
                                    <legend style="line-height: 0;"><span style="background: #fff">Production Report</span></legend>--%>
                                
                                <asp:Button ID="btnProcess" runat="server" Text="View Report" OnClick="btnProcess_Click" CssClass="btn btn-info  pull-right" />
                                
                                <%--</fieldset>--%>

                            </div>
                            <div class="col-md-6">
                                <fieldset>
                                    <legend style="line-height: 0;"><span style="background: #fff">Production Report</span></legend>
                                    <asp:RadioButton ID="rdDailyfactoryProduction" runat="server" Text="Daily factory Production" GroupName="rpt_Prod" Checked="True" /><br />
                                    <asp:RadioButton ID="rdbDailyProductionDetails" runat="server" Text="Daily Production Details" GroupName="rpt_Prod" /><br />
                                    <asp:RadioButton ID="rdbTna" runat="server" Text="TNA" GroupName="rpt_Prod" /><br />
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
