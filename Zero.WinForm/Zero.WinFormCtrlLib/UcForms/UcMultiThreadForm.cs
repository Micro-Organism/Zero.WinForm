﻿using System;
using System.Windows.Forms;

namespace Zero.WinFormCtrlLib
{
    public partial class UcMultiThreadForm : UcBase
    {
        private const string LineBreak = "\r\n";
        public static string CACHE_FILE_PATH = @"D:\\TEMP";//GlobalParameters.SoftwareAppDataRoamingDirectoryPath + @"\CacheFiles";

        public UcMultiThreadForm()
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
            this.rtbMsg.Text = string.Empty;
            try
            {

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
