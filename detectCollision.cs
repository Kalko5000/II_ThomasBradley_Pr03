using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Detect collisions between the GameObjects with Colliders attached
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided with " + other.gameObject.name);
    }
}
