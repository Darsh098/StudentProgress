<%@ Page Title="" Language="C#" MasterPageFile="~/Index.master" AutoEventWireup="true" CodeFile="frm_StaffAllocation.aspx.cs" Inherits="frm_StaffAllocation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center class="lineborder linebg">
        <h1 style="font-size:2.8em;text-align:center">Staff Allocation And Mangement</h1>
        <asp:Image ID="img_institutedetails" runat="server" Height="200" AlternateText="Image Not Found" ImageUrl="~/Images/teacher.png" />

    </center>
    <br />


    <font class="label">Choose Staff : </font>
    <asp:DropDownList ID="ddlStaff" runat="server" CssClass="lineborder linebg" AutoPostBack="true" SkinID="DDL_Skin" OnSelectedIndexChanged="ddlStaff_SelectedIndexChanged"></asp:DropDownList><br />

    <span id="spn_stream" runat="server" visible="false">
    <font class="label">Choose Stream : </font>
    <asp:DropDownList ID="ddlStream" runat="server" CssClass="lineborder linebg" AutoPostBack="true" SkinID="DDL_Skin" OnSelectedIndexChanged="ddlStream_SelectedIndexChanged"></asp:DropDownList><br />
    </span>

    <span id="spn_course" runat="server" visible="false">
    <font class="label">Choose Course : </font>
    <asp:DropDownList ID="ddlCourse" runat="server" CssClass="lineborder linebg" AutoPostBack="true" SkinID="DDL_Skin" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged"></asp:DropDownList><br />
    </span>

    <span id="spn_sem" runat="server" visible="false">
    <font class="label">Choose Semester : </font>
    <asp:DropDownList ID="ddlSem" runat="server" CssClass="lineborder linebg" AutoPostBack="true" SkinID="DDL_Skin" OnSelectedIndexChanged="ddlSem_SelectedIndexChanged"></asp:DropDownList><br />
    </span>

    <span id="spn_div" runat="server" visible="false">
    <font class="label">Choose Division : </font>
    <asp:DropDownList ID="ddldivision" runat="server" CssClass="lineborder linebg" AutoPostBack="true" SkinID="DDL_Skin"></asp:DropDownList><br />
    </span>

    <span id="spn_sub" runat="server" visible="false">
    <font class="label">Choose Subject : </font>
    <asp:DropDownList ID="ddlsubject" runat="server" CssClass="lineborder linebg" AutoPostBack="true" SkinID="DDL_Skin"></asp:DropDownList><br />
    </span>

    <asp:Button ID="btn_insert" runat="server" Text="Allocate New Subject" OnClick="btn_insert_Click"/>
    &nbsp;&nbsp;<asp:Button ID="btn_cancel" Visible="false" runat="server"  Text="Cancel" OnClick="btn_cancel_Click"/>    
    <br /><br />

    <center>
        <asp:GridView ID="Grd_Staff" Visible="False" runat="server" AutoGenerateColumns="False" OnRowDeleting="Grd_Staff_RowDeleting" OnRowCancelingEdit="Grd_Staff_RowCancelingEdit"> 
                    <Columns>
                        <asp:TemplateField HeaderText="Id" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lbl_Sa_Id" Visible="false" runat="server" Text='<%# Bind("Sa_Id") %>'></asp:Label>
                            </ItemTemplate>
                            <ControlStyle Width="100%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="9%" />
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Name" ReadOnly="True" DataField="Staff_Name">
                        <ControlStyle Width="100%" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="22%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Sub_Name" HeaderText="Subject">
                        <ControlStyle Width="100%" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="22%" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Semester" ReadOnly="True" DataField="Sem_Name">
                        <ControlStyle Width="100%" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="22%" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Division" ReadOnly="True" DataField="Div_Name">
                        <ControlStyle Width="100%" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="22%" />
                        </asp:BoundField>
                        <asp:CommandField ButtonType="Image" HeaderText="Delete" ShowDeleteButton="True" DeleteImageUrl="~/Images/trash can-1.1s-50px.png">
                        <ControlStyle Width="70%" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="9%" />
                        </asp:CommandField>
                    </Columns>
                    <HeaderStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:GridView></center>

    </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    </div>
    </div>
    </div>
</asp:Content>

