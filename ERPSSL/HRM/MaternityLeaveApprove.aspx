<%@ Page Title="" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true" CodeBehind="MaternityLeaveApprove.aspx.cs" Inherits="ERPSSL.HRM.MaternityLeaveApprove" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <div class="panel">
        <div class="panel-heading panel-heading-01">
            <i class="fa fa-edit fa-fw icon-padding"></i>Maternity Leave Approve Form 
        </div>
    </div>
    <div class="hm_sec_2_content scrollbar">
         <div class="col-md-12" style="padding: 0px">
                <div class="col-md-9"></div>
                <div class="col-md-3">
                    <p>Leave Code :<asp:Label ID="lblLeaveId" runat="server"></asp:Label></p>
                </div>
            </div>
        <div class="col-md-12">
            <div class="alert alert-danger" style="padding: 0px; padding-left: 10px" role="alert">
                Applicant
            </div>
        </div>
        <div class="col-md-12">
            <div class="col-md-2">

                <div class="col-md-12" style="padding: 0px">
                    <div class="col-md-7">
                        E-ID:
                    </div>
                    <div class="col-md-5">
                        <asp:Label ID="lblApplicantId" runat="server"></asp:Label>
                        <asp:HiddenField ID="hidReportingBossID" runat="server" />
                    </div>
                </div>

            </div>
            <div class="col-md-4">
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-3">
                            Name:
                        </div>
                        <div class="col-md-8">
                            <asp:Label ID="lblApplicantName" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-6">
                            Department:
                        </div>
                        <div class="col-md-6">
                            <asp:Label ID="lblApplicantDepartment" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-3">

                <div class="col-md-12">
                    <div class="col-md-6">
                        Designation:
                    </div>
                    <div class="col-md-6">
                        <asp:Label ID="lblApplicantDesignation" runat="server"></asp:Label>
                    </div>
                </div>

            </div>
        </div>
        <div class="col-md-12">
            <div class="alert alert-danger" style="padding: 0px; padding-left: 10px" role="alert">
                Approve
            </div>
        </div>
        <div class="col-md-12">
            <asp:CheckBox ID="CheckBox1" runat="server" Text="Are you want to Update?" AutoPostBack="true"
                OnCheckedChanged="CheckBox1_CheckChanged" />
            <br />
        </div>
        <div class="col-md-12 bg-success">
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </div>
        <div class="col-md-12">
            <div class="row">
                <br />
                <div class="col-md-12">
                    <div class="col-md-3">
                        Applied Date :
                    </div>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtbbxAppliedDate" Class="form-control" runat="server"></asp:TextBox>

                        <asp:HiddenField ID="hidLeaveCode" runat="server" />
                    </div>
                </div>
            </div>
            <div class="row">
                <br />
                <div class="col-md-12">
                    <div class="col-md-3">
                        Leave Date From :
                    </div>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtbxLeaveDateFrom" Class="form-control" runat="server" ></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtbxLeaveDateFrom"
                            PopupButtonID="txtbxLeaveDateFrom" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />


                    </div>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-12">
                    <div class="col-md-3">
                        Leave Date To :
                    </div>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtbxLeaveDateTo" Class="form-control" runat="server" ></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtbxLeaveDateTo"
                            PopupButtonID="txtbxLeaveDateTo" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />

                    </div>
                </div>
            </div>
            <br />

            <div class="row">
                <div class="col-md-12">
                    <div class="col-md-3">
                        Total day:
                    </div>
                    <div class="col-md-6">
                        <asp:TextBox ID="txtbxTotalDay" runat="server"
                            Class="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-12">
                    <div class="col-md-3">
                        Description :
                    </div>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" Height="150px" ID="txtbxDexrcription" Class="form-control" TextMode="MultiLine" />
                    </div>
                </div>
            </div>
            <br />

            <div class="row">
                <div class="col-md-12">
                    <br />
                    <div class="col-md-3">
                    </div>
                    <div class="col-md-6">
                        <asp:Button ID="BtnAprove" runat="server" class="btn btn-primary" Text="Approve"
                            OnClick="BtnAprove_Click" />
                        <asp:Button ID="btnDisapporve" runat="server" class="btn btn-info  pull-right" Text="Disapprove"
                            OnClick="btnDisapporve_Click" />
                    </div>
                </div>
            </div>
            <br />
        </div>

    </div>

</asp:Content>
