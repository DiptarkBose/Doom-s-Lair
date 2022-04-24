using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionCanvasControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject canvas;
    bool instructionMode;
    void Start()
    {
        canvas.SetActive(false);
        instructionMode = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            if (instructionMode)
            {
                canvas.SetActive(false);
                instructionMode = false;
            }
            else
            {
                canvas.SetActive(true);
                instructionMode = true;
            }
        }
    }
}
