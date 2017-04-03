<%@ Page Title="" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true" CodeBehind="Dataimport.aspx.cs" Inherits="ERPSSL.HRM.Dataimport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
       .LoaderBackground_ {
            /*background-color:;*/
            filter: alpha(opacity=90);
            opacity: 0.9;
            z-index: 999999999;
            overflow: hidden;
            width: 20%;
            height: 20%;
            position: absolute;
            margin: 170px 300px 0;
        }

        .LoaderBackground_Image {   
            display: block;
            position: absolute;
            left: 48%;
            top: 40%;
            width: 50px;
            height: 50px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
     <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
   <%-- <asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdWaitImage" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="UpdatePanel8">
                <ProgressTemplate>
                    <div class="LoaderBackground_">
                        <asp:Image ID="Image1" runat="server" CssClass="LoaderBackground_Image" ImageUrl="../content/image/busy.gif" />
                    </div>

                </ProgressTemplate>
            </asp:UpdateProgress>--%>
            <div class="hm_sec_2_content scrollbar">
                <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="glyphicon glyphicon-edit icon-padding"></i>Data Import
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12 bg-success">
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </div>
                    <div class="col-md-12">
                        <br />
                         <span class=" btn btn-info">Browse
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </span>
                        <div class="col-md-2">
                            <asp:Button ID="Button1" runat="server" class="form-control btn btn-info pull-right" Text="Import" OnClick="btnUpload_Click" />

                        </div>

                        <div class="col-md-2">
                            <asp:Button ID="btDelete" runat="server" class="form-control btn btn-info pull-right" Text="Delete" OnClick="btDelete_Click" />

                        </div>


                        <div class="col-md-2">
                            <asp:Button ID="btnConformation" runat="server" class="form-control btn btn-info pull-right" Text="Confirm" OnClick="btnConformation_Click" />

                        </div>
                    </div>
                    <br />
                </div>
                <div id="duMessage" runat="server">
                    <div class="alert alert-danger" style="padding: 0px; padding-left: 10px" role="alert">
                        Those are Duplicate Values. Please Chcek your File. If you want Save Without Duplicate Values Click Confirm Button 
                    </div>
                    <br />
                </div>
                <div class="col-md-7">
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
        <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
