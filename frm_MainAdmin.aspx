<%@ Page Title="" Language="C#" MasterPageFile="~/Index.master" AutoEventWireup="true" CodeFile="frm_MainAdmin.aspx.cs" Inherits="frm_MainAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <center class="lineborder linebg">
        <h1 style="font-size:2.8em;text-align:center">Institutes</h1>
    </center><br />
    <asp:Repeater ID="rpt_institues" runat="server" OnItemCommand="rpt_institues_ItemCommand">
        <HeaderTemplate>
            <table>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
             <td><asp:ImageButton ID="imginstitutelogo" runat="server" Height="25%" Width="25%" ImageAlign="Left" CommandName="InstituteUrl" CommandArgument='<%#Eval("Inst_Id") %>'/> </td>
             <td><asp:Label ID="lblinstitutename" runat="server" Text='<%#Eval("Inst_Name") %>' style="text-align:right"></asp:Label> </td>
             <asp:Label ID="lblintituteid" runat="server" Text='<%#Eval("Inst_Id") %>' Visible="false"></asp:Label>
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

