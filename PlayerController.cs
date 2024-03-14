using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public GameObject northExit;
    public GameObject southExit;
    public GameObject eastExit;
    public GameObject westExit;
    public GameObject middleOfTheRoom;

    private float speed = 5.0f;
    private bool amMoving = false;
    private bool amAtMiddleOfRoom = false;

    private void TurnOffExits()
    {
        northExit.gameObject.SetActive(false);
        southExit.gameObject.SetActive(false);
        eastExit.gameObject.SetActive(false);
        westExit.gameObject.SetActive(false);
    }

    private void TurnOnExits()
    {
        northExit.gameObject.SetActive(true);
        southExit.gameObject.SetActive(true);
        eastExit.gameObject.SetActive(true);
        westExit.gameObject.SetActive(true);
    }

    void Start()
    {
        TurnOffExits();
        middleOfTheRoom.SetActive(false);

        if (!MySingleton.currentDirection.Equals("?"))
        {
            amMoving = true;
            middleOfTheRoom.SetActive(true);
            amAtMiddleOfRoom = false;

            if (MySingleton.currentDirection.Equals("north"))
            {
                transform.position = southExit.transform.position;
                transform.LookAt(northExit.transform.position);
            }
            else if (MySingleton.currentDirection.Equals("south"))
            {
                transform.position = northExit.transform.position;
                transform.LookAt(southExit.transform.position);
            }
            else if (MySingleton.currentDirection.Equals("west"))
            {
                transform.position = eastExit.transform.position;
                transform.LookAt(westExit.transform.position);
            }
            else if (MySingleton.currentDirection.Equals("east"))
            {
                transform.position = westExit.transform.position;
                transform.LookAt(eastExit.transform.position);
            }
        }
        else
        {
            amMoving = false;
            amAtMiddleOfRoom = true;
            middleOfTheRoom.SetActive(false);
            transform.position = middleOfTheRoom.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("door"))
        {
            MySingleton.thePlayer.LeaveRoom();
            EditorSceneManager.LoadScene("Dungeon1");
        }
        else if (other.CompareTag("middleOfTheRoom") && !MySingleton.currentDirection.Equals("?"))
        {
            middleOfTheRoom.SetActive(false);
            TurnOnExits();
            amAtMiddleOfRoom = true;
            amMoving = false;
            MySingleton.currentDirection = "middle";
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow) && !amMoving && MySingleton.thePlayer.GetCurrentRoom().HasExit("north"))
        {
            amMoving = true;
            TurnOnExits();
            MySingleton.currentDirection = "north";
            transform.LookAt(northExit.transform.position);
        }
        // Similar checks for other directions...

        // Make the player move in the current direction
        if (MySingleton.currentDirection.Equals("north"))
        {
            transform.position = Vector3.MoveTowards(transform.position, northExit.transform.position, speed * Time.deltaTime);
        }
        // Similar checks for other directions...
    }
}