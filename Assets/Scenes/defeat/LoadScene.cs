using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    public string sceneName;
    //load scene by the name of the scene
    public void LoadNewScene()
    {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
