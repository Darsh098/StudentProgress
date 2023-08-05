<%@ Page Title="" Language="C#" MasterPageFile="~/Index.master" AutoEventWireup="true" CodeFile="frm_DisplayStudents_Inst.aspx.cs" Inherits="frm_DisplayStudents_Inst" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
     <h1 class="lineborder linebg" style="font-size:2.8em;text-align:center">Students List</h1>
    <br />
    <asp:Repeater ID="rpt_studentdisplay" runat="server" OnItemCommand="rpt_studentdisplay_ItemCommand">
             <HeaderTemplate>
            <table>
                <th>Student Name</th>
                <th>Course</th>
                <th>Semester</th>
                <th>Edit</th>
                <th>Delete</th>
                
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                    <td><asp:Label ID="lblstudname" runat="server" Text='<%# Eval("Stud_Name") %>'/></td>
                <td><asp:Label ID="lblcourname" runat="server" Text='<%# Eval("Cour_Name") %>'/></td>    
                <td><asp:Label ID="lblsemname" runat="server" Text='<%# Eval("Sem_Name") %>'/></td>
                <td><asp:Button ID="btn_edit" runat="server" Text="Edit" CommandName="Edit" CommandArgument='<%# Eval("Stud_Id") %>' /></td>
                <td><asp:Button ID="btn_delete" runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%# Eval("Stud_Id") %>' /></td>
                </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
   
    </asp:Repeater>
    </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    </div>
    </div>
</asp:Content>

