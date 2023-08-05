<%@ Page Title="" Language="C#" MasterPageFile="~/Index.master" AutoEventWireup="true" CodeFile="frm_MainInstituteAdmin.aspx.cs" Inherits="frm_MainInstituteAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <br /> <span>
     <asp:Image ID="imglogo" runat="server"/> <h3 id="lblinstname" runat="server"></h3></span>


            <marquee>
                <asp:Image ID="instimg1" runat="server" AlternateText="Image Not Found"  Height="40%" Width="40%"/>
                <asp:Image ID="instimg2" runat="server" AlternateText="Image Not Found"  Height="40%" Width="40%"/>
                <asp:Image ID="instimg3" runat="server" AlternateText="Image Not Found"  Height="40%" Width="40%"/>
                <%--<asp:Image ID="Image1" runat="server" AlternateText="Image Not Found" ImageUrl='<%# Eval("Inst_Id","frm_Inst_Logo.ashx?myInstId={0}")  %>' />
                <asp:Image ID="Image2" runat="server" AlternateText="Image Not Found" ImageUrl='<%# Eval("Inst_Id","frm_Inst_Logo.ashx?myInstId={0}")  %>' />--%></marquee>

            <h3>Vision Of The Insitute</h3>
    <p id="instdescription" runat="server"></p>
    </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    </div>
    </div>
    </div>
</asp:Content>

