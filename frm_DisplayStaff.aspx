<%@ Page Title="" Language="C#" MasterPageFile="~/Index.master" AutoEventWireup="true" CodeFile="frm_DisplayStaff.aspx.cs" Inherits="frm_DisplayStaff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <br />
     <h1 class="lineborder linebg" style="font-size:2.8em;text-align:center">Staff List</h1>
    <br />

     <font id="lblInst" runat="server" class="label">Choose Institute : </font>
                <asp:DropDownList ID="ddlInst" runat="server" CssClass="lineborder linebg" SkinID="DDL_Skin" AutoPostBack="true" OnSelectedIndexChanged="ddlInst_SelectedIndexChanged"></asp:DropDownList><br />
    <asp:Repeater ID="rpt_staffdisplay" runat="server" OnItemCommand="rpt_staffdisplay_ItemCommand">
             <HeaderTemplate>
            <table>
                <th>Staff Name</th>
                 <th>Institute Name</th>
                 <th>Edit</th>
                 <th>Delete</th>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                    <td><asp:Label ID="lblstudname" runat="server" Text='<%# Eval("Staff_Name") %>'/></td>
                    <td><asp:Label ID="lblinstname" runat="server" Text='<%# Eval("Inst_Name") %>'/></td>
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

