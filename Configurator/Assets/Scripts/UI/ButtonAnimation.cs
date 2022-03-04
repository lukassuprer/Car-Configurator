using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonAnimation : MonoBehaviour
{
    public Animator menuAnimator;
    public Animator colorsAnimator;
    public Animator buttonAnimator;
    public Animator spoilerAnimator;
    
    public TextMeshProUGUI buttonText;
    public TextMeshProUGUI wheelText;
    public TextMeshProUGUI spoilerText;
    public TextMeshProUGUI soundText;

    public SpoilersManager spoilersManager;
    public WheelsManager wheelsManager;
    public ApplyColor applyColor;
    public ChangePosition changePosition;
    
    private bool isOpened;

    public void OnClick()
    {
        if (isOpened == false)
        {
            menuAnimator.SetBool("open", true);
            buttonAnimator.SetBool("open", true);
            buttonText.text = ">";
            spoilerText.text = "s";
            wheelText.text = "w";
            soundText.text = "e";
            isOpened = true;
        }
        else
        {
            colorsAnimator.SetBool("open", false);
            menuAnimator.SetBool("open", false);
            buttonAnimator.SetBool("open", false);
            changePosition.EnableCam();

            applyColor.isOpened = false;
            spoilersManager.Close();
            wheelsManager.Close();
            
            buttonText.text = "<";
            spoilerText.text = "";
            wheelText.text = "";
            soundText.text = "";
            isOpened = false;
        }
    }
}
