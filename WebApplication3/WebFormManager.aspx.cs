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
        //string connString = @"Data Source=SONDINH\SQLEXPRESS;Initial Catalog=QLOTo;Integrated Security=True";
        private string connString = @"Data Source=MSIHOANG;Initial Catalog=CarStore;Integrated Security=True";
        //private SqlConnection myConn;
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
            string soGhe = txtSoGhe.Text;
            string mucTieuThu = txtMucTieuThu.Text;
            string namSanXuat = txtNamSX.Text;
            string loaiNhienLieu = txtLoaiNhienLieu.Text;

            //var file = Request.Files["inpFileAnh"];
            /*
            HttpPostedFile file = Request.Files["inpFileAnh"];
            byte[] fileData = null;
            if (file != null && file.ContentLength > 0)
            {
                using (BinaryReader reader = new BinaryReader(file.InputStream))
                {
                    fileData = reader.ReadBytes(file.ContentLength);
                }
            }
            */


            //Them du lieu vao CSDL
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                string insertQuery = "INSERT INTO car (id, name, company, color, carclass, price, seat, fuel, year, description) " +
                    "VALUES (@maSo, @tenXe, @thuongHieu, N@mauSac, @kieuXe, @giaThanh, @soGhe, @mucTieuThu, @namSanXuat, @loaiNhienLieu)";
                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@maSo", maSo);
                    cmd.Parameters.AddWithValue("@tenXe", tenXe);
                    cmd.Parameters.AddWithValue("@thuongHieu", thuongHieu);
                    cmd.Parameters.AddWithValue("@mauSac", mauSac);
                    cmd.Parameters.AddWithValue("@kieuXe", kieuXe);
                    cmd.Parameters.AddWithValue("@giaThanh", giaThanh);
                    cmd.Parameters.AddWithValue("@soGhe", soGhe);
                    cmd.Parameters.AddWithValue("@mucTieuThu", mucTieuThu);
                    cmd.Parameters.AddWithValue("@namSanXuat", namSanXuat);
                    cmd.Parameters.AddWithValue("@loaiNhienLieu", loaiNhienLieu);

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
            int soGhe = int.Parse(txtSoGhe.Text);
            string mucTieuThu = txtMucTieuThu.Text;
            int namSanXuat = int.Parse(txtNamSX.Text);
            string loaiNhienLieu = txtLoaiNhienLieu.Text;

            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                string updateQuery = "Update car SET name = @tenXe, company = @thuongHieu, color = @mauSac, carclass = @kieuXe, price = @giaThanh, seat = @soGhe, fuel = @mucTieuThu, year = @namSanXuat,  description = @loaiNhienLieu WHERE id = @maSo";
                using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@maSo", maSo);
                    cmd.Parameters.AddWithValue("@tenXe", tenXe);
                    cmd.Parameters.AddWithValue("@thuongHieu", thuongHieu);
                    cmd.Parameters.AddWithValue("@mauSac", mauSac);
                    cmd.Parameters.AddWithValue("@kieuXe", kieuXe);
                    cmd.Parameters.AddWithValue("@giaThanh", giaThanh);
                    cmd.Parameters.AddWithValue("@soGhe", soGhe);
                    cmd.Parameters.AddWithValue("@mucTieuThu", mucTieuThu);
                    cmd.Parameters.AddWithValue("@namSanXuat", namSanXuat);
                    cmd.Parameters.AddWithValue("@loaiNhienLieu", loaiNhienLieu);


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
                string deleteQuery = "DELETE FROM car WHERE id = @maSo";
                using (SqlCommand cmd = new SqlCommand(deleteQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@maSo", maSo);
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
                string soGhe = selectedRow.Cells[7].Text;
                string mucTieuThu = selectedRow.Cells[8].Text;
                string namSanXuat = selectedRow.Cells[9].Text;
                string loaiNhienLieu = selectedRow.Cells[10].Text;

                //Hen thi thong tin vao cac textBox
                txtMaSo.Text = maSo;
                txtTen.Text = tenXe;
                txtThuongHieu.Text = thuongHieu;
                txtMauSac.Text = mauSac;
                txtKieuXe.Text = kieuXe;
                txtGia.Text = giaThanh;
                txtSoGhe.Text = soGhe;
                txtMucTieuThu.Text = mucTieuThu;
                txtNamSX.Text = namSanXuat;
                txtLoaiNhienLieu.Text = loaiNhienLieu;
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
    }
}