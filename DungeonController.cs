using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonController : MonoBehaviour
{
    public GameObject northDoor, southDoor, eastDoor, westDoor;

    void Start()
    {
        Room theCurrentRoom = MySingleton.thePlayer.getCurrentRoom();
        if (theCurrentRoom.hasExit("north"))
        {
            this.northDoor.SetActive(false);
        }

        if (theCurrentRoom.hasExit("south"))
        {
            this.southDoor.SetActive(false);
        }

        if (theCurrentRoom.hasExit("east"))
        {
            this.eastDoor.SetActive(false);
        }

        if (theCurrentRoom.hasExit("west"))
        {
            this.westDoor.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}