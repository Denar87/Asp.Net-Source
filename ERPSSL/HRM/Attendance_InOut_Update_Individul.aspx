<%@ Page Title="" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true" CodeBehind="Attendance_InOut_Update_Individul.aspx.cs" Inherits="ERPSSL.HRM.Attendance_InOut_Update_Individul" %>

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
                        <i class="fa fa-edit fa-fw icon-padding"></i>Individual Attendance In/Out Update
                    </div>

                </div>
                <div class="col-md-12">
                    <div class="col-md-4">
                        <fieldset>
                            <legend style="line-height: 5px;"><span style="background: #fff">Select for Process</span></legend>
                            <div class="col-md-12">
                            </div>

                            <div class="col-md-12" runat="server" id="divEid" style="padding-left: 0px;">
                                <div class="row" style="padding-bottom: 8px;">

                                    <div class="col-md-3" style="padding-left: 0px;">
                                        E-ID
                                    </div>

                                    <div class="col-md-9" style="padding-left: 0px;">
                                        <asp:TextBox Class="form-control" runat="server" AutoPostBack="true" Font-Bold="true" ID="txtbxEID" OnTextChanged="txtbxEID_TextChangeEvent"
                                            placeholder="E-ID"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-12" runat="server" id="divName" style="padding-left: 0px;">
                                <div class="row" style="padding-bottom: 8px;">
                                    <div class="col-md-3" style="padding-left: 0px;">
                                        Name
                                    </div>
                                    <div class="col-md-9" style="padding-left: 0px;">
                                        <asp:TextBox Class="form-control" runat="server" ID="txtbxName" ReadOnly="true"
                                            placeholder="Name"></asp:TextBox>
                                    </div>
                                </div>

                            </div>

                            <div class="col-md-12" runat="server" id="divIndiDepartment" style="padding-left: 0px;">
                                <div class="row" style="padding-bottom: 8px;">
                                    <div class="col-md-3" style="padding-left: 0px;">
                                        Department
                                    </div>
                                    <div class="col-md-9" style="padding-left: 0px;">
                                        <asp:TextBox Class="form-control" runat="server" ID="txtbxDepartment" ReadOnly="true"
                                            placeholder="Department"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-12" runat="server" id="divDesgination" style="padding-left: 0px;">
                                <div class="row" style="padding-bottom: 8px;">
                                    <div class="col-md-3" style="padding-left: 0px;">
                                        Desgination
                                    </div>
                                    <div class="col-md-9" style="padding-left: 0px;">
                                        <asp:TextBox Class="form-control" runat="server" ID="txtbxDesgination" ReadOnly="true"
                                            placeholder="Degination"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-12" style="padding-left: 0px;">
                                <div class="row" style="padding-bottom: 8px;">

                                    <div class="col-md-3" style="padding-left: 0px;">
                                        From
                                    </div>

                                    <div class="col-md-9" style="padding-left: 0px;">

                                        <asp:TextBox Class="form-control" runat="server" ID="txtDate" autocomplete="off"
                                            placeholder="MM/dd/yyyy"></asp:TextBox>

                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDate"
                                            PopupButtonID="Image_AT" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />

                                    </div>
                                </div>


                            </div>

                            <div class="col-md-12" style="padding-left: 0px;">
                                <div class="row" style="padding-bottom: 8px;">

                                    <div class="col-md-3" style="padding-left: 0px;">
                                        To
                                    </div>

                                    <div class="col-md-9" style="padding-left: 0px;">


                                        <asp:TextBox CssClass="form-control" runat="server" ID="txtToDate" autocomplete="off" placeholder="MM/dd/yyyy"></asp:TextBox>

                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtToDate"
                                            PopupButtonID="Image_AT" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />

                                    </div>
                                </div>


                            </div>
                            <%--  <div class="col-md-12" style="padding-left: 0px;">
                                <div class="row" style="padding-bottom: 8px;">

                                    <div class="col-md-3" style="padding-left: 0px;">
                                        Entry Type
                                    </div>
                                    <div class="col-md-9" style="padding-left: 0px;">
                                        <asp:DropDownList ID="drpEntryType" AutoPostBack="True" CssClass="form-control"
                                            runat="server">
                                            <asp:ListItem Value="Select Entry Type">  
                                                                                            
                                            </asp:ListItem>
                                            <asp:ListItem Value="In-Time">  
                                                                                            
                                            </asp:ListItem>
                                            <asp:ListItem Value="Out Time">  
                                                                                            
                                            </asp:ListItem>

                                        </asp:DropDownList>

                                    </div>


                                </div>

                            </div>--%>

                            <%-- <div class="col-md-12" style="padding-left: 0px;">
                                <div class="row" style="padding-bottom: 8px;">

                                    <div class="col-md-3" style="padding-left: 0px;">
                                        Time
                                    </div>
                                    <div class="col-md-9" style="padding-left: 0px;">
                                        <div class="form-control">
                                            <cc1:TimeSelector ID="txtAttInTime" runat="server" Hour="9" Minute="0" Second="0" CssClass="time_section" SelectedTimeFormat="TwentyFour"
                                                AllowSecondEditing="True" AmPm="AM" BorderColor="Silver"
                                                Date="01/01/0001 09:00:00">
                                            </cc1:TimeSelector>
                                        </div>


                                    </div>

                                </div>

                            </div>--%>
                            <div class="col-md-12" style="padding-left: 0px;">

                                <div class="row" style="padding-bottom: 8px;">

                                    <div class="col-md-3" style="padding-left: 0px;">
                                        Remark
                                    </div>
                                    <div class="col-md-9" style="padding-left: 0px;">

                                        <asp:TextBox ID="txtbxremark" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                            </div>
                            <div class="col-md-12" style="padding-left: 0px;">
                                <div class="row">
                                    <div class="col-md-3" style="padding-left: 0px;">
                                    </div>
                                    <div class="col-md-9" style="padding-left: 0px;">

                                        <asp:Button ID="btnConfirm" runat="server" Text="Confirm" CssClass="btn btn-primary pull right" OnClick="btn_Confirm_Clcik" />
                                        <asp:Button ID="btnProcess" runat="server" Text="Process" CssClass="btn btn-info pull right" OnClick="btnProcess_Click" Style="margin-right: 5px" />
                                    </div>
                                </div>
                            </div>
                    </div>
                    <div class="col-md-8">
                        <br />
                        <asp:GridView ID="grdview" runat="server" AutoGenerateColumns="False" Width="100%"
                            CellPadding="4" BackColor="White" BorderColor="#336666"
                            BorderStyle="Solid" BorderWidth="1px" AllowPaging="false">
                            <Columns>

                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox runat="server" ID="headerLevelCheckBox" AutoPostBack="true" OnCheckedChanged="headerLevelCheckBox_CheckedChanged" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="rowLevelCheckBox" runat="server" />
                                        <headerstyle verticalalign="Middle" cssclass="Grid_Header" />
                                        <itemstyle horizontalalign="Left" width="1%" cssclass="Grid_Border" />
                                        <footerstyle cssclass="Grid_Footer" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField Visible="False" HeaderText="EID">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEID" runat="server" Text='<%# Eval("EID")%>' />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                </asp:TemplateField>

                                <%-- <asp:BoundField DataField="EID" HeaderText="E-ID">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>


                                <asp:BoundField DataField="EmployeeFullName" HeaderText="Employee Name">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>

                                <asp:BoundField DataField="DEG_NAME" HeaderText="Designation">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>--%>

                                <asp:BoundField DataField="AttendanceDate" DataFormatString="{0:MMMM d, yyyy}" HeaderText="Attendance Date">
                                    <ItemStyle HorizontalAlign="Center" Width="25%" />
                                </asp:BoundField>

                                <%--   <asp:BoundField DataField="InTime" HeaderText="In time">
                                    <ItemStyle HorizontalAlign="Center" Width="15%" />
                                </asp:BoundField>
                                  <asp:BoundField DataField="OutTime" HeaderText="Out time">
                                    <ItemStyle HorizontalAlign="Center" Width="15%" />
                                </asp:BoundField>--%>

                                <asp:TemplateField Visible="False" HeaderText="Attendance Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAttendanceDate" runat="server" Text='<%# Eval("AttendanceDate")%>' />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="In Time">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtbxIntime" runat="server" Width="100%" ToolTip="Enter Time" Text='<%# Bind("In_Time") %>' Style="text-align: center"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="25%" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Out Time">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtbxOuttime" runat="server" Width="100%" ToolTip="Enter Time" Text='<%# Bind("Out_Time") %>' Style="text-align: center"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="25%" />
                                </asp:TemplateField>

                                <asp:BoundField DataField="Status" HeaderText="Status">
                                    <ItemStyle HorizontalAlign="Center" Width="15%" />
                                </asp:BoundField>

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
     
            </div>

            <script type="text/javascript">

                function func(result) {
                    if (result === 'Data Updated Successfully') {
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
