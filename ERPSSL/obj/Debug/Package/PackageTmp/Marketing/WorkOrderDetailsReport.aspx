<%@ Page Title="" Language="C#" MasterPageFile="~/Marketing/Marketing.Master" AutoEventWireup="true" CodeBehind="WorkOrderDetailsReport.aspx.cs" Inherits="ERPSSL.Marketing.WorkOrderDetailsReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
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

            <div class="row">
                <div class="hm_sec_2_content scrollbar">
                    <div class="panel">
                        <div class="panel-heading panel-heading-01">
                            <i class="glyphicon glyphicon-edit icon-padding"></i>Client Visit Report
                        </div>
                    </div>
                    <div class="col-md-12 bg-success">
                        <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label>
                        <asp:Label ID="lblMessageUpdate" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label>
                    </div>


                    <div>
                    <div class="col-md-12">
                        <div class="row">
                            <div class="col-md-3">

                            </div>
                            <div class="col-md-6">
                                <%--<fieldset>
                                    <legend style="line-height: 0;"><span style="background: #fff">Production Report</span></legend>--%>
                                <div id="div1" class="row">

                                    <div class="col-md-6">
                                        <asp:Label ID="lblfrom" runat="server">From Date</asp:Label>
                                        <asp:TextBox ID="txtFromDate" CssClass="form-control" placeholder="MM/dd/yyyy" runat="server"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFromDate"
                                            PopupButtonID="txtFromDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorFromDate" runat="server" ErrorMessage="Input From Date" ValidationGroup="marketing" ControlToValidate="txtFromDate" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:Label ID="lblToDate" runat="server">To Date</asp:Label>
                                        <asp:TextBox ID="txtToDate" CssClass="form-control" placeholder="MM/dd/yyyy" runat="server"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtToDate"
                                            PopupButtonID="txtToDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorToDate" runat="server" ErrorMessage="Input To Date" ValidationGroup="marketing" ControlToValidate="txtToDate" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                </div>


                                <div class="row">
                                     <div class="col-md-6">
                                      <%--  <asp:Label ID="lblMarketingPersonOrStage" runat="server">Select Marketing Person/ Stage</asp:Label>
                                        <asp:DropDownList ID="mpsDropDownList" AppendDataBoundItems="True" CssClass="form-control" runat="server">
                                        </asp:DropDownList>--%>
                                    </div>
                                    <div class="col-md-6" style="padding-top: 5px;">
                                        <asp:Button ID="btnProcess" ValidationGroup="marketing" runat="server" Text="View Report" CssClass="btn btn-info  pull-right" OnClick="btnProcess_Click" />
                                    </div>
                                </div>
                                <%--</fieldset>--%>
                            </div>
                            
                        </div>

                    </div>

                    <div class="col-md-12">
                        <%-- Report Viewer Here --%>
                        <rsweb:ReportViewer ID="WorkOrderDetailsReportViewer" runat="server" Width="800px" style="width:1050px;"></rsweb:ReportViewer>
                    </div>
                </div>


                </div>
            </div>
        </ContentTemplate>

    </asp:UpdatePanel>
    <script type="text/javascript">
        function func(result) {
            if (result === 'Data Saved Successfully') {
                toastr.success(result);

            }
            else if (result === 'Data Post Successfully !') {
                toastr.success(result);
            }
            else if (result === 'Data Already Exist') {
                toastr.error(result);
            }

            else if (result === 'Data Updated Successfully') {
                toastr.success(result);
            }
            else if (result === 'Data Updating failure') {
                toastr.error(result);
            }
            else
                toastr.error(result);

            return false;
        }

    </script>

</asp:Content>
