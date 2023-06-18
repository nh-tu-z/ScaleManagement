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
    }
}
