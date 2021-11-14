using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

public class EffectsController : Singleton<EffectsController> {

    public GameObject HUD;
    public GameObject sliderPrefab;
    public bool interactableSliders = false;
    [HideInInspector]
    public EffectData[] effectsData;
    WeightedRoulette weightedRoulette;

    List<CameraEffect> effects = new List<CameraEffect>();

    MainCharacter mainCharacter;
    Camera mainCamera;
    Canvas canvas;
    //HorizontalLayoutGroup panel;

    void Awake()
    {

    }

	// Use this for initialization
	void Start () {
        mainCharacter = Object.FindObjectOfType<MainCharacter>();
        mainCamera = Camera.main;
        //panel = HUD.transform.Find("BarPanel").GetComponentInChildren<HorizontalLayoutGroup>();
        effectsData = GetComponentsInChildren<EffectData>();
        foreach(EffectData effectData in effectsData)
        {
            effects.Add(effectData.cameraEffect);
        }

        //weightedRoulette = new WeightedRoulette(StaticData.mainCharacterInfo.mainCharacterStats.GetEffectWeights());

        AddEffectsToCamera();
        //AddSliders();

        //BindEffectsToMainCharacter();
        //LoadEffectValues();
        //TriggerEffectsChanged();
    }

    void TestWeightedRoulette()
    {
        weightedRoulette.Show();
        int[] types = new int[8];
        for(int i=0; i<100; i++)
        {
            types[weightedRoulette.RequestIndex()]++;
        }

        for (int i = 0; i < 8; i++)
        {
            Debug.Log(types[i]);
        }
    }

    void LoadEffectValues()
    {
        float[] effectLevels = StaticData.mainCharacterInfo.mainCharacterStats.GetEffectLevels();
        for (int i=0; i<effects.Count; i++)
        {
            effects[i].SetLevel(effectLevels[i]);
        }
    }

    void AddEffectsToCamera()
    {
        foreach(CameraEffect effect in effects)
        {
            effect.AttachToCamera(mainCamera);
        }
    }

    void AddSliders()
    {
        string sliderName;
        foreach (CameraEffect effect in effects)
        {
            GameObject sliderGameObject = Instantiate(sliderPrefab) as GameObject;
            sliderName = effect.GetEffectName() + "Slider";
            sliderGameObject.name = sliderName;
            //sliderGameObject.transform.SetParent(panel.transform);
            sliderGameObject.transform.localScale = Vector3.one;
            effect.SetSlider(sliderGameObject.GetComponent<Slider>(), interactableSliders);
        }
    }

    public void AddCollectedObject(ObjectEffect objectEffect)
    {
        effectsData[(int)objectEffect.effectItem].Add(objectEffect.value);
        mainCharacter.AddEssence(objectEffect.value);
    }

    public GameObject RequestObject(Transform enemyTransform)
    {
        int objectIndex = weightedRoulette.RequestIndex();
        GameObject spawnedObject = Instantiate(effectsData[objectIndex].objectEffect, enemyTransform.position + Vector3.up * 0.3f, Quaternion.identity) as GameObject;
        Debug.Log(spawnedObject.name);
        return spawnedObject;
    }

    public void BindEffectsToMainCharacter()
    {
        foreach(EffectData effectData in effectsData)
        {
            effectData.OnEffectChanged += mainCharacter.StatChanged;
            effectData.TriggerEffectChanged();
        }
    }

    public void TriggerEffectsChanged()
    {
        foreach (EffectData effectData in effectsData)
        {
            effectData.TriggerEffectChanged();
        }
    }

    public WeightedRoulette GetEffectsRoulette()
    {
        return weightedRoulette;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.J))
        {
            RequestObject(mainCharacter.transform);
        }
    }

    public void SaveStats()
    {
        StaticData.mainCharacterInfo.mainCharacterStats.SetEffectWeights(weightedRoulette.GetWeights());
        SaveEffectsInfo();
    }

    public void SaveEffectsInfo()
    {
        float[] effectLevels = new float[8];
        for(int i = 0; i < effects.Count; i++)
        {
            effectLevels[i] = effects[i].level;
        }
        StaticData.mainCharacterInfo.mainCharacterStats.SetEffectLevels(effectLevels);
    }
}
