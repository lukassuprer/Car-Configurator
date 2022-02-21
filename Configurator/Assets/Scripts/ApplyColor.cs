using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class ApplyColor : MonoBehaviour
{
    public Material material;
    public static Color myColour;

    public void ChooseColor(string color)
    {
        myColour = Color.clear; ColorUtility.TryParseHtmlString (color, out myColour);
        material.color = myColour;
    }
}
