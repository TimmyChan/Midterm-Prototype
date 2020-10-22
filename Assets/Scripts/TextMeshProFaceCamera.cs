using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMeshProFaceCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // make textbox always face the camera 
        this.transform.rotation = Camera.main.transform.rotation;
    }
}
