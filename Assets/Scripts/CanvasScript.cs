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
    GameObject shop;
    ShopScript shopScript;

    void Start()
    {
        shopScript = shop.GetComponent<ShopScript>();
        if (shopScript != null)
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
        if (shopScript != null)
            shopScript.SetEntityValues();
    }

    private void CalculateMoney()
    {
        if (shopScript != null)
            dna += shopScript.singleLifeNumber * shopScript.singleLifeEff * Time.deltaTime;


        SetMoneyText();
    }
}
