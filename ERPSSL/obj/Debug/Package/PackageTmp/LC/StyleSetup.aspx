<%@ Page Title="" Language="C#" MasterPageFile="~/LC/Site.Master" AutoEventWireup="true" CodeBehind="StyleSetup.aspx.cs" Inherits="ERPSSL.LC.StyleSetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <div class="hm_sec_2_content scrollbar">
        <div class="panel">
            <div class="panel-heading panel-heading-01">
                <i class="fa fa-edit fa-fw icon-padding"></i>Style Setup 
            </div>
        </div>
        <div class="row">
            <div class="col-md-12 bg-success">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </div>
            <div class="col-md-12">
                <div class="col-md-5">
                    <div class="row" style="padding-top: 3px;">
                        <div class="col-md-5">
                            Style Name <a style="color: red; font-size: 11px">*</a>
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtStyle" runat="server" class="form-control"></asp:TextBox>
                            <asp:HiddenField ID="hidBueyId" runat="server" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtStyle"
                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Style Name"
                                ValidationGroup="Group1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row" style="padding-top: 3px;">
                        <div class="col-md-5">
                            Specification 
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtSpecification" runat="server" class="form-control"></asp:TextBox>
                            <asp:HiddenField ID="HiddenField1" runat="server" />

                        </div>
                    </div>

                    <div class="row" style="padding-top: 3px;">
                        <div class="col-md-5">
                            H S Code
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtHSCode" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row" style="padding-top: 3px;">
                        <div class="col-md-5">
                            CAT
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtCAT" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row" style="padding-top: 5px;">
                        <div class="col-md-5">
                        </div>
                        <div class="col-md-7" style="text-align: right;">
                            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="file_Upload" onchange="readfile(this);"
                                Width="85%" />
                            <%-- <asp:Image ID="imgUploadStyle" runat="server" class="avater_details" ImageAlign="Right" Height="150px"
                                ImageUrl="../resources/no_image.png" onerror="this.onerror=null; this.src='resources/no_image_found.png';"
                                Width="130px" />--%>
                        </div>
                    </div>
                    <div class="row" style="padding-top: 8px;">
                        <div class="col-md-12">
                            <div class="col-md-3">
                            </div>
                            <div class="col-md-9">
                                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" ValidationGroup="Group1" Text="Submit" class="btn btn-info  pull-right" /><%--OnClick="btnSave_Click"--%>
                            </div>
                        </div>
                    </div>

                </div>
                <div class="col-md-7">
                    <asp:GridView ID="grdStyle" runat="server" AutoGenerateColumns="False" Width="100%"
                        CellPadding="5" AllowPaging="false" PageSize="10">
                        <%--OnPageIndexChanging="gridviewSection_PageIndexChanging"--%>
                        <Columns>

                            <%-- <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center">
                                <HeaderTemplate>
                                    Sl No.
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblSRNO" runat="server"
                                        Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>

                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="2%" HeaderStyle-HorizontalAlign="Center">
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
                                    <asp:Label ID="lblByerId" runat="server" Text='<%# Eval("StyleId")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="StyleName" HeaderText="Name">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Specification" HeaderText="Specification">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                            <asp:BoundField DataField="HS_Code" HeaderText="HS Code">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>

                            <asp:BoundField DataField="CAT" HeaderText="CAT">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                            <%--<asp:BoundField DataField="Style_Photo" HeaderText="Name">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>--%>
                            <asp:TemplateField HeaderText="Image">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemTemplate>
                                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# "StyleImg.ashx?StyleId="+ Eval("StyleId") %>' Width="60%" />
                                </ItemTemplate>
                                <ItemStyle Width="4%" HorizontalAlign="Center" />
                                <ControlStyle CssClass="imgwd" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgButtonEidt" runat="server" ImageUrl="img/list_edit.png" OnClick="imgButtonEidt_Click" />
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
    </div>

    <script type="text/javascript">

        function func(result) {
            if (result === 'Style Saved Successfully') {
                toastr.success(result);
            }
            else if (result === 'Style Updated Successfully') {
                toastr.success(result);
            }
            else
                toastr.error(result);
            return false;
        }

    </script>
</asp:Content>
