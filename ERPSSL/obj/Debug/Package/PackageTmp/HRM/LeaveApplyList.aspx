<%@ Page Title="" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true"
    CodeBehind="LeaveApplyList.aspx.cs" Inherits="ERPSSL.HRM.LeaveApplyList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ToolkitScriptManager1" />


    <div class="hm_sec_2_content scrollbar">
        <div class="panel">
            <div class="panel-heading panel-heading-01">
                <i class="fa fa-edit fa-fw icon-padding"></i>Leave Apply List For HRM
            </div>
        </div>
        <div class="col-md-12">
            <div class="col-md-6">
                <asp:HiddenField ID="hidLeaveCode" runat="server" />
                <asp:HiddenField ID="hidAppliedDate" runat="server" />
                <asp:GridView ID="gridviewLeaveInfo" runat="server" AutoGenerateColumns="False" Width="100%"
                    CellPadding="5" AllowPaging="True">
                    <Columns>

                        <asp:TemplateField Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblLeaveCode" runat="server" Text='<%# Eval("LeaveCode")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblEid" runat="server" Text='<%# Eval("Eid")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Eid" HeaderText="Eid">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>

                        <asp:BoundField DataField="FullName" HeaderText="Full-Name">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Designation" HeaderText="Designation">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>

                        <asp:BoundField DataField="Department" HeaderText="Department">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>



                        <asp:BoundField DataField="LeaveAppliedDate" HeaderText="Applied">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:BoundField DataField="LeaveDates" HeaderText="Leave Dates">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:BoundField DataField="LeaveType" HeaderText="Leave Type">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TotalDay" HeaderText="Total Day">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="View">
                            <ItemTemplate>
                                <asp:Button ID="btnaprove" runat="server" Text="View" CssClass="btn btn-info  pull-right" OnClick="btnaprove_Click" />
                            </ItemTemplate>
                            <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataRowStyle ForeColor="Red" />
                    <RowStyle CssClass="Grid_RowStyle" />
                    <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                    <PagerSettings Mode="NumericFirstLast" />
                    <PagerStyle ForeColor="#000066" HorizontalAlign="Left" BackColor="White" CssClass="pagination01 pageback" />
                    <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" />
                    <FooterStyle CssClass="Grid_Footer" />
                </asp:GridView>
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

                    </table>
                </fieldset>
                <fieldset>

                    <legend style="line-height: 0;"><span style="background: #fff">Leave Apply</span></legend>

                    <div class="col-md-6">
                        <div class="row">
                            <asp:HiddenField ID="hidEid" runat="server" />
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

                        <div class="col-md-12">
                                  <div class="col-md-offset-6 col-md-6">  
                                      <br />                           
                                <asp:Button ID="btnSave" runat="server" Text="Approve" class="btn btn-primary pull-left" OnClick="btnSave_click" Width="90px" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-danger pull-right" OnClick="btnCancel_click" Width="90px" />
                            </div>
                        </div>
                    </div>

                </fieldset>

            </div>
        </div>
    </div>

    <script type="text/javascript">
        function func(result) {

            if (result === 'Level Cancel Successfully!') {
                toastr.success(result);
            }
            else if (result == 'Leave Approved Successfully') {
                toastr.success(result);
            }
            else
                toastr.error(result);

            return false;
        }
    </script>



</asp:Content>
