using scale.CommandText;
using scale.Interfaces;
using scale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scale.Services
{
    public class KhachHangService : IKhachHangService
    {
        private readonly IDbService _dbService;

        public KhachHangService(IDbService dbService)
        {
            _dbService = dbService;
        }

        public IEnumerable<KhachHang> GetAllKhachHangs()
        {
            return _dbService.Query<KhachHang>(KhachHangCommand.GetAllKhachHang);
        }

        public IEnumerable<string> GetAllKhachHangNames()
        {
            return _dbService.Query<string>(KhachHangCommand.GetKhachHangName);
        }
    }
}
