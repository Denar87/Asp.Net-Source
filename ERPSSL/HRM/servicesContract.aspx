<%@ Page Title="" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true" CodeBehind="servicesContract.aspx.cs" Inherits="ERPSSL.HRM.servicesContract" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

 <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        function CheckAll(chk) {
            all = document.getElementsByTagName("input");
            for (i = 0; i < all.length; i++) {
                if (all[i].type == "checkbox" && all[i].id.indexOf("dgvErp_child") > -1) {
                    all[i].checked = chk.checked;
                }
            }
        }
    </script>
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

    </script>  <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        function CheckAll(chk) {
            all = document.getElementsByTagName("input");
            for (i = 0; i < all.length; i++) {
                if (all[i].type == "checkbox" && all[i].id.indexOf("dgvErp_child") > -1) {
                    all[i].checked = chk.checked;
                }
            }
        }
    </script>
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
  
 <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<%--<asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
          
<ContentTemplate>--%>

 
    <div class="hm_sec_2_content scrollbar">
          <div class="panel">
        <div class="panel-heading panel-heading-01">
            <i class="glyphicon glyphicon-edit icon-padding"></i>Service Contact
        </div>
    </div>
        <asp:Panel ID="pnl_result" runat="server" Visible="false">
        <div class="result">
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
            <asp:Label ID="lblTrnsMessage" runat="server"></asp:Label>
        </div>
    </asp:Panel>
<hr />
 <div class="row">

   <div class="col-md-12">
 <div class="col-md-4">
           <div class="row">
                 
              <div class="col-md-12">
                        <div class="col-md-3">
                            E-ID 
                              <asp:Label ID="lblHiddenId" Visible="false" runat="server"></asp:Label>
                        </div>
                        <div class="col-md-9">
                            <asp:TextBox ID="txtEid_LV" class="form-control" runat="server" 
                                ontextchanged="txtEid_LV_TextChanged" AutoPostBack="True"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEid_LV"
                                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input E-ID No"
                                                    ValidationGroup="ServiceContract"></asp:RequiredFieldValidator>
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
                            <asp:TextBox ID="txtEmpName_TRNS" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
              <div class="col-md-12">
                        <div class="col-md-3">
                         File Name
                        </div>
                        <div class="col-md-9">
                            <asp:TextBox ID="txtFileTitle" class="form-control" runat="server"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFileTitle"
                                                    Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ErrorMessage="Input File Name"
                                                    ValidationGroup="ServiceContract"></asp:RequiredFieldValidator>

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
                            <asp:TextBox ID="txtDepartment" class="form-control" runat="server"></asp:TextBox>
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
                            <asp:TextBox ID="txtDesignation" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <br />
                  <div class="row" style="margin-top:8px;">
              <div class="col-md-12">
                        <div class="col-md-3">
                         File Upload
                        </div>
                        <div class="col-md-9">
                          
              <asp:FileUpload ID="FileUpload" runat="server" class="" style="border:1px solid #E4E4E4; width:162px;"/>
         
                        </div>
                  
           
                    </div>
               </div>
                      <br />
                      <div class="row">
                          <div class="col-md-12">
                          <div class="col-md-5"></div>
                          <div class="col-md-7">
                              
                             
           <asp:Button class="btn btn-info pull-right" ValidationGroup="ServiceContract" ID="btnUpload" runat="server" Text="Upload" 
                  OnClick="btnUpload_Click" />
                         
                              </div>
                      
                      </div>
                          </div>

                </div>
                  <div class="col-md-4">
           <div class="row">
              <div class="col-md-12">
                        <div class="col-md-5">
                             Photo
                        </div>
                        <div class="col-md-7">
                            <asp:Image ID="Emp_IMG_TRNS" ImageUrl="~/HRM/resources/no_image.png"
                                CssClass="img-thumbnail" Width="120px" Height="120px"  
                                runat="server" />
                        </div>
                    </div>
               </div>
                
                </div>
                
            </div>
    </div>
     <div  style="text-align:right";>
               
                
                </div>
<br />

 <div class="row">
      <div class="col-md-12">
      <div class="col-md-7">
          <fieldset>
              <legend style="line-height: 0; margin-bottom: 0;"><span style="background: #fff">Service Details</span></legend>
         
      <div class="row">
                                                    
                   <div class="col-md-12" >   
                 <asp:TextBox ID="txtServiceDetails" runat="server" CssClass="textBox" TextMode="MultiLine"></asp:TextBox>
                             </div>
                              <br />  

                               <div class="col-md-offset-9 col-md-3"> 
                                   <br />
                                    <asp:Button class="btn btn-info pull-right" ID="BtnSubmit" runat="server" Text="Save"  OnClick="BtnSubmit_Click"   />
                <%--<asp:Button  ID="btnPrint" runat="server" class="btn btn-danger" Text="Print" OnClick="btnPrint_Click" />--%>
                     
                                  </div>
                                  
                                    </div>
               </fieldset>
                          </div>  

     
                         
          
                         
                
  
      <div class="col-md-offset-1 col-md-4">
         
         <fieldset>
             <legend style="line-height: 0; margin-bottom: 0;"><span style="background: #fff">Uploaded File List</span></legend>
         
                <div class="col-md-12">
                    <div class="row">
                        <div class="col-md-12">
                         



                         <asp:GridView ID="grd_File" runat="server" EmptyDataText="No Records Found!" AllowPaging="True"
                    AllowSorting="True" AutoGenerateColumns="False" Width="100%" DataKeyNames="FILE_ID"
                    ShowFooter="True" CellPadding="5" 
                                onselectedindexchanged="grd_File_SelectedIndexChanged" OnPageIndexChanging="grd_File_PageIndexChanging">
                    <Columns>
                         <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblfileID" runat="server" Text='<%# Eval("FILE_ID")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                        <asp:BoundField DataField="FILE_TITLE" HeaderText="File Title">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="25%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FILE_SIZE" HeaderText="File Size">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>


                    <asp:TemplateField>
                     <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />

                        <ItemTemplate>
                            <asp:LinkButton ID="lnkDownload" Text = "Download" CommandArgument = '<%# Eval("FILE_PATH") %>' runat="server" OnClick = "DownloadFile"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField> <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        <ItemTemplate>
                            <asp:LinkButton ID = "lnkDelete" Text = "Delete" CommandArgument = '<%# Eval("FILE_ID") %>' runat = "server" OnClick = "DeleteFile" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    </Columns>
                    <EmptyDataRowStyle ForeColor="Red" />
                    <RowStyle CssClass="Grid_RowStyle" />
                    <AlternatingRowStyle CssClass="Grid_AltRowStyle" />
                             <PagerSettings Mode="NumericFirstLast" />
                    <PagerStyle BackColor="#6393c1" ForeColor="White" HorizontalAlign="Left" CssClass="pagination01 pageback" />
                </asp:GridView></div>
                   </div>
                 </div>
             </fieldset>
              </div>

          </div>
  
        </div>
        </div>

   <%-- </ContentTemplate>

<Triggers>
 <asp:AsyncPostBackTrigger ControlID="btnUpload" EventName="Click" />
     <asp:AsyncPostBackTrigger ControlID="BtnSubmit" EventName="Click" />
<asp:AsyncPostBackTrigger ControlID="txtEid_LV" EventName="TextChanged" />
    <asp:AsyncPostBackTrigger ControlID="txtServiceDetails" EventName="TextChanged" />
</Triggers>
</asp:UpdatePanel>--%>
</asp:Content>
