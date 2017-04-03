<%@ Page Title="" Language="C#" MasterPageFile="~/BuyingHouse/BuyingSite.Master" AutoEventWireup="true" CodeBehind="PendingList.aspx.cs" Inherits="ERPSSL.BuyingHouse.PendingList" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <%--<asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>--%>
    <div class="row">
        <div class="hm_sec_2_content scrollbar">
            <div class="panel">
                <div class="panel-heading panel-heading-01">
                    <i class="glyphicon glyphicon-edit icon-padding"></i>Order Status
                </div>
            </div>
            <div class="col-md-12 bg-success">
                <asp:HiddenField ID="hidLcNo" runat="server" />
                <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label>
                <asp:Label ID="lblMessageUpdate" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label>
            </div>

            <div class="col-md-12">
                <%--  <div class="row" style="margin-top: 5px">
                     <div class="col-md-4">
                        <div class="col-md-3">Order No</div>
                        <div class="col-md-9">
                            <asp:TextBox ID="txtOrderNo" runat="server" OnTextChanged="txtOrderNo_TextChanged" AutoPostBack="true" class="form-control"></asp:TextBox>
                            <cc1:AutoCompleteExtender ServiceMethod="SearchLCNo"
                                MinimumPrefixLength="1"
                                CompletionInterval="100" EnableCaching="False"
                                TargetControlID="txtOrderNo"
                                ID="AutoCompleteExtender2" runat="server" DelimiterCharacters="" Enabled="True" ServicePath="">
                            </cc1:AutoCompleteExtender>
                            <asp:Label ID="lblSeason" runat="server" Text="Label" Visible="false"></asp:Label>
                        </div>
                    </div>
                </div>--%>

                <div class="row" style="margin-top: 5px">


                    <div class="col-md-12" style="padding-bottom: 10px;">


                        <div class="col-md-8" style="overflow-x: hidden; overflow-y: hidden; max-height: 400px; height: auto">
                            <asp:GridView ID="GridPendingList" runat="server" AutoGenerateColumns="False" Width="100%"
                                CellPadding="20" BackColor="White" BorderColor="#336666" BorderStyle="Solid"
                                BorderWidth="1px" AllowPaging="false">
                                <Columns>
                                    <%-- <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox runat="server" ID="headerTaskCheckBox" AutoPostBack="true" OnCheckedChanged="headerTaskCheckBox_CheckedChanged" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="rowTaskCheckBox" runat="server" />
                                        <headerstyle verticalalign="Middle" cssclass="Grid_Header" />
                                        <itemstyle horizontalalign="Left" width="2%" cssclass="Grid_Border" />
                                        <footerstyle cssclass="Grid_Footer" />
                                    </ItemTemplate>
                                </asp:TemplateField>--%>

                                    <%-- <asp:BoundField DataField="Sl_No" HeaderText="Sl No.">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                    </asp:BoundField>--%>
                                    <%--  <asp:TemplateField Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblInput_Name" runat="server" Text='<%# Eval("Input_Name")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>

                                    <asp:TemplateField Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOrder_No" runat="server" Text='<%# Eval("Order_No")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="Order_No" HeaderText="Order">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Width="20%" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Task_Number" HeaderText=" Pending Task Number">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Width="20%" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Status" HeaderText=" Status">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Width="20%" />
                                    </asp:BoundField>

                                  <%--  <asp:BoundField DataField="Schedule_Date" HeaderText=" Schedule Date">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Width="20%" />
                                    </asp:BoundField>--%>


                                    <asp:TemplateField HeaderText="Update">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgbtnPendingOrderEdit" runat="server" ImageUrl="~/LC/img/list_edit.png"
                                                OnClick="imgbtnPendingOrderEdit_Click" />
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
                                <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" BackColor="#336666"
                                    Font-Bold="True" ForeColor="White" />
                                <FooterStyle CssClass="Grid_Footer" BackColor="White" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                <SortedAscendingHeaderStyle BackColor="#487575" />
                                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                <SortedDescendingHeaderStyle BackColor="#275353" />
                            </asp:GridView>
                        </div>

                        <div class="col-md-16">
                        </div>




                    </div>


                </div>
                <div class="col-md-12" style="max-height: 400px; height: auto">
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" class="btn btn-info pull-right" Visible="false" ValidationGroup="Group1" OnClick="btnUpdate_Click" />
                </div>
            </div>


        </div>
    </div>

    <script type="text/javascript">
        function func(result) {
            if (result === 'Data Saved Successfully') {
                toastr.success(result);

            }
            else if (result === 'Data Post Successfully !') {
                toastr.success(result);
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
