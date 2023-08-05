<%@ Page Title="" Language="C#" MasterPageFile="~/Index.master" AutoEventWireup="true" CodeFile="frm_ChooseTest.aspx.cs" Inherits="frm_ChooseTest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <center class="lineborder linebg">
            <h1 style="font-size:2.8em;text-align:center">Opting A Test</h1>
                     <asp:Image ID="img_course" runat="server" AlternateText="Image Not Found" ImageUrl="~/Images/test1.png" Height="200"></asp:Image>
                 </center><br />
                
                <font class="label">Choose Stream : </font>
                <asp:DropDownList ID="ddlStream" runat="server" CssClass="lineborder linebg" AutoPostBack="true" SkinID="DDL_Skin" OnSelectedIndexChanged="ddlStream_SelectedIndexChanged"></asp:DropDownList><br />
                
            <font class="label">Choose Course : </font>
                <asp:DropDownList ID="ddlCourse" runat="server" CssClass="lineborder linebg" AutoPostBack="true" SkinID="DDL_Skin" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged"></asp:DropDownList><br />
                <font class="label">Choose Semester : </font>
                <asp:DropDownList ID="ddlSem" runat="server" AutoPostBack="true" CssClass="lineborder linebg" SkinID="DDL_Skin" OnSelectedIndexChanged="ddlSem_SelectedIndexChanged"></asp:DropDownList><br />

                
                
    <br />
    <span id="lblbtn" runat="server"></span>
     <asp:Button ID="btn_unimarks" runat="server" Text="University Marks" OnClick="btn_unimarks_Click"></asp:Button>

    </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    </div>
    </div>
    </div>
</asp:Content>

