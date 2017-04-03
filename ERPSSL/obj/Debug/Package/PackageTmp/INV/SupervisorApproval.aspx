<%@ Page Title="" Language="C#" MasterPageFile="~/INV/Site.Master" AutoEventWireup="true"
    CodeBehind="SupervisorApproval.aspx.cs" Inherits="ERPSSL.INV.SupervisorApproval" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
    <div class="row">   
        <asp:HiddenField ID="hdnId" runat="server" />
        <div class="hm_sec_2_content scrollbar">
            <div class="panel">
            <div class="panel-heading panel-heading-01">
                <i class="glyphicon glyphicon-edit icon-padding"></i>Supervisor Approval
            </div>
        </div>
            <div class="col-md-12 bg-success">
                <center>
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label></center>
            </div>

            <div class="row">
                <fieldset style="border: none;">
                    <div class="col-md-12">
                        <div class="col-md-7">
                            <fieldset style="border: none">
                                <asp:GridView ID="grdRequisition" runat="server" AutoGenerateColumns="False" Width="100%"
                                    CellPadding="4" GridLines="Both" DataKeyNames="Id" OnRowCommand="grdRequisition_SelectedIndexChanged"
                                    BackColor="White" BorderColor="#336666" BorderStyle="Solid" BorderWidth="1px" AllowPaging="True">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Select">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgbtnEdit" runat="server" CommandArgument='<%# Eval("Id") %>'
                                                    CommandName="select" ImageUrl="img/edit.png" />
                                            </ItemTemplate>
                                            <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="false"></asp:BoundField>
                                        <asp:BoundField DataField="BarCode" HeaderText="BarCode" SortExpression="BarCode"
                                            Visible="false"></asp:BoundField>
                                        <asp:BoundField DataField="ReqNo" HeaderText="Req No." SortExpression="ReqNo">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DesiredRcvDate" HeaderText="Exp. Date" SortExpression="DesiredRcvDate" DataFormatString="{0:dd/MM/yyyy}">
                                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ProductName" HeaderText="Item" SortExpression="Product"
                                            Visible="False"></asp:BoundField>
                                        <asp:BoundField DataField="CompanyName" HeaderText="CompanyName" SortExpression="CompanyName"
                                            Visible="False"></asp:BoundField>
                                        <asp:BoundField DataField="CompanyType" HeaderText="CompanyType" SortExpression="CompanyType"
                                            Visible="false"></asp:BoundField>
                                        <asp:BoundField DataField="DPT_NAME" HeaderText="Department" SortExpression="DPT_NAME">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EmployeeName" HeaderText="Employee" SortExpression="EmployeeName" HeaderStyle-HorizontalAlign="Left">
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Qty" HeaderText="Qty" SortExpression="Qty" Visible="False" />
                                        <asp:BoundField DataField="UnitName" HeaderText="Unit Name" SortExpression="UnitName"
                                            Visible="False" />
                                        <asp:BoundField DataField="ReqDate" HeaderText="Req. Date" SortExpression="ReqDate" DataFormatString="{0:dd/MM/yyyy}">
                                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="BalQty" HeaderText="Bal.Qty" SortExpression="BalQty" Visible="False" />
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

                        <div class="col-md-5">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-5">
                                        Product
                                    </div>
                                    <div class="col-md-7">
                                        <asp:TextBox ID="txtReqNo" CssClass="form-control" runat="server" Visible="false"></asp:TextBox>
                                        <asp:TextBox ID="txtProduct" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-5">
                                        Unit
                                    </div>
                                    <div class="col-md-7">
                                        <asp:TextBox ID="txtUnit" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-5">
                                        Brand
                                    </div>
                                    <div class="col-md-7">
                                        <asp:TextBox ID="txtBrand" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-5">
                                        Bal QTY
                                    </div>
                                    <div class="col-md-7">
                                        <asp:TextBox ID="txtBalQTY" CssClass="form-control" runat="server" ReadOnly="true" placeholder="0"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-5">
                                        Request QTY
                                    </div>
                                    <div class="col-md-7">
                                        <asp:TextBox ID="txtRequestQTY" CssClass="form-control" runat="server" ReadOnly="true" placeholder="0"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-5">
                                        Approve Qty
                                    </div>
                                    <div class="col-md-7">
                                        <asp:TextBox ID="txtApproveQty" CssClass="form-control" runat="server" placeholder="0"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row ">
                                <div class="col-md-12">
                                    <div class="col-md-5">
                                        <asp:HiddenField ID="HiddenField1" runat="server" />
                                    </div>
                                    <div class="col-md-7">
                                        <asp:Button ID="BtnSave" runat="server" Text="Approve" Style="margin-top: 6px; margin-right: 20px;"
                                            class="btn btn-info pull-right" OnClick="BtnSave_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </fieldset>
            </div>
        </div>
    </div>
    <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
    <script>

        function func(result) {
            if (result === 'Product has been approved') {
                toastr.success(result);

            }
            else if (result === 'Sorry! Invalid data. Approve quantity cannot be zero or negetive. Please enter correct data') {
                toastr.error(result);

            }
            else if (result === 'Error in approval! Please try again') {
                toastr.error(result);

            }


            else
                toastr.error(result);

            return false;
        }

   </script>
</asp:Content>
