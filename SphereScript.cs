using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        print("inside Sphere Sciprt");
        print("SecretNumber = " + MySingleton.secretNumber);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
