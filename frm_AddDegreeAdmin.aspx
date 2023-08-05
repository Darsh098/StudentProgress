<%@ Page Title="" Language="C#" MasterPageFile="~/Index.master" AutoEventWireup="true" CodeFile="frm_AddDegreeAdmin.aspx.cs" Inherits="frm_AddDegreeAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center class="lineborder linebg">
        <h1 style="font-size:2.8em;text-align:center">Degree Elaborate And Management</h1>
        <asp:Image ID="img_course" runat="server" AlternateText="Image Not Found"  ImageUrl="~/Images/diploma.gif" SkinID="IMG_Skin" Height="200"></asp:Image></center>
    <br />
    <font class="label">Enter Degree Name : </font>
    <asp:TextBox ID="txtdegname" runat="server" CssClass="lineborder linebg"></asp:TextBox><br />
    <asp:Button ID="btn_insert" runat="server" Text="Insert" OnClick="btn_insert_Click" />&nbsp;
        
                &nbsp;<asp:Button ID="btn_cancel" runat="server" Text="Cancel" OnClick="btn_cancel_Click" /><br />
    <br />

    <asp:GridView ID="Grd_Degree" runat="server" AutoGenerateColumns="False" OnRowUpdating="Grd_Degree_RowUpdating1" OnRowCancelingEdit="Grd_Degree_RowCancelingEdit" OnRowDeleting="Grd_Degree_RowDeleting" OnRowEditing="Grd_Degree_RowEditing">
        <Columns>
            <asp:BoundField DataField="deg_Id" HeaderText="Degree Id" ReadOnly="True">
                <ControlStyle Width="100%" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="41%" />
            </asp:BoundField>
            <asp:BoundField DataField="deg_Name" HeaderText="Degree Name">
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

