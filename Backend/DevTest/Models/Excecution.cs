using System;

namespace DevTest.Models
{
    public class Excecution
    {

       // public long Id { get; set; } = 0;

        public int Commands { get; set; }

        public long Result { get; set; }

        public double Duration { get; set; }

        public DateTime? Stamp { get; set; }
    }
}