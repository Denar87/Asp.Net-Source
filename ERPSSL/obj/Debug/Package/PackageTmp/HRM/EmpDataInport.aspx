<%@ Page Title="" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true" CodeBehind="EmpDataInport.aspx.cs" Inherits="ERPSSL.HRM.EmpDataInport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="hm_sec_2_content scrollbar">
        <div class="panel">
            <div class="panel-heading panel-heading-01">
                <i class="fa fa-edit fa-fw icon-padding"></i>Employee Data Import
            </div>
        </div>
        <div class="col-md-12">
            <div class="col-md-4">
                <fieldset>
                    <legend style="line-height: 5px;"><span style="background: #fff">Select for Items</span></legend>
                    <div class="col-md-12">
                    </div>
                    <div class="col-md-12" style="padding-left: 0px;">

                        <div class="row">
                            <div class="col-md-3" style="padding-left: 0px;">
                                Region
                            </div>
                            <div class="col-md-9" style="padding-left: 0px;">
                                <asp:DropDownList ID="ddlRegion1" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="drpdwnResion1ForDepartmentSelecttedIndexChanged"
                                    runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <br />
                    </div>

                    <div class="col-md-12" style="padding-left: 0px;">

                        <div class="row">

                            <div class="col-md-3" style="padding-left: 0px;">
                                Office
                            </div>
                            <div class="col-md-9" style="padding-left: 0px;">
                                <asp:DropDownList ID="ddlOffice1" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="onSelectedIndedexChangeOffice1"
                                    runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <br />
                    </div>

                    <div class="col-md-12" style="padding-left: 0px;">

                        <div class="row">
                            <%-- <h5 style="padding-left: 0px;">Department
                                    </h5>--%>
                            <div class="col-md-3" style="padding-left: 0px;">
                                Department
                            </div>
                            <div class="col-md-9" style="padding-left: 0px;">
                                <asp:DropDownList ID="ddlDept1" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="drpdwnDepartment1SelectedIndexChange"
                                    runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <br />
                    </div>

                    <div class="col-md-12" style="padding-left: 0px;">

                        <div class="row">
                            <%--<h5 style="padding-left: 0px;">Section
                                    </h5>--%>
                            <div class="col-md-3" style="padding-left: 0px;">
                                Section
                            </div>
                            <div class="col-md-9" style="padding-left: 0px;">
                                <asp:DropDownList ID="ddlSection" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="ddlSection_SelecttedIndexChanged"
                                    runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <br />
                    </div>
                    <div class="col-md-12" style="padding-left: 0px;">
                        <div class="row">
                            <%-- <h5 style="padding-left: 0px;">Sub-Section
                                    </h5>--%>
                            <div class="col-md-3" style="padding-left: 0px;">
                                Sub-Section
                            </div>
                            <div class="col-md-9" style="padding-left: 0px;">
                                <asp:DropDownList ID="ddlSubSections" AutoPostBack="True" CssClass="form-control"
                                    runat="server" OnSelectedIndexChanged="ddlSubSections_SelectedIndexChanged">
                                </asp:DropDownList>

                            </div>

                        </div>
                        <br />
                    </div>

                    <div class="col-md-12" style="padding-left: 0px;">
                        <div class="col-md-3" style="padding-left: 0px;">
                        </div>
                        <div class="col-md-9" style="padding-left: 0px;">
                             <asp:Button ID="btnProcess" runat="server" Text="Process" Width="80px" CssClass="btn btn-primary" OnClick="btnProcess_Clcik" />
                            <asp:Button ID="btnConfirm" runat="server" Text="Confirm" Width="80px" CssClass="btn btn-success" OnClick="btn_Confirm_Clcik" />
                        </div>
                        <br />
                    </div>
                </fieldset>
            </div>

            <div class="col-md-8">
                <br />
                <div class="alert alert-success" role="alert">
                    <h4>Note:</h4>
                    Please Download Excel Data Sheet And Input All Employee's Data Correctly.</div>
                <%--<asp:Button ID="btnDounload" runat="server" Text="Download" CssClass="btn btn-info pull-right" OnClick="btnDounload_Click" />--%>

                <div class="col-md-8">

                    <span class=" btn btn-info">Browse
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </span>

                </div>
                <div class="col-md-4">
                    <asp:ImageButton ID="imgbtnRegionEdit" runat="server" Width="80px" Height="80px" ImageUrl="../css/Image/ExeclImage.jpg" CssClass="pull-right" OnClick="btnDounload_Click" />
               <span class="icon-download-alt icon-large">            
                </span>

            </div>




        </div>
              <div class="col-md-12">
                    <asp:GridView ID="gridGridviewDublicate" runat="server" AutoGenerateColumns="False" Width="100%"
                        CellPadding="5" AllowPaging="True" PageSize="20" OnPageIndexChanging="gridGridviewDublicate_PageIndexChanging">
                        <Columns>
                            <%-- <asp:TemplateField Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblSection" runat="server" Text='<%# Eval("SEC_ID")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                            <asp:BoundField DataField="EID" HeaderText="EID">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FirstName" HeaderText="First Name">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>

                            <asp:BoundField DataField="LastName" HeaderText="Last Name">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>

                            <asp:BoundField DataField="BloodGroup" HeaderText="Blood">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>

                            <asp:BoundField DataField="BloodGroup" HeaderText="Blood">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>


                            <asp:BoundField DataField="ContactNumber" HeaderText="Contact Number">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>

                            <asp:BoundField DataField="Department" HeaderText="Department">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>

                            <asp:BoundField DataField="Section" HeaderText="Section">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>

                            <asp:BoundField DataField="Section" HeaderText="Section">
                                <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                <FooterStyle CssClass="Grid_Footer" />
                            </asp:BoundField>



                        </Columns>
                        <EmptyDataRowStyle ForeColor="Red" />
                        <RowStyle CssClass="Grid_RowStyle" />
                        <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                        <PagerStyle ForeColor="#000066" HorizontalAlign="Left" BackColor="White" CssClass="pagination01 pageback" />
                        <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" />
                        <FooterStyle CssClass="Grid_Footer" />
                    </asp:GridView>
                </div>
    </div>


    </div>

     <script>

         function func(result) {
             if (result === 'Data Process Successfully!') {
                 toastr.success(result);

             }
             else if (result === 'Process Confirm Successfully!') {
                 toastr.success(result);
             }
             else
                 toastr.error(result);

             return false;
         }

   </script>
</asp:Content>

