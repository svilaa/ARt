using UnityEngine;
using System.Collections;
using MorePPEffects;

public class PosterizationEffect : CameraEffect {

    Posterization effect;

    override
    protected void Init()
    {
        
    }

    override
    public void AttachToCamera(Camera camera)
    {
        effect = camera.gameObject.AddComponent<Posterization>() as Posterization;
    }

    override
    protected void UpdateEffect()
    {
        float value = GetEvaluatedEffectValue();
        effect.tonesAmount = value;
    }
}
