using DevTest.Models;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace DevTest.Services
{
    public class VectorService : IVectorService
    {
        public int CountDuplicates(Vector vector, List<Vector> vectorsVisited)
        {
            var pointsAlreadyVisited = new HashSet<Point>();

            if (vectorsVisited.Count == 1)//no need to check first vector, will never have duplicates
                return 0;

            for (var i = 0; i < vectorsVisited.Count; i++)
            {
                FindDuplicates(vector, vectorsVisited[i], pointsAlreadyVisited);
            }

            //remove starting point, as it will always be a duplicate
            pointsAlreadyVisited.Remove(vector.Start);

            return pointsAlreadyVisited.Count;
        }

        private void FindDuplicates(Vector a, Vector b, HashSet<Point> points)
        {
            double pa1X = a.Start.X;
            double pa2X = a.End.X;
            double pb1X = b.Start.X;
            double pb2X = b.End.X;
            double pa1Y = a.Start.Y;
            double pa2Y = a.End.Y;
            double pb1Y = b.Start.Y;
            double pb2Y = b.End.Y;

            double dxa = pa2X - pa1X;
            double dya = pa2Y - pa1Y;
            double dxb = pb2X - pb1X;
            double dyb = pb2Y - pb1Y;
            double determinant = (dya * dxb) - (dyb * dxa);

            if (b.Length == 0) //Checking for duplicates on starting point
            {
                var dxc = pb1X - pa1X;
                var dyc = pb1Y - pa1Y;
                //ignoring first vector
                if ((dxc * dya) - (dyc * dxa) == 0)
                {
                    bool onLine = PointIsOnVector(a, new Point((int)pb1X, (int)pb1Y));

                    if (onLine)
                        points.Add(new Point(b.Start.X, b.Start.Y));
                }
                return;
            }

            //check if parallel
            if (determinant == 0)
            {
                if (dya == 0) //Xaxis
                {
                    if (a.Start.Y != b.Start.Y)
                        return;

                    var j = 1;
                    for (var i = 0; i <= b.Length; i++)
                    {
                        if (dxb < 0)
                            j = -1;

                        if (PointIsOnVector(a, new Point(b.Start.X + (i * j), b.Start.Y)))
                            points.Add(new Point(b.Start.X + (i * j), b.Start.Y));
                    }

                    return;
                }
                if (dxa == 0) //Yaxis
                {
                    if (a.Start.X != b.Start.X)
                        return;
                    var j = 1;
                    for (var i = 0; i <= b.Length; i++)
                    {
                        if (dyb < 0)
                            j = -1;
                        if (PointIsOnVector(a, new Point(b.Start.X, b.Start.Y + (i * j))))
                            points.Add(new Point(b.Start.X, b.Start.Y + (i * j)));
                    }
                }
            }
            else
            {
                double t1 = (((pa1X - pb1X) * dyb) + ((pb1Y - pa1Y) * dxb))
                    / determinant;

                double t2 = (((pb1X - pa1X) * dya) + ((pa1Y - pb1Y) * dxa))
                    / -determinant;

                double x = pa1X + (dxa * t1);
                double y = pa1Y + (dya * t1);

                if (t1 >= 0 && t1 <= 1 && t2 >= 0 && t2 <= 1 && new Point((int)x, (int)y) != a.Start)
                    points.Add(new Point((int)Math.Round(x), (int)Math.Round(y)));
            }
        }

        private bool PointIsOnVector(Vector a, Point b)
        {
            double dxa = a.End.X - a.Start.X;
            double dya = a.End.Y - a.Start.Y;
            if (Math.Abs(dxa) >= Math.Abs(dya))
            {
                return dxa > 0 ?
                  a.Start.X <= b.X && b.X <= a.End.X :
                  a.End.X <= b.X && b.X <= a.Start.X;
            }
            else
                return dya > 0 ?
                  a.Start.Y <= b.Y && b.Y <= a.End.Y :
                  a.End.Y <= b.Y && b.Y <= a.Start.Y;
        }
    }
}

