<%@ Page Title="" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true" CodeBehind="MachineReadableProblem.aspx.cs" Inherits="ERPSSL.HRM.MachineReadableProblem" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .time_section input
        {
            width: 27px !important;
            height: auto !important;
            text-align: center;
            border: none !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>
            <div class="hm_sec_2_content scrollbar">
                <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="fa fa-edit fa-fw icon-padding"></i>Attendance for Machine Readable Problem
                    </div>
                </div>
                <div class="col-md-12 bg-success">
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </div>
                <div class="row">
                    <fieldset style="border: none;">
                        <div class="col-md-12">
                            <div class="col-md-6">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Shift<span style="color: #f00;">*</span>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="ddlShiftCode" AutoPostBack="True" CssClass="form-control"
                                                runat="server" OnSelectedIndexChanged="ddlShiftCode_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlShiftCode"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select a Shift Code"
                                                Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Region
                                        </div>
                                        <div class="col-md-7">
                                            <asp:Label ID="lblRegionId" runat="server" Visible="false"></asp:Label>
                                            <asp:TextBox ID="txtRegion" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                            <%--<asp:DropDownList ID="ddlRegion" AutoPostBack="True" CssClass="form-control"
                                                runat="server" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged">
                                            </asp:DropDownList>--%>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Office
                                        </div>
                                        <div class="col-md-7">
                                            <asp:Label ID="lblOfficeId" runat="server" Visible="false"></asp:Label>
                                            <asp:TextBox ID="txtOffice" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                            <%--<asp:DropDownList ID="ddlOffice" CssClass="form-control" AutoPostBack="true"
                                                runat="server">
                                            </asp:DropDownList>--%>
                                        </div>
                                    </div>
                                </div>
                                <br />

                                <%--<div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Shift
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtShift" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>

                                        </div>
                                    </div>
                                </div>
                                <br />--%>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Date<span style="color: #f00;">*</span>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox Class="form-control" runat="server" ID="txtDate" autocomplete="off"
                                                placeholder="MM/dd/yyyy"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDate"
                                                Display="Dynamic" ErrorMessage="Select Reason Date" ForeColor="Red" SetFocusOnError="True"
                                                ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDate"
                                                PopupButtonID="Image_AT" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                        </div>
                                    </div>
                                </div>
                                <br />

                            </div>
                            <div class="col-md-6">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            First In Time<span style="color: #f00;">*</span>
                                        </div>
                                        <div class="col-md-7">
                                            <div class="form-control">
                                                <cc1:TimeSelector ID="txtStartTime" runat="server" Hour="09" Minute="00" Second="00" CssClass="time_section" SelectedTimeFormat="TwentyFour"
                                                    AllowSecondEditing="True" AmPm="AM" BorderColor="Silver"
                                                    Date="01/01/0001 09:00:00">
                                                </cc1:TimeSelector>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Last Out Time<span style="color: #f00;">*</span>
                                        </div>
                                        <div class="col-md-7">
                                            <div class="form-control">
                                                <cc1:TimeSelector ID="txtEndTime" runat="server" AllowSecondEditing="True" AmPm="PM" CssClass="time_section" SelectedTimeFormat="TwentyFour"
                                                    BorderColor="Silver" Date="01/01/0001 09:00:00" Hour="9" Minute="0" Second="0">
                                                </cc1:TimeSelector>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Working Day<span style="color: #f00;">*</span>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="ddlWorkingDay" CssClass="form-control"
                                                runat="server">
                                                <asp:ListItem Value="0" Text="------ Select One ------"></asp:ListItem>
                                                <asp:ListItem Value="General">General</asp:ListItem>
                                                <asp:ListItem Value="Holiday">Holiday</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlWorkingDay"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select a Working Day"
                                                Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Remarks<span style="color: #f00;">*</span>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtRemarks" CssClass="form-control" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtRemarks"
                                                Display="Dynamic" ForeColor="Red" Font-Size="11px" SetFocusOnError="True" ErrorMessage="Input Remarks"
                                                ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>

                                <div class="row ">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                        </div>
                                        <div class="col-md-7">
                                            <asp:Button ID="BtnSave" runat="server" Text="Save" ValidationGroup="Group1" Style="margin-top: 15px;"
                                                class="btn btn-info pull-right" OnClick="BtnSave_Click" />
                                        </div>
                                    </div>
                                </div>
                                
                            </div>
                        </div>
                    </fieldset>
                    <div class="col-md-12">
                        <fieldset>
                            <legend style="line-height: 0;"><span style="background: #fff">Office Attendance List</span></legend>
                            <asp:GridView ID="gridviewMachineProblem" runat="server" AutoGenerateColumns="False" Width="100%"
                                CellPadding="5" AllowPaging="True" OnPageIndexChanging="gridviewMachineProblem_PageIndexChanging" PageSize="100">
                                <Columns>
                                    <asp:TemplateField Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblId" runat="server" Text='<%# Eval("MachineProblem_Id")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ShiftCode" HeaderText="Shift Code">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ShiftName" HeaderText="Shift">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Att_Date" HeaderText="Date" DataFormatString="{0:MMMM d, yyyy}">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Att_Day" HeaderText="Day">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="InTime" HeaderText="In Time" DataFormatString="{0:t}">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OutTime" HeaderText="Out Time" DataFormatString="{0:t}">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Working_Day" HeaderText="Working Day">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Remarks" HeaderText="Remarks">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <%--<asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgbtnLeaveEdit" runat="server" ImageUrl="img/list_edit.png" OnClick="imgbtnLeaveEdit_Click" />
                                </ItemTemplate>
                                <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                            </asp:TemplateField>--%>
                                </Columns>
                                <EmptyDataRowStyle ForeColor="Red" />
                                <RowStyle CssClass="Grid_RowStyle" />
                                <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                <PagerSettings Mode="NumericFirstLast" />
                                <PagerStyle ForeColor="#000066" HorizontalAlign="Left" BackColor="White" CssClass="pagination01 pageback" />
                                <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:GridView>
                            <br />
                        </fieldset>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="BtnSave" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="ddlShiftCode" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
     <script>

         function func(result) {
             if (result === 'Data Added successfully!') {
                 toastr.success(result);

             }
             else if (result === "Data Already Exists!") {
                 toastr.error(result);
             }
             else if (result === "No record found!") {
                 toastr.error(result);
             }
             else if (result === "Out Time can't be less than In Time") {
                 toastr.error(result);
             }

             else
                 toastr.error(result);

             return false;
         }

   </script>
</asp:Content>
