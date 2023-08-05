<%@ Page Title="" Language="C#" MasterPageFile="~/Index.master" AutoEventWireup="true" CodeFile="frm_SignUp_for_students.aspx.cs" Inherits="_Default" Theme="AspControlsSkin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Theme1/signupcss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center class="lineborder linebg">
            <h1 style="font-size:2.8em;text-align:center">Student's Personal Details</h1>
        <asp:Image ID="img_sigup" runat="server" AlternateText="Image Not Found" ImageUrl="Images/278-avatar-man-plus-outline.gif" Height="200"></asp:Image></center>
    <br />

    <font id="lblname" runat="server">Enter Your Name : </font>
    <asp:TextBox ID="txtname" runat="server" CssClass="lineborder linebg"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfv1_name" runat="server" ErrorMessage="Name is Required" ControlToValidate="txtname" Display="Dynamic" Font-Size="15px" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />



    <font id="lblgender" runat="server">Choose Gender : </font>
    <asp:RadioButtonList ID="rd_gender" runat="server" RepeatDirection="Horizontal" Width="60%">
        <asp:ListItem Value="0">Male</asp:ListItem>
        <asp:ListItem Value="1">Female</asp:ListItem>
        <asp:ListItem Value="2">Others</asp:ListItem>
    </asp:RadioButtonList>

    <font id="lblbdate" runat="server">Select BirthDate : </font>
    <br />
    <asp:TextBox ID="txtdate" runat="server" CssClass="lineborder linebg" TextMode="Date"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfv2_date" runat="server" ErrorMessage="BirthDate is Required" ControlToValidate="txtdate" Display="Dynamic" Font-Size="15px" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />

    <font id="lblemail" runat="server">Enter Your E-mail : </font>
    <asp:TextBox ID="txtemail" runat="server" CssClass="lineborder linebg"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfv3_email" runat="server" ErrorMessage="E-mail is Required" ControlToValidate="txtemail" Display="Dynamic" Font-Size="15px" ForeColor="Red"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="rev_email" runat="server" ControlToValidate="txtemail" Display="Dynamic" ErrorMessage="Enter a Valid E-mail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Font-Size="15px" ForeColor="Red"></asp:RegularExpressionValidator>
    <br />

    <font id="lbladdress" runat="server">Enter Your Address : </font>
    <asp:TextBox ID="txtaddress" runat="server" CssClass="lineborder linebg" TextMode="MultiLine"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfv4_address" runat="server" ErrorMessage="Address is Required" ControlToValidate="txtaddress" Display="Dynamic" Font-Size="15px" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />

    <font id="lblcontno" runat="server">Enter MobileNumber : </font>
    <asp:TextBox ID="txtcontno" runat="server" CssClass="lineborder linebg" TextMode="Phone" MaxLength="10"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfv5_contno" runat="server" ErrorMessage="Contact Number is Required" ControlToValidate="txtcontno" Display="Dynamic" Font-Size="15px" ForeColor="Red"></asp:RequiredFieldValidator>
    <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Enter Valid Contact No" Type="Double" MaximumValue="9999999999" MinimumValue="6000000000" ControlToValidate="txtcontno" Display="Dynamic" Font-Size="15px" ForeColor="Red"></asp:RangeValidator><br />


    <font id="lblcountry" runat="server">Select Country : </font>
    <asp:DropDownList ID="ddl_Country" runat="server" AutoPostBack="true" CssClass="lineborder linebg" OnSelectedIndexChanged="ddl_Country_SelectedIndexChanged"></asp:DropDownList><br />

    <font id="lblstate" runat="server">Select State : </font>
    <asp:DropDownList ID="ddl_State" runat="server" AutoPostBack="true" CssClass="lineborder linebg" OnSelectedIndexChanged="ddl_State_SelectedIndexChanged"></asp:DropDownList><br />

    <font id="lblcity" runat="server">Select City : </font>
    <asp:DropDownList ID="ddl_City" runat="server" AutoPostBack="true" CssClass="lineborder linebg"></asp:DropDownList><br />
    <font>Enter Password : </font>

    <asp:TextBox ID="txtpassword" runat="server" CssClass="lineborder linebg" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfv_5" runat="server" ControlToValidate="txtpassword" ErrorMessage="Password is Required" SkinID="RFV_Skin" Display="Dynamic" Font-Size="15px" ForeColor="Red"></asp:RequiredFieldValidator><br />

    <font class="label">Confirm Password : </font>
    <asp:TextBox ID="txtconfpassword" runat="server" CssClass="lineborder linebg" TextMode="Password"></asp:TextBox>
    <asp:CompareValidator ID="cv_1" runat="server" ControlToValidate="txtconfpassword" ErrorMessage="Password Must Be Same " ControlToCompare="txtpassword" SkinID="CV_Skin" Display="Dynamic" Font-Size="15px" ForeColor="Red"></asp:CompareValidator><br />

    <asp:Button ID="btn_register" runat="server" OnClick="btn_register_Click" Text="Register"></asp:Button>
    <asp:Button ID="btn_cancel" runat="server" Text="Cancel" OnClick="btn_cancel_Click"></asp:Button><br />
    <br />
    </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    </div>
    </div>
    </div>
</asp:Content>
