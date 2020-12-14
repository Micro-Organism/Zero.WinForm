using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.Runtime.InteropServices;

namespace Zero.FrameworkLib.OSHelpers
{
    public class PrimaryScreen
    {
        #region Win32 API
        [DllImport("user32.dll")]
        static extern IntPtr GetDC(IntPtr ptr);

        /// <summary>
        /// GetDeviceCaps
        /// </summary>
        /// <param name="hdc">handle to DC</param>
        /// <param name="nIndex">index of capability</param>
        /// <returns></returns>
        [DllImport("gdi32.dll")]
        static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

        [DllImport("user32.dll", EntryPoint = "ReleaseDC")]
        static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDc);
        #endregion

        #region DeviceCaps常量
        const int HORZRES = 8;
        const int VERTRES = 10;
        const int LOGPIXELSX = 88;
        const int LOGPIXELSY = 90;
        const int DESKTOPVERTRES = 117;
        const int DESKTOPHORZRES = 118;
        #endregion

        #region 属性
        /// <summary>
        /// 获取屏幕分辨率当前物理大小
        /// </summary>
        public static System.Drawing.Size WorkingArea
        {
            get
            {
                IntPtr hdc = GetDC(IntPtr.Zero);
                System.Drawing.Size size = new System.Drawing.Size();
                size.Width = GetDeviceCaps(hdc, HORZRES);
                size.Height = GetDeviceCaps(hdc, VERTRES);
                ReleaseDC(IntPtr.Zero, hdc);
                return size;
            }
        }

        /// <summary>
        /// 当前系统DPI_X 大小 一般为96
        /// </summary>
        public static int DpiX
        {
            get
            {
                IntPtr hdc = GetDC(IntPtr.Zero);
                int DpiX = GetDeviceCaps(hdc, LOGPIXELSX);
                ReleaseDC(IntPtr.Zero, hdc);
                return DpiX;
            }
        }

        /// <summary>
        /// 当前系统DPI_Y 大小 一般为96
        /// </summary>
        public static int DpiY
        {
            get
            {
                IntPtr hdc = GetDC(IntPtr.Zero);
                int DpiX = GetDeviceCaps(hdc, LOGPIXELSY);
                ReleaseDC(IntPtr.Zero, hdc);
                return DpiX;
            }
        }

        /// <summary>
        /// 获取真实设置的桌面分辨率大小
        /// </summary>
        //public static System.Windows.Size DESKTOP
        //{
        //    get
        //    {
        //        IntPtr hdc = GetDC(IntPtr.Zero);
        //        System.Windows.Size size = new System.Windows.Size();
        //        size.Width = GetDeviceCaps(hdc, DESKTOPHORZRES);
        //        size.Height = GetDeviceCaps(hdc, DESKTOPVERTRES);
        //        ReleaseDC(IntPtr.Zero, hdc);
        //        return size;
        //    }
        //}

        /// <summary>
        /// 获取宽度缩放百分比
        /// </summary>
        public static float ScaleX
        {
            get
            {
                IntPtr hdc = GetDC(IntPtr.Zero);
                int t = GetDeviceCaps(hdc, DESKTOPHORZRES);
                int d = GetDeviceCaps(hdc, HORZRES);
                float ScaleX = (float)GetDeviceCaps(hdc, DESKTOPHORZRES) / (float)GetDeviceCaps(hdc, HORZRES);
                ReleaseDC(IntPtr.Zero, hdc);
                return ScaleX;
            }
        }

        /// <summary>
        /// 获取高度缩放百分比
        /// </summary>
        public static float ScaleY
        {
            get
            {
                IntPtr hdc = GetDC(IntPtr.Zero);
                float ScaleY = (float)(float)GetDeviceCaps(hdc, DESKTOPVERTRES) / (float)GetDeviceCaps(hdc, VERTRES);
                ReleaseDC(IntPtr.Zero, hdc);
                return ScaleY;
            }
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 获取系统版本
        /// </summary>
        /// <returns></returns>
        public static string get_OSVersion()
        {
            try
            {
                using (ManagementClass mc = new ManagementClass("Win32_OperatingSystem"))
                {
                    if (null == mc)
                    {
                        return string.Empty;
                    }
                    using (ManagementObjectCollection moc = mc.GetInstances())
                    {
                        foreach (ManagementObject each in moc)
                        {
                            var aaa = each.Properties["Version"].Value.ToString();
                        }
                    }

                    return mc["Version"] as string;
                }
            }
            catch (Exception exc)
            {
                return exc.ToString();
            }
        }

        /// <summary>
        /// 得到当前正在运行的操作系统的名称。 比如： 
        /// "Microsoft Windows 7 Enterprise".
        /// </summary>
        /// <returns></returns>
        public static string GetOSName()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT Caption FROM Win32_OperatingSystem");

            foreach (ManagementObject queryObj in searcher.Get())
            {
                return queryObj["Caption"] as string;
            }

            return null;
        }
        #endregion
    }
}
