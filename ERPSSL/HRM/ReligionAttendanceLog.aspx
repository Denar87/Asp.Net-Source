<%@ Page Title="" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true" CodeBehind="ReligionAttendanceLog.aspx.cs" Inherits="ERPSSL.HRM.ReligionAttendanceLog" %>

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
            <div class="row hm_sec_2_content scrollbar">
                <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="fa fa-edit fa-fw icon-padding"></i>Extra Shift Dpt./Religion Wise
                    </div>
                </div>
                <center>
                    <div class="col-md-12 bg-success">
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </div>
                </center>
                <div class="row">
                    <fieldset style="border: none;">
                        <div class="col-md-12">
                            <div class="col-md-6">
                                <div class="row">
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
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlRegion"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select a Region"
                                                Font-Size="11px" ValidationGroup="Group2" InitialValue="0"></asp:RequiredFieldValidator>
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
                                            <asp:DropDownList ID="ddlOffice" CssClass="form-control" AutoPostBack="True"
                                                runat="server" OnSelectedIndexChanged="ddlOffice_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlOffice"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select an Office"
                                                Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlOffice"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select a Office"
                                                Font-Size="11px" ValidationGroup="Group2" InitialValue="0"></asp:RequiredFieldValidator>

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
                                            <asp:DropDownList ID="ddlDepartment" CssClass="form-control" AutoPostBack="True"
                                                runat="server" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlDepartment"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select a Department"
                                                Font-Size="11px" ValidationGroup="Group2" InitialValue="0"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Religion<span style="color: #f00;">*</span>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="ddlReligion" Class="form-control" runat="server" OnSelectedIndexChanged="ddlReligion_SelectedIndexChanged" AutoPostBack="true">
                                                <asp:ListItem Text="------ Select Religion------" Value="0"></asp:ListItem>
                                                <asp:ListItem>Buddhism</asp:ListItem>
                                                <asp:ListItem>Catholic</asp:ListItem>
                                                <asp:ListItem>Christian</asp:ListItem>
                                                <asp:ListItem>Christian (RC)</asp:ListItem>
                                                <asp:ListItem>Hindu</asp:ListItem>
                                                <asp:ListItem>Islam</asp:ListItem>
                                                <asp:ListItem>Sonaton (Hindu)</asp:ListItem>
                                                <asp:ListItem>Others</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlReligion"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select a Religion"
                                                Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
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
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDate" Font-Size="11px"
                                                Display="Dynamic" ErrorMessage="Select Reason Date" ForeColor="Red" SetFocusOnError="True"
                                                ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtDate" Font-Size="11px"
                                                Display="Dynamic" ErrorMessage="Select Reason Date" ForeColor="Red" SetFocusOnError="True"
                                                ValidationGroup="Group2"></asp:RequiredFieldValidator>
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
                                            In Time<span style="color: #f00;">*</span>
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
                                            Out Time<span style="color: #f00;">*</span>
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
                                            Remarks<span style="color: #f00;">*</span>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="ddlReasonType" CssClass="form-control"
                                                runat="server">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlReasonType"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select a Reason Type"
                                                Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator><br />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddlReasonType"
                                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select a Reason Type"
                                                Font-Size="11px" ValidationGroup="Group2" InitialValue="0"></asp:RequiredFieldValidator><br />
                                            <%-- <asp:DropDownList ID="ddlRemarks" Class="form-control" runat="server">
                                                <asp:ListItem Text="------ Select Type------" Value="0"></asp:ListItem>
                                                <asp:ListItem>Religion</asp:ListItem>
                                                <asp:ListItem>Others</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Group1" Font-Size="11px"
                                                runat="server" ControlToValidate="ddlRemarks" ErrorMessage="Select Type"
                                                InitialValue="0"></asp:RequiredFieldValidator>--%>
                                            <asp:TextBox ID="txtRemarks" CssClass="form-control" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtRemarks"
                                                Display="Dynamic" ForeColor="Red" Font-Size="11px" SetFocusOnError="True" ErrorMessage="Input Remarks"
                                                ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtRemarks"
                                                Display="Dynamic" ForeColor="Red" Font-Size="11px" SetFocusOnError="True" ErrorMessage="Input Remarks"
                                                ValidationGroup="Group2"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="row ">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                        </div>
                                        <div class="col-md-7">
                                            <asp:Button ID="btnSaveByReligion" runat="server" Text="Procecss for Religion" ValidationGroup="Group1" Style="margin-top: 15px;"
                                                class="btn btn-info pull-right" OnClick="btnSaveByReligion_Click" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row ">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                        </div>
                                        <div class="col-md-7">
                                            <asp:Button ID="btnSaveByDepartment" runat="server" Text="Procecss for Department" ValidationGroup="Group2" Style="margin-top: 15px; margin-right: 20px;"
                                                class="btn btn-primary" OnClick="btnSaveByDepartment_Click" />
                                        </div>
                                    </div>
                                </div>
                                <br />
                            </div>
                        </div>
                    </fieldset>
                    <div class="col-md-12">
                        <fieldset>
                            <legend style="line-height: 5px;"><span style="background: #fff">Dept./Religion wise Attendance Log</span></legend>
                            <asp:GridView ID="gridviewAttendanceByReligion" runat="server" AutoGenerateColumns="False" Width="100%"
                                CellPadding="5" AllowPaging="True" OnPageIndexChanging="gridviewAttendanceByReligion_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReligionSechedule_Id" runat="server" Text='<%# Eval("ReligionSechedule_Id")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Date" HeaderText="Date" DataFormatString="{0:MMMM d, yyyy}">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <%--<asp:TemplateField HeaderText="Reason Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReasonType" runat="server" Text='<%# Bind("HRM_ReasonType.ReasonType") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                        <ItemStyle CssClass="Grid_Border" Width="15%" HorizontalAlign="Center" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:TemplateField>--%>
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
                                    <asp:BoundField DataField="Remarks" HeaderText="Remarks">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
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
            <asp:AsyncPostBackTrigger ControlID="btnSaveByDepartment" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="ddlRegion" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="ddlOffice" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="ddlDepartment" EventName="SelectedIndexChanged" />
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
            else if (result === "Data Adding failure!") {
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
