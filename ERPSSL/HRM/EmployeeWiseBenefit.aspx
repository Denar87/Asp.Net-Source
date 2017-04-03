<%@ Page Title="" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeWiseBenefit.aspx.cs" Inherits="ERPSSL.HRM.EmployeeWiseBenefit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
          
<ContentTemplate>

    <div class="hm_sec_2_content scrollbar">
        <div class="panel">
            <div class="panel-heading panel-heading-01">
                <i class="fa fa-edit fa-fw icon-padding"></i>Employee Wise Benefit
            </div>
        </div>
        <div class="col-md-12 bg-success">
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </div>
        <div class="row">
            <br />
            <div class="col-md-12">
                <div class="alert alert-danger" style="padding: 0px; padding-left: 10px" role="alert">
                    Employee select
                </div>
            </div>
            <div class="col-md-12">
                <div class="col-md-6">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-5">
                                Region
                            </div>
                            <div class="col-md-7">
                                <asp:DropDownList ID="ddlRegion" CssClass="form-control" runat="server"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:HiddenField ID="bebefitId" runat="server" />

                            </div>
                        </div>
                    </div>
                    <br />

                     <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-5">
                                Office
                            </div>
                            <div class="col-md-7">
                                <asp:DropDownList ID="ddlOffice" CssClass="form-control" runat="server"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlOffice_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>

                   




                </div>
                <div class="col-md-6">
                   
                     <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-5">
                                Department
                            </div>
                            <div class="col-md-7">
                                <asp:DropDownList ID="drpDepartment" CssClass="form-control" runat="server"
                                    AutoPostBack="True" OnSelectedIndexChanged="drpDepartment_SelectedIndexChanged">
                                </asp:DropDownList>

                            </div>
                        </div>
                    </div>

                    <br />

                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-5">
                                Employee
                            </div>
                            <div class="col-md-7">
                                <asp:DropDownList ID="drpEmployee" AutoPostBack="true" OnSelectedIndexChanged="drpEmployee_SelectedIndexChanged" CssClass="form-control" runat="server">
                                </asp:DropDownList>

                            </div>
                        </div>
                    </div>
                </div>




            </div>

        </div>
        <div class="col-md-12">
            <br />
            <div class="row">
                <div class="alert alert-danger" style="padding: 0px; padding-left: 10px" role="alert">
                    Employee Details
                </div>
            </div>
            <div class="col-md-12">
                <div class="col-md-4">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-5">
                                E-ID No
                            </div>
                            <div class="col-md-7">
                                <asp:TextBox ID="txtEid_TRNS" class="form-control" runat="server"></asp:TextBox>

                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-5">
                                Employee Name
                            </div>
                            <div class="col-md-7">
                                <asp:TextBox ID="txtEmpName_TRNS" class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>



                </div>
                <div class="col-md-4">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-5">
                                Department
                            </div>
                            <div class="col-md-7">
                                <asp:TextBox ID="txtDepartment" class="form-control" runat="server"></asp:TextBox>
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
                                <asp:TextBox ID="txtDesignation" class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-5">
                                Employee Photo
                            </div>
                            <div class="col-md-7">
                                <asp:Image ID="Emp_IMG_TRNS" ImageUrl="resources/no_image.png" CssClass="img-thumbnail" Width="120px" Height="120px"
                                    runat="server" />
                            </div>
                        </div>
                    </div>

                </div>

            </div>
        </div>

        <div class="col-md-12">
            <br />
            <div class="row">
                <div class="alert alert-danger" style="padding: 0px; padding-left: 10px" role="alert">
                    Employee Benefit
                </div>
            </div>
            <div class="col-md-12">
                <div class="col-md-4">
                    <div class="col-md-12">
                        <div class="col-md-5">
                            Benefit Type
                        </div>
                        <div class="col-md-7">
                            <asp:DropDownList ID="drpBenefitType" class="form-control" runat="server"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Group2"
                                runat="server" ControlToValidate="drpBenefitType" ErrorMessage="Select Benefit Type" InitialValue="0"></asp:RequiredFieldValidator>

                        </div>
                    </div>




                </div>
                <div class="col-md-4">
                    <div class="col-md-12">

                        <div class="col-md-5">
                            Amount
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="txtbxAmount" runat="server" class="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtbxAmount"
                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Amount"
                                ValidationGroup="Group2"></asp:RequiredFieldValidator>
                        </div>

                    </div>
                </div>
                <div class="col-md-4">
                    <div class="col-md-12">

                        <div class="col-md-5">
                            Effective Date
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox runat="server" ID="txtbxEffectiveDate" Class="form-control" placeholder="MM/dd/yyyy" />
                            <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtbxEffectiveDate"
                                PopupButtonID="txtbxEffectiveDate" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtbxEffectiveDate"
                                Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input Effective Date"
                                ValidationGroup="Group2"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                </div>
                <div class="col-md-12">
                    <br />
                    <div class="col-md-10">
                    </div>
                    <div class="col-md-2">
                        <asp:Button ID="btnSaveEmployeeWiseBebefit" ValidationGroup="Group2" class="btn btn-info  pull-right" runat="server" Text="Submit" OnClick="btnSaveEmployeeWiseBebefit_Click" />
                    </div>
                </div>



            </div>
        </div>
    </div>

    </ContentTemplate>
<Triggers>
 <asp:AsyncPostBackTrigger ControlID="btnSaveEmployeeWiseBebefit" EventName="Click" />
<asp:AsyncPostBackTrigger ControlID="ddlRegion" EventName="SelectedIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="drpDepartment" EventName="SelectedIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="ddlOffice" EventName="SelectedIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="drpEmployee" EventName="SelectedIndexChanged" />
</Triggers>
</asp:UpdatePanel>
    <script>

        function func(result) {

            if (result === 'This Employee is Inactive!') {
                toastr.error(result);
            }
            else if (result === 'Data Save Successfully') {
                toastr.success(result);
            }

            return false;
        }

   </script>
</asp:Content>
