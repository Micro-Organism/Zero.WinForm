using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Zero.WinFormCtrlLib
{
    public partial class UcProgressForm : UcBase
    {
        private const string LineBreak = "\r\n";
        public static string CACHE_FILE_PATH = @"D:\\TEMP";//GlobalParameters.SoftwareAppDataRoamingDirectoryPath + @"\CacheFiles";

        /// <summary>
        /// 声明一个更新主线程的委托
        /// </summary>
        /// <param name="step"></param>
        public delegate void UpdateUI(int step);
        public UpdateUI UpdateUIDelegate;

        /// <summary>
        /// 声明一个在完成任务时通知主线程的委托
        /// </summary>
        public delegate void AccomplishTask();
        public AccomplishTask TaskCallBack;

        /// <summary>
        /// 首先要建立一个委托来实现非创建控件的线程更新控件。 
        /// </summary>
        /// <param name="step"></param>
        public delegate void AsynUpdateUI(int step);

        public UcProgressForm()
        {
            InitializeComponent();
        }

        #region 基本事件

        /// <summary>
        /// 系统环境的测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            int taskCount = 100; //任务量为10000
            this.progressBar.Maximum = taskCount;
            this.progressBar.Value = 0;

            this.UpdateUIDelegate += UpdataUIStatus;//绑定更新任务状态的委托
            this.TaskCallBack += Accomplish;//绑定完成任务要调用的委托

            Thread thread = new Thread(new ParameterizedThreadStart(this.Write));
            thread.IsBackground = true;
            thread.Start(taskCount);
        }

        /// <summary>
        /// 系统路径的测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfig_Click(object sender, EventArgs e)
        {
            this.richTextBox2.Text = string.Empty;
            this.richTextBox2.Text = GetPEArchitecture("C:\\Windows\\System32\\mfc120.dll").ToString();
        }

        /// <summary>
        /// Npoi的测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNpoi_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region 基本方法
        /// <summary>
        /// 写入
        /// </summary>
        /// <param name="lineCount"></param>
        public void Write(object lineCount)
        {
            //获取执行时间
            var sleepTotalTime = this.GetSleepTime();

            //睡眠一次的时间
            var sleepOnceTime = Convert.ToInt32(sleepTotalTime / (int)lineCount); //ms

            for (int i = 0; i < (int)lineCount; i++)
            {
                Thread.Sleep(sleepOnceTime);

                //写入一条数据，调用更新主线程ui状态的委托
                UpdateUIDelegate(1);
            }

            //任务完成时通知主线程作出相应的处理
            TaskCallBack();
        }

        private double GetSleepTime()
        {
            //获取文件路径
            var filePath = Path.Combine(CACHE_FILE_PATH, "demo.sql");

            System.IO.FileInfo fileInfo  = new System.IO.FileInfo(filePath);
            //文件大小
            var fileLength = System.Math.Ceiling(fileInfo.Length / 1024.0); //KB

            //总共睡眠时间
            var time = System.Math.Ceiling(fileLength / 20); //ms

            return time;
        }

        /// <summary>
        /// 更新UI
        /// </summary>
        /// <param name="step"></param>
        private void UpdataUIStatus(int step)
        {
            if (InvokeRequired)
            {
                this.Invoke(new AsynUpdateUI(delegate (int _step)
                {
                    this.progressBar.Value += _step;
                    this.labProgress.Text = this.progressBar.Value.ToString() + "/" + this.progressBar.Maximum.ToString();
                }), step);
            }
            else
            {
                this.progressBar.Value += step;
                this.labProgress.Text = this.progressBar.Value.ToString() + "/" + this.progressBar.Maximum.ToString();
            }
        }

        /// <summary>
        /// 完成任务时需要调用
        /// </summary>
        private void Accomplish()
        {
            //还可以进行其他的一些完任务完成之后的逻辑处理
            MessageBox.Show("任务完成");
        }

        /// <summary>
        /// 判断类型
        /// </summary>
        /// <param name="pFilePath"></param>
        /// <returns></returns>
        public ushort GetPEArchitecture(string pFilePath)
        {
            ushort architecture = 0;
            try
            {
                using (System.IO.FileStream fStream = new System.IO.FileStream(pFilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    using (System.IO.BinaryReader bReader = new System.IO.BinaryReader(fStream))
                    {
                        if (bReader.ReadUInt16() == 23117) //check the MZ signature
                        {
                            fStream.Seek(0x3A, System.IO.SeekOrigin.Current); //seek to e_lfanew.
                            fStream.Seek(bReader.ReadUInt32(), System.IO.SeekOrigin.Begin); //seek to the start of the NT header.
                            if (bReader.ReadUInt32() == 17744) //check the PE\0\0 signature.
                            {
                                fStream.Seek(20, System.IO.SeekOrigin.Current); //seek past the file header,
                                architecture = bReader.ReadUInt16(); //read the magic number of the optional header.
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {

            }
            return architecture;
        }
        #endregion

    }
}
