<%@ Page Title="Attendance" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true"
    CodeBehind="AttendanceReasonByStaff.aspx.cs" Inherits="ERPSSL.HRM.AttendanceReasonByStaff" %>

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
    <script src="content/js/bootstrap-datetimepicker.js" type="text/javascript"></script>
    <link href="content/css/bootstrap-datetimepicker.min.css" rel="stylesheet" type="text/css" />
    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="hm_sec_2_content scrollbar">
                    <div class="panel">
                        <div class="panel-heading panel-heading-01">
                            <i class="fa fa-edit fa-fw icon-padding"></i>Staff Movement Log
                        </div>
                        <center>
                            <div class="col-md-12 bg-success">
                                <asp:Label ID="lblMessage" runat="server"></asp:Label>
                            </div>
                        </center>
                    </div>
                    <asp:HiddenField ID="hiddenId" runat="server" />

                    <fieldset style="margin-top: 5px">
                        <div class="col-md-12">
                            <div class="col-md-5">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-6">
                                            E-ID<span style="color: #f00;">*</span>
                                            <asp:Label ID="lblHiddenId" runat="server" Visible="false"></asp:Label>
                                            <asp:Label ID="lblBioId" runat="server" Visible="false"></asp:Label>
                                        </div>
                                        <div class="col-md-6">
                                            <asp:TextBox ID="txtEid_AT" Class="form-control" runat="server" AutoPostBack="True"
                                                OnTextChanged="txtEid_AT_TextChanged"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEid_AT"
                                                Display="Dynamic" ForeColor="Red" Font-Size="11px" SetFocusOnError="True" ErrorMessage="Input EID"
                                                ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-6">
                                            Employee Name
                                        </div>
                                        <div class="col-md-6">
                                            <asp:TextBox ID="txtEmpName_AT" Class="form-control" runat="server" Enabled="False"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            Department
                                        </div>
                                        <div class="col-md-8">
                                            <asp:Label ID="lblDeparmentId" runat="server" Visible="false"></asp:Label>
                                            <asp:TextBox ID="txtDepartment_AT" Class="form-control" runat="server" Enabled="False"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            Designation
                                        </div>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtDesignation_AT" Class="form-control" runat="server" Enabled="False"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <br />
                            </div>
                            <div class="col-md-3">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-6">
                                            Photo
                                        </div>
                                        <div class="col-md-6">
                                            <asp:Image ID="Emp_IMG_AT" runat="server" class="avater_details" Height="90px" ImageUrl="resources/no_image.png"
                                                onerror="this.onerror=null" Width="90px" />
                                        </div>
                                        &nbsp
                                    </div>
                                </div>
                            </div>
                        </div>
                    </fieldset>
                    <fieldset style="border: none;">
                        <div class="col-md-12">
                            <div class="col-md-6">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Region
                                        </div>
                                        <div class="col-md-7">
                                            <asp:Label ID="lblRegionId" runat="server" Visible="false"></asp:Label>
                                            <asp:TextBox ID="txtRegion" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                            <%-- <asp:DropDownList ID="ddlRegions" AutoPostBack="True" CssClass="form-control"
                                                runat="server" OnSelectedIndexChanged="ddlRegions_SelectedIndexChanged">
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
                                            <%-- <asp:DropDownList ID="ddlOffice" AppendDataBoundItems="false" CssClass="form-control"
                                                runat="server">
                                            </asp:DropDownList>--%>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Shift
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtShiftCode" CssClass="form-control" runat="server" ReadOnly="true" Visible="false"></asp:TextBox>
                                            <asp:TextBox ID="txtShift" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                            <%--<asp:DropDownList ID="ddlShift" CssClass="form-control"
                                                runat="server">
                                                <asp:ListItem Value="0" Text="------ Select One ------"></asp:ListItem>
                                                <asp:ListItem Value="Day">Day</asp:ListItem>
                                                <asp:ListItem Value="Evening">Evening</asp:ListItem>
                                                <asp:ListItem Value="Night">Night</asp:ListItem>
                                            </asp:DropDownList>--%>
                                        </div>
                                    </div>
                                </div>
                                <br />
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
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Reason Type<span style="color: #f00;">*</span>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="ddlReasonType" CssClass="form-control"
                                                runat="server">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlReasonType"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select a Reason Type"
                                                Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>

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
                                            Last Out Time
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
                                            Status
                                        </div>
                                        <div class="col-md-7">
                                            <asp:RadioButton ID="rdbPresent" runat="server" Text="Present" GroupName="ATN" Checked="True" />&nbsp&nbsp
                                            <asp:RadioButton ID="rdbLate" runat="server" Text="Late" GroupName="ATN" />&nbsp&nbsp
                                           <%-- <asp:RadioButton ID="rdbOverLate" runat="server" Text="Over Late" GroupName="ATN" />&nbsp&nbsp--%>
                                            <asp:RadioButton ID="rdbAbsent" runat="server" Text="Absent" GroupName="ATN" />
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
                                            <asp:HiddenField ID="HiddenField3" runat="server" />
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
                    <%--<div class="col-md-12">--%>
                    <fieldset>
                        <legend style="line-height: 0;"><span style="background: #fff">Staff Movement Log</span></legend>

                        <asp:GridView ID="gridviewAttendanceReasonStaff" runat="server" AutoGenerateColumns="False" Width="100%"
                            CellPadding="5" AllowPaging="True" OnPageIndexChanging="gridviewAttendanceReasonStaff_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblId" runat="server" Text='<%# Eval("Ind_ReasonId")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:BoundField DataField="ShiftCode" HeaderText="Shift Code">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>--%>
                                <asp:BoundField DataField="ShiftName" HeaderText="Shift">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ReasonDate" HeaderText="Date" DataFormatString="{0:MMMM d, yyyy}">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>
                                <asp:BoundField DataField="InTime" HeaderText="First In Time" DataFormatString="{0:t}">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>
                                <asp:BoundField DataField="OutTime" HeaderText="Last Out Time" DataFormatString="{0:t}">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Reason Type">
                                    <ItemTemplate>
                                        <asp:Label ID="lblReasonType" runat="server" Text='<%# Bind("HRM_ReasonType.ReasonType") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                    <ItemStyle CssClass="Grid_Border" Width="15%" HorizontalAlign="Center" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="Remarks" HeaderText="Remarks">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgbtnEdit" runat="server" ImageUrl="img/list_edit.png" OnClick="imgbtnEdit_Click" />
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
                        <br />
                    </fieldset>
                    <%-- </div>--%>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="BtnSave" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="txtEid_AT" EventName="TextChanged" />
        </Triggers>
    </asp:UpdatePanel>
    <script type="text/javascript">

        function func(result) {
            if (result === 'This Employee is Inactive!') {
                toastr.error(result);

            }

           else if (result === 'Record Added successfully!') {
                toastr.success(result);

           }
           else if (result === 'Record Adding Failure!') {
               toastr.error(result);
           }
           else if (result === 'Record Updated Successfully') {
               toastr.success(result);
           }
           else if (result === 'Record Updating Failure!') {
               toastr.error(result);
           }
            return false;
        }

    </script>
</asp:Content>
