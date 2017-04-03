<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Site.Master" AutoEventWireup="true"
    CodeBehind="PaymentVoucher.aspx.cs" Inherits="ERPSSL.Accounting.UI_Voucher.PaymentVoucher" 
    EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("[id*=GridView1] td").hover(function () {
                $("td", $(this).closest("tr")).addClass("hover_row");
            }, function () {
                $("td", $(this).closest("tr")).removeClass("hover_row");
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <div class="span12">
        <br />
        <div class="col-xs-12 col-sm-6 widget-container-col">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="widget-box">
                        <div class="widget-header">
                            <h5 class="widget-title bigger lighter" style="color: #ff6a00;">
                                <i class="ace-icon fa fa-table"></i>Payment Voucher
                            </h5>
                            <ul class="VoucherPanel" style="margin-right: 40px">
                                <li>
                                    <label class="control-label" for="inputFname1">
                                        Voucher No:
                                <asp:TextBox ID="txtVoucherNo" runat="server" Width="150px" Enabled="False" BackColor="Orange" ForeColor="White">
                                </asp:TextBox>
                                    </label>
                                </li>
                                <li>
                                    <label class="control-label" for="inputFname1">
                                        Voucher Date:
                                <asp:TextBox ID="dtpVoucherDate" runat="server" placeholder="MM/dd/yyyy" Width="100px" BackColor="Orange" ForeColor="White">
                                </asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="dtpVoucherDate"
                                            PopupButtonID="dtpVoucherDate" Format="MM/dd/yyyy" CssClass="ajax__calendar"
                                            Enabled="True" />
                                    </label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="dtpVoucherDate"
                                        ForeColor="Red" ValidationGroup="validation" runat="server" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                </li>
                                <li>
                                    <label class="control-label" for="inputFname1">
                                        Currency:
                                <asp:DropDownList ID="cmbCurrency" runat="server" Width="80px">
                                </asp:DropDownList>
                                    </label>
                                </li>
                            </ul>
                            <div class="buttonPanel">
                                <span onclick="return confirm('Are you sure want to delete?')">
                                    <asp:ImageButton ID="btnReset" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/refresh69.png"
                                        Width="32px" OnClick="btnReset_Click" />
                                </span>
                                <asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/left arrow9.png"
                                    Width="32px" ToolTip="Go Back" OnClick="btnBack_Click" />
                                <asp:ImageButton ID="btnSubmit" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/save29.png"
                                    Width="32px" OnClick="btnSubmit_Click" ToolTip="Save Changes" ValidationGroup="validation" />
                                <asp:ImageButton ID="btnVchList" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/speech balloon.png"
                                    Width="32px" OnClick="btnVchList_Click" />

                            </div>
                        </div>

                        <%-------------Panel--------------%>
                        <div class="widget-body">
                            <div class="widget-main no-padding">
                                <br />
                                <div style="position: relative">
                                    <ul class="voucher_total_style">
                                        <li>
                                            <asp:Label ID="txtdbtTotal" runat="server" Text="Dr.- 0.00"></asp:Label></li>
                                        <li>
                                            <asp:Label ID="txtCrdTotal" runat="server" Text="Cr.- 0.00"></asp:Label></li>
                                    </ul>

                                </div>
                                <asp:Panel ID="messagePanel" runat="server" Style="padding: 0px" class="messagePanel"
                                    Visible="false">
                                    <div id="lblMesssge" runat="server" class="alert alert-success">
                                        <asp:Label ID="lblMessage" runat="server" Text="message"></asp:Label>
                                    </div>
                                </asp:Panel>
                                <%-------------left panel--------------%>
                                <div class="vch_sec_1">
                                    <div class="row-fluid">
                                        <div class="">
                                            <asp:GridView ID="dtg_ACT" runat="server" CellPadding="5" AutoGenerateColumns="false" Width="100%"
                                                ShowFooter="true" GridLines="None" OnRowDeleting="dtg_ACT_RowDeleting" OnRowCancelingEdit="dtg_ACT_RowCancelingEdit"
                                                OnRowEditing="dtg_ACT_RowEditing" OnRowUpdating="dtg_ACT_RowUpdating" OnRowDataBound="dtg_ACT_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Sr.">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSerial" runat="server" Text='<%#Eval("Voucher_Details_ID") %>'
                                                                Width="30px"></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header Color_Orange" Width="30px" />
                                                        <ItemStyle HorizontalAlign="Left" Width="30px" CssClass="Grid_Border" />
                                                        <FooterStyle CssClass="Grid_Footer Color_Orange" Width="30px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Nature">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblNature" runat="server" Text='<%#Eval("Nature") %>' Width="80px"></asp:Label>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:DropDownList ID="cmbNature" runat="server" Width="75px" OnSelectedIndexChanged="cmbNature_SelectedIndexChanged"
                                                                AutoPostBack="true" OnDataBound="cmbNature_DataBound">
                                                                <asp:ListItem>Dr./Cr.</asp:ListItem>
                                                                <asp:ListItem>DEBIT</asp:ListItem>
                                                                <asp:ListItem>CREDIT</asp:ListItem>
                                                            </asp:DropDownList>
                                                            </EditItemTemplate>
                                                        </FooterTemplate>
                                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header Color_Orange" Width="80px" />
                                                        <ItemStyle HorizontalAlign="Left" Width="80px" CssClass="Grid_Border" />
                                                        <FooterStyle CssClass="Grid_Footer Color_Orange" Width="80px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Particulars">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblParticulars" runat="server" Text='<%#Eval("Particulars") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:TextBox ID="txtParticulars" runat="server" Width="250px" OnTextChanged="txtParticulars_TextChanged" AutoPostBack="True" />
                                                        </FooterTemplate>
                                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header Color_Orange" Width="250px" />
                                                        <ItemStyle HorizontalAlign="Left" CssClass="Grid_Border" Width="250px" />
                                                        <FooterStyle CssClass="Grid_Footer Color_Orange" Width="250px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Cheque No">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblChequeNo" runat="server" Text='<%#Eval("ChequeNo") %>' Width="150px"></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtChequeNoEdit" runat="server" Text='<%#Eval("ChequeNo") %>' Width="150px"></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:TextBox ID="txtChequeNo" runat="server" Width="150px" />
                                                        </FooterTemplate>
                                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header Color_Orange" Width="150px" />
                                                        <ItemStyle HorizontalAlign="Left" CssClass="Grid_Border" Width="150px" />
                                                        <FooterStyle CssClass="Grid_Footer Color_Orange" Width="150px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Dr.">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDebit" runat="server" Text='<%#Eval("Debit") %>' Width="100px"></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtDebitEdit" runat="server" Text='<%#Eval("Debit") %>' Width="100px"></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:TextBox ID="txtDebit" runat="server" Width="100px" Text="0.00" ReadOnly="true" />
                                                        </FooterTemplate>
                                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header Color_Orange" Width="100px" />
                                                        <ItemStyle HorizontalAlign="Right" CssClass="Grid_Border" Width="100px" />
                                                        <FooterStyle CssClass="Grid_Footer Color_Orange" Width="100px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Cr.">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCredit" runat="server" Text='<%#Eval("Credit") %>' Width="100px"></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtCreditEdit" runat="server" Text='<%#Eval("Credit") %>' Width="100px"></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:TextBox ID="txtCredit" runat="server" Width="100px" Text="0.00" ReadOnly="true" />
                                                        </FooterTemplate>
                                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header Color_Orange" Width="100px" />
                                                        <ItemStyle HorizontalAlign="Right" CssClass="Grid_Border" Width="100px" />
                                                        <FooterStyle CssClass="Grid_Footer Color_Orange" Width="100px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set_1/pencil41.png"
                                                                Width="16px" CommandName="Edit" ToolTip="Edit" CssClass="float_but" />
                                                            <span onclick="return confirm('Are you sure want to delete?')">
                                                                <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/cross106.png"
                                                                    Width="16px" CommandName="Delete" ToolTip="Delete" CssClass="float_but" />
                                                            </span>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:ImageButton ID="btnUpdate" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/refresh69.png"
                                                                Width="16px" CommandName="Update" ToolTip="Update" CssClass="float_but" />
                                                            <asp:ImageButton ID="btnCancel" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/cross106.png"
                                                                Width="16px" CommandName="Cancel" ToolTip="Cancel" CssClass="float_but" />
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/check60.png"
                                                                OnClick="Add" CommandName="EmptyDataTemplate" Width="32px" />
                                                        </FooterTemplate>
                                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header Color_Orange" Width="150px" />
                                                        <ItemStyle HorizontalAlign="Right" CssClass="Grid_Border" Width="150px" />
                                                        <FooterStyle CssClass="Grid_Footer Color_Orange" Width="150px" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EmptyDataTemplate>
                                                    <tr class="Grid_Header Color_Orange">
                                                        <th scope="col">Nature
                                                        </th>
                                                        <%-- <th scope="col">Ledger Code
                                                    </th>--%>
                                                        <th scope="col">Particulars
                                                        </th>
                                                        <th scope="col">ChequeNo
                                                        </th>
                                                        <th scope="col">Debit
                                                        </th>
                                                        <th scope="col">Credit
                                                        </th>
                                                        <th scope="col">Option
                                                        </th>
                                                    </tr>
                                                    <tr class="Grid_Footer Color_Orange">
                                                        <td>
                                                            <asp:DropDownList ID="cmbNature" runat="server" Width="85px" OnSelectedIndexChanged="cmbNature_SelectedIndexChanged"
                                                                AutoPostBack="true" OnDataBound="cmbNature_DataBound">
                                                                <asp:ListItem>Dr./Cr.</asp:ListItem>
                                                                <asp:ListItem>DEBIT</asp:ListItem>
                                                                <asp:ListItem>CREDIT</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtParticulars" runat="server" Width="250px" OnTextChanged="txtParticulars_TextChanged" AutoPostBack="True"/>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtChequeNo" runat="server" Width="150px" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtDebit" runat="server" Width="100px" Text="0.00" ReadOnly="true" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtCredit" runat="server" Width="100px" Text="0.00" ReadOnly="true" />
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/add200.png"
                                                                Width="30px" OnClick="Add" CommandName="EmptyDataTemplate" />
                                                        </td>
                                                    </tr>
                                                </EmptyDataTemplate>
                                                <EmptyDataRowStyle ForeColor="Red" />
                                                <RowStyle CssClass="Grid_RowStyle" />
                                                <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                                <PagerStyle BackColor="#6393c1" ForeColor="White" HorizontalAlign="Right" CssClass="gridview_paging" />
                                            </asp:GridView>
                                            <div class="Voucher_form">
                                                <div class="controls">
                                                    <label class="control-label" for="inputFname1">
                                                        Narration:
                                                    </label>
                                                    <asp:TextBox ID="txtNarration" runat="server" Width="99%" TextMode="MultiLine"></asp:TextBox>
                                                </div>
                                                <div class="clearfix">
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%-------------right panel--------------%>
                                <div class="vch_sec_2">
                                    <asp:GridView ID="dgLedger_List" runat="server" CellPadding="1" AutoGenerateColumns="false"
                                        Width="100%" DataKeyNames="Ledger_Code" OnRowDataBound="OnRowDataBound" OnSelectedIndexChanged="dgLedger_List_SelectedIndexChanged">
                                        <Columns>
                                            <asp:BoundField DataField="Ledger_Code" HeaderText="Ledger Code" Visible="false">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Ledger_Name" HeaderText="Particulars">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="50%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                        </Columns>
                                        <EmptyDataRowStyle ForeColor="Red" />
                                        <RowStyle CssClass="Grid_RowStyle" />
                                        <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                        <PagerStyle BackColor="#6393c1" ForeColor="White" HorizontalAlign="Right" CssClass="gridview_paging" />
                                    </asp:GridView>
                                </div>
                                <div class="clearfix">
                                </div>
                            </div>
                            <div class="clearfix">
                            </div>
                        </div>
                        <%-------------Panel--------------%>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
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
