using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public enum STATS { HEALTH, STAMINA, STAMINA_INCREASE, MELEE_ATTACK, MELEE_DEFENSE, MAGIC_ATTACK, MAGIC_DEFENSE, SPEED };

[System.Serializable]
public class MainCharacterStats {

    float[] effectStats;
    float[] upgradeStats;
    float[] effectLevels;
    float[] effectWeights;

    public MainCharacterStats()
    {
        effectStats = Enumerable.Repeat(0f, 8).ToArray();
        upgradeStats = Enumerable.Repeat(0f, 8).ToArray();
        effectWeights = Enumerable.Repeat(5f, 8).ToArray();
        effectLevels = Enumerable.Repeat(0f, 8).ToArray();
        ReevaluateEffectStats();
    }

    private MainCharacterStats(float[] effectLevels, float[] upgradeStats)
    {
        effectStats = Enumerable.Repeat(0f, 8).ToArray();
        this.upgradeStats = upgradeStats;
        effectWeights = Enumerable.Repeat(5f, 8).ToArray();
        this.effectLevels = effectLevels;
        ReevaluateEffectStats();
    }

    public float Get(STATS stat)
    {
        return GetEffectStat(stat) + GetUpgradeStat(stat);
    }

    public void SetEffectStat(STATS stat, float value)
    {
        effectStats[(int)stat] = value;
    }

    public float GetEffectStat(STATS stat)
    {
        return effectStats[(int)stat];
    }

    public void SetUpgradeStat(STATS stat, float value)
    {
        upgradeStats[(int)stat] = value;
    }

    public float GetUpgradeStat(STATS stat)
    {
        return upgradeStats[(int)stat];
    }

    public float[] GetEffectStats()
    {
        return effectStats;
    }

    public float[] GetUpgradeStats()
    {
        return upgradeStats;
    }

    public void AddUpgradeStats(float[] newUpgradeStats)
    {
        EffectData[] effectDatas = StaticData.effectDatas;
        for (int i = 0; i < 8; i++)
        {
            upgradeStats[i] += effectDatas[i].upgradeCurve.Evaluate(newUpgradeStats[i]);
        }
    }

    void AddUpgradeStat(STATS stat, float value)
    {
        SetUpgradeStat(stat, GetUpgradeStat(stat) + value);
    }

    public void DecreaseEffects(float percentage)
    {
        for(int i=0; i<8; i++)
        {
            effectLevels[i] = Mathf.Max(0f, effectLevels[i] - 10 * percentage);
        }
        ReevaluateEffectStats();
    }

    public void DebugShowStats()
    {
        for(int i=0; i<8; i++)
        {
            Debug.Log(((STATS)i).ToString() + ": " + GetEffectStat((STATS)i) + " (e) + " + GetUpgradeStat((STATS)i) + " (u) = " + Get((STATS)i));
        }
    }

    public MainCharacterStats GetBasicCopy()
    {
        return new MainCharacterStats(effectLevels.Clone() as float[], upgradeStats.Clone() as float[]);
    }

    public float[] GetEffectLevels()
    {
        return effectLevels;
    }

    public float[] GetEffectWeights()
    {
        return effectWeights;
    }

    public void SetEffectLevels(float[] effectLevels)
    {
        this.effectLevels = effectLevels;
        ReevaluateEffectStats();
    }

    void ReevaluateEffectStats()
    {
        EffectData[] effectDatas = StaticData.effectDatas;
        for(int i=0; i<8; i++)
        {
            //effectStats[i] = effectDatas[i].GetEvaluatedStatFromLevel(effectLevels[i]);
        }
    }

    public void SetEffectWeights(float[] effectWeights)
    {
        this.effectWeights = effectWeights;
    }
}
