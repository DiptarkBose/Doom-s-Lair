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
    private int playerHealth;
    public TextMeshProUGUI keyPieceCountText;
    public TextMeshProUGUI healthText;
    public GameObject cannotWinText;
    public GameObject winText;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        keyPieceCount = 0;
        playerHealth = 100;
        setKeyPieceCountText();
        setHealthText();
        cannotWinText.SetActive(false);
        winText.SetActive(false);
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
        else if(other.CompareTag("Poison"))
        {
            playerHealth -= 10;
            setHealthText();
        }
        else if(other.CompareTag("Door"))
        {
            if(keyPieceCount < 3)
            {
                cannotWinText.SetActive(true);
            }
            else
            {
                winText.SetActive(true);
            }
        }
        else if(other.CompareTag("Health"))
        {
            playerHealth = Mathf.Clamp(playerHealth + 10, 0, 100);
            setHealthText();
            Destroy(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            if (keyPieceCount < 3)
            {
                cannotWinText.SetActive(false);
            }
        }
    }

    void setKeyPieceCountText()
    {
        keyPieceCountText.text = "Key Pieces: "+keyPieceCount+"/3";
    }

    void setHealthText()
    {
        healthText.text = "Health: " + playerHealth;
    }
}
