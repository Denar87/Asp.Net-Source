<%@ Page Title="" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeReActive.aspx.cs" Inherits="ERPSSL.HRM.EmployeeReActive" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
       <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
     <div class="hm_sec_2_content scrollbar">
   <div class="panel">
        <div class="panel-heading panel-heading-01">
            <i class="fa fa-edit fa-fw icon-padding"></i>Employee R-Active
        </div>
    </div>
           
    
        <div class="row">
            <br />
            <div class="col-md-12">
                <div class="col-md-4">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-5">
                                E-ID
                            </div>
                            <div class="col-md-7">
                                <asp:TextBox ID="txtEid_TRNS" class="form-control"  OnTextChanged="txtEIdNo_TextChanged" AutoPostBack="True" runat="server"></asp:TextBox>                               
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
                                <asp:TextBox ID="txtEmpName_TRNS" ReadOnly="true" class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <br />
                    

                </div>
                <div class="col-md-4">
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
                    <br />
                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-5">
                                Designation
                            </div>
                            <div class="col-md-7">
                                <asp:TextBox ID="txtDesignation" ReadOnly="true" class="form-control" runat="server"></asp:TextBox>
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
                                <asp:Image ID="Emp_IMG_TRNS" ImageUrl="resources/no_image.png" CssClass="img-thumbnail pull-right" Width="80"
                                    runat="server" />
                            </div>
                        </div>
                    </div>
                    <br />
                    
                
            </div>
        </div>
        

        </div>

        <div class="panel panel-default">
  <!-- Default panel contents -->
  <div class="panel-heading">Conditon</div>
  <div class="panel-body">
      
       <div class="col-md-12">
   <asp:CheckBox ID="chewithPreviousData" runat="server" Text="With Previous Data" />
           </div>
       <div class="col-md-12">
   <asp:CheckBox ID="cheWithoutPreviousData" runat="server" Text="Without Previous Data" />
</div>
      
     
          <div class="col-md-1">
             Remarks
              </div>
          <div class="col-md-3">
              <asp:TextBox ID="txtRemarks_TRM" runat="server" CssClass="form-control"></asp:TextBox>
              </div>


      <div class="col-md-12">
            <asp:Button class="btn btn-info pull-right"  ID="Button2" runat="server" Text="Submit"
                                OnClick="btnSubmit_Click" />
          </div>
  </div>

  
</div>

    </div>    

    <script>

        function func(result) {
            if (result === 'Active Successfully!') {
                toastr.success(result);

            }
            else if (result === 'Please Input E-ID') {
                toastr.success(result);
            }
            else if (result === 'Please Select Condition') {
                toastr.success(result);
            }
            else
                toastr.error(result);

            return false;
        }

   </script>
</asp:Content>
