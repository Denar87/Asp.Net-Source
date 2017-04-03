<%@ Page Title="" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true" CodeBehind="Increment.aspx.cs" Inherits="ERPSSL.HRM.Increment" %>

<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <%--<ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>--%>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
        <ContentTemplate>
            <div class="row hm_sec_2_content scrollbar">
                <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="fa fa-edit fa-fw icon-padding"></i>Increment
                    </div>
                </div>
                <div class="col-md-12 bg-success">
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                    <asp:HiddenField ID="hdnOffice" runat="server" />
                </div>
                <div class="row">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-6">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Region
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="ddlRegion" CssClass="form-control" runat="server"
                                                AutoPostBack="True" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged">
                                            </asp:DropDownList>

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
                                            <asp:DropDownList ID="ddlOffice" CssClass="form-control" runat="server"
                                                AutoPostBack="True" OnSelectedIndexChanged="ddlOffice_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Department
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="drpDepartment" CssClass="form-control" runat="server"
                                                AutoPostBack="True" OnSelectedIndexChanged="drpDepartment_SelectedIndexChanged">
                                            </asp:DropDownList>

                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Gross
                                        </div>
                                        <div class="col-md-2">

                                            <asp:TextBox ID="txtGross" runat="server" Width="135%" placeholder="%" class="form-control"></asp:TextBox>


                                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" SetFocusOnError="true"
                                        ControlToValidate="txtGross" ValidationGroup="vIncrement"></asp:RequiredFieldValidator>--%>
                                        </div>
                                        <div class="col-md-1" style="color: #f00;" > OR </div>
                                        <div class="col-md-4">

                                            <asp:TextBox ID="txtbxGrossAmount" runat="server" placeholder="Amount" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <%-- <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-5">
                                    Gross Amount
                                </div>
                                <div class="col-md-7">

                                    <asp:TextBox ID="txtbxGrossAmount" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>--%>
                                <%--                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-5">
                                    Year
                                </div>
                                <div class="col-md-7">
                                    <asp:TextBox ID="txtDateFrom" CssClass="form-control" runat="server"></asp:TextBox>
                                      <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtDateFrom"
                                            PopupButtonID="txtDateFrom" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />            
                                                        
                                    
                                </div>
                            </div>
                        </div>
                                --%>
                                <%--<br />--%>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                        </div>
                                        <div class="col-md-3">
                                            <asp:Button ID="btnSave" runat="server" Text="Process" class="btn btn-info  pull-right"
                                                OnClick="btnSave_Click" ValidationGroup="vIncrement" />
                                        </div>

                                        <div class="col-md-4">
                                            <asp:Button ID="btnConformation" runat="server" Text="Confirmation" class="btn btn-level"
                                        OnClick="btnConformation_Click" ValidationGroup="vIncrement" />
                                            
                                        </div>


                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                            </div>
                        </div>
                        <br />
                        <div class="row" id="divGradeViewEmployee" runat="server">
                            <%--<div class="col-md-12">--%>
                                <fieldset style="border: none;">
                                    <asp:GridView ID="grdemployees" runat="server" EmptyDataText="No Records Found!"
                                        AutoGenerateColumns="False" Width="80%"
                                        DataKeyNames="EID" ShowFooter="False" CellPadding="5" PageSize="50" OnPageIndexChanging="grdemployees_PageIndexChanging">
                                        <Columns>
                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEID" runat="server" Text='<%# Eval("EID")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSalary" runat="server" Text='<%# Eval("EMP_Salary")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="EID" HeaderText="E-ID">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="5%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="EMP_Name" HeaderText="Name">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DEG_NAME" HeaderText="Designation">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="12%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="EMP_CONTACT_NO" HeaderText="contact">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DPT_NAME" HeaderText="Dept.">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Old_Salary" HeaderText="Previous Salary">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="EMP_Salary" HeaderText="Current Salary">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Gross_Rate" HeaderText="Increment Amount">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="8%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>

                                           <%-- <asp:BoundField DataField="IncrementRate" HeaderText="Increment Rate">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="8%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            --%>

                                            <asp:BoundField DataField="Salary_Update_Date" HeaderText="Increment Time">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>

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

                                            <%--<asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgbtnEmployeeEdit" runat="server" ImageUrl="img/list_edit.png"
                                            OnClick="imgbtnEmployeeEdit_Click" />
                                    </ItemTemplate>
                                    <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                                </asp:TemplateField>--%>
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
                           <%-- </div>--%>
                        </div>

                        <div class="row" id="divGridviewTemployeeData" runat="server">
                            <div class="col-md-12">
                                <fieldset style="border: none;">
                                    <asp:GridView ID="gridviewTemployeData" runat="server" EmptyDataText="No Records Found!"
                                        AutoGenerateColumns="False" Width="80%"
                                        DataKeyNames="EID" ShowFooter="False" CellPadding="5" PageSize="50" OnPageIndexChanging="gridviewTemployeData_PageIndexChanging">
                                        <Columns>
                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEID" runat="server" Text='<%# Eval("EID")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOldSalary" runat="server" Text='<%# Eval("PreviousSalary")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="CurrentSalary" runat="server" Text='<%# Eval("CurrentSalary")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="IncrementAmount" runat="server" Text='<%# Eval("IncrementAcount")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:BoundField DataField="EID" HeaderText="E-ID">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="5%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Name" HeaderText="Name">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Designation" HeaderText="Designation">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="12%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="Contact" HeaderText="contact">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Department" HeaderText="Dept.">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="PreviousSalary" HeaderText="Previous Salary">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CurrentSalary" HeaderText="Current Salary">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <%-- <asp:BoundField DataField="IncrementAcount" HeaderText="Increment Amount">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Left" Width="8%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>--%>
                                            <asp:BoundField DataField="IncrementDate" HeaderText="Increment Time">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Increment Amount">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtbxIncrementAmount" runat="server" Text='<%# Eval("IncrementAcount")%>'></asp:TextBox>
                                                </ItemTemplate>

                                                <%-- <FooterStyle HorizontalAlign="Right" />
                                        <FooterTemplate>
                                            <asp:Button ID="ButtonAdd1" runat="server" Text="Add New Row"
                                                CssClass="btnNormalAdd" />
                                        </FooterTemplate>--%>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="ACTIONS">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgbtnEdit" runat="server" ImageUrl="resources/ico/dg_edit.png"
                                                        OnClick="imgbtnEdit_Click" />
                                                </ItemTemplate>
                                                <HeaderStyle Width="5%" VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Delete">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgDeletePagePermission" runat="server" OnClick="imgDeletePagePermission_Click" ImageUrl="../Adminpanel/resources/list_Delete.png" />
                                                </ItemTemplate>
                                                <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                                            </asp:TemplateField>

                                            <%--<asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgbtnEmployeeEdit" runat="server" ImageUrl="img/list_edit.png"
                                            OnClick="imgbtnEmployeeEdit_Click" />
                                    </ItemTemplate>
                                    <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                                </asp:TemplateField>--%>
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

                        <br />
                        <%--<div class="row">
                            <div class="col-md-12" id="btnConformationId" visible="false" runat="server">
                                <div class="col-md-5">
                                </div>
                                <div class="col-md-7">
                                    
                                </div>
                            </div>
                        </div>--%>

                    </div>


                </div>
            </div>

        </ContentTemplate>

        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="ddlRegion" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="ddlOffice" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="drpDepartment" EventName="SelectedIndexChanged" />

        </Triggers>
    </asp:UpdatePanel>
    <script>

        function func(result) {

            if (result === 'Input Gross % or Gross Amount') {
                toastr.error(result);
            }
            else if (result === 'Data Update Successfully') {
                toastr.success(result);

            }
            else if (result === 'Data Delete Successfully') {
                toastr.success(result);

            }
            else if (result === 'Data Save Successfully') {
                toastr.success(result);

            }

            return false;
        }

    </script>
</asp:Content>
