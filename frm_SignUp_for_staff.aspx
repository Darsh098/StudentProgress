<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Index.master" Theme="AspControlsSkin" CodeFile="frm_SignUp_for_staff.aspx.cs" Inherits="frm_SignUP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Theme1/signupcss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center class="lineborder linebg">
            <h1 style="font-size:2.8em;text-align:center">Staff's Personal Details</h1>
        <asp:Image ID="img_staff" runat="server" SkinID="IMG_Skin" ImageUrl="~/Images/680-it-developer-outline.gif" />

    </center><br />
                        
                        <font class="label">Enter Your Name : </font>

                        <asp:TextBox ID="txtname" runat="server" CssClass="lineborder linebg"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_1" runat="server" ControlToValidate="txtname" ErrorMessage="Name is Required" SkinID="RFV_Skin"></asp:RequiredFieldValidator><br />

                        <font class="label">Choose Your Gender : </font>
                            <asp:RadioButtonList ID="rd_gender" runat="server" RepeatDirection="Horizontal" Width="60%">
                            <asp:ListItem Value="0">Male</asp:ListItem>
                            <asp:ListItem Value="1">Female</asp:ListItem>
                                <asp:ListItem Value="2">Others</asp:ListItem>
                            </asp:RadioButtonList>


                        <font class="label">Select Your BirthDate : </font><br />
                        <asp:TextBox ID="txtbdate" runat="server" CssClass="lineborder linebg" TextMode="Date"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_3" runat="server" ControlToValidate="txtbdate" ErrorMessage="BirthDate is Required" SkinID="RFV_Skin"></asp:RequiredFieldValidator><br />

                        <font class="label">Enter Your E-mail : </font>
                        <asp:TextBox ID="txtemail" runat="server" CssClass="lineborder linebg" TextMode="Email"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_4" runat="server" ControlToValidate="txtemail" ErrorMessage="Email is Required" SkinID="RFV_Skin"></asp:RequiredFieldValidator><br />

                        <font class="label">Enter Your Address : </font>
                        <asp:TextBox ID="txtaddress" runat="server" CssClass="lineborder linebg" TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_6" runat="server" ControlToValidate="txtaddress" ErrorMessage="Address is Required" SkinID="RFV_Skin"></asp:RequiredFieldValidator><br />

                        <font class="label">Enter Your Contact No : </font>
                        <asp:TextBox ID="txtcontno" runat="server" CssClass="lineborder linebg" TextMode="Phone" MaxLength="10"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_7" runat="server" ControlToValidate="txtcontno" ErrorMessage="ContactNo is Required" SkinID="RFV_Skin"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Enter Valid Contact No" Type="Double" MaximumValue="9999999999" MinimumValue="6000000000" ControlToValidate="txtcontno" Display="Dynamic" Font-Size="15px" ForeColor="Red"></asp:RangeValidator><br />

                        <font class="label">Select Country : </font>
                        <asp:DropDownList ID="ddl_Country" runat="server" SkinID="DDL_Skin" CssClass="lineborder linebg" OnSelectedIndexChanged="ddl_Country_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList><br />

                        <font class="label">Select State : </font>
                        <asp:DropDownList ID="ddl_State" runat="server" SkinID="DDL_Skin" CssClass="lineborder linebg" OnSelectedIndexChanged="ddl_State_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList><br />

                        <font class="label">Select City : </font>
                        <asp:DropDownList ID="ddl_City" runat="server" SkinID="DDL_Skin" CssClass="lineborder linebg" AutoPostBack="true"></asp:DropDownList><br />

                         <font class="label">Enter Password : </font>
                        <asp:TextBox ID="txtpassword" runat="server" CssClass="lineborder linebg" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_5" runat="server" ControlToValidate="txtpassword" ErrorMessage="Password is Required" SkinID="RFV_Skin"></asp:RequiredFieldValidator><br />

                        <font class="label">Confirm Password : </font>
                        <asp:TextBox ID="txtconfpassword" runat="server" CssClass="lineborder linebg" TextMode="Password"></asp:TextBox>
                        <asp:CompareValidator ID="cv_1" runat="server" ControlToValidate="txtconfpassword" ControlToCompare="txtpassword" SkinID="CV_Skin"></asp:CompareValidator><br />


                        <asp:Button ID="btn_register" runat="server" Text="Register" OnClick="btn_register_Click"></asp:Button>&nbsp;
                        &nbsp;<asp:Button ID="btn_cancel" runat="server" Text="Cancel" OnClick="btn_cancel_Click"></asp:Button>
    </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
          
    </div>
    </div>
    </div>
</asp:Content>