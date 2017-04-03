<%@ Page Title="" Language="C#" MasterPageFile="~/FA/Site.Master" AutoEventWireup="true"
    CodeBehind="FA_AssetSetUp.aspx.cs" Inherits="ERPSSL.FA.FA_AssetSetUp" %>

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
                <i class="fa fa-edit fa-fw icon-padding"></i>Asset SetUp
            </div>
        </div>
        
      
            <div class="col-md-12 bg-success">
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </div>
            <div class="row">
                
                    <div class="col-md-12">
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-5">
                                        Group
                                    </div>
                                    <div class="col-md-7">
                                        <asp:DropDownList ID="ddlGroup" CssClass="form-control" runat="server">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                          SetFocusOnError="true"   ControlToValidate="ddlGroup" 
                                            ValidationGroup="AssetSetup"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-5">
                                        Name
                                    </div>
                                    <div class="col-md-7">
                                        <asp:TextBox ID="txtAssetName" runat="server" class="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" SetFocusOnError="true" 
                                            ControlToValidate="txtAssetName" ValidationGroup="AssetSetup"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-5">
                                        Brand
                                    </div>
                                    <div class="col-md-7">
                                        <asp:TextBox ID="txtBrand" runat="server" class="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                          SetFocusOnError="true"   ControlToValidate="txtBrand" 
                                            ValidationGroup="AssetSetup"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-5">
                                        Style & Size
                                    </div>
                                    <div class="col-md-7">
                                        <asp:TextBox ID="txtStyleAndSize" runat="server" class="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                          SetFocusOnError="true"   ControlToValidate="txtStyleAndSize" 
                                            ValidationGroup="AssetSetup"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-5">
                                        Unit
                                    </div>
                                    <div class="col-md-7">
                                        <asp:DropDownList ID="ddlUnit" CssClass="form-control" runat="server">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                         SetFocusOnError="true"    ControlToValidate="ddlUnit" 
                                            ValidationGroup="AssetSetup"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-5">
                                        <asp:HiddenField ID="hdnAssetId" runat="server" />
                                    </div>
                                    <div class="col-md-7">
                                        <asp:Button ID="btnSubmit" runat="server" Text="Save" class="btn btn-info" 
                                            onclick="btnSubmit_Click" ValidationGroup="AssetSetup" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                        </div>


                    </div>
                <br />
                
                <div class="row">
                 <div class="col-md-12">
                 <fieldset style="border:none;">
                    <asp:GridView ID="grdAssets" runat="server" ShowFooter="True" Width="100%" HorizontalAlign="Left"
                        AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" CellPadding="5"
                        BorderColor="#99CCFF" BorderStyle="Solid" CssClass="Grid_Border" ForeColor="#339933"
                        PageSize="5" OnPageIndexChanging="grdAssets_PageIndexChanging" >
                        <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                        <Columns>
                            <asp:TemplateField HeaderText="AssetId">
                                <ItemTemplate>
                                    <asp:Label ID="lblAssetId" runat="server" Text='<%# Eval("AssetId")%>' />
                                </ItemTemplate>
                                <FooterStyle CssClass="Grid_Footer" />
                                <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" VerticalAlign="Middle"
                                    Width="5%" />
                            </asp:TemplateField>

                             <asp:BoundField DataField="GroupName" HeaderText="GroupName ">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="14%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                           <asp:BoundField DataField="AssetName" HeaderText="AssetName">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="14%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:BoundField DataField="UnitName" HeaderText="UnitName">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="14%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Brand" HeaderText="Brand">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="14%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:BoundField DataField="StyleAndSize" HeaderText="StyleAndSize">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="14%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:BoundField DataField="UpdateDate" HeaderText="UpdateDate">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="14%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>

                             <asp:TemplateField HeaderText="Option">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImgBtnEdit" runat="server" ImageUrl="../FA/img/list_edit.png" 
                                       OnClick="imgBtnEdit_Click" />
                                    <asp:ImageButton ID="ImgBtnDelete"  runat="server" ImageUrl="../FA/img/remove.png" 
                                        OnClick="imgbtnDelete_Clik" />
                                </ItemTemplate>
                                <FooterStyle CssClass="Grid_Footer" />
                                <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" Width="12%" />
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataRowStyle ForeColor="Red" />
                        <PagerSettings Mode="NumericFirstLast" />
                        <PagerStyle CssClass="pagination01 pageback" />
                        <RowStyle CssClass="Grid_RowStyle" />
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
