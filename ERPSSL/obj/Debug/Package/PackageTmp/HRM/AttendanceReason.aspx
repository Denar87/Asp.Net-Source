<%@ Page Title="" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true" CodeBehind="AttendanceReason.aspx.cs" Inherits="ERPSSL.HRM.AttendanceReason" %>

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
                        <i class="fa fa-edit fa-fw icon-padding"></i>Extra Scedule Shift wise 
                    </div>
                </div>
                <center>
                    <div class="col-md-12 bg-success">
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </div>
                </center>
                <div class="row" style="margin:0 auto">
                    <fieldset style="border: none;">
                        <div class="col-md-12">
                            <div class="col-md-6">
                                
                                <div class="row" style="margin-bottom:8px">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Shift<span style="color: #f00;">*</span>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:HiddenField ID="hiddenId" runat="server" />
                                            <asp:DropDownList ID="ddlShiftCode" CssClass="form-control"
                                                runat="server">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlShiftCode"
                                                Display="Dynamic" ForeColor="Red" Font-Size="11px" SetFocusOnError="True" ErrorMessage="Select a Shift Code"
                                                ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                
                                <%-- <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Region
                                        </div>
                                        <div class="col-md-7">
                                            <asp:Label ID="lblRegionId" runat="server" Visible="false"></asp:Label>
                                            <asp:TextBox ID="txtRegion" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                            <%--<asp:DropDownList ID="ddlRegions" AutoPostBack="True" CssClass="form-control"
                                                runat="server" OnSelectedIndexChanged="ddlRegions_SelectedIndexChanged">
                                            </asp:DropDownList>--%>
                                <%-- </div>
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
                                            <asp:TextBox ID="txtOffice" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>--%>
                                <%--<asp:DropDownList ID="ddlOffice" AppendDataBoundItems="false" CssClass="form-control"
                                                runat="server">
                                            </asp:DropDownList>--%>
                                <%--  </div>
                                    </div>
                                </div>
                                <br />--%>

                                <div class="row" style="margin-bottom:8px">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            From Date<span style="color: #f00;">*</span>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox Class="form-control" runat="server" ID="txtfromDate" autocomplete="off"
                                                placeholder="MM/dd/yyyy"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtfromDate"
                                                Display="Dynamic" ErrorMessage="Select From Date" ForeColor="Red" SetFocusOnError="True"
                                                ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtfromDate"
                                                PopupButtonID="Image_AT" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                        </div>
                                    </div>
                                </div>

                                <div class="row" style="margin-bottom:8px">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            To Date<span style="color: #f00;">*</span>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox Class="form-control" runat="server" ID="txttoDate" autocomplete="off" AutoPostBack="true"
                                                placeholder="MM/dd/yyyy" OnTextChanged="txttoDate_TextChanged"></asp:TextBox>
                                            <asp:HiddenField runat="server" ID="hdfTotalDay" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txttoDate"
                                                Display="Dynamic" ErrorMessage="Select To Date" ForeColor="Red" SetFocusOnError="True"
                                                ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txttoDate"
                                                PopupButtonID="Image_AT" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                        </div>
                                    </div>
                                </div>

                                <div class="row" style="margin-bottom:8px">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Start Time<span style="color: #f00;">*</span>
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
                                
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            End Time<span style="color: #f00;">*</span>
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
                            </div>

                            <div class="col-md-6">
                                <div class="row" style="margin-bottom:8px">
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
                                
                                <div class="row" style="margin-bottom:8px">
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

                                <div class="row" style="margin-bottom:8px">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Remarks<span style="color: #f00;">*</span>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtRemarks" CssClass="form-control" runat="server" TextMode="MultiLine" Height="76px"></asp:TextBox>
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
                                        <div class="col-md-7" >
                                            <asp:Button ID="BtnSave" runat="server" Text="Save" ValidationGroup="Group1"
                                                class="btn btn-info pull-right" OnClick="BtnSave_Click" />
                                        </div>
                                    </div>
                                </div>
                                
                            </div>
                        </div>
                    </fieldset>

                    <div class="col-md-12" style="margin-top:-10px">
                        <fieldset>
                            <legend style="line-height: 5px;"><span style="background: #fff">Extra Shcedule List</span></legend>
                            <asp:GridView ID="gridviewAttendanceReason" runat="server" AutoGenerateColumns="False" Width="100%"
                                CellPadding="5" AllowPaging="True" OnPageIndexChanging="gridviewAttendanceReason_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblId" runat="server" Text='<%# Eval("ReasonId")%>' />
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
                                    <asp:BoundField DataField="InTime" HeaderText="Start Time" DataFormatString="{0:t}">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OutTime" HeaderText="End Time" DataFormatString="{0:t}">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="LateAllowed" HeaderText="Late Allowed" DataFormatString="{0:t}">
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
    <script type="text/javascript">

        function func(result) {
            if (result === 'Record Added successfully!') {
                toastr.success(result);

            }
            else if (result === 'Record Adding Error!') {
                toastr.error(result);
            }
            else if (result === 'Record Updated Successfully') {
                toastr.success(result);
            }
            else if (result === 'Record Updating Error!') {
                toastr.error(result);
            }
            else
                toastr.error(result);

            return false;
        }

   </script>
</asp:Content>
