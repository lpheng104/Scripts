using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerScript : MonoBehaviour
{

    public GameObject NorthEntrance;
    public GameObject SouthEntrance;
    public GameObject EastEntrance;
    public GameObject WestEntrance;

    public float speed = 0;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        CheckPosition();

    }

    private void OnTriggerEnter(Collider other)
    {
        print("Secret Number = " + MySingleton.secretNumber);
        MySingleton.secretNumber = 5;
        EditorSceneManager.LoadScene("Scene2");
       
        if (other.gameObject.CompareTag("North"))
        {
            MySingleton.North = true;
        }
        if (other.gameObject.CompareTag("South"))
        {
            MySingleton.South = true;
        }
        if (other.gameObject.CompareTag("East"))
        {
            MySingleton.East = true;
        }
        if (other.gameObject.CompareTag("West"))
        {
            MySingleton.West = true;
        }
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void OnTriggerExit(Collider other)
    {
       
    }
    // Update is called once per frame

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    void Update()
    {
        
    }

    void CheckPosition()
    {
        if (MySingleton.North == true)
        {
            this.gameObject.transform.position = SouthEntrance.gameObject.transform.position;
            MySingleton.North = false;
        }
        if (MySingleton.South == true)
        {
            this.gameObject.transform.position = NorthEntrance.gameObject.transform.position;
            MySingleton.South = false;
        }
        if (MySingleton.East == true)
        {
            this.gameObject.transform.position = WestEntrance.gameObject.transform.position;
            MySingleton.East = false;
        }
        if (MySingleton.West == true)
        {
            this.gameObject.transform.position = EastEntrance.gameObject.transform.position;
            MySingleton.West = false;
        }
    }
}
