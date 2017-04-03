<%@ Page Title="" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true" CodeBehind="MaternityLeaveList.aspx.cs" Inherits="ERPSSL.HRM.MaternityLeaveList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
          
<ContentTemplate>

    
    <div class="hm_sec_2_content scrollbar">
        <div class="panel">
        <div class="panel-heading panel-heading-01">
            <i class="fa fa-edit fa-fw icon-padding"></i>Leave Apply List For HRM
        </div>
    </div>
        <div class="col-md-12">
            <div class="col-md-12">
                <br />
                <asp:GridView ID="gridviewLeaveInfo" runat="server" AutoGenerateColumns="False" Width="100%"
                    CellPadding="5" AllowPaging="True">
                    <Columns>
                        <asp:TemplateField Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblMaternityLeaveId" runat="server" Text='<%# Eval("MaternityLeaveId")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblEid" runat="server" Text='<%# Eval("EID")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:BoundField DataField="AppliedDate" HeaderText="Applied">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:BoundField DataField="LeaveDateFrom" HeaderText="Leave Date From">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:BoundField DataField="LeaveDateTo" HeaderText="Leave Date To">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TotalDay" HeaderText="Total Day">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>

                        <asp:BoundField DataField="ReportingBossName" HeaderText="Reporting Boss Name">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>


                        <asp:TemplateField HeaderText="View">
                            <ItemTemplate>
                                <asp:Button ID="btnView" runat="server" Text="View" CssClass="btn btn-info  pull-right" OnClick="btnView_Click" />
                            </ItemTemplate>
                            <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
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
</asp:UpdatePanel>
</asp:Content>
