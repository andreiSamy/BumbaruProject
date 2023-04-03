using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Animator animator;
    public CharacterController controller;
    private Vector3 direction;
    public float speed = 8f;
    public float jumpForce = 10f;
    public float gravity = -20f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Transform model;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
        float hInput = Input.GetAxis("Horizontal");
        direction.x = hInput * speed;


        animator.SetFloat("speed", Mathf.Abs(hInput));
        bool isGrounded = Physics.CheckSphere(groundCheck.position, 0.15f, groundLayer);

        direction.y += gravity * Time.deltaTime;
        if (isGrounded)
        {

            if (Input.GetButtonDown("Jump"))
            {
            direction.y = jumpForce;
        
            }
        }
        if(hInput !=0)
        {
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(hInput, 0, 0));
            model.rotation = newRotation;
        }


        controller.Move(direction * Time.deltaTime);
    }
}
