<%@ Page Title="" Language="C#" MasterPageFile="~/INV/Site.Master" AutoEventWireup="true" ClientIDMode="Static"
    CodeBehind="DeptWise_Store_RequisitionList.aspx.cs" Inherits="ERPSSL.INV.DeptWise_Store_RequisitionList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">

                <asp:HiddenField ID="hdnAdminEID" runat="server" />
                <asp:HiddenField ID="hdnEID" runat="server" />
                <asp:HiddenField ID="hdnId" runat="server" />
                <asp:HiddenField ID="hdnOfficeID" runat="server" />
                <div class="hm_sec_2_content scrollbar">
                    <div class="panel">
                        <div class="panel-heading panel-heading-01">
                            <i class="glyphicon glyphicon-edit icon-padding"></i>Department wise Store Requisition List 
                        </div>
                    </div>
                    <div class="col-md-12 bg-success">
                        <center>

                            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label></center>
                    </div>
                    <div class="col-md-12">
                        <div class="col-md-12">
                            <fieldset>
                                <legend style="line-height: 5px;"><span style="background: #fff">Select Department And Date</span></legend>
                                <div class="col-md-6">
                                    <div class="row">
                                        <div class="col-md-4">Department</div>
                                        <div class="col-md-8">
                                            <asp:DropDownList ID="ddlDepartment" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-4">Employee</div>
                                        <div class="col-md-8">
                                            <asp:DropDownList ID="ddlEmployee" CssClass="form-control" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <div class="row">

                                        <div class="col-md-3">From</div>
                                        <div class="col-md-6">
                                            <asp:TextBox ID="txtFromDate" CssClass="form-control" runat="server"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFromDate"
                                                PopupButtonID="txtFromDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-3">To</div>
                                        <div class="col-md-6">
                                            <asp:TextBox ID="txtToDate" CssClass="form-control" runat="server"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtToDate"
                                                PopupButtonID="txtToDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                        </div>
                                        <div class="col-md-3">
                                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                                        </div>
                                    </div>
                                </div>
                            </fieldset>


                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="col-md-5">
                            <fieldset>
                                <legend style="line-height: 5px;"><span style="background: #fff">Requisition List</span></legend>
                                <asp:GridView ID="grdRequisition" runat="server" AutoGenerateColumns="False" Width="100%"
                                    CellPadding="4" GridLines="Both" DataKeyNames="ReqNo" OnRowCommand="grdRequisition_SelectedIndexChanged"
                                    BackColor="White" BorderColor="#336666" BorderStyle="Solid" BorderWidth="1px" AllowPaging="True" PageSize="20">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Select">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgbtnEdit" runat="server" CommandArgument='<%# Eval("ReqNo") %>'
                                                    CommandName="select" ImageUrl="img/edit.png" />
                                            </ItemTemplate>
                                            <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ReqNo" HeaderText="Req No." SortExpression="ReqNo">

                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ReqDate" HeaderText="Req. Date" SortExpression="ReqDate" DataFormatString="{0:dd/MM/yyyy}">
                                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DPT_NAME" HeaderText="Department" SortExpression="DPT_NAME">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EmployeeName" HeaderText="Employee" SortExpression="EmployeeName">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DesiredRcvDate" HeaderText="Exp. Date" Visible="true" SortExpression="DesiredRcvDate" DataFormatString="{0:dd/MM/yyyy}">
                                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                    </Columns>
                                    <EmptyDataRowStyle ForeColor="Red" />
                                    <RowStyle CssClass="Grid_RowStyle" BackColor="White" ForeColor="#333333" />
                                    <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                    <PagerSettings Mode="NumericFirstLast" />
                                    <PagerStyle ForeColor="White" HorizontalAlign="Left" BackColor="#336666" CssClass="pagination01 pageback" />
                                    <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" BackColor="#336666"
                                        Font-Bold="True" ForeColor="White" />
                                    <FooterStyle CssClass="Grid_Footer" BackColor="White" ForeColor="#333333" />
                                    <SelectedRowStyle BackColor="Silver" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                    <SortedAscendingHeaderStyle BackColor="#487575" />
                                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                    <SortedDescendingHeaderStyle BackColor="#275353" />
                                </asp:GridView>
                            </fieldset>
                        </div>

                        <div class="col-md-7">
                            <fieldset>
                                <legend style="line-height: 5px;"><span style="background: #fff">Requisition Item List</span></legend>
                                <asp:GridView ID="grvReqItemList" runat="server" AutoGenerateColumns="False" Width="100%" DataKeyNames="ReqNo"
                                    CellPadding="4" GridLines="Both"
                                    BackColor="White" BorderColor="#336666" BorderStyle="Solid" BorderWidth="1px" AllowPaging="True" PageSize="20">
                                    <Columns>
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblReqNo" runat="server" Text='<%# Eval("ReqNo")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBarcode" runat="server" Text='<%# Eval("BarCode")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="true" HeaderText="Item" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="13%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblItem" runat="server" Text='<%# Eval("ProductName")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ProductName" HeaderText="Item" ItemStyle-Width="13%" Visible="false"></asp:BoundField>
                                        <asp:BoundField DataField="Brand" HeaderText="Brand" ItemStyle-Width="12%" Visible="false"></asp:BoundField>
                                        <asp:BoundField DataField="StyleAndSize" HeaderText="Description" ItemStyle-Width="12%" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                                        <asp:BoundField DataField="Qty" HeaderText="Req. Qty" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                                        <asp:BoundField DataField="BalQty" HeaderText="Bal.Qty" SortExpression="BalQty" Visible="false" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%" NullDisplayText="0" />
                                        <asp:TemplateField HeaderText="Approved Qty" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBalance" runat="server" Text='<%# Eval("HeadApproveQty")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="UnitName" HeaderText="Unit" SortExpression="UnitName" ItemStyle-Width="8%" />
                                        <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" ItemStyle-Width="10%" />
                                    </Columns>
                                    <EmptyDataRowStyle ForeColor="Red" />
                                    <RowStyle CssClass="Grid_RowStyle" BackColor="White" ForeColor="#333333" />
                                    <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                    <PagerSettings Mode="NumericFirstLast" />
                                    <PagerStyle ForeColor="White" HorizontalAlign="Left" BackColor="#336666" CssClass="pagination01 pageback" />
                                    <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" BackColor="#336666"
                                        Font-Bold="True" ForeColor="White" />
                                    <FooterStyle CssClass="Grid_Footer" BackColor="White" ForeColor="#333333" />
                                    <SelectedRowStyle BackColor="Silver" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                    <SortedAscendingHeaderStyle BackColor="#487575" />
                                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                    <SortedDescendingHeaderStyle BackColor="#275353" />
                                </asp:GridView>
                            </fieldset>
                            <br />
                            <div class="row ">
                                <div class="col-md-12">
                                    <div class="col-md-10">
                                        <asp:HiddenField ID="HiddenField1" runat="server" />
                                    </div>
                                    <div class="col-md-2">
                                        <div class="row">
                                            <asp:Button ID="BtnSave" runat="server" Text="Edit" Style="margin-right: 15px; float: right;" ValidationGroup="Group1"
                                                class="btn btn-info" OnClick="BtnSave_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
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
            else
                toastr.error(result);
            return false;
        }
    </script>
</asp:Content>
