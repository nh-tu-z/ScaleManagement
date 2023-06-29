using scale.CommandText;
using scale.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using scale.Model.Entity;

namespace scale.Services
{
    public class MatHangService : IMatHangService
    {
        private readonly IDbService _dbService;

        public MatHangService(IDbService dbService)
        {
            _dbService = dbService;
        }

        public IEnumerable<string> GetTenHang()
        {
           return _dbService.Query<string>(SanPhamCommand.GetSanPhamName);
        }

        public IEnumerable<SanPham> GetAllMatHang() 
        {
            return _dbService.Query<SanPham>(SanPhamCommand.GetAllSanPham);
        }
    }
}
