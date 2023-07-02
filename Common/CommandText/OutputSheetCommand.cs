using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scale.CommandText
{
    public static class OutputSheetCommand
    {
        public const string Get20OutputSheets = @"
            SELECT TOP 20 
                sheet.SoPhieu, sheet.SoXe, client.Name, 
                price.TyTrong, price.Gia,
                sheet.TrongLuongVao, sheet.TrongLuongRa, sheet.TienVanChuyen, 
                sheet.GioVao, sheet.GioRa, sheet.GhiChu 
            FROM PhieuCan AS sheet 
            JOIN KhachHang AS client ON sheet.KhachHangID = client.ID 
            JOIN DonGia AS price ON sheet.SanPhamID = price.SanPhamID";
    }
}
