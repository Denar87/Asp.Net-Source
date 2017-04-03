<%@ Page Title="" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true" CodeBehind="holiday.aspx.cs" Inherits="ERPSSL.HRM.holiday" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />

   

    <div class="hm_sec_2_content scrollbar">
         <div class="panel">
        <div class="panel-heading panel-heading-01">
            <i class="fa fa-edit fa-fw icon-padding"></i>Holiday Setup
        </div>
    </div>
        <div class="row">
            <div class="col-md-12 bg-success">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </div>
            <div class="col-md-12">
                <br />
                <div class="col-md-6">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-5">
                                Holiday Name
                            </div>
                            <div class="col-md-7">
                                <asp:TextBox ID="txtbxName" runat="server" class="form-control"></asp:TextBox>
                                <asp:HiddenField ID="hidHolidayId" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtbxName" Display="Dynamic" ForeColor="Red" Font-Size="11px" SetFocusOnError="True" ErrorMessage="Enter Company Name" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-5">
                                Holiday Type
                            </div>
                            <div class="col-md-7">
                                <asp:DropDownList ID="ddlHolidayType" AutoPostBack="True" class="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <br />

                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-5">
                                From Date
                            </div>
                            <div class="col-md-7">
                                <asp:TextBox ID="txtBxFromDate" runat="server" class="form-control" placeholder="MM/dd/yyyy"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtBxFromDate" PopupButtonID="txtBxFromDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                            </div>
                        </div>
                    </div>
                    <br />

                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-5">
                                To Date
                            </div>
                            <div class="col-md-7">
                                <asp:TextBox OnTextChanged="txtBxToDate_TextChanged" AutoPostBack="True" ID="txtBxToDate" runat="server" Class="form-control" placeholder="MM/dd/yyyy" />
                                <ajaxToolkit:CalendarExtender ID="calendarButtonExtender1" runat="server" TargetControlID="txtBxToDate" PopupButtonID="txtBxToDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                            
                            </div>
                        </div>
                    </div>
                    <br />

                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-5">
                                Total Date
                            </div>
                            <div class="col-md-7">
                                <asp:TextBox ID="txtBxTotalDay" ReadOnly="true" runat="server" Class="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <br />


                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-5">
                            </div>
                            <div class="col-md-7">
                                <asp:Button ID="btnSaveHolidays" runat="server" ValidationGroup="Group1" Text="Submit" CssClass="btn btn-info pull-right" OnClick="btnHolidays_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
            <asp:GridView ID="gridViewHolidays" runat="server" AutoGenerateColumns="False" Width="100%"
                CellPadding="5" AllowPaging="True" PageSize="10" OnPageIndexChanging="gridViewHolidays_PageIndexChanging">
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
                            <asp:Label ID="HolidayCode" runat="server" Text='<%# Eval("HolidayCode")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:BoundField DataField="HolidayName" HeaderText="Holiday Name">
                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                        <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                        <FooterStyle CssClass="Grid_Footer" />
                    </asp:BoundField>

                    <asp:BoundField DataField="HolidayTypeName" HeaderText="Holiday Type Name">
                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                        <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                        <FooterStyle CssClass="Grid_Footer" />
                    </asp:BoundField>

                    <%--<asp:TemplateField HeaderText="Holiday Type">
                        <ItemTemplate>
                            <asp:Label ID="lblPersonEID" runat="server" Text='<%# Bind("HRM_HOLIDAY_TYPE.HOLIDAY_TYPE_NAME") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterStyle CssClass="Grid_Footer" />
                        <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                        <ItemStyle CssClass="Grid_Border" HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                    </asp:TemplateField>--%>

                   

                     <asp:BoundField DataField="HolidayFromDate" HeaderText="Holiday From Date">
                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                        <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                        <FooterStyle CssClass="Grid_Footer" />
                    </asp:BoundField>


                     <asp:BoundField DataField="HolidayToDate" HeaderText="Holiday To Date">
                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                        <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                        <FooterStyle CssClass="Grid_Footer" />
                    </asp:BoundField>

                    <asp:TemplateField HeaderText="Update">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgbtnHolidayEdit" runat="server" ImageUrl="img/list_edit.png"
                                OnClick="imgbtnHolidayEdit_Click" />
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
        <br />

        
    </div>

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
