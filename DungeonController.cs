using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonController : MonoBehaviour
{
    public GameObject[] closedDoors;

    void Start()
    {
        if (LitmansSingleton.theCurrentRoom == null)
        {
            GenerateRandomRoom();
        }
        else
        {
            LoadRoom(LitmansSingleton.theCurrentRoom);
        }
    }

    private void GenerateRandomRoom()
    {
        int openDoorIndex = Random.Range(0, 4);
        this.closedDoors[openDoorIndex].SetActive(false);

        LitmansSingleton.theCurrentRoom = new Room("a room");
        LitmansSingleton.addRoom(LitmansSingleton.theCurrentRoom);
        LitmansSingleton.theCurrentRoom.AddOpenDoor(LitmansSingleton.MapIndexToStringForExit(openDoorIndex));

        for (int i = 0; i < 4; i++)
        {
            if (openDoorIndex != i && Random.Range(0, 2) == 1)
            {
                this.closedDoors[i].SetActive(false);
                LitmansSingleton.theCurrentRoom.AddOpenDoor(LitmansSingleton.MapIndexToStringForExit(i));
            }
        }
    }

    private void LoadRoom(Room room)
    {
        for (int i = 0; i < 4; i++)
        {
            if (room.isOpenDoor(LitmansSingleton.MapIndexToStringForExit(i)))
            {
                this.closedDoors[i].SetActive(false);
            }
        }
    }
}
