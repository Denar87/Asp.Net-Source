<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Site.Master" AutoEventWireup="true"
    CodeBehind="VoucherDetails.aspx.cs" Inherits="ERPSSL.Accounting.UI_Voucher.VoucherDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" AsyncPostBackTimeout="2400" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                    <div class="LoaderBackground_">
                        <asp:Image ID="Image1" runat="server" CssClass="LoaderBackground_Image" ImageUrl="../Images/preloaders.gif" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div class="span12">
                <br />
                <div class="col-xs-12 col-sm-6 widget-container-col">
                    <div class="widget-box">
                        <div class="widget-header">
                            <h5 class="widget-title bigger lighter">
                                <i class="ace-icon fa fa-table"></i>Voucher Details
                            </h5>
                            <ul class="VoucherPanel" style="margin-right: 80px">
                                <li>
                                    <label class="control-label" for="inputFname1">
                                        Voucher No:
                                <asp:TextBox ID="txtVoucherNo" runat="server" Width="150px" ReadOnly="true">
                                </asp:TextBox>
                                    </label>
                                </li>
                                <li>
                                    <label class="control-label" for="inputFname1">
                                        Voucher Date:
                                <asp:TextBox ID="dtpVoucherDate" runat="server" placeholder="MM/dd/yyyy" Width="100px" ReadOnly="true">
                                </asp:TextBox>
                                    </label>
                                </li>
                            </ul>
                            <div class="buttonPanel">
                                <asp:ImageButton ID="BtnApprove" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/check59.png"
                                    Width="32px" OnClick="BtnApprove_Click" ToolTip="Approve Voucher" />

                                <span onclick="return confirm('Are you sure want to Discard?')">
                                    <asp:ImageButton ID="BtnDiscard" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/ban2.png"
                                        Width="32px" OnClick="BtnDiscard_Click" ToolTip="Discard Voucher" />
                                </span>

                                <asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/left arrow9.png"
                                    Width="32px" OnClick="btnBack_Click" ToolTip="Go Back" />
                                <asp:ImageButton ID="btnUpdate" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/save29.png"
                                    Width="32px" OnClick="btnUpdate_Click" ToolTip="Update Voucher" />
                                <asp:ImageButton ID="btnPrint" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/print49.png"
                                    Width="32px" OnClick="btnPrint_Click" />
                            </div>
                        </div>
                        <div class="widget-body">
                            <div class="widget-main no-padding">
                                <br />
                                <asp:Panel ID="messagePanel" runat="server" Style="padding-bottom: 10px" class="messagePanel"
                                    Visible="false">
                                    <div id="lblMesssge" runat="server" class="alert alert-success">
                                        <asp:Label ID="lblMessage" runat="server" Text="message"></asp:Label>
                                    </div>
                                </asp:Panel>
                                <div class="row-fluid" style="height: 410px; overflow: scroll; margin-top: 10px; padding-top: 10px; padding-bottom: 10px; border-top: 1px solid #eee;">
                                    <asp:Panel ID="Panel1" runat="server" Style="padding: 10px" class="messagePanel"
                                        Visible="false">
                                        <asp:Label ID="Label1" runat="server" Text="message"></asp:Label>
                                    </asp:Panel>
                                    <asp:GridView ID="dtg_list" runat="server" EmptyDataText="No Records Found!" AllowPaging="False"
                                        AllowSorting="True" AutoGenerateColumns="False" Width="100%" ShowFooter="True"
                                        CellPadding="0" PageSize="50" DataKeyNames="Ledger_Code">
                                        <Columns>
                                            <asp:BoundField DataField="Ledger_Code" HeaderText="Ledger Code">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Nature" HeaderText="Nature">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ChequeNo" HeaderText="Cheque No.">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Particulars" HeaderText="Particulars">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="30%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Debit" HeaderText="Dr." DataFormatString="{0:n}">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Right" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Credit" HeaderText="Cr." DataFormatString="{0:n}">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Right" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Voucher_Date" HeaderText="Voucher Date" DataFormatString="{0:MM/dd/yyyy}"
                                                HtmlEncode="false">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                        </Columns>
                                        <EmptyDataRowStyle ForeColor="Red" />
                                        <RowStyle CssClass="Grid_RowStyle" />
                                        <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                        <PagerStyle BackColor="#6393c1" ForeColor="White" HorizontalAlign="Right" CssClass="gridview_paging" />
                                    </asp:GridView>
                                    <div class="Voucher_form">
                                        <div class="clearfix">
                                        </div>
                                        <div class="controls">
                                            <label class="control-label" for="inputFname1">
                                                Narration:
                                            </label>
                                            <asp:TextBox ID="txtNarration" runat="server" Width="99%" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="clearfix">
                                </div>
                            </div>
                            <div class="clearfix">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        window.onload = function () {

            var x = document.getElementById('<%= lblMessage.ClientID %>');

            if (x.innerHTML == 'message') {
                document.getElementById("<%=lblMesssge.ClientID %>").style.display = "none";
            }
            else {
                var seconds = 5;
                setTimeout(function () {
                    document.getElementById("<%=lblMesssge.ClientID %>").style.display = "none";
            }, seconds * 1000);
        }
        };
    </script>
</asp:Content>


