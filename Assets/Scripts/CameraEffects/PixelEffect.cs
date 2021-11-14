using UnityEngine;
using System.Collections;

public class PixelEffect : CameraEffect {

    MorePPEffects.LowResolutionEffect effect;

    float ratio;

	override
	protected void Init ()
    {
        ratio = ((float)Screen.width) / Screen.height;
	}

    override
    public void AttachToCamera (Camera camera)
    {
        effect = camera.gameObject.AddComponent<MorePPEffects.LowResolutionEffect>() as MorePPEffects.LowResolutionEffect;
    }

    override
    protected void UpdateEffect () {
        effect.resolutionX = (int)GetEvaluatedEffectValue();
        effect.resolutionY = (int)(effect.resolutionX / ratio);
    }

}
