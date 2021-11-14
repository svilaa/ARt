using UnityEngine;
using System.Collections;

public class ChromaticAberrationEffect : CameraEffect {

    ChromaticAberration effect;

    override
    protected void Init()
    {

    }

    override
    public void AttachToCamera(Camera camera)
    {
        effect = camera.gameObject.AddComponent<ChromaticAberration>() as ChromaticAberration;
        effect.elapsed = 1f;
    }

    override
    protected void UpdateEffect()
    {
        float currentValue = GetEvaluatedEffectValue();
        effect.ChromaticAberrationRedX = Random.Range(0f, currentValue);
        effect.ChromaticAberrationRedY = Random.Range(0f, currentValue);
        effect.ChromaticAberrationGreenX = Random.Range(0f, currentValue);
        effect.ChromaticAberrationGreenY = Random.Range(0f, currentValue);
        effect.ChromaticAberrationBlueX = Random.Range(0f, currentValue);
        effect.ChromaticAberrationBlueY = Random.Range(0f, currentValue);
    }
}
