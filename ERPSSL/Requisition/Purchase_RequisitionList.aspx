﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Requisition/Site.Master" AutoEventWireup="true"
    CodeBehind="Purchase_RequisitionList.aspx.cs" Inherits="ERPSSL.Requisition.Purchase_RequisitionList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="glyphicon glyphicon-edit icon-padding"></i>Purchase Requisition List 
                    </div>
                </div>
                <asp:HiddenField ID="hdnAdminEID" runat="server" />
                <asp:HiddenField ID="hdnEID" runat="server" />
                <asp:HiddenField ID="hdnId" runat="server" />
                <div class="hm_sec_2_content scrollbar">
                    <div class="col-md-12 bg-success">
                        <center>
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label></center>
                    </div>
                    <br />

                    <div class="col-md-12">
                        <div class="col-md-9">
                            <fieldset>
                                <legend style="line-height: 0;"><span style="background: #fff">Select Date</span></legend>
                                <div class="col-md-5">
                                    <div class="col-md-2">From</div>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="txtFromDate" CssClass="form-control" runat="server"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFromDate"
                                            PopupButtonID="txtFromDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />

                                    </div>

                                    <%-- // OnTextChanged="txtDate_TextChanged"--%>
                                </div>
                                <div class="col-md-5">
                                    <div class="col-md-2">To</div>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="txtToDate" CssClass="form-control" runat="server"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtToDate"
                                            PopupButtonID="txtToDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                    </div>
                                </div>
                                <div class="row">
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-info pull-right" OnClick="btnSearch_Click" />

                                </div>
                            </fieldset>
                        </div>
                    </div>
                    <br></br>
                    <div class="col-md-12">


                        <div class="col-md-5">
                            <fieldset>
                                <legend style="line-height: 0;"><span style="background: #fff">Requisition List</span></legend>
                                <asp:GridView ID="grdRequisition" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" DataKeyNames="ReqNo" GridLines="Both" OnRowCommand="grdRequisition_SelectedIndexChanged" PageSize="20" Width="100%">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Select">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgbtnEdit" runat="server" CommandArgument='<%# Eval("ReqNo") %>' CommandName="select" ImageUrl="img/edit.png" />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                                        </asp:TemplateField>
                                        <%-- <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="False"></asp:BoundField>--%><%--<asp:BoundField DataField="BarCode" HeaderText="BarCode" SortExpression="BarCode"
                                                    Visible="false"></asp:BoundField>--%>
                                        <asp:BoundField DataField="ReqNo" HeaderText="Req No." SortExpression="ReqNo">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ReqDate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Req. Date" SortExpression="ReqDate">
                                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                                        </asp:BoundField>
                                        <%--<asp:BoundField DataField="ProductName" HeaderText="Item"
                                                    Visible="true"></asp:BoundField>
                                                <asp:BoundField DataField="CompanyName" HeaderText="CompanyName" SortExpression="CompanyName"
                                                    Visible="False"></asp:BoundField>
                                                <asp:BoundField DataField="CompanyType" HeaderText="CompanyType" SortExpression="CompanyType"
                                                    Visible="false"></asp:BoundField>--%>
                                        <asp:BoundField DataField="DPT_NAME" HeaderText="Department" SortExpression="DPT_NAME">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EmployeeName" HeaderText="Employee" SortExpression="EmployeeName">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DesiredRcvDate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Exp. Date" SortExpression="DesiredRcvDate" Visible="true">
                                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                                        </asp:BoundField>
                                        <%--<asp:BoundField DataField="Qty" HeaderText="Req. Qty" SortExpression="Qty" Visible="true" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField DataField="BalQty" HeaderText="Bal.Qty" SortExpression="BalQty" Visible="true" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField DataField="UnitName" HeaderText="Unit" SortExpression="UnitName"
                                                    Visible="true" />--%>
                                    </Columns>
                                    <EmptyDataRowStyle ForeColor="Red" />
                                    <RowStyle BackColor="White" CssClass="Grid_RowStyle" ForeColor="#333333" />
                                    <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                    <PagerSettings Mode="NumericFirstLast" />
                                    <PagerStyle BackColor="#336666" CssClass="pagination01 pageback" ForeColor="White" HorizontalAlign="Left" />
                                    <HeaderStyle BackColor="#336666" CssClass="Grid_Header" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" Width="10%" />
                                    <FooterStyle BackColor="White" CssClass="Grid_Footer" ForeColor="#333333" />
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
                                <legend style="line-height: 0;"><span style="background: #fff">Requisition Item List</span></legend>
                                <asp:GridView ID="grvReqItemList" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" DataKeyNames="ReqNo" GridLines="Both" PageSize="20" Width="100%">
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
                                        <asp:TemplateField HeaderText="Item" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="13%" Visible="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lblItem" runat="server" Text='<%# Eval("ProductName")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ProductName" HeaderText="Item" ItemStyle-Width="13%" Visible="false" />
                                        <asp:BoundField DataField="Brand" HeaderText="Brand" ItemStyle-Width="12%" Visible="false" />
                                        <asp:BoundField DataField="StyleAndSize" HeaderText="Description" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="12%" />
                                        <asp:BoundField DataField="Qty" HeaderText="Req. Qty" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%" />
                                        <%-- <asp:TemplateField Visible="true" HeaderText="Stock" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBalance" runat="server" Text='<%# Eval("BalQty")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                        <asp:BoundField DataField="BalQty" HeaderText="Bal.Qty" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%" NullDisplayText="0" SortExpression="BalQty" Visible="false" />
                                        <%--   <asp:TemplateField Visible="true" HeaderText="Total App. Qty" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTotalAppQty" runat="server" Text='<%# Eval("Total_App_Qty")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%><%-- <asp:BoundField DataField="Total_App_Qty" HeaderText="Total App. Qty" Visible="false" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%" />
                                                <asp:BoundField DataField="ManagerApproveQty" HeaderText="Req. Qty" Visible="true" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%" />--%>
                                        <asp:TemplateField HeaderText="Approved Qty" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBalance" runat="server" Text='<%# Eval("HeadApproveQty")%>' />
                                                <%--<asp:TextBox ID="txtApproveQty" runat="server" Text='<%# Eval("HeadApproveQty")%>' Width="100%" ToolTip="Enter Approve Quantity" Style="text-align: center" OnTextChanged="txtApproveQty_TextChanged"></asp:TextBox>--%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="UnitName" HeaderText="Unit" ItemStyle-Width="8%" SortExpression="UnitName" />
                                        <asp:BoundField DataField="Status" HeaderText="Status" ItemStyle-Width="10%" SortExpression="Status" />
                                    </Columns>
                                    <EmptyDataRowStyle ForeColor="Red" />
                                    <RowStyle BackColor="White" CssClass="Grid_RowStyle" ForeColor="#333333" />
                                    <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                    <PagerSettings Mode="NumericFirstLast" />
                                    <PagerStyle BackColor="#336666" CssClass="pagination01 pageback" ForeColor="White" HorizontalAlign="Left" />
                                    <HeaderStyle BackColor="#336666" CssClass="Grid_Header" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" Width="10%" />
                                    <FooterStyle BackColor="White" CssClass="Grid_Footer" ForeColor="#333333" />
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
                                    <div class="row">
                                        <asp:Button ID="BtnSave" runat="server" class="btn btn-info pull-right" OnClick="BtnSave_Click" Style="float: right; margin-right: 18px;" Text="Edit" ValidationGroup="Group1" />
                                    </div>
                                </div>
                            </div>
                        </div>


                    </div>

                    <br>

                    </br>
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
