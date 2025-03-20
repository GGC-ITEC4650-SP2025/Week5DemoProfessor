using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    public Vector3 step;
    
    public float moveDist;
    private float distLeft;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //move based on distance and reverse directions        
        if(distLeft > 0) {
            transform.position += (step * Time.deltaTime);
            distLeft -= step.magnitude * Time.deltaTime;
        }
        else {
            step = -1 * step;
            distLeft = moveDist;
        }
              
    }
}
