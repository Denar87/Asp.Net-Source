<%@ Page Title="Attendance" Language="C#" MasterPageFile="~/PAYROLL/Site.Master" AutoEventWireup="true"
    CodeBehind="OT_AddDeduction.aspx.cs" Inherits="ERPSSL.PAYROLL.OT_AddDeduction" %>

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
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
        <ContentTemplate>
            <script src="content/js/bootstrap-datetimepicker.js" type="text/javascript"></script>
            <link href="content/css/bootstrap-datetimepicker.min.css" rel="stylesheet" type="text/css" />


            <asp:UpdateProgress ID="UpdWaitImage" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="UpdatePanel1">
                <ProgressTemplate>
                    <div class="LoaderBackground_">
                        <asp:Image ID="Image1" runat="server" CssClass="LoaderBackground_Image" ImageUrl="../content/image/busy.gif" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>

            <div class="hm_sec_2_content scrollbar">
                <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="fa fa-edit fa-fw icon-padding"></i>OT Add/Deduction
                    </div>
                    <div class="col-md-12 bg-success">
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </div>
                </div>
                <asp:HiddenField ID="hiddenId" runat="server" />
                <asp:HiddenField ID="hdnEmployeeShiftCode" runat="server" />

                <div class="row" style="margin: 0 auto">

                    <div class="col-md-12">
                        <fieldset>
                            <legend style="line-height: 5px;"><span style="background: #fff">Employee Details</span></legend>
                            <div class="col-md-12">
                                <div class="col-md-4">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                E-ID  
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtEid_AT" Class="form-control" runat="server" AutoPostBack="True" OnTextChanged="txtEid_AT_TextChanged"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEid_AT"
                                                    Display="Dynamic" ForeColor="Red" Font-Size="11px" SetFocusOnError="True" ErrorMessage="Require an Employee ID"
                                                    ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Employee 
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtEmpName_TRNS" class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />

                                </div>
                                <div class="col-md-4">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Department
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtDepartment" class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Designation
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtDesignation" class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-4">

                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-6">
                                                Photo
                                            </div>
                                            <div class="col-md-6">
                                                <asp:Image ID="Emp_IMG_TR" CssClass="form-control" runat="server" class="avater_details" Height="80px" ImageUrl="resources/no_image.png"
                                                    onerror="this.onerror=null; this.src='resources/no_image_found.png';" Width="80px" />
                                            </div>
                                        </div>
                                    </div>

                                </div>

                            </div>
                        </fieldset>
                    </div>

                    <div class="col-md-12">
                        <fieldset>
                            <legend style="line-height: 5px;"><span style="background: #fff">Attendance List</span></legend>
                            <div class="row" style="padding-bottom: 8px;">

                                <div class="col-md-2">
                                    <asp:Label ID="Label1" runat="server" Visible="true">From</asp:Label>
                                    <asp:TextBox Class="form-control" runat="server" ID="txtfromDate" autocomplete="off"
                                        placeholder="MM/dd/yyyy"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfromDate"
                                        PopupButtonID="Image_AT" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtfromDate"
                                        Display="Dynamic" ErrorMessage="Select From Date" ForeColor="Red" SetFocusOnError="True" Font-Size="11px"
                                        ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                </div>

                                <div class="col-md-2">
                                    <asp:Label ID="Label2" runat="server" Visible="true">To</asp:Label>
                                    <asp:TextBox Class="form-control" runat="server" ID="txtToDate" autocomplete="off"
                                        placeholder="MM/dd/yyyy"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtToDate"
                                        PopupButtonID="Image_AT" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtToDate"
                                        Display="Dynamic" ErrorMessage="Select To Date" ForeColor="Red" SetFocusOnError="True" Font-Size="11px"
                                        ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                </div>

                                <div class="col-md-2" style="margin-top: 15px">

                                    <asp:Button ID="btnSearch" runat="server" Text="Search" class="btn btn-info" ValidationGroup="Group1"
                                        OnClick="btnSearch_Click" />
                                </div>

                                <div class="col-md-2" style="margin-top: 15px">
                                    <asp:RadioButton ID="rdExtraOT" runat="server" Text="Add OT" GroupName="group1" Checked="true" />
                                </div>

                                <div class="col-md-2" style="margin-top: 15px">
                                    <asp:RadioButton ID="rdExtraOTDeduct" runat="server" Text="Deduction OT" GroupName="group1" />
                                </div>

                            </div>

                            <asp:GridView ID="GridViewEMP_AT" runat="server" AutoGenerateColumns="False" Width="100%"
                                EmptyDataText="No Records Found!" AllowPaging="True" AllowSorting="True" CellPadding="5"
                                DataKeyNames="ATTE_ID" OnPageIndexChanging="GridViewEMP_AT_PageIndexChanging" PageSize="31">
                                <Columns>

                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:CheckBox runat="server" ID="headerLevelCheckBox" AutoPostBack="true" OnCheckedChanged="headerLevelCheckBox_CheckedChanged" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="rowLevelCheckBox" runat="server" />
                                            <headerstyle verticalalign="Middle" cssclass="Grid_Header" />
                                            <itemstyle horizontalalign="Center" width="5%" cssclass="Grid_Border" />
                                            <footerstyle cssclass="Grid_Footer" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblId" runat="server" Text='<%# Eval("ATTE_ID")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lbltotalot" runat="server" Text='<%# Eval("OT_Total")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAttnDate" runat="server" DataFormatString="{0:MM/dd/yyyy}" Text='<%# Eval("Attendance_Date")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

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
                                    <asp:BoundField DataField="Attendance_Date" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Date">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Width="12%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Attendance_Day" HeaderText="Day">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Status" HeaderText="Status">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Width="6%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OT" HeaderText="OT">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Width="8%" Font-Bold="true" ForeColor="Maroon" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="OT_ExtraAdd" HeaderText="OT Add">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OT_Deduction" HeaderText="OT Deduction">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Width="8%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OT_Total" HeaderText="Total OT">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Width="8%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="Add/Deduct" ItemStyle-Width="14%" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox ID="OTExtraAdd" runat="server" CssClass="input" Width="100%">                                               
                                            </asp:TextBox>
                                        </ItemTemplate>
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


                        </fieldset>

                        <div class="row" style="padding-bottom: 8px;">
                            <div class="col-md-12">
                                <div class="col-md-6">
                                </div>
                                <div class="col-md-6">
                                    <div class="row">
                                        <div class="col-md-9">
                                        </div>
                                        <div class="col-md-3">
                                            <asp:Button ID="btnAttSubmit" runat="server" Text="Process" CssClass="btn btn-primary" ValidationGroup="Group1"
                                                OnClick="btnAttSubmit_Click" />
                                        </div>

                                        <%--<div class="col-md-4">
                                                <asp:Button ID="btnOTProcess" runat="server" Text="OT Process" CssClass="btn btn-primary" ValidationGroup="Group1"
                                                    OnClick="btnOTProcess_Click" />
                                            </div>--%>
                                    </div>


                                </div>
                            </div>

                        </div>


                    </div>
                </div>
            </div>
            <script type="text/javascript">

                function func(result) {
                    if (result === 'Data Update Successfully.') {
                        toastr.success(result);

                    }
                    else
                        toastr.error(result);

                    return false;
                }

            </script>
        </ContentTemplate>

        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAttSubmit" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
