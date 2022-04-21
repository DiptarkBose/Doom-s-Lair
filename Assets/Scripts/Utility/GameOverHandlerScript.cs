using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverHandlerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameOverCanvas;
    public GameObject player;
    void Start()
    {
        gameOverCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerController playerController = player.GetComponent<PlayerController>();
        if (playerController)
        {
            AttributeSet attributeSet = playerController.attributeSet;
            float curHealth = (float)attributeSet.GetType().GetField("Health").GetValue(attributeSet);
            if (curHealth <= 0)
                gameOverCanvas.SetActive(true);
        }
    }
}
