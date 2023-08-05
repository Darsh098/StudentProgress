<%@ Page Title="" Language="C#" MasterPageFile="~/Index.master" AutoEventWireup="true" CodeFile="frm_AddDivison.aspx.cs" Inherits="frm_AddDivison" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <center>
         <h1 style="font-size:2.8em;text-align:center" class="lineborder linebg">Division Elaborate</h1>
         </center>

            <font class="label">Choose Stream : </font>
            
                <asp:DropDownList ID="ddlStream" runat="server" CssClass="lineborder linebg" AutoPostBack="true" SkinID="DDL_Skin" OnSelectedIndexChanged="ddlStream_SelectedIndexChanged"></asp:DropDownList><br />
            
                <font class="label">Choose Course : </font>
                <asp:DropDownList ID="ddlCourse" runat="server" CssClass="lineborder linebg" AutoPostBack="true" SkinID="DDL_Skin" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged"></asp:DropDownList><br />
                <font class="label">Choose Semester : </font>
                <asp:DropDownList ID="ddlSem" runat="server" CssClass="lineborder linebg" AutoPostBack="true" SkinID="DDL_Skin"></asp:DropDownList><br />
            
                <font class="label">Enter Division Name : </font>
             <asp:TextBox ID="txtdivison" runat="server" CssClass="lineborder linebg" ></asp:TextBox><br />
            
         <asp:Button ID="btn_insert" runat="server" Text="Insert" OnClick="btn_insert_Click"/>&nbsp;
        
                &nbsp;<asp:Button ID="btn_cancel" runat="server" OnClick="btn_cancel_Click"  Text="Cancel"/>
    </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    </div>
    </div>
    </div>
</asp:Content>

