using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace Zero.FrameworkLib.OSHelpers
{
    public class RegisterHelper
    {
        #region 字段属性

        #endregion

        #region 单例模式
        public static RegisterHelper _Instance;
        public static RegisterHelper Instance 
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new RegisterHelper();
                }
                return _Instance;
            }
        }
        #endregion

        #region 帮助方法
        /// <summary>
        /// 是否已经安装了组件
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        public bool IsInstallComponent(string condition)
        {
            var strCondition = string.Format("SELECT * FROM Win32_Product Where Name Like '%{0}%' ", condition);
            ManagementObjectSearcher mos = new ManagementObjectSearcher(strCondition);
            var managementObjectCollections = mos.Get();
            if (managementObjectCollections.Count > 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 是否已经安装了组件
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        public List<string> InstallComponentList(string condition = "")
        {
            List<string> lstresponses = new List<string>();
            var strCondition = string.Format("SELECT * FROM Win32_Product Where Name Like '%{0}%' ", condition);
            ManagementObjectSearcher mos = new ManagementObjectSearcher(strCondition);
            var managementObjectCollections = mos.Get();
            foreach (var mo in managementObjectCollections)
            {
                lstresponses.Add(mo["Name"].ToString());
            }
            return lstresponses;
        }
        #endregion
    }
}
