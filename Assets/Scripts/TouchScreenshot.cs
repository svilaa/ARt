using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchScreenshot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            TakeScreenshot();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void OnMouseDown()
    {
        Debug.Log("Screenshot");
        TakeScreenshot();
    }

    public void TakeScreenshot()
    {
        System.DateTime currentDatetime = System.DateTime.Now;
        string filename = "ARt_" + Random.Range(0, 1000).ToString() + currentDatetime.ToString("yyyy-MM-dd\\THH_mm_ss");
        Debug.Log(filename);
#if UNITY_EDITOR || UNITY_UNITY_STANDALONE
        ScreenCapture.CaptureScreenshot(Application.persistentDataPath + "/" + filename + ".jpg");
#elif UNITY_ANDROID
        ScreenCapture.CaptureScreenshot(filename + ".jpg");
#endif
    }
}
