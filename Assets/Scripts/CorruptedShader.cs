using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CorruptedShader : MonoBehaviour
{
    public float shiftX = 10;
    public float shiftY = 10;

    private Texture texture;
    private Material material;

    void Awake()
    {
        material = new Material(Shader.Find("Hidden/Distortion"));
        texture = Resources.Load<Texture>("Checkerboard-big");
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        material.SetFloat("_ValueX", shiftX);
        material.SetFloat("_ValueY", shiftY);
        material.SetTexture("_Texture", texture);
        Graphics.Blit(source, destination, material);
    }
}
