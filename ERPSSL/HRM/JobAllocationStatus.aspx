<%@ Page Title="" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true" CodeBehind="JobAllocationStatus.aspx.cs" Inherits="ERPSSL.HRM.JobAllocationStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="panel">
        <div class="panel-heading panel-heading-01">
            <i class="fa fa-edit fa-fw icon-padding"></i>Job Allocation Status
        </div>
    </div>
    <div class="hm_sec_2_content scrollbar">
        <fieldset style="border: none;">
            <div class="col-md-12" style="border-bottom: 1px solid black">
                <div class="col-md-9"></div>
                <div class="col-md-3">
                    <p>Job Allocation Code:<asp:Label ID="lblJobAllocationCode" runat="server"></asp:Label></p>
                </div>
            </div>
             <div class="col-md-12 bg-success">
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </div>
            <div class="col-md-12">
                <div class="col-md-2">
                    Reason:
                </div>
                <div class="col-md-10">
                    <asp:Label ID="lblReason" runat="server"></asp:Label>
                </div>
            </div>
            <div class="col-md-12">
                <div class="col-md-2">
                    Client Name:
                </div>
                <div class="col-md-10">
                    <asp:Label ID="lblClicentName" runat="server"></asp:Label>
                </div>
            </div>
            <div class="col-md-12">
                <div class="col-md-2">
                    Date:
                </div>
                <div class="col-md-10">
                    <asp:Label ID="lblDate" runat="server"></asp:Label>
                </div>
            </div>

            <div class="col-md-12">
                <br />
                <br />
                <div class="col-md-3">
                    <div>
                        <h5 style="padding-left: 20px">Status
                            </h5>
                            <div class="col-md-12">
                                <asp:DropDownList ID="drpdwnStatus"  CssClass="form-control"
                                    runat="server">
                                     <asp:ListItem Text="------- Select -------- " Value="0"></asp:ListItem>
                                    <asp:ListItem>Success</asp:ListItem>
                                     <asp:ListItem>Pending</asp:ListItem>
                                     <asp:ListItem>Cancel</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                     <div>
                        <h5 style="padding-left: 20px">Remark
                            </h5>
                            <div class="col-md-12">
                                <asp:TextBox ID="txtbxRemark" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                      <div class="col-md-12">
                          <br />
                      <asp:Button ID="btnStatusChange" runat="server" Text="Status Change" CssClass="btn-info"  OnClick="btnStatusChange_Click"  />
                           </div>
                    </div>

               
                <div class="col-md-9">
                    <div class="col-md-12">
            <asp:GridView ID="gridviewEmployeeList" runat="server" AutoGenerateColumns="False"
                Width="100%" CellPadding="5" AllowPaging="True" OnPageIndexChanging="gridviewEmployeeList_PageIndexChanging">
                <Columns>                   
                   
                    <asp:BoundField DataField="Eid" HeaderText="E-ID">
                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                        <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                        <FooterStyle CssClass="Grid_Footer" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Employee" HeaderText="Employee">
                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                        <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                        <FooterStyle CssClass="Grid_Footer" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Region" HeaderText="Region">
                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                        <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                        <FooterStyle CssClass="Grid_Footer" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Office" HeaderText="Office">
                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                        <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                        <FooterStyle CssClass="Grid_Footer" />
                    </asp:BoundField>

                    <asp:BoundField DataField="DepartmentName" HeaderText="Department">
                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                        <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                        <FooterStyle CssClass="Grid_Footer" />
                    </asp:BoundField>                  

                </Columns>
                <EmptyDataRowStyle ForeColor="Red" />
                <RowStyle CssClass="Grid_RowStyle" />
                <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                <PagerSettings Mode="NumericFirstLast" />
                <PagerStyle ForeColor="#000066" HorizontalAlign="Left" BackColor="White" CssClass="pagination01 pageback" />
                <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" />
                <FooterStyle CssClass="Grid_Footer" />
            </asp:GridView>
        </div




                </div>

            </div>

        </fieldset>
    </div>
</asp:Content>
