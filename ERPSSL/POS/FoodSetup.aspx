<%@ Page Title="" Language="C#" MasterPageFile="~/POS/Site.Master" AutoEventWireup="true" CodeBehind="FoodSetup.aspx.cs" Inherits="ERPSSL.POS.FoodSetup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
     <div class="hm_sec_2_content scrollbar">
         <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="glyphicon glyphicon-edit icon-padding"></i>Food Setup
                    </div>
                </div> 
    <div class="row">

        <div class="box col-md-12">
            <div class="box-inner">
                
                <div class="box-content row content" id="content-1">
                    <div class="col-md-12">
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>

                        <div class="row" style="margin:0 8px;">
                            <asp:GridView ID="GridViewItem" runat="server" ShowFooter="True" Width="100%" DataKeyNames="Id"
                                AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" BackColor="White"
                                BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnPageIndexChanging="GridViewItem_PageIndexChanging"
                                OnRowCancelingEdit="GridViewItem_RowCancelingEdit" OnRowCommand="GridViewItem_RowCommand"
                                OnRowDeleting="GridViewItem_RowDeleting" OnRowEditing="GridViewItem_RowEditing"
                                OnRowUpdating="GridViewItem_RowUpdating">
                                <Columns>
                                    <asp:TemplateField HeaderText="Food Name">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtItemName" runat="server" Text='<%# Bind("ItemName") %>' CssClass=""
                                                MaxLength="30" Width="85%"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblItemName" runat="server" Text='<%# Bind("ItemName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtItemNameNew" runat="server" CssClass="" MaxLength="30" Width="85%"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredField1" runat="server" ControlToValidate="txtItemNameNew"
                                                Display="Dynamic" ErrorMessage="Name is required!" ForeColor="Red" SetFocusOnError="True"
                                                ValidationGroup="newGrpSubSec"></asp:RequiredFieldValidator>
                                        </FooterTemplate>
                                        <HeaderStyle Width="25%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Food Price">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtItemPrice" runat="server" Text='<%# Bind("Price") %>' CssClass=""
                                                MaxLength="30" Width="80%"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblItemPrice" runat="server" Text='<%# Bind("Price") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtItemPriceNew" runat="server" CssClass="" MaxLength="30" Width="80%"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredField2" runat="server" ControlToValidate="txtItemPriceNew"
                                                Display="Dynamic" ErrorMessage="Price is required!" ForeColor="Red" SetFocusOnError="True"
                                                ValidationGroup="newGrpSubSec"></asp:RequiredFieldValidator>
                                        </FooterTemplate>
                                        <HeaderStyle Width="15%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Discount">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtItemDiscountAmount" runat="server" Text='<%# Bind("DiscountAmount") %>'
                                                CssClass="" MaxLength="30" Width="80%"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblItemDiscountAmount" runat="server" Text='<%# Bind("DiscountAmount") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtItemDiscountAmountNew" runat="server" CssClass="" MaxLength="30"
                                                Width="80%"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredField3" runat="server" ControlToValidate="txtItemDiscountAmountNew"
                                                Display="Dynamic" ErrorMessage="Discount Amount is required!" ForeColor="Red"
                                                SetFocusOnError="True" ValidationGroup="newGrpSubSec"></asp:RequiredFieldValidator>
                                        </FooterTemplate>
                                        <HeaderStyle Width="15%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="VAT">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtItemVatAmount" runat="server" Text='<%# Bind("VAT") %>' CssClass=""
                                                MaxLength="30" Width="65%"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblItemVatAmount" runat="server" Text='<%# Bind("VAT") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtItemVatNew" runat="server" CssClass="" MaxLength="30" Width="65%"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredField300" runat="server" ControlToValidate="txtItemVatNew"
                                                Display="Dynamic" ErrorMessage="VAT Amount is required!" ForeColor="Red" SetFocusOnError="True"
                                                ValidationGroup="newGrpSubSec"></asp:RequiredFieldValidator>
                                        </FooterTemplate>
                                        <HeaderStyle Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Group">
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddlItemGroup" runat="server" Height="28px" CssClass="input"
                                                Width="90%">
                                                <%--<asp:ListItem>Rides</asp:ListItem>--%>
                                                <asp:ListItem>Food</asp:ListItem>
                                            </asp:DropDownList>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblItemGroup" runat="server" Text='<%# Bind("ItemGroupName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:DropDownList ID="ddlItemGroupNew" runat="server" Height="28px" CssClass="input"
                                                Width="90%">
                                               <%-- <asp:ListItem>Rides</asp:ListItem>--%>
                                                <asp:ListItem>Food</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredField4" runat="server" ControlToValidate="ddlItemGroupNew"
                                                InitialValue="--Select--" Display="Dynamic" ErrorMessage="Section Name is required!"
                                                ForeColor="Red" SetFocusOnError="True" ValidationGroup="newGrpSubSec"></asp:RequiredFieldValidator>
                                        </FooterTemplate>
                                        <HeaderStyle Width="15%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status">
                                        <EditItemTemplate>
                                            <asp:CheckBox ID="CheckBoxStatus" runat="server" Checked='<%# Bind("Status") %>' />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBoxStatus_view" runat="server" Checked='<%# Bind("Status") %>'
                                                Enabled="false" />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:CheckBox ID="CheckBoxStatusNew" runat="server" />
                                        </FooterTemplate>
                                        <HeaderStyle Width="5%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Option">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkEdit" runat="server" Text="" CommandName="Edit" ToolTip="Edit"
                                                CommandArgument=''><img id="Img1" src="~/img/edit.jpg" width="28" height="28" runat="server" /></asp:LinkButton>
                                            <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete"
                                                ToolTip="Delete" OnClientClick='return confirm("Are you sure you want to delete this entry?");'
                                                CommandArgument=''><img id="Img2" src="~/img/remove.png" runat="server" /></asp:LinkButton>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:LinkButton ID="lnkInsert" runat="server" Text="" ValidationGroup="editGrp3"
                                                CommandName="Update" ToolTip="Save" CommandArgument=''><img id="Img3" src="~/img/save.png" runat="server" /></asp:LinkButton>
                                            <asp:LinkButton ID="lnkCancel" runat="server" Text="" CommandName="Cancel" ToolTip="Cancel"
                                                CommandArgument=''><img id="Img4" src="~/img/cancle.png" runat="server" /></asp:LinkButton>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:LinkButton ID="lnkInsert" runat="server" Text="" ValidationGroup="newGrpSubSec"
                                                CommandName="InsertNewItem" ToolTip="Add New Entry" CommandArgument=''><img id="Img5" src="~/img/add.png" runat="server" /></asp:LinkButton>
                                            <asp:LinkButton ID="lnkCancel" runat="server" Text="" CommandName="Cancel" ToolTip="Cancel"
                                                CommandArgument=''><img id="Img6" src="~/img/cancle.png" runat="server" /></asp:LinkButton>
                                        </FooterTemplate>
                                        <HeaderStyle Width="14%" />
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" CssClass="Grid_Header" />
                                <PagerSettings Mode="NumericFirstLast" />
                                <PagerStyle BackColor="#6393c1" ForeColor="White" HorizontalAlign="Left" CssClass="pagination01 pageback" />
                                <RowStyle ForeColor="#000066" />
                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#00547E" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        </div>
    </div>
    <script>

        function func(result) {
            if (result === 'Record Added successfully!') {
                toastr.success(result);

            }
            else if (result === 'Food Deleted successfully!') {
                toastr.success(result);
            }
            else if (result === 'Record Updated successfully!') {
                toastr.success(result);
            }
            else
                toastr.error(result);

            return false;
        }

   </script>
</asp:Content>
