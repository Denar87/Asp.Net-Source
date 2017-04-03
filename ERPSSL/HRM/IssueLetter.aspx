<%@ Page Title="" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true" CodeBehind="IssueLetter.aspx.cs" validateRequest="false" Inherits="ERPSSL.HRM.IssueLetter" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

    <script src="tiny_mce/tiny_mce.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        tinyMCE.init({
            // General options
            mode: "textareas",
            theme: "advanced",
            plugins: "pagebreak,style,layer,table,save,advhr,advimage,advlink,emotions,iespell,inlinepopups,gsynuhimgupload,paste",
            theme_advanced_buttons3_add: "pastetext,pasteword,selectall",
            paste_auto_cleanup_on_paste: true,
            content_css: "css/custom_content.css",
            theme_advanced_font_sizes: "10px,11px,12px,13px,14px,16px,18px,20px,25px,30px,35px",
            font_size_style_values: "10px,11px,12px,13px,14px,16px,18px,20px,25px,30px,35px",
            theme_advanced_blockformats: "p,address,pre,div,h1,h2,h3,h4,h5,h6,blockquote,dt,dd,code,samp",


            // Theme options
            theme_advanced_buttons1: "save,newdocument,|,bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,justifyfull,|,styleselect,formatselect,fontselect,fontsizeselect,removeformat,cleanup",
            theme_advanced_buttons2: "cut,copy,paste,pastetext,pasteword,|,search,replace,|,bullist,numlist,|,outdent,indent,blockquote,|,undo,redo,|,link,unlink,anchor,image,gsynuhimgupload,cleanup,help,code,|,insertdate,inserttime,preview,|,forecolor,backcolor",
            theme_advanced_buttons3: "tablecontrols,|,hr,removeformat,visualaid,|,sub,sup,|,charmap,emotions,iespell,media,advhr,|,print,|,ltr,rtl,|,fullscreen,insertlayer,moveforward,movebackward,absolute,|,styleprops,spellchecker,|,cite,abbr,acronym,del,ins,attribs,|,visualchars,nonbreaking,template,blockquote,pagebreak,|,insertfile,insertimage",
            theme_advanced_buttons4: "",
            theme_advanced_toolbar_location: "top",
            theme_advanced_toolbar_align: "left",
            theme_advanced_statusbar_location: "bottom",
            plugin_insertdate_dateFormat: "%Y-%m-%d",
            plugin_insertdate_timeFormat: "%H:%M:%S",
            theme_advanced_resizing: true,
            theme_advanced_disable: "help,styleselect",
            skin: "o2k7",
            skin_variant: "silver",
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
   <%-- <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
          
<ContentTemplate>--%>
   <div class="hm_sec_2_content scrollbar">
        <div class="panel">
            <div class="panel-heading panel-heading-01">
                <i class="fa fa-edit fa-fw icon-padding"></i>Letter Format
            </div>
            <div class="col-md-12 bg-success">
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" Width="100%" OnDemand="true"
                    childrenastriggers="True" CssClass="ajax__myTab" ActiveTabIndex="0">
                    <ajaxToolkit:TabPanel runat="server" HeaderText="Formate Wise Letter" ID="TabPanel1"
                        OnDemandMode="None">
                        <ContentTemplate>
                            <div class="row">
                                <div class="panel">
                                    <div class="panel-heading panel-heading-01">
                                        <i class="fa fa-edit fa-fw icon-padding"></i>letter Issue
                                    </div>
                                </div>
                                <div class="">
                                    <div class="col-md-12 bg-success">
                                        <asp:Label ID="Label2" runat="server"></asp:Label>
                                    </div>

                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="col-md-3">
                                                        E-ID 
                                <asp:Label ID="lblHiddenId" runat="server" Visible="false"></asp:Label>
                                                    </div>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtEid_AT" Class="form-control" runat="server" AutoPostBack="True"
                                                            OnTextChanged="txtEid_AT_TextChanged"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="col-md-3">
                                                        Employee Name
                                                    </div>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtEmpName_AT" Class="form-control" runat="server" Enabled="False"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="col-md-3">
                                                        Department
                                                    </div>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtDepartment_AT" Class="form-control" runat="server" Enabled="False"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="col-md-3">
                                                        Designation
                                                    </div>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtDesignation_AT" Class="form-control" runat="server" Enabled="False"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                        </div>
                                        <div class="col-md-4">
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="col-md-3">
                                                        Photo
                                                    </div>
                                                    <div class="col-md-9">
                                                        <asp:Image ID="Emp_IMG_AT" runat="server" class="avater_details" Height="90px" ImageUrl="resources/no_image.png"
                                                            onerror="this.onerror=null" Width="90px" />
                                                    </div>
                                                    &nbsp
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                     <fieldset>
                                         
                                        <div class="col-md-12">
                                            <div class="col-md-5">
                                                <div class="col-md-4">
                                                    Letter Type
                                                </div>
                                                <div class="col-md-7">
                                                    <asp:DropDownList ID="drpLetterType" Class="form-control" AutoPostBack="true" OnSelectedIndexChanged="drpLetterTitle_SelecttedIndexChanged"
                                                        runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="col-md-5">
                                                <div class="col-md-4">
                                                    Letter Title
                                                </div>
                                                <div class="col-md-7">
                                                    <asp:DropDownList ID="drpdwnLetterTitle" Class="form-control" runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="col-md-2">
                                                <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary" Text="Seach"
                                                    OnClick="btnSearch_Click" />
                                            </div>
                                        </div>
                                    </fieldset>
                                    <br />
                                    <br />
                                    <div id="lformate" runat="server" class="col-md-12" style="margin-top: 10px;">
                                        <asp:TextBox ID="txtLatterDetails" runat="server" CssClass="textBox" TextMode="MultiLine"
                                            Height="300px" Width="100%"></asp:TextBox>
                                        <br />
                                        <asp:Button ID="btnProcess" runat="server" CssClass="btn btn-primary" Text="Print"
                                            OnClick="btnProcess_click" />
                                    </div>
                                    <br />
                                    <div class="col-md-12">

                                        <rsweb:ReportViewer ID="ReportViewerEmp" AsyncRendering="False" interactivedeviceinfos="(Collection)"
                                            SizeToReportContent="True" Width="100%" Height="700px" runat="server" Font-Names="Verdana"
                                            Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
                                        </rsweb:ReportViewer>
                                    </div>
                                    <hr />
                                </div>
                            </div>
                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>


                    <ajaxToolkit:TabPanel runat="server" HeaderText="Type Wise Letter" ID="TabPanel2"
                        OnDemandMode="None">
                        <ContentTemplate>


<%--                            <div class="col-md-12">
                                <fieldset>
                                    <legend style="line-height: 0;"><span style="background: #fff">Department Employee Report</span></legend>
                                    <div class="col-md-12">
                                        <div class="col-md-3">
                                            <div class="row">
                                                <h5 style="padding-left: 20px">Regions
                                                </h5>
                                                <div class="col-md-12">
                                                    <asp:DropDownList ID="ddlRegions" AutoPostBack="True" OnSelectedIndexChanged="drpdwnResionForDepartmentSelecttedIndexChanged" CssClass="form-control"
                                                        runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <br />
                                        </div>
                                        <div class="col-md-3">
                                            <div class="row">
                                                <h5 style="padding-left: 20px">Office
                                                </h5>
                                                <div class="col-md-12">
                                                    <asp:DropDownList ID="drpOffice" AutoPostBack="True" OnSelectedIndexChanged="onSelectedIndedexChangeOffice" CssClass="form-control"
                                                        runat="server">
                                                    </asp:DropDownList>
                                                </div>

                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="row">

                                                <h5 style="padding-left: 20px">Department
                                                </h5>
                                                <div class="col-md-12">
                                                    <asp:DropDownList ID="depDepartment" AutoPostBack="True" OnSelectedIndexChanged="drpdwnDepartmentSelectedIndexChange" CssClass="form-control"
                                                        runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <h5 style="padding-left: 20px">Blood Group
                                            </h5>
                                            <div class="col-md-12">
                                                <asp:DropDownList ID="ddlBloodGrp" Class="form-control" runat="server" CssClass="form-control">
                                                    <asp:ListItem Text="------- Select -------- " Value="0"></asp:ListItem>
                                                    <asp:ListItem Value="1">O +</asp:ListItem>
                                                    <asp:ListItem Value="2">O -</asp:ListItem>
                                                    <asp:ListItem Value="3">A +</asp:ListItem>
                                                    <asp:ListItem Value="4">A -</asp:ListItem>
                                                    <asp:ListItem Value="5">B +</asp:ListItem>
                                                    <asp:ListItem Value="6">B -</asp:ListItem>
                                                    <asp:ListItem Value="7">AB +</asp:ListItem>
                                                    <asp:ListItem Value="8">AB -</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ValidationGroup="GroupPersonalInfo"
                                                    runat="server" ControlToValidate="ddlBloodGrp" ErrorMessage="Select Blood Group"
                                                    InitialValue="0"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                </fieldset>
                            </div>--%>
                            <div class="col-md-12">
                            
                                <fieldset>
                                    <legend style="line-height: 0;"><span style="background: #fff">Employment Info</span></legend>

                                    <div class="col-md-12">
                                        <div class="col-md-5">
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="col-md-6">
                                                        E-ID 
                                <asp:Label ID="HiddenId" runat="server" Visible="false"></asp:Label>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <asp:TextBox ID="txtEid1_AT" Class="form-control" runat="server" AutoPostBack="True" OnTextChanged="txtEid1_AT_TextChanged"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="col-md-6">
                                                        Employee Name
                                                    </div>
                                                    <div class="col-md-6">
                                                        <asp:TextBox ID="txtEmpName1_AT" Class="form-control" AutoPostBack="true" runat="server" Enabled="False"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="col-md-4">
                                                        Department
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtDepartment1_AT" Class="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="col-md-4">
                                                        Designation
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtDesignation1_AT" Class="form-control" runat="server" Enabled="False"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                        </div>
                                        <div class="col-md-3">
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="col-md-6">
                                                        Photo
                                                    </div>
                                                    <div class="col-md-6">
                                                        <asp:Image ID="img2" runat="server" Target="_blank" class="avater_details" Height="90px" ImageUrl="resources/no_image.png"
                                                            onerror="this.onerror=null" Width="90px" />
                                                    </div>
                                                    &nbsp
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                            <div class="col-md-12">
                                <fieldset>
                                    <legend style="line-height: 0;"><span style="background: #fff">All Employee Report</span></legend>
                                    <div class="col-md-6">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div>
                                                    <br />
                                                     <asp:RadioButton ID="rdJobcertificate" runat="server" Text="Job Certification" GroupName="rpt_emp"
                                                        Font-Bold="True" /><br />
                                                    <asp:RadioButton ID="rdJobTransfer" runat="server" Text="Job Transfer" GroupName="rpt_emp"
                                                        Font-Bold="True" /><br />
                                                    <asp:RadioButton ID="rdAppointment" runat="server" Text="Appointment Letter" GroupName="rpt_emp"
                                                        Font-Bold="True" /><br />
                                                    <asp:RadioButton ID="rdTermination" runat="server" Text="Job Termination Letter" GroupName="rpt_emp"
                                                        Font-Bold="True" /><br />
                                                    <asp:RadioButton ID="rdIncrement" runat="server" Text="Salary Increment Letter" GroupName="rpt_emp"
                                                        Font-Bold="True" /><br />
                                                </div>
                                                <div class="col-md-12">
                                                    <asp:Button ID="btnProcess1" runat="server" Text="Process" Width="80px" OnClick="btnProcess1_Click"
                                                        CssClass="btn btn-info" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div>
                                                    <br /> 
                                                </div>
                                            </div>
                                        </div>

                                    </div>


                                </fieldset>
                                <br />
                                <br />
                            </div>


                        </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                </ajaxToolkit:TabContainer>

            </div>

        </div>
    </div>


<%--</ContentTemplate>
</asp:UpdatePanel>--%>
</asp:Content>
