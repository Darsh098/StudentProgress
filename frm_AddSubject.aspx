<%@ Page Title="" Language="C#" MasterPageFile="~/Index.master" Theme="AspControlsSkin" AutoEventWireup="true" CodeFile="frm_AddSubject.aspx.cs" Inherits="frm_AddSubject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="Theme1/signupcss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
      <center class="lineborder linebg">
          <h1 style="font-size:2.8em">Subject Elaborate And Management</h1>
          <asp:Image ID="img_course" runat="server"  ImageUrl="~/Images/animation_500_kywu6g21.gif" SkinID="IMG_Skin"></asp:Image>

      </center><br />
                
                <font class="label">Choose Stream : </font>
            
                <asp:DropDownList ID="ddlStream" runat="server" CssClass="lineborder linebg" AutoPostBack="true" SkinID="DDL_Skin" OnSelectedIndexChanged="ddlStream_SelectedIndexChanged"></asp:DropDownList><br />
            
                <font class="label">Choose Course : </font>
                <asp:DropDownList ID="ddlCourse" runat="server" CssClass="lineborder linebg" AutoPostBack="true" SkinID="DDL_Skin" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged"></asp:DropDownList><br />
                <font class="label">Choose Semester : </font>
                <asp:DropDownList ID="ddlSem" runat="server" CssClass="lineborder linebg" AutoPostBack="true" SkinID="DDL_Skin" OnSelectedIndexChanged="ddlSem_SelectedIndexChanged"></asp:DropDownList><br />
                <font class="label">Enter Subject Name : </font>
             <asp:TextBox ID="txtsubjectname" runat="server" CssClass="lineborder linebg"></asp:TextBox><br />
                <font class="label">Enter Subject Code : </font>
             <asp:TextBox ID="txtsubjectcode" runat="server" CssClass="lineborder linebg" ></asp:TextBox><br />
            
         <asp:Button ID="btn_insert" runat="server" Text="Insert" OnClick="btn_insert_Click"/>&nbsp;
        
                &nbsp;<asp:Button ID="btn_cancel" runat="server"  Text="Cancel" OnClick="btn_cancel_Click"/><br /><br />
        
              <center><asp:GridView ID="dt_subject" runat="server" AutoGenerateColumns="False" OnRowUpdating="dt_subject_RowUpdating" OnRowEditing="dt_subject_RowEditing" OnRowDeleting="dt_subject_RowDeleting" OnRowCancelingEdit="dt_subject_RowCancelingEdit"> 
                    <Columns>
                        <asp:BoundField HeaderText="ID" ReadOnly="True" DataField="Sub_Id">
                        <ControlStyle Width="100%" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="15%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Sub_Name" HeaderText="Subject">
                        <ControlStyle Width="100%" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="33%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Sub_Code" HeaderText="Subject Code">
                        <ControlStyle Width="100%" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="33%" />
                        </asp:BoundField>
                        <asp:CommandField ButtonType="Image" HeaderText="Edit" EditImageUrl="~/Images/pencil-1.1s-50px.png" ShowEditButton="True" CancelImageUrl="~/Images/close-1.1s-50px.png" UpdateImageUrl="~/Images/ok-1.1s-50px.png">
                        <ControlStyle Width="70%" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="9%" />
                        </asp:CommandField>
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
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    </div>
    </div>
    </div>
</asp:Content>

