using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DangNhap
{
    public partial class Form1 : Form
    {
        QL_NguoiDung cauhinh = new QL_NguoiDung();
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
           if (string.IsNullOrEmpty(txtUsername.Text.Trim()))
            {
                MessageBox.Show("Bạn Chưa Nhập Tên Đăng Nhập");
                txtUsername.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                MessageBox.Show("Bạn Chưa Nhập Mật Khẩu");
                txtPassword.Focus();
                return;
            }
            int kq = cauhinh.check_Config();
            if (kq == 0)
            {
                ProccesLogin();
            }
            if (kq == 1)
            {
                MessageBox.Show("Chuỗi cấu hình không tồn tại");
            }
        }

        private void ProccesLogin()
        {
            int kq = cauhinh.check_user (txtUsername.Text, txtPassword.Text);
            if (kq == -1)
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");
                return;
            }
            if (kq == 0)
            {
                MessageBox.Show("Tài khoản bị khóa");
                return;
            }
            if (Program.main == null || Program.main.IsDisposed)
            {
                Program.main = new frmmaMain();
            }
            this.Visible = false;
            Program.main.Show();
        }
    }
}
