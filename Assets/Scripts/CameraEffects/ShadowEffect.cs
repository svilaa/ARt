using UnityEngine;
using System.Collections;

public class ShadowEffect : CameraEffect {

    public Light ambientLight;
    public Light playerLight;

    override
    protected void Init()
    {

    }

    override
    public void AttachToCamera(Camera camera)
    {

    }

    override
    protected void UpdateEffect()
    {
        float currentValue = GetEvaluatedEffectValue();
        playerLight.intensity = currentValue;
        ambientLight.intensity = StaticTools.Map(maxValue - GetEvaluatedEffectValue(), minValue, maxValue, 0f, 1f);
    }
}
