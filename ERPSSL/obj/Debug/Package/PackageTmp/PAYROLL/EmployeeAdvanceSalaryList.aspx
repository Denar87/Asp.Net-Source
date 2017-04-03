<%@ Page Title="" Language="C#" MasterPageFile="~/PAYROLL/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeAdvanceSalaryList.aspx.cs" Inherits="ERPSSL.PAYROLL.EmployeeAdvanceSalaryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">       
<ContentTemplate>
    <div class="hm_sec_2_content scrollbar">
        <div class="panel">
            <div class="panel-heading panel-heading-01">
                <i class="fa fa-edit fa-fw icon-padding"></i>Employee Advance Salary List
            </div>
        </div>
        <div id="Div1" class="row" runat="server">

            <div class="col-md-12">
                <fieldset style="border: none;">
                    <asp:GridView ID="grdemployees" runat="server" EmptyDataText="No Records Found!"
                        AutoGenerateColumns="False" Width="100%"
                        DataKeyNames="EID" ShowFooter="True" CellPadding="5" PageSize="50" AllowPaging="True" OnPageIndexChanging="grdemployees_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblAdvanceSalaryId" runat="server" Text='<%# Eval("AdvanceSalaryId")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblAdCode" runat="server" Text='<%# Eval("ASCode")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="EID" HeaderText="E-ID">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="5%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>

                            <asp:BoundField DataField="ASCode" HeaderText="Pay Code">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="5%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>

                            <asp:BoundField DataField="EmployeeName" HeaderText="Name">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>

                            <asp:BoundField DataField="ResionName" HeaderText="Region">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                            <asp:BoundField DataField="OfficeName" HeaderText="Office">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>

                            <asp:BoundField DataField="DepartmentName" HeaderText="Department">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TotalAmount" HeaderText="Total Amount">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>

                            <asp:BoundField DataField="NoOfInstalment" HeaderText="No. of Installment">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="5%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>

                            <asp:BoundField DataField="StartDate" HeaderText="Start Date" DataFormatString="{0:MMMM d, yyyy}">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>

                            <asp:BoundField DataField="EndDate" HeaderText="End Date" DataFormatString="{0:MMMM d, yyyy}">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>

                            <asp:TemplateField HeaderText="Update">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgEmployeeAdvanceSalry" runat="server" ImageUrl="img/list_edit.png"
                                        OnClick="imgEmployeeAdvanceSalry_Click" />
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
</asp:UpdatePanel>
</asp:Content>
