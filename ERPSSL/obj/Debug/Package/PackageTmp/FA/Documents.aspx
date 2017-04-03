<%@ Page Title="" Language="C#" MasterPageFile="~/FA/Site.Master" AutoEventWireup="true"
    CodeBehind="Documents.aspx.cs" Inherits="ERPSSL.FA.Documents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">


    <div class="row">
        <div class="hm_sec_2_content scrollbar">
            <div class="panel">
                <div class="panel-heading panel-heading-01">
                    <i class="fa fa-edit fa-fw icon-padding"></i>Documents
                </div>
            </div>


            <div class="col-md-12 bg-success">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
                <asp:Label ID="lblStatus" runat="server" ForeColor="#CC3300"></asp:Label>
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
                                        <asp:DropDownList ID="ddlRegion" CssClass="form-control" runat="server"
                                            AutoPostBack="True" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-5">
                                        Office
                                    </div>
                                    <div class="col-md-7">
                                        <asp:DropDownList ID="ddlOffice" CssClass="form-control" runat="server"
                                            AutoPostBack="True" OnSelectedIndexChanged="ddlOffice_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-5">
                                        Department
                                    </div>
                                    <div class="col-md-7">
                                        <asp:DropDownList ID="ddlDepartment" CssClass="form-control" runat="server"
                                            AutoPostBack="True" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-5">
                                        User
                                    </div>
                                    <div class="col-md-7">
                                        <asp:DropDownList ID="ddlUser" CssClass="form-control" runat="server"
                                            AutoPostBack="True" OnSelectedIndexChanged="ddlUser_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-5">
                                        Asset
                                    </div>
                                    <div class="col-md-7">
                                        <asp:DropDownList ID="ddlAsset" CssClass="form-control" runat="server"
                                            AutoPostBack="True" OnSelectedIndexChanged="ddlAsset_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Asset Code
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtAssetCode" CssClass="form-control" runat="server"
                                                AutoPostBack="True" OnTextChanged="txtAssetCode_TextChanged"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                ControlToValidate="txtAssetCode" SetFocusOnError="True" ValidationGroup="Doc"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            File Type
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="ddlFileType" CssClass="form-control" runat="server">
                                                <asp:ListItem Value="">-Select One-</asp:ListItem>
                                                <asp:ListItem Value="Photo1">Photo1</asp:ListItem>
                                                <asp:ListItem Value="Photo2">Photo2</asp:ListItem>
                                                <asp:ListItem Value="Photo3">Photo3</asp:ListItem>
                                                <asp:ListItem Value="Document">Document</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                ControlToValidate="ddlFileType" SetFocusOnError="True" ValidationGroup="Doc"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Attach
                                        </div>
                                        <div class="col-md-7">
                                            <asp:FileUpload ID="uplAttachment" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            Remarks
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtRemarks" CssClass="form-control" runat="server" TextMode="MultiLine"
                                                Height="100px"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            <asp:HiddenField ID="hdfDocuments" runat="server" />
                                        </div>
                                        <div class="col-md-7">
                                            <asp:Button ID="btnUpload" runat="server" Text="Upload" class="btn btn-info"
                                                OnClick="btnUpload_Click" ValidationGroup="Doc" />
                                        </div>
                                    </div>
                                </div>
                                <br />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-4">
                                <asp:Image ID="Image1" runat="server" Height="200px" Width="200px" ImageUrl="img/NoPhoto.jpg" CssClass="img-thumbnail" />
                            </div>
                            <div class="col-md-4">
                                <asp:Image ID="Image2" runat="server" Height="200px" Width="200px" AlternateText="Photo 2" ImageUrl="img/NoPhoto.jpg" CssClass="img-thumbnail" />
                            </div>
                            <div class="col-md-4">
                                <asp:Image ID="Image3" runat="server" Height="200px" Width="200px" AlternateText="Photo 3" ImageUrl="img/NoPhoto.jpg" CssClass="img-thumbnail" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <div class="row" id="FindingAsset" runat="server">

                <div class="col-md-12">

                    <fieldset>
                        <legend style="line-height: 0;"><span style="background: #fff; font-weight: 600;">Find
                                Asset</span></legend>
                        <asp:Label ID="lblAssetCode" runat="server" Font-Bold="True" Font-Size="Larger"></asp:Label>
                        <div style="width: 95%">
                            <hr />
                        </div>
                        <div style="background-color: #F1F0F0;" runat="server">

                            <div style="float: left; width: 35%;">
                                <asp:Label ID="lblAsset" runat="server" Font-Bold="True"></asp:Label><br />
                                <asp:Label ID="lblGroup" runat="server" Font-Bold="True"></asp:Label><br />
                                <asp:Label ID="lblUser" runat="server" Text=""></asp:Label><br />
                                <asp:Label ID="lblDepartment" runat="server" Text=""></asp:Label><br />
                                <asp:Label ID="lblOffice" runat="server" Text=""></asp:Label><br />
                                <asp:Label ID="lblRegion" runat="server" Text=""></asp:Label><br />
                            </div>
                            <div style="float: left; width: 60%;">
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="AccTax" runat="server" Text="As Per"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Tax" runat="server" Text="Accounting" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label5" runat="server" Text="Tax" Font-Bold="True"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text="A/C Balance" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblACClosingBalance" runat="server" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblACClosingBalanceTax" runat="server" Font-Bold="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text="Acc. Dep. Balance" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblADClosingBalance" runat="server" Font-Bold="False"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblADClosingBalanceTax" runat="server" Font-Bold="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label3" runat="server" Text="Rev. Rsrv. Balance" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblRRClosingBalance" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblRRClosingBalanceTax" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label4" runat="server" Text="Method" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblMethod" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblMethodTax" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div style="clear: both;">
                            <div style="width: 95%">
                                <hr />
                            </div>
                        </div>


                    </fieldset>
                </div>

            </div>
            <br />
            <div class="row">
                <div class="col-md-12">
                    <asp:GridView ID="grdDocuments" runat="server" ShowFooter="True" Width="80%"
                        AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" CellPadding="5"
                        BorderColor="#99CCFF" BorderStyle="Solid" CssClass="Grid_Border" ForeColor="#339933"
                        OnPageIndexChanging="grdDocuments_PageIndexChanging" PageSize="5">
                        <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                        <Columns>
                            <asp:TemplateField HeaderText="DocId">
                                <ItemTemplate>
                                    <asp:Label ID="DocId" runat="server" Text='<%# Eval("DocId")%>' />
                                </ItemTemplate>
                                <FooterStyle CssClass="Grid_Footer" />
                                <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" VerticalAlign="Middle"
                                    Width="4%" />
                            </asp:TemplateField>

                            <asp:BoundField DataField="FileName" HeaderText="FileName ">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="14%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Remarks" HeaderText="Remarks">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="14%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>


                            <asp:TemplateField HeaderText="Option">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink1" Target="_blank" runat="server" NavigateUrl='<%# Bind("Link")%>'
                                        Text="Download">
                                    </asp:HyperLink>
                                    <asp:ImageButton ID="ImgBtnDelete" OnClick="imgbtnDelete_Clik" runat="server" ImageUrl="../FA/img/remove.png" />
                                </ItemTemplate>
                                <FooterStyle CssClass="Grid_Footer" />
                                <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" Width="11%" />
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataRowStyle ForeColor="Red" />
                        <PagerSettings Mode="NumericFirstLast" />
                        <PagerStyle CssClass="pagination01 pageback" />
                        <RowStyle CssClass="Grid_RowStyle" />
                    </asp:GridView>
                </div>
            </div>

        </div>
    </div>

</asp:Content>
