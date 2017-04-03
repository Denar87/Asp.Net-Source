<%@ Page Title="" Language="C#" MasterPageFile="~/Adminpanel/Site.Master" AutoEventWireup="true" CodeBehind="AddCategory.aspx.cs" Inherits="ERPSSL.Adminpanel.AddCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
        <ContentTemplate>
            <div class="hm_sec_2_content scrollbar">
                <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="fa fa-edit fa-fw icon-padding"></i>Add Feature
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="resultText">
                        <asp:Image ID="imgstatusloading" runat="server" CssClass="lblstatusloading_icon"
                            Visible="false" />
                        <asp:Image ID="imgstatus" runat="server" CssClass="lblstatus_icon" Visible="false" />
                        <asp:Label ID="lblStatus" runat="server" Font-Bold="true" CssClass="lbltext"></asp:Label>
                    </div>
                    <div class="col-md-5">
                        <div class="row">
                            <label class="control-label" for="inputFname1">
                                Module Name<a style="color: red; font-size: 11px">*</a></label>
                            <div class="controls">
                                <asp:DropDownList ID="drpModulName" runat="server" CssClass="form-control" Width="60%" AutoPostBack="true" OnSelectedIndexChanged="drpModulName_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:HiddenField ID="hidcategoryId" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" ValidationGroup="Group2"
                                    runat="server" ControlToValidate="drpModulName" ErrorMessage="Select Module Name"
                                    InitialValue="0"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="row">
                            <label class="control-label" for="inputFname1">
                                Feature Name<a style="color: red; font-size: 11px">*</a></label>
                            <div class="controls">
                                <asp:TextBox ID="txtbxCateGoryName" runat="server" CssClass="form-control" Width="60%"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtbxCateGoryName"
                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Feature Name"
                                    ValidationGroup="Group2"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="row">
                            <br />
                            <label class="control-label" for="inputFname1">
                                Menu Order<a style="color: red; font-size: 11px">*</a></label>
                            <div class="controls">
                                <asp:TextBox ID="txtbxMenuOrder" runat="server" CssClass="form-control" Width="60%"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtbxCateGoryName"
                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Menu Order"
                                    ValidationGroup="Group2"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="row">
                            <br />
                            <label class="control-label" for="inputFname1">
                                Status</label>
                            <div class="controls">
                                <asp:DropDownList ID="drpdownStatus" runat="server" CssClass="form-control" Width="60%">
                                    <asp:ListItem Text="--- Select --- " Value="0"></asp:ListItem>
                                    <asp:ListItem>True</asp:ListItem>
                                    <asp:ListItem>False</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <%--<div class="form-group">
                    <div class="form-group">
                        <asp:Button ID="BtnSave" runat="server" ValidationGroup="Group2" CssClass="btn btn-info"
                            Text="Save Feature" OnClick="BtnSave_Click" />
                    </div>
                </div>--%>
                        <div class="row" style="padding: 0px">
                            <br />

                            <asp:Button ID="BtnSave" runat="server" ValidationGroup="Group2" CssClass="btn btn-info"
                                Text="Save Feature" OnClick="BtnSave_Click" />

                        </div>

                    </div>
                    <%--         AllowPaging="True" OnPageIndexChanging="gridviewCategory_PageIndexChanging"--%>
                    <div class="col-md-7" style="height: 410px; overflow: scroll; margin-top: 10px; padding-top: 10px; padding-bottom: 10px; border-top: 0px solid #eee;">

                        <asp:GridView ID="gridviewCategory" runat="server" AutoGenerateColumns="False" PageSize="10" Width="100%">
                            <Columns>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="3%" HeaderStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        Sl No.
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblSRNO" runat="server"
                                            Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCatgoryId" runat="server" Text='<%# Eval("CategoryId")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ModuleName" HeaderText="Module">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CategoryName" HeaderText="Feature">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CategoryOrder" HeaderText="Order">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Status" HeaderText="Status">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgbtCategoryEdit" runat="server" ImageUrl="~/img/list_edit.png" OnClick="imgbtCategoryEdit_Click" />
                                    </ItemTemplate>
                                    <ItemStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
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
    </asp:UpdatePanel>

    <script type="text/javascript">



        function func(result) {
            if (result === 'Data Saved Successfully') {
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
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
