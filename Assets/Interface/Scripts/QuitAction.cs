using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitAction : MonoBehaviour
{
   private float pauseDuration=2.5f;

    // Start is called before the first frame update
    public void Quit()
    {
      Invoke("ActuallyQuit", pauseDuration);
    }

   public void ActuallyQuit()
   {

     #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
     #elif UNITY_STANDALONE
        Application.Quit();
     #endif
   }
}
