using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] 
    private float moveSpeed;

    [SerializeField]
    private float lookSensitivity;

    [SerializeField]
    private float jumpHeight = 10;

    [SerializeField]
    private float gravity = 9.81f;

    private CharacterController characterController;
    private Vector2 moveVector;
    private Vector2 lookVector;
    private Vector3 rotation;
    private float verticalVelocity;
    public AttributeSet attributeSet;

 
    public TextMeshProUGUI keyPieceCountText;
    public TextMeshProUGUI healthText;
    public Animator anim;
 

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        attributeSet = gameObject.GetComponentInParent<AttributeSet>();
        UpdateUI();
    }

    void Update()
    {
        Move();
        Rotate();
        UpdateUI();

        anim.SetBool("IsGrounded", characterController.isGrounded);
        anim.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))));
        /*
        if(moveVector.x > 0 || moveVector.y > 0)
        {
            anim.SetFloat("Speed", 5);
        }
        */
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        lookVector = context.ReadValue<Vector2>();
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if(characterController.isGrounded && context.performed)
        {
            Jump();
        }
    }

    private void Move()
    {
        verticalVelocity += -gravity*Time.deltaTime;

        if(characterController.isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -0.1f * gravity * Time.deltaTime;
        }
        Vector3 move = (transform.right*moveVector.x) + (transform.forward*moveVector.y) + (transform.up * verticalVelocity);
        characterController.Move(move * moveSpeed * Time.deltaTime);
    }

    private void Rotate()
    {
        rotation.y += (lookVector.x * lookSensitivity * Time.deltaTime);
        transform.localEulerAngles = rotation;
    }

    private void Jump()
    {
        verticalVelocity = Mathf.Sqrt(jumpHeight * gravity);
    }

    
    public void UpdateUI()
    {
        setKeyPieceCountText();
        setHealthText();
    }

    void setKeyPieceCountText()
    {
        keyPieceCountText.text = "Key Pieces: " + attributeSet.KeyPieceCount + "/3";
    }

    void setHealthText()
    {
        healthText.text = "Health: " + attributeSet.Health;
    }

}
