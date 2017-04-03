<%@ Page Title="" Language="C#" MasterPageFile="~/Marketing/Marketing.Master" AutoEventWireup="true" CodeBehind="ViewLastMonthCollection.aspx.cs" Inherits="ERPSSL.Marketing.ViewLastMonthCollection" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script language="javascript" type="text/javascript">
        function ShowIcon() {
            var e = document.getElementById("processing");
            e.style.visibility = (e.style.visibility == 'visible') ? 'hidden' : 'visible';
        }
        function ShowIcon_tr() {
            var et = document.getElementById("processing_tr");
            et.style.visibility = (et.style.visibility == 'visible') ? 'hidden' : 'visible';
        }
    </script>
    <style type="text/css">
        .imgwd {
            width: 88px;
        }

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

     <script src="content/js/bootstrap-datetimepicker.js" type="text/javascript"></script>

    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePageMethods="true" EnablePartialRendering="true" ID="ScriptManager1" />

    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="hm_sec_2_content scrollbar">
                    <div class="panel">
                        <div class="panel-heading panel-heading-01">
                            <i class="fa fa-edit fa-fw icon-padding"></i>View Last Month Collection
                        </div>
                    </div>
                    <br />
                
                    <%-- Grid View --%>

                    <div class="row" style="margin: auto 0;">
                        
                        <div class="col-md-12" style="margin: auto 0; padding-top:2px;">
                            

                            <asp:GridView ID="TransactionGridView" runat="server" AutoGenerateColumns="False" Width="100%"
                                        CellPadding="5" AllowPaging="True">
                                        <Columns>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="7%" HeaderStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    Sl No.
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSRNO" runat="server"
                                                        Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" Width="7%" />
                                            </asp:TemplateField>

                                            <asp:TemplateField Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblID_transaction" runat="server" Text='<%# Eval("TransactionId")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:BoundField DataField="Client" HeaderText="Client Name" />

                                            <asp:BoundField HeaderText="Collection Date" DataField="CollectionDate" DataFormatString="{0:MM/dd/yyyy}" />

                                            <asp:BoundField DataField="CollectionAmount" HeaderText="Collection Amount" DataFormatString="{0:0.00}" />

                                            <asp:BoundField HeaderText="Remarks" DataField="TRemarks" />

                                            <asp:TemplateField HeaderText="Edit" Visible="False">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgButtonEidtWordOrder" runat="server" ImageUrl="~/img/list_edit.png"/>
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
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function func(result) {
            if (result === 'Data Saved Successfully') {
                toastr.success(result);
            }
            else if (result === 'Data Save Successfully') {
                toastr.success(result);
            }
            else if (result === 'Data Updated Successfully') {
                toastr.success(result);
            }
            else
                toastr.error(result);
            return false;
        }
    </script> 

</asp:Content>
