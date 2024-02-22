using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Room r = new Room("a room");
        LitmansSingleton.addRoom(r);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
