<%@ Page Title="Attendance" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true"
    CodeBehind="Attendance.aspx.cs" Inherits="ERPSSL.HRM.Attendance" %>

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
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
        <ContentTemplate>
            <script src="content/js/bootstrap-datetimepicker.js" type="text/javascript"></script>
            <link href="content/css/bootstrap-datetimepicker.min.css" rel="stylesheet" type="text/css" />
            <div class="row">


                <div class="hm_sec_2_content scrollbar">
                    <div class="panel">
                        <div class="panel-heading panel-heading-01">
                            <i class="fa fa-edit fa-fw icon-padding"></i>Manual Attendance Register
                        </div>

                    </div>
                    <div class="col-md-12 bg-success">
                        <center>
                            <asp:Label ID="lblMessege" runat="server"></asp:Label></center>
                    </div>
                    <fieldset>
                        <div class="col-md-12">
                            <div class="col-md-5">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-6">
                                            E-ID<span style="color: #f00;">*</span>
                                            <asp:Label ID="lblHiddenId" runat="server" Visible="false"></asp:Label>
                                            <asp:Label ID="lblShiftCode" runat="server" Visible="false"></asp:Label>
                                        </div>
                                        <div class="col-md-6">
                                            <asp:TextBox ID="txtEid_AT" Class="form-control" runat="server" AutoPostBack="True"
                                                OnTextChanged="txtEid_AT_TextChanged"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtEid_AT"
                                                Display="Dynamic" ForeColor="Red" Font-Size="11px" SetFocusOnError="True" ErrorMessage="Enter E-ID"
                                                ValidationGroup="validation_AT"></asp:RequiredFieldValidator>
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
                                            Attendance Date<span style="color: #f00;">*</span>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:Label ID="lblATT_Day" runat="server" Visible="false"></asp:Label>
                                            <asp:TextBox Class="form-control" runat="server" ID="txtAttDate" autocomplete="off"
                                                placeholder="MM/dd/yyyy"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAttDate"
                                                Display="Dynamic" ErrorMessage="Select Attendance Date" ForeColor="Red" SetFocusOnError="True" Font-Size="11px"
                                                ValidationGroup="validation_AT"></asp:RequiredFieldValidator>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtAttDate"
                                                PopupButtonID="Image_AT" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Remarks
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtRemarks_AT" Class="form-control" runat="server" TextMode="MultiLine" Height="50px"></asp:TextBox>
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
                                                <%--<asp:ListItem Value="General" Text="General"></asp:ListItem>--%>
                                                <asp:ListItem Value="General">General</asp:ListItem>
                                                <asp:ListItem Value="Holiday">Holiday</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlWorkingDay"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select a Working Day"
                                                Font-Size="11px" ValidationGroup="validation_AT" InitialValue="0"></asp:RequiredFieldValidator>
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
                                                <cc1:TimeSelector ID="txtAttInTime" runat="server" Hour="9" Minute="0" Second="0" CssClass="time_section" SelectedTimeFormat="TwentyFour"
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
                                                <cc1:TimeSelector ID="txtAttOutTime" runat="server" AllowSecondEditing="True" AmPm="PM" CssClass="time_section" SelectedTimeFormat="TwentyFour"
                                                    BorderColor="Silver" Date="01/01/0001 09:00:00" Hour="9" Minute="0" Second="0">
                                                </cc1:TimeSelector>
                                            </div>
                                        </div>
                                        &nbsp
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12 ">
                                        <div class="col-md-5">
                                            Status
                                        </div>
                                        <div class="col-md-7 radio_input" style="padding-left: 0; padding-right: 0; width: 55%; float: right;">
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
                                        </div>
                                        <div class="col-md-7">
                                            <asp:Button ID="btnAttSubmit" runat="server" Text="Submit" class="btn btn-info pull-right" ValidationGroup="validation_AT"
                                                OnClick="btnAttSubmit_Click" />
                                        </div>
                                    </div>

                                </div>
                                <br />
                            </div>
                        </div>
                    </fieldset>
                    <div class="col-md-12">
                        <fieldset>
                            <legend style="line-height: 0;"><span style="background: #fff">Attendance List</span></legend>
                            <asp:GridView ID="GridViewEMP_AT" runat="server" AutoGenerateColumns="False" Width="100%"
                                EmptyDataText="No Records Found!" AllowPaging="True" AllowSorting="True" CellPadding="5"
                                DataKeyNames="ATTE_ID" OnPageIndexChanging="GridViewEMP_AT_PageIndexChanging" PageSize="100">
                                <Columns>
                                    <asp:BoundField DataField="AttendanceId" HeaderText="Id" Visible="false">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="EID" HeaderText="E-ID">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="12%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="First Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblatEmpname" runat="server" Text='<%# Bind("HRM_PersonalInformations.FirstName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                        <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" Width="20%" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Last Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblatEmpname" runat="server" Text='<%# Bind("HRM_PersonalInformations.LastName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                        <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" Width="20%" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="In_Time" HeaderText="First In Time" DataFormatString="{0:t}">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Out_Time" HeaderText="Last Out Time" DataFormatString="{0:t}">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Attendance_Date" DataFormatString="{0:MMMM d, yyyy}" HeaderText="Attendance Date">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Attendance_Day" HeaderText="Day">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                </Columns>
                                <EmptyDataRowStyle ForeColor="Red" />
                                <RowStyle CssClass="Grid_RowStyle" />
                                <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                <PagerSettings Mode="NumericFirstLast" />
                                <PagerStyle ForeColor="#000066" HorizontalAlign="Justify" BackColor="#6393C1" CssClass="pagination01 pageback" />
                                <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" HorizontalAlign="Center" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:GridView>
                        </fieldset>

                    </div>
                </div>
            </div>
        </ContentTemplate>

        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAttSubmit" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="txtEid_AT" EventName="TextChanged" />
        </Triggers>
    </asp:UpdatePanel>

    <script type="text/javascript">

        function func(result) {
            if (result === 'This Employee is Inactive!') {
                toastr.error(result);

            }
            else if (result === 'Attendance Recorded successfully!') {
                toastr.success(result);

            }
            else if (result === 'Attendance Recorded failure!') {
                toastr.error(result);
            }
            else if (result === 'Attendance Already Recorded in this day for this Employee!') {
                toastr.error(result);
            }
            return false;
        }

    </script>

</asp:Content>
