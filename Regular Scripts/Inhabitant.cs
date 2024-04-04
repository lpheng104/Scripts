using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Inhabitant
{
    protected string name;
    protected Room currentRoom;
    protected int hp, ac;

    public Inhabitant(string name)
    {
        this.name = name;
        this.currentRoom = null;
        this.hp = Random.Range(10, 16);
        this.ac = Random.Range(8, 17);
    }

    public Room getCurrentRoom()
    {
        return this.currentRoom;
    }

    public void setCurrentRoom(Room r)
    {
        this.currentRoom = r;
    }

    public void takeDamage(int damage)
    {
        this.hp = this.hp - damage;
    }

    public int getHP()
    {
        return this.hp;
    }

    public int getAC()
    {
        return this.ac;
    }
}