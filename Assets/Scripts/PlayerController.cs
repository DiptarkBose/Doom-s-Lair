using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.UI;

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
    public AudioSource audioSource;
    public Slider healthSlider;


    public TextMeshProUGUI keyPieceCountText;
    public TextMeshProUGUI healthText;
    public Animator anim;
 

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        attributeSet = gameObject.GetComponentInParent<AttributeSet>();
        audioSource = GetComponent<AudioSource>();
        UpdateUI();
    }

    void Update()
    {
        Move();
        Rotate();
        UpdateUI();

        anim.SetBool("IsGrounded", characterController.isGrounded);
        float side = Input.GetAxis("Horizontal");
        float straight = Input.GetAxis("Vertical");
        float curSpeed = (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal")));

        // animator settings
        if (side < 0)
        {
            anim.SetBool("Left", true);
            anim.SetBool("Right", false);
        }
        else if (side > 0)
        {
            anim.SetBool("Right", true);
            anim.SetBool("Left", false);
        }
        else
        {
            anim.SetBool("Left", false);
            anim.SetBool("Right", false);
        }

        if (straight < 0)
            anim.SetBool("Back", true);
        else if (straight > 0)
            anim.SetBool("Back", false);
        else
            anim.SetBool("Back", false);
        anim.SetFloat("Speed", curSpeed);

        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Attack");
        }
        if (Input.GetMouseButtonDown(1))
        {
            anim.SetTrigger("Kick");
        }

        // audio settings
        if (curSpeed > 0)
        {
            if(!audioSource.isPlaying)
                audioSource.Play();
        }
        else
            audioSource.Stop();
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
        setHealthBar();
    }

    /*
    void setKeyPieceCountText()
    {
        keyPieceCountText.text = "Key Pieces: " + attributeSet.KeyPieceCount + "/3";
    }
    */

    void setHealthBar()
    {
        healthSlider.value = attributeSet.Health;
    }

}
