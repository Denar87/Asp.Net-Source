<%@ Page Title="" Language="C#" MasterPageFile="~/Merchandising/Merchandising.Master" AutoEventWireup="true" CodeBehind="OrderItems.aspx.cs" Inherits="ERPSSL.Merchandising.OrderItems" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        function SuccessAlert(result) {
            swal({
                title: result,
                type: 'success',
                timer: 1000,
                showConfirmButton: false
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
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>
            <div class="row">

                <div class="hm_sec_2_content scrollbar">
                    <div class="panel">
                        <div class="panel-heading panel-heading-01">
                            <i class="glyphicon glyphicon-edit icon-padding"></i>Order Color & Size  (
                            <asp:Label ID="WorkOrderId" runat="server" Text="" Visible="false"></asp:Label>
                            <asp:Label ID="WorkOrder" runat="server" ForeColor="#009900"></asp:Label>,
                            <asp:Label ID="StyleId" runat="server" Text="" Visible="false"></asp:Label>
                            <asp:Label ID="Style" runat="server" ForeColor="#000066"></asp:Label>,
                            <asp:Label ID="BuyerId" runat="server" Text="" Visible="false"></asp:Label>
                            <asp:Label ID="Buyer" runat="server" Text="" ForeColor="#660066"></asp:Label>,
                            <asp:Label ID="OrderQuantity" runat="server" Text="" ForeColor="#993366"></asp:Label>
                            )
                            <a href="NewOrderEntry.aspx"><img src="img/left arrow9.png" height="22px;" class="right"/></a>
                            
                        </div>
                    </div>
                    <div class="col-md-12 bg-success">
                        <center>
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label></center>
                    </div>
                    <div class="col-md-12" style="margin-top: 10px;">
                        <%--<fieldset>--%>

                        <%--</fieldset>--%>



                        <div class="col-md-12" style="padding-top: 5px;">
                            <table class="table table-bordered">
                                <tr class="info">
                                    <td>GMT Item 
                                        <span>
                                            <asp:CheckBox ID="gmtItemCheckBox" runat="server" AutoPostBack="True" OnCheckedChanged="gmtItemCheckBox_CheckedChanged" />
                                        </span>

                                    </td>
                                    <td>Article No
                               
                                    </td>
                                    <td>Color
                                
                                    </td>
                                    <td>Size
                                   
                                    </td>
                                    <td>Quantity
                                   
                                    </td>
                                    <td>Rate</td>
                                    <td>Total Amount</td>
                                    <td>Action</td>
                                </tr>
                                <tr>
                                    <td style="width: 200px">
                                        <asp:DropDownList ID="gmtItemDropDownList" runat="server" Class="form-control"></asp:DropDownList>
                                        <asp:TextBox ID="gmtItemTextBox" Text="" Style="color: maroon" Class="form-control" runat="server" Visible="false"></asp:TextBox>
                                    </td>
                                    <td style="width: 200px">
                                        <asp:TextBox ID="articleTextBox" Text="" Style="color: maroon" Class="form-control" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlcolor" Style="color: maroon" Class="form-control" runat="server"></asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="sizeTextBox" Text="" Style="color: maroon" Class="form-control" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="quantityTextBox" Text="" Style="color: maroon" Class="form-control" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="rateTextBox" Class="form-control" Text="" runat="server" OnTextChanged="rateTextBox_TextChanged" AutoPostBack="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="totalAmountTextBox" Class="form-control" Text="" Enabled="false" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="btnAdd_Click" />
                                    </td>


                                </tr>
                            </table>
                        </div>
                        <div class="row" style="float: right; padding-right: 30px;">
                        </div>

                    </div>
                    <br />

                    <asp:GridView ID="grdorder" runat="server" AutoGenerateColumns="False" Width="100%"
                        CellPadding="20" BackColor="White" BorderColor="#336666" BorderStyle="Solid"
                        BorderWidth="1px">
                        <Columns>

                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center">
                                <HeaderTemplate>
                                    Sl. No
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblSRNO" runat="server"
                                        Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" Width="3%" />
                            </asp:TemplateField>

                            <asp:TemplateField Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblSizeID" runat="server" Text='<%# Eval("SizeId")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>                            
                            <asp:BoundField DataField="OrderNo" HeaderText="Order No">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="GMTItemName" HeaderText="GMT Item Name">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ArticleNo" HeaderText="Article No">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Color" HeaderText="Color">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Size" HeaderText="Size">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                            <asp:BoundField DataField="Rate" HeaderText="Rate" />
                            <asp:BoundField DataField="TotalAmount" HeaderText="Total Amount" />
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgbtnDel" runat="server" ImageUrl="~/Merchandising/img/Alarm-Error-icon.png" OnClick="imgbtnDel_Click"/>
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

                    <div class="row" style="padding-top:10px;">
                         <div class="col-md-9">
                             
                             
                             
                         </div>
                       <%-- <div class="col-md-2">
                             <asp:Button ID="backButton" runat="server" Text="Back" Class="btn btn-info right" style="width:100px;" OnClick="backButton_Click"/>
                        </div>--%>
                        <div class="col-md-2">
                             <asp:Button ID="saveButton" runat="server" Text="Confirm"  Class="btn btn-success right" OnClick="saveButton_Click" style="width:100px;"/>
                        </div>
                    </div>
                    <br />

                    <div class="panel">
                        <div class="panel-heading panel-heading-01">
                            <i class="glyphicon glyphicon-certificate icon-padding"></i>All Confirmed Items
                        </div>
                    </div>

                    <asp:GridView ID="AllConfirmOrderGridView" runat="server" AutoGenerateColumns="False" Width="100%"
                        CellPadding="20" BackColor="White" BorderColor="#336666" BorderStyle="Solid"
                        BorderWidth="1px" ShowFooter="True" OnRowDataBound="AllConfirmOrderGridView_RowDataBound">
                        <Columns>

                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center">
                                <HeaderTemplate>
                                    Sl. No
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblSRNO" runat="server"
                                        Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" Width="3%" />
                            </asp:TemplateField>

                            <asp:TemplateField Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblSizeID" runat="server" Text='<%# Eval("SizeId")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>                            
                            <asp:BoundField DataField="OrderNo" HeaderText="Order No">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="GMTItemName" HeaderText="GMT Item Name">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ArticleNo" HeaderText="Article No">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Color" HeaderText="Color">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Size" HeaderText="Size">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Quantity" HeaderText="Quantity" >
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Rate" HeaderText="Rate" >
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TotalAmount" HeaderText="Total Amount" >
                           
                            <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                           
                        </Columns>
                        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                        <EmptyDataRowStyle ForeColor="Red" />
                        <RowStyle CssClass="Grid_RowStyle" BackColor="White" ForeColor="#333333" />
                        <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                        <PagerSettings Mode="NumericFirstLast" />
                        <PagerStyle ForeColor="White" HorizontalAlign="Left" BackColor="#336666" CssClass="pagination01 pageback" />
                        <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" BackColor="#333399" Font-Bold="True" ForeColor="White" />
                        <FooterStyle CssClass="Grid_Footer" BackColor="White" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#487575" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#275353" />
                    </asp:GridView>

                </div>
                <asp:HiddenField ID="hiddenCompanyType" runat="server" />
                <asp:HiddenField ID="hidId" runat="server" />
                <asp:HiddenField ID="hdnBrand" runat="server" />
                <asp:HiddenField ID="hdnStyle" runat="server" />
                <%--<asp:HiddenField ID="hdnProductName" runat="server" />--%>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <script>
        function func(result) {
            if (result === 'Purchase information posted successfully') {
                toastr.success(result);

            }
            else if (result === 'Data Update Successfully') {
                toastr.success(result);

            }
            else if (result === 'Purchase information has been added temporarily. Please post.') {
                toastr.success(result);
            }
            else
                toastr.error(result);
            return false;
        }

    </script>

</asp:Content>
