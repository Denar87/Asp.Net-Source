<%@ Page Title="" Language="C#" MasterPageFile="~/PAYROLL/Site.Master" AutoEventWireup="true" CodeBehind="Salary_Punishment.aspx.cs" Inherits="ERPSSL.PAYROLL.Salary_Punishment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
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
                        <i class="fa fa-edit fa-fw icon-padding"></i>Salary Punishment 
                    </div>

                </div>
                <div class="col-md-12">
                    <div class="col-md-4">
                        <fieldset>
                            <legend style="line-height: 5px;"><span style="background: #fff">Select for Process</span></legend>
                            <div class="col-md-12">
                                <div class="col-md-2" style="padding-left: 0px;">
                                </div>
                                <div class="col-md-10" style="padding-right: 0px;">
                                    <asp:CheckBox ID="ckIndividualSalaryPunish" AutoPostBack="true" OnCheckedChanged="ckIndividualSalaryPunish_click" runat="server" Text="Individual Employee" />
                                </div>
                            </div>
                            <div class="col-md-12" runat="server" id="region" style="padding-left: 0px;">

                                <div class="row" style="padding-bottom: 8px;">
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

                            <div class="col-md-12" runat="server" id="office" style="padding-left: 0px;">

                                <div class="row" style="padding-bottom: 8px;">
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

                            <div class="col-md-12" runat="server" id="department" style="padding-left: 0px;">

                                <div class="row" style="padding-bottom: 8px;">
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

                            </div>

                            <div class="col-md-12" runat="server" id="section" style="padding-left: 0px;">

                                <div class="row" style="padding-bottom: 8px;">
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

                            </div>
                            <div class="col-md-12" runat="server" id="subsection" style="padding-left: 0px;">
                                <div class="row" style="padding-bottom: 8px;">
                                    <%-- <h5 style="padding-left: 0px;">Sub-Section
                                    </h5>--%>
                                    <div class="col-md-3" style="padding-left: 0px;">
                                        Sub-Section
                                    </div>
                                    <div class="col-md-9" style="padding-left: 0px;">
                                        <asp:DropDownList ID="ddlSubSections" CssClass="form-control"
                                            runat="server">
                                        </asp:DropDownList>

                                    </div>

                                </div>

                            </div>
                            <%--  <div class="col-md-12" style="padding-left: 0px;">
                                <div class="row" style="padding-bottom: 8px;">
                                    
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

                            </div>--%>

                            <div class="col-md-12" runat="server" id="divEid" style="padding-left: 0px;">
                                <div class="row" style="padding-bottom: 8px;">

                                    <div class="col-md-3" style="padding-left: 0px;">
                                        E-ID
                                    </div>

                                    <div class="col-md-9" style="padding-left: 0px;">

                                      <asp:TextBox Class="form-control" runat="server" AutoPostBack="true" ID="txtbxEID" OnTextChanged="txtbxEID_TextChangeEvent"
                                            placeholder="E-ID"></asp:TextBox>

                                           <cc2:AutoCompleteExtender ServiceMethod="SearchCustomers"
                                            MinimumPrefixLength="1"
                                            CompletionInterval="100" EnableCaching="False"
                                            TargetControlID="txtbxEID"
                                            ID="AutoCompleteExtender1" runat="server" DelimiterCharacters="" Enabled="True" ServicePath="">
                                        </cc2:AutoCompleteExtender>
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
                                            placeholder="Wing"></asp:TextBox>

                                    </div>
                                </div>


                            </div>
                            <div class="col-md-12" runat="server" id="divDesgination" style="padding-left: 0px;">
                                <div class="row" style="padding-bottom: 8px;">
                                    <div class="col-md-3" style="padding-left: 0px;">
                                        Designation
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
                                        Salary Month
                                    </div>
                                    <div class="col-md-9" style="padding-left: 0px;">
                                        <asp:DropDownList ID="ddlMonthList" CssClass="form-control"
                                            runat="server">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlMonthList"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Month Required"
                                            Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-12" style="padding-left: 0px;">
                                <div class="row" style="padding-bottom: 8px;">
                                    <div class="col-md-3" style="padding-left: 0px;">
                                        Salary Year
                                    </div>
                                    <div class="col-md-9" style="padding-left: 0px;">
                                        <asp:DropDownList ID="ddlYearList" CssClass="form-control"
                                            runat="server">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlYearList"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Year Required"
                                            Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-12" runat="server" id="divDeduct" style="padding-left: 0px;">
                                <div class="row" style="padding-bottom: 8px;">
                                    <div class="col-md-3" style="padding-left: 0px;">
                                        Deduction Type
                                    </div>
                                    <div class="col-md-9" style="padding-left: 0px;">
                                        <asp:DropDownList ID="ddlDeductionType" CssClass="form-control"
                                            runat="server">
                                            <asp:ListItem Text="-- Select Type--" Value="0"></asp:ListItem>
                                            <asp:ListItem>Day</asp:ListItem>
                                            <asp:ListItem>Amount</asp:ListItem>
                                        </asp:DropDownList>

                                    </div>
                                </div>
                            </div> 

                             <div class="col-md-12" runat="server" id="divDiductdayamt" style="padding-left: 0px;">
                                <div class="row" style="padding-bottom: 8px;">
                                    <div class="col-md-3" style="padding-left: 0px;">
                                        Deduct Day/Amount
                                    </div>

                                    <div class="col-md-9" style="padding-left: 0px;">
                                        <asp:TextBox class="form-control" runat="server" ID="txtbxDeduct"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

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

                                        <asp:Button ID="btnConfirm" runat="server" Text="Confirm" ValidationGroup="Group1" CssClass="btn btn-primary pull right" OnClick="btn_Confirm_Click" />
                                        <asp:Button ID="btnProcess" runat="server" Text="Process" ValidationGroup="Group1" CssClass="btn btn-info pull right" OnClick="btnProcess_Click" Style="margin-right: 5px" />
                                    </div>
                                </div>
                            </div>
                        </fieldset>
                    </div>


                    <div class="col-md-8" style="padding-bottom: 8px">
                        <br />
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
                                        <asp:CheckBox runat="server" ID="headerLevelCheckBox" onclick="checkAll(this);" OnCheckedChanged="headerLevelCheckBox_CheckedChanged" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="rowLevelCheckBox" runat="server" onclick="Check_Click(this)" />
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

                                <asp:BoundField DataField="Salary_Month" HeaderText="Salary Month">
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Salary_Year" HeaderText="Salary Year">
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                </asp:BoundField>

                                <asp:TemplateField HeaderText="Deduct Day/Amount" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txttotalDeductDayOrAmt" runat="server" Width="100%" ToolTip="Enter Deduct Day" Text='<%# Bind("TotalDeductDay") %>' Style="text-align: center"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>


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




            </div>

            </div>
                <%--<div class="col-md-12">
                        <div class="row radio_input00">
                           
                        </div>

                    </div>--%>
            </div>

              <script type="text/javascript">
                  function Check_Click(objRef) {

                      //Get the Row based on checkbox
                      var row = objRef.parentNode.parentNode;
                      if (objRef.checked) {
                          //If checked change color to Aqua
                          row.style.backgroundColor = "MistyRose";
                      }
                      else {

                          row.style.backgroundColor = "white";
                      }


                      //Get the reference of GridView
                      var GridView = row.parentNode;

                      //Get all input elements in Gridview
                      var inputList = GridView.getElementsByTagName("input");

                      for (var i = 0; i < inputList.length; i++) {
                          //The First element is the Header Checkbox
                          var headerCheckBox = inputList[0];

                          //Based on all or none checkboxes
                          //are checked check/uncheck Header Checkbox
                          var checked = true;
                          if (inputList[i].type == "checkbox" && inputList[i] != headerCheckBox) {
                              if (!inputList[i].checked) {
                                  checked = false;
                                  break;
                              }
                          }
                      }
                      headerCheckBox.checked = checked;

                  }
            </script>
            <script type="text/javascript">
                function checkAll(objRef) {
                    var GridView = objRef.parentNode.parentNode.parentNode;
                    var inputList = GridView.getElementsByTagName("input");
                    for (var i = 0; i < inputList.length; i++) {
                        //Get the Cell To find out ColumnIndex
                        var row = inputList[i].parentNode.parentNode;
                        if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                            if (objRef.checked) {
                                //If the header checkbox is checked
                                //check all checkboxes
                                //and highlight all rows
                                row.style.backgroundColor = "MistyRose";
                                inputList[i].checked = true;
                            }
                            else {

                                row.style.backgroundColor = "white";
                                inputList[i].checked = false;
                            }
                        }
                    }
                }
            </script>

            <script type="text/javascript">

                function func(result) {
                    if (result === 'Data Update Successfully') {
                        toastr.success(result);

                    }
                    else if (result === 'Data Process Successfully') {
                        toastr.success(result)
                    }
                    else if (result === 'Please Select Region') {
                        toastr.error(result);
                    }

                    else if (result === 'Please Select E-ID') {
                        toastr.error(result)
                    }
                    else
                        toastr.error(result);

                    return false;
                }

            </script>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
