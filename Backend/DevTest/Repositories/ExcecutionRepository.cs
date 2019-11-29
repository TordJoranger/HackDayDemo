using DevTest.Models;
using System.Collections.Generic;

namespace DevTest.Repositories
{
    public class ExcecutionRepository : IExcecutionRepository
    {
        private readonly ApiDbContext _context;

        public ExcecutionRepository(ApiDbContext context)
        {
            _context = context;
        }

        public void Add(Excecution excecution)
        {
            _context.Add(excecution);
        }

       // public IEnumerable<Excecution> GetExcecutions()
        //{
           // return _context.Excecutions;
       // }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}