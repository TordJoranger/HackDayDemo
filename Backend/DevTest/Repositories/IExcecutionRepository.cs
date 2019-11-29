using DevTest.Models;
using System.Collections.Generic;

namespace DevTest.Repositories
{
    public interface IExcecutionRepository
    {
        void Add(Excecution excecution);

        bool Save();

       // IEnumerable<Excecution> GetExcecutions();
    }
}