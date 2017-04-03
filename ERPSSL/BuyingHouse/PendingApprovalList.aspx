<%@ Page Title="" Language="C#" MasterPageFile="~/BuyingHouse/BuyingSite.Master" AutoEventWireup="true" CodeBehind="PendingApprovalList.aspx.cs" Inherits="ERPSSL.BuyingHouse.PendingApprovalList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
        <ContentTemplate>
            <div class="hm_sec_2_content scrollbar">
                <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="fa fa-edit fa-fw icon-padding"></i>Notification List
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12 bg-success">
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </div>
                    <div class="col-md-12">
                        <asp:GridView ID="gridviewPanding" runat="server" AutoGenerateColumns="False"
                            Width="100%" CellPadding="5" AllowPaging="True" OnPageIndexChanging="gridviewPanding_OnPageIndexChanging">
                            <Columns>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="3%" HeaderStyle-HorizontalAlign="Center">
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
                                        <asp:Label ID="lblTID" runat="server" Text='<%# Eval("TID")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRedirectPageName" runat="server" Text='<%# Eval("RedirectPage")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTableUniqeID" runat="server" Text='<%# Eval("TableUniqeID")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUserEID" runat="server" Text='<%# Eval("UserEID")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblOrder_No" runat="server" Text='<%# Eval("Order_No")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="PandingDescription" HeaderText="New Comments">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>

                                <asp:TemplateField HeaderText="View">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgbtnEdit" runat="server" ImageUrl="~/img/list_edit.png" OnClick="imgbtnEdit_Click" />
                                    </ItemTemplate>
                                    <ItemStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataRowStyle ForeColor="Red" />
                            <RowStyle CssClass="Grid_RowStyle" />
                            <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                            <PagerSettings Mode="NumericFirstLast" />
                            <PagerStyle ForeColor="#000066" HorizontalAlign="Left" BackColor="White" CssClass="pagination01 pageback" />
                            <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <%--  <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />--%>
        </Triggers>
    </asp:UpdatePanel>

    <script type="text/javascript">

        function func(result) {
            if (result === 'Data Save Successfully') {
                toastr.success(result);
            }
            else if (result === 'Data Update Successfully') {
                toastr.success(result);
            }
            else
                toastr.error(result);
            return false;
        }

    </script>

</asp:Content>
