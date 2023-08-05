
<%@ Page Title="" Language="C#" MasterPageFile="~/Index.master" AutoEventWireup="true" CodeFile="frm_UniversityMarksEntry.aspx.cs" Inherits="frm_UniversityMarksEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <center class="lineborder linebg">
        <h1 style="font-size:2.8em;text-align:center">University Assessment And Management</h1>
                     <asp:Image ID="img_course" runat="server" AlternateText="Image Not Found" ImageUrl="~/Images/exam.png" Height="200"></asp:Image>
                 </center><br />
        
                 <font id="Font2" runat="server">Enter Passing Year : </font>
    <asp:DropDownList ID="ddlPassingYear" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPassingYear_SelectedIndexChanged"></asp:DropDownList>
    

              <font id="lbl_totalmarksobt" runat="server">Enter TotalMarks Obtained : </font>
    <asp:TextBox ID="txt_totalmarksobt" runat="server" Font-Size="12" valign="center" CssClass="lineborder linebg" MaxLength="3"></asp:TextBox>     
     <asp:RequiredFieldValidator ID="rfv3_totalmarksobt" runat="server" ErrorMessage="TotalMarksObtained is Required" ControlToValidate="txt_totalmarksobt" Display="Dynamic" Font-Size="15px" ForeColor="Red" ValidationGroup="Marksheet"></asp:RequiredFieldValidator> 
     <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Enter Valid Marks" Type="Integer" MaximumValue="100" MinimumValue="0" ControlToValidate="txt_totalmarksobt" Display="Dynamic" Font-Size="15px" ForeColor="Red"></asp:RangeValidator><br />

                 <font id="lbl_totalmarks" runat="server">Enter TotalMarks : </font>
    <asp:TextBox ID="txt_totalmarks" runat="server" CssClass="lineborder linebg" MaxLength="3"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfv4_totalmarks" runat="server" ErrorMessage="TotalMarks is Required" ControlToValidate="txt_totalmarks" Display="Dynamic" Font-Size="15px" ForeColor="Red" ValidationGroup="Marksheet"></asp:RequiredFieldValidator>
     <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="Enter Valid Marks" Type="Integer" MaximumValue="100" MinimumValue="0" ControlToValidate="txt_totalmarks" Display="Dynamic" Font-Size="15px" ForeColor="Red"></asp:RangeValidator><br />

                 <font id="Font1" runat="server">Enter Remarks : </font>
    <asp:TextBox ID="txtremarks" runat="server" CssClass="lineborder linebg"></asp:TextBox><br />
    <asp:Button ID="btn_register" runat="server" Text="Register" OnClick="btn_register_Click"></asp:Button>&nbsp;&nbsp;
    &nbsp;&nbsp;<asp:Button ID="btn_cancel" runat="server" Text="Cancel" OnClick="btn_cancel_Click"></asp:Button><br /><br />

     <asp:GridView ID="dt_studentlist" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField HeaderText="Select Student">
                <EditItemTemplate>
                    <asp:CheckBox ID="chked_studselect" runat="server" Text=" " />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="chk_studselect" runat="server" Text=" "/>
                </ItemTemplate>
                <ControlStyle Width="100%" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="25%" />
            </asp:TemplateField>
            <asp:BoundField DataField="Sc_RollNo" HeaderText="Roll No">
            <ControlStyle Width="100%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="25%" />
            </asp:BoundField>
            <asp:BoundField DataField="Stud_Name" HeaderText="Name">
            <ControlStyle Width="100%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="25%" />
            </asp:BoundField>
            <asp:BoundField DataField="Div_Name" HeaderText="Divison">
            <ControlStyle Width="100%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="25%" />
            </asp:BoundField>
        </Columns>
    </asp:GridView><br />
    <asp:GridView ID="grd_studentlistupdate" runat="server" AutoGenerateColumns="False" OnRowEditing="grd_studentlistupdate_RowEditing" OnRowUpdating="grd_studentlistupdate_RowUpdating" OnRowCancelingEdit="grd_studentlistupdate_RowCancelingEdit">
        <Columns>
            <asp:TemplateField HeaderText="ID" Visible="False">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Uni_Id") %>'></asp:Label>
                </ItemTemplate>
                <ControlStyle Width="100%" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20%" />
            </asp:TemplateField>
            <asp:BoundField DataField="Stud_Name" HeaderText="Name" ReadOnly="true">
            <ControlStyle Width="100%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20%" />
            </asp:BoundField>
            <asp:BoundField DataField="Uni_ExamYear" HeaderText="Passing Year" ReadOnly="true">
            <ControlStyle Width="100%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20%" />
                </asp:BoundField>
            <asp:BoundField DataField="Uni_ObtainedMarks" HeaderText="Obtained Marks">
            <ControlStyle Width="100%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20%"/>
                </asp:BoundField>
            <asp:BoundField DataField="Uni_TotalMarks" HeaderText="Total Marks" ReadOnly="true">
            <ControlStyle Width="100%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20%" />
                </asp:BoundField>
            <asp:CommandField ButtonType="Image" HeaderText="Edit" ShowEditButton="True" EditImageUrl="~/Images/pencil-1.1s-50px.png" UpdateImageUrl="~/Images/ok-1.1s-50px.png" CancelImageUrl="~/Images/close-1.1s-50px.png">
                    <ControlStyle Width="70%" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="9%"/>
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

