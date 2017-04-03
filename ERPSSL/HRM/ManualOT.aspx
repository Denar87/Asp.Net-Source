<%@ Page Title="" Language="C#" MasterPageFile="~/PAYROLL/Site.Master" AutoEventWireup="true" CodeBehind="ManualOT.aspx.cs" Inherits="ERPSSL.HRM.ManualOT" %>

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

            <div class="hm_sec_2_content scrollbar">
                <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="fa fa-edit fa-fw icon-padding"></i>Manual OT
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="col-md-4">
                        <fieldset>
                            <legend style="line-height: 5px;"><span style="background: #fff">Select for Search</span></legend>
                            <div class="col-md-12">
                            </div>
                            <div class="col-md-12" style="padding-left: 0px;">

                                <div class="row">
                                    <%--<h5 style="padding-left: 0px;">Region
                                    </h5>--%>
                                    <div class="col-md-3" style="padding-left: 0px;">
                                        Region
                                    </div>
                                    <div class="col-md-9" style="padding-left: 0px;">
                                        <asp:DropDownList ID="ddlRegion1" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="drpdwnResion1ForDepartmentSelecttedIndexChanged"
                                            runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <br />
                            </div>
                            <%--<div class="col-md-6">
                                    <div class="row">
                                        <h5 style="padding-left: 0px;">Section
                                        </h5>
                                        <div class="col-md-12" style="padding-left: 0px;">
                                            <asp:DropDownList ID="ddlSection" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="ddlSection_SelecttedIndexChanged"
                                                runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                </div>--%>

                            <div class="col-md-12" style="padding-left: 0px;">

                                <div class="row">
                                    <%--<h5 style="padding-left: 0px;">Office
                                    </h5>--%>
                                    <div class="col-md-3" style="padding-left: 0px;">
                                        Office
                                    </div>
                                    <div class="col-md-9" style="padding-left: 0px;">
                                        <asp:DropDownList ID="ddlOffice1" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="onSelectedIndedexChangeOffice1"
                                            runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <br />
                            </div>
                            <%--<div class="col-md-6">
                                    <div class="row">
                                        <h5 style="padding-left: 0px;">Sub-Section
                                        </h5>
                                        <div class="col-md-12" style="padding-left: 0px;">
                                            <asp:DropDownList ID="ddlSubSections" AutoPostBack="True" CssClass="form-control"
                                                runat="server" OnSelectedIndexChanged="ddlSubSections_SelectedIndexChanged">
                                            </asp:DropDownList>
                                           
                                        </div>
                                    </div>
                                </div>--%>

                            <div class="col-md-12" style="padding-left: 0px;">

                                <div class="row">
                                    <%-- <h5 style="padding-left: 0px;">Department
                                    </h5>--%>
                                    <div class="col-md-3" style="padding-left: 0px;">
                                        Department
                                    </div>
                                    <div class="col-md-9" style="padding-left: 0px;">
                                        <asp:DropDownList ID="ddlDept1" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="drpdwnDepartment1SelectedIndexChange"
                                            runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <br />
                            </div>

                            <div class="col-md-12" style="padding-left: 0px;">

                                <div class="row">
                                    <%--<h5 style="padding-left: 0px;">Section
                                    </h5>--%>
                                    <div class="col-md-3" style="padding-left: 0px;">
                                        Section
                                    </div>
                                    <div class="col-md-9" style="padding-left: 0px;">
                                        <asp:DropDownList ID="ddlSection" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="ddlSection_SelecttedIndexChanged"
                                            runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <br />
                            </div>
                            <div class="col-md-12" style="padding-left: 0px;">
                                <div class="row">
                                    <%-- <h5 style="padding-left: 0px;">Sub-Section
                                    </h5>--%>
                                    <div class="col-md-3" style="padding-left: 0px;">
                                        Sub-Section
                                    </div>
                                    <div class="col-md-9" style="padding-left: 0px;">
                                        <asp:DropDownList ID="ddlSubSections" AutoPostBack="True" CssClass="form-control"
                                            runat="server" OnSelectedIndexChanged="ddlSubSections_SelectedIndexChanged">
                                        </asp:DropDownList>

                                    </div>

                                </div>
                                <br />
                            </div>
                            <div class="col-md-12" style="padding-left: 0px;">
                                <div class="row">
                                    <%--<h5 style="padding-left: 0px;">Date
                                        </h5>--%>
                                    <div class="col-md-3" style="padding-left: 0px;">
                                        Date
                                    </div>

                                    <div class="col-md-9" style="padding-left: 0px;">

                                        <asp:TextBox Class="form-control" runat="server" ID="txtDate" autocomplete="off"
                                            placeholder="MM/dd/yyyy"></asp:TextBox>

                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDate"
                                            PopupButtonID="Image_AT" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />

                                    </div>
                                </div>
                                <br />

                            </div>
                            <div class="col-md-12" style="padding-left: 0px;">
                                <div class="row">
                                    <%--<h5 style="padding-left: 0px;">Date
                                        </h5>--%>
                                    <div class="col-md-3" style="padding-left: 0px;">
                                        O-T Hour 
                                    </div>

                                    <div class="col-md-9" style="padding-left: 0px;">

                                        <asp:TextBox ID="txtbxOtHour" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>
                                <br />

                            </div>
                           
                            <div class="col-md-12" style="padding-left: 0px;">

                                <div class="row">

                                    <div class="col-md-3" style="padding-left: 0px;">
                                        Remark
                                    </div>
                                    <div class="col-md-9" style="padding-left: 0px;">

                                        <asp:TextBox ID="txtbxremark" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                            </div>
                            <div class="col-md-12" style="padding-left: 0px;">
                                <div class="col-md-3" style="padding-left: 0px;">
                                </div>
                                <div class="col-md-9" style="padding-left: 0px;">
                                    <asp:Button ID="btnProcess" runat="server" Text="Process"  Width="80px" CssClass="btn btn-info" OnClick="btnProcess_Click" />
                                    <asp:Button ID="btnConfirm" runat="server" Text="Confirm"  Width="80px" CssClass="btn btn-primary" OnClick="btn_Confirm_Clcik" />
                                </div>
                                <br />
                            </div>
                    </div>

                    <div class="col-md-8">
                        <br />
                        <asp:GridView ID="grdview" runat="server" AutoGenerateColumns="False" Width="100%"
                            CellPadding="4" BackColor="White" BorderColor="#336666"
                            BorderStyle="Solid" BorderWidth="1px" AllowPaging="false" >
                            <Columns>
                                <%--<asp:TemplateField>
                                        <HeaderTemplate>
                                            Sl No.
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblSRNO" runat="server"
                                                Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>--%>


                                <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:CheckBox runat="server" ID="headerLevelCheckBox" AutoPostBack="true" OnCheckedChanged="headerLevelCheckBox_CheckedChanged" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="rowLevelCheckBox" runat="server" />
                                                    <headerstyle verticalalign="Middle" cssclass="Grid_Header" />
                                                    <itemstyle horizontalalign="Left" width="10%" cssclass="Grid_Border" />
                                                    <footerstyle cssclass="Grid_Footer" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                <asp:TemplateField Visible="False" HeaderText="EID">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEID" runat="server" Text='<%# Eval("EID")%>' />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="6%" CssClass="Grid_Border" />
                                </asp:TemplateField>

                                <asp:BoundField DataField="EID" HeaderText="E-ID">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>


                                <asp:BoundField DataField="EmployeeFullName" HeaderText="Employee Name">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>

                                <asp:BoundField DataField="DEG_NAME" HeaderText="Designation">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>

                                <asp:BoundField DataField="TOHour" HeaderText="OT-Hour">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>

                                 <%--<asp:TemplateField HeaderText="O-T Hour">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtbxOTHOUR" runat="server" Width="100%" ToolTip="Enter Time" Text='<%# Bind("TOHour") %>' Style="text-align: center"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="15%" />
                                </asp:TemplateField>--%>

                                <asp:BoundField DataField="DATE_JOINED" DataFormatString="{0:MMMM d, yyyy}" HeaderText="Date">
                                    <ItemStyle HorizontalAlign="Center" Width="15%"/>
                                </asp:BoundField>

                               <%-- <asp:TemplateField HeaderText="Time">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtbx" runat="server" Width="100%" ToolTip="Enter Time" Text='<%# Bind("Shift_TotalHour") %>' Style="text-align: center"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="15%" />
                                </asp:TemplateField>--%>


                            </Columns>
                            <EmptyDataRowStyle ForeColor="Red" />
                            <RowStyle CssClass="Grid_RowStyle" BackColor="White" ForeColor="#333333" HorizontalAlign="Center" />
                            <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                            <PagerSettings Mode="NumericFirstLast" />
                            <PagerStyle ForeColor="White" HorizontalAlign="Left" BackColor="#336666" CssClass="pagination01 pageback" />
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" BackColor="#336666"
                                Font-Bold="True" ForeColor="White" />
                            <FooterStyle CssClass="Grid_Footer" BackColor="White" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="Silver" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                            <SortedAscendingHeaderStyle BackColor="#487575" />
                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                            <SortedDescendingHeaderStyle BackColor="#275353" />
                        </asp:GridView>


                    </div>


                </div>
            </div>
            </fieldset>

                        

                        
            </div>

            </div>
                <%--<div class="col-md-12">
                        <div class="row radio_input00">
                           
                        </div>

                    </div>--%>
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
    </asp:UpdatePanel>
</asp:Content>
