using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class Room
{
    private string name;
    private Exit[] theExits = new Exit[4];
    private int howManyExits = 0;
    private Player currentPlayer;

    public Room(string name)
    {
        this.name = name;
        this.currentPlayer = null;
    }

    public void AddPlayer(Player thePlayer)
    {
        this.currentPlayer = thePlayer;
        this.currentPlayer.SetCurrentRoom(this);
    }

    public bool HasExit(string direction)
    {
        for (int i = 0; i < howManyExits; i++)
        {
            if (theExits[i].GetDirection().Equals(direction))
            {
                return true;
            }
        }
        return false;
    }

    public void AddExit(string direction, Room destinationRoom)
    {
        if (howManyExits < theExits.Length)
        {
            Exit e = new Exit(direction, destinationRoom);
            theExits[howManyExits] = e;
            howManyExits++;
        }
    }
}