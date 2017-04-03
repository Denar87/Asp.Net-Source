<%@ Page Title="Attendance" Language="C#" MasterPageFile="~/PAYROLL/Site.Master" AutoEventWireup="true"
    CodeBehind="BankAdvice.aspx.cs" Inherits="ERPSSL.PAYROLL.BankAdvice" %>

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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <script src="content/js/bootstrap-datetimepicker.js" type="text/javascript"></script>
    <link href="content/css/bootstrap-datetimepicker.min.css" rel="stylesheet" type="text/css" />
    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>
            <div class="hm_sec_2_content scrollbar">
                <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="fa fa-edit fa-fw icon-padding"></i>Bank Advice Generate
                    </div>
                    <div class="col-md-12 bg-success">
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">

                        <%--<div class="col-md-6">
                        <div class="alert alert-danger" style="padding: 0px; padding-left: 10px; font-weight: bold" role="alert">
                            Select Employee
                        </div>
                    </div>--%>
                        <div class="col-md-6">
                            <div class="panel panel-info">
                                <div class="panel-heading " style="background-color: #778899; color: white">Office Details </div>
                                <div class="panel-body" style="font-size: 11px; height: 220px; color: green; margin-top: 0px; margin-bottom: 0px;">


                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                Region
                                            </div>
                                            <div class="col-md-8">
                                                <asp:DropDownList ID="ddlRegion" CssClass="form-control" runat="server"
                                                    AutoPostBack="True" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:HiddenField ID="hiadvanceSalaryId" runat="server" />
                                                <asp:HiddenField ID="hiAdCode" runat="server" />
                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator16" ValidationGroup="Group2"
                                                runat="server" ControlToValidate="ddlRegion" ErrorMessage="Select Region" InitialValue="0"></asp:RequiredFieldValidator>--%>
                                            </div>
                                        </div>
                                    </div>
                                    <br />

                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                Office
                                            </div>
                                            <div class="col-md-8">
                                                <asp:DropDownList ID="ddlOffice" CssClass="form-control" runat="server"
                                                    AutoPostBack="True" OnSelectedIndexChanged="ddlOffice_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Group2"
                                                    runat="server" ControlToValidate="ddlOffice" ErrorMessage="Select Office" InitialValue="0"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                Department
                                            </div>
                                            <div class="col-md-8">
                                                <asp:DropDownList ID="drpDepartment" CssClass="form-control" runat="server">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Group2"
                                                    runat="server" ControlToValidate="drpDepartment" ErrorMessage="Select Department" InitialValue="0"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                Date 
                                            </div>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtDateFrom" class="form-control" placeholder="dd/MM/yyyy" runat="server"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDateFrom"
                                                    PopupButtonID="Image_AT" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="panel panel-info">
                                <div class="panel-heading " style="background-color: #778899; color: white">Employee Details </div>
                                <div class="panel-body" style="font-size: 11px; height: 220px; color: green; margin-top: 0px; margin-bottom: 0px;">


                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                E-ID
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtEid_TRNS" class="form-control" runat="server" OnTextChanged="txtEid_TRNS_TextChanged" AutoPostBack="True"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Name
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtEmpName_TRNS" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />

                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Department
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtDepartment" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Designation
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtDesignation" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <%--<br />
                       
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-5">
                                        Photo
                                    </div>
                                    <div class="col-md-7">
                                        <asp:Image ID="Emp_IMG_TRNS" ImageUrl="resources/no_image.png" CssClass="img-thumbnail" Width="120px" Height="120px"
                                            runat="server" />
                                    </div>
                                </div>
                            </div>--%>
                                </div>
                            </div>

                        </div>

                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-12" <%--style="float: right; overflow: hidden"--%>>

                        <%-- <div class="col-md-2" >--%>
                        

                        <asp:Button ID="btnPrint" runat="server" Text="Print" class="btn btn-danger pull right" OnClick="btnPrint_Click" style="margin-right:17px"/>
                        <asp:Button ID="btnUpdate" runat="server" Text="Generate" class="btn btn-info pull right" ValidationGroup="Group1" OnClick="btnUpdate_Click" style="margin-right:15px"/>
                        <%-- </div>--%>
                    </div>
                </div>


                <div class="col-md-12">
                    <fieldset style="border-color:skyblue">
                        <legend style="line-height: 5px; border-color:skyblue"><span style="background: #fff">Bank Advice</legend>
                        <asp:GridView ID="GridViewEMP_AT" runat="server" AutoGenerateColumns="False" Width="100%"
                            EmptyDataText="No Records Found!" AllowPaging="True" AllowSorting="True" CellPadding="5"
                            DataKeyNames="EID" OnPageIndexChanging="GridViewEMP_AT_PageIndexChanging" PageSize="50">
                            <Columns>

                                <asp:BoundField DataField="EID" HeaderText="E-ID">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblatEmpname" runat="server" Text='<%# Bind("FullName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                    <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="15%" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:TemplateField>

                                <asp:BoundField DataField="DEG_NAME" HeaderText="Deg">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>
                                <asp:BoundField DataField="BankName" HeaderText="Bank Name">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>
                                <asp:BoundField DataField="AccountNo" HeaderText="Account No">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>

                                <asp:BoundField DataField="Total_Gross_Sal" HeaderText="Gross Salary">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>



                            </Columns>
                            <EmptyDataRowStyle ForeColor="Red" />
                            <RowStyle CssClass="Grid_RowStyle" />
                            <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                            <PagerSettings Mode="NumericFirstLast" />
                            <PagerStyle ForeColor="#000066" HorizontalAlign="Left" BackColor="White" CssClass="pagination01 pageback" />
                            <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" HorizontalAlign="Center" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:GridView>
                        <br />

                        </span>

                    </fieldset>
                </div>


                <div class="col-md-12">

                    <center>
                        <rsweb:ReportViewer ID="ReportViewerBankAdvice" AsyncRendering="False" InteractiveDeviceInfos="(Collection)"
                            SizeToReportContent="True" Width="100%" Height="700px" runat="server" Font-Names="Verdana"
                            Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" BackColor="White">
                        </rsweb:ReportViewer>
                    </center>


                </div>
            </div>

        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnUpdate" EventName="Click" />

        </Triggers>
    </asp:UpdatePanel>

    <script type="text/javascript">

        function func(result) {

            if (result === 'No Data Found!') {
                toastr.error(result);
            }
            else
                toastr.error(result);

            return false;
        }
    </script>

</asp:Content>
