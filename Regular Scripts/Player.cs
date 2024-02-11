using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Player
{
    private string name;
    private int hp;

    public Player(string name)
    {
        this.hp = (int)Random.Range(10.0f, 20.0f);
        this.name = name;
    }

    public void display()
    {
        Debug.Log(this.name + " -> HP: " + this.hp);
    }

    public string Name
    {
        get { return name; }
    }

    public int HP
    {
        get { return hp; }
    }
}
