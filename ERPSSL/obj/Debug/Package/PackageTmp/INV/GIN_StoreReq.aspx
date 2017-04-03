<%@ Page Title="" Language="C#" MasterPageFile="~/INV/Site.Master" AutoEventWireup="true" CodeBehind="GIN_StoreReq.aspx.cs" Inherits="ERPSSL.INV.GIN_StoreReq" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>
            <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
            <div class="row">
                <div class="hm_sec_2_content scrollbar">
                    <div class="panel">
                        <div class="panel-heading panel-heading-01">
                            <i class="glyphicon glyphicon-edit icon-padding"></i>GIN Through Requisition
                        </div>
                    </div>
                    <asp:HiddenField ID="hdnBarCode" runat="server" />
                    <asp:HiddenField ID="hdnEID" runat="server" />

                    <div class="col-md-12 bg-success">
                        <center> <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label></center>
                    </div>
                    <div class="col-md-12">
                        <div class="col-md-12">
                            <div class="panel panel-success">
                                <div class="panel-heading"><b>Requisition List</b> </div>
                                <div class="panel-body">
                                    <div class="col-md-12">
                                        <asp:GridView ID="grdRequisition" runat="server" AutoGenerateColumns="False" Width="100%"
                                            CellPadding="4" GridLines="Both" DataKeyNames="ReqNo"
                                            BackColor="White" BorderColor="#336666" BorderStyle="Solid" BorderWidth="1px" AllowPaging="True" PageSize="20">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Select">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgSelect" runat="server" OnClick="imgSelect_Click" ImageUrl="img/edit.png" />
                                                    </ItemTemplate>
                                                    <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                                                </asp:TemplateField>

                                                <asp:TemplateField Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblReqNo" runat="server" Text='<%# Eval("ReqNo")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDepartmentCode" runat="server" Text='<%# Eval("DPT_CODE")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEID" runat="server" Text='<%# Eval("EID")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <%-- <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="False"></asp:BoundField>--%>
                                                <%--<asp:BoundField DataField="BarCode" HeaderText="BarCode" SortExpression="BarCode"
                                                    Visible="false"></asp:BoundField>--%>
                                                <asp:BoundField DataField="ReqNo" HeaderText="Req No." SortExpression="ReqNo">
                                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ReqDate" HeaderText="Req. Date" SortExpression="ReqDate" DataFormatString="{0:dd/MM/yyyy}">
                                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                </asp:BoundField>

                                                <%--<asp:BoundField DataField="ProductName" HeaderText="Item"
                                                    Visible="true"></asp:BoundField>
                                                <asp:BoundField DataField="CompanyName" HeaderText="CompanyName" SortExpression="CompanyName"
                                                    Visible="False"></asp:BoundField>
                                                <asp:BoundField DataField="CompanyType" HeaderText="CompanyType" SortExpression="CompanyType"
                                                    Visible="false"></asp:BoundField>--%>
                                                <asp:BoundField DataField="DPT_NAME" HeaderText="Department" SortExpression="DPT_NAME">
                                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="EmployeeName" HeaderText="Employee (Req. By)" SortExpression="EmployeeName">
                                                    <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Program" HeaderText="Program" SortExpression="Program">
                                                    <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="DesiredRcvDate" HeaderText="Exp. Date" Visible="true" SortExpression="DesiredRcvDate" DataFormatString="{0:dd/MM/yyyy}">
                                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                </asp:BoundField>
                                                <%--<asp:BoundField DataField="Qty" HeaderText="Req. Qty" SortExpression="Qty" Visible="true" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField DataField="BalQty" HeaderText="Bal.Qty" SortExpression="BalQty" Visible="true" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField DataField="UnitName" HeaderText="Unit" SortExpression="UnitName"
                                                    Visible="true" />--%>
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
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <br />
                            <div class="panel panel-success">
                                <div class="panel-heading"><b>Items Details</b> </div>
                                <div class="panel-body">
                                    <div class="col-md-12">
                                        <asp:GridView ID="grdstoreReqDelivery" runat="server" AutoGenerateColumns="False" Width="100%"
                                            CellPadding="4" GridLines="Both" DataKeyNames="ReqNo" OnRowDataBound="grdstoreReqDelivery_RowDataBound"
                                            BackColor="White" BorderColor="#336666" BorderStyle="Solid" BorderWidth="1px" AllowPaging="True" PageSize="20">
                                            <Columns>

                                                <asp:TemplateField Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblHeadApproveQuanity" runat="server" Text='<%# Eval("HeadApproveQty")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblProgramId" runat="server" Text='<%# Eval("ProgramId")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBarCode" runat="server" Text='<%# Eval("BarCode")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDepartmentCode" runat="server" Text='<%# Eval("DPT_CODE")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDReqNo" runat="server" Text='<%# Eval("ReqNo")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLastReceive" runat="server" Text='<%# Eval("LastRecived")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:CheckBox runat="server" ID="headerLevelCheckBox" AutoPostBack="true" OnCheckedChanged="headerLevelCheckBox_CheckedChanged" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="rowLevelCheckBox" runat="server" AutoPostBack="true" OnCheckedChanged="rowLevelCheckBox_CheckedChanged" />
                                                        <headerstyle verticalalign="Middle" cssclass="Grid_Header" />
                                                        <itemstyle horizontalalign="Left" width="10%" cssclass="Grid_Border" />
                                                        <footerstyle cssclass="Grid_Footer" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center">
                                                    <HeaderTemplate>
                                                        Sl No.
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSRNO" runat="server"
                                                            Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblReqNo" runat="server" Text='<%# Eval("ReqNo")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%-- <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="False"></asp:BoundField>--%>
                                                <%--<asp:BoundField DataField="BarCode" HeaderText="BarCode" SortExpression="BarCode"
                                                    Visible="false"></asp:BoundField>--%>

                                                <asp:BoundField DataField="ReqNo" HeaderText="Req No." SortExpression="ReqNo">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="ProductName" HeaderText="Item" SortExpression="ProductName">
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="Brand" HeaderText="Brand" SortExpression="Brand">
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="StyleAndSize" HeaderText="Size" SortExpression="StyleAndSize">
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="UnitName" HeaderText="Unit" SortExpression="UnitName">
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="HeadApproveQty" HeaderText="Approved Qty" SortExpression="HeadApproveQty">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="LastRecived" HeaderText="Total Issued" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="7%">
                                                    <ItemStyle HorizontalAlign="Center" ForeColor="Maroon" Font-Bold="true" />
                                                </asp:BoundField>

                                                <asp:TemplateField HeaderText="Store">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="ddlStoreList" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="ddlStoreList_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Program" HeaderText="Program" SortExpression="Program">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Program" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="ddlStyle" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="ddlStyle_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Program" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="ddlProgram" Width="100%" runat="server"></asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Balance" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBalance" runat="server" Text="0" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Issue Qty" Visible="true" ItemStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtbxReceiveAmount" runat="server" Width="100%" Style="text-align: center; font-weight: bold"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Remarks" Visible="true" ItemStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtRemarks" runat="server" Width="100%" Style="text-align: center; font-weight: bold"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--<asp:BoundField DataField="Qty" HeaderText="Req. Qty" SortExpression="Qty" Visible="true" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField DataField="BalQty" HeaderText="Bal.Qty" SortExpression="BalQty" Visible="true" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField DataField="UnitName" HeaderText="Unit" SortExpression="UnitName"
                                                    Visible="true" />--%>
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

                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <asp:Button ID="btnTransfer" runat="server" Text="Issue" Style="margin-top: 6px; margin-right: 30px;"
                                class="btn btn-success pull-right" OnClick="btnTransfer_Click" />
                            <asp:HiddenField ID="hidGin" runat="server" />
                            <asp:HiddenField ID="hidEid" runat="server" />
                        </div>
                        <div class="col-md-12">
                            <br />
                            <%--<legend style="line-height: 0px;"><span style="background: #fff">Goods Issue Search By Date </span></legend>--%>
                            <div class="panel panel-info">
                                <div class="panel-heading"><b>Goods Issue Search By Date</b></div>
                                <div class="panel-body" style="font-size: 10px; color: green;">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                <div class="row">
                                                    <div class="col-md-3" style="padding-left: 0px;">
                                                        From Date
                                                    </div>
                                                    <div class="col-md-9" style="padding-left: 0px;">
                                                        <asp:TextBox Class="form-control" runat="server" ID="txtbxFromDate" autocomplete="off"
                                                            placeholder="MM/dd/yyyy"></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtbxFromDate"
                                                            PopupButtonID="Image_AT" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="row">
                                                    <div class="col-md-3" style="padding-left: 0px;">
                                                        To Date
                                                    </div>
                                                    <div class="col-md-9" style="padding-left: 0px;">
                                                        <asp:TextBox Class="form-control" runat="server" ID="txtbxToDate" autocomplete="off" placeholder="MM/dd/yyyy"></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtbxToDate"
                                                            PopupButtonID="Image_AT" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="row">
                                                    <asp:Button ID="btnSearch" runat="server" Text="Search" class="btn btn-info" OnClick="btnSearch_Click" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12" style="padding-bottom: 10px">
                                            <br />
                                            <asp:GridView ID="GrdviewAfterDeiveryProduct" runat="server" AutoGenerateColumns="False" Width="100%"
                                                CellPadding="4" GridLines="Both" DataKeyNames="ReqNo"
                                                BackColor="White" BorderColor="#336666" BorderStyle="Solid" BorderWidth="1px" AllowPaging="True" PageSize="20">
                                                <Columns>
                                                    <asp:BoundField DataField="ReqNo" HeaderText="Req No.">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="ProductName" HeaderText="Item">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="Brand" HeaderText="Brand" SortExpression="Brand">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="StyleAndSize" HeaderText="Size" SortExpression="StyleAndSize">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="UnitName" HeaderText="Unit" SortExpression="UnitName">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="HeadApproveQty" HeaderText="Issue Qty" SortExpression="HeadApproveQty">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="TransferDate" HeaderText="Issue Date" SortExpression="ReqDate" DataFormatString="{0:dd/MM/yyyy}">
                                                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="EmployeeName" HeaderText="Received Employee">
                                                        <ItemStyle HorizontalAlign="Left" />
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
            if (result === 'GIN Issued Successfully') {
                toastr.success(result);
            }
            else
                toastr.error(result);
            return false;
        }
    </script>
</asp:Content>
