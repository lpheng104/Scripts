using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
    private string name;
    private string[] openDoors = new string[4];
    private int numOpenDoors = 0;

    public Room(string name)
    {
        this.name = name;
    }

    public void AddOpenDoor(string direction)
    {
        openDoors[numOpenDoors] = direction;
        numOpenDoors++;
    }

    public bool isOpenDoor(string direction)
    {
        for (int i = 0; i < numOpenDoors; i++)
        {
            if (direction.Equals(openDoors[i]))
            {
                return true;
            }
        }
        return false;
    }
}
