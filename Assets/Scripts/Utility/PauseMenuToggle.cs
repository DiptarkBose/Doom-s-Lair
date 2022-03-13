using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class PauseMenuToggle : MonoBehaviour
{
    CanvasGroup canvasGroup;
    public static bool gamePaused;
    // Start is called before the first frame update
    void Start()
    {
        gamePaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (canvasGroup.interactable)
            {
                canvasGroup.interactable = false;
                canvasGroup.blocksRaycasts = false;
                canvasGroup.alpha = 0f;
            }
            else
            {
                canvasGroup.interactable = true;
                canvasGroup.blocksRaycasts = true;
                canvasGroup.alpha = 1f;
            }
            gamePaused = !gamePaused;
            //PauseGame();
        }
    }

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    /*
    void PauseGame()
    {
        if (gamePaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
    */
}
