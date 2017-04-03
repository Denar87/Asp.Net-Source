<%@ Page Title="" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true" CodeBehind="JobAllocationList.aspx.cs" Inherits="ERPSSL.HRM.JobAllocationList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ToolkitScriptManager1" />
    
<asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
          
<ContentTemplate>
   
    <div class="hm_sec_2_content scrollbar">
         <div class="panel">
        <div class="panel-heading panel-heading-01">
            <i class="fa fa-edit fa-fw icon-padding"></i>Job Allocation List
        </div>
    </div>
    <div class="row">
        <div class="col-md-12 bg-success">
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </div>
        <div class="col-md-12">
            <br />
            <div class="col-md-4">
                <div class="col-md-12">
                    <div class="col-md-3">
                        From 
                    </div>
                    <div class="col-md-9">
                        <asp:TextBox runat="server" ID="txtbxFrom" Class="form-control" placeholder="MM/dd/yyyy" />
                        <ajaxToolkit:calendarextender ID="CalendarExtender" runat="server" TargetControlID="txtbxFrom"
                            PopupButtonID="txtbxFrom" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />

                    </div>
                </div>

            </div>
            <div class="col-md-4">
                <div class="col-md-12">
                    <div class="col-md-3">
                        To 
                    </div>
                    <div class="col-md-9">
                        <asp:TextBox runat="server" ID="txtbxTo" Class="form-control" placeholder="MM/dd/yyyy" />
                        <ajaxToolkit:calendarextender ID="CalendarExtender3" runat="server" TargetControlID="txtbxTo"
                            PopupButtonID="txtbxTo" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />

                    </div>
                </div>


            </div>
            <div class="col-md-4">
                  <asp:Button ID="btnSearch" runat="server" Text="Serach" CssClass=" btn btn-info pull-right" OnClick="btnSearch_Click" />
            </div>
            <br />
            <br />
            <br />
        </div>

        <div class="col-md-12">
            <asp:GridView ID="gridviewJobAllocationList" runat="server" AutoGenerateColumns="False"
                Width="100%" CellPadding="5" AllowPaging="True" OnPageIndexChanging="gridviewJobAllocationList_PageIndexChanging">
                <Columns>
                    <asp:TemplateField Visible="False">
                        <ItemTemplate>
                            <asp:Label ID="lblAllocationJobCode" runat="server" Text='<%# Eval("JobAllocationCode")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="JobAllocationCode" HeaderText="Job Allocation Code">
                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                        <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                        <FooterStyle CssClass="Grid_Footer" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ClientName" HeaderText="Client Name">
                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                        <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                        <FooterStyle CssClass="Grid_Footer" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Reasion" HeaderText="Reason">
                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                        <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                        <FooterStyle CssClass="Grid_Footer" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Remark" HeaderText="Remark">
                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                        <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                        <FooterStyle CssClass="Grid_Footer" />
                    </asp:BoundField>

                    <asp:BoundField DataField="RequestFrom" HeaderText="Request From">
                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                        <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                        <FooterStyle CssClass="Grid_Footer" />
                    </asp:BoundField>

                    <asp:BoundField DataField="JobAllocationDate" HeaderText="Assign Date">
                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                        <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                        <FooterStyle CssClass="Grid_Footer" />
                    </asp:BoundField>

                    <asp:TemplateField HeaderText="Reprot">
                        <ItemTemplate>
                            <asp:Button ID="btnReport" runat="server" Text="Report" CssClass="btn btn-info pull-right" OnClick="btnReport_Click" />

                        </ItemTemplate>
                        <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            <asp:Button ID="btnStatus" runat="server" Text="Status" CssClass="btn btn-info pull-right" OnClick="btnStatus_Click" />

                        </ItemTemplate>
                        <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-info pull-right" OnClick="btnDelete_Click" />

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

<Triggers>
 <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />

</Triggers>
</asp:UpdatePanel>
</asp:Content>
