using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RecursiveBacktracker 
{
    public static void CreateMaze(MaskedGrid grid)
    {

        System.Random rnd = new System.Random();
        var stack = new Stack<Cell>();
        stack.Push(grid.GetRandomCell());

        while (stack.Any())
        {
            Cell current = stack.Peek();
            List<Cell> nb = current.Neighbours().Where(c => c.Links().Count == 0).ToList();

            if (nb.Count == 0)
            {
                stack.Pop();
            }
            else
            {
                int index = rnd.Next(nb.Count);
                var neighbour = nb[index];
                current.LinkCells(neighbour, true);
                stack.Push(neighbour);
            }
        }
    }
}
