using System;

namespace Zero.WinFormCtrlLib
{
    public partial class UcMessageBox : UcBase
    {
        UcMessageBox ucMessageBox;

        public UcMessageBox()
        {
            InitializeComponent();
            ucMessageBox = new UcMessageBox();
        }

        /// <summary>
        /// 关闭界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            ucMessageBox.Dispose();
        }

    }
}
