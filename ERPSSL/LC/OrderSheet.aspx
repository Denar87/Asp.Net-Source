<%@ Page Title="" Language="C#" MasterPageFile="~/LC/Site.Master" AutoEventWireup="true" CodeBehind="OrderSheet.aspx.cs" Inherits="ERPSSL.LC.OrderSheet" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="hm_sec_2_content scrollbar">
                    <div class="panel">
                        <div class="panel-heading panel-heading-01">
                            <i class="glyphicon glyphicon-edit icon-padding"></i>Order Entry 
                            <span style="color: brown" id="ShowInfo" runat="server" visible="false">(
                                <b>Bayer Name : 
                                    <asp:Label ID="lblBayername" ForeColor="#cc6699" runat="server"></asp:Label>
                                </b>
                                //
                                <b>LC No : 
                                    <asp:Label ID="lblLCNo" ForeColor="#cc6699" runat="server"></asp:Label>
                                </b>
                                //
                                <b>LC Qty : 
                                    <asp:Label ID="lblLCQty" ForeColor="#cc6699" runat="server"></asp:Label>
                                </b>
                                //
                                <b>USD : $
                                    <asp:Label ID="lblUSDValue" ForeColor="#cc6699" runat="server"></asp:Label>
                                </b>
                                //
                                <b>BDT : 
                                    <asp:Label ID="lblBDTValue" ForeColor="#cc6699" runat="server"></asp:Label>
                                    Tk.
                                </b>
                                )
                            </span>
                        </div>
                    </div>
                    <div class="col-md-12 bg-success">
                        <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label>
                        <asp:Label ID="lblMessageUpdate" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label>
                    </div>
                    <div class="col-md-12" style="margin: auto 0; padding-right: 0;">
                        <div class="col-md-5" style="background-color: #a7c5a7; padding-bottom: 10px; padding-left: 0; margin: auto 0;">
                            <div class="row" style="margin: auto 0; padding-left: 0;">
                                <div class="col-md-6" style="margin: auto 0;">

                                    <div class="row">
                                        <asp:HiddenField ID="hidorderid" runat="server" />
                                        Order Received Date
                                    <asp:TextBox ID="txtOrderReceivedDate" Class=" form-control2 form-control " runat="server" placeholder="MM/dd/yyyy"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtOrderReceivedDate"
                                            PopupButtonID="txtOrderReceivedDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                    </div>
                                    <div class="row">
                                        Buyer Department
                                    <asp:TextBox ID="txtBuyerDepartment" Class=" form-control2 form-control " runat="server"></asp:TextBox>
                                    </div>

                                    <div class="row">
                                        Supplier No
                                    <asp:TextBox ID="txtSupplierNo" Class=" form-control2 form-control " runat="server"></asp:TextBox>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12" style="padding: 0px;">
                                            <div class="col-md-2" style="padding: 0px;">
                                                Season 
                                                <asp:HiddenField ID="hidSeasonID" runat="server" />
                                            </div>
                                            <div class="col-md-1">
                                                <asp:CheckBox ID="chkSeason" runat="server" Visible="true" AutoPostBack="True" OnCheckedChanged="chkSeason_CheckedChanged"></asp:CheckBox>
                                            </div>
                                            <div class="col-md-9"></div>
                                        </div>
                                        <div class="col-md-12" style="padding: 0px;">
                                            <asp:DropDownList ID="ddlSeason" AutoPostBack="true" OnSelectedIndexChanged="ddlSeason_SelectedIndexChanged" CssClass="form-control" runat="server">
                                            </asp:DropDownList>
                                            <asp:TextBox ID="txtSeason" runat="server" class="form-control" Visible="false"></asp:TextBox>
                                        </div>

                                    </div>
                                    <div class="row">
                                        Order No.
                                    <asp:TextBox ID="txtOrder" Class=" form-control2 form-control " runat="server"></asp:TextBox>
                                    </div>
                                    <div class="row">
                                        Article
                                    <asp:TextBox ID="txtArticle" Class=" form-control2 form-control " runat="server"></asp:TextBox>
                                    </div>

                                    <div class="row">
                                        Color
                                        <asp:TextBox ID="txtColor" Class=" form-control2 form-control " runat="server"></asp:TextBox>
                                    </div>
                                    <div class="row">
                                        Specification
                                        <asp:TextBox ID="txtSpecification" Class=" form-control2 form-control " runat="server"></asp:TextBox>
                                    </div>
                                    <div class="row">
                                        Fiber Content 1
                                        <asp:TextBox ID="txtFiberContent1" Class=" form-control2 form-control " runat="server"></asp:TextBox>
                                    </div>
                                    
                                </div>
                                <div class="col-md-6">
                                    <div class="row">
                                        <div class="col-md-12" style="padding: 0px;">
                                            <div class="col-md-2" style="padding: 0;">
                                                Style
                                            </div>
                                            <div class="col-md-1" style="padding: 0; float: left;">
                                                <asp:CheckBox ID="chkNewstyle" runat="server" Visible="true" AutoPostBack="True" OnCheckedChanged="chkNewstyle_CheckedChanged"></asp:CheckBox>
                                            </div>
                                            <div class="col-md-9" style="padding: 0;">
                                            </div>
                                        </div>
                                        <div class="col-md-12" style="padding: 0;">
                                            <asp:DropDownList ID="ddlStyle" AppendDataBoundItems="True" CssClass="form-control2 form-control" runat="server">
                                            </asp:DropDownList>
                                            <asp:TextBox ID="txtStyle" runat="server" class="form-control" Visible="false"></asp:TextBox>
                                        </div>

                                    </div>
                                    <div class="row">
                                        Size
                                    <asp:TextBox ID="txtsize" Class=" form-control2 form-control " runat="server"></asp:TextBox>
                                    </div>
                                    <div class="row">
                                        Order Qty
                                   <asp:TextBox ID="txtOrderQty" Class=" form-control2 form-control " runat="server" Text="0"></asp:TextBox>
                                    </div>
                                    <div class="row">
                                        FOB($) 
                                   <asp:TextBox ID="txtFob" Class="form-control2 form-control" runat="server" AutoPostBack="True" OnTextChanged="txtFob_TextChanged" Text="0"></asp:TextBox>
                                    </div>

                                    <div class="row">
                                        Value
                                   <asp:TextBox ID="txtValue" Class="form-control2 form-control " Enabled="false" runat="server"></asp:TextBox>
                                    </div>

                                    <div class="row">
                                        Shipment Date
                                   <asp:TextBox ID="txtDate" Class="form-control2 form-control " placeholder="MM/dd/yyyy" runat="server"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate"
                                            PopupButtonID="txtDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                    </div>
                                    <div class="row">
                                        Shipment Mode
                                        <asp:DropDownList ID="ddlShipmentMode" CssClass="form-control2 form-control" runat="server">
                                            <asp:ListItem Value="0">---Select---</asp:ListItem>
                                            <asp:ListItem Value="By Air">By Air</asp:ListItem>
                                            <asp:ListItem Value="By Sea">By Sea</asp:ListItem>
                                            <asp:ListItem Value="By Land">By Land</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="row">
                                        Fiber Content 2
                                        <asp:TextBox ID="txtFiberContent2" Class=" form-control2 form-control " runat="server"></asp:TextBox>
                                    </div>
                                    <div class="row" style="margin-top: 5px;">
                                        <asp:Button ID="btnSubmit" runat="server" Text="Add" class="btn btn-info pull-right" ValidationGroup="Group1" OnClick="btnSubmit_Click" />
                                    </div>

                                </div>
                            </div>
                        </div>

                        <div class="col-md-7" style="padding: 0;">
                            <%--<div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-6">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="col-md-6">
                                                    <b>Buyer Name: </b>
                                                </div>
                                                <div class="col-md-6">
                                                    <span style="color: brown"><b>
                                                        <asp:Label ID="lblBayername" runat="server"></asp:Label></b></span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-6">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="col-md-4">
                                                    <b>LC No:</b>
                                                </div>
                                                <div class="col-md-8">
                                                    <<span style="color: brown"><b>
                                                        <asp:Label ID="lblLCNo" runat="server"></asp:Label></b></span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>--%>
                            <fieldset>
                                <legend style="line-height: 0px; padding-top: 5px;"><span style="background: #fff">Order Sheet</span></legend>
                                <div class="col-md-12" style="overflow-x: hidden; overflow-y: scroll; max-height: 400px; padding: 0; height: auto">
                                    <asp:GridView ID="grdorder" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="20" BackColor="White"
                                        BorderColor="#336666" BorderStyle="Solid" OnRowDataBound="grdorder_RowDataBound"
                                        BorderWidth="1px" AllowPaging="false">
                                        <Columns>
                                            <asp:BoundField DataField="OrderEntryID" HeaderText="Id" Visible="false">
                                                <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOrderEntryID" runat="server" Text='<%# Eval("OrderEntryID")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="OrderNo" HeaderText="Order No">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Article" HeaderText="Article">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="8%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ColorSpecification" HeaderText="Color/Specification">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Style" HeaderText="Style" Visible="false">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="7%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ShipmentDate" HeaderText="Date" DataFormatString="{0:dd MMM, yyyy}" HtmlEncode="false">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="9%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="OrderQuantity" HeaderText="Qty">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TotalQty" HeaderText="Value" DataFormatString="{0:0.00}">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                <ItemStyle HorizontalAlign="Right" Width="7%" CssClass="Grid_Border" />
                                                <FooterStyle CssClass="Grid_Footer" />
                                            </asp:BoundField>
                                            <%--<asp:TemplateField HeaderText="Value">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTotalQty" runat="server" Text='<%# Eval("TotalQty")%>' />
                                                </ItemTemplate>
                                                <ItemStyle Width="7%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                                            </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="Update">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgbtnOrderSheetEdit" runat="server" ImageUrl="img/list_edit.png"
                                                        OnClick="imgbtnOrderSheetEdit_Click" />
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
                                        <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" BackColor="#336666"
                                            Font-Bold="True" ForeColor="White" />
                                        <FooterStyle CssClass="Grid_Footer" BackColor="White" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                        <SortedAscendingHeaderStyle BackColor="#487575" />
                                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                        <SortedDescendingHeaderStyle BackColor="#275353" />
                                    </asp:GridView>
                                    <div class="row" id="showDiv" runat="server" visible="false">
                                        <div class="col-md-2">
                                            <asp:Label ID="lblTotal" Enabled="false" Style="float: left; margin-left: -15px;" Font-Bold="true" Font-Size="12px" ForeColor="Maroon" runat="server" Text="Total"></asp:Label>
                                        </div>
                                        <div class="col-md-2"></div>
                                        <div class="col-md-2"></div>
                                        <div class="col-md-2" style="padding: 0;">
                                            <asp:Label ID="lblQty" Enabled="false" Style="float: right; margin-right: -53px;" Font-Bold="true" Font-Size="12px" ForeColor="Maroon" runat="server"></asp:Label>
                                        </div>
                                        <div class="col-md-2" style="padding: 0;">
                                            <asp:Label ID="lblTotalCost" Style="float: right; margin-right: -23px;" runat="server" Font-Bold="true" Font-Size="12px" ForeColor="Maroon"></asp:Label>
                                        </div>
                                        <div class="col-md-2">
                                            <asp:Label ID="Label1" Style="float: right; margin-right: 51px;" runat="server" Text="$" Font-Bold="true" Font-Size="12px" ForeColor="Maroon"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

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

            else if (result === 'Data Updated Successfully') {
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
