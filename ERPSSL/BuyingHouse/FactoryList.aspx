<%@ Page Title="" Language="C#" MasterPageFile="~/BuyingHouse/BuyingSite.Master" AutoEventWireup="true" CodeBehind="FactoryList.aspx.cs" Inherits="ERPSSL.BuyingHouse.FactoryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <div class="hm_sec_2_content scrollbar">
        <div class="panel">
            <div class="panel-heading panel-heading-01">
                <i class="fa fa-edit fa-fw icon-padding"></i>Supplier/Factory List 
            </div>
        </div>
        <div class="row" style="margin: auto 0;">
            <div class="col-md-12 bg-success">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </div>
            <div class="row" style="padding-left: 0px;">

                <div class="col-md-9" style="padding-left: 15px; padding-top: 8px; padding-bottom: 8px;">
                    <asp:TextBox ID="txtSearch" placeholder="Enter a Factory Name" Class="form-control" runat="server" autocomplete="off" onkeydown="if(window.event.keyCode == 13){document.getElementById('btnSearch').click();};"></asp:TextBox>


                    <cc1:AutoCompleteExtender ServiceMethod="SearchFactory"
                        MinimumPrefixLength="1"
                        CompletionInterval="100" EnableCaching="false" CompletionSetCount="10"
                        TargetControlID="txtSearch"
                        ID="AutoCompleteExtender1" runat="server" FirstRowSelected="false">
                    </cc1:AutoCompleteExtender>
                </div>
                <div class="col-md-3" style="padding-left: 0px; padding-top: 8px; padding-bottom: 8px;">
                    <asp:Button ID="btnSearch" runat="server" Width="90%" Font-Size="12px" Text="Search" CssClass="btn btn-default pull-left" OnClick="btnSearch_Click" />

                </div>
            </div>
        </div>
        <div class="col-md-12" style="padding-top: 8px;">
            <asp:GridView ID="grdFactory2" runat="server" AutoGenerateColumns="False" Width="100%"
                CellPadding="5" AllowPaging="True" PageSize="10">
                <Columns>
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center">
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
                            <asp:Label ID="lblFactoryId" runat="server" Text='<%# Eval("FactoryId")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="FactoryName" HeaderText="Supplier/Factory">
                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                        <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                        <FooterStyle CssClass="Grid_Footer" />
                    </asp:BoundField>
                    <asp:BoundField DataField="FactoryAddress" HeaderText="Address">
                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                        <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                        <FooterStyle CssClass="Grid_Footer" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ContactPerson1" HeaderText="Contact Person">
                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                        <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                        <FooterStyle CssClass="Grid_Footer" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CP1_Designation" HeaderText="Designation">
                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                        <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                        <FooterStyle CssClass="Grid_Footer" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CP1_Email" HeaderText="Email">
                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                        <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                        <FooterStyle CssClass="Grid_Footer" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CP1_ContactNumber" HeaderText="Contact Number">
                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                        <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                        <FooterStyle CssClass="Grid_Footer" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Comments">
                        <ItemTemplate>
                            <asp:TextBox ID="txtComment" runat="server" Placeholder="Enter Comments" CssClass="GridMargin" Height="30px"></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" Width="20%" />
                    </asp:TemplateField>

                    <%--   <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgButtonEidt" runat="server" ImageUrl="~/img/list_edit.png" OnClick="imgButtonEidt_Click" />
                            </ItemTemplate>
                            <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                        </asp:TemplateField>--%>
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

    <script type="text/javascript">
        function func(result) {
            if (result === 'Data Saved Successfully') {
                toastr.success(result);
            }
            else if (result === 'Data Updated Successfully') {
                toastr.success(result);
            }
            else
                toastr.error(result);
            return false;
        }
    </script>

</asp:Content>
