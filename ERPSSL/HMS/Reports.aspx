<%@ Page Title="" Language="C#" MasterPageFile="~/HMS/HMS.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="ERPSSL.HMS.Reports" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
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
                                                                                 
                                    <div class="row" style="padding-left: 0px;">
                                        <div class="col-md-6" style="padding-left: 0px; padding-right: 0px;">
                                            <div class="col-md-12" style="padding-left: 0px;">
                                                <fieldset>
                                                    <legend style="line-height: 5px;"><span style="background: #fff">Select for Search</span></legend>
                                                    <div class="col-md-12" style="padding-left: 0px;">
                                                        <div class="col-md-6" style="padding-left: 0px;">
                                                            <div class="row">
                                                                <h5 style="padding-left: 20px;">Date From
                                                                </h5>
                                                                <div class="col-md-12">
                                                                    <asp:TextBox Class="form-control" runat="server" ID="txtDateFrom" autocomplete="off"
                                                                        placeholder="MM/dd/yyyy"></asp:TextBox>

                                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtDateFrom"
                                                                        PopupButtonID="Image_AT" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                                                </div>

                                                            </div>
                                                             <div class="row">
                                                                <h5 style="padding-left: 20px;">Patient ID
                                                                </h5>
                                                                <div class="col-md-12">
                                                                    <asp:TextBox Class="form-control" runat="server" ID="txtId" ></asp:TextBox>

                                                                 </div>

                                                            </div>
                                                        </div>
                                                        <div class="col-md-6" style="padding-left: 0px;">

                                                            <div class="row">
                                                                <h5 style="padding-left: 20px;">Date To                                                                </h5>
                                                                <div class="col-md-12">
                                                                    <asp:TextBox Class="form-control" runat="server" ID="txtbxToDate" autocomplete="off"
                                                                        placeholder="MM/dd/yyyy"></asp:TextBox>

                                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtbxToDate"
                                                                        PopupButtonID="Image_AT" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                                                </div>

                                                            </div>

                                                        </div>
                                                    </div>
                                                                                                
                                                </fieldset>

                                            </div>                                          
                                         
                                            <div class="col-md-12" style="">


                                                <asp:Button ID="btnProcess" runat="server" Text="View Report" Width="113px" CssClass="btn btn-info  pull-right" OnClick="btnProcess_Click" />
                                              
                                            </div>
                                        </div>
                                        <div class="col-md-6" style="padding-left: 0px;">
                                            <div class="col-md-12" style="padding-left: 0px;">

                                                <div class="row radio_input00">
                                                    <fieldset>
                                                        <legend style="line-height: 5px;"><span style="background: #fff">HMS Report</span></legend>
                                                        <div style="padding-top: 0px">

                                                            <asp:RadioButton ID="rdBillDetails" runat="server" Text=" Patient Bill Details" GroupName="rpt_patient" Checked="True" /><br />
                                                            <asp:RadioButton ID="rdbillByPatietId" runat="server" Text=" Patient Bill By ID Wise" GroupName="rpt_patient" /><br />
                                                            <asp:RadioButton ID="rdPatientSummary" runat="server" Text=" Patient Summary" GroupName="rpt_patient" /><br />
                                                            <asp:RadioButton ID="rdCollectionAmt" runat="server" Text=" Collection Amount Date Wise" GroupName="rpt_patient" /><br />
                                                            <asp:RadioButton ID="rdDischargePatient" runat="server" Text=" Discharge Patient Date Wise" GroupName="rpt_patient" /><br />
                                                        </div>
                                                    </fieldset>
                                                   
                                                  
                                                </div>

                                            </div>
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

