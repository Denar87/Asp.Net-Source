<%@ Page Title="" Language="C#" MasterPageFile="~/INV/Site.Master" AutoEventWireup="true"
    CodeBehind="IssueByQuotation.aspx.cs" Inherits="ERPSSL.INV.IssueByQuotation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <asp:HiddenField ID="hdnBarCode" runat="server" />
                <asp:HiddenField ID="hdnEID" runat="server" />
                <div class="hm_sec_2_content scrollbar">
                     <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="glyphicon glyphicon-edit icon-padding"></i>Goods Issue Note(GIN) - Through
                        Tender
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
                                            CellPadding="4" AutoGenerateSelectButton="True" ForeColor="#333333" GridLines="Both"
                                            OnSelectedIndexChanged="grdRequisition_SelectedIndexChanged" DataKeyNames="Id">
                                            <Columns>
                                                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id"></asp:BoundField>
                                                <asp:BoundField DataField="BarCode" HeaderText="BarCode" SortExpression="BarCode"
                                                    Visible="false"></asp:BoundField>
                                                <asp:BoundField DataField="ReqNo" HeaderText="Req No." SortExpression="ReqNo"></asp:BoundField>
                                                <%--<asp:BoundField DataField="DesiredRcvDate" HeaderText="Desired Rcv. Date" SortExpression="DesiredRcvDate"
                                                    DataFormatString="{0:dd/MM/yyyy}"></asp:BoundField>--%>
                                                <asp:BoundField DataField="ProductName" HeaderText="Item" SortExpression="ProductName">
                                                </asp:BoundField>
                                                <asp:BoundField DataField="CompanyName" HeaderText="Store" SortExpression="CompanyName">
                                                </asp:BoundField>
                                                <asp:BoundField DataField="CompanyType" HeaderText="Store Type" SortExpression="CompanyType"
                                                    Visible="false"></asp:BoundField>
                                                <asp:BoundField DataField="DPT_NAME" HeaderText="Department" SortExpression="DPT_NAME" />
                                                <asp:BoundField DataField="EmployeeName" HeaderText="Employee" SortExpression="EmployeeName" />
                                                <asp:BoundField DataField="Qty" HeaderText="Qty" SortExpression="Qty" />
                                                <%--<asp:BoundField DataField="UnitName" HeaderText="Unit Name" SortExpression="UnitName" />--%>
                                                <%--<asp:BoundField DataField="ReqDate" HeaderText="Req. Date" SortExpression="ReqDate" />--%>
                                                <asp:BoundField DataField="BalQty" HeaderText="Bal. Qty" SortExpression="BalQty" />
                                            </Columns>
                                            <EditRowStyle BackColor="#999999" />
                                            <EmptyDataRowStyle ForeColor="Red" />
                                            <RowStyle CssClass="Grid_RowStyle" BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" />
                                            <AlternatingRowStyle CssClass="Grid_AltRowStyle" BackColor="White" ForeColor="#284775" />
                                            <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#284775" />
                                            <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" BackColor="#5D7B9D"
                                                Font-Bold="True" ForeColor="White" />
                                            <FooterStyle CssClass="Grid_Footer" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                        </asp:GridView>
                                    </fieldset>
                                </div>
                                <div class="col-md-5">
                                    <%--<div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Requisition No.
                                            </div>
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="ddlRequisition" Class="form-control" runat="server" AutoPostBack="True"
                                                    OnSelectedIndexChanged="ddlRequisition_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <br />--%>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                GIN No.
                                            </div>
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="ddlRequisition" Class="form-control" runat="server" AutoPostBack="True" Visible=false
                                                    OnSelectedIndexChanged="ddlRequisition_SelectedIndexChanged"></asp:DropDownList>
                                                    <asp:TextBox ID="txtChalanNo" CssClass="form-control" runat="server" ReadOnly="true">
                                                    </asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                GIN Date
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox Class="form-control" runat="server" ID="txtTransferDate" autocomplete="off"
                                                    placeholder="MM/dd/yyyy"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtTransferDate"
                                                    Display="Dynamic" ErrorMessage="Select Date" ForeColor="Red" SetFocusOnError="True"
                                                    Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtTransferDate"
                                                    PopupButtonID="Image_AT" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Department
                                            </div>
                                            <div class="col-md-7">
                                                
                                                <asp:TextBox ID="txtDepartment" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Item
                                            </div>
                                            <div class="col-md-7">
                                                
                                                <asp:TextBox ID="txtProductName" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
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
                                    <%-- <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Brand
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtBrand" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />--%>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Bal QTY
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtBalQty" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Issue QTY
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtDelQty" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
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
                                                <asp:Button ID="btnTransfer" runat="server" Text="Issue" Style="margin-top: 6px;
                                                    margin-right: 20px;" class="btn btn-info pull-right" OnClick="btnTransfer_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </fieldset>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
     <script>

         function func(result) {
             if (result === 'GIN issued successfully!') {
                 toastr.success(result);

             }
             
             else if (result === 'Sorry! Invalid data. Issue quantity cannot be zero or negetive. Please enter correct data') {
                 toastr.error(result);

             }
             else if (result === 'Sorry! There are not enough quantity of selected good to issue. Please purchase or issue with less quantity') {
                 toastr.error(result);

             }

             else
                 toastr.error(result);

             return false;
         }

   </script>
</asp:Content>
