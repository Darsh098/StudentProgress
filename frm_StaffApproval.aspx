<%@ Page Title="" Language="C#" MasterPageFile="~/Index.master" AutoEventWireup="true" CodeFile="frm_StaffApproval.aspx.cs" Inherits="frm_StaffApproval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
        <h1 style="font-size:2.8em;text-align:center" class="linebg lineborder">Staff's Approval</h1></center>
    </center>
        
    
    <asp:GridView ID="dt_approval" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="dt_approval_RowCancelingEdit" OnRowEditing="dt_approval_RowEditing" OnRowUpdating="dt_approval_RowUpdating" OnRowCommand="dt_approval_RowCommand">
        <Columns>
            <asp:BoundField DataField="Staff_Id" HeaderText="Staff ID" ReadOnly="True">
            <ControlStyle Width="100%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="16%" />
            </asp:BoundField>
            <asp:BoundField DataField="Staff_Name" HeaderText="Staff Name" ReadOnly="true">
            <ControlStyle Width="100%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="16%" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Divison">
                <EditItemTemplate>
                    <asp:DropDownList ID="ddl_division" runat="server"></asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Div_Id") %>'></asp:Label>
                </ItemTemplate>
                <ControlStyle Width="100%" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="16%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="View Details" ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="btn_details" runat="server" CausesValidation="false" Text="Show" CommandArgument='<%# Bind("Staff_Id") %>' CommandName="display" />
                </ItemTemplate>
                <ControlStyle Width="100%" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="16%" />
            </asp:TemplateField>
            <asp:CommandField ButtonType="Button" HeaderText="Acitivate" ShowEditButton="True" EditText="Activate">
            <ControlStyle Width="100%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="16%" />
            </asp:CommandField>
        </Columns>
    </asp:GridView>
    </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    </div>
    </div>
    </div>
</asp:Content>

