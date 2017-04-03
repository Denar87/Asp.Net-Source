<%@ Page Title="" Language="C#" MasterPageFile="~/BuyingHouse/BuyingSite.Master" AutoEventWireup="true" CodeBehind="OnGoingOrderUpdate.aspx.cs" Inherits="ERPSSL.BuyingHouse.OnGoingOrderUpdate" %>


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
                    <i class="glyphicon glyphicon-edit icon-padding"></i>Order Details  
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
                                    <asp:TextBox ID="txtOrder" Class=" form-control2 form-control " runat="server" AutoPostBack="true" OnTextChanged="txtOrder_TextChanged"></asp:TextBox>
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
                                Order Received Date
                                    <asp:TextBox ID="txtOrderReceivedDate" Class=" form-control2 form-control " Enabled="false" runat="server" placeholder="MM/dd/yyyy"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtOrderReceivedDate"
                                    PopupButtonID="txtOrderReceivedDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                            </div>

                            <div class="row">
                                Season
                                    <asp:DropDownList ID="ddlSeason" AutoPostBack="true" Enabled="false" OnSelectedIndexChanged="ddlSeason_SelectedIndexChanged" CssClass="form-control" runat="server">
                                    </asp:DropDownList>
                            </div>
                            <div class="row">
                                Pre Order No.
                                    <asp:TextBox ID="txtPreOrderNo" Class=" form-control2 form-control " Enabled="false" runat="server"></asp:TextBox>
                            </div>



                            <div class="row">
                                Article
                                    <asp:TextBox ID="txtArticle" Class=" form-control2 form-control " runat="server" Enabled="false"></asp:TextBox>
                            </div>

                        </div>
                        <div class="col-md-3">



                            <div class="row">
                                Color/Specification
                                   <asp:TextBox ID="txtColor" Class=" form-control2 form-control " runat="server" Enabled="false"></asp:TextBox>
                            </div>

                            <div class="row">
                                <%--<div class="col-md-12" style="padding: 0px;">--%>
                                    Style   
                                <%--</div>--%>
                                <%-- <div class="col-md-11" style="margin-left: -14px;">--%>
                                <asp:DropDownList ID="ddlStyle" AppendDataBoundItems="True" CssClass="form-control2 form-control" runat="server" Enabled="false">
                                </asp:DropDownList>
                                <%-- <asp:TextBox ID="txtStyle" runat="server" Width="116%" class="form-control" Visible="false"></asp:TextBox>
                                </div>--%>

                                <%-- <div class="col-md-1" style="margin-top: 8px; margin-left: 6px">
                                    <asp:CheckBox ID="chkNewstyle" runat="server" Visible="true" AutoPostBack="True" OnCheckedChanged="chkNewstyle_CheckedChanged"></asp:CheckBox>
                                </div>--%>
                            </div>

                            <div class="row">
                                Size
                                    <asp:TextBox ID="txtsize" Class=" form-control2 form-control " runat="server" Enabled="false"></asp:TextBox>
                            </div>

                            <div class="row">
                                Order Qty
                                   <asp:TextBox ID="txtOrderQty" Class=" form-control2 form-control " runat="server" Text="0" Enabled="false"></asp:TextBox>
                            </div>
                            <div class="row">
                                FOB($) 
                                   <asp:TextBox ID="txtFob" Class="form-control2 form-control" runat="server" AutoPostBack="True" OnTextChanged="txtFob_TextChanged" Text="0" Enabled="false"></asp:TextBox>
                            </div>


                        </div>

                        <div class="col-md-3">


                            <div class="row">
                                Value
                                   <asp:TextBox ID="txtValue" Class="form-control2 form-control " Enabled="false" runat="server"></asp:TextBox>
                            </div>
                            <div class="row">
                                Shipment Date
                                   <asp:TextBox ID="txtDate" Class="form-control2 form-control " placeholder="MM/dd/yyyy" runat="server" Enabled="false"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate"
                                    PopupButtonID="txtDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                            </div>

                            <div class="row">
                                Buyer Department
                                    <asp:TextBox ID="txtBuyerDepartment" Class=" form-control2 form-control " runat="server" Enabled="false"></asp:TextBox>
                            </div>
                            <div class="row">
                                Supplier No
                                    <asp:TextBox ID="txtSupplierNo" Class=" form-control2 form-control " runat="server" Enabled="false"></asp:TextBox>
                            </div>

                            <div class="row">
                                Yarn/Fabrication
                                    <asp:TextBox ID="txtYarnFabrication" Class=" form-control2 form-control " runat="server" Enabled="false"></asp:TextBox>

                            </div>

                        </div>

                        <div class="col-md-3">

                            <div class="row">
                                Delivery Date
                                    <asp:TextBox ID="txtDeliveryDate" Class=" form-control2 form-control " runat="server" placeholder="MM/dd/yyyy" Enabled="false"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtDeliveryDate"
                                    PopupButtonID="txtDeliveryDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                            </div>
                            <div class="row">
                                LC Received Date
                                    <asp:TextBox ID="txtLCReceivedDate" Class=" form-control2 form-control " runat="server" placeholder="MM/dd/yyyy" Enabled="false"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtLCReceivedDate"
                                    PopupButtonID="txtLCReceivedDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                            </div>
                            <div class="row">
                                FOB Port
                                    <asp:TextBox ID="txtFOBPort" Class=" form-control2 form-control " runat="server" Enabled="false"></asp:TextBox>

                            </div>

                            <div class="row">
                                Shipment Mode
                                   <%-- <asp:TextBox ID="txtShipmentMode" Class=" form-control2 form-control " runat="server"></asp:TextBox>--%>
                                <asp:DropDownList ID="ddlShipmentMode" CssClass="form-control2 form-control" runat="server" Enabled="false">
                                    <asp:ListItem>---Select---</asp:ListItem>
                                    <asp:ListItem>By Air</asp:ListItem>
                                    <asp:ListItem>By Sea</asp:ListItem>
                                    <asp:ListItem>By Land</asp:ListItem>
                                </asp:DropDownList>
                            </div>

                            <div class="row">
                                Schedule Date
                                    <asp:TextBox ID="txtScheduleDate" Class=" form-control2 form-control " runat="server" placeholder="MM/dd/yyyy" Enabled="false"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtScheduleDate"
                                    PopupButtonID="txtScheduleDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                            </div>
                            <%--<div class="row" style="margin-top: 5px;">
                                <asp:Button ID="btnSubmit" runat="server" Text="Add" class="btn btn-info pull-right" ValidationGroup="Group1" OnClick="btnSubmit_Click" />
                            </div>--%>
                        </div>


                        <%-- </fieldset>--%>
                    </div>
                </div>



                <div class="row" style="margin-top: 5px">
                    <div class="col-md-12" style="padding-bottom: 10px;">


                        <div class="col-md-12" style="height: auto">

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
                                            <asp:TextBox ID="txtSchedule_Date" runat="server" Enabled="false" placeholder="MM/dd/yyyy" Text='<%# Bind("Schedule_Date") %>' CssClass="form-control"
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
                                            <asp:DropDownList ID="ddlStatus" runat="server" Enabled="false" Height="28px" Width="100%"></asp:DropDownList>
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
                <div class="col-md-12" style="max-height: 400px; height: auto">
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
