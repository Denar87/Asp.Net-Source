<%@ Page Title="" Language="C#" MasterPageFile="~/FA/Site.Master" AutoEventWireup="true"
    CodeBehind="FA_AssetGroups.aspx.cs" Inherits="ERPSSL.FA.FA_AssetGroups" %>

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
                <i class="fa fa-edit fa-fw icon-padding"></i>Asset Group
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
                                        Group Name
                                    </div>
                                    <div class="col-md-7">
                                        <asp:TextBox ID="txtAssetGroupName" runat="server" class="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" SetFocusOnError="true" 
                                            ControlToValidate="txtAssetGroupName" ValidationGroup="vAssetGroup"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-5">
                                        Group Code
                                    </div>
                                    <div class="col-md-7">
                                        <asp:TextBox ID="txtGroupCode" runat="server" class="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" SetFocusOnError="true" 
                                            ControlToValidate="txtGroupCode" ValidationGroup="vAssetGroup"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-5">
                                        Tangibility
                                    </div>
                                    <div class="col-md-7">
                                        <asp:DropDownList ID="ddlTangibility" CssClass="form-control" runat="server">
                                            <asp:ListItem Value="0">--Select One--</asp:ListItem>
                                            <asp:ListItem Value="1">Tangible</asp:ListItem>
                                            <asp:ListItem Value="2">InTangible</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                               
                            </div>
                             <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-5">
                                        A/C Dep. rate
                                    </div>
                                    <div class="col-md-7">
                                        <asp:TextBox ID="txtACDepRate" runat="server" class="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" SetFocusOnError="true" 
                                            ControlToValidate="txtACDepRate" ValidationGroup="vAssetGroup"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-5">
                                        Tax Dep. rate
                                    </div>
                                    <div class="col-md-7">
                                        <asp:TextBox ID="txtTxDepRate" runat="server" class="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" SetFocusOnError="true" 
                                            ControlToValidate="txtTxDepRate" ValidationGroup="vAssetGroup"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-5">
                                        <asp:HiddenField ID="hdfAssetGroup" runat="server" />
                                    </div>
                                    <div class="col-md-7">
                                        <asp:Button ID="btnSubmit" runat="server" Text="Save" class="btn btn-info" 
                                            OnClick="btnSubmit_Click" ValidationGroup="vAssetGroup" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                           
                        </div>
                        <br />
                        <div class="row">
                        <div class="col-md-12">
                          
                         <fieldset style="border: none">
                                <asp:GridView ID="grdAssetGroups" runat="server" ShowFooter="True" Width="100%" HorizontalAlign="Left" AutoGenerateColumns="False"
                                    AllowPaging="True" AllowSorting="True" CellPadding="5" BorderColor="#99CCFF" OnPageIndexChanging="grdAssetGroup_PageIndexChanging"
                                    BorderStyle="Solid" CssClass="Grid_Border" ForeColor="#339933" PageSize="5">
                                    <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="GroupCode">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGroupCode" runat="server" Text='<%# Eval("GroupCode")%>' />
                                            </ItemTemplate>
                                            <FooterStyle CssClass="Grid_Footer" />
                                            <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                            <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" VerticalAlign="Middle"
                                                Width="5%" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="GroupName" HeaderText="GroupName">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Tangibility" HeaderText="Tangibility ">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ACDepreciationRate" HeaderText="ACDepreciationRate">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="TaxDepreciationRate" HeaderText="TaxDepreciationRate">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="UpdateDate" HeaderText="UpdateDate">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Option">
                                            <ItemTemplate>
                                                    <asp:ImageButton ID="ImgBtnEdit" runat="server" ImageUrl="../FA/img/list_edit.png" OnClick="imgBtnEdit_Click"
                                                    />
                                                   <asp:ImageButton ID="ImgBtnDelete" runat="server" ImageUrl="../FA/img/remove.png" OnClick="imgbtnDelete_Clik"
                                                     />
                                            </ItemTemplate>
                                            <FooterStyle CssClass="Grid_Footer" />
                                            <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                            <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" Width="8%" />
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
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
