<%@ Page Title="" Language="C#" MasterPageFile="~/Index.master" AutoEventWireup="true" CodeFile="frm_MarksReporting.aspx.cs" Inherits="frm_MarksChart" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center class="lineborder linebg">
        <h1 style="font-size:2.8em;text-align:center">Student's Growth University Assessment</h1>
        <asp:Image ID="img_educationDetails" runat="server" AlternateText="Image Not Found" ImageUrl="~/Images/153-bar-chart-growth-outline.gif" Height="200"></asp:Image>
    </center>
    <br />
    <font>Choose Semester : </font>
    <asp:DropDownList ID="ddlSem" runat="server" CssClass="lineborder linebg" AutoPostBack="true" SkinID="DDL_Skin" OnSelectedIndexChanged="ddlSem_SelectedIndexChanged"></asp:DropDownList><br />

    <br />
    <asp:Chart ID="chrtMarks" runat="server" BorderlineWidth="0" Height="400" Width="880">
        <Series>
            <asp:Series Name="Series1" XValueMember="Sem_Name" YValueMembers="Sem_Marks" ChartType="StackedColumn" 
                LegendText="All Subject Marks" IsValueShownAsLabel="true" ChartArea="chrtMarksArea" MarkerBorderColor="#DBDBDB" Font="Microsoft Sans Serif, 8.25pt"></asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="chrtMarksArea">
                <AxisX Interval="1" IsLabelAutoFit="true"></AxisX>
            </asp:ChartArea>
        </ChartAreas>
        <Legends>
            <asp:Legend Docking="Bottom" Alignment="Center" Title="Marks"></asp:Legend>
        </Legends>
        <Titles>
            <asp:Title Docking="Top" TextStyle="Shadow" Text="Progress Report" Font="Microsoft Sans Serif, 14.25pt"></asp:Title>
        </Titles>
    </asp:Chart><br />

    <asp:HyperLink Target="_blank" ID="link_rprt" runat="server" Text="View Report"></asp:HyperLink>
    
    </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    </div>
    </div>
    </div>
</asp:Content>

