using QuanLyNhaXeFinalProject.DAO;
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
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Bạn muốn thoát khỏi chương trình này?", "Thông Báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string userName = txbUsername.Text;
            string passWord = txbPassword.Text;
            if (login(userName, passWord))
            {
                fMain fmain = new fMain();
                this.Hide();
                fmain.ShowDialog();
                this.Show();
            }
            else
            {
              MessageBox.Show("Tài khoản hoặc mật khẩu không đúng! Vui lòng thử lại..");
            }
        }

        bool login(string userName, string passWord)
        {
            return AccountDAO.Instance.loginadmin(userName, passWord);
        }

        private void FLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
