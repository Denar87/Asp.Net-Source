<%@ Page Title="" Language="C#" MasterPageFile="~/ERP_Accounting/Site.Master" AutoEventWireup="true"
    CodeBehind="AllVoucherDetails.aspx.cs" Inherits="ERPSSL.ERP_Accounting.AllVoucherDetails" %>

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
                            <%-- <legend style="line-height: 5px"><span style="background: #fff">Select for Search</span></legend>--%>

                            <div class="col-md-5">
                                <div class="row">

                                    <div class="col-md-4">Voucher No</div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtVoucherNo" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-5">
                                <div class="row">
                                    <div class="col-md-4">Voucher Date</div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtVoucherDate" CssClass="form-control" runat="server"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtVoucherDate"
                                            PopupButtonID="txtVoucherDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                    </div>
                                    <%--<div class="col-md-3">
                                        <asp:RadioButton ID="rdbUnaproved" runat="server" Text="Pending" GroupName="print" Checked="" OnCheckedChanged="rdbUnaproved_CheckedChanged"
                                            AutoPostBack="true" />                                       
                                        <asp:RadioButton ID="rdbAproved" runat="server" Text="Approved" GroupName="print"
                                            OnCheckedChanged="rdbAproved_CheckedChanged" AutoPostBack="true" />
                                    </div>--%>
                                    </div>
                                </div>
                                    <div class="col-md-2 pull-right">
                                      <%--  <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/ERP_Accounting/img/zoom77.png"
                                            Width="32px" OnClick="btnSearch_Click" ToolTip="Search Voucher" />--%>

                                        <asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/ERP_Accounting/img/left arrow9.png"
                                            Width="32px" ToolTip="Go Back" OnClick="btnBack_Click" />

                                        <asp:ImageButton ID="BtnApprove" runat="server" ImageUrl="~/ERP_Accounting/img/check60.png"
                                            Width="32px" OnClick="BtnApprove_Click" ToolTip="Approve Voucher" />

                                        <asp:ImageButton ID="BtnDiscard" runat="server" ImageUrl="~/ERP_Accounting/img/ban2.png"
                                            Width="32px" OnClick="BtnDiscard_Click" ToolTip="Discard Voucher" />
                                    </div>
                                </div>

                        </fieldset>
                    </div>
                    <div class="col-md-12">
                        <fieldset>
                            <legend style="line-height: 5px;"><span style="background: #fff">Voucher Details</span></legend>
                            <asp:GridView ID="grvVoucherDetails" runat="server" AutoGenerateColumns="False" Width="100%"
                                CellPadding="4" GridLines="Both" DataKeyNames="Voucher_No"
                                BackColor="White" BorderStyle="Solid" BorderWidth="1px" AllowPaging="True" BorderColor="#CCCCCC"
                                OnRowCommand="grvVoucherDetails_SelectedIndexChanged"
                                OnRowCancelingEdit="grvVoucherDetails_RowCancelingEdit"
                                OnRowUpdating="grvVoucherDetails_RowUpdating"
                                OnRowDataBound="grvVoucherDetails_RowDataBound"
                                OnPageIndexChanging="grvVoucherDetails_PageIndexChanging"
                                OnRowEditing="grvVoucherDetails_RowEditing">

                                <Columns>
                                    <asp:TemplateField Visible="false" HeaderText="Tr Code" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTransactionCode" runat="server" Text='<%# Eval("Transaction_Code")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField Visible="false" HeaderText="Vch. No" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblVoucherNo" runat="server" Text='<%# Eval("Voucher_No")%>' />
                                        </ItemTemplate>

                                    </asp:TemplateField>

                                    <asp:TemplateField Visible="true" HeaderText="Ledger Code" ItemStyle-Width="8%" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLedgerCode" runat="server" Text='<%# Eval("Ledger_Code")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Particulars">
                                        <ItemTemplate>
                                            <asp:Label ID="lblParticulars" runat="server" Text='<%#Eval("Particulars") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="cmbParticulars" runat="server" Height="28px" AutoPostBack="True">
                                            </asp:DropDownList>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:TemplateField>

                                    <asp:TemplateField Visible="true" HeaderText="Nature" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNature" runat="server" Text='<%# Eval("Nature")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField Visible="true" HeaderText="Cheque No." ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblChequeNo" runat="server" Text='<%# Eval("ChequeNo")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField Visible="true" HeaderText="Dr." ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDr" runat="server" Text='<%# Eval("Debit","{0:n}")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="true" HeaderText="Cr." ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCr" runat="server" Text='<%# Eval("Credit","{0:n}")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="true" HeaderText="V. Date" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblVDate" runat="server" Text='<%# Eval("Voucher_Date","{0:dd/MM/yyyy}")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%-- <asp:BoundField DataField="Nature" HeaderText="Nature" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center">
                                        <ItemStyle Width="5%" CssClass="Grid_Border" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="ChequeNo" HeaderText="Cheque No." Visible="true">
                                        <ItemStyle Width="7%" CssClass="Grid_Border" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Debit" HeaderText="Dr." DataFormatString="{0:n}" ItemStyle-Width="8%" ItemStyle-HorizontalAlign="Center">
                                        <ItemStyle Width="10%" CssClass="Grid_Border" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Credit" HeaderText="Cr." Visible="true" DataFormatString="{0:n}" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%" NullDisplayText="0">
                                        <ItemStyle HorizontalAlign="Center" CssClass="Grid_Border" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Voucher_Date" HeaderText="V. Date" Visible="true" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="Center">
                                        <ItemStyle Width="5%" CssClass="Grid_Border" />
                                    </asp:BoundField>--%>

                                    <asp:TemplateField Visible="true" HeaderText="Module" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblModuleName" runat="server" Text='<%# Eval("ModuleName")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField Visible="true" HeaderText="Type" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblModuleType" runat="server" Text='<%# Eval("ModuleType")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField Visible="true" HeaderText="Identity No." ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIdNo" runat="server" Text='<%# Eval("IdentificationNo")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField Visible="false" HeaderText="IsChangable">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIsChangable" runat="server" Text='<%# Eval("IsChangable")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkEdit" runat="server" Text="" CommandName="Edit" ToolTip="Edit">
                                                <img id="Img1" src="~/ERP_Accounting/img/dg_edit.png" alt="Edit Details" runat="server" />
                                            </asp:LinkButton>
                                            <%-- <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/ERP_Accounting/img/dg_edit.png"
                                                CommandName="Edit" Width="18px" ToolTip="Edit Details" />--%>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:LinkButton ID="lnkUpdate" runat="server" Text="" CommandName="Update" ToolTip="Update">
                                                <img id="Img3" src="~/ERP_Accounting/img/tick.png" alt="Save" runat="server" />
                                            </asp:LinkButton>
                                            <%-- <asp:ImageButton ID="btnUpdate" runat="server" ImageUrl="~/ERP_Accounting/img/tick.png"
                                                Width="18px" CommandName="Update" ToolTip="Update" CssClass="float_but" />--%>
                                            <asp:ImageButton ID="btnCancel" runat="server" ImageUrl="~/ERP_Accounting/img/cross.png"
                                                Width="18px" CommandName="Cancel" ToolTip="Cancel" CssClass="float_but" />
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Details">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgbtnEdit" runat="server" CommandArgument='<%# Eval("Voucher_No") %>' ToolTip="View Details"
                                                CommandName="select" ImageUrl="~/ERP_Accounting/img/details-icon.png" Width="18" />
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



                        <div class="col-md-12">
                            <div class="col-md-10">
                               <b>Narration</b>
                                        <asp:TextBox ID="txtNarration" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <b style="margin-left:50px">Total Qty</b><asp:Label ID="lblTotalQty" Style="float: right;font-size:12px" runat="server" Text="" Font-Bold="true" ForeColor="Maroon"></asp:Label>
                            </div>
                        </div>

                    </div>

                    <div class="col-md-12" style="padding-top: 5px">
                        <fieldset>
                            <legend style="line-height: 0; margin-bottom: 0"><span style="background: #fff">Voucher Info</span></legend>
                            <asp:GridView ID="grvVoucherInfo" runat="server" AutoGenerateColumns="False" Width="100%" DataKeyNames="Voucher_No"
                                CellPadding="4" GridLines="Both" OnRowDataBound="grvVoucherInfo_RowDataBound"
                                BackColor="White" BorderColor="#336666" BorderStyle="Solid" BorderWidth="1px">
                                <Columns>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="2%">
                                        <HeaderTemplate>
                                            Sl No.
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblSRNO" runat="server"
                                                Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <%--  <asp:BoundField DataField="ModuleName" HeaderText="Module" ItemStyle-Width="5%">
                                        <ItemStyle Width="10%" CssClass="Grid_Border" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="ModuleType" HeaderText="Type" Visible="true" ItemStyle-Width="5%">
                                        <ItemStyle Width="10%" CssClass="Grid_Border" />
                                    </asp:BoundField>--%>

                                    <asp:TemplateField Visible="false" HeaderText="Challan No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblChallanNo" runat="server" Text='<%# Eval("ChallanNo")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="GroupName" HeaderText="Group">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="ProductName" HeaderText="Item">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Brand" HeaderText="Brand">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="StyleSize" HeaderText="Style/Size">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Barcode" HeaderText="Code" Visible="false">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CPU" HeaderText="CPU">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="ReceiveQuantity" HeaderText="Qty">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
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
            if (result === 'Data Processed Successfully') {
                toastr.success(result);
            }
            else if (result === 'Voucher Approved Successfully') {
                toastr.success(result);
            }
            else if (result === 'Ledger Name Updated Successfully') {
                toastr.success(result);
            }
            else
                toastr.error(result);

            return false;
        }

    </script>
</asp:Content>
