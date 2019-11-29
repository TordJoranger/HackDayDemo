using DevTest.Models;
using System.Collections.Generic;
using System.Drawing;

namespace DevTest.Services
{
    public interface IVectorService
    {
        int CountDuplicates(Vector vector, List<Vector> vectorsVisited);
    }
}