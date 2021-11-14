using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    WebCamDevice[] devices;
    static WebCamTexture cam;
    bool frontCamera;

    // Start is called before the first frame update
    void Start()
    {
        if (cam == null)
        {
            cam = new WebCamTexture(Screen.width, Screen.height);
            frontCamera = false;
            devices = WebCamTexture.devices;
        }
        GetComponent<Renderer>().material.mainTexture = cam;

        if (!cam.isPlaying)
        {
            cam.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FlipCamera()
    {
        if (devices.Length > 1)
        {
            cam.Stop();
            if (frontCamera == true)
            {
                cam.deviceName = devices[0].name;
                frontCamera = WebCamTexture.devices[0].isFrontFacing;
            }
            else
            {
                cam.deviceName = devices[1].name;
                frontCamera = WebCamTexture.devices[1].isFrontFacing;
            }
            cam.Play();
        }
    }
}
