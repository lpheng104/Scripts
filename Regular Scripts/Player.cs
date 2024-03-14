using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private string name;
    private Room currentRoom;

    public Player(string name)
    {
        this.name = name;
        this.currentRoom = null;
    }

    public Room GetCurrentRoom()
    {
        return currentRoom;
    }

    public void SetCurrentRoom(Room r)
    {
        currentRoom = r;
    }

    public void LeaveRoom()
    {
        currentRoom = null;
    }
}
