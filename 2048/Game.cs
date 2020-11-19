using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;
using System.Linq;

namespace _2048
{
    public enum Direction { Left, Right, Up, Down };
    public class Game
    {
        static readonly Random Random = new Random();
        public Grid Grid { get; set; }

        private int Score { get; set; }
        public Game()
        {
            Grid = new Grid();
            AddNewCell();
            AddNewCell();
            /*
            Grid.cells[0, 0].Number = 2;
            Grid.cells[1, 0].Number = 4;
            Grid.cells[2, 0].Number = 2;
            Grid.cells[3, 0].Number = 4;

            Grid.cells[0, 1].Number = 4;
            Grid.cells[1, 1].Number = 2;
            Grid.cells[2, 1].Number = 4;
            Grid.cells[3, 1].Number = 2;

            Grid.cells[0, 2].Number = 2;
            Grid.cells[1, 2].Number = 4;
            Grid.cells[2, 2].Number = 2;
            Grid.cells[3, 2].Number = 4;

            Grid.cells[0, 3].Number = 4;
            Grid.cells[1, 3].Number = 2;
            Grid.cells[2, 3].Number = 4;
            Grid.cells[3, 3].Number = 2;
            */
        }

        public void AddNewCell()
        {

            var c = Grid.GetRandomEmptyCell();
            if (c != null)
                c.Number = Random.Next(4) > 0 ? 2 : 4;
        }

        public Cell[] ShiftCells(Cell[] row)
        {
            

            for (int i = 0; i < Grid.SIZE; i++)
            {
                bool move = false;
                if (i > 0)
                {
                    if (row[i - 1].IsEmpty && !row[i].IsEmpty)
                    {
                        row[i - 1].Number = row[i].Number;
                        row[i].Number = 0;

                        move = true;
                    }

                    if (row[i - 1].Number == row[i].Number && !row[i].IsEmpty)
                    {
                        row[i - 1].Number += row[i].Number;
                        row[i].Number = 0;

                        Score += row[i - 1].Number;
                    }
                }

                if (move)
                {
                    i = 0;
                }
            }

            return row;
        }


        public void Shift(Direction direction) 
        {
            string oldGrid = Grid.ToString();

            switch(direction)
            {
                case Direction.Left:
                    for (int y = 0; y < Grid.SIZE; y++)
                    {
                        Cell[] row = Grid.getRow(y);
                        Cell[] newRow = ShiftCells(row);

                        for (int x = 0; x < Grid.SIZE; x++)
                        {
                            Grid.cells[y, x] = newRow[x];
                        }
                    }
                    break;

                case Direction.Right:
                    for (int y = 0; y < Grid.SIZE; y++)
                    {
                        Cell[] row = Grid.getRow(y, true);


                        Cell[] newRow = ShiftCells(row);

                        for (int x = 0; x < Grid.SIZE; x++)
                        {
                            Grid.cells[y, Grid.SIZE-x-1] = newRow[x];
                        }
                    }
                    break;

                case Direction.Up:
                    for (int x = 0; x < Grid.SIZE; x++)
                    {
                        Cell[] col = Grid.getColumn(x);


                        Cell[] newCol = ShiftCells(col);

                        for (int y = 0; y < Grid.SIZE; y++)
                        {
                            Grid.cells[y, x] = newCol[y];
                        }
                    }
                    break;

                case Direction.Down:
                    for (int x = 0; x < Grid.SIZE; x++)
                    {
                        Cell[] col = Grid.getColumn(x,true);


                        Cell[] newCol = ShiftCells(col);

                        for (int y = 0; y < Grid.SIZE; y++)
                        {
                            Grid.cells[Grid.SIZE-y-1, x] = newCol[y];
                        }
                    }
                    break;
            }
            string newGrid = Grid.ToString();
            if (newGrid != oldGrid) 
            {
                AddNewCell();
            }
        }

        public bool isGameOver() 
        {
            int[,] numbers = Grid.getNumbers();
            for (int i = 1; i < Grid.SIZE-1; i++)
            {
                for (int j = 0; j < Grid.SIZE; j++)
                {
                    if(numbers[i,j] == numbers[i-1,j] && numbers[i, j] == numbers[i + 1, j])
                        return false;
                }
            }

            for (int i = 1; i < Grid.SIZE - 1; i++)
            {
                for (int j = 0; j < Grid.SIZE; j++)
                {
                    if (numbers[j, i] == numbers[j, i-1] && numbers[j, i] == numbers[j, i+1])
                        return false;
                }
            }

            return true;
        }

        public override string ToString()
        {
            return Score.ToString(); 
        }
    }  
}
