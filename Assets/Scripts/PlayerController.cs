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

    private int keyPieceCount;
    public TextMeshProUGUI keyPieceCountText;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        keyPieceCount = 0;
        setKeyPieceCountText();
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
            moveDirection.y = 0f;
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }
        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        characterController.Move(moveDirection * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Collectible"))
        {
            other.gameObject.SetActive(false);
            keyPieceCount++;
            setKeyPieceCountText();
        }
    }

    void setKeyPieceCountText()
    {
        keyPieceCountText.text = "Key Pieces: "+keyPieceCount+"/3";
    }
}
