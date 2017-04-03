<%@ Page Title="" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true"
    CodeBehind="Salary_Update.aspx.cs" Inherits="ERPSSL.Salary_Update" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">

        <ContentTemplate>
            <%--  <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
 
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>--%>
            <div class="hm_sec_2_content scrollbar">
                <asp:Panel ID="pnl_result" runat="server" Visible="false">
                    <div class="result">
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </div>
                </asp:Panel>
                <div class="panel">
                    <div class="panel-heading panel-heading-01">
                        <i class="fa fa-edit fa-fw icon-padding"></i>Salary Update
                    </div>
                </div>
                <asp:Label ID="lblstatus" runat="server" Text=""></asp:Label>

                <div class="row">
                    <fieldset>
                        <legend style="line-height: 0;"><span style="background: #fff;">Employee Information
                        </span></legend>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-6">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                E-ID
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtEid_LV" CssClass="form-control" runat="server" AutoPostBack="True"
                                                    OnTextChanged="txtEid_LV_TextChanged"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                    ControlToValidate="txtEid_LV" ErrorMessage="Enter EID"
                                                    ValidationGroup="UpdateSalary"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Employee Name
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtEmpName" ReadOnly="true" class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                <asp:Label ID="Label1" runat="server" Text="Grade"></asp:Label>
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtGrade" ReadOnly="true" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Department
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtDepartment" ReadOnly="true" class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Employee Photo
                                            </div>
                                            <div class="col-lg-7">
                                                <asp:Image ID="Emp_IMG_TRNS" ImageUrl="~/HRM/resources/no_image.png" CssClass="img-thumbnail"
                                                    Width="100px" Height="87px" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Designation
                                            </div>
                                            <div class="col-md-7">
                                                <%--  <asp:DropDownList ID="DropDownList1" CssClass="form-control " runat="server">
                            </asp:DropDownList>--%>
                                                <asp:DropDownList ID="DropDownList1" ReadOnly="true" CssClass="form-control" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Current Salary
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtCurrent_Salary" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </fieldset>
                    
                    <fieldset>
                        <legend style="line-height: 0;"><span style="background: #fff;">Salary Update</span></legend>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-6">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Basic
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtBasic" CssClass="form-control" ReadOnly="true" runat="server" AutoPostBack="True"
                                                    OnTextChanged="txtEid_LV_TextChanged"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                House Rent
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtHouseRent" ReadOnly="true" class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Medical
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtMedical" ReadOnly="true" class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Conveyance
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtConveynce" ReadOnly="true" class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                </div>
                                <div class="col-md-6">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Fixed Allowance
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtFixedAlo" ReadOnly="true" class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Food Allowance
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtbxFoodAllowance" ReadOnly="true" class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                Others
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtOther" ReadOnly="true" class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                <asp:Label ID="Label2" runat="server" Text="Gross Salary"></asp:Label>
                                            </div>
                                            <div class="col-md-7">
                                                <asp:TextBox ID="txtGrossSalary" runat="server" AutoPostBack="True" class="form-control"
                                                    OnTextChanged="txtGrossSalary_TextChanged"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtGrossSalary"
                                                    ErrorMessage="Enter Salary" ValidationGroup="UpdateSalary"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="col-md-5">
                                                </div>
                                                <div class="col-md-7">
                                                    <asp:Button ID="txtUpdate" runat="server" CssClass="btn btn-info pull-right" OnClick="txtUpdate_Click"
                                                        Text="Update" ValidationGroup="UpdateSalary" />
                                                </div>
                                            </div>
                                        </div>
                                    
                                </div>
                            </div>
                        </div>
                    </fieldset>
                </div>
            </div>
            <%--   </ContentTemplate>
    </asp:UpdatePanel>--%>
        </ContentTemplate>

        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="txtUpdate" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="txtEid_LV" EventName="TextChanged" />
            <asp:AsyncPostBackTrigger ControlID="txtGrossSalary" EventName="TextChanged" />
        </Triggers>
    </asp:UpdatePanel>

    <script type="text/javascript">

        function func(result) {

            if (result === 'This Employee is Inactive!') {
                toastr.error(result);
            }

            else if (result === 'Salary Update successfully!') {
                toastr.success(result);
            }
            return false;
        }

    </script>
</asp:Content>
