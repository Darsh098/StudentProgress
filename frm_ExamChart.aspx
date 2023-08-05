<%@ Page Title="" Language="C#" MasterPageFile="~/Index.master" AutoEventWireup="true" CodeFile="frm_ExamChart.aspx.cs" Inherits="frm_ExamChart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center class="lineborder linebg">
        <h1 style="font-size:2.8em;text-align:center">Student's Growth College Assessment</h1>
        <asp:Image ID="img_educationDetails" runat="server" AlternateText="Image Not Found" ImageUrl="~/Images/153-bar-chart-growth-outline.gif" Height="200"></asp:Image>
    </center>
    <br />
    <font>Choose Test : </font>
    <asp:DropDownList ID="ddltest" runat="server" CssClass="lineborder linebg" AutoPostBack="true" SkinID="DDL_Skin" OnSelectedIndexChanged="ddltest_SelectedIndexChanged"></asp:DropDownList><br />

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

    </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    </div>
    </div>
    </div>
</asp:Content>

