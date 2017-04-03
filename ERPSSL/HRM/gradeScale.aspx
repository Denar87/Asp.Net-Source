<%@ Page Title="" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true"
    CodeBehind="gradeScale.aspx.cs" Inherits="ERPSSL.HRM.gradeScale" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
<ContentTemplate>
    <div class="panel">
        <div class="panel-heading panel-heading-01">
            <i class="fa fa-edit fa-fw icon-padding"></i>Setup Grade Scale
        </div>
    </div>
    <div class="hm_sec_2_content scrollbar">
    <div class="row">
        <div class="col-md-12">

            <asp:Button ID="btnNewInsert" runat="server" Text="Add Grade +" CssClass="btn btn-primary"
                OnClick="btnNewInsert_Click" Width="120px" />
            <asp:UpdatePanel ID="UpdatePanelDatagrid" runat="server">
                <ContentTemplate>
                    <asp:Label ID="lblMessageUpanel" runat="server"></asp:Label>
                    <br />
                    <asp:GridView ID="GridViewGRADE" runat="server" EmptyDataText="No Records Found!"
                        AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" Width="100%"
                        DataKeyNames="GRADE_ID" ShowFooter="True" CellPadding="5" OnPageIndexChanging="GridViewGRADE_PageIndexChanging"
                        OnRowDeleting="GridViewGRADE_RowDeleting" OnRowCommand="GridViewGRADE_RowCommand">
                        <Columns>
                         <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            Sl No.
                                        </HeaderTemplate>
                                        <ItemTemplate  >
                                            <asp:Label ID="lblSRNO" runat="server"
                                                Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                        </ItemTemplate>
                              <HeaderStyle Width="5%" VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                    </asp:TemplateField>
                            <asp:BoundField DataField="STEP" HeaderText="STEP">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="5%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                            <asp:BoundField DataField="GRADE" HeaderText="GRADE">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                            <asp:BoundField DataField="GROSS_SAL" HeaderText="GROSS">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="5%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                            <asp:BoundField DataField="HOUSE_RENT" HeaderText="HOUSE RENT">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="5%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BASIC" HeaderText="BASIC">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="5%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                            <asp:BoundField DataField="MEDICAL" HeaderText="MEDICAL">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="5%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CONVEYANCE" HeaderText="CONVEYANCE">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="5%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FOOD_ALLOW" HeaderText="FOOD">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="5%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                            <asp:BoundField DataField="OTHERS" HeaderText="OTHERS">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="5%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                            <asp:BoundField DataField="REMARKS" HeaderText="REMARKS">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="5%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="ACTIONS">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButtonEdit" runat="server" CommandName="GradeEdit" CommandArgument='<%#Eval("GRADE_ID") %>'>
                                                    <img src="resources/ico/dg_edit.png" />
                                    </asp:LinkButton>
                                    <asp:ImageButton ID="imgDelete" runat="server" ImageUrl="resources/ico/dg_delete.png"
                                        ToolTip="Delete" CommandName="Delete" CausesValidation="false" OnClientClick="return confirm('Are you sure you want to delete?')"
                                        CssClass="dgvEMS_row_edit" />
                                </ItemTemplate>
                                <HeaderStyle Width="5%" VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataRowStyle ForeColor="Red" />
                        <RowStyle CssClass="Grid_RowStyle" />
                        <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                        <PagerSettings Mode="NumericFirstLast" />
                        <PagerStyle BackColor="#6393c1" ForeColor="White" HorizontalAlign="Left" CssClass="pagination01 pageback" />
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
            <asp:Panel ID="Panel1" runat="server" Style="display: none" CssClass="modalPopup">
                <asp:Panel ID="Panel3" runat="server" Style="cursor: move; background-color: #DDDDDD; border: solid 1px Gray; color: Black">
                    <asp:LinkButton ID="CancelButton" runat="server" CssClass="close_pop">
                                    <img src="resources/ico/close.png" />
                    </asp:LinkButton>
                </asp:Panel>
                <asp:UpdatePanel ID="UpdatePanelSubmit" runat="server">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnSubmit" />
                    </Triggers>
                    <ContentTemplate>
                        <h2>Grade Info (<asp:Label ID="lblID" runat="server"></asp:Label>)</h2>
                        <div>
                            <%--Progress--%>
                            <div class="load_progress">
                                <asp:UpdateProgress runat="server" ID="UpdateProgress1">
                                    <ProgressTemplate>
                                        Please wait
                                    <img src="resources/ico/ajax_loading.gif" />
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                            <%--Pregress--%>
                            <asp:Label ID="lblModalMessage" runat="server" Font-Bold="true"></asp:Label>
                            <fieldset>
                                <legend>Grade Info</legend>

                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="17%">
                                            <label>
                                                Step:</label>
                                        </td>
                                        <td width="33%">
                                            <%--  <asp:TextBox ID="txtStep" runat="server"></asp:TextBox>--%>
                                            <asp:DropDownList ID="drpStep" runat="server">
                                                <asp:ListItem Value="1">Step-1</asp:ListItem>
                                                <asp:ListItem Value="2">Step-2</asp:ListItem>
                                                <asp:ListItem Value="3">Step-3</asp:ListItem>
                                                <asp:ListItem Value="4">Step-4</asp:ListItem>
                                                <asp:ListItem Value="5">Step-5</asp:ListItem>
                                                <asp:ListItem Value="6">Step-6</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="drpStep"
                                                ForeColor="Red" ValidationGroup="validation" ErrorMessage="*" runat="server"
                                                Display="dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <%--   <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtStep"
                                            ErrorMessage="Please Enter Only Numbers!" ForeColor="Red" ValidationExpression="^\d+$"
                                            ValidationGroup="validation"></asp:RegularExpressionValidator>--%>
                                        </td>
                                        <td width="18%">
                                            <label>
                                                Grade:</label>
                                        </td>
                                        <td width="32%">
                                            <asp:TextBox ID="txtGrade" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtGrade"
                                                ForeColor="Red" ValidationGroup="validation" ErrorMessage="*" runat="server"
                                                Display="dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>
                                                Basic:
                                            </label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBasic" runat="server" Width="120px"></asp:TextBox>
                                            <asp:TextBox ID="txtBasicpr" onchange="calBasicPr()" placeholder="%" runat="server"
                                                Width="40px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtBasic"
                                                ForeColor="Red" ValidationGroup="validation" ErrorMessage="*" runat="server"
                                                Display="dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtBasic"
                                                ErrorMessage="Please Enter Only Numbers!" ForeColor="Red" ValidationExpression="^\d+$"
                                                ValidationGroup="validation"></asp:RegularExpressionValidator>
                                        </td>
                                        <td>
                                            <label>
                                                House Rent:
                                            </label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtHouseRent" Width="120px" runat="server"></asp:TextBox>
                                            <asp:TextBox ID="txtHouseRentpr" onchange="calHouseRentpr()" placeholder="%" runat="server"
                                                Width="40px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtHouseRent"
                                                ForeColor="Red" ValidationGroup="validation" ErrorMessage="*" runat="server"
                                                Display="dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtHouseRent"
                                                ErrorMessage="Please Enter Only Numbers!" ForeColor="Red" ValidationExpression="^\d+$"
                                                ValidationGroup="validation"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>
                                                Conveyance:
                                            </label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtConveyance" Width="120px" runat="server"></asp:TextBox>
                                            <asp:TextBox ID="txtConveyancepr" onchange="calConveyancepr()" placeholder="%" runat="server"
                                                Width="40px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="txtConveyance"
                                                ForeColor="Red" ValidationGroup="validation" ErrorMessage="*" runat="server"
                                                Display="dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtConveyance"
                                                ErrorMessage="Please Enter Only Numbers!" ForeColor="Red" ValidationExpression="^\d+$"
                                                ValidationGroup="validation"></asp:RegularExpressionValidator>
                                        </td>
                                        <td>
                                            <label>
                                                Medical:
                                            </label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMedical" Width="120px" runat="server"></asp:TextBox>
                                            <asp:TextBox ID="txtMedicalpr" onchange="calmedicalpr()" placeholder="%" runat="server"
                                                Width="40px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txtMedical"
                                                ForeColor="Red" ValidationGroup="validation" ErrorMessage="*" runat="server"
                                                Display="dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtMedical"
                                                ErrorMessage="Please Enter Only Numbers!" ForeColor="Red" ValidationExpression="^\d+$"
                                                ValidationGroup="validation"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>
                                                Food Allowance:
                                            </label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFoodAllowance" Width="120px" runat="server"></asp:TextBox>
                                            <asp:TextBox ID="txtFoodAllowancepr" onchange="calfoodAllowancepr()" placeholder="%"
                                                runat="server" Width="40px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="txtFoodAllowance"
                                                ForeColor="Red" ValidationGroup="validation" ErrorMessage="*" runat="server"
                                                Display="dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtFoodAllowance"
                                                ErrorMessage="Please Enter Only Numbers!" ForeColor="Red" ValidationExpression="^\d+$"
                                                ValidationGroup="validation"></asp:RegularExpressionValidator>
                                        </td>
                                        <td>
                                            <label>
                                                Others:
                                            </label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtOthers" Width="120px" runat="server"></asp:TextBox>
                                            <asp:TextBox ID="txtOtherspr" onchange="calotherpr()" placeholder="%" runat="server"
                                                Width="40px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtOthers"
                                                ForeColor="Red" ValidationGroup="validation" ErrorMessage="*" runat="server"
                                                Display="dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtOthers"
                                                ErrorMessage="Please Enter Only Numbers!" ForeColor="Red" ValidationExpression="^\d+$"
                                                ValidationGroup="validation"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>
                                                Remarks:
                                            </label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRemarks" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="txtRemarks"
                                                ForeColor="Red" ValidationGroup="validation" ErrorMessage="*" runat="server"
                                                Display="dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <label>
                                                Gross Salary:
                                            </label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtGrsSal" onclick="txtBox1_ClientClicked()" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtGrsSal"
                                                ForeColor="Red" ValidationGroup="validation" ErrorMessage="*" runat="server"
                                                Display="dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtGrsSal"
                                                ErrorMessage="Please Enter Only Numbers!" ForeColor="Red" ValidationExpression="^\d+$"
                                                ValidationGroup="validation"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                            <div class="clear">
                            </div>
                            <div class="submission">
                                <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" Width="80px"
                                    CssClass="btn btn-info pull-right" />
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" Width="80px" OnClick="btnSubmit_Click"
                                    ValidationGroup="validation" CssClass="btn btn-info pull-right" />
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" Width="80px" OnClick="btnUpdate_Click"
                                    Visible="false" CssClass="btn btn-info pull-right" />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender" runat="server" TargetControlID="LinkButton1"
                PopupControlID="Panel1" BackgroundCssClass="modalBackground" CancelControlID="CancelButton"
                DropShadow="True" PopupDragHandleControlID="Panel3" DynamicServicePath="" Enabled="True" />
        </div>
    </div>
        </div>
    <script type="text/javascript">
        function txtBox1_ClientClicked() {

            var basic = document.getElementById('<%=txtBasic.ClientID%>').value

            var houseRent = document.getElementById('<%=txtHouseRent.ClientID%>').value

            var conveyance = document.getElementById('<%=txtConveyance.ClientID%>').value

            var medical = document.getElementById('<%=txtMedical.ClientID%>').value

            var foodAllowance = document.getElementById('<%=txtFoodAllowance.ClientID%>').value

            var other = document.getElementById('<%=txtOthers.ClientID%>').value

            var total = parseFloat(basic) + parseFloat(houseRent) + parseFloat(conveyance) + parseFloat(medical) + parseFloat(foodAllowance) + parseFloat(other);

            if (isNaN(total)) {
                document.getElementById('<%=txtGrsSal.ClientID%>').value = 0;
            }
            else {
                document.getElementById('<%=txtGrsSal.ClientID%>').value = total;
            }


        }

        function calBasicPr() {
            var grossSalary = document.getElementById('<%=txtGrsSal.ClientID%>').value
            var basispe = document.getElementById('<%=txtBasicpr.ClientID%>').value
            var cal = (grossSalary * basispe);
            var total = cal / 100;
            document.getElementById('<%=txtBasic.ClientID%>').value = total;

        }

        function calHouseRentpr(txt) {

            var grossSalaryforh = document.getElementById('<%=txtGrsSal.ClientID%>').value
            var basispeforh = document.getElementById('<%=txtHouseRentpr.ClientID%>').value
            var calforh = (grossSalaryforh * basispeforh);
            var totalforh = calforh / 100;
            document.getElementById('<%=txtHouseRent.ClientID%>').value = totalforh;

        }


        function calConveyancepr(txt) {

            var grossSalary = document.getElementById('<%=txtGrsSal.ClientID%>').value
            var convencee = document.getElementById('<%=txtConveyancepr.ClientID%>').value
            var cal = (grossSalary * convencee);
            var total = cal / 100;
            document.getElementById('<%=txtConveyance.ClientID%>').value = total;

        }

        function calmedicalpr(txt) {

            var grossSalary = document.getElementById('<%=txtGrsSal.ClientID%>').value
            var medical = document.getElementById('<%=txtMedicalpr.ClientID%>').value
            var cal = (grossSalary * medical);
            var total = cal / 100;
            document.getElementById('<%=txtMedical.ClientID%>').value = total;

        }

        function calfoodAllowancepr(txt) {

            var grossSalary = document.getElementById('<%=txtGrsSal.ClientID%>').value
            var foodAllownace = document.getElementById('<%=txtFoodAllowancepr.ClientID%>').value
            var cal = (grossSalary * foodAllownace);
            var total = cal / 100;
            document.getElementById('<%=txtFoodAllowance.ClientID%>').value = total;

        }


        function calotherpr(txt) {

            var grossSalary = document.getElementById('<%=txtGrsSal.ClientID%>').value
            var other = document.getElementById('<%=txtOtherspr.ClientID%>').value
            var cal = (grossSalary * other);
            var total = cal / 100;
            document.getElementById('<%=txtOthers.ClientID%>').value = total;

        }


    </script>
    
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
