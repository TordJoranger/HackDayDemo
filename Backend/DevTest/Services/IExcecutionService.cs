using System.Collections.Generic;
using DevTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevTest.Services
{
    public interface IExcecutionService
    {
      //  IEnumerable<Excecution> GetExcecutions();
        Excecution CreateExcecution(Path path);
    }
}
