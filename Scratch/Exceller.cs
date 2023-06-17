using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using scale.SQLQuery;
using scale.Model;
// debugging
using System.Diagnostics;
// excel
using OfficeOpenXml;
using System.IO;
// tutorial - https://www.youtube.com/watch?v=j3S3aI8nMeE
namespace scale.Helper
{
    class Exceller
    {
        private const string defaultPath = @"C:\Users\Vinhle\Desktop\tuhngo\tuexcel.xlsx";
        public static async Task Initialize(string path = defaultPath)
        {
            // License for Excel
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            Trace.WriteLine($"Exceller.Initialize - Start");

            // TODO - execute data there
            //...
            // start a file with path
            var file = new FileInfo(path);

            // get data for test excel
            var people = MineQuery.GetClients();

            await SaveExcelFile(people, file);
            Trace.WriteLine($"Exceller.Initialize - End");
        }

        private static async Task SaveExcelFile(List<Client> people, FileInfo file)
        {
            // ensure that there isn't a excel file with same name in the location
            DeleteIfExist(file);

            // this machanism makes sure that the 'package' is automatically disposed after the closed curly brace 
            // curently, we are using C# 7.3. using machanism is just available on C# 8.0 onward
            // i.e. using var package = new ExcelPackage(file);
            using (var package = new ExcelPackage(file))
            {
                var workSheet = package.Workbook.Worksheets.Add("MainReport");

                var range = workSheet.Cells["A2"].LoadFromCollection(people, true);
                range.AutoFitColumns();

                // manipulation
                // Format Header
                workSheet.Cells["A1"].Value = "Our Cool Report";
                workSheet.Cells["A1:C1"].Merge = true;
                workSheet.Column(1).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                workSheet.Row(1).Style.Font.Size = 24;
                // set color
                //workSheet.Row(1).Style.Font.Color.SetColor(OfficeOpenXml.Style.ExcelIndexedColor.Indexed0);

                workSheet.Column(2).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                workSheet.Row(2).Style.Font.Bold = true;
                workSheet.Column(2).Width = 20;

                await package.SaveAsync();
            }
        }

        private static void DeleteIfExist(FileInfo file)
        {
            if(file.Exists)
            {
                file.Delete();
            }
        }
    }
}
