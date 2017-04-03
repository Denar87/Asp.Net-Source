<%@ Page Title="" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true"
    CodeBehind="regions.aspx.cs" Inherits="ERPSSL.HRM.regions" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
          
<ContentTemplate>

    
    <div class="hm_sec_2_content scrollbar">
   <div class="panel">
        <div class="panel-heading panel-heading-01">
            <i class="fa fa-edit fa-fw icon-padding"></i>Region Setup
        </div>
    </div>
        <div class="col-md-12 bg-success">
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </div>
        <div class="col-md-12">
            <br />
            <div class="col-md-5">
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-5">
                            Region
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtbxRegionName" runat="server" class="form-control"></asp:TextBox>
                            <asp:HiddenField ID="hidRegionId" runat="server" />
                            <asp:HiddenField ID="hidRegionName" runat="server" />
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-5">
                            Region Code
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtbxResgionCode" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-5">
                        </div>
                        <div class="col-md-7">
                            <asp:Button ID="btnRegionSubmit" runat="server" Text="Submit" class="btn btn-info  pull-right"
                                OnClick="btnRegionSubmit_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-7">
                <asp:GridView ID="gridviewRegions" runat="server" AutoGenerateColumns="False" Width="100%"
                    CellPadding="5" AllowPaging="True"  PageSize="10" OnPageIndexChanging="gridViewOffice_PageIndexChanging">
                    <Columns>

                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            Sl No.
                                        </HeaderTemplate>
                                        <ItemTemplate  >
                                            <asp:Label ID="lblSRNO" runat="server"
                                                Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                        <asp:TemplateField Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblRegionId" runat="server" Text='<%# Eval("RegionID")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="RegionName" HeaderText="Region">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:BoundField DataField="RegionCode" HeaderText="Region Code">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Update">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgbtnRegionEdit" runat="server" ImageUrl="img/list_edit.png"
                                    OnClick="imgbtnRegionEdit_Click" />
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
        <br />
        <br />
        </div>
    
</ContentTemplate>

<Triggers>
 <asp:AsyncPostBackTrigger ControlID="btnRegionSubmit" EventName="Click" />
</Triggers>
</asp:UpdatePanel>
    <script>
        
        function func(result) {
            if (result === 'Data Save successfully!') {
                toastr.success(result);

            }
            else if (result === 'Data Update successfully!') {
                toastr.success(result);
            }
            else
                toastr.error(result);
                
            return false;
        }

   </script>
</asp:Content>
