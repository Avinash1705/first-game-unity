using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{      
    public CharacterController controller;
    public float speed =12f;
    UnityEngine.Vector3 velocity;
    bool isGrounded;
    public float gravity = -9.8f;
    //jump
    public float jumpHeight = 6.0f;

    public Transform groundCheck;
    public float groundDistance =0.4f;
    public LayerMask groundMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position ,groundDistance,groundMask);
        if(isGrounded && velocity.y < 0){
            velocity.y =-2f;
        }

        float x =Input.GetAxis("Horizontal");
        float z =Input.GetAxis("Vertical");
        UnityEngine.Vector3 move =transform.right *x +transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        bool spacebar= Input.GetButtonDown("Jump");
        Debug.Log("before jump"+spacebar);
        //jump on spacebar
        if(Input.GetKeyDown(KeyCode.Space) ){
            Debug.Log("jump");
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        
        velocity.y +=gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
