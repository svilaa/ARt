using UnityEngine;
using System.Collections;
using MorePPEffects;

public class WiggleEffect : CameraEffect {

    Wiggle effect;

    override
    protected void Init()
    {
        
    }

    override
    public void AttachToCamera(Camera camera)
    {
        effect = camera.gameObject.AddComponent<Wiggle>() as Wiggle;
    }

    override
    protected void UpdateEffect()
    {
        float value = GetEvaluatedEffectValue();
        effect.amplitudeX = value * Scale(currentRandomNumbers[0], 0f, 1f, 0f, 40f);
        effect.amplitudeY = value * Scale(currentRandomNumbers[1], 0f, 1f, 0f, 40f);
        effect.distortionX = value * Scale(currentRandomNumbers[2], 0f, 1f, 0f, 2f);
        effect.distortionY = value * Scale(currentRandomNumbers[3], 0f, 1f, 0f, 2f);
        effect.speed = value * Scale(currentRandomNumbers[4], 0f, 1f, 0f, 5f);
    }
}
