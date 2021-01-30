using System;
using System.Windows.Forms;
using Zero.FrameworkLib.OSHelpers;
using Zero.FrameworkLib.ProcessHelper;

namespace Zero.WinFormCtrlLib
{
    public partial class UcDosForm : UcBase
    {
        private const string LineBreak = "\r\n";
        public static string CACHE_FILE_PATH = @"D:\\TEMP";//GlobalParameters.SoftwareAppDataRoamingDirectoryPath + @"\CacheFiles";

        public UcDosForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 系统环境的测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            //string cmd = this.txbDos.Text.Trim();//"status"
            //string errorStr = string.Empty;
            //ProcessHelper.ExecuteCmd(cmd, out errorStr);

            this.rtbMsg.Text = string.Empty;
            try
            {
                var responses = RegisterHelper.Instance.InstallComponentList("Microsoft Visual C++ 2013 x64");
                foreach (var item in responses)
                {
                    this.rtbMsg.Text += item + "\r\n";
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }

        }

        /// <summary>
        /// 系统路径的测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfig_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Npoi的测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNpoi_Click(object sender, EventArgs e)
        {

        }
    }
}
