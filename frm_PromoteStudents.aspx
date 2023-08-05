<%@ Page Title="" Language="C#" MasterPageFile="~/Index.master" AutoEventWireup="true" CodeFile="frm_PromoteStudents.aspx.cs" Inherits="frm_PromoteStudents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center class="lineborder linebg">
        <h1 style="font-size:2.8em;text-align:center">Promoting Student's</h1>
                     <asp:Image ID="img_course" runat="server" AlternateText="Image Not Found" ImageUrl="~/Images/employee.png" Height="200"></asp:Image>
                 </center><br />
                
                <font class="label">Choose Stream : </font>
                <asp:DropDownList ID="ddlStream" runat="server" CssClass="lineborder linebg" AutoPostBack="true" SkinID="DDL_Skin" OnSelectedIndexChanged="ddlStream_SelectedIndexChanged"></asp:DropDownList><br />
                
            <font class="label">Choose Course : </font>
                <asp:DropDownList ID="ddlCourse" runat="server" CssClass="lineborder linebg" AutoPostBack="true" SkinID="DDL_Skin" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged"></asp:DropDownList><br />
                <font class="label">Choose Semester : </font>
                <asp:DropDownList ID="ddlSem" runat="server" CssClass="lineborder linebg" SkinID="DDL_Skin" AutoPostBack="true" OnSelectedIndexChanged="ddlSem_SelectedIndexChanged"></asp:DropDownList><br />

    <asp:GridView ID="dt_studentlist" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField HeaderText="Stud Id" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblStudId" runat="server" Visible="false" Text='<%# Bind("Stud_Id") %>'></asp:Label>
                </ItemTemplate>
                <ControlStyle Width="100%" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="25%" />
            </asp:TemplateField>
            <asp:BoundField DataField="Sc_RollNo" HeaderText="Roll No">
            <ControlStyle Width="100%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="25%" />
            </asp:BoundField>
            <asp:BoundField DataField="Stud_Name" HeaderText="Name">
            <ControlStyle Width="100%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="25%" />
            </asp:BoundField>
            <asp:BoundField DataField="Div_Name" HeaderText="Divison">
            <ControlStyle Width="100%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="25%" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>

    <asp:Button ID="btn_Promote" runat="server" Text="Promote" OnClick="btn_Promote_Click"></asp:Button>
    <br /><font ID="lbl" runat="server" Visible="false" style="color:green;" class="label">Last Semester Student Have Been Graduated!!</font>
    </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    </div>
    </div>
    </div>
</asp:Content>

