using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    //public Rigidbody rb;
    public float jumpForce;
    public float gravityScale;
    public CharacterController characterController;

    private Vector3 moveDirection;
    
    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        rb.velocity = new Vector3(Input.GetAxis("Horizontal")*moveSpeed, rb.velocity.y, Input.GetAxis("Vertical") * moveSpeed);
        if(Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
        */
        moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);
        if (Input.GetButtonDown("Jump"))
        {
            moveDirection.y = jumpForce;
        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale);
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
