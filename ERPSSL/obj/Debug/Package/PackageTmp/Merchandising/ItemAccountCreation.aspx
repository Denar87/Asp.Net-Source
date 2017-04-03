<%@ Page Title="" Language="C#" MasterPageFile="~/Merchandising/Merchandising.Master" AutoEventWireup="true"
    CodeBehind="ItemAccountCreation.aspx.cs" Inherits="ERPSSL.Merchandising.ItemAccountCreation" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    

    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="hm_sec_2_content scrollbar">
                    <div class="panel">
                        <div class="panel-heading panel-heading-01">
                            <i class="glyphicon glyphicon-edit icon-padding"></i>Item Account Creation Info
                        </div>
                    </div>
                    <div class="col-md-12">

                        <div class="row" style="padding-top: 10px;">

                            <div class="col-md-12" style="background-color: #f0f5f6; padding-bottom: 10px;">
                                <div class="col-md-3" style="padding-left: 0;">
                                    <div class="row">
                                        Company
                                        <asp:DropDownList ID="drpCompany" CssClass="form-control2 form-control" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="row">
                                        Sub Group Code 
                                        <asp:TextBox ID="txtSubGroupCode" runat="server" class="form-control2 form-control"></asp:TextBox>

                                    </div>
                                    <div class="row">
                                        Items Description 
                                          <asp:TextBox ID="txtItemDescription" runat="server" class="form-control2 form-control"></asp:TextBox>
                                    </div>
                                    <div class="row">
                                        Min Label
                                          <asp:TextBox ID="txtMinLabel" runat="server" class="form-control2 form-control"></asp:TextBox>
                                    </div>

                                </div>
                                <div class="col-md-3">
                                    <div class="row">
                                        Cons UOM
                                          <asp:DropDownList ID="drpConsUOM" CssClass="form-control2 form-control" runat="server">
                                          </asp:DropDownList>
                                    </div>
                                    <div class="row">
                                        Item Category
                                             <asp:DropDownList ID="drpItemCategory" CssClass="form-control2 form-control" runat="server">
                                             </asp:DropDownList>
                                    </div>
                                    <div class="row">
                                        Sub Group Name
                                            <asp:TextBox ID="txtSubGroupName" runat="server" class="form-control2 form-control"></asp:TextBox>
                                    </div>

                                    <div class="row">
                                        Item size
                                       <asp:TextBox ID="txtItemSize" runat="server" class="form-control2 form-control"></asp:TextBox>
                                    </div>

                                </div>
                                <div class="col-md-3">
                                    <div class="row">
                                        Max Label
                                          <asp:TextBox ID="txtMaxLabel" runat="server" class="form-control2 form-control"></asp:TextBox>
                                    </div>
                                    <div class="row">
                                        Item Account
                                        <asp:TextBox ID="txtItemAccount" Class=" form-control2 form-control " runat="server"></asp:TextBox>
                                    </div>

                                    <div class="row">
                                        Item Group
                                      <asp:TextBox ID="txtItemGroup" Class=" form-control2 form-control " runat="server"></asp:TextBox>
                                    </div>
                                    <div class="row">
                                        Item Code
                                       <asp:TextBox ID="txtItemCode" Class=" form-control2 form-control " runat="server"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-3">

                                    <div class="row">
                                        Re Order Label
                                        <asp:TextBox ID="txtReOrderLabel" Class=" form-control2 form-control " runat="server"></asp:TextBox>
                                    </div>
                                    <div class="row">
                                        Order UOM
                                        <asp:DropDownList ID="drpOrderUOM" CssClass="form-control2 form-control" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="row">
                                        Status
                                            <asp:DropDownList ID="drpStatus" CssClass="form-control2 form-control" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="row" style="padding-top: 12px;padding-right:60px;">
                                        <asp:Button ID="btnItemAccountSubmit" runat="server" ValidationGroup="Group1" Text="Submit" CssClass="btn btn-info pull-right" />
                                    </div>
                                </div>

                            </div>


                        </div>
                        <div class="row" id="ShowGrid" runat="server" style="padding-top: 5px;">

                            <div class="col-md-12" style="padding-left: 0; margin: auto 0;">
                                <div class="row" style="padding-left: 0; padding-top: 5px; margin: auto 0;">
                                    <fieldset style="margin: auto 0;">
                                        <legend style="line-height: 0px; padding-top: 5px;"><span style="background: #fff">Item Account Creation List</span></legend>
                                        <div class="row" style="overflow-x: hidden; overflow-y: scroll; max-height: 400px; height: auto; margin: auto 0;">
                                            <asp:GridView ID="gridviewItemAccount" runat="server" AutoGenerateColumns="False" Width="100%"
                                                CellPadding="5" AllowPaging="True">
                                                <Columns>

                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center">
                                                        <HeaderTemplate>
                                                            SL No.
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSRNO" runat="server"
                                                                Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <%--<asp:TemplateField Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCompanyId" runat="server" Text='<%# Eval("CompanyId")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                    <asp:BoundField DataField="ItemAccount" HeaderText="Item Account">
                                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                        <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                        <FooterStyle CssClass="Grid_Footer" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="ItemCategory" HeaderText="Item Category">
                                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                        <ItemStyle HorizontalAlign="Left" Width="20%" CssClass="Grid_Border" />
                                                        <FooterStyle CssClass="Grid_Footer" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="GroupName" HeaderText="Group Name">
                                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                        <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                                        <FooterStyle CssClass="Grid_Footer" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="SubGroupName" HeaderText="Sub Group Name">
                                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                        <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                                        <FooterStyle CssClass="Grid_Footer" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="ItemDescription" HeaderText="Item Description">
                                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                        <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                        <FooterStyle CssClass="Grid_Footer" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="ItemSize" HeaderText="Item Size">
                                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                        <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                                        <FooterStyle CssClass="Grid_Footer" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="ConsUOM" HeaderText="Cons UOM">
                                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                        <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                                        <FooterStyle CssClass="Grid_Footer" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="CompanyName" HeaderText="Company">
                                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                        <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                                        <FooterStyle CssClass="Grid_Footer" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Status" HeaderText="Status">
                                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                        <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                                        <FooterStyle CssClass="Grid_Footer" />
                                                    </asp:BoundField>

                                                    <asp:TemplateField HeaderText="Update">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="imgbtnItemAccEdit" runat="server" ImageUrl="img/list_edit.png" />
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
