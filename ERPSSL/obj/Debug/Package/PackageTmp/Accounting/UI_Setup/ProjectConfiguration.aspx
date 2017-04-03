<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Site.Master" AutoEventWireup="true" CodeBehind="ProjectConfiguration.aspx.cs" Inherits="ERPSSL.Accounting.UI_Setup.ProjectConfiguration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <div class="span12">
        <br />
        <div class="col-xs-12 col-sm-6 widget-container-col">
            <div class="widget-box">
                <div class="widget-header">
                    <h5 class="widget-title bigger lighter">
                        <i class="ace-icon fa fa-table"></i>Statement Configuration
                    </h5>
                </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <%-------------Panel--------------%>
                        <div class="widget-body">
                            <div class="widget-main no-padding">
                                <asp:Panel ID="messagePanel" runat="server" Style="padding: 0px" class="messagePanel"
                                    Visible="false">
                                    <div id="lblMesssge" runat="server" class="alert alert-success">
                                        <asp:Label ID="lblMessage" runat="server" Text="message"></asp:Label>
                                    </div>
                                </asp:Panel>
                                <br />
                                <div class="row-fluid">
                                    <div class="" style="padding-left: 10px;">
                                        <h3>Pre-defined Settings!</h3>
                                        <asp:GridView ID="dtg_list" runat="server" EmptyDataText="No Records Found!" AllowPaging="False"
                                            AllowSorting="True" AutoGenerateColumns="False" Width="99%" ShowFooter="True"
                                            CellPadding="1" OnPageIndexChanging="dtg_list_PageIndexChanging" OnRowDeleting="dtg_list_RowDeleting" OnRowCancelingEdit="dtg_list_RowCancelingEdit"
                                            OnRowEditing="dtg_list_RowEditing" OnRowUpdating="dtg_list_RowUpdating">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Topic Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTopicName" runat="server" Text='<%#Eval("TopicName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" Width="30%" />
                                                    <ItemStyle HorizontalAlign="Left" CssClass="Grid_Border" Width="30%" />
                                                    <FooterStyle CssClass="Grid_Footer" Width="30%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Query By">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGroupQueryValue1" runat="server" Text='<%#Eval("QueryValue1") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtQueryValue1" runat="server" Text='<%#Eval("QueryValue1") %>' Width="300px"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" Width="30%" />
                                                    <ItemStyle HorizontalAlign="Left" CssClass="Grid_Border" Width="30%" />
                                                    <FooterStyle CssClass="Grid_Footer" Width="30%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Query By">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGroupQueryValue2" runat="server" Text='<%#Eval("QueryValue2") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtQueryValue2" runat="server" Text='<%#Eval("QueryValue2") %>' Width="300px" ReadOnly="true"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" Width="30%" />
                                                    <ItemStyle HorizontalAlign="Left" CssClass="Grid_Border" Width="30%" />
                                                    <FooterStyle CssClass="Grid_Footer" Width="30%" />
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

