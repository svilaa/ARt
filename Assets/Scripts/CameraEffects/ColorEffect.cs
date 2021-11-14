using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class ColorEffect : CameraEffect {

    ColorCorrectionCurves effect;

    bool[] isUp = { true, true, true, true };
    float[] colorValue = { 1f, 0f, 0f, 0f };
    float[] maxValues = { 5f, 1f, 1f, 1f };
    float[] velocity = { 0.32f, 0.59f, 0.37f, 0.17f };
    float maxVelocity = 4f;
    float currentMaxVelocity;
    //float[] maxVelocity = { 4f, 4f, 4f, 4f };

    override
    protected void Init()
    {

    }

    override
    public void AttachToCamera(Camera camera)
    {
        effect = camera.gameObject.AddComponent<ColorCorrectionCurves>() as ColorCorrectionCurves;
        DefaultEffect();
    }

    void DefaultEffect()
    {
        effect.saturation = 1f;
        effect.redChannel.MoveKey(0, new Keyframe(0, 0));
        effect.redChannel.MoveKey(1, new Keyframe(1, 1));
        effect.blueChannel.MoveKey(0, new Keyframe(0, 0));
        effect.blueChannel.MoveKey(1, new Keyframe(1, 1));
        effect.greenChannel.MoveKey(0, new Keyframe(0, 0));
        effect.greenChannel.MoveKey(1, new Keyframe(1, 1));
        effect.UpdateParameters();
    }

    override
    protected void UpdateEffect()
    {
        float currentMaxVelocity = GetEvaluatedEffectValue();
        float currentLevelValue = currentMaxVelocity/2;

        if(value < 0.3f)
        {
            DefaultEffect();
            return;
        }

        for (int i = 0; i < 4; ++i)
        {
            if (isUp[i])
            {
                colorValue[i] += Time.deltaTime * velocity[i];
                if (colorValue[i] >= maxValues[i] * currentLevelValue)
                {
                    isUp[i] = false;
                    velocity[i] = Random.Range(currentLevelValue, currentMaxVelocity);
                }
            }
            else {
                colorValue[i] -= Time.deltaTime * velocity[i];
                if (colorValue[i] <= 0)
                {
                    isUp[i] = true;
                }
            }

            switch (i)
            {
                case 0:
                    effect.saturation = colorValue[i];
                    break;
                case 1:
                    effect.redChannel.MoveKey(0, new Keyframe(0, colorValue[i]));
                    effect.redChannel.MoveKey(1, new Keyframe(1, 1f - colorValue[i]));
                    break;
                case 2:
                    effect.blueChannel.MoveKey(0, new Keyframe(0, colorValue[i]));
                    effect.blueChannel.MoveKey(1, new Keyframe(1, 1f - colorValue[i]));
                    break;
                case 3:
                    effect.greenChannel.MoveKey(0, new Keyframe(0, colorValue[i]));
                    effect.greenChannel.MoveKey(1, new Keyframe(1, 1f - colorValue[i]));
                    break;
            }
        }
        effect.UpdateParameters();
    }
}
