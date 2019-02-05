﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    
    public void ChooseLevel(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void CloseApplication()
    {
        Application.Quit();
    }
}
