<%@ Page Title="" Language="C#" MasterPageFile="~/Index.master" AutoEventWireup="true" CodeFile="frm_Educational_Details.aspx.cs" Inherits="frm_Educational_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center class="lineborder linebg">
        <h1 style="font-size:2.8em;text-align:center">Academics Details</h1>
        <asp:Image ID="img_educationDetails" runat="server" AlternateText="Image Not Found" ImageUrl="~/Images/112-book-morph-outline.gif" Height="200"></asp:Image>

    </center>


    <br />
    <h2>10th Details</h2>
    <font id="lbl10_passingyear" runat="server">Enter Your Passing Year : </font>
    <asp:TextBox ID="txt10_passingyear" runat="server" CssClass="lineborder linebg" Font-Size="12" valign="center" MaxLength="4"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfv1_passingyear" runat="server" ErrorMessage="Passing Year is Required" ControlToValidate="txt10_passingyear" Display="Dynamic" Font-Size="15px" ForeColor="Red" ValidationGroup="Marksheet"></asp:RequiredFieldValidator>
    <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Entered Number Must Between 1900 to 2022" Type="Integer" MaximumValue="2022" MinimumValue="1900" ControlToValidate="txt10_passingyear" Display="Dynamic" Font-Size="15px" ForeColor="Red"></asp:RangeValidator><br />

    <font id="lbl10_boardname" runat="server">Enter Your BoardName : </font>
    <asp:TextBox ID="txt10_boardname" runat="server" CssClass="lineborder linebg"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfv2_boardname" runat="server" ErrorMessage="BoardName is Required" ControlToValidate="txt10_boardname" Display="Dynamic" Font-Size="15px" ForeColor="Red" ValidationGroup="Marksheet"></asp:RequiredFieldValidator>
    <br />

    <font id="lbl10_totalmarksobt" runat="server">Enter TotalMarks Obtained : </font>
    <asp:TextBox ID="txt10_totalmarksobt" runat="server" Font-Size="12" valign="center" CssClass="lineborder linebg" OnTextChanged="txt10_totalmarksobt_TextChanged" AutoPostBack="true"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfv3_totalmarksobt" runat="server" ErrorMessage="TotalMarksObtained is Required" ControlToValidate="txt10_totalmarksobt" Display="Dynamic" Font-Size="15px" ForeColor="Red" ValidationGroup="Marksheet"></asp:RequiredFieldValidator>
    <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="Enter Valid Marks" Type="Integer" MaximumValue="1000" MinimumValue="0" ControlToValidate="txt10_totalmarksobt" Display="Dynamic" Font-Size="15px" ForeColor="Red"></asp:RangeValidator><br />

    <font id="lbl10_totalmarks" runat="server">Enter TotalMarks : </font>
    <asp:TextBox ID="txt10_totalmarks" runat="server" CssClass="lineborder linebg" OnTextChanged="txt10_totalmarksobt_TextChanged" AutoPostBack="True" MaxLength="3"></asp:TextBox>
    <font id="lblpercent" runat="server" visible="False"></font>
    <asp:RequiredFieldValidator ID="rfv4_totalmarks" runat="server" ErrorMessage="TotalMarks is Required" ControlToValidate="txt10_totalmarks" Display="Dynamic" Font-Size="15px" ForeColor="Red" ValidationGroup="Marksheet"></asp:RequiredFieldValidator>
    <asp:RangeValidator ID="RangeValidator3" runat="server" ErrorMessage="Enter Valid Marks" Type="Integer" MaximumValue="1000" MinimumValue="0" ControlToValidate="txt10_totalmarks" Display="Dynamic" Font-Size="15px" ForeColor="Red"></asp:RangeValidator><br />



    <h2>12th Details</h2>

    <font id="lbl12_passingyear" runat="server">Enter Your Passing Year : </font>
    <asp:TextBox ID="txt12_passingyear" runat="server" CssClass="lineborder linebg" MaxLength="4"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfv5_passingyear" runat="server" ErrorMessage="Passing Year is Required" ControlToValidate="txt12_passingyear" Display="Dynamic" Font-Size="15px" ForeColor="Red" ValidationGroup="Marksheet"></asp:RequiredFieldValidator>
    <asp:RangeValidator ID="RangeValidator4" runat="server" ErrorMessage="Entered Number Must Between 1900 to 2022" Type="Integer" MaximumValue="2022" MinimumValue="1900" ControlToValidate="txt12_passingyear" Display="Dynamic" Font-Size="15px" ForeColor="Red"></asp:RangeValidator><br />

    <font id="lbl12_boardname" runat="server">Enter Your BoardName : </font>
    <asp:TextBox ID="txt12_boardname" runat="server" Font-Size="12" valign="center" CssClass="lineborder linebg"></asp:TextBox>

    <asp:RequiredFieldValidator ID="rfv6_boardname" runat="server" ErrorMessage="BoardName is Required" ControlToValidate="txt12_boardname" Display="Dynamic" Font-Size="15px" ForeColor="Red" ValidationGroup="Marksheet"></asp:RequiredFieldValidator>
    <br />

    <font id="lbl12_totalmarksobt" runat="server">Enter TotalMarks Obtained : </font>
    <asp:TextBox ID="txt12_totalmarksobt" runat="server" CssClass="lineborder linebg" OnTextChanged="txt12_totalmarks_TextChanged" AutoPostBack="true" MaxLength="3"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfv7_totalmarksobt" runat="server" ErrorMessage="TotalMarksObtained is Required" ControlToValidate="txt12_totalmarksobt" Display="Dynamic" Font-Size="15px" ForeColor="Red" ValidationGroup="Marksheet"></asp:RequiredFieldValidator>
    <asp:RangeValidator ID="RangeValidator5" runat="server" ErrorMessage="Enter Valid Marks" Type="Integer" MaximumValue="1000" MinimumValue="0" ControlToValidate="txt12_totalmarksobt" Display="Dynamic" Font-Size="15px" ForeColor="Red"></asp:RangeValidator><br />

    <font id="lbl12_totalmarks" runat="server">Enter TotalMarks : </font>
    <asp:TextBox ID="txt12_totalmarks" runat="server" CssClass="lineborder linebg" OnTextChanged="txt12_totalmarks_TextChanged" AutoPostBack="true" MaxLength="3"></asp:TextBox>
    <font id="lblpercent12" runat="server" visible="False"></font>
    <asp:RequiredFieldValidator ID="rfv8_totalmarks" runat="server" ErrorMessage="TotalMarks is Required" ControlToValidate="txt12_totalmarks" Display="Dynamic" Font-Size="15px" ForeColor="Red" ValidationGroup="Marksheet"></asp:RequiredFieldValidator>
    <asp:RangeValidator ID="RangeValidator6" runat="server" ErrorMessage="Enter Valid Marks" Type="Integer" MaximumValue="1000" MinimumValue="0" ControlToValidate="txt12_totalmarks" Display="Dynamic" Font-Size="15px" ForeColor="Red"></asp:RangeValidator><br />


    <asp:GridView ID="dtGrd_Test" runat="server" Width="100%" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True">
        <Columns>
            <asp:BoundField HeaderText="Sr.No" DataField="SrNo">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Grade">
                <ItemTemplate>
                    <asp:DropDownList ID="ddlGradeGrid" runat="server" AutoPostBack="True" Font-Size="1.0em" Width="100%" DataSourceID="DS_Grade" DataTextField="deg_Name" DataValueField="deg_id">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="DS_Grade" runat="server"
                        ConnectionString="Data Source=LAPTOP-PU1IODI3;Initial Catalog=DB_StudentProgress;Integrated Security=True" SelectCommand="SELECT deg_name,deg_id FROM Tbl_DegreeMaster WHERE deg_IsActive='TRUE'"></asp:SqlDataSource>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="14%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Board">
                <ItemTemplate>
                    <asp:DropDownList ID="ddlUniGrid" runat="server" AutoPostBack="True" Font-Size="1.0em" Width="100%" DataSourceID="DS_Uni" DataTextField="board_name" DataValueField="board_id">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="DS_Uni" runat="server" ConnectionString="Data Source=LAPTOP-PU1IODI3;Initial Catalog=DB_StudentProgress;Integrated Security=True"
                        SelectCommand="SELECT board_name,board_id FROM Tbl_BoardMaster WHERE board_IsActive='TRUE'"></asp:SqlDataSource>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="31%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Passing Year">
                <ItemTemplate>
                    <asp:DropDownList ID="ddlYearGrid" runat="server" AutoPostBack="True" Font-Size="1.0em" Width="100%">
                    </asp:DropDownList>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="15%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Total Marks">
                <ItemTemplate>
                    <input type="text" id="txtTotalMarks" runat="server" value='<%# Eval("TotalMarks") %>' style="margin: 0px; width: 85%; padding: 5px;" maxlength="3" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="20%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Obt Marks">
                <ItemTemplate>
                    <input type="text" id="txtObtMarks" runat="server" value='<%# Eval("ObtMarks") %>' style="margin: 0px; width: 85%; padding: 5px;" maxlength="3" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="20%" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Button ID="btn_newrow" runat="server" Text="Add New Record" OnClick="btn_newrow_Click"></asp:Button><br />


    <br />
    <asp:Button ID="btn_register" runat="server" Text="Register" ValidationGroup="Marksheet" OnClick="btn_register_Click"></asp:Button>
    <asp:Button ID="btn_cancel" runat="server" Text="Cancel" OnClick="btn_cancel_Click"></asp:Button><br />
    <br />
    </div>
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    </div>
        </div>
        </div>
</asp:Content>

