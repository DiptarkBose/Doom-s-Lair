using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuToggle : MonoBehaviour
{

    public GameObject PauseScreen;
    public GameObject health;
    public GameObject keyText;
    public GameObject keyImage;
    public GameObject armor;

    bool GamePaused;


    // Start is called before the first frame update
    void Start()
    {
        GamePaused = false;
        PauseScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if(GamePaused)
                ResumeGame();
            else
                PauseGame();
        }
        if (GamePaused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    public void PauseGame()
    {
        GamePaused = true;
        PauseScreen.SetActive(true);
        
        health.SetActive(false);
        keyText.SetActive(false);
        keyImage.SetActive(false);
        armor.SetActive(false);
    }

    public void ResumeGame()
    {
        GamePaused = false;
        PauseScreen.SetActive(false);

        health.SetActive(true);
        keyText.SetActive(true);
        keyImage.SetActive(true);
        armor.SetActive(true);
    }
}