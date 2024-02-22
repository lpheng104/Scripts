using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LitmansSingleton
{
    public static string currentDirection = "?";
    private static Room[] theRooms = new Room[100];
    private static int numRooms = 0;

    public static void addRoom(Room r)
    {
        LitmansSingleton.theRooms[numRooms] = r;
        LitmansSingleton.numRooms++;
    }
}