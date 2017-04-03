<%@ Page Title="" Language="C#" MasterPageFile="~/LC/Site.Master" AutoEventWireup="true" CodeBehind="BuyerSetup.aspx.cs" Inherits="ERPSSL.LC.BuyerSetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <div class="hm_sec_2_content scrollbar">
        <div class="panel">
            <div class="panel-heading panel-heading-01">
                <i class="fa fa-edit fa-fw icon-padding"></i>Buyer Setup 
            </div>
        </div>
        <div class="row">
            <div class="col-md-12 bg-success">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </div>
            <div class="col-md-12">
                <div class="col-md-5" style="background-color: #a7c5a7; padding-bottom: 10px; margin:auto 0;">
                    <div class="row" style="margin: auto 0;">
                        <div class="col-md-6" style="padding-left:0;">
                            <div class="row" style="padding-top: 5px;">
                                Buyer Type
                                <a style="color: red; font-size: 11px">*</a>
                                <asp:DropDownList ID="drpBuyerType" class="form-control"
                                    runat="server">
                                    <asp:ListItem Text="--- Select --- " Value="0"></asp:ListItem>
                                    <asp:ListItem>Foreign</asp:ListItem>
                                    <asp:ListItem>Local</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="Group1"
                                    runat="server" ControlToValidate="drpBuyerType" ErrorMessage="Buyer Type"
                                    InitialValue="0"></asp:RequiredFieldValidator>
                            </div>

                            <div class="row" style="padding-top: 5px;">
                                Buyer Name
                                <a style="color: red; font-size: 11px">*</a>
                                <asp:TextBox ID="txtbxBuyerName" runat="server" class="form-control"></asp:TextBox>
                                <asp:HiddenField ID="hidBueyId" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtbxBuyerName"
                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Buyer Name"
                                    ValidationGroup="Group1"></asp:RequiredFieldValidator>
                            </div>

                            <div class="row" style="padding-top: 5px;">
                                Country
                                    <asp:DropDownList ID="drpCountery" class="form-control"
                                        runat="server">
                                        <asp:ListItem Text="--- Select --- " Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Group1"
                                    runat="server" ControlToValidate="drpCountery" ErrorMessage="Select Countery" InitialValue="0"></asp:RequiredFieldValidator>
                            </div>
                            <div class="row" style="padding-top: 5px;">
                                Contact Person
                                 <a style="color: red; font-size: 11px">*</a>
                                <asp:TextBox ID="txtbxContractPerson" runat="server" class="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtbxContractPerson"
                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Contract Person"
                                    ValidationGroup="Group1"></asp:RequiredFieldValidator>
                            </div>

                            <div class="row" style="padding-top: 5px;">
                                Cell No.
                                    <asp:TextBox ID="txtbxCellNo" runat="server" class="form-control"></asp:TextBox>
                            </div>
                            <div class="row" style="padding-top: 5px;">
                                Phone No.
                                    <asp:TextBox ID="txtbxPhone" runat="server" class="form-control"></asp:TextBox>
                            </div>
                            <div class="row" style="padding-top: 5px;">
                                E-mail
                                    <asp:TextBox ID="txtEmail" runat="server" class="form-control"></asp:TextBox>
                            </div>
                            <div class="row" style="padding-top: 5px;">
                                Buyer Address                              
                                    <asp:TextBox ID="txtBuyerAddress" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                            </div>

                        </div>
                        <div class="col-md-6">
                            <div class="row" style="padding-top: 5px;">
                                Consignee
                                    <asp:TextBox ID="txtConsignee" runat="server" class="form-control"></asp:TextBox>
                            </div>

                            <div class="row" style="padding-top: 5px;">
                                Notify Party
                                    <asp:TextBox ID="txtNotifyParty" runat="server" class="form-control"></asp:TextBox>
                            </div>
                            <div class="row" style="padding-top: 5px;">
                                Address                              
                                    <asp:TextBox ID="txtbxAddress" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                            </div>

                            <div class="row" style="padding-top: 5px;">
                                Delivery Address                              
                                    <asp:TextBox ID="txtDeliveryAddress" runat="server" class="form-control" TextMode="MultiLine" Height="150%"></asp:TextBox>
                            </div>

                            <div class="row" style="padding-top: 5px;">
                                Destination Address                              
                                    <asp:TextBox ID="txtDestinationAddress" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                            </div>


                            <div class="row" style="padding-top: 5px;">
                                Status
                                 <a style="color: red; font-size: 11px">*</a>

                                <asp:DropDownList ID="drpSataus" class="form-control"
                                    runat="server">
                                    <asp:ListItem Text="--- Select --- " Value="0"></asp:ListItem>
                                    <asp:ListItem>True</asp:ListItem>
                                    <asp:ListItem>False</asp:ListItem>
                                </asp:DropDownList>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="Group1"
                                    runat="server" ControlToValidate="drpSataus" ErrorMessage="Select Status"
                                    InitialValue="0"></asp:RequiredFieldValidator>
                            </div>
                            <div class="row" style="padding-top: 5px;">
                                Land Address                              
                                    <asp:TextBox ID="txtLandAddress" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                            </div>
                            <div class="row" style="padding-top: 5px;">
                                Sea Address                              
                                    <asp:TextBox ID="txtSeaAddress" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                            </div>

                            <div class="row" style="padding-top: 5px;">
                                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" ValidationGroup="Group1" Text="Submit" class="btn btn-info  pull-right" /><%--OnClick="btnSave_Click"--%>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-md-7">

                    <asp:GridView ID="grdBuyer" runat="server" AutoGenerateColumns="False" Width="100%"
                        CellPadding="5" AllowPaging="false" PageSize="100">
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

                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center">
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
                                    <asp:Label ID="lblByerId" runat="server" Text='<%# Eval("Buyer_ID")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="Buyer_Name" HeaderText="Name">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>

                            <asp:BoundField DataField="Contact_Person" HeaderText="Con.Person">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>

                            <asp:BoundField DataField="Mobile" HeaderText="Mobile">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>

                            <asp:BoundField DataField="Phone" HeaderText="Phone">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>


                            <asp:BoundField DataField="Address" HeaderText="Address">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>

                            <%---%>

                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgButtonEidt" runat="server" ImageUrl="img/list_edit.png" OnClick="imgButtonEidt_Click" />
                                </ItemTemplate>
                                <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
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

    <script type="text/JavaScript">

        function func(result) {
            if (result === 'Buyer Saved Successfully') {
                toastr.success(result);
            }
            else if (result === 'Buyer Updated Successfully') {
                toastr.success(result);
            }
            else
                toastr.error(result);

            return false;
        }

    </script>
</asp:Content>
