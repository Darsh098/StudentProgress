<%@ Page Title="" Language="C#" MasterPageFile="~/Index.master" Theme="AspControlsSkin" AutoEventWireup="true" CodeFile="frm_AddCourse.aspx.cs" Inherits="frm_AddCourse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="Theme1/signupcss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                 <center class="lineborder linebg">
                     <h1 style="font-size:2.8em;text-align:center">Course Elaborate And Management</h1>
                     <asp:Image ID="img_course" runat="server" AlternateText="Image Not Found" ImageUrl="~/Images/animation_500_kytywjy2.gif" Height="200"></asp:Image>
                 </center><br />
                <font class="label">Choose a Stream : </font>
                <asp:DropDownList ID="ddl_stream" runat="server" CssClass="lineborder linebg" SkinID="DDL_Skin"></asp:DropDownList><br />
                <font class="label">Enter Course Name : </font>
                <asp:TextBox ID="txtcourse" runat="server"  CssClass="lineborder linebg"></asp:TextBox><br />
                <font class="label">Enter Course Duration : </font><br />
                <asp:TextBox ID="txtcourseduration" runat="server" TextMode="Number" CssClass="lineborder linebg" MaxLength="1"></asp:TextBox>
     <asp:RangeValidator ID="rgv1" runat="server" ErrorMessage="Entered Number Must Between 1 to 5" Type="Integer" MaximumValue="5" MinimumValue="1" ControlToValidate="txtcourseduration" Display="Dynamic" Font-Size="15px" ForeColor="Red"></asp:RangeValidator><br /><br />

             <asp:Button ID="btn_insert" runat="server" Text="Insert" OnClick="btn_insert_Click"/>&nbsp;
                &nbsp;<asp:Button ID="btn_cancel" runat="server" Text="Cancel" OnClick="btn_cancel_Click"/>
    <br /><br />
    <center><asp:GridView ID="Grd_Course" runat="server" AutoGenerateColumns="False" OnRowUpdating="Grd_Course_RowUpdating" OnRowEditing="Grd_Course_RowEditing" OnRowCancelingEdit="Grd_Course_RowCancelingEdit"> 
                    <Columns>
                        <asp:TemplateField HeaderText="ID" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Cour_Id") %>'></asp:Label>
                            </ItemTemplate>
                            <ControlStyle Width="100%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="15%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Stream">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlStream" runat="server" CssClass="lineborder linebg" SkinID="DDL_Skin"></asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("Stream_Name") %>'></asp:Label>
                            </ItemTemplate>
                            <ControlStyle Width="100%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="38%" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Cour_Name" HeaderText="Course">
                        <ControlStyle Width="100%" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="38%" />
                        </asp:BoundField>
                        <asp:CommandField ButtonType="Image" HeaderText="Edit" EditImageUrl="~/Images/pencil-1.1s-50px.png" ShowEditButton="True" CancelImageUrl="~/Images/close-1.1s-50px.png" UpdateImageUrl="~/Images/ok-1.1s-50px.png">
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
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    </div>
    </div>
    </div>
</asp:Content>

