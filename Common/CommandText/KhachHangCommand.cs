using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scale.CommandText
{
    public class KhachHangCommand
    {
        public const string GetKhachHangName = @"
            SELECT client.Name
            FROM KhachHang AS client";

        public const string GetAllKhachHang = @"
            SELECT client.ID, client.Name, client.SDT, client.DiaChi, client.GhiChu
            FROM dbo.KhachHang AS client";

        public const string GetLastKhachHangID = @"
            SELECT TOP 1 client.ID
            FROM dbo.KhachHang AS client
            ORDER BY client.ID DESC";

        public const string UpdateKhachHang = @"
            TODO";
    }
}
