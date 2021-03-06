﻿using UnityEngine;

public class PlayerController : MonoBehaviour
        
{
    //CharacterController controller;
    //public float speed = 6;
    //public float speedRun = 1;

    //private float x;
    //public Camera camera;

    //GroundVerification groundVerification;
    //GameObject player;

    //public bool isJump;
    //public float jumpHeight = 40f;
    //public bool isMove;

    ////Choper la camera, multiplier par la normale du forward de la caméra (une unité dans la direction vecteur pos  - destination)

    //private void Start()
    //{
    //    player = GameObject.FindGameObjectWithTag("Player");
    //    groundVerification = player.GetComponentInChildren<GroundVerification>();
    //    if (!groundVerification)
    //    {
    //        Debug.LogError("Component GroundVerification missing in gameObject (or in children).");
    //    }

    //    if (!camera)
    //    {
    //        camera = Camera.main;
    //    }


    //}

    //void Update()
    //{
    //    // Defaut
    //    Vector3 forward = Vector3.zero;
    //    Vector3 right = Vector3.zero;

    //    if (Input.GetButton("Vertical"))
    //    {
    //        if (Input.GetButtonUp("Vertical"))
    //        {
    //            forward = Vector3.zero;
    //            isMove = false;
    //            speed = 0;
    //        }
    //        else
    //        {
    //            speed = 6;
    //            forward = camera.transform.forward * Input.GetAxis("Vertical") * speed * speedRun ;
    //            forward.y = 0f; 
    //            Vector3 rotation = camera.transform.rotation.eulerAngles;
    //            rotation.x = 0f;
    //            rotation.z = 0f;

    //            transform.rotation = Quaternion.Euler(rotation);
    //            isMove = true;
    //            speedRun = 1;
    //        }

    //    }

    //    if (Input.GetButton("Horizontal"))
    //    {
    //        if (Input.GetButtonUp("Horizontal"))
    //        {
    //            right = Vector3.zero;

    //        }
    //        else
    //        {
    //            right = camera.transform.right * Input.GetAxis("Horizontal") * speed;
    //            right.x = 0f;

    //        }

    //    }

    //    if (groundVerification.isGrounded || isJump)
    //    {
    //        GetComponent<Rigidbody>().velocity = forward;
    //    }

    //    if (Input.GetButton("Jump"))
    //    {
    //        if (groundVerification.isGrounded)
    //        {
    //            GetComponent<Rigidbody>().velocity += Vector3.up * jumpHeight;

    //        }

    //    }

    //    if (Input.GetButton("Sprint"))
    //    {
    //        if (isMove)
    //        {
    //            speedRun = 3;
    //        }

    //    }



    //}


    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        // let the gameObject fall down
        gameObject.transform.position = new Vector3(0, 5, 0);
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection = moveDirection * speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        // Apply gravity
        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

        // Move the controller
        controller.Move(moveDirection * Time.deltaTime);
    }

    }