<%@ Page Title="" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true" CodeBehind="IncomeHead.aspx.cs" Inherits="ERPSSL.HRM.IncomeHead" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">


     
    <div class="hm_sec_2_content scrollbar">
        <div class="panel">
        <div class="panel-heading panel-heading-01">
            <i class="fa fa-edit fa-fw icon-padding"></i>Income Head
        </div>
    </div>
        <div class="row">
            <div class="col-md-12 bg-success">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </div>
            <div class="col-md-12">
                <br />
                <div class="col-md-5">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-5">
                                Income Head
                            </div>
                            <div class="col-md-7">
                                <asp:TextBox ID="txtbxIncomeHead" runat="server" class="form-control"></asp:TextBox>
                                <asp:HiddenField ID="hidIncomeHeadId" runat="server" />
                            </div>
                        </div>
                    </div>
                    <br />
                    
                    <br />
                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-5">
                            </div>
                            <div class="col-md-7">
                                <asp:Button ID="btnIncomeHead" runat="server" Text="Submit" class="btn btn-info pull-right" OnClick="btnIncomeHead_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-7">
                    <asp:GridView ID="grdIncomeHead" runat="server" AutoGenerateColumns="False"
                        Width="100%" CellPadding="5" AllowPaging="True">
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
                                    <asp:Label ID="lblIncomeHead" runat="server" Text='<%# Eval("IncomeHeaderID")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="IncomeHeader" HeaderText="Income Header">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                           
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgIncomeHeadEdit" runat="server" ImageUrl="img/list_edit.png"
                                        OnClick="imgIncomeHeadEdit_Click" />
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
    </div>
    <script>

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
