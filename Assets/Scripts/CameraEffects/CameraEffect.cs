using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public abstract class CameraEffect : MonoBehaviour {

    public AnimationCurve effectCurve;
    public float value;
    public float minValue;
    public float maxValue;
    public float level;
    public float minLevel;
    public float maxLevel;
    public float additionalTemporalValue;
    public float temporalCoolDown;
    protected float incrementMultiplier = 0.4f;
    public string effectName;
    public Color color;

    protected Slider slider;

    public float targetLevel;
    public float lastLevel;
    public float currentTime;
    public float limitTime;
    public float probabilityRandom;
    public float minRandom;
    public float maxRandom;

    protected abstract void Init();
    public abstract void AttachToCamera(Camera camera);
    protected abstract void UpdateEffect();

    protected float[] lastRandomNumbers;
    protected float[] targetRandomNumbers;
    protected float[] currentRandomNumbers;

    void Awake ()
    {
        level = 0;
        value = 0;
        additionalTemporalValue = 0;
        temporalCoolDown = (maxLevel - minLevel + 1) * 0.01f;
        lastRandomNumbers = new float[10];
        targetRandomNumbers = new float[10];
        currentRandomNumbers = new float[10];
        GenerateNewRandomNumbers();

        lastLevel = 0f;
        currentTime = 0f;
        limitTime = GetLimitTime();
        targetLevel = GetNewTargetLevel();

        Init();
    }

    protected float Scale(float value, float min, float max, float minScale, float maxScale)
    {
        float scaled = minScale + (value - min) / (max - min) * (maxScale - minScale);
        return scaled;
    }

    void GenerateNewRandomNumbers()
    {
        targetRandomNumbers.CopyTo(currentRandomNumbers, 0);
        for(int i=0; i< targetRandomNumbers.Length; i++)
        {
            targetRandomNumbers[i] = Random.Range(0f, 1f);
        }
    }

    float GetLimitTime()
    {
        return Random.Range(2, 8);
    }

    float GetNewTargetLevel()
    {
        GenerateNewRandomNumbers();
        if (Random.Range(0.0f, 1.0f) <= probabilityRandom) {
            return Random.Range(minRandom, maxRandom);
        } else
        {
            return 0f;
        }
        
    }

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        this.value = GetValueFromLevel();
        UpdateEffect();

        if(currentTime > limitTime)
        {
            currentTime = 0;
            lastLevel = targetLevel;
            targetLevel = GetNewTargetLevel();
        } else
        {
            currentTime += Time.deltaTime;
            level = Mathf.Lerp(lastLevel, targetLevel, currentTime / limitTime);
            for(int i=0; i<currentRandomNumbers.Length; i++)
            {
                currentRandomNumbers[i] = Mathf.Lerp(lastRandomNumbers[i], targetRandomNumbers[i], currentTime / limitTime);
            }
        }
    }

    protected float GetValueFromLevel()
    {
        return StaticTools.Map(level, minLevel, maxLevel, 0, 1);
    }

    protected int GetLevelFromValue()
    {
        return (int)StaticTools.Map(value, minValue, maxValue, minLevel, maxLevel);
    }

    protected float GetTotalValue()
    {
        return value + additionalTemporalValue;
    }

    protected float GetEvaluatedEffectValue()
    {
        return Mathf.Lerp(minValue, maxValue, effectCurve.Evaluate(value));
    }

    public void SetSlider(Slider slider, bool isInteractable)
    {
        this.slider = slider;
        slider.minValue = minLevel;
        slider.maxValue = maxLevel;
        slider.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = this.color;
        if(isInteractable)
        {
            slider.onValueChanged.AddListener(SliderListener);
        }
        slider.interactable = isInteractable;
        SetInitLevel();
    }

    public void SliderListener(float value)
    {
        this.level = value;
        this.value = GetValueFromLevel();
    }

    public void SetInitLevel()
    {
        this.level = 0f;
        slider.value = 0f;
    }

    public string GetEffectName()
    {
        return this.effectName;
    }

    public void Add(float increment)
    {
        this.level = Mathf.Max(minLevel, Mathf.Min(maxLevel, level + increment * incrementMultiplier));
        this.value = GetValueFromLevel();
        this.slider.value = this.level;
    }

    public void SetLevel(float level)
    {
        this.level = level;
        this.value = GetValueFromLevel();
        this.slider.value = this.level;
    }
  
    public float GetEvaluationFromLevel(float level)
    {
        return effectCurve.Evaluate(StaticTools.Map(level, minLevel, maxLevel, 0f, 1f));
    }
}
