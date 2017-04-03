<%@ Page Title="Salary Proccess" Language="C#" MasterPageFile="~/PAYROLL/Site.Master" AutoEventWireup="true"
    CodeBehind="SalaryProccessByOffice.aspx.cs" Inherits="ERPSSL.PAYROLL.SalaryProccessByOffice" %>

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

    <style type="text/css">

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
                        <i class="fa fa-edit fa-fw icon-padding"></i>Salary Generate
                    </div>
                    <div class="col-md-12 bg-success">
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="col-md-12">
                    <fieldset>
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
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlRegion"
                                                Display="Dynamic" ForeColor="Red" Font-Size="11px" SetFocusOnError="True" ErrorMessage="Select Region" InitialValue="0"
                                                ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Office<span style="color: #f00;">*</span>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="ddlOffice" CssClass="form-control"
                                                runat="server">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlOffice"
                                                Display="Dynamic" ForeColor="Red" Font-Size="11px" SetFocusOnError="True" ErrorMessage="Select Office" InitialValue="0"
                                                ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </fieldset>
                    <fieldset>
                        <div class="col-md-12">
                            <div class="col-md-6">
                                <div class="row" style="padding-bottom: 8px">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Date From<span style="color: #f00;">*</span>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox Class="form-control" runat="server" ID="txtDateFrom" autocomplete="off"
                                                placeholder="MM/dd/yyyy"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDateFrom"
                                                Display="Dynamic" ErrorMessage="Select From Date" ForeColor="Red" SetFocusOnError="True" Font-Size="11px"
                                                ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDateFrom"
                                                PopupButtonID="Image_AT" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Date To<span style="color: #f00;">*</span>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox Class="form-control" runat="server" ID="txtDateTo" autocomplete="off" AutoPostBack="true"
                                                placeholder="MM/dd/yyyy" OnTextChanged="txtDateTo_TextChanged"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDateTo"
                                                Display="Dynamic" ErrorMessage="Select To Date" ForeColor="Red" SetFocusOnError="True" Font-Size="11px"
                                                ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDateTo"
                                                PopupButtonID="Image_AT" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="row" style="padding-bottom: 8px">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Total Day / Holiday
                                        </div>
                                        <div class="col-md-4">
                                            <asp:TextBox Class="form-control" runat="server" ID="txtTotalDay" ReadOnly="true"></asp:TextBox>
                                            <asp:TextBox Class="form-control" runat="server" ID="txtWeekend1" ReadOnly="true" Visible="false"></asp:TextBox>
                                            <asp:TextBox Class="form-control" runat="server" ID="txtWeekend2" ReadOnly="true" Visible="false"></asp:TextBox>
                                            <asp:TextBox Class="form-control" runat="server" ID="txtWeekend" ReadOnly="true" Visible="false"></asp:TextBox>
                                        </div>
                                        <div class="col-md-3">
                                            <asp:TextBox Class="form-control" runat="server" ID="txtHoliday" ForeColor="Red" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <%--  <div class="row" style="padding-bottom:8px">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Holiday
                                        </div>
                                        
                                    </div>
                                </div>--%>

                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                        </div>
                                        <div class="col-md-7">
                                            <asp:Button ID="btnConfirm" runat="server" Text="Confirm" class="btn btn-primary pull right" ValidationGroup="" OnClick="btnConfirm_Click" />
                                            <asp:Button ID="btnUpdate" runat="server" Text="Generate" class="btn btn-info pull right" ValidationGroup="Group1" OnClick="btnUpdate_Click" Style="margin-right: 5px" />
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </fieldset>
                    <fieldset style="padding-bottom: 10px">
                        <legend style="line-height: 5px;"><span style="background: #fff">Processed Salary Details</span></legend>
                        <div class="col-md-12" style="padding-bottom: 10px">
                            <asp:GridView ID="GridViewEMP_AT" runat="server" AutoGenerateColumns="False" Width="100%"
                                EmptyDataText="No Records Found!" AllowPaging="True" AllowSorting="True" CellPadding="5"
                                DataKeyNames="PaySalary_Temp_ID" OnPageIndexChanging="GridViewEMP_AT_PageIndexChanging" PageSize="50">
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

                                    <asp:BoundField DataField="PaySalary_Temp_ID" HeaderText="SL" Visible="false">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="EID" HeaderText="E-ID">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="7%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FullName" HeaderText="Name">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DesginationName" HeaderText="Designation">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <%--<asp:BoundField DataField="Grade" HeaderText="Grade">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>--%>
                                    <asp:BoundField DataField="Total_Basic_New" HeaderText="Basic" DataFormatString="{0:0.00}">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="8%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="HOUSE_RENT" HeaderText="House Rent" DataFormatString="{0:0.00}">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="8%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MEDICAL" HeaderText="Medical" DataFormatString="{0:0.00}">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <%--<asp:BoundField DataField="CONVEYANCE" HeaderText="Conveyance" DataFormatString="{0:0.00}">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="8%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FixedAllowance" HeaderText="Fixed Allowance" DataFormatString="{0:0.00}">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="8%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>--%>
                                    <asp:BoundField DataField="GROSS_SAL" HeaderText="Gross" DataFormatString="{0:0.00}">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="8%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Worked_Day" HeaderText="Pay Days">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Attendance_Bonus" HeaderText="Att. Bonus" DataFormatString="{0:0.00}">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Over_Time" HeaderText="OT (hrs)">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OT_Taka" HeaderText="OT Amt." DataFormatString="{0:0.00}">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total_Gross_Sal" HeaderText="Total Gross" DataFormatString="{0:0.00}">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total_Deduction" HeaderText="Total Deduction" DataFormatString="{0:0.00}">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Net_Payable" HeaderText="Net Payable" DataFormatString="{0:0.00}">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                </Columns>
                                <EmptyDataRowStyle ForeColor="Red" />
                                <RowStyle CssClass="Grid_RowStyle" />
                                <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                <PagerSettings Mode="NumericFirstLast" />
                                <PagerStyle ForeColor="#000066" HorizontalAlign="Left" BackColor="White" CssClass="pagination01 pageback" />
                                <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" HorizontalAlign="Center" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:GridView>
                            <div class="col-md-12">
                               <%-- <span style="margin-left: 220px;"><b>Total :</b></span>--%>
                                <asp:Label ID="lblTotalPayable" Style="float: right; margin-right: 0px;" runat="server" Text="" Font-Size="14px" Font-Bold="true" ForeColor="Maroon"></asp:Label>
                            </div>

                        </div>
                    </fieldset>
                </div>
            </div>
        </ContentTemplate>
        <%--<Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnConfirm" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="ddlRegion" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="ddlOffice" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="ddlDepartment" EventName="SelectedIndexChanged" />
        </Triggers>--%>
    </asp:UpdatePanel>

    <script type="text/javascript">

        function func(result) {
            if (result === 'Salary processed successfully') {
                toastr.success(result);
            }
            else if (result === 'Salary processed temporarily') {
                toastr.success(result);
            }
            else {
                toastr.error(result);
            }
            return false;
        }

    </script>
</asp:Content>
