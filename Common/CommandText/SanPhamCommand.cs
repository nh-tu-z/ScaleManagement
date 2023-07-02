using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scale.CommandText
{
    public static class SanPhamCommand
    {
        public const string GetSanPhamName = @"
            SELECT product.Name
            FROM SanPham AS product";

        public const string GetAllSanPham = @"
            SELECT product.ID, product.Name, product.GhiChu
            FROM dbo.SanPham AS product";
    }
}
