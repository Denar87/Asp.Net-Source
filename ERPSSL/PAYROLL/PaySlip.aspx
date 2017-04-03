<%@ Page Title="Payroll" Language="C#" MasterPageFile="~/PAYROLL/Site.Master" AutoEventWireup="true"
    CodeBehind="PaySlip.aspx.cs" Inherits="ERPSSL.PAYROLL.PaySlip" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .time_section input {
            width: 27px !important;
            height: auto !important;
            text-align: center;
            border: none !important;
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
    <%-- <script language="javascript" type="text/javascript">
        function printDiv(divID) {
            //Get the HTML of div
            var divElements = document.getElementById(divID).innerHTML;
            //Get the HTML of whole page
            var oldPage = document.body.innerHTML;

            //Reset the page's HTML with div's HTML only
            document.body.innerHTML =
                "<html><head><title></title></head><body>" +
                divElements + "</body>";

            //Print Page
            window.print();

            //Restore orignal HTML
            document.body.innerHTML = oldPage;
        }
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <script src="content/js/bootstrap-datetimepicker.js" type="text/javascript"></script>
    <link href="content/css/bootstrap-datetimepicker.min.css" rel="stylesheet" type="text/css" />
    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>
     <asp:UpdateProgress ID="UpdWaitImage" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="UpdatePanel8">
                <ProgressTemplate>
                    <div class="LoaderBackground_">
                        <asp:Image ID="Image1" runat="server" CssClass="LoaderBackground_Image" ImageUrl="../content/image/busy.gif" />
                    </div>

                </ProgressTemplate>
            </asp:UpdateProgress>
    <div class="hm_sec_2_content scrollbar">
        <div class="panel">
            <div class="panel-heading panel-heading-01">
                <i class="fa fa-edit fa-fw icon-padding"></i>Pay Slip
            </div>
            <div class="col-md-12 bg-success">
                <asp:Label ID="lblMessege" runat="server"></asp:Label>
            </div>
        </div>
        <%-- <div class="row">--%>
        <%--<div class="col-md-12">--%>
        <fieldset style="border: none">
            <div class="col-md-12">            
                <div class="col-md-6">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="row">
                            <div class="col-md-3">
                                Salary Month
                            </div>
                            <div class="col-md-9">
                                <asp:TextBox runat="server" ID="txtbxFrom" Class="form-control" placeholder="MM/dd/yyyy" />
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtbxFrom"
                                    PopupButtonID="txtbxFrom" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtbxFrom"
                                    Display="Dynamic" ErrorMessage="Select first Date" ForeColor="Red" SetFocusOnError="True" Font-Size="11px"
                                    ValidationGroup="validation_AT"></asp:RequiredFieldValidator>
                            </div>
                                </div>
                        </div>
                         <div class="col-md-12" style="padding-top:8px;">

                                            <div class="row">
                                                <div class="col-md-3">
                                                    Region
                                                </div>
                                                <div class="col-md-9">
                                                    <asp:DropDownList ID="ddlRegion1" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="drpdwnResion1ForDepartmentSelecttedIndexChanged"
                                                        runat="server">
                                                    </asp:DropDownList>                                                   
                                                </div>
                                            </div>
                                        </div>
                                       <div class="col-md-12" style="padding-top:8px;">
                                            <div class="row">
                                                <div class="col-md-3">
                                                    Office
                                                </div>
                                                <div class="col-md-9">
                                                    <asp:DropDownList ID="ddlOffice1" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="onSelectedIndedexChangeOffice1"
                                                        runat="server">
                                                    </asp:DropDownList>                                                   
                                                </div>
                                            </div>

                                        </div>
                                        <div class="col-md-12" style="padding-top:8px;">

                                            <div class="row">
                                                <div class="col-md-3">
                                                    Department
                                                </div>
                                                <div class="col-md-9">
                                                    <asp:DropDownList ID="ddlDept1" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="drpdwnDepartment1SelectedIndexChange"
                                                        runat="server">
                                                    </asp:DropDownList>                                                  
                                                </div>
                                            </div>
                                        </div>
                                       <div class="col-md-12" style="padding-top:8px;">
                                            <div class="row">
                                                <div class="col-md-3">
                                                    Section
                                                </div>
                                                <div class="col-md-9">
                                                    <asp:DropDownList ID="ddlSection" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="ddlSection_SelecttedIndexChanged"
                                                        runat="server">
                                                    </asp:DropDownList>                                                    
                                                </div>
                                            </div>
                                        </div>
                                       <div class="col-md-12" style="padding-top:8px;">
                                            <div class="row">
                                                <div class="col-md-3">
                                                    Sub-Section
                                                </div>
                                                <div class="col-md-9">
                                                    <asp:DropDownList ID="ddlSubSections"  CssClass="form-control"
                                                        runat="server">
                                                    </asp:DropDownList>                                               
                                                </div>
                                            </div>
                                        </div>
                    </div>
                </div>

                    <div class="col-md-6">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-6">
                                Pay Slip Print Type
                            </div>
                            <div class="col-md-6">
                                <asp:RadioButton ID="rdbAll" runat="server" Text="All" GroupName="ATN" Checked="true" />&nbsp&nbsp&nbsp&nbsp&nbsp
                                <asp:RadioButton ID="rdbIndividual" runat="server" Text="Individual" GroupName="ATN" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </fieldset>
        <%-- </div>--%>


        <fieldset>
            <legend style="line-height: 5px;"><span style="background: #fff">Select Employee</span></legend>
            <div class="col-md-12">
                <div class="col-md-6">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-6">
                                E-ID
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtEid_AT" Class="form-control" runat="server" AutoPostBack="True"
                                    OnTextChanged="txtEid_AT_TextChanged"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtEid_AT"
                                    Display="Dynamic" ForeColor="Red" Font-Size="11px" SetFocusOnError="True" ErrorMessage="Input EID"
                                    ValidationGroup="validation_AT"></asp:RequiredFieldValidator>--%>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-6">
                                Name
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtEmpName_AT" Class="form-control" runat="server" Enabled="False"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-6">
                                Department
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtDepartment_AT" Class="form-control" runat="server" Enabled="False"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-6">
                                Designation
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtDesignation_AT" Class="form-control" runat="server" Enabled="False"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <br />
                </div>
            </div>
        </fieldset>

        <fieldset style="border: none">
            <div class="col-md-12">
                <div class="col-md-6">
                </div>
                <div class="col-md-6">
                    <div class="col-md-8">
                    </div>
                    <div class="col-md-4">
                        <asp:Button ID="btnProcess" runat="server" Text="Process" Width="80px" OnClick="btnProcess_Click" ValidationGroup="validation_AT"
                            CssClass="btn btn-info  pull-right" />
                    </div>
                </div>
            </div>
        </fieldset>

        <%--  <fieldset style="border: none">
            <div class="col-md-12">
                <div class="col-md-6">
                </div>
                <div class="col-md-6">
                    <div class="col-md-8">
                    </div>
                    <div class="col-md-4">
                        <input type="button" class="btn btn-primary  pull-right" value="Print" onclick="javascript: printDiv('printablediv')" />
                    </div>
                </div>
            </div>
        </fieldset>--%>

        <fieldset style="border: none">
            <div class="col-md-12" id="printablediv" style="clear: both;">
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%"
                    Font-Names="Verdana" Font-Size="8pt" InteractiveDeviceInfos="(Collection)"
                    WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="500px"
                    PageCountMode="Actual" AsyncRendering="False" ShowFindControls="false"
                    InteractivityPostBackMode="AlwaysSynchronous">
                </rsweb:ReportViewer>
            </div>
        </fieldset>
        <%--  </div>--%>
    </div>
            </ContentTemplate>
        </asp:UpdatePanel>
      <script type="text/javascript">

          function func(result) {
              if (result === 'Data Processed Successfully') {
                  toastr.success(result);
              }
              else
                  toastr.error(result);

              return false;
          }

    </script>
</asp:Content>
