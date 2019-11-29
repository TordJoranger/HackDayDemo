using System.Drawing;

namespace DevTest.Models
{
    public struct Vector
    {
        public Point Start { get; set; }
        public Point End { get; set; }
        public int Length { get; set; }

        public Vector(Point start, int length, Point end)
        {
            Start = start;
            Length = length;
            End = end;
        }
    }
}
