<%@ Page Title="" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true" CodeBehind="MaternityLeaveByEid.aspx.cs" Inherits="ERPSSL.HRM.MaternityLeaveByEid" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
      <toolkitscriptmanager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
     
 <%--   <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
<ContentTemplate>--%>

    <div class="row">
        
        <div class="hm_sec_2_content scrollbar">
            <div class="panel">
            <div class="panel-heading panel-heading-01">
                <i class="fa fa-edit fa-fw icon-padding"></i>Maternity Leave Form
            </div>
            <div class="col-md-12 bg-success">
                <asp:Label ID="lblMessege" runat="server"></asp:Label>
            </div>
        </div>
            <div class="col-md-12" style="padding: 0px">
                <div class="col-md-6">
                      <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-3">
                            Applicant ID 
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtEIdNo" runat="server" ontextchanged="txtEIdNo_TextChanged" AutoPostBack="True" Class="form-control"></asp:TextBox>
                           
                        </div>
                    </div>
                </div>
                </div>
                <div class="col-md-3">
                    </div>
                <div class="col-md-3">
                    <p>Leave Code :<asp:Label ID="lblLeaveId" runat="server"></asp:Label></p>
                </div>
            </div>
            <div class="row">
                <br />
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
                    <br />
                    <div class="alert alert-danger" style="padding: 0px; padding-left: 10px" role="alert">
                        Maternity Leave Info
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="col-md-6">

                        <div class="col-md-5">
                            Total Maternity Leave:
                        </div>
                        <div class="col-md-6" style="padding: 0px">
                            <asp:Label ID="lblTotalMaternityLeave" runat="server"></asp:Label>
                        </div>

                    </div>

                </div>
                <div class="col-md-12">
                    <br />
                    <div class="alert alert-danger" style="padding: 0px" role="alert">
                        Details Of Event
                    </div>
                    <div class="col-md-12 bg-success">
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </div>
                  
                    <div class="col-md-6">
                          <br />
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-5">
                                    Applied 
                                </div>
                                <div class="col-md-6">
                                    <asp:Label ID="lblDateApplied" runat="server"></asp:Label>
                                    <asp:HiddenField ID="hidLeaveId" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <br />
                            <div class="col-md-12">
                                <div class="col-md-5">
                                    Leave Date From 
                                </div>
                                <div class="col-md-6">
                                    <asp:TextBox runat="server" ID="txtbxLeaveDateFrom" Class="form-control" placeholder="MM/dd/yyyy" OnTextChanged="txtbxLeaveDateTo_TextChanged" AutoPostBack="True" />
                                    <calendarextender ID="CalendarExtender2" runat="server" TargetControlID="txtbxLeaveDateFrom"
                                        PopupButtonID="txtbxLeaveDateFrom" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />

                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <br />
                            <div class="col-md-12">
                                <div class="col-md-5">
                                    Leave Date To 
                                </div>
                                <div class="col-md-6">
                                    <asp:TextBox runat="server" ID="txtbxLeaveDateTo" Class="form-control" placeholder="MM/dd/yyyy" OnTextChanged="txtbxLeaveDateTo_TextChanged" AutoPostBack="True" />
                                    <calendarextender ID="CalendarExtender1" runat="server" TargetControlID="txtbxLeaveDateTo"
                                        PopupButtonID="txtbxLeaveDateTo" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />

                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <br />
                            <div class="col-md-12">
                                <div class="col-md-5">
                                    Description
                                </div>
                                <div class="col-md-6">
                                    <asp:TextBox runat="server" Height="150px" ID="txtbxDexrcription" Class="form-control" TextMode="MultiLine" placeholder="Description" />

                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="col-md-12">
                    <br />
                    <asp:GridView ID="gridviewLeaveInfo" runat="server" AutoGenerateColumns="False" Width="100%"
                        CellPadding="5" AllowPaging="True">
                        <Columns>
                            <asp:TemplateField Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblMaternityLeaveId" runat="server" Text='<%# Eval("MaternityLeaveId")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="AppliedDate" HeaderText="Applied">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                            <asp:BoundField DataField="LeaveDateFrom" HeaderText="Leave Date From">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                            <asp:BoundField DataField="LeaveDateTo" HeaderText="Leave Date To">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TotalDay" HeaderText="Total Day">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                            
                             <asp:BoundField DataField="ReportingBossName" HeaderText="Reporting Boss Name">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>

                            <asp:TemplateField HeaderText="Leve Status">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkStatus" CssClass="btn btn-info  pull-right" CommandArgument='<%# Eval("ApproveStatus") %>'
                                        runat="server"><%# Eval("ApproveStatus")%></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="DisApprove Status">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkStatus" CssClass="btn btn-info  pull-right" CommandArgument='<%# Eval("DisApproveStatus") %>'
                                        runat="server"><%# Eval("DisApproveStatus")%></asp:LinkButton>
                                </ItemTemplate>
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
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <br />
                        <div class="col-md-2">
                        </div>
                        <div class="col-md-6">
                            <asp:Button ID="BtnLeaveSubmit" runat="server" class="btn btn-info  pull-right"
                                Text="Submit" OnClick="BtnLeaveSubmit_Click" />
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
  <%--  </ContentTemplate>

<Triggers>
 <asp:AsyncPostBackTrigger ControlID="BtnLeaveSubmit" EventName="Click" />
<asp:AsyncPostBackTrigger ControlID="txtEIdNo" EventName="TextChanged" />
</Triggers>
</asp:UpdatePanel>--%>
</asp:Content>
