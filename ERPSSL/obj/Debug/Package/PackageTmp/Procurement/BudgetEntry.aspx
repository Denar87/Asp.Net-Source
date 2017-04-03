<%@ Page Title="" Language="C#" MasterPageFile="~/Procurement/Site.Master" AutoEventWireup="true" CodeBehind="BudgetEntry.aspx.cs" Inherits="ERPSSL.Procurement.BudgetEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
     <ajaxToolkit:ToolkitScriptManager runat="Server" ID="ScriptManager1" AsyncPostBackTimeout="2400" />
    <asp:UpdatePanel ID="upnlAjax" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                    <div class="LoaderBackground_">
                        <asp:Image ID="Image1" runat="server" CssClass="LoaderBackground_Image" ImageUrl="../Images/preloaders.gif" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div class="">
                <br />
                <div class="hm_sec_2_content scrollbar">
                    <%------------------UpdatePanel-----------------%>

                    <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="glyphicon glyphicon-edit icon-padding"></i>Budget Creation
                    </div>
                </div>
                    <br />
                    <div class="widget-box">
                        <div class="widget-header">
                            
                            <ul class="SearchPanel">
                                <li>
                                    <label class="control-label" for="inputFname1">
                                        Budget Year:
                                        <asp:TextBox ID="dtpTo" runat="server" placeholder="Year" Width="80px"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="dtpTo_CalendarExtender1" runat="server" TargetControlID="dtpTo"
                                            PopupButtonID="dtpTo" CssClass="ajax__calendar" Enabled="True"
                                            Format="yyyy" BehaviorID="calendar1" OnClientHidden="onCalendarHidden" OnClientShown="onCalendarShown" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="dtpTo"
                                            ForeColor="Red" ValidationGroup="validation_" ErrorMessage="*"
                                            runat="server" Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                    </label>
                                </li>
                            </ul>
                            <div class="buttonPanel">
                                <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/add200.png"
                                    Width="32px" OnClick="btnAdd_Click" ToolTip="Save Changes" ValidationGroup="validation_" />
                                <asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/left arrow9.png"
                                    Width="32px" ToolTip="Go Back" OnClick="btnBack_Click" />
                                <asp:ImageButton ID="btnPrint" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/print49.png"
                                    Width="32px" OnClick="btnPrint_Click" ToolTip="Print" Visible="false" />
                            </div>
                        </div>
                        <%------------------Sec-----------------%>
                        <div style="overflow-x: hidden; overflow-y: scroll; margin-top: 10px; padding-top: 10px; padding-bottom: 10px; border-top: 1px solid #eee; height: 442px;">
                            <asp:Panel ID="messagePanel" runat="server" Style="padding: 0px" class="messagePanel"
                                Visible="false">
                                <div id="lblMesssge" runat="server" class="alert alert-success">
                                    <asp:Label ID="lblMessage" runat="server" Text="message"></asp:Label>
                                </div>
                            </asp:Panel>
                            <asp:GridView ID="dtg_list" runat="server" EmptyDataText="No Records Found!" AllowPaging="False"
                                AllowSorting="True" Width="100%" ShowFooter="True" AutoGenerateColumns="False"
                                CellPadding="1" OnRowCancelingEdit="dtg_list_RowCancelingEdit"
                                OnRowEditing="dtg_list_RowEditing" OnRowUpdating="dtg_list_RowUpdating">
                                <Columns>
                                    <asp:TemplateField HeaderText="Ledger Code" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLedger_Code" runat="server" Text='<%#Eval("Ledger_Code") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" Width="100px" />
                                        <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" Width="100px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Budget Code" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBudget_Code" runat="server" Text='<%#Eval("Budget_Code") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" Width="100px" />
                                        <ItemStyle HorizontalAlign="Left" Width="100px" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" Width="100px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ledger Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLedger_Name" runat="server" Text='<%#Eval("Ledger_Name") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" Width="20%" />
                                        <ItemStyle HorizontalAlign="Left" Width="20%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" Width="20%" />
                                    </asp:TemplateField>

                                    <%---------------Month-------------------%>
                                    <asp:TemplateField HeaderText="JAN">
                                        <ItemTemplate>
                                            <asp:Label ID="lblJan" runat="server" Text='<%#Eval("Jan") %>' Width="50px"></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtMonth_Jan" runat="server" Text='<%#Eval("Jan") %>' Width="50px"></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" Width="7%" />
                                        <ItemStyle HorizontalAlign="Left" CssClass="Grid_Border" Width="7%" />
                                        <FooterStyle CssClass="Grid_Footer" Width="7%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="FEB">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFeb" runat="server" Text='<%#Eval("Feb") %>' Width="50px"></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtMonth_Feb" runat="server" Text='<%#Eval("Feb") %>' Width="50px"></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" Width="7%" />
                                        <ItemStyle HorizontalAlign="Left" CssClass="Grid_Border" Width="7%" />
                                        <FooterStyle CssClass="Grid_Footer" Width="7%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="MAR">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMar" runat="server" Text='<%#Eval("Mar") %>' Width="50px"></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtMonth_Mar" runat="server" Text='<%#Eval("Mar") %>' Width="50px"></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" Width="7%" />
                                        <ItemStyle HorizontalAlign="Left" CssClass="Grid_Border" Width="7%" />
                                        <FooterStyle CssClass="Grid_Footer" Width="7%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="APR">
                                        <ItemTemplate>
                                            <asp:Label ID="lblApr" runat="server" Text='<%#Eval("Apr") %>' Width="50px"></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtMonth_Apr" runat="server" Text='<%#Eval("Apr") %>' Width="50px"></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" Width="7%" />
                                        <ItemStyle HorizontalAlign="Left" CssClass="Grid_Border" Width="7%" />
                                        <FooterStyle CssClass="Grid_Footer" Width="7%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="MAY">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMay" runat="server" Text='<%#Eval("May") %>' Width="50px"></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtMonth_May" runat="server" Text='<%#Eval("May") %>' Width="50px"></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" Width="7%" />
                                        <ItemStyle HorizontalAlign="Left" CssClass="Grid_Border" Width="7%" />
                                        <FooterStyle CssClass="Grid_Footer" Width="7%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="JUN">
                                        <ItemTemplate>
                                            <asp:Label ID="lblJun" runat="server" Text='<%#Eval("Jun") %>' Width="50px"></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtMonth_Jun" runat="server" Text='<%#Eval("Jun") %>' Width="50px"></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" Width="7%" />
                                        <ItemStyle HorizontalAlign="Left" CssClass="Grid_Border" Width="7%" />
                                        <FooterStyle CssClass="Grid_Footer" Width="7%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="JUL">
                                        <ItemTemplate>
                                            <asp:Label ID="lblJul" runat="server" Text='<%#Eval("Jul") %>' Width="50px"></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtMonth_Jul" runat="server" Text='<%#Eval("Jul") %>' Width="50px"></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" Width="7%" />
                                        <ItemStyle HorizontalAlign="Left" CssClass="Grid_Border" Width="7%" />
                                        <FooterStyle CssClass="Grid_Footer" Width="7%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="AUG">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAug" runat="server" Text='<%#Eval("Aug") %>' Width="50px"></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtMonth_Aug" runat="server" Text='<%#Eval("Aug") %>' Width="50px"></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" Width="7%" />
                                        <ItemStyle HorizontalAlign="Left" CssClass="Grid_Border" Width="7%" />
                                        <FooterStyle CssClass="Grid_Footer" Width="7%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SEP">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSep" runat="server" Text='<%#Eval("Sep") %>' Width="50px"></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtMonth_Sep" runat="server" Text='<%#Eval("Sep") %>' Width="50px"></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" Width="7%" />
                                        <ItemStyle HorizontalAlign="Left" CssClass="Grid_Border" Width="7%" />
                                        <FooterStyle CssClass="Grid_Footer" Width="7%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="OCT">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOct" runat="server" Text='<%#Eval("Oct") %>' Width="50px"></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtMonth_Oct" runat="server" Text='<%#Eval("Oct") %>' Width="50px"></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" Width="7%" />
                                        <ItemStyle HorizontalAlign="Left" CssClass="Grid_Border" Width="7%" />
                                        <FooterStyle CssClass="Grid_Footer" Width="7%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="NOV">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNov" runat="server" Text='<%#Eval("Nov") %>' Width="50px"></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtMonth_Nov" runat="server" Text='<%#Eval("Nov") %>' Width="50px"></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" Width="7%" />
                                        <ItemStyle HorizontalAlign="Left" CssClass="Grid_Border" Width="7%" />
                                        <FooterStyle CssClass="Grid_Footer" Width="7%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DEC">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDec" runat="server" Text='<%#Eval("Dec") %>' Width="50px"></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtMonth_Dec" runat="server" Text='<%#Eval("Dec") %>' Width="50px"></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" Width="7%" />
                                        <ItemStyle HorizontalAlign="Left" CssClass="Grid_Border" Width="7%" />
                                        <FooterStyle CssClass="Grid_Footer" Width="7%" />
                                    </asp:TemplateField>
                                    <%-- ---------------Month-----------------%>

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set_1/pencil41.png"
                                                Width="16px" CommandName="Edit" ToolTip="Edit" CssClass="float_but" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:ImageButton ID="btnUpdate" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/refresh69.png"
                                                Width="16px" CommandName="Update" ToolTip="Update" CssClass="float_but" />
                                            <asp:ImageButton ID="btnCancel" runat="server" ImageUrl="~/Accounting/Resources/png_icon_set/cross106.png"
                                                Width="16px" CommandName="Cancel" ToolTip="Cancel" CssClass="float_but" />
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" Width="50px" />
                                        <ItemStyle HorizontalAlign="Right" CssClass="Grid_Border" Width="50px" />
                                        <FooterStyle CssClass="Grid_Footer" Width="50px" />
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataRowStyle ForeColor="Red" />
                                <RowStyle CssClass="Grid_RowStyle" />
                                <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                <PagerStyle BackColor="#6393c1" ForeColor="White" HorizontalAlign="Right" CssClass="gridview_paging" />
                            </asp:GridView>
                        </div>

                    </div>
                    <%------------------UpdatePanel-----------------%>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
