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


    public int population;
    public int maxPopulation { get { return 15 + (houseNumber * 10); } }

    public double wood;
    public double stone;
    public double food;
    public double knowledge;
    public double iron;
    public double evergy;



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

    #endregion buildings


    void Start()
    {
        canvasScript = canvas.GetComponent<CanvasScript>();
    }

    void Update()
    {
        SetEntityValues();
    }

    public void SetEntityValues()
    {
        // HouseNumberText.text = string.Format("{0}  <color = green>({1:0})</color> <color = grey>({2:0})</color> ", houseNumber, houseWoodCost, houseStoneCost);<color=green>green</color>
        HouseNumberText.text = houseNumber +"<color=green>("+ houseWoodCost.ToString("f0") + ")</color><color=grey>(" + houseWoodCost.ToString("f0") + ")</color> ";

      //  Debug.Log("house num text : " + HouseNumberText.text);
        //(myText.text[charIndex].ToString(), "<color=#000000>" + myText.text[charIndex].ToString() + "</color>");
    }
}
