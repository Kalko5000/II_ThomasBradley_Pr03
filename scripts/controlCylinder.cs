using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlCylinder : MonoBehaviour
{
    public GameObject sphere;
    public float speed = 1.0f;

    private Vector3 direction;
    private Vector3 directionOp;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = sphere.transform.position - transform.position;
        direction = direction.normalized;
        directionOp = Vector3.Cross(direction, Vector3.up).normalized;
        
        if(Input.GetKey(KeyCode.I) || Input.GetKey(KeyCode.K)) {
            transform.LookAt(sphere.transform);
            transform.Translate(direction * Input.GetAxis("Vertical") * speed * Time.deltaTime, Space.World);
        }
        if(Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.L)) {
            transform.LookAt(sphere.transform);
            transform.Translate(directionOp * -Input.GetAxis("Horizontal") * speed * Time.deltaTime, Space.World);
        }
    }
}
