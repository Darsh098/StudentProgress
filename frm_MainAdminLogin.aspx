<%@ Page Title="" Language="C#" MasterPageFile="~/Index.master" AutoEventWireup="true" CodeFile="frm_MainAdminLogin.aspx.cs" Inherits="frm_MainAdminLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center class="lineborder linebg">
            <h1 style="font-size:2.8em;text-align:center">Admin's Login</h1>
        <asp:Image ID="img_sigin" runat="server" AlternateText="Image Not Found" ImageUrl="Images/268-avatar-man-outline.gif" Height="200"></asp:Image>

    </center><br />
                
                <font class="label">Enter Username : </font>
   
                  <asp:TextBox ID="txtusername" runat="server" CssClass="lineborder linebg" SkinID="TB_Skin" placeholder="Email" TextMode="Email"></asp:TextBox><br />
                  
                <font class="label">Enter Password :    </font>
                    
                    <asp:TextBox ID="txtpassword" runat="server" CssClass="lineborder linebg" SkinID="TB_Skin" TextMode="Password"></asp:TextBox>
    <span style="color:red" id="lberror" runat="server" visible="false">Username OR Password Is Wrong.</span><br />
            <asp:Button ID="btn_login" runat="server" Text="Login"  OnClick="btn_login_Click"></asp:Button>&nbsp;
                
                    &nbsp;<asp:Button ID="btn_cancel" runat="server" Text="Cancel" OnClick="btn_cancel_Click"></asp:Button>              
  
    </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    </div>
    </div>
    </div>
</asp:Content>

