<%@ Page Title="" Language="C#" MasterPageFile="~/HRM/Site.Master" AutoEventWireup="true"
    CodeBehind="LetterFormat.aspx.cs" Inherits="ERPSSL.HRM.LetterFormat" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
<%--<asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">--%>
<%--          
<ContentTemplate>--%>

  
    <div class="hm_sec_2_content scrollbar">
          <div class="panel">
        <div class="panel-heading panel-heading-01">
            <i class="fa fa-edit fa-fw icon-padding"></i>Letter Format
        </div>
    </div>
        <asp:Panel ID="pnl_result" runat="server" Visible="false">
            <div class="result">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </div>
        </asp:Panel>
        <div class="col-md-12">
            <div class="row">
                <div class="col-md-2">
                    Type :
                </div>
                <div class="col-md-9">
                    <asp:DropDownList ID="drpType" runat="server" class="form-control">
                    </asp:DropDownList>
                </div>
            </div>
        </div>
      
        <div class="col-md-12">
          <br />
            <div class="row" style="margin-bottom: 8px;">
                <div class="col-md-2">
                    Title :
                </div>
                <div class="col-md-9">
                    <asp:TextBox ID="txtTitle" runat="server" class="form-control"></asp:TextBox>
                    <asp:HiddenField ID="hidLatterFormateId" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="latter"
                        runat="server" ErrorMessage="Please Input Title" SetFocusOnError="true" ControlToValidate="txtTitle"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
        <div class="col-md-12" style="margin-top: 10px;">
            <asp:TextBox ID="txtLatterDetails" runat="server" CssClass="textBox" TextMode="MultiLine"
                Height="300px" Width="100%"></asp:TextBox>
        </div>
        <div class="row">
            <div class="col-md-12" style="margin-top: 6px">
                <div class="col-md-offset-9 col-md-3">
                    <asp:Button ID="btnLetterFormate" runat="server" Text="Submit" Width="30%" CssClass="btn btn-info pull-right"
                        OnClick="btnLetterFormate_Click" />
                </div>
            </div>
            <div class="col-md-12">
                <br />
                <asp:GridView ID="gridviewLatterFormate" runat="server" AutoGenerateColumns="False"
                    Width="100%" CellPadding="5" AllowPaging="True">
                    <Columns>
                        <asp:TemplateField Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblLatterId" runat="server" Text='<%# Eval("LId")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Type" HeaderText="Type">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Title" HeaderText="Title">
                            <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                            <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                            <FooterStyle CssClass="Grid_Footer" />
                        </asp:BoundField>
                        <%-- <asp:BoundField DataField="LTR_Details" HeaderText="LTR_Details">
                        <HeaderStyle VerticalAlign="Middle" CssClass="Grid_Header" />
                        <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="Grid_Border" />
                        <FooterStyle CssClass="Grid_Footer" />
                    </asp:BoundField>--%>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgbtnLatterFormate" runat="server" ImageUrl="img/list_edit.png"
                                    OnClick="imgbtnLatterFormate_Click" />
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
    
<%--</ContentTemplate>

<Triggers>
 <asp:AsyncPostBackTrigger ControlID="btnLetterFormate" EventName="Click" />

</Triggers>
</asp:UpdatePanel>--%>
</asp:Content>
