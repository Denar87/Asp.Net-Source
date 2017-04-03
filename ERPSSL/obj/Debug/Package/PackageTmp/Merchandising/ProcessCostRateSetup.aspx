<%@ Page Title="" Language="C#" MasterPageFile="~/Merchandising/Merchandising.Master" AutoEventWireup="true"
    CodeBehind="ProcessCostRateSetup.aspx.cs" Inherits="ERPSSL.Merchandising.ProcessCostRateSetup" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
          
 <ContentTemplate>


      <div class="row">
                <div class="hm_sec_2_content scrollbar">
                    <div class="panel">
                        <div class="panel-heading panel-heading-01">
                            <i class="glyphicon glyphicon-edit icon-padding"></i>Cost Component Info
                        </div>
                    </div>
                    <div class="col-md-12">

                        <div class="row" style =" padding-top: 10px;">

                            <div class="col-md-12" style="background-color: #f0f5f6; padding-bottom: 10px;" >
                                <div class="col-md-3" style="padding-left: 0;">
                                    <div class="row">
                                        Cost Component
                                         <asp:DropDownList ID="drpCostComponent"  class="form-control"  runat="server">  </asp:DropDownList>
                                    </div>
                                    
                                </div>
                                 <div class="col-md-3">

                                   <div class="row">
                                        Rate
                                           <asp:TextBox ID="txtRate" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">

                                    <div class="row">
                                        Status
                                          <asp:DropDownList ID="drpStatus"  class="form-control"  runat="server">  </asp:DropDownList>
                                    </div>
                               </div>
                               

                                <div class="col-md-3">
                                   <div class="row" style ="padding-top:12px;padding-right:150px;">
                                        <asp:Button ID="btnCostCompSubmit" runat="server" ValidationGroup="Group1" Text="Submit" CssClass="btn btn-info pull-right" />
                                    </div>
                                </div>

                            </div>


                        </div>
                         <div class="row" id="ShowGrid" runat="server" style="padding-top: 5px;">
                           
                            <div class="col-md-12" style="padding-left: 0; margin: auto 0;">
                                <div class="row" style="padding-left: 0; padding-top: 5px; margin: auto 0;">
                                    <fieldset style="margin: auto 0;">
                                        <legend style="line-height: 0px; padding-top: 5px;"><span style="background: #fff">Cost Component List</span></legend>
                                        <div class="row" style="overflow-x: hidden; overflow-y: scroll; max-height: 400px; height: auto; margin: auto 0;">
                                           <asp:GridView ID="grdorder" runat="server" AutoGenerateColumns="False" Width="100%"
                                                CellPadding="20" BackColor="White" BorderColor="#336666" BorderStyle="Solid"
                                                BorderWidth="1px" AllowPaging="false">
                                                <Columns>
                                                     <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center">
                                                            <HeaderTemplate>
                                                                SL No.
                                                            </HeaderTemplate>
                                                            <ItemTemplate  >
                                                                <asp:Label ID="lblSRNO" runat="server"
                                                                    Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                            </ItemTemplate>
                                                     </asp:TemplateField>

                                                        <asp:TemplateField Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCostComponenttId" runat="server" Text='<%# Eval("CostComponentID")%>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField=" CostComponent" HeaderText=" Cost Component">
                                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                            <FooterStyle CssClass="Grid_Footer" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Rate" HeaderText="Rate">
                                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                            <FooterStyle CssClass="Grid_Footer" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Status" HeaderText="Status">
                                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                            <FooterStyle CssClass="Grid_Footer" />
                                                        </asp:BoundField>
                                                       
                                                    <asp:TemplateField HeaderText="View">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="imgbtnCostComponentEdit" runat="server" ImageUrl="img/list_edit.png" />
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
                                                <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" BackColor="#336666" Font-Bold="True" ForeColor="White" />
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
                    </div>
                </div>
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

