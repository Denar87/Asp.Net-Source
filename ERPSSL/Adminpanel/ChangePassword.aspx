<%@ Page Title="" Language="C#" MasterPageFile="~/Adminpanel/Site.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="ERPSSL.Adminpanel.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <%--<div class="row">
       
            <div class="col-md-12 bg-success">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </div>
            
        <div class="col-md-12">
            <div class="col-md-6">
                <div class="form-group">
                    <label class="control-label" for="inputFname1">
                        Current password</label>
                    <div class="controls">
                        <asp:TextBox ID="txtCurrentPass" TextMode="Password" runat="server" CssClass="form-control" Width="60%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtCurrentPass"
                            ForeColor="Red" ValidationGroup="FormValidation" ErrorMessage="Please Enter Current Password!!"
                            runat="server" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label" for="inputFname1">
                        New password</label>
                    <div class="controls">
                        <asp:TextBox ID="txtNewPass" TextMode="Password" runat="server" CssClass="form-control" Width="60%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtNewPass"
                            ForeColor="Red" ValidationGroup="FormValidation" ErrorMessage="Please Enter New Password!!"
                            runat="server" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label" for="inputFname1">
                        Confirm new password</label>
                    <div class="controls">
                        <asp:TextBox ID="txtConfirmPass" TextMode="Password" runat="server" CssClass="form-control" Width="60%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtConfirmPass"
                            ForeColor="Red" ValidationGroup="FormValidation" ErrorMessage="Please Enter Confirm Password!!"
                            runat="server" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <div class="form-group">
                        <asp:Button ID="BtnChange" runat="server" ValidationGroup="FormValidation" CssClass="btn btn-info" OnClick="BtnChange_Clik"
                            Text="Change Password" />
                    </div>
                </div>
            </div>
        </div>
    </div>--%>


    <div class="hm_sec_2_content scrollbar">
        <div class="panel">
            <div class="panel-heading panel-heading-01">
                <i class="fa fa-edit fa-fw icon-padding"></i>Change Password
            </div>
        </div>
        <div class="col-md-12 bg-success">
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </div>
        <div class="col-md-12">
            <div class="col-md-6">
                <div class="row">
                    <label class="control-label" for="inputFname1">
                        User Name<a style="color: red; font-size: 11px">*</a></label> 
                    <div class="controls">
                        <asp:DropDownList ID="drpUserName" runat="server" CssClass="form-control" Width="60%" AutoPostBack="true"
                            OnSelectedIndexChanged="drpUserName_SelectedIndexChanged">
                        </asp:DropDownList>

                    </div>
                </div>

                <div class="row">
                    <label class="control-label" for="inputFname1">
                        Current password</label>
                    <div class="controls">
                        <asp:TextBox ID="txtCurrentPass" runat="server" Enabled="false" CssClass="form-control" Width="60%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtCurrentPass"
                            ForeColor="Red" ValidationGroup="FormValidation" ErrorMessage="Please Enter Current Password!!"
                            runat="server" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="row">
                    <label class="control-label" for="inputFname1">
                        New password</label>
                    <div class="controls">
                        <asp:TextBox ID="txtNewPass" TextMode="Password" runat="server" CssClass="form-control" Width="60%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtNewPass"
                            ForeColor="Red" ValidationGroup="FormValidation" ErrorMessage="Please Enter New Password!!"
                            runat="server" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <label class="control-label" for="inputFname1">
                        Confirm new password</label>
                    <div class="controls">
                        <asp:TextBox ID="txtConfirmPass" TextMode="Password" runat="server" CssClass="form-control" Width="60%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtConfirmPass"
                            ForeColor="Red" ValidationGroup="FormValidation"
                            runat="server" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtConfirmPass" CssClass="ValidationError" 
                            ControlToCompare="txtNewPass" ErrorMessage="No Match" ToolTip="Password must be the same" />
                    </div>
                </div>
                <div class="row" style="padding: 0px;">
                    <br />

                    <asp:Button ID="BtnChange" runat="server" ValidationGroup="FormValidation" CssClass="btn btn-info" OnClick="BtnChange_Clik"
                        Text="Change Password" />
                </div>
            </div>
        </div>
    </div>
    <script>

        function func(result) {
            //if (result === 'your Current Password is not Match.') {
            //    toastr.error(result);

            //}
            if (result === 'Password Change Successfully.') {
                toastr.success(result);

            }
            else if (result === 'These passwords do not match. Try again?') {
                toastr.success(result);
            }
            else
                toastr.error(result);

            return false;
        }

    </script>
</asp:Content>


