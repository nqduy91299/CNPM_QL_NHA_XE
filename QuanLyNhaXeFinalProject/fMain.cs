using QuanLyNhaXeFinalProject.DAO;
using QuanLyNhaXeFinalProject.TDO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaXeFinalProject
{
    public partial class fMain : Form
    {

        public fMain()
        {
            InitializeComponent();
            loadCHUYEN_XE();
            loadTT_VE();
        }

        private void QuanToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void AdminToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Txb_sdtKH_TextChanged(object sender, EventArgs e)
        {

        }

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ĐăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn đăng xuất?", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                this.Close();
            }

        }

        private void ADMINToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            fAdmin fadmin = new fAdmin();
            fadmin.ShowDialog();
        }

        private void khoitao()
        {
            label_TENNV.Text = "Nhân Viên";
        }

        private void FMain_Load(object sender, EventArgs e)
        {
            khoitao();
        }

        void loadCHUYEN_XE()
        {
            List<Route> listRoutes = routeDAO.Instance.GetListRoute();
            cbb_tuyenxe_banve.DataSource = listRoutes;
            cbb_tuyenxe_banve.DisplayMember = "NAME";
        }

        void loadGIO_KH(int id)
        {
            List<gioKH> listGioKH = gioKHDAO.Instance.GetListGioKH(id);
            cbb_gioXH_banve.DataSource = listGioKH;
            cbb_gioXH_banve.DisplayMember = "GIO";
        }

        void loadCar(int id)
        {
            List<car> listCar = carDAO.Instance.GetListCar(id);
            cbb_soXe_banve.DataSource = listCar;
            cbb_soXe_banve.DisplayMember = "BienSo";
            txb_idxe.Text = carDAO.Instance.Getidxe(id).ToString();
            txb_price.Text = lichtrinhDAO.Instance.GetCast(id).ToString("N");
        }

        void loadSoghe(int id)
        {
            int t = carDAO.Instance.GetGhe(id);
            List<int> list = new List<int>();

            for (int i =1; i<=t; i++)
            {
                list.Add(i);
            }
            cbb_ghe_banve.DataSource = list;
        }
        
        void loadTT_VE()
        {
            string query = "SELECT ID, TEN_KH, SDT_KH, SO_TT_GHE, CHUYEN, GIO FROM TT_VE";
            dataGridView_timkiemve.DataSource = dataProvider.Instance.ExecuteQuery(query);
        }

        

        private void ComboBox_tuyenxe_banve_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if(cb.SelectedItem == null)
            {
                return;
            }
            Route selected = cb.SelectedItem as Route;
            id = selected.ID;
            loadGIO_KH(id);
        }

        private void Cbb_gioXH_banve_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
            {
                return;
            }
            gioKH selected = cb.SelectedItem as gioKH;
            if(selected == null)
            {
                return;
            }
            id = selected.ID;
            loadCar(id);
        }

        private void Cbb_soXe_banve_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
            {
                return;
            }
            car selected = cb.SelectedItem as car;
            if (selected == null)
            {
                return;
            }
            id = selected.ID;
            loadSoghe(id);
            }

        private void Btn_ban_Click(object sender, EventArgs e)
        {
            string tuyen = cbb_tuyenxe_banve.Text;
            string gio = cbb_gioXH_banve.Text;
            string bienso = cbb_soXe_banve.Text;
            string idxe = txb_idxe.Text;
            string tenkh = txb_tenKH_banve.Text;
            string sdt = txb_sdtKH_banve.Text;
            string ghe = cbb_ghe_banve.Text;

            if(txb_sdtKH_banve.Text.Length != 0 || txb_tenKH_banve.Text.Length != 0)
            {
                if (MainDAO.Instance.InsertBill(tenkh, sdt, ghe, tuyen, gio, bienso, idxe))
                {
                    MessageBox.Show("Bán vé thành công");
                    loadTT_VE();
                }
                else
                {
                    MessageBox.Show("Có lỗi khi bán vé");
                }
            }
            else
            {
                MessageBox.Show("Tên hoặc SĐT bị trống!");
            }


            

        }

        private void btn_im_banve_CLICK(object sender, EventArgs e)
        {
            string text = txb_tim_sdtKH.Text;
            string query = "EXECUTE SEARCH_SDT_KH @SDT";
            dataGridView_timkiemve.DataSource = dataProvider.Instance.ExecuteQuery(query, new object[] { text });
        }

        private void Btn_xoa_banve_Click(object sender, EventArgs e)
        {
            string idve = txb_ID_veban.Text;
            if (MainDAO.Instance.DeleteVE(idve))
            {
                MessageBox.Show("Xóa vé thành công");
                loadTT_VE();
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa vé");
            }
            
        }

        private void DataGridView_timkiemve_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            if (numrow >= 0)
            {
                txb_ID_veban.Text = dataGridView_timkiemve.Rows[numrow].Cells[0].Value.ToString();

            }
            else
            {
                numrow = 1;
            }
        }
    }
}
