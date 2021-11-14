using UnityEngine;
using System.Collections;
using MorePPEffects;

public class FOVEffect : CameraEffect {

    Lens effect;

    override
    protected void Init()
    {

    }

    override
    public void AttachToCamera(Camera camera)
    {
        effect = camera.gameObject.AddComponent<Lens>() as Lens;
        effect.cubicDistortion = 0f;
    }

    override
    protected void UpdateEffect()
    {
        effect.lensDistortion = GetEvaluatedEffectValue();
    }
}
