<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormHome.aspx.cs" Inherits="WebApplication3.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="vi-VN">
<head runat="server">
    <title></title>
    <webopt:bundlereference runat="server" path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link href="Style/StyleSheet1.css" rel="stylesheet" type="text/css" />
    <link href="lib/font-awesome/css/all.css" rel="stylesheet" />
    <script type="text/javascript">

    </script>    
    <style type="text/css">
        .auto-style1 {
            position: relative;
            line-height: 10px;
            border-radius: 5px;
            font-size: 1vw;
            font-weight: 450;
            text-transform: capitalize;
            cursor: pointer;
            outline-width: medium;
            outline-style: none;
            outline-color: invert;
            left: -1px;
            top: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="sm" EnablePageMethods="true" runat="server"/>
        <header>
            <nav class="navbar navbar-expand-lg navbar-toggleable-sm navbar-dark">
                <div class="container container-nav">
                    <a class="navbar-brand" runat="server" href="~/WebFormHome.aspx"><span class="navbar-brand-name">oto</span>chat</a>
                        <div class="box-search-nav">
                            <asp:TextBox ID="textsearchnav" runat="server" placeholder="Tên, hãng xe" OnTextChanged="TextBoxnav_TextChanged"></asp:TextBox>
                            <button class="btnsearchnav" onclick="TextBoxnav_TextChanged"><i class="fa-solid fa-magnifying-glass"></i></button>
                        </div>
                    <div class="collapse navbar-collapse d-sm-inline-flex justify-content-end">
                        <ul class="navbar-nav navbar-right">
                            <li><a runat="server" class="nav-link introduce" href="~/Account/Register">Giới thiệu</a></li>
                            <li>
                                <a runat="server" class="nav-link service" href="~/Account/Login">Dịch vụ 
                                    <i class="fa-solid fa-chevron-down"></i>
                                    <div class="box-service-list">
                                        <ul class="service-list">
                                            <li><i class="fa-solid fa-wrench"></i> bảo dưỡng</li>
                                            <li><i class="fa-regular fa-file-lines"></i> bảo hành</li>
                                            <li><i class="fa-solid fa-car-burst"></i> cứu hộ</li>
                                            <li><i class="fa-solid fa-car-on"></i> làm đẹp</li>
                                        </ul>
                                    </div>
                                </a>

                            </li>
                            <li><a runat="server" class="nav-link" href="~/Account/Login">Ưu đãi</a></li>
                            <li><a runat="server" class="nav-link product" href="~/Account/Login">Sản Phẩm</a></li>
                            <li><a runat="server" class="nav-link constact" href="~/Account/Login">Liên hệ <i class="fa-solid fa-phone-volume"></i></a></li>
                        </ul>
                    </div>
                </div>
            </nav>
        </header>
        <section>
            <header class="section-header">
                <div class="section-header-background">
                    <div class="section-header-background-content">

                    </div>
                </div>
            </header>
            <section class="section-main">
                <div class="main-product container">
                    <div class="boxchild-filter">
                        <h5><i class="fa-solid fa-filter"></i> bộ lọc tìm kiếm</h5>
                        <div class="boxchild-filter-box">
                            <div class="boxchild-filter-box-company filterchild">
                                <h6>Theo hãng xe</h6>
                                <asp:CheckBoxList AutoPostBack="true" CssClass="box-filter-list" ID="Company" runat="server" OnSelectedIndexChanged="Company_SelectedIndexChanged">
                                    <asp:ListItem Value="honda"> Honda <span><img src="Data/Logo/logo_honda.jpg"/></span></asp:ListItem>
                                    <asp:ListItem Value="huyndai"> Huyndai <span><img src="Data/Logo/logo_huyndai.jpg"/></span></asp:ListItem>
                                    <asp:ListItem Value="vinfast"> vinfast <span><img src="Data/Logo/logo_vinfast.jpg"/></span></asp:ListItem>
                                    <asp:ListItem Value="bmw"> Bmw <span><img src="Data/Logo/logo_bmw.jpg"/></span></asp:ListItem>
                                    <asp:ListItem Value="mercedes"> Mercedes <span><img src="Data/Logo/logo_mercedes.jpg"/></span></asp:ListItem>
                                    <asp:ListItem Value="toyota"> Toyota <span><img src="Data/Logo/logo_toyota.jpg"/></span></asp:ListItem>
                                    <asp:ListItem Value="nissan"> Nissan <span><img src="Data/Logo/logo_nissan.jpg"/></span></asp:ListItem>
                                    <asp:ListItem Value="kia"> Kia <span><img src="Data/Logo/logo_kia.jpg"/></span></asp:ListItem>
                                    <asp:ListItem Value="audi"> Audi <span><img src="Data/Logo/logo_audi.jpg"/></span></asp:ListItem>
                                    <asp:ListItem Value="ford"> Ford <span><img src="Data/Logo/logo_ford.jpg"/></span></asp:ListItem>
                                    <asp:ListItem Value="mitsubishi"> Mitsubishi <span><img src="Data/Logo/logo_mitsubishi.jpg"/></span></asp:ListItem>
                                    <asp:ListItem Value="lexus"> Lexus <span><img src="Data/Logo/logo_lexus.jpg"/></span></asp:ListItem>
                                    <asp:ListItem Value="mazda"> Mazda <span><img src="Data/Logo/logo_mazda.jpg"/></span></asp:ListItem>
                                </asp:CheckBoxList>
                            </div>
                            <div class="boxchild-filter-box-color filterchild">
                                <h6>Màu sắc</h6>
                                <asp:CheckBoxList AutoPostBack="true" ID="Color" runat="server" OnSelectedIndexChanged="Color_SelectedIndexChanged" style="width: 68px">
                                    <asp:ListItem Value="white">Trắng</asp:ListItem>
                                    <asp:ListItem Value="black">Đen</asp:ListItem>
                                    <asp:ListItem Value="grey">Xám</asp:ListItem>
                                    <asp:ListItem Value="blue">Xanh</asp:ListItem>
                                    <asp:ListItem Value="red">Đỏ</asp:ListItem>
                                </asp:CheckBoxList>
                            </div>                            
                            <div class="boxchild-filter-box-class filterchild">
                                <h6>Hạng xe</h6>
                                <asp:CheckBoxList AutoPostBack="true" ID="Class" runat="server" OnSelectedIndexChanged="Class_SelectedIndexChanged">
                                    <asp:ListItem Value="a">A</asp:ListItem>
                                    <asp:ListItem Value="b">B</asp:ListItem>
                                    <asp:ListItem Value="c">C</asp:ListItem>
                                    <asp:ListItem Value="d">D</asp:ListItem>
                                    <asp:ListItem Value="e">E</asp:ListItem>
                                    <asp:ListItem Value="f">F</asp:ListItem>
                                    <asp:ListItem Value="s">S</asp:ListItem>
                                </asp:CheckBoxList>
                            </div>
                            <div class="boxchild-filter-box-fuel filterchild" >
                                <h6>Mức tiêu thụ nhiên liệu</h6>
                                <asp:CheckBoxList AutoPostBack="true" ID="Fuel" runat="server" OnSelectedIndexChanged="Fuel_SelectedIndexChanged">
                                    <asp:ListItem Value="4.2">< 4.2 lít/100km</asp:ListItem>
                                    <asp:ListItem Value="4.3">4.2 - 6.3 lít/100km</asp:ListItem>
                                    <asp:ListItem Value="6.3">> 6.3 lít/100km</asp:ListItem>
                                </asp:CheckBoxList>
                            </div>
                            <div class="boxchild-filter-box-seat filterchild">
                                <h6>Số lượng chỗ ngồi</h6>
                                <asp:CheckBoxList AutoPostBack="true" ID="Seat" runat="server" OnSelectedIndexChanged="Seat_SelectedIndexChanged">
                                    <asp:ListItem Value="2">2 chỗ</asp:ListItem>
                                    <asp:ListItem Value="4">4 chỗ</asp:ListItem>
                                    <asp:ListItem Value="5">5 chỗ</asp:ListItem>
                                    <asp:ListItem Value="7">7 chỗ</asp:ListItem>
                                </asp:CheckBoxList>
                            </div>
                            <div class="boxchild-filter-box-year filterchild" >
                                <h6>Năm sản xuất</h6>
                                <asp:CheckBoxList AutoPostBack="true" ID="Year" runat="server" OnSelectedIndexChanged="Year_SelectedIndexChanged">
                                    <asp:ListItem Value="2018">2018</asp:ListItem>
                                    <asp:ListItem Value="2019">2019</asp:ListItem>
                                    <asp:ListItem Value="2020">2020</asp:ListItem>
                                    <asp:ListItem Value="2021">2020</asp:ListItem>
                                    <asp:ListItem Value="2022">2022</asp:ListItem>
                                    <asp:ListItem Value="2023">2023</asp:ListItem>
                                </asp:CheckBoxList>
                            </div>
                        </div>
                        <asp:Button ID="BtnDeleteAll" runat="server" Text="Xóa tất cả" OnClick="BtnDeleteAll_Click" />
                    </div>
                    <div class="show-list-product">
                        <div class="section-main-nav">
                            <div class="view-sort">
                                <div class="element sort"><i class="fa-solid fa-sort"></i> Sắp xếp chỗ ngồi</div>
                                <asp:DropDownList CssClass="dropdown" ID="DropDownListSeat" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListSeat_SelectedIndexChanged">
                                    <asp:ListItem Value="defaul">Mặc định</asp:ListItem>                                    
                                    <asp:ListItem Value="asc">Tăng dần</asp:ListItem>
                                    <asp:ListItem Value="desc">Giảm dần</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="view-sort">
                                <div class="element sort"><i class="fa-solid fa-sort"></i> Sắp xếp năm sản xuất</div>
                                <asp:DropDownList CssClass="dropdown" ID="DropDownListYear" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListYear_SelectedIndexChanged">
                                    <asp:ListItem Value="defaul">Mặc định</asp:ListItem>                                                                        
                                    <asp:ListItem Value="asc">Tăng dần</asp:ListItem>
                                    <asp:ListItem Value="desc">Giảm dần</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="view-sort">
                                <div class="element sort"><i class="fa-solid fa-sort"></i> Sắp xếp theo Giá</div>
                                <asp:DropDownList CssClass="dropdown" ID="DropDownListPrice" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListPrice_SelectedIndexChanged">
                                    <asp:ListItem Value="defaul">Mặc định</asp:ListItem>                                    
                                    <asp:ListItem Value="asc">Tăng dần</asp:ListItem>
                                    <asp:ListItem Value="desc">Giảm dần</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal" RepeatColumns="3" RepeatLayout="Table">
                            <ItemTemplate>
                                <div class="data-item">
                                    <img src="Data/Imageproduct/<%#Eval("Image") %>"/>
                                    <p class="product-name"><%#Eval("name") %></p>
                                    <p class="product-category"><%#Eval("company") %></p>
                                    <p class="product-price" id="price"><%#Eval("price", "{0:0,00}")%> VNĐ</p>
                                    <p class="product-description"><%#Eval("description") %></p>
                                    <div class="item-detail">Xem chi tiết <i class="fa-solid fa-share"></i></div>
                                    <div class="gift"><i class="fa-solid fa-gift"></i></div>
                                </div>
                            </ItemTemplate>
                        </asp:DataList>
                        <div class="box-btn-page justify-content-center">
                            <div class="btnPage">
                            <asp:Button BorderColor="White" CssClass="btnPage" ID="ButtonFirstPage" runat="server" Text="Trang đầu" OnClick="ButtonFirstPage_Click"/>
                            </div>
                            <div class="btnPage">
                            <asp:Button BorderColor="White" CssClass="btnPage" ID="ButtonPreviousPage" runat="server" Text="Trước" OnClick="ButtonPreviousPage_Click" />

                            </div>
                            <div class="btnPage">
                            <asp:Button BorderColor="White" CssClass="btnPage" ID="ButtonNextPage" runat="server" Text="Sau" OnClick="ButtonNextPage_Click"/>

                            </div>
                            <div class="btnPage">
                            <asp:Label Font-Size="13px" ID="LabelViewPageIndex" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <footer class="footer-main">
                <div class="box-end">
                    <h3 class="title">Kết nối với chúng tôi</h3>
                    <p class="content">Liên hệ ngay để chọn cho mình những sản phầm ưng ý<br />
                        và được hỗ trợ, tư vấn một cách nhiệt tình nhất.</p>
                    <div class="form-contact">
                        <asp:TextBox ID="txtContact" runat="server" placeholder="example@gmail.com" OnTextChanged="txtContact_TextChanged"></asp:TextBox>
                        <asp:Button ID="btnSubmitContact" runat="server" Text="Gửi" OnClick="btnSubmitContact_Click" />
                        <i class="fa-solid fa-envelope"></i>
                    </div>
                </div>
            </footer>
        </section>
        <footer >
            <div class="box-footer container">
                <div class="box-footer-left">
                    <h5>Nổi bật</h5>
                    <p>Theo dõi chúng tôi trên các nền tảng mạng <br /> 
                        xã hội để cập nhật thông tin mới nhất về các mẫu xe được người <br />
                        dùng cũng như các nhà sản xuất đáng giá cao. <br />
                        Hãy đến với chúng tôi để trải nhiệm những dịch vụ tốt nhất!
                    </p>
                    <h5>Theo dõi chúng tôi</h5>
                    <div class="footer-left-box-icon">
                        <i class="fa-brands fa-facebook"></i>
                        <i class="fa-brands fa-instagram"></i>
                        <i class="fa-brands fa-twitter"></i>
                        <i class="fa-brands fa-youtube"></i>
                        <i class="fa-brands fa-tiktok"></i>
                    </div>
                </div>
                <div class="box-footer-right">
                    <h5>popular shop</h5>
                    <div class="footer-right-box-img">
                        <img src="Data/footerlambogini.jpg"/>
                        <img src="Data/footerminicooper.jpg"/>
                        <img src="Data/footeraudi.jpg" />
                        <img src="Data/footerhuyndai.jpg"/>
                    </div>
                </div>
            </div>
            <p class="end">&copy; <%: DateTime.Now.Year %> - My ASP.NET Application - Coppyright: Mùi, Sơn, Hoàng</p>
        </footer>
    </form>
</body>
</html>

