using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    public int difficulty;

    public void Easy()
    {
        difficulty = 1;
        PlayerPrefs.SetInt("difficulty", difficulty);
        SceneManager.LoadScene("Play"); 
    }

    public void Medium()
    {
        difficulty = 2;
        PlayerPrefs.SetInt("difficulty", difficulty);
        SceneManager.LoadScene("Play");
    }

    public void Hard()
    {
        difficulty = 3;
        PlayerPrefs.SetInt("difficulty", difficulty);
        SceneManager.LoadScene("Play");
    }
}
