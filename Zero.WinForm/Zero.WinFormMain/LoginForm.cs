using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Zero.WinFormMain
{
    public partial class LoginForm : BaseForm
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.LoginUser();
        }

        private void btnLogin_KeyDown(object sender, KeyEventArgs e)
        {
            //if条件检测按下的是不是Enter键
            if (e.KeyCode == Keys.Enter)
            {
                this.LoginUser();
            }
        }

        private void LoginUser()
        {
            if (this.txtLoginName.Text.Equals("admin"))
            {
                if (this.txtPassword.Text.Equals("admin"))
                {
                    this.Hide();
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                    return;
                }
                MessageBox.Show("密码错误");
            }
            MessageBox.Show("用户名错误");
        }
    }
}
