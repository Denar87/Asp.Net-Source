<%@ Page Title="Attendance" Language="C#" MasterPageFile="~/PAYROLL/Site.Master" AutoEventWireup="true"
    CodeBehind="OT_CalculationDatewise.aspx.cs" Inherits="ERPSSL.PAYROLL.OT_CalculationDatewise" %>

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

        .LoaderBackground_ {
            /*background-color:;*/
            filter: alpha(opacity=90);
            opacity: 0.9;
            z-index: 999999999;
            overflow: hidden;
            width: 20%;
            height: 20%;
            position: absolute;
            margin: 170px 300px 0;
        }

        .LoaderBackground_Image {
            display: block;
            position: absolute;
            left: 48%;
            top: 40%;
            width: 50px;
            height: 50px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <script src="content/js/bootstrap-datetimepicker.js" type="text/javascript"></script>
    <link href="content/css/bootstrap-datetimepicker.min.css" rel="stylesheet" type="text/css" />
    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdWaitImage" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="UpdatePanel8">
                <ProgressTemplate>
                    <div class="LoaderBackground_">
                        <asp:Image ID="Image1" runat="server" CssClass="LoaderBackground_Image" ImageUrl="../content/image/busy.gif" />
                    </div>

                </ProgressTemplate>
            </asp:UpdateProgress>

            <div class="hm_sec_2_content scrollbar">
                <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="fa fa-edit fa-fw icon-padding"></i>OT Calculation Date wise
                    </div>
                    <div class="col-md-12 bg-success">
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="row">

                    <fieldset style="border: none;">
                        <div class="col-md-12">
                            <div class="col-md-1">
                                Date From
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox Class="form-control" runat="server" ID="txtDateFrom" autocomplete="off" OnTextChanged="txtDateFrom_TextChanged" AutoPostBack="true"
                                    placeholder="MM/dd/yyyy"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDateFrom"
                                    Display="Dynamic" ErrorMessage="Select From Date" ForeColor="Red" SetFocusOnError="True" Font-Size="11px"
                                    ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDateFrom"
                                    PopupButtonID="Image_AT" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                            </div>
                            <div class="col-md-1">
                                Date To
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox Class="form-control" runat="server" ID="txtDateTo" autocomplete="off"
                                    placeholder="MM/dd/yyyy"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDateTo"
                                    Display="Dynamic" ErrorMessage="Select To Date" ForeColor="Red" SetFocusOnError="True" Font-Size="11px"
                                    ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDateTo"
                                    PopupButtonID="Image_AT" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                            </div>
                            <div class="col-md-3">
                                <asp:Button ID="btnUpdate" runat="server" Text="Process" class="btn btn-info" ValidationGroup="Group1" OnClick="btnUpdate_Click" />
                            </div>
                        </div>
                    </fieldset>
                </div>

                <div class="col-md-12">
                    <fieldset>
                        <legend style="line-height: 5px;"><span style="background: #fff">Processed OT List</span></legend>
                        <asp:GridView ID="GridViewEMP_AT" runat="server" AutoGenerateColumns="False" Width="100%"
                            EmptyDataText="No Records Found!" AllowPaging="True" AllowSorting="True" CellPadding="5"
                            DataKeyNames="ATTE_ID" OnPageIndexChanging="GridViewEMP_AT_PageIndexChanging" PageSize="50">
                            <Columns>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        Sl.
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblSRNO" runat="server"
                                            Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="AttendanceId" HeaderText="Id" Visible="false">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Attendance_Date" DataFormatString="{0:MMM d, yyyy}" HeaderText="Date">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>
                                <%-- <asp:BoundField DataField="Attendance_Day" HeaderText="Day">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>--%>
                                <asp:BoundField DataField="EID" HeaderText="E-ID">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>
                               <%-- <asp:TemplateField HeaderText="First Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblatEmpname" runat="server" Text='<%# Bind("HRM_PersonalInformations.FirstName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                    <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="15%" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Last Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblatEmpname" runat="server" Text='<%# Bind("HRM_PersonalInformations.LastName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                    <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="15%" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:TemplateField>--%>
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
                                <asp:BoundField DataField="Over_Time" HeaderText="Over Time" DataFormatString="{0:t}">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>
                                <%--<asp:BoundField DataField="Shift_TotalHour" HeaderText="Total ShiftTime" DataFormatString="{0:t}">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>--%>

                                <asp:BoundField DataField="OT_Total" HeaderText="OT (hrs.)">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>

                                <%--<asp:BoundField DataField="OT_Applicable"  HeaderText="OT Applicable">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>--%>
                            </Columns>
                            <EmptyDataRowStyle ForeColor="Red" />
                            <RowStyle CssClass="Grid_RowStyle" />
                            <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                            <PagerSettings Mode="NumericFirstLast" />
                            <PagerStyle ForeColor="#000066" HorizontalAlign="Left" BackColor="White" CssClass="pagination01 pageback" />
                            <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" HorizontalAlign="Center" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:GridView>

                    </fieldset>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

    <script type="text/javascript">

        function func(result) {

            if (result === 'OT Processed Successfully') {
                toastr.success(result);
            }
            else
                toastr.error(result);

            return false;
        }
    </script>

</asp:Content>
