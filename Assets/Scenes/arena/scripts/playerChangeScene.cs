using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerChangeScene : MonoBehaviour
{
    public void LoadNewScene()
    {
        if (PlayerPrefs.GetInt("victoryCount") == 5)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Victory");
            PlayerPrefs.SetInt("victoryCount", 0);
        }
        else
        {
            if (PlayerPrefs.HasKey("victoryCount"))
            {
                PlayerPrefs.SetInt("victoryCount", PlayerPrefs.GetInt("victoryCount") + 1);
                UnityEngine.SceneManagement.SceneManager.LoadScene("arenaScene");
            }
            else
            {
                PlayerPrefs.SetInt("victoryCount", 0);
                UnityEngine.SceneManagement.SceneManager.LoadScene("arenaScene");
            }
        }
    }
}
