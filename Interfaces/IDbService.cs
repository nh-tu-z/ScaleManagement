using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scale.Interfaces
{
    public interface IDbService
    {
        IEnumerable<T> Query<T>(string query, object parameters = null) where T : class;
        int Execute(string query, object parameters = null);
        T QuerySingleOrDefault<T>(string query, object parameters = null);
    }
}
