using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnonymizeApi.Logic
{
    public interface IPersonNameFinder
    {
        Task<IEnumerable<string>> FindPersonNames(string s);
    }
}