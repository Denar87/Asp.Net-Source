<%@ Page Title="" Language="C#" MasterPageFile="~/INV/Site.Master" AutoEventWireup="true"
    CodeBehind="ReturnTOCentralFromStore.aspx.cs" Inherits="ERPSSL.INV.ReturnTOCentralFromStore" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>
            <div class="row">
                <asp:HiddenField ID="hdnBarCode" runat="server" />
                <div class="hm_sec_2_content scrollbar">
                    <div class="panel">
                        <div class="panel-heading panel-heading-01">
                            <i class="glyphicon glyphicon-edit icon-padding"></i>Return To Central
                        </div>
                    </div>
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label>
                    <div class="row" style="margin: auto 0; padding-top:5px;">
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-4">
                                    Date <a style="color: red; font-size: 11px">*</a>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtDate" CssClass="form-control" runat="server"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtDate"
                                        PopupButtonID="txtDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                </div>
                            </div>
                            <div class="row" style="padding-top: 5px">
                                <div class="col-md-4">
                                    Department<a style="color: red; font-size: 11px">*</a>
                                </div>
                                <div class="col-md-8">

                                    <asp:TextBox ID="txtChalanNo" CssClass="form-control" runat="server" ReadOnly="True"
                                        Visible="false"></asp:TextBox>
                                    <asp:DropDownList ID="ddlDepartment" AutoPostBack="true" CssClass="form-control"
                                        runat="server" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlDepartment"
                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select a Department"
                                        InitialValue="0" Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="row" style="padding-top: 5px">
                                <div class="col-md-4">
                                    E-ID/Name<a style="color: red; font-size: 11px">*</a>
                                </div>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddlEmployee" CssClass="form-control" runat="server">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlEmployee"
                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select an Employee"
                                        InitialValue="0" Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="row" style="padding-top: 5px">
                                <div class="col-md-4">
                                    Store To<a style="color: red; font-size: 11px">*</a>
                                </div>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddlStore" AutoPostBack="true" CssClass="form-control" runat="server"
                                        OnSelectedIndexChanged="ddlStore_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlStore"
                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select a Store"
                                        InitialValue="0" Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="row" style="padding-top: 5px">
                                <div class="col-md-4">
                                    Item Group<a style="color: red; font-size: 11px">*</a>
                                </div>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddlProductGroup" AutoPostBack="true" CssClass="form-control"
                                        runat="server" OnSelectedIndexChanged="ddlProductGroup_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlProductGroup"
                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select a Group"
                                        InitialValue="0" Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="row" style="padding-top: 5px">
                                <div class="col-md-4">
                                    Item Description<a style="color: red; font-size: 11px">*</a>
                                </div>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddlProduct" AutoPostBack="true" CssClass="form-control" runat="server"
                                        OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlProduct"
                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select an Item"
                                        InitialValue="0" Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="row" style="padding-top: 5px">
                                <div class="col-md-4">
                                    Balance Qty
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtBalanceQty" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row" style="padding-top: 5px">
                                <div class="col-md-4">
                                    Return Qty<a style="color: red; font-size: 11px">*</a>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtReturnQty" CssClass="form-control" runat="server" AutoPostBack="true"
                                        OnTextChanged="txtReturnQty_TextChanged"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtReturnQty"
                                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Enter Return Qty"
                                        Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="row" style="padding-top: 5px">
                                <div class="col-md-4">
                                    Remaining Qty
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtRemainingQty" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row" style="padding-top: 5px">
                                <div class="col-md-4">
                                </div>
                                <div class="col-md-8">
                                    <asp:Button ID="BtnSave" runat="server" Text="Return" class="btn btn-info pull-right" ValidationGroup="Group1"
                                        OnClick="BtnSave_Click" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <%--<div class="row">--%>
                            <asp:GridView ID="grdTransfer" runat="server" Width="100%" AutoGenerateColumns="false"
                                AllowSorting="true" CellPadding="5" BorderColor="#E3F0FC" BorderStyle="Solid"
                                CssClass="Grid_Border" AllowPaging="True">
                                <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                <Columns>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            Sl.
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblSRNO" runat="server"
                                                Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblId" runat="server" Text='<%# Eval("Id")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ProductName" HeaderText="Item">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DPT_NAME" HeaderText="Department">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Employee" HeaderText="Employee">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ReturnQty" HeaderText="Return Qty">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BalanceQty" HeaderText="Balance Qty">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <%--<asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImgGroupEdit" runat="server" ImageUrl="img/list_edit.png" OnClick="ImgGroupEdit_Click" />
                                            </ItemTemplate>
                                            <FooterStyle CssClass="Grid_Footer" />
                                            <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                            <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" Width="8%" />
                                        </asp:TemplateField>--%>
                                </Columns>
                                <EmptyDataRowStyle ForeColor="Red" />
                                <PagerSettings Mode="NumericFirstLast" />
                                <PagerStyle CssClass="pagination01 pageback" />
                                <RowStyle CssClass="Grid_RowStyle" />
                            </asp:GridView>
                            <%--</div>--%>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <script type="text/javascript">

        function func(result) {
            if (result === 'Item Returned Successfully') {
                toastr.success(result);

            }
            else
                toastr.error(result);

            return false;
        }

    </script>
</asp:Content>
