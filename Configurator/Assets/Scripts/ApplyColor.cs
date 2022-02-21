using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyColor : MonoBehaviour
{
    public FlexibleColorPicker colorPicker;
    public Material material;

    private void Update()
    {
        material.color = colorPicker.color;
    }
}
