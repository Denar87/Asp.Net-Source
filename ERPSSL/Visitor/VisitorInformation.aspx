<%@ Page Title="" Language="C#" MasterPageFile="~/Visitor/Visitor_Site.Master" AutoEventWireup="true" CodeBehind="VisitorInformation.aspx.cs" Inherits="ERPSSL.Visitor.VisitorInformation" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
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
                            <i class="glyphicon glyphicon-edit icon-padding"></i>Visitor Information  (
                            <asp:Label ID="lbldate" runat="server"></asp:Label>
                            <%-- <asp:Label ID="WorkOrder" runat="server" ForeColor="#009900"></asp:Label>,
                            <asp:Label ID="StyleId" runat="server" Text="" Visible="false"></asp:Label>
                            <asp:Label ID="Style" runat="server" ForeColor="#000066"></asp:Label>,
                            <asp:Label ID="BuyerId" runat="server" Text="" Visible="false"></asp:Label>
                            <asp:Label ID="Buyer" runat="server" Text="" ForeColor="#660066"></asp:Label>,
                            <asp:Label ID="OrderQuantity" runat="server" Text="" ForeColor="#993366"></asp:Label>--%>
                            )
                            <%--<a href="NewOrderEntry.aspx"><img src="img/left arrow9.png" height="22px;" class="right"/></a>--%>
                        </div>
                    </div>
                    <div class="col-md-12 bg-success">
                        <center>
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label></center>
                        <asp:HiddenField ID="hidvisitorid" runat="server" />
                    </div>
                    <div class="col-md-12" style="margin-top: 10px;">
                        <%--<fieldset>--%>

                        <%--</fieldset>--%>



                        <div class="col-md-12" style="padding-top: 5px;">
                            <table class="table table-bordered">
                                <tr class="info">
                                    <td>Visitor Name   
                                    </td>
                                    <td>From/Address                               
                                    </td>
                                    <td>Phone                                
                                    </td>
                                    <td>To Whom                                   
                                    </td>
                                    <td>purpose                                   
                                    </td>
                                    <td>Card No</td>
                                    <td>In time</td>
                                    <td>Out Time</td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td style="width: 150px">
                                        <%-- <asp:DropDownList ID="gmtItemDropDownList" runat="server" Class="form-control"></asp:DropDownList>
                                        <asp:TextBox ID="gmtItemTextBox" Text="" Style="color: maroon" Class="form-control" runat="server" Visible="false"></asp:TextBox>--%>
                                        <asp:TextBox ID="txtVisitorName" Text="" Style="color: maroon" Class="form-control" runat="server"></asp:TextBox>
                                    </td>
                                    <td style="width: 150px">
                                        <asp:TextBox ID="txtformAddress" Text="" Style="color: maroon" Class="form-control" runat="server"></asp:TextBox>
                                    </td>
                                    <td style="width: 130px">
                                        <asp:TextBox ID="txtPhone" Text="" Style="color: maroon" Class="form-control" runat="server"></asp:TextBox>
                                    </td>
                                    <td style="width: 150px">
                                        <asp:TextBox ID="txtToWhom" Text="" Style="color: maroon" Class="form-control" runat="server"></asp:TextBox>
                                    </td>
                                    <td style="width: 150px">
                                        <asp:TextBox ID="txtPurpose" Text="" Style="color: maroon" Class="form-control" runat="server"></asp:TextBox>
                                    </td>
                                    <td style="width: 80px">
                                        <asp:TextBox ID="txtcardNo" Class="form-control" Text="" runat="server" AutoPostBack="True"></asp:TextBox>
                                    </td>
                                    <td style="width: 80px">
                                        <asp:TextBox ID="txtInTime" Class="form-control" Text="" runat="server"></asp:TextBox>
                                    </td>
                                    <td style="width: 80px">
                                        <asp:TextBox ID="txtOutTime" Class="form-control" Text="" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                                    </td>


                                </tr>
                            </table>
                        </div>
                        <div class="row" style="float: right; padding-right: 43px;">
                        </div>

                    </div>
                    <br />
                    <div class="row" style="float: right; padding-right: 43px; padding-left: 30px;">
                        <asp:GridView ID="grVisitorInfo" runat="server" AutoGenerateColumns="False" Width="100%"
                            CellPadding="20" BackColor="White" BorderColor="#336666" BorderStyle="Solid"
                            BorderWidth="1px">
                            <Columns>

                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="8%" HeaderStyle-HorizontalAlign="Center">
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
                                        <asp:Label ID="lblV_ID" runat="server" Text='<%# Eval("V_ID")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="VisitorName" HeaderText="Visitor Name">
                                    <ItemStyle HorizontalAlign="left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ToWhom" HeaderText="To Whom">
                                    <ItemStyle HorizontalAlign="left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Phone" HeaderText="Phone">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>

                                <asp:BoundField DataField="Purpose" HeaderText="Purpose">
                                    <ItemStyle HorizontalAlign="left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CardNo" HeaderText="Card No">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>

                                <asp:BoundField DataField="InTime" HeaderText="InTime">
                                     <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="OutTime" HeaderText="OutTime">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>

                                <asp:TemplateField HeaderText="Update">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgbtnVisitorEdit" runat="server" ImageUrl="~/Visitor/img/list_edit.png"
                                            OnClick="imgbtnVisitorEdit_Click" />
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

                </div>

            </div>

           
        </ContentTemplate>
    </asp:UpdatePanel>
    <script>

        function func(result) {

            if (result === 'Data Insert Successfully') {
                toastr.success(result);
            }

            else if (result === 'Data Update Successfully') {
                toastr.success(result);

            }

            return false;
        }

    </script>

</asp:Content>
