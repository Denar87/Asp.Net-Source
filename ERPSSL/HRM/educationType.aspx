<%@ Page Title="" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true" CodeBehind="educationType.aspx.cs" Inherits="ERPSSL.HRM.educationType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">

        <ContentTemplate>
           

            <div class="hm_sec_2_content scrollbar">
                 <div class="panel">
                <div class="panel-heading panel-heading-01">
                    <i class="fa fa-edit fa-fw icon-padding"></i>Education Type Setup
                </div>
            </div>
                <div class="row">
                    <div class="col-md-12 bg-success">
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </div>
                    <div class="col-md-12">
                        <br />
                        <div class="col-md-5">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-5">
                                        Education Type
                                    </div>
                                    <div class="col-md-7">
                                        <asp:TextBox ID="txtbxEducationType" runat="server" class="form-control"></asp:TextBox>
                                        <asp:HiddenField ID="hidEmployeeTypeId" runat="server" />

                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtbxEducationType"
                                            Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Education Type"
                                            ValidationGroup="GroupEducationType"></asp:RequiredFieldValidator>

                                    </div>
                                </div>
                            </div>
                            <br />


                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-5">
                                    </div>
                                    <div class="col-md-7">
                                        <asp:Button ID="btnEducationTypeSubmit" ValidationGroup="GroupEducationType" runat="server" Text="Submit" class="btn btn-info pull-right" OnClick="btnEducationTypeSubmit_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-7">
                            <asp:GridView ID="gridviewEducationType" runat="server" AutoGenerateColumns="False"
                                Width="100%" CellPadding="5" AllowPaging="True" OnPageIndexChanging="gridviewEducationType_PageIndexChanging">
                                <Columns>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="3%" HeaderStyle-HorizontalAlign="Center">
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
                                            <asp:Label ID="lblEducationTypeId" runat="server" Text='<%# Eval("EducationTypeID")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="EducationTypeName" HeaderText="Education Type">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgbtnEducationTypeEdit" runat="server" ImageUrl="img/list_edit.png" OnClick="imgbtnEducationTypeEdit_Click" />
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
            </div>
        </ContentTemplate>

        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnEducationTypeSubmit" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>

     <script>

         function func(result) {
             if (result === 'Data Save successfully!') {
                 toastr.success(result);

             }
             else if (result === 'Data Update successfully!') {
                 toastr.success(result);
             }
             else
                 toastr.error(result);

             return false;
         }

   </script>

</asp:Content>
