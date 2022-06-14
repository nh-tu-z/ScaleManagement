using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// model
using scale.Model;
// excel
using OfficeOpenXml;
// debugging
using System.Diagnostics;

namespace scale.Helper
{
    /*
     * Interface for excel. At the beginning, we have 3 excel files need to write into:
     * + ...
     * + ...
     * + ...
     */
    public interface IExcellor
    {
        // Properties declaration

        // Each excel file must have a location
        string Dir_ { get; set; }
        // Name of excel file
        string Name_ { get; set; }

        // Methods declaration

        // Initialization - customize the form of excel or make some 
        // configuration
        Task init();

        // Fill data in excel file - depends on the type of data we want
        // to ingest in the file, the \data can be cast to specific data type
        Task write(List<object> data);
    }

    public class Excel : IExcellor
    {
        public Excel()
        {
            // License for non commercial excel
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            // init default value
            // TODO - we need to add these default vaules by configuration
            Dir_ = @"C:\Users\Vinhle\Desktop\tuhngo";
            Name_ = @"tuexcel.xlsx";

            // debugging
            Trace.WriteLine($"Excel Constructor");
        }
        public string Dir_ { get; set; }
        public string Name_ { get; set; }

        public virtual Task init()
        {
            // No implementaion
            return Task.CompletedTask;
        }
        public virtual Task write(List<object> data)
        {
            // No implement 
            return Task.CompletedTask;
        }
        public void deleteIfExists(FileInfo file)
        {
            if (file.Exists)
            {
                file.Delete();
            }

        }
    }
    public class WeightSheetExcel : Excel
    {
        public override async Task write(List<object> data)
        {
            // debugging
            Trace.WriteLine($"WeightSheetExcel - write(List<object> data): Start...");

            // cast to specific data type
            List<OutputSheet> outputSheet = data.Cast<OutputSheet>().ToList();

            // TODO - change the Name_ property

            // start a file with path
            string path = Dir_ + @"\" + Name_;
            Trace.WriteLine($"WeightSheetExcel - write(List<object> data): writing path is {path}");

            var file = new FileInfo(path);

            // ensure that there isn't a excel file with same name in the location
            deleteIfExists(file);

            // filling data in...
            using (var package = new ExcelPackage(file))
            {
                var workSheet = package.Workbook.Worksheets.Add("Phiếu cân");

                // Format Header
                workSheet.Cells["A1"].Value = "Our Cool Report";
                workSheet.Cells["A1:C1"].Merge = true;
                workSheet.Column(1).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                workSheet.Cells["A2"].Value = "Số Phiếu";
                workSheet.Cells["B2"].Value = "Số Xe";
                workSheet.Cells["C2"].Value = "Khách Hàng";
                workSheet.Cells["D2"].Value = "Trọng Lượng Vào";
                workSheet.Cells["E2"].Value = "Trọng Lượng Ra";
                workSheet.Cells["F2"].Value = "Trọng Lượng Hàng";
                workSheet.Cells["G2"].Value = "Quy Đổi";
                workSheet.Cells["H2"].Value = "Đơn giá";
                workSheet.Cells["I2"].Value = "Thành Tiền";
                workSheet.Cells["J2"].Value = "Tiền Vận Chuyển (VNĐ)";
                workSheet.Cells["K2"].Value = "Giờ Vào";
                workSheet.Cells["L2"].Value = "Giờ Ra";
                workSheet.Cells["M2"].Value = "Ghi Chú";
                workSheet.Row(2).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                workSheet.Row(2).Style.Font.Bold = true;

                // table data
                // 3 because we have already filled data row 1 and 2 above
                int offset = 3;
                foreach(OutputSheet item in outputSheet)
                {
                    workSheet.Cells[$"A{offset}"].Value = item.SheetID;
                    workSheet.Cells[$"B{offset}"].Value = item.TruckNumber;
                    workSheet.Cells[$"C{offset}"].Value = item.Client;
                    workSheet.Cells[$"D{offset}"].Value = item.WeightIn;
                    workSheet.Cells[$"E{offset}"].Value = item.WeightOut;
                    workSheet.Cells[$"F{offset}"].Value = "???";
                    workSheet.Cells[$"G{offset}"].Value = item.Exchange;
                    workSheet.Cells[$"H{offset}"].Value = item.UnitPrice;
                    workSheet.Cells[$"I{offset}"].Value = "???";
                    workSheet.Cells[$"J{offset}"].Value = "???";
                    workSheet.Cells[$"K{offset}"].Value = item.TimeIn;
                    workSheet.Cells[$"L{offset}"].Value = item.TimeOut;
                    workSheet.Cells[$"M{offset}"].Value = item.Note;

                    // for next round
                    offset++;
                }

                await package.SaveAsync();
                // debugging
                Trace.WriteLine($"WeightSheetExcel - write(List<object> data): End");
            }
        }
    }
    public class ScaleSheet : Excel
    {
        public override async Task write(List<object> data)
        {
            // debugging
            Trace.WriteLine($"ScaleSheet - write(List<object> data): Start...");

            // cast to specific data type
            List<OutputSheet> outputSheet = data.Cast<OutputSheet>().ToList();

            // TODO - change the Name_ property

            // start a file with path
            string path = Dir_ + @"\" + Name_;
            Trace.WriteLine($"ScaleSheet - write(List<object> data): writing path is {path}");

            var file = new FileInfo(path);

            // ensure that there isn't a excel file with same name in the location
            deleteIfExists(file);

            // filling data in...
            using (var package = new ExcelPackage(file))
            {
                var workSheet = package.Workbook.Worksheets.Add("Phiếu cân 2");

                await package.SaveAsync();
                // debugging
                Trace.WriteLine($"ScaleSheet - write(List<object> data): End");
            }
        }
    }
}
