using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    #region singleLife
    [SerializeField]
    private Text Dna;
    public double dna;

    [SerializeField]
    GameObject singleLifeGO;
    SingleLifeScript singleLifeScript;
    #endregion singleLife
    #region multicellLife
    [SerializeField]
    private Text Energy;
    public double energy;

    [SerializeField]
    GameObject multiCellLifeGO;
    SingleLifeScript multiCellLifeScript;

    public void AddEnergy(double energyToAdd)
    {
        energy += energyToAdd;
    }


    #endregion multicellLife



    void Start()
    {
        singleLifeScript = singleLifeGO.GetComponent<SingleLifeScript>();
        if (singleLifeScript != null)
            Debug.Log("megy");

        dna = 30;

    }

    public void SetMoneyText()
    {
        Dna.text = "Dna : " + dna.ToString("f0");
    }

    void Update()
    {
        CalculateMoney();
        RefreshUI();
    }

    private void RefreshUI()
    {
        if (singleLifeScript != null)
            singleLifeScript.SetEntityValues();
    }

    private void CalculateMoney()
    {
        if (singleLifeScript != null)
            dna += singleLifeScript.singleLifeNumber * singleLifeScript.singleLifeEff * (singleLifeScript.nucleusNumber * 1.05)  * Time.deltaTime;


        SetMoneyText();
    }
}
