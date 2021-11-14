using UnityEngine;
using System.Collections;

public class RadialBlurEffect : CameraEffect {

    MorePPEffects.RadialBlur effect;

    public Vector2 targetScreenPos;
    public Vector2 lastScreenPos;
    public Vector2 currentScreenPos;
    public float movementLimitTime;
    public float movementCurrentTime;

	override
	protected void Init ()
    {
        targetScreenPos = new Vector2(Random.Range(0, Screen.width), Random.Range(0, Screen.height));
        lastScreenPos = new Vector2(Random.Range(0, Screen.width), Random.Range(0, Screen.height));
        movementLimitTime = Random.Range(3, 8);
        movementCurrentTime = 0;
    }

    override
    public void AttachToCamera (Camera camera)
    {
        effect = camera.gameObject.AddComponent<MorePPEffects.RadialBlur>() as MorePPEffects.RadialBlur;
    }

    override
    protected void UpdateEffect () {
        effect.blurStrength = GetEvaluatedEffectValue();
        currentScreenPos = Vector2.LerpUnclamped(currentScreenPos, targetScreenPos, movementCurrentTime / movementLimitTime);
        effect.centerX = currentScreenPos.x / Screen.width;
        effect.centerY = currentScreenPos.y / Screen.height;

        movementCurrentTime += Time.deltaTime;

        if (movementCurrentTime > movementLimitTime)
        {
            lastScreenPos = targetScreenPos;
            targetScreenPos = new Vector2(Random.Range(0, Screen.width), Random.Range(0, Screen.height));
            movementLimitTime = Random.Range(3, 8);
            movementCurrentTime = 0;
        }
    }

}
