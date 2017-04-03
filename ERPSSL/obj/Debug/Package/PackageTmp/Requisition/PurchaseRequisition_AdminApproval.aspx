<%@ Page Title="" Language="C#" MasterPageFile="~/Requisition/Site.Master" AutoEventWireup="true"
    CodeBehind="PurchaseRequisition_AdminApproval.aspx.cs" Inherits="ERPSSL.Requisition.PurchaseRequisition_AdminApproval" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

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

                        <i class="glyphicon glyphicon-edit icon-padding"></i>Purchase Requisition Admin Approval
                    </div>
                </div>
                <asp:HiddenField ID="hdnAdminEID" runat="server" />
                <asp:HiddenField ID="hdnOfficeID" runat="server" />
                <asp:HiddenField ID="hdnId" runat="server" />
                <div class="hm_sec_2_content scrollbar">
                    <div class="col-md-12 bg-success">

                        <center>
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label></center>
                    </div>
                    <br />



                    <div class="col-md-12">
                     <fieldset>
                            <legend style="line-height: 0;"><span style="background: #fff">Select Department And Date</span></legend>
                            <div class="col-md-4">
                                <div class="row">
                                    <div class="col-md-3">Department</div>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddlDepartment" CssClass="form-control" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-3">Status</div>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddlStatus" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                                            <asp:ListItem>--Select One--</asp:ListItem>
                                            <asp:ListItem>Pending</asp:ListItem>
                                            <asp:ListItem>Approve</asp:ListItem>
                                            <asp:ListItem>Re-Forward</asp:ListItem>
                                            <asp:ListItem>Initial</asp:ListItem>
                                            <asp:ListItem>Hold</asp:ListItem>
                                            <asp:ListItem>Under Proccess</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="row">

                                    <div class="col-md-3">From</div>
                                    <div class="col-md-7">
                                        <asp:TextBox ID="txtFromDate" CssClass="form-control" runat="server"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFromDate"
                                            PopupButtonID="txtFromDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />

                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-3">To</div>
                                    <div class="col-md-7">
                                        <asp:TextBox ID="txtToDate" CssClass="form-control" runat="server"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtToDate"
                                            PopupButtonID="txtToDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                    </div>
                                    <div class="col-md-2">
                                        <div class="row">
                                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" />

                                        </div>
                                    </div>
                                </div>


                                <%-- // OnTextChanged="txtDate_TextChanged"--%>
                            </div>

                            <br />


                        </fieldset>
                    </div>
                    <div class="col-md-12">


                        <fieldset>
                            <legend style="line-height: 0; margin-bottom: 0;"><span style="background: #fff">Pending Requisition List</span></legend>
                            <asp:GridView ID="grdRequisition" runat="server" AutoGenerateColumns="False" Width="100%"
                                CellPadding="4" GridLines="Both" DataKeyNames="ReqNo" OnRowCommand="grdRequisition_SelectedIndexChanged"
                                BackColor="White" BorderColor="#336666" BorderStyle="Solid" BorderWidth="1px" AllowPaging="True" PageSize="20" HorizontalAlign="Center">
                                <Columns>
                                  
                                    <%-- <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="False"></asp:BoundField>--%>
                                    <%--<asp:BoundField DataField="BarCode" HeaderText="BarCode" SortExpression="BarCode"
                                                    Visible="false"></asp:BoundField>--%>
                                    <asp:BoundField DataField="ReqNo" HeaderText="Req No." SortExpression="ReqNo">
                                        <ItemStyle HorizontalAlign="Center" CssClass="Grid_Border" />
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
                                        <ItemStyle HorizontalAlign="Center" CssClass="Grid_Border" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="EmployeeName" HeaderText="Employee" SortExpression="EmployeeName">
                                        <ItemStyle HorizontalAlign="Center" CssClass="Grid_Border" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DesiredRcvDate" HeaderText="Exp. Date" Visible="true" SortExpression="DesiredRcvDate" DataFormatString="{0:dd/MM/yyyy}">
                                        <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="Reason_Justification" HeaderText="Reason" SortExpression="Reason_Justification">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                  <%--  <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status">
                                        <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                    </asp:BoundField>--%>
                                      <asp:TemplateField HeaderText="Select">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgbtnEdit" runat="server" CommandArgument='<%# Eval("ReqNo") %>'
                                                CommandName="select" ImageUrl="img/edit.png" />
                                        </ItemTemplate>
                                        <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                                    </asp:TemplateField>
                                    <%--     <asp:BoundField DataField="Remarks" HeaderText="Remarks" SortExpression="Remarks" >
                                            <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                        </asp:BoundField>--%>
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
                        <fieldset style="background-color: #808080">
                            <legend style="line-height: 0; margin-bottom: 0;"><span style="background: #fff"></span></legend>
                            <asp:GridView ID="grvReqItemList" runat="server" AutoGenerateColumns="False" Width="100%" DataKeyNames="ReqNo"
                                CellPadding="4" GridLines="Both" ShowFooter="true"
                                BackColor="White" BorderColor="#336666" BorderStyle="Solid" BorderWidth="1px" AllowPaging="True" PageSize="20" OnRowDataBound="grvReqItemList_RowDataBound">
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
                                    <asp:TemplateField Visible="true" HeaderText="Item" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblItem" runat="server" Text='<%# Eval("ProductName")%>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="13%" CssClass="Grid_Border" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ProductName" HeaderText="Item" ItemStyle-Width="10%" Visible="false">
                                        <ItemStyle Width="13%" CssClass="Grid_Border" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Brand" HeaderText="Brand" ItemStyle-Width="10%" Visible="false">
                                        <ItemStyle Width="12%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="StyleAndSize" HeaderText="Description" ItemStyle-Width="9%" ItemStyle-HorizontalAlign="Center">
                                        <ItemStyle HorizontalAlign="Center" Width="12%" CssClass="Grid_Border" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="UnitName" HeaderText="Unit" SortExpression="UnitName" ItemStyle-Width="8%">
                                        <ItemStyle Width="8%" CssClass="Grid_Border" />
                                    </asp:BoundField>
                                    <asp:TemplateField Visible="true" HeaderText="Stock" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="8%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBalance" runat="server" Text='<%# Eval("BalQty")%>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="BalQty" HeaderText="Bal.Qty" SortExpression="BalQty" Visible="false" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%" NullDisplayText="0">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                    </asp:BoundField>
                                    <asp:TemplateField Visible="false" HeaderText="Total App. Qty" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotalAppQty" runat="server" Text='<%# Eval("Total_App_Qty")%>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                    </asp:TemplateField>
                                    <%--                                          <asp:TemplateField Visible="true" HeaderText="Total Price" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTotal" runat="server" Text='<%# Eval("Total")%>' />
                                            </ItemTemplate>
                                               <FooterTemplate>
                                                <asp:Label ID="lblsalary" runat="server" />
                                            </FooterTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                        </asp:TemplateField>--%>
                      
                                    <asp:BoundField DataField="Total_App_Qty" HeaderText="Total App. Qty" Visible="false" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ManagerApproveQty" HeaderText="Req. Qty" Visible="true" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="App. Qty" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtApproveQty" runat="server" Text='<%# Eval("HeadApproveQty")%>' OnTextChanged="txtApproveQty_Changed" AutoPostBack="true"  Width="100%" ToolTip="Enter Approve Quantity" Style="text-align: center"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                    </asp:TemplateField>
                                   <%-- <asp:BoundField DataField="UnitName" HeaderText="Unit" SortExpression="UnitName" ItemStyle-Width="8%">
                                        <ItemStyle Width="8%" CssClass="Grid_Border" />
                                    </asp:BoundField>--%>
                                    <asp:TemplateField HeaderText="Price" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtPrice" runat="server" Text='<%# Eval("Price")%>' OnTextChanged="txtPrice_Changed" AutoPostBack="true" Width="100%" ToolTip="Enter Price" Style="text-align: center"></asp:TextBox>
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                    </asp:TemplateField>

                                     <asp:TemplateField Visible="true" HeaderText="Total Price" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotal" runat="server" />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblsalary" runat="server" />
                                        </FooterTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />

                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Remarks" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtRemarks" runat="server" Width="100%" Text='<%# Eval("Remarks")%>' ToolTip="Remarks" Style="text-align: center"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlStatus" Text='<%# Eval("Status")%>' runat="server" CssClass="input" Width="100%">
                                                <asp:ListItem Text="Approve" Value="Approve"></asp:ListItem>
                                                <asp:ListItem>Re-Forward</asp:ListItem>
                                                <asp:ListItem>Pending</asp:ListItem>
                                                <asp:ListItem>Initial</asp:ListItem>
                                                <asp:ListItem>Under Proccess</asp:ListItem>
                                                <asp:ListItem>Hold</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
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
                        <br />
                        <div class="row ">
                            <div class="col-md-12">
                                <div class="col-md-8">
                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                </div>
                                <div class="col-md-4">
                                    <div class="pull-right">
                                        <asp:Button ID="btnPrint" runat="server" Style="margin-top: 6px;" Text="Print" CssClass="btn btn-warning"
                                            OnClick="btnPrint_Click" />
                                        <asp:Button ID="BtnSave" runat="server" Text="Proccess" Style="margin-top: 6px;" ValidationGroup="Group1"
                                            class="btn btn-info pull-right" OnClick="BtnSave_Click" />
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="col-md-11"></div>
                        <div class="col-md-1">
                            <%--     <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btn btn-warning"
                                OnClick="btnPrint_Click" />--%>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <center>
                            <rsweb:ReportViewer ID="ReportViewerPurchase" AsyncRendering="False" InteractiveDeviceInfos="(Collection)"
                                SizeToReportContent="True" Width="100%" Height="700px" runat="server" Font-Names="Verdana"
                                Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" BackColor="White">
                            </rsweb:ReportViewer>
                        </center>


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
