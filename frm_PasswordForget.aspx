<%@ Page Title="" Language="C#" MasterPageFile="~/Index.master" AutoEventWireup="true" CodeFile="frm_PasswordForget.aspx.cs" Inherits="frm_PasswordForget" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <center class="lineborder linebg">
            <h1 style="font-size:2.8em;text-align:center">Change Password</h1>
        </center><br />
    
    <font class="label">Enter Old Password : </font>
    <asp:TextBox ID="txtpasswordold" runat="server" CssClass="lineborder linebg" TextMode="Password"></asp:TextBox>
    <font Id="lberr" runat="server" visible="false" style="color:red;">Old Password Doesn't Match</font>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtpasswordold" ErrorMessage="Old Password is Required" SkinID="RFV_Skin" Display="Dynamic" Font-Size="15px" ForeColor="Red"></asp:RequiredFieldValidator><br />

    <font class="label">Enter New Password : </font>
    <asp:TextBox ID="txtpassword" runat="server" CssClass="lineborder linebg" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfv_5" runat="server" ControlToValidate="txtpassword" ErrorMessage="Password is Required" SkinID="RFV_Skin" Display="Dynamic" Font-Size="15px" ForeColor="Red"></asp:RequiredFieldValidator><br />

    <font class="label">Confirm Password : </font>
    <asp:TextBox ID="txtconfpassword" runat="server" CssClass="lineborder linebg" TextMode="Password"></asp:TextBox>
    <asp:CompareValidator ID="cv_1" runat="server" ControlToValidate="txtconfpassword" ControlToCompare="txtpassword" ErrorMessage="Password Must Be Same" SkinID="CV_Skin" Display="Dynamic" Font-Size="15px" ForeColor="Red"></asp:CompareValidator><br />

    <asp:Button ID="btn_Change" runat="server" OnClick="btn_Change_Click" Text="Change"></asp:Button>&nbsp;&nbsp;
    &nbsp;&nbsp;<asp:Button ID="btn_cancel" runat="server" Text="Clear" OnClick="btn_cancel_Click"></asp:Button><br />
    <font Id="lblsuc" runat="server" visible="false" style="color:green;">Password Changed SuccessFully</font>
    </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    </div>
    </div>
    </div>
</asp:Content>

