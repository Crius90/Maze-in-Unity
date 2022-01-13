using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mask 
{
    public int Rows { get; set; }
    public int Columns { get; set; }

    public bool[,] cellState;

    public Mask(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;

        cellState = new bool[Rows, Columns];

        for (int row = 0; row < Rows; row++)
        {
            for (int col = 0; col < Columns; col++)
            {
                cellState[row, col] = true;
            }
        }
    }

    public bool GetCellState(int row, int col)
    {
        if (row >= 0 && row <= Rows)
        {
            if (col >= 0 && col <= Columns)
            {
                return cellState[row, col];
            }
        }
        return false;
    }

    public void SetCellState(int row, int col, bool insideMaze)
    {
        cellState[row, col] = insideMaze;
    }

    public int CountCells()
    {
        int count = 0;

        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                if (cellState[i, j])
                {
                    count++;
                }
            }
        }
        return count;
    }

    public (int row, int col) RandomLocation()
    {
        System.Random rnd = new System.Random();

        while (true)
        {
            int row = rnd.Next(Rows - 1);
            int col = rnd.Next(Columns - 1);

            if (cellState[row, col])
            {
                return (row, col);
            }
        }
    }
}
