using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class Player2 : MonoBehaviour
{
    private Player thePlayer;
    public TextMeshPro nametag1;

    void Start()
    {
        this.thePlayer = new Player("Bingus");
        //thePlayer.display();
        //SetNametag1();
        nametag1.text = "Name: " + thePlayer.Name + " HP: " + thePlayer.HP;
    }
    void SetNametag1()
    {
        nametag1.text = "Name: " + thePlayer.Name + " HP: " + thePlayer.HP;
    }

    void Update()
    {

    }

}
