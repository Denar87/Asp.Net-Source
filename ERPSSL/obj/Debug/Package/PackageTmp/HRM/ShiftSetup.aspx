<%@ Page Title="" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true" CodeBehind="ShiftSetup.aspx.cs" Inherits="ERPSSL.HRM.ShiftSetup" %>

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
    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>
            <div class="row hm_sec_2_content scrollbar">
                <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="glyphicon glyphicon-edit icon-padding"></i>Shift Setup
                    </div>
                </div>
                <center>
                    <div class="col-md-12 bg-success">
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </div>
                </center>
                <asp:HiddenField ID="hiddenId" runat="server" />
                <div class="row">
                    <fieldset style="border: none;">
                        <div class="col-md-12">
                            <div class="col-md-6">
                                <%-- <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Region<span style="color: #f00;">*</span>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="ddlRegion" AutoPostBack="True" CssClass="form-control"
                                                runat="server" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlRegion"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select a Region"
                                                Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Office<span style="color: #f00;">*</span>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="ddlOffice" CssClass="form-control" AutoPostBack="true"
                                                runat="server" OnSelectedIndexChanged="ddlOffice_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlOffice"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select an Office"
                                                Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Department<span style="color: #f00;">*</span>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="ddlDepartment" CssClass="form-control"
                                                runat="server">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlDepartment"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select an Office"
                                                Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <br />--%>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Shift Name<span style="color: #f00;">*</span>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtShiftName" CssClass="form-control" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtShiftName"
                                                Display="Dynamic" ForeColor="Red" Font-Size="11px" SetFocusOnError="True" ErrorMessage="Input Shift Name"
                                                ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Shift Code<span style="color: #f00;">*</span>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtShiftCode" CssClass="form-control" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtShiftCode"
                                                Display="Dynamic" ForeColor="Red" Font-Size="11px" SetFocusOnError="True" ErrorMessage="Input Shift Code"
                                                ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Shift Type<span style="color: #f00;">*</span>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="ddlShift" CssClass="form-control"
                                                runat="server">
                                                <asp:ListItem Value="0" Text="------ Select One ------"></asp:ListItem>
                                                <asp:ListItem Value="Day">Day</asp:ListItem>
                                                <%--<asp:ListItem Value="Evening">Evening</asp:ListItem>--%>
                                                <asp:ListItem Value="Night">Night</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlShift"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select a Shift"
                                                Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Weekend1
                                        </div>
                                        <div class="col-md-7">
                                            <%-- <asp:TextBox ID="txtWeekend1" CssClass="form-control" runat="server"></asp:TextBox>--%>
                                            <asp:DropDownList ID="ddlWeekend1" CssClass="form-control"
                                                runat="server">
                                                <asp:ListItem Value="n/a" Text="------ Select One ------"></asp:ListItem>
                                                <asp:ListItem Value="Saturday">Saturday</asp:ListItem>
                                                <asp:ListItem Value="Sunday">Sunday</asp:ListItem>
                                                <asp:ListItem Value="Monday">Monday</asp:ListItem>
                                                <asp:ListItem Value="Tuesday">Tuesday</asp:ListItem>
                                                <asp:ListItem Value="Wednesday">Wednesday</asp:ListItem>
                                                <asp:ListItem Value="Thursday">Thursday</asp:ListItem>
                                                <asp:ListItem Value="Friday">Friday</asp:ListItem>
                                                <asp:ListItem Value="None">None</asp:ListItem>
                                            </asp:DropDownList>
                                            <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlWeekend1"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Weekend1"
                                                Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>--%>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Weekend1 Duty
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="ddlWeekend1Duty" AutoPostBack="true" OnSelectedIndexChanged="ddlWeekend1Duty_ddlWeekend1Duty"
                                                CssClass="form-control" runat="server">
                                                <asp:ListItem Value="0" Text="------ Select One ------"></asp:ListItem>
                                                <asp:ListItem Value="True">Yes</asp:ListItem>
                                                <asp:ListItem Value="False">No</asp:ListItem>
                                            </asp:DropDownList>
                                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlWeekend1Duty"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Weekend1 Duty"
                                                Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>--%>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row" runat="server" id="weekEnd1Duty">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Weekend1 Duty Hour
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtWeekend1DutyHour" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Weekend2
                                        </div>
                                        <div class="col-md-7">
                                            <%-- <asp:TextBox ID="txtWeekend2" CssClass="form-control" runat="server"></asp:TextBox>--%>
                                            <asp:DropDownList ID="ddlWeekend2" CssClass="form-control"
                                                runat="server">
                                                <asp:ListItem Value="n/a" Text="------ Select One ------"></asp:ListItem>
                                                <asp:ListItem Value="Saturday">Saturday</asp:ListItem>
                                                <asp:ListItem Value="Sunday">Sunday</asp:ListItem>
                                                <asp:ListItem Value="Monday">Monday</asp:ListItem>
                                                <asp:ListItem Value="Tuesday">Tuesday</asp:ListItem>
                                                <asp:ListItem Value="Wednesday">Wednesday</asp:ListItem>
                                                <asp:ListItem Value="Thursday">Thursday</asp:ListItem>
                                                <asp:ListItem Value="Friday">Friday</asp:ListItem>
                                                <asp:ListItem Value="None">None</asp:ListItem>
                                            </asp:DropDownList>
                                            <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlWeekend2"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Weekend2"
                                                Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>--%>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Weekend2 Duty
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="ddlWeekend2Duty" AutoPostBack="true" OnSelectedIndexChanged="ddlWeekend2Duty_SelectIndex"
                                                CssClass="form-control" runat="server">
                                                <asp:ListItem Value="0" Text="------ Select One ------"></asp:ListItem>
                                                <asp:ListItem Value="True">Yes</asp:ListItem>
                                                <asp:ListItem Value="False">No</asp:ListItem>
                                            </asp:DropDownList>
                                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlWeekend2Duty"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select Weekend2 Duty"
                                                Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>--%>
                                        </div>
                                    </div>
                                </div>

                                <div class="row" runat="server" id="weekEnd2Duty">
                                    <br />
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Weekend2 Duty Hour
                                        </div>

                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtWeekend2DutyHour" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Start Time<span style="color: #f00;">*</span>
                                        </div>
                                        <div class="col-md-7">
                                            <div class="form-control">
                                                <cc1:TimeSelector ID="txtStartTime" runat="server" Hour="9" Minute="0" Second="0" AllowSecondEditing="True" CssClass="time_section"
                                                    AmPm="AM" BorderColor="Silver"
                                                    Date="01/01/0001 09:00:00" SelectedTimeFormat="TwentyFour">
                                                </cc1:TimeSelector>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            End Time<span style="color: #f00;">*</span>
                                        </div>
                                        <div class="col-md-7">
                                            <div class="form-control">
                                                <cc1:TimeSelector ID="txtEndTime" runat="server" AllowSecondEditing="True" AmPm="PM" CssClass="time_section" SelectedTimeFormat="TwentyFour"
                                                    BorderColor="Silver" Date="01/01/0001 18:00:00" Hour="18" Minute="0" Second="0">
                                                </cc1:TimeSelector>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Late Allowed<span style="color: #f00;">*</span>
                                        </div>
                                        <div class="col-md-7">
                                            <div class="form-control">
                                                <cc1:TimeSelector ID="txtLateAllowed" runat="server" AllowSecondEditing="True" AmPm="PM" CssClass="time_section" SelectedTimeFormat="TwentyFour"
                                                    BorderColor="Silver" Date="01/01/0001 00:00:00" Hour="0" Minute="0" Second="0">
                                                </cc1:TimeSelector>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            <asp:HiddenField ID="HiddenField3" runat="server" />
                                        </div>
                                        <div class="col-md-7">
                                            <asp:Button ID="BtnSave" runat="server" Text="Save" ValidationGroup="Group1" Style="margin-top: 15px; margin-right: 20px;"
                                                class="btn btn-info pull-right" OnClick="BtnSave_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </fieldset>
                    <div class="col-md-12">
                        <fieldset>
                            <legend style="line-height: 0; margin-bottom: 0;"><span style="background: #fff">Shift List</span></legend>

                            <asp:GridView ID="gridviewTimeSchedule" runat="server" AutoGenerateColumns="False" Width="100%"
                                CellPadding="5" AllowPaging="True" OnPageIndexChanging="gridviewTimeSchedule_PageIndexChanging" PageSize="50">
                                <Columns>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            Sl No.
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblSRNO" runat="server"
                                                Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblId" runat="server" Text='<%# Eval("ScheduleId")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Region">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRegion" runat="server" Text='<%# Bind("HRM_Regions.RegionName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                        <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" Width="10%" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Office">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOffice" runat="server" Text='<%# Bind("HRM_Office.OfficeName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                        <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" Width="15%" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Department">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDepartment" runat="server" Text='<%# Bind("HRM_DEPARTMENTS.DPT_NAME") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                        <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" Width="15%" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:TemplateField>--%>
                                    <asp:BoundField DataField="ShiftName" HeaderText="Shift">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="8%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ShiftCode" HeaderText="Shift Code">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="StartTime" HeaderText="Start Time" DataFormatString="{0:t}">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="EndTime" HeaderText="End Time" DataFormatString="{0:t}">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="LateAllowed" HeaderText="Late Allowed" DataFormatString="{0:t}">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="ShiftType" HeaderText="Shift Type">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="8%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Weekend1" HeaderText="Weekend1">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="8%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <%--<asp:BoundField DataField="Weekend1_Duty" HeaderText="Weekend1 Duty">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>--%>
                                    <asp:BoundField DataField="Weekend1Duty_Hour" HeaderText="Weekend1 Duty Hour">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="8%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Weekend2" HeaderText="Weekend2">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="8%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <%-- <asp:BoundField DataField="Weekend2_Duty" HeaderText="Weekend2 Duty">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>--%>
                                    <asp:BoundField DataField="Weekend2Duty_Hour" HeaderText="Weekend2 Duty Hour">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="8%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgbtnEdit" runat="server" ImageUrl="img/list_edit.png" OnClick="imgbtnEdit_Click" />
                                        </ItemTemplate>
                                        <ItemStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
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

                        </fieldset>
                    </div>
                </div>
            </div>
        </ContentTemplate>

        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="BtnSave" EventName="Click" />
            <%-- <asp:AsyncPostBackTrigger ControlID="ddlRegion" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="ddlOffice" EventName="SelectedIndexChanged" />--%>
            <asp:AsyncPostBackTrigger ControlID="ddlWeekend1Duty" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="ddlWeekend2Duty" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
    <script>

        function func(result) {
            if (result === 'Data Save Successfully') {
                toastr.success(result);

            }
            else if (result === 'Data Update Successfully') {
                toastr.success(result);
            }
            else
                toastr.error(result);

            return false;
        }

    </script>
</asp:Content>
