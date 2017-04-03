<%@ Page Title="" Language="C#" MasterPageFile="~/Visitor/Visitor_Site.Master" AutoEventWireup="true" CodeBehind="VisitorList.aspx.cs" Inherits="ERPSSL.Visitor.VisitorList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <%--<asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>--%>
    <div class="row">


        <div class="hm_sec_2_content scrollbar">
            <div class="panel">
                <div class="panel-heading panel-heading-01">
                    <i class="glyphicon glyphicon-edit icon-padding"></i>Visitor List
                </div>
            </div>
            <div class="col-md-12 bg-success">
                <center>
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label></center>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="col-md-6">
                         <asp:CheckBox ID="ckDatewise" AutoPostBack="true" OnCheckedChanged="ckDatewise_CheckedChanged" runat="server" Text="Date Wise Search" />
                    </div>
                    <div class="col-md-6">
                       
                    </div>
                </div>
                
            </div>
            <div class="row">
                <div class="col-md-12" style="margin-top: 10px;">
                    <div class="col-md-8">
                        <div class="col-md-5" id="fromdate" runat="server">
                            <div class="row">
                                <div class="col-md-12" style="padding-bottom: 5px" >
                                    <div class="col-md-5">
                                        From
                                    </div>
                                    <div class="col-md-7">
                                        <asp:TextBox runat="server" ID="txtvisitfrom" Class="form-control" placeholder="MM/dd/yyyy" />

                                        <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtvisitfrom"
                                            PopupButtonID="txtvisitfrom" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                    </div>


                                </div>
                            </div>
                        </div>
                        <div class="col-md-5" id="todate" runat="server">
                            <div class="row">
                                <div class="col-md-12" style="padding-bottom: 5px">
                                    <div class="col-md-5">
                                        To
                                    </div>
                                    <div class="col-md-7">
                                        <asp:TextBox runat="server" ID="txtvisitTo" Class="form-control" placeholder="MM/dd/yyyy" />

                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtvisitTo"
                                            PopupButtonID="txtvisitTo" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                    </div>


                                </div>
                            </div>
                        </div>
                         <div class="col-md-5" id="Searchbox" runat="server">
                            <div class="row">
                                <div class="col-md-12" style="padding-bottom: 5px">                                 
                                  
                                        <asp:TextBox ID="txtSearch" runat="server"  Class="form-control"  />


                                </div>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-12" style="margin-top: 10px;">
                    <div class="col-md-12">
                        <div class="row">
                            <asp:GridView ID="grVisitorInfo" runat="server" AutoGenerateColumns="False" Width="100%"
                                CellPadding="20" BackColor="White" BorderColor="#336666" BorderStyle="Solid"
                                BorderWidth="1px">
                                <Columns>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            Sl. No
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblSRNO" runat="server"
                                                Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Width="3%" />
                                    </asp:TemplateField>

                                    <asp:TemplateField Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblV_ID" runat="server" Text='<%# Eval("V_ID")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="VisitorName" HeaderText="Visitor Name">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ToWhom" HeaderText="To Whom">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Phone" HeaderText="Phone">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Purpose" HeaderText="Purpose">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CardNo" HeaderText="Card No">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="InTime" HeaderText="InTime" />
                                    <asp:BoundField DataField="OutTime" HeaderText="OutTime" />


                                    <%-- <asp:TemplateField HeaderText="Update">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgbtnVisitorEdit" runat="server" ImageUrl="~/Visitor/img/list_edit.png"
                                                OnClick="imgbtnVisitorEdit_Click" />
                                        </ItemTemplate>
                                        <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Grid_Border" />
                                    </asp:TemplateField>--%>
                                </Columns>
                                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                                <EmptyDataRowStyle ForeColor="Red" />
                                <RowStyle CssClass="Grid_RowStyle" BackColor="White" ForeColor="#333333" />
                                <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                <PagerSettings Mode="NumericFirstLast" />
                                <PagerStyle ForeColor="White" HorizontalAlign="Left" BackColor="#336666" CssClass="pagination01 pageback" />
                                <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" BackColor="#336666" Font-Bold="True" ForeColor="White" />
                                <FooterStyle CssClass="Grid_Footer" BackColor="White" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                <SortedAscendingHeaderStyle BackColor="#487575" />
                                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                <SortedDescendingHeaderStyle BackColor="#275353" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
    <script>

        function func(result) {
            if (result === 'Data Saved Successfully') {
                toastr.success(result);

            }
            else if (result === 'No Data Found') {
                toastr.error(result);
            }

            return false;
        }

    </script>
</asp:Content>
