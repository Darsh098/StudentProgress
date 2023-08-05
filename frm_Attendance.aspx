<%@ Page Title="" Language="C#" MasterPageFile="~/Index.master" AutoEventWireup="true" CodeFile="frm_Attendance.aspx.cs" Inherits="frm_Attendance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
        <h1 style="font-size:2.8em;text-align:center">Collecting Presence</h1>
        <asp:Image ID="img_course" runat="server" AlternateText="Image Not Found" ImageUrl="~/Images/attendance.png" Height="200"></asp:Image>
                 </center><br /><br />
                
                <font class="label">Choose Stream : </font>
                <asp:DropDownList ID="ddlStream" runat="server" CssClass="lineborder linebg" AutoPostBack="true" SkinID="DDL_Skin" OnSelectedIndexChanged="ddlStream_SelectedIndexChanged"></asp:DropDownList><br />
                
            <font class="label">Choose Course : </font>
                <asp:DropDownList ID="ddlCourse" runat="server" CssClass="lineborder linebg" AutoPostBack="true" SkinID="DDL_Skin" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged"></asp:DropDownList><br />
                <font class="label">Choose Semester : </font>
                <asp:DropDownList ID="ddlSem" runat="server" CssClass="lineborder linebg" SkinID="DDL_Skin" OnSelectedIndexChanged="ddlSem_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList><br />
 
            <font class="label">Choose Division : </font>
            <asp:DropDownList ID="ddl_division" runat="server" CssClass="lineborder linebg" OnSelectedIndexChanged="ddl_division_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList><br />
            
    <asp:Calendar ID="cldar" runat="server" Visible="false" OnSelectionChanged="cldar_SelectionChanged" Height="25%" Width="25%"></asp:Calendar>
            <font class="label">Choose Date : </font>

    <asp:Label ID="txtdate" runat="server" Text=""></asp:Label>
    <asp:ImageButton ID="btndate" runat="server" ImageUrl="~/Images/New Project.png" style="padding:0px" OnClick="btndate_Click" />
    


    <asp:Repeater ID="dt_studentstatus" runat="server">
        <HeaderTemplate>
            <table>
                <th>Check</th>
                <th>Roll Number</th>
                <th>Name</th>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                    <td><asp:CheckBox ID="chk_studselect" runat="server" Text=" "/></td>
                    <td><asp:Label ID="lblrollno" runat="server" Text='<%# Eval("Sc_RollNo") %>'/> <asp:Label ID="lblstudid" runat="server" Text='<%# Eval("Stud_Id") %>' Visible="false"/></td>
                <td><asp:Label ID="lblname" runat="server" Text='<%# Eval("Stud_Name") %>'/></td>
                </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater><br /><br />

    <font class="label" runat="server" id="lblStatus" visible="false">Choose Status : </font>
            <asp:RadioButtonList ID="rd_status" runat="server" RepeatDirection="Horizontal" Visible="false">
                
                <asp:ListItem Value="1">Present</asp:ListItem>
                <asp:ListItem Value="2">Absent</asp:ListItem>
                <%--<asp:ListItem Value="2">Leave</asp:ListItem>--%>
            </asp:RadioButtonList>

    <asp:GridView ID="grd_studentstatus" runat="server" AutoGenerateColumns="False" OnRowEditing="grd_studentstatus_RowEditing" OnRowUpdating="grd_studentstatus_RowUpdating" OnRowCancelingEdit="grd_studentstatus_RowCancelingEdit">
        <Columns>
            <asp:BoundField DataField="Stud_Id" HeaderText="Student Id" ReadOnly="True">
            <ControlStyle Width="100%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="25%" />
            </asp:BoundField>
            <asp:BoundField DataField="Stud_Name" HeaderText="Student Name" ReadOnly="true">
            <ControlStyle Width="100%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="25%" />
            </asp:BoundField>
            <asp:TemplateField Visible="false">
                <ItemTemplate>
                     <asp:Label ID="lblattid" runat="server" Text='<%# Eval("Att_Id") %>' Visible="false"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Status">

                <ControlStyle Width="100%" />
                <ItemTemplate>
                    <asp:Label ID="lblstatus" runat="server" Text='<%# Eval("Status_Type") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:RadioButton Id="grdrd_present" runat="server" GroupName="rd_status" Text="Present" ToolTip="1"></asp:RadioButton>
                    <asp:RadioButton Id="grdrd_absent" runat="server" GroupName="rd_status" Text="Absent" ToolTip="2"></asp:RadioButton>
                </EditItemTemplate>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="25%" />
                
            </asp:TemplateField>
            <asp:CommandField ButtonType="Button" HeaderText="Edit" ShowEditButton="True">
            <ControlStyle Width="100%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="25%" />
            </asp:CommandField>
        </Columns>
    </asp:GridView>
    <asp:Button ID="btn_save" runat="server" Text="Save" OnClick="btn_save_Click" />
    </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    </div>
    </div>
    </div>
</asp:Content>

