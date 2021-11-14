using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadRatio : MonoBehaviour
{
    // Source  https://forum.unity.com/threads/align-camera-to-plane-quad-boundaries.165522/
    public ScreenScaleMode scaleMode = ScreenScaleMode.ScaleToWidthAndHeight;

    public enum ScreenScaleMode
    {
        ScaleToWidthAndHeight,
        ScaleToWidthOnly,
        ScaleToHeightOnly
    }

    // Update is called once per frame
    void Update()
    {
        float quadDepth = Camera.main.transform.position.z - transform.position.z;

        Vector3 tr = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, quadDepth));
        Vector3 tl = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, quadDepth));

        // DEFAULT: Scale To Width & Height
        float aspectRatio = transform.localScale.y / transform.localScale.x;
        float widthScale = (tl.x - tr.x);
        float heightScale = widthScale;

        // WIDTH ONLY?
        if (scaleMode == ScreenScaleMode.ScaleToWidthOnly)
        {
            heightScale = widthScale * aspectRatio;
        }

        // HEIGHT ONLY?
        else if (scaleMode == ScreenScaleMode.ScaleToHeightOnly)
        {
            widthScale = heightScale / aspectRatio;
        }

        transform.localScale = new Vector3(-widthScale, -heightScale, 1);


    }
}
