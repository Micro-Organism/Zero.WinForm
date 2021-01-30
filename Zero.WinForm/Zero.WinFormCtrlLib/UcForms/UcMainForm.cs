using System;
using System.Data;
using System.Linq;
using System.Management;
using System.Windows.Forms;
using Zero.FrameworkLib.OSHelpers;
using Zero.NPOILib;

namespace Zero.WinFormCtrlLib
{
    public partial class UcMainForm : UcBase
    {
        private const string LineBreak = "\r\n";
        public static string CACHE_FILE_PATH = @"D:\\TEMP";//GlobalParameters.SoftwareAppDataRoamingDirectoryPath + @"\CacheFiles";

        //C#判断操作系统是否为Unix
        public static bool IsUnix
        {
            get
            {
                return Environment.OSVersion.Platform == PlatformID.Unix;
            }
        }

        public UcMainForm()
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
            System.Drawing.Rectangle rec = Screen.GetWorkingArea(this);

            //int SH1 = rec.Height();
            //int SW1 = rec.Width();

            int SH2 = Screen.PrimaryScreen.Bounds.Height;
            int SW2 = Screen.PrimaryScreen.Bounds.Width;

            string aaa = string.Format("SH2={0}, SW2={1}; ", SH2, SW2);

            //double workWidth = SystemParameters.WorkArea.Width; // 屏幕工作区域宽度
            //double workHeight = SystemParameters.WorkArea.Height; // 屏幕工作区域高度
            //double screenWidth = SystemParameters.PrimaryScreenWidth; // 屏幕整体宽度
            //double screenHeight = SystemParameters.PrimaryScreenHeight; // 屏幕整体高度

            //string bbb = string.Format("workWidth={0}, workHeight={1}, screenWidth={2}, screenHeight={3}; ", workWidth, workHeight, screenWidth, screenHeight);

            //this.Width = (int)(workWidth * 0.8 + 0.5); // 设置窗体宽度
            //this.Height = (int)(workHeight * 0.8 + 0.5); // 设置窗体高度

            //Window mainWindow = new Window();
            //Graphics currentGraphics = Graphics.FromHwnd(new WindowInteropHelper(mainWindow).Handle);
            //double dpixRatio = currentGraphics.DpiX / 96;
            //string ccc = string.Format("dpixRatio={0}; ", dpixRatio);

            string ddd = string.Empty;
            using (ManagementClass mc = new ManagementClass("Win32_DesktopMonitor"))
            {
                using (ManagementObjectCollection moc = mc.GetInstances())
                {

                    int PixelsPerXLogicalInch = 0; // dpi for x
                    int PixelsPerYLogicalInch = 0; // dpi for y

                    foreach (ManagementObject each in moc)
                    {
                        PixelsPerXLogicalInch = int.Parse((each.Properties["PixelsPerXLogicalInch"].Value.ToString()));
                        PixelsPerYLogicalInch = int.Parse((each.Properties["PixelsPerYLogicalInch"].Value.ToString()));
                    }

                    ddd = string.Format("PixelsPerXLogicalInch={0}, PixelsPerYLogicalInch={1}; ", PixelsPerXLogicalInch, PixelsPerYLogicalInch);
                }
            }

            //string eee = string.Format("DESKTOP={0}, DpiX={1}, DpiY={2}, ScaleX={3}, ScaleY={4}, WorkingArea={5}; ",
            //    PrimaryScreen.DESKTOP, PrimaryScreen.DpiX, PrimaryScreen.DpiY,
            //    PrimaryScreen.ScaleX, PrimaryScreen.ScaleY, PrimaryScreen.WorkingArea);

            string fff = PrimaryScreen.get_OSVersion();

            string ggg = string.Format(@"当前操作系统: " + PrimaryScreen.GetOSName() +
                LineBreak + "当前操作系统的版本：" + Environment.OSVersion.VersionString +
                LineBreak + "机器名：" + Environment.MachineName +
                LineBreak + "当前已登录到 Windows 操作系统的人员的用户名：" + Environment.UserName +
                LineBreak + "当前计算机上的处理器数：" + Environment.ProcessorCount +
                LineBreak + "当前操作系统是否为 64 位操作系统？   答：" + (Environment.Is64BitOperatingSystem ? "是" : "否") +
                LineBreak + "当前进程是否为 64 位进程？   答：" + (Environment.Is64BitProcess ? "是" : "否 "));

            var name = (from x in new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem").Get().Cast<ManagementObject>()
                        select x.GetPropertyValue("Caption")).FirstOrDefault();
            string hhh = name != null ? name.ToString() : "Unknown";

            string strQuery = "select *from win32_OperatingSystem";
            SelectQuery queryOS = new SelectQuery(strQuery);
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(queryOS);
            string mmm = string.Empty;
            foreach (var os in searcher.Get())
            {
                mmm = string.Format(@"操作系统版本号：" + os["Version"] +
                LineBreak + "操作系统标题：" + os["Caption"] +
                LineBreak + "操作系统序列号：" + os["SerialNumber"] +
                LineBreak + "操作系统路径：" + os["SystemDirectory"]);
            }

            //var yyy = GetVersion();

            //var lll = GetDpiForWindow();
            //var kkk = SetProcessDpiAwareness();
            //var nnn = SetThreadDpiAwarenessContext();
            //var ppp = GetVersionEx();

            this.richTextBox1.Text = aaa + LineBreak + fff + LineBreak + ggg + LineBreak + hhh + LineBreak + mmm;

        }

        /// <summary>
        /// 系统路径的测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfig_Click(object sender, EventArgs e)
        {
            var aaa = string.Format("Environment.SpecialFolder.ApplicationData : {0}", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            var bbb = string.Format("Environment.SpecialFolder.CommonApplicationData : {0}", Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));
            var ccc = string.Format("Environment.SpecialFolder.LocalApplicationData : {0}", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            var ddd = string.Format("Environment.SpecialFolder.Desktop : {0}", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            var eee = string.Format("Environment.SpecialFolder.MyDocuments : {0}", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
            var fff = string.Format("Environment.SpecialFolder.MyMusic : {0}", Environment.GetFolderPath(Environment.SpecialFolder.MyMusic));
            var ggg = string.Format("Environment.SpecialFolder.MyPictures : {0}", Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
            var hhh = string.Format("Environment.SpecialFolder.MyVideos : {0}", Environment.GetFolderPath(Environment.SpecialFolder.MyVideos));
            var iii = string.Format("Environment.SpecialFolder.ProgramFiles : {0}", Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles));
            var jjj = string.Format("Environment.SpecialFolder.ProgramFilesX86 : {0}", Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86));
            var kkk = string.Format("Environment.SpecialFolder.AdminTools : {0}", Environment.GetFolderPath(Environment.SpecialFolder.AdminTools));
            var lll = string.Format("Environment.SpecialFolder.CommonDesktopDirectory : {0}", Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory));
            this.richTextBox2.Text = aaa + LineBreak + bbb + LineBreak + ccc + LineBreak + ddd + LineBreak + eee + LineBreak + 
                fff + LineBreak + ggg + LineBreak + hhh + LineBreak + iii + LineBreak + jjj + LineBreak + kkk + LineBreak + lll;
        }

        /// <summary>
        /// Npoi的测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNpoi_Click(object sender, EventArgs e)
        {
            try
            {
                this.richTextBox3.Text += LineBreak + " 开始.....";
                var file_name = string.Format(@"{0}\\{1}", CACHE_FILE_PATH, "Demo.xls");
                NpoiHelper.CreateExcel(file_name, "Demo");
                this.richTextBox3.Text += LineBreak + string.Format("创建 {0} 成功！", file_name);
            }
            catch (Exception exc)
            {
                this.richTextBox3.Text += LineBreak + exc.Message;
            }
            finally
            {
                this.richTextBox3.Text += LineBreak + " 结束.....";
            }

        }
    }
}
