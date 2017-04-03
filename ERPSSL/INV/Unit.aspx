<%@ Page Title="" Language="C#" MasterPageFile="~/INV/Site.Master" AutoEventWireup="true"
    CodeBehind="Unit.aspx.cs" Inherits="ERPSSL.INV.Unit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <%--<asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>--%>
    <div class="row">


        <div class="hm_sec_2_content scrollbar">
            <div class="panel">
                <div class="panel-heading panel-heading-01">
                    <i class="glyphicon glyphicon-edit icon-padding"></i>Unit
                </div>
            </div>
            <div class="col-md-12 bg-success">
                <center>
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label></center>
            </div>
            <div class="row">
                <div class="col-md-12" style="margin: auto 0;">
                    <div class="col-md-6" style="margin: auto 0;">
                        <div class="row">
                            <div class="col-md-4">
                                Unit Name
                            </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtUnitName" runat="server" class="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtUnitName"
                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Enter Unit Name"
                                    Font-Size="11px" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="row" style="padding-top:5px;">
                            <div class="col-md-4">
                                <asp:HiddenField ID="hdfUnitID" runat="server" />
                            </div>
                            <div class="col-md-8">
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-info pull-right"
                                    ValidationGroup="Group1" OnClick="btnSubmit_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6" style="margin: auto 0;">
                        <div class="row">
                            <asp:GridView ID="grdUnit" runat="server" Width="95%"
                                AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" CellPadding="5"
                                BorderColor="#E3F0FC" BorderStyle="Solid" CssClass="Grid_Border" ForeColor="#339933"
                                PageSize="10" OnPageIndexChanging="grdUnit_PageIndexChanging">
                                <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                <Columns>
                                    <asp:TemplateField Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUnitId" runat="server" Text='<%# Eval("UnitId")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="UnitName" HeaderText="Unit Name">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImgUnitEdit" runat="server" ImageUrl="img/list_edit.png" OnClick="ImgUnitEdit_Click" />
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
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
    <script>

        function func(result) {
            if (result === 'Data Saved Successfully') {
                toastr.success(result);

            }
            else if (result === 'Data Saving Failure') {
                toastr.error(result);
            }
            else if (result === 'Data Already Exist') {
                toastr.error(result);
            }

            else if (result === 'Data Updated Sucessfully') {
                toastr.success(result);
            }
            else if (result === 'Data Updating failure') {
                toastr.error(result);
            }
            else
                toastr.error(result);

            return false;
        }

    </script>
</asp:Content>
