using UnityEngine;
using System.Collections;
using MorePPEffects;

public class SobelEffect : CameraEffect {

    Sobel effect;

    override
    protected void Init()
    {
        
    }

    override
    public void AttachToCamera(Camera camera)
    {
        effect = camera.gameObject.AddComponent<Sobel>() as Sobel;
    }

    override
    protected void UpdateEffect()
    {
        float value = GetEvaluatedEffectValue();
        effect.threshold = value;
    }
}
