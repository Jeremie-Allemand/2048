using System;
using System.Text;
using Xunit;
using _2048;

namespace XUnitTest2048
{
    public class UnitTest2048
    {
        [Theory]
        [InlineData("2, , , ", "2, , , ")]
        [InlineData(" ,2, , ", "2, , , ")]
        [InlineData(" , ,2, ", "2, , , ")]
        [InlineData(" , , ,2", "2, , , ")]
        [InlineData("2,2, , ", "4, , , ")]
        [InlineData(" ,2,2, ", "4, , , ")]
        [InlineData(" , ,2,2", "4, , , ")]
        [InlineData("2, ,2, ", "4, , , ")]
        [InlineData(" ,2, ,2", "4, , , ")]
        [InlineData("2, , ,2", "4, , , ")]
        [InlineData("2,2,2, ", "4,2, , ")]
        [InlineData(" ,2,2,2", "4,2, , ")]
        [InlineData("2, ,2,2", "4,2, , ")]
        [InlineData("2,2, ,2", "4,2, , ")]
        [InlineData("2,2,2,2", "4,4, , ")]
        [InlineData("2,4,2,4", "2,4,2,4")]
        [InlineData("2,4,4, ", "2,8, , ")]
        [InlineData(" ,2,4,4", "2,8, , ")]
        [InlineData(" ,2, ,4", "2,4, , ")]
        [InlineData("2, ,4, ", "2,4, , ")]
        [InlineData("8,4,4, ", "8,8, , ")]
        [InlineData("8, ,4,4", "8,8, , ")]
        [InlineData("8,4, ,4", "8,8, , ")]
        public void Test1(string source, string expected)
        {
            var row = CreateRow(source);
            Game.ShiftCells(row);
            var result = RowToString(row);
            expected = RemoveWhitespace(expected);
            result = RemoveWhitespace(result);
            Assert.Equal(expected, result);
        }

        private Cell[] CreateRow(string s)
        {
            var values = s.Split(',');
            var cells = new Cell[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                int.TryParse(values[i], out var v);
                cells[i] = new Cell(v);
            }
            return cells;
        }

        private string RowToString(Cell[] row)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < row.Length; i++)
            {
                sb.Append(row[i]);
                if (i < row.Length - 1)
                    sb.Append(',');
            }
            return sb.ToString();
        }
        public  string RemoveWhitespace(string s)
        {
            return string.Join("", s.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
        }
    }
}
