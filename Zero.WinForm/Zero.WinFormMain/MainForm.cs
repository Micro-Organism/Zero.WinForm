using System;
using System.Windows.Forms;
using Zero.WinFormCtrlLib;

namespace Zero.WinFormMain
{
    public partial class MainForm : Form
    {
        #region 字段属性

        /// <summary>
        /// 主界面
        /// </summary>
        UcMainForm ucMainForm;
        /// <summary>
        /// DOS命令
        /// </summary>
        UcDosForm ucDosForm;
        /// <summary>
        /// 进程界面
        /// </summary>
        UcProgressForm ucProgressForm;
        /// <summary>
        /// RibbonForm
        /// </summary>
        UcRibbon ribbonForm;
        /// <summary>
        /// 多线程
        /// </summary>
        UcMultiThreadForm ucMultiThreadForm;
        #endregion

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            this.InitializeForm();
        }
        #endregion

        #region 基本事件

        /// <summary>
        /// 进程工具
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProgressToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            this.panelMain.Controls.Clear();
            ucProgressForm = new UcProgressForm();
            ucProgressForm.Dock = DockStyle.Fill;
            this.panelMain.Controls.Add(ucProgressForm);
            this.panelMain.Refresh();
        }

        /// <summary>
        /// ribbonForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ribbonFormRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panelMain.Controls.Clear();
            ribbonForm = new UcRibbon();
            ribbonForm.Dock = DockStyle.Fill;
            this.panelMain.Controls.Add(ribbonForm);
            this.panelMain.Refresh();
        }

        /// <summary>
        /// DOS命令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dosFormDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panelMain.Controls.Clear();
            ucDosForm = new UcDosForm();
            ucDosForm.Dock = DockStyle.Fill;
            this.panelMain.Controls.Add(ucDosForm);
            this.panelMain.Refresh();
        }

        /// <summary>
        /// 多线程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void multiThreadTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panelMain.Controls.Clear();
            ucMultiThreadForm = new UcMultiThreadForm();
            ucMultiThreadForm.Dock = DockStyle.Fill;
            this.panelMain.Controls.Add(ucMultiThreadForm);
            this.panelMain.Refresh();
        }
        #endregion

        #region 基本方法

        /// <summary>
        /// 初始化
        /// </summary>
        public void InitializeForm()
        {
            this.panelMain.Controls.Clear();
            ucMainForm = new UcMainForm();
            ucMainForm.Dock = DockStyle.Fill;
            this.panelMain.Controls.Add(ucMainForm);
            this.panelMain.Refresh();
        }

        #endregion
    }
}
