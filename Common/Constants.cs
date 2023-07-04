using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scale.Common
{
    public static class Constants
    {
        public enum COMPortAction
        {
            Connect,
            Disconnect
        }

        public const string BienSoXeRegexPattern = @"^\d{2}[A-Za-z]\d-\d{4,5}$";
    }
}
