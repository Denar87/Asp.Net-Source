<%@ Page Title="" Language="C#" MasterPageFile="~/Adminpanel/Site.Master" AutoEventWireup="true"
    CodeBehind="AddPage.aspx.cs" Inherits="ERPSSL.Adminpanel.AddPage" %>




<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../css/jquery.dataTables.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">


    <asp:HiddenField ID="hidPageId" runat="server" />

    <div class="hm_sec_2_content scrollbar" style="padding-top:0px">
        <div class="panel">
            <div class="panel-heading panel-heading-01">
                <i class="fa fa-edit fa-fw icon-padding"></i>Add Page
            </div>
        </div>
        <div class="col-md-12" style="padding-top:10px">
            <div class="resultText">
                <asp:Image ID="imgstatusloading" runat="server" CssClass="lblstatusloading_icon"
                    Visible="false" />
                <asp:Image ID="imgstatus" runat="server" CssClass="lblstatus_icon" Visible="false" />
                <asp:Label ID="lblStatus" runat="server" Font-Bold="true" CssClass="lbltext"></asp:Label>
            </div>
            <div class="col-md-4">
                <div class="row">
                    <label class="control-label" for="inputFname1">
                        Module<a style="color: red; font-size: 11px">*</a></label>
                    <div>
                        <asp:DropDownList ID="drpModulName" runat="server" CssClass="form-control" AutoPostBack="true" Width="80%" OnSelectedIndexChanged="drpModulName_change">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" ValidationGroup="Group1"
                            runat="server" ControlToValidate="drpModulName" ErrorMessage="Select a Module"
                            InitialValue="0"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="row" style="padding-bottom: 0px">
                    <label class="control-label" for="inputFname1">
                        Feature<a style="color: red; font-size: 11px">*</a></label>
                    <div>
                        <asp:DropDownList ID="drpwonCategoryName" runat="server" CssClass="form-control" Width="80%" AutoPostBack="true" OnSelectedIndexChanged="drpwonCategoryName_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="Group1"
                            runat="server" ControlToValidate="drpwonCategoryName" ErrorMessage="Select a Feature"
                            InitialValue="0"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row" style="padding-bottom: 8px">
                    <label class="control-label" for="inputFname1">
                        Page<a style="color: red; font-size: 11px">*</a></label>
                    <div>
                        <asp:TextBox ID="txtbxPageName" runat="server" CssClass="form-control" Width="80%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtbxPageName"
                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Page Name"
                            ValidationGroup="Group1"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row" style="padding-bottom: 8px">
                    <label class="control-label" for="inputFname1">
                        Page Url<a style="color: red; font-size: 11px">*</a></label>
                    <div>
                        <asp:TextBox ID="txtbxPageUrl" runat="server" CssClass="form-control" Width="80%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtbxPageName"
                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Page Url"
                            ValidationGroup="Group1"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row" style="padding-bottom: 8px">
                    <label class="control-label" for="inputFname1">
                        Menu Order<a style="color: red; font-size: 11px">*</a></label>
                    <div>
                        <asp:TextBox ID="txtbxOrder" runat="server" CssClass="form-control" Width="80%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtbxOrder"
                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Page Order"
                            ValidationGroup="Group1"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <label class="control-label" for="inputFname1">
                        Status<a style="color: red; font-size: 11px">*</a></label>
                    <div>
                        <asp:DropDownList ID="drpdownStatus" runat="server" CssClass="form-control" Width="80%">
                            <asp:ListItem Text="--- Select --- " Value="0"></asp:ListItem>
                            <asp:ListItem>True</asp:ListItem>
                            <asp:ListItem>False</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="Group1"
                            runat="server" ControlToValidate="drpdownStatus" ErrorMessage="Select Status"
                            InitialValue="0"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <%--<div class="row">
                    <div>
                        <asp:Button ID="BtnSave" runat="server" ValidationGroup="Group1" CssClass="btn btn-info"
                            Text="Save Page" OnClick="BtnSave_Click" />
                    </div>
                </div>--%>
                 <div class="row" style="padding:0px;">
                    
                         <asp:Button ID="BtnSave" runat="server" ValidationGroup="Group1" CssClass="btn btn-info"
                            Text="Save Page" OnClick="BtnSave_Click" />
                   
                </div>



            </div>
            <%-- CellPadding="5" AllowPaging="True" OnPageIndexChanging="gridviewPage_PageIndexChanging" PageSize="20"--%>

             <div class="col-md-8" style="height: 410px; overflow: scroll; margin-top: 10px; padding-top: 10px; padding-bottom: 10px; border-top: 0px solid #eee;">
                <asp:GridView ID="gridviewPage" runat="server" AutoGenerateColumns="False"  Width="100%"
                    CellPadding="20" >
                    <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="3%" HeaderStyle-HorizontalAlign="Center">
                            <HeaderTemplate>
                                Sl.
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblSRNO" runat="server"
                                    Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblPageId" runat="server" Text='<%# Eval("PageID")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ModulName" HeaderText="Module">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FeatureName" HeaderText="Feature">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PageName" HeaderText="Page">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PageUrl" HeaderText="Page Url">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PageOrder" HeaderText="Order">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Status" HeaderText="Status">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>

                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgbtnModulEdit" runat="server" ImageUrl="~/img/list_edit.png" OnClick="imgbtnModulEdit_Click" />
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

    <script src="../js/jquery-1.11.3.min.js"></script>
    <script src="../js/jquery.dataTables.min.js"></script>


    

    <script type="text/javascript">

        //$(document).ready(function () {
        //    $(".gvv").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable({
        //        "lengthMenu": [[100, 200, 300, 400, -1], [100, 200, 300, 400, "All"]] //value:item pair

        //    });
        //});

        function func(result) {
            if (result === 'Page saved successfully') {
                toastr.success(result);
            }
            else if (result === 'Page updated successfully') {
                toastr.success(result);
            }
            else
                toastr.error(result);

            return false;
        }

    </script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
