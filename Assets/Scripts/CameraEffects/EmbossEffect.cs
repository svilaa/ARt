using UnityEngine;
using System.Collections;
using MorePPEffects;

public class EmbossEffect : CameraEffect {

    Emboss effect;

    override
    protected void Init()
    {
        
    }

    override
    public void AttachToCamera(Camera camera)
    {
        effect = camera.gameObject.AddComponent<Emboss>() as Emboss;
    }

    override
    protected void UpdateEffect()
    {
        float value = GetEvaluatedEffectValue();
        effect.strength = value;
    }
}
