using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;


namespace RSERP_ST431
{
   public class ExcelHelper
    {
       [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);
  
          /// <summary>
         /// 保存Excel模版
        /// </summary>
         /// <param name="columns">列名,例如：商品编码,商品名称,刊登单号,门店名称</param>
          /// <param name="FileName">文件名，例如：Ebay侵权下线</param>
        /// <param name="SheetName">工作表名称，例如：Ebay侵权下线</param>
          /// <param name="message">错误信息</param>
          public void SaveExcelTemplate(string[] columns, string FileName, string SheetName, ref string message)
          {
              string Filter = "Excel文件(*.xls)|*.xls|Excel文件(*.xlsx)|*.xlsx";
  
              SaveFileDialog saveFileDialog1 = new SaveFileDialog();
              saveFileDialog1.DefaultExt = "csv";
              saveFileDialog1.FileName = FileName;
              saveFileDialog1.Filter = Filter;
              saveFileDialog1.FilterIndex = 0;
              saveFileDialog1.RestoreDirectory = true;
              saveFileDialog1.CreatePrompt = true;
              saveFileDialog1.Title = "Excel文件";
              saveFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
 
             if (saveFileDialog1.ShowDialog() != DialogResult.OK)
                 return;
  
             //获得文件路径
             string localFilePath = saveFileDialog1.FileName.ToString();
             if (Regex.IsMatch(localFilePath, @"\.csv$"))
              {
                  localFilePath = Regex.Replace(saveFileDialog1.FileName, @"\.csv$", "", RegexOptions.IgnoreCase) + ".csv";
                  File.WriteAllText(localFilePath, string.Join(",", columns), Encoding.Default);
              }
              else
              {
               //获取文件路径，不带文件名
                 ArrayToExcelTemplate(columns, localFilePath, SheetName, ref message);
              }
  
              if (string.IsNullOrEmpty(message))
                 MessageBox.Show("\n\n导出完毕! ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
         }

         /// <summary>
         /// 导出模版
          /// </summary>
          /// <param name="columns">列名,例如：商品编码,商品名称,刊登单号,门店名称</param>
          /// <param name="localFilePath">本地路径</param>
          /// <param name="SheetName">工作表名称，例如：Ebay侵权下线</param>
          /// <param name="message">错误信息</param>
          public void ArrayToExcelTemplate(string[] columns, string localFilePath, string SheetName, ref string message)
          {
              Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
              if (xlApp == null)
              {
                  message = "无法创建Excel对象，可能计算机未安装Excel！";
                  return;
              }
  
              //創建Excel對象
              Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
              Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
              Microsoft.Office.Interop.Excel.Worksheet worksheet = null;
              if (worksheet == null) worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.Add(Type.Missing, Type.Missing, 1, Type.Missing);
              Microsoft.Office.Interop.Excel.Range range = null;
  
            long totalCount = columns.Length;
             worksheet.Name = SheetName;//第一个sheet在Excel中显示的名称
             int c;
             c = 0;
              ////写入标题
             for (int i = 0, count = columns.Length; i < count; i++)
             {
                 //if (string.IsNullOrEmpty(columns[i])) continue;
                 worksheet.Cells[1, c + 1] = columns[i];
                 range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, c + 1];
                 range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;//居中  
                 c++;
 
             }
 
            try
             {
                 localFilePath = Regex.Replace(localFilePath, ".xls$|.xlsx$", "", RegexOptions.IgnoreCase);
                 localFilePath += xlApp.Version.CompareTo("11.0") == 0 ? ".xls" : ".xlsx";
                 workbook.SaveCopyAs(localFilePath);
             }
             catch (Exception ex)
            {
                 message = "生成Excel附件过程中出现异常，详细信息如：" + ex.ToString();
            }
 
 
             try
             {
                 if (xlApp != null)
                 {
 
                     int lpdwProcessId;
                     GetWindowThreadProcessId(new IntPtr(xlApp.Hwnd), out lpdwProcessId);
                     System.Diagnostics.Process.GetProcessById(lpdwProcessId).Kill();
                }
             }
             catch (Exception ex)
             {
                 message = "Delete Excel Process Error:" + ex.Message;
             }
 
         }
    }
}
