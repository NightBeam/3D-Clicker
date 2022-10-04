using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CheckerGraphics : MonoBehaviour
{
    public bool graphicsStatictics;
    public static string keyGraphics = "Graph";
    public GameObject GraphicsObject;
    public Toggle toggle;
    private void Start()
    {
        graphicsStatictics = Convert.ToBoolean(PlayerPrefs.GetInt(keyGraphics));
        if(graphicsStatictics == false)
        {
            toggle.isOn = false;
        }
        else
        {
            toggle.isOn = true;
        }
    }
    private void Update()
    {
        if (graphicsStatictics == false)
        { 
            GraphicsObject.SetActive(false);
            PlayerPrefs.SetInt(keyGraphics, 0);
        }
        else
        {
            GraphicsObject.SetActive(true);
            PlayerPrefs.SetInt(keyGraphics, 1);
        }
    }
    public void ChangeGrphics()
    {
        graphicsStatictics = toggle.isOn;
    }
}
