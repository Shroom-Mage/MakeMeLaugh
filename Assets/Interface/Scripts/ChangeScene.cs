using System;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    [SerializeField]
    public String sceneToLoad;

    // Start is called before the first frame update
    public void LoadScene()
    {
        Console.WriteLine("Loading scene " + sceneToLoad);
        SceneManager.LoadScene(sceneToLoad);
    }

}
