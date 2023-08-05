<%@ Page Title="" Language="C#" Theme="AspControlsSkin" MasterPageFile="~/Index.master" AutoEventWireup="true" CodeFile="frm_Admission.aspx.cs" Inherits="frm_Admission" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="Theme1/signupcss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <center class="lineborder linebg">
            <h1 style="font-size:2.8em;text-align:center">Admission Open Now</h1>
            <asp:Image ID="imgAdmission" ImageUrl="~/Images/406-study-graduation-outline.png" runat="server" CssClass="image"></asp:Image>

        </center><br />
    
                <font id="lblInst" runat="server" class="label">Choose Institute : </font>
                <asp:DropDownList ID="ddlInst" runat="server" CssClass="lineborder linebg" SkinID="DDL_Skin" AutoPostBack="true" OnSelectedIndexChanged="ddlInst_SelectedIndexChanged"></asp:DropDownList><br />
                <font class="label">Choose Stream : </font>
                <asp:DropDownList ID="ddlStream" runat="server" CssClass="lineborder linebg" AutoPostBack="true" SkinId="DDL_Skin" OnSelectedIndexChanged="ddlStream_SelectedIndexChanged"></asp:DropDownList><br />
                <font class="label">Choose Course : </font>
                <asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="true" SkinID="DDL_Skin" CssClass="lineborder linebg" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged"></asp:DropDownList><br />
                <font class="label">Choose Semester : </font>
                <asp:DropDownList ID="ddlSem" runat="server" AutoPostBack="true" SkinID="DDL_Skin" CssClass="lineborder linebg" OnSelectedIndexChanged="ddlSem_SelectedIndexChanged"></asp:DropDownList><br />
                
            <font class="label">Choose Division : </font>
                <asp:DropDownList ID="ddl_div" runat="server" AutoPostBack="true" SkinID="DDL_Skin" CssClass="lineborder linebg" ></asp:DropDownList><br />
    
                <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click"></asp:Button>&nbsp;
                &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" ></asp:Button>


  
    </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">


    </div>
    </div>
    </div>
</asp:Content>