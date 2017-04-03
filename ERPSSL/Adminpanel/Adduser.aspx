<%@ Page Title="" Language="C#" MasterPageFile="~/Adminpanel/Site.Master" AutoEventWireup="true" CodeBehind="Adduser.aspx.cs" Inherits="ERPSSL.Adminpanel.Adduser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <%--<ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />--%>
    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
        <ContentTemplate>
            <%--<div class="panel">
        <div class="panel-heading panel-heading-01">
            <i class="fa fa-edit fa-fw icon-padding"></i>Add User
        </div>
    </div>--%>

            <div class="hm_sec_2_content scrollbar">
                <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="fa fa-edit fa-fw icon-padding"></i>Add User
                    </div>
                </div>
                <div class="col-md-12 bg-success">
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </div>
                <div class="col-md-12">
                    <div class="resultText">
                        <asp:Image ID="imgstatusloading" runat="server" CssClass="lblstatusloading_icon"
                            Visible="false" />
                        <asp:Image ID="imgstatus" runat="server" CssClass="lblstatus_icon" Visible="false" />
                        <asp:Label ID="lblStatus" runat="server" Font-Bold="true" CssClass="lbltext"></asp:Label>
                    </div>

                    <div class="col-md-6">

                        <div class="row" style="margin-bottom: 8px">
                            <div class="col-md-3" id="eidlbl" runat="server">E-ID:<a style="color: red; font-size: 11px">*</a></div>
                            <div class="col-md-7">
                                <asp:TextBox ID="txtbxEID" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtbxEID"
                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input E-ID"
                                    ValidationGroup="Group2"></asp:RequiredFieldValidator>
                                <asp:HiddenField ID="hidEID" runat="server" />
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 8px">
                            <div class="col-md-3">User Name:<a style="color: red; font-size: 11px">*</a></div>

                            <div class="col-md-7">
                                <script src="js/CheckUser.js" type="text/javascript"></script>
                                <asp:UpdatePanel ID="PnlUsrDetails" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtbxUserName" runat="server" placeholder="Unique User Name" CssClass="form-control"
                                            AutoPostBack="True" OnTextChanged="txtEID_TextChanged"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtbxUserName"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input User Name"
                                            ValidationGroup="Group2"></asp:RequiredFieldValidator>

                                        <div id="Checkusername" runat="server" visible="false" class="CheckResult">
                                            <asp:Image ID="Image1" runat="server" CssClass="lblstatus_icon" />
                                            <asp:Label ID="Label1" runat="server"></asp:Label>
                                        </div>
                                        <div class="waitingdiv" id="loadingdiv" style="display: none">
                                            <img src="resources/ico/LoadingImage.gif" alt="Loading.." class="waiting_img" />
                                            Please wait...
                                        </div>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>

                        <div class="row" style="margin-bottom: 8px">
                            <div class="col-md-3">User Full Name:</div>
                            <div class="col-md-7">
                                <asp:TextBox ID="txtbxUsrFullName" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 8px">
                            <div class="col-md-3">Email:<a style="color: red; font-size: 11px">*</a></div>
                            <div class="col-md-7">
                                <asp:TextBox ID="txtbxEmail" runat="server" placeholder="Email" autocomplete="off" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtbxEmail"
                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Email"
                                    ValidationGroup="Group2"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="row" id="password" runat="server" style="margin-bottom: 8px">
                            <div class="col-md-3">Password:</div>
                            <div class="col-md-7">
                                <asp:TextBox ID="txtbxPassword" placeholder="Password" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row" id="Conpassword" runat="server" style="margin-bottom: 8px">
                            <div class="col-md-3">Confirm password:</div>
                            <div class="col-md-7">
                                <asp:TextBox ID="txtbxConformePassword" placeholder="Confirm password" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row" style="margin-bottom: 8px">
                            <div class="col-md-3">Status:</div>
                            <div class="col-md-7">
                                <asp:DropDownList ID="drpdownStatus" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="0">...Select...</asp:ListItem>
                                    <asp:ListItem Value="true">Yes</asp:ListItem>
                                    <asp:ListItem Value="false">No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <%--<div class="row" style="margin-bottom:8px">
                    <div class="col-md-3"></div>
                    <div class="col-md-7">
                        <asp:Button ID="BtnSave" runat="server" ValidationGroup="Group2" CssClass="btn btn-info"
                            Text="Submit" OnClick="BtnSave_Click" />
                    </div>
                </div>--%>

                        <div class="row" style="margin-bottom: 10px;">
                            <div class="col-md-3"></div>
                            <div class="col-md-7">
                                <asp:Button ID="BtnSave" runat="server" ValidationGroup="Group2" CssClass="btn btn-info"
                                    Text="Submit" OnClick="BtnSave_Click" />
                            </div>
                        </div>

                    </div>

                    <div class="col-md-6">
                        <asp:GridView ID="gridviewadduser" runat="server" AutoGenerateColumns="False" Width="100%">
                            <Columns>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="3%" HeaderStyle-HorizontalAlign="Center">
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
                                        <asp:Label ID="lblEID" runat="server" Text='<%# Eval("EID")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="LoginName" HeaderText="User Name">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>
                                <asp:BoundField DataField="UserFullName" HeaderText="User Full Name">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>

                                <asp:BoundField DataField="Use_Email" HeaderText="Email">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>

                                <asp:TemplateField HeaderText="Update">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgbtnRegionEdit" runat="server" ImageUrl="img/list_edit.png"
                                            OnClick="imgbtnUsernEdit_Click" />
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
        </ContentTemplate>
    </asp:UpdatePanel>
    <script>

        function func(result) {
            if (result === 'User Save Successfully.') {
                toastr.success(result);

            }
            else if (result === 'User Updated Successfully') {
                toastr.success(result);

            }
            else if (result === "Password Not Match") {
                toastr.error(result);
            }
            else if (result === " User Name Already Exist!") {
                toastr.error(result);
            }
           
            else
                toastr.error(result);

            return false;
        }

    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
