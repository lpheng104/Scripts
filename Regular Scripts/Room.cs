using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void addPlayer(Player thePlayer)
    {
        this.currentPlayer = thePlayer;
        this.currentPlayer.setCurrentRoom(this); //this updates the player to their new current room
    }

    //remove the current player from this room
    public void removePlayer(string direction)
    {
        Exit theExit = this.getExitGivenDirection(direction);
        Room destinationRoom = theExit.getDestinationRoom();
        destinationRoom.addPlayer(this.currentPlayer);
        this.currentPlayer = null; //finally remove the player that just left from this room

    }

    private Exit getExitGivenDirection(string direction)
    {
        for (int i = 0; i < this.howManyExits; i++)
        {
            if (this.theExits[i].getDirection().Equals(direction))
            {
                return this.theExits[i]; //returns the exit in the given direction
            }
        }
        return null; //never found the exit
    }

    public bool hasExit(string direction)
    {
        for (int i = 0; i < this.howManyExits; i++)
        {
            if (this.theExits[i].getDirection().Equals(direction))
            {
                return true;
            }
        }
        return false;
    }

    public void addExit(string direction, Room destinationRoom)
    {
        if (this.howManyExits < this.theExits.Length)
        {
            Exit e = new Exit(direction, destinationRoom);
            this.theExits[this.howManyExits] = e;
            this.howManyExits++;
        }
    }
}