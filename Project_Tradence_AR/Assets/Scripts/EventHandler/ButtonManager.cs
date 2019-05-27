using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    // Nama Scene
    public string SceneName;

    public void ChangeScene()
    {
        SceneManager.LoadScene(SceneName);
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }

}
