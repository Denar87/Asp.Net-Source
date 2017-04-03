<%@ Page Title="" Language="C#" MasterPageFile="~/INV/Site.Master" AutoEventWireup="true"
    CodeBehind="StoreRequisition_SupervisorApproval.aspx.cs" Inherits="ERPSSL.INV.StoreRequisition_SupervisorApproval" %>


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
                        <i class="glyphicon glyphicon-edit icon-padding"></i>Store Requisition Supervisor Approval
                    </div>
                </div>

                <asp:HiddenField ID="hdnId" runat="server" />
                <div class="row" style="margin: 0 auto">
                    <div class="col-md-12 bg-success">
                        <center>
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label></center>
                    </div>

                    <div class="row">

                        <fieldset style="width: 70%; margin: 0 auto 8px;">
                            <legend style="line-height: 0; margin-bottom: 0"><span style="background: #fff">Pending Requisition List</span></legend>
                            <asp:GridView ID="grdRequisition" runat="server" AutoGenerateColumns="False" Width="100%"
                                CellPadding="4" GridLines="Both" DataKeyNames="ReqNo" OnRowCommand="grdRequisition_SelectedIndexChanged"
                                BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" AllowPaging="True" PageSize="20">
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
                                    <asp:BoundField DataField="ReqNo" HeaderText="Req No." SortExpression="ReqNo">
                                        <ItemStyle HorizontalAlign="Center" CssClass="Grid_Border" Width="10%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ReqDate" HeaderText="Req. Date" SortExpression="ReqDate" DataFormatString="{0:dd/MM/yyyy}">
                                        <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                    </asp:BoundField>

                                    <%--<asp:BoundField DataField="ProductName" HeaderText="Item"
                                                    Visible="true"></asp:BoundField>
                                                <asp:BoundField DataField="CompanyName" HeaderText="CompanyName" SortExpression="CompanyName"
                                                    Visible="False"></asp:BoundField>
                                                <asp:BoundField DataField="CompanyType" HeaderText="CompanyType" SortExpression="CompanyType"
                                                    Visible="false"></asp:BoundField>--%>
                                    <asp:BoundField DataField="DPT_NAME" HeaderText="Department" SortExpression="DPT_NAME">
                                        <ItemStyle HorizontalAlign="Left" CssClass="Grid_Border" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="EmployeeName" HeaderText="Employee" SortExpression="EmployeeName">
                                        <ItemStyle HorizontalAlign="Left" CssClass="Grid_Border" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DesiredRcvDate" HeaderText="Exp. Date" Visible="true" SortExpression="DesiredRcvDate" DataFormatString="{0:dd/MM/yyyy}">
                                        <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
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
                                    <asp:TemplateField ItemStyle-Width="2%">
                                        <HeaderTemplate>
                                            <asp:CheckBox runat="server" ID="headerLevelCheckBox" AutoPostBack="true" OnCheckedChanged="headerLevelCheckBox_CheckedChanged" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="rowLevelCheckBox" runat="server" AutoPostBack="true" OnCheckedChanged="rowLevelCheckBox_CheckedChanged" />
                                            <headerstyle verticalalign="Middle" cssclass="Grid_Header" />
                                            <itemstyle horizontlalign="Center" width="2%" cssclass="Grid_Border" />
                                            <footerstyle cssclass="Grid_Footer" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReqNo" runat="server" Text='<%# Eval("ReqNo")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReq" runat="server" Text='<%# Eval("Qty")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBarcode" runat="server" Text='<%# Eval("BarCode")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:BoundField DataField="ReqNo" HeaderText="Req No." Visible="false"></asp:BoundField>--%>
                                    <asp:BoundField DataField="ProductName" HeaderText="Item" ItemStyle-Width="13%">
                                        <ItemStyle Width="13%" CssClass="Grid_Border" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Brand" HeaderText="Brand" Visible="false" ItemStyle-Width="12%">
                                        <ItemStyle Width="12%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="StyleAndSize" HeaderText="Descriptiopn" ItemStyle-Width="12%">
                                        <ItemStyle Width="12%" CssClass="Grid_Border" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BalQty" HeaderText="Stock" SortExpression="BalQty" Visible="false" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%" NullDisplayText="0">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Qty" HeaderText="Req. Qty" SortExpression="Qty" Visible="true" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Approve Qty" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtApproveQty" runat="server" Text='<%# Eval("ManagerApproveQty")%>' Width="100%" Style="text-align: center"  ></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="UnitName" HeaderText="Unit" SortExpression="UnitName" ItemStyle-Width="8%">
                                        <ItemStyle Width="8%" CssClass="Grid_Border" />
                                    </asp:BoundField>
                                     <asp:TemplateField HeaderText="Status" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="input" Width="100%">
                                                            <asp:ListItem Text="Approved" Value="Approved"></asp:ListItem>
                                                             <asp:ListItem>Re-Forward</asp:ListItem>
                                                              <asp:ListItem>Pending</asp:ListItem>
                                                             <asp:ListItem>Cancel</asp:ListItem>                                                            
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
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

                        <div class="row ">
                            <div class="col-md-12">
                                <div class="col-md-1" style="width: 10%">
                                   <%-- <b>Approved By</b>--%>
                                </div>
                                <%--<div class="col-md-3">
                                    <asp:DropDownList ID="ddlSupervisor1EID" CssClass="form-control" runat="server"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlSupervisor1EID"
                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Approved By Required!"
                                        Font-Size="11px" ValidationGroup="Group1" InitialValue="0"></asp:RequiredFieldValidator>
                                </div>--%>
                                <div class="col-md-2">
                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                </div>
                                <div class="col-md-6" style="margin-left: 154px">
                                    <%--<div class="pull-right">--%>
                                    <asp:Button ID="BtnProcess" runat="server" Text="Process" ValidationGroup="Group1"
                                        class="btn btn-info pull-right" OnClick="BtnProcess_Click" />
                                    <%--</div>--%>
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
