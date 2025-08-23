using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FishingLogic : MonoBehaviour
{
    // Singleton of FishingLogic
    public static FishingLogic Instance { get; private set; }
    public List<FishData> oceanFish;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void StartFishing()
    {
        StartCoroutine(FishingCo());
    }

    IEnumerator FishingCo()
    {
        yield return new WaitForSeconds(4f);

        FishData fish = CalculateFish();

        if (fish.name == "NoFish") // No fish was caught
        {
            EndFishing();
        }
        else // A fish was caught
        {
            StartCoroutine(FightFish(fish));
        }
    }

    private FishData CalculateFish()
    {
        // We are going to use cumalitive probability to determine which fish bites
        float totalProbability = 0f;
        foreach (FishData fish in oceanFish) 
        {
            totalProbability += fish.probabliity;
        }

        // We generate a random number between 0 - totalProbability that will determine which fish is biting
        int randomValue = Random.Range(0, Mathf.FloorToInt(totalProbability) + 1);

        float cumulativeProbability = 0f;
        foreach (FishData fish in oceanFish)
        {
            cumulativeProbability += fish.probabliity;
            if (randomValue <= cumulativeProbability) // If the random value falls within the range of the cumulative probability so far then that particular fish will bite
            {
                return fish;
            }
        }

        return null;
    }

    private void FightFish(FishData fishy)
    {

    }

    private void EndFishing()
    {

    }
}
