<%@ Page Title="" Language="C#" MasterPageFile="~/FA/Site.Master" AutoEventWireup="true"
    CodeBehind="AssetUser.aspx.cs" Inherits="ERPSSL.FA.AssetUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>


  <asp:UpdatePanel ID="UpdatePanel7" runat="server">
    <ContentTemplate>

    <div class="row">

        <div class="hm_sec_2_content scrollbar">
                    <div class="panel">
            <div class="panel-heading panel-heading-01">
                <i class="fa fa-edit fa-fw icon-padding"></i>Asset User
            </div>
            <asp:HiddenField ID="hdnUnitId" runat="server" />
        </div>
        <div class="col-md-12 bg-success">
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </div>
        <div class="col-md-6">
            <div class="row">
                <div class="col-md-12">
                    <div class="col-md-5">
                        Region
                    </div>
                    <div class="col-md-7">
                        <asp:DropDownList ID="ddlRegion" runat="server" CssClass="form-control" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" SetFocusOnError="true" 
                            ControlToValidate="ddlRegion" ValidationGroup="User"></asp:RequiredFieldValidator>
                        <asp:HiddenField ID="hidRegionId" runat="server" />
                    </div>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-12">
                    <div class="col-md-5">
                        Office
                    </div>
                    <div class="col-md-7">
                        <asp:DropDownList ID="ddlOffice" runat="server" CssClass="form-control" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlOffice_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"  SetFocusOnError="true"
                            ControlToValidate="ddlOffice" ValidationGroup="User"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-12">
                    <div class="col-md-5">
                        Department Name
                    </div>
                    <div class="col-md-7">
                        <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" SetFocusOnError="true" 
                            ControlToValidate="ddlDepartment" ValidationGroup="User"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-12">
                    <div class="col-md-5">
                        Designation
                    </div>
                    <div class="col-md-7">
                        <div style="float: left; font-size: 13px; margin-right: 5px;">
                        </div>
                        <asp:TextBox ID="txtDesignation" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" SetFocusOnError="true"
                            ControlToValidate="txtDesignation" ValidationGroup="User"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-5">
                        </div>
                        <div class="col-md-7">
                        </div>
                    </div>
                </div>
                <br />
            </div>
        </div>
        <div class="col-md-6">
            <div class="row">
                <div class="col-md-12">
                    <div class="col-md-5">
                        User's Name
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"  SetFocusOnError="true"
                            ControlToValidate="txtUserName" ValidationGroup="User"></asp:RequiredFieldValidator>
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                    </div>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-12">
                    <div class="col-md-5">
                        Employee ID
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtEmployeeId" CssClass="form-control" runat="server" 
                            AutoPostBack="True" ontextchanged="txtEmployeeId_TextChanged"></asp:TextBox>
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-12">
                    <div class="col-md-5">
                        Email
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" SetFocusOnError="true" 
                            ControlToValidate="txtEmail" ValidationGroup="User"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-12">
                    <div class="col-md-5">
                        Phone
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"  SetFocusOnError="true"
                            ControlToValidate="txtPhone" ValidationGroup="User"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-12">
                    <div class="col-md-5">
                        
                    </div>
                    <div class="col-md-7">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-info" Text="Save" 
                            onclick="btnSave_Click" ValidationGroup="User" />
                    </div>
                </div>
            </div>
           
            <br />
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
     <div class="row">
                <div class="col-md-12">
                        <fieldset style="border:none">
                    <asp:GridView ID="grdUser" runat="server" ShowFooter="True" Width="100%"
                        AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" CellPadding="5"
                        BorderColor="#99CCFF" BorderStyle="Solid" CssClass="Grid_Border" ForeColor="#339933"  OnPageIndexChanging="grdUser_PageIndexChanging"
                        PageSize="5">
                        <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                        <Columns>
                            <asp:TemplateField HeaderText="User Id">
                                <ItemTemplate>
                                    <asp:Label ID="lblUserId" runat="server" Text='<%# Eval("UserId")%>' />
                                </ItemTemplate>
                                <FooterStyle CssClass="Grid_Footer" />
                                <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" VerticalAlign="Middle"
                                    Width="5%" />
                            </asp:TemplateField>
                            
                                <asp:BoundField DataField="EmployeeId" HeaderText="EmployeeId ">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                           <asp:BoundField DataField="Name" HeaderText="Name">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Designation" HeaderText="Designation">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                         <asp:BoundField DataField="Email" HeaderText="Email">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                         <asp:BoundField DataField="Phone" HeaderText="Phone">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                          <asp:BoundField DataField="DepartmentName" HeaderText="Department Name">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                          <asp:BoundField DataField="OfficeName" HeaderText="Office Name">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                         <asp:BoundField DataField="RegionName" HeaderText="RegionName">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>

                            <%--<asp:TemplateField HeaderText="Option">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImgBtnEdit" runat="server" ImageUrl="../FA/img/list_edit.png" OnClick="imgBtnEdit_Click"
                                         />
                                    <asp:ImageButton ID="ImgBtnDelete" OnClick="imgbtnDelete_Clik" runat="server" ImageUrl="../FA/img/remove.png" 
                                         />
                                </ItemTemplate>
                                <FooterStyle CssClass="Grid_Footer" />
                                <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" Width="8%" />
                            </asp:TemplateField>--%>
                        </Columns>
                        <EmptyDataRowStyle ForeColor="Red" />
                        <HeaderStyle Height="25px" />
                        <PagerSettings Mode="NumericFirstLast" />
                        <PagerStyle CssClass="pagination01 pageback" />
                        <RowStyle CssClass="Grid_RowStyle" Height="25px" />
                    </asp:GridView>
                </fieldset>
                </div>
            </div>

            </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>


    
    
</asp:Content>
