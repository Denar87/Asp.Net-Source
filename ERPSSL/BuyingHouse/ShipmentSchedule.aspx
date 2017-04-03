<%@ Page Title="" Language="C#" MasterPageFile="~/BuyingHouse/BuyingSite.Master" AutoEventWireup="true" CodeBehind="ShipmentSchedule.aspx.cs" Inherits="ERPSSL.BuyingHouse.ShipmentSchedule" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <div class="hm_sec_2_content scrollbar">
        <div class="panel">
            <div class="panel-heading panel-heading-01">
                <i class="fa fa-edit fa-fw icon-padding"></i>Shipment Schedule Setup 
            </div>
        </div>
        <div class="col-md-12 bg-success">
            <asp:HiddenField ID="hidLcNo" runat="server" />
            <asp:Label ID="Label1" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label>
            <asp:Label ID="lblMessageUpdate" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label>
        </div>
            <div class="col-md-12">
                <div class="row" style="margin-top: 5px">
                    <div class="col-md-5">
                        <div class="col-md-2">Order</div>
                        <div class="col-md-10">
                            <asp:TextBox ID="txtOrder" Class=" form-control2 form-control " runat="server" AutoPostBack="true" OnTextChanged="txtOrder_TextChanged"></asp:TextBox>
                            <cc1:AutoCompleteExtender ServiceMethod="SearchLCNo"
                                MinimumPrefixLength="1"
                                CompletionInterval="100" EnableCaching="False"
                                TargetControlID="txtOrder"
                                ID="AutoCompleteExtender2" runat="server" DelimiterCharacters="" Enabled="True" ServicePath="">
                            </cc1:AutoCompleteExtender>
                            <asp:Label ID="lblSeason" runat="server" Text="Label" Visible="false"></asp:Label>
                        </div>
                    </div>
                    <div class="col-md-5">
                        <div class="col-md-2">Buyer Name</div>
                        <div class="col-md-10">
                            <asp:TextBox ID="txtBuyer" runat="server" class="form-control" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="col-md-12" style="padding-top: 5px; margin: 0 auto;">
                    <div class="row">
                        <asp:GridView ID="grdShipment" runat="server" AutoGenerateColumns="False" Width="100%"
                            CellPadding="5" AllowPaging="True" PageSize="10">
                            <%--OnPageIndexChanging="gridviewSection_PageIndexChanging"--%>
                            <Columns>
                                <asp:TemplateField Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblOrderNo" runat="server" Text='<%# Eval("OrderNo")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox runat="server" ID="headerLevelCheckBox" AutoPostBack="true" OnCheckedChanged="headerLevelCheckBox_CheckedChanged" />
                                        <itemstyle horizontalalign="Left" width="1%" cssclass="Grid_Border" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="rowLevelCheckBox" runat="server" />
                                        <headerstyle verticalalign="Middle" cssclass="Grid_Header" />
                                        <itemstyle horizontalalign="Left" width="1%" cssclass="Grid_Border" />
                                        <footerstyle cssclass="Grid_Footer" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="1%" CssClass="Grid_Border" />
                                </asp:TemplateField>

                                <asp:BoundField DataField="OrderNo" HeaderText="Article No">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>

                                <asp:BoundField DataField="Style" HeaderText="Style">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>

                                <asp:BoundField DataField="ColorSpecification" HeaderText="Color Specification">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>

                                <asp:BoundField DataField="OrderQuantity" HeaderText="Qty.">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Left" Width="7%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>


                                <asp:BoundField DataField="FobQty" HeaderText="FOB ($)">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Left" Width="7%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ShipmentDate" HtmlEncode="false" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Shipment Date">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Left" Width="7%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>
                                <%--    <asp:BoundField DataField="ExtendShipmentDate" HeaderText="Extended Shipment Date">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>--%>
                                <asp:BoundField DataField="Shipment_Mode" HeaderText="Shipment Mode">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Extended Shipment Date">
                                    <ItemTemplate>
                                        <%--<asp:Label ID="lblExtDate" runat="server" Text='<%# Bind("ExtendShipmentDate") %>' Visible="false"></asp:Label>--%>
                                        <asp:TextBox ID="txtExtDate" runat="server" placeholder="MM/dd/yyyy" class="form-control"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtExtDate"
                                            PopupButtonID="Image_AT" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                    </ItemTemplate>
                                    <ItemStyle Width="20%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                                </asp:TemplateField>
                                <%--<asp:BoundField DataField="ShipmentMode" HeaderText="Shipment Mode">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>--%>


                                <asp:TemplateField HeaderText="Shipment Complete Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCompDate" runat="server" Text='<%# Bind("CompShipmentDate") %>' Visible="false"></asp:Label>
                                        <asp:TextBox ID="txtCompDate" runat="server" placeholder="MM/dd/yyyy" class="form-control"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtCompDate"
                                            PopupButtonID="Image_AT" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                    </ItemTemplate>
                                    <ItemStyle Width="20%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                                </asp:TemplateField>

                                <%--  <asp:TemplateField HeaderText="Edit">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgButtonEidt" runat="server" ImageUrl="img/list_edit.png" OnClick="imgButtonEidt_Click"/>
                        <asp:ImageButton ID="imgBtnSave" runat="server" ImageUrl="img/list_edit.png" />
                    </ItemTemplate>
                    <ItemStyle Width="15%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
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
                    <div class="row" style="padding-top: 5px;">
                        <%--  <div class="col-md-2"></div>--%>
                        <div class="col-md-12">
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-primary pull-right" Visible="false" OnClick="btnSubmit_Click" />
                        </div>
                    </div>
                </div>
            </div>
   
    </div>
    <script type="text/JavaScript">
        function func(result) {
            if (result === 'Data Added Successfully') {
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
