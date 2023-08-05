<%@ Page Title="University Marks" Language="C#" MasterPageFile="~/Index.master" AutoEventWireup="true" CodeFile="frm_ViewReportMarks.aspx.cs" Inherits="frm_ViewReportMarks" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <CR:CrystalReportViewer ID="CRV_StudentMarks" runat="server" ToolPanelView="None" HasCrystalLogo="False" 
        HasRefreshButton="True" HasSearchButton="False" 
        SeparatePages="False" Width="903px" ToolPanelWidth="10%" AutoDataBind="True" HasGotoPageButton="False" HasPageNavigationButtons="False" Height="2258px" ToolbarImagesFolderUrl="" />    
   <%-- <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
        <Report FileName="CR_Marks.rpt">
        </Report>
    </CR:CrystalReportSource>--%>

    </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">    
    </div>
    </div>
    </div>    
</asp:Content>

