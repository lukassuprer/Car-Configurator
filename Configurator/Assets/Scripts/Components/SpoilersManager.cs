using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SpoilersManager : MonoBehaviour
{
    [System.Serializable]
    public class Spoilers
    {
        public int index;
        public Sprite imageIcon;
        public GameObject[] spoilerObject;
        
    }
    
    public List<Spoilers> spoilerList = new List<Spoilers>();
    private List<GameObject> buttonsList = new List<GameObject>();
    private int currentSpoiler = 0;
    public GameObject spoilerButton;
    public Transform spoilerHolder;
    public Animator animator;
    public bool isOpened;
    private Texture2D icon;

    private void Start()
    {
        SetColor();
        SummonUI();
    }

    public void NextSpoiler(int index)
    {
        currentSpoiler = index;
        for (int i = 0; i < spoilerList.Count; i++)
        {
            for (int j = 0; j < spoilerList[i].spoilerObject.Length; j++)
            {
                spoilerList[i].spoilerObject[j].SetActive(false);
            }
        }
        for (int i = 0; i < spoilerList[currentSpoiler].spoilerObject.Length; i++)
        {
            spoilerList[currentSpoiler].spoilerObject[i].SetActive(true);
            spoilerList[currentSpoiler].spoilerObject[i].GetComponent<Renderer>().material.color = ApplyColor.myColour;
        }
    }

    public void SetColor()
    {
        for (int i = 0; i < spoilerList[currentSpoiler].spoilerObject.Length; i++)
        {
            spoilerList[currentSpoiler].spoilerObject[i].GetComponent<Renderer>().material.color = ApplyColor.myColour;
        }
    }

    private void SummonUI()
    {
        foreach (var spoiler in spoilerList)
        {
            GameObject button = Instantiate(spoilerButton, spoilerHolder.position, spoilerHolder.rotation, spoilerHolder);
            button.name = spoiler.index.ToString();
            button.GetComponent<Button>().onClick.AddListener(delegate { NextSpoiler(spoiler.index); });
            button.GetComponent<Button>().image.sprite = spoiler.imageIcon;
            buttonsList.Add(button);
        }
    }
    public void OpenUI()
    {
        if (!isOpened)
        {
            Open();
        }else if (isOpened)
        {
            Close();
        }
    }

    public void Open()
    {
        animator.SetBool("open", true);
        foreach (var button in buttonsList)
        {
            //button.GetComponent<Button>().GetComponentInChildren<TextMeshProUGUI>().text = button.name;
        }
        isOpened = true;
    }

    public void Close()
    {
        animator.SetBool("open", false);
        foreach (var button in buttonsList)
        {
            //button.GetComponent<Button>().GetComponentInChildren<TextMeshProUGUI>().text = "";
        }
        isOpened = false;
    }
}
