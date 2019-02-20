using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera[] camera;
    private int currentCam;

    // Start is called before the first frame update
    void Start()
    {
        currentCam = 0;
        
        if(camera.Length > 0){
            disableAll();
            camera[currentCam].enabled = true;
        }
    }

    public bool switchCamera(int x)
    {
        if (x < 0 || x >= camera.Length)
            return false;

        camera[currentCam].enabled = false;
        camera[x].enabled = true;
        currentCam = x;
        return true;
    }

    private void disableAll()
    {
        for (int i = 0; i < camera.Length; i++)
            camera[i].enabled = false;
    }
}
