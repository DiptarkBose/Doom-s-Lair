using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody rb; // why was this commented?

    private int redBallCount;
    private int blueBallCount;

    private int health;

    public TextMeshProUGUI healthCount;

    public float jumpForce;
    public float gravityScale;
    public CharacterController characterController;

    private Vector3 moveDirection;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();
        

        redBallCount = 0;
        blueBallCount = 0;
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
        //moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);
        
        float yStore = moveDirection.y;
        moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
        moveDirection = moveDirection.normalized * moveSpeed;
        moveDirection.y = yStore;

        if (characterController.isGrounded)
        {
            moveDirection.y = 0f;
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }
        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        characterController.Move(moveDirection * Time.deltaTime);
    }

    void setCountText()
    {
        healthCount.text = "Health: " + health.ToString();
        
        //winTextObject.SetActive(true);
        
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("RedBall"))
        {
            health++;
            setCountText();
            Debug.Log("I collide");
        }
    }
}
