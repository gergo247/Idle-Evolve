using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager theInstance;

    [SerializeField]
    ShopScript shopScript;
    [SerializeField]
    CanvasScript canvasScript;
    void Start()
    {
        if (theInstance == null)
            theInstance = this;

      

    }

   
}
