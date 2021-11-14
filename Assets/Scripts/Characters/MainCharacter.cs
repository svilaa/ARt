using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class MainCharacter : MonoBehaviour
{

    public GameObject HUD;
    public GameObject sliderPrefab;
    public GameObject textPrefab;

    public float maxStamina = 100f;
    public float stamina;
    public float staminaCooldown = 5f;
    public float staminaWaitAfterFull = 2f;
    public float staminaWaitAfterAction = 0.3f;
    public float speed;
    public float essence;
    public bool cheatsEnabled;
    public ParticleSystem smoke;
    public GameObject meleeWeaponPlaceholder;
    public GameObject magicWeaponPlaceholder;

    VerticalLayoutGroup statsPanel;
    Text essenceText;

    bool waitingStaminaAfterFull = false;

    float currentStaminaWaitAfterAction = 0.0f;

    int objectLayer;
    EffectsController effectsController;

    public float invencivilityTimeAfterHit = 2.0f;
    bool isInvencible;

    MainCharacterStats mainCharacterStats;

    public void OnAwake()
    {
        StaticData.LoadCurrentStats();
        statsPanel = HUD.transform.Find("StatsPanel").GetComponentInChildren<VerticalLayoutGroup>();
        stamina = 0f;
        objectLayer = LayerMask.NameToLayer("Object");
        effectsController = Object.FindObjectOfType<EffectsController>();
        isInvencible = false;
        ConfigureCamera();
        mainCharacterStats = StaticData.mainCharacterInfo.mainCharacterStats;
    }

    void ConfigureCamera()
    {
        /*
#if UNITY_EDITOR
        SaveSystem.Load();
#endif
        switch (SaveData.GetInstance().userOptions.cameraType)
        {
            case CameraType.BEHIND_CHARACTER:
                Camera.main.gameObject.SetActive(false);
                transform.FindChild("SPSCamera").gameObject.SetActive(true);
                mainCharacterController.SecondaryControls = true;
                Debug.Log("Set Behind Camera");
                break;
            case CameraType.ORTOGRAPHIC:
            default:
                // Normal behavior
                Debug.Log("Set Ortographic Camera");
                break;
        }
        */
    }

    // Use this for initialization
    void Start() {
        AddEssence(StaticData.mainCharacterInfo.currentEssence);
    }
	
	// Update is called once per frame
	void Update () {
        if(cheatsEnabled)
        {
            stamina = 0f;
        }
	}

    public void AddEssence(float essenceValue)
    {
        essence = Mathf.Min(99, essence + essenceValue);
        essenceText.text = string.Format("{0:00}", essence);
    }

    public void StatChanged(STATS stat, float value)
    {
        mainCharacterStats.SetEffectStat(stat, value);

        switch(stat)
        {
            case STATS.HEALTH:
                break;
            case STATS.SPEED:
                break;
            case STATS.MELEE_ATTACK:
                break;
            case STATS.MELEE_DEFENSE:
                break;
            case STATS.MAGIC_ATTACK:
                break;
            case STATS.MAGIC_DEFENSE:
                break;
            case STATS.STAMINA:
                break;
            case STATS.STAMINA_INCREASE:
                break;
        }
    }

    float AdaptCurrentValueWhenIncreasesMaxStat(float currentValue, float oldMax, float newMax)
    {
        if (oldMax < newMax)
        {
            return newMax - (oldMax - currentValue);
        }

        return Mathf.Min(currentValue, newMax);
    }
}
