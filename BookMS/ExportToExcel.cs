using OfficeOpenXml;
using System;
using System.IO;
using System.Linq;
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
                //Pay attention! chart[i,j] represents the cell of (i+1) column and (j+1）row in dataGridView 
                //ColumnCount represents the number of column while the RowCount represents the number of rows
                for (int i = 0; i < chart.ColumnCount + 0; i++)
                    sheet.Cells[1, i + 1].Value = chart.Columns[i].HeaderText;//input the Header into the excel

                for (int i = 0; i < chart.RowCount; i++)//i repesents the number of columns
                    for (int j = 0; j < chart.ColumnCount; j++)//j represents the number of rows
                        sheet.Cells[i + 2, j + 1].Value = chart[j, i].Value as string;


                string fileSource = @"Output.xlsx"; //source document
                using (SaveFileDialog saveFileDialog1 = new SaveFileDialog()) {
                    package.Save();
                    saveFileDialog1.Title = "Save";
                    saveFileDialog1.FileName = "Book sheet.xls"; //设置默认另存为的名字，可选
                    saveFileDialog1.Filter = "Excel 文件(*.xls)|*.xls|Excel 文件(*.xlsx)|*.xlsx|所有文件(*.*)|*.*";
                    saveFileDialog1.AddExtension = true;
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                        System.IO.File.Copy(fileSource, saveFileDialog1.FileName, true);
                    }
                }
                File.Delete(@"Output.xlsx");//delete the document stored before

            }
        }
    }
}
