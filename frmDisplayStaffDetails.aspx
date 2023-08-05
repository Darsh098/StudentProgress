<%@ Page Title="" Language="C#" MasterPageFile="~/Index.master" AutoEventWireup="true" CodeFile="frmDisplayStaffDetails.aspx.cs" Inherits="frmDisplayStaffDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>Personal Details</h2>
    <font>Name : </font>
    <asp:Label ID="lblname" runat="server" Text='<%# Eval("Staff_Name") %>'></asp:Label><br />

    <font>Gender : </font>
    <asp:Label ID="lblgender" runat="server" Text='<%# Eval("Staff_Gender") %>'></asp:Label><br />

    <font>Date Of Birth : </font>
    <asp:Label ID="lblbdate" runat="server" Text='<%# Eval("Staff_Bdate") %>'></asp:Label><br />

    <font>E-mail : </font>
    <asp:Label ID="lblemail" runat="server" Text='<%# Eval("Staff_Email") %>'></asp:Label><br />

    <font>Contact No : </font>
    <asp:Label ID="lblcontno" runat="server" Text='<%# Eval("Staff_ContNo") %>'></asp:Label><br />

    <h2>Qualification Details</h2>
    <br />
    <asp:GridView ID="grd_quali" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Sq_Name" HeaderText="Degree ">
            <ControlStyle Width="100%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="25%" />
            </asp:BoundField>
            <asp:BoundField DataField="Sq_PassYear" HeaderText="Passing Year ">
            <ControlStyle Width="100%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="25%" />
            </asp:BoundField>
            <asp:BoundField DataField="Sq_Percentage" HeaderText="Percentage ">
            <ControlStyle Width="100%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="25%" />
            </asp:BoundField>
            <asp:BoundField DataField="Sq_UniName" HeaderText="University">
            <ControlStyle Width="100%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="25%" />
            </asp:BoundField>
        </Columns>
    </asp:GridView><br />

    <h2>Experience Details</h2>
    <br />
    <asp:GridView ID="grd_exp" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Se_OrgName" HeaderText="Company">
            <ControlStyle Width="100%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="25%" />
            </asp:BoundField>
            <asp:BoundField DataField="Se_DesignationName" HeaderText="Designation">
            <ControlStyle Width="100%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="25%" />
            </asp:BoundField>
            <asp:BoundField DataField="Se_Fromdate" HeaderText="Joining Date">
            <ControlStyle Width="100%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="25%" />
            </asp:BoundField>
            <asp:BoundField DataField="Se_Todate" HeaderText="Leaving Date">
            <ControlStyle Width="100%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="25%" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>

    </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    </div>
    </div>
    </div>
</asp:Content>

