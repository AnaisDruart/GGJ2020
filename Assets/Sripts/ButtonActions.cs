using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActions : MonoBehaviour
{

    public GameObject buttonActionsUI;
    public GameObject helpControlsUI;

    private void Start()
    {
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (Input.GetKey("escape"))
        {
            Play();
        }
    }

    public void Play()
    {
        buttonActionsUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ControlsHelp()
    {
        helpControlsUI.SetActive(true);
    }
}
