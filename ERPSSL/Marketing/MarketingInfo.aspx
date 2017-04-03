<%@ Page Title="" Language="C#" MasterPageFile="~/Marketing/Marketing.Master" AutoEventWireup="true" CodeBehind="MarketingInfo.aspx.cs" Inherits="ERPSSL.Marketing.MarketingInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="hm_sec_2_content scrollbar">
                    <div class="panel">
                        <div class="panel-heading panel-heading-01">
                            <i class="glyphicon glyphicon-edit icon-padding"></i>Marketing Information
                        </div>
                    </div>
                    <div class="col-md-12 bg-success">
                        <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label>
                        <asp:Label ID="lblMessageUpdate" runat="server" ForeColor="Green" Font-Size="13px"></asp:Label>
                    </div>

                    <div class="col-md-12">
                        <div class="row">
                            <div class="col-md-12" style="background-color: silver; padding-bottom: 10px;">
                                <%-- <fieldset>
                        <legend style="line-height: 0px; padding-top: 5px;"><span style="background: #fff">Order Entry </span></legend>--%>

                                <div class="col-md-4">
                                    <asp:HiddenField ID="hidMarketingInfoId" runat="server" />
                                    <div class="row">
                                        <asp:HiddenField ID="hidorderid" runat="server" />
                                        Visit Date
                                    <asp:TextBox ID="visitDateTextBox" Class=" form-control2 form-control " runat="server" placeholder="MM/dd/yyyy"></asp:TextBox>

                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="visitDateTextBox"
                                            PopupButtonID="visitDateTextBox" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                    </div>

                                    <div class="row">
                                        Client Name
                                    <asp:TextBox ID="clientNameTextBox" Class=" form-control2 form-control " runat="server"></asp:TextBox>
                                    </div>

                                    <div class="row">
                                        Contact Person
                                    <asp:TextBox ID="contactPersonTextBox" Class=" form-control2 form-control " runat="server"></asp:TextBox>
                                    </div>

                                    <div class="row">
                                        Designation
                                    <asp:TextBox ID="designationTextBox" Class=" form-control2 form-control " runat="server"></asp:TextBox>
                                    </div>

                                    <div class="row">
                                        Remarks
                                    <asp:TextBox ID="remarksTextBox" Class=" form-control2 form-control " runat="server" Width="204%"></asp:TextBox>
                                    </div>

                                </div>

                                <div class="col-md-4">

                                    <div class="row">
                                        Contact Number
                                    <asp:TextBox ID="contactNumberTextBox" Class=" form-control2 form-control " runat="server"></asp:TextBox>
                                    </div>

                                    <div class="row">
                                        E-Mail
                                    <asp:TextBox ID="emailTextBox" Class=" form-control2 form-control " runat="server"></asp:TextBox>
                                    </div>

                                    <div class="row">
                                        Address
                                    <asp:TextBox ID="addressTextBox" Class=" form-control2 form-control " runat="server"></asp:TextBox>
                                    </div>

                                    <div class="row">
                                        Reference <span>
                                            <asp:CheckBox ID="referenceCheckBox" runat="server" Width="10" OnCheckedChanged="referenceCheckBox_CheckedChanged" AutoPostBack="True" />
                                        </span>
                                        <asp:TextBox ID="referenceTextBox" Class=" form-control2 form-control " runat="server"></asp:TextBox>
                                        <asp:DropDownList ID="referenceDropDownList" Class=" form-control2 form-control " runat="server"></asp:DropDownList>
                                    </div>


                                </div>

                                <div class="col-md-4">

                                    <div class="row">
                                        Project<span>
                                            <asp:CheckBox ID="projectCheckBox" runat="server" Width="10" OnCheckedChanged="projectCheckBox_CheckedChanged" AutoPostBack="True" />
                                        </span>
                                    <asp:TextBox ID="projectTextBox" Class=" form-control2 form-control " runat="server"></asp:TextBox>
                                    <asp:DropDownList ID="projectDropDownList" AutoPostBack="false" CssClass="form-control" runat="server">
                                    </asp:DropDownList>
                                    </div>

                                    <div class="row">
                                        Module
                                    <asp:TextBox ID="moduleTextBox" Class=" form-control2 form-control " runat="server"></asp:TextBox>
                                    </div>

                                    <div class="row">
                                        Marketing Person
                                    <asp:DropDownList ID="marketingPersonDropDownList" CssClass="form-control" runat="server">
                                    </asp:DropDownList>
                                    </div>

                                    <div class="row">
                                        Stage
                                    <asp:DropDownList ID="stageDropDownList" AutoPostBack="false" CssClass="form-control" runat="server">
                                    </asp:DropDownList>
                                    </div>



                                    <div class="row" style="margin-top: 5px; padding-top: 10px;">
                                        <asp:Button ID="submitButton" runat="server" Text="Submit" class="btn btn-info pull-right" OnClick="submitButton_Click" />
                                    </div>

                                </div>



                                <%-- </fieldset>--%>
                            </div>


                           


                        </div>


                        <%-- Grid View Here --%>
                        <br />

                        <div class="row">

                             <div class="col-md-12">
                                Search
                                    <asp:TextBox ID="searchTextBox" Class=" form-control2 form-control " runat="server" placeholder="Insert Client Name for Search" BackColor="White" AutoPostBack="True" OnTextChanged="searchTextBox_TextChanged"></asp:TextBox>
                                <cc1:AutoCompleteExtender ServiceMethod="SearchClientName"
                                    MinimumPrefixLength="1"
                                    CompletionInterval="100" EnableCaching="False"
                                    TargetControlID="searchTextBox"
                                    ID="AutoCompleteExtender" runat="server" DelimiterCharacters="" Enabled="True" ServicePath="">
                                </cc1:AutoCompleteExtender>
                            </div>

                            <div class="col-md-12" style="padding-top:10px;">
                                <asp:GridView ID="marketingInfoGridView" runat="server" AutoGenerateColumns="False" Width="100%"
                                    CellPadding="5" AllowPaging="True" Style="text-align: center;" OnPageIndexChanging="marketingInfoGridView_PageIndexChanging">
                                    <Columns>

                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center">
                                            <HeaderTemplate>
                                                Sl. No
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblSRNO" runat="server"
                                                    Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                                        </asp:TemplateField>


                                        <asp:TemplateField Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMarketingInfo" runat="server" Text='<%# Eval("MarketingInfoId")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <%--<asp:BoundField DataField="ResionName" HeaderText="Resion Name">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>--%>
                                        <%-- <asp:TemplateField HeaderText="Division">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCategoryFSubCat" runat="server" Text='<%# Bind("HRM_Regions.RegionName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle CssClass="Grid_Footer" />
                                        <HeaderStyle CssClass="Grid_Header" VerticalAlign="Middle" />
                                        <ItemStyle CssClass="Grid_Border" HorizontalAlign="Left" Width="15%" />
                                    </asp:TemplateField>--%>
                                        <asp:BoundField DataField="VisitDate" HeaderText="Visit Date" DataFormatString="{0:MM/dd/yyyy}" />
                                        <asp:BoundField DataField="Client" HeaderText="Client Name" />
                                        <asp:BoundField DataField="ContactPerson" HeaderText="Contact Person">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Left" Width="20%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Designation" HeaderText="Designation" Visible="False">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ContactNumber" HeaderText="Contact Number">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                                            <FooterStyle CssClass="Grid_Footer" />
                                        </asp:BoundField>


                                        <asp:BoundField DataField="Email" HeaderText="E-Mail" Visible="False" />
                                        <asp:BoundField DataField="Address" HeaderText="Address" Visible="False" />
                                        <asp:BoundField DataField="ProjectName" HeaderText="Project Name" />
                                        <asp:BoundField DataField="Module" HeaderText="Module" Visible="False" />
                                        <asp:BoundField DataField="StageName" HeaderText="Stage Name" />
                                        <asp:BoundField DataField="MArketingPersonName" HeaderText="Marketing Person" />
                                        <asp:BoundField DataField="Remarks" HeaderText="Remarks" Visible="False" />


                                        <asp:TemplateField HeaderText="Update">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgbtnEdit" runat="server" ImageUrl="img/list_edit.png" OnClick="imgbtnEdit_Click" />
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
            </div>
        </ContentTemplate>

        <%--        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
        </Triggers>--%>
    </asp:UpdatePanel>
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
