<%@ Page Title="" Language="C#" MasterPageFile="~/LC/Site.Master" AutoEventWireup="true" CodeBehind="ConsumptionCalculation.aspx.cs"
    Inherits="ERPSSL.LC.ConsumptionCalculation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="hm_sec_2_content scrollbar">
                    <div class="panel">
                        <div class="panel-heading panel-heading-01">
                            <i class="glyphicon glyphicon-edit icon-padding"></i>Consumption Calculation
                        </div>
                    </div>
                    <div class="col-md-12 bg-success">
                        <center>
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label></center>
                    </div>
                    <div class="row">
                        <div class="col-md-12" style="margin: auto 0; padding: 0px;">
                            <div class="col-md-4">
                                <div class="row">
                                    <div class="col-md-4">
                                        Finish Goods
                                    </div>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddlFinishGoods" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlFinishGoods_SelectedIndexChanged"
                                            CssClass="form-control">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" Display="Dynamic" runat="server" SetFocusOnError="true"
                                            ControlToValidate="ddlFinishGoods" ErrorMessage="Please Select Finish Goods" ForeColor="Red"
                                            InitialValue="0" ValidationGroup="CC_LC"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="row">
                                    <div class="col-md-4">
                                        Buyer
                                    </div>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddlBuyer" runat="server" CssClass="form-control">
                                            <asp:ListItem>--Select Buyer--</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" SetFocusOnError="true" ControlToValidate="ddlBuyer"
                                            ErrorMessage="Select Buyer" Display="Dynamic" InitialValue="0" ForeColor="Red" ValidationGroup="CC_LC"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4" style="margin-left: -14px;">
                                <div class="row">
                                    <div class="col-md-4">
                                        Calculation Date
                                    </div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtCalculationDate" runat="server" placeholder="Calculation Date" class="form-control"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtCalculationDate"
                                            PopupButtonID="txtCalculationDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" SetFocusOnError="true" Display="Dynamic" ForeColor="Red"
                                            ControlToValidate="txtCalculationDate" ErrorMessage="Select Date" ValidationGroup="CC_LC"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12" style="margin: auto 0; padding: 0px; padding-top: 5px;">
                            <div class="col-md-12" style="margin: auto 0; padding: 0px; padding-top: 8px;">
                                <div class="col-md-12">
                                    <div class="col-md-3">
                                        A) GSM 
                                    </div>
                                    <div class="col-md-2">
                                        <asp:RadioButton ID="rdbGivenByDuyer" GroupName="rdb" ForeColor="#006600" runat="server" Text="Given By Buyer" />
                                    </div>
                                    <div class="col-md-2">
                                        <asp:RadioButton ID="rdbNotGivenByDuyer" GroupName="rdb" ForeColor="#800000" runat="server" Text="Not Given By Buyer" />
                                    </div>
                                    <div class="col-md-3" style="margin-top: -8px;">
                                        <asp:TextBox ID="TextBox1" runat="server" placeholder="Body" class="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2" style="margin-top: -8px;">
                                        <asp:TextBox ID="TextBox2" runat="server" placeholder="Neek/ Rib" class="form-control"></asp:TextBox>
                                    </div>
                                    <h1 style="padding-top: 8px;">
                                    </h>
                                </div>
                                <hr />
                                <div class="col-md-12" style="padding-top: 8px;">
                                    <div class="col-md-3">
                                        B) Sewing & Seamen Allowance 
                                    </div>
                                    <div class="col-md-2">
                                        <asp:RadioButton ID="rdbSSGivenByDuyer" GroupName="rdb1" ForeColor="#006600" runat="server" Text="Given By Buyer" />
                                    </div>
                                    <div class="col-md-2">
                                        <asp:RadioButton ID="rdbSSNotGivenByDuyer" GroupName="rdb1" ForeColor="#800000" runat="server" Text="Not Given By Buyer" />
                                    </div>
                                    <div class="col-md-5" style="margin-top: -8px;">
                                        <asp:TextBox ID="TextBox4" runat="server" placeholder="" class="form-control"></asp:TextBox>
                                    </div>
                                    <h1 style="padding-top: 8px;">
                                    </h>
                                </div>
                                <hr />
                                <div class="col-md-12" style="padding-top: 8px;">
                                    <div class="col-md-3">
                                        C) Wastages (%) 
                                    </div>
                                    <div class="col-md-2">
                                        <asp:RadioButton ID="rdbWGivenByDuyer" GroupName="rdb2" ForeColor="#006600" runat="server" Text="Given By Buyer" />
                                    </div>
                                    <div class="col-md-2">
                                        <asp:RadioButton ID="rdbNotWGivenByDuyer" GroupName="rdb2" ForeColor="#800000" runat="server" Text="Not Given By Buyer" />
                                    </div>
                                    <div class="col-md-5" style="margin-top: -8px;">
                                        <asp:TextBox ID="TextBox3" runat="server" placeholder="" class="form-control"></asp:TextBox>
                                    </div>
                                    <h1 style="padding-top: 8px;">
                                    </h>
                                </div>
                                <hr />
                                <div class="col-md-12">
                                    <div class="col-md-3">
                                        D) Measurement Chart
                                    </div>
                                    <div class="col-md-2">
                                        <asp:RadioButton ID="RadioButton3" GroupName="rdb3" ForeColor="#006600" runat="server" Text="Given By Buyer" />
                                    </div>
                                    <div class="col-md-2">
                                        <asp:RadioButton ID="RadioButton4" GroupName="rdb3" ForeColor="#800000" runat="server" Text="Not Given By Buyer" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="col-md-4">
                                </div>
                                <div class="col-md-8">
                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-info pull-right" ValidationGroup="CC_LC"
                                        OnClick="btnSubmit_Click" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12" style="padding-top: 10px; margin: 0 auto;">
                            <asp:GridView ID="grdMeasurement_Parameter" runat="server" AutoGenerateColumns="False" Width="100%"
                                CellPadding="5" AllowPaging="True" PageSize="10" OnPageIndexChanging="grdMeasurement_Parameter_PageIndexChanging">
                                <Columns>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            Sl No.
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblSRNO" runat="server"
                                                Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMagerment_Id" runat="server" Text='<%# Eval("Measurement_Id")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="MagermentName" HeaderText="Measurement Name">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FinishGoodsName" HeaderText="Finish Goods">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                        <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                        <FooterStyle CssClass="Grid_Footer" />
                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgButtonEidt" runat="server" ImageUrl="img/list_edit.png" />
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
            //if (result === 'Save Successfully') {
            //    toastr.success(result);

            //}
            if (result === 'Data Added Successfully') {
                toastr.success(result);
            }
            else if (result === 'Data Saving Failure') {
                toastr.error(result);
            }
            else if (result === 'Data Already Exist') {
                toastr.error(result);
            }

            else if (result === 'Data Updated Successfully') {
                toastr.success(result);
            }
            else if (result === 'Data deleted Sucessfully') {
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
