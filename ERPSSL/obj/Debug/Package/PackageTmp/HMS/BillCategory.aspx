<%@ Page Title="" Language="C#" MasterPageFile="~/HMS/HMS.Master" AutoEventWireup="true"
    CodeBehind="BillCategory.aspx.cs" Inherits="ERPSSL.HMS.BillCategory" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
          
 <ContentTemplate>

       <div class="hm_sec_2_content scrollbar">
                <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="fa fa-edit fa-fw icon-padding"></i>Bill Category Setup
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
                                     Category Name
                                </div>
                                <div class="col-md-7">
                                    <asp:TextBox ID="txtCategory" runat="server" class="form-control"></asp:TextBox>
                                    <asp:HiddenField ID="hidCategoryId" runat="server" />
                                    <asp:HiddenField ID="hidCategoryName" runat="server" />
                                </div>
                            </div>
                        </div>
              
                        <br />

                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-5">
                                </div>
                                <div class="col-md-7">
                                    <asp:Button ID="btnBillCateGorySubmit" runat="server" ValidationGroup="Group1" Text="Submit" CssClass="btn btn-info pull-right" OnClick="btnBillCateGorySubmit_Click"/>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-7">
                        <asp:GridView ID="gridviewBillCateGory" runat="server" AutoGenerateColumns="False" Width="100%"
                            CellPadding="20" BackColor="White" BorderColor="#336666" BorderStyle="Solid"
                            BorderWidth="1px" AllowPaging ="True" OnPageIndexChanging="gridviewBillCateGory_PageIndexChanging" >
                            <Columns>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        SL No.
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblSRNO" runat="server"
                                            Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Category Id" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCategoryId" runat="server" Text='<%# Bind("HMS_CategoryId") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField DataField="CategoryName" HeaderText="Category Name">
                                    <HeaderStyle VerticalAlign="Middle"  />
                                    <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>
                               
                                <asp:TemplateField HeaderText="View">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgbtnBillCategoryEdit" runat="server" ImageUrl="img/list_edit.png" OnClick="imgbtnBillCategoryEdit_Click" />
                                    </ItemTemplate>
                                    <ItemStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                                </asp:TemplateField>

                            </Columns>
                            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                            <EmptyDataRowStyle ForeColor="Red" />
                            <RowStyle CssClass="Grid_RowStyle" BackColor="White" ForeColor="#333333" />
                            <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                            <PagerSettings Mode="NumericFirstLast" />
                            <PagerStyle ForeColor="White" HorizontalAlign="Left" BackColor="#336666" CssClass="pagination01 pageback" />
                            <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" BackColor="#336666" Font-Bold="True" ForeColor="White" />
                            <FooterStyle CssClass="Grid_Footer" BackColor="White" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                            <SortedAscendingHeaderStyle BackColor="#487575" />
                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                            <SortedDescendingHeaderStyle BackColor="#275353" />
                        </asp:GridView>
                    </div>
                </div>
                <br />
             <br />
        </div>

 </ContentTemplate>

 </asp:UpdatePanel>

    <script type="text/javascript">

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

