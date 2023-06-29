using scale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scale.Interfaces
{
    public interface IKhachHangService
    {
        IEnumerable<KhachHang> GetAllKhachHangs();
        IEnumerable<string> GetAllKhachHangNames();
    }
}
