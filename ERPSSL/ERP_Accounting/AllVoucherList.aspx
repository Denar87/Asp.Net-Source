<%@ Page Title="" Language="C#" MasterPageFile="~/ERP_Accounting/Site.Master" AutoEventWireup="true"
    CodeBehind="AllVoucherList.aspx.cs" Inherits="ERPSSL.ERP_Accounting.AllVoucherList" %>

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
                        <i class="glyphicon glyphicon-edit icon-padding"></i>Voucher List
                    </div>
                </div>
                <asp:HiddenField ID="hdnId" runat="server" />

                <div class="row">
                    <div class="col-md-12 bg-success">
                        <center>
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label></center>
                    </div>
                    <div class="col-md-12">
                        <fieldset>
                            <%--<legend style="line-height: 5px"><span style="background: #fff">Select for Search</span></legend>--%>

                            <div class="col-md-4">
                                <div class="row">

                                    <div class="col-md-4">Voucher No</div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtVoucherNo" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-8">
                                <div class="row">
                                    <div class="col-md-2">Voucher Date</div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtVoucherDate" CssClass="form-control" runat="server"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtVoucherDate"
                                            PopupButtonID="txtVoucherDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                    </div>
                                    <div class="col-md-7">
                                        <asp:RadioButton ID="rdbUnaproved" runat="server" Text="Pending" GroupName="print" Checked="true" OnCheckedChanged="rdbUnaproved_CheckedChanged"
                                            AutoPostBack="true" />
                                        <%-- <asp:RadioButton ID="rdbChecked" runat="server" Text="Checked" GroupName="print"
                                            OnCheckedChanged="rdbChecked_CheckedChanged" AutoPostBack="true" />--%>
                                        <asp:RadioButton ID="rdbAproved" runat="server" Text="Approved" GroupName="print"
                                            OnCheckedChanged="rdbAproved_CheckedChanged" AutoPostBack="true" />

                                        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary pull right" OnClick="btnSearch_Click" />
                                        <asp:Button ID="btnAll" runat="server" Text="All" CssClass="btn btn-info" OnClick="btnAll_Click" Visible="false" />
                                    </div>
                                </div>

                            </div>

                            <br />
                        </fieldset>
                    </div>
                    <div class="col-md-12">
                        <fieldset>
                            <legend style="line-height: 5px; "><span style="background: #fff">Voucher List</span></legend>
                            <asp:GridView ID="grdAllVoucherList" runat="server" AutoGenerateColumns="False" Width="100%" EmptyDataText="No Records Found!"
                                CellPadding="4" GridLines="Both" DataKeyNames="Voucher_No"  OnPageIndexChanging="grdAllVoucherList_PageIndexChanging"
                                BackColor="White" BorderStyle="Solid" BorderWidth="1px" AllowPaging="True" BorderColor="#CCCCCC" PageSize="30">
                                <Columns>

                                         <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblVoucher_NO" runat="server" Text='<%# Eval("Voucher_No")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                    <asp:BoundField DataField="Voucher_No" HeaderText="Voucher No">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Voucher_Date" HeaderText="Voucher Date" SortExpression="ReqDate" DataFormatString="{0:MM/dd/yyyy}">
                                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Dr" HeaderText="Dr.">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Cr" HeaderText="Cr.">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Narration" HeaderText="Narration">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="Details">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgbtnEdit" runat="server" CommandArgument='<%# Eval("Voucher_No") %>' ToolTip="View Details"
                                                 OnClick="imgbtnEdit_Click" ImageUrl="~/ERP_Accounting/img/details-icon.png" Width="18" />
                                        </ItemTemplate>
                                        <ItemStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
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

                    </div>

                    <div class="col-md-12">
                        <fieldset style="border: none">
                            <%--<legend style="line-height: 0; margin-bottom: 0"><span style="background: #fff">Pending Requisition Item List</span></legend>--%>
                            <asp:GridView ID="grvVoucherDetails" runat="server" AutoGenerateColumns="False" Width="100%" DataKeyNames="Voucher_No"
                                CellPadding="4" GridLines="Both"
                                BackColor="White" BorderColor="#336666" BorderStyle="Solid" BorderWidth="1px">
                                <Columns>
                                    <%--  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                                        <HeaderTemplate>
                                            Sl No.
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblSRNO" runat="server"
                                                Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <%-- <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblId" runat="server" Text='<%# Eval("Id")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField Visible="true" HeaderText="Ledger Code">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLedgerCode" runat="server" Text='<%# Eval("Ledger_Code")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="Nature" HeaderText="Nature" ItemStyle-Width="13%">
                                        <ItemStyle Width="10%" CssClass="Grid_Border" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ChequeNo" HeaderText="Cheque No." Visible="true" ItemStyle-Width="12%">
                                        <ItemStyle Width="15%" CssClass="Grid_Border" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Particulars" HeaderText="Particulars" ItemStyle-Width="30%">
                                        <ItemStyle CssClass="Grid_Border" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Debit" HeaderText="Dr." DataFormatString="{0:n}" ItemStyle-Width="8%" ItemStyle-HorizontalAlign="Center">
                                        <ItemStyle Width="10%" CssClass="Grid_Border" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Credit" HeaderText="Cr." Visible="true" DataFormatString="{0:n}" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%" NullDisplayText="0">
                                        <ItemStyle HorizontalAlign="Center" CssClass="Grid_Border" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Voucher_Date" HeaderText="Voucher Date" Visible="true" DataFormatString="{0:MM/dd/yyyy}" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                    </asp:BoundField>

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
                                <div class="col-md-10">
                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                </div>
                                <div class="col-md-2">
                                    <div class="pull-right">
                                        <asp:Button ID="BtnSave" runat="server" Text="Proccess" Style="margin-top: 6px;" ValidationGroup="Group1"
                                            class="btn btn-info" OnClick="BtnSave_Click" Visible="false" />
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
            if (result === 'Data processed successfully') {
                toastr.success(result);
            }
            else
                toastr.error(result);

            return false;
        }

    </script>
</asp:Content>
