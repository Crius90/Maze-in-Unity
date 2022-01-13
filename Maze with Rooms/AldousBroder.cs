using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class AldousBroder 
{
    public static void CreateMaze(MazeGrid grid)
    {
        Random rand = new Random((int)DateTime.Now.Ticks);

        Cell currentCell = grid.GetRandomCell();

        int unvisited = grid.Size() - 1;

        while (unvisited > 0)
        {
            List<Cell> neighbours = currentCell.Neighbours();
            int randomSample = rand.Next(neighbours.Count);
            Cell neighbour = neighbours[randomSample];

            if (!neighbour.links.Any())
            {
                currentCell.LinkCells(neighbour, true);
                unvisited--;
            }

            currentCell = neighbour;
            
        }

    }
}
