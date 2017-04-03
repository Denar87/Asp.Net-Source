<%@ Page Title="Attendance" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true"
    CodeBehind="AttendanceUpdate.aspx.cs" Inherits="ERPSSL.HRM.AttendanceUpdate" %>

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
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">      
<ContentTemplate>
    <script src="content/js/bootstrap-datetimepicker.js" type="text/javascript"></script>
    <link href="content/css/bootstrap-datetimepicker.min.css" rel="stylesheet" type="text/css" />
    <div class="row">
       
        <asp:HiddenField ID="hiddenId" runat="server" />
        <div class="hm_sec_2_content scrollbar">
             <div class="panel">
            <div class="panel-heading panel-heading-01">
                <i class="fa fa-edit fa-fw icon-padding"></i>Attendance Update
            </div>
            <div class="col-md-12 bg-success">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </div>
        </div>
            <fieldset>
                <div class="col-md-12">
                    <div class="col-md-6">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-5">
                                    Region
                                </div>
                                <div class="col-md-7">
                                    <asp:DropDownList ID="ddlRegion" AutoPostBack="True" CssClass="form-control"
                                        runat="server" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlRegion"
                                        Display="Dynamic" ForeColor="Red" Font-Size="11px" SetFocusOnError="True" ErrorMessage="Select Region"
                                        ValidationGroup="validation_AT"></asp:RequiredFieldValidator>--%>
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
                                    <asp:DropDownList ID="ddlOffice" AutoPostBack="true" CssClass="form-control"
                                        runat="server" OnSelectedIndexChanged="ddlOffice_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlOffice"
                                        Display="Dynamic" ForeColor="Red" Font-Size="11px" SetFocusOnError="True" ErrorMessage="Select Office"
                                        ValidationGroup="validation_AT"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-5">
                                    Department
                                </div>
                                <div class="col-md-7">
                                    <asp:DropDownList ID="ddlDepartment" AutoPostBack="True" CssClass="form-control"
                                        runat="server" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlDepartment"
                                        Display="Dynamic" ForeColor="Red" Font-Size="11px" SetFocusOnError="True" ErrorMessage="Select Department"
                                        ValidationGroup="validation_AT"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-5">
                                    Shift Code
                                </div>
                                <div class="col-md-7">
                                    <asp:DropDownList ID="ddlShiftCode" AutoPostBack="True" CssClass="form-control"
                                        runat="server" OnSelectedIndexChanged="ddlShiftCode_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlShiftCode"
                                        Display="Dynamic" ForeColor="Red" Font-Size="11px" SetFocusOnError="True" ErrorMessage="Select Shift Code"
                                        ValidationGroup="validation_AT"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                        </div>
                        <br />
                    </div>
                </div>
            </fieldset>

            <fieldset style="border: none;">
                <div class="col-md-12">
                    <div class="col-md-6">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-5">
                                    E-ID
                                </div>
                                <div class="col-md-7">
                                    <asp:TextBox Class="form-control" runat="server" ID="txtEID" AutoPostBack="true"
                                        placeholder="Search By E-ID" OnTextChanged="txtEID_TextChanged"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEID"
                                        Display="Dynamic" ForeColor="Red" Font-Size="11px" SetFocusOnError="True" ErrorMessage="Input EID"
                                        ValidationGroup="validation_AT"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-5">
                                    Attendance Date
                                </div>
                                <div class="col-md-7">
                                    <asp:Label ID="lblATT_Day" runat="server" Visible="false"></asp:Label>
                                    <asp:TextBox Class="form-control" runat="server" ID="txtAttDate" autocomplete="off" ReadOnly="true"
                                        placeholder="MM/dd/yyyy"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAttDate"
                                        Display="Dynamic" ErrorMessage="Attendance Date is required" ForeColor="Red" SetFocusOnError="True" Font-Size="11px"
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
                                    <asp:TextBox ID="txtRemarks_AT" Class="form-control" runat="server" TextMode="MultiLine" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-5">
                                    Working Day
                                </div>
                                <div class="col-md-7">
                                    <asp:TextBox ID="txtWorkingDay" Class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtWorkingDay"
                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Working Day is required"
                                        Font-Size="11px" ValidationGroup="validation_AT"></asp:RequiredFieldValidator>
                                    <%--<asp:DropDownList ID="ddlWorkingDay" CssClass="form-control" ReadOnly="True"
                                        runat="server">
                                        <asp:ListItem Value="0" Text="------ Select One ------"></asp:ListItem>
                                        <asp:ListItem Value="General">General</asp:ListItem>
                                        <asp:ListItem Value="Holiday">Holiday</asp:ListItem>
                                    </asp:DropDownList>--%>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlWorkingDay"
                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select a Working Day"
                                        Font-Size="11px" ValidationGroup="validation_AT" InitialValue="0"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                        </div>
                        
                    </div>
                    <div class="col-md-6">

                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-5">
                                    In Time
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
                                    Out Time
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
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-3">
                                    Status
                                </div>
                                <div class="col-md-9">
                                    <asp:RadioButton ID="rdbPresent" runat="server" Text="Present" GroupName="ATN" Checked="True" />&nbsp&nbsp
                                <asp:RadioButton ID="rdbLate" runat="server" Text="Late" GroupName="ATN" />&nbsp&nbsp
                                <asp:RadioButton ID="rdbOverLate" runat="server" Text="Over Late" GroupName="ATN" />&nbsp&nbsp
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
                                    <asp:Button ID="btnAttSubmit" runat="server" Text="Update" class="btn btn-info pull-right" ValidationGroup="validation_AT"
                                        OnClick="btnAttSubmit_Click" />
                                </div>
                            </div>

                        </div>
                       
                    </div>
                </div>
            </fieldset>
            <div class="col-md-12">
                <fieldset>
                    <legend style="line-height: 5px;"><span style="background: #fff">Attendance List</span></legend>
                    <asp:GridView ID="GridViewEMP_AT" runat="server" AutoGenerateColumns="False" Width="100%"
                        EmptyDataText="No Records Found!" AllowPaging="True" AllowSorting="True" CellPadding="5"
                        DataKeyNames="ATTE_ID" OnPageIndexChanging="GridViewEMP_AT_PageIndexChanging" PageSize="100">
                        <Columns>
                            <asp:TemplateField Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblId" runat="server" Text='<%# Eval("ATTE_ID")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Image">
                                <ItemTemplate>
                                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# "ImageHandler.ashx?ImID="+ Eval("EID") %>' />
                                </ItemTemplate>

                            </asp:TemplateField>
                            <asp:BoundField DataField="EID" HeaderText="E-ID">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
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
                                    <asp:Label ID="lblatlastname" runat="server" Text='<%# Bind("HRM_PersonalInformations.LastName") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" Width="20%" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="In_Time" HeaderText="In Time" DataFormatString="{0:t}">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Out_Time" HeaderText="Out Time" DataFormatString="{0:t}">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Attendance_Date" DataFormatString="{0:MMMM d, yyyy}" HeaderText="Date">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Attendance_Day" HeaderText="Day">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Status" HeaderText="Status">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgbtnAttEdit" runat="server" ImageUrl="img/list_edit.png" OnClick="imgbtnAttEdit_Click" />
                                </ItemTemplate>
                                <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                            </asp:TemplateField>
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
                </fieldset>
            </div>
        </div>
    </div>
    </ContentTemplate>

<Triggers>
 <asp:AsyncPostBackTrigger ControlID="btnAttSubmit" EventName="Click" />
<asp:AsyncPostBackTrigger ControlID="ddlRegion" EventName="SelectedIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="ddlOffice" EventName="SelectedIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="ddlDepartment" EventName="SelectedIndexChanged" />
     <asp:AsyncPostBackTrigger ControlID="ddlShiftCode" EventName="SelectedIndexChanged" />
</Triggers>
</asp:UpdatePanel>
</asp:Content>
