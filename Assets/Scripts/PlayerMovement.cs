﻿using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 1000f;
    public float sideSpeed = 800f;
    public float jumpForce = 5f;
    bool jumpLimit = false; // change to int for multiple jumping at once

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpLimit)
        {
            rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
            jumpLimit = false;
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
          {
              rb.AddForce(0, 0, speed * Time.deltaTime);
          }
          else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
          {
              rb.AddForce(-sideSpeed * Time.deltaTime, 0, 0);
          }
          else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
          {
              rb.AddForce(sideSpeed * Time.deltaTime, 0, 0);
          }
          else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
          {
              rb.AddForce(0, 0, -sideSpeed * Time.deltaTime);
          }
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.name)
        {
            case "Finish":
                rb.constraints = RigidbodyConstraints.FreezePosition;
                break;
            case "riverBoat":
            case "Ground":
                jumpLimit = true;
                break;
        }
    }
}
