using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class axisVelocity : MonoBehaviour
{
    public float velocity;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("up")) {
            Debug.Log("Se ha pulsado flecha arriba: H -> " + Input.GetAxis("Horizontal") * velocity +
                      " | V -> " +  Input.GetAxis("Vertical") * velocity);
        } else if (Input.GetKeyDown("down")) {
            Debug.Log("Se ha pulsado flecha abajo: H -> " + Input.GetAxis("Horizontal") * velocity +
                      " | V -> " +  Input.GetAxis("Vertical") * velocity);
        } else if (Input.GetKeyDown("left")) {
            Debug.Log("Se ha pulsado flecha izquierda: H -> " + Input.GetAxis("Horizontal") * velocity +
                      " | V -> " +  Input.GetAxis("Vertical") * velocity);
        } else if (Input.GetKeyDown("right")) {
            Debug.Log("Se ha pulsado flecha derecha: H -> " + Input.GetAxis("Horizontal") * velocity +
                      " | V -> " +  Input.GetAxis("Vertical") * velocity);
        }
    }
}
