using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine.Rendering;

public class MazeGrid
{
    
   public int Rows { get; set; }
   public int Columns { get; set; }

   private int gridSize { get; set; }

   public Cell[,] Cells;

   private Random rand = new Random((int) DateTime.Now.Ticks);
   
   public MazeGrid(int row, int column){

      Rows = row;
      Columns = column;

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
            Cells[row, col] = new Cell(row, col);
         }
      }
   }

   private void ConfigureCells()
   {
      for (int row = 0; row < Rows; row++)
      {
         for (int col = 0; col < Columns; col++)
         {
            if (row > 0)
               Cells[row, col].North = Cells[row - 1, col];
            if (row < (Rows - 1))
               Cells[row, col].South = Cells[row + 1, col];
            if (col > 0)
               Cells[row, col].West = Cells[row, col - 1];
            if (col < (Columns - 1))
               Cells[row, col].East = Cells[row, col + 1];
         }
      }
   }

   public Cell GetRandomCell()
   {
      int row = rand.Next(Rows - 1);
      int col = rand.Next(Columns - 1);

      return Cells[row, col];
   }

   public int Size()
   {
      return Columns * Rows;
   }

   public Cell GetCell(int row, int col)
   {
      if (row >= 0 && row <= Rows)
      {
         if (col >= 0 && col <= Columns)
         {
            return Cells[row, col];
         }
      }

      return null;
   }

}
