<%@ Page Title="" Language="C#" MasterPageFile="~/FA/Site.Master" AutoEventWireup="true" CodeBehind="AcConfiguration.aspx.cs" Inherits="ERPSSL.FA.AcConfiguration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        $(function () {
            debugger;
            $("[id*=GridView1] td").hover(function () {
                $("td", $(this).closest("tr")).addClass("hover_row");
            }, function () {
                $("td", $(this).closest("tr")).removeClass("hover_row");
            });
        });
    </script>
    <script type="text/javascript">
        function EditSelectAll(StartIndex, HeadIndex) {
            var grid = document.getElementById("<%=dgListSales.ClientID%>");
            var inputs = grid.getElementsByTagName("input");
            var isValid = false;
            for (var i = StartIndex; i < inputs.length; i += 1) {
                if (inputs[i].type == "checkbox") {
                    if (inputs[HeadIndex].checked == true) {
                        if (i != HeadIndex)
                            inputs[i].checked = true;
                    }
                    else if (inputs[HeadIndex].checked == false) {
                        if (i != HeadIndex) {
                            inputs[i].checked = false;
                        }
                    }
                }
            }
        }

        function Edit(StartIndex, HeadIndex) {
            var grid = document.getElementById("<%=dgListSales.ClientID%>");
            var inputs = grid.getElementsByTagName("input");
            var isValid = false;
            var checkedCount = 0;
            for (var i = StartIndex; i < inputs.length; i += 1) {
                if (inputs[i].type == "checkbox") {
                    if (i != HeadIndex) {
                        if (inputs[i].checked == false) {
                            ++checkedCount;
                        }
                    }
                    if (checkedCount == 0) {
                        inputs[HeadIndex].checked = true;
                    }
                    else {
                        inputs[HeadIndex].checked = false;
                    }
                }
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <h3>Asset Summary
            </h3>


            <asp:Label ID="lblMessage" runat="server" Font-Bold="true" Font-Size="Large"></asp:Label>
            <br />

            <div style="height: 270px; overflow: scroll;">
                <asp:GridView ID="dgListSales" runat="server" AutoGenerateColumns="False" Width="100%"
                    EmptyDataText="No Records Found!" AllowPaging="false" AllowSorting="True" CellPadding="5">
                    <Columns>

                        <asp:BoundField DataField="AssetCode" HeaderText="Item">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="20%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>

                        <asp:BoundField DataField="XACAcquisition" HeaderText="Total">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="20%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>

                        <asp:TemplateField HeaderText="Status">
                            <HeaderTemplate>
                                <div class="GridCheckbox_ ">
                                    <asp:CheckBox ID="chkbxEditAll_" runat="server" AutoPostBack="true" onclick="EditSelectAll(0,0)" />
                                    <asp:Label ID="LabelEdit" AssociatedControlID="chkbxEditAll_" runat="server"
                                        Text="Select All" CssClass="CheckBoxLabel"></asp:Label>
                                </div>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div class="GridCheckbox ">
                                    <asp:CheckBox ID="chkbxEditItem_" runat="server" onclick="Edit(0, 0)" Enabled="true" />
                                    <asp:Label ID="LabelStatus" AssociatedControlID="chkbxEditItem_" runat="server" ForeColor="Black"
                                        Text="" CssClass="CheckBoxLabel"></asp:Label>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataRowStyle ForeColor="Red" />

                    <RowStyle CssClass="Grid_RowStyle" />
                    <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                    <PagerStyle BackColor="#6393c1" ForeColor="White" HorizontalAlign="Right" CssClass="gridview_paging" />
                </asp:GridView>
            </div>
            <asp:Button ID="btnSync" runat="server" Text="Post Asset" class="btn btn-danger" OnClick="btnSync_Click" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
