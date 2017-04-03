<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Site.Master" AutoEventWireup="true"
    CodeBehind="LedgerBook.aspx.cs" Inherits="ERPSSL.Accounting.UI_Reporting.LedgerBook"
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
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" AsyncPostBackTimeout="2400"/>
    <script type="text/javascript">
        var xPos, yPos;
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_beginRequest(BeginRequestHandler);
        prm.add_endRequest(EndRequestHandler);
        function BeginRequestHandler(sender, args) {
            xPos = $get('scrollDiv').scrollLeft;
            yPos = $get('scrollDiv').scrollTop;
        }
        function EndRequestHandler(sender, args) {
            $get('scrollDiv').scrollLeft = xPos;
            $get('scrollDiv').scrollTop = yPos;
        }
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                    <div class="LoaderBackground_">
                        <asp:Image ID="Image1" runat="server" CssClass="LoaderBackground_Image" ImageUrl="../Images/preloaders.gif" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <%-------------Panel--------------%>
            <div class="span12">
                <br />
                <div class="col-xs-12 col-sm-6 widget-container-col">
                    <div class="widget-box">
                        <div class="widget-header">
                            <h5 class="widget-title bigger lighter">
                                <i class="ace-icon fa fa-table"></i>Ledger Book
                            </h5>
                            <ul class="SearchPanel">
                                <li>
                                    <label class="control-label" for="inputFname1">
                                        Input Ledger Name/Code:
                                        <asp:TextBox ID="LedgerSearch" runat="server" placeholder="" Width="350px"
                                            OnTextChanged="LedgerSearch_TextChanged" AutoPostBack="true">
                                        </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="LedgerSearch"
                                            ForeColor="Red" ValidationGroup="validation" ErrorMessage="*"
                                            runat="server" Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                    </label>
                                </li>
                            </ul>
                            <div class="buttonPanel">
                                <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/zoom77.png"
                                    Width="32px" ValidationGroup="validation" OnClick="btnSearch_Click" />
                                <asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/left arrow9.png"
                                    Width="32px" ToolTip="Go Back" />
                                <asp:ImageButton ID="btnPrint" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/print49.png"
                                    Width="32px" OnClick="btnPrint_Click" />
                            </div>
                        </div>
                        <div class="widget-body">
                            <div class="widget-main no-padding">
                                <br />
                                <asp:Panel ID="messagePanel" runat="server" Style="padding: 0px" class="messagePanel"
                                    Visible="false">
                                    <div id="lblMesssge" runat="server" class="alert alert-success">
                                        <asp:Label ID="lblMessage" runat="server" Text="message"></asp:Label>
                                    </div>
                                </asp:Panel>
                                <div class="row-fluid" style="height: 410px; overflow-x: hidden; overflow-y: scroll; margin-top: 10px; padding-top: 10px; padding-bottom: 10px; border-top: 1px solid #eee;">
                                    <asp:Panel ID="Panel1" runat="server" Style="padding: 10px" class="messagePanel"
                                        Visible="false">
                                        <asp:Label ID="Label1" runat="server" Text="message"></asp:Label>
                                    </asp:Panel>
                                    <asp:GridView ID="dtg_list" runat="server" EmptyDataText="No Records Found!" AllowPaging="False"
                                        AllowSorting="True" AutoGenerateColumns="False" Width="100%" ShowFooter="True"
                                        CellPadding="1" OnRowDataBound="OnRowDataBound" DataKeyNames="Ledger_Code,Ledger_Name" OnSelectedIndexChanged="dtg_list_SelectedIndexChanged"
                                        OnRowCommand="dtg_list_RowCommand">
                                        <Columns>
                                            <asp:BoundField DataField="Ledger_Code" HeaderText="Ledger Code">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="5%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Ledger_Name" HeaderText="Particulars">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="30%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Debit" HeaderText="Dr." HeaderStyle-HorizontalAlign="Right"
                                                DataFormatString="{0:n}">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="right" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Credit" HeaderText="Cr." HeaderStyle-HorizontalAlign="Right"
                                                DataFormatString="{0:n}">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="right" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Balance" HeaderText="Bal." HeaderStyle-HorizontalAlign="Right"
                                                DataFormatString="{0:n}">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="right" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:TemplateField ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnView" runat="server" ImageUrl="../Resources/details-icon.png"
                                                        CommandName="View" Width="18px" ToolTip="View Details" />
                                                </ItemTemplate>
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:TemplateField>
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
                    </div>
                </div>
            </div>
            <%-------------Panel--------------%>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
