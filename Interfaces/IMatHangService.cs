using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using scale.Model.Entity;

namespace scale.Interfaces
{
    public interface IMatHangService
    {
        IEnumerable<string> GetTenHang();
        IEnumerable<SanPham> GetAllMatHang();
    }
}
