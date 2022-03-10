using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int KeyThreshHold;
    public GameObject winText;
    public GameObject cannotWinText;

    private void Start()
    {
        winText.SetActive(false);
        cannotWinText.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerController playerController = other.GetComponent<PlayerController>();
        if (playerController)
        {
            if (playerController.attributeSet.KeyPieceCount >= KeyThreshHold)
            {
                winText.SetActive(true);
            }
            else
            {
                cannotWinText.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        cannotWinText.SetActive(false);
    }
}
