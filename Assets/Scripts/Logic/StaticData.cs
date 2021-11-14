using UnityEngine;
using System.Collections;
using System.Linq;

public static class StaticData {

    public static bool loadedStaticData = false;
    public static string fileDataPath = Application.persistentDataPath + "/data.bin";
    public static int charactersLayerMask = (1 << LayerMask.NameToLayer("MainCharacter")) | (1 << LayerMask.NameToLayer("EnemyCharacter"));
    public static string normalMapScene = "Map";
    public static bool isSplashScreenShowed = false;
    public static bool isFirstLevel = true;
    public static MainCharacterInfo mainCharacterInfo;
    public static UserOptions userOptions;
    public static float difficulty;
    public static EffectData[] effectDatas;
    public static CameraEffect[] cameraEffects;

    public static void LoadCurrentStats()
    {
        if (StaticData.isFirstLevel)
        {
            Debug.Log("First level, loading default stats");
            StaticData.isFirstLevel = false;
            SetDefaultStats();
        }
    }

    public static void SetDefaultStats()
    {
        Debug.Log("Loading default stats");
        StaticData.mainCharacterInfo = new MainCharacterInfo();
        StaticData.userOptions = new UserOptions();        
        StaticData.mainCharacterInfo.Set(100f, 0f, null /*Firebolt*/, null /*Sword*/, new MainCharacterStats());
    }

    public static void LoadEffectsInfo()
    {
        effectDatas = new EffectData[8];
        cameraEffects = new CameraEffect[8];
        GameObject effectsManager = Resources.Load("Prefabs/Logic/EffectsManager") as GameObject;
        Transform effectsManagerTransform = effectsManager.transform;
        for(int i=0; i<8; i++)
        {
            Transform effect = effectsManagerTransform.GetChild(i);
            effectDatas[i] = effect.GetComponent<EffectData>();
            cameraEffects[i] = effect.GetComponent<CameraEffect>();
        }
    }
}

[System.Serializable]
public class MainCharacterInfo
{
    public float currentHealth;
    public float currentEssence;
    public string magicWeapon;
    public string meleeWeapon;
    public MainCharacterStats mainCharacterStats;

    public void Set(float currentHealth, float currentEssence, string magicWeapon, string meleeWeapon, MainCharacterStats mainCharacterStats)
    {
        this.currentHealth = currentHealth;
        this.currentEssence = currentEssence;
        this.magicWeapon = magicWeapon;
        this.meleeWeapon = meleeWeapon;
        this.mainCharacterStats = mainCharacterStats;
    }
}

[System.Serializable]
public class UserOptions
{
    public float masterVolume = 1f;
    public float musicVolume = 1f;
    public float sfxVolume = 1f;
    public CameraType cameraType = CameraType.ORTOGRAPHIC;
    public SystemLanguage language = Application.systemLanguage;
}

[System.Serializable]
public enum CameraType { ORTOGRAPHIC, BEHIND_CHARACTER };