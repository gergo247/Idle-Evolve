using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiCellurarLifeStageScript : MonoBehaviour
{

    [SerializeField]
    GameObject canvas;
    CanvasScript canvasScript;

    bool evolveButtonVisible { get { return !IntelligentLifeUnlocked && canvasScript.energy > 1000000; } }
    bool IntelligentLifeUnlocked = false;

    #region photosynthesis 
    [SerializeField]
    private Text PhotoCellNumberText;
    [SerializeField]
    private Button BuyPhotoCellButton;

    public int PhotoCellNumber;
    int _photoCellCost;
    public double photoCellCost { get { return 10 + ((PhotoCellNumber * PhotoCellNumber * 0.44) * 2.1); } }
    public void BuyPhotoCell()
    {
        if (canvasScript.energy >= photoCellCost)
        {
            canvasScript.energy -= photoCellCost;
            PhotoCellNumber++;
        }
    }
    #endregion photosynthesis

    #region carnivore
    [SerializeField]
    private Text CarnivoreNumberText;
    [SerializeField]
    private Button BuyCarnivoreButton;
    public int carnivoreNumber;
    int _carnivoreCost;
    public double carnivoreCost { get { return 150 + (carnivoreNumber * carnivoreNumber * 1.1); } }

    public float carnivoreSpeed = 600;
    public void BuyCarnivore()
    {
        if (canvasScript.energy >= carnivoreCost)
        {
            canvasScript.energy -= carnivoreCost;
            carnivoreNumber++;
        }
    }

    public void CarnivoreFoundFood()
    {
        canvasScript.AddEnergy(1000 * (carnivoreNumber * 1.03));
    }

    #endregion nucleus


    void Start()
    {
        //every 10 mins in beggining
        InvokeRepeating("CarnivoreFoundFood", carnivoreSpeed, carnivoreSpeed);
    }

    void Update()
    {
    }
}
