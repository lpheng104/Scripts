using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LitmansSingleton
{
    public static string currentDirection = "?";
    private static Room[] rooms = new Room[100];
    private static int numRooms = 0;
    public static Room theCurrentRoom = null;

    public static void addRoom(Room room)
    {
        rooms[numRooms] = room;
        numRooms++;
    }

    public static Room GetPreviousRoom()
    {
        if (numRooms > 1)
        {
            return rooms[numRooms - 2];
        }
        return null;
    }

    public static string MapIndexToStringForExit(int index)
    {
        if (index == 0) return "north";
        else if (index == 1) return "south";
        else if (index == 2) return "east";
        else if (index == 3) return "west";
        else return "?";
    }
}
