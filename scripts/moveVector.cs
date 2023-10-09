using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveVector : MonoBehaviour
{
    public Vector3 moveDirection;
    public float speed = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
    }
}
