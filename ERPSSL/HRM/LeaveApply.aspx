﻿<%@ Page Title="" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true"  CodeBehind="LeaveApply.aspx.cs" Inherits="ERPSSL.HRM.LeaveApply" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

  <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ToolkitScriptManager1" />
    <%--<asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">

        <ContentTemplate>--%>
    <div class="hm_sec_2_content scrollbar">
        <div class="panel">
            <div class="panel-heading panel-heading-01">
                <i class="fa fa-edit fa-fw icon-padding"></i>Leave Apply
            </div>
        </div>
        <div class="row">
            <br />
            <fieldset>

                <div class="col-md-12">
                    <div class="col-md-4">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-5">
                                    E-ID  

                                </div>
                                <div class="col-md-7">
                                    <asp:TextBox ID="txtEid_TRNS" class="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEid_TRNS"
                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input E-ID No"
                                        ValidationGroup="EmployeeIDCard"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-5">
                                    Employee 
                                </div>
                                <div class="col-md-7">
                                    <asp:TextBox ID="txtEmpName_TRNS" class="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <br />


                    </div>
                    <div class="col-md-4">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-5">
                                    Department
                                </div>
                                <div class="col-md-7">
                                    <asp:TextBox ID="txtDepartment" class="form-control" runat="server"></asp:TextBox>
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
                                    <asp:TextBox ID="txtDesignation" class="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">


                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-6">
                                    Photo
                                </div>
                                <div class="col-md-6">
                                    <asp:Image ID="Emp_IMG_TR" CssClass="form-control" runat="server" class="avater_details" Height="80px" ImageUrl="resources/no_image.png"
                                        onerror="this.onerror=null; this.src='resources/no_image_found.png';" Width="80px" />
                                </div>
                            </div>
                        </div>


                    </div>

                </div>
            </fieldset>





           <div class="col-md-6" style="padding-left: 0px">
                <fieldset>

                    <legend style="line-height: 0;"><span style="background: #fff">Leave Apply</span></legend>

                    <div class="col-md-6">
                        <div class="row">
                            <div class="col-md-12">
                                <h6>Leave Type</h6>
                                <asp:DropDownList ID="drpLeaveType" Class="form-control" runat="server">
                                </asp:DropDownList>

                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <h6>From Date</h6>
                                <asp:TextBox runat="server" ID="txtbxFromDate" Class="form-control" placeholder="MM/dd/yyyy" />
                                <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtbxFromDate"
                                    PopupButtonID="txtbxFromDate" Format="MM/dd/yyyy" CssClass="ajax__calendar"
                                    Enabled="True" />
                            </div>
                        </div>

                        <%-- <div class="row">
                            <div class="col-md-12">
                                <h6>Reason/Remarks</h6>
                                <asp:TextBox ID="txtbxResion" runat="server" Class="form-control"></asp:TextBox>

                            </div>
                        </div>--%>
                        <div class="row" visible="false">
                            <div class="col-md-12">
                                <%--<h6>Approved Supervisor</h6>--%>
                                <asp:DropDownList ID="drpdwnApproveSupervisor" Class="form-control" runat="server" Visible="False">
                                </asp:DropDownList>

                            </div>
                        </div>


                    </div>
                    <div class="col-md-6">

                        <div class="row">
                            <div class="col-md-12">
                                <h6>Total Day</h6>
                                <asp:TextBox ID="txtbxTotalDay" ReadOnly="true" runat="server" Class="form-control"></asp:TextBox>

                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <h6>To Date</h6>
                                <asp:TextBox runat="server" OnTextChanged="txtbxToDate_TextChanged" AutoPostBack="True" ID="txtbxToDate" Class="form-control" placeholder="MM/dd/yyyy" />
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtbxToDate"
                                    PopupButtonID="txtTodate" Format="MM/dd/yyyy" CssClass="ajax__calendar"
                                    Enabled="True" />
                            </div>
                        </div>
                        <div class="row" visible="false">
                            <div class="col-md-12">
                                <%-- <h6>Approved Admin</h6>--%>
                                <asp:DropDownList ID="drpApprovedAdmin" Class="form-control" runat="server" Visible="False">
                                </asp:DropDownList>

                            </div>
                        </div>

                        <div class="row" visible="false">
                            <div class="col-md-12">
                                <%--   <h6>Approved HR</h6>--%>
                                <asp:DropDownList ID="drpApprovedHR" Class="form-control" runat="server" Visible="False">
                                </asp:DropDownList>

                            </div>
                        </div>




                    </div>

                    <div class="col-md-12">
                        <div class="row">
                            <div class="col-md-12">
                                <h6>Reason/Remarks</h6>
                                <asp:TextBox ID="txtbxResion" runat="server" Class="form-control"></asp:TextBox>

                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-8">
                        </div>
                        <div class="col-md-2">
                            <br />
                            <asp:Button ID="btnSave" runat="server" Text="Apply" class="btn btn-primary" OnClick="btnSave_click" Width="85px" />
                        </div>

                    </div>

                </fieldset>
            </div>




            <div class="col-md-6" style="padding-left: 0px">
                <fieldset>
                    <legend style="line-height: 0;"><span style="background: #fff">Leave Details</span></legend>
                    <table class="table table-bordered">
                        <tr class="info">
                            <td>Leave</td>
                            <td>CL</td>
                            <td>SL</td>
                            <td>AL</td>
                            <td id="mlHeader" runat="server">ML</td>
                            <td>Others</td>
                        </tr>
                        <tr>
                            <td>Total</td>
                            <td>
                                <asp:Label ID="lblCl" runat="server" Text=""></asp:Label></td>
                            <td>
                                <asp:Label ID="lblSl" runat="server" Text=""></asp:Label></td>

                            <td>
                                <asp:Label ID="lblAL" runat="server" Text=""></asp:Label></td>
                            <td id="rdToal" runat="server">
                                <asp:Label ID="lblML" runat="server" Text=""></asp:Label></td>
                            <td>
                                <asp:Label ID="lblLWP" runat="server" Text=""></asp:Label></td>

                        </tr>
                        <tr class="success">
                            <td>Enjoyed</td>
                            <td>
                                <asp:Label ID="lblCloE" runat="server" Text=""></asp:Label></td>
                            <td>
                                <asp:Label ID="lblSLE" runat="server" Text=""></asp:Label></td>

                            <td>
                                <asp:Label ID="lblALE" runat="server" Text=""></asp:Label></td>
                            <td id="tdMLE" runat="server">
                                <asp:Label ID="lblMLE" runat="server" Text=""></asp:Label></td>
                            <td>
                                <asp:Label ID="lblLWPE" runat="server" Text=""></asp:Label></td>

                        </tr>
                        <tr>
                            <td>Balance</td>
                            <td>
                                <asp:Label ID="lblClB" runat="server" Text=""></asp:Label></td>
                            <td>
                                <asp:Label ID="lblSLB" runat="server" Text=""></asp:Label></td>

                            <td>
                                <asp:Label ID="lblALB" runat="server" Text=""></asp:Label></td>
                            <td id="tdmlB" runat="server">
                                <asp:Label ID="lblMLB" runat="server" Text=""></asp:Label></td>
                            <td>
                                <asp:Label ID="lblLWPB" runat="server" Text=""></asp:Label></td>
                        </tr>

                        <tr>
                            <td>Pending</td>
                            <td>
                                <asp:Label ID="lblClP" runat="server" Text=""></asp:Label></td>
                            <td>
                                <asp:Label ID="lblSlP" runat="server" Text=""></asp:Label></td>

                            <td>
                                <asp:Label ID="lblAlP" runat="server" Text=""></asp:Label></td>
                            <td id="td1" runat="server">
                                <asp:Label ID="lblMlP" runat="server" Text=""></asp:Label></td>
                            <td>
                                <asp:Label ID="lblWpP" runat="server" Text=""></asp:Label></td>
                        </tr>

                    </table>
                </fieldset>
            </div>



        </div>



    </div>

    <script>

        function func(result) {

            if (result === 'This Employee is Inactive!') {
                toastr.error(result);
            }
            else if (result === 'Data Save Successfully!') {
                toastr.success(result);
            }
            else if (result === 'Please Input E-ID') {
                toastr.error(result);
            }
            else if (result === 'This Date Already Exist for Leave !') {
                toastr.error(result);
            }
            else if (result === 'Please Input From Date') {
                toastr.error(result);
            }
            else if (result === 'Please Input To Date') {
                toastr.error(result);
            }
            else if (result === "Please Select Leave Type") {
                toastr.error(result)
            }

            else
                toastr.error(result);
            return false;
        }

    </script>
</asp:Content>

