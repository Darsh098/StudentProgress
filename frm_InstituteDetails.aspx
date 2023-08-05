<%@ Page Title="" Language="C#" MasterPageFile="~/Index.master" AutoEventWireup="true" CodeFile="frm_InstituteDetails.aspx.cs" Inherits="frm_InstituteDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="Theme1/signupcss.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <center class="lineborder linebg">
        <h1 style="font-size:2.8em;text-align:center">Institute's Information</h1>
        <asp:Image ID="img_institutedetails" runat="server" Height="200" AlternateText="Image Not Found" ImageUrl="~/Images/403-museum-authority-outline.gif" />

    </center><br />
    
                <font class="label">Enter Some Details About Institute : </font>
            <asp:TextBox ID="txtinstdetails" runat="server" TextMode="MultiLine" SkinID="TB_Skin" CssClass="lineborder linebg"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_1" ForeColor="Red" Font-Size="15px" runat="server" ErrorMessage="Institute Details is Required" ControlToValidate="txtinstdetails" Display="Dynamic"></asp:RequiredFieldValidator><br />
            
            <font class="label">Upload Institute Logo : </font><br />
            <asp:FileUpload ID="fldinst_logo" runat="server" CssClass="lineborder linebg"/><br />
                <asp:RequiredFieldValidator ID="rfv_2" runat="server" ErrorMessage="Institute Logo is Required" ControlToValidate="fldinst_logo" ForeColor="Red" Font-Size="15px" Display="Dynamic"></asp:RequiredFieldValidator><br />
            
            <font class="label">Enter Institute ContactNo : </font>
            <asp:TextBox ID="txtinstcontno" runat="server" TextMode="Phone" CssClass="lineborder linebg" MaxLength="10"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_3" runat="server" ErrorMessage="Institute ContactNo is Required" ControlToValidate="txtinstcontno" SkinID="RFV_Skin" Display="Dynamic" Font-Size="15px" ForeColor="Red"></asp:RequiredFieldValidator>
    <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Enter Valid Contact No" Type="Double" MaximumValue="9999999999" MinimumValue="6000000000" ControlToValidate="txtinstcontno" Display="Dynamic" Font-Size="15px" ForeColor="Red"></asp:RangeValidator><br />
            
            <font class="label">Enter Alternate Institute ContactNo : </font>
            <asp:TextBox ID="txtinstaltcontno" runat="server" TextMode="Phone" CssClass="lineborder linebg" MaxLength="10"></asp:TextBox><br />
        
        <font class="label">Enter Institute E-mail : </font>
            <asp:TextBox ID="txtinstemail" runat="server" TextMode="Email" CssClass="lineborder linebg"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_4" runat="server" ErrorMessage="Institute E-mail is Required" ControlToValidate="txtinstemail" SkinID="RFV_Skin" Display="Dynamic" Font-Size="15px" ForeColor="Red"></asp:RequiredFieldValidator><br />
            
        <font class="label">Enter Institute Password : </font>
            <asp:TextBox ID="txtinstpassword" runat="server" TextMode="Password" CssClass="lineborder linebg"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_6" runat="server" ErrorMessage="Institute Password is Required" ControlToValidate="txtinstpassword" SkinID="RFV_Skin" Display="Dynamic" Font-Size="15px" ForeColor="Red"></asp:RequiredFieldValidator><br />
            
        <font class="label">Upload Institute Image-1 : </font><br />
        <asp:FileUpload ID="fldinstimage1" runat="server" CssClass="lineborder linebg"/><br />
                <asp:RequiredFieldValidator ID="rfv_5" runat="server" ErrorMessage="At least one Institute Image is Required" ControlToValidate="fldinstimage1" ForeColor="Red" Font-Size="15px" Display="Dynamic"></asp:RequiredFieldValidator><br />
        
            <font class="label">Upload Institute Images-2 : </font><br />
            <asp:FileUpload ID="fldinstimage2" runat="server" CssClass="lineborder linebg"/>
                <br /><br />
             
            <font class="label">Upload Institute Images-3 : </font><br />
            <asp:FileUpload ID="fldinstimage3" runat="server" CssClass="lineborder linebg"/>
                <br /><br />
            <asp:Button ID="btn_submit" runat="server" Text="Upload" OnClick="btn_submit_Click"></asp:Button>&nbsp;
        &nbsp;<asp:Button ID="btn_cancel" runat="server" Text="Cancel" OnClick="btn_cancel_Click"></asp:Button>
    
    </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    </div>
    </div>
    </div>

</asp:Content>

