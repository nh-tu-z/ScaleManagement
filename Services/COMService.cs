using scale.Interfaces;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using scale.CommandText;

namespace scale.Services
{
    public class COMService : ICOMService
    {
        private readonly IDbService _dbService;

        public COMService(IDbService dbService) 
        {
            _dbService = dbService;
        }

        /// <summary>
        /// Get available ports from system
        /// </summary>
        public IEnumerable<string> GetAvailablePorts()
        {
            return SerialPort.GetPortNames();
        }

        public bool DoesPortExist(string portName) 
        {
            return _dbService.QuerySingleOrDefault<bool>(COMCommand.DoesPortExist, new { portName });
        }

        public bool InsertPort(string portName)
        {
            return _dbService.QuerySingleOrDefault<bool>(COMCommand.InsertPort, new { portName });
        }
    }
}
