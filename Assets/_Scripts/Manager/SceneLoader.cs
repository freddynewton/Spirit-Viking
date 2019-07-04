using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SceneLoader : MonoBehaviour
{
    public string Scene;

    public void loadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(Scene);
    }
}
