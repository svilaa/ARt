using UnityEngine;
using System.Collections;
using MorePPEffects;

public class WavesEffect : CameraEffect {

    Waves effect;

    override
    protected void Init()
    {
        
    }

    override
    public void AttachToCamera(Camera camera)
    {
        effect = camera.gameObject.AddComponent<Waves>() as Waves;
    }

    override
    protected void UpdateEffect()
    {
        float value = GetEvaluatedEffectValue();
        effect.strengthX = value;
        effect.strengthY = value;
    }
}
