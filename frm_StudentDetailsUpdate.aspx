<%@ Page Title="" Language="C#" MasterPageFile="~/Index.master" AutoEventWireup="true" CodeFile="frm_StudentDetailsUpdate.aspx.cs" Inherits="frm_StudentDetailsUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <center class="lineborder linebg">
        <h1 style="font-size:2.8em;text-align:center">Student Profile</h1>
         </center>
    <h2>Personal Details</h2>
    <font>Name : </font>
    <asp:Label ID="lblname" runat="server"></asp:Label>
    <asp:TextBox ID="txtname" runat="server" Visible="false"></asp:TextBox><br />

    <br /><font>Gender : </font>
    <asp:Label ID="lblgender" runat="server"></asp:Label>
    <asp:TextBox ID="txtgender" runat="server" Visible="false"></asp:TextBox><br />

    <br />
    
    <font>Date Of Birth : </font>
    <asp:Label ID="lblbdate" runat="server"></asp:Label>
    <input type="date" id="txtbdate" runat="server" visible="false" />
    <br />

    <br /><font>E-mail : </font>
    <asp:Label ID="lblemail" runat="server"></asp:Label><br />

    <br /><font>Contact No : </font>
    <asp:Label ID="lblcontno" runat="server"></asp:Label>
    <asp:TextBox ID="txtcontno" runat="server" Visible="false" TextMode="Phone" MaxLength="10"></asp:TextBox><br /><br />
     
    <asp:Button ID="btn_edit" runat="server" Text="Edit" OnClick="btn_edit_Click"/>&nbsp;&nbsp;
                &nbsp;&nbsp;<asp:Button ID="btn_cancel" runat="server" Text="Cancel" OnClick="btn_cancel_Click" Visible="false"/>
    &nbsp;&nbsp;<asp:Button ID="btn_back" runat="server" Text="Back" OnClientClick="JavaScript:window.history.back(1); return false;"  Visible="false"/>
    <h2>Qualification Details</h2>
    <br />
    <asp:GridView ID="grd_educat" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Stq_Name" HeaderText="Standard">
            <ControlStyle Width="100%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="25%" />
            </asp:BoundField>
            <asp:BoundField DataField="Stq_PassYear" HeaderText="Passing Year ">
            <ControlStyle Width="100%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="25%" />
            </asp:BoundField>
            <asp:BoundField DataField="Stq_Percentage" HeaderText="Percentage ">
            <ControlStyle Width="100%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="25%" />
            </asp:BoundField>
            <asp:BoundField DataField="Stq_SchoolName" HeaderText="Board">
            <ControlStyle Width="100%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="25%" />
            </asp:BoundField>
        </Columns>
    </asp:GridView><br />
    </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    </div>
    </div>
    </div>
</asp:Content>

