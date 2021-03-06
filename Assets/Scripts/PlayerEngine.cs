﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEngine : MonoBehaviour
{
    private CharacterController controller;
    public float speed = 5.0f;
    private float gravity = 10.0f;

    private Vector3 moveVector;
    private float verticalVelocity = 0.0f;

    public float animationDuration = 3.0f;

    private bool isDead = false;
    private float startTime;

    public Text coinScore;
    private int totalCoins;

    public float jumpSpeed = 10.0f;
    private bool onGround = true;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        //rb = GetComponent<Rigidbody>();
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown("space") && onGround)
        {
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            onGround = false;
        }
        */
        if (isDead)
        {
            return;
        }
        if(Time.time - startTime < animationDuration)
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

        coinScore.text = ((int)totalCoins).ToString();
    }

    public void SetSpeed(float value)
    {
        speed += value;
    }
    
    // if arthur collide this callback will fires up
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "Coin")
        {
            //play sound + add to coin score
            totalCoins++;
            FindObjectOfType<AudioManager>().Play("coin");
            Destroy(hit.gameObject);
        }

        if (hit.point.z > transform.position.z + controller.radius && !( hit.gameObject.tag== "Coin"))
        {
            Death();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Tile")
        {
            onGround = true;
        }
    }

    private void Death()
    {
        FindObjectOfType<AudioManager>().Stop("background");
        FindObjectOfType<AudioManager>().Play("end");
        isDead = true;
        GetComponent<Score>().onDeath();
        //Debug.Log("dead");
    }
}
