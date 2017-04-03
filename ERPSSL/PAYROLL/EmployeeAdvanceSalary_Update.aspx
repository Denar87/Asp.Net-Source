<%@ Page Title="" Language="C#" MasterPageFile="~/PAYROLL/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeAdvanceSalary_Update.aspx.cs" Inherits="ERPSSL.PAYROLL.EmployeeAdvanceSalary_Update" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
        <ContentTemplate>
            <div class="hm_sec_2_content scrollbar">
                <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="fa fa-edit fa-fw icon-padding"></i>Employee Advance Salary Update
                    </div>
                </div>
                <div id="Div1" class="row" runat="server">
                    <div class="col-md-12" style="padding-top: 10px">
                        <div class="col-md-2">
                            EID
                            <asp:TextBox ID="txtEID" class="form-control" runat="server"></asp:TextBox>
                            <asp:HiddenField ID="hidAdDetailsId" runat="server" />
                            <asp:HiddenField ID="hdfPayCode" runat="server" />
                             <asp:HiddenField ID="hdfMonth" runat="server" />
                             <asp:HiddenField ID="hdfYear" runat="server" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEID"
                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="EID Required"
                                ValidationGroup="Group1"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-2">
                            Month
                            <asp:DropDownList ID="ddlMonthList" CssClass="form-control" runat="server">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlMonthList"
                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Month Required"
                                Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-2">
                            Year
                            <asp:DropDownList ID="ddlYearList" CssClass="form-control" runat="server">
                            </asp:DropDownList>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlYearList"
                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Year Required"
                                Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-2" style="padding-top: 15px; margin-left: -10px">
                            <asp:Button ID="btnSearch" runat="server" Text="Search" class="btn btn-info pull-left" OnClick="btnSearch_Click" />
                        </div>
                        <div class="col-md-2" style="padding-top: 15px; margin-left: -90px">
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" class="btn btn-primary pull-left" ValidationGroup="Group1" OnClick="btnUpdate_Click" />
                        </div>
                    </div>

                    <div class="col-md-12">
                        <fieldset style="border: none;">
                            <asp:GridView ID="grdemployees" runat="server" EmptyDataText="No Records Found!"
                                AutoGenerateColumns="False" Width="100%"
                                DataKeyNames="EID" ShowFooter="false" CellPadding="5" PageSize="50" AllowPaging="True" OnPageIndexChanging="grdemployees_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAdvanceSalaryDetailsId" runat="server" Text='<%# Eval("AdvanceSalaryDetailsId")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="3%" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            Sl.
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblSRNO" runat="server"
                                                Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    </asp:TemplateField>

                                    <asp:TemplateField Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAdCode" runat="server" Text='<%# Eval("ASCode")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="ASCode" HeaderText="Pay Code">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="EID" HeaderText="E-ID">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="EmployeeName" HeaderText="Name">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="ResionName" HeaderText="Region">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Left" Width="8%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="OfficeName" HeaderText="Office">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Left" Width="8%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="DepartmentName" HeaderText="Department">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Left" Width="8%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="TotalAmount" HeaderText="Total Amount" DataFormatString="{0:0.00}">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Right" Width="8%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="NoOfInstalment" HeaderText="No. of Installment">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="StartDate" HeaderText="Pay From" DataFormatString="{0:dd-MMM-yyyy}">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="EndDate" HeaderText="Pay To" DataFormatString="{0:dd-MMM-yyyy}">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Month_Name" HeaderText="Pay Month">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Year" HeaderText="Pay Year">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="Update">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgEmployeeAdvanceSalry" runat="server" ImageUrl="img/list_edit.png"
                                                OnClick="imgEmployeeAdvanceSalry_Click" />
                                        </ItemTemplate>
                                        <ItemStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
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
    </asp:UpdatePanel>

    <script type="text/javascript">

        function func(result) {
            if (result === 'Data recorded successfully') {
                toastr.success(result);
            }
            else if (result === 'Data Updated Successfully') {
                toastr.success(result);
            }
            else
                toastr.error(result);

            return false;
        }

    </script>

</asp:Content>
