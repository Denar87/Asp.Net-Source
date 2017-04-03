<%@ Page Title="" Language="C#" MasterPageFile="~/Adminpanel/Site.Master" AutoEventWireup="true" CodeBehind="UpdateuserAccess.aspx.cs" Inherits="ERPSSL.Adminpanel.UpdateuserAccess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
        <ContentTemplate>

            <div class="hm_sec_2_content scrollbar">
                <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="fa fa-edit fa-fw icon-padding"></i>Update User Access
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="resultText">
                        <asp:Image ID="imgstatusloading" runat="server" CssClass="lblstatusloading_icon"
                            Visible="false" />
                        <asp:Image ID="imgstatus" runat="server" CssClass="lblstatus_icon" Visible="false" />
                        <asp:Label ID="lblStatus" runat="server" Font-Bold="true" CssClass="lbltext"></asp:Label>
                    </div>
                    <div class="col-md-12">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label" for="inputFname1">
                                    User Name</label>
                                <div class="controls">
                                    <asp:DropDownList ID="drpUserName" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="drpRole_change" Width="100%">
                                    </asp:DropDownList>
                                    <asp:HiddenField ID="hiduserId" runat="server" />

                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label" for="inputFname1">
                                    Module</label>
                                <div class="controls">
                                    <asp:DropDownList ID="drpModule" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="drpModule_change" Width="100%">
                                    </asp:DropDownList>


                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label" for="inputFname1">
                                    Feature</label>
                                <div class="controls">
                                    <asp:DropDownList ID="drpFeature" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="drpFeature_change" Width="100%">
                                    </asp:DropDownList>


                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12" style="height: 410px; overflow: scroll; margin-top: 10px; padding-top: 10px; padding-bottom: 10px; border-top: 0px solid #eee;">
                        <asp:GridView ID="gridviewUserAccess" runat="server" AutoGenerateColumns="False" Width="100%">
                            <Columns>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="3%" HeaderStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        Sl.
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblSRNO" runat="server"
                                            Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUserAccessId" runat="server" Text='<%# Eval("UserAccessId")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField DataField="RoleName" HeaderText="Role Name">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>


                                <asp:BoundField DataField="ModuleName" HeaderText="Module Name">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>

                                <asp:BoundField DataField="CategoryName" HeaderText="Features">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>

                                <asp:BoundField DataField="pageName" HeaderText="Page Name">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>


                                <asp:TemplateField HeaderText="Visit">
                                    <ItemTemplate>

                                        <asp:CheckBox ID="chCanVisit" runat="server" Checked='<%# bool.Parse(Eval("CanVisit").ToString() == "True" ? "True": "False")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>

                                        <asp:CheckBox ID="ChCanEdit" runat="server" Checked='<%# bool.Parse(Eval("CanEdit").ToString() == "True" ? "True": "False")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>

                                        <asp:CheckBox ID="ChCanDelete" runat="server" Checked='<%# bool.Parse(Eval("CanDelete").ToString() == "True" ? "True": "False")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Execute">
                                    <ItemTemplate>

                                        <asp:CheckBox ID="ChCanExecute" runat="server" Checked='<%# bool.Parse(Eval("CanExecute").ToString() == "True" ? "True": "False")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>

                                        <asp:ImageButton ID="imgDeletePagePermission" runat="server" ImageUrl="resources/list_Delete.png" OnClick="imgDeletePagePermission_Click" />
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
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function func(result) {
            if (result === 'Data Saved Successfully') {
                toastr.success(result);
            }

                //else if (result === 'Data Updated Successfully') {
                //    toastr.success(result);
                //}

            else
                toastr.error(result);

            return false;
        }

    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
