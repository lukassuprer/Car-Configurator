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
    public ChangePosition changePosition;
    public SaveManager saveManager;
    private List<Image> materialColors = new List<Image>();
    private Color materialColor;
    public string myStringColor;

    private void Awake()
    {
        myColour = material.color;
        myStringColor = ColorUtility.ToHtmlStringRGBA(material.color);
    }

    private void Start()
    {
        SummonUI();
    }

    public void ChooseColor(string color)
    {
        myColour = Color.clear;
        myStringColor = color;
        ColorUtility.TryParseHtmlString(color, out myColour);
        material.color = myColour;
        saveManager.SetColorName(color);
    }

    private void SummonUI()
    {
        foreach (var color in listColors)
        {
            GameObject button = Instantiate(colorButton, buttonHolder.position, buttonHolder.rotation, buttonHolder);
            color.colorValue.a = 0f;
            button.GetComponent<Image>().color = color.colorValue;
            button.name = color.name;
            Button objectButton = button.GetComponent<Button>();
            objectButton.onClick.AddListener(delegate { ChooseColor(color.name); });
            objectButton.onClick.AddListener(delegate { spoilersManager.SetColor(); });
            objectButton.onClick.AddListener(delegate { changePosition.EnableCam(); });
            button.GetComponent<Outline>().effectColor = color.colorValue;
            materialColors.Add(objectButton.image);
        }
    }

    public void OpenUI()
    {
        if (!isOpened)
        {
            animator.SetBool("open", true);
            isOpened = true;
            for (int i = 0; i < materialColors.Count; i++)
            {
                materialColor = materialColors[i].color;
                materialColor.a = 255f;
                materialColors[i].color = materialColor;
            }
            
        }else if (isOpened)
        {
            animator.SetBool("open", false);
            isOpened = false;
            waitClose();
        }
    }

    IEnumerator waitClose()
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < materialColors.Count; i++)
        {
            materialColor = materialColors[i].color;
            materialColor.a = 0;
            materialColors[i].color = materialColor;
        }
    }
}