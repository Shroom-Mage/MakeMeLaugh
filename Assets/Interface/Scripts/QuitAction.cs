using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitAction : MonoBehaviour
{
    // Start is called before the first frame update
    public void Quit()
    {
     #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
     #elif UNITY_STANDALONE
        Application.Quit();
     #endif
    }

}
