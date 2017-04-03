<%@ Page Title="" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true"
    CodeBehind="designation.aspx.cs" Inherits="ERPSSL.HRM.designation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">

        <ContentTemplate>


            <div class="hm_sec_2_content scrollbar">
                <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="glyphicon glyphicon-edit icon-padding"></i>Designation Setup
                    </div>
                </div>
                <div class="row">
                 <%--   <div class="col-md-12 bg-success">
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
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
                                <div class="col-md-7">
                                    <asp:TextBox ID="txtBasic" Width="100%" runat="server" ReadOnly="true" class="form-control"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBasic"
                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Basic"
                                        ValidationGroup="Degination"></asp:RequiredFieldValidator>
                                </div>

                            </div>


                            <div class="col-md-12">
                                <br />
                                <div class="col-md-5">
                                    Medical

                                </div>
                                <div class="col-md-7">

                                    <asp:TextBox ID="txtMedical" runat="server" ReadOnly="true" Width="100%" class="form-control"></asp:TextBox>


                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtMedical"
                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Medical"
                                        ValidationGroup="Degination"></asp:RequiredFieldValidator>
                                </div>


                            </div>

                            <div class="col-md-12">
                                <br />
                                <div class="col-md-5">
                                    Conveyance
                                </div>
                                <div class="col-md-7">
                                    <asp:TextBox ID="txtConveyance" ReadOnly="true" runat="server" Width="100%" class="form-control"></asp:TextBox>

                                 <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtConveyance"
                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Conveyance"
                                        ValidationGroup="Degination"></asp:RequiredFieldValidator>--%>
                                </div>

                            </div>

                            <%-- <div class="col-md-12">
                        <br />
                        <div class="col-md-5">
                            Conveyance
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtConveyance" runat="server" Width="100%" class="form-control"></asp:TextBox>                        

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtConveyance"
                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Conveyance"
                                ValidationGroup="Degination"></asp:RequiredFieldValidator>
                        </div>
                         
                    </div>--%>
                        </div>
                        <div class="col-md-6">
                            <div class="col-md-12">
                                <div class="col-md-5">
                                    Grade:
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
                                    House Rent

                                </div>
                                <div class="col-md-7">
                                    <asp:TextBox ID="txtHouseRent" ReadOnly="true" runat="server" Width="100%" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtHouseRent"
                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input House Rent"
                                        ValidationGroup="Degination"></asp:RequiredFieldValidator>

                                </div>

                            </div>

                            <div class="col-md-12">
                                <br />
                                <div class="col-md-5">
                                    Food Allowance
                                </div>
                                <div class="col-md-7">
                                    <asp:TextBox ID="txtFoodAllowance" ReadOnly="true" runat="server" Width="100%" class="form-control"></asp:TextBox>

                                   <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFoodAllowance"
                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Fixed Allowance"
                                        ValidationGroup="Degination"></asp:RequiredFieldValidator>--%>
                                </div>


                            </div>



                            <%-- <div class="col-md-12">
                        <br />
                        <div class="col-md-5">
                            Holiday Allowance

                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtbxHolidayAllowance" runat="server" class="form-control"></asp:TextBox>
                          

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtbxHolidayAllowance"
                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Holiday Allowance"
                                ValidationGroup="Degination"></asp:RequiredFieldValidator>

                        </div>
                    </div>--%>
                            <%-- <div class="col-md-12">
                        <br />
                        <div class="col-md-5">
                            Attendance Bonus
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtOthers" runat="server" class="form-control"></asp:TextBox>


                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtOthers"
                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Others"
                                ValidationGroup="Degination"></asp:RequiredFieldValidator>

                        </div>
                    </div>--%>

                            <div class="col-md-12">
                                <br />
                                <div class="col-md-5">
                                    Gross Salary

                                </div>
                                <div class="col-md-7">
                                    <asp:TextBox ID="txtGrsSal" OnTextChanged="txtEid_AT_TextChanged" AutoPostBack="true" runat="server" Width="100%" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtGrsSal"
                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Gross Salary"
                                        ValidationGroup="Degination"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <br />
                            <div style="float: right; padding-right: 36px">
                                <asp:Button ID="btnSave" runat="server" ValidationGroup="Degination" Text="Save" OnClick="btnSave_Click" CssClass=" btn btn-success" />
                            </div>

                        </div>
                    </div>
                    <div class="col-md-12">
                        <br />
                        <asp:GridView ID="gridviewDesignation" runat="server" AutoGenerateColumns="False"
                            Width="100%" CellPadding="5" AllowPaging="True" PageSize="20" OnPageIndexChanging="gridviewDesignation_PageIndexChanging">
                            <Columns>

                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        Sl No.
                                    </HeaderTemplate>
                                    <ItemTemplate>
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
                                    <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
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
                                <asp:BoundField DataField="FOOD_ALLOW" HeaderText="Food Allowance">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Left" Width="5%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>

                                <asp:TemplateField HeaderText="ACTIONS">
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
                            <PagerStyle BackColor="#6393c1" ForeColor="White" HorizontalAlign="Left" CssClass="pagination01 pageback" />
                        </asp:GridView>

                    </div>
                </div>
            </div>

        </ContentTemplate>

        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />

        </Triggers>
    </asp:UpdatePanel>

     <script>
         function func(result) {
             if (result === 'Data Save successfully!') {
                 toastr.success(result);
             }
             else if (result === 'Data Update successfully!') {
                 toastr.success(result);
             }
             else if (result === 'Gross Total is not Equal to Misc. Total!') {
                 toastr.error(result);
             }
             else
                 toastr.error(result);
             return false;
         }
    </script>

</asp:Content>
