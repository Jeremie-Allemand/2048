using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;

namespace _2048
{
    public class Grid
    {
        public Cell[,] cells { get; set; }
        public const int SIZE = 4;

        static readonly Random Random = new Random();
        public Grid()
        {
            cells = new Cell[SIZE, SIZE];
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    cells[i, j] = new Cell(0);
                }
            }
        }

        public int GetEmptyCellCount()
        {
            int count = 0;
            foreach (var c in cells)
            {
                if (c.IsEmpty)
                {
                    count++;
                }
            }
            return count;
        }

        public Cell GetRandomEmptyCell()
        {
            int emptyCellCount = GetEmptyCellCount();
            if (emptyCellCount == 0)
                return null;
            int rndCellIdx = Random.Next(emptyCellCount);
            int count = 0;
            foreach (var c in cells)
            {
                if (c.IsEmpty)
                {
                    if (count == rndCellIdx)
                        return c;
                    count++;
                }
            }

            return null;
        }

        public Cell[] getRow(int rowIdx, bool reverse = false) 
        {
            Cell[] row = new Cell[SIZE];
            if (reverse)
            {
                for (int x = 0; x < SIZE; x++)
                {
                    row[SIZE-x-1] = cells[rowIdx, x];
                }
                return row;
            }

            else
            {
                for (int x = 0; x < SIZE; x++)
                {
                    row[x] = cells[rowIdx, x];
                }
                return row;
            }
        }

        public Cell[] getColumn(int colIdx, bool reverse = false)
        {
            Cell[] col = new Cell[SIZE];
            if (reverse)
            {
                for (int y = 0; y < SIZE; y++)
                {
                    col[SIZE - y - 1] = cells[y, colIdx];
                }
                return col;
            }

            else
            {
                for (int y = 0; y < SIZE; y++)
                {
                    col[y] = cells[y, colIdx];
                }
                return col;
            }

        }

        public int[,] getNumbers() 
        {
            int[,] numbers = new int[SIZE, SIZE];
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    numbers[i, j] = cells[i, j].Number; 
                }
            }
            return numbers;
        }


        override public String ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    sb.Append($"{ "[" + cells[i,j] + "]"}");
                }

                sb.Append("\n");
            }
            return sb.ToString();   
        }
    }
}
