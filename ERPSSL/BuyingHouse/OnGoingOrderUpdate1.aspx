<%@ Page Title="" Language="C#" MasterPageFile="~/BuyingHouse/BuyingSite.Master" AutoEventWireup="true" CodeBehind="OnGoingOrderUpdate1.aspx.cs" Inherits="ERPSSL.BuyingHouse.OnGoingOrderUpdate1" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

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
                    <i class="glyphicon glyphicon-edit icon-padding"></i>Order Status
                </div>
            </div>
            <div class="col-md-12 bg-success">
                <asp:HiddenField ID="hidLcNo" runat="server" />
                <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label>
                <asp:Label ID="lblMessageUpdate" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label>
            </div>

            <div class="col-md-12">
                <%--  <div class="row" style="margin-top: 5px">
                     <div class="col-md-4">
                        <div class="col-md-3">Order No</div>
                        <div class="col-md-9">
                            <asp:TextBox ID="txtOrderNo" runat="server" OnTextChanged="txtOrderNo_TextChanged" AutoPostBack="true" class="form-control"></asp:TextBox>
                            <cc1:AutoCompleteExtender ServiceMethod="SearchLCNo"
                                MinimumPrefixLength="1"
                                CompletionInterval="100" EnableCaching="False"
                                TargetControlID="txtOrderNo"
                                ID="AutoCompleteExtender2" runat="server" DelimiterCharacters="" Enabled="True" ServicePath="">
                            </cc1:AutoCompleteExtender>
                            <asp:Label ID="lblSeason" runat="server" Text="Label" Visible="false"></asp:Label>
                        </div>
                    </div>
                </div>--%>

                <div class="row" style="margin-top: 5px">
                    <div class="col-md-12" style="background-color: silver; padding-bottom: 10px;">
                        <%-- <fieldset>
                        <legend style="line-height: 0px; padding-top: 5px;"><span style="background: #fff">Order Entry </span></legend>--%>
                        <div class="col-md-3">
                            <div class="row">
                                Order No.
                                    <asp:TextBox ID="txtOrder" Class=" form-control2 form-control " runat="server" Enabled="false"  AutoPostBack="true" OnTextChanged="txtOrder_TextChanged"></asp:TextBox>
                                <cc1:AutoCompleteExtender ServiceMethod="SearchLCNo"
                                    MinimumPrefixLength="1"
                                    CompletionInterval="100" EnableCaching="False"
                                    TargetControlID="txtOrder"
                                    ID="AutoCompleteExtender2" runat="server" DelimiterCharacters="" Enabled="True" ServicePath="">
                                </cc1:AutoCompleteExtender>
                                <asp:Label ID="lblSeason" runat="server" Text="Label" Visible="false"></asp:Label>
                            </div>


                            <div class="row">
                                <asp:HiddenField ID="hidorderid" runat="server" />
                                Style
                                    <asp:TextBox ID="txtStyle" Class=" form-control2 form-control " Enabled="false" runat="server" placeholder=""></asp:TextBox>
                                <%--<ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtStyle"
                                    PopupButtonID="txtOrderReceivedDate"  CssClass="ajax__calendar" Enabled="True" />--%>
                            </div>

                            <div class="row">
                                Season
                                    <%--<asp:TextBox ID="TextBox1" Class=" form-control2 form-control " Enabled="false" runat="server"></asp:TextBox>--%>

                                    <asp:DropDownList ID="ddlSeason" AutoPostBack="true" Enabled="false" OnSelectedIndexChanged="ddlSeason_SelectedIndexChanged" CssClass="form-control" runat="server">
                                    </asp:DropDownList>
                            </div>
                            <div class="row">
                                TT Office.
                                    <asp:TextBox ID="txtTTOffice" Class=" form-control2 form-control " Enabled="false" runat="server"></asp:TextBox>
                            </div>



                            <div class="row">
                                Princpal
                                    <asp:TextBox ID="txtPrincpal" Class=" form-control2 form-control " runat="server" Enabled="false"></asp:TextBox>
                            </div>

                            <div class="row">
                                Merchandiser Dpt
                                   <asp:TextBox ID="txtMerchandiserDpt" Class=" form-control2 form-control " runat="server" Enabled="false"></asp:TextBox>
                            </div>

                        </div>

                        <div class="col-md-3">

                             <div class="row">
                                Merchandiser Name
                                   <asp:TextBox ID="txtMerchandiserName" Class=" form-control2 form-control " runat="server" Enabled="false"></asp:TextBox>
                            </div>

                            

                            <div class="row">
                               
                                    Buyer Department   
                                                                                              
                                 <asp:TextBox ID="txtBuyerDepartment" runat="server"  class="form-control" Enabled="false" Visible="true"></asp:TextBox>
                                </div>

                                

                            <div class="row">
                                Buyer
                                    <asp:TextBox ID="txtBuyer" Class=" form-control2 form-control " runat="server" Enabled="false"></asp:TextBox>
                            </div>

                            <div class="row">
                                Style Type
                                   <asp:TextBox ID="txtStylType" Class=" form-control2 form-control " runat="server" Text="0" Enabled="false"></asp:TextBox>
                            </div>
                            <div class="row">
                                Quota/Category 
                                   <asp:TextBox ID="txtQuota" Class="form-control2 form-control" runat="server" AutoPostBack="True" OnTextChanged="txtFob_TextChanged" Text="0" Enabled="false"></asp:TextBox>
                            </div>
                          <div class="row">
                                Custom/Style Description 
                                   <asp:TextBox ID="txtCustom" Class="form-control2 form-control" runat="server" AutoPostBack="True" OnTextChanged="txtFob_TextChanged" Text="0" Enabled="false"></asp:TextBox>
                            </div>

                        </div>

                        <div class="col-md-3">


                            <div class="row">
                                Trading/Commission
                                   <asp:TextBox ID="txtTrading" Class="form-control2 form-control " Enabled="false" runat="server"></asp:TextBox>
                            </div>
                            <div class="row">
                                Quotation Terms
                                   <asp:TextBox ID="txtQuotationTerms" Class="form-control2 form-control " placeholder="" runat="server" Enabled="false"></asp:TextBox>
                                <%--<ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate"
                                    PopupButtonID="txtDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />--%>
                            </div>

                            <%--<div class="row">
                                Buyer Department
                                    <asp:TextBox ID="txtBuyerDepartment" Class=" form-control2 form-control " runat="server" Enabled="false"></asp:TextBox>
                            </div>--%>
                            <div class="row">
                                Freight
                                    <asp:TextBox ID="txtFreight" Class=" form-control2 form-control " runat="server" Enabled="false"></asp:TextBox>
                            </div>

                            <div class="row">
                                Shipment Mode 
                                    <asp:TextBox ID="txtShipmentMode" Class=" form-control2 form-control " runat="server" Enabled="false"></asp:TextBox>

                            </div>

                            <div class="row">
                                Payment Terms 
                                    <asp:TextBox ID="txtPaymentTerms" Class=" form-control2 form-control " runat="server" Enabled="false"></asp:TextBox>

                            </div>

                            <div class="row">
                                Country of Production 
                                    <asp:TextBox ID="txtCountryProduction" Class=" form-control2 form-control " runat="server" Enabled="false"></asp:TextBox>

                            </div>

                        </div>

                        <div class="col-md-3">

                            <div class="row">
                                Garments Maker
                                    <asp:TextBox ID="txtGarmentMaker" Class=" form-control2 form-control " runat="server" placeholder="" Enabled="false"></asp:TextBox>
                                <%--<ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtDeliveryDate"
                                    PopupButtonID="txtDeliveryDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />--%>
                            </div>
                            <div class="row">
                               Buyer Price
                                    <asp:TextBox ID="txtBuyerPrice" Class=" form-control2 form-control " runat="server" placeholder="" Enabled="false"></asp:TextBox>
                                <%--<ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtLCReceivedDate"
                                    PopupButtonID="txtLCReceivedDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />--%>
                            </div>
                            <div class="row">
                               Currency
                                    <asp:TextBox ID="txtCurrency" Class=" form-control2 form-control " runat="server" Enabled="false"></asp:TextBox>

                            </div>

                            <div class="row">
                                      Contract Qty
                                    <asp:TextBox ID="txtContractQty" Class=" form-control2 form-control " Enabled="false" runat="server"></asp:TextBox>
                                <%--<asp:DropDownList ID="ddlShipmentMode" CssClass="form-control2 form-control" runat="server" Enabled="false">
                                    <asp:ListItem>---Select---</asp:ListItem>
                                    <asp:ListItem>By Air</asp:ListItem>
                                    <asp:ListItem>By Sea</asp:ListItem>
                                    <asp:ListItem>By Land</asp:ListItem>
                                </asp:DropDownList>--%>
                            </div>

                            <div class="row">
                                Unit
                                    <asp:TextBox ID="txtUnit" Class=" form-control2 form-control " runat="server" placeholder="" Enabled="false"></asp:TextBox>
                                <%--<ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtScheduleDate"
                                    PopupButtonID="txtScheduleDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />--%>
                            </div>
                           <div class="row">
                                      Total Amount
                                    <asp:TextBox ID="txtTotalAmount" Class=" form-control2 form-control " Enabled="false" runat="server"></asp:TextBox>
                               
                            </div>
                        </div>


                        <%-- </fieldset>--%>
                    </div>
                </div>



                <div class="row" style="margin-top: 5px">
                    <div class="col-md-12" style="padding-bottom: 10px;">


                        <div class="col-md-12" style="overflow-x: hidden; overflow-y: hidden; max-height: 400px; height: auto">

                            <asp:GridView ID="GridTask" runat="server" ShowFooter="True" Width="100%" DataKeyNames="TaskDetails_Id"
                                AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" BackColor="White"
                                BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3"
                                 OnPageIndexChanging="GridTask_PageIndexChanging"
                                OnRowCancelingEdit="GridTask_RowCancelingEdit"
                                OnRowEditing="GridTask_RowEditing"
                                OnRowUpdating="GridTask_RowUpdating"                                
                                  OnRowDataBound="GridTask_RowDataBound">                          
                             
                                <Columns>
                                  
                                     <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="2%" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            Sl No.
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblSRNO" runat="server"
                                                Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="6%" />
                                    </asp:TemplateField>
                                     <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="2%" HeaderStyle-HorizontalAlign="Center" Visible="false">

                                        <ItemTemplate>
                                            <asp:Label ID="lblID" runat="server"
                                                Text='<%# Bind("TaskDetails_Id") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="6%" />
                                    </asp:TemplateField>
                                      <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="2%" HeaderStyle-HorizontalAlign="Center" Visible="false" HeaderText="Phase">

                                        <ItemTemplate>
                                            <asp:Label ID="lblOrderID" runat="server"
                                                Text='<%# Bind("Order_No") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="6%" />
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Task">
                                        <%--  <EditItemTemplate>
                                                        <asp:TextBox ID="txtProductionProcess" runat="server" Text='<%# Bind("ProductionProcess") %>' CssClass="form-control"
                                                            MaxLength="30" Width="100%"></asp:TextBox>
                                                    </EditItemTemplate>--%>

                                        <ItemTemplate>
                                            <asp:Label ID="lblTask" runat="server" CssClass="form-control" Text='<%# Bind("Task") %>'></asp:Label>
                                        </ItemTemplate>

                                        <HeaderStyle Width="20%" />
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Schedule Date">

                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtSchedule_Date" runat="server" placeholder="MM/dd/yyyy" Text='<%# Bind("Schedule_Date") %>' CssClass="form-control"
                                                MaxLength="30" Width="100%"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtSchedule_Date"
                                                PopupButtonID="txtSchedule_Date" Format="MM/dd/yyyy" CssClass="ajax__calendar"
                                                Enabled="True" />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblSchedule_Date" runat="server" CssClass="form-control" Text='<%# Bind("Schedule_Date","{0:MM/dd/yyyy}") %>'></asp:Label>
                                        </ItemTemplate>

                                        <HeaderStyle Width="20%" />
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Status">

                                        <EditItemTemplate>
                                             <asp:DropDownList ID="ddlStatus" runat="server" Height="28px" Width="100%"></asp:DropDownList>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="ddlStatus" runat="server" CssClass="form-control" Text='<%# Bind("Status") %>'></asp:Label>
                                        </ItemTemplate>

                                        <HeaderStyle Width="20%" />
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Resposible Person">

                                        <EditItemTemplate>
                                             <asp:DropDownList ID="ddlResposiblePerson" runat="server" Height="28px" Width="100%"></asp:DropDownList>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblResposiblePerson" runat="server" CssClass="form-control" Text='<%# Bind("Responsible_Person") %>'></asp:Label>
                                        </ItemTemplate>

                                        <HeaderStyle Width="20%" />
                                    </asp:TemplateField>

                                   

                                    <asp:TemplateField HeaderText="Comments">

                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtComments" runat="server" Text='<%# Bind("Comments") %>' CssClass="form-control"
                                                MaxLength="30" Width="100%"></asp:TextBox>

                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblComments" runat="server" CssClass="form-control" Text='<%# Bind("Comments") %>'></asp:Label>
                                        </ItemTemplate>

                                        <HeaderStyle Width="20%" />
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Option" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkEdit" runat="server" Text="" CommandName="Edit" ToolTip="Edit"
                                                CommandArgument=''>
                                                <img id="Img1" src="~/img/edit.jpg" width="28" height="28" runat="server" />
                                            </asp:LinkButton>
                                            <%-- <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete"
                                                            ToolTip="Delete" OnClientClick='return confirm("Are you sure you want to delete this entry?");'
                                                            CommandArgument=''>
                                                            <img id="Img2" src="~/img/remove.png" runat="server" />
                                                        </asp:LinkButton>--%>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:LinkButton ID="lnkUpdate" runat="server" Text="" ValidationGroup="editGrp3"
                                                CommandName="Update" ToolTip="Save" CommandArgument=''>
                                                <img id="Img3" src="~/img/save.png" runat="server" />
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="lnkCancel" runat="server" Text="" CommandName="Cancel" ToolTip="Cancel"
                                                CommandArgument=''>
                                                <img id="Img4" src="~/img/cancle.png" runat="server" />
                                            </asp:LinkButton>
                                        </EditItemTemplate>

                                        <HeaderStyle Width="10%" />
                                    </asp:TemplateField>



                                




                                </Columns>
                                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                                <EmptyDataRowStyle ForeColor="Red" />
                                <RowStyle CssClass="Grid_RowStyle" BackColor="White" ForeColor="#333333" />
                                <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                                <PagerSettings Mode="NumericFirstLast" />
                                <PagerStyle ForeColor="White" HorizontalAlign="Left" BackColor="#336666" CssClass="pagination01 pageback" />
                                <HeaderStyle Width="10%" VerticalAlign="Middle" CssClass="Grid_Header" BackColor="#336666"
                                    Font-Bold="True" ForeColor="White" />
                                <FooterStyle CssClass="Grid_Footer" BackColor="White" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                <SortedAscendingHeaderStyle BackColor="#487575" />
                                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                <SortedDescendingHeaderStyle BackColor="#275353" />
                            </asp:GridView>
                        </div>




                    </div>
                </div>
                <div class="col-md-12" style="max-height: 400px;  height: auto">
                    <asp:Button ID="btnUpdate" runat="server" Visible="false" Text="Update" class="btn btn-info pull-right" ValidationGroup="Group1" OnClick="btnUpdate_Click" />
                </div>
            </div>


        </div>
    </div>

    <script type="text/javascript">
        function func(result) {
            if (result === 'Data Saved Successfully') {
                toastr.success(result);

            }
            else if (result === 'Data Post Successfully !') {
                toastr.success(result);
            }
            else if (result === 'Data Already Exist') {
                toastr.error(result);
            }

            else if (result === 'Data Updated Successfully') {
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
