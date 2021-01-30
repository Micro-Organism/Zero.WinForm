using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zero.WinFormCtrlLib
{
    public class ZeroInputBox : Form
    {
        private TextBox txtData;

        private Label lblInfo;

        private System.ComponentModel.Container components = null;

        private ZeroInputBox()

        {

            InitializeComponent();

        }

        protected override void Dispose(bool disposing)

        {

            if (disposing)

            {

                if (components != null)

                {

                    components.Dispose();

                }

            }

            base.Dispose(disposing);

        }

        private void InitializeComponent()

        {

            this.txtData = new TextBox();

            this.lblInfo = new Label();

            this.SuspendLayout();

            //

            // txtData

            //

            this.txtData.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));

            this.txtData.Location = new System.Drawing.Point(19, 8);

            this.txtData.Name = "txtData";

            this.txtData.Size = new System.Drawing.Size(317, 23);

            this.txtData.TabIndex = 0;

            this.txtData.Text = "";

            this.txtData.KeyDown += new KeyEventHandler(this.txtData_KeyDown);

            //

            // lblInfo

            //

            this.lblInfo.BackColor = System.Drawing.SystemColors.Info;

            this.lblInfo.BorderStyle = BorderStyle.Fixed3D;

            this.lblInfo.FlatStyle = FlatStyle.System;

            this.lblInfo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));

            this.lblInfo.ForeColor = System.Drawing.Color.Gray;

            this.lblInfo.Location = new System.Drawing.Point(19, 32);

            this.lblInfo.Name = "lblInfo";

            this.lblInfo.Size = new System.Drawing.Size(317, 16);

            this.lblInfo.TabIndex = 1;

            this.lblInfo.Text = "[Enter]确认 | [Esc]取消";

            //

            // InputBox

            //

            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);

            this.ClientSize = new System.Drawing.Size(350, 48);

            this.ControlBox = false;

            this.Controls.Add(this.lblInfo);

            this.Controls.Add(this.txtData);

            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            this.Name = "InputBox";

            this.Text = "InputBox";

            this.ResumeLayout(false);



        }

        //对键盘进行响应

        private void txtData_KeyDown(object sender, KeyEventArgs e)

        {

            if (e.KeyCode == Keys.Enter)

            {

                this.Close();

            }

            else if (e.KeyCode == Keys.Escape)

            {

                txtData.Text = string.Empty;

                this.Close();

            }

        }

        //显示InputBox

        public static string ShowInputBox(string Title, string keyInfo)

        {

            ZeroInputBox inputbox = new ZeroInputBox();

            inputbox.Text = Title;

            if (keyInfo.Trim() != string.Empty)

                inputbox.lblInfo.Text = keyInfo;

            inputbox.ShowDialog();

            return inputbox.txtData.Text;

        }

        private void button_Click(object sender, System.EventArgs e)
        {
            // Microsoft. VisualBasic.Interaction.InputBox(  "type  your  name  ",  "input  ","",0,0);

            //可以将你要显示的文本信息代替下面的string.Empty。

            string inMsg = ZeroInputBox.ShowInputBox("输入信息", string.Empty);

            //对用户的输入信息进行检查

            if (inMsg.Trim() != string.Empty)
            {
                MessageBox.Show(inMsg);

            }
            else
            {
            MessageBox.Show("输入为string.Empty");
            }
        }
    }
}
