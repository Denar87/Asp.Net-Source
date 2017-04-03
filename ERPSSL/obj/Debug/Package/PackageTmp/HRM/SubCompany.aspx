<%@ Page Title="" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true"
    CodeBehind="SubCompany.aspx.cs" Inherits="ERPSSL.HRM.SubCompany" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <%--<asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">   
<ContentTemplate>--%>
    <div class="hm_sec_2_content scrollbar">
        <div class="panel">
            <div class="panel-heading panel-heading-01">
                <i class="fa fa-edit fa-fw icon-padding"></i>Sub Company Setup
            </div>
        </div>
        <div class="row">



            <div class="col-md-12 bg-success">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </div>
            <div class="col-md-12">
                <div class="col-md-4">
                    <div class="row" style="padding-top: 5px;">
                        <div class="col-md-12" style="padding-bottom: 5px">
                            <div class="col-md-5">
                                Company 
                                    <asp:HiddenField ID="hidSubCompanyId" runat="server" />
                            </div>
                            <div class="col-md-7">
                                <%--<asp:TextBox ID="txtFirstName" runat="server" Class="form-control"></asp:TextBox>--%>
                                <asp:DropDownList ID="ddlCompany" runat="server" CssClass="form-control"></asp:DropDownList>


                            </div>
                        </div>
                    </div>
                    <div class="row" style="padding-top: 5px;">
                        <div class="col-md-12" style="padding-bottom: 5px">
                            <div class="col-md-5">
                                Sub Company 
                            </div>
                            <div class="col-md-7">
                                <asp:TextBox ID="txtSubCompanyName" runat="server" Class="form-control"></asp:TextBox>

                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtSubCompanyName"
                                    Display="Dynamic" ForeColor="Red" Font-Size="11px" SetFocusOnError="True" ErrorMessage="Enter Sub Company Name" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="row" style="padding-top: 5px;">
                        <div class="col-md-12" style="padding-bottom: 5px">
                            <div class="col-md-5">
                                Sub Company Code
                            </div>
                            <div class="col-md-7">
                                <asp:TextBox ID="txtSubCompanyCode" runat="server" class="form-control"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSubCompanyCode"
                                    Display="Dynamic" ForeColor="Red" Font-Size="11px" SetFocusOnError="True" ErrorMessage="Enter Sub Company Code" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>

                    <div class="row" style="padding-top: 5px;">
                        <div class="col-md-12" style="padding-bottom: 5px">
                            <div class="col-md-5">
                                Address
                            </div>
                            <div class="col-md-7">
                                <asp:TextBox ID="txtbxAddress" TextMode="MultiLine" runat="server" class="form-control"></asp:TextBox>

                            </div>
                        </div>
                    </div>


                    <div class="row">
                        <div class="col-md-12">

                            <div class="col-md-8">
                            </div>
                            <div class="col-md-4" style="margin-right:-50px;">
                                <asp:Button ID="btnCompany" runat="server" ValidationGroup="Group1" Text="Submit"
                                    CssClass="btn btn-info pull-right" OnClick="btnCompany_Click" />
                            </div>
                        </div>

                    </div>


                </div>
                <div class="col-md-8">

                    <div class="col-md-12">
                        <asp:GridView ID="gridviewSubCompany" runat="server" AutoGenerateColumns="False" Width="100%"
                            CellPadding="5" AllowPaging="True" OnPageIndexChanging="gridviewCompany_PageIndexChanging">
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
                                        <asp:Label ID="lblSubCompany_Id" runat="server" Text='<%# Eval("SubCompany_Id")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:BoundField DataField="CompanyName" HeaderText="Company">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SubCompanyName" HeaderText="Sub Company">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SubCompanyAddress" HeaderText="Address">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Left" Width="20%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SubCompanyCode" HeaderText="Sub Company Code">
                                    <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                </asp:BoundField>                              

                                <asp:TemplateField HeaderText="Update">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgbtnSubCompanyEdit" runat="server" ImageUrl="img/list_edit.png"
                                            OnClick="imgbtnSubCompanyEdit_Click" />
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



                <%-- <div class="col-md-4">


                        <div class="col-md-12">
                            <div class="col-md-2">
                            </div>
                            <div class="col-md-10">

                                <asp:Image ID="Emp_IMG_TRNS" runat="server" class="avater_details" Height="150px"
                                    ImageUrl="../resources/no_image.png" onerror="this.onerror=null; this.src='resources/no_image_found.png';"
                                    Width="130px" />

                            </div>
                        </div>

                        <div class="col-md-12">
                            <div class="col-md-2">
                                <br />
                                Logo</div>
                            <div class="col-md-10">
                                <br />
                                <asp:FileUpload ID="FileUpload1" runat="server" CssClass="file_Upload" onchange="readfile(this);"
                                    Width="85%" />
                            </div>
                        </div>

                        <br />
                        <div class="col-md-12">
                            <br />
                            <div class="col-md-3">
                            </div>
                            <div class="col-md-4">
                               
                            </div>
                        </div>

                    </div>--%>
            </div>
        </div>

    </div>
    <%--    
</ContentTemplate>
<Triggers>
 <asp:AsyncPostBackTrigger ControlID="btnCompany" EventName="Click" />
</Triggers>
</asp:UpdatePanel>--%>
    <script type="text/javascript">

        function func(result) {
            if (result === 'Data Save Successfully') {
                toastr.success(result);

            }
            else if (result === 'Delete Data Successfully') {
                toastr.success(result);

            }
            else if (result === 'Data Update Successfully') {
                toastr.success(result);

            }
            else if (result === 'File is too big!! Max file size 100kb!!! Please Resize !!!!') {
                toastr.error(result);

            }

            else
                toastr.error(result);

            return false;
        }

    </script>

</asp:Content>
