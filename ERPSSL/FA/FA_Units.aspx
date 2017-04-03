<%@ Page Title="" Language="C#" MasterPageFile="~/FA/Site.Master" AutoEventWireup="true" CodeBehind="FA_Units.aspx.cs" Inherits="ERPSSL.FA.FA_Units" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="row"> 
        <div class="hm_sec_2_content scrollbar">
        <div class="panel">
            <div class="panel-heading panel-heading-01">
                <i class="fa fa-edit fa-fw icon-padding"></i>Measure Of Unit
            </div>
            <asp:HiddenField ID="hdnUnitId" runat="server" />
        </div>

       
            <div class="col-md-12 bg-success">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </div>
            <div class="row">
                <fieldset style="border: none">
                    <div class="col-md-12">
                        <div class="col-md-6">

                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-5">
                                        Unit Name
                                    </div>
                                    <div class="col-md-7">
                                        <asp:TextBox ID="txtUnit" runat="server" class="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" SetFocusOnError="true"
                                            ValidationGroup="vFA_Units" ControlToValidate="txtUnit"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                        </div>
                        <div class="col-md-6">

                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-5">
                                        <asp:Button ID="btnSubmit" runat="server" Text="Save" class="btn btn-info"
                                            OnClick="btnSubmit_Click" ValidationGroup="vFA_Units" />
                                        <asp:HiddenField ID="hdfIncoTerm" runat="server" />
                                    </div>
                                    <div class="col-md-7">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </fieldset>
                <div class="row">
                    <div class="col-lg-12">
                        <div class="col-lg-8">
                            <fieldset style="border: none">
                                <asp:GridView ID="grdUnit" runat="server" ShowFooter="True" Width="80%"
                                    AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" CellPadding="5"
                                    BorderColor="#99CCFF" BorderStyle="Solid" CssClass="Grid_Border" ForeColor="#339933" OnPageIndexChanging="grdUnit_PageIndexChanging"
                                    PageSize="5">
                                    <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="SL No.">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUnitId" runat="server" Text='<%# Eval("UnitId")%>' />
                                            </ItemTemplate>
                                            <FooterStyle CssClass="Grid_Footer" />
                                            <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                            <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" VerticalAlign="Middle"
                                                Width="5%" />
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="UnitName" HeaderText="UnitName ">
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
                                                <asp:ImageButton ID="ImgBtnEdit" runat="server" ImageUrl="../FA/img/list_edit.png" OnClick="imgBtnEdit_Click" />
                                                <asp:ImageButton ID="ImgBtnDelete" OnClick="imgbtnDelete_Clik" runat="server" ImageUrl="../FA/img/remove.png" />
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

</asp:Content>
