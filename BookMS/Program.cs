using BookMS.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookMS {
    static class Program {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main() {
            // 按照官方文档，这一句是设定用这个库为非商业使用
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;//这一句话不能删，删掉的话到时候导入文件的时候会有问题
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            //System.Windows.Forms.Application.Run(new adminNewManagecs());
            //Application.Run(new userNewManage("8000"));
            //Application.Run(new userNewManage("8000"));
            Application.Run(new login());
            //Application.Run(new searchBookInfo());

        }
    }
}
