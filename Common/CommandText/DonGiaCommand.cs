using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scale.CommandText
{
    public static class DonGiaCommand
    {
        public const string GetDonGias = @"SELECT * FROM DonGia";

        public const string GetAllDonGias = @"
            SELECT price.SanPhamID, price.Ngay, price.TyTrong, price.Gia, price.GhiChu
            FROM dbo.DonGia AS price";
    }
}
