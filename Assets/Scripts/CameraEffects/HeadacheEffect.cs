using UnityEngine;
using System.Collections;
using MorePPEffects;

public class HeadacheEffect : CameraEffect {

    Headache effect;

    override
    protected void Init()
    {
        
    }

    override
    public void AttachToCamera(Camera camera)
    {
        effect = camera.gameObject.AddComponent<Headache>() as Headache;
    }

    override
    protected void UpdateEffect()
    {
        float value = GetEvaluatedEffectValue();
        effect.strength = value;
        effect.speed = value;
    }
}
