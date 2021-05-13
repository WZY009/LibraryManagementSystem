using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookMS {
    static class ExportToExcel {
        public static FileInfo file = new FileInfo(@"Output.xlsx");
        public static void Export(DataGridView chart) {
            using (ExcelPackage package = new ExcelPackage(file)) {
                ExcelWorksheet sheet;
                try {
                    sheet = package.Workbook.Worksheets.Add("My Sheet");
                }
                catch (Exception) {
                    sheet = package.Workbook.Worksheets.First();
                }
                for(int i=1;i<chart.ColumnCount+1;i++) 
                    sheet.Cells[1,i].Value = chart.Columns[i-1].HeaderText;//shr牛逼
                for (int i = 0; i < chart.RowCount+1; ++i)
                    for (int j = 0; j < chart.ColumnCount-1; ++j)
                        sheet.Cells[j+2,i+1].Value = chart[i, j].Value;
                
                package.Save();
            }
        }
    }
}
