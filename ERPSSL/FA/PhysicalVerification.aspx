<%@ Page Title="" Language="C#" MasterPageFile="~/FA/Site.Master" AutoEventWireup="true"
    CodeBehind="PhysicalVerification.aspx.cs" Inherits="ERPSSL.FA.PhysicalVerification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
        <ContentTemplate>
            <div class="row">
                 <div class="hm_sec_2_content scrollbar">
                <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="fa fa-edit fa-fw icon-padding"></i>Physical Verification
                    </div>
                </div>

               
                    <div class="col-md-12 bg-success">
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </div>

                    <div class="row">
                        <div class="col-md-12" style="margin-top: 20px;">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-6">
                                        <div class="row">
                                            <div class="col-md-5">
                                                Region
                                            </div>
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="ddlRegion" CssClass="form-control" runat="server" AutoPostBack="True"
                                                    OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col-md-5">
                                                Office
                                            </div>
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="ddlOffice" CssClass="form-control" runat="server" AutoPostBack="True"
                                                    OnSelectedIndexChanged="ddlOffice_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col-md-5">
                                                Department
                                            </div>
                                            <div class="col-md-7">
                                                <asp:DropDownList ID="ddlDepartment" CssClass="form-control" runat="server" AutoPostBack="True"
                                                    OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="col-md-12">
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="img/NoPhoto.jpg" CssClass="img-thumbnail" />
                                                    </div>
                                                    <div class="col-md-4">
                                                        <asp:Image ID="Image2" runat="server" AlternateText="Photo 2" ImageUrl="img/NoPhoto.jpg" CssClass="img-thumbnail" />
                                                    </div>
                                                    <div class="col-md-4">
                                                        <asp:Image ID="Image3" runat="server" AlternateText="Photo 3" ImageUrl="img/NoPhoto.jpg" CssClass="img-thumbnail" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-12">
                            <div class="row">
                                <div class="col-lg-12">
                                    <fieldset>
                                        <legend style="line-height: 0;"><span style="background: #fff; font-weight: 600;">Find
                                    Asset</span></legend>
                                        <asp:GridView ID="grdAssets" runat="server" Width="100%" HorizontalAlign="Center"
                                            AutoGenerateColumns="False" BackColor="White" BorderColor="#99CCFF" BorderStyle="Solid"
                                            CellPadding="5" CssClass="Grid_Border" DataKeyNames="AssetCode" OnSelectedIndexChanged="grdAssets_SelectedIndexChanged"
                                            OnRowDeleting="grdAssets_RowDeleting" OnRowDataBound="grdAssets_RowDataBound" RowStyle-Height="25px">
                                            <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                            <Columns>
                                                <asp:BoundField DataField="AssetCode" HeaderText="AssetCode" SortExpression="AssetCode"
                                                    ReadOnly="True" />
                                                <asp:BoundField DataField="CustomAssetName" HeaderText="CustomAssetName" SortExpression="CustomAssetName"
                                                    ReadOnly="True" />
                                                <asp:BoundField DataField="RegionName" HeaderText="RegionName" SortExpression="RegionName" />
                                                <asp:BoundField DataField="OfficeName" HeaderText="OfficeName" SortExpression="OfficeName" />
                                                <asp:BoundField DataField="DepartmentName" HeaderText="DepartmentName" SortExpression="DepartmentName" />
                                                <asp:BoundField DataField="IsNotFound" HeaderText="Status" SortExpression="IsNotFound" />
                                                <asp:CommandField ShowSelectButton="True" SelectText="Show Photo" />
                                                <asp:CommandField DeleteText="Change Status" ShowDeleteButton="True">
                                                    <ItemStyle ForeColor="Red" />
                                                </asp:CommandField>
                                            </Columns>
                                            <EmptyDataRowStyle ForeColor="Red" />
                                            <RowStyle CssClass="Grid_RowStyle" />
                                            <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                            <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#336666" />
                                            <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" Font-Bold="True"
                                                ForeColor="White" Height="25px" />
                                            <FooterStyle CssClass="Grid_Footer" BackColor="White" ForeColor="#333333" />
                                            <SelectedRowStyle BackColor="#636332" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                            <SortedAscendingHeaderStyle BackColor="#487575" />
                                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                            <SortedDescendingHeaderStyle BackColor="#275353" />
                                        </asp:GridView>
                                    </fieldset>
                                    <asp:Label ID="lblVerification" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <hr />
                    <div class="row">
                        <div class="col-md-12" style="margin-top: 20px;">
                            <div class="col-md-5">
                                <fieldset>
                                    <legend style="line-height: 0;"><span style="background: #fff">Extra Assets</span></legend>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Asset Code:
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtAssetCode" CssClass="form-control" runat="server"
                                                    OnTextChanged="txtAssetCode_TextChanged" AutoPostBack="True"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                    ControlToValidate="txtAssetCode" SetFocusOnError="True"
                                                    ValidationGroup="Physical"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                    </div>

                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                <asp:HiddenField ID="HiddenField1" runat="server" />
                                            </div>
                                            <div class="col-md-7">
                                                <asp:Button ID="Button2" runat="server" Text="Insert" class="btn btn-info"
                                                    OnClick="Button2_Click" ValidationGroup="Physical" />
                                            </div>
                                        </div>
                                    </div>
                                    <asp:Label ID="lblExtraAssetIdentityStatus" runat="server" Text=""></asp:Label>
                                </fieldset>
                            </div>
                            <div class="col-md-7">
                                <fieldset>
                                    <legend style="line-height: 0;"><span style="background: #fff">Extra Assets Found</span></legend>
                                    <asp:GridView ID="grdExtraAssets" runat="server" AutoGenerateColumns="False" BackColor="White" Width="100%"
                                        BorderColor="#99CCFF" BorderStyle="Solid" CellPadding="2" CssClass="Grid_Border" OnRowDeleting="grdExtraAssets_RowDeleting"
                                        DataKeyNames="ExtraId">
                                        <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                        <Columns>
                                            <%-- <asp:BoundField DataField="ExtraId" HeaderText="ExtraId" SortExpression="ExtraId"
                                        ReadOnly="True" />--%>
                                            <asp:BoundField DataField="AssetCode" HeaderText="AssetCode" SortExpression="AssetCode"
                                                ReadOnly="True" />
                                            <asp:BoundField DataField="CustomAssetName" HeaderText="CustomAssetName" SortExpression="CustomAssetName"
                                                ReadOnly="True" />
                                            <asp:BoundField DataField="RegionName" HeaderText="RegionName" SortExpression="RegionName" />
                                            <asp:BoundField DataField="OfficeName" HeaderText="OfficeName" SortExpression="OfficeName" />
                                            <asp:BoundField DataField="DepartmentName" HeaderText="DepartmentName" SortExpression="DepartmentName" />
                                            <asp:CommandField DeleteText="Remove" ShowDeleteButton="True" />
                                        </Columns>
                                        <EmptyDataRowStyle ForeColor="Red" />
                                        <RowStyle CssClass="Grid_RowStyle" Height="25px" />
                                        <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                        <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#336666" />
                                        <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" Font-Bold="True"
                                            ForeColor="White" Height="25px" />
                                        <FooterStyle CssClass="Grid_Footer" BackColor="White" ForeColor="#333333" />
                                        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                        <SortedAscendingHeaderStyle BackColor="#487575" />
                                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                        <SortedDescendingHeaderStyle BackColor="#275353" />
                                    </asp:GridView>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
