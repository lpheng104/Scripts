using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class LitmansCode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("onCollision");
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Secret Number = " + MySingleton.secretNumber);
        MySingleton.secretNumber = 5;
        EditorSceneManager.LoadScene("Scene2");
    }

    private void OnTriggerExit(Collider other)
    {
        print("onTriggerExit");

    }
    // Update is called once per frame
    void Update()
    {

    }
}