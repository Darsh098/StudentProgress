<%@ Page Title="" Language="C#" MasterPageFile="~/Index.master" AutoEventWireup="true" CodeFile="frm_MainPage.aspx.cs" Inherits="frm_MainPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <h1 style="font-size:2.8em;text-align:center">Choose Login Type </h1>
    <br />
    <div style="width: 98%; overflow: hidden;">
     <div style="width: 49%; text-align:center; float:left;"> 
          <asp:ImageButton ID="imgadmin" runat="server" ImageAlign="Middle" BorderStyle="Solid" AlternateText="Image Not Found" ImageUrl="~/Images/manager.png" OnClick="imgadmin_Click"/>
        <br /><p align="center" style="font-size:1.2em;font-family:Verdana;">Admin</p> 
         <asp:ImageButton ID="imgstaff" runat="server" ImageAlign="Middle" BorderStyle="Solid" AlternateText="Image Not Found" ImageUrl="~/Images/teacher.png" OnClick="imgstaff_Click"/>
        <br /><p align="center" style="font-size:1.2em;font-family:Verdana;">Staff</p> 
     </div>
     <div style="margin-left: 49%; text-align:center;">  
         <asp:ImageButton ID="imginstadmin" runat="server" ImageAlign="Middle" BorderStyle="Solid" AlternateText="Image Not Found" ImageUrl="~/Images/choice.png" OnClick="imginstadmin_Click"/>
        <br /><p align="center" style="font-size:1.2em;font-family:Verdana;">Institute Admin</p>
         <asp:ImageButton ID="imgstudent" runat="server" ImageAlign="Middle" BorderStyle="Solid" AlternateText="Image Not Found" ImageUrl="~/Images/student.png" OnClick="imgstudent_Click"/>
        <br /><p align="center" style="font-size:1.2em;font-family:Verdana;">Student</p>
     </div>
</div>
    </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    </div>
    </div>
    </div>
</asp:Content>

