<%@ Page Title="" Language="C#" MasterPageFile="~/Marketing/Marketing.Master" AutoEventWireup="true" CodeBehind="ViewCurrentMonthVisit.aspx.cs" Inherits="ERPSSL.Marketing.ViewCurrentMonthVisit" %>
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
                            <i class="glyphicon glyphicon-edit icon-padding"></i>View Current Month Visit
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
                                    <asp:TextBox ID="visitDateTextBox" Class=" form-control2 form-control " Enabled="false" runat="server" placeholder="MM/dd/yyyy"></asp:TextBox>
                                        
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="visitDateTextBox"
                                            PopupButtonID="visitDateTextBox" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                                    </div>

                                    <div class="row">
                                        Client Name
                                    <asp:TextBox ID="clientNameTextBox" Class=" form-control2 form-control " runat="server" Enabled="false"></asp:TextBox>
                                    </div>

                                    <div class="row">
                                        Contact Person
                                    <asp:TextBox ID="contactPersonTextBox" Class=" form-control2 form-control " runat="server" Enabled="false"></asp:TextBox>
                                    </div>

                                    <div class="row">
                                        Designation
                                    <asp:TextBox ID="designationTextBox" Class=" form-control2 form-control " runat="server" Enabled="false"></asp:TextBox>
                                    </div>

                                    <div class="row">
                                        Remarks
                                    <asp:TextBox ID="remarksTextBox" Class=" form-control2 form-control " runat="server" Width="204%" Enabled="false"></asp:TextBox>
                                    </div>

                                </div>

                                <div class="col-md-4">

                                    <div class="row">
                                        Contact Number
                                    <asp:TextBox ID="contactNumberTextBox" Class=" form-control2 form-control " runat="server" Enabled="false"></asp:TextBox>
                                    </div>

                                    <div class="row">
                                        E-Mail
                                    <asp:TextBox ID="emailTextBox" Class=" form-control2 form-control " runat="server" Enabled="false"></asp:TextBox>
                                    </div>

                                    <div class="row">
                                        Address
                                    <asp:TextBox ID="addressTextBox" Class=" form-control2 form-control " runat="server" Enabled="false"></asp:TextBox>
                                    </div>

                                    <div class="row">
                                        Reference
                                    <asp:DropDownList ID="referenceDropDownList" Class=" form-control2 form-control " runat="server" Enabled="false"></asp:DropDownList>
                                    </div>
                                    

                                </div>

                                <div class="col-md-4">
                                    
                                    <div class="row">
                                        Project
                                    <asp:DropDownList ID="projectDropDownList" AutoPostBack="false" CssClass="form-control" runat="server" Enabled="false">
                                       
                                    </asp:DropDownList>
                                    </div>

                                    <div class="row">
                                        Module
                                    <asp:TextBox ID="moduleTextBox" Class=" form-control2 form-control " runat="server" Enabled="false"></asp:TextBox>
                                    </div>

                                    <div class="row">
                                        Marketing Person
                                    <asp:DropDownList ID="marketingPersonDropDownList"  CssClass="form-control" runat="server" Enabled="false">                                       
                                    </asp:DropDownList>
                                    </div>

                                    <div class="row">
                                        Stage
                                    <asp:DropDownList ID="stageDropDownList" AutoPostBack="false" CssClass="form-control" runat="server" Enabled="false">
                                       
                                    </asp:DropDownList>
                                    </div>

                                </div>



                                <%-- </fieldset>--%>
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
