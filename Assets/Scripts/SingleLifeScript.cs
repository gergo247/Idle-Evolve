using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingleLifeScript : MonoBehaviour
{
   

    [SerializeField]
    GameObject canvas;
    CanvasScript canvasScript;

    bool evolveButtonVisible { get { return !MultiLifeUnlocked && singleLifeNumber > 10000 ; } }
    bool MultiLifeUnlocked = false;



    #region singlelife
    [SerializeField]
    private Text SingleLifeNumberText;
    [SerializeField]
    private Button BuySingleLifeButton;

    public int singleLifeNumber;
    int _singleLifeCost;
    public float singleLifeEff;
    public double singleLifeCost { get { return 10 + ((singleLifeNumber * singleLifeNumber * 0.33) * 2); } }
    public void BuySingleLife()
    {
        if (canvasScript.dna >= singleLifeCost)
        {
            canvasScript.dna -= singleLifeCost;
            singleLifeNumber++;
        }
    }
    #endregion singlelife


    #region nucleus
    [SerializeField]
    private Text NucleusNumberText;
    [SerializeField]
    private Button BuyNucleusButton;
    public int nucleusNumber;
    int _nucleusCost;
    public double nucleusCost { get { return 89 + (nucleusNumber * nucleusNumber * 0.9); } }
    public void BuyNucleus()
    {
        if (canvasScript.dna >= nucleusCost)
        {
            canvasScript.dna -= nucleusCost;
            nucleusNumber++;
        }
    }
    #endregion nucleus

    void Start()
    {
        canvasScript = canvas.GetComponent<CanvasScript>();

        SetStartingValues();
    }

    private void SetStartingValues()
    {
        singleLifeNumber = 1;
        singleLifeEff = 1;
        nucleusNumber = 1;
    }

    void Update()
    {
        SetEntityValues();
    }

   

    public void SetEntityValues()
    {
        SingleLifeNumberText.text = string.Format("{0} ({1:0})", singleLifeNumber, singleLifeCost);
        NucleusNumberText.text = string.Format("{0} ({1:0})", nucleusNumber, nucleusCost);
    }
}