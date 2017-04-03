<%@ Page Title="" Language="C#" MasterPageFile="~/Requisition/Site.Master" AutoEventWireup="true"
    CodeBehind="PurchaseRequisition_Supervisor2Approval.aspx.cs" Inherits="ERPSSL.Requisition.PurchaseRequisition_Supervisor2Approval" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="hm_sec_2_content scrollbar">
                <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="glyphicon glyphicon-edit icon-padding"></i>Purchase Requisition Supervisor-2 Approval
                    </div>
                </div>

                <asp:HiddenField ID="hdnId" runat="server" />
                <div class="row">
                    <div class="col-md-12 bg-success">
                        <center>
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label></center>
                    </div>

                    <div class="row">
                        <fieldset style="width: 70%; margin: 0 auto 8px;">
                            <legend style="line-height: 0; margin-bottom: 0;"><span style="background: #fff">Pending Requisition List</span></legend>
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
                                    <%-- <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="False"></asp:BoundField>--%>
                                    <%--<asp:BoundField DataField="BarCode" HeaderText="BarCode" SortExpression="BarCode"
                                                    Visible="false"></asp:BoundField>--%>
                                    <asp:BoundField DataField="ReqNo" HeaderText="Requisition No." SortExpression="ReqNo">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ReqDate" HeaderText="Req. Date" SortExpression="ReqDate" DataFormatString="{0:dd/MM/yyyy}">
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
                                    <asp:BoundField DataField="DesiredRcvDate" HeaderText="Exp. Date" Visible="true" SortExpression="DesiredRcvDate" DataFormatString="{0:dd/MM/yyyy}">
                                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Reason_Justification" HeaderText="Reason" SortExpression="Reason_Justification">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <%--<asp:BoundField DataField="Qty" HeaderText="Req. Qty" SortExpression="Qty" Visible="true" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField DataField="BalQty" HeaderText="Bal.Qty" SortExpression="BalQty" Visible="true" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField DataField="UnitName" HeaderText="Unit" SortExpression="UnitName"
                                                    Visible="true" />--%>
                                </Columns>
                                <EmptyDataRowStyle ForeColor="Red" />
                                <RowStyle CssClass="Grid_RowStyle" ForeColor="#333333" />
                                <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                <PagerSettings Mode="NumericFirstLast" />
                                <PagerStyle ForeColor="White" HorizontalAlign="Left" BackColor="#336666" CssClass="pagination01 pageback" />
                                <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header"
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
                    <div class="col-md-12">
                        <fieldset>
                            <legend style="line-height: 0; margin-bottom: 0"><span style="background: #fff">Pending Requisition Item List</span></legend>
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
                                    <%--<asp:BoundField DataField="ReqNo" HeaderText="Req No." Visible="false"></asp:BoundField>--%>
                                    <asp:BoundField DataField="ProductName" HeaderText="Item" ItemStyle-Width="13%">
                                        <ItemStyle Width="13%" CssClass="Grid_Border" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Brand" HeaderText="Brand" Visible="false" ItemStyle-Width="12%">
                                        <ItemStyle Width="12%" CssClass="Grid_Border" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="StyleAndSize" HeaderText="Descriptiopn" ItemStyle-Width="12%">
                                        <ItemStyle Width="12%" CssClass="Grid_Border" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="UnitName" HeaderText="Unit" SortExpression="UnitName" ItemStyle-Width="8%">
                                        <ItemStyle Width="8%" CssClass="Grid_Border" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BalQty" HeaderText="Stock" SortExpression="BalQty" Visible="true" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%" NullDisplayText="0">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ManagerApproveQty" HeaderText="Requisition Qty" Visible="true" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Approve Qty" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtApproveQty" runat="server" Text='<%# Eval("Manager2ApproveQty")%>' Width="100%" Style="text-align: center"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                    </asp:TemplateField>

                                    <%-- <asp:TemplateField HeaderText="Status" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="input" Width="100%">
                                                            <asp:ListItem Text="Approved" Value="Approved"></asp:ListItem>
                                                            <asp:ListItem>Pending</asp:ListItem>
                                                            <asp:ListItem>Initial</asp:ListItem>
                                                            <asp:ListItem>Under Proccess</asp:ListItem>
                                                            <asp:ListItem>Hold</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                </Columns>
                                <EmptyDataRowStyle ForeColor="Red" />
                                <RowStyle CssClass="Grid_RowStyle" ForeColor="#333333" />
                                <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                <PagerSettings Mode="NumericFirstLast" />
                                <PagerStyle ForeColor="White" HorizontalAlign="Left" BackColor="#336666" CssClass="pagination01 pageback" />
                                <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header"
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
                                    <div class="pull-right">
                                        <asp:Button ID="BtnSave" runat="server" Text="Proccess" Style="margin-top: 6px;" ValidationGroup="Group1"
                                            class="btn btn-info pull-right" OnClick="BtnSave_Click" />
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
            if (result === 'Requisition approved successfully') {
                toastr.success(result);
            }
            else
                toastr.error(result);

            return false;
        }

    </script>
</asp:Content>
