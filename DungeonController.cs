using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonController : MonoBehaviour
{
    public GameObject northDoor;
    public GameObject southDoor;
    public GameObject eastDoor;
    public GameObject westDoor;

    private void Start()
    {
        if (MySingleton.thePlayer != null)
        {
            Room currentRoom = MySingleton.thePlayer.GetCurrentRoom();
            ActivateDoor(currentRoom.HasExit("north"), northDoor);
            ActivateDoor(currentRoom.HasExit("south"), southDoor);
            ActivateDoor(currentRoom.HasExit("east"), eastDoor);
            ActivateDoor(currentRoom.HasExit("west"), westDoor);
        }
        else
        {
            Debug.LogWarning("Player not found in the dungeon.");
        }
    }

    private void ActivateDoor(bool hasExit, GameObject door)
    {
        if (door != null)
        {
            door.SetActive(!hasExit);
        }
        else
        {
            Debug.LogWarning("Door GameObject is not assigned.");
        }
    }
}