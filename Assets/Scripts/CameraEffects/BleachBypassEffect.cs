using UnityEngine;
using System.Collections;
using MorePPEffects;

public class BleachBypassEffect : CameraEffect {

    BleachBypass effect;

    override
    protected void Init()
    {
        
    }

    override
    public void AttachToCamera(Camera camera)
    {
        effect = camera.gameObject.AddComponent<BleachBypass>() as BleachBypass;
    }

    override
    protected void UpdateEffect()
    {
        float value = GetEvaluatedEffectValue();
        effect.darkness = value;
    }
}
