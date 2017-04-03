<%@ Page Title="" Language="C#" MasterPageFile="~/Procurement/Site.Master" AutoEventWireup="true" CodeBehind="BudgetEntryList.aspx.cs" Inherits="ERPSSL.Procurement.BudgetEntryList" %>
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
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="hm_sec_2_content scrollbar">

                    <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="glyphicon glyphicon-edit icon-padding"></i>Budget List
                    </div>
                </div>
                    <br />
                    <div class="widget-box">
                        <div class="widget-header">
                            
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
                                <li>
                                    <label class="control-label" for="inputFname1">
                                        From:
                                        <asp:TextBox ID="dtpFrom" runat="server" placeholder="MM/dd/yyyy"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender" runat="server" TargetControlID="dtpFrom"
                                            PopupButtonID="dtpFrom" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                    </label>
                                </li>
                            </ul>
                            <div class="buttonPanel">
                                <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/zoom77.png"
                                    Width="32px" ValidationGroup="validation" OnClick="btnSearch_Click" />
                                <asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/left arrow9.png"
                                    Width="32px" ToolTip="Go Back" OnClick="btnBack_Click" />
                                <asp:ImageButton ID="btnPrint" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/print49.png"
                                    Width="32px" OnClick="btnPrint_Click" />
                            </div>
                        </div>
                        <%-------------Panel--------------%>
                        <div class="widget-body">
                            <div class="widget-main no-padding">
                                <br />
                                <div class="radio_panel_reporting">
                                    <div class="SingleCheckbox ">
                                        <asp:RadioButton ID="rdbViewdtod" runat="server" GroupName="print"
                                            OnCheckedChanged="rdbViewdtod_CheckedChanged"
                                            AutoPostBack="true" />
                                        <asp:Label ID="Label3" AssociatedControlID="rdbViewdtod" runat="server"
                                            Text="Periodic Record's" CssClass="CheckBoxLabel"></asp:Label>
                                    </div>

                                    <div class="SingleCheckbox margin_left">
                                        <asp:RadioButton ID="rdbViewAll" runat="server" GroupName="print" Checked="true" />
                                        <asp:Label ID="Label2" AssociatedControlID="rdbViewAll" runat="server"
                                            Text="All Record's" CssClass="CheckBoxLabel"></asp:Label>
                                    </div>
                                </div>
                                <asp:Panel ID="messagePanel" runat="server" Style="padding: 0px" class="messagePanel"
                                    Visible="false">
                                    <div id="lblMesssge" runat="server" class="alert alert-success">
                                        <asp:Label ID="lblMessage" runat="server" Text="message"></asp:Label>
                                    </div>
                                </asp:Panel>
                                <div class="row-fluid" style="height: 410px; overflow: scroll; margin-top: 10px; padding-top: 10px; padding-bottom: 10px; border-top: 1px solid #eee;">
                                    <asp:GridView ID="dtg_list" runat="server" EmptyDataText="No Records Found!" AllowPaging="True"
                                        AllowSorting="True" AutoGenerateColumns="False" Width="100%" ShowFooter="True"
                                        CellPadding="1" PageSize="50" DataKeyNames="Budget_Code">
                                        <Columns>
                                            <asp:BoundField DataField="Budget_Code" HeaderText="Budget Code">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Ledger_Name" HeaderText="Particulars">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Left" Width="50%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Total_Budget" HeaderText="Total" DataFormatString="{0:n}">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Right" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <%-- <asp:BoundField DataField="Budget_Date" HeaderText="Budget Date" DataFormatString="{0:MM/dd/yyyy}">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="right" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>--%>

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
                        <%-------------Panel--------------%>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
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
