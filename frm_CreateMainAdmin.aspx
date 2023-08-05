<%@ Page Title="" Language="C#" MasterPageFile="~/Index.master" AutoEventWireup="true" CodeFile="frm_CreateMainAdmin.aspx.cs" Inherits="frm_CreateMainAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
   <center class="lineborder linebg">
        <h1 style="font-size:2.8em;text-align:center">Create Admin</h1>
     <asp:Image ID="img_sigin" runat="server" AlternateText="Image Not Found" ImageUrl="Images/268-avatar-man-outline.gif" Height="200"></asp:Image></center><br/>
               
                <font class="label">Enter UserName : </font>
                <asp:TextBox ID="txtusername" Visible="false" runat="server" CssClass="lineborder linebg" placeholder="Email" TextMode="Email"></asp:TextBox><br />
            
                <font class="label">Enter Password : </font>
            <asp:TextBox ID="txtpassword" Visible="false" runat="server" CssClass="lineborder linebg" TextMode="Password"></asp:TextBox><br />

    <asp:Button ID="Btn_Create" runat="server" Text="Create" OnClick="Btn_Create_Click"></asp:Button>&nbsp; 
            &nbsp;<asp:Button ID="btn_cancel" runat="server" Text="Cancel" OnClick="btn_cancel_Click"></asp:Button>

    </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    </div>
    </div>
    </div>
</asp:Content>

