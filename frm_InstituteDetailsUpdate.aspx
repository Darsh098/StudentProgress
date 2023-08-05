<%@ Page Title="" Language="C#" MasterPageFile="~/Index.master" Theme="AspControlsSkin" AutoEventWireup="true" CodeFile="frm_InstituteDetailsUpdate.aspx.cs" Inherits="frm_InstituteDetailsUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="Theme1/signupcss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center class="lineborder linebg">
        <h1 style="font-size:2.8em;text-align:center">Institute Modification</h1>
        <asp:Image ID="img_institutedetails" runat="server" Height="200" AlternateText="Image Not Found" ImageUrl="~/Images/403-museum-authority-outline.gif" />

    </center><br />
    <center>
        <br />
        <asp:GridView ID="dt_inst" runat="server" ForeColor="#14213D" Font-Bold="True" CssClass="lineborder linebg" AutoGenerateColumns="False" OnRowCancelingEdit="dt_inst_RowCancelingEdit" OnRowEditing="dt_inst_RowEditing" OnRowUpdating="dt_inst_RowUpdating">
                <Columns>
                    <asp:TemplateField HeaderText="Logo">
                        <EditItemTemplate>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("InstD_Id", "frm_Inst_Logo.ashx?myId={0}") %>' />
                        <asp:FileUpload ID="fldImgGrid" runat="server"></asp:FileUpload>
                        </EditItemTemplate>
                        <ItemTemplate><br />
                           <asp:Image ID="Image1" CssClass="image" runat="server"  ImageUrl='<%# Eval("InstD_Id", "frm_Inst_Logo.ashx?myId={0}") %>' Width="50%" Height="50%"/>
                        </ItemTemplate>
                        <ControlStyle Width="100%" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="15%" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="InstD_Details" HeaderText="Description">
                    <ControlStyle Width="100%" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="40%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="InstD_ContactNo" HeaderText="ContactNo1">
                    <ControlStyle Width="100%" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="9%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="InstD_AltContactNo" HeaderText="ContactNo2">
                    <ControlStyle Width="100%" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="9%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="InstD_Email" HeaderText="E-mail">
                    <ControlStyle Width="100%" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="17%" />
                    </asp:BoundField>
                    <asp:CommandField ButtonType="Image" HeaderText="Edit" ShowEditButton="True" EditImageUrl="~/Images/pencil-1.1s-50px.png" UpdateImageUrl="~/Images/ok-1.1s-50px.png" CancelImageUrl="~/Images/close-1.1s-50px.png">
                    <ControlStyle Width="70%" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="9%"/>
                    </asp:CommandField>
                </Columns>
                <HeaderStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:GridView><br />

        <asp:GridView ID="grd_instgallery" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="grd_instgallery_RowCancelingEdit" OnRowEditing="grd_instgallery_RowEditing" OnRowUpdating="grd_instgallery_RowUpdating">
            <Columns>
                <asp:TemplateField HeaderText="ID" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("InstG_Id") %>'></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Width="100%" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Image 1">
                    <ItemTemplate>
                        <asp:Image ID="imginst1" runat="server" ImageUrl='<%# Eval("InstG_Id", "frm_Inst_Images.ashx?InstGId1={0}") %>'></asp:Image>
                    </ItemTemplate>
                    <ControlStyle Width="100%" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20%" />
                    <EditItemTemplate>
                        <asp:Image ID="imginstei1" runat="server" ImageUrl='<%# Eval("InstG_Id", "frm_Inst_Images.ashx?InstGId1={0}") %>'></asp:Image>
                        <asp:FileUpload ID="fld_img1" runat="server" ></asp:FileUpload>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Image 2">
                    <ItemTemplate>
                        <asp:Image ID="imginst2" runat="server" ImageUrl='<%# Eval("InstG_Id", "frm_Inst_Images.ashx?InstGId2={0}") %>'></asp:Image>
                    </ItemTemplate>
                    <ControlStyle Width="100%" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20%" />
                    <EditItemTemplate>
                        <asp:Image ID="imginstei2" runat="server" ImageUrl='<%# Eval("InstG_Id", "frm_Inst_Images.ashx?InstGId2={0}") %>'></asp:Image>
                        <asp:FileUpload ID="fld_img2" runat="server"></asp:FileUpload>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Image 3">
                    <ItemTemplate>
                        <asp:Image ID="imginst3" runat="server" ImageUrl='<%# Eval("InstG_Id", "frm_Inst_Images.ashx?InstGId3={0}") %>'></asp:Image>
                    </ItemTemplate>
                    <ControlStyle Width="100%" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20%" />
                    <EditItemTemplate>
                         <asp:Image ID="imginstei3" runat="server" ImageUrl='<%# Eval("InstG_Id", "frm_Inst_Images.ashx?InstGId3={0}") %>'></asp:Image>
                        <asp:FileUpload ID="fld_img3" runat="server"></asp:FileUpload>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ButtonType="Image" HeaderText="Edit" ShowEditButton="True" EditImageUrl="~/Images/pencil-1.1s-50px.png" UpdateImageUrl="~/Images/ok-1.1s-50px.png" CancelImageUrl="~/Images/close-1.1s-50px.png">
                    <ControlStyle Width="70%" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="9%"/>
                    </asp:CommandField>
            </Columns>

        </asp:GridView>
    </center>
    </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    
    </div>
    </div>
    </div>
</asp:Content>

