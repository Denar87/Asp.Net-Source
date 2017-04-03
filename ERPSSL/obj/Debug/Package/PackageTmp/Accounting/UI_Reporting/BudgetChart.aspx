<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Site.Master" AutoEventWireup="true" CodeBehind="BudgetChart.aspx.cs" Inherits="ERPSSL.Accounting.UI_Reporting.BudgetChart" %>

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
    <script type="text/javascript" language="javascript">
        function onCalendarShown() {
            var cal = $find("calendar1");
            cal._switchMode("years", true);
            if (cal._yearsBody) {
                for (var i = 0; i < cal._yearsBody.rows.length; i++) {
                    var row = cal._yearsBody.rows[i];
                    for (var j = 0; j < row.cells.length; j++) {
                        Sys.UI.DomEvent.addHandler(row.cells[j].firstChild, "click", call);
                    }
                }
            }
        }

        function onCalendarHidden() {
            var cal = $find("calendar1");
            if (cal._yearsBody) {
                for (var i = 0; i < cal._yearsBody.rows.length; i++) {
                    var row = cal._yearsBody.rows[i];
                    for (var j = 0; j < row.cells.length; j++) {
                        Sys.UI.DomEvent.removeHandler(row.cells[j].firstChild, "click", call);
                    }
                }
            }
        }

        function call(eventElement) {
            var target = eventElement.target;
            switch (target.mode) {
                case "year":
                    var cal = $find("calendar1");
                    cal.set_selectedDate(target.date);
                    cal._blur.post(true);
                    cal.raiseDateSelectionChanged(); break;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <div class="span12">
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="col-xs-12 col-sm-6 widget-container-col">
                    <div class="widget-box">
                        <div class="widget-header">
                            <h5 class="widget-title bigger lighter">
                                <i class="ace-icon fa fa-table"></i>Budget Varience
                            </h5>
                            <ul class="SearchPanel">
                                <li>
                                    <label class="control-label" for="inputFname1">
                                        Budget Year:
                                        <asp:TextBox ID="dtpTo" runat="server" placeholder="Year" Width="80px" ValidationGroup="validation"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="dtpTo_CalendarExtender1" runat="server" TargetControlID="dtpTo"
                                            PopupButtonID="dtpTo" CssClass="ajax__calendar" Enabled="True"
                                            Format="yyyy" BehaviorID="calendar1" OnClientHidden="onCalendarHidden" OnClientShown="onCalendarShown" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="dtpTo"
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
                                    Width="32px" />
                            </div>
                        </div>
                        <%-------------Panel--------------%>
                        <div class="widget-body">
                            <div class="widget-main no-padding">
                                <br />

                                <asp:Panel ID="messagePanel" runat="server" Style="padding: 0px" class="messagePanel"
                                    Visible="false">
                                    <div id="lblMesssge" runat="server" class="alert alert-success">
                                        <asp:Label ID="lblMessage" runat="server" Text="message"></asp:Label>
                                    </div>
                                </asp:Panel>
                                <div class="row-fluid" style="min-height: 410px; overflow-x: hidden; overflow-y: scroll; margin-top: 10px; padding-top: 10px; padding-bottom: 10px; border-top: 1px solid #eee;">
                                    <asp:Literal ID="lt" runat="server"></asp:Literal>
                                    <div id="chart_div" style="background: #fff; border: 0px solid #eee; margin-top: 7px; padding: 5px;"></div>
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
