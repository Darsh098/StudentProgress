<%@ Page Title="" Language="C#" MasterPageFile="~/Index.master" AutoEventWireup="true" CodeFile="frm_SubjectAllocation.aspx.cs" Inherits="frm_SubjectAllocation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center class="lineborder linebg">
        <h1 style="font-size:2.8em;text-align:center">Staff Application</h1>
        
       <asp:Image ID="img_sigin" runat="server" AlternateText="Image Not Found" ImageUrl="~/Images/animation_500_kywu6g21.gif" Height="200"></asp:Image></center><br />
                
                <font class="label">Choose Institute : </font>
                <asp:DropDownList ID="ddlInst" runat="server" CssClass="lineborder linebg" AutoPostBack="true" SkinID="DDL_Skin" OnSelectedIndexChanged="ddlInst_SelectedIndexChanged"></asp:DropDownList><br />

                       <font class="label">Choose Stream : </font>
                <asp:DropDownList ID="ddlStream" runat="server" CssClass="lineborder linebg" AutoPostBack="true" SkinID="DDL_Skin" OnSelectedIndexChanged="ddlStream_SelectedIndexChanged"></asp:DropDownList><br />
            
                <font class="label">Choose Course : </font>
                <asp:DropDownList ID="ddlCourse" runat="server" CssClass="lineborder linebg" AutoPostBack="true" SkinID="DDL_Skin" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged"></asp:DropDownList><br />
                <font class="label">Choose Semester : </font>
                <asp:DropDownList ID="ddlSem" runat="server" CssClass="lineborder linebg" AutoPostBack="true" SkinID="DDL_Skin" OnSelectedIndexChanged="ddlSem_SelectedIndexChanged"></asp:DropDownList><br />
                <font class="label">Enter Subject Name : </font>
             <asp:DropDownList ID="ddl_subject" runat="server" CssClass="lineborder linebg"></asp:DropDownList><br />
        
                <font class="label">Enter Year : </font>
                   <asp:DropDownList ID="ddl_year" runat="server" AutoPostBack="True"  CssClass="lineborder linebg">
                                    </asp:DropDownList><br />

                   <font class="label">Enter Remarks : </font>
                    <asp:TextBox ID="txtremarks" runat="server" CssClass="lineborder linebg" TextMode="MultiLine"></asp:TextBox><br />
    
            <asp:Button ID="btn_insert" runat="server" Text="Insert"  OnClick="btn_insert_Click"></asp:Button>&nbsp;            
                    &nbsp;<asp:Button ID="btn_cancel" runat="server" Text="Cancel"></asp:Button>
    </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    </div>
    </div>
    </div>
</asp:Content>

