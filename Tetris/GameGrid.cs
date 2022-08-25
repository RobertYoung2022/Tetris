using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class GameGrid
    {
        private readonly int[,] grid;

        public int Rows { get; }
        public int Columns { get; }

        // index for access to array
        public int this[int row, int column]
        {
            get => grid[row, column];
            set => grid[row, column] = value;
            
        }

        // Constructor
        public GameGrid(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            grid = new int[rows, columns];
        }

        // check if a given row is inside the column or not
        public bool IsInside(int row, int column)
        {
            return row >= 0 && row < Rows && column >= 0 && column < Columns;
        }

        // method to check if a given cell is empty or not
        public bool IsEmpty(int row, int column)
        {
            return IsInside(row, column) && grid[row, column] == 0;
        }

        // method to check if an entire row is full
        public bool IsRowFull(int row)
        {
            for (int column = 0; column < Columns; column++)
            {
                if (grid[row ,column] == 0)
                {
                    return false;
                }
            }
            return true;
        }

        // method to check if an entire row is empty
        public bool IsRowEmpty(int row)
        {
            for (int column = 0; column < Columns; column++)
            {
                if (grid[row, column] != 0)
                {
                    return false;
                }
            }
            return true;
        }

        private void ClearRow(int row)
        {
            for (int column = 0; column < Columns; column++)
            {
                grid[row, column] = 0;
            }

        }

        private void MoveRowDown(int row, int numRows)
        {
            for (int column = 0; column < Columns; column++)
            {
                grid[row + numRows, column] = grid[row, column];
                grid[row, column] = 0;
            }
        }

        public int ClearFullRows()
        {
            int cleared = 0;

            for (int row = Rows - 1; row >= 0; row--)
            {
                if (IsRowFull(row))
                {
                    ClearRow(row);
                    cleared++;
                }
                else if (cleared > 0)
                {
                    MoveRowDown(row, cleared);
                }
            }
            return cleared;
        }
    }
}
