<%@ Page Title="" Language="C#" MasterPageFile="~/Marketing/Marketing.Master" AutoEventWireup="true" CodeBehind="VisitStatusUpdate.aspx.cs" Inherits="ERPSSL.Marketing.VisitStatusUpdate" %>

  <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

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
                            <i class="glyphicon glyphicon-edit icon-padding"></i>Visit Status Update
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
                                   

                                    <div class="row">
                                        Client Name
                                    <asp:TextBox ID="clientNameTextBox" Class=" form-control2 form-control " runat="server" OnTextChanged="clientNameTextBox_TextChanged" AutoPostBack="True"></asp:TextBox>
                                        <cc1:AutoCompleteExtender ServiceMethod="SearchClientName"
                                    MinimumPrefixLength="1"
                                    CompletionInterval="100" EnableCaching="False"
                                    TargetControlID="clientNameTextBox"
                                    ID="AutoCompleteExtender" runat="server" DelimiterCharacters="" Enabled="True" ServicePath="">
                                </cc1:AutoCompleteExtender>
                                        <asp:HiddenField ID="HidMarketingInfoId" runat="server" />
                                        <asp:HiddenField ID="HiddenFieldworkOrderId" runat="server" />
                                    </div>

                                    <div class="row">
                                       
                                        Visit Date
                                    <asp:TextBox ID="visitDateTextBox" Class=" form-control2 form-control " Enabled="False" runat="server" placeholder="MM/dd/yyyy"></asp:TextBox>
                                        
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="visitDateTextBox"
                                            PopupButtonID="visitDateTextBox" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                    </div>

                                    <div class="row">
                                        Contact Person
                                    <asp:TextBox ID="contactPersonTextBox" Class=" form-control2 form-control "  runat="server" Enabled="False"></asp:TextBox>
                                    </div>

                                    <div class="row">
                                        Designation
                                    <asp:TextBox ID="designationTextBox" Class=" form-control2 form-control " runat="server" Enabled="False"></asp:TextBox>
                                    </div>

                                    <div class="row">
                                        Remarks
                                    <asp:TextBox ID="remarksTextBox" Class=" form-control2 form-control " Width="283%" runat="server" Enabled="False"></asp:TextBox>
                                    </div>

                                </div>

                                <div class="col-md-4">

                                    <div class="row">
                                        Contact Number
                                    <asp:TextBox ID="contactNumberTextBox" Class=" form-control2 form-control " runat="server" Enabled="False"></asp:TextBox>
                                    </div>

                                    <div class="row">
                                        E-Mail
                                    <asp:TextBox ID="emailTextBox" Class=" form-control2 form-control " runat="server" Enabled="False"></asp:TextBox>
                                    </div>

                                    <div class="row">
                                        Address
                                    <asp:TextBox ID="addressTextBox" Class=" form-control2 form-control " runat="server" Enabled="False"></asp:TextBox>
                                    </div>

                                    <div class="row">
                                        Reference
                                    <asp:TextBox ID="referenceTextBox" Class=" form-control2 form-control " runat="server" Enabled="False"></asp:TextBox>
                                    </div>

                                    

                                </div>

                                <div class="col-md-4">
                                    
                                    <div class="row">
                                        Project
                                    <asp:TextBox ID="projectTextBox" Class=" form-control2 form-control " runat="server" Enabled="False"></asp:TextBox>
                                    </div>

                                    <div class="row">
                                        Module
                                    <asp:TextBox ID="moduleTextBox" Class=" form-control2 form-control " runat="server" Enabled="False"></asp:TextBox>
                                    </div>

                                    <div class="row">
                                        Marketing Person
                                    <asp:TextBox ID="marketingPersonTextBox" Class=" form-control2 form-control " runat="server" Enabled="False"></asp:TextBox>
                                    </div>

                                    <div class="row">
                                        Stage
                                    <asp:TextBox ID="stageTextBox" Class=" form-control2 form-control " runat="server" Enabled="False"></asp:TextBox>
                                    </div>
                                    

                                    <div class="row" style="margin-top: 15px;">
                                        <asp:Button ID="submitButton" runat="server" Text="Submit" class="btn btn-info pull-right"/>
                                    </div>

                                </div>



                                <%-- </fieldset>--%>
                            </div>
                        </div>


                        <%-- Grid View Here --%>
                        <br />

                        <div class="row">
                            <div class="col-md-12">
                                <div class="row" style="margin-top: 5px">
                    <div class="col-md-12" style="padding-bottom: 10px;">


                        <div class="col-md-12" style="overflow-x: hidden; overflow-y: hidden; max-height: 400px; height: auto">

                            <asp:GridView ID="GridTask" runat="server" ShowFooter="True" Width="100%" DataKeyNames="TaskDetails_Id"
                                AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" BackColor="White"
                                BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3"
                                
                                OnRowCancelingEdit="GridTask_RowCancelingEdit"
                                OnRowEditing="GridTask_RowEditing"
                                OnRowUpdating="GridTask_RowUpdating" OnPageIndexChanging="GridTask_PageIndexChanging">                          
                             
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
                                                Text='<%# Bind("WorkOrderId") %>'></asp:Label>
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
                                            <asp:TextBox ID="txtSchedule_Date" runat="server" placeholder="MM/dd/yyyy" Text='<%# Bind("Date") %>' CssClass="form-control"
                                                MaxLength="30" Width="100%"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtSchedule_Date"
                                                PopupButtonID="txtSchedule_Date" Format="MM/dd/yyyy" CssClass="ajax__calendar"
                                                Enabled="True" />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblSchedule_Date" runat="server" CssClass="form-control" Text='<%# Bind("Date","{0:MM/dd/yyyy}") %>'></asp:Label>
                                        </ItemTemplate>

                                        <HeaderStyle Width="20%" />
                                    </asp:TemplateField>

                                     <%--<asp:TemplateField HeaderText="Status">

                                        <EditItemTemplate>
                                             <asp:DropDownList ID="ddlStatus" runat="server" Height="28px" Width="100%"></asp:DropDownList>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="ddlStatus" runat="server" CssClass="form-control" Text='<%# Bind("Status") %>'></asp:Label>
                                        </ItemTemplate>

                                        <HeaderStyle Width="20%" />
                                    </asp:TemplateField>--%>

                                     <%--<asp:TemplateField HeaderText="Resposible Person">

                                        <EditItemTemplate>
                                             <asp:DropDownList ID="ddlResposiblePerson" runat="server" Height="28px" Width="100%"></asp:DropDownList>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblResposiblePerson" runat="server" CssClass="form-control" Text='<%# Bind("Responsible_Person") %>'></asp:Label>
                                        </ItemTemplate>

                                        <HeaderStyle Width="20%" />
                                    </asp:TemplateField>--%>

                                    <asp:TemplateField HeaderText="Remarks">

                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtRemarks" runat="server" Text='<%# Bind("Remarks") %>' CssClass="form-control"
                                                MaxLength="30" Width="100%"></asp:TextBox>

                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblRemarks" runat="server" CssClass="form-control" Text='<%# Bind("Remarks") %>'></asp:Label>
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
