<%@ Page Title="" Language="C#" MasterPageFile="~/Index.master" AutoEventWireup="true" CodeFile="frm_Institute.aspx.cs" Inherits="frm_HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="Theme1/signupcss.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
                <center>
                    <h1 style="font-size:2.8em;text-align:center">Institute Elaborate</h1>
                    <asp:Image ID="img_inst" runat="server" AlternateText="Image Not Found" ImageUrl="~/Images/486-school-outline.gif" Height="200">

                    </asp:Image></center>
        
        <font id="lblinstname" runat="server" class="label">Enter Institute Name : </font></td>
        
                <asp:TextBox ID="txtinstname" runat="server" Font-Size="12" valign="center"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv1_instname" runat="server" ValidationGroup="Valid" ErrorMessage="Institute Name is Required" ControlToValidate="txtinstname" Display="Dynamic" Font-Size="15px" ForeColor="Red"></asp:RequiredFieldValidator><br />
            
            <font id="lblcountry" runat="server" class="label">Select Country : </font>
                <asp:DropDownList ID="ddl_Country" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_Country_SelectedIndexChanged"></asp:DropDownList><br />
                
            <font id="lblstate" runat="server" class="label">Select State : </font>
                <asp:DropDownList ID="ddl_State" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_State_SelectedIndexChanged"></asp:DropDownList><br />
                
    <font id="lblcity" runat="server" class="label">Select City : </font>
                <asp:DropDownList ID="ddl_City" runat="server" AutoPostBack="true"></asp:DropDownList><br />
                
        <font id="lblinstaddress" runat="server" class="label">Enter Institute Address : </font>
                <asp:TextBox ID="txtinstaddress" runat="server" Font-Size="12" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv4_instaddress" ValidationGroup="Valid" runat="server" ErrorMessage="Institute Address is Required" ControlToValidate="txtinstaddress" Display="Dynamic" Font-Size="15px" ForeColor="Red"></asp:RequiredFieldValidator><br />
                
                <asp:Button ID="btn_register" runat="server" Text="Register" ValidationGroup="Valid" OnClick="btn_register_Click"></asp:Button>&nbsp;

                &nbsp;<asp:Button ID="btn_cancel" runat="server" Text="Cancel" OnClick="btn_cancel_Click"></asp:Button>
    
    </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
            </div>
    </div>
    </div>
        
</asp:Content>
