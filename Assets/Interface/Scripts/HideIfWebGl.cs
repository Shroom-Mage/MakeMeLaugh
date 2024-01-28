using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideIfWebGl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #if UNITY_WEBGL
            // Perform WebGL-specific actions here
            Debug.Log("Running in WebGL");
            // Add your WebGL-specific code here
            gameObject.SetActive(false);
        #endif

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
