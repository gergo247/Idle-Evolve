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

    

    private void CalculateDna()
    {
        if (singleLifeScript != null)
        {
            dna += singleLifeScript.singleLifeNumber * singleLifeScript.singleLifeEff * (singleLifeScript.nucleusNumber * 1.05) * Time.deltaTime;
        }

        SetDnaText();
    }
    public void SetDnaText()
    {
        Dna.text = "Dna : " + dna.ToString("f0");
    }

    #endregion singleLife
    #region multicellLife
    [SerializeField]
    private Text Energy;
    public double energy;

    [SerializeField]
    GameObject multiCellLifeGO;
    MultiCellurarLifeStageScript multiCellLifeScript;

    public void AddEnergy(double energyToAdd)
    {
        energy += energyToAdd;
    }

    private void CalculateEnergy()
    {
        if (multiCellLifeScript != null)
        {
            energy += multiCellLifeScript.photoCellNumber * multiCellLifeScript.photoEff * Time.deltaTime;
            //Debug.Log("energy : " + energy);
        }

        SetEnergyText();
    }

    public void SetEnergyText()
    {
        Energy.text = "E : " + energy.ToString("f0");
    }

    #endregion multicellLife



    void Start()
    {
        singleLifeScript = singleLifeGO.GetComponent<SingleLifeScript>();
        multiCellLifeScript = multiCellLifeGO.GetComponent<MultiCellurarLifeStageScript>();

        dna = 30;
        energy = 100;

    }

    void Update()
    {
        CalculateDna();
        CalculateEnergy();
        RefreshUI();
    }

    private void RefreshUI()
    {
        if (singleLifeScript != null)
            singleLifeScript.SetEntityValues();
        if (multiCellLifeScript != null)
            multiCellLifeScript.SetEntityValues();
    }

   
}
