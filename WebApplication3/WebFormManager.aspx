<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormManager.aspx.cs" Inherits="WebApplication3.WebFormManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style5">
                <tr>
                    <td class="auto-style10">
                        &nbsp;</td>
                    <td class="auto-style10" colspan="2">
                        &nbsp;</td>
                    <td class="auto-style31">
                        &nbsp;</td>
                    <td class="auto-style30" rowspan="18">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style16">
                        &nbsp;</td>
                    <td class="auto-style16" colspan="3">
                        <asp:Label ID="Label1" runat="server" Text="QUẢN LÝ SẢN PHẨM" Font-Bold="True" Font-Overline="False" Font-Size="X-Large"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style16">
                        &nbsp;</td>
                    <td class="auto-style16" colspan="3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style10">
                        <asp:Label ID="Label3" runat="server" Text="Mã số xe"></asp:Label>
                    </td>
                    <td class="auto-style10" colspan="2">
                        <asp:TextBox ID="txtMaSo" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style13" rowspan="15">
                        <asp:GridView ID="grvDanhSachXe" runat="server" AutoGenerateSelectButton="True" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="grvDanhSachXe_SelectedIndexChanged" AllowPaging="True" Width="720px">
                            <AlternatingRowStyle BackColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style10">
                        <asp:Label ID="Label4" runat="server" Text="Tên xe"></asp:Label>
                    </td>
                    <td class="auto-style10" colspan="2">
                        <asp:TextBox ID="txtTen" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style10">
                        <asp:Label ID="Label5" runat="server" Text="Thương hiệu"></asp:Label>
                    </td>
                    <td class="auto-style10" colspan="2">
                        <asp:TextBox ID="txtThuongHieu" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style10">
                        <asp:Label ID="Label9" runat="server" Text="Màu sắc"></asp:Label>
                    </td>
                    <td class="auto-style10" colspan="2">
                        <asp:TextBox ID="txtMauSac" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style10">
                        <asp:Label ID="Label8" runat="server" Text="Kiểu xe"></asp:Label>
                    </td>
                    <td class="auto-style10" colspan="2">
                        <asp:TextBox ID="txtKieuXe" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style11">
                        <asp:Label ID="Label7" runat="server" Text="Giá thành"></asp:Label>
                    </td>
                    <td class="auto-style11" colspan="2">
                        <asp:TextBox ID="txtGia" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style11">
                        <asp:Label ID="Label11" runat="server" Text="Số ghế"></asp:Label>
                    </td>
                    <td class="auto-style11" colspan="2">
                        <asp:TextBox ID="txtSoGhe" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style11">
                        <asp:Label ID="Label12" runat="server" Text="Mức tiêu thụ nhiên liệu"></asp:Label>
                    </td>
                    <td class="auto-style11" colspan="2">
                        <asp:TextBox ID="txtMucTieuThu" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style11">
                        <asp:Label ID="Label10" runat="server" Text="Năm sản xuất"></asp:Label>
                    </td>
                    <td class="auto-style11" colspan="2">
                        <asp:TextBox ID="txtNamSX" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style11">
                        <asp:Label ID="Label13" runat="server" Text="Loại nhiên liệu"></asp:Label>
                    </td>
                    <td class="auto-style11" colspan="2">
                        <asp:TextBox ID="txtLoaiNhienLieu" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style11">
                        &nbsp;</td>
                    <td class="auto-style11" colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style11">
                        <asp:Button ID="btnThem" runat="server" OnClick="btnThem_Click" Text="Thêm Mới" Width="100px" />
                        </td>
                    <td class="auto-style11">
                        <asp:Button ID="btnSua" runat="server" Text="Chỉnh Sửa" OnClick="btnSua_Click" Width="100px" />
                        </td>
                    <td class="auto-style11">
                        <asp:Button ID="btnXoa" runat="server" Text="Xóa" OnClick="btnXoa_Click" CssClass="auto-style28" Width="100px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style22">
                        &nbsp;</td>
                    <td class="auto-style22" colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style22">
                        &nbsp;</td>
                    <td class="auto-style22" colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="3">&nbsp;</td>
                </tr>
                </table>
        </div>
    </form>
</body>
</html>
