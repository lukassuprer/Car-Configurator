using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class ApplyColor : MonoBehaviour
{
    [System.Serializable]
    public class CarColor
    {
        public string name;
        public Color colorValue;
    }

    public Material material;
    public static Color myColour;
    public List<CarColor> listColors = new List<CarColor>();
    public GameObject colorButton;
    public Transform buttonHolder;
    public SpoilersManager spoilersManager;
    public Animator animator;
    public bool isOpened;

    private void Awake()
    {
        myColour = material.color;
    }

    private void Start()
    {
        SummonUI();
    }

    public void ChooseColor(string color)
    {
        /*foreach (var colorVar in listColors)
        {
            colorVar.colorValue = myColour;
        }*/

        myColour = Color.clear;
        ColorUtility.TryParseHtmlString(color, out myColour);
        material.color = myColour;
    }

    private void SummonUI()
    {
        foreach (var color in listColors)
        {
            GameObject button = Instantiate(colorButton, buttonHolder.position, buttonHolder.rotation, buttonHolder);
            color.colorValue.a = 255f;
            button.GetComponent<Image>().color = color.colorValue;
            button.name = color.name;
            button.GetComponent<Button>().onClick.AddListener(delegate { ChooseColor(color.name); });
            button.GetComponent<Button>().onClick.AddListener(delegate { spoilersManager.SetColor(); });
            button.GetComponent<Outline>().effectColor = color.colorValue;
        }
    }

    public void OpenUI()
    {
        if (!isOpened)
        {
            animator.SetBool("open", true);
            isOpened = true;
        }else if (isOpened)
        {
            animator.SetBool("open", false);
            isOpened = false;
        }
    }
}