using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class Player1 : MonoBehaviour
{

    private Player thePlayer;
    public TextMeshPro nametag1;
    public GameObject destinationGO;

    public Vector3 targetPosition;
    public float speed = 10;

    void Start()
    {
        //Vector3.moveTowards
        this.thePlayer = new Player("Bungus");
        //thePlayer.display();
        //SetNametag1();
        nametag1.text = "Name: " + thePlayer.Name + " HP: " + thePlayer.HP;
        //this.gameObject.transform.position = this.destinationGO.transform.position;
        targetPosition = destinationGO.transform.position;
    }
    void SetNametag1()
    {
        nametag1.text = "Name: " + thePlayer.Name + " HP: " + thePlayer.HP;
    }

    void Update()
    {
        if (Vector3.Distance(this.gameObject.transform.position, this.destinationGO.transform.position) > 1.0f) ;
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, targetPosition, speed * Time.deltaTime);
        }
    }
}
