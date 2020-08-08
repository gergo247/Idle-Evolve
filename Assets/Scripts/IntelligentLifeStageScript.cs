using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntelligentLifeStageScript : MonoBehaviour
{
    [SerializeField]
    GameObject canvas;
    CanvasScript canvasScript;

    // bool evolveButtonVisible { get { return !IntelligentLifeUnlocked && canvasScript.energy > 1000000; } }

    #region resources 
    [SerializeField]
    private Text PopulationText;
    [SerializeField]
    private Text WoodText;
    [SerializeField]
    private Text StoneText;
    [SerializeField]
    private Text FoodText;
    [SerializeField]
    private Text KnowledgeText;
    [SerializeField]
    private Text IronText;
    [SerializeField]
    private Text EnergyText;


    public int maxPopulation { get { return 15 + (houseNumber * 10); } }
    public int population;

    int techPopLimit1 = 1000;
    int techPopLimit2 = 10000;
    int techPopLimit3 = 100000;
    int techPopLimit4 = 1000000;

    public float timeUntilBirth;
    public double timeBetweenBirth { get { return (30 / Math.Sqrt(houseNumber)); } }
    public double wood;
    public double stone;
    public double food;
    public double knowledge;
    public double iron;        
    public double energy;



    void CalculateResources()
    {
        wood += (1 + woodCutterNumber) * Time.deltaTime;
        stone += (1 + stoneMineNumber) * Time.deltaTime;
        food = (1 + farmNumber - (population * 0.5)) * Time.deltaTime;
        knowledge = (1 + farmNumber) * Time.deltaTime;
        iron = (0 + ironWorksNumber) * Time.deltaTime;
        energy = (0 + thermanPowerPlantNumber) * Time.deltaTime;

        if (population < maxPopulation)
        {
            timeUntilBirth += Time.deltaTime;
            if (timeUntilBirth > timeBetweenBirth)
            {
                timeUntilBirth = 0;
                population++;
            }
        }
            
    }

    #endregion resources

    #region buildings
    [SerializeField]
    private Text HouseNumberText;
    [SerializeField]
    private Button BuildHouseButton;



    public int houseNumber;
    int _houseCost;
    public double houseWoodCost { get { return 10 + (houseNumber * houseNumber * 0.33); } }
    public double houseStoneCost { get { return 10 + (houseNumber * houseNumber * 0.33); } }

    public void BuyHouse()
    {
        if (wood >= houseWoodCost && stone > houseStoneCost)
        {
            wood -= houseWoodCost;
            stone -= houseStoneCost;

            houseNumber++;
        }
    }

    [SerializeField]
    private Text WoodCutterNumberText;
    [SerializeField]
    private Button BuildWoodCutterButton;
    public bool woodCutterButtonVisible { get { return population < techPopLimit2; } }

    public int woodCutterNumber;
    int _woodCutterCost;
    public double woodCutterWoodCost { get { return 10 + (woodCutterNumber * woodCutterNumber * 0.33); } }
    public double woodCutterStoneCost { get { return 10 + (woodCutterNumber * woodCutterNumber * 0.33); } }

    public void BuyWoodCutter()
    {
        if (wood >= woodCutterWoodCost && stone > woodCutterStoneCost)
        {
            wood -= woodCutterWoodCost;
            stone -= woodCutterStoneCost;

            woodCutterNumber++;
        }
    }

    [SerializeField]
    private Text StoneMineNumberText;
    [SerializeField]
    private Button BuildStoneMineButton;
    public bool stoneMineButtonVisible { get { return population < techPopLimit2; } }

    public int stoneMineNumber;
    int _stoneMineCost;
    public double stoneMineWoodCost { get { return 10 + (stoneMineNumber * stoneMineNumber * 0.33); } }
    public double stoneMineStoneCost { get { return 10 + (stoneMineNumber * stoneMineNumber * 0.33); } }

    public void BuyStoneMine()
    {
        if (wood >= stoneMineWoodCost && stone > stoneMineStoneCost)
        {
            wood -= stoneMineWoodCost;
            stone -= stoneMineStoneCost;

            stoneMineNumber++;
        }
    }
    [SerializeField]
    private Text FarmNumberText;
    [SerializeField]
    private Button BuildFarmButton;
    public bool farmButtonVisible { get { return population < techPopLimit2; } }

    public int farmNumber;
    int _farmCost;
    public double farmWoodCost { get { return 10 + (farmNumber * farmNumber * 0.33); } }
    public double farmStoneCost { get { return 10 + (farmNumber * farmNumber * 0.33); } }

    public void BuyFarm()
    {
        if (wood >= farmWoodCost && stone > farmStoneCost)
        {
            wood -= farmWoodCost;
            stone -= farmStoneCost;

            farmNumber++;
        }
    }

    [SerializeField]
    private Text LibraryText;
    [SerializeField]
    private Button BuildLibraryButton;
    public bool libraryButtonVisible { get { return population > techPopLimit1; } }


    public int libraryNumber;
    int _libraryCost;
    public double libraryWoodCost { get { return 10 + (libraryNumber * libraryNumber * 0.33); } }
    public double libraryStoneCost { get { return 10 + (libraryNumber * libraryNumber * 0.33); } }

    public void BuyLibrary()
    {
        if (wood >= libraryWoodCost && stone > libraryStoneCost)
        {
            wood -= libraryWoodCost;
            stone -= libraryStoneCost;

            libraryNumber++;
        }
    }


    [SerializeField]
    private Text IronWorksText;
    [SerializeField]
    private Button BuildIronWorksButton;
    public bool ironWorksButtonVisible { get { return population > techPopLimit1; } }

    public int ironWorksNumber;
    int _ironWorksCost;
    public double ironWorksWoodCost { get { return 10 + (ironWorksNumber * ironWorksNumber * 0.33); } }
    public double ironWorksStoneCost { get { return 10 + (ironWorksNumber * ironWorksNumber * 0.33); } }

    public void BuyIronWorks()
    {
        if (wood >= ironWorksWoodCost && stone > ironWorksStoneCost)
        {
            wood -= ironWorksWoodCost;
            stone -= ironWorksStoneCost;

            ironWorksNumber++;
        }
    }

    [SerializeField]
    private Text ThermanPowerPlantText;
    [SerializeField]
    private Button BuildThermanPowerPlantButton;
    public bool thermanPowerPlantButtonVisible { get { return population > techPopLimit2; } }



    public int thermanPowerPlantNumber;
    int _thermanPowerPlantCost;
    public double thermanPowerPlantWoodCost { get { return 10 + (thermanPowerPlantNumber * thermanPowerPlantNumber * 0.33); } }
    public double thermanPowerPlantStoneCost { get { return 10 + (thermanPowerPlantNumber * thermanPowerPlantNumber * 0.33); } }

    public void BuyThermanPowerPlant()
    {
        if (wood >= thermanPowerPlantWoodCost && stone > thermanPowerPlantStoneCost)
        {
            wood -= thermanPowerPlantWoodCost;
            stone -= thermanPowerPlantStoneCost;

            thermanPowerPlantNumber++;
        }
    }

    [SerializeField]
    private Text FactoryText;
    [SerializeField]
    private Button BuildFactoryButton;
    public bool factoryButtonVisible { get { return population > techPopLimit2; } }



    public int factoryNumber;
    int _factoryCost;
    public double factoryWoodCost { get { return 10 + (factoryNumber * factoryNumber * 0.33); } }
    public double factoryStoneCost { get { return 10 + (factoryNumber * factoryNumber * 0.33); } }

    public void BuyFactory()
    {
        if (wood >= factoryWoodCost && stone > factoryStoneCost)
        {
            wood -= factoryWoodCost;
            stone -= factoryStoneCost;

            factoryNumber++;
        }
    }
     void SetBuildingButtonVisibility()
    {



        BuildWoodCutterButton.gameObject.SetActive(woodCutterButtonVisible);
        BuildStoneMineButton.gameObject.SetActive(woodCutterButtonVisible);
        BuildFarmButton.gameObject.SetActive(woodCutterButtonVisible);
        BuildLibraryButton.gameObject.SetActive(woodCutterButtonVisible);
        BuildThermanPowerPlantButton.gameObject.SetActive(woodCutterButtonVisible);
        BuildFactoryButton.gameObject.SetActive(woodCutterButtonVisible);

    }

    #endregion buildings


    void Start()
    {
        canvasScript = canvas.GetComponent<CanvasScript>();
    }

    void Update()
    {
        SetEntityValues();
        SetVisibilityValues();
    }

    private void SetVisibilityValues()
    {
        SetBuildingButtonVisibility();
    }

    public void SetEntityValues()
    {
        // HouseNumberText.text = string.Format("{0}  <color = green>({1:0})</color> <color = grey>({2:0})</color> ", houseNumber, houseWoodCost, houseStoneCost);<color=green>green</color>
        HouseNumberText.text = houseNumber +"<color=green>("+ houseWoodCost.ToString("f0") + ")</color><color=grey>(" + houseWoodCost.ToString("f0") + ")</color> ";

      //  Debug.Log("house num text : " + HouseNumberText.text);
        //(myText.text[charIndex].ToString(), "<color=#000000>" + myText.text[charIndex].ToString() + "</color>");
    }
}
