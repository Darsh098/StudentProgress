<%@ Page Title="" Language="C#" MasterPageFile="~/Index.master" AutoEventWireup="true" CodeFile="frm_StaffLogin.aspx.cs" Inherits="frm_SignIn_MasterPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Theme1/signupcss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <center class="lineborder linebg"> 
        <h1 style="font-size:2.8em;text-align:center">Staff Login</h1>
         <asp:Image ID="img_sigin" runat="server" AlternateText="Image Not Found" ImageUrl="Images/268-avatar-man-outline.gif" Height="200"></asp:Image></center><br/>
               
                <font class="label">Enter UserName : </font>
                <asp:TextBox ID="txtusername" runat="server" CssClass="lineborder linebg" placeholder="Email" TextMode="Email"></asp:TextBox><br />
            
                <font class="label">Enter Password : </font>
            <asp:TextBox ID="txtpassword" runat="server" CssClass="lineborder linebg" TextMode="Password"></asp:TextBox><br />
            
    <span style="color:red" id="lberror" runat="server" visible="false">Username OR Password Is Wrong.</span><br />
    
        <asp:Button ID="btn_login" runat="server" Text="Login" OnClick="btn_login_Click"></asp:Button>&nbsp; 
            &nbsp;<asp:Button ID="btn_cancel" runat="server" Text="Cancel" OnClick="btn_cancel_Click"></asp:Button>
        
             <h3 style="margin-right:3px;text-align:right;"><a href="frm_SignUp_for_staff.aspx" style="border-bottom:solid 2px;border-color:#f56a6a;">Sign Up</a></h3><br />
   
    </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
   
    </div>
    </div>
    </div>
</asp:Content>

