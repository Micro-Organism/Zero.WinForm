using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Zero.NPOILib
{
    public class NpoiHelper
    {
        #region 属性字段

        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public NpoiHelper()
        {

        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 创建Excel文件
        /// </summary>
        /// <param name="filie_name"></param>
        /// <param name="sheet_name"></param>
        /// <returns></returns>
        public static bool CreateExcel(string filie_name, string sheet_name) 
        {
            //创建工作薄
            HSSFWorkbook wk = new HSSFWorkbook();
            //创建一个名称为mySheet的表
            ISheet tb = wk.CreateSheet(sheet_name);
            //创建一行，此行为第二行
            IRow row = tb.CreateRow(1);
            for (int i = 0; i < 20; i++)
            {
                ICell cell = row.CreateCell(i);  //在第二行中创建单元格
                cell.SetCellValue(i);//循环往第二行的单元格中添加数据
            }
            using (FileStream fs = File.OpenWrite(filie_name)) //打开一个xls文件，如果没有则自行创建，如果存在myxls.xls文件则在创建是不要打开该文件！
            {
                wk.Write(fs);   //向打开的这个xls文件中写入mySheet表并保存。
            }

            return true;
        }
        #endregion

        #region 私有方法

        #endregion
    }
}
