using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DIsplayScreen : MonoBehaviour
{
    float baseScreenResolution = 9f/18f;
    float widthCamera;
    float heightCamera;
    
    Camera thisCamera;
    // Start is called before the first frame update
    void Start()
    {
        thisCamera = GetComponent<Camera>();
        AdjustCamera();
    }
    // Update is called once per frame
    void Update()
    {
        AdjustCamera();
    }
    private void AdjustCamera(){
        widthCamera = Screen.width;
        heightCamera = Screen.height;
        baseScreenResolution = heightCamera/widthCamera;
        if(baseScreenResolution <= .5f){
            thisCamera.orthographicSize = 10f;
        }else{
            thisCamera.orthographicSize = 6.32f / baseScreenResolution;
        }
    }
}
