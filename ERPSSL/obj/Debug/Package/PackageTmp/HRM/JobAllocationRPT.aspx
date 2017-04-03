<%@ Page Title="" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true" CodeBehind="JobAllocationRPT.aspx.cs" Inherits="ERPSSL.HRM.JobAllocationRPT" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    
    <div class="row">
       
        <div class="hm_sec_2_content scrollbar">
             <div class="panel">
        <div class="panel-heading panel-heading-01">
            <i class="fa fa-edit fa-fw icon-padding"></i>Job Allocation Reports
        </div>
    </div>
            <div class="col-md-12">
                <br />
               <%-- <fieldset>--%>
                    <%--<legend style="line-height: 0;"><span style="background: #fff">Job Allocation Report</span></legend>--%>
                    <asp:Label ID="lblHiddenId" runat="server" Visible="false"></asp:Label>
                    <div class="col-md-12">
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-5">
                                    From 
                                </div>
                                <div class="col-md-7">
                                    <asp:TextBox runat="server" ID="txtbxFrom" Class="form-control" placeholder="MM/dd/yyyy" />
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtbxFrom"
                                        PopupButtonID="txtbxFrom" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtbxFrom" SetFocusOnError="True" ValidationGroup="vJobAllocationRPT"></asp:RequiredFieldValidator>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-5">
                                    To 
                                </div>
                                <div class="col-md-7">
                                    <asp:TextBox runat="server" ID="txtbxTo" Class="form-control" placeholder="MM/dd/yyyy" />
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtbxTo"
                                        PopupButtonID="txtbxTo" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtbxTo" SetFocusOnError="True" ValidationGroup="vJobAllocationRPT"></asp:RequiredFieldValidator>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-5">
                                    Region
                                </div>
                                <div class="col-md-7">
                                    <asp:DropDownList ID="ddlRegions" AutoPostBack="True" OnSelectedIndexChanged="drpdwnResionForDepartmentSelecttedIndexChanged" CssClass="form-control"
                                        runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-5">
                                    Office
                                </div>
                                <div class="col-md-7">
                                    <asp:DropDownList ID="drpOffice" AutoPostBack="True" OnSelectedIndexChanged="onSelectedIndedexChangeOffice" CssClass="form-control"
                                        runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-5">
                                    Department
                                </div>
                                <div class="col-md-7">
                                    <asp:DropDownList ID="depDepartment" CssClass="form-control"
                                        runat="server" AutoPostBack="True" OnSelectedIndexChanged="depDepartment_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <fieldset>
                               <%-- <legend style="line-height: 0;"><span style="background: #fff">Client Info</span></legend>--%>
                                <div class="row">
                                    <div class="col-md-5">
                                        Client Name
                                    </div>
                                    <div class="col-md-7">
                                        <asp:DropDownList ID="drpClient" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="drpClient_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>
                            </fieldset>
                            <br />
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div>
                                        <asp:RadioButton ID="rdAllClient" runat="server" Text="All Client Job allocation" GroupName="rpt_emp"
                                            Checked="True" Font-Bold="True" /><br />
                                        <asp:RadioButton ID="rdIndividualClient" runat="server" Text="Client wise Job allocation" GroupName="rpt_emp"
                                            Font-Bold="True" /><br />

                                        <asp:RadioButton ID="rdRegionWiseEmployee" runat="server" Text="Region wise Job allocation" GroupName="rpt_emp"
                                            Font-Bold="True" /><br />
                                        <asp:RadioButton ID="rdOfficewiseEmployee" runat="server" Text="Office wise Job allocation" GroupName="rpt_emp"
                                            Font-Bold="True" /><br />
                                        <asp:RadioButton ID="rdDeptWiseEmployee" runat="server" Text="Department wise Job allocation" GroupName="rpt_emp"
                                            Font-Bold="True" /><br />
                                    </div>
                                    <br />
                                    <div class="col-md-12">
                                        <asp:Button ID="btnProcess" runat="server" Text="Process" Width="80px"
                                            CssClass="btn btn-info pull-right" OnClick="btnProcess_Click" ValidationGroup="vJobAllocationRPT" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
               <%-- </fieldset>--%>
            </div>
        </div>
    </div>

</asp:Content>
