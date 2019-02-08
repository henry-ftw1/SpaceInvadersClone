using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject menu;
    public bool paused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                Resume();
            }
            else
            {
                Stop();
            }
        }
    }

    public void Resume()
    {
        paused = false;
        menu.SetActive(false);
        Time.timeScale = 1f;
    }

    void Stop()
    {
        paused = true;
        Time.timeScale = 0f;
        menu.SetActive(true);
    }
}
