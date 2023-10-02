using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using Microsoft.SqlServer.Server;

namespace WebApplication3
{
    public partial class WebFormManager : System.Web.UI.Page
    {
        private string connString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            string maSo = txtMaSo.Text;
            string tenXe = txtTen.Text;
            string thuongHieu = txtThuongHieu.Text;
            string mauSac = txtMauSac.Text;
            string kieuXe = txtKieuXe.Text;
            string giaThanh = txtGia.Text;
            string soGhe = ddlSoGhe.Text;
            string luongTieuThu = txtNhienLieuTieuThu.Text;   
            string namSanXuat = txtNamSX.Text;
            string loaiNhienLieu = ddlNhienLieu.Text;



            //Them du lieu vao CSDL
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                string insertQuery = "INSERT INTO car (id, name, company, color, carclass, price, seat, fuel, year, description) VALUES (@id, @name, @company, @color, @carclass, @price, @seat, @fuel, @year, @description)";
                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@id", maSo);
                    cmd.Parameters.AddWithValue("@name", tenXe);
                    cmd.Parameters.AddWithValue("@company", thuongHieu);
                    cmd.Parameters.AddWithValue("@color", mauSac);
                    cmd.Parameters.AddWithValue("@carclass", kieuXe);
                    cmd.Parameters.AddWithValue("@price", giaThanh);
                    cmd.Parameters.AddWithValue("@seat", soGhe);
                    cmd.Parameters.AddWithValue("@fuel", luongTieuThu);
                    cmd.Parameters.AddWithValue("@description", loaiNhienLieu);
                    cmd.Parameters.AddWithValue("@year", namSanXuat);



                    //cmd.Parameters.AddWithValue("@hinhAnh", fileData);

                    //cmd.Parameters.Add("@binaryData", SqlDbType.VarBinary, -1).Value = yourByteArray;

                    cmd.ExecuteNonQuery();
                }
            }
            BindGridView();
        }

        protected void btnSua_Click(object sender, EventArgs e)
        {
            string maSo = txtMaSo.Text;
            string tenXe = txtTen.Text;
            string thuongHieu = txtThuongHieu.Text;
            string mauSac = txtMauSac.Text;
            string kieuXe = txtKieuXe.Text;
            decimal giaThanh = decimal.Parse(txtGia.Text);

            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                string updateQuery = "Update tblOToSub SET Ten = @tenXe, ThuongHieu = @thuongHieu, MauSac = @mauSac, KieuXe = @kieuXe, GiaThanh = @giaThanh WHERE MaSo = @MaSo";
                using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@maSo", maSo);
                    cmd.Parameters.AddWithValue("@tenXe", tenXe);
                    cmd.Parameters.AddWithValue("@thuongHieu", thuongHieu);
                    cmd.Parameters.AddWithValue("@mauSac", mauSac);
                    cmd.Parameters.AddWithValue("@kieuXe", kieuXe);
                    cmd.Parameters.AddWithValue("@giaThanh", giaThanh);
                    cmd.ExecuteNonQuery();
                }
            }
            BindGridView();
        }

        protected void btnXoa_Click(object sender, EventArgs e)
        {
            string maSo = txtMaSo.Text;
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                string updateQuery = "DELETE FROM car WHERE id = @MaSo";
                using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@maSo", maSo);
                    //cmd.Parameters.AddWithValue("@tenXe", tenXe);
                    //cmd.Parameters.AddWithValue("@thuongHieu", thuongHieu);
                    //cmd.Parameters.AddWithValue("@mauSac", mauSac);
                    //cmd.Parameters.AddWithValue("@kieuXe", kieuXe);
                    //cmd.Parameters.AddWithValue("@giaThanh", giaThanh);
                    cmd.ExecuteNonQuery();
                }
            }
            BindGridView();
        }

        protected void grvDanhSachXe_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy index của row được chọn
            int selectedRowIndex = grvDanhSachXe.SelectedIndex;

            //Kiem tra neu index hop le
            if (selectedRowIndex >= 0 && selectedRowIndex < grvDanhSachXe.Rows.Count)
            //if(selectedRowIndex >= 0)
            {
                //Lay du lieu tu row duoc chon
                GridViewRow selectedRow = grvDanhSachXe.Rows[selectedRowIndex];
                string maSo = selectedRow.Cells[1].Text;
                string tenXe = selectedRow.Cells[2].Text;
                string thuongHieu = selectedRow.Cells[3].Text;
                string mauSac = selectedRow.Cells[4].Text;
                string kieuXe = selectedRow.Cells[5].Text;
                string giaThanh = selectedRow.Cells[6].Text;
                string soGhe = selectedRow.Cells[8].Text;
                string luongTieuThu = selectedRow.Cells[8].Text;
                string namSanXuat = selectedRow.Cells[9].Text;
                string loaiNhienLieu = selectedRow.Cells[7].Text;


                //Hen thi thong tin vao cac textBox
                txtMaSo.Text = maSo;
                txtTen.Text = tenXe;
                txtThuongHieu.Text = thuongHieu;
                txtMauSac.Text = mauSac;
                txtKieuXe.Text = kieuXe;
                txtGia.Text = giaThanh;
                ddlSoGhe.Text = soGhe;
                txtNhienLieuTieuThu.Text = luongTieuThu;
                txtNamSX.Text = namSanXuat;
                ddlNhienLieu.Text = loaiNhienLieu;
            }
        }

        private void BindGridView()
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM car";
                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    grvDanhSachXe.DataSource = dataTable;
                    grvDanhSachXe.DataBind();
                }
            }
        }

        protected void BtnTaiAnh_Click(object sender, EventArgs e)
        {
            var file = Request.Files["inpFileAnh"];

            if (file != null && file.ContentLength > 0)
            {
                byte[] fileData;
                using (var binaryReader = new BinaryReader(file.InputStream))
                {
                    fileData = binaryReader.ReadBytes(file.ContentLength);
                }

                // Lưu mảng byte `fileData` vào cơ sở dữ liệu
            }
        }
    }
}