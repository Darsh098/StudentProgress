<%@ Page Title="" Language="C#" MasterPageFile="~/Index.master" AutoEventWireup="true" CodeFile="frm_AddTest_Admin.aspx.cs" Inherits="frm_AddTest_Institute" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center class="lineborder linebg">
        <h1 style="font-size:2.8em;text-align:center">Test Elaborate And Management</h1>
        <asp:Image ID="img_course" runat="server" AlternateText="Image Not Found"  ImageUrl="~/Images/test.png" SkinID="IMG_Skin" Height="200"></asp:Image>

    </center>
    <br />
    <font class="label">Enter Test Name : </font>
    <asp:TextBox ID="txttestname" runat="server" CssClass="lineborder linebg"></asp:TextBox><br />
    <asp:Button ID="btn_insert" runat="server" Text="Insert" OnClick="btn_insert_Click" />&nbsp;
        
                &nbsp;<asp:Button ID="btn_cancel" runat="server" Text="Cancel" OnClick="btn_cancel_Click" /><br />
    <br />

    <asp:GridView ID="Grd_Test" runat="server" AutoGenerateColumns="False" OnRowUpdating="Grd_Test_RowUpdating" OnRowCancelingEdit="Grd_Test_RowCancelingEdit" OnRowDeleting="Grd_Test_RowDeleting" OnRowEditing="Grd_Test_RowEditing">
        <Columns>
            <asp:BoundField DataField="Tt_Id" HeaderText="Test Id" ReadOnly="True">
                <ControlStyle Width="100%" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="41%" />
            </asp:BoundField>
            <asp:BoundField DataField="Tt_Name" HeaderText="Test Name">
                <ControlStyle Width="100%" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="41%" />
            </asp:BoundField>
            <asp:CommandField ButtonType="Image" HeaderText="Edit" EditImageUrl="~/Images/pencil-1.1s-50px.png" ShowEditButton="True" CancelImageUrl="~/Images/close-1.1s-50px.png" UpdateImageUrl="~/Images/ok-1.1s-50px.png">
                <ControlStyle Width="70%" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="9%" />
            </asp:CommandField>
            <asp:CommandField ButtonType="Image" HeaderText="Delete" ShowDeleteButton="True" DeleteImageUrl="~/Images/trash can-1.1s-50px.png">
                <ControlStyle Width="70%" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="9%" />
            </asp:CommandField>
        </Columns>
    </asp:GridView>
    </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    </div>
    </div>
    </div>
</asp:Content>

