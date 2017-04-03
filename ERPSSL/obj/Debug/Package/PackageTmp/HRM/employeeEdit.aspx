<%@ Page Title="" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true"
    CodeBehind="employeeEdit.aspx.cs" Inherits="ERPSSL.HRM.employeeEdit" %>

<%@ Register Src="~/HRM/UserControls/PersonalEdit.ascx" TagPrefix="PersonalControl"
    TagName="personaledit" %>
<%@ Register Src="~/HRM/UserControls/employementEdit.ascx" TagPrefix="employmentControl"
    TagName="employemntedit" %>

<%@ Register Src="~/HRM/UserControls/AssignToEdit.ascx" TagPrefix="AssignToControl"
    TagName="AssignTo" %>

<%@ Register Src="~/HRM/UserControls/TraningAcademic.ascx" TagPrefix="TraningAcademicControl"
    TagName="TraningAcademic" %>

<%@ Register Src="~/HRM/UserControls/ExperienceEdit.ascx" TagPrefix="ExperienceEditControl"
    TagName="Expericenceupdate" %>

<%@ Register Src="~/HRM/UserControls/ChildrenInfoEdit.ascx" TagPrefix="childrenControl"
    TagName="childrenupdate" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    
    <div class="hm_sec_2_content scrollbar">
        <div class="panel">
        <div class="panel-heading panel-heading-01">
            <i class="fa fa-edit fa-fw icon-padding"></i>Employee Edit
        </div>
    </div>

    <asp:Panel ID="pnl_result" runat="server" Visible="false">
        <div class="result">
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </div>
    </asp:Panel>
    <div>
        <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" Width="100%" OnDemand="true"
            childrenastriggers="True" CssClass="ajax__myTab" ActiveTabIndex="0">
            <ajaxToolkit:TabPanel runat="server" HeaderText="Personal Information" ID="TabPanel1"
                OnDemandMode="None">
                <ContentTemplate>
                    <PersonalControl:personaledit ID="personaledit1" runat="server" />
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel runat="server" HeaderText="Employment" ID="TabPanel2" OnDemandMode="None">
                <ContentTemplate>
                    <employmentControl:employemntedit ID="personaledit2" runat="server" />
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel runat="server" HeaderText="Academic/Training" ID="TabPanel4"
                OnDemandMode="None">
                <ContentTemplate>
                    <TraningAcademicControl:TraningAcademic ID="TraningAcadesmic" runat="server" />
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel runat="server" HeaderText="Experience" ID="TabPanel5" OnDemandMode="None">
                <ContentTemplate>
                    <ExperienceEditControl:Expericenceupdate ID="exprience" runat="server" />
                </ContentTemplate>
            </ajaxToolkit:TabPanel>

            <ajaxToolkit:TabPanel runat="server" HeaderText="Image Upload" ID="TabPanel6" OnDemandMode="None">
                <ContentTemplate>
                    <div class="row">
                        <div class="col-md-12 bg-success">
                            <asp:Label ID="lblImagemessage" runat="server"></asp:Label>
                        </div>
                        <div class="col-md-12">
                            <fieldset>
                                <div class="panel">
                                    <div class="panel-heading panel-heading-01">
                                        <i class="fa fa-edit fa-fw icon-padding"></i>Image Upload
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-12">
                                                <div class="col-md-5">
                                                    Employee Photo:
                                                </div>
                                                <div class="col-md-7">
                                                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="file_Upload" onchange="readfile(this);"
                                                        Width="85%" />
                                                </div>
                                            </div>
                                            <br />
                                            <div class="col-md-12">
                                                <div class="col-md-5">
                                                </div>
                                                <div class="col-md-7">
                                                    <asp:Image ID="Emp_IMG_TRNS" runat="server" class="avater_details" Height="150px"
                                                        ImageUrl="../resources/no_image.png" onerror="this.onerror=null; this.src='resources/no_image_found.png';"
                                                        Width="130px" />
                                                </div>
                                            </div>
                                            <br />
                                            <br />
                                            <div class="col-md-12">
                                                <div class="col-md-11">
                                                </div>
                                                <div class="col-md-1">
                                                    <asp:Button ID="btnimageUpload" runat="server" Text="Save" class="btn btn-info pull-right"
                                                        OnClick="btnimageUpload_Click" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                        </div>
                                    </div>
                                </div>
                            </fieldset>
                            <br />
                            <fieldset>
                                <div class="panel">
                                    <div class="panel-heading panel-heading-01">
                                        <i class="fa fa-edit fa-fw icon-padding"></i>Singnature Upload 
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-12">
                                                <div class="col-md-5">
                                                    Singnature:
                                                </div>
                                                <div class="col-md-7">
                                                    <asp:FileUpload ID="FileUpload2" runat="server" CssClass="file_Upload" onchange="readfile(this);"
                                                        Width="85%" />
                                                </div>
                                            </div>
                                            <br />
                                            <div class="col-md-12">
                                                <div class="col-md-5">
                                                </div>
                                                <div class="col-md-7">
                                                    <asp:Image ID="imgSinature" runat="server" class="avater_details" Height="150px"
                                                        ImageUrl="../resources/no_image.png" onerror="this.onerror=null; this.src='resources/no_image_found.png';"
                                                        Width="130px" />
                                                </div>
                                            </div>
                                            <br />
                                            <br />
                                            <div class="col-md-12">
                                                <div class="col-md-11">
                                                </div>
                                                <div class="col-md-1">
                                                    <asp:Button ID="btnSignature" runat="server" Text="Save" class="btn btn-info pull-right"
                                                        OnClick="btnSignature_Click" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                        </div>
                                    </div>
                                </div>
                            </fieldset>
                            <fieldset>
                                    <div class="panel">
                                        <div class="panel-heading panel-heading-01">
                                            <i class="glyphicon glyphicon-edit icon-padding"></i>Nominee Image Upload
                                        </div>
                                    </div>
                                    <div class="row">
                                        <br />
                                        <div class="col-md-12">
                                            <div class="col-md-3">
                                            </div>
                                            <div class="col-md-6">
                                                <div class="col-md-12">
                                                    <div class="col-md-5">
                                                        Nominee Photo:
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:FileUpload ID="FileUpload3" runat="server" CssClass="file_Upload" onchange="readfile(this);"
                                                            Width="85%" />
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="col-md-12">
                                                    <div class="col-md-5">
                                                    </div>
                                                    <div class="col-md-7">
                                                        <asp:Image ID="imagenominee" runat="server" class="avater_details" Height="150px"
                                                            ImageUrl="../resources/no_image.png" onerror="this.onerror=null; this.src='resources/no_image_found.png';"
                                                            Width="130px" />
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <div class="col-md-12">
                                                    <div class="col-md-11">
                                                    </div>
                                                    <div class="col-md-1">
                                                        <asp:Button ID="btnNominee" runat="server" Text="Save" class="btn btn-info pull-right" OnClick="btnNominee_Click" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                            </div>
                                        </div>
                                    </div>
                                </fieldset>
                        </div>
                    </div>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>

             <ajaxToolkit:TabPanel runat="server" HeaderText="Children's Info" ID="TabPanel7" OnDemandMode="None">
                <ContentTemplate>
                    <childrenControl:childrenupdate ID="Expericenceupdate1" runat="server" />
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel runat="server" HeaderText="Assign To" ID="TabPanel3" OnDemandMode="None">
                <ContentTemplate>
                    <AssignToControl:AssignTo ID="Assignto" runat="server" />
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
        </ajaxToolkit:TabContainer>
    </div>
        </div>

     <script>

         function func(result) {
             if (result === 'Data Save successfully!') {
                 toastr.success(result);

             }
             else if (result === 'Image Save Successfully!') {
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
