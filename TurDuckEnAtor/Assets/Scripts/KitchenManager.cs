using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KitchenManager : MonoBehaviour
{
    public GameObject forestGameObject;
    public GameObject pondGameObject;
    public GameObject coopGameObject;
    public GameObject servedGameObject;
    public GameObject chefStatusObject;

    private TextMeshProUGUI forestText;
    private TextMeshProUGUI pondText;
    private TextMeshProUGUI coopText;
    private TextMeshProUGUI servedText;
    private TextMeshProUGUI chefStatusText;

    private Forest turkeyForest;
    private Pond duckPond;
    private Coop chickenCoop;

    private Chicken currentChicken;
    private Duck currentDuck;
    private Turkey currentTurkey;
    private TurDuckEn currentTurDuckEn;
    private int currentTurDuckEnCount;

    private TurDuckEn[] servedTurDuckens;

    private enum CurrentOperation
    {
        GetChicken,
        BoneChicken,
        GetDuck,
        BoneDuck,
        GetTurkey,
        BoneTurkey,
        AssembleTurDuckEn,
        PrepareTurDuckEnForOven,
        BakingTurDuckEn,
        ServeTurDuckEn,
        Done
    }

    private CurrentOperation chefState;

    void Start()
    {
        int totalTurDuckEns = 7;

        turkeyForest = new Forest(totalTurDuckEns);
        duckPond = new Pond(totalTurDuckEns);
        chickenCoop = new Coop(totalTurDuckEns);
        servedTurDuckens = new TurDuckEn[totalTurDuckEns];

        currentTurDuckEnCount = 0;

        forestText = forestGameObject.GetComponent<TextMeshProUGUI>();
        pondText = pondGameObject.GetComponent<TextMeshProUGUI>();
        coopText = coopGameObject.GetComponent<TextMeshProUGUI>();
        servedText = servedGameObject.GetComponent<TextMeshProUGUI>();
        chefStatusText = chefStatusObject.GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        chefStatusText.text = "Chef Status: " + chefState.ToString();

        switch(chefState)
        {
            case CurrentOperation.GetChicken:
                currentChicken = chickenCoop.RemoveChicken();
                chefState = CurrentOperation.BoneChicken;
                break;
            case CurrentOperation.BoneChicken:
                currentChicken.Debone();
                chefState = CurrentOperation.GetDuck;
                break;
            case CurrentOperation.GetDuck:
                currentDuck = duckPond.RemoveDuck();
                chefState = CurrentOperation.BoneDuck;
                break;
            case CurrentOperation.BoneDuck:
                currentDuck.Debone();
                chefState = CurrentOperation.GetTurkey;
                break;
            case CurrentOperation.GetTurkey:
                currentTurkey = turkeyForest.RemoveTurkey();
                chefState = CurrentOperation.BoneTurkey;
                break;
            case CurrentOperation.BoneTurkey:
                currentTurkey.Debone();
                chefState = CurrentOperation.AssembleTurDuckEn;
                break;
            case CurrentOperation.AssembleTurDuckEn:
                currentTurDuckEn = new TurDuckEn(currentTurkey, currentDuck, currentChicken);
                currentTurkey = null;
                currentDuck = null;
                currentChicken = null;
                chefState = CurrentOperation.PrepareTurDuckEnForOven;
                break;
            case CurrentOperation.PrepareTurDuckEnForOven:
                currentTurDuckEn.PrepareForOven();
                chefState = CurrentOperation.BakingTurDuckEn;
                break;
            case CurrentOperation.BakingTurDuckEn:
                if(!currentTurDuckEn.IsCooked)
                {
                    currentTurDuckEn.CookOneMinute();
                }
                else
                {
                    chefState = CurrentOperation.ServeTurDuckEn;
                }
                break;
            case CurrentOperation.ServeTurDuckEn:
                servedTurDuckens[currentTurDuckEnCount] = currentTurDuckEn;
                currentTurDuckEnCount++;
                currentTurDuckEn = null;
                if(turkeyForest.NoMoreTurkeys() || duckPond.NoMoreDucks() || chickenCoop.NoMoreChickens())
                {
                    chefState = CurrentOperation.Done;
                }
                else
                {
                    chefState = CurrentOperation.GetChicken;
                }

                break;
            case CurrentOperation.Done:
       
                break;
        }


        forestText.text = "Forest: ";
        if (!turkeyForest.NoMoreTurkeys())
        {
            foreach (int weight in turkeyForest.GetRemainingTurkeyWeights())
            {
                forestText.text += weight.ToString() + " ";
            }
        }
        else
        {
            forestText.text += "Empty";
        }

        pondText.text = "Pond: ";
        if (!duckPond.NoMoreDucks())
        {
            foreach (int weight in duckPond.GetRemainingDuckWeights())
            {
                pondText.text += weight.ToString() + " ";
            }
        }
        else
        {
            pondText.text += "Empty";
        }

        coopText.text = "Coop: ";
        if (!chickenCoop.NoMoreChickens())
        {
            foreach (int weight in chickenCoop.GetRemainingChickenWeights())
            {
                coopText.text += weight.ToString() + " ";
            }
        }
        else
        {
            coopText.text += "Empty";
        }

        servedText.text = "Served: ";
        if(currentTurDuckEnCount > 0)
        {
            int totalCalories = 0;
            int totalWeight = 0;

            for(int td = 0; td < currentTurDuckEnCount; td++)
            {
                totalWeight += servedTurDuckens[td].GetTotalWeightInOunces();
                totalCalories += servedTurDuckens[td].GetCalories();
            }

            servedText.text += totalWeight + " ounces with " + totalCalories + " total calories.";
        }
        else
        {
            servedText.text += "None";
        }
    }
}
