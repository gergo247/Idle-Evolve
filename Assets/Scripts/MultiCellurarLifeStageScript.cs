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

    public int photoCellNumber = 1;
    public float photoEff = 1;

    int _photoCellCost;
    public double photoCellCost { get { return 10 + ((photoCellNumber * photoCellNumber * 0.44) * 2.1); } }
    public void BuyPhotoCell()
    {
        if (canvasScript.energy >= photoCellCost)
        {
            canvasScript.energy -= photoCellCost;
            photoCellNumber++;
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

    void CarnivoreFoundFood()
    {
        Debug.Log("food found");
        canvasScript.AddEnergy(1000 * (carnivoreNumber * 1.03) * Random.Range(0.95f,1.1f));
    }

    #endregion carnivore


    void Start()
    {
        canvasScript = canvas.GetComponent<CanvasScript>();
        carnivoreSpeed = 600;
        //every 10 mins in beggining
        InvokeRepeating("CarnivoreFoundFood", carnivoreSpeed, carnivoreSpeed);

        photoEff = 1;
        photoCellNumber = 1;
    }

    void Update()
    {
    }

    public void SetEntityValues()
    {
        PhotoCellNumberText.text = string.Format("{0} ({1:0})", photoCellNumber, photoCellCost);
        CarnivoreNumberText.text = string.Format("{0} ({1:0})", carnivoreNumber, carnivoreCost);
    }
}
