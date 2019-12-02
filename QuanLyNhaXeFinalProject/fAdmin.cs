using QuanLyNhaXeFinalProject.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaXeFinalProject
{
    public partial class fAdmin : Form
    {
        
        public fAdmin()
        {
            InitializeComponent();
            
        }

        private void FAdmin_Load(object sender, EventArgs e)
        {
            khoitao();
            loadTTNV();
            loadTTXE();
            loadTTLUONG();
            loadTTCHUYEN();
            getTotal();
        }

        private void loadTTNV()
        {
            string query = "SELECT MA_NV, TEN_NV, GIOI_TINH, CHUC_VU, NGAY_SINH, CMND, SDT, DIA_CHI, NGAY_VAO_LAM FROM NHAN_VIEN";
            dataGridView_showttNV.DataSource = dataProvider.Instance.ExecuteQuery(query);
        }

        private void loadTTXE()
        {
            string query = "SELECT a.*, b.GIO FROM XE a, GIO_CHAY b WHERE b.ID = a.ID_GIOKH";
            dataGridView_ttXE.DataSource = dataProvider.Instance.ExecuteQuery(query);
        }

        private void loadTTLUONG()
        {
            string query = "SELECT b.MA_NV, b.TEN_NV, b.GIOI_TINH, a.CHUC_VU, a.TIEN_LUONG FROM LUONG_COBAN a, NHAN_VIEN b WHERE a.CHUC_VU =b.CHUC_VU";
            dataGridView_TTLUONG.DataSource = dataProvider.Instance.ExecuteQuery(query);
        }

        private void loadTTCHUYEN()
        {
            string query = "SELECT a.ID, d.NAME, c.GIO, a.GIA_VE, b.SO_GHE, e.TEN_NV, b.BIEN_SO, a.ID_XE, a.MA_NV FROM LICH_TRINH a, XE b, GIO_CHAY c, TUYEN_XE d , NHAN_VIEN e WHERE b.ID = a.ID_XE AND a.MA_NV = e.MA_NV AND b.ID_GIOKH = c.ID AND c.ID_TUYEN_XE = d.ID";
            dataGridView_TTCHUYEN.DataSource = dataProvider.Instance.ExecuteQuery(query);
        }

        private void loadTTVE(string from, string end)
        {
            string query = String.Format("SELECT a.TEN_KH, a.SDT_KH, a.SO_TT_GHE, f.GIA_VE, c.GIO, a.NGAY_BAN, d.NAME, e.TEN_NV FROM TT_VE a, Xe b, GIO_CHAY c, TUYEN_XE d, NHAN_VIEN e, LICH_TRINH f WHERE a.ID_XE = b.ID AND b.ID_GIOKH = c.ID AND c.ID_TUYEN_XE = d.ID AND b.ID = f.ID_XE AND f.MA_NV = e.MA_NV AND NGAY_BAN BETWEEN '{0}' AND '{1}'", from, end);
            dataGridView_Doanhthu.DataSource = dataProvider.Instance.ExecuteQuery(query);
            getTotal();
        }


        private void khoitao()
        {
            cbb_timtheo_qlnv.Text = "(Select)";
            cbb_timtheo_qlnv.Items.Add("Tên Nhân Viên");
            cbb_timtheo_qlnv.Items.Add("SĐT Nhân Viên");
            cbb_timtheo_qlnv.Items.Add("Mã Nhân Viên");

            cbbGioitinh.Text = "(Select)";
            cbbGioitinh.Items.Add("Nam");
            cbbGioitinh.Items.Add("Nữ");

            cbbChucVu.Text = "(Select)";
            cbbChucVu.Items.Add("Quản Lý");
            cbbChucVu.Items.Add("NV Bán Vé");
            cbbChucVu.Items.Add("Tài Xế");

            cbb_timtheo_qlx.Text = "(Select)";
            cbb_timtheo_qlx.Items.Add("Mã Xe");
            cbb_timtheo_qlx.Items.Add("Biển Số Xe");

            cbb_timtheo_qlluong.Text = "(Select)";
            cbb_timtheo_qlluong.Items.Add("Chức Vụ");
            cbb_timtheo_qlluong.Items.Add("Tên Nhân Viên");
            loadDateTimePickerBill();

        }

        public void getTotal()
        {

            int tien = dataGridView_Doanhthu.Rows.Count;
            float thanhtien = 0;
            for (int i = 0; i < tien - 1; i++)
            {
                thanhtien += float.Parse(dataGridView_Doanhthu.Rows[i].Cells[3].Value.ToString());
            }
            //CultureInfo culture = new CultureInfo("vi-VN");
            //Thread.CurrentThread.CurrentCulture = culture;
            txb_totalPrice.Text = thanhtien.ToString("N");

        }


        private void loadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dateTimePicker_start.Value = new DateTime(today.Year, today.Month, 1);
            dateTimePicker_end.Value = dateTimePicker_start.Value.AddMonths(1).AddDays(-1);
            string from = dateTimePicker_start.Value.ToString();
            string end = dateTimePicker_end.Value.ToString();
            loadTTVE(from, end);


        }

        private void ComboBox_gioxuatben_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TxbNgayKH_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxbTenNV_TextChanged(object sender, EventArgs e)
        {

        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void DataGridView_showttNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataGridView_showttNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }


        private void CbbGioitinh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Cbb_timtheo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
        private void Button3_Click(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }


        private void DataGridView_ttXE_Click(object sender, EventArgs e)
        {
            
        }

        private void DataGridView_showttNV_Click(object sender, EventArgs e)
        {
            int numrow;
            numrow = dataGridView_showttNV.CurrentRow.Index;
            if (numrow >= 0)
            {
                txbMSNV.Text = dataGridView_showttNV.Rows[numrow].Cells[0].Value.ToString();
                txbTenNV.Text = dataGridView_showttNV.Rows[numrow].Cells[1].Value.ToString();
                cbbGioitinh.Text = dataGridView_showttNV.Rows[numrow].Cells[2].Value.ToString();
                cbbChucVu.Text = dataGridView_showttNV.Rows[numrow].Cells[3].Value.ToString();
                txbSDT.Text = dataGridView_showttNV.Rows[numrow].Cells[6].Value.ToString();
                txbCMND.Text = dataGridView_showttNV.Rows[numrow].Cells[5].Value.ToString();
                txbNgayVao.Text = dataGridView_showttNV.Rows[numrow].Cells[8].Value.ToString();
                txbNgaySInh.Text = dataGridView_showttNV.Rows[numrow].Cells[4].Value.ToString();
                txbDC.Text = dataGridView_showttNV.Rows[numrow].Cells[7].Value.ToString();
            }
            else
            {
                numrow = 1;
            }
        }

        private void Btn_qlnv_tim_Click(object sender, EventArgs e)
        {
            string text = txb_search.Text;
            if (cbb_timtheo_qlnv.Text == "Tên Nhân Viên")
            {
                string query = "EXECUTE SEARCH_NV_TEN @TEN_NV";
                dataGridView_showttNV.DataSource = dataProvider.Instance.ExecuteQuery(query, new object[] { text });
            }
            if (cbb_timtheo_qlnv.SelectedItem == "SĐT Nhân Viên")
            {
                string query = "EXECUTE SEARCH_NV_SDT @SDT";
                dataGridView_showttNV.DataSource = dataProvider.Instance.ExecuteQuery(query, new object[] { text });
            }
            if (cbb_timtheo_qlnv.Text == "Mã Nhân Viên")
            {
                string query = "EXECUTE SEARCH_NV_MANV @MA_NV";
                dataGridView_showttNV.DataSource = dataProvider.Instance.ExecuteQuery(query, new object[] { text });
            }
        }

        private void Btn_them_qlnv_Click(object sender, EventArgs e)
        {
            string id = txbMSNV.Text;
            string tennv = txbTenNV.Text;
            string ngaysinh = txbNgaySInh.Text;
            string gioitinh = cbbGioitinh.SelectedItem.ToString();
            string cmnd = txbCMND.Text;
            string diachi = txbDC.Text;
            string sdt = txbSDT.Text;
            string ngayvao = txbNgayVao.Text;
            string chucvu = cbbChucVu.Text;

            if (adminDAO.Instance.InsertNV(id, tennv, ngaysinh, gioitinh, cmnd, diachi, sdt, ngayvao, chucvu))
            {
                MessageBox.Show("Thêm nhân viên thành công");
                loadTTNV();
                loadTTLUONG();
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm nhân viên");
            }
        }

        private void Btn_xoa_qlnv_Click(object sender, EventArgs e)
        {
            string msnv = txbMSNV.Text;
            if (adminDAO.Instance.DeleteNV(msnv))
            {
                MessageBox.Show("Xóa nhân viên thành công");
                loadTTNV();
                loadTTLUONG();
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa nhân viên");
            }
        }

        private void Btn_sua_qlnv_Click(object sender, EventArgs e)
        {
            string msnv = txbMSNV.Text;
            string tennv = txbTenNV.Text;
            string ngaysinh = txbNgaySInh.Text;
            string gioitinh = cbbGioitinh.SelectedItem.ToString();
            string cmnd = txbCMND.Text;
            string diachi = txbDC.Text;
            string sdt = txbSDT.Text;
            string ngayvao = txbNgayVao.Text;
            string chucvu = cbbChucVu.Text;

            if (adminDAO.Instance.UpdateNV(tennv, ngaysinh, gioitinh, cmnd, diachi, sdt, ngayvao, chucvu, msnv))
            {
                MessageBox.Show("Sửa thông tin nhân viên thành công");
                loadTTNV();
                loadTTCHUYEN();
                loadTTLUONG();
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa thông tin nhân viên");
            }
        }

        private void Btn_qlnv_clear_Click(object sender, EventArgs e)
        {
            txbMSNV.Clear();
            txbTenNV.Clear();
            txbNgaySInh.Clear();
            cbbGioitinh.Text = "(Select)";
            txbCMND.Clear();
            txbDC.Clear();
            txbSDT.Clear();
            txbNgayVao.Clear();
            cbbChucVu.Text = "(Select)";
            loadTTNV();
        }


        private void DataGridView_ttXE_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            if (numrow >= 0)
            {
                txb_maXe_qlx.Text = dataGridView_ttXE.Rows[numrow].Cells[0].Value.ToString();
                txb_TENXE_qlx.Text = dataGridView_ttXE.Rows[numrow].Cells[2].Value.ToString();
                txb_soGhe_qlx.Text = dataGridView_ttXE.Rows[numrow].Cells[1].Value.ToString();
                txb_bienSo_qlx.Text = dataGridView_ttXE.Rows[numrow].Cells[3].Value.ToString();
                txb_ID_GIOKH_qlxe.Text = dataGridView_ttXE.Rows[numrow].Cells[4].Value.ToString();
                txb_GioKH_qlxe.Text = dataGridView_ttXE.Rows[numrow].Cells[5].Value.ToString();
            }
            else
            {
                numrow = 1;
            }
        }

        private void Btn_qlx_tim_Click(object sender, EventArgs e)
        {
            string text = txb_tim_qlx.Text;
            if (cbb_timtheo_qlx.Text == "Mã Xe")
            {
                string query = "EXECUTE SEARCH_XE_MAXE @MA_XE";
                dataGridView_ttXE.DataSource = dataProvider.Instance.ExecuteQuery(query, new object[] { text });
            }
            if (cbb_timtheo_qlx.SelectedItem == "Biển Số Xe")
            {
                string query = "EXECUTE SEARCH_XE_BIENSO @BIEN_SO";

                dataGridView_ttXE.DataSource = dataProvider.Instance.ExecuteQuery(query, new object[] { text });
            }
            

        }

        private void Btn_them_qlx_Click(object sender, EventArgs e)
        {
            string bienso = txb_bienSo_qlx.Text;
            string soghe = txb_soGhe_qlx.Text;
            string tenxe = txb_TENXE_qlx.Text;
            string idgiokh = txb_ID_GIOKH_qlxe.Text;
            if (adminDAO.Instance.InsertXE(bienso, soghe, tenxe, idgiokh))
            {
                MessageBox.Show("Thêm xe thành công");
                loadTTXE();
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm xe");
            }
        }

        private void Btn_xoa_qlx_Click(object sender, EventArgs e)
        {
            string maxe = txb_maXe_qlx.Text;
            if (adminDAO.Instance.DeleteXE(maxe))
            {
                MessageBox.Show("Xóa xe thành công");
                loadTTXE();
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa xe");
            }
        }

        private void Btn_sua_qlx_Click(object sender, EventArgs e)
        {
            string bienso = txb_bienSo_qlx.Text;
            string soghe = txb_soGhe_qlx.Text;
            string tenxe = txb_TENXE_qlx.Text;
            string maxe = txb_maXe_qlx.Text;
            string idgiokh = txb_ID_GIOKH_qlxe.Text;
            if (adminDAO.Instance.UpdateXE(bienso, soghe, tenxe, maxe, idgiokh))
            {
                MessageBox.Show("Sửa thông tin xe thành công");
                loadTTXE();
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa thông tin xe");
            }
        }

        private void Button2_qlx_clear_Click(object sender, EventArgs e)
        {
            txb_ID_GIOKH_qlxe.Clear();
            txb_GioKH_qlxe.Clear();
            txb_maXe_qlx.Clear();
            txb_bienSo_qlx.Clear();
            txb_soGhe_qlx.Clear();
            txb_TENXE_qlx.Clear();
            loadTTXE();
        }

       

        private void DataGridView_TTLUONG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            if (numrow >= 0)
            {
                txb_MaNV_qlluong.Text = dataGridView_TTLUONG.Rows[numrow].Cells[0].Value.ToString();
                txb_TenNV_qlluong.Text = dataGridView_TTLUONG.Rows[numrow].Cells[1].Value.ToString();
                txb_Gioitinh_qlluong.Text = dataGridView_TTLUONG.Rows[numrow].Cells[2].Value.ToString();
                txb_ChucVu_qlluong.Text = dataGridView_TTLUONG.Rows[numrow].Cells[3].Value.ToString();
                txb_luong_qlluong.Text = dataGridView_TTLUONG.Rows[numrow].Cells[4].Value.ToString();

            }
            else
            {
                numrow = 1;
            }
        }

        private void Btn_Tim_qlluong_Click(object sender, EventArgs e)
        {
            string text = txb_search_qlluong.Text;
            if (cbb_timtheo_qlluong.Text == "Chức Vụ")
            {
                string query = "EXECUTE SEARCH_LUONG_CHUCVU @CHUCVU";
                dataGridView_TTLUONG.DataSource = dataProvider.Instance.ExecuteQuery(query, new object[] { text });
            }
            if(cbb_timtheo_qlluong.Text == "Tên Nhân Viên")
            {
                string query = "EXECUTE SEARCH_LUONG_TENNV @TEN_NV";
                dataGridView_TTLUONG.DataSource = dataProvider.Instance.ExecuteQuery(query, new object[] { text });
            }
        }

        private void Btn_clear_qlluong_Click(object sender, EventArgs e)
        {
            txb_TenNV_qlluong.Clear();
            txb_ChucVu_qlluong.Clear();
            txb_Gioitinh_qlluong.Clear();
            txb_MaNV_qlluong.Clear();
            txb_luong_qlluong.Clear();
            loadTTLUONG();

        }

        private void Btn_sua_qlluong_Click(object sender, EventArgs e)
        {
            string tienluong = txb_luong_qlluong.Text;
            string chucvu = txb_ChucVu_qlluong.Text;
            if (adminDAO.Instance.UpdateLUONG(chucvu, tienluong))
            {
                MessageBox.Show("Sửa tiền lương thành công");
                loadTTLUONG();
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa tiền lương xe");
            }
        }

        private void DataGridView_TTCHUYEN_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataGridView_TTCHUYEN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            if (numrow >= 0)
            {
                txbMaCHUYEN_qlchuyen.Text = dataGridView_TTCHUYEN.Rows[numrow].Cells[0].Value.ToString();
                txbTuyen_qlchuyen.Text = dataGridView_TTCHUYEN.Rows[numrow].Cells[1].Value.ToString();
                txb_GioXB_qlchuyen.Text = dataGridView_TTCHUYEN.Rows[numrow].Cells[2].Value.ToString();
                txb_giave_qlchuyen.Text = dataGridView_TTCHUYEN.Rows[numrow].Cells[3].Value.ToString();
                txb_slghe_qlchuyen.Text = dataGridView_TTCHUYEN.Rows[numrow].Cells[4].Value.ToString();
                txb_tentx_qlchuyen.Text = dataGridView_TTCHUYEN.Rows[numrow].Cells[5].Value.ToString();
                txb_bienso_qlchuyen.Text = dataGridView_TTCHUYEN.Rows[numrow].Cells[6].Value.ToString();
                txb_maxe_qlchuyen.Text = dataGridView_TTCHUYEN.Rows[numrow].Cells[7].Value.ToString();
                txb_maNV_qlchuyen.Text = dataGridView_TTCHUYEN.Rows[numrow].Cells[8].Value.ToString();
            }
            else
            {
                numrow = 1;
            }
        }

        private void TextBox9_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Btn_thongke_Click(object sender, EventArgs e)
        {
            string from = dateTimePicker_start.Value.ToString();
            string end = dateTimePicker_end.Value.ToString();
            loadTTVE(from, end);
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txbMaCHUYEN_qlchuyen.Clear();
            txbTuyen_qlchuyen.Clear();
            txb_GioXB_qlchuyen.Clear();
            txb_giave_qlchuyen.Clear();
            txb_slghe_qlchuyen.Clear();
            txb_tentx_qlchuyen.Clear();
            txb_bienso_qlchuyen.Clear();
            txb_maxe_qlchuyen.Clear();
            txb_maNV_qlchuyen.Clear();


        }

        private void Btn_xoa_qlchuyen_Click(object sender, EventArgs e)
        {
            string machuyen = txbMaCHUYEN_qlchuyen.Text;
            if (adminDAO.Instance.DeleteCHUYEN(machuyen))
            {
                MessageBox.Show("Xóa chuyến xe thành công");
                loadTTCHUYEN();
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa chuyến xe");
            }
        }

        private void Btn_sua_qlchuyen_Click(object sender, EventArgs e)
        {
            
        }

        private void Btn_them_qlchuyen_Click(object sender, EventArgs e)
        {
            
        }

        private void DataGridView_TTLUONG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TxbMSNV_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
