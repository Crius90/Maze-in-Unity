using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

public class MaskedGrid : MazeGrid
{
   public Mask Mask { get; set; }

   public MaskedGrid(Mask mask) : base(mask.Rows, mask.Columns)
   {
      Mask = mask;

      PrepareGrid();
      ConfigureCells();
   }

   private void PrepareGrid()
   {
      Cells = new Cell[Rows, Columns];

      for (int row = 0; row < Rows; row++)
      {
         for (int col = 0; col < Columns; col++)
         {
            if (Mask.GetCellState(row, col))
            {
               Cells[row, col] = new Cell(row, col);
            }
         }
      }
   }

   public void ConfigureCells()
   {
      for (int row = 0; row < Rows; row++)
      {
         for (int col = 0; col < Columns; col++)
         {
            if (Mask.GetCellState(row, col))
            {
               if (row > 0)
                  Cells[row, col].North = Cells[row - 1, col];
               if (row < (Rows - 1))
                  Cells[row, col].South = Cells[row + 1, col];
               if (col < (Columns - 1))
                  Cells[row, col].East = Cells[row, col + 1];
               if (col > 0)
                  Cells[row, col].West = Cells[row, col - 1];
            }
         }
      }
   }

   public new Cell GetRandomCell()
   {
      var c = Mask.RandomLocation();

      return Cells[c.row, c.col];
   }

   public new int Size()
   {
      return Mask.CountCells();
   }
}
