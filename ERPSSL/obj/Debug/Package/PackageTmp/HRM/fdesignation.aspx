<%@ Page Title="" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true"
    CodeBehind="fdesignation.aspx.cs" Inherits="ERPSSL.HRM.fdesignation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="hm_sec_2_content scrollbar">
    <div class="panel">
        <div class="panel-heading panel-heading-01">
            <i class="fa fa-edit fa-fw icon-padding"></i>Designation Setup
        </div>
    </div>
    <div class="row">
        <div class="row">
            <div class="col-md-12 bg-success">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </div>
            <%--<div class="col-md-12">
            <div class="col-md-5">
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-5">
                            Designation
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtbxDesignation" runat="server" class="form-control"></asp:TextBox>
                            <asp:HiddenField ID="hidDesignationId" runat="server" />
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-5">
                        </div>
                        <div class="col-md-7">
                            <asp:Button ID="btnDesignationSubmit" runat="server" Text="Submit" class="btn btn-info  pull-right"
                                OnClick="btnDesignationSubmit_Clik" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-7">
                <asp:GridView ID="gridviewDesignation" runat="server" AutoGenerateColumns="False"
                    Width="100%" CellPadding="5" AllowPaging="True">
                    <Columns>
                        <asp:TemplateField Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblDesignationId" runat="server" Text='<%# Eval("DEG_ID")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="DEG_NAME" HeaderText="Designation Name">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgbtnDepartmentEdit" runat="server" ImageUrl="img/list_edit.png"
                                    OnClick="imgbtnDepartmentEdit_Click" />
                            </ItemTemplate>
                            <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataRowStyle ForeColor="Red" />
                    <RowStyle CssClass="Grid_RowStyle" />
                    <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                    <PagerStyle ForeColor="#000066" HorizontalAlign="Left" BackColor="White" />
                    <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" />
                    <FooterStyle CssClass="Grid_Footer" />
                </asp:GridView>
            </div>
        </div>--%>
            <div class="col-md-12">
                <br />
                <div class="col-md-6">

                    <div class="col-md-12">
                        <div class="col-md-5">
                            Designation
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtbxDesignation" runat="server" Width="100%" class="form-control"></asp:TextBox>
                            <asp:HiddenField ID="hidDesignationId" runat="server" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtbxDesignation"
                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Designation"
                                ValidationGroup="Degination"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <br />
                        <div class="col-md-5">
                            Basic
                        </div>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtBasic" Width="100%" runat="server" class="form-control"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBasic"
                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Basic"
                                ValidationGroup="Degination"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtBasicpr" Width="100%" onchange="calBasicPr()" class="form-control" placeholder="%" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-12">
                        <br />
                        <div class="col-md-5">
                            House Rent

                        </div>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtHouseRent" runat="server" Width="100%" class="form-control"></asp:TextBox>                           
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtHouseRent"
                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input House Rent"
                                ValidationGroup="Degination"></asp:RequiredFieldValidator>

                        </div>
                           <div class="col-md-2">
                                <asp:TextBox ID="txtHouseRentpr" onchange="calHouseRentpr()" Width="100%" class="form-control" placeholder="%" runat="server"></asp:TextBox>

                               </div>
                    </div>
                    <div class="col-md-12">
                        <br />
                        <div class="col-md-5">
                            Medical

                        </div>
                        <div class="col-md-5">

                            <asp:TextBox ID="txtMedical" runat="server" Width="100%" class="form-control"></asp:TextBox>
                         

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtMedical"
                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Medical"
                                ValidationGroup="Degination"></asp:RequiredFieldValidator>
                        </div>
                          <div class="col-md-2">
                                 <asp:TextBox ID="txtMedicalpr" onchange="calmedicalpr()" Width="100%" class="form-control" placeholder="%" runat="server"></asp:TextBox>
                              </div>

                    </div>

                    <div class="col-md-12">
                        <br />
                        <div class="col-md-5">
                            Convince
                        </div>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtConveyance" runat="server" Width="100%" class="form-control"></asp:TextBox>                        

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtConveyance"
                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Convince"
                                ValidationGroup="Degination"></asp:RequiredFieldValidator>
                        </div>
                          <div class="col-md-2">
                                 <asp:TextBox ID="txtConveyancepr" onchange="calConveyancepr()" Width="100%" class="form-control" placeholder="%" runat="server"></asp:TextBox>
                              </div>
                    </div>


                </div>
                <div class="col-md-6">
                    <div class="col-md-12">
                        <div class="col-md-5">
                            Grade
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtbxGrade" Width="100%" runat="server" class="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtbxGrade"
                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Grade"
                                ValidationGroup="Degination"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="col-md-12">
                        <br />
                        <div class="col-md-5">
                            Fixed Allowance
                        </div>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtFiexedAllowance" runat="server" Width="100%" class="form-control"></asp:TextBox>
                           
                           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFiexedAllowance"
                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Fixed Allowance"
                                ValidationGroup="Degination"></asp:RequiredFieldValidator>--%>
                        </div>
                         <div class="col-md-2">
                              <asp:TextBox ID="txtFoodAllowancepr" onchange="calfoodAllowancepr()" Width="100%" class="form-control" placeholder="%" runat="server"></asp:TextBox>

                             </div>

                    </div>



                    <div class="col-md-12">
                        <br />
                        <div class="col-md-5">
                            Holiday Allowance

                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtbxHolidayAllowance" runat="server" class="form-control" Width="100%"></asp:TextBox>
                            <%-- <asp:TextBox ID="txtbxHolidayAllowancePr" onchange="calHolidayAllowancePr()" Width="20%" class="form-control" placeholder="%" runat="server"></asp:TextBox>--%>

                         <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtbxHolidayAllowance"
                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Holiday Allowance"
                                ValidationGroup="Degination"></asp:RequiredFieldValidator>--%>

                        </div>
                    </div>
                    <div class="col-md-12">
                        <br />
                        <div class="col-md-5">
                            Attendance Bonus
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtOthers" runat="server" class="form-control" Width="100%"></asp:TextBox>


                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtOthers"
                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Others"
                                ValidationGroup="Degination"></asp:RequiredFieldValidator>--%>

                        </div>
                    </div>

                    <div class="col-md-12">
                        <br />
                        <div class="col-md-5">
                            Gross Salary

                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtGrsSal" onclick="txtBox1_ClientClicked()" OnTextChanged="txtEid_AT_TextChanged" AutoPostBack="true" runat="server" Width="100%" class="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtGrsSal"
                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Gross Salary"
                                ValidationGroup="Degination"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="col-md-12">
                    <br />
                    <div style="float: right; padding-right: 36px">
                        <asp:Button ID="btnSave" runat="server" ValidationGroup="Degination" Text="Submit" OnClick="btnSave_Click" CssClass=" btn btn-success" />
                    </div>

                </div>
            </div>
            <div class="col-md-12" style="padding-right:40px;">
                <br />
                <asp:GridView ID="gridviewDesignation" runat="server" AutoGenerateColumns="False"
                    Width="100%" CellPadding="5" AllowPaging="True" PageSize="20" OnPageIndexChanging="gridviewDesignation_PageIndexChanging">
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

                        <asp:TemplateField Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblDesignationId" runat="server" Text='<%# Eval("DEG_ID")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="DEG_NAME" HeaderText="Designation">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:BoundField DataField="GRADE" HeaderText="Grade">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="5%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:BoundField DataField="BASIC" HeaderText="Basic"  DataFormatString="{0:N2}">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="5%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                         <asp:BoundField DataField="HOUSE_RENT" HeaderText="House Rent" DataFormatString="{0:N2}">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="5%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MEDICAL" HeaderText="Medical Allownce" DataFormatString="{0:N2}">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="5%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CONVEYANCE" HeaderText="Conveyance" DataFormatString="{0:N2}">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="5%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FixedAllowance" HeaderText="Fixed Allowance" DataFormatString="{0:N2}">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="5%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:BoundField DataField="AttendanceBonus" HeaderText="Attendance Bonus" DataFormatString="{0:N2}">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="5%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Holiday_Allowance" HeaderText="Holiday Allowance" DataFormatString="{0:N2}">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="5%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                         <asp:BoundField DataField="GROSS_SAL" HeaderText="Gross Salary" DataFormatString="{0:N2}">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="5%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Update">
                            <ItemTemplate>
                                <%--   <asp:LinkButton ID="LinkButtonEdit" runat="server" OnClick="imgbtnDepartmentEdit_Click">
                                                    <img src="resources/ico/dg_edit.png" />
                            </asp:LinkButton>--%>

                                <asp:ImageButton ID="LinkButtonEdit" runat="server" ImageUrl="resources/ico/dg_edit.png"
                                    OnClick="imgbtnDepartmentEdit_Click" />


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
                    <PagerStyle BackColor="#6393c1" ForeColor="White" HorizontalAlign="Justify" CssClass="pagination01 pageback" />
                </asp:GridView>

            </div>
        </div>
    </div>
        </div>
    <script type="text/javascript">
        function txtBox1_ClientClicked() {

            var basic = document.getElementById('<%=txtBasic.ClientID%>').value

            var houseRent = document.getElementById('<%=txtHouseRent.ClientID%>').value

            var conveyance = document.getElementById('<%=txtConveyance.ClientID%>').value

            var medical = document.getElementById('<%=txtMedical.ClientID%>').value

            var fiexedAllowance = document.getElementById('<%=txtFiexedAllowance.ClientID%>').value

            var other = document.getElementById('<%=txtOthers.ClientID%>').value

            var HolidayAllowance = document.getElementById('<%=txtbxHolidayAllowance.ClientID%>').value

            var total = parseFloat(basic) + parseFloat(houseRent) + parseFloat(conveyance) + parseFloat(medical) + parseFloat(fiexedAllowance) + parseFloat(other) + parseFloat(HolidayAllowance);

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

       // function calfoodAllowancepr(txt) {

            //var grossSalary = document.getElementById('<%=txtGrsSal.ClientID%>').value
           // var foodAllownace = document.getElementById('<%=txtFoodAllowancepr.ClientID%>').value
           // var cal = (grossSalary * foodAllownace);
           // var total = cal / 100;
           // document.getElementById('<%=txtFiexedAllowance.ClientID%>').value = total;

       // }






    </script>
     <script>

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
