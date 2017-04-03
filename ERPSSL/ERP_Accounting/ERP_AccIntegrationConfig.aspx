<%@ Page Title="" Language="C#" MasterPageFile="~/ERP_Accounting/Site.Master" AutoEventWireup="true" CodeBehind="ERP_AccIntegrationConfig.aspx.cs" Inherits="ERPSSL.ERP_Accounting.ERP_AccIntegrationConfig" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    
    <div class="row">

        <div class="hm_sec_2_content scrollbar">
            <div class="panel">
                <div class="panel-heading panel-heading-01">
                    <i class="fa fa-edit fa-fw icon-padding"></i>ERP Configuration
                </div>
            </div>
            <br />
            <div class="col-md-12">
                <div class="col-md-6">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-4">
                                Module Name<a style="color: red; font-size: 11px">*</a>
                                <asp:HiddenField ID="hidId" runat="server" />
                            </div>
                            <div class="col-md-8">
                                <asp:DropDownList ID="drpModulName" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="drpModulName"
                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select a Module"
                                    Font-Size="11px" ValidationGroup="Group2" InitialValue="0"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <br />

                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-4">
                                Module Type
                            </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtModuleType" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-4">
                                Nature<a style="color: red; font-size: 11px">*</a>
                            </div>
                            <div class="col-md-8">
                                <asp:DropDownList ID="ddlNature" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlNature_SelectedIndexChanged">
                                    <asp:ListItem>--Select--</asp:ListItem>
                                    <asp:ListItem>Debit</asp:ListItem>
                                    <asp:ListItem>Credit</asp:ListItem>
                                </asp:DropDownList>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlNature"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Select a Nature"
                                            Font-Size="11px" ValidationGroup="Group2" InitialValue="0"></asp:RequiredFieldValidator>--%>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-4">
                                Ledger Name<a style="color: red; font-size: 11px">*</a>
                            </div>
                            <div class="col-md-8">
                                <asp:DropDownList ID="ddlLedgerName" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <br />

                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-4">
                                Voucher Type<a style="color: red; font-size: 11px">*</a>
                            </div>
                            <div class="col-md-8">
                                <asp:DropDownList ID="ddlVoucherType" runat="server" CssClass="form-control">
                                    <asp:ListItem>--Select--</asp:ListItem>
                                    <asp:ListItem>PAYMENT</asp:ListItem>
                                    <asp:ListItem>RECEIPT</asp:ListItem>
                                    <asp:ListItem>JOURNAL</asp:ListItem>
                                    <asp:ListItem>CONTRA</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-4">
                                Is Changable<a style="color: red; font-size: 11px">*</a>
                            </div>
                            <div class="col-md-8">
                                <asp:CheckBox ID="chkIsChangable" runat="server" />
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-4">
                            </div>
                            <div class="col-md-8">
                                <asp:Button ID="BtnSave" runat="server" ValidationGroup="Group2" CssClass="btn btn-info"
                                    Text="Add" OnClick="BtnSave_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <asp:GridView ID="dgGridList" runat="server" AutoGenerateColumns="False" Width="100%"
                        AllowPaging="true" CellPadding="5"
                        OnPageIndexChanging="dgGridList_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="3%" HeaderStyle-HorizontalAlign="Center">
                                <HeaderTemplate>
                                    Sl.
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblSRNO" runat="server"
                                        Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Center" CssClass="Grid_Border" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Id" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblID" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                </FooterTemplate>
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Module">
                                <ItemTemplate>
                                    <asp:Label ID="lblModuleName" runat="server" Text='<%#Eval("ModuleName") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Module Id" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblModuleId" runat="server" Text='<%#Eval("ModuleId") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Type">
                                <ItemTemplate>
                                    <asp:Label ID="lblItemName" runat="server" Text='<%#Eval("Item") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Ledger Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblParticulars" runat="server" Text='<%#Eval("Particulars") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="cmbParticulars" runat="server" Height="28px">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <FooterTemplate>
                                </FooterTemplate>
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Nature">
                                <ItemTemplate>
                                    <asp:Label ID="lblTransactionNature" runat="server" Text='<%#Eval("TransactionNature") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Voucher Type">
                                <ItemTemplate>
                                    <asp:Label ID="lblVoucher_Type" runat="server" Text='<%#Eval("Voucher_Type") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Is Changable">
                                <ItemTemplate>
                                    <asp:Label ID="lblchangable" runat="server" Text='<%#Eval("IsChangable") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImgEdit" runat="server" ImageUrl="img/list_edit.png" OnClick="ImgEdit_Click" />
                                </ItemTemplate>
                                <FooterStyle CssClass="Grid_Footer" />
                                <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" Width="8%" />
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle CssClass="pagination01 pageback" />
                    </asp:GridView>

                </div>
            </div>

            <%--  <div class="col-md-12" style="padding-bottom: 10px; padding-top: 10px">
                        <asp:DropDownList ID="ddlModule" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlModule_SelectedIndexChanged" Height="28" Width="250">
                            <asp:ListItem>--Select--</asp:ListItem>
                            <asp:ListItem>Sales</asp:ListItem>
                            <asp:ListItem>Inventory</asp:ListItem>
                            <asp:ListItem>Fixed Asset</asp:ListItem>
                            <asp:ListItem>Payroll</asp:ListItem>
                        </asp:DropDownList>
                    </div>--%>


            <br />
        </div>
    </div>
   
    <script type="text/javascript">

        function func(result) {
            if (result === 'Data Added Successfully') {
                toastr.success(result);
            }
            if (result === 'Data Updated Successfully') {
                toastr.success(result);
            }
            else
                toastr.error(result);

            return false;
        }

    </script>
</asp:Content>
