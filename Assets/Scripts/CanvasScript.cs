using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    [SerializeField]
    private Text Dna;

    public double dna;

    [SerializeField]
    GameObject singleLifeGO;
    SingleLifeScript singleLifeScript;

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
