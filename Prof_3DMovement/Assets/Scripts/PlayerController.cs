using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float rotSpeed;

    public float jumpSpeed;
    private float yVel;

    private Vector3 myRot;

    CharacterController myCon;



    // Start is called before the first frame update
    void Start()
    {
        myCon = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 step = h * transform.right + v * transform.forward;
        
        //JUMPING and FALLING
        if(!myCon.isGrounded) {
            yVel -= 10 * Time.deltaTime;
            transform.parent = null;
        }
        else if(Input.GetButtonDown("Jump")) {
            yVel = jumpSpeed;
        }
        else {
            yVel = -1;
        }
        Vector3 move = step * speed;
        move.y = yVel;        
        myCon.Move(move * Time.deltaTime);

        float mx = Input.GetAxis("Mouse X");
        Vector3 rotStep = mx * Vector3.up;
        myRot += rotStep * rotSpeed * Time.deltaTime;
        transform.localEulerAngles = myRot;
    }

    void OnControllerColliderHit(ControllerColliderHit hit) {
        GameObject otherGo = hit.gameObject;
        if(otherGo.name == "Platform") {
            transform.parent = otherGo.transform;
        }
    }
}
