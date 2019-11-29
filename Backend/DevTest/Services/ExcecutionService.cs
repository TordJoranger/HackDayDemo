using DevTest.Models;
using DevTest.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using static DevTest.Constants;

namespace DevTest.Services
{
    public class ExcecutionService : IExcecutionService
    {
       // private readonly IExcecutionRepository _repository;
        private readonly IVectorService _vectorService;

        public ExcecutionService(/*IExcecutionRepository repository,*/ IVectorService vectorService)
        {
           // _repository = repository;
            _vectorService = vectorService;
        }

        public Excecution CreateExcecution(Path path)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var result = CalclulateUniqePoints(path);
            sw.Stop();

            var excecution = new Excecution
            {
                Duration = sw.Elapsed.TotalSeconds,
                Commands = path.Commands.Count,
                Result = result,
                Stamp = DateTime.Now
            };

           // _repository.Add(excecution);

            return  excecution;
        }

       // public IEnumerable<Excecution> GetExcecutions()
        //{
           // return _repository.GetExcecutions();
       // }

        private int CalclulateUniqePoints(Path path)
        {
            var start = new Point(path.Start.X, path.Start.Y);
            var startVector = new Vector(start, 0, start);
            var currentCoordinate = start;
            var vectorsVisited = new List<Vector> { startVector };
            int duplicates = 0;
            var steps = 0;

            foreach (Command command in path.Commands)
            {
                switch (command.Direction)
                {
                    case West:
                        {
                            var vector = new Vector(new Point(currentCoordinate.X, currentCoordinate.Y), command.Steps,
                                new Point(currentCoordinate.X - command.Steps, currentCoordinate.Y));

                            duplicates += _vectorService.CountDuplicates(vector, vectorsVisited);
                            vectorsVisited.Add(vector);
                            currentCoordinate.X -= command.Steps;
                            steps += command.Steps;
                            break;
                        }
                    case East:
                        {
                            var vector = new Vector(new Point(currentCoordinate.X, currentCoordinate.Y), command.Steps,
                                 new Point(currentCoordinate.X + command.Steps, currentCoordinate.Y));
                            duplicates += _vectorService.CountDuplicates(vector, vectorsVisited);
                            vectorsVisited.Add(vector);
                            currentCoordinate.X += command.Steps;
                            steps += command.Steps;
                            break;
                        }
                    case North:
                        {
                            var vector = new Vector(new Point(currentCoordinate.X, currentCoordinate.Y), command.Steps,
                                new Point(currentCoordinate.X, currentCoordinate.Y + command.Steps));
                            duplicates += _vectorService.CountDuplicates(vector, vectorsVisited);
                            vectorsVisited.Add(vector);
                            currentCoordinate.Y += command.Steps;
                            steps += command.Steps;
                            break;
                        }
                    case South:
                        {
                            var vector = new Vector(new Point(currentCoordinate.X, currentCoordinate.Y), command.Steps,
                               new Point(currentCoordinate.X, currentCoordinate.Y - command.Steps));
                            duplicates += _vectorService.CountDuplicates(vector, vectorsVisited);
                            vectorsVisited.Add(vector);
                            currentCoordinate.Y -= command.Steps;
                            steps += command.Steps;
                            break;
                        }
                }
            }
            //Adding 1 for initial node 
            return steps - duplicates + 1;
        }
    }
}