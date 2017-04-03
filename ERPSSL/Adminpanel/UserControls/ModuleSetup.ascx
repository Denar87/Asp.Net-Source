<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ModuleSetup.ascx.cs"
    Inherits="ERPSSL.Adminpanel.UserControls.ModuleSetup" %>

<%--<div class="panel">
        <div class="panel-heading panel-heading-01">
            <i class="fa fa-edit fa-fw icon-padding"></i>Add Module</div>
    </div>--%>
<link href="../css/jquery.dataTables.min.css" rel="stylesheet" />
<div class="resultText">
    <asp:Image ID="imgstatusloading" runat="server" CssClass="lblstatusloading_icon"
        Visible="false" />
    <asp:Image ID="imgstatus" runat="server" CssClass="lblstatus_icon" Visible="false" />
    <asp:Label ID="lblStatus" runat="server" Font-Bold="true" CssClass="lbltext"></asp:Label>
</div>
<div class="hm_sec_2_content scrollbar">
    <div class="panel">
        <div class="panel-heading panel-heading-01">
            <i class="fa fa-edit fa-fw icon-padding"></i>Add Module
        </div>
    </div>

    <div class="col-md-12">
        <div class="col-md-5">
            <div class="form-group">
                <label class="control-label" for="inputFname1">
                    Module Name<a style="color: red; font-size: 11px">*</a></label>
                <div class="controls">
                    <asp:TextBox ID="txtModuleName" runat="server" CssClass="form-control" Width="60%"></asp:TextBox>
                    <asp:HiddenField ID="hidModuleId" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtModuleName"
                        ForeColor="Red" ValidationGroup="FormValidation" ErrorMessage="Please Enter Module Name!!"
                        runat="server" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label" for="inputFname1">
                    Url<a style="color: red; font-size: 11px">*</a></label>
                <div class="controls">
                    <asp:TextBox ID="txtUrl" runat="server" CssClass="form-control" Width="60%"></asp:TextBox>
                    <asp:HiddenField ID="hidModulImageIcon" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtUrl"
                        ForeColor="Red" ValidationGroup="FormValidation" ErrorMessage="Please Enter Module URL!!"
                        runat="server" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label" for="inputFname1">
                    Module Order<a style="color: red; font-size: 11px">*</a></label>
                <div class="controls">
                    <asp:TextBox ID="txtbxModuleOrder" runat="server" CssClass="form-control" Width="60%"></asp:TextBox>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtbxModuleOrder"
                        ForeColor="Red" ValidationGroup="FormValidation" ErrorMessage="Please Enter Module Order!!"
                        runat="server" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="form-group">
                <label class="control-label" for="inputFname1">
                    Status</label>
                <div class="controls">
                    <asp:DropDownList ID="drpdownStatus" runat="server" CssClass="form-control" Width="60%">
                        <asp:ListItem Text="--- Select --- " Value="0"></asp:ListItem>
                        <asp:ListItem>True</asp:ListItem>
                        <asp:ListItem>False</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label" for="inputFname1">
                    Module Icon</label>
                <div class="controls">
                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="file_Upload" onchange="readfile(this);"
                        Width="85%" />
                    <div id="moduleImage" runat="server">
                        <asp:Image ID="ModulImage" runat="server" class="avater_details" Height="150px" ImageUrl="../resources/no_image.png"
                            onerror="this.onerror=null; this.src='resources/no_image_found.png';" Width="130px" />
                    </div>
                </div>
            </div>


            <%--<div class="form-group">
                <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-info" ValidationGroup="FormValidation"
                    Text="Save Module" OnClick="BtnSave_Click" />
            </div>--%>
            <div class="col-md-12" style="padding: 0px;">

                <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-info" ValidationGroup="FormValidation"
                    Text="Save Module" OnClick="BtnSave_Click" />


            </div>



        </div>



        <%--  CellPadding="5" AllowPaging="True" OnPageIndexChanging="gridviewModul_PageIndexChanging"--%>
        <div class="col-md-7" style="height: 410px; overflow: scroll; margin-top: 10px; padding-top: 10px; padding-bottom: 10px; border-top: 0px solid #eee;">
            <asp:GridView ID="gridviewModul" runat="server" AutoGenerateColumns="False" Width="100%" OnPageIndexChanging="gridviewModul_PageIndexChanging" AllowPaging="true" PageSize="10" CellPadding="20">
                <Columns>
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
                            <asp:Label ID="lblModulId" runat="server" Text='<%# Eval("ModuleID")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ModuleName" HeaderText="Module">
                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                        <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                        <FooterStyle CssClass="Grid_Footer" />
                    </asp:BoundField>

                    <asp:BoundField DataField="ModuleURL" HeaderText="URL">
                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                        <ItemStyle HorizontalAlign="Left" Width="20%" CssClass="Grid_Border" />
                        <FooterStyle CssClass="Grid_Footer" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ModuleOrder" HeaderText="Order">
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
                            <asp:ImageButton ID="imgbtnModulEdit" runat="server" ImageUrl="~/img/list_edit.png"
                                OnClick="imgbtnModulEdit_Click" />
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

<%--<script src="../js/jquery-1.11.3.min.js"></script>
<script src="../js/jquery.dataTables.min.js"></script>




<script type="text/javascript">

    $(document).ready(function () {
        $(".gvv").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable({
            "lengthMenu": [[100, 200, 300, 400, -1], [100, 200, 300, 400, "All"]] //value:item pair

        });
    });
</script>--%>
