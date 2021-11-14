using UnityEngine;
using System.Collections;

public class EffectData : MonoBehaviour {

    public System.Action<STATS, float> OnEffectChanged;

    public CameraEffect cameraEffect;
    public GameObject objectEffect;
    public STATS statType;
    public AnimationCurve statCurve;
    public AnimationCurve upgradeCurve;
    public KeyCode debugKey;

    public void Add(float increment)
    {
        cameraEffect.Add(increment);
        TriggerEffectChanged();
    }

    public void TriggerEffectChanged()
    {
        if (OnEffectChanged != null)
        {
            OnEffectChanged(statType, GetEvaluatedStatValue());
        }
    }

    public float GetEvaluatedStatValue()
    {
        return statCurve.Evaluate(cameraEffect.value);
    }

    public float GetEvaluatedStatFromValue(float value)
    {
        return statCurve.Evaluate(value);
    }

    public float GetEvaluatedUpgradeStatFromValue(float value)
    {
        return upgradeCurve.Evaluate(value);
    }

    public void Update()
    {
        if(Input.GetKeyDown(debugKey))
        {
            if (Input.GetKey(KeyCode.LeftAlt))
            {
                Add(-1);
            }
            else
            {
                Add(1);
            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            Add(-1000);
        }
    }
}
