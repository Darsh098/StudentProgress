<%@ Page Title="" Language="C#" MasterPageFile="~/Index.master" AutoEventWireup="true" CodeFile="frm_DisplayStaff_Inst.aspx.cs" Inherits="frm_DisplayStaff_Inst" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <br />
     <h1 class="lineborder linebg" style="font-size:2.8em;text-align:center">Staff List</h1>
    <br />
    <font class="label">Choose Stream : </font>
            <asp:DropDownList ID="ddlStream" runat="server" CssClass="lineborder linebg" AutoPostBack="true" SkinID="DDL_Skin" OnSelectedIndexChanged="ddlStream_SelectedIndexChanged"></asp:DropDownList><br />

    <font class="label">Choose Course : </font>
    <asp:DropDownList ID="ddlCourse" runat="server" CssClass="lineborder linebg" AutoPostBack="true" SkinID="DDL_Skin" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged"></asp:DropDownList><br />

    <asp:Repeater ID="rpt_staffdisplay" runat="server" OnItemCommand="rpt_staffdisplay_ItemCommand">
             <HeaderTemplate>
            <table>
                <th>Staff Name</th>
                 <th>Contact Number</th>
                <th>Email</th>
                <th>Edit</th>
                <th>Delete</th>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                    <td><asp:Label ID="lblstaffname" runat="server" Text='<%# Eval("Staff_Name") %>'/></td>
                    <td><asp:Label ID="lblstaffcont" runat="server" Text='<%# Eval("Staff_ContNo") %>'/></td>
                <td><asp:Label ID="lblstaffemail" runat="server" Text='<%# Eval("Staff_Email") %>'/></td>
                <td><asp:Button ID="btn_edit" runat="server" Text="Edit" CommandName="Edit" CommandArgument='<%# Eval("Staff_Id") %>' /></td>
                <td><asp:Button ID="btn_delete" runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%# Eval("Staff_Id") %>' /></td>
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
    </div>
</asp:Content>

