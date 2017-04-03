<%@ Page Title="" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true"
    CodeBehind="company.aspx.cs" Inherits="ERPSSL.HRM.company"  %>
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
            <i class="fa fa-edit fa-fw icon-padding"></i>Company Setup
        </div>
    </div>
    <div class="row">
    
        
        <div class="row">
            <div class="col-md-12 bg-success">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </div>
            <div class="col-md-12">
                <br />
                <div class="col-md-4">
                   <div class="row" style="padding-top:8px;">
                        <div class="col-md-12">
                            <div class="col-md-3">
                                Company 
                            </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtbxName" runat="server" class="form-control"></asp:TextBox>
                                <asp:HiddenField ID="hidCompanyId" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtbxName"
                                    Display="Dynamic" ForeColor="Red" Font-Size="11px" SetFocusOnError="True" ErrorMessage="Enter Company Name" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                   
                    <div class="row" style="padding-top:8px;">
                        <div class="col-md-12">
                            <div class="col-md-3">
                                Address
                            </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtbxAddress" TextMode="MultiLine" runat="server" class="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtbxAddress"
                                    Display="Dynamic" ForeColor="Red" Font-Size="11px" SetFocusOnError="True" ErrorMessage="Enter Company Address" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                  
                 <div class="row" style="padding-top:8px;">
                        <div class="col-md-12">
                            <div class="col-md-3">
                                Phone
                            </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtbxPhoneNo" runat="server" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                  
                    <div class="row" style="padding-top:8px;">
                        <div class="col-md-12">
                            <div class="col-md-3">
                                Mobile
                            </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtbxMobileNo" runat="server" class="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtbxMobileNo"
                                    Display="Dynamic" ForeColor="Red" Font-Size="11px" SetFocusOnError="True" ErrorMessage="Enter Mobile No." ValidationGroup="Group1"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                   
                  <div class="row" style="padding-top:8px;">
                        <div class="col-md-12">
                            <div class="col-md-3">
                                Fax
                            </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtbxFax" runat="server" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
              
                   <div class="row" style="padding-top:8px;">
                        <div class="col-md-12">
                            <div class="col-md-3">
                                E-mail
                            </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtbxEmail" runat="server" class="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtbxEmail"
                                    Display="Dynamic" ForeColor="Red" Font-Size="11px" SetFocusOnError="True" ErrorMessage="Enter E-mail Address" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    </div>
                <div class="col-md-4">
                   
                    <div class="row" style="padding-top:8px;">
                        <div class="col-md-12">
                            <div class="col-md-3">
                                Web
                            </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtbxWebSite" runat="server" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                 
                    <div class="row" style="padding-top:8px;">
                        <div class="col-md-12">
                            <div class="col-md-3">
                               ERC No
                            </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtErcNo" runat="server" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                     <div class="row" style="padding-top:8px;">
                        <div class="col-md-12">
                            <div class="col-md-3">
                              ERC Date
                            </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtERCDate" runat="server"  placeholder="MM/dd/yyyy" class="form-control"></asp:TextBox>
                                 <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtERCDate"
                                                PopupButtonID="Image_AT" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                            </div>
                        </div>
                    </div>
                      <div class="row" style="padding-top:8px;">
                        <div class="col-md-12">
                            <div class="col-md-3">
                            REG. No
                            </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtRegNo" runat="server" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                     <div class="row" style="padding-top:8px;">
                        <div class="col-md-12">
                            <div class="col-md-3">
                               REG Date
                            </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtRegDate" runat="server" placeholder="MM/dd/yyyy" class="form-control"></asp:TextBox>
                                 <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtRegDate"
                                                PopupButtonID="Image_AT" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                            </div>
                        </div>
                    </div>
                       <div class="row" style="padding-top:8px;">
                        <div class="col-md-12">
                            <div class="col-md-3">
                             Area Code
                            </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtAreaCode" runat="server" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>


                </div>
               <div class="col-md-4">
                       

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
                                <div class="col-md-2"><br />Logo</div>
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
                                    <%--  <asp:Button ID="btnimageUpload" runat="server" Text="UpLoad" class="btn btn-info  pull-right" />--%>
                                </div>
                            </div>
                       
                    </div>
             <div class="row">
                        <div class="col-md-12">

                            <div class="col-md-3">
                            </div>
                            <div class="col-md-8">
                                <asp:Button ID="btnCompany" runat="server" ValidationGroup="Group1" Text="Submit"
                                    CssClass="btn btn-info pull-right" OnClick="btnCompany_Click" />
                            </div>
                        </div>

                    </div>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-12">
                <asp:GridView ID="gridviewCompany" runat="server" AutoGenerateColumns="False" Width="100%"
                    CellPadding="5" AllowPaging="True" OnPageIndexChanging="gridviewCompany_PageIndexChanging">
                    <Columns>

                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            Sl No.
                                        </HeaderTemplate>
                                        <ItemTemplate  >
                                            <asp:Label ID="lblSRNO" runat="server"
                                                Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                        <asp:TemplateField Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblCompanyId" runat="server" Text='<%# Eval("CompanyId")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Name" HeaderText="Company">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Address" HeaderText="Address">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="20%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Mobile" HeaderText="Mobile">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Phone" HeaderText="Phone">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Email" HeaderText="Email">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Fax" HeaderText="Fax">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>

                        <asp:TemplateField HeaderText="Update">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgbtnCompanyEdit" runat="server" ImageUrl="img/list_edit.png"
                                    OnClick="imgbtnCompanyEdit_Click" />
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
