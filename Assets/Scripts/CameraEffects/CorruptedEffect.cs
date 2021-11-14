using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorruptedEffect : CameraEffect
{
    CorruptedShader effect;
    private Texture texture;
    private Material material;

    override
    protected void Init()
    {

    }

    override
    public void AttachToCamera(Camera camera)
    {
        effect = camera.gameObject.AddComponent<CorruptedShader>() as CorruptedShader;
    }

    override
    protected void UpdateEffect()
    {
        float length = GetEvaluatedEffectValue();
        effect.shiftX = length * Scale(currentRandomNumbers[0], 0f, 1f, 0.5f, 1.0f);
        effect.shiftY = length * Scale(currentRandomNumbers[1], 0f, 1f, 0.5f, 1.0f);
    }
}
