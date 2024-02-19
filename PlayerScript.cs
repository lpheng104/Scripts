using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    public GameObject CenterPosition;
    public Vector3 targetPosition;

    public GameObject NorthEntrance;
    public GameObject SouthEntrance;
    public GameObject EastEntrance;
    public GameObject WestEntrance;

    public float speed = 0;
    public float SlowSpeed = 0;
    

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetPosition = CenterPosition.transform.position;
        

        CheckPosition();
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Secret Number = " + MySingleton.secretNumber);
        MySingleton.secretNumber = 5;
       
        if (other.gameObject.CompareTag("North"))
        {
            EditorSceneManager.LoadScene("Dungeon1");
            MySingleton.North = true;
            MySingleton.Middle = true;
        }
        if (other.gameObject.CompareTag("South"))
        {
            EditorSceneManager.LoadScene("Dungeon1");
            MySingleton.South = true;
            MySingleton.Middle = true;
        }
        if (other.gameObject.CompareTag("East"))
        {
            EditorSceneManager.LoadScene("Dungeon1");
            MySingleton.East = true;
            MySingleton.Middle = true;
        }
        if (other.gameObject.CompareTag("West"))
        {
            EditorSceneManager.LoadScene("Dungeon1");
            MySingleton.West = true;
            MySingleton.Middle = true;
        }
        if(other.gameObject.CompareTag("Center"))
        {
            MySingleton.Middle = false;
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
        if (MySingleton.Middle == true)
        {
            MoveToCenter();
        }

        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
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

    void MoveToCenter()
    {
         this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, targetPosition, 1);
    }
}
