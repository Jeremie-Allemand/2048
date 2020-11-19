using System;
using System.Collections.Generic;
using System.Text;

namespace _2048
{
    public class Cell
    {
        public int Number { get; set; }

        public bool IsEmpty { get => Number <= 0; }

        public Cell()
        {

        }
        public Cell(int nb)
        {
            Number = nb;
        }

        public override string ToString()
        {
            return !IsEmpty ? Number.ToString() : " "; 
        }
    }
}
