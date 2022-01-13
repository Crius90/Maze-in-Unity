using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
    public int UpperX {get; set;}
    public int UpperY { get; set; }
    public int LowerX { get; set; }
    public int LowerY { get; set; }

    public Room(int x1, int y1, int x2, int y2)
    {
        UpperX = x1;
        LowerX = x2;
        UpperY = y1;
        LowerY = y2;
    }

    public int RoomSize()
    {
        int count = 0;
        for (int i = UpperX; i <= LowerX; i++)
        {
            for (int j = UpperY; j <= LowerY; j++)
            {
                count++;
            }
        }

        return count;
    }

    public bool CheckIntersection(Room room)
    {
        if (UpperX - 2 >= room.LowerX || room.UpperX >= LowerX + 2)
            return false;

        if (UpperY - 2 >= room.LowerY || room.UpperY >= LowerY + 2)
            return false;

        return true;
    }
}
