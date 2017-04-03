<%@ Page Title="" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true"
    CodeBehind="officeSetup.aspx.cs" Inherits="ERPSSL.HRM.officeSetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">

        <ContentTemplate>

            <div class="hm_sec_2_content scrollbar">
                <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="fa fa-edit fa-fw icon-padding"></i>Office Setup
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
                                        Region
                                    </div>
                                    <div class="col-md-7">
                                        <%--<asp:DropDownList ID="drpRegion" AutoPostBack="True" OnSelectedIndexChanged="drpRegion_SelecttedIndexChanged"
                                required="required" class="form-control" runat="server">
                            </asp:DropDownList>--%>

                                        <asp:DropDownList ID="drpRegion" required="required" class="form-control"  AutoPostBack="True" OnSelectedIndexChanged="drpRegion_SelecttedIndexChanged" runat="server">
                                        </asp:DropDownList>

                                        

                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-5">
                                        Office
                                    </div>
                                    <div class="col-md-7">
                                        <asp:TextBox ID="txtbxOfficeName" runat="server" class="form-control"></asp:TextBox>
                                        <%--<asp:TextBox ID="txtbxOfficeName" runat="server" class="form-control"></asp:TextBox>--%>
                                        <asp:HiddenField ID="hidOfficeId" runat="server" />
                                        <asp:HiddenField ID="hidOfficeName" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-5">
                                        Office Code
                                    </div>
                                    <div class="col-md-7">
                                        <div class="col-md-12" style="padding-left:0px;">

                                            <div class="col-md-7" style="padding-left:0px;">

                                                <asp:TextBox ID="txtRegionCode" runat="server" Width="90px" ReadOnly="true" class="form-control"></asp:TextBox>

                                            </div>

                                            <div class="col-md-5" style="padding-left:0px;">

                                                <asp:TextBox ID="txtbxOfficeCode" runat="server" Width="90px" class="form-control"></asp:TextBox>
                                            </div>


                                        </div>

                                        <%--  <asp:Label ID="lblRegionCode" runat="server"></asp:Label>--%>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-5">
                                        Address
                                    </div>
                                    <div class="col-md-7">
                                        <asp:TextBox ID="txtbxAddress" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-5">
                                    </div>
                                    <div class="col-md-7">
                                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Submit" class="btn btn-info  pull-right" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-7">
                            <asp:GridView ID="gridViewOffice" runat="server" AutoGenerateColumns="False" Width="100%"
                                CellPadding="5" AllowPaging="True" PageSize="10" OnPageIndexChanging="gridViewOffice_PageIndexChanging">
                                <Columns>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center">
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
                                            <asp:Label ID="lblOfficeId" runat="server" Text='<%# Eval("OfficeID")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:BoundField DataField="ResionName" HeaderText="Resion Name">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>--%>
                                    <asp:TemplateField HeaderText="Region">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCategoryFSubCat" runat="server" Text='<%# Bind("HRM_Regions.RegionName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle CssClass="Grid_Footer" />
                                        <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                        <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="15%" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="OfficeName" HeaderText="Office">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Left" Width="20%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OfficeCode" HeaderText="Office Code">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OfficeAddress" HeaderText="Office Address">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Update">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgbtnEdit" runat="server" ImageUrl="img/list_edit.png" OnClick="imgbtnEdit_Clik" />
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
        </ContentTemplate>

        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <script>

        function func(result) {
            if (result === 'Data Save successfully') {
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
