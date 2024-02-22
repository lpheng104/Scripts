using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class LitmansCode : MonoBehaviour
{
    public GameObject northExit;
    public GameObject southExit;
    public GameObject eastExit;
    public GameObject westExit;
    public GameObject middleOfTheRoom;

    public GameObject northExitBlocker;
    public GameObject southExitBlocker;
    public GameObject eastExitBlocker;
    public GameObject westExitBlocker;

    private float speed = 5.0f;
    private bool amMoving = false;
    private bool amAtMiddleOfRoom = false;
    private int NumExits;
    private int randomNumber;


    private void turnOffExits()
    {
        this.northExit.gameObject.SetActive(false);
        this.southExit.gameObject.SetActive(false);
        this.eastExit.gameObject.SetActive(false);
        this.westExit.gameObject.SetActive(false);

    }

    private void turnOnExits()
    {
        this.northExit.gameObject.SetActive(true);
        this.southExit.gameObject.SetActive(true);
        this.eastExit.gameObject.SetActive(true);
        this.westExit.gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = this.gameObject.GetComponent<Rigidbody>();

        //disable all exits when the scene first loads
        this.turnOffExits();

        //disable the middle collider until we know what our initial state will be
        //it should already be disabled by default, but for clarity, lets do it here
        this.middleOfTheRoom.SetActive(false);

          randomNumber = UnityEngine.Random.Range(1, 4);

        NumExits = (int)randomNumber;


        if (!LitmansSingleton.currentDirection.Equals("?"))
        {
            //mark ourselves as moving since we are entering the scene through one of the exits
            this.amMoving = true;

            //we will be positioning the player by one of the exits so we can turn on the middle collider
            this.middleOfTheRoom.SetActive(true);
            this.amAtMiddleOfRoom = false;

            if (LitmansSingleton.currentDirection.Equals("north"))
            {
                this.gameObject.transform.position = this.southExit.transform.position;
                this.gameObject.transform.LookAt(this.northExit.transform.position);
                //rb.MovePosition(this.southExit.transform.position);
            }
            else if (LitmansSingleton.currentDirection.Equals("south"))
            {
                this.gameObject.transform.position = this.northExit.transform.position;
                this.gameObject.transform.LookAt(this.southExit.transform.position);
                //rb.MovePosition(this.northExit.transform.position);
            }
            else if (LitmansSingleton.currentDirection.Equals("west"))
            {
                this.gameObject.transform.position = this.eastExit.transform.position;
                this.gameObject.transform.LookAt(this.westExit.transform.position);
                //rb.MovePosition(this.eastExit.transform.position);
            }
            else if (LitmansSingleton.currentDirection.Equals("east"))
            {
                this.gameObject.transform.position = this.westExit.transform.position;
                this.gameObject.transform.LookAt(this.eastExit.transform.position);
                //rb.MovePosition(this.westExit.transform.position);
            }
            //StartCoroutine(turnOnMiddle());
        }
        else
        {
            //We will be positioning the play at the middle
            //so keep the middle collider off for this run of the scene
            this.amMoving = false;
            this.amAtMiddleOfRoom = true;
            this.middleOfTheRoom.SetActive(false);
            this.gameObject.transform.position = this.middleOfTheRoom.transform.position;
        }
    }

    /*
    IEnumerator turnOnMiddle()
    {
        yield return new WaitForSeconds(1);
        this.middleOfTheRoom.SetActive(true);
        print("turned on");

    }
    */

    private void OnTriggerEnter(Collider other)
    {
        NumExits = randomNumber;
        print(other.tag);
        if (other.CompareTag("door"))
        {
            print("Loading scene");

            EditorSceneManager.LoadScene("Dungeon1");
        }
        else if (other.CompareTag("middleOfTheRoom") && !LitmansSingleton.currentDirection.Equals("?"))
        {
            //we have hit the middle of the room, so lets turn off the collider
            //until the next run of the scene to avoid additional collisions
            this.middleOfTheRoom.SetActive(false);
            this.turnOnExits();

            print("middle");
            this.amAtMiddleOfRoom = true;
            this.amMoving = false;
            LitmansSingleton.currentDirection = "middle";
        }
        else
        {
            print("spomethilskdfjskldjfsdjkl");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (NumExits == 1)
        {
            this.northExitBlocker.gameObject.SetActive(true);
            this.southExitBlocker.gameObject.SetActive(true);
            this.eastExitBlocker.gameObject.SetActive(true);
            this.westExitBlocker.gameObject.SetActive(false);
        }

        if(NumExits == 2)
        {
            this.northExitBlocker.gameObject.SetActive(false);
            this.southExitBlocker.gameObject.SetActive(false);
            this.eastExitBlocker.gameObject.SetActive(true);
            this.westExitBlocker.gameObject.SetActive(true);
        }

        if (NumExits == 3)
        {
            this.northExitBlocker.gameObject.SetActive(true);
            this.southExitBlocker.gameObject.SetActive(false);
            this.eastExitBlocker.gameObject.SetActive(true);
            this.westExitBlocker.gameObject.SetActive(true);
        }

        if (NumExits == 4)
        {
            this.northExitBlocker.gameObject.SetActive(true);
            this.southExitBlocker.gameObject.SetActive(true);
            this.eastExitBlocker.gameObject.SetActive(true);
            this.westExitBlocker.gameObject.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) && !this.amMoving)
        {
            this.amMoving = true;
            this.turnOnExits();
            LitmansSingleton.currentDirection = "north";
            this.gameObject.transform.LookAt(this.northExit.transform.position);
        }

        if (Input.GetKeyUp(KeyCode.DownArrow) && !this.amMoving)
        {
            this.amMoving = true;
            this.turnOnExits();
            LitmansSingleton.currentDirection = "south";
            this.gameObject.transform.LookAt(this.southExit.transform.position);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) && !this.amMoving)
        {
            this.amMoving = true;
            this.turnOnExits();
            LitmansSingleton.currentDirection = "west";
            this.gameObject.transform.LookAt(this.westExit.transform.position);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) && !this.amMoving)
        {
            this.amMoving = true;
            this.turnOnExits();
            LitmansSingleton.currentDirection = "east";
            this.gameObject.transform.LookAt(this.eastExit.transform.position);

        }

        //make the player move in the current direction
        if (LitmansSingleton.currentDirection.Equals("north"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.northExit.transform.position, this.speed * Time.deltaTime);
        }

        if (LitmansSingleton.currentDirection.Equals("south"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.southExit.transform.position, this.speed * Time.deltaTime);
        }

        if (LitmansSingleton.currentDirection.Equals("west"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.westExit.transform.position, this.speed * Time.deltaTime);
        }

        if (LitmansSingleton.currentDirection.Equals("east"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.eastExit.transform.position, this.speed * Time.deltaTime);
        }

    }
}