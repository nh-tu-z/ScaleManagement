using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scale.CommandText
{
    public class COMCommand
    {
        public const string InsertPort = @"
            INSERT INTO COM (PortName)
            VALUES (@PortName)";

        public const string DoesPortExist = @"
            SELECT TOP 1 COUNT(*)
            FROM COM
            WHERE PortName = @PortName";
    }
}
