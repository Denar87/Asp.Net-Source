<%@ Page Title="" Language="C#" MasterPageFile="~/INV/Site.Master" AutoEventWireup="true" CodeBehind="SupplierDeatils.aspx.cs" Inherits="ERPSSL.INV.Supplierdetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="UserControl/Supplier_Documents.ascx" TagName="Supplier_Documents" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <div class="panel">
        <div class="panel-heading panel-heading-01">
            <i class="glyphicon glyphicon-edit icon-padding"></i>Supplier Infromation
        </div>
    </div>
    <div class="row scrollbar">
        <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" Width="100%" OnDemand="true"
            CssClass="ajax__myTab" ActiveTabIndex="0">
            <ajaxToolkit:TabPanel runat="server" HeaderText="Basic Information" ID="TabPanel1"
                OnDemandMode="None">
                <ContentTemplate>
                    <div class="hm_sec_2_content scrollbar">

                        <div class="col-md-12">
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label>

                        </div>
                        <fieldset>
                            <legend style="line-height: 0;"><span style="background: #fff">Basic Info</span></legend>

                            <div class="col-md-12">

                                <div class="col-md-8">
                                    <div class="col-md-6">
                                        <div class="row" style="margin-bottom: 8px;">
                                            <div class="col-md-12">
                                                <div class="col-md-4">Supplier Name </div>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtSupplierName" Class="form-control" runat="server" OnTextChanged="txtSupplierName_TextChanged"></asp:TextBox>
                                                    <asp:HiddenField ID="hidSupplierId" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row" style="margin-bottom: 8px;">
                                            <div class="col-md-12">
                                                <div class="col-md-4">Supplier Code</div>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtSupplierCode" Class="form-control" runat="server"></asp:TextBox>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6" style="margin-bottom: 8px;">
                                        <div class="row" style="margin-bottom: 8px;">
                                            <div class="col-md-12">
                                                <div class="col-md-4">Tel Phone </div>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtPhone" Class="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row" style="margin-bottom: 8px;">
                                            <div class="col-md-12">
                                                <div class="col-md-4">Mobile </div>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtMobile" Class="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row" style="margin-bottom: 8px;">
                                        <div class="col-md-12">


                                            <div class="col-md-2" style="padding-right: 0; width: 20%; padding-left: 30px;">Address</div>


                                            <div class="col-md-10" style="padding-left: 0; width: 77%">
                                                <asp:TextBox ID="txtbxAddress" runat="server" class="form-control"></asp:TextBox>

                                            </div>


                                        </div>
                                    </div>

                                    <div class="row" style="margin-bottom: 8px;">
                                        <div class="col-md-12">


                                            <div class="col-md-2" style="padding-right: 0; width: 20%; padding-left: 30px;">Remarks</div>


                                            <div class="col-md-10" style="padding-left: 0; width: 77%">
                                                <asp:TextBox ID="txtSupremarks" runat="server" class="form-control"></asp:TextBox>

                                            </div>


                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-4">
                                    <div class="row" style="margin-bottom: 8px;">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="col-md-4">E-mail</div>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtEmail" Class="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" style="margin-bottom: 8px;">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="col-md-4">Fax</div>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="TextBox7" Class="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" style="margin-bottom: 8px;">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="col-md-4">Distict</div>
                                                <div class="col-md-8">
                                                    <asp:DropDownList ID="ddlDistrict" Class="form-control" runat="server"></asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" style="margin-bottom: 8px;">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="col-md-4">Status</div>
                                                <div class="col-md-8">
                                                    <asp:DropDownList ID="ddlStatus" CssClass="form-control" runat="server">
                                                        <asp:ListItem Value="0">Select One</asp:ListItem>
                                                        <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                        <asp:ListItem Value="No">No</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <br />

                                </div>

                            </div>
                        </fieldset>
                        <fieldset>
                            <legend style="line-height: 0;"><span style="background: #fff">Contact Info</span></legend>
                            <div class="col-md-12" style="margin-top: 10px;">
                                <div class="col-md-4">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-4">Contact Person </div>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtPerson" Class="form-control" runat="server"></asp:TextBox><asp:HiddenField ID="HiddenField2" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-4">Designation</div>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtdesignation" Class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />

                                </div>
                                <div class="col-md-4">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-4">Phone </div>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtPhoneNo" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-4">Mobile No </div>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtmobileNo" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">

                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-4">Fax </div>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtFax" Class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-4">Email </div>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtEmailAddress" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <br />
                                </div>
                            </div>
                        </fieldset>

                        <fieldset>
                            <legend style="line-height: 0;"><span style="background: #fff">Business Info</span></legend>

                            <div class="col-md-12" style="margin-top: 10px;">
                                <div class="col-md-12">
                                    <asp:Label ID="lblBusinessmsg" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label>
                                </div>
                                <div class="col-md-4">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-4">Tarde License</div>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtTradelicense" Class="form-control" runat="server"></asp:TextBox><asp:HiddenField ID="HiddenField1" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-4">Validity </div>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtValidity" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-4">Business Type</div>
                                            <div class="col-md-8">
                                                <asp:DropDownList ID="ddlBusinessType" Class="form-control" runat="server"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>


                                </div>

                                <div class="col-md-4">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-4">Certoficate Of Incorp. </div>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtCertificateIncorp" Class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-4">Certificate of Incorp.  Date</div>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtIncorpDate" Class="form-control" runat="server"></asp:TextBox><ajaxToolkit:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtIncorpDate"
                                                    PopupButtonID="txtIncorpDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-4">Business Capital </div>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtBusinessCapital" Class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">

                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-4">TIN </div>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtTin" Class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-4">VAT</div>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtVat" Class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-4">Bank Name </div>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtBankName" Class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <br />
                                </div>
                            </div>
                        </fieldset>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-4"></div>
                                <div class="col-md-8">
                                    <asp:Button ID="btnSupplier" runat="server" ValidationGroup="Group1" Text="Submit"
                                        CssClass="btn btn-info pull-right" OnClick="btnSupplier_Click" Style="float: right" />
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <asp:GridView ID="gridviewSupplier" runat="server" AutoGenerateColumns="False" Width="100%" BorderColor="#E3F0FC" CellPadding="5" AllowPaging="True" OnPageIndexChanging="gridviewSupplier_PageIndexChanging">
                                    <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                    <Columns>
                                        <asp:TemplateField Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSupplierId" runat="server" Text='<%# Eval("Id")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="SupplierName" HeaderText="Supplier Name">
                                            <FooterStyle CssClass="Grid_Footer" />
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="SupplierCode" HeaderText="Code">
                                            <FooterStyle CssClass="Grid_Footer" />
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Center" Width="6%" CssClass="Grid_Border" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ContactPerson" HeaderText="Contact Person">
                                            <FooterStyle CssClass="Grid_Footer" />
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Address" HeaderText="Address">
                                            <FooterStyle CssClass="Grid_Footer" />
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Phone" HeaderText="Contact No.">
                                            <FooterStyle CssClass="Grid_Footer" />
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EmailAddress" HeaderText="E-mail">
                                            <FooterStyle CssClass="Grid_Footer" />
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="Grid_Border" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Fired" HeaderText="Enlisted">
                                            <FooterStyle CssClass="Grid_Footer" />
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="Grid_Border" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgbtnSupplierEdit" runat="server" ImageUrl="img/list_edit.png"
                                                    OnClick="imgbtnSupplierEdit_Click" />
                                            </ItemTemplate>
                                            <ItemStyle Width="6%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataRowStyle ForeColor="Red" />
                                    <FooterStyle CssClass="Grid_Footer" />
                                    <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" />
                                    <PagerSettings Mode="NumericFirstLast" />
                                    <PagerStyle CssClass="pagination01 pageback" />
                                    <RowStyle CssClass="Grid_RowStyle" />
                                </asp:GridView>
                            </div>
                        </div>

                    </div>
                </ContentTemplate>

            </ajaxToolkit:TabPanel>



            <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="Item">
                <ContentTemplate>
                    <div class="col-md-12" style="margin-top: 10px;">
                        <div class="col-md-12">
                            <asp:Label ID="lblItemmsg" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label>
                        </div>
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-4">Item group </div>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddlItemgroup" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlItemgroup_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-4">Item Name </div>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddlItemName" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-4"></div>
                                    <div class="col-md-8">
                                        <asp:Button ID="btn_ItemInfo" runat="server" ValidationGroup="Group1" Text="Submit"
                                            CssClass="btn btn-info pull-right" OnClick="btn_ItemInfo_Click" />

                                    </div>
                                </div>
                            </div>
                            <br />
                        </div>
                        <div class="col-md-12">
                            <div class="col-md-12">
                                <asp:GridView ID="grdItemInfos" runat="server" AutoGenerateColumns="False" Width="100%" BorderColor="#E3F0FC" CellPadding="5" AllowPaging="True" OnPageIndexChanging="gridviewSupplier_PageIndexChanging">
                                    <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                    <Columns>
                                        <asp:TemplateField Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblItem" runat="server" Text='<%# Eval("Id")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="SupplierCode" HeaderText="Supplier Code">
                                            <FooterStyle CssClass="Grid_Footer" />

                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />

                                            <ItemStyle HorizontalAlign="Center" Width="15%" CssClass="Grid_Border" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ProductId" HeaderText="ProductId">
                                            <FooterStyle CssClass="Grid_Footer" />

                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />

                                            <ItemStyle HorizontalAlign="Center" Width="6%" CssClass="Grid_Border" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="GroupId" HeaderText="GroupId">
                                            <FooterStyle CssClass="Grid_Footer" />

                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />

                                            <ItemStyle HorizontalAlign="Center" Width="6%" CssClass="Grid_Border" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgbtnItemEdit" runat="server" ImageUrl="img/list_edit.png"
                                                    OnClick="imgbtnItemEdit_Click" />

                                            </ItemTemplate>

                                            <ItemStyle Width="6%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                                        </asp:TemplateField>
                                    </Columns>

                                    <EmptyDataRowStyle ForeColor="Red" />

                                    <FooterStyle CssClass="Grid_Footer" />

                                    <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" />

                                    <PagerSettings Mode="NumericFirstLast" />

                                    <PagerStyle CssClass="pagination01 pageback" />

                                    <RowStyle CssClass="Grid_RowStyle" />
                                </asp:GridView>

                            </div>
                        </div>
                    </div>

                </ContentTemplate>











            </ajaxToolkit:TabPanel>

            <ajaxToolkit:TabPanel ID="TabPanel4" runat="server" HeaderText="Required document">
                <ContentTemplate></ContentTemplate>





            </ajaxToolkit:TabPanel>

            <ajaxToolkit:TabPanel ID="TabPanel5" runat="server" HeaderText="Attached document">
                <ContentTemplate>
                    <%--<uc1:Supplier_Documents ID="Supplier_Documents1" runat="server" />--%>
                    <div class="col-md-12">
                        <asp:Label ID="lblDocmsg" runat="server" Text=""></asp:Label>
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                        Description
                                    </div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtDescription" Class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                        Remarks
                                    </div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtRemarks" Class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                        File upload
                                    </div>
                                    <div class="col-md-8">
                                        <asp:FileUpload ID="FileUpload1" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                    </div>
                                    <div class="col-md-8">
                                        <asp:Button ID="btn_Submit" runat="server" Text="Submit" CssClass="btn btn-info pull-right" OnClick="btn_Submit_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </ContentTemplate>
            </ajaxToolkit:TabPanel>


        </ajaxToolkit:TabContainer>
    </div>
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
