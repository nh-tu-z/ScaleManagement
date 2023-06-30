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
    public class DonGiaService : IDonGiaService
    {
        private readonly IDbService _dbService;

        public DonGiaService(IDbService dbService)
        {
            _dbService = dbService;
        }

        public IEnumerable<DonGia> GetAllDonGias()
        {
            return _dbService.Query<DonGia>(DonGiaCommand.GetAllDonGias);
        }
    }
}
