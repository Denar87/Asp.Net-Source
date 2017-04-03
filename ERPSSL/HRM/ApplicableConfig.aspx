<%@ Page Title="" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true" CodeBehind="ApplicableConfig.aspx.cs" Inherits="ERPSSL.HRM.ApplicableConfig" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>


    <div class="hm_sec_2_content scrollbar">
        <div class="panel">
            <div class="panel-heading panel-heading-01">
                <i class="fa fa-edit fa-fw icon-padding"></i>Applicable Config
            </div>
        </div>
        <div class="row">



            <div class="col-md-12">

                <fieldset>
                    <legend style="line-height: 5px;"><span style="background: #fff">Select for Search</span></legend>


                    <div class="col-md-4" style="padding-left: 0px;">

                        <div class="row">

                            <div class="col-md-3" style="padding-left: 0px;">
                                Region
                            </div>
                            <div class="col-md-12" style="padding-left: 0px;">
                                <asp:DropDownList ID="ddlRegion1" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="drpdwnResion1ForDepartmentSelecttedIndexChanged"
                                    runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <br />
                    </div>

                    <div class="col-md-4" style="padding-left: 0px;">

                        <div class="row">

                            <div class="col-md-3" style="padding-left: 0px;">
                                Office
                            </div>
                            <div class="col-md-12" style="padding-left: 0px;">
                                <asp:DropDownList ID="ddlOffice1" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="onSelectedIndedexChangeOffice1"
                                    runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <br />
                    </div>


                    <div class="col-md-4" style="padding-left: 0px;">

                        <div class="row">

                            <div class="col-md-3" style="padding-left: 0px;">
                                Department
                            </div>
                            <div class="col-md-12" style="padding-left: 0px;">
                                <asp:DropDownList ID="ddlDept1" AutoPostBack="True" CssClass="form-control"
                                    runat="server" OnSelectedIndexChanged="drpdwnDepartment1SelectedIndexChange">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <br />
                    </div>


                    <div class="col-md-4" style="padding-left: 0px;">

                        <div class="row">

                            <div class="col-md-3" style="padding-left: 0px;">
                                Section
                            </div>
                            <div class="col-md-12" style="padding-left: 0px;">
                                <asp:DropDownList ID="ddlSection" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="ddlSection_SelecttedIndexChanged"
                                    runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <br />
                    </div>

                    <div class="col-md-4" style="padding-left: 0px;">

                        <div class="row">

                            <div class="col-md-3" style="padding-left: 0px;">
                                Sub-Section
                            </div>
                            <div class="col-md-12" style="padding-left: 0px;">
                                <asp:DropDownList ID="ddlSubSections" CssClass="form-control"
                                    runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <br />
                    </div>


                    <div class="col-md-4" style="padding-left: 0px;">

                        <div class="row">

                            <div class="col-md-3" style="padding: 0px;">
                                E-ID
                            </div>
                            <div class="col-md-12" style="padding-left: 0px;">
                                <asp:TextBox ID="txtbxEid" runat="server" CssClass="form-control"></asp:TextBox>

                            </div>
                        </div>
                    </div>
                    <div class="col-md-12" style="padding: 0px;">
                        <asp:CheckBox ID="chSalaryCheck" AutoPostBack="true" OnCheckedChanged="chSalaryCheck_buttonClick" GroupName="MeasurementSystem" runat="server" Text="Salary Wise Search" />

                    </div>
                    <div class="col-md-4" style="padding: 0px;">
                        <asp:TextBox ID="txtbxSalarySearch" runat="server" CssClass="form-control" placeholder="From Salary" Style="width: 325px;"></asp:TextBox>
                    </div>
                    <div class="col-md-4" style="padding: 0px;">
                        <asp:TextBox ID="txtbxSalryFrom" runat="server" placeholder="To Salary" CssClass="form-control" Style="width: 325px;"></asp:TextBox>
                    </div>

                    <div class="col-md-12" style="padding-top: 16px">
                        <div class="pull-right">
                            <asp:Button ID="btnProcess" runat="server" Text="Process" Width="80px" CssClass="btn btn-info" OnClick="btnProcess_Click" />
                            <asp:Button ID="btnConfirm" runat="server" Text="Confirm" Width="80px" CssClass="btn btn-primary" OnClick="btn_Confirm_Clcik" />
                        </div>
                    </div>

                </fieldset>
            </div>

            <br />
            <div class="col-md-12" style="padding-bottom:10px">
                <asp:GridView ID="grdview" runat="server" AutoGenerateColumns="False" Width="100%"
                    CellPadding="4" BackColor="White" BorderColor="#336666"
                    BorderStyle="Solid" BorderWidth="1px" AllowPaging="false">
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

                        <asp:TemplateField Visible="False" HeaderText="E-ID">
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

                          <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:CheckBox runat="server" ID="headOtApplicable" AutoPostBack="true" Text="OT. Applicable" OnCheckedChanged="headOtApplicable_CheckedChanged" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="roqOTApplicable" Checked='<%# bool.Parse(Eval("OT_Applicable").ToString() == "True" ? "True": "False")%>' runat="server" />
                                <headerstyle verticalalign="Middle" cssclass="Grid_Header" />
                                <itemstyle horizontalalign="Left" width="10%" cssclass="Grid_Border" />
                                <footerstyle cssclass="Grid_Footer" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:CheckBox runat="server" ID="headAttendanceBouns" AutoPostBack="true" Text="Att. Bouns Applicable" OnCheckedChanged="headAttendanceBouns_CheckedChanged" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="roqAttendanceBouns" Checked='<%# bool.Parse(Eval("Attendance_Bouns").ToString() == "True" ? "True": "False")%>' runat="server" />
                                <headerstyle verticalalign="Middle" cssclass="Grid_Header" />
                                <itemstyle horizontalalign="Left" width="10%" cssclass="Grid_Border" />
                                <footerstyle cssclass="Grid_Footer" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:CheckBox runat="server" ID="headlateApplicable" AutoPostBack="true" Text="Late Applicable" OnCheckedChanged="headlateApplicable_CheckedChanged" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="rowAlateApplicable" runat="server" Checked='<%# bool.Parse(Eval("Late_Applicable").ToString() == "True" ? "True": "False")%>' />
                                <headerstyle verticalalign="Middle" cssclass="Grid_Header" />
                                <itemstyle horizontalalign="Left" width="10%" cssclass="Grid_Border" />
                                <footerstyle cssclass="Grid_Footer" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:CheckBox runat="server" ID="headAbsenceApplic" AutoPostBack="true" Text="Absent Applicable" OnCheckedChanged="headAbsenceApplic_CheckedChanged" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="rowAbsenceApplic" runat="server" Checked='<%# bool.Parse(Eval("Absence_Applicable").ToString() == "True" ? "True": "False")%>' />
                                <headerstyle verticalalign="Middle" cssclass="Grid_Header" />
                                <itemstyle horizontalalign="Left" width="10%" cssclass="Grid_Border" />
                                <footerstyle cssclass="Grid_Footer" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:CheckBox runat="server" ID="headTaxApplic" AutoPostBack="true" Text="TAX Applicable" OnCheckedChanged="headTaxApplic_CheckedChanged" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="rowTaxApplic" runat="server" Checked='<%# bool.Parse(Eval("Tax_Applicable").ToString() == "True" ? "True": "False")%>' />
                                <headerstyle verticalalign="Middle" cssclass="Grid_Header" />
                                <itemstyle horizontalalign="Left" width="10%" cssclass="Grid_Border" />
                                <footerstyle cssclass="Grid_Footer" />
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:CheckBox runat="server" ID="headpfApplic" AutoPostBack="true" Text="PF Applicable" OnCheckedChanged="headpfApplic_CheckedChanged" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="rowPfApplic" runat="server" Checked='<%# bool.Parse(Eval("PF_Applicable").ToString() == "True" ? "True": "False")%>' />
                                <headerstyle verticalalign="Middle" cssclass="Grid_Header" />
                                <itemstyle horizontalalign="Left" width="10%" cssclass="Grid_Border" />
                                <footerstyle cssclass="Grid_Footer" />
                            </ItemTemplate>
                        </asp:TemplateField>

                       <%-- <asp:TemplateField Visible="false">
                            <HeaderTemplate>
                                <asp:CheckBox runat="server" ID="headONAmount" AutoPostBack="true" Text="On Amount" OnCheckedChanged="headONAmount_CheckedChanged" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="rowonAmount" runat="server" Checked='<%# bool.Parse(Eval("On_Amount").ToString() == "True" ? "True": "False")%>' />
                                <headerstyle verticalalign="Middle" cssclass="Grid_Header" />
                                <itemstyle horizontalalign="Left" width="10%" cssclass="Grid_Border" />
                                <footerstyle cssclass="Grid_Footer" />
                            </ItemTemplate>
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


    <script type="text/javascript">

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
