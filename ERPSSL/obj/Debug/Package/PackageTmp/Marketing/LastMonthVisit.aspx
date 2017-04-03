<%@ Page Title="" Language="C#" MasterPageFile="~/Marketing/Marketing.Master" AutoEventWireup="true" CodeBehind="LastMonthVisit.aspx.cs" Inherits="ERPSSL.Marketing.LastMonthVisit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <%--<asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>--%>
    <div class="row">
        <div class="hm_sec_2_content scrollbar">
            <div class="panel">
                <div class="panel-heading panel-heading-01">
                    <i class="glyphicon glyphicon-edit icon-padding"></i>Last Month Visit
                </div>
            </div>
            <div class="col-md-12 bg-success">
                <asp:HiddenField ID="hidLcNo" runat="server" />
                <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label>
                <asp:Label ID="lblMessageUpdate" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label>
            </div>

            <div class="col-md-12">
               
                    <fieldset>
                        <legend style="line-height: 0px; padding-top: 5px;"><span style="background: #fff">Last Month Visit List</span></legend>
                        <div class="col-md-12" style="overflow-x: hidden; overflow-y: scroll; max-height: 400px; height: auto">
                            <asp:GridView ID="grdorder" runat="server" AutoGenerateColumns="False" Width="100%"
                                CellPadding="20" BackColor="White" BorderColor="#336666" BorderStyle="Solid"
                                BorderWidth="1px">
                                <Columns>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="7%" HeaderStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    Sl No.
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSRNO" runat="server"
                                                        Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" Width="7%" />
                                            </asp:TemplateField>
                                    <%--<asp:BoundField DataField="OrderEntryID" HeaderText="Id" Visible="false"></asp:BoundField>--%>
                                    <%--<asp:TemplateField Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOrderEntryID" runat="server" Text='<%# Eval("OrderEntryID")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                      <asp:TemplateField Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMarketingId_No" runat="server" Text='<%# Eval("MarketingInfoId")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Client" HeaderText="Client Name">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ContactPerson" HeaderText="Contact Person">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="VisitDate" HeaderText="Visit Date">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    
                                    <asp:BoundField DataField="ProjectName" HeaderText="Project Name">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Module" HeaderText="Module" HtmlEncode="false">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="View">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgbtnOrderSheetEdit" runat="server" ImageUrl="~/Marketing/img/Documents-icon.png" OnClick="imgbtnOrderSheetEdit_Click" />
                                        </ItemTemplate>
                                        <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                                    </asp:TemplateField>

                                </Columns>
                                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                                <EmptyDataRowStyle ForeColor="Red" />
                                <RowStyle CssClass="Grid_RowStyle" BackColor="White" ForeColor="#333333" />
                                <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                <PagerSettings Mode="NumericFirstLast" />
                                <PagerStyle ForeColor="White" HorizontalAlign="Left" BackColor="#336666" CssClass="pagination01 pageback" />
                                <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" BackColor="#336666"
                                    Font-Bold="True" ForeColor="White" />
                                <FooterStyle CssClass="Grid_Footer" BackColor="White" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                <SortedAscendingHeaderStyle BackColor="#487575" />
                                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                <SortedDescendingHeaderStyle BackColor="#275353" />
                            </asp:GridView>
                        </div>
                    </fieldset>
               

              



            </div>
        </div>
    </div>

    <script type="text/javascript">
        function func(result) {
            if (result === 'Data Saved Successfully') {
                toastr.success(result);

            }
            else if (result === 'Data Post Successfully !') {
                toastr.success(result);
            }
            else if (result === 'Data Already Exist') {
                toastr.error(result);
            }

            else if (result === 'Data Updated Sucessfully') {
                toastr.success(result);
            }
            else if (result === 'Data Updating failure') {
                toastr.error(result);
            }
            else
                toastr.error(result);

            return false;
        }

    </script>

</asp:Content>
