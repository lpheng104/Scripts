using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon
{
    private string name;
    private Room startRoom;
    private Player thePlayer;

    public Dungeon(string name)
    {
        this.name = name;
    }

    public void SetStartRoom(Room r)
    {
        startRoom = r;
    }

    public void AddPlayer(Player thePlayer)
    {
        this.thePlayer = thePlayer;
        startRoom.AddPlayer(thePlayer);
    }
}