<%@ Page Title="" Language="C#" MasterPageFile="~/Merchandising/Merchandising.Master" AutoEventWireup="true" CodeBehind="YarnCountDetermination.aspx.cs" Inherits="ERPSSL.Merchandising.YarnCountDetermination" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

    <script type="text/javascript">
        function successalert(result) {
            swal({
                title: result,
                type: 'success'
            });
        }

        function notsuccessalert(result) {
            swal({
                title: result,
                type: 'error'
            });
        }

        function updatealert() {
            swal({
                title: 'Congratulations!',
                text: 'File Name Update',
                type: 'success'
            });
        }

        function notupdatealert() {
            swal({
                title: 'Oops...!',
                text: 'File Name Not Update',
                type: 'error'
            });
        }

        function CommonRequiredFiledError(result) {
            swal({
                title: result,
                type: 'warning',
                timer: 1500,
                showConfirmButton: false
            });
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <script src="content/js/bootstrap-datetimepicker.js" type="text/javascript"></script>
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePageMethods="true" EnablePartialRendering="true" ID="ScriptManager1" />
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel4" ChildrenAsTriggers="true">

        <ContentTemplate>

            <div class="row">
                <div class="hm_sec_2_content scrollbar">
                    <div class="panel">
                        <div class="panel-heading panel-heading-01">
                            <i class="glyphicon glyphicon-edit icon-padding"></i>Yarn Count Determination
                        </div>
                    </div>

                    <div class="col-md-12">

                        <div class="row" style="padding-top: 10px;">

                            <div class="col-md-12" style="background-color: #fff; padding-bottom: 10px;">
                                <div class="col-md-3" style="padding-left: 0;">
                                    <div class="row">
                                        Fab Nature
                                        <asp:DropDownList ID="fabNatureDropDownList" class="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-md-3">

                                    <div class="row">
                                        Construction
                                           <%--<asp:TextBox ID="txtConstruction" runat="server" class="form-control"></asp:TextBox>--%>
                                        <asp:DropDownList ID="constructionDropDownList" class="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="constructionDropDownList_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-md-3">

                                    <div class="row">
                                        Color Range
                                          <asp:DropDownList ID="colorRangeDropDownList" class="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                </div>


                                <div class="col-md-3">
                                    <div class="row">
                                        GSM
                                           <asp:TextBox ID="gSMTextBox" runat="server" class="form-control"></asp:TextBox>
                                    </div>

                                </div>

                            </div>


                            <div class="col-md-12" style="padding-top: 5px;">
                                <table class="table table-bordered">
                                    <tr class="info">
                                        <td>Composition</td>
                                        <td>%</td>
                                        <td>Count</td>
                                        <td>Type</td>
                                        <td>Price</td>
                                        <td>UM</td>
                                        <td>Stich Length</td>
                                        <td>Process Loss</td>

                                    </tr>
                                    <tr>
                                        <td style="width: 150px;">
                                            <asp:DropDownList ID="compositionDropDownList" class="form-control" runat="server"></asp:DropDownList>
                                        </td>
                                        <td style="width: 150px;">
                                            <asp:TextBox ID="percentageTextBox" runat="server" class="form-control"></asp:TextBox>
                                        </td>
                                        <td style="width: 150px;">
                                            <asp:DropDownList ID="countDropDownList" class="form-control" runat="server" OnTextChanged="countDropDownList_TextChanged" AutoPostBack="true"></asp:DropDownList>
                                        </td>
                                        <td style="width: 150px;">
                                            <asp:DropDownList ID="typeDropDownList" class="form-control" runat="server" OnTextChanged="typeDropDownList_TextChanged" AutoPostBack="true"></asp:DropDownList>
                                        </td>

                                        <td style="width: 100px;">
                                            <asp:TextBox ID="priceTextBox" runat="server" class="form-control"></asp:TextBox></td>

                                        <td style="width: 100px;">
                                            <asp:DropDownList ID="UMDropDownList" class="form-control" runat="server"></asp:DropDownList></td>

                                        <td style="width: 100px;">
                                            <asp:TextBox ID="txtStichLength" Class="form-control" Text="0" runat="server"></asp:TextBox>
                                        </td>
                                        <td style="width: 100px;">
                                            <asp:TextBox ID="txtProcessLoss" runat="server" class="form-control"></asp:TextBox>
                                        </td>

                                    </tr>

                                </table>
                            </div>

                            <div class="col-md-12" style="padding-bottom: 10px;">
                                <div class="col-md-12">

                                    <div class="row" style="padding-top: 10px;">
                                        <asp:Button ID="addButton" runat="server" Text="Add" CssClass="btn btn-success pull-right" Style="width: 100px;" OnClick="addButton_Click" />
                                    </div>
                                </div>

                            </div>

                        </div>


                        <div class="row" style="padding-top: 10px;">
                        </div>

                        <div class="row" id="ShowGrid" runat="server" style="padding-top: 5px;">
                            <asp:HiddenField ID="yarnCountTypeIdHiddenField" runat="server" />
                            <div class="col-md-12" style="padding-left: 0; margin: auto 0;">
                                <div class="row" style="padding-left: 0; padding-top: 5px; margin: auto 0;">
                                    <fieldset style="margin: auto 0;">
                                        <legend style="line-height: 0px; padding-top: 5px;"><span style="background: #fff">Yarn Count Determination List</span></legend>
                                        <div class="row" style="overflow-x: hidden; overflow-y: scroll; max-height: 400px; height: auto; margin: auto 0;">
                                            <asp:GridView ID="grdorder" runat="server" AutoGenerateColumns="False" Width="100%"
                                                CellPadding="20" BackColor="White" BorderColor="#336666" BorderStyle="Solid"
                                                BorderWidth="1px" AllowPaging="false" EmptyDataText="No Data">
                                                <Columns>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center">
                                                        <HeaderTemplate>
                                                            SL No.
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSRNO" runat="server"
                                                                Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblYarnDetId" runat="server" Text='<%# Eval("YarnDeterminationId")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="FebricNature" HeaderText="Febric Nature">
                                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                        <ItemStyle HorizontalAlign="Left" CssClass="Grid_Border" />
                                                        <FooterStyle CssClass="Grid_Footer" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="ColorRange" HeaderText="Color Range">
                                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                        <ItemStyle HorizontalAlign="Left" CssClass="Grid_Border" />
                                                        <FooterStyle CssClass="Grid_Footer" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Construction" HeaderText="Construction">
                                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                        <ItemStyle HorizontalAlign="Left" CssClass="Grid_Border" />
                                                        <FooterStyle CssClass="Grid_Footer" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="GSM" HeaderText="GSM/Weight">
                                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                        <ItemStyle HorizontalAlign="Left" CssClass="Grid_Border" />
                                                        <FooterStyle CssClass="Grid_Footer" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="Composition" HeaderText="Composition">
                                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                        <ItemStyle HorizontalAlign="Left" CssClass="Grid_Border" />
                                                        <FooterStyle CssClass="Grid_Footer" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="YarnCount" HeaderText="Yarn Count">
                                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                        <ItemStyle HorizontalAlign="Left" CssClass="Grid_Border" />
                                                        <FooterStyle CssClass="Grid_Footer" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="Price" HeaderText="Price">
                                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                        <ItemStyle HorizontalAlign="Left" CssClass="Grid_Border" />
                                                        <FooterStyle CssClass="Grid_Footer" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="unitName" HeaderText="Unit">
                                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                        <ItemStyle HorizontalAlign="Left" CssClass="Grid_Border" />
                                                        <FooterStyle CssClass="Grid_Footer" />
                                                    </asp:BoundField>

                                                    <asp:TemplateField HeaderText="Edit">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="imgbtnYarnCountDetEdit" runat="server" ImageUrl="img/list_edit.png" OnClick="imgbtnYarnCountDetEdit_Click" />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                                                    </asp:TemplateField>

                                                </Columns>
                                                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                                                <EmptyDataRowStyle ForeColor="Red" />
                                                <RowStyle CssClass="Grid_RowStyle" BackColor="White" ForeColor="#333333" />
                                                <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                                <PagerSettings Mode="NumericFirstLast" />
                                                <PagerStyle ForeColor="White" HorizontalAlign="Left" BackColor="#336666" CssClass="pagination01 pageback" />
                                                <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" BackColor="#336666" Font-Bold="True" ForeColor="White" />
                                                <FooterStyle CssClass="Grid_Footer" BackColor="White" ForeColor="#333333" />
                                                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                                <SortedAscendingHeaderStyle BackColor="#487575" />
                                                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                                <SortedDescendingHeaderStyle BackColor="#275353" />
                                            </asp:GridView>
                                        </div>
                                    </fieldset>
                                </div>
                            </div>
                        </div>


                    </div>


                    <div class="col-md-12" style="padding-top: 5px;">
                        <table class="table table-bordered">
                            <tr class="info">
                                <td>Construction / Finish Febric</td>
                                <td>Kniting Cost</td>
                                <td>Drying Cost</td>
                                <td>Total Cost</td>

                            </tr>
                            <tr>
                                <td style="width: 150px;">
                                    <asp:TextBox ID="constructionFinishFebricTextBox" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                </td>
                                <td style="width: 150px;">
                                    <asp:TextBox ID="kinitingCostTextBox" runat="server" Text="0" class="form-control" OnTextChanged="kinitingCostTextBox_TextChanged" AutoPostBack="true"></asp:TextBox>
                                </td>
                                <td style="width: 150px;">

                                    <div class="row">
                                        <div class="col-md-6" style="padding: 0px;">
                                            <asp:DropDownList ID="dryingCostDropDownList" class="form-control" Width="90%" runat="server">

                                                <asp:ListItem>---Select---</asp:ListItem>
                                                <asp:ListItem>Engyme</asp:ListItem>
                                                <asp:ListItem>NonEngyme</asp:ListItem>

                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-md-6" style="padding: 0px;">
                                            <asp:TextBox ID="dryingCostTextBox" Class="form-control" Text="0" Width="90%" runat="server" OnTextChanged="dryingCostTextBox_TextChanged" AutoPostBack="true"></asp:TextBox>
                                        </div>
                                    </div>
                                </td>
                                <td style="width: 100px;">
                                    <asp:TextBox ID="totalTextBox" Class="form-control" Text="0" runat="server"></asp:TextBox>
                                </td>

                            </tr>

                        </table>
                    </div>


                    <div class="col-md-12" style="padding-bottom: 10px;">
                        <div class="col-md-12">

                            <div class="row" style="padding-top: 5px;">
                                <asp:Button ID="confirmButton" runat="server" Text="Confirm" CssClass="btn btn-success pull-right" Style="width: 100px;" OnClick="confirmButton_Click" />
                            </div>
                        </div>

                    </div>



                    <div class="row" id="Div1" runat="server" style="padding-top: 5px;">
                        <asp:HiddenField ID="HiddenField" runat="server" />
                        <div class="col-md-12" style="padding-left: 0; margin: auto 0;">
                            <div class="row" style="padding-left: 0; padding-top: 5px; margin: auto 0;">

                                <asp:Panel ID="Panel1" runat="server" BackColor="#99CCFF">


                                    <fieldset style="margin: auto 0;">
                                        <%--<legend style="line-height: 0px; padding-top: 5px;"><span style="background: #fff">Yarn Count Determination List</span></legend>--%>

                                        <div class="row" style="padding-top: 10px;">

                                            <div class="col-md-12" style="background-color: #99CCFF; padding-bottom: 10px;">
                                                <div class="col-md-3" style="padding-left: 0;">
                                                    <div class="row">
                                                        Construction
                                                    <asp:TextBox ID="constructionSearchTextBox" runat="server" class="form-control" AutoPostBack="True" OnTextChanged="constructionSearchTextBox_TextChanged"></asp:TextBox>
                                                        <cc1:AutoCompleteExtender ServiceMethod="SearchConstruction"
                                                            MinimumPrefixLength="1"
                                                            CompletionInterval="100" EnableCaching="False"
                                                            TargetControlID="constructionSearchTextBox"
                                                            ID="AutoCompleteExtender1" runat="server" DelimiterCharacters="" Enabled="True" ServicePath="">
                                                        </cc1:AutoCompleteExtender>
                                                    </div>
                                                </div>

                                                <div class="col-md-3">

                                                    <div class="row">
                                                        GSM / Weight
                                                    <asp:TextBox ID="gsmWeightSearchTextBox" runat="server" class="form-control" AutoPostBack="True" OnTextChanged="gsmWeightSearchTextBox_TextChanged"></asp:TextBox>
                                                        <cc1:AutoCompleteExtender ServiceMethod="SearchGSMWeight"
                                                            MinimumPrefixLength="1"
                                                            CompletionInterval="100" EnableCaching="False"
                                                            TargetControlID="gsmWeightSearchTextBox"
                                                            ID="AutoCompleteExtender2" runat="server" DelimiterCharacters="" Enabled="True" ServicePath="">
                                                        </cc1:AutoCompleteExtender>
                                                    </div>
                                                </div>

                                                <div class="col-md-3">

                                                    <div class="row">
                                                        Composition %
                                                <asp:TextBox ID="compostionSearchTextBox" runat="server" class="form-control" AutoPostBack="True" OnTextChanged="compostionSearchTextBox_TextChanged"></asp:TextBox>
                                                        <cc1:AutoCompleteExtender ServiceMethod="SearchComposition"
                                                            MinimumPrefixLength="1"
                                                            CompletionInterval="100" EnableCaching="False"
                                                            TargetControlID="compostionSearchTextBox"
                                                            ID="AutoCompleteExtender3" runat="server" DelimiterCharacters="" Enabled="True" ServicePath="">
                                                        </cc1:AutoCompleteExtender>
                                                    </div>
                                                </div>

                                            </div>

                                        </div>

                                        <div class="row" style="overflow-x: hidden; overflow-y: scroll; max-height: 400px; height: auto; margin: auto 0;">
                                            <asp:GridView ID="YarnDeterminationGridView" runat="server" AutoGenerateColumns="False" Width="100%"
                                                CellPadding="20" BackColor="White" BorderColor="#336666" BorderStyle="Solid"
                                                BorderWidth="1px" AllowPaging="false" EmptyDataText="No Data">
                                                <Columns>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center">
                                                        <HeaderTemplate>
                                                            SL No.
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSRNO" runat="server"
                                                                Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblUniqueId" runat="server" Text='<%# Eval("UniqueId")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="FabricNature" HeaderText="Febric Nature">
                                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                        <ItemStyle HorizontalAlign="Left" CssClass="Grid_Border" />
                                                        <FooterStyle CssClass="Grid_Footer" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="GroupName" HeaderText="Contruction">
                                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                        <ItemStyle HorizontalAlign="Left" CssClass="Grid_Border" />
                                                        <FooterStyle CssClass="Grid_Footer" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="GSM" HeaderText="GSM/Weight">
                                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                        <ItemStyle HorizontalAlign="Left" CssClass="Grid_Border" />
                                                        <FooterStyle CssClass="Grid_Footer" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="ColorName" HeaderText="Color Name">
                                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                        <ItemStyle HorizontalAlign="Left" CssClass="Grid_Border" />
                                                        <FooterStyle CssClass="Grid_Footer" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="CompostionPercentage" HeaderText="Compostion %">
                                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                        <ItemStyle HorizontalAlign="Left" CssClass="Grid_Border" />
                                                        <FooterStyle CssClass="Grid_Footer" />
                                                    </asp:BoundField>

                                                    <%--  <asp:BoundField DataField="Composition" HeaderText="Composition">
                                                         <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                         <ItemStyle HorizontalAlign="Left" CssClass="Grid_Border" />
                                                         <FooterStyle CssClass="Grid_Footer" />
                                                     </asp:BoundField>
                                                     <asp:BoundField DataField="YarnCount" HeaderText="Yarn Count">
                                                         <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                         <ItemStyle HorizontalAlign="Left" CssClass="Grid_Border" />
                                                         <FooterStyle CssClass="Grid_Footer" />
                                                     </asp:BoundField>

                                                     <asp:BoundField DataField="Price" HeaderText="Price">
                                                         <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                         <ItemStyle HorizontalAlign="Left" CssClass="Grid_Border" />
                                                         <FooterStyle CssClass="Grid_Footer" />
                                                     </asp:BoundField>
                                                     <asp:BoundField DataField="unitName" HeaderText="Unit">
                                                         <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                                         <ItemStyle HorizontalAlign="Left" CssClass="Grid_Border" />
                                                         <FooterStyle CssClass="Grid_Footer" />
                                                     </asp:BoundField>--%>

                                                    <asp:TemplateField HeaderText="Edit">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="imgbtnYarnCountDetEdit2" runat="server" ImageUrl="img/list_edit.png" OnClick="imgbtnYarnCountDetEdit2_Click" />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                                                    </asp:TemplateField>

                                                </Columns>
                                                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                                                <EmptyDataRowStyle ForeColor="Red" />
                                                <RowStyle CssClass="Grid_RowStyle" BackColor="White" ForeColor="#333333" />
                                                <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                                <PagerSettings Mode="NumericFirstLast" />
                                                <PagerStyle ForeColor="White" HorizontalAlign="Left" BackColor="#336666" CssClass="pagination01 pageback" />
                                                <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" BackColor="#336666" Font-Bold="True" ForeColor="White" />
                                                <FooterStyle CssClass="Grid_Footer" BackColor="White" ForeColor="#333333" />
                                                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                                <SortedAscendingHeaderStyle BackColor="#487575" />
                                                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                                <SortedDescendingHeaderStyle BackColor="#275353" />
                                            </asp:GridView>
                                        </div>
                                    </fieldset>


                                </asp:Panel>


                            </div>
                        </div>
                    </div>


                </div>
            </div>



        </ContentTemplate>

    </asp:UpdatePanel>


</asp:Content>

