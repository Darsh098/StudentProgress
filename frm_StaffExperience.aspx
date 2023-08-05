<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Index.master" Theme="AspControlsSkin" CodeFile="frm_StaffExperience.aspx.cs" Inherits="frm_StaffExperience" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Theme1/signupcss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <center class="lineborder linebg">

        <h1 style="font-size:2.8em;text-align:center">Staff Work Experience</h1>
            <asp:Image ID="img_experience" runat="server" AlternateText="Image Not Found" ImageUrl="~/Images/187-suitcase-outline.gif" Height="200"></asp:Image></center><br />
            
    <asp:GridView ID="dtGrd_Test" runat="server" Width="99%" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField HeaderText="Sr.No" DataField="SrNo" >
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Organization Name">
                                <ItemTemplate>
                                    <input type="text" id="txtOrganization" runat="server" value='<%# Eval("Organization") %>' style="margin:0px; width:85%; padding:5px;" />
                                 </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="20%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Designation">
                                <ItemTemplate>
                                    <input type="text" id="txtDesignation" runat="server" value='<%# Eval("Designation") %>' style="margin:0px; width:85%; padding:5px;" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="20%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Joining Date">
                                <ItemTemplate>
                                    <input type="date" id="txtJoin" runat="server" value='<%# Eval("JoinDate")%>' style="margin:0px; width:88%; padding:5px;" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="20%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Leaving Date">
                                <ItemTemplate>
                                    <input type="date" id="txtLeave" runat="server" max="2-2-2022" value='<%# Eval("LeaveDate")%>' style="margin:0px; width:88%; padding:5px;" />                                    
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="20%" />
                            </asp:TemplateField>
                        </Columns>
                        </asp:GridView>
        <asp:Button ID="btn_addnewrecord" runat="server" Text="Add New Record" OnClick="btn_addnewrecord_Click"></asp:Button><br /><br />
        
        <asp:Button ID="btn_register" runat="server" Text="Register" OnClick="btn_register_Click"></asp:Button>
    &nbsp;&nbsp;&nbsp;<asp:Button ID="btn_cancel" runat="server" Text="Cancel"></asp:Button>
    </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
            
    
               
        </div>
    </div>
    </div>
</asp:Content>
