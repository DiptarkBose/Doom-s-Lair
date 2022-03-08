using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public float gravityScale;
    public CharacterController characterController;
    private Vector3 moveDirection;

    public TextMeshProUGUI keyPieceCountText;
    public TextMeshProUGUI healthText;
    public AttributeSet attributeSet;

    public Animator anim;
    public Transform pivot;
    public float rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        UpdateUI();
        attributeSet = gameObject.GetComponentInParent<AttributeSet>();
    }

    // Update is called once per frame
    void Update()
    {
        float yStore = moveDirection.y;
        moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
        moveDirection = moveDirection.normalized * moveSpeed;
        moveDirection.y = yStore;

        if (characterController.isGrounded)
        {
            //moveDirection.y = 0f;
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }
        
        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        characterController.Move(moveDirection * Time.deltaTime);

        anim.SetBool("IsGrounded", characterController.isGrounded);
        anim.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))));

        // Move the player in different directions based on Camera Look Directions
        
        if (moveDirection.x != 0 || moveDirection.z != 0)
        {
            transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, rotateSpeed*Time.deltaTime);
        }
 
        UpdateUI();
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
