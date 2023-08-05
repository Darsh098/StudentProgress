<%@ Page Title="" Language="C#" MasterPageFile="~/Index.master" AutoEventWireup="true" CodeFile="frm_StudentList.aspx.cs" Inherits="frm_StudentList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <center class="lineborder linebg">
        <h1 style="font-size:2.8em;text-align:center">College Assessment</h1>
        <asp:Image ID="img_institutedetails" runat="server" Height="200" AlternateText="Image Not Found" ImageUrl="~/Images/exam.png" />

    </center><br />
    <br /><font id="Font1" runat="server">Enter Exam Date : </font>
    <%--<input type="date" id="txtexamdate" runat="server" class="lineborder linebg" />--%>
    <asp:DropDownList ID="ddlPassingYear" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPassingYear_SelectedIndexChanged"></asp:DropDownList>
    <br/>

      <font id="lbl_totalmarksobt" runat="server">Enter TotalMarks Obtained : </font><br />
    <asp:TextBox ID="txt_totalmarksobt" runat="server" MaxLength="3" Width="60%" CssClass="lineborder linebg"></asp:TextBox>
     <asp:RequiredFieldValidator ID="rfv3_totalmarksobt" runat="server" ErrorMessage="TotalMarksObtained is Required" ControlToValidate="txt_totalmarksobt" Display="Dynamic" Font-Size="15px" ForeColor="Red" ValidationGroup="Marksheet"></asp:RequiredFieldValidator> 
    <asp:RangeValidator ID="rgv1" runat="server" ErrorMessage="Enter Valid Marks" Type="Integer" MaximumValue="100" MinimumValue="0" ControlToValidate="txt_totalmarksobt" Display="Dynamic" Font-Size="15px" ForeColor="Red"></asp:RangeValidator><br />

                 <font id="lbl_totalmarks" runat="server">Enter TotalMarks : </font><br />
    <asp:TextBox ID="txt_totalmarks" runat="server" MaxLength="3" CssClass="lineborder linebg"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfv4_totalmarks" runat="server" ErrorMessage="TotalMarks is Required" ControlToValidate="txt_totalmarks" Display="Dynamic" Font-Size="15px" ForeColor="Red" ValidationGroup="Marksheet"></asp:RequiredFieldValidator> 
    <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Enter Valid Marks" Type="Integer" MaximumValue="100" MinimumValue="0" ControlToValidate="txt_totalmarks" Display="Dynamic" Font-Size="15px" ForeColor="Red"></asp:RangeValidator><br />

    <font id="Font2" runat="server">Enter Remarks : </font>
    <asp:TextBox ID="txtremarks" runat="server" Font-Size="12" valign="center" CssClass="lineborder linebg"></asp:TextBox><br />

    <asp:Button ID="btn_add" runat="server" Text="Add" OnClick="btn_add_Click"></asp:Button>&nbsp;
    &nbsp;<asp:Button ID="btn_cancel" runat="server" Text="Cancel" OnClick="btn_cancel_Click"></asp:Button>&nbsp;
    &nbsp;<asp:Button ID="Btn_CheckAll" runat="server" Text="Check All" OnClick="Btn_CheckAll_Click"></asp:Button>
    <font id="lblerror" runat="server" Color="Red" Visible="false">Select Atleast One Student</font>
    <br /><br />

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
    </asp:GridView>

     <asp:GridView ID="Grd_StudentsMarksUpdate" runat="server" AutoGenerateColumns="False" OnRowEditing="Grd_StudentsMarksUpdate_RowEditing" OnRowUpdating="Grd_StudentsMarksUpdate_RowUpdating" OnRowCancelingEdit="Grd_StudentsMarksUpdate_RowCancelingEdit">
        <Columns>
            <asp:TemplateField HeaderText="ID" Visible="False">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Em_Id") %>'></asp:Label>
                </ItemTemplate>
                <ControlStyle Width="100%" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20%" />
            </asp:TemplateField>
            <asp:BoundField DataField="Stud_Name" HeaderText="Name" ReadOnly="true">
            <ControlStyle Width="100%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20%" />
            </asp:BoundField>
            <asp:BoundField DataField="Tt_Name" HeaderText="Test" ReadOnly="true">
            <ControlStyle Width="100%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20%" />
                </asp:BoundField>
            <asp:BoundField DataField="Em_ObtainedMarks" HeaderText="Obtained Marks">
            <ControlStyle Width="100%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20%"/>
                </asp:BoundField>
            <asp:BoundField DataField="Em_TotalMarks" HeaderText="Total Marks" ReadOnly="true">
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

