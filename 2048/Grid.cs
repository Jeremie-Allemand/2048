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
        public int Size {get;set;}

        static readonly Random Random = new Random();
        public Grid(int size)
        {
            Size = size;
            cells = new Cell[Size, Size];
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
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
            Cell[] row = new Cell[Size];
            if (reverse)
            {
                for (int x = 0; x < Size; x++)
                {
                    row[Size-x-1] = cells[rowIdx, x];
                }
                return row;
            }

            else
            {
                for (int x = 0; x < Size; x++)
                {
                    row[x] = cells[rowIdx, x];
                }
                return row;
            }
        }

        public Cell[] getColumn(int colIdx, bool reverse = false)
        {
            Cell[] col = new Cell[Size];
            if (reverse)
            {
                for (int y = 0; y < Size; y++)
                {
                    col[Size - y - 1] = cells[y, colIdx];
                }
                return col;
            }

            else
            {
                for (int y = 0; y < Size; y++)
                {
                    col[y] = cells[y, colIdx];
                }
                return col;
            }

        }

        public int[,] getNumbers() 
        {
            int[,] numbers = new int[Size, Size];
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    numbers[i, j] = cells[i, j].Number; 
                }
            }
            return numbers;
        }


        override public String ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    sb.Append($"{ "[" + cells[i,j] + "]"}");
                }

                sb.Append("\n");
            }
            return sb.ToString();   
        }
    }
}
