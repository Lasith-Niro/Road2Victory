using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEngine : MonoBehaviour
{
    private CharacterController controller;
    public float speed = 5.0f;
    private float gravity = 10.0f;

    private Vector3 moveVector;
    private float verticalVelocity = 0.0f;

    public float animationDuration = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time < animationDuration)
        {
            // blocking key board inputs until the start animation finishes
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }
        moveVector = Vector3.zero;

        if (controller.isGrounded)
        {
            verticalVelocity = -0.5f; // like normal gravity
        } 
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        
        //X -> Left/Right
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
        //Y -> Up/Down
        moveVector.y = verticalVelocity;
        //Z -> Forword/Backword
        moveVector.z = speed; //Always go forword

        controller.Move(moveVector * Time.deltaTime);
    }
}
