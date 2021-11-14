using UnityEngine;
using System.Collections;

public class WeightedRoulette {

    protected float[] weights;
    protected float[] roulette;
    protected float totalWeight;
    int lastIndex;

    public WeightedRoulette(float[] weights)
    {
        this.weights = weights;
        roulette = new float[weights.Length];
        ConfigureRoulette();
        this.lastIndex = -1;
    }

    void ConfigureRoulette()
    {
        float currentValue = 0f;
        for (int i = 0; i < roulette.Length; i++)
        {
            currentValue += weights[i];
            roulette[i] = currentValue;
        }
        this.totalWeight = this.roulette[this.roulette.Length - 1];
    }

    public void AddWeight(int index, float additionalWeight)
    {
        weights[index] += additionalWeight;
        ConfigureRoulette();
    }

    public float[] GetWeights()
    {
        return weights;
    }

    public void SetWeight(int index, float weight)
    {
        weights[index] = weight;
        ConfigureRoulette();
    }

    public WeightedRoulette GetCopy()
    {
        return new WeightedRoulette(weights);
    }

    public int RequestIndex()
    {
        float selectedWeight = Random.Range(0, totalWeight);
        int currentIndex = 0;
        while (true)
        {
            if (selectedWeight < roulette[currentIndex])
            {
                break;
            }
            currentIndex++;
        }
        return currentIndex;
    }

    public int RequestNonRepeatedIndex()
    {
        int index = -1;
        do
        {
            index = RequestIndex();
        } while (index == lastIndex);
        lastIndex = index;
        return index;
    }

    public void Show()
    {
        Debug.Log("Roulette info: Total weight: " + totalWeight);
        for(int i= 0; i < roulette.Length; i++) {
            Debug.Log(i + ": " + weights[i] / totalWeight * 100 + "% (" + weights[i] + ")");
        }
    }
}
